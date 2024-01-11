using System;
using System.Data;
using XML130.Libraries;

namespace XML130.EasyData
{
    public class DinhDangMa
    {
        public static string LayMaTuDong(
          string tenBang,
          string key,
          string dinhdangMacDinh,
          DataTable dt_tmp)
        {
            string format = dinhdangMacDinh;
            int count = dt_tmp.Rows.Count;
            if (count == 0)
                ++count;
            string str = string.Format(format, (object)count);
            for (DataRow[] dataRowArray = dt_tmp.Select(string.Format("{0} = '{1}'", (object)key, (object)str)); dataRowArray.Length > 0; dataRowArray = dt_tmp.Select(string.Format("{0} = '{1}'", (object)key, (object)str)))
                str = string.Format(format, (object)++count);
            return str;
        }

        public static string LayMaNV()
        {
            int num = SQLHelper.ExecuteScalar<int>("SELECT max(EmployeeID)+1 FROM Employee");
            string format = Param.GetValue<string>("EmployeeID", "Format code", (object)"{0:d7}");
            string ma = string.Format(format, (object)num);
            while (HeThong.Exits("Employee", "EmployeeID", ma))
                ma = string.Format(format, (object)num++);
            return ma;
        }

        // lấy mã tự động
        public static string LayMaTuDong(string CotMa, string TableName, string dinhdang)
        {
            int num = SQLHelper.ExecuteScalar<int>(string.Format("SELECT COUNT({0}) FROM {1}", (object)CotMa, (object)TableName)) + 1;
            string ma = string.Format(dinhdang, (object)num);
            while (HeThong.Exits(TableName, CotMa, ma))
                ma = string.Format(dinhdang, (object)num++);
            return ma;
        }

        public static string MaBn( DateTime ngay)
        {
            var query = "SELECT COUNT(MaBn) FROM tblDmBenhNhan WHERE DAY([Date])='" + ngay.Day +
                        "' AND MONTH([Date])='" + ngay.Month + "' AND YEAR([Date])='" + ngay.Year + "'";
            //var query = "select count(*) from tblDmBenhNhan where [Date]='" + Convert.ToDateTime(ngay).ToString("MM/dd/yyyy") + "'";
            int num = SQLHelper.ExecuteScalar<int>(query) + 1;
            var code = string.Format(@"{0:ddyyMM}{1:d4}", ngay, num);
            return code;
           
        }

        public static string MaChiDinh(DateTime ngay)
        {
            var query = "SELECT COUNT(Id) FROM tblDmChiDinh WHERE DAY([NgayChiDinh])='" + ngay.Day +
                        "' AND MONTH([NgayChiDinh])='" + ngay.Month + "' AND YEAR([NgayChiDinh])='" + ngay.Year + "'";
            
            int num = SQLHelper.ExecuteScalar<int>(query) + 1;
            var code = string.Format(@"PCD/{0:ddMMyy}/{1:d6}", ngay, num);
            return code;
        }

        public static string Lm(int input)
        {
            string strRet = string.Empty;
            decimal number = input;
            Boolean _Flag = true;
            string[] arrLama = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] arrNumber = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            int i = 0;
            while (_Flag)
            {
                while (number >= arrNumber[i])
                {
                    number -= arrNumber[i];
                    strRet += arrLama[i];
                    if (number < 1)
                        _Flag = false;
                }
                i++;
            }

            return strRet;
        }
    }
}
