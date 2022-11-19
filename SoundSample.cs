using JazzApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Execution functions and parameters for the form SoundSampleForm
    /// <para></para>
    /// </summary>
    static public class SoundSample
    {
        #region Member variables

        /// <summary>Concert number</summary>
        static private int m_concert_number = -12345;

        /// <summary>Set concert number</summary>
        static private void SetConcertNumber(int i_concert_number) { m_concert_number = i_concert_number; }

        /// <summary>Get concert number</summary>
        static private int GetConcertNumber() { return m_concert_number; }

        /// <summary>Interface object to DOC XML holding (for this class) paths to server directories where concert data (documents) are stored</summary>
        static private SeasonDocInterface m_season_doc = null;

        /// <summary>Sets interface object to DOC XML holding (for this class) paths to server directories where concert data (documents) are stored</summary>
        static private void SetSeasonDocInterface(SeasonDocInterface i_season_doc) { m_season_doc = i_season_doc;  }

        /// <summary>Returns interface object to DOC XML holding (for this class) paths to server directories where concert data (documents) are stored</summary>
        static private SeasonDocInterface GetSeasonDocInterface() { return m_season_doc;  }

        /// <summary>URL for the sound sample file that may be downloaded</summary>
        static private string m_download_sound_sample_url = @"";

        /// <summary>Set and get URL for the sound sample file that may be downloaded</summary>
        static private string DownloadSoundSampleUrl { get { return m_download_sound_sample_url;  }  set { m_download_sound_sample_url = value;  } }

        /// <summary>URL for the sound sample QR code file that may be downloaded</summary>
        static private string m_download_sound_sample_qr_code_url = @"";

        /// <summary>Set and get URL for the sound sample QR code file that may be downloaded</summary>
        static private string DownloadSoundSampleQrCodeUrl { get { return m_download_sound_sample_qr_code_url; } set { m_download_sound_sample_qr_code_url = value; } }

        /// <summary>URL for the sound sample file that may be uploaded</summary>
        static private string m_upload_sound_sample_url = @"";

        /// <summary>Set and get URL for the sound sample file that may be uploaded</summary>
        static public string UploadSoundSampleUrl { get { return m_upload_sound_sample_url; } set { m_upload_sound_sample_url = value; } }

        /// <summary>URL for the sound sample QR code file that may be downloaded</summary>
        static private string m_upload_sound_sample_qr_code_url = @"";

        /// <summary>Set and get URL for the sound sample QR code file that may be uploaded</summary>
        static private string UploadSoundSampleQrCodeUrl { get { return m_upload_sound_sample_qr_code_url; } set { m_upload_sound_sample_qr_code_url = value; } }

        /// <summary>File name for the sound sample file that may be downloaded</summary>
        static private string m_download_sound_sample_file_name = @"";

        /// <summary>Set and get file name for the sound sample file that may be downloaded</summary>
        static public string DownloadSoundSampleFileName { get { return m_download_sound_sample_file_name; } set { m_download_sound_sample_file_name = value; } }

        /// <summary>File name for the sound sample QR code file that may be downloaded</summary>
        static private string m_download_sound_sample_qr_code_file_name = @"";

        /// <summary>Set and get file name for the sound sample QR code file that may be downloaded</summary>
        static public string DownloadSoundSampleQrCodeFileName { get { return m_download_sound_sample_qr_code_file_name; } set { m_download_sound_sample_qr_code_file_name = value; } }

        /// <summary>File name for the sound sample file that may be uploaded</summary>
        static private string m_upload_sound_sample_file_name = @"";

        /// <summary>Set and get file name for the sound sample file that may be uploaded</summary>
        static public string UploadSoundSampleFileName { get { return m_upload_sound_sample_file_name; } set { m_upload_sound_sample_file_name = value; } }

        /// <summary>File name for the sound sample QR code file that may be downloaded</summary>
        static private string m_upload_sound_sample_qr_code_file_name = @"";

        /// <summary>Set and get file name for the sound sample QR code file that may be uploaded</summary>
        static public string UploadSoundSampleQrCodeFileName { get { return m_upload_sound_sample_qr_code_file_name; } set { m_upload_sound_sample_qr_code_file_name = value; } }

        /// <summary>Server directory for the sound sample file that may be downloaded</summary>
        static private string m_download_sound_sample_server_dir = @"";

        /// <summary>Set and get server directory for the sound sample file that may be downloaded</summary>
        static private string DownloadSoundSampleServerDir { get { return m_download_sound_sample_server_dir; } set { m_download_sound_sample_server_dir = value; } }

        /// <summary>Server directory for the sound sample QR code file that may be downloaded</summary>
        static private string m_download_sound_sample_qr_code_server_dir = @"";

        /// <summary>Set and get server directory for the sound sample QR code file that may be downloaded</summary>
        static private string DownloadSoundSampleQrCodeServerDir { get { return m_download_sound_sample_qr_code_server_dir; } set { m_download_sound_sample_qr_code_server_dir = value; } }

        /// <summary>Server directory for the sound sample file that may be uploaded</summary>
        static private string m_upload_sound_sample_server_dir = @"";

        /// <summary>Set and get server directory for the sound sample file that may be uploaded</summary>
        static private string UploadSoundSampleServerDir { get { return m_upload_sound_sample_server_dir; } set { m_upload_sound_sample_server_dir = value; } }

        /// <summary>Server directory for the sound sample QR code file that may be downloaded</summary>
        static private string m_upload_sound_sample_qr_code_server_dir = @"";

        /// <summary>Set and get server directory for the sound sample QR code file that may be uploaded</summary>
        static private string UploadSoundSampleQrCodeServerDir { get { return m_upload_sound_sample_qr_code_server_dir; } set { m_upload_sound_sample_qr_code_server_dir = value; } }

        /// <summary>The end of the name for the upload sound sample file</summary>
        private static string GetEndFileNameSoundSample() { return "_Sound_Sample"; }

        /// <summary>Returns the end of the name for the upload sound sample QR code image file</summary>
        private static string GetEndFileNameSoundQr() { return "_Sound_QR_code"; }

        /// <summary>The URL for the sound sample file that shall be saved</summary>
        private static string m_sound_sample_url_to_be_saved = @"";

        /// <summary>Sets the URL for the sound sample file that shall be saved</summary>
        private static void SetSoundSampleToSaveUrl(string i_sound_sample_url_to_be_saved) { m_sound_sample_url_to_be_saved = i_sound_sample_url_to_be_saved; }

        /// <summary>Returns the URL for the sound sample file that shall be saved</summary>
        public static string GetSoundSampleToSaveUrl() { return m_sound_sample_url_to_be_saved; }

        /// <summary>The URL for the sound sample QR code file that shall be saved</summary>
        private static string m_sound_sample_qr_code_url_to_be_saved = @"";

        /// <summary>Sets the URL for the sound sample QR code file that shall be saved</summary>
        private static void SetSoundSampleQrCodeToSaveUrl(string i_sound_sample_url_to_be_saved) { m_sound_sample_qr_code_url_to_be_saved = i_sound_sample_url_to_be_saved; }

        /// <summary>Returns the URL for the sound sample QR code file that shall be saved</summary>
        public static string GetSoundSampleQrCodeToSaveUrl() { return m_sound_sample_qr_code_url_to_be_saved; }

        #endregion // Member variables

        #region Initialization

        /// <summary>
        /// Initialization 
        /// <para>1. Set the download URL (DownloadSoundSampleUrl) for an existing sound sample file on the server. 
        /// The URL is set only if its a mp3 or mp4 file (and no Youtube link). Call of IsValidAudioVideoFile and GetSoundSample</para>
        /// <para>2. If sound sample file exists set file name (DownloadSoundSampleFileName) and server directory (DownloadSoundSampleServerDir)</para>
        /// <para>3. Set the URL for the QR code image (DownloadSoundSampleQrCodeUrl), file name (DownloadSoundSampleQrCodeFileName) and 
        /// server directory (DownloadSoundSampleQrCodeServerDir). Call of GetSoundSampleQrCode</para>
        /// <para>4. Set upload file and directory names.</para>
        /// <para>4.1 Create an instance of class SeasonDocInterface. File and directory names are retrieved from JazzDokumente_20NN_20MM.xml</para>
        /// <para>4.2 Set the member variables UploadSoundSampleUrl (please note always mp4), UploadSoundSampleFileName, UploadSoundSampleServerDir,
        /// UploadSoundSampleQrCodeUrl, UploadSoundSampleQrCodeFileName and UploadSoundSampleQrCodeServerDir</para>
        /// </summary>
        /// <param name="i_concert_number"></param>
        /// <param name="o_error"></param>
        /// <returns></returns>
        static public bool Init(int i_concert_number, out string o_error)
        {
            o_error = @"";

            InitMemberVariables();

            SetConcertNumber(i_concert_number);

            string error_msg = @"";

            if (IsValidAudioVideoFile(GetSoundSample()))
            {
                DownloadSoundSampleUrl = GetSoundSample();
            }

            bool b_case_download = true;

            if (DownloadSoundSampleUrl.Length > 0)
            {
                DownloadSoundSampleFileName = Path.GetFileName(DownloadSoundSampleUrl);

                DownloadSoundSampleServerDir = GetServerDirectory(DownloadSoundSampleUrl, DownloadSoundSampleFileName, b_case_download);
            }

            DownloadSoundSampleQrCodeUrl = GetSoundSampleQrCode();

            if (DownloadSoundSampleQrCodeUrl.Length > 0)
            {
                DownloadSoundSampleQrCodeFileName = Path.GetFileName(DownloadSoundSampleQrCodeUrl);

                DownloadSoundSampleQrCodeServerDir = GetServerDirectory(DownloadSoundSampleQrCodeUrl, DownloadSoundSampleQrCodeFileName, b_case_download);
            }

            m_season_doc = new SeasonDocInterface();

            int autumn_year = JazzXml.GetYearAutumnInt();

            if (!m_season_doc.InitSetActiveDoc(autumn_year, out error_msg))
            {
                o_error = @"SoundSample.Init SeasonDocInterface.Init failed " + error_msg;

                return false;
            }

            SetSeasonDocInterface(m_season_doc);

            UploadSoundSampleUrl = GetSeasonDocInterface().GetUrlToFileNameWithConcertPath(m_concert_number, GetEndFileNameSoundSample(), "mp4");

            UploadSoundSampleFileName = Path.GetFileName(UploadSoundSampleUrl);

            UploadSoundSampleServerDir = GetSeasonDocInterface().GetServerConcertPath(m_concert_number);

            UploadSoundSampleQrCodeUrl = GetSeasonDocInterface().GetUrlToFileNameWithConcertPath(m_concert_number, GetEndFileNameSoundQr(), "png");

            UploadSoundSampleQrCodeFileName = Path.GetFileName(UploadSoundSampleQrCodeUrl);

            UploadSoundSampleQrCodeServerDir = GetSeasonDocInterface().GetServerConcertPath(m_concert_number);

            return true;

        } // Init

        /// <summary>
        /// Returns the server directory for the input URL
        /// </summary>
        /// <param name="i_url">Full URL to fiel on the server</param>
        /// <param name="i_file_name">File name</param>
        /// <returns>Relative server directory starting with www/</returns>
        static private string GetServerDirectory(string i_url, string i_file_name, bool i_case_download)
        {
            string jazz_live_aarau_ch = @"jazzliveaarau.ch";

            int index_jazz_live_aarau = i_url.IndexOf(jazz_live_aarau_ch);

            if (index_jazz_live_aarau < 0)
            {
                return @"SoundSample.GetServerDirectoryGetServerDirectory Missing string in input URL " + jazz_live_aarau_ch;
            }

            int index_keep = index_jazz_live_aarau + jazz_live_aarau_ch.Length + 1;

            string server_dir_name = i_url.Substring(index_keep);

            int index_file_name = server_dir_name.IndexOf(i_file_name);

            if (index_file_name < 0)
            {
                return @"SoundSample.GetServerDirectoryGetServerDirectory Missing file name in input URL " + i_url;
            }

            string server_dir = server_dir_name.Substring(0, index_file_name - 1);

            if(i_case_download)
            {
                return server_dir;
            }
            else
            {
                return @"www/" + server_dir;
            }
            

        } // GetServerDirectory

        /// <summary>
        /// Initialization of all member variables
        /// </summary>
        private static void InitMemberVariables()
        {
            DownloadSoundSampleUrl = @"";

            DownloadSoundSampleFileName = @"";

            DownloadSoundSampleServerDir = @"";

            DownloadSoundSampleQrCodeUrl = @"";

            DownloadSoundSampleQrCodeFileName = @"";

            DownloadSoundSampleQrCodeServerDir = @"";

            UploadSoundSampleUrl = @"";

            UploadSoundSampleFileName = @"";

            UploadSoundSampleServerDir = @"";

            UploadSoundSampleQrCodeUrl = @"";

            UploadSoundSampleQrCodeFileName = @"";

            UploadSoundSampleQrCodeServerDir = @"";

            SetSoundSampleToSaveUrl(@"");

            SetSoundSampleQrCodeToSaveUrl(@"");

            SetConcertNumber(-12345);

        } // InitMemberVariables

        /*QQQQQ
        /// <summary>
        /// Checks that SoundSample form may be opened TODO Check also if DOC exists for the active (current) year
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>false if form not is allowed to be opened</returns>
        static private bool CheckYear(out string o_error)
        {
            o_error = @"";

            int current_season_start_year = JazzUtils.GetCurrentSeasonStartYear();

            int autumn_year = JazzXml.GetYearAutumnInt();

            if (autumn_year != current_season_start_year && autumn_year != current_season_start_year + 1)
            {
                o_error = "SoundSample.CheckYear Nur möglich für Saison " + current_season_start_year.ToString() + @"-" + (current_season_start_year + 1).ToString()
                            + @" und Saison " + (current_season_start_year + 1).ToString() + @"-" + (current_season_start_year + 2).ToString();
                return false; ;
            }

            return true;
        }
        QQQ*/

        /// <summary>
        /// Returns true if the input sound sample file extension is valid (mp3 or mp4)
        /// <para>Return false if not a file on the JAZZ live AARAU server</para>
        /// </summary>
        /// <returns></returns>
        public static bool IsValidAudioVideoFile(string i_server_path_file_name)
        {
            string server_path_file_name_ext = Path.GetExtension(i_server_path_file_name);

            string jazz_live_aarau_ch = @"jazzliveaarau.ch";

            if (!i_server_path_file_name.Contains(jazz_live_aarau_ch))
            {
                return false;
            }

            if (server_path_file_name_ext.Equals(@".mp3") || server_path_file_name_ext.Equals(@".mp4"))
            {
                return true;
            }
            else
            {
                return false;
            }

        } // IsValidAudioVideoFile

        #endregion // Initialization

        #region Write functions

        /// <summary>
        /// Write sound sample file name and sound sample QR code file name to the XML object
        /// </summary>
        /// <param name="o_error"></param>
        /// <returns></returns>
        static public bool WriteSoundSample(out string o_error)
        {
            o_error = @"";

            string full_url_path_to_sound_file = GetSoundSampleToSaveUrl();

            JazzXml.SetSoundSample(m_concert_number, full_url_path_to_sound_file);

            string full_url_path_to_sound_qr_code_file = GetSoundSampleQrCodeToSaveUrl();

            JazzXml.SetSoundSampleQrCode(m_concert_number, full_url_path_to_sound_qr_code_file);

            return true;

        } // WriteSoundSample

        #endregion // Write functions

        #region Get XML functions

        /// <summary>Returns the season name</summary>
        static public string GetSeasonName() { return JazzXml.GetYearAutum() + @"-" + JazzXml.GetYearSpring(); }

        /// <summary>Returns the name of the band</summary>
        static public string GetBandName() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetBandName(m_concert_number)); }

        /// <summary>Returns the URL of the sound sample file (that is on the server)</summary>
        static public string GetSoundSample() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetSoundSample(m_concert_number)); }

        /// <summary>Returns the URL of the sound sample QR code file (that is on the server)</summary>
        static public string GetSoundSampleQrCode() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetSoundSampleQrCode(m_concert_number)); }


        #endregion // Get XML functions

        #region Help functions

        /// <summary>
        /// Returns true if the download icon shall be displayed (available) or the sound file
        /// </summary>
        /// <returns></returns>
        public static bool DisplayDownloadSoundFileIcon()
        {
            string server_path_file_name = GetSoundSample();

            if (server_path_file_name.Length == 0)
            {
                return false;
            }

            return IsValidAudioVideoFile(server_path_file_name);

        } // DisplayDownloadSoundFileIcon

        /// <summary>
        /// Returns true if the download icon shall be displayed (available) or the sound qr code image
        /// </summary>
        /// <returns></returns>
        public static bool DisplayDownloadSoundQrIcon()
        {
            string qr_file = GetSoundSampleQrCode();

            if (qr_file.Length == 0)
            {
                return false;
            }

            return true;

        } // DisplayDownloadSoundQrIcon

        #endregion // Help functions

        #region Download, upload and delete audio/video file

        /// <summary>Download audio/video file</summary>
        /// <param name="i_cancel_download">Flag telling if the user cancelled the download</param>
        /// <param name="o_error">Error message</param>
        public static bool DownloadAudioVideoFile(out bool i_cancel_download, out string o_error)
        {
            o_error = @"";
            i_cancel_download = false;

            string server_path_file_name = GetSoundSample();

            if (!IsValidAudioVideoFile(server_path_file_name))
            {
                o_error = @"SoundSample.DownloadAudioVideoFile Not a valid audio/video file " + server_path_file_name;

                return false;
            }

            string file_extensions = @"mp3,mp4";

            string server_directory = DownloadSoundSampleServerDir;

            string download_file_name = DownloadSoundSampleFileName;

            string file_type_case = @"sound";

            if (!OpenSaveDialog.Download(server_directory, download_file_name, file_type_case, file_extensions, out i_cancel_download, out o_error))
            {
                o_error = @"SoundSample.DownloadAudioVideoFile OpenSaveDialog.Download failed " + o_error;

                return false;
            }

            return true;

        } // DownloadAudioVideoFile

        /// <summary>
        /// Upload the audio (mp3) or video (mp4) file
        /// <para>Use the member variables for the upload files and directory names: UploadSoundSampleServerDir, UploadSoundSampleFileName, ...</para>
        /// <para>1. Upload the sound sample file. Preset file extension is mp4. Call of OpenSaveDialog.Upload</para>
        /// <para>2. URL (extension) for the uploaded file may have been changed. Modify UploadSoundSampleFileName for this case</para>
        /// <para>3. Set the URL of the uploaded file that shall be registered in the XML season file. Call of SetSoundSampleToSaveUrl</para>
        /// <para>4. Create and upload the QR code image for the uploaded file. Call of CreateUploadSoundQrCodeFile</para>
        /// </summary>
        /// <param name="i_cancel_upload">Flag telling if the user cancelled the upload</param>
        /// <param name="o_error">Error message</param>
        /// <returns>false for failure</returns>
        public static bool UploadAudioVideoFile(out bool i_cancel_upload, out string o_error)
        {
            o_error = @"";

            i_cancel_upload = false;

            string server_dir_name = UploadSoundSampleServerDir;

            server_dir_name = server_dir_name.Substring(4); // Remove www/

            string file_name_with_ext = UploadSoundSampleFileName;

            string error_message = @"";
            string out_file_name_upload = @""; // Output file extension may be changed in OpenSaveDialog.Upload for a new file
            string file_extensions = "mp3,mp4";
            bool b_admin_file = false;
            bool b_create_backup = false;

            if (!OpenSaveDialog.Upload(server_dir_name, file_name_with_ext, "sound", file_extensions, b_admin_file, 
                b_create_backup, out i_cancel_upload, out out_file_name_upload, out error_message))
            {
                o_error = @"SoundSample.UploadAudioVideoFile OpenSaveDialog.Upload failed " + error_message;

                return false;
            }

            string sound_sample_url = UploadSoundSampleUrl;

            if (out_file_name_upload.Contains(".mp3"))
            {
                sound_sample_url = sound_sample_url.Replace(".mp4", @".mp3");

                UploadSoundSampleFileName = out_file_name_upload;

            }

            SetSoundSampleToSaveUrl(sound_sample_url);

            if (!CreateUploadSoundQrCodeFile(out error_message))
            {
                o_error = @"SoundSample.UploadAudioVideoFile CreateUploadSoundQrCodeFile failed " + error_message;

                return false;
            }

            return true;

        } // UploadAudioVideoFile

        /// <summary>
        /// Delete the audio or video file and the QR file. Only the values in the XML file is deleted. 
        /// Then user can cancel. The files are still on the server.
        /// </summary>
        /// <param name="i_cancel_upload">Flag telling if the user cancelled the upload</param>
        /// <param name="o_error">Error message</param>
        /// <returns>false for failure</returns>
        public static bool DeleteAudioVideoFile(out string o_error)
        {
            o_error = @"";

            SetSoundSampleToSaveUrl(@"");

            SetSoundSampleQrCodeToSaveUrl(@"");

            return true;

        } // DeleteAudioVideoFile

        #endregion // Download, upload and delete audio/video file

        #region QR codes

        /// <summary>
        /// Creates and uploads the QR code file for the uploaded sound sample file
        /// <para>1. Get the URL for the file that was uploaded. Call of GetSoundSampleToSaveUrl</para>
        /// <para>2. Generate the QR code image. Call of QrCodeUtils.GenerateQrCodeImage</para>
        /// <para>3. Save QR code image as a local file. Call of QrCodeUtils.SaveQrCode</para>
        /// <para>4. Upload the QR code image to the server. Call of  JazzFtp.Execute.Run, case JazzFtp.Input.Case.UpLoadFile</para>
        /// <para>5. Set the member variable that holds the value for the season XML object (file). Call of SetSoundSampleQrCodeToSaveUrl</para>
        /// </summary>
        /// <param name="o_error"></param>
        /// <returns></returns>
        public static bool CreateUploadSoundQrCodeFile(out string o_error)
        {
            o_error = @"";
 
            //QQ 2021-03-02 string full_url_path_to_sound_file = UploadSoundSampleUrl;

            string full_url_path_to_sound_file = GetSoundSampleToSaveUrl();

            string error_message = "";
            int image_size = 300;
            Bitmap bitmap_qr_code = QrCodeUtils.GenerateQrCodeImage(full_url_path_to_sound_file, image_size, out error_message);
            if (null == bitmap_qr_code)
            {
                o_error = "SoundSample.CreateUploadSoundQrCodeFile QrCodeUtils.GenerateQrCodeImage failed " + error_message;

                return false;
            }

            string name_temp_code_dir = FileUtil.GetFullNameLocalQrCodeDir();

            string file_name_no_ext = Path.GetFileNameWithoutExtension(SoundSample.UploadSoundSampleQrCodeFileName);

            string mime_type = "png";
            string file_name_path = name_temp_code_dir + file_name_no_ext;
            if (!QrCodeUtils.SaveQrCode(bitmap_qr_code, file_name_path, mime_type, out error_message))
            {
                o_error = "SoundSample.CreateUploadSoundQrCodeFile QrCodeUtils.SaveQrCode failed " + error_message;

                return false;
            }

            JazzFtp.Input ftp_upload_xml = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.UpLoadFile);

            ftp_upload_xml.LocalDirectory = FileUtil.GetQrCodeDir();
            ftp_upload_xml.LocalFileName = UploadSoundSampleQrCodeFileName;

            ftp_upload_xml.ServerDirectory = UploadSoundSampleQrCodeServerDir;
            ftp_upload_xml.ServerFileName = UploadSoundSampleQrCodeFileName;

            JazzFtp.Result result_upload = JazzFtp.Execute.Run(ftp_upload_xml);

            if (!result_upload.Status)
            {
                o_error = @"SoundSample.CreateUploadSoundQrCodeFile JazzFtp.Execute.Run (UpLoadFile) failed " + result_upload.ErrorMsg;
                return false;
            }

            SetSoundSampleQrCodeToSaveUrl(UploadSoundSampleQrCodeUrl);

            return true;

        } // CreateUploadSoundQrCodeFile

        /// <summary>Download audio/video QR file</summary>
        /// <param name="i_cancel_download">Flag telling if the user cancelled the download</param>
        /// <param name="o_error">Error message</param>
        public static bool DownloadAudioVideoQrFile(out bool i_cancel_download, out string o_error)
        {
            o_error = @"";
            i_cancel_download = false;

            string file_extensions = @"png";

            string server_directory = DownloadSoundSampleQrCodeServerDir;

            string download_file_name = DownloadSoundSampleQrCodeFileName;

            string file_type_case = @"img";

            if (!OpenSaveDialog.Download(server_directory, download_file_name, file_type_case, file_extensions, out i_cancel_download, out o_error))
            {
                o_error = @"SoundSample.DownloadAudioVideoQrFile OpenSaveDialog.Download failed " + o_error;

                return false;
            }

            return true;

        } // DownloadAudioVideoQrFile

        #endregion // QR codes

        #region Content HTML file with QR codes
        /// <summary>
        /// Returns an HTML string for a web page for the download of sound sample and band website QR codes
        /// </summary>
        /// <param name="i_season_start_year">Season start year</param>
        /// <returns>String defining an HTML page that displays the QR codes</returns>
        public static string QrCodesSoundSampleWebsiteHtmlString(int i_season_start_year)
        {
            string ret_html_str = @"";

            XDocument current_xml_object = JazzXml.GetDocumentCurrent();

            string season_str = JazzUtils.SeasonName(i_season_start_year);

            string error_msg = @"";

            JazzUtils.SetMemberLogin(true);

            if (!AdminUtils.SetCurrentSeason(season_str, out error_msg))
            {
                ret_html_str = @"SoundSample.QrCodesSoundSampleWebsiteHtmlString Error " + error_msg;

                return ret_html_str;
            }

            ret_html_str = ret_html_str + @"<!DOCTYPE html>" + "\n";

            ret_html_str = ret_html_str + @"<html lang='en'>" + "\n";

            ret_html_str = ret_html_str + @"<head>" + "\n";

            ret_html_str = ret_html_str + @"    <meta charset='UTF - 8'>" + "\n";

            ret_html_str = ret_html_str + @"    <meta http-equiv='X - UA - Compatible' content='IE = edge'>" + "\n";

            ret_html_str = ret_html_str + @"    <meta name='viewport' content='width = device - width, initial - scale = 1.0'>" + "\n";

            ret_html_str = ret_html_str + @"    <title>QR Codes</title>" + "\n";

            ret_html_str = ret_html_str + @"</head>" + "\n";

            ret_html_str = ret_html_str + @"<style>" + "\n";

            ret_html_str = ret_html_str + @"body { font-family: 'Arial'; font-size: 15px; background-color: #F5F5F5; } " + "\n";

            ret_html_str = ret_html_str + @"h3 { font-weight: bold; } " + "\n";

            ret_html_str = ret_html_str + @"td { border: 1px solid black; }" + "\n";

            ret_html_str = ret_html_str + @".cl_table_header { font-weight: bold; }" + "\n";

            ret_html_str = ret_html_str + @".cl_table_row { font-weight: normal; }" + "\n";

            ret_html_str = ret_html_str + @".cl_date { padding: 5px; }" + "\n";

            ret_html_str = ret_html_str + @".cl_concert { padding: 5px; }" + "\n";

            ret_html_str = ret_html_str + @".cl_qr { cursor: pointer; padding: 5px; text-align: center; }" + "\n";

            ret_html_str = ret_html_str + @"</style>" + "\n";

            ret_html_str = ret_html_str + @"" + "\n";

            ret_html_str = ret_html_str + @"<body>" + "\n";

            ret_html_str = ret_html_str + @"    <h3>QR Codes " + season_str + @"</h3>" + "\n";

            ret_html_str = ret_html_str + @"" + "\n";

            ret_html_str = ret_html_str + @"    <table>" + "\n";

            ret_html_str = ret_html_str + @"        <tr class= 'cl_table_header'>" + "\n";

            ret_html_str = ret_html_str + @"            <td class= 'cl_date'>Datum</td>" + "\n";

            ret_html_str = ret_html_str + @"            <td class= 'cl_concert'>Konzert</td>" + "\n";

            ret_html_str = ret_html_str + @"            <td class= 'cl_qr'>QR Sound</td>" + "\n";

            ret_html_str = ret_html_str + @"            <td class= 'cl_qr'>QR Web</td>" + "\n";

            ret_html_str = ret_html_str + @"        </tr>" + "\n";

            ret_html_str = ret_html_str + @"" + "\n";

            int n_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

            for (int concert_number = 1; concert_number <= n_concerts; concert_number++)
            {
                ret_html_str = ret_html_str + QrCodesSoundSampleWebsiteHtmlRowString(concert_number);
            }

            ret_html_str = ret_html_str + @"" + "\n";

            ret_html_str = ret_html_str + @"    </table>" + "\n";

            ret_html_str = ret_html_str + @"" + "\n";

            ret_html_str = ret_html_str + @"</body>" + "\n";

            ret_html_str = ret_html_str + @"</html>" + "\n";

            JazzXml.SetDocumentCurrent(current_xml_object);

            return ret_html_str;

        } // QrCodesSoundSampleWebsiteHtmlString

        /// <summary>
        /// Returns one row for the HTML file
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        /// <returns>One row for the HTML file</returns>
        private static string QrCodesSoundSampleWebsiteHtmlRowString(int i_concert_number)
        {
            string ret_html_row_str = @"";

            int concert_year_int = JazzXml.GetYearInt(i_concert_number);

            int concert_month_int = JazzXml.GetMonthInt(i_concert_number);

            int concert_day_int = JazzXml.GetDayInt(i_concert_number);

            string concert_date = TimeUtil.ConcertYearMonthDayIso(concert_year_int, concert_month_int, concert_day_int);

            string concert_band = JazzXml.GetBandName(i_concert_number);

            string sound_qr = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetSoundSampleQrCode(i_concert_number));

            string website_qr = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetBandWebsiteQrCode(i_concert_number));

            ret_html_row_str = ret_html_row_str + @"" + "\n";

            ret_html_row_str = ret_html_row_str + @"        <tr class= 'cl_table_row'>" + "\n";

            ret_html_row_str = ret_html_row_str + @"            <td class= 'cl_date'>" + concert_date + @"</td>" + "\n";

            ret_html_row_str = ret_html_row_str + @"            <td class= 'cl_concert'>" + concert_band + @"</td>" + "\n";

            if (sound_qr.Length == 0)
            {
                ret_html_row_str = ret_html_row_str + @"            <td class= 'cl_qr'>-</td>" + "\n";
            }
            else
            {
                ret_html_row_str = ret_html_row_str + @"            <td class= 'cl_qr'><a href= '" + sound_qr + @"'>IMG</a></td>" + "\n";
            }

            if (website_qr.Length == 0)
            {
                ret_html_row_str = ret_html_row_str + @"            <td class= 'cl_qr'>-</td>" + "\n";
            }
            else
            {
                ret_html_row_str = ret_html_row_str + @"            <td class= 'cl_qr'><a href= '" + website_qr + @"'>IMG</a></td>" + "\n";
            }

            ret_html_row_str = ret_html_row_str + @"        </tr>" + "\n";

            return ret_html_row_str;

        } // QrCodesSoundSampleWebsiteHtmlRowString

        #endregion // Content HTML file with QR codes

    } // SoundSample

} // namespace
