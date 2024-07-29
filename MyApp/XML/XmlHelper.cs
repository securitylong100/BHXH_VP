﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using XML130.EasyUtils;
using XML130.Libraries;

namespace XML130.XML
{
    public class XmlHelper
    {
        public static Dictionary<string, string> XmlTypes { get; }
            = new Dictionary<string, string>()
            {
                { "XML_GIAMDINHHS", "Giám định hồ sơ" },
                { "XML1", "XML 1" },
                { "XML2", "XML 2" },
                { "XML3", "XML 3" },
                { "XML4", "XML 4" },
                { "XML5", "XML 5" },
                { "XML6", "XML 6" },
                { "XML7", "XML 7" },
                { "XML8", "XML 8" },
                { "XML9", "XML 9" },
                { "XML10", "XML 10" },
                { "XML11", "XML 11" },
            };

        /// <summary>
        /// Đọc file XML giám định hồ sơ vào Dataset với các table tương ứng XML 1, XML 2,...
        /// </summary>
        /// <param name="xmlFile">Đường dẫn file</param>
        /// <returns></returns>
        public static DataSet LoadXmlFile(string xmlFile)
        {
            if (!File.Exists(xmlFile)) return null;
            DataSet dsXmlOpenned = new DataSet();
            DataSet dsXmlFile = new DataSet();
            dsXmlFile.ReadXml(xmlFile);
            #region LẤY THÔNG TIN HỒ SƠ
            DataTable dtGiamDinhHoSo = new DataTable("XML_GIAMDINHHS");
            dtGiamDinhHoSo.Columns.Add("ID");
            dtGiamDinhHoSo.Columns.Add("KEY");
            dtGiamDinhHoSo.Columns.Add("MA_LK");
            dtGiamDinhHoSo.Columns.Add("MACSKCB");
            dtGiamDinhHoSo.Columns.Add("NGAYLAP");
            dtGiamDinhHoSo.Columns.Add("SOLUONGHOSO");
            DataRow drGiamDinhHoSo = dtGiamDinhHoSo.NewRow();
            if (dsXmlFile.Tables.Contains("THONGTINDONVI"))
            {
                drGiamDinhHoSo["MACSKCB"] = dsXmlFile.Tables["THONGTINDONVI"].Rows[0]["MACSKCB"].ToString();
            }
            if (dsXmlFile.Tables.Contains("THONGTINHOSO"))
            {
                drGiamDinhHoSo["NGAYLAP"] = dsXmlFile.Tables["THONGTINHOSO"].Rows[0]["NGAYLAP"].ToString();
                drGiamDinhHoSo["SOLUONGHOSO"] = dsXmlFile.Tables["THONGTINHOSO"].Rows[0]["SOLUONGHOSO"].ToString();
            }
            dtGiamDinhHoSo.Rows.Add(drGiamDinhHoSo);
            dsXmlOpenned.Tables.Add(dtGiamDinhHoSo);
            #endregion
            #region ĐỌC FILE HỒ SƠ
            if (dsXmlFile.Tables.Contains("FILEHOSO") && dsXmlFile.Tables["FILEHOSO"].Rows.Count > 0)
            {
                foreach (DataRow drFileHoSo in dsXmlFile.Tables["FILEHOSO"].Rows)
                {
                    string xmlType = drFileHoSo["LOAIHOSO"].ToString();
                    string xmlContent = drFileHoSo["NOIDUNGFILE"].ToString();

                    using (Stream stream = EasyEncoding.GenerateStreamFromString(EasyEncoding.Base64Decode(xmlContent)))
                    {
                        DataSet dsXmlType = new DataSet();
                        dsXmlType.ReadXml(stream);
                        if (dsXmlType.Tables.Count > 0)
                        {
                            foreach (DataTable dtXmlType in dsXmlType.Tables)
                            {
                                if (dtXmlType.Columns.Contains("MA_LK") && dtXmlType.Rows.Count > 0)
                                {
                                    if (dtGiamDinhHoSo.Rows[0].IsNull("MA_LK")
                                        && !dtXmlType.Rows[0].IsNull("MA_LK"))
                                    {
                                        dtGiamDinhHoSo.Rows[0]["MA_LK"] = dtXmlType.Rows[0]["MA_LK"];
                                    }
                                    DataTable dt = dtXmlType.DefaultView.ToTable(xmlType);
                                    if (!dt.Columns.Contains("MA_LOI")) dt.Columns.Add("MA_LOI");
                                    if (!dt.Columns.Contains("THONGTIN_LOI")) dt.Columns.Add("THONGTIN_LOI");
                                    dsXmlOpenned.Tables.Add(dt);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            return dsXmlOpenned;
        }

        public static DataSet LoadXmlDataFromDb(string maLK)
        {
            DataSet ds = new DataSet();
            foreach (string xmlType in XmlTypes.Keys)
            {
                DataTable dt = LoadXmlDataFromDb(xmlType, maLK);
                ds.Tables.Add(dt);
            }
            return ds;
        }

        public static DataTable LoadXmlDataFromDb(string xmlType, string maLK)
        {
            string sql = string.Format("IF OBJECT_ID('{0}', 'U') IS NOT NULL SELECT * FROM {0} WHERE ISNULL('{1}','')='' OR MA_LK='{1}';", xmlType, maLK);
            DataTable dt = SQLHelper.ExecuteDataTable(sql);
            dt.TableName = xmlType;
            return dt;
        }

        public static Dictionary<string, List<ClsXmlError>> ValidateXml(ref DataSet dsXmlFile)
        {
            Dictionary<string, List<ClsXmlError>> dictErrors = new Dictionary<string, List<ClsXmlError>>();
            /// Tải master mã lỗi cha/ mã lỗi con từ databas
            DataTable dtErrors = SQLHelper.ExecuteDataTable("SELECT * FROM XMLERROR");
            if (dtErrors != null && dtErrors.Rows.Count > 0)
            {
                /// Duyệt các file XML
                foreach (DataTable dtXml in dsXmlFile.Tables)
                {
                    if (!dictErrors.ContainsKey(dtXml.TableName))
                    {
                        dictErrors.Add(dtXml.TableName, new List<ClsXmlError>());
                    }
                    /// Duyệt từng dòng dữ liệu của XML
                    foreach (DataRow dr in dtXml.Rows)
                    {
                        List<ClsXmlError> lstRowErrors = new List<ClsXmlError>();
                        /// Duyệt từng mã lỗi
                        foreach (DataRow drError in dtErrors.Rows)
                        {
                            ClsXmlError error = new ClsXmlError()
                            {
                                /// Tên trường cần kiểm tra
                                Item = drError["ITEM"].ToString(),
                                /// Tên file XML
                                XmlType = drError["XML"].ToString(),
                                /// Mã lỗi cha
                                MaLoiCha = drError["MA_LOI_CHA"].ToString(),
                                /// Mã lỗi con
                                MaLoiCon = drError["MA_LOI_CON"].ToString(),
                                /// Chi tiết lỗi
                                NoiDungLoi = drError["NOI_DUNG_LOI"].ToString(),
                            };
                            /// Chỉ xử lý các lỗi tương ứng với file XML đang duyệt
                            if (error.XmlType == dtXml.TableName)
                            {
                                /// Lấy giá trị trường cần kiểm tra của dòng dữ liệu hiện tại
                                string value = dr[error.Item].ToString();
                                /// Mặc định thì nếu trường cần kiểm tra không có dữ liệu sẽ thêm lỗi vào danh sách
                                if (string.IsNullOrWhiteSpace(value))
                                {
                                    lstRowErrors.Add(error);
                                }
                                /// Thực hiện xử lý lỗi cho từng trường hợp dựa trên mã lỗi con
                                switch (error.MaLoiCon)
                                {
                                    #region XML1
                                    /// GIOI_TINH không tồn tại ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp GIOI_TINH trống thì cả 2 lỗi 105001 và 105002 được thêm vào danh sách
                                    case "105002":
                                        {
                                            /// Trường hợp cột GIOI_TINH có dữ liệu nhưng nằm ngoài các trường hợp 1,2,3 thì thêm lỗi vào danh sách
                                            if (!int.TryParse(value, out int kq) || kq < 1 || kq > 3) lstRowErrors.Add(error);
                                            break;
                                        }
                                    /// MA_QUOCTICH không tồn tại trong danh mục ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp MA_QUOCTICH trống thì cả 2 lỗi 108001 và 108002 được thêm vào danh sách
                                    case "108002":
                                        {
                                            /// Lấy TEN_QUOCTICH dựa trên MA_QUOC_TICH
                                            /// Nếu TEN_QUOCTICH không tồn tại thì thêm lỗi vào danh sách
                                            string sql = string.Format("SELECT [TEN_QUOCTICH] FROM tblDmQD130_QuocTich WHERE [MA_QUOCTICH]='{0}' ", value);
                                            string quocTich = SQLHelper.ExecuteScalar<string>(sql);
                                            if (string.IsNullOrWhiteSpace(quocTich)) lstRowErrors.Add(error);
                                            break;
                                        }
                                    /// MA_NGHE_NGHIEP không tồn tại trong danh mục ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp MA_NGHE_NGHIEP trống thì cả 2 lỗi 110001 và 110002 được thêm vào danh sách
                                    case "110002":
                                        {
                                            /// Nếu MA_NGHE_NGHIEP = 00000 thì không kiểm tra
                                            /// Các trường hợp khác thì lấy TEN_NGHE_NGHIEP dựa trên MA_NGHE_NGHIEP
                                            /// Nếu TEN_NGHE_NGHIEP không tồn tại thì thêm lỗi vào danh sách
                                            if (value != "00000")
                                            {
                                                StringBuilder sb = new StringBuilder();
                                                sb.AppendLine("SELECT TEN_NGHE_NGHIEP FROM tblDmQD130_NgheNghiep ");
                                                sb.AppendFormat("WHERE [MA_NGHE_NGHIEP]='{0}' ", value);
                                                sb.AppendFormat("OR [MA_NGHE_NGHIEP_C1]='{0}' ", value);
                                                sb.AppendFormat("OR [MA_NGHE_NGHIEP_C2]='{0}' ", value);
                                                sb.AppendFormat("OR [MA_NGHE_NGHIEP_C3]='{0}' ", value);
                                                sb.AppendFormat("OR [MA_NGHE_NGHIEP_C4]='{0}' ", value);
                                                sb.AppendFormat("OR [MA_NGHE_NGHIEP_C5]='{0}' ", value);
                                                string ngheNghiep = SQLHelper.ExecuteScalar<string>(sb.ToString());
                                                if (string.IsNullOrWhiteSpace(ngheNghiep)) lstRowErrors.Add(error);
                                            }
                                            break;
                                        }
                                    /// KET_QUA_DTRI không tồn tại ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp KET_QUA_DTRI trống thì cả 2 lỗi 140001 và 140002 được thêm vào danh sách
                                    case "140002":
                                        {
                                            /// Nếu KET_QUA_DTRI không nằm trong 1~7 thì thêm lỗi vào danh sách
                                            if (!int.TryParse(value, out int kq) || kq < 1 || kq > 7) lstRowErrors.Add(error);
                                            break;
                                        }
                                    /// MA_LOAI_RV không tồn tại ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp MA_LOAI_RV trống 141001 và 141002 được thêm vào danh sách
                                    case "141002":
                                        {
                                            /// Nếu MA_LOAI_RV không nằm trong 1~5 thì thêm lỗi vào danh sách
                                            if (!int.TryParse(value, out int kq) || kq < 1 || kq > 5) lstRowErrors.Add(error);
                                            break;
                                        }
                                    /// CAN_NANG phải là dạng số ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp CAN_NANG trống 159001 và 159002 được thêm vào danh sách
                                    case "159002":
                                        {
                                            if (!double.TryParse(value, out double kq)) lstRowErrors.Add(error);
                                            break;
                                        }
                                    #endregion
                                    #region XML2
                                    /// MA_NHOM không tồn tại trong danh mục (lỗi này đã bị xóa trong database)
                                    /// Trường hợp MA_NHOM trống 206001 được thêm vào danh sách
                                    case "206002":
                                        {
                                            break;
                                        }
                                    /// PHAM_VI không tồn tại trong danh mục ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp PHAM_VI trống 216001 và 216002 được thêm vào danh sách
                                    case "216002":
                                        {
                                            if (!int.TryParse(value, out int kq) || kq < 1 || kq > 3) lstRowErrors.Add(error);
                                            break;
                                        }
                                    /// TYLE_TT_BH đang khác 0 với các hồ sơ ngoài phạm vi thanh toán BHYT
                                    /// Trường hợp TYLE_TT_BH trống 217001 và 217002 được thêm vào danh sách
                                    case "217002":
                                        {
                                            string phamVi = dr["PHAM_VI"].ToString();
                                            if (!int.TryParse(value, out int kq)
                                                || ((phamVi == "2" || phamVi == "3") && kq != 0))
                                            {
                                                lstRowErrors.Add(error);
                                            }
                                            break;
                                        }
                                    /// MA_KHOA không tồn tại (lỗi này đã bị xóa trong database)
                                    /// Trường hợp MA_KHOA trống 231001 và 231002 được thêm vào danh sách
                                    case "231002":
                                        {
                                            string sql = string.Format("SELECT [TEN] FROM tblDmCSKCB_KhoaPhong WHERE [MA]='{0}' ", value);
                                            string tenKhoa = SQLHelper.ExecuteScalar<string>(sql);
                                            if (string.IsNullOrWhiteSpace(tenKhoa)) lstRowErrors.Add(error);
                                            break;
                                        }
                                    /// MA_BAC_SI không tồn tại trong danh mục ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp MA_BAC_SI trống 232001 và 232002 được thêm vào danh sách
                                    case "232002":
                                        {
                                            string maBacsi = string.Join("','", value.Split(';'));
                                            string sql = string.Format("SELECT HO_TEN FROM tblDmCSKCB_NhanVienYTe WHERE MACCHN in ('{0}') ", maBacsi);
                                            string tenBacsi = SQLHelper.ExecuteScalar<string>(sql);
                                            if (string.IsNullOrWhiteSpace(tenBacsi)) lstRowErrors.Add(error);
                                            break;
                                        }
                                    /// NGAY_YL không được nhỏ hơn ngày vào viện ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp NGAY_YL trống 234001, 234002 và 234003 được thêm vào danh sách
                                    case "234002":
                                        {
                                            /// Lấy dữ liệu NGAY_VAO từ XML1 và so sánh với NGAY_YL
                                            if (dsXmlFile.Tables.Contains("XML1"))
                                            {
                                                foreach (DataRow drXml1 in dsXmlFile.Tables["XML1"].Rows)
                                                {
                                                    if (long.TryParse(drXml1["NGAY_VAO"].ToString(), out long ngayVao)
                                                        && long.TryParse(value, out long ngayYL)
                                                        && ngayYL < ngayVao)
                                                    {
                                                        lstRowErrors.Add(error);
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    /// NGAY_YL không được lớn hơn ngày ra viện ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp NGAY_YL trống 234001, 234002 và 234003 được thêm vào danh sách
                                    case "234003":
                                        {
                                            /// Lấy dữ liệu NGAY_VAO từ XML1 và so sánh với NGAY_YL
                                            if (dsXmlFile.Tables.Contains("XML1"))
                                            {
                                                foreach (DataRow drXml1 in dsXmlFile.Tables["XML1"].Rows)
                                                {
                                                    if (long.TryParse(drXml1["NGAY_RA"].ToString(), out long ngayRa)
                                                        && long.TryParse(value, out long ngayYL)
                                                        && ngayYL > ngayRa)
                                                    {
                                                        lstRowErrors.Add(error);
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    /// MA_PTTT không được để trống
                                    case "235001":
                                        {
                                            if (!int.TryParse(value, out int kq) || kq < 1 || kq > 3) lstRowErrors.Add(error);
                                            break;
                                        }
                                    /// NGUON_CTRA không tồn tại trong danh mục ( mặc định lỗi này không được thêm vào danh sách )
                                    /// Trường hợp NGUON_CTRA trống 236001 và 236002 được thêm vào danh sách
                                    case "236002":
                                        {
                                            if (!int.TryParse(value, out int kq) || kq < 1 || kq > 4) lstRowErrors.Add(error);
                                            break;
                                        }
                                    #endregion
                                    #region XML3
                                    /// MA_VAT_TU không được để trống
                                    case "305001":
                                    /// TEN_VAT_TU không được để trống
                                    case "308001":
                                        {
                                            /// Trường hợp MA_VAT_TU và TEN_VAT_TU trống nhưng MA_NHOM != 10 thì bỏ qua lỗi này
                                            if (int.TryParse(dr["MA_NHOM"].ToString(), out int maNhom) && 10 != maNhom)
                                            {
                                                lstRowErrors.Remove(error);
                                            }
                                            break;
                                        }
                                    /// MA_DICH_VU không được để trống
                                    case "303001":
                                    /// TEN_DICH_VU không được để trống
                                    case "309001":
                                        {
                                            /// Trường hợp MA_DICH_VU và TEN_DICH_VU trống nhưng MA_NHOM == 10 thì bỏ qua lỗi này
                                            if (int.TryParse(dr["MA_NHOM"].ToString(), out int maNhom) && 10 == maNhom)
                                            {
                                                lstRowErrors.Remove(error);
                                            }
                                            break;
                                        }
                                    /// TT_THAU không được để trống
                                    case "316001":
                                    /// TT_THAU sai định dạng khi mã nhóm bằng 10 hoặc 11
                                    case "316002":
                                        {
                                            /// Trường hợp TT_THAU trống 316001 và 316002 được thêm vào danh sách
                                            /// Trường hợp TT_THAU trống nhưng MA_NHOM != 10 thì bỏ qua lỗi này
                                            if (int.TryParse(dr["MA_NHOM"].ToString(), out int maNhom) && 10 != maNhom)
                                            {
                                                lstRowErrors.Remove(error);
                                            }
                                            break;
                                        }
                                    /// NGUOI_THUC_HIEN không được để trống khi mã nhóm bằng 1 2 3 8 18
                                    case "334001":
                                        {
                                            /// Mảng chứa các MA_NHOM bắt buộc NGUOI_THUC_HIEN không được để trống
                                            int[] nhomKhongDuocDeTrong = new int[] { 0, 1, 2, 3, 8, 18 };
                                            /// Nếu MA_NHOM không nằm trong các nhóm bắt buộc thì bỏ qua lỗi này (trừ trường hợp trống)
                                            if (int.TryParse(dr["MA_NHOM"].ToString(), out int maNhom)
                                                && !nhomKhongDuocDeTrong.Contains(maNhom))
                                            {
                                                lstRowErrors.Remove(error);
                                            }
                                            break;
                                        }
                                    /// NGAY_TH_YL không được để trống khi mã nhóm bằng 1 2 3 8 18
                                    case "337001":
                                    /// NGAY_TH_YL không được nhỏ hơn ngày y lệnh
                                    case "337002":
                                        {
                                            /// Trường hợp NGAY_TH_YL trống 337001 và 337002 được thêm vào danh sách
                                            /// Mảng chứa các MA_NHOM bắt buộc NGAY_TH_YL không được để trống
                                            int[] nhomKhongDuocDeTrong = new int[] { 0, 1, 2, 3, 8, 18 };
                                            if (int.TryParse(dr["MA_NHOM"].ToString(), out int maNhom))
                                            {
                                                /// Nếu NGAY_TH_YL trống và MA_NHOM không nằm trong các nhóm bắt buộc thì bỏ qua
                                                if (string.IsNullOrWhiteSpace(value))
                                                {
                                                    if (!nhomKhongDuocDeTrong.Contains(maNhom))
                                                    {
                                                        lstRowErrors.Remove(error);
                                                    }
                                                }
                                                /// Trường hợp NGAY_TH_YL nhỏ hơn NGAY_YL thì thêm lỗi vào danh sách
                                                else if (long.TryParse(value, out long ngayTHYL)
                                                    && long.TryParse(dr["NGAY_YL"].ToString(), out long ngayYL)
                                                    && ngayTHYL < ngayYL)
                                                {
                                                    lstRowErrors.Add(error);
                                                }
                                            }

                                            break;
                                        }
                                    /// MA_GIUONG không đúng định dạng
                                    case "332001":
                                        {
                                            /// Trường hợp MA_NHOM != 15 thì bỏ qua lỗi này
                                            if (int.TryParse(dr["MA_NHOM"].ToString(), out int maNhom) && 15 != maNhom)
                                            {
                                                lstRowErrors.Remove(error);
                                            }
                                            break;
                                        }
                                    /// MA_MAY không đúng định dang
                                    case "342001":
                                        {
                                            /// Mảng chứa các MA_NHOM cho phép MA_MAY được để trống
                                            int[] nhomDuocDeTrong = new int[] { 7, 10, 11, 13 };
                                            /// Nếu MA_NHOM không nằm trong các nhóm này thì bỏ qua lỗi này
                                            if (int.TryParse(dr["MA_NHOM"].ToString(), out int maNhom)
                                                && nhomDuocDeTrong.Contains(maNhom))
                                            {
                                                lstRowErrors.Remove(error);
                                            }
                                            break;
                                        }
                                    /// TAI_SU_DUNG không tồn tại trong danh mục
                                    case "343001":
                                        {
                                            /// Trường hợp MA_NHOM != 11 thì bỏ qua lỗi này
                                            if (int.TryParse(dr["MA_NHOM"].ToString(), out int maNhom) && 11 != maNhom)
                                            {
                                                lstRowErrors.Remove(error);
                                            }
                                            break;
                                        }
                                    #endregion
                                    default:
                                        break;
                                }
                            }
                        }
                        if (lstRowErrors.Count > 0)
                        {
                            if (dtXml.Columns.Contains("MA_LOI"))
                                dr["MA_LOI"] = string.Join(";", lstRowErrors.Select(x => x.MaLoiCon));
                            if (dtXml.Columns.Contains("THONGTIN_LOI"))
                                dr["THONGTIN_LOI"] = string.Join(";", lstRowErrors.Select(x => x.NoiDungLoi));
                            dictErrors[dtXml.TableName].AddRange(lstRowErrors);
                        }
                        else
                        {
                            if (dtXml.Columns.Contains("MA_LOI"))
                                dr["MA_LOI"] = string.Empty;
                            if (dtXml.Columns.Contains("THONGTIN_LOI"))
                                dr["THONGTIN_LOI"] = string.Empty;
                        }
                    }
                }
            }
            return dictErrors;
        }

        /// <summary>
        /// Cập nhật dữ liệu bảng tương ứng file XML trong DB
        /// </summary>
        /// <param name="dtXmlType">Dữ liệu đầu vào với TableName là XmlType</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static bool UpdateXmlType2Db(string xmlTypeName, DataTable dtXmlType, Action<string, bool> callback = null)
        {
            DataTable dtInfo = SQLHelper.GetTableInfo(xmlTypeName);
            if (dtInfo != null && dtInfo.Rows.Count > 0)
            {
                if (dtXmlType.Rows.Count > 0)
                {
                    StringBuilder sbCallback = new StringBuilder();
                    sbCallback.AppendFormat("Cập nhật dữ liệu {0}\n", xmlTypeName);
                    using (SqlConnection conn = new SqlConnection(SQLHelper.Connectionstring))
                    {
                        conn.Open();
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            foreach (DataRow dr in dtXmlType.Rows)
                            {
                                #region XÂY DỰNG QUERY UPDATE
                                string stt = string.Empty;
                                string maLK = dr["MA_LK"].ToString();
                                StringBuilder sbWhere = new StringBuilder();
                                StringBuilder sbUpdate = new StringBuilder();
                                sbUpdate.AppendFormat("UPDATE [{0}] SET [MA_LK]='{1}' ", xmlTypeName, maLK);
                                sbWhere.AppendFormat("WHERE [MA_LK]='{0}' ", maLK);
                                if (dtXmlType.Columns.Contains("STT"))
                                {
                                    stt = dr["STT"].ToString();
                                    sbWhere.AppendFormat("AND [STT]='{0}' ", stt);
                                }
                                sbWhere.Append("AND ( 1=2 ");
                                // Thông điệp trả về
                                sbCallback.AppendFormat("Lượt khám: {1}\n", xmlTypeName, maLK);
                                if (!string.IsNullOrWhiteSpace("STT")) sbCallback.AppendFormat("Số thứ tự: {0}\n", stt);
                                // -----------------
                                #region KIỂM TRA TÍNH HỢP LỆ CỦA DỮ LIỆU
                                foreach (DataRow drInfo in dtInfo.Rows)
                                {
                                    string colName = drInfo["ColumnName"].ToString();
                                    if (colName != "MA_LK" && colName != "STT" && dtXmlType.Columns.Contains(colName))
                                    {
                                        string value = dr[colName].ToString().Replace("'", "''");
                                        bool isNullable = drInfo["AllowDBNull"].ToString().ToUpper() == "TRUE";
                                        if (!string.IsNullOrWhiteSpace(value))
                                        {
                                            sbWhere.AppendFormat("OR [{0}] IS NULL ", colName);
                                            SqlDbType sqlType = (SqlDbType)(int)drInfo["ProviderType"];
                                            switch (sqlType)
                                            {
                                                case SqlDbType.DateTime:
                                                case SqlDbType.DateTime2:
                                                case SqlDbType.SmallDateTime:
                                                case SqlDbType.DateTimeOffset:
                                                    {
                                                        if (DateTime.TryParse(value, out DateTime dtValue))
                                                        {
                                                            value = EasyDateTimeClass.ConvertDateTime(dtValue,
                                                                CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern);
                                                        }
                                                        sbUpdate.AppendFormat(",[{0}]=CONVERT(DATETIME,'{1}') ", colName, value);
                                                        sbWhere.AppendFormat("OR [{0}]!=CONVERT(DATETIME,'{1}' ", colName, value);
                                                        break;
                                                    }
                                                case SqlDbType.Date:
                                                    {
                                                        if (DateTime.TryParse(value, out DateTime dtValue))
                                                        {
                                                            value = dtValue.ToString("yyyyMMdd");
                                                        }
                                                        sbUpdate.AppendFormat(",[{0}]=CONVERT(DATE,'{1}') ", colName, value);
                                                        sbWhere.AppendFormat("OR FORMAT([{0}],'yyyyMMdd')!='{1}' ", colName, value);
                                                        break;
                                                    }
                                                case SqlDbType.NVarChar:
                                                    sbUpdate.AppendFormat(",[{0}]=N'{1}' ", colName, value);
                                                    sbWhere.AppendFormat("OR [{0}]!=N'{1}' ", colName, value);
                                                    break;
                                                default:
                                                    sbUpdate.AppendFormat(",[{0}]='{1}' ", colName, value);
                                                    sbWhere.AppendFormat("OR [{0}]!='{1}' ", colName, value);
                                                    break;
                                            }
                                        }
                                        else if (isNullable)
                                        {
                                            sbUpdate.AppendFormat(",[{0}]=NULL ", colName);
                                            sbWhere.AppendFormat("OR [{0}] IS NOT NULL ", colName);
                                        }
                                        else
                                        {
                                            sbCallback.AppendFormat("Cột {0} không được để trống!\n", colName);
                                            callback?.Invoke(sbCallback.ToString(), false);
                                            return false;
                                        }
                                    }
                                }
                                #endregion
                                sbWhere.AppendLine(");");
                                sbUpdate.Append(sbWhere);
                                #endregion
                                #region THỰC THI QUERY UPDATE
                                using (SqlCommand command = new SqlCommand(sbUpdate.ToString(), conn, trans))
                                {
                                    try
                                    {
                                        /// Cập nhật các thay đổi vào CSDL
                                        command.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        trans.Rollback();
                                        sbCallback.AppendFormat("Lỗi: {0}", ex.Message);
                                        callback?.Invoke(sbCallback.ToString(), false);
                                        return false;
                                    }
                                }
                                #endregion
                            }
                            trans.Commit();
                            sbCallback.AppendFormat("Cập nhật dữ liệu {0} hoàn tất\n", xmlTypeName);
                            callback?.Invoke(sbCallback.ToString(), true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Ghi dữ liệu từ file XML vào bảng tương ứng trong DB
        /// </summary>
        /// <param name="dtXmlType">Dữ liệu đầu vào với TableName là XmlType</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static bool ImportXmlType2Db(string xmlTypeName, DataTable dtXmlType, Action<string, bool> callback = null)
        {
            bool isOk = true;
            StringBuilder sbCallback = new StringBuilder();
            sbCallback.AppendFormat("Thêm mới dữ liệu {0}\n", xmlTypeName);
            try
            {
                DataTable dtInfo = SQLHelper.GetTableInfo(xmlTypeName);
                if (dtInfo != null && dtInfo.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtXmlType.Rows)
                    {
                        string maLK = dr["MA_LK"].ToString();
                        string stt = dtXmlType.Columns.Contains("STT") ? dr["STT"].ToString() : string.Empty;
                        sbCallback.AppendFormat("Lượt khám: {0}\n", maLK);
                        if (!string.IsNullOrWhiteSpace(stt))
                        {
                            sbCallback.AppendFormat("Số thứ tự: {0}\n", stt);
                        }
                        #region XÂY DỰNG QUERY INSERT
                        StringBuilder sbValues = new StringBuilder();
                        StringBuilder sbColumns = new StringBuilder();
                        sbColumns.Append("MA_LK");
                        sbValues.AppendFormat("'{0}'", maLK);
                        foreach (DataRow drInfo in dtInfo.Rows)
                        {
                            string colName = drInfo["ColumnName"].ToString();
                            if (colName != "MA_LK" && dtXmlType.Columns.Contains(colName))
                            {
                                string value = dr[colName].ToString().Replace("'", "''");
                                bool isNullable = drInfo["AllowDBNull"].ToString().ToUpper() == "TRUE";
                                if (!string.IsNullOrWhiteSpace(value))
                                {
                                    sbColumns.AppendFormat(",{0}", colName);
                                    SqlDbType sqlType = (SqlDbType)(int)drInfo["ProviderType"];
                                    switch (sqlType)
                                    {
                                        case SqlDbType.DateTime:
                                        case SqlDbType.DateTime2:
                                        case SqlDbType.SmallDateTime:
                                        case SqlDbType.DateTimeOffset:
                                            {
                                                if (DateTime.TryParse(value, out DateTime dtValue))
                                                {
                                                    value = EasyDateTimeClass.ConvertDateTime(dtValue,
                                                        CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern);
                                                }
                                                sbValues.AppendFormat(",CONVERT(DATETIME,'{0}')", value);
                                                break;
                                            }
                                        case SqlDbType.Date:
                                            {
                                                if (DateTime.TryParse(value, out DateTime dtValue))
                                                {
                                                    value = dtValue.ToString("yyyyMMdd");
                                                }
                                                sbValues.AppendFormat(",CONVERT(DATE,'{0}')", value);
                                                break;
                                            }
                                        case SqlDbType.NVarChar:
                                            sbValues.AppendFormat(",N'{0}'", value);
                                            break;
                                        default:
                                            sbValues.AppendFormat(",'{0}'", value);
                                            break;
                                    }
                                }
                                else if (!isNullable)
                                {
                                    isOk = false;
                                    sbCallback.AppendFormat("Cột {0} không được để trống!", colName);
                                }
                            }
                        }
                        #endregion
                        #region THỰC THI QUERY INSERT
                        if (isOk)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendFormat("INSERT INTO {0} ({1}) SELECT {2} ", xmlTypeName, sbColumns, sbValues);
                            sb.AppendFormat("WHERE NOT EXISTS ( SELECT 1 FROM {0} WHERE MA_LK='{1}' ", xmlTypeName, maLK);
                            if (!string.IsNullOrWhiteSpace(stt))
                            {
                                sb.AppendFormat("AND STT='{0}' ", stt);
                            }
                            sb.Append(");");
                            int result = SQLHelper.ExecuteNonQuery(sb.ToString());
                            if (result < 1)
                            {
                                isOk = false;
                                sbCallback.AppendLine("Thêm dữ liệu vào CSDL thất bại!");
                                callback?.Invoke(sbCallback.ToString(), false);
                            }
                        }
                        #endregion
                    }
                    sbCallback.AppendLine("Thêm dữ liệu vào CSDL hoàn tất!");
                    callback?.Invoke(sbCallback.ToString(), true);
                }
            }
            catch (Exception ex)
            {
                sbCallback.AppendFormat("Phát sinh lỗi: {0}\n{1}", xmlTypeName, ex.InnerException?.Message ?? ex.Message);
                callback?.Invoke(sbCallback.ToString(), false);
            }
            return isOk;
        }

        /// <summary>
        /// Ghi dữ liệu XML 1, XML 2,... ra file xml và trả về chuỗi base64
        /// </summary>
        /// <param name="dtXmlType">Dữ liệu đầu vào với TableName là XmlType</param>
        /// <param name="xmlTypePath">Đường dẫn file xml được xuất</param>
        /// <param name="writerSettings">Cấu hình XmlWriter</param>
        /// <returns>File XML được mã hóa base64</returns>
        public static string WriteXmlType2Xml(string xmlTypeName, DataTable dtXmlType, string maLK, string xmlTypePath = null, XmlWriterSettings writerSettings = null)
        {
            StringBuilder sbFileHoSoXml = new StringBuilder();
            using (XmlWriter writerXml = XmlWriter.Create(sbFileHoSoXml, writerSettings))
            {
                writerXml.WriteStartDocument();
                switch (xmlTypeName)
                {
                    case "XML1":
                        {
                            WriteXmlRow(writerXml, dtXmlType, "TONG_HOP", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("TONG_HOP");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            break;
                        }
                    case "XML2":
                        {
                            writerXml.WriteStartElement("CHITIEU_CHITIET_THUOC");
                            writerXml.WriteStartElement("DSACH_CHI_TIET_THUOC");
                            WriteXmlRow(writerXml, dtXmlType, "CHI_TIET_THUOC", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("CHI_TIET_THUOC");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML3":
                        {
                            writerXml.WriteStartElement("CHITIEU_CHITIET_DVKT_VTYT");
                            writerXml.WriteStartElement("DSACH_CHI_TIET_DVKT");
                            WriteXmlRow(writerXml, dtXmlType, "CHI_TIET_DVKT", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("CHI_TIET_DVKT");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML4":
                        {
                            writerXml.WriteStartElement("CHITIEU_CHITIET_DICHVUCANLAMSANG");
                            writerXml.WriteStartElement("DSACH_CHI_TIET_CLS");
                            WriteXmlRow(writerXml, dtXmlType, "CHI_TIET_CLS", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("CHI_TIET_CLS");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML5":
                        {
                            writerXml.WriteStartElement("CHITIEU_CHITIET_DIENBIENLAMSANG");
                            writerXml.WriteStartElement("DSACH_CHI_TIET_DIEN_BIEN_BENH");
                            WriteXmlRow(writerXml, dtXmlType, "CHI_TIET_DIEN_BIEN_BENH", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("CHI_TIET_DIEN_BIEN_BENH");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML6":
                        {
                            writerXml.WriteStartElement("CHI_TIEU_HO_SO_BENH_AN_CHAM_SOC_VA_DIEU_TRI_HIV_AIDS");
                            writerXml.WriteStartElement("DSACH_HO_SO_BENH_AN_CHAM_SOC_VA_DIEU_TRI_HIV_AIDS");
                            WriteXmlRow(writerXml, dtXmlType, "HO_SO_BENH_AN_CHAM_SOC_VA_DIEU_TRI_HIV_AIDS", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("HO_SO_BENH_AN_CHAM_SOC_VA_DIEU_TRI_HIV_AIDS");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML7":
                        {
                            WriteXmlRow(writerXml, dtXmlType, "CHI_TIEU_DU_LIEU_GIAY_RA_VIEN", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_GIAY_RA_VIEN");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            break;
                        }
                    case "XML8":
                        {
                            WriteXmlRow(writerXml, dtXmlType, "CHI_TIEU_DU_LIEU_TOM_TAT_HO_SO_BENH_AN", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_TOM_TAT_HO_SO_BENH_AN");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            break;
                        }
                    case "XML9":
                        {
                            writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_GIAY_CHUNG_SINH");
                            writerXml.WriteStartElement("DSACH_GIAYCHUNGSINH");
                            WriteXmlRow(writerXml, dtXmlType, "DU_LIEU_GIAY_CHUNG_SINH", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("DU_LIEU_GIAY_CHUNG_SINH");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            writerXml.WriteEndElement();
                            writerXml.WriteEndElement();
                            break;
                        }
                    case "XML10":
                        {
                            WriteXmlRow(writerXml, dtXmlType, "CHI_TIEU_DU_LIEU_GIAY_NGHI_DUONG_THAI", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_GIAY_NGHI_DUONG_THAI");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            break;
                        }
                    case "XML11":
                        {
                            WriteXmlRow(writerXml, dtXmlType, "CHI_TIEU_DU_LIEU_GIAY_CHUNG_NHAN_NGHI_VIEC_HUONG_BAO_HIEM_XA_HOI", maLK);
                            //foreach (DataRow drXmlType in dtXmlType.Rows)
                            //{
                            //    writerXml.WriteStartElement("CHI_TIEU_DU_LIEU_GIAY_CHUNG_NHAN_NGHI_VIEC_HUONG_BAO_HIEM_XA_HOI");
                            //    foreach (DataColumn col in dtXmlType.Columns)
                            //    {
                            //        string value = drXmlType[col].ToString();
                            //        writerXml.WriteElementString(col.ColumnName, value);
                            //    }
                            //    writerXml.WriteEndElement();
                            //}
                            break;
                        }
                    default:
                        break;
                }
                writerXml.WriteEndDocument();
                writerXml.Flush();
            }
            string xmlContent = sbFileHoSoXml.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");
            if (!string.IsNullOrWhiteSpace(xmlTypePath))
            {
                File.WriteAllText(xmlTypePath, xmlContent);
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(xmlContent));
        }

        private static void WriteXmlRow(XmlWriter writerXml, DataTable dtXmlType, string rowName, string maLK)
        {
            foreach (DataRow drXmlType in dtXmlType.Rows)
            {
                if (maLK == drXmlType["MA_LK"].ToString())
                {
                    writerXml.WriteStartElement(rowName);
                    foreach (DataColumn col in dtXmlType.Columns)
                    {
                        if (!col.ColumnName.EndsWith("_Id") && col.ColumnName != "MA_LOI" && col.ColumnName != "THONGTIN_LOI") // bỏ _Id
                        {
                            string value = drXmlType[col].ToString();
                            writerXml.WriteElementString(col.ColumnName, value);
                        }
                    }
                    writerXml.WriteEndElement();
                }
            }
        }
    }

    public class ClsXmlError
    {
        public string XmlType { get; set; }
        public string Item { get; set; }
        public string MaLoiCha { get; set; }
        public string MaLoiCon { get; set; }
        public string NoiDungLoi { get; set; }
    }
}