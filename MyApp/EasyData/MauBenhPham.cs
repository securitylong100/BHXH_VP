using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML130.EasyData
{
    public class MauBenhPham
    {
        public static DataTable MauBenh()
        {
            var table = new DataTable();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("name", typeof(string));

            //table.Rows.Add("MBP/0001", @"Mẫu máu");
            //table.Rows.Add("MBP/0002", @"Dịch mũi");
            //table.Rows.Add("MBP/0003", @"Dịch tỵ hầu");
            //table.Rows.Add("MBP/0004", @"Dịch hầu họng");
            //table.Rows.Add("MBP/0005", @"Dịch rửa mũi");
            //table.Rows.Add("MBP/0006", @"Dịch phế quản");
            //table.Rows.Add("MBP/0007", @"Dịch phế nang");
            //table.Rows.Add("MBP/0008", @"Dịch đờm");
            //table.Rows.Add("MBP/0009", @"Dịch não tủy");
            //table.Rows.Add("MBP/0010", @"Dịch nội khí quản");
            //table.Rows.Add("MBP/0011", @"Dịch phết trực tràng");
            //table.Rows.Add("MBP/0012", @"Mẫu phân");
            //table.Rows.Add("MBP/0013", @"Mẫu tinh dịch");
            //table.Rows.Add("MBP/0014", @"Mẫu nước tiểu");
            //table.Rows.Add("MBP/0015", @"Mẫu nước bọt");
            //table.Rows.Add("MBP/0016", @"Mẫu nốt phỏng");
            //table.Rows.Add("MBP/0017", @"Mảnh sinh thiết da");
            //return table;

            // tuấn cập nhật
            table.Rows.Add("MBP/001", @"10ml máu, ống chuyên dụng");
            table.Rows.Add("MBP/002", @"BS lấy BP");
            table.Rows.Add("MBP/003", @"Citrate");
            table.Rows.Add("MBP/004", @"Dịch");
            table.Rows.Add("MBP/005", @"Dịch CTC");
            table.Rows.Add("MBP/006", @"Dịch hầu họng");
            table.Rows.Add("MBP/007", @"Dịch ối");
            table.Rows.Add("MBP/008", @"Dịch, đờm");
            table.Rows.Add("MBP/009", @"EDTA");
            table.Rows.Add("MBP/010", @"EDTA toàn phần");
            table.Rows.Add("MBP/011", @"EDTA, Heparin");
            table.Rows.Add("MBP/012", @"EDTA, Heparin, Serum");
            table.Rows.Add("MBP/013", @"EDTA,heparin, serum");
            table.Rows.Add("MBP/014", @"Heparin");
            table.Rows.Add("MBP/015", @"Heparin Vaccum");
            table.Rows.Add("MBP/016", @"Heparin, Serum");
            table.Rows.Add("MBP/017", @"Máu mẹ-mẫu của bố");
            table.Rows.Add("MBP/018", @"Mẫu phân");
            table.Rows.Add("MBP/019", @"Máu, dịch");
            table.Rows.Add("MBP/020", @"Máu, nước tiểu");
            table.Rows.Add("MBP/021", @"Máu, tóc, da …");
            table.Rows.Add("MBP/022", @"Nước tiểu");
            table.Rows.Add("MBP/023", @"Serum");
            table.Rows.Add("MBP/024", @"Serum, EDTA");
            table.Rows.Add("MBP/025", @"Serum, Heparin");
            table.Rows.Add("MBP/026", @"Serum, nước tiểu");
            table.Rows.Add("MBP/027", @"Tinh dịch");
            return table;
        }
    }


}
