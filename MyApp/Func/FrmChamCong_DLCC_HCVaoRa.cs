using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML130.EasyEnum;
using XML130.EasyHelper;
using XML130.EasyUtils;
using XML130.InterfaceInheritance;
using XML130.Libraries;
using XML130.EasyData;
using DevExpress.Export;

namespace XML130.Func
{
    public partial class FrmChamCong_DLCC_HCVaoRa : FrmBase
    {
        private string _query;
        public FrmChamCong_DLCC_HCVaoRa()
        {
            InitializeComponent();

            EasyGridStyleHelper = new EasyGridStyleHelper(this, customGridControl, customGridView, false, true, false, false,
                false, false, true, true);
            barSearch.Visible = false;
        }

        protected override void OnInit()
        {
            barEditItemTime.EditValue = EasyValue.ValueTime;
            OnSearch();
        }

        protected override void OnSearch()
        {
            try
            {
                //CASE a.GioiTinh WHEN 1 THEN N'Nam' WHEN 2 THEN N'Nữ' ELSE N'Không xác định' END AS GioiTinh
                //_query = "SELECT DISTINCT  b.TenKhoaPhong,b.MaNv,a.UserEnrollNumber,b.TenNv,b.ChucVu,b.NgaySinh,a.TimeDate,CASE b.GioiTinh WHEN 1 THEN N'Nam' WHEN 2 THEN N'Nữ' ELSE N'Không xác định' END AS GioiTinh2, IIF (DATENAME(WEEKDAY,a.TimeDate)='Monday','T2',IIF (DATENAME(WEEKDAY,a.TimeDate)='Tuesday','T3',IIF (DATENAME(WEEKDAY,a.TimeDate)='Wednesday','T4',IIF(DATENAME(WEEKDAY, a.TimeDate) = 'Thursday', 'T5', IIF(DATENAME(WEEKDAY, a.TimeDate) = 'Friday', 'T6', IIF(DATENAME(WEEKDAY, a.TimeDate) = 'Saturday', 'T7', 'CN')))))) AS Thu, STUFF(( SELECT ',' + CONCAT (SUBSTRING(CONVERT(varchar(40),TimeStr),11,3),'h',SUBSTRING(CONVERT(varchar(40),TimeStr),15,2))  FROM CheckInOut b WHERE a.UserEnrollNumber = b.UserEnrollNumber and a.TimeDate=b.TimeDate  FOR XML PATH('')),1,1,'') LogChamCong FROM CheckInOut a , tblNhanVien b WHERE a.UserEnrollNumber=b.UserEnrollNumber AND";

                _query = @" with tbl_chamcong
                        as(
	                        select UserEnrollNumber,TimeDate,InTime,OutTime,IsWinner
		                        ,case DATENAME(dw,TimeDate) when 'Monday' then 'T2' when 'Tuesday' then 'T3' when 'Wednesday' then 'T4'
		                        when 'Thursday' then 'T5' when 'Friday' then 'T6' when 'Saturday' then 'T7' else 'CN' end as Thu
		                        ,case IsWinner when 0 then dateadd(hour,7,OffsetDateTime) else dateadd(minute,450,OffsetDateTime) end OffsetIn
		                        ,case IsWinner when 0 then dateadd(hour,17,OffsetDateTime) else dateadd(minute,990,OffsetDateTime) end OffsetOut
		                        ,STUFF(( select ', ' + concat(format(TimeStr,'HH'),'h',format(TimeStr,'mm')) 
				                         from [WiseEyeMix3].dbo.CheckInOut 
				                         where UserEnrollNumber=p.UserEnrollNumber and TimeDate=p.TimeDate
				                         FOR XML PATH (''))
				                         , 1, 1, '' ) as LogChamCong
	                        from(
		                        select UserEnrollNumber,TimeDate,convert(datetime,TimeDate) as OffsetDateTime,IsWinner
			                        -- Điều kiện giờ vào trong khoảng 0h-9h30 và giờ ra trong khoảng 15h-22h
			                        ,case when convert(int,format(min(TimeStr),'HHmm')) between 0 and 930 then min(TimeStr) else null end InTime
			                        ,case when convert(int,format(max(TimeStr),'HHmm')) between 1500 and 2200 then max(TimeStr) else null end OutTime
		                        from(
			                        select UserEnrollNumber,TimeDate,TimeStr
				                        ,case when convert(int,format(TimeDate,'MMdd')) between 416 and 1015 then 0 else 1 end IsWinner
			                        from [WiseEyeMix3].[dbo].[CheckInOut] 
			                        where 1=1
			                        and (convert(int,format(TimeStr,'HHmm')) between 0 and 930
			                        or convert(int,format(TimeStr,'HHmm')) between 1500 and 2200)
			                        --and TimeDate between '2024-01-14' and '2024-01-14'
		                        ) a 
		                        group by UserEnrollNumber,TimeDate,IsWinner
	                        ) p
                        )

                        select TenKhoaPhong,MaNv,UserEnrollNumber,TenNv,ChucVu,NgaySinh,GioiTinh2,Thu,TimeDate
                        -- sửa ở đây
	                        ,IIF(InTime is null,NULL,  CONCAT (SUBSTRING(CONVERT(varchar(40),InTime),11,3),'h',SUBSTRING(CONVERT(varchar(40),InTime),15,2))) as InTime
	                        ,IIF(OutTime is null,NULL,  CONCAT (SUBSTRING(CONVERT(varchar(40),OutTime),11,3),'h',SUBSTRING(CONVERT(varchar(40),OutTime),15,2))) as OutTime
                        -- hết sửa 643
                            ,TongGio,TongPhut
	                        ,case when DiTre < 0 then abs(DiTre) else null end DiMuon
							,case when VeSom < 0 then abs(VeSom) else null end VeSom
	                        ,LogChamCong
							-- hàm xử lý không chấm
	                        ,case when InTime is null then N'Thiếu giờ vào'
		                          when OutTime is null then N'Thiếu giờ ra'
		                          when DiTre < 0 and VeSom > 0  then concat(N'Đi muộn ',abs(DiTre),N' phút')
		                          when VeSom < 0 and DiTre > 0 then concat(N'Về sớm ',abs(VeSom),N' phút')
		                          when VeSom < 0 and DiTre < 0 then concat(N'Đi muộn ',abs(DiTre),N' phút') + concat(N' ;Về sớm ',abs(VeSom),N' phút')
		                          else null end TrangThai
							,case 	
								    when InTime is null or OutTime is null  then '1'	
		                          else null end KhongCham

 
                        from(
	                        select b.TenKhoaPhong,b.MaNv,b.UserEnrollNumber,b.TenNv,b.ChucVu,b.NgaySinh
		                        ,case b.GioiTinh when 1 then N'Nam' when 2 then N'Nữ' else N'Không xác định' end as GioiTinh2
		                        ,a.Thu,a.TimeDate,a.OffsetIn,a.InTime,a.OffsetOut,a.OutTime
		                        ,case when convert(int,format(TimeDate,'MMdd')) between 416 and 1015 then DATEDIFF(HOUR,a.InTime,a.OutTime)-2 else DATEDIFF(HOUR,a.InTime,a.OutTime)-1 end  TongGio
		                        ,case when convert(int,format(TimeDate,'MMdd')) between 416 and 1015 then DATEDIFF(MINUTE,a.InTime,a.OutTime)-120 else DATEDIFF(MINUTE,a.InTime,a.OutTime)-60  end TongPhut
		                        ,case when b.DBFlg=1 and TimeDate between b.DBStartTime and b.DBEndTime
			                          then datediff(minute,a.InTime,dateadd(minute,30,a.OffsetIn))
			                          else datediff(minute,a.InTime,a.OffsetIn) end DiTre
		                        ,case when b.DBFlg=1 and TimeDate between b.DBStartTime and b.DBEndTime
			                          then datediff(minute,dateadd(minute,30,a.OffsetOut),a.OutTime)
			                          when b.DBFlg=2 
			                          then datediff(minute,dateadd(hour,1,a.OffsetOut),a.OutTime)
			                          else datediff(minute,a.OffsetOut,a.OutTime) end VeSom
		                        ,a.LogChamCong
	                        from [dbo].[tblNhanVien] b
	                        join tbl_chamcong a
	                        on b.UserEnrollNumber=a.UserEnrollNumber
                        ) c where 1=1 and";

                if (barEditItemFrom.EditValue != null && barEditItemTo.EditValue != null)
                {
                    _query += " TimeDate BETWEEN '" +
                              Convert.ToDateTime(barEditItemFrom.EditValue).ToString("MM/dd/yyyy") + "' AND '" +
                              Convert.ToDateTime(barEditItemTo.EditValue).ToString("MM/dd/yyyy") + "' ";
                }
                //_query += "ORDER BY  B.Stt,a.TimeStr"; //a.UserEnrollNumber
                var dataTable = SQLHelper.ExecuteDataTable(_query);
                customGridControl.DataSource = dataTable;

                EasyCommon.BestFitColumnsGridView(customGridView);
                customGridView.CustomDrawCell += customGridView_CustomDrawCell;

            }
            catch (Exception exception)
            {
                EasyDialog.ShowErrorDialog("Phát sinh lỗi. (" + exception.Message + ")");
            }
        }
        private void customGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (customGridView.RowCount == 0) return;
            string _color = customGridView.GetRowCellValue(customGridView.FocusedRowHandle, "TrangThai") == null ? "" : customGridView.GetRowCellValue(customGridView.FocusedRowHandle, "TrangThai").ToString();
           
            if (_color.Length >0)
            {
                e.Appearance.BackColor = Color.Yellow;
            }
          
        }
        protected override void OnReload()
        {
            OnInit();
        }

        protected override void OnEdit()
        {
           
        }

        protected override void OnAdd()
        {
            
        }

        protected override void OnDelete()
        {
           
        }

        private void customGridControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EasyCommon.ExportToExcel(Text, customGridView, null, AutoSize, ExportType.WYSIWYG, true);
        }
    }
}