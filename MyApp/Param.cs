using XML130.Libraries;
using System;
using System.Data;
using System.Globalization;

namespace XML130
{
    public class Param
    {
        public static void SetValue(string paramCode, object value)
        {
            string empty = string.Empty;
            string str;
            if (value.GetType() == typeof(DateTime))
            {
                CultureInfo cultureInfo = new CultureInfo("en-US");
                str = Convert.ToDateTime(value, (IFormatProvider)cultureInfo.DateTimeFormat).ToString((IFormatProvider)cultureInfo.DateTimeFormat);
            }
            else if (value.GetType() == typeof(Decimal))
            {
                CultureInfo cultureInfo = new CultureInfo("en-US");
                str = Convert.ToDecimal(value, (IFormatProvider)cultureInfo.NumberFormat).ToString();
            }
            else
                str = value.ToString();
            SQLHelper.ExecuteNonQuery(string.Format("update tblThamSo set GiaTri = N'{0}' where TenThamSo = N'{1}'", (object)str, (object)paramCode));
        }

        public static T GetValue<T>(string paramCode, string category, object defaultValue) => Param.GetValue<T>(paramCode, category, defaultValue, true);

        public static T GetValue<T>(
          string paramCode,
          string category,
          object defaultValue,
          bool allowEdit)
        {
            string empty1 = string.Empty;
            if (!HeThong.Exits("tblThamSo", "TenThamSo", paramCode))
            {
                string empty2 = string.Empty;
                string str;
                if (typeof(T) == typeof(DateTime))
                {
                    CultureInfo cultureInfo = new CultureInfo("en-US");
                    str = Convert.ToDateTime(defaultValue, (IFormatProvider)cultureInfo.DateTimeFormat).ToString((IFormatProvider)cultureInfo.DateTimeFormat);
                }
                else if (typeof(T) == typeof(Decimal))
                {
                    CultureInfo cultureInfo = new CultureInfo("en-US");
                    str = Convert.ToDecimal(defaultValue, (IFormatProvider)cultureInfo.NumberFormat).ToString();
                }
                else
                    str = defaultValue.ToString();
                SQLHelper.ExecuteNonQuery(string.Format("INSERT INTO [tblThamSo]\r\n                                    ([TenThamSo]\r\n                                    ,[GiaTri]\r\n                                    ,[ChoPhepThayDoi]\r\n                                    ,[Nhom]\r\n                                    ,[KieuDuLieu])\r\n                                VALUES (N'{0}', N'{1}', {2}, N'{3}', N'{4}')", (object)paramCode, (object)str, (object)Convert.ToInt32(allowEdit), (object)category, (object)typeof(T).ToString()));
            }
            DataTable dataTable = SQLHelper.ExecuteDataTable(string.Format("select * from tblThamSo where TenThamSo = N'{0}'", (object)paramCode));
            if (dataTable == null || dataTable.Rows.Count == 0)
                return default(T);
            DataRow row = dataTable.Rows[0];
            if (typeof(T) == typeof(DateTime))
            {
                CultureInfo provider = new CultureInfo("en-US");
                return (T)Convert.ChangeType(row["GiaTri"], typeof(T), (IFormatProvider)provider);
            }
            if (!(typeof(T) == typeof(Decimal)))
                return (T)Convert.ChangeType(row["GiaTri"], typeof(T));
            CultureInfo provider1 = new CultureInfo("en-US");
            return (T)Convert.ChangeType(row["GiaTri"], typeof(T), (IFormatProvider)provider1);
        }
    }
}
