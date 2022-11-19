using JazzApp;
using JazzFtp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Handles the upload of a photo gallery
    /// <para></para>
    /// </summary>
    public class PhotoUpload
    {
        #region Member variables

        /// <summary>Input JazzPhoto object</summary>
        private JazzPhoto m_jazz_photo_input = null;

        /// <summary>JazzPhoto object with data from the local gallery text file</summary>
        private JazzPhoto m_jazz_photo_local_dir = null;

        /// <summary>Full path to the local directory with gallery pictures</summary>
        private string m_local_gallery_directory = @"";

        /// <summary>Debug flag</summary>
        private bool m_debug = false;
        /// <summary>Get and set debug flag</summary>
        private bool Debug { get { return m_debug; } set { m_debug = value; } }

        /// <summary>Debug string</summary>
        private string m_debug_string = @"";
        /// <summary>Get and set debug string</summary>
        private string DebugStr { get { return m_debug_string; } set { m_debug_string = value; } }

        /// <summary>New line (for Windows)</summary>
        private string m_new_line = "\r\n";
        /// <summary>Get new line (for Windows)</summary>
        private string NewLine { get { return m_new_line; } }

        /// <summary>Quote in string</summary>
        private string m_quote = "\"";
        /// <summary>Get quote in string</summary>
        private string QuoteChar { get { return m_quote; } }

        /// <summary>Debug file name</summary>
        private string m_debug_file_name = @"DebugPhotoUpload.txt";
        /// <summary>Get debug file name</summary>
        private string DebugFileName { get { return m_debug_file_name; }  }

        /// <summary>Debug full (with path) file name</summary>
        private string m_debug_file_path = @"DebugPhotoUpload.txt";
        /// <summary>Get and set debug full (with path) file name</summary>
        private string DebugFile { get { return m_debug_file_path; } set { m_debug_file_path = value; } }

        /// <summary>Full path to local maintenance directory</summary>
        private string m_local_maintenace_directory = @"";
        /// <summary>Get and set full path to local maintenance directory</summary>
        private string MaintenanceDir { get { return m_local_maintenace_directory; } set { m_local_maintenace_directory = value; } }

        /// <summary>Full path to local photo scripts directory</summary>
        private string m_local_photo_scripts_directory = @"";
        /// <summary>Get and set full path to local photo scripts directory</summary>
        private string PathPhotoScriptsDir { get { return m_local_photo_scripts_directory; } set { m_local_photo_scripts_directory = value; } }

        /// <summary>Full path to local photo concerts directory</summary>
        private string m_local_photo_concerts_directory = @"";
        /// <summary>Get and set full path to local photo concerts directory</summary>
        private string PathPhotoConcertsDir { get { return m_local_photo_concerts_directory; } set { m_local_photo_concerts_directory = value; } }

        /// <summary>Full path to local photo gallery directory</summary>
        private string m_local_photo_gallery_directory = @"";
        /// <summary>Get and set full path to local photo gallery directory</summary>
        private string PathPhotoGalleryDir { get { return m_local_photo_gallery_directory; } set { m_local_photo_gallery_directory = value; } }

        /// <summary>TextBox for messages (may be null)</summary>
        private TextBox m_textbox_message = null;
        /// <summary>Get and set TextBox for messages (may be null)</summary>
        private TextBox TxtBoxMsg { get { return m_textbox_message; } set { m_textbox_message = value; } }

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor: No debug</summary>
        public PhotoUpload()
        {
            Debug = false;

            SetLocalFoldersFiles();

        } // Constructor: No debug

        /// <summary>Constructor: Debug</summary>
        public PhotoUpload(bool i_debug)
        {
            Debug = i_debug;

            SetLocalFoldersFiles();

        } // Constructor: Debug

        #endregion // Constructor

        #region Main execution function

        /// <summary>Execute upload of the photo gallery
        /// <para>There is a local directory with small and big pictures that shall be uploaded to the server.</para>
        /// <para>There is also a text file with data (names of the musicians) in this directory.</para>
        /// <para>1. Get data from the textfile in the directory with the pictures. Call of GetDataLocalDirectory</para>
        /// <para>2. Check the data of the local picture directory. Call of CheckDataLocalDirectory</para>
        /// <para>3. Generate the local JavaScript data file (e.g. JazzFotosDaten_2019.js) and save in Fotos/FotoScripts. Call of GenerateJazzFotosDatenJs</para>
        /// <para>4. Generate the HTML files and save in Fotos/FotoKonzerte/Konzert.200YY.MM.DD. Call of GenerateGalleryHtmlFiles</para>
        /// <para>5. Generate the Bisher file JazzBisherFotos.20YY.htm and save in Fotos/FotoKonzerte. Call of GenerateBisherHtmlFile</para>
        /// <para>6. Generate the Bisher file JazzGalerieZwei.htm and save in Fotos/FotoGalerie. Call of GenerateJazzGalleryTwoHtmlFile</para>
        /// <para>7. Upload the local files to the server. Call of UploadGalleryFiles</para>
        /// <para>8. Set the XML object corresponding to file JazzFotoGalerieZwei.xml with data about the uploaded gallery. Call of SetXmlUploadedGallery</para>
        /// <para>9. Update the XML object JazzFotoGalerieZwei.xml corresponding to file . Call of PhotoMain.UpdateGallerySeasonXmlFile</para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_textbox_message">Text box for messages. Can be null</param>
        /// <param name="o_error">Error description</param>
        public bool Execute(JazzPhoto i_jazz_photo, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            TxtBoxMsg = i_textbox_message;
            ShowMsg(PhotoStrings.MsgUploadGalleryStart);
            DebugStringInit();
            DebugStringAppend(@"Enter PhotoUpload.Execute");

            if (null == i_jazz_photo)
            {
                o_error = @"PhotoUpload.Execute i_jazz_photo is null";
                return false;
            }

            m_jazz_photo_input = i_jazz_photo;
            m_jazz_photo_local_dir = m_jazz_photo_input;

            DebugStringAppend(@"Bandname " + m_jazz_photo_input.BandName);

            ShowMsg(PhotoStrings.MsgUploadGalleryGetCheckLocalData);
            if (!GetDataLocalDirectory(out o_error))
            {
                o_error = @"PhotoUpload.Execute GetDataLocalDirectory failed " + o_error;
                ShowMsg(o_error);
                DebugStringAppend(o_error);
                return false;
            }

            if (!CheckDataLocalDirectory(out o_error))
            {
                // Error for the user o_error = @"PhotoUpload.Execute CheckDataLocalDirectory failed " + o_error;
                ShowMsg(o_error);
                DebugStringAppend(o_error);
                return false;
            }

            ShowMsg(PhotoStrings.MsgUploadGalleryGenerateHtmlJavaScriptFiles);
            DebugStringAppend(PhotoStrings.MsgUploadGalleryGenerateHtmlJavaScriptFiles);
            int year_concert_number_add = -12345;
            if (!GenerateJazzFotosDatenJs(m_jazz_photo_local_dir, i_textbox_message, out year_concert_number_add, out o_error))
            {
                o_error = @"PhotoUpload.Execute GenerateJazzFotosDatenJs failed " + o_error;
                ShowMsg(o_error);
                DebugStringAppend(o_error);
                return false;
            }

            if (!GenerateGalleryHtmlFiles(m_jazz_photo_local_dir, year_concert_number_add, out o_error))
            {
                o_error = @"PhotoUpload.Execute GenerateGalleryHtmlFiles failed " + o_error;
                ShowMsg(o_error);
                DebugStringAppend(o_error);
                return false;
            }

            if (!GenerateBisherHtmlFile(m_jazz_photo_local_dir, out  o_error))
            {
                o_error = @"PhotoUpload.Execute GenerateBisherHtmlFile failed " + o_error;
                ShowMsg(o_error);
                DebugStringAppend(o_error);
                return false;
            }

            if (!GenerateJazzGalleryTwoHtmlFile(out o_error))
            {
                o_error = @"PhotoUpload.Execute GenerateJazzGalleryTwoHtmlFile failed " + o_error;
                ShowMsg(o_error);
                DebugStringAppend(o_error);
                return false;
            }

            if (!Debug)
            {
                ShowMsg(PhotoStrings.MsgUploadAllGalleryFiles);
                DebugStringAppend(PhotoStrings.MsgUploadAllGalleryFiles);
                if (!UploadGalleryFiles(m_jazz_photo_local_dir, out o_error))
                {
                    o_error = @"PhotoUpload.Execute UploadGalleryFiles failed " + o_error;
                    ShowMsg(o_error);
                    DebugStringAppend(o_error);
                    return false;
                }
            }

            ShowMsg(PhotoStrings.MsgUploadGalleryUpdateXml);
            DebugStringAppend(PhotoStrings.MsgUploadGalleryUpdateXml);
            bool b_only_test = false;
            if (Debug)
            {
                b_only_test = true;
            }
            if (!SetXmlUploadedGallery(m_jazz_photo_local_dir, b_only_test, out o_error))
            {
                o_error = @"PhotoUpload.Execute SetXmlUploadedGallery failed " + o_error;
                ShowMsg(o_error);
                DebugStringAppend(o_error);
                return false;
            }

            ShowMsg(PhotoStrings.MsgUploadGalleryUpdateSeasonProgramXml);
            DebugStringAppend(PhotoStrings.MsgUploadGalleryUpdateSeasonProgramXml);
            if (!PhotoMain.UpdateGallerySeasonXmlFile(m_jazz_photo_local_dir, out o_error))
            {
                o_error = @"PhotoUpload.Execute PhotoMain.UpdateGallerySeasonXmlFile failed " + o_error;
                ShowMsg(o_error);
                DebugStringAppend(o_error);
                return false;
            }

            ShowMsg(PhotoStrings.MsgUploadGalleryFinished);
            DebugStringAppend(@"Exit PhotoUpload.Execute");
            DebugCreateFile();

            return true;

        } // Execute

        #endregion // Main execution function

        #region Upload the files for the added gallery

        /// <summary>
        /// Upload the file JazzGalerieZwei.htm to the server
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>false for failure</returns>
        public bool UploadGalleryFileTwo(out string o_error)
        {
            o_error = @"";

            string local_directory_gallery = PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.GalleryOneServerDir; ;

            string server_directory_gallery = @"www/" + PhotoMain.GalleryOneServerDir;

            string file_name_gallery = PhotoMain.GalleryTwoHtmlFileName;

            string local_address_directory_js = PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.PhotoScriptsDir;

            string server_directory_js = @"www/" + PhotoMain.PhotoScriptsDir;

            string file_name_js = PhotoMain.JazzFotosDatenFileNameStart + @"2020.js";

            JazzFtp.Input ftp_input_gallery = new JazzFtp.Input(Main.ExeDirectory, Input.Case.UpLoadFile);

            ftp_input_gallery.ServerDirectory = server_directory_gallery;
            ftp_input_gallery.ServerFileName = file_name_gallery;

            ftp_input_gallery.LocalDirectory = local_directory_gallery;
            ftp_input_gallery.LocalFileName = file_name_gallery;

            JazzFtp.Result ftp_result_gallery = JazzFtp.Execute.Run(ftp_input_gallery);

            if (!ftp_result_gallery.Status)
            {
                o_error = @"PhotoUpload.UploadGalleryFileTwo JazzFtp.Execute.Run for gallery two file failed " + ftp_result_gallery.ErrorMsg;
                return false;
            }

            return true;

        } // UploadGalleryFileTwo


        /// <summary>Upload JavaScript and Bisher files for the added gallery
        /// <para>1. Construct file and directory names for the JavaScript file e.g. JazzFotosDaten_2019.js</para>
        /// <para>2. Upload the JavaScript file. Call of JazzFtp.Execute.Run</para>
        /// <para>3. Construct file and directory names for the HTML bisher file e.g. JazzBisherFotos.2019.htm</para></para>
        /// <para>4. Upload the HTML file. Call of JazzFtp.Execute.Run</para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto for the added gallery</param>
        /// <param name="o_error">Error description</param>
        private bool UploadJavaScriptBisherFiles(JazzPhoto i_jazz_photo, out string o_error)
        {
            o_error = @"";

            string local_address_directory_js = PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.PhotoScriptsDir;

            string server_directory_js = @"www/" + PhotoMain.PhotoScriptsDir;

            string file_name_js = PhotoMain.JazzFotosDatenFileNameStart + i_jazz_photo.Year + @".js";

            JazzFtp.Input ftp_input_js = new JazzFtp.Input(Main.ExeDirectory, Input.Case.UpLoadFile);

            ftp_input_js.ServerDirectory = server_directory_js;
            ftp_input_js.ServerFileName = file_name_js;

            ftp_input_js.LocalDirectory = local_address_directory_js;
            ftp_input_js.LocalFileName = file_name_js;

            JazzFtp.Result ftp_result_js = JazzFtp.Execute.Run(ftp_input_js);

            if (!ftp_result_js.Status)
            {
                o_error = @"PhotoUpload.UploadJavaScriptBisherFiles JazzFtp.Execute.Run for js file failed " + ftp_result_js.ErrorMsg;
                return false;
            }

            string local_address_directory_htm = PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.GalleryTwoServerDir;

            string server_directory_htm = @"www/" + PhotoMain.GalleryTwoServerDir;

            string file_name_htm = PhotoMain.BisherFileNameStartString + i_jazz_photo.Year + @".htm";

            JazzFtp.Input ftp_input_htm = new JazzFtp.Input(Main.ExeDirectory, Input.Case.UpLoadFile);

            ftp_input_htm.ServerDirectory = server_directory_htm;
            ftp_input_htm.ServerFileName = file_name_htm;

            ftp_input_htm.LocalDirectory = local_address_directory_htm;
            ftp_input_htm.LocalFileName = file_name_htm;

            JazzFtp.Result ftp_result_htm = JazzFtp.Execute.Run(ftp_input_htm);

            if (!ftp_result_htm.Status)
            {
                o_error = @"PhotoUpload.UploadJavaScriptBisherFiles JazzFtp.Execute.Run for htm file failed " + ftp_result_htm.ErrorMsg;
                return false;
            }

            return true;

        } // UploadJavaScriptBisherFiles

        /// <summary>Upload files for the added gallery
        /// <para>All picture, HTML and JavaScript files that will be uploaded are already created. </para>
        /// <para>They are in two subdirectories of the Admin Photos directory: FotoKonzerte and FotoScripts</para>
        /// <para>1. Return error if the gallery already has been uploaded. Call of PhotoMain.GalleryExistsOnServer</para>
        /// <para>2. Get arrays with picture names. Call of GetUploadPictureFileNames.</para>
        /// <para>3. Get HTML file names. Call of GetUploadHtmlFileNames</para>
        /// <para>4. Create the gallery directory on the server. Call of PhotoMain.CreateServerGalleryDirectory</para>
        /// <para>5. Get the path to the server gallery directory. Call of PhotoMain.GetGalleryTwoDirServerPath</para>
        /// <para>6. Loop file types: Big photos (1), small photos (2), HTML picture files (3) and the gallery HTML file (4)</para>
        /// <para>6.1 Select array of file names that shall be uploaded and display the type of files that are uploaded (ShowMsg). </para>
        /// <para>6.2 </para>
        /// <para>6.3 Loop all files</para>
        /// <para>6.3.1 Call of JazzFtp.Execute</para>
        /// <para>7. Upload of the bisher JavaScript files. Call of UploadJavaScriptBisherFiles</para>
        /// <para>8. Upload of the file JazzGalerieZwei.htm. Call of UploadGalleryFileTwo</para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto for the added gallery</param>
        /// <param name="o_error">Error description</param>
        private bool UploadGalleryFiles(JazzPhoto i_jazz_photo, out string o_error)
        {
            o_error = @"";

            bool dir_exists = false;
            if (!PhotoMain.GalleryExistsOnServer(i_jazz_photo, out dir_exists, out o_error))
            {
                o_error = @"PhotoUpload.UploadGalleryFiles PhotoMain.GalleryExistsOnServer failed " + o_error;
                return false;
            }

            if (dir_exists)
            {
                o_error = PhotoStrings.ErrMsgGalleryIsAlreadyUploaded;
                return false;
            }

            string[] big_pic_file_names = null;
            string[] small_pic_file_names = null;
            if (!GetUploadPictureFileNames(i_jazz_photo, out big_pic_file_names, out small_pic_file_names, out o_error))
            {
                o_error = @"PhotoUpload.UploadGalleryFiles GetUploadPictureFileNames failed " + o_error;
                return false;
            }

            string gallery_html_file_name = @"";
            string[] html_pic_file_names = null;
            if (!GetUploadHtmlFileNames(i_jazz_photo, out gallery_html_file_name, out html_pic_file_names, out o_error))
            {
                o_error = @"PhotoUpload.UploadGalleryFiles GetUploadHtmlFileNames failed " + o_error;
                return false;
            }

            if (!PhotoMain.CreateServerGalleryDirectory(i_jazz_photo, out o_error))
            {
                o_error = @"PhotoUpload.UploadGalleryFiles PhotoMain.CreateServerGalleryDirectory failed " + o_error;
                return false;
            }

            string server_gallery_dir = PhotoMain.GetGalleryTwoDirServerPath(i_jazz_photo);
            if (server_gallery_dir.Length == 0)
            {
                o_error = @"PhotoMain.GalleryExistsOnServer GetGalleryTwoDirServerPath failed";
                return false;
            }

            string[] upload_files = null;
            for (int file_type = 1; file_type <= 4; file_type++)
            {
                if (1 == file_type)
                {
                    ShowMsg(PhotoStrings.MsgUploadGalleryBigPhotos);
                    upload_files = big_pic_file_names;
                }
                else if (2 == file_type)
                {
                    ShowMsg(PhotoStrings.MsgUploadGallerySmallPhotos);
                    upload_files = small_pic_file_names;
                }
                else if (3 == file_type)
                {
                    ShowMsg(PhotoStrings.MsgUploadGalleryHtml);
                    upload_files = html_pic_file_names;
                }
                else if (4 == file_type)
                {
                    upload_files = new string[1];
                    upload_files[0] = gallery_html_file_name;
                }
                string directory_name = @"";
                if (!i_jazz_photo.GalleryTwoDirectoryName(out directory_name, out o_error))
                {
                    o_error = @"PhotoMain.UploadGalleryFiles JazzPhoto.GalleryTwoDirectoryName failed " + o_error;

                    return false;
                }
                string local_directory = PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.GalleryTwoServerDir + @"\" + directory_name;

                for (int index_file = 0; index_file < upload_files.Length; index_file++)
                {
                    JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, Input.Case.UpLoadFile);

                    ftp_input.ServerDirectory = server_gallery_dir;
                    ftp_input.ServerFileName = upload_files[index_file];

                    ftp_input.LocalDirectory = local_directory; // Not m_local_gallery_directory;
                    ftp_input.LocalFileName = upload_files[index_file];

                    JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

                    if (!ftp_result.Status)
                    {
                        o_error = @"PhotoUpload.UploadGalleryFiles JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                        return false;
                    }

                } // index_file

            } // file_type

            ShowMsg(PhotoStrings.MsgUploadGalleryJavaScript);
            if (!UploadJavaScriptBisherFiles(i_jazz_photo, out o_error))
            {
                o_error = @"PhotoUpload.UploadGalleryFiles UploadJavaScriptBisherFiles failed " + o_error;
                return false;
            }

            ShowMsg(PhotoStrings.MsgUploadGalleryTwoHtml);
            if (!UploadGalleryFileTwo(out o_error))
            {
                o_error = @"PhotoUpload.UploadGalleryFiles UploadGalleryFileTwo failed " + o_error;
                return false;
            }

            return true;

        } // UploadGalleryFiles

        /// <summary>Get upload local and server picture file names 
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto for the added gallery</param>
        /// <param name="o_error">Error description</param>
        private bool GetUploadHtmlFileNames(JazzPhoto i_jazz_photo, out string o_gallery_html_file_name,
                                            out string[] o_html_pic_file_names, out string o_error)
        {
            o_error = @"";
            o_gallery_html_file_name = @"";

            o_html_pic_file_names = new string[9];

            string local_gallery_dir = @"";
            if (!i_jazz_photo.GalleryTwoDirectoryName(out local_gallery_dir, out o_error))
            {
                o_error = @"PhotoUpload.GenerateGalleryHtmlFiles JazzPhoto.GalleryTwoDirectoryName failed " + o_error;
                return false;
            }

            string server_dir = PhotoMain.GetGalleryTwoDirServerPath(i_jazz_photo);
            if (server_dir.Length < 4)
            {
                o_error = @"PhotoUpload.GetUploadHtmlFileNames PhotoMain.GetGalleryTwoDirServerPath failed " + o_error;
                return false;
            }

            string file_name_gallery = PhotoMain.GalleryHtmFileNameStartString + i_jazz_photo.GalleryName + @".htm";

            o_gallery_html_file_name = file_name_gallery;

            for (int index_file = 0; index_file < 9; index_file++)
            {
                int file_number = index_file + 1;
                string file_name_image = PhotoMain.GalleryPhotoFileNameStartString + i_jazz_photo.GalleryName + @"_0" + file_number.ToString() + @".htm";

                o_html_pic_file_names[index_file] = file_name_image;

            } // index_file

            return true;

        } // GetUploadHtmlFileNames

        /// <summary>Get upload local and server picture file names without paths
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto for the added gallery</param>
        /// <param name="o_error">Error description</param>
        private bool GetUploadPictureFileNames(JazzPhoto i_jazz_photo, 
            out string[] o_big_pic_file_names, out string[] o_small_pic_file_names, out string o_error)
        {
            o_error = @"";
            o_big_pic_file_names = null;
            o_small_pic_file_names = null;

            o_big_pic_file_names = GetBigPictureFileNames(i_jazz_photo, out o_error);
            if (null == o_big_pic_file_names)
            {
                o_error = @"PhotoUpload.GetUploadPictureFileNames GetBigPictureFileNames failed " + o_error;
                return false;
            }

            o_small_pic_file_names = GetSmallPictureFileNames(i_jazz_photo, out o_error);
            if (null == o_small_pic_file_names)
            {
                o_error = @"PhotoUpload.GetUploadPictureFileNames GetSmallPictureFileNames failed " + o_error;
                return false;
            }

            return true;

        } // GetUploadPictureFileNames

        #endregion // Upload the files for the added gallery

        #region Set uploaded JazzPhoto object XML data

        /// <summary>Set XML data for the uploaded gallery
        /// <para>1. Get JazzPhoto season number and concert number. Call of SetXmlUploadedGallery</para>
        /// <para>2. Get the XML object holding the data about photos and galleries. Call of JazzXml.GetObjectPhotoTwo</para>
        /// <para>3. Set the data for the gallery that have been uploaded. Call of JazzXml.SetPhotoTwo</para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto for the uploaded gallery</param>
        /// <param name="b_only_test">If true XML data will be set as test. Afterwards the original data will be reset </param>
        /// <param name="o_error">Error description</param>
        private bool SetXmlUploadedGallery(JazzPhoto i_jazz_photo, bool b_only_test, out string o_error)
        {
            o_error = @"";

            int season_number = -12345;
            int concert_number = -12345;
            if (!PhotoMain.GetJazzPhotoSeasonConcert(i_jazz_photo, out season_number, out concert_number, out o_error))
            {
                o_error = @"PhotoUpload.SetXmlUploadedGallery PhotoMain.GetJazzPhotoSeasonConcert failed " + o_error;
                return false;
            }

            XDocument xdocument_before_change = JazzXml.GetObjectPhotoTwo();

            if (!JazzXml.SetPhotoTwo(season_number, concert_number, i_jazz_photo, out o_error))
            {
                o_error = @"PhotoUpload.SetXmlUploadedGallery JazzXml.SetPhotoTwo failed " + o_error;
                return false;
            }

            if (b_only_test)
            {
                XDocument xdocument_after_change = JazzXml.GetObjectPhotoTwo();

                DebugCreateXmlFile(xdocument_after_change, @"Debug_PhotoTwoAfterSetGalleryData.xml");

                JazzXml.SetObjectPhotoTwo(xdocument_before_change);
            }

            return true;

        } // SetXmlUploadedGallery

        #endregion // Set uploaded JazzPhoto object XML data

        #region Get and check data from the local gallery directory

        /// <summary>Get data from the local gallery directory text file
        /// <para>Big and small pictures have been created and placed in a local directory</para>
        /// <para>There is also a text file with the names of the musicians and with flags telling if the pictures exist</para>
        /// <para>The pictures and the text file is in a subdirectory to the Admin Photos directory, e.g. Konzert.2019.11.30</para>
        /// <para>The name of the text file is Gallery name/number, e.g. G138.txt</para>
        /// <para>Data for the upload is saved in the JazzPhoto object JazzUpdate.m_jazz_photo_local_dir</para>
        /// <para>1. Get the name and the path to the local directory with the pictures and the text file. Call of GetNameAndPathToLocalGalleryDirectory</para>
        /// <para>2. Get the data from the text file. Call of GetDataFromLocalGalleryDirectory</para>
        /// </summary>
        private bool GetDataLocalDirectory(out string o_error)
        {
            o_error = @"";

            if (!PhotoMain.GetNameAndPathToLocalGalleryDirectory(m_jazz_photo_local_dir, out m_local_gallery_directory, out o_error))
            {
                o_error = @"PhotoUpload.GetDataLocalDirectory GetNameAndPathToLocalGalleryDirectory failed " + o_error;
                
                return false;
            }

            if (!m_jazz_photo_local_dir.GetDataFromLocalGalleryDirectory(m_local_gallery_directory, out o_error))
            {
                o_error = @"PhotoUpload.GetDataLocalDirectory JazzPhoto.GetDataFromLocalGalleryDirectory failed " + o_error;

                return false;
            }

            return true;

        } // GetDataLocalDirectory

        /// <summary>Check data from the local gallery directory text file
        /// <para>Data about the local directory with the gallery pictures have been retrieved</para>
        /// <para>This data is saved in the in the JazzPhoto object JazzUpdate.m_jazz_photo_local_dir</para>
        /// <para>1. Check the flags that small and big pictures exist. Calls of JazzPhoto.BigPictureIsSet and SmallPictureIsSet</para>
        /// <para>2. Get the names of the picture files. Call of GetBigPictureFileNames and GetSmallPictureFileNames</para>
        /// <para>3. Loop for the nine pictures</para>
        /// <para>3.1 Check that the big and small photo exists. Calls of File.Exists</para>
        /// </summary>
        private bool CheckDataLocalDirectory(out string o_error)
        {
            o_error = @"";

            for (int picture_number = 1; picture_number <= 9; picture_number++)
            {
                if (!m_jazz_photo_local_dir.BigPictureIsSet(picture_number) || !m_jazz_photo_local_dir.SmallPictureIsSet(picture_number))
                {
                    o_error = PhotoStrings.ErrMsgMissingPicturesInGallery + picture_number.ToString();

                    return false;
                }

            } // picture_number

            string[] big_pic_file_names = GetBigPictureFileNames(m_jazz_photo_local_dir, out o_error);
            if (null == big_pic_file_names)
            {
                o_error = @"PhotoUpload.GetDataLocalDirectory GetBigPictureFileNames failed " + o_error;
                return false;
            }

            string[] small_pic_file_names = GetSmallPictureFileNames(m_jazz_photo_local_dir, out o_error);
            if (null == small_pic_file_names)
            {
                o_error = @"PhotoUpload.GetDataLocalDirectory GetSmallPictureFileNames failed " + o_error;
                return false;
            }

            for (int picture_file = 1; picture_file <= 9; picture_file++)
            {
                string file_name_big_path = m_local_gallery_directory + big_pic_file_names[picture_file - 1];
                string file_name_small_path = m_local_gallery_directory + small_pic_file_names[picture_file - 1];


                if (!File.Exists(file_name_big_path))
                {
                    o_error = PhotoStrings.ErrMsgMissingPictureFileInGallery + file_name_big_path;

                    return false;
                }

                if (!File.Exists(file_name_small_path))
                {
                    o_error = PhotoStrings.ErrMsgMissingPictureFileInGallery + file_name_small_path;

                    return false;
                }

            } // picture_file

            DebugStringAppend(@"PhotoUpload.CheckDataLocalDirectory All picture boolean flags are true and all picture files are in" + NewLine + "the local directory " + m_local_gallery_directory);

            return true;

        } // CheckDataLocalDirectory

        /// <summary>Returns the names of the big pictures files without path.</summary>
        private string[] GetBigPictureFileNames(JazzPhoto i_jazz_photo, out string o_error)
        {
            o_error = @"";

            string[] ret_big_pic_names = new string[9];

            for (int picture_file = 1; picture_file <= 9; picture_file++)
            {
                string file_name_big = @"";

                bool b_big = true;
                if (!m_jazz_photo_local_dir.GalleryPhotoName(b_big, picture_file, out file_name_big, out o_error))
                {
                    o_error = @"PhotoUpload.GetBigPictureFileNames JazzPhoto.GalleryPhotoName failed " + o_error;
                    return null;
                }

                ret_big_pic_names[picture_file - 1] = file_name_big;

            } // picture_file

            return ret_big_pic_names;

        } // GetBigPictureFileNames

        /// <summary>Returns the names of the small pictures files without path</summary>
        private string[] GetSmallPictureFileNames(JazzPhoto i_jazz_photo, out string o_error)
        {
            o_error = @"";

            string[] ret_small_pic_names = new string[9];

            for (int picture_file = 1; picture_file <= 9; picture_file++)
            {
                string file_name_small = @"";

                bool b_big = false;
                if (!m_jazz_photo_local_dir.GalleryPhotoName(b_big, picture_file, out file_name_small, out o_error))
                {
                    o_error = @"PhotoUpload.GetSmallPictureFileNames JazzPhoto.GalleryPhotoName failed " + o_error;
                    return null;
                }

                ret_small_pic_names[picture_file - 1] = file_name_small;

            } // picture_file

            return ret_small_pic_names;

        } // GetSmallPictureFileNames

        #endregion // Get and check data from the local gallery directory

        #region Write JazzPhoto 


        #endregion // Write JazzPhoto 

        #region Generate gallery HTML files

        /// <summary>Generate HTML files for a gallery that shall be uploaded to the server
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_year_concert_number_add">Year (not season) concert number that defines the name of variable in JazzFotosDaten_20NN.js</param>
        /// <param name="o_error">Error description</param>
        private bool GenerateGalleryHtmlFiles(JazzPhoto i_jazz_photo, int i_year_concert_number_add, out string o_error)
        {
            o_error = @"";

            bool b_gallery = true;
            string content_gallery = StartPartGalleryHtmlFile(i_jazz_photo, b_gallery);

            string concert_data = @"ConcertData_" + i_year_concert_number_add.ToString();

            content_gallery = content_gallery + @"    <script language='JavaScript'>document.write(BodySmallPhotos(" + concert_data + @"))</script>" + NewLine;

            content_gallery = content_gallery + EndPartGalleryHtmlFile();

            string[] content_image_files = new string[9];

            for (int index_image = 0; index_image < 9; index_image++)
            {
                string content_image = @"";
                int image_number = index_image + 1;

                b_gallery = false;
                content_image = content_image + StartPartGalleryHtmlFile(i_jazz_photo, b_gallery);

                content_image = content_image + @"    <script language='JavaScript'>document.write(" + ScriptFunction(i_year_concert_number_add, image_number) + @")</script>" + NewLine;

                content_image = content_image + EndPartGalleryHtmlFile();

                content_image_files[index_image] = content_image;

            } // index_image

            string local_gallery_dir = @"";
            if (!i_jazz_photo.GalleryTwoDirectoryName(out local_gallery_dir, out o_error))
            {
                o_error = @"PhotoUpload.GenerateGalleryHtmlFiles JazzPhoto.GalleryTwoDirectoryName failed " + o_error;
                return false;
            }

            string local_address_directory = FileUtil.SubDirectory(PathPhotoConcertsDir + local_gallery_dir + @"\", Main.m_exe_directory);

            string file_name_gallery = PhotoMain.GalleryHtmFileNameStartString + i_jazz_photo.GalleryName + @".htm";

            string full_file_name_gallery = local_address_directory + file_name_gallery;

            File.WriteAllText(full_file_name_gallery, content_gallery, Encoding.UTF8);

            for (int index_file = 0; index_file < 9; index_file++)
            {
                int file_number = index_file + 1;
                string file_name_image = PhotoMain.GalleryPhotoFileNameStartString + i_jazz_photo.GalleryName + @"_0" + file_number.ToString() + @".htm";

                string full_file_name_image = local_address_directory + file_name_image;

                File.WriteAllText(full_file_name_image, content_image_files[index_file], Encoding.UTF8);

            } // index_file

            DebugStringAppend(@"GenerateGalleryHtmlFiles Files are created in directory " + local_address_directory);

            return true;

        } // GenerateGalleryHtmlFiles

        /// <summary>Generate the JazzBisherFotos.20NN.htm HTML file
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto</param>
        /// <param name="o_error">Error description</param>
        public bool GenerateBisherHtmlFile(JazzPhoto i_jazz_photo, out string o_error)
        {
            o_error = @"";

            //bool b_gallery = true;
            string content_bisher = StartHeaderHtmlFile();

            content_bisher = content_bisher + @"    <TITLE>Fotos " + i_jazz_photo.Year + @" JAZZ live AARAU</TITLE>" + NewLine;

            bool b_bisher = true;
            content_bisher = content_bisher + ScriptFilesHtmlFiles(i_jazz_photo, b_bisher);

            content_bisher = content_bisher + @"  <BODY text=#FF0028 vLink=color=#FF0028 aLink=color=#FF0028 link=color=#FF0028 bgColor='#FFFFFF' BODY scrolling='auto'>" + NewLine;

            content_bisher = content_bisher + @"    <script language='JavaScript'>document.write(BodyConcertPhotos())</script>" + NewLine;

            content_bisher = content_bisher + EndPartGalleryHtmlFile();

            string file_name_bisher = PhotoMain.BisherFileNameStartString + i_jazz_photo.Year + @".htm";

            string full_file_name_gallery = PathPhotoConcertsDir + file_name_bisher;

            File.WriteAllText(full_file_name_gallery, content_bisher, Encoding.UTF8);

            DebugStringAppend(@"GenerateBisherHtmlFile File " + file_name_bisher + @" is created in directory " + PathPhotoConcertsDir);

            return true;

        } // GenerateBisherHtmlFile

        /// <summary>Generate the JazzGallerieZwei.htm HTML file
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public bool GenerateJazzGalleryTwoHtmlFile(out string o_error)
        {
            o_error = @"";

            //bool b_gallery = true;
            string content_gallery = StartHeaderHtmlFile();

            content_gallery = content_gallery + @"    <TITLE>JAZZ live AARAU Fotogalerie</TITLE>" + NewLine;

            content_gallery = content_gallery + @"  </HEAD>" + NewLine;

            content_gallery = content_gallery + @"  <!-- Datei generiert mit Admin (PhotoUpload.GenerateJazzGalleryTwoHtmlFile)  -->" + NewLine;

            content_gallery = content_gallery + @"  <BODY text=#000000 vLink=#ff0028 aLink=#ff0028 link=#ff0028 bgColor=#000000 BODY scrolling='auto'>" + NewLine;

            content_gallery = content_gallery + @"    <CENTER>" + NewLine;

            content_gallery = content_gallery + @"        <TABLE cellSpacing=2 cellPadding=4 width=450 border=0>" + NewLine;

            content_gallery = content_gallery + @"          <TR>" + NewLine;

            content_gallery = content_gallery + @"            <TD vAlign=top bgColor=#000000 colSpan=10>" + NewLine;

            content_gallery = content_gallery + @"              <CENTER>" + NewLine;

            content_gallery = content_gallery + @"                <FONT size=6 face='Arial Narrow' color=#ff0028>" + NewLine;

            content_gallery = content_gallery + @"                  JAZZ <I>live</I> AARAU" + NewLine;

            content_gallery = content_gallery + @"                </FONT>" + NewLine;

            content_gallery = content_gallery + @"              </CENTER>" + NewLine;

            content_gallery = content_gallery + @"            </TD>" + NewLine;

            content_gallery = content_gallery + @"          </TR>" + NewLine;

            content_gallery = content_gallery + @"        </TABLE>" + NewLine;

            content_gallery = content_gallery + @"        <TABLE cellSpacing=2 cellPadding=4 width=450 border=0>" + NewLine;

            content_gallery = content_gallery + @"          <TR>" + NewLine;

            content_gallery = content_gallery + @"            <TD vAlign=top bgColor=#000000 colSpan=9>" + NewLine;

            content_gallery = content_gallery + @"              <CENTER> <BR><BR>" + NewLine;

            content_gallery = content_gallery + @"                <IMG alt='Fotogalerie 2' height=50 border=0 src='JazzBild_Galerie_2.jpg' > " + NewLine;

            content_gallery = content_gallery + @"              </CENTER>" + NewLine;

            content_gallery = content_gallery + @"            </TD>" + NewLine;

            content_gallery = content_gallery + @"          </TR>" + NewLine;

            content_gallery = content_gallery + @"          <TR>" + NewLine;

            content_gallery = content_gallery + @"            <TD vAlign=top bgColor=#000000 colSpan=9>" + NewLine;

            content_gallery = content_gallery + @"              <CENTER>" + NewLine;

            content_gallery = content_gallery + @"                <FONT size=4 face='Arial Narrow' color=#ff0028>" + NewLine;

            content_gallery = content_gallery + @"                  &nbsp; Fotogalerie 2  &nbsp;" + NewLine;

            content_gallery = content_gallery + @"                </FONT>" + NewLine;

            content_gallery = content_gallery + @"              </CENTER>" + NewLine;

            content_gallery = content_gallery + @"            </TD>" + NewLine;

            content_gallery = content_gallery + @"          </TR>" + NewLine;

            content_gallery = content_gallery + GenerateJazzGalleryHtmlRows();

            content_gallery = content_gallery + @"        </TABLE>" + NewLine;

            content_gallery = content_gallery + @"    </CENTER>" + NewLine;

            content_gallery = content_gallery + @"  </BODY>" + NewLine;

            content_gallery = content_gallery + @"</HTML>" + NewLine;

            string file_name_gallery = PhotoMain.GalleryTwoHtmlFileName;

            string full_file_name_gallery = PathPhotoGalleryDir + file_name_gallery;

            File.WriteAllText(full_file_name_gallery, content_gallery, Encoding.UTF8);

            DebugStringAppend(@"GenerateBisherHtmlFile File " + file_name_gallery + @" is created in directory " + PathPhotoGalleryDir);

            return true;

        } // GenerateJazzGalleryTwoHtmlFile

        /// <summary>
        /// Returns the strings with TR and TD elements for all years
        /// </summary>
        private string GenerateJazzGalleryHtmlRows()
        {
            string ret_rows = @"";

            int start_year = 2006;

            DateTime current_time = DateTime.Now;

            int now_year = current_time.Year;

            int end_year = now_year;

            int n_columns = 0;

            for (int concert_year = start_year; concert_year <= end_year; concert_year++)
            {
                n_columns = n_columns + 1;

                if (n_columns == 1)
                {
                    ret_rows = ret_rows + @"          <TR>" + NewLine;
                }

                ret_rows = ret_rows + @"            <TD align=middle>" + NewLine;

                ret_rows = ret_rows + @"              <P>" + NewLine;

                ret_rows = ret_rows + @"                <FONT size=3 face='Arial Narrow' color=#ff0028>" + NewLine;

                ret_rows = ret_rows + @"                  <A href='../FotoKonzerte/JazzBisherFotos." + concert_year.ToString();

                ret_rows = ret_rows + @".htm'> " + concert_year.ToString() + " </A>" + NewLine;

                ret_rows = ret_rows + @"                </FONT>" + NewLine;

                ret_rows = ret_rows + @"              </P>" + NewLine;

                ret_rows = ret_rows + @"            </TD>" + NewLine;

                if (n_columns == 9 || concert_year == end_year)
                {
                    ret_rows = ret_rows + @"          </TR>" + NewLine;

                    n_columns = 0;
                }

            } // concert_year


            return ret_rows;

        } // GenerateJazzGalleryHtmlRows

        /// <summary>Returns the JavaScript function call
        /// <para></para>
        /// </summary>
        private string ScriptFunction(int i_year_concert_number_add, int i_image_number)
        {
            string ret_script_function = @"";

            ret_script_function = ret_script_function + @"BodyPhoto";

            if (1 == i_image_number)
            {
                ret_script_function = ret_script_function + @"One";
            }
            else if (2 == i_image_number)
            {
                ret_script_function = ret_script_function + @"Two";
            }
            else if (3 == i_image_number)
            {
                ret_script_function = ret_script_function + @"Three";
            }
            else if (4 == i_image_number)
            {
                ret_script_function = ret_script_function + @"Four";
            }
            else if (5 == i_image_number)
            {
                ret_script_function = ret_script_function + @"Five";
            }
            else if (6 == i_image_number)
            {
                ret_script_function = ret_script_function + @"Six";
            }
            else if (7 == i_image_number)
            {
                ret_script_function = ret_script_function + @"Seven";
            }
            else if (8 == i_image_number)
            {
                ret_script_function = ret_script_function + @"Eight";
            }
            else if (9 == i_image_number)
            {
                ret_script_function = ret_script_function + @"Nine";
            }

            ret_script_function = ret_script_function + @"(ConcertData_" + i_year_concert_number_add.ToString() + @")";

            return ret_script_function;

        } // ScriptFunction

        // <summary>Start header of an HTML file</summary>
        private string StartHeaderHtmlFile()
        {
            string start_part_header_string = @"";

            start_part_header_string = start_part_header_string + @"<!DOCTYPE HTML PUBLIC " + QuoteChar + @"-//W3C//DTD HTML 4.0 Transitional//EN" + QuoteChar + @">" + NewLine + NewLine;

            start_part_header_string = start_part_header_string + @"<HTML>" + NewLine;

            start_part_header_string = start_part_header_string + @"  <HEAD>" + NewLine;

            return start_part_header_string;

        } // StartHeaderHtmlFile

        // <summary>Script files and end header for HTML files</summary>
        private string ScriptFilesHtmlFiles(JazzPhoto i_jazz_photo, bool i_b_bisher)
        {
            string script_files_string = @"";

            string level_dir_str = TwoLevelDir();
            if (i_b_bisher)
            {
                level_dir_str = OneLevelDir();
            }

            script_files_string = script_files_string + @"    <script type=" + QuoteChar + @"text/javascript" + QuoteChar + @" src=" + QuoteChar + level_dir_str + @"JazzFotosDatenGemeinsam.js" + QuoteChar + @"></script>" + NewLine;

            script_files_string = script_files_string + @"    <script type=" + QuoteChar + @"text/javascript" + QuoteChar + @" src=" + QuoteChar + level_dir_str + @"JazzFotosDaten_" + i_jazz_photo.Year + ".js" + QuoteChar + @"></script>" + NewLine;

            if (i_b_bisher)
            {
                script_files_string = script_files_string + @"    <script type=" + QuoteChar + @"text/javascript" + QuoteChar + @" src=" + QuoteChar + OneLevelDir() + @"JazzBisherFotos.js" + QuoteChar + @"></script>" + NewLine;
            }
            else
            {
                script_files_string = script_files_string + @"    <script type=" + QuoteChar + @"text/javascript" + QuoteChar + @" src=" + QuoteChar + TwoLevelDir() + @"JazzGallery.js" + QuoteChar + @"></script>" + NewLine;
            }

            script_files_string = script_files_string + @"    <noscript>" + NewLine;

            script_files_string = script_files_string + @"      Um den vollen Funktionsumfang dieser Webseite zu erfahren, benötigen Sie JavaScript." + NewLine;

            script_files_string = script_files_string + @"      Eine Anleitung wie Sie JavaScript in Ihrem Browser einschalten, befindet sich " + NewLine;

            script_files_string = script_files_string + @"      <a href='http://www.enable-javascript.com/de/' target='_blank'>hier</a>." + NewLine;

            script_files_string = script_files_string + @"    </noscript>" + NewLine;

            script_files_string = script_files_string + @"  </HEAD>" + NewLine;

            return script_files_string;

        } // ScriptFilesHtmlFiles

        private string OneLevelDir() { return @"./../FotoScripts/"; }
        private string TwoLevelDir() { return @"./../../FotoScripts/"; }

        /// <summary>Generate start part of a gallery HTML file
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_b_gallery">Flag telling if it is for the gallery file or the image gallery files</param>
        /// <param name="o_error">Error description</param>
        private string StartPartGalleryHtmlFile(JazzPhoto i_jazz_photo, bool i_b_gallery)
        {
            string start_part_string = @"";

            start_part_string = start_part_string + StartHeaderHtmlFile();

            if (i_b_gallery)
            {
                // For Bisher_2018.htm start_part_string = start_part_string + @"    <TITLE>Fotos " + i_jazz_photo.Year + @" JAZZ live AARAU</TITLE>" + NewLine;
                start_part_string = start_part_string + @"    <TITLE>JAZZ live AARAU Konzert Fotos</TITLE>" + NewLine;
            }
            else
            {
                start_part_string = start_part_string + @"    <TITLE>JAZZ live AARAU Foto</TITLE>" + NewLine;
            }

            bool b_bisher = false;
            start_part_string = start_part_string + ScriptFilesHtmlFiles(i_jazz_photo, b_bisher);

            // For Bisher_2018.htm start_part_string = start_part_string + @"  <BODY text=#FF0028 vLink=color=#FF0028 aLink=color=#FF0028 link=color=#FF0028 bgColor='#FFFFFF' BODY scrolling='auto'>" + NewLine;
            start_part_string = start_part_string + @"  <BODY text=#FF0028 vLink=color=#FF0028 aLink=color=#FF0028 link=color=#FF0028 bgColor=#000000 BODY scrolling='auto'>" + NewLine;

            return start_part_string;

        } // StartPartGalleryHtmlFile

        /// <summary>Generate end part of an HTML file
        /// <para></para>
        /// </summary>
        private string EndPartGalleryHtmlFile()
        {
            string end_part_string = @"";

            end_part_string = end_part_string + @"  </BODY>" + NewLine;

            end_part_string = end_part_string + @"</HTML>" + NewLine + NewLine;

            return end_part_string;

        } // EndPartGalleryHtmlFile

        #endregion // Generate gallery HTML files

        #region Generate JavaScript data file JazzFotosDaten_20NN.js with the added gallery 

        /// <summary>Generate JavaScript data file JazzFotosDaten_20NN.js for the added gallery 
        /// <para>For every uploaded gallery a text block (with date, gallery name, phototexts and photographer) shall be added. </para>
        /// <para>The text block defines a JavaScript object (variable) with a name. The object is added to an array.</para>
        /// <para>There will not be a gallery for every concert. </para>
        /// <para>1. Get JazzPhoto objects that have uploaded galleries (gallery directories). Call of GetJazzPhotosForUploadedGalleries</para>
        /// <para>2. Check if gallery already has been uploaded. Call of CheckIfGalleryAlreadyIsUploaded</para>
        /// <para>3. Get year concert numbers for the JazzPhoto objects with uploaded galleries. Call of GetYearConcertNumbersJazzPhotosUploadedGalleries</para>
        /// <para>4. Create the JavaScript file with data (JazzFotosDaten_20NN.js). Call of CreateJazzFotosDatenJs</para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_textbox_message">Text box for messages. Can be null</param>
        /// <param name="o_year_concert_number_add">Year (not season) concert number that defines the name of variable in JazzFotosDaten_20NN.js</param>
        /// <param name="o_error">Error description</param>
        private bool GenerateJazzFotosDatenJs(JazzPhoto i_jazz_photo, TextBox i_textbox_message, out int o_year_concert_number_add, out string o_error)
        {
            o_error = @"";
            o_year_concert_number_add = -12345;

            JazzPhoto[] jazz_photos_with_galleries = null;

            if (!GetJazzPhotosForUploadedGalleries(i_jazz_photo, out jazz_photos_with_galleries, out o_error))
            {
                o_error = @"PhotoUpload.GenerateJazzFotosDatenJs PhotoMain.GetJazzPhotosForUploadedGalleries failed " + o_error;
                return false;
            }

            bool b_do_not_add_data = false;
            if (!CheckIfGalleryAlreadyIsUploaded(i_jazz_photo, jazz_photos_with_galleries, out o_error))
            {
                if (Debug)
                {
                    o_error = o_error + @" Allowed in Debug mode!";
                    DebugStringAppend(@"GenerateJazzFotosDatenJs " + i_jazz_photo.BandName + @" is already uploaded. In Debug mode allowed");
                    b_do_not_add_data = true;
                }       
                else
                {
                    return false;
                }                
            }
                           
            int[] year_concert_numbers = GetYearConcertNumbersJazzPhotosUploadedGalleries(jazz_photos_with_galleries, i_jazz_photo, out o_year_concert_number_add, out o_error);
            if (null == year_concert_numbers || year_concert_numbers.Length != jazz_photos_with_galleries.Length)
            {
                o_error = @"PhotoUpload.GenerateJazzFotosDatenJs GetYearConcertNumbersJazzPhotosUploadedGalleries failed " + o_error;
                return false;
            }

            string script_file_name = @"";
            if (!CreateJazzFotosDatenJs(jazz_photos_with_galleries, year_concert_numbers, i_jazz_photo, o_year_concert_number_add, b_do_not_add_data, out script_file_name, out o_error))
            {
                o_error = @"PhotoUpload.GenerateJazzFotosDatenJs CreateJazzFotosDatenJs failed " + o_error;
                return false;
            }

            DebugStringAppend(@"Exit GenerateJazzFotosDatenJs");

            return true;

        } // GenerateJazzFotosDatenJs

        /// <summary>Create the JavaScript file with data (JazzFotosDaten_20NN.js)
        /// <para>1. Create string with the file content from the input JazzPhotoObjects</para>
        /// <para>2. Add the new JazzPhoto object to the file content.</para>
        /// <para>3. Get the file name start (JazzFotosDatenFileNameStart) and path (PathPhotoScriptsDir).</para>
        /// <para>4. Create the file. Call of File.WriteAllText</para>
        /// <para>Please note that also a new year file will be created.</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto for which a gallery shall be uploaded</param>
        /// <param name="i_jazz_photos_with_galleries">JazzPhoto objects with uploaded galleries. All for the same year</param>
        /// <param name="i_year_concert_numbers">Concert year numbers</param>
        /// <param name="i_jazz_photo_add">JazzPhoto object that shall be added to the file</param>
        /// <param name="b_do_not_add_data">Flag for the case that i_jazz_photo_add data not shall be added</param>
        /// <param name="o_file_name">Output file name with path</param>
        /// <param name="o_error">Error description</param>
        /// <returns>false for failure</returns>
        private bool CreateJazzFotosDatenJs(JazzPhoto[] i_jazz_photos_with_galleries, int[] i_year_concert_numbers, JazzPhoto i_jazz_photo_add, int i_year_concert_number_add, bool b_do_not_add_data, out string o_file_name, out string o_error)
        {
            o_error = @"";
            o_file_name = @"";

            string file_content = @"";

            file_content = file_content + @"// File: /www/FotoScripts/JazzFotosDaten_" + i_jazz_photo_add.Year + @".js" + NewLine + NewLine;            

            file_content = file_content + @"// Diese Datei wird vom Programm JAZZ live AARAU Admin generiert, d.h. man soll in dieser Datei keine Änderungen machen." + NewLine + NewLine;

            file_content = file_content + @"var all_concerts = new Array();" + NewLine + NewLine;            

            int number_with_galleries = i_jazz_photos_with_galleries.Length;

            int index_photo_end = number_with_galleries + 1;

            for (int index_photo = 0; index_photo < index_photo_end; index_photo++)
            {
                JazzPhoto current_photo = null;
                int current_year_concert_number = -12345;
                if (index_photo < number_with_galleries)
                {
                    current_photo = i_jazz_photos_with_galleries[index_photo];
                    current_year_concert_number = i_year_concert_numbers[index_photo];
                }
                else
                {
                    if (b_do_not_add_data)
                    {
                        DebugStringAppend(@"CreateJazzFotosDatenJs Data not added for " + i_jazz_photo_add.BandName +
                                          @" since data already exists in the file content. ");
                        break;
                    }
                    current_photo = i_jazz_photo_add;
                    current_year_concert_number = i_year_concert_number_add;
                }
                string variable_name = @"ConcertData_" + current_year_concert_number.ToString();
                file_content = file_content + @"var " + variable_name + @" =" + NewLine;
                file_content = file_content + @"{" + NewLine;
                file_content = file_content + @"    Year : " + QuoteChar + current_photo.Year + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    Month : " + QuoteChar + current_photo.Month + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    Day : " + QuoteChar + current_photo.Day + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    GalleryName : " + QuoteChar + current_photo.GalleryName + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    BandName : " + QuoteChar + ReplaceDoubleQuotes(current_photo.BandName) + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    TextImageOne : " + QuoteChar + ReplaceDoubleQuotes(current_photo.TextOne) + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    TextImageTwo : " + QuoteChar + ReplaceDoubleQuotes(current_photo.TextTwo) + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    TextImageThree : " + QuoteChar + ReplaceDoubleQuotes(current_photo.TextThree) + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    TextImageFour : " + QuoteChar + ReplaceDoubleQuotes(current_photo.TextFour) + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    TextImageFive : " + QuoteChar + ReplaceDoubleQuotes(current_photo.TextFive) + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    TextImageSix : " + QuoteChar + ReplaceDoubleQuotes(current_photo.TextSix) + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    TextImageSeven : " + QuoteChar + ReplaceDoubleQuotes(current_photo.TextSeven) + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    TextImageEight : " + QuoteChar + ReplaceDoubleQuotes(current_photo.TextEight) + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    TextImageNine : " + QuoteChar + ReplaceDoubleQuotes(current_photo.TextNine) + QuoteChar + @"," + NewLine;
                file_content = file_content + @"    PhotographerName : " + QuoteChar + ReplaceDoubleQuotes(current_photo.PhotographerName) + QuoteChar + NewLine;
                file_content = file_content + @"};" + NewLine;
                file_content = file_content + @"all_concerts.push(" + variable_name + @");" + NewLine + NewLine;

            } // index_photo

            string local_address_directory = PathPhotoScriptsDir;

            string file_name = PhotoMain.JazzFotosDatenFileNameStart + i_jazz_photo_add.Year + @".js";

            string full_file_name = local_address_directory + file_name;

            File.WriteAllText(full_file_name, file_content, Encoding.UTF8);

            o_file_name = full_file_name;

            DebugStringAppend(@"CreateJazzFotosDatenJs File name " + o_file_name);

            return true;

        } // CreateJazzFotosDatenJs

        /// <summary>Replaces " with '
        /// <para>Fix of problem with Erich "Joey Oz" Fischer</para>
        /// <para>Not yet tested 2020-07-25</para>
        /// </summary>
        /// <param name="i_photo_text">Photo text for JavaScript</param>
        private string ReplaceDoubleQuotes(string i_photo_text)
        {
            return i_photo_text.Replace("\"", "'");

        } // ReplaceDoubleQuotes

        /// <summary>Check if the gallery already is uploaded (for a given year)
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto for which a gallery shall be uploaded</param>
        /// <param name="i_jazz_photos_with_galleries">JazzPhoto objects with uploaded galleries. All for the same year</param>
        /// <param name="o_error">Error description</param>
        /// <returns>false if gallery already is uploaded</returns>
        private bool CheckIfGalleryAlreadyIsUploaded(JazzPhoto i_jazz_photo, JazzPhoto[] i_jazz_photos_with_galleries, out string o_error)
        {
            o_error = @"";

            if (i_jazz_photos_with_galleries.Length == 0)
            {
                DebugStringAppend(@"CheckIfGalleryAlreadyIsUploaded No galleries have been uploaded for this year");
                return true;
            }

            for (int index_photo = 0; index_photo < i_jazz_photos_with_galleries.Length; index_photo++)
            {
                JazzPhoto current_photo = i_jazz_photos_with_galleries[index_photo];

                if (current_photo.YearInt == i_jazz_photo.YearInt && current_photo.MonthInt == i_jazz_photo.MonthInt && current_photo.DayInt == i_jazz_photo.DayInt)
                {
                    o_error = PhotoStrings.ErrMsgGalleryIsAlreadyUploaded;

                    DebugStringAppend(@"CheckIfGalleryAlreadyIsUploaded " + o_error + @" Error for concert " + i_jazz_photo.BandName);

                    return false;
                }

            } // index_photo


            return true;

        } // CheckIfGalleryAlreadyIsUploaded

        /// <summary>Returns year concert numbers for the JazzPhoto objects with uploaded galleries
        /// <para>Please note that it is not the season concert numbers that are returned.</para>
        /// <para>Start year for galleries based on JavaScripts is 2018, i.e. start season for concert years is 2017-2018</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photos_with_galleries">JazzPhoto objects with uploaded galleries. All for the same year. This array may have the length=0</param>
        /// <param name="o_error">Error description</param>
        /// <returns>Array with year (not season) concert numbers. Array with length zero may be returned</returns>
        private int[] GetYearConcertNumbersJazzPhotosUploadedGalleries(JazzPhoto[] i_jazz_photos_with_galleries, JazzPhoto i_jazz_photo_add, out int o_year_concert_number_add, out string o_error)
        {
            o_error = @"";
            int[] ret_year_concert_numbers = null;
            o_year_concert_number_add = -12345;

            if (null == i_jazz_photos_with_galleries)
            {
                return ret_year_concert_numbers;
            }

            int concert_year = i_jazz_photo_add.YearInt;
            int[] months = null;
            int[] days = null;
            int[] year_concert_numbers = GetYearConcertNumbers(concert_year, out months, out days, out o_error);
            if (null == year_concert_numbers || year_concert_numbers.Length == 0)
            {
                o_error = @"PhotoMain.SetGallerySeason GetYearConcertNumbers failed " + o_error;
                return ret_year_concert_numbers;
            }

            o_year_concert_number_add = GetYearConcertNumber(i_jazz_photo_add, year_concert_numbers, months, days, out o_error);
            if (o_year_concert_number_add < 0)
            {
                o_error = @"PhotoMain.SetGallerySeason GetYearConcertNumber (1) failed " + o_error;
                return ret_year_concert_numbers;
            }

            if (i_jazz_photos_with_galleries.Length == 0)
            {
                ArrayList dummy_array = new ArrayList();
                ret_year_concert_numbers = (int[])dummy_array.ToArray(typeof(int));
                return ret_year_concert_numbers;
            }

            ret_year_concert_numbers = new int[i_jazz_photos_with_galleries.Length];
            for (int index_init=0; index_init<ret_year_concert_numbers.Length; index_init++)
            {
                ret_year_concert_numbers[index_init] = -12345;
            }

            for (int index_photo=0; index_photo< i_jazz_photos_with_galleries.Length; index_photo++)
            {
                JazzPhoto current_photo = i_jazz_photos_with_galleries[index_photo];

                int year_concert_number = GetYearConcertNumber(current_photo, year_concert_numbers, months, days, out o_error);
                if (year_concert_number < 0)
                {
                    o_error = @"PhotoMain.SetGallerySeason GetYearConcertNumber (2) failed " + o_error;
                    return ret_year_concert_numbers;
                }

                ret_year_concert_numbers[index_photo] = year_concert_number;

                /*QQQQQ
                int month_photo = current_photo.MonthInt;
                int day_photo = current_photo.DayInt;

                for (int index_date = 0; index_date < months.Length; index_date++)
                {
                    if (months[index_date] == month_photo && days[index_date] == day_photo)
                    {
                        ret_year_concert_numbers[index_photo] = year_concert_numbers[index_date];
                        DebugStringAppend(@"GetYearConcertNumbersJazzPhotosUploadedGalleries ret_year_concert_numbers= " + ret_year_concert_numbers[index_photo].ToString() +
                                            @" for concert " + current_photo.BandName);
                    }

                    if (o_year_concert_number_add < 0 && months[index_date] == i_jazz_photo_add.MonthInt && days[index_date] == i_jazz_photo_add.DayInt)
                    {
                        o_year_concert_number_add = year_concert_numbers[index_date];
                        DebugStringAppend(@"GetYearConcertNumbersJazzPhotosUploadedGalleries o_year_concert_number_add= " + o_year_concert_number_add.ToString() +
                                            @" for concert " + i_jazz_photo_add.BandName);
                    }

                } // index_date
                QQQQ*/


            } // index_photo

            return ret_year_concert_numbers;

        } // GetYearConcertNumbersJazzPhotosUploadedGalleries

        private int GetYearConcertNumber(JazzPhoto i_jazz_photo, int[] i_year_concert_numbers, int[] i_months, int[] i_days, out string o_error)
        {
            o_error = @"";
            int ret_year_concert_number = -12345;
            if (null == i_months || i_months.Length == 0)
            {
                o_error = @"PhotoMain.GetYearConcertNumber i_months is null or has zero length";
                return ret_year_concert_number;
            }
            if (null == i_days || i_days.Length == 0)
            {
                o_error = @"PhotoMain.GetYearConcertNumber i_days is null or has zero length";
                return ret_year_concert_number;
            }

            for (int index_date = 0; index_date < i_months.Length; index_date++)
            {

                if (i_months[index_date] == i_jazz_photo.MonthInt && i_days[index_date] == i_jazz_photo.DayInt)
                {
                    ret_year_concert_number = i_year_concert_numbers[index_date];
                }

            } // index_date

            return ret_year_concert_number;

        } // GetYearConcertNumber

        /// <summary>Returns year concert numbers
        /// <para>Please note that it is not the season concert numbers that are returned.</para>
        /// <para>Start year for galleries based on JavaScripts is 2018, i.e. start season for concert years is 2017-2018</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photos_with_galleries">JazzPhoto objects with uploaded galleries. All for the same year. This array may have the length=0</param>
        /// <param name="o_error">Error description</param>
        /// <returns>Array with all year (not season) concert numbers</returns>
        private int[] GetYearConcertNumbers(int i_concert_year, out int[] o_months, out int[] o_days, out string o_error)
        {
            o_error = @"";
            o_months = null;
            o_days = null;

            int[] ret_year_concert_numbers = null;

            ArrayList month_array = new ArrayList();
            ArrayList day_array = new ArrayList();
            ArrayList year_concert_number_array = new ArrayList();

            int year_concert_number = 0;

            XDocument input_active_season_object = JazzXml.GetDocumentCurrent();

            for (int season_start_year = 2017; season_start_year <= i_concert_year; season_start_year++)
            {
                if (!JazzXml.SetXmlDocument(season_start_year))
                {
                    o_error = @"PhotoMain.GetYearConcertNumbers JazzXml.SetXmlDocument failed for season_start_year= " + season_start_year.ToString();
                    return null;
                }

                int number_season_concerts = JazzXml.GetNumberConcertsInCurrentDocument();
                if (number_season_concerts < 1)
                {
                    o_error = @"PhotoMain.GetYearConcertNumbers number_season_concerts < 1 for for season_start_year= " + season_start_year.ToString();
                    return null;
                }

                for (int concert_number = 1; concert_number <= number_season_concerts; concert_number++)
                {
                    int current_concert_year = JazzXml.GetYearInt(concert_number);
                    if (i_concert_year == current_concert_year)
                    {
                        int current_concert_month = JazzXml.GetMonthInt(concert_number);
                        int current_concert_day = JazzXml.GetDayInt(concert_number);
                        year_concert_number = year_concert_number + 1;

                        month_array.Add(current_concert_month);
                        day_array.Add(current_concert_day);
                        year_concert_number_array.Add(year_concert_number);

                        // DebugStringAppend(@"GetYearConcertNumbers year_concert_number= " + year_concert_number.ToString() + 
                        //                    @" current_concert_month " + current_concert_month.ToString() + @" current_concert_day= " + current_concert_day);
                    }

                } // concert_number

            } // season_start_year

            JazzXml.SetDocumentCurrent(input_active_season_object);

            o_months = (int[])month_array.ToArray(typeof(int));
            o_days = (int[])day_array.ToArray(typeof(int));
            ret_year_concert_numbers = (int[])year_concert_number_array.ToArray(typeof(int));

            return ret_year_concert_numbers;

        } // GetYearConcertNumbers

        /// <summary>Get JazzPhoto objects that have uploaded galleries (gallery directories)
        /// <para>1. Get all JazzPhotos for a given year (defined by the input JazzObject). The JazzPhoto objects are are ordered after date</para>
        /// <para>   Call of PhotoMain.GetJazzPhotoObjectsYearOrDate</para>
        /// <para>2. Loop for all JazzPhoto objects:</para>
        /// <para>2.1 Get directory name. Call of JazzPhoto.GalleryTwoDirectoryName</para>
        /// <para>2.2 Get server path. Call of PhotoMain.GetGalleryTwoDirServerPath</para>
        /// <para>2.3 Determine if the server directory exists. Call of PhotoMain.GalleryExistsOnServer</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_textbox_message">Text box for messages. Can be null</param>
        /// <param name="o_error">Error description</param>
        private bool GetJazzPhotosForUploadedGalleries(JazzPhoto i_jazz_photo, out JazzPhoto[] o_jazz_photos_with_uploaded_galeries,  out string o_error)
        {
            o_error = @"";

            o_jazz_photos_with_uploaded_galeries = null;

            int upload_year = i_jazz_photo.YearInt;
            bool b_only_year = true;

            JazzPhoto[] jazz_photos = PhotoMain.GetJazzPhotoObjectsYearOrDate(b_only_year, upload_year, -12345, -12345, out o_error);
            if (null == jazz_photos)
            {
                o_error = @"PhotoUpload.GetJazzPhotosForUploadedGalleries PhotoMain.GetJazzPhotoObjectsYearOrDate failed " + o_error;
                return false;
            }

            DebugStringAppend(@"GetJazzPhotosForUploadedGalleries Number JazzPhotos year " + upload_year + @" is " + jazz_photos.Length.ToString());

            ArrayList jazz_photos_uploaded_array = new ArrayList();

            for (int index_photo = 0; index_photo < jazz_photos.Length; index_photo++)
            {
                JazzPhoto current_photo = jazz_photos[index_photo];

                bool dir_exists = false;
                if (!PhotoMain.GalleryExistsOnServer(current_photo, out dir_exists, out o_error))
                {
                    o_error = @"PhotoUpload.GetJazzPhotosForUploadedGalleries JPhotoMain.GalleryExistsOnServer failed " + o_error;
                    return false;
                }

                if (dir_exists)
                {
                    jazz_photos_uploaded_array.Add(current_photo);
                }

            } // index_photo

            o_jazz_photos_with_uploaded_galeries = (JazzPhoto[])jazz_photos_uploaded_array.ToArray(typeof(JazzPhoto));

            DebugStringAppend(@"GetJazzPhotosForUploadedGalleries Number JazzPhotos with uploaded galleries " + o_jazz_photos_with_uploaded_galeries.Length.ToString());

            return true;

        } // GetJazzPhotosForUploadedGalleries

        #endregion // Generate JavaScript data file JazzFotosDaten_20NN.js with the added gallery 

        #region Local file folders

        /// <summary>Set local directory and file names</summary>
        private void SetLocalFoldersFiles()
        {
            MaintenanceDir = FileUtil.SubDirectory(PhotoMain.PhotoMaintenanceDir, Main.m_exe_directory) + @"\";

            PathPhotoScriptsDir = FileUtil.SubDirectory(PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.PhotoScriptsDir, Main.m_exe_directory) + @"\";

            PathPhotoConcertsDir = FileUtil.SubDirectory(PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.GalleryTwoServerDir, Main.m_exe_directory) + @"\";

            PathPhotoGalleryDir = FileUtil.SubDirectory(PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.GalleryOneServerDir, Main.m_exe_directory) + @"\";

            DebugFile = MaintenanceDir + DebugFileName;

        } // SetLocalFoldersFiles

        #endregion // Local file folders

        #region Debug

        /// <summary>Init the debug string</summary>
        private void DebugStringInit()
        {
            if (!Debug)
                return;

            DebugStr = @"";

        } // DebugStringInit

        /// <summary>Append to the debug string</summary>
        private void DebugStringAppend(string i_debug_str)
        {
            if (!Debug)
                return;

            DebugStr = DebugStr + NewLine + i_debug_str;

        } // DebugStringAppend

        /// <summary>Create XML file</summary>
        private void DebugCreateXmlFile(XDocument i_xdocument, string i_file_name)
        {
            if (!Debug)
                return;

            if (null == i_xdocument)
                return;

            if (i_file_name.Trim().Length == 0)
                return;

            i_xdocument.Save(MaintenanceDir + i_file_name);

            DebugStringAppend(@"DebugCreateXmlFile Creation of file " + MaintenanceDir + i_file_name);

        } // DebugCreateXmlFile

        /// <summary>Create debug file</summary>
        private void DebugCreateFile()
        {
            if (!Debug)
                return;

            string i_file_name = DebugGetFileName();

            File.WriteAllText(i_file_name, DebugStr, Encoding.UTF8);

        } // DebugCreateFile

        /// <summary>Returns debug file name</summary>
        public string DebugGetFileName()
        {
            return MaintenanceDir + @"Debug_PhotoUpload.txt";

        } // DebugGetFileName

        /// <summary>Show message in TextBox control</summary>
        private void ShowMsg(string i_message)
        {
            if (null == TxtBoxMsg)
                return;

            TxtBoxMsg.Text = i_message;
            TxtBoxMsg.Refresh();

        } // ShowMsg

        #endregion // Debug


    } // PhotoUpload

} // namespace
