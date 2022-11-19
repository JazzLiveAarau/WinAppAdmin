using JazzApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Execution functions and parameters for form RequestForm
    /// <para></para>
    /// </summary>
    static public class Request
    {
        #region Names and paths for the XML files holding requests data

        /// <summary>Server path to the XML requests file (JazzAnfragen.xml)</summary>
        private static string m_url_xml_req_files_folder = "XML";
        /// <summary>Get the server path to the XML requests file (JazzAnfragen.xml)</summary>
        public static string ReqFileServerDir { get { return m_url_xml_req_files_folder; } }

        /// <summary>Name of the XML requests file.</summary>
        private static string m_req_xml_filename = "JazzAnfragen.xml";
        /// <summary>Get the name of the XML requests file</summary>
        public static string ReqFileName { get { return m_req_xml_filename; } }

        /// <summary>Local directory for audio data (CDs mit mp3 Dateien)</summary>
        private static string m_name_dir_audio = @"Audio";
        /// <summary>Get the local directory for audio data (CDs mit mp3 Dateien)</summary>
        public static string AudioLocalDir { get { return m_name_dir_audio; } }

        #endregion // Names and paths for the XML files holding requests data

        #region Init, set, get and add functions

        /// <summary>Initialization of requests object corresponding to the XML file JazzAnfragen.xml
        /// <para>Call of JazzXml.InitReq</para>
        /// <para>Please note that JazzXml.InitApplicationAndCurrentSeasonXml is called by the constructor of Main</para>
        /// <para>This is necessary because concert dates and band names are retrieved</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static public bool InitXmlReq(out string o_error)
        {
            o_error = @"";
            bool ret_init = true;

            string error_message = @"";

            if (!JazzXml.InitReq(ReqFileServerDir, ReqFileName, out error_message))
            {
                o_error = @"Request.InitXmlReq JazzXml.InitReq failed " + error_message;
                return false;
            }

            int request_year = JazzXml.GetPublishSeasonStartYearInt() + 1;

            if (!JazzXml.SetXmlDocument(request_year))
            {
                o_error = @"Request.InitXmlReq JazzXml.SetXmlDocument failed for year " + request_year.ToString();

                return false;
            }

            /* Don't understand 2019-01-19 Probably because of Bindella, that they should be able to retriev data until 1/9
            int autumn_year = JazzXml.GetYearAutumnInt();
            int month_september = 9;
            int day_one = 1;

            bool date_passed = TimeUtil.PassedTime(autumn_year, month_september, day_one);
            if (!date_passed)
            {
                request_year = request_year - 1;

                if (!JazzXml.SetXmlDocument(request_year))
                {
                    o_error = @"Request.InitXmlReq JazzXml.SetXmlDocument failed for year " + request_year.ToString();

                    return false;
                }
            }
            */

            return ret_init;

        } // InitXmlReq

        /// <summary>Set combobox requests</summary>
        public static void SetComboBoxRequests(ComboBox i_combo_box)
        {
            string error_message = @"";

            string[] band_names = GetAllBandNames(out error_message);
            if (null == band_names)
                return;
            if (0 == band_names.Length)
                return;

            i_combo_box.Items.Clear();

            i_combo_box.Items.Add(RequestStrings.PromptAddRequest);

            i_combo_box.Items.Add(RequestStrings.PromptSelectRequest);


            for (int index_name = 0; index_name < band_names.Length; index_name++)
            {
                i_combo_box.Items.Add(band_names[index_name]);
            }

            i_combo_box.Text = RequestStrings.PromptSelectRequest;

        } // SetComboBoxRequests

        /// <summary>Get all band names</summary>
        private static string[] GetAllBandNames(out string o_error)
        {
            o_error = @"";
            string[] ret_names = null;
            string error_message = @"";

            JazzReq[] all_reqs = JazzXml.GetAllRequests(out error_message);
            if (null == all_reqs)
            {
                o_error = @"Request.GetAllBandNames JazzXml.GetAllRequests failed " + error_message;
                return ret_names;
            }

            if (all_reqs.Length == 0)
            {
                o_error = @"Request.GetAllBandNames Number of requests is zero (0) ";
                return ret_names;
            }

            ret_names = new string[all_reqs.Length];

            for (int index_req = 0; index_req < all_reqs.Length; index_req++)
            {
                JazzReq current_req = all_reqs[index_req];

                ret_names[index_req] = current_req.BandName;
            }

            return ret_names;

        } // GetAllBandNames

        /// <summary>Get object JazzReq corresponding to the input band name
        /// <para>Call of JazzXml.GetRequest</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_band_name">Band name</param>
        /// <param name="o_error">Error message</param>
        public static JazzReq GetJazzReq(string i_band_name, out string o_error)
        {
            o_error = @"";
            string error_message = @"";
            JazzReq ret_req = JazzXml.GetRequest(i_band_name, out error_message);
            if (null == ret_req)
            {
                o_error = @"Request.GetJazzReq JazzXml.GetRequest failed " + error_message;

                return null;
            }

            return ret_req;

        } // GetJazzReq

        /// <summary>Add JazzReq data to the requests XML object corresponding to file JazzAnfragen.xml
        /// <para>Band name must be unique. Call of TimeUtil.YearMonthDayHourMinSec</para>
        /// <para>Registration year, mont and day is set. Call of TimeUtil.YearMonthDay</para>
        /// <para>JazzReq is added. Call of JazzXml.AddRequest</para>
        /// <para>Please note that the unique registration number is set by JazzXml.AddRequest</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static bool AddReq(out string o_added_band_name, out string o_error)
        {
            o_error = @"";
            o_added_band_name = @"";

            JazzReq add_jazz_req = new JazzReq();

            string date_time = TimeUtil.YearMonthDayHourMinSec();

            string band_name_unique = RequestStrings.DefaultBandName + date_time;
            add_jazz_req.BandName = band_name_unique;

            string reg_year_str = @"";
            string reg_month_str = @"";
            string reg_day_str = @"";

            TimeUtil.YearMonthDay(out reg_year_str, out reg_month_str, out reg_day_str);

            add_jazz_req.RegYear = reg_year_str;
            add_jazz_req.RegMonth = reg_month_str;
            add_jazz_req.RegDay = reg_day_str;

            if (!JazzXml.AddRequest(add_jazz_req, out o_error))
            {
                o_error = @"Request.AddReq JazzXml.AddRequest failed " + o_error;
                return false;
            }

            o_added_band_name = band_name_unique;

            // Programming check
            if (!JazzXml.CheckRequestRegNumber(add_jazz_req.RegNumber, out o_error))
            {
                o_error = @"Request.AddReq Programming error: JazzXml.CheckRequestRegNumber failed " + o_error;
                return false;
            }

            return true;

        } // AddReq

        #endregion // Init, set, get and add functions

        #region Deletion of sound files

        /// <summary>Names of the sound files that shall be deleted</summary>
        private static string[] m_delete_sound_filenames = null;
        /// <summary>Get the names of the sound files that shall be deleted</summary>
        public static string[] GetDeleteSoundFileNames { get { return m_delete_sound_filenames; } }

        /// <summary>Get the names of the sound files that shall be deleted</summary>
        public static void SetDeleteSoundFileNames(string[] i_delete_sound_filenames) { m_delete_sound_filenames = i_delete_sound_filenames; }

        /// <summary>Initialization of array with the sound files that shall be deleted</summary>
        public static void InitDeleteSoundFileNames()
        {
            ArrayList delete_sound_filenames_array = new ArrayList();

            m_delete_sound_filenames = (string[])delete_sound_filenames_array.ToArray(typeof(string));

        } // InitDeleteSoundFileNames

        /// <summary>Add sound file name that shall be deleted</summary>
        public static void AddDeleteSoundFileName(string i_delete_sound_filename)
        {
            ArrayList delete_sound_filenames_array = new ArrayList();

            for (int index_add = 0; index_add < m_delete_sound_filenames.Length; index_add++)
            {
                delete_sound_filenames_array.Add(m_delete_sound_filenames[index_add]);
            }

            delete_sound_filenames_array.Add(i_delete_sound_filename);


            m_delete_sound_filenames = (string[])delete_sound_filenames_array.ToArray(typeof(string));

        } // AddDeleteSoundFileName

        /// <summary>Final deletion of the sound files
        /// <para>Get the files that are marked for delete. Call of GetDeleteSoundFileNames</para>
        /// <para>Delete the files. Calls of JazzFtp.Execute.Run</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static bool FinalDeleteSoundFiles(out string o_error)
        {
            o_error = @"";

            string[] file_names = GetDeleteSoundFileNames;
            if (null == file_names)
            {
                o_error = @"Request.FinalDeleteSoundFiles file_names is null";
                return false;
            }

            if (file_names.Length == 0)
            {
                return true;
            }

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.DeleteFile);

            for (int index_file=0; index_file< file_names.Length; index_file++)
            {
                string path_file_name = file_names[index_file];
                string file_name = Path.GetFileName(path_file_name);
                string file_path = path_file_name.Replace(file_name, "");
                int file_path_length = file_path.Length;
                file_path = file_path.Substring(0, file_path_length - 1);
                // Adds to path ?? !!! string file_path = Path.GetFullPath(path_file_name);

                ftp_input.ExecCase = JazzFtp.Input.Case.DeleteFile; 
                ftp_input.ServerDirectory = file_path;
                ftp_input.ServerFileName = file_name;

                JazzFtp.Result result_delete = JazzFtp.Execute.Run(ftp_input);

                if (!result_delete.Status)
                {
                    o_error = @"Request.FinalDeleteSoundFiles JazzFtp.Execute.Run failed " + result_delete.ErrorMsg;
                    return false;
                }

            } // index_file

            InitDeleteSoundFileNames();

            return true;

        } // FinalDeleteSoundFiles

        /// <summary>Regret deletion of the sound files
        /// <para>Get the files that are marked for delete. Call of GetDeleteSoundFileNames</para>
        /// <para>Rename the files. Calls of JazzFtp.Execute.Run</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static bool RegretDeleteSoundFiles(out string o_error)
        {
            o_error = @"";

            string[] file_names = GetDeleteSoundFileNames;
            if (null == file_names)
            {
                o_error = @"Request.RegretDeleteSoundFiles file_names is null";
                return false;
            }

            if (file_names.Length == 0)
            {
                return true;
            }

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.RenameFile);

            for (int index_file = 0; index_file < file_names.Length; index_file++)
            {
                string path_file_name = file_names[index_file];
                string file_name = Path.GetFileName(path_file_name);
                string file_path = path_file_name.Replace(file_name, "");
                int file_path_length = file_path.Length;
                file_path = file_path.Substring(0, file_path_length - 1);

                string file_rename = file_name.Replace(RequestStrings.RequestExtensionDelete, @"");

                ftp_input.ExecCase = JazzFtp.Input.Case.RenameFile; 
                ftp_input.ServerDirectory = file_path;
                ftp_input.ServerFileName = file_name;
                ftp_input.ServerRenameFileName = file_rename;

                JazzFtp.Result result_delete = JazzFtp.Execute.Run(ftp_input);

                if (!result_delete.Status)
                {
                    o_error = @"Request.RegretDeleteSoundFiles JazzFtp.Execute.Run failed " + result_delete.ErrorMsg;
                    return false;
                }

            } // index_file

            InitDeleteSoundFileNames();

            return true;

        } // RegretDeleteSoundFiles

        #endregion // Deletion of sound files

        #region Create TXT list

        /// <summary>Create requests list as a text file and open Notepad
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="b_private_notes">Flag telling if private notes shall be listed</param>
        /// <param name="b_for_evaluation">Flag telling if only requests for evaluation shall be listed</param>
        /// <param name="b_with_cd_links">Flag telling if CD links shall be added to list</param>
        /// <param name="b_selected_bands">Flag telling if only selected bands shall be listed</param>
        /// <param name="b_with_info_files">Flag telling if information files shall be added to the list</param>
        /// <param name="b_with_video_links">Flag telling if video links shall be added to the list</param>
        /// <param name="b_with_photos">Flag telling if photo files shall be added to the list</param>
        /// <param name="b_sort_date">Flag telling if requests shall be sorted after request date</param>
        /// <param name="o_error">Error message</param>
        public static bool CreateRequestsList(bool b_private_notes, bool b_for_evaluation, bool b_with_cd_links, bool b_selected_bands, bool b_with_info_files, bool b_with_video_links, bool b_with_photos, bool b_sort_date, out string o_error)
        {
            o_error = @"";

            bool b_htm = false;
            bool b_time_stamp_file_name = true;
            JazzReq[] all_reqs = null;
            int tab_1 = -12345;
            int end_line = -12345;
            string header_line = @"";
            string file_name = @"";
            if (!InitRequestsList(b_htm, b_for_evaluation, b_selected_bands, b_sort_date, b_time_stamp_file_name, out all_reqs, out tab_1, out end_line, out header_line, out file_name, out o_error))
            {
                if (o_error.Contains(RequestStrings.ErrMsgNoSelectedRequests))
                {
                    return false; // Keep the original error
                }
                o_error = @"Request.CreateRequestsList InitRequestsList failed " + o_error;
                return false;
            }

            if (all_reqs == null)
            {
                o_error = @"Request.CreateRequestsList all_reqs is null";
                return false;
            }

            int n_all_reqs = all_reqs.Length;

            int n_spaces = -12345;

            string date_str = TimeUtil.YearMonthDayIso();
            n_spaces = tab_1 - date_str.Length;
            header_line = date_str + Spaces(n_spaces) + header_line;

            try
            {
                using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(file_name))
                {
                    outfile.Write(UnderlineHeader(end_line));
                    outfile.Write(System.Environment.NewLine);
                    outfile.Write(header_line);
                    outfile.Write(System.Environment.NewLine);
                    outfile.Write(UnderlineHeader(end_line));
                    outfile.Write(System.Environment.NewLine);

                    outfile.Write(System.Environment.NewLine);

                    for (int index_req=0; index_req<n_all_reqs; index_req++)
                    {
                        JazzReq current_req = all_reqs[index_req];

                        string error_message = @"";
                        if (!RequestBand.ReadPrivateNotes(ref current_req, out error_message))
                        {
                            error_message = @"Request.CreateRequestsList " + error_message;
                            return false;
                        }
                        
                        if (!b_for_evaluation)
                        {
                            ReqRecordLines(outfile, current_req, tab_1, b_private_notes, b_with_cd_links, b_with_info_files, b_with_video_links, b_with_photos, b_selected_bands, end_line);
                        }
                        else
                        {
                            if (current_req.ToBeEvaluatedBoolean)
                            {
                                ReqRecordLines(outfile, current_req, tab_1, b_private_notes, b_with_cd_links, b_with_info_files, b_with_video_links, b_with_photos, b_selected_bands, end_line);
                            }
                        }
                        

                    } // index_req


                    outfile.Write(Underline(end_line));
                    outfile.Write(System.Environment.NewLine);

                }
            } // try

            catch (Exception e)
            {
                o_error = " Unhandled Exception " + e.GetType() + " occurred at " + DateTime.Now + "!";
                return false;
            }

            System.Diagnostics.Process.Start("notepad.exe", file_name);
            //System.Diagnostics.Process.Start("winword.exe", file_name);


            return true;

        } // CreateRequestsList

        /// <summary>Add lines for one request record</summary>
        private static void ReqRecordLines(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, bool b_with_cd_links, bool b_with_info_files, bool b_with_video_links, bool b_with_photos, bool b_selected_bands, int i_end_line)
        {
            bool b_htm = false;

            ReqHeaderLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);

            ReqConcertNumberLine(i_outfile, i_current_req, i_tab_1, b_selected_bands, i_end_line, b_htm);

            ReqCommentsLines(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);

            ReqPrivateNotesLines(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);

            // No longer used ReqSoundSampleLinkLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
            // No longer used ReqWebsiteLinkLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);

            if (b_with_video_links)
            {
                ReqLinkOneLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkTwoLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkThreeLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkFourLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkFiveLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkSixLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkSevenLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkEightLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkNineLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
            }

            if (b_with_video_links)
            {
                ReqInfoFileOneLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqInfoFileTwoLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqInfoFileThreeLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
            }

            ReqAudioOneLine(i_outfile, i_current_req, i_tab_1, b_private_notes, b_with_cd_links, i_end_line, b_htm);

            ReqAudioTwoLine(i_outfile, i_current_req, i_tab_1, b_private_notes, b_with_cd_links, i_end_line, b_htm);

            ReqAudioThreeLine(i_outfile, i_current_req, i_tab_1, b_private_notes, b_with_cd_links, i_end_line, b_htm);

            if (b_with_photos)
            {
                ReqPhotoOneLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoTwoLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoThreeLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoFourLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoFiveLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoSixLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoSevenLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoEightLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoNineLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
            }

        } // ReqRecordLines

        #endregion // Create TXT list

        #region Create HTM list

        /// <summary>Create requests list as an html file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="b_private_notes">Flag telling if private notes shall be listed</param>
        /// <param name="b_for_evaluation">Flag telling if only requests for evaluation shall be listed</param>
        /// <param name="b_with_cd_links">Flag telling if CD links shall be added to list</param>
        /// <param name="b_selected_bands">Flag telling if only selected bands shall be listed</param>
        /// <param name="b_with_info_files">Flag telling if information files shall be added to the list</param>
        /// <param name="b_with_video_links">Flag telling if video links shall be added to the list</param>
        /// <param name="b_with_photos">Flag telling if photo files shall be added to the list</param>
        /// <param name="b_sort_date">Flag telling if requests shall be sorted after request date</param>
        /// <param name="b_time_stamp_file_name">Flag telling if a time stamp (yyyy-mm-dd) shall be added to the file name</param>
        /// <param name="o_file_name">Output file name with path</param>
        /// <param name="o_error">Error message</param>
        public static bool CreateHtmlRequestsList(bool b_private_notes, bool b_for_evaluation, bool b_with_cd_links, bool b_selected_bands, bool b_with_info_files, bool b_with_video_links, bool b_with_photos, bool b_sort_date, bool b_time_stamp_file_name, out string o_file_name, out string o_error)
        {
            o_error = @"";
            o_file_name = @"";

            bool b_htm = true;

            JazzReq[] all_reqs = null;
            int tab_1 = -12345;
            int end_line = -12345;
            string header_line = @"";
            string file_name = @"";
            if (!InitRequestsList(b_htm, b_for_evaluation, b_selected_bands, b_sort_date, b_time_stamp_file_name, out all_reqs, out tab_1, out end_line, out header_line, out file_name, out o_error))
            {
                if (o_error.Contains(RequestStrings.ErrMsgNoSelectedRequests))
                {
                    return false; // Keep the original error
                }
                o_error = @"Request.CreateHtmlRequestsList InitRequestsList failed " + o_error;
                return false;
            }

            if (all_reqs == null)
            {
                o_error = @"Request.CreateHtmlRequestsList all_reqs is null";
                return false;
            }

            int n_all_reqs = all_reqs.Length;

            int n_spaces = -12345;

            string date_str = TimeUtil.YearMonthDayIso();
            n_spaces = tab_1 - date_str.Length;
            header_line = date_str + HtmlSpaces(n_spaces) + header_line;
            FileStream file_stream = null;

            try
            {
                // https://msdn.microsoft.com/de-de/library/system.text.encoding(v=vs.110).aspx
                // https://msdn.microsoft.com/en-us/library/72d9f8d5(v=vs.110).aspx
                // Encoding encoding_unicode = Encoding.GetEncoding(65001); // Unicode (UTF-8)

                file_stream = new FileStream(file_name, FileMode.Create);
                int buffer_size = 512;
                using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(file_stream, Encoding.UTF8, buffer_size))
                {
                    HtmlHeader(outfile, header_line);

                    for (int index_req = 0; index_req < n_all_reqs; index_req++)
                    {
                        JazzReq current_req = all_reqs[index_req];

                        string error_message = @"";
                        if (!RequestBand.ReadPrivateNotes(ref current_req, out error_message))
                        {
                            error_message = @"Request.CreateHtmlRequestsList " + error_message;
                            return false;
                        }

                        if (!b_for_evaluation)
                        {
                            ReqHtmlRecordLines(outfile, current_req, tab_1, b_private_notes, b_with_cd_links, b_with_info_files, b_with_video_links, b_with_photos, b_selected_bands, end_line);
                        }
                        else
                        {
                            if (current_req.ToBeEvaluatedBoolean)
                            {
                                ReqHtmlRecordLines(outfile, current_req, tab_1, b_private_notes, b_with_cd_links, b_with_info_files, b_with_video_links, b_with_photos, b_selected_bands, end_line);
                            }
                        }


                    } // index_req


                    HtmlEndLines(outfile);

                }
            } // try

            catch (Exception e)
            {
                o_error = " Unhandled Exception " + e.GetType() + " occurred at " + DateTime.Now + "!";
                return false;
            }
            finally
            {
                if (file_stream != null)
                    file_stream.Dispose();
            }

            o_file_name = file_name;

            return true;

        } // CreateHtmlRequestsList

        /// <summary>Add Html lines for one request record</summary>
        private static void ReqHtmlRecordLines(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, bool b_with_cd_links, bool b_with_info_files, bool b_with_video_links, bool b_with_photos, bool b_selected_bands, int i_end_line)
        {
            bool b_htm = true;

            ReqHeaderLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);

            ReqCommentsLines(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);

            ReqConcertNumberLine(i_outfile, i_current_req, i_tab_1, b_selected_bands, i_end_line, b_htm);

            ReqPrivateNotesLines(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);

            // No longer used ReqSoundSampleLinkLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
            // No longer used ReqWebsiteLinkLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);

            if (b_with_video_links)
            {
                ReqLinkOneLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkTwoLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkThreeLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkFourLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkFiveLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkSixLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkSevenLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkEightLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqLinkNineLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
            }

            if (b_with_info_files)
            {
                ReqInfoFileOneLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqInfoFileTwoLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
                ReqInfoFileThreeLine(i_outfile, i_current_req, i_tab_1, b_private_notes, i_end_line, b_htm);
            }

            ReqAudioOneLine(i_outfile, i_current_req, i_tab_1, b_private_notes, b_with_cd_links, i_end_line, b_htm);

            ReqAudioTwoLine(i_outfile, i_current_req, i_tab_1, b_private_notes, b_with_cd_links, i_end_line, b_htm);

            ReqAudioThreeLine(i_outfile, i_current_req, i_tab_1, b_private_notes, b_with_cd_links, i_end_line, b_htm);

            if (b_with_photos)
            {
                ReqPhotoOneLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoTwoLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoThreeLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoFourLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoFiveLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoSixLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoSevenLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoEightLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
                ReqPhotoNineLine(i_outfile, i_current_req, i_tab_1, i_end_line, b_htm);
            }

        } // ReqHtmlRecordLines

        #endregion // Create HTM list

        #region Check functions

        /// <summary>Get a list of directory names for requests that have been deleted
        /// <para>1. Get the last request number. Call of JazzXml.GetReqLastRegNumber</para>
        /// <para>3. Create local array req_exists and set initial value to false.</para>
        /// <para>4. Get all existing (not deleted) requests. Call of JazzXml.GetAllRequests</para>
        /// <para>5. Loop for all elements in array req_exists</para>
        /// <para>5.1. Set value to true if request exists, i.e. request has not been deleted</para>
        /// <para>6. Create output array with directory names for requests that have been deleted</para>
        /// </summary>
        /// <param name="o_deleted_request_dir_names">Array with directory names for requests that have been deleted</param>
        /// <param name="o_error">Error message</param>
        public static bool GetDeletedRequestDirNames(out string[] o_deleted_request_dir_names, out string o_error)
        {
            o_deleted_request_dir_names = null;
            o_error = @"";

            string reg_number_last_str = JazzXml.GetReqLastRegNumber();
            int reg_number_last = JazzUtils.StringToInt(reg_number_last_str);
            if (reg_number_last <= 0)
            {
                o_error = @"Request.GetDeletedRequestDirNames reg_number_last_str <= 0 ";
                return false;
            }

            bool[] req_exists = new bool[reg_number_last];
            for (int index_init = 0; index_init < reg_number_last; index_init++)
            {
                req_exists[index_init] = false;
            }

            JazzReq[] all_requests = JazzXml.GetAllRequests(out o_error);
            if (0 == all_requests.Length)
            {
                o_error = @"Request.GetDeletedRequestDirNames JazzXml.GetAllRequests failed " + o_error;
                return false;
            }

            for (int index_req = 0; index_req < all_requests.Length; index_req++)
            {
                JazzReq current_req = all_requests[index_req];
                int reg_number = current_req.RegNumberInt;
                int index_exists = reg_number - 1;
                req_exists[index_exists] = true;
            }

            JazzReq dummy_req = new JazzReq();

            ArrayList name_array = new ArrayList();

            for (int index_name = 0; index_name < reg_number_last; index_name++)
            {
                if (!req_exists[index_name])
                {
                    int not_existing_reg_number = index_name + 1;

                    dummy_req.RegNumberInt = not_existing_reg_number;

                    string reg_dir = dummy_req.RegNumberName();

                    name_array.Add(reg_dir);

                }
            }

            o_deleted_request_dir_names = (string[])name_array.ToArray(typeof(string));

            return true;

        } // GetDeletedRequestDirNames

        /// <summary>Get a list of not deleted sound files
        /// <para>1. Get a list of directory names for requests that have been deleted. Call of GetDeletedRequestDirNames.</para>
        /// <para>2. Loop for all directory names</para>
        /// <para>2.1. Determine if audio directory exists and if it is empty. Call of AudioDirExists.</para>
        /// <para>2.2. Determine if audio files and add existing to the output array. Calls of AudioDirExists and GetAudioFileNames</para>
        /// <para>Please note that also other (debug) arrays are created but not used</para>
        /// </summary>
        /// <param name="o_not_deleted_sound_file_names">Array with sound file names that should have been deleted</param>
        /// <param name="i_text_box">Textbox for progress messages</param>
        /// <param name="o_error">Error message</param>
        public static bool GetNotDeletedAudioFileNames(out string[] o_not_deleted_sound_file_names, TextBox i_text_box, out string o_error)
        {
            o_not_deleted_sound_file_names = null;
            o_error = @"";

            i_text_box.Text = @"Enter GetNotDeletedAudioFileNames";
            i_text_box.Refresh();

            string[] deleted_request_dir_names = null;

            if (!GetDeletedRequestDirNames(out deleted_request_dir_names, out o_error))
            {
                o_error = @"Request.GetDeletedRequestDirNames GetDeletedRequestDirNames failed " + o_error;
                return false;
            }

            if (null == deleted_request_dir_names)
            {
                o_error = @"Request.GetDeletedRequestDirNames deleted_request_dir_names is null";
                return false;
            }

            ArrayList existing_audio_dirs_array = new ArrayList();
            ArrayList existing_audio_one_dirs_array = new ArrayList();
            ArrayList existing_audio_two_dirs_array = new ArrayList();
            ArrayList existing_audio_three_dirs_array = new ArrayList();
            ArrayList not_deleted_audio_file_names_array = new ArrayList();

            for (int index_dir=0; index_dir< deleted_request_dir_names.Length; index_dir++)
            {
                string dir_name = deleted_request_dir_names[index_dir];
                int audio_dir_number = 0;
                string server_audio_path = @"";
                bool dir_audio_exists = false;
                bool dir_audio_is_empty = false;

                if (!AudioDirExists(dir_name, audio_dir_number, out server_audio_path, out dir_audio_exists, out dir_audio_is_empty, out o_error))
                {
                    o_error = @"Request.GetNotDeletedAudioFileNames AudioDirExists (Audio) failed " + o_error;
                    return false;
                }

                i_text_box.Text = @"Directory " + server_audio_path + @" Exists= " + dir_audio_exists.ToString() + @" Empty= " + dir_audio_is_empty.ToString();
                i_text_box.Refresh();

                if (dir_audio_exists)
                {
                    existing_audio_dirs_array.Add(server_audio_path);
                }
              
                string server_audio_one_path = @"";
                bool dir_audio_one_exists = false;
                bool dir_audio_one_is_empty = false;

                string server_audio_two_path = @"";
                bool dir_audio_two_exists = false;
                bool dir_audio_two_is_empty = false;

                string server_audio_three_path = @"";
                bool dir_audio_three_exists = false;
                bool dir_audio_three_is_empty = false;

                if (dir_audio_exists && !dir_audio_is_empty)
                {
                    audio_dir_number = 1;
                    if (!AudioDirExists(dir_name, audio_dir_number, out server_audio_one_path, out dir_audio_one_exists, out dir_audio_one_is_empty, out o_error))
                    {
                        o_error = @"Request.GetNotDeletedAudioFileNames AudioDirExists (AudioOne) failed " + o_error;
                        return false;
                    }

                    if (dir_audio_one_exists)
                    {
                        existing_audio_one_dirs_array.Add(server_audio_one_path);
                    }

                    if (dir_audio_one_exists && !dir_audio_one_is_empty)
                    {
                        if (!GetAudioFileNames(ref not_deleted_audio_file_names_array, server_audio_one_path, out o_error))
                        {
                            o_error = @"Request.GetNotDeletedAudioFileNames GetAudioFileNames (AudioOne) failed " + o_error;
                            return false;
                        }
                    }

                    audio_dir_number = 2;
                    if (!AudioDirExists(dir_name, audio_dir_number, out server_audio_two_path, out dir_audio_two_exists, out dir_audio_two_is_empty, out o_error))
                    {
                        o_error = @"Request.GetNotDeletedAudioFileNames AudioDirExists (AudioTwo) failed " + o_error;
                        return false;
                    }

                    if (dir_audio_two_exists)
                    {
                        existing_audio_two_dirs_array.Add(server_audio_two_path);
                    }

                    if (dir_audio_two_exists && !dir_audio_two_is_empty)
                    {
                        if (!GetAudioFileNames(ref not_deleted_audio_file_names_array, server_audio_two_path, out o_error))
                        {
                            o_error = @"Request.GetNotDeletedAudioFileNames GetAudioFileNames (AudioTwo) failed " + o_error;
                            return false;
                        }
                    }

                    audio_dir_number = 3;
                    if (!AudioDirExists(dir_name, audio_dir_number, out server_audio_three_path, out dir_audio_three_exists, out dir_audio_three_is_empty, out o_error))
                    {
                        o_error = @"Request.GetNotDeletedAudioFileNames AudioDirExists (AudioThree) failed " + o_error;
                        return false;
                    }

                    if (dir_audio_three_exists)
                    {
                        existing_audio_three_dirs_array.Add(server_audio_three_path);
                    }

                    if (dir_audio_three_exists && !dir_audio_three_is_empty)
                    {
                        if (!GetAudioFileNames(ref not_deleted_audio_file_names_array, server_audio_three_path, out o_error))
                        {
                            o_error = @"Request.GetNotDeletedAudioFileNames GetAudioFileNames (AudioThree) failed " + o_error;
                            return false;
                        }
                    }

                } // dir_audio_exists && !dir_audio_is_empty

            } // index_dir

            string[] existing_audio_dirs = (string[])existing_audio_dirs_array.ToArray(typeof(string));
            string[] existing_audio_one_dirs = (string[])existing_audio_one_dirs_array.ToArray(typeof(string));
            string[] existing_audio_two_dirs = (string[])existing_audio_two_dirs_array.ToArray(typeof(string));
            string[] existing_audio_three_dirs = (string[])existing_audio_three_dirs_array.ToArray(typeof(string));

            o_not_deleted_sound_file_names = (string[])not_deleted_audio_file_names_array.ToArray(typeof(string));

            i_text_box.Text = @"The number of not deleted sound files is " + o_not_deleted_sound_file_names.Length.ToString();
            i_text_box.Refresh();

            return true;

        } // GetNotDeletedAudioFileNames

        /// <summary>Get a list of not deleted sound files for a given directory
        /// <para>1. Get file names of the directory. Call of JazzFtp.Execute.Run for Input.Case.GetDirFileNames.</para>
        /// <para>2. Add paths to the file name and add to the output array</para>
        /// </summary>
        /// <param name="io_not_deleted_audio_file_names_array">Array with sound file names that should have been deleted</param>
        /// <param name="i_server_audio_xxx_path">Server directory path</param>
        /// <param name="o_error">Error message</param>
        private static bool GetAudioFileNames(ref ArrayList io_not_deleted_audio_file_names_array, string i_server_audio_xxx_path, out string o_error)
        {
            o_error = @"";

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.GetDirFileNames);

            ftp_input.ServerDirectory = i_server_audio_xxx_path;

            JazzFtp.Result result_filenames = JazzFtp.Execute.Run(ftp_input);
            if (!result_filenames.Status)
            {
                o_error = @"Request.GetAudioFileNames JazzFtp.Execute.Run failed " + o_error;
                return false;
            }

            string[] file_names = result_filenames.ArrayStr;
            int n_names = file_names.Length;
            if (0 == n_names)
            {
                return true;
            }

            
            for (int index_name = 0; index_name < n_names; index_name++)
            {
                string current_name = file_names[index_name];

                string file_name_with_path = i_server_audio_xxx_path + @"/" + current_name;

                io_not_deleted_audio_file_names_array.Add(file_name_with_path);
            }

            return true;

        } // GetAudioFileNames

        /// <summary>Determines if an audio directory (e.g. REG00123) exists and if it empty
        /// <para>Please note that check directory is e.g. REG00123 or AudioOne, AudioTwo or AudioThree in e.g. REG00123</para>
        /// <para>1. Set full name for the directory, which is dependent on i_audio_dir_number (case)</para>
        /// <para>2. Check if directory exists. Call of JazzFtp.Execute.Run for Input.Case.DirExists </para>
        /// <para>3. Determine if directory is empty. Call of JazzFtp.Execute.Run for Input.Case.DirEmpty</para>
        /// </summary>
        /// <param name="i_dir_name">Directory name e.g. REG00123</param>
        /// <param name="i_audio_dir_number">Defines the directory Eq. 0: Audio Eq. 1: Audio/AudioOne Eq. 2: Audio/AudioTwo Eq. 3: Audio/AudioThree </param>
        /// <param name="o_server_path">Server directory</param>
        /// <param name="o_dir_exists">Flag telling if directory exists</param>
        /// <param name="o_dir_is_empty"Flag telling if directory is empty</param>
        /// <param name="o_error">Error message</param>
        private static bool AudioDirExists(string i_dir_name, int i_audio_dir_number, out string o_server_path, out bool o_dir_exists, out bool o_dir_is_empty, out string o_error)
        {
            o_server_path = @"";
            o_dir_exists = false;
            o_dir_is_empty = false;
            o_error = @"";

            if (i_audio_dir_number < 0 || i_audio_dir_number > 3)
            {
                o_error = @"Request.AudioDirExists i_audio_dir_number= " + i_audio_dir_number.ToString() + @" is not 0, 1, 2 or 3";
                return false;
            }

            string server_path = @"www/" + RequestStrings.DirNameAudio + @"/" + i_dir_name;
            if (1 == i_audio_dir_number)
            {
                server_path = server_path + @"/" + RequestStrings.DirNameAudioOne;
            }
            else if (2 == i_audio_dir_number)
            {
                server_path = server_path + @"/" + RequestStrings.DirNameAudioTwo;
            }
            else if (3 == i_audio_dir_number)
            {
                server_path = server_path + @"/" + RequestStrings.DirNameAudioThree;
            }

            o_server_path = server_path;

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.DirExists);
            ftp_input.ServerDirectory = server_path;

            JazzFtp.Result result_exists = JazzFtp.Execute.Run(ftp_input);
            if (!result_exists.Status)
            {
                o_error = @"Request.AudioDirExists JazzFtp.Execute.Run (DirExists) failed " + o_error;
                return false;
            }

            if (!result_exists.BoolResult)
            {
                o_dir_exists = false;

                return true;
            }
            else
            {
                o_dir_exists = true;
            }

            ftp_input.ExecCase = JazzFtp.Input.Case.DirEmpty;

            JazzFtp.Result result_empty = JazzFtp.Execute.Run(ftp_input);
            if (!result_empty.Status)
            {
                o_error = @"Request.AudioDirExists JazzFtp.Execute.Run (DirEmpty) failed " + o_error;
                return false;
            }

            if (result_empty.BoolResult)
            {
                o_dir_is_empty = true;
            }
            else
            {
                o_dir_is_empty = false;
            }


            return true;

        } // AudioDirExists

        #endregion // Check functions

        #region Add header, comments and private note lines

        /// <summary>Add the request header line</summary>
        private static void ReqHeaderLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            i_outfile.Write(Underline(i_end_line) + HtmlEndOfLine(i_htm));
            i_outfile.Write(System.Environment.NewLine);

            string req_date_str = i_current_req.RegDate();
            int n_spaces = i_tab_1 - req_date_str.Length;

            string spaces_string = Spaces(n_spaces);
            if (i_htm)
                spaces_string = HtmlSpaces(n_spaces);

            string req_header_line = req_date_str + spaces_string + i_current_req.BandName;

            i_outfile.Write(HtmlBold(req_header_line, i_htm) + HtmlEndOfLine(i_htm));
            i_outfile.Write(System.Environment.NewLine);

        } // ReqHeaderLine

        /// <summary>Adds request concert number line</summary>
        private static void ReqConcertNumberLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_selected_bands, int i_end_line, bool i_htm)
        {
            if (!b_selected_bands)
                return;

            if (i_current_req.ConcertNumber.Length == 0)
                return;

            string concert_number_str = i_current_req.ConcertNumber;
            int concert_number_int = i_current_req.ConcertNumberInt;
            if (concert_number_int < 0)
                return;

            string number_date_band = GetConcertNumberDateBandName(concert_number_int);

            string concert_str = RequestStrings.LabelConcertNumber;
            int n_spaces = i_tab_1 - concert_str.Length;

            string req_concert_number_line = concert_str + Spaces(n_spaces) + number_date_band;
            if (i_htm)
            {
                req_concert_number_line = concert_str + HtmlSpaces(n_spaces) + number_date_band;
            }

            i_outfile.Write(req_concert_number_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

        } // ReqConcertNumberLine

        /// <summary>Returns concert number, date and band name</summary>
        private static string GetConcertNumberDateBandName(int i_concert_number)
        {
            // It doesn't help adding space for Arial
            string number_str = i_concert_number.ToString();
            if (i_concert_number > 0 && i_concert_number <= 9)
                number_str = number_str + @" ";

            string day_str = JazzXml.GetDay(i_concert_number);
            if (1 == day_str.Length)
                day_str = @"0" + day_str;

            string month_str = JazzXml.GetMonth(i_concert_number);
            if (1 == month_str.Length)
                month_str = @"0" + month_str;

            string date_str = JazzXml.GetYear(i_concert_number) + @"-" + month_str + @"-" + day_str;

            return number_str + @"   Datum: " + date_str + @"  Bandname: " + JazzXml.GetBandName(i_concert_number);

        } // GetConcertNumberDateBandName

        /// <summary>Adds request comments lines</summary>
        private static void ReqCommentsLines(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            if (i_current_req.Comments.Length == 0)
                return;

            string comments_str = RequestStrings.LabelComments;
            int n_spaces = i_tab_1 - comments_str.Length;

            string[] comment_lines = StringToMultipleLines(i_current_req.Comments, i_tab_1, i_end_line);
            if (null == comment_lines || comment_lines.Length == 0)
            { 
                return;
            }

            string spaces_string = Spaces(n_spaces);
            if (i_htm)
                spaces_string = HtmlSpaces(n_spaces);

            string spaces_tab_1_string = Spaces(i_tab_1);
            if (i_htm)
                spaces_tab_1_string = HtmlSpaces(i_tab_1);

            string req_comments_line = comments_str + spaces_string + comment_lines[0];

            i_outfile.Write(req_comments_line + HtmlEndOfLine(i_htm));
            i_outfile.Write(System.Environment.NewLine);

            for (int index_line=1; index_line< comment_lines.Length; index_line++)
            {
                req_comments_line = spaces_tab_1_string + comment_lines[index_line];

                i_outfile.Write(req_comments_line + HtmlEndOfLine(i_htm));
                i_outfile.Write(System.Environment.NewLine);
            }            

        } // ReqCommentsLines

        /// <summary>Adds request private notes lines</summary>
        private static void ReqPrivateNotesLines(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            if (!b_private_notes)
                return;

            if (i_current_req.PrivateNotes.Length == 0)
                return;

            string private_notes_str = RequestStrings.LabelPrivateNotes;
            int n_spaces = i_tab_1 - private_notes_str.Length;

            string[] private_notes_lines = StringToMultipleLines(i_current_req.PrivateNotes, i_tab_1, i_end_line);
            if (null == private_notes_lines || private_notes_lines.Length == 0)
            {
                return;
            }

            string spaces_string = Spaces(n_spaces);
            if (i_htm)
                spaces_string = HtmlSpaces(n_spaces);

            string spaces_tab_1_string = Spaces(i_tab_1);
            if (i_htm)
                spaces_tab_1_string = HtmlSpaces(i_tab_1);

            string req_private_notes_line = private_notes_str + spaces_string + private_notes_lines[0];

            i_outfile.Write(req_private_notes_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

            for (int index_line = 1; index_line < private_notes_lines.Length; index_line++)
            {
                req_private_notes_line = spaces_tab_1_string + private_notes_lines[index_line];

                i_outfile.Write(req_private_notes_line);
                i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));
            }

        } // ReqPrivateNotesLines

        /// <summary>Adds request sound sample link line No longer used</summary>
        private static void ReqSoundSampleLinkLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        { 
            if (i_current_req.SoundSample.Length == 0)
                return;

            string sound_sample_str = RequestStrings.LabelVideoLink;
            int n_spaces = i_tab_1 - sound_sample_str.Length;

            string req_sound_sample_line = sound_sample_str + Spaces(n_spaces) + i_current_req.SoundSample;
            if (i_htm)
            {
                bool b_web_page = true;
                req_sound_sample_line = sound_sample_str + HtmlSpaces(n_spaces) + HtmlLink(i_current_req.SoundSample, b_web_page);
            }

            i_outfile.Write(req_sound_sample_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

        } // ReqSoundSampleLinkLine

        /// <summary>Adds request website link line No longer used</summary>
        private static void ReqWebsiteLinkLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            if (i_current_req.BandWebsite.Length == 0)
                return;

            string website_str = RequestStrings.LabelWebsiteLink;
            int n_spaces = i_tab_1 - website_str.Length;

            string req_web_site_line = website_str + Spaces(n_spaces) + i_current_req.BandWebsite;
            if (i_htm)
            {
                bool b_web_page = true;
                req_web_site_line = website_str + HtmlSpaces(n_spaces) + HtmlLink(i_current_req.BandWebsite, b_web_page);
            }

            i_outfile.Write(req_web_site_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

        } // ReqWebsiteLinkLine

        #endregion // Add header, comments and private note lines

        #region Add audio lines

        /// <summary>Adds request audio one line</summary>
        private static void ReqAudioOneLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, bool b_with_cd_links, int i_end_line, bool i_htm)
        {
            if (i_current_req.AudioOneCd.Length == 0)
                return;

            string audio_one_str = RequestStrings.LabelAudioOne;
            int n_spaces = i_tab_1 - audio_one_str.Length;

            string req_audio_one_line = audio_one_str + Spaces(n_spaces) + i_current_req.AudioOneCd;
            if (i_htm)
            {
                req_audio_one_line = audio_one_str + HtmlSpaces(n_spaces) + i_current_req.AudioOneCd;
            }

            i_outfile.Write(req_audio_one_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

            if (!b_with_cd_links)
                return;

            int audio_number = 1;
            AddCdLines(i_outfile, i_current_req, audio_number, i_tab_1, i_end_line, i_htm);

        } // ReqAudioOneLine

        /// <summary>Adds request audio two line</summary>
        private static void ReqAudioTwoLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, bool b_with_cd_links, int i_end_line, bool i_htm)
        {
            if (i_current_req.AudioTwoCd.Length == 0)
                return;

            string audio_two_str = RequestStrings.LabelAudioTwo;
            int n_spaces = i_tab_1 - audio_two_str.Length;

            string req_audio_two_line = audio_two_str + Spaces(n_spaces) + i_current_req.AudioTwoCd;
            if (i_htm)
            {
                req_audio_two_line = audio_two_str + HtmlSpaces(n_spaces) + i_current_req.AudioTwoCd;
            }

            i_outfile.Write(req_audio_two_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

            if (!b_with_cd_links)
                return;

            int audio_number = 2;
            AddCdLines(i_outfile, i_current_req, audio_number, i_tab_1, i_end_line, i_htm);

        } // ReqAudioTwoLine

        /// <summary>Adds request audio three line</summary>
        private static void ReqAudioThreeLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, bool b_with_cd_links, int i_end_line, bool i_htm)
        {
            if (i_current_req.AudioThreeCd.Length == 0)
                return;

            string audio_three_str = RequestStrings.LabelAudioThree;
            int n_spaces = i_tab_1 - audio_three_str.Length;

            string req_audio_three_line = audio_three_str + Spaces(n_spaces) + i_current_req.AudioThreeCd;
            if (i_htm)
            {
                req_audio_three_line = audio_three_str + HtmlSpaces(n_spaces) + i_current_req.AudioThreeCd;
            }

            i_outfile.Write(req_audio_three_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

            if (!b_with_cd_links)
                return;

            int audio_number = 3;
            AddCdLines(i_outfile, i_current_req, audio_number, i_tab_1, i_end_line, i_htm);

        } // ReqAudioThreeLine

        /// <summary>Adds request audio line</summary>
        private static void ReqAudioLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line)
        {
            string all_cd_names = @"";
            if (i_current_req.AudioOneCd.Length == 0 && i_current_req.AudioTwoCd.Length == 0 && i_current_req.AudioThreeCd.Length == 0)
            {
                return;
            }
            else if (i_current_req.AudioOneCd.Length > 0 && i_current_req.AudioTwoCd.Length > 0 && i_current_req.AudioThreeCd.Length > 0)
            {
                all_cd_names = i_current_req.AudioOneCd + ", " + i_current_req.AudioTwoCd + ", " + i_current_req.AudioThreeCd;
            }
            else if (i_current_req.AudioTwoCd.Length > 0 && i_current_req.AudioThreeCd.Length > 0)
            {
                all_cd_names = i_current_req.AudioTwoCd + ", " + i_current_req.AudioThreeCd;
            }
            else if (i_current_req.AudioOneCd.Length > 0 && i_current_req.AudioThreeCd.Length > 0)
            {
                all_cd_names = i_current_req.AudioOneCd + ", " + i_current_req.AudioThreeCd;
            }
            else if (i_current_req.AudioOneCd.Length > 0)
            {
                all_cd_names = i_current_req.AudioOneCd;
            }
            else if (i_current_req.AudioTwoCd.Length > 0)
            {
                all_cd_names = i_current_req.AudioTwoCd;
            }
            else if (i_current_req.AudioThreeCd.Length > 0)
            {
                all_cd_names = i_current_req.AudioThreeCd;
            }
            else
            {
                all_cd_names = @"Requests.ReqAudioLine Programming error";
            }

            if (all_cd_names.Length == 0)
                return; // Programming error


            string website_str = RequestStrings.LabelAudio;
            int n_spaces = i_tab_1 - website_str.Length;

            string req_audio_line = website_str + Spaces(n_spaces) + all_cd_names;

            i_outfile.Write(req_audio_line);
            i_outfile.Write(System.Environment.NewLine);

        } // ReqAudioLine

        /// <summary>Adds request audio one line</summary>
        private static void AddCdLines(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_audio_number, int i_tab_1, int i_end_line, bool i_htm)
        {
            string server_dir = @"";
            string[] sound_files = null;
            string error_message = @"";
            if (!RequestBand.DownloadAudioGetFileNames(i_current_req, i_audio_number, out server_dir, out sound_files, out error_message))
            {
                return;
            }

            if (sound_files == null)
                return;
            string jazz_url = @"http://www.jazzliveaarau.ch";
            for (int index_file = 0; index_file < sound_files.Length; index_file++)
            {
                string server_dir_without_www = server_dir.Substring(4);
                string url_file = jazz_url + server_dir_without_www + sound_files[index_file];

                string url_line = Spaces(i_tab_1) + url_file;
                if (i_htm)
                {
                    bool b_web_page = false;
                    url_line = HtmlSpaces(i_tab_1) + HtmlLink(url_line, b_web_page);
                }


                i_outfile.Write(url_line);
                i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));
            }

        } // AddCdLines

        #endregion // Add audio lines

        #region Add information file lines

        /// <summary>Adds request information file one </summary>
        private static void ReqInfoFileOneLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            if (i_current_req.InfoOne.Length == 0)
                return;

            int file_number = 1;

            string info_file_1_str = RequestStrings.LabelInfoFileOne;
            int n_spaces = i_tab_1 - info_file_1_str.Length;

            string req_info_file_1_line = info_file_1_str + Spaces(n_spaces) + i_current_req.InfoOne;
            if (i_htm)
            {
                req_info_file_1_line = info_file_1_str + HtmlSpaces(n_spaces) + InfoFileLink(i_current_req, file_number);
            }

            i_outfile.Write(req_info_file_1_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

        } // ReqInfoFileOneLine

        /// <summary>Adds request information file two </summary>
        private static void ReqInfoFileTwoLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            if (i_current_req.InfoTwo.Length == 0)
                return;

            int file_number = 2;

            string info_file_2_str = RequestStrings.LabelInfoFileTwo;
            int n_spaces = i_tab_1 - info_file_2_str.Length;

            string req_info_file_2_line = info_file_2_str + Spaces(n_spaces) + i_current_req.InfoTwo;
            if (i_htm)
            {
                req_info_file_2_line = info_file_2_str + HtmlSpaces(n_spaces) + InfoFileLink(i_current_req, file_number);
            }

            i_outfile.Write(req_info_file_2_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

        } // ReqInfoFileTwoLine

        /// <summary>Adds request information file three </summary>
        private static void ReqInfoFileThreeLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            if (i_current_req.InfoThree.Length == 0)
                return;

            int file_number = 3;

            string info_file_3_str = RequestStrings.LabelInfoFileThree;
            int n_spaces = i_tab_1 - info_file_3_str.Length;

            string req_info_file_3_line = info_file_3_str + Spaces(n_spaces) + i_current_req.InfoThree;
            if (i_htm)
            {
                req_info_file_3_line = info_file_3_str + HtmlSpaces(n_spaces) + InfoFileLink(i_current_req, file_number);
            }

            i_outfile.Write(req_info_file_3_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

        } // ReqInfoFileTwoLine


        #endregion // Add information file lines

        #region Add link lines

        /// <summary>Adds request link 1 line</summary>
        private static void ReqLinkOneLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            int link_number = 1;

            ReqLinkLine(i_outfile, i_current_req, link_number, i_tab_1, b_private_notes, i_end_line, i_htm);

        } // ReqLinkOneLine

        /// <summary>Adds request link 2 line</summary>
        private static void ReqLinkTwoLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            int link_number = 2;

            ReqLinkLine(i_outfile, i_current_req, link_number, i_tab_1, b_private_notes, i_end_line, i_htm);

        } // ReqLinkTwoLine

        /// <summary>Adds request link 3 line</summary>
        private static void ReqLinkThreeLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            int link_number = 3;

            ReqLinkLine(i_outfile, i_current_req, link_number, i_tab_1, b_private_notes, i_end_line, i_htm);

        } // ReqLinkThreeLine

        /// <summary>Adds request link 4 line</summary>
        private static void ReqLinkFourLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            int link_number = 4;

            ReqLinkLine(i_outfile, i_current_req, link_number, i_tab_1, b_private_notes, i_end_line, i_htm);

        } // ReqLinkFourLine

        /// <summary>Adds request link 5 line</summary>
        private static void ReqLinkFiveLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            int link_number = 5;

            ReqLinkLine(i_outfile, i_current_req, link_number, i_tab_1, b_private_notes, i_end_line, i_htm);

        } // ReqLinkFiveLine

        /// <summary>Adds request link 6 line</summary>
        private static void ReqLinkSixLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            int link_number = 6;

            ReqLinkLine(i_outfile, i_current_req, link_number, i_tab_1, b_private_notes, i_end_line, i_htm);

        } // ReqLinkSixLine

        /// <summary>Adds request link 7 line</summary>
        private static void ReqLinkSevenLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            int link_number = 7;

            ReqLinkLine(i_outfile, i_current_req, link_number, i_tab_1, b_private_notes, i_end_line, i_htm);

        } // ReqLinkSevenLine

        /// <summary>Adds request link 8 line</summary>
        private static void ReqLinkEightLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            int link_number = 8;

            ReqLinkLine(i_outfile, i_current_req, link_number, i_tab_1, b_private_notes, i_end_line, i_htm);

        } // ReqLinkEightLine

        /// <summary>Adds request link 9 line</summary>
        private static void ReqLinkNineLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            int link_number = 9;

            ReqLinkLine(i_outfile, i_current_req, link_number, i_tab_1, b_private_notes, i_end_line, i_htm);

        } // ReqLinkNineLine

        /// <summary>Adds a request link line</summary>
        private static void ReqLinkLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_link_number, int i_tab_1, bool b_private_notes, int i_end_line, bool i_htm)
        {
            if (i_link_number < 1 || i_link_number > 9)
                return;

            string link_type = @"";
            string link_text = @"";
            string link_url = @"";
            string link_str = @"";
            GetLinkData(i_current_req, i_link_number, out link_url, out link_text, out link_type, out link_str);

            if (link_url.Length == 0)
                return;

            int n_spaces = i_tab_1 - link_str.Length;

            string req_link_line = link_str + Spaces(n_spaces) + link_url;
            if (i_htm)
            {
                req_link_line = link_str + HtmlSpaces(n_spaces) + HtmlLinkText(link_url, link_text);
            }

            i_outfile.Write(req_link_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

        } // ReqLinkLine

        /// <summary>Get link data</summary>
        private static void GetLinkData(JazzReq i_current_req, int i_link_number, out string o_link, out string o_link_text, out string o_link_type, out string o_link_str)
        {
            o_link = @"";
            o_link_text = @"";
            o_link_type = @"";
            o_link_str = @"";

            if (1 == i_link_number)
            {
                o_link = i_current_req.LinkOne;
                if (o_link.Length == 0)
                    return;
                o_link_text = i_current_req.LinkTextOne;
                o_link_type = i_current_req.LinkTypeOne;
                GetTextAndLinkStr(o_link_type, o_link_text, out o_link_text, out o_link_str);
            }
            else if (2 == i_link_number)
            {
                o_link = i_current_req.LinkTwo;
                if (o_link.Length == 0)
                    return;
                o_link_text = i_current_req.LinkTextTwo;
                o_link_type = i_current_req.LinkTypeTwo;
                GetTextAndLinkStr(o_link_type, o_link_text, out o_link_text, out o_link_str);
            }
            else if (3 == i_link_number)
            {
                o_link = i_current_req.LinkThree;
                if (o_link.Length == 0)
                    return;
                o_link_text = i_current_req.LinkTextThree;
                o_link_type = i_current_req.LinkTypeThree;
                GetTextAndLinkStr(o_link_type, o_link_text, out o_link_text, out o_link_str);
            }
            else if (4 == i_link_number)
            {
                o_link = i_current_req.LinkFour;
                if (o_link.Length == 0)
                    return;
                o_link_text = i_current_req.LinkTextFour;
                o_link_type = i_current_req.LinkTypeFour;
                GetTextAndLinkStr(o_link_type, o_link_text, out o_link_text, out o_link_str);
            }
            else if (5 == i_link_number)
            {
                o_link = i_current_req.LinkFive;
                if (o_link.Length == 0)
                    return;
                o_link_text = i_current_req.LinkTextFive;
                o_link_type = i_current_req.LinkTypeFive;
                GetTextAndLinkStr(o_link_type, o_link_text, out o_link_text, out o_link_str);
            }
            else if (6 == i_link_number)
            {
                o_link = i_current_req.LinkSix;
                if (o_link.Length == 0)
                    return;
                o_link_text = i_current_req.LinkTextSix;
                o_link_type = i_current_req.LinkTypeSix;
                GetTextAndLinkStr(o_link_type, o_link_text, out o_link_text, out o_link_str);
            }
            else if (7 == i_link_number)
            {
                o_link = i_current_req.LinkSeven;
                if (o_link.Length == 0)
                    return;
                o_link_text = i_current_req.LinkTextSeven;
                o_link_type = i_current_req.LinkTypeSeven;
                GetTextAndLinkStr(o_link_type, o_link_text, out o_link_text, out o_link_str);
            }
            else if (8 == i_link_number)
            {
                o_link = i_current_req.LinkEight;
                if (o_link.Length == 0)
                    return;
                o_link_text = i_current_req.LinkTextEight;
                o_link_type = i_current_req.LinkTypeEight;
                GetTextAndLinkStr(o_link_type, o_link_text, out o_link_text, out o_link_str);
            }
            else if (9 == i_link_number)
            {
                o_link = i_current_req.LinkNine;
                if (o_link.Length == 0)
                    return;
                o_link_text = i_current_req.LinkTextNine;
                o_link_type = i_current_req.LinkTypeNine;
                GetTextAndLinkStr(o_link_type, o_link_text, out o_link_text, out o_link_str);
            }
            else
            {
                return; // Programming error
            }

        } // GetLinkData

        /// <summary>Get link link text and link string (label)</summary>
        static private void GetTextAndLinkStr(string i_link_type, string i_link_text, out string o_link_text, out string o_link_str)
        {
            o_link_text = @"";
            o_link_str = @"";

            if (i_link_type.Equals(RequestStrings.LinkTypeVideo))
            {
                o_link_str = RequestStrings.LabelVideoLink;
                o_link_text = RequestStrings.LinkTypeVideo;
            }
            else if (i_link_type.Equals(RequestStrings.LinkTypeSound))
            {
                o_link_str = RequestStrings.LabelSoundLink;
                o_link_text = RequestStrings.LinkTypeSound;
            }
            else if (i_link_type.Equals(RequestStrings.LinkTypeWebsite))
            {
                o_link_str = RequestStrings.LabelWebsiteLink;
                o_link_text = RequestStrings.LinkTypeWebsite;
            }
            else
            {
                return; // Programming error
            }

            if (i_link_text.Length > 0)
            {
                o_link_text = i_link_text;
            }

        } // GetTextAndLinkStr


        #endregion // Add link lines

        #region Add photo lines

        /// <summary>Adds photo 1 line</summary>
        private static void ReqPhotoOneLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            int link_number = 1;

            ReqPhotoLine(i_outfile, i_current_req, link_number, i_tab_1, i_end_line, i_htm);

        } // ReqPhotoOneLine

        /// <summary>Adds photo 2 line</summary>
        private static void ReqPhotoTwoLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            int link_number = 2;

            ReqPhotoLine(i_outfile, i_current_req, link_number, i_tab_1, i_end_line, i_htm);

        } // ReqPhotoTwoLine

        /// <summary>Adds photo 3 line</summary>
        private static void ReqPhotoThreeLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            int link_number = 3;

            ReqPhotoLine(i_outfile, i_current_req, link_number, i_tab_1, i_end_line, i_htm);

        } // ReqPhotoThreeLine

        /// <summary>Adds photo 4 line</summary>
        private static void ReqPhotoFourLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            int link_number = 4;

            ReqPhotoLine(i_outfile, i_current_req, link_number, i_tab_1, i_end_line, i_htm);

        } // ReqPhotoFourLine

        /// <summary>Adds photo 5 line</summary>
        private static void ReqPhotoFiveLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            int link_number = 5;

            ReqPhotoLine(i_outfile, i_current_req, link_number, i_tab_1, i_end_line, i_htm);

        } // ReqPhotoFiveLine

        /// <summary>Adds photo 6 line</summary>
        private static void ReqPhotoSixLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            int link_number = 6;

            ReqPhotoLine(i_outfile, i_current_req, link_number, i_tab_1, i_end_line, i_htm);

        } // ReqPhotoSixLine

        /// <summary>Adds photo 7 line</summary>
        private static void ReqPhotoSevenLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            int link_number = 7;

            ReqPhotoLine(i_outfile, i_current_req, link_number, i_tab_1, i_end_line, i_htm);

        } // ReqPhotoSevenLine

        /// <summary>Adds photo 8 line</summary>
        private static void ReqPhotoEightLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            int link_number = 8;

            ReqPhotoLine(i_outfile, i_current_req, link_number, i_tab_1, i_end_line, i_htm);

        } // ReqPhotoEightLine

        /// <summary>Adds photo 9 line</summary>
        private static void ReqPhotoNineLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_tab_1, int i_end_line, bool i_htm)
        {
            int link_number = 9;

            ReqPhotoLine(i_outfile, i_current_req, link_number, i_tab_1, i_end_line, i_htm);

        } // ReqPhotoNineLine

        /// <summary>Adds a photo line</summary>
        private static void ReqPhotoLine(System.IO.StreamWriter i_outfile, JazzReq i_current_req, int i_photo_number, int i_tab_1, int i_end_line, bool i_htm)
        {
            if (i_photo_number < 1 || i_photo_number > 9)
                return;

            string file_name = GetPhotoFileName(i_current_req, i_photo_number);

            if (file_name.Length == 0)
                return;

            string photo_str = RequestStrings.GetPhotoLabel(i_photo_number);

            int n_spaces = i_tab_1 - photo_str.Length;

            string req_photo_line = photo_str + Spaces(n_spaces) + file_name;
            if (i_htm)
            {
                req_photo_line = photo_str + HtmlSpaces(n_spaces) + PhotoFileLink(i_current_req, file_name);
            }

            i_outfile.Write(req_photo_line);
            i_outfile.Write(System.Environment.NewLine + HtmlEndOfLine(i_htm));

        } // ReqPhotoLine

        /// <summary>Get photo file name</summary>
        private static string GetPhotoFileName(JazzReq i_current_req, int i_photo_number)
        {
            string ret_file_name = @"";

            if (1 == i_photo_number)
            {
                ret_file_name = i_current_req.PhotoOne;
                if (ret_file_name.Length == 0)
                    return ret_file_name;
            }
            else if (2 == i_photo_number)
            {
                ret_file_name = i_current_req.PhotoTwo;
                if (ret_file_name.Length == 0)
                    return ret_file_name;
            }
            else if (3 == i_photo_number)
            {
                ret_file_name = i_current_req.PhotoThree;
                if (ret_file_name.Length == 0)
                    return ret_file_name;
            }
            else if (4 == i_photo_number)
            {
                ret_file_name = i_current_req.PhotoFour;
                if (ret_file_name.Length == 0)
                    return ret_file_name;
            }
            else if (5 == i_photo_number)
            {
                ret_file_name = i_current_req.PhotoFive;
                if (ret_file_name.Length == 0)
                    return ret_file_name;
            }
            else if (6 == i_photo_number)
            {
                ret_file_name = i_current_req.PhotoSix;
                if (ret_file_name.Length == 0)
                    return ret_file_name;
            }
            else if (7 == i_photo_number)
            {
                ret_file_name = i_current_req.PhotoSeven;
                if (ret_file_name.Length == 0)
                    return ret_file_name;
            }
            else if (8 == i_photo_number)
            {
                ret_file_name = i_current_req.PhotoEight;
                if (ret_file_name.Length == 0)
                    return ret_file_name;
            }
            else if (9 == i_photo_number)
            {
                ret_file_name = i_current_req.PhotoNine;
                if (ret_file_name.Length == 0)
                    return ret_file_name;
            }
            else
            {
                return ret_file_name; // Programming error
            }

            return ret_file_name;

        } // GetPhotoFileName

        #endregion // Add photo lines

        #region  Functions that add lines for the HTM list

        /// <summary>Returns Html header</summary>
        private static void HtmlHeader(System.IO.StreamWriter i_outfile, string i_header)
        {
            string ret_line_1 = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>";
            i_outfile.Write(ret_line_1);
            i_outfile.Write(System.Environment.NewLine);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_2 = @"<HTML>";
            i_outfile.Write(ret_line_2);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_3 = @"<HEAD>";
            i_outfile.Write(ret_line_3);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_4 = @"<TITLE>" + RequestStrings.TitleRequestForm + @"</TITLE>";
            i_outfile.Write(ret_line_4);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_5 = @"</HEAD >";
            i_outfile.Write(ret_line_5);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_6 = @"<BODY BGCOLOR = '#F5F5F5'>";
            i_outfile.Write(ret_line_6);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_7 = @"<P><HR width = '100%' align = 'center' ></P>";
            i_outfile.Write(ret_line_7);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_8 = @"<FONT size = 5 face = 'Arial'>";
            i_outfile.Write(ret_line_8);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_9 = @"<P ALIGN = CENTER ><b>" + RequestStrings.TitleRequestForm + @"</b></P>";
            i_outfile.Write(ret_line_9);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_10 = @"</FONT>";
            i_outfile.Write(ret_line_10);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_11 = @"<p><HR width = '100%' align = 'center'></p>";
            i_outfile.Write(ret_line_11);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_12 = @"<FONT size = 3 face = 'Arial'>";
            i_outfile.Write(ret_line_12);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_13 = @"<h3>" + i_header + @"</h3>";
            i_outfile.Write(ret_line_13);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_14 = @"<p><pre>";
            i_outfile.Write(ret_line_14);
            i_outfile.Write(System.Environment.NewLine);

        } // HtmlHeader

        /// <summary>Returns Html header</summary>
        private static void HtmlEndLines(System.IO.StreamWriter i_outfile)
        {

            string ret_line_1 = @"</pre></p>";
            i_outfile.Write(ret_line_1);
            i_outfile.Write(System.Environment.NewLine);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_2 = @"</FONT>";
            i_outfile.Write(ret_line_2);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_3 = @"</BODY>";
            i_outfile.Write(ret_line_3);
            i_outfile.Write(System.Environment.NewLine);

            string ret_line_4 = @"</HTML>";
            i_outfile.Write(ret_line_4);
            i_outfile.Write(System.Environment.NewLine);

        } // HtmlEndLines

        /// <summary>Returns Html spaces</summary>
        private static string HtmlSpaces(int i_n_spaces)
        {
            string ret_str = "";

            for (int i_space = 1; i_space <= i_n_spaces; i_space++)
            {
                ret_str = ret_str + "&nbsp;";
            }

            return ret_str;

        } // HtmlSpaces

        #endregion  // Functions that add lines for the HTM list

        #region Utility functions for list of requests

        /// <summary>Returns spaces</summary>
        private static string Spaces(int i_n_spaces)
        {
            string ret_str = "";

            for (int i_space=1; i_space<= i_n_spaces; i_space++)
            {
                ret_str = ret_str + " ";
            }

            return ret_str;
        } // Spaces

        /// <summary>Returns line </summary>
        private static string Underline(int i_n_length)
        {
            string ret_str = "";

            for (int i_space = 1; i_space <= i_n_length; i_space++)
            {
                ret_str = ret_str + "-";
            }

            return ret_str;
        } // Underline

        /// <summary>Returns line for header</summary>
        private static string UnderlineHeader(int i_n_length)
        {
            string ret_str = "";

            for (int i_space = 1; i_space <= i_n_length; i_space++)
            {
                ret_str = ret_str + "=";
            }

            return ret_str;
        } // UnderlineHeader

        /// <summary>Returns multiple lines for a given string</summary>
        private static string[] StringToMultipleLines(string i_string, int i_tab_1, int i_end_line)
        {
            string[] ret_lines = null;

            ArrayList ret_array_list = new ArrayList();

            string output_line = @"";
            int n_char_line = 0;
            int n_lines = 0;
            for (int index_char=0; index_char<i_string.Length; index_char++)
            {
                string current_char = i_string.Substring(index_char, 1);

                if (current_char.Equals("\n"))
                {
                    ret_array_list.Add(output_line);
                    output_line = @"";
                    n_char_line = 0;
                    n_lines = n_lines + 1;
                }
                else
                {
                    output_line = output_line + current_char;
                    n_char_line = n_char_line + 1;
                }
                
                if (current_char.Equals(@" "))
                {
                    if (!NextWordAlso(i_string, index_char, i_tab_1, i_end_line, n_char_line))
                    {
                        ret_array_list.Add(output_line);
                        output_line = @"";
                        n_char_line = 0;
                        n_lines = n_lines + 1;
                    }
                }

            } // index_char

            if (n_char_line > 0)
            {
                ret_array_list.Add(output_line);
                n_lines = n_lines + 1;
            }

            ret_lines = (string[])ret_array_list.ToArray(typeof(string));

            return ret_lines;

        } // StringToMultipleLines

        private static bool NextWordAlso(string i_string, int i_index_char, int i_tab_1, int i_end_line, int i_n_char_line )
        {
            string remaining_string = i_string.Substring(i_index_char + 1);
            int n_available = i_end_line - i_tab_1 - i_n_char_line;

            int n_to_next_space = 0;
            for (int index_next=0; index_next< remaining_string.Length; index_next++)
            {
                string current_char = remaining_string.Substring(index_next, 1);
                if (current_char.Equals(@" "))
                {
                    if (n_to_next_space <= n_available)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    n_to_next_space = n_to_next_space + 1;
                }
            }

            return true; // End of line reached
        }

        /// <summary>Returns a link for an HTML page
        /// <para></para>
        /// </summary>
        /// <param name="i_url">URL</param>
        /// <param name="i_web_page">Eq. true: String Webseite Eq. false: File name</param>
        private static string HtmlLink(string i_url, bool i_web_page)
        {
            string file_name = System.IO.Path.GetFileNameWithoutExtension(i_url);

            string exposed_text = RequestStrings.LabelWebPage;
            if (!i_web_page)
            {
                exposed_text = file_name;
            }

            string html_link = @"<a href='" + i_url + @"'>" + exposed_text + @"</a>";

            return html_link;

        } // HtmlLink    

        /// <summary>Returns a link for an HTML page
        /// <para></para>
        /// </summary>
        /// <param name="i_url">URL</param>
        /// <param name="i_text">Displayed text for the link</param>
        private static string HtmlLinkText(string i_url, string i_text)
        {
            string file_name = System.IO.Path.GetFileNameWithoutExtension(i_url);

            string html_link = @"<a href='" + i_url + @"'>" + i_text + @"</a>";

            return html_link;

        } // HtmlLinkText    

        /// <summary>Returns an HTM link for a photo file
        /// <para></para>
        /// </summary>
        /// <param name="i_req">Object JazzReq</param>
        ///  <param name="i_file_name">Photo file name</param>
        private static string PhotoFileLink(JazzReq i_req, string i_file_name)
        {          
           string url_info_file = @"http://www.jazzliveaarau.ch/" + RequestStrings.ServerDirRequestFiles + @"/" + i_req.RegNumberName() + @"/" + i_file_name;

            string html_link = @"<a href='" + url_info_file + @"'>" + i_file_name + @"</a>";

            return html_link;

        } // PhotoFileLink    

        /// <summary>Returns an HTM link for an information file
        /// <para></para>
        /// </summary>
        /// <param name="i_req">Object JazzReq</param>
        ///  <param name="i_file_number">File number 1, 2 or 3</param>
        private static string InfoFileLink(JazzReq i_req, int i_file_number)
        {
            string file_name = i_req.InfoOne;

            if (1 == i_file_number)
            {
                file_name = i_req.InfoOne;
            }
            else if (2 == i_file_number)
            {
                file_name = i_req.InfoTwo;
            }
            else if (3 == i_file_number)
            {
                file_name = i_req.InfoThree;
            }
            else
            {
                return @"InfoFileLink error: i_file_number not 1, 2 or 3";
            }


            string url_info_file = @"http://www.jazzliveaarau.ch/" + RequestStrings.ServerDirRequestFiles + @"/" + i_req.RegNumberName() + @"/" + file_name;

            string html_link = @"<a href='" + url_info_file + @"'>" + file_name + @"</a>";

            return html_link;

        } // InfoFileLink    

        /// <summary>Returns end of line for an Html file</summary>
        private static string HtmlEndOfLine(bool i_htm)
        {
            if (i_htm)
            {
                return @"<br>";
            }
            else
            {
                return @"";
            }

        } // HtmlEndOfLine

        /// <summary>Returns bold text for an Html file</summary>
        private static string HtmlBold(string i_string, bool i_htm)
        {
            string o_string = i_string;
            if (i_htm)
            {
                return @"<b>" + o_string + @"</b>";
            }

            return o_string;

        } // HtmlBold

        /// <summary>Initialization of the file creation
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_htm">Flag telling if an HTML or TXT shall be created</param>
        /// <param name="b_for_evaluation">Flag telling if only requests for evaluation shall be listed</param>
        /// <param name="b_selected_bands">Flag telling that only selected (and sorted) requests shall be listed</param>
        /// <param name="b_sort_date">Flag telling that requests shall be sorted after request date</param>
        /// <param name="i_time_stamp_file_name">Flag telling if a time stamp (yyyy-mm-dd) shall be added to the file name</param>
        /// <param name="o_all_reqs">All JazzReq objects</param>
        /// <param name="o_tab_1">Error message</param>
        /// <param name="o_end_line">Length to the first tab</param>
        /// <param name="o_header_line">Header line</param>
        /// <param name="o_file_name">Full file name (.txt or .htm)</param>
        /// <param name="o_error">Error message</param>
        private static bool InitRequestsList(bool i_htm, bool b_for_evaluation, bool b_selected_bands, bool b_sort_date, bool i_time_stamp_file_name, out JazzReq[] o_all_reqs, out int o_tab_1, out int o_end_line, out string o_header_line, out string o_file_name, out string o_error)
        {
            o_error = @"";
            o_all_reqs = null;
            o_file_name = @"";
            o_header_line = @"";

            o_tab_1 = 18;
            o_end_line = 80;

            JazzReq[] all_reqs = JazzXml.GetAllRequests(out o_error);
            if (null == all_reqs || all_reqs.Length == 0)
            {
                o_error = @"Request.InitRequestsList all_reqs is null or has no elements";
                return false;
            }

            if (b_sort_date)
            {
                JazzReq[] date_sorted_reqs = GetDateSortedRequests(all_reqs, out o_error);
                if (null == date_sorted_reqs)
                {
                    return false;
                }

                all_reqs = date_sorted_reqs;
            }

            JazzReq[] selected_sorted_reqs = null;

            if (b_selected_bands)
            {
                selected_sorted_reqs = GetSelectedBandRequests(all_reqs, out o_error);
                if (null == selected_sorted_reqs)
                {
                    return false;
                }
            } 

            string file_name = RequestStrings.RequestsTextFileNameAll;
            string header_line = RequestStrings.RequestHeaderAll;
            if (b_for_evaluation)
            {
                file_name = RequestStrings.RequestsTextFileNameForEvaluation;
                header_line = RequestStrings.RequestHeaderForEvaluation;
            }
            else if (b_selected_bands)
            {
                file_name = RequestStrings.RequestsTextFileNameForSelectedBands;
                header_line = RequestStrings.RequestHeaderForSelectedBands;
            }

            file_name = FileUtil.SubDirectory(RequestStrings.LocalDirRequestFiles, Main.m_exe_directory) + @"\" + file_name;

            if (i_time_stamp_file_name)
            {
                file_name = file_name + TimeUtil.YearMonthDay();
            }

            if (i_htm)
            {
                file_name = file_name + ".htm";
            }
            else
            {
                file_name = file_name + ".txt";
            }

            if (b_selected_bands)
            {
                o_all_reqs = selected_sorted_reqs;
            }
            else
            {
                o_all_reqs = all_reqs;
            }

            o_header_line = header_line;
            o_file_name = file_name;

            return true;

        } // InitRequestsList

        /// <summary>Returns selected band requests, i.e. the bands that will play in the jazzclub
        /// <para>The returned array is sorted with respect to concert date (actually concert number)</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_all_reqs">All requests</param>
        /// <param name="o_error">Error message</param>
        private static JazzReq[] GetSelectedBandRequests(JazzReq[] i_all_reqs, out string o_error)
        {
            o_error = @"";

            JazzReq[] ret_reqs = null;

            if (null == i_all_reqs)
            {
                o_error = @"Request.GetSelectedBandRequests i_all_reqs is null";
                return ret_reqs;
            }

            int n_selected = 0;
            for (int index_count = 0; index_count < i_all_reqs.Length; index_count++)
            {
                JazzReq current_req = i_all_reqs[index_count];
                int concert_number = current_req.ConcertNumberInt;
                if (concert_number >= 1 && concert_number <= 12)
                {
                    n_selected = n_selected + 1;
                }
            }

            if (0 == n_selected)
            {
                {
                    o_error = RequestStrings.ErrMsgNoSelectedRequests;
                    return ret_reqs;
                }
            }

            JazzReq[] unsorted_reqs = new JazzReq[n_selected];
            int index_out = -1;
            for (int index_unsorted = 0; index_unsorted < i_all_reqs.Length; index_unsorted++)
            {
                JazzReq current_req = i_all_reqs[index_unsorted];
                int concert_number = current_req.ConcertNumberInt;
                if (concert_number >= 1 && concert_number <= 12)
                {
                    index_out = index_out + 1;
                    unsorted_reqs[index_out] = i_all_reqs[index_unsorted];
                }
            }

            JazzReq[] sorted_reqs = new JazzReq[n_selected];

            bool[] reg_sorted = new bool[n_selected];
            for (int index_init=0; index_init<n_selected; index_init++)
            {
                reg_sorted[index_init] = false;
            }

            
            for (int index_outer=0; index_outer<n_selected; index_outer++)
            {
                int min_concert_number = 50000;
                int index_min = -1;
                for (int index_inner = 0; index_inner < n_selected; index_inner++)
                {
                    JazzReq current_inner = unsorted_reqs[index_inner];
                    int concert_number_inner = current_inner.ConcertNumberInt;
                    bool b_sorted = reg_sorted[index_inner];
                    if (concert_number_inner <= min_concert_number && !b_sorted)
                    {
                        index_min = index_inner;
                        min_concert_number = concert_number_inner;
                    }
                } // index_inner

                if (index_min<0)
                {
                    o_error = @"Request.GetSelectedBandRequests Sorting programming error";
                    return ret_reqs;
                }

                sorted_reqs[index_outer] = unsorted_reqs[index_min];
                reg_sorted[index_min] = true;

            } // index_outer

            ret_reqs = sorted_reqs;

            return ret_reqs;

        } // GetSelectedBandRequests

        /// <summary>Returns requests sorted after request date
        /// <para></para>
        /// </summary>
        /// <param name="i_all_reqs">All requests</param>
        /// <param name="o_error">Error message</param>
        private static JazzReq[] GetDateSortedRequests(JazzReq[] i_all_reqs, out string o_error)
        {
            o_error = @"";

            JazzReq[] ret_reqs = null;

            if (null == i_all_reqs)
            {
                o_error = @"Request.GetDateSortedRequests i_all_reqs is null";
                return ret_reqs;
            }

            JazzReq[] unsorted_reqs = i_all_reqs;

            int n_selected = unsorted_reqs.Length;

            JazzReq[] sorted_reqs = new JazzReq[n_selected];

            bool[] reg_sorted = new bool[n_selected];
            for (int index_init = 0; index_init < n_selected; index_init++)
            {
                reg_sorted[index_init] = false;
            }

            for (int index_outer = 0; index_outer < n_selected; index_outer++)
            {
                int min_number_days = 50000;
                int index_min = -1;
                for (int index_inner = 0; index_inner < n_selected; index_inner++)
                {
                    JazzReq current_inner = unsorted_reqs[index_inner];
                    int number_days = NumberOfDays(current_inner);
                    bool b_sorted = reg_sorted[index_inner];
                    if (number_days <= min_number_days && !b_sorted)
                    {
                        index_min = index_inner;
                        min_number_days = number_days;
                    }
                } // index_inner

                if (index_min < 0)
                {
                    o_error = @"Request.GetDateSortedRequests Sorting programming error";
                    return ret_reqs;
                }

                sorted_reqs[index_outer] = unsorted_reqs[index_min];
                reg_sorted[index_min] = true;

            } // index_outer

            ret_reqs = sorted_reqs;

            return ret_reqs;

        } // GetDateSortedRequests

        /// <summary>Returns number of days from 2017-01-01 to request date
        /// <para></para>
        /// </summary>
        /// <param name="i_req">Request object</param>
        private static int NumberOfDays(JazzReq i_req)
        {
            DateTime date_time_compare = new DateTime(2017, 1, 1);

            DateTime date_time_request = new DateTime(i_req.RegYearInt, i_req.RegMonthInt, i_req.RegDayInt);

            int number_days = (date_time_request - date_time_compare).Days;

            return number_days;

        } // NumberOfDays

        /// <summary>Open default browser
        /// <para>The input URL may be website, a page on a website or a local file with extension htm</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_url">URL</param>
        /// <param name="o_error">Error message</param>
        public static bool OpenDefaultBrowser(string i_url, out string o_error)
        {
            o_error = @"";

            // https://support.microsoft.com/en-us/help/305703/how-to-start-the-default-internet-browser-programmatically-by-using-vi
            // string target = "http://www.microsoft.com";
            //Use no more than one assignment when you test this code. 
            //string target = "ftp://ftp.microsoft.com";
            //string target = "C:\\Program Files\\Microsoft Visual Studio\\INSTALL.HTM"; 

            try
            {
                System.Diagnostics.Process.Start(i_url);
            }
            catch (System.ComponentModel.Win32Exception no_browser)
            {
                if (no_browser.ErrorCode == -2147467259)
                {
                    o_error = @"Request.OpenDefaultBrowser " + no_browser.Message;
                }
            }
            catch (System.Exception other)
            {
                o_error = @"Request.OpenDefaultBrowser " + other.Message;
            }


            return true;
        } // OpenDefaultBrowser

        #endregion // Utility functions for list of requests

    } // Request

} // namespace
