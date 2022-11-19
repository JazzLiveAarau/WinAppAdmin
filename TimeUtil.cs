using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Time utility functions</summary>
    public static class TimeUtil
    {
        /// <summary>Returns date and time (year_month_day_hour_Minute_Second) as a string</summary>
        public static string YearMonthDayHourMinSec()
        {
            DateTime current_time = DateTime.Now;
            int now_year = current_time.Year;
            int now_month = current_time.Month;
            int now_day = current_time.Day;
            int now_hour = current_time.Hour;
            int now_minute = current_time.Minute;
            int now_second = current_time.Second;

            string time_text = now_year.ToString() + "_" + _IntToString(now_month) + "_" + _IntToString(now_day) + "_" + _IntToString(now_hour) + "_" + _IntToString(now_minute) + "_" + _IntToString(now_second);

            return time_text;
        } // YearMonthDayHourMinSec

        /// <summary>Returns current year, month and day as strings</summary>
        public static void YearMonthDay(out string o_year_str, out string o_month_str, out string o_day_str)
        {
            DateTime current_time = DateTime.Now;
            int now_year = current_time.Year;
            int now_month = current_time.Month;
            int now_day = current_time.Day;

            o_year_str = now_year.ToString();
            o_month_str = now_month.ToString();
            o_day_str = now_day.ToString();

        } // YearMonthDayHourMinSec

        /// <summary>Returns current year as int</summary>
        public static int YearInt()
        {
            DateTime current_time = DateTime.Now;
            int now_year = current_time.Year;
            return now_year;

        } // YearInt

        /// <summary>Returns current month as int</summary>
        public static int MonthInt()
        {
            DateTime current_time = DateTime.Now;
            int now_month = current_time.Month;
            return now_month;

        } // MonthInt

        /// <summary>Returns current day as int</summary>
        public static int DayInt()
        {
            DateTime current_time = DateTime.Now;
            int now_day = current_time.Day;
            return now_day;

        } // DayInt

        /// <summary>Returns date (year_month_day) as a string</summary>
        public static string YearMonthDay()
        {
            DateTime current_time = DateTime.Now;
            int now_year = current_time.Year;
            int now_month = current_time.Month;
            int now_day = current_time.Day;

            string time_text = "_" + now_year.ToString() + "_" + _IntToString(now_month) + "_" + _IntToString(now_day);

            return time_text;
        } // YearMonthDay

        /// <summary>Returns date (year-month-day) as a string</summary>
        public static string YearMonthDayIso()
        {
            DateTime current_time = DateTime.Now;
            int now_year = current_time.Year;
            int now_month = current_time.Month;
            int now_day = current_time.Day;

            string time_text = now_year.ToString() + "-" + _IntToString(now_month) + "-" + _IntToString(now_day);

            return time_text;
        } // YearMonthDay

        /// <summary>
        /// Returns date in the iso format
        /// </summary>
        /// <param name="i_concert_year">Concert year as int</param>
        /// <param name="concert_month">Concert month as int</param>
        /// <param name="i_concert_day">Concert day as int</param>
        /// <returns>Date iso string</returns>
        public static string ConcertYearMonthDayIso(int i_concert_year_int, int concert_month_int, int i_concert_day_int)
        {

            string date_iso = i_concert_year_int.ToString() + "-" + _IntToString(concert_month_int) + "-" + _IntToString(i_concert_day_int);

            return date_iso;

        } // ConcertYearMonthDayIso

        /// <summary>Returns true if the date/time is passed. The function can be used to determine if a concert has been played </summary>
        public static bool PassedTime(int i_year, int i_month, int i_day)
        {
            DateTime current_time = DateTime.Now;
            int now_year = current_time.Year;
            int now_month = current_time.Month;
            int now_day = current_time.Day;

            if (i_year < now_year)
                return true;
            else if (i_year == now_year && i_month < now_month)
                return true;
            else if (i_year == now_year && i_month == now_month && i_day < now_day)
                return true;
            else
                return false;

        } // PassedTime

        /// <summary>Returns true if the year is passed.</summary>
        public static bool PassedYear(int i_year)
        {
            DateTime current_time = DateTime.Now;
            int now_year = current_time.Year;

            if (i_year < now_year)
                return true;
            else
                return false;

        } // PassedYear

        /// <summary>Returns the name of the day</summary>
        public static string DayName(int i_year, int i_month, int i_day)
        {
            string ret_day = @"";

            DateTime date_time = new DateTime(i_year, i_month, i_day);

            ret_day = date_time.DayOfWeek.ToString();

            if (ret_day.Equals("Sunday"))
                ret_day = "Sonntag";
            else if (ret_day.Equals("Monday"))
                ret_day = "Montag";
            else if (ret_day.Equals("Tuesday"))
                ret_day = "Dienstag";
            else if (ret_day.Equals("Wednesday"))
                ret_day = "Mittwoch";
            else if (ret_day.Equals("Thursday"))
                ret_day = "Donnerstag";
            else if (ret_day.Equals("Friday"))
                ret_day = "Freitag";
            else if (ret_day.Equals("Saturday"))
                ret_day = "Samstag";
            else
                ret_day = "TimeUtil.Dayname Programming error ret_day= " + ret_day;

            return ret_day;

        } // DayName

        /// <summary>Returns the date that is a saturday and closest to the input date</summary>
        public static void GetClosestSaturdayDate(int i_year, int i_month, int i_day, out int o_year, out int o_month, out int o_day)
        {
            o_year = -12345;

            o_month = -12345;

            o_day = -12345;

            DateTime input_date_time = new DateTime(i_year, i_month, i_day);

            int n_days_pos = 0;

            for (int day_pos = 0; day_pos <= 7; day_pos++)
            {
                DateTime day_time_pos = input_date_time.AddDays(day_pos);

                string day_of_week = day_time_pos.DayOfWeek.ToString();

                if (day_of_week.Equals("Saturday"))
                {
                    break;
                }

                n_days_pos = n_days_pos + 1;

            } // day_pos

            int n_days_neg = 0;

            for (int day_neg = 0; day_neg >= -7; day_neg--)
            {
                DateTime day_time_neg = input_date_time.AddDays(day_neg);

                string day_of_week = day_time_neg.DayOfWeek.ToString();

                if (day_of_week.Equals("Saturday"))
                {
                    break;
                }

                n_days_neg = n_days_neg - 1;

            } // day_neg

            if (n_days_pos == 7 || n_days_neg == -7)
            {
                return;
            }

            DateTime candidate_date_time_pos = input_date_time.AddDays(n_days_pos);

            DateTime candidate_date_time_neg = input_date_time.AddDays(n_days_neg);

            if (Math.Abs(n_days_pos) < Math.Abs(n_days_neg))
            {
                o_year = candidate_date_time_pos.Year;
                o_month = candidate_date_time_pos.Month;
                o_day = candidate_date_time_pos.Day;
            }
            else
            {
                o_year = candidate_date_time_neg.Year;
                o_month = candidate_date_time_neg.Month;
                o_day = candidate_date_time_neg.Day;
            }

        } // GetClosestSaturdayDate


        /// <summary>Returns date and time as a string with a '0' added if input number is less that ten (10)</summary>
        private static string _IntToString(int i_int)
        {
            string time_text = i_int.ToString();

            if (i_int <= 9)
            {
                time_text = "0" + time_text;
            }

            return time_text;
        }  // _IntToString

    } // Class TimeUtil
} // JazzAppAdmin
