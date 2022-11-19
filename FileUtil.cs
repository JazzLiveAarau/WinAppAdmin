using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using JazzApp;

namespace JazzAppAdmin
{
    /// <summary>File utility functions</summary>
    static public class FileUtil
    {
        /// <summary>Get full name to the config (XML) file for this application.</summary>
        public static string ConfigFileName(string i_name, string i_exe_directory)
        {
            string config_file_name = i_name.Trim() + ".config";

            string full_name = Path.Combine(i_exe_directory, config_file_name);

            return full_name;
        } // ConfigFileName

        /// <summary>Get the path to a subdirectory. Create the directory (all directories) if not existing.</summary>
        public static string SubDirectory(string i_subdir_name, string i_exe_directory)
        {
            string sub_directory = Path.Combine(i_exe_directory, i_subdir_name);

            if (!Directory.Exists(sub_directory))
            {
                Directory.CreateDirectory(sub_directory);
            }

            return sub_directory;
        } // SubDirectory

        /// <summary>
        /// Create a file. One line with name and date is written
        /// </summary>
        /// <param name="i_file_name">File name</param>
        /// <param name="i_directory">Directory</param>
        /// <param name="i_exe_directory">Execution directory for the application</param>
        /// <param name="o_error">Error message</param>
        /// <returns>File name with path. Empty string for error</returns>
        public static string CreateFile(string i_file_name, string i_subdir_name, string i_exe_directory, out string o_error)
        {
            o_error = @"";

            string sub_dir = SubDirectory(i_subdir_name, i_exe_directory);

            string file_name_path = Path.Combine(sub_dir, i_file_name);

            try
            {
                using (StreamWriter file_sw = File.CreateText(file_name_path))
                {
                    file_sw.WriteLine(@"// File " + file_name_path + @" created.  " + TimeUtil.YearMonthDayHourMinSec());
                }
            }
            catch (Exception ex)
            {
                o_error = @"FileUtil.CreateFile " + ex.Message;
                return @"";
            }

            return file_name_path;

        } // CreateFile

        /// <summary>
        /// Create an XML file with the XML file statement and a header as comment
        /// </summary>
        /// <param name="i_file_name">File name</param>
        /// <param name="i_directory">Directory</param>
        /// <param name="i_header_txt">Header text</param>
        /// <param name="i_exe_directory">Execution directory for the application</param>
        /// <param name="o_error">Error message</param>
        /// <returns>File name with path. Empty string for error</returns>
        public static string CreateXmlFile(string i_file_name, string i_subdir_name, string i_exe_directory, string i_header_txt, out string o_error)
        {
            o_error = @"";

            string ext_file_str = Path.GetExtension(i_file_name);

            if (!ext_file_str.Equals(".xml"))
            {
                o_error = @"FileUtil.CreateXmlFile File extension " + ext_file_str + " is not .xml";

                return @"";
            }

            string sub_dir = SubDirectory(i_subdir_name, i_exe_directory);

            string file_name_path = Path.Combine(sub_dir, i_file_name);

            string xml_specification_str = @"<?xml version='1.0' encoding='utf - 8'?>";

            string header_comment_str = @"<!--  " + i_header_txt + @"  -->";

            try
            {
                using (StreamWriter file_sw = File.CreateText(file_name_path))
                {
                    file_sw.WriteLine(xml_specification_str);

                    file_sw.WriteLine(header_comment_str);
                }
            }
            catch (Exception ex)
            {
                o_error = @"FileUtil.CreateXmlFile " + ex.Message;

                return @"";
            }

            return file_name_path;

        } // CreateXmlFile

        /// <summary>
        /// Appends a line to an existing file
        /// </summary>
        /// <param name="i_file_name_path">File name with path</param>
        /// <param name="i_line">Line that shall be appended</param>
        /// <returns>false for error</returns>
        public static bool AppendLine(string i_file_name_path, string i_line)
        {
            try
            {
                using (StreamWriter file_sw = File.AppendText(i_file_name_path))
                {
                    file_sw.WriteLine(i_line);
                }
            }
            catch (Exception ex)
            {
                string erroe_message = @"FileUtil.AppendLine " + ex.Message;
                return false;
            }

            return true;
        } // AppendLine

        /// <summary>
        /// Append a file to another file
        /// </summary>
        /// <param name="i_file_name_path">Full file name_</param>
        /// <param name="i_append_file_name">Name of file to be appended</param>
        /// <param name="i_append_directory">Name of append directory</param>
        /// <param name="i_exe_directory">Execution directory for the application</param>
        /// <param name="o_error">Error message</param>
        /// <returns>false for error</returns>
        static public bool AppendFile(string i_file_name_path, string i_append_file_name, string i_append_directory, string i_exe_directory, out string o_error)
        {
            o_error = @"";

            string append_sub_dir = SubDirectory(i_append_directory, i_exe_directory);

            string append_file_name_path = Path.Combine(append_sub_dir, i_append_file_name);

            try
            {
                using (StreamReader file_sr = File.OpenText(append_file_name_path))
                {
                    string row_str = @"";
                    while ((row_str = file_sr.ReadLine()) != null)
                    {
                        AppendLine(i_file_name_path, row_str);
                    }
                }
            }
            catch (Exception ex)
            {
                string erroe_message = @"FileUtil.AppendFile " + ex.Message;
                return false;
            }

            return true;

        } // AppendFile

        /// <summary>
        /// Get files with given extensions
        /// </summary>
        /// <param name="i_extension">Array of extensions (with point)</param>
        /// <param name="i_directory">Search directory</param>
        /// <param name="o_file_names">Array of found files with paths</param>
        /// <returns>false if directory not exists or the input array of extensions is empty</returns>
        static public bool GetFilesDirectory(string[] i_extensions, string i_directory, out string[] o_file_names)
        {
            ArrayList files_string_array = new ArrayList();
            o_file_names = (string[])files_string_array.ToArray(typeof(string));

            for (int i_ext = 0; i_ext < i_extensions.Length; i_ext++)
            {
                string current_ext = i_extensions[i_ext];

                string[] files_ext = Directory.GetFiles(i_directory, "*" + current_ext);

                foreach (string file_ext in files_ext)
                {
                    files_string_array.Add(file_ext);
                }
            }

            files_string_array.Reverse();

            o_file_names = (string[])files_string_array.ToArray(typeof(string));

            return true;
        } // GetFilesDirectory

        /// <summary>Returns true if the file is in the array.</summary>
        /// <param name="i_file_name">File name</param>
        /// <param name="i_file_names_array">Array of files</param>
        /// <returns>Returns true or false if the i_file_name is in array i_file_names_array</returns>
        public static bool FileIsInArray(string i_file_name, string[] i_file_names_array)
        {
            foreach (string file_name_array in i_file_names_array)
            {
                if (String.Compare(i_file_name, file_name_array, false) == 0)
                {
                    return true;
                }

            }

            return false;
        } // FileIsInArray

        /// <summary>Add date (year, month, day, hour, second) and machine to the file name.</summary>
        public static string AddDateAndMachineToFileName(string i_file_name)
        {
            string time_machine_file_name_no_ext = Path.GetFileNameWithoutExtension(i_file_name);

            string time_machine_file_name = time_machine_file_name_no_ext + "_" + TimeUtil.YearMonthDayHourMinSec()
                + "_" + System.Environment.MachineName + Path.GetExtension(i_file_name);

            return time_machine_file_name;
        } // AddDateAndMachineToFileName

        /// <summary>Get local name for the backup file with addresses (year, month, day, hour, second and machine are added to the file name).</summary>
        public static string BackupAddressesFileName(string i_addresses_file_name, string i_addresses_directory, string i_exe_directory)
        {
            string time_addresses_file_name = Path.GetFileNameWithoutExtension(i_addresses_file_name);

            time_addresses_file_name = time_addresses_file_name + "_" + TimeUtil.YearMonthDayHourMinSec()
                + "_" + System.Environment.MachineName + Path.GetExtension(i_addresses_file_name);

            string path_time_file_name_addresses = Path.Combine(XmlFilesDirectory(i_addresses_directory, i_exe_directory), time_addresses_file_name);

            return path_time_file_name_addresses;
        }

        /// <summary>Get full name to the login-logout file</summary>
        public static string AddressesFileName(string i_addresses_file_name, string i_addresses_directory, string i_exe_directory)
        {
            string path_file_name_addresses = Path.Combine(EmailAdressesDirectory(i_addresses_directory, i_exe_directory), i_addresses_file_name);

            return path_file_name_addresses;
        }

        /// <summary>Get full name to the directory with the list of adresses. Create the directory if not existing.</summary>
        public static string EmailAdressesDirectory(string i_addresses_directory, string i_exe_directory)
        {
            string email_addresses_directory = Path.Combine(i_exe_directory, i_addresses_directory);

            if (!Directory.Exists(email_addresses_directory))
            {
                Directory.CreateDirectory(email_addresses_directory);
            }

            return email_addresses_directory;
        }

        /// <summary>Get full name to the directory with the XML and XSD files. Create the directory if not existing.</summary>
        public static string XmlFilesDirectory(string i_addresses_directory, string i_exe_directory)
        {
            string email_addresses_directory = Path.Combine(i_exe_directory, i_addresses_directory);

            if (!Directory.Exists(email_addresses_directory))
            {
                Directory.CreateDirectory(email_addresses_directory);
            }

            return email_addresses_directory;
        } // XmlFilesDirectory

        /// <summary>Name of the local directory where QR Code images are stored</summary>
        static private string m_dir_qr_code_name = "QRCodes";

        /// <summary>Returns the name of the local directory where QR Code images are stored</summary>
        static public string GetQrCodeDir() { return m_dir_qr_code_name;  }

        /// <summary>Returns the name of the local subdirectory for QR Code images
        /// <para>The directory will be created if not existing</para>
        /// </summary>
        public static string GetFullNameLocalQrCodeDir()
        {
            return FileUtil.SubDirectory(m_dir_qr_code_name, Main.m_exe_directory) + @"\";

        } // GetFullNameLocalQrCodeDir


        #region Replace text in a file

        /// <summary>Get content of a file as a string
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_full_filename">Input file name with path</param>
        /// <param name="o_file_as_string">Output string with the content of the input file</param>
        /// <param name="o_error">Error description</param>
        public static bool FileToString(string i_full_filename, out string o_file_as_string, out string o_error)
        {
            o_error = @"";
            o_file_as_string = @"";
            string error_message = "FileUtil.FileToString ";

            if (!File.Exists(i_full_filename))
            {
                o_error = @"FileUtil.FileToString File: " + i_full_filename + @" does not exist.";
                return false;
            }

            try
            {
                using (FileStream file_stream = new FileStream(i_full_filename, FileMode.Open, FileAccess.Read, FileShare.Read))

                using (StreamReader stream_reader = new StreamReader(file_stream))
                {
                    while (stream_reader.Peek() >= 0)
                    {
                        string current_row = stream_reader.ReadLine() + "\n";
                        o_file_as_string = o_file_as_string + current_row;

                    } // while
                } // StreamReader
            } // try

            catch (FileNotFoundException) { o_error = "File not found"; return false; }
            catch (DirectoryNotFoundException) { o_error = error_message + "Directory not found"; return false; }
            catch (InvalidOperationException) { o_error = error_message + "Invalid operation"; return false; }
            catch (InvalidCastException) { o_error = error_message + "invalid cast"; return false; }
            catch (Exception e)
            {
                o_error = error_message + "Unhandled Exception " + e.GetType();
                return false;
            }

            return true;

        } // FileToString


        /// <summary>Replace text in a string (that is the content of a file)
        /// <para>The function does not work with band names (in an XML file) that has &, ' and other such characters</para>
        /// <para>The JazzDokumente_201xx_20yy.xml has coverter these character. Example:</para>
        /// <para>Peter Schärli: &amp;quot;Don&amp;apos;t Change Your Hair For Me&amp;quot;</para>
        /// <para>Even with a find string converted with JazzXml.ModifyWriteXml did not work</para>
        /// <para></para>
        /// </summary>
        /// <param name="io_file_string">Input and output string (that is the content of file)</param>
        /// <param name="i_find_string">Find string</param>
        /// <param name="i_replace_string">Replacement string</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceTextInFileString(ref string io_file_string, string i_find_string, string i_replace_string, out string o_error)
        {
            o_error = @"";

            // TODO Add checks of input data

            string output_string = io_file_string.Replace(i_find_string, i_replace_string);

            io_file_string = output_string;

            return true;

        } // ReplaceTextInFileString

        /// <summary>Replace band name in an XML string (that is the content of a file)
        /// <para>Code assumes that there are twelve (12) concerts</para>
        /// <para></para>
        /// <para>This function is for JazzDokumente_201xx_20yy.xml and the replace string (new band name) is converted with </para>
        /// <para></para>
        /// </summary>
        /// <param name="io_file_string">Input and output string (that is the content of file)</param>
        /// <param name="i_concert_number">Concert (band name) number</param>
        /// <param name="i_replace_string">Replacement string (new band name)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceBandNameInFileString(ref string io_file_string, int i_concert_number, string i_replace_string, out string o_error)
        {
            o_error = @"";

            string find_string_band_name = @"<BandName>";
            string find_string_band_name_end = @"</BandName>";

            string mod_replace_string = JazzXml.ModifyWriteXml(i_replace_string);

            int start_index = 0;

            for (int n_concerts=1; n_concerts<=12;n_concerts++)
            {
                int found_index = io_file_string.IndexOf(find_string_band_name, start_index);

                if (i_concert_number == n_concerts)
                {
                    int end_index = io_file_string.IndexOf(find_string_band_name_end, found_index);
                    int replace_index = found_index + find_string_band_name.Length;

                    string debug_string = io_file_string.Substring(replace_index, end_index - replace_index);

                    int length_replace_string = mod_replace_string.Length;

                    string removed_str = io_file_string.Remove(replace_index, end_index - replace_index);

                    string name_added_str = removed_str.Insert(replace_index, mod_replace_string);

                    io_file_string = name_added_str;
                }
                else
                {
                    start_index = found_index + 1;
                }
            }
            

            return true;

        } // ReplaceBandNameInFileString

        /// <summary>Replace season years in an XML string (that is the content of a file)
        /// <para></para>
        /// <para>This function is for JazzDokumente_201xx_20yy.xml</para>
        /// <para></para>
        /// </summary>
        /// <param name="io_file_string">Input and output string (that is the content of file)</param>
        /// <param name="i_replace_string">Replacement string (season years)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceSeasonYearsInFileString(ref string io_file_string, string i_replace_string, out string o_error)
        {
            o_error = @"";

            string find_string_season_years = @"<SeasonYears>";
            string find_string_season_years_end = @"</SeasonYears>";

            string mod_replace_string = JazzXml.ModifyWriteXml(i_replace_string);

            int start_index = 0;

            int found_index = io_file_string.IndexOf(find_string_season_years, start_index);
            if (found_index < 0)
            {
                o_error = @"FileUtil.ReplaceSeasonYearsInFileString found_index < 0";
                return false;
            }

            int end_index = io_file_string.IndexOf(find_string_season_years_end, found_index);
            if (end_index < 0)
            {
                o_error = @"FileUtil.ReplaceSeasonYearsInFileString end_index < 0";
                return false;
            }

            int replace_index = found_index + find_string_season_years.Length;

            int length_replace_string = mod_replace_string.Length;

            string removed_str = io_file_string.Remove(replace_index, end_index - replace_index);

            string season_years_added_str = removed_str.Insert(replace_index, mod_replace_string);

            io_file_string = season_years_added_str;

            return true;

        } // ReplaceSeasonYearsInFileString

        /// <summary>Create file from string (that is the content of a file)
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_local_file_with_path">Input file name with path</param>
        /// <param name="i_htm_file_string">Input string (that is the content of file)</param>
        /// <param name="o_error">Error description</param>
        public static bool StringToFile(string i_full_filename, string i_file_string, out string o_error)
        {
            o_error = @"";

            // TODO Add checks of input data

            File.WriteAllText(i_full_filename, i_file_string);

            return true;

        } // StringToFile

        #endregion // Replace text in a file

    } // FileUtil
} // namespace
