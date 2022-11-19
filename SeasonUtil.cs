using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace JazzAppAdmin
{
    /// <summary>Class with functions that handle the seasons</summary>
    static public class SeasonUtil
    {

        /// <summary>Start year for JAZZ live AARAU (used to construct the name for the first XMLfile)</summary>
        static private int m_start_season = 1996;

        /// <summary>For the construction of possible season file names: The number of years after the current year </summary>
        static private int m_possible_years_after_current = 3;

        /// <summary>Start month for a new season</summary>
        static private int m_start_month_new_season = JazzAppAdminSettings.Default.NewSeasonStartMonth;

        /// <summary>Returns the current season start year as an integer</summary>
        static public int GetCurrentSeasonStartYear()
        {
            int ret_start_year = -12345;

            DateTime current_time = DateTime.Now;
            int now_year = current_time.Year;
            int now_month = current_time.Month;


            if (now_month < m_start_month_new_season)
            {
                ret_start_year = now_year - 1;
            }
            else
            {
                ret_start_year = now_year;
            }

            return ret_start_year;
        } // GetCurrentSeasonStartYear

        /// <summary>Get all possible season XML file names (no path) as strings</summary>
        public static string[] GetAllPossibleXmlSeasonFileNamesAsStrings()
        {
            string[] ret_list_file_names = null;
            ArrayList array_list_file_names = new ArrayList();

            int current_start_year = GetCurrentSeasonStartYear();
            int start_year = SeasonUtil.m_start_season;
            int end_year = current_start_year + SeasonUtil.m_possible_years_after_current;

            for (int i_year = start_year; i_year <= end_year; i_year++)
            {
                string file_name = JazzAppAdminSettings.Default.SeasonFileNameStart + i_year.ToString() + @"_" + (i_year + 1).ToString() + @".xml";

                array_list_file_names.Add(file_name);
            }


            ret_list_file_names = (string[])array_list_file_names.ToArray(typeof(string));

            return ret_list_file_names;
        } // GetAllPossibleXmlSeasonFileNamesAsStrings

        /// <summary>Get all possible season XML files as URLs (file names with paths for the server)</summary>
        public static string[] GetAllPossibleXmlSeasonFileUrls()
        {
            string[] ret_list_file_urls = null;
            ArrayList array_list_file_urls = new ArrayList();

            string[] all_file_names = GetAllPossibleXmlSeasonFileNamesAsStrings();

            int n_number_files = all_file_names.Length;

            string server_directory = @"http://" + JazzAppAdminSettings.Default.FtpHost + @"/" + JazzAppAdminSettings.Default.XmlExistingDir + @"/";
           

            for (int i_index_url = 0; i_index_url < n_number_files; i_index_url++)
            {
                string file_url = server_directory + all_file_names[i_index_url];

                array_list_file_urls.Add(file_url);
            }


                ret_list_file_urls = (string[])array_list_file_urls.ToArray(typeof(string));

            return ret_list_file_urls;
        } // GetAllPossibleXmlSeasonFileUrls


        /// <summary>Get all possible season XML local file names (with paths for the computer)</summary>
        public static string[] GetAllPossibleXmlSeasonLocalFileNames()
        {
            string[] ret_list_file_locals = null;
            ArrayList array_list_file_locals = new ArrayList();

            string[] all_file_names = GetAllPossibleXmlSeasonFileNamesAsStrings();

            int n_number_files = all_file_names.Length;

            string local_directory = FileUtil.SubDirectory(JazzAppAdminSettings.Default.XmlExistingDir, Main.m_exe_directory) + @"/";

            for (int i_index_local = 0; i_index_local < n_number_files; i_index_local++)
            {
                string file_local = local_directory + all_file_names[i_index_local];

                array_list_file_locals.Add(file_local);
            }


            ret_list_file_locals = (string[])array_list_file_locals.ToArray(typeof(string));

            return ret_list_file_locals;

        } // GetAllPossibleXmlSeasonLocalFileNames



    } // SeasonUtil

} // JazzAppAdmin
