using System;
using System.Collections.Generic;

namespace XML130.EasyUtils
{
    internal class EasyDateTimeClass
    {
        /// <summary>
        /// Convert string Date
        /// </summary>
        /// <param name="date">string Date to convert</param>
        /// <returns>Default datetime format dd/MM/yyyy</returns>
        public static string ConvertDate(string date)
        {
            return ConvertDate(date, "dd/MM/yyyy");
        }
        /// <summary>
        /// Convert string Date
        /// </summary>
        /// <param name="date">string Date to convert</param>
        /// <param name="dateFormat">string format date</param>
        /// <returns>string Date format as DateFormat</returns>
        public static string ConvertDate(string date, string dateFormat)
        {
            if (date.Length > 0)
            {
                DateTime dt = Convert.ToDateTime(date);
                return dt.ToString(dateFormat);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Convert Date
        /// </summary>
        /// <param name="date">Date to convert</param>
        /// <returns>Default datetime format dd/MM/yyyy</returns>
        public static string ConvertDate(DateTime date)
        {
            return ConvertDate(date, "dd/MM/yyyy");
        }
        /// <summary>
        /// Convert Date
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="dateFormat">string format date</param>
        /// <returns>string Date format as DateFormat</returns>
        public static string ConvertDate(DateTime date, string dateFormat)
        {
            if (date != null)
            {
                return date.ToString(dateFormat);
            }
            else
            {
                return "";
            }
        }

        public static DateTime Convert2Date(string date)
        {
            DateTime dt = Convert.ToDateTime(date);
            return dt;
        }

        /// <summary>
        /// Convert string Datetime
        /// </summary>
        /// <param name="dateTime">string Datetime to convert</param>
        /// <returns>Default dd/MM/yyyy HH:mm:ss</returns>
        public static string ConvertDateTime(string dateTime)
        {
            return ConvertDateTime(dateTime, "dd/MM/yyyy hh:mm:ss tt");
        }
        /// <summary>
        /// Convert string Datetime
        /// </summary>
        /// <param name="dateTime">string Datetime to convert</param>
        /// <param name="dateFormat">string format date</param>
        /// <returns>string Datetime format as DateFormat</returns>
        public static string ConvertDateTime(string dateTime, string dateFormat)
        {
            if (dateTime.Length > 0)
            {
                DateTime dt = Convert.ToDateTime(dateTime);
                return dt.ToString(dateFormat);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Convert Datetime
        /// </summary>
        /// <param name="dateTime">Datetime to convert</param>
        /// <returns>Default dd/MM/yyyy HH:mm:ss</returns>
        public static string ConvertDateTime(DateTime dateTime)
        {
            return ConvertDateTime(dateTime, "dd/MM/yyyy HH:mm:ss tt");
        }
        /// <summary>
        /// Convert Datetime
        /// </summary>
        /// <param name="dateTime">Datetime to convert</param>
        /// <param name="dateFormat">string format date</param>
        /// <returns>string Datetime format as DateFormat</returns>
        public static string ConvertDateTime(DateTime dateTime, string dateFormat)
        {
            if (dateTime != null)
            {
                return dateTime.ToString(dateFormat);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        ///  Convert string Time
        /// </summary>
        /// <param name="time">string Time to convert</param>
        /// <returns>Default HH:mm:ss</returns>
        public static string ConvertTime(string time)
        {
            return ConvertTime(time, "HH:mm:ss");
        }

        public static string ConvertTimeSa(string time)
        {
            return ConvertTime(time, "HH:mm");
        }

        /// <summary>
        ///  Convert string Time
        /// </summary>
        /// <param name="time">string Time to convert</param>
        /// <param name="timeFormat">string format time</param>
        /// <returns>string Time format as TimeFormat</returns>
        public static string ConvertTime(string time, string timeFormat)
        {
            if (time.Length > 0)
            {
                DateTime dt = Convert.ToDateTime(time);
                return dt.ToString(timeFormat);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        ///  Convert Time
        /// </summary>
        /// <param name="time">Time to convert</param>
        /// <returns>Default HH:mm:ss</returns>
        public static string ConvertTime(DateTime time)
        {
            return ConvertTime(time, "HH:mm:ss");
        }

        /// <summary>
        ///  Convert Time
        /// </summary>
        /// <param name="time">Time to convert</param>
        /// <param name="timeFormat">string format time</param>
        /// <returns>string Time format as TimeFormat</returns>
        public static string ConvertTime(DateTime time, string timeFormat)
        {
            if (time != null)
            {
                return time.ToString(timeFormat);
            }
            else
            {
                return "";
            }
        }

        public static string DayOfWeek(string date)
        {
            if (date.Length > 0)
            {
                DateTime dt = Convert.ToDateTime(date);
                return DayOfWeek(dt);
            }
            else
            {
                return "";
            }
        }

        public static string DayOfWeek(DateTime date)
        {
            string strReturn = "";
            if (date != null)
            {
                switch (date.DayOfWeek.ToString())
                {
                    case "Sunday":
                        strReturn = "Chủ nhật";
                        break;
                    case "Monday":
                        strReturn = "Thứ 2";
                        break;
                    case "Tuesday":
                        strReturn = "Thứ 3";
                        break;
                    case "Wednesday":
                        strReturn = "Thứ 4";
                        break;
                    case "Thursday":
                        strReturn = "Thứ 5";
                        break;
                    case "Friday":
                        strReturn = "Thứ 6";
                        break;
                    case "Saturday":
                        strReturn = "Thứ 7";
                        break;
                }
            }
            return strReturn;
        }

        public static string RelativeDate(DateTime theDate)
        {

            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            const int minute = 60;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            thresholds.Add(60, "{0} giây trước");
            thresholds.Add(minute * 2, "1 phút trước");
            thresholds.Add(45 * minute, "{0} phút trước");
            thresholds.Add(120 * minute, "1 giờ trước");
            thresholds.Add(day, "{0} giờ trước");
            thresholds.Add(day * 2, "hôm qua");
            thresholds.Add(day * 30, "{0} ngày trước");
            thresholds.Add(day * 365, "{0} tháng trước");
            thresholds.Add(long.MaxValue, "{0} năm trước");

            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;
            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    string s = string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                    return s;
                }
            }
            return "";
        }

        public static string RelativeDateT(DateTime theDate)
        {

            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            const int minute = 60;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            thresholds.Add(60, "");
            thresholds.Add(minute * 2, "");
            thresholds.Add(45 * minute, "");
            thresholds.Add(120 * minute, "");
            thresholds.Add(day, "");
            thresholds.Add(day * 2, "hôm qua");
            thresholds.Add(day * 30, "{0} ngày trước");
            thresholds.Add(day * 365, "{0} tháng trước");
            thresholds.Add(long.MaxValue, "{0} năm trước");

            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;
            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    string s = string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                    return s;
                }
            }
            return "";
        }

        public int GetMonthsBetween(DateTime from , DateTime to) //tru ngay ra so
        {
            if (from > to) return GetMonthsBetween(to, from);
            var monthDiff = Math.Abs((to.Year * 12 + (to.Month - 1)) - (from.Year * 12 + (from.Month - 1)));
            if (from.AddMonths(monthDiff) > to || to.Day < from.Day)
            {
                return monthDiff - 1;
            }
            else
            {
                return monthDiff;
            }
        }
    }
}
