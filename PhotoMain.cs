using JazzApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Execution functions and parameters for form PhotoMainForm
    /// <para></para>
    /// </summary>
    public static class PhotoMain
    {
        #region Member variables season strings and concert strings

        /// <summary>Available seasons, not including the un-published seasons since member not is logged in</summary>
        private static string[] m_season_strings = null;
        /// <summary>Get available seasons, not including the un-published seasons since member not is logged in</summary>
        private static string[]  GetSeasonStrings() { return m_season_strings; }

        /// <summary>Flag telling that only concerts without zip file shall be available for upload of a zip file</summary>
        private static bool m_only_concerts_without_zip = true;
        /// <summary>Get flag telling that only concerts without zip file shall be available for upload of a zip file</summary>
        public static bool GetZipFlag() { return m_only_concerts_without_zip; }
        /// <summary>Set flag telling that only concerts without zip file shall be available for upload of a zip file</summary>
        public static void SetZipFlag(bool i_only_concerts_without_zip) { m_only_concerts_without_zip = i_only_concerts_without_zip; }

        /// <summary>Available concerts defined by member variable m_only_concerts_without_zip</summary>
        private static string[] m_concert_strings = null;
        /// <summary>Get available concerts defined by member variable m_only_concerts_without_zip. If true only concerts without ZIP files will be returned. TODO Perhaps and only for passed (played) concerts</summary>
        private static string[] GetConcertStrings() { return m_concert_strings; }

        /// <summary>Concert numbers corresponding to m_concert_strings</summary>
        private static int[] m_concert_numbers = null;
        /// <summary>GetcConcert numbers corresponding to GetConcertStrings()</summary>
        private static int[] GetConcertNumbers() { return m_concert_numbers; }

        /// <summary>Get concert number as int for a given bandname (concert string)</summary>
        public static int GetConcertNumber(string i_concert_string)
        {
            int ret_concert_number = -12345;

            for (int index_string=0; index_string< m_concert_strings.Length; index_string++)
            {
                string current_band_name = m_concert_strings[index_string];
                if (current_band_name.Equals(i_concert_string))
                {
                    ret_concert_number = m_concert_numbers[index_string];
                    return ret_concert_number;
                }
            }

            // string error_message = @"PhotoMain.GetConcertNumber failed for " + i_concert_string;
            return ret_concert_number;

        } // GetConcertNumber

        #endregion // Member variables season strings and concert strings

        #region Size of pictures

        /// <summary>Width of the small picture</summary>
        private static int m_small_picture_width = 120;
        /// <summary>Get the width of the small picture</summary>
        private static int GetSmallPictureWidth() { return m_small_picture_width; }

        /// <summary>Height of the small picture</summary>
        private static int m_small_picture_height = 100;
        /// <summary>Get the height of the small picture</summary>
        private static int GetSmallPictureHeight() { return m_small_picture_height; }

        /// <summary>Tolerance for the small picture</summary>
        private static int m_small_picture_tolerance = 5;
        /// <summary>Get the tolerance for the small picture</summary>
        private static int GetSmallPictureTol() { return m_small_picture_tolerance; }

        /// <summary>Height of the big picture</summary>
        private static int m_big_picture_height = 500;
        /// <summary>Get the height of the big picture</summary>
        private static int GetBigPictureHeight() { return m_big_picture_height; }

        /// <summary>Tolerance for the big picture</summary>
        private static int m_big_picture_tolerance = 25;
        /// <summary>Get the tolerance for the big picture</summary>
        private static int GetBigPictureTol() { return m_big_picture_tolerance; }

        /// <summary>Width of the big poster-newsletter picture</summary>
        private static int m_big_poster_newsletter_picture_width = 860;
        /// <summary>Get the width of the big poster-newsletter picture</summary>
        public static int GetBigPosterNewsletterPictureWidth() { return m_big_poster_newsletter_picture_width; }

        /// <summary>Width of the small poster-newsletter picture</summary>
        private static int m_small_poster_newsletter_picture_width = 60;
        /// <summary>Get the width of the small poster-newsletter picture</summary>
        public static int GetSmallPosterNewsletterPictureWidth() { return m_small_poster_newsletter_picture_width; }

        #endregion // Size of pictures

        #region Initialization for the zip form

        /// <summary>Initialization for the form PhotoZipForm</summary>
        public static bool InitZip(out string o_error)
        {
            o_error = @"";

            // Available seasons, not including the un-published seasons since member not is logged in
            JazzUtils.SetMemberLogin(false);
            m_season_strings = JazzXml.GetAvailableSeasons(JazzUtils.GetMemberLogin());

            if (null == m_season_strings)
            {
                o_error = @"PhotoMain.InitZip m_season_strings is null ";
                return false;
            }

            if (0 == m_season_strings.Length)
            {
                o_error = @"PhotoMain.InitZip m_season_strings has no elements ";
                return false;
            }

            string error_message = @"";
            if (!SetCurrentSeason(GetSeasonStrings()[GetSeasonStrings().Length - 1], out error_message))
            {
                o_error = @"PhotoMain.InitZip SetCurrentSeason failed " + o_error;
                return false;
            }

            SetZipFlag(true);

            SetAvailableConcerts();

            return true;

        } // InitZip

        /// <summary>Set current season</summary>
        static public void SetSeason(string i_season_name)
        {
            string error_message = @"";
            if (!SetCurrentSeason(i_season_name, out error_message))
            {
                return;
            }

        } // SetSeason

        /// <summary>Set available concert. Member parameter GetZipFlag() defines the concerts that will be set</summary>
        static public void SetAvailableConcerts()
        {
            m_concert_strings = GetAvailableConcertStrings(out m_concert_numbers);

        } // SetAvailableConcerts

        /// <summary>Get concert strings. Member parameter GetZipFlag() defines the concerts that will be returned</summary>
        static private string[] GetAvailableConcertStrings(out int[] o_concert_numbers)
        {
            string[] ret_concerts = null;
            o_concert_numbers = null;

            int n_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

            ArrayList concerts_array = new ArrayList();
            ArrayList concert_number_array = new ArrayList();

            for (int i_concert = 1; i_concert <= n_concerts; i_concert++)
            {
                string band_name = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetBandName(i_concert));

                string zip_file_two = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPhotoGalleryTwoZip(i_concert));

                if (GetZipFlag())
                {
                    if (zip_file_two.Trim().Length == 0)
                    {
                        concerts_array.Add(band_name);
                        concert_number_array.Add(i_concert);
                    }
                }
                else
                {
                    concerts_array.Add(band_name);
                    concert_number_array.Add(i_concert);
                }

            } // i_concert

            ret_concerts = (string[])concerts_array.ToArray(typeof(string));

            o_concert_numbers = (int[])concert_number_array.ToArray(typeof(int));

            return ret_concerts;

        } // GetAvailableConcertStrings

        #endregion // Initialization for the zip form

        #region Initialization for the gallery form

        /// <summary>Set current season for the gallery form</summary>
        public static bool SetGallerySeason(JazzPhoto i_jazz_photo, out string o_error)
        {
            o_error = @"";

            bool b_photo_one = false;
            int n_photo_seasons = JazzXml.GetNumberOfPhotoSeasons(b_photo_one, out o_error);
            if (n_photo_seasons<=0)
            {
                o_error = @"PhotoMain.SetGallerySeason JazzXml.GetNumberOfPhotoSeasons failed " + o_error;
                return false;
            }

            JazzPhoto[] jazz_photos = null;

            string start_year = @"";

            for (int season_number= n_photo_seasons; season_number >= 1; season_number--)
            {
                jazz_photos = JazzXml.GetPhotoTwoObjects(season_number, out o_error);
                if (jazz_photos == null)
                {
                    o_error = @"PhotoMain.SetGallerySeason JazzXml.GetPhotoTwoObjects failed " + o_error;
                    return false;
                }

                for (int index_photo=0; index_photo< jazz_photos.Length; index_photo++)
                {
                    JazzPhoto current_photo = jazz_photos[index_photo];

                    if (i_jazz_photo.YearInt == current_photo.YearInt && i_jazz_photo.MonthInt == current_photo.MonthInt && i_jazz_photo.DayInt == current_photo.DayInt)
                    {
                        start_year = JazzXml.GetPhotoTwoStartYearSeason(season_number);

                        season_number = 1;
                        break;
                    }

                } // index_photo

            } // season_number

            if (start_year.Length == 0)
            {
                o_error = @"PhotoMain.SetGallerySeason Start season not found";
                return false;
            }

            int start_season_int = JazzUtils.StringToInt(start_year);

            if (!JazzXml.SetXmlDocument(start_season_int))
            {
                o_error = @"PhotoMain.SetGallerySeason JazzXml.SetXmlDocument failed for start_season_int= " + start_season_int.ToString();
                return false;
            }

            // string band_name_test_1 = JazzXml.GetBandName(1);

            return true;

        } // SetGallerySeason

        #endregion // Initialization for the gallery form

        #region Search object

        /// <summary>Class with search functions</summary>
        private static Search m_search = null;
        /// <summary>Get search object</summary>
        public static Search GetSearch { get { return m_search; } }

        #endregion // Search object

        #region Names and paths for the XML files holding photo gallery data

        /// <summary>Server path to the directory for the XML gallery photo files (JazzGalerieEin.xml and JazzGalerieZwei.xml)</summary>
        private static string m_url_xml_photo_files_folder = "XML";
        /// <summary>Get the server path to directory for the XML photo gallery files (JazzGalerieEin.xml and JazzGalerieZwei.xml)</summary>
        public static string PhotoFileServerDir { get { return m_url_xml_photo_files_folder; } }

        /// <summary>Name of the XML photo gallery one file.</summary>
        private static string m_photo_one_xml_filename = "JazzFotoGalerieEin.xml";
        /// <summary>Get the name of the XML photo gallery one file.</summary>
        public static string PhotoOneFileName { get { return m_photo_one_xml_filename; } }

        /// <summary>Name of the XML photo gallery two file.</summary>
        private static string m_photo_two_xml_filename = "JazzFotoGalerieZwei.xml";
        /// <summary>Get the name of the XML photo gallery zwei file.</summary>
        public static string PhotoTwoFileName { get { return m_photo_two_xml_filename; } }

        /// <summary>Name of the gallery two HTML file.</summary>
        private static string m_gallery_two_html_filename = "JazzGalerieZwei.htm";
        /// <summary>Get the name of the gallery two HTML file.</summary>
        public static string GalleryTwoHtmlFileName { get { return m_gallery_two_html_filename; } }

        #endregion // Names and paths for the XML files holding photo gallery data

        #region Server Newsletter Directory

        /// <summary>Name of the server newsletter poster directory</summary>
        private static string m_server_newsletter_poster_dir = @"setup/Newsletter/Plakat";
        /// <summary>Get the name of the server newsletter poster directory</summary>
        public static string ServerNewsletterDir { get { return m_server_newsletter_poster_dir; } }

        // string server_newsletter_poster_dir = @"setup/Newsletter/Plakat";

        #endregion // Server Newsletter Directory

        #region Upload photo XML files

        /// <summary>Names of the XML files for upload</summary>
        private static string[] m_upload_photo_xml_filenames = null;
        /// <summary>Get the names of the XML files for upload</summary>
        public static string[] GetUploadPhotoXmlFileNames { get { return m_upload_photo_xml_filenames; } }

        /// <summary>XML objects (XDocument) for the XML files that shall be uploaded</summary>
        private static XDocument[] m_upload_photo_xml_xdocuments = null;
        /// <summary>Get the XML objects (XDocument) for the XML files that shall be uploaded</summary>
        public static XDocument[] GetUploadPhotoXmlXDocuments { get { return m_upload_photo_xml_xdocuments; } }

        /// <summary>Initialization of XML files for upload</summary>
        public static void InitUploadPhotoXmlFiles()
        {
            ArrayList name_array = new ArrayList();
            ArrayList xdocument_array = new ArrayList();

            name_array.Add(PhotoOneFileName);
            name_array.Add(PhotoTwoFileName);

            xdocument_array.Add(JazzXml.GetObjectPhotoOne());
            xdocument_array.Add(JazzXml.GetObjectPhotoTwo());

            m_upload_photo_xml_filenames = (string[])name_array.ToArray(typeof(string));
            m_upload_photo_xml_xdocuments = (XDocument[])xdocument_array.ToArray(typeof(XDocument));

        } // InitUploadPhotoXmlFiles

        /// <summary>Add season XML file (JazzProgramm_20xx_20yy.xml) for upload</summary>
        public static void AddUploadPhotoXmlFile(string i_season_xml_file_name, XDocument i_season_xml_object)
        {
            // TODO It would be nicer if the function checks if the season XML already in the list, i.e. when the
            // updates the same season with multiple ZIP files the same XML season file will be uploaded several times
            // Only a performance problem, and it will very seldom be the case

            ArrayList name_array = new ArrayList();
            ArrayList xdocument_array = new ArrayList();

            for (int index_add=0; index_add< m_upload_photo_xml_filenames.Length; index_add++)
            {
                name_array.Add(m_upload_photo_xml_filenames[index_add]);
                xdocument_array.Add(m_upload_photo_xml_xdocuments[index_add]);
            }
           
            name_array.Add(i_season_xml_file_name);            
            xdocument_array.Add(i_season_xml_object);

            m_upload_photo_xml_filenames = (string[])name_array.ToArray(typeof(string));
            m_upload_photo_xml_xdocuments = (XDocument[])xdocument_array.ToArray(typeof(XDocument));

        } // AddUploadPhotoXmlFile

        /// <summary>Upload photo XML files (JazzGalerieEin.xml and JazzGalerieZwei.xml) and season XML files (JazzProgramm_20xx_20yy.xml)</summary>
        public static bool UploadXmlFiles(out string o_error)
        {
            o_error = @"";

            for (int index_upload = 0; index_upload < m_upload_photo_xml_filenames.Length; index_upload++)
            {
                if (!AdminUtils.UploadXmlToServer(m_upload_photo_xml_filenames[index_upload], m_upload_photo_xml_xdocuments[index_upload], out o_error))
                {
                    o_error = @"PhotoMain.UploadXmlFilesAdminUtils.UploadXmlToServer failed index_upload= " + index_upload.ToString() + @" " + o_error;
                    
                    return false;
                }
            }

            InitUploadPhotoXmlFiles();

            return true;

        } // UploadXmlFiles

        #endregion // Upload photo XML files

        #region Names and directories for the photo gallery files

        /// <summary>Server path to the directory for the gallery one photo files</summary>
        private static string m_url_gallery_one_folder = "FotoGalerie";
        /// <summary>Get the server path to the directory for the gallery one photo files</summary>
        public static string GalleryOneServerDir { get { return m_url_gallery_one_folder; } }

        /// <summary>Server path to the directory for the gallery two photo files</summary>
        private static string m_url_gallery_two_folder = "FotoKonzerte";
        /// <summary>Get the server path to the directory for the gallery two photo files</summary>
        public static string GalleryTwoServerDir { get { return m_url_gallery_two_folder; } }

        /// <summary>Server directory for the photo ZIP file</summary>
        private static string m_url_zip_files_folder = "/konzertfotos/";
        /// <summary>Get the server directory for the photo ZIP file</summary>
        public static string ZipFilesServerDir { get { return m_url_zip_files_folder; } }

        /// <summary>Directory name for photo photo scripts</summary>
        private static string m_photo_scripts_folder = "FotoScripts";
        /// <summary>Get the directory name for photo photo scripts</summary>
        public static string PhotoScriptsDir { get { return m_photo_scripts_folder; } }

        /// <summary>Directory name for temporary photo files</summary>
        private static string m_photo_temp_folder = "FotoTempFiles";
        /// <summary>Get the directory name for temporary photo files</summary>
        public static string PhotoTempDir { get { return m_photo_temp_folder; } }

        /// <summary>Start part of the gallery directory name</summary>
        private static string m_gallery_dir_name_start = "Konzert";
        /// <summary>Get the start part of the gallery directory name</summary>
        public static string GalleryDirNameStart { get { return m_gallery_dir_name_start; } }

        /// <summary>Start part of concert directory for the gallery two photo files</summary>
        private static string m_url_gallery_two_dir_name_start = "Konzert.";
        /// <summary>Get the start part of concert directory for the gallery two photo files</summary>
        public static string GalleryTwoDirStart { get { return m_url_gallery_two_dir_name_start; } }

        /// <summary>Start string for a gallery HTM file </summary>
        private static string m_url_gallery_htm_file_name_start = "JazzGalerie_";
        /// <summary>Get the start string for a gallery HTM file (JazzGalerie_)</summary>
        public static string GalleryHtmFileNameStartString { get { return m_url_gallery_htm_file_name_start; } }

        /// <summary>Start string for a gallery photo file </summary>
        private static string m_url_gallery_photo_file_name_start = "JazzBild_";
        /// <summary>Get the start string for a gallery photo file</summary>
        public static string GalleryPhotoFileNameStartString { get { return m_url_gallery_photo_file_name_start; } }

        /// <summary>Start string for the bisher HTM file </summary>
        private static string m_bisher_file_name_start = "JazzBisherFotos.";
        /// <summary>Get the start string for the bisher HTM file</summary>
        public static string BisherFileNameStartString { get { return m_bisher_file_name_start; } }

        /// <summary>Start string for the poster-newsletter file name</summary>
        private static string m_poster_newsletter_file_name_start = "PlakatNewsletter";
        /// <summary>Get the start string for the poster-newsletter file name</summary>
        public static string PosterNewsletterNameStartString { get { return m_poster_newsletter_file_name_start; } }

        /// <summary>End string for the small poster-newsletter file name</summary>
        private static string m_poster_newsletter_small_file_name_end = "_Klein";
        /// <summary>Get the end string for the small poster-newsletter file name</summary>
        public static string PosterNewsletterSmallNameEndString { get { return m_poster_newsletter_small_file_name_end; } }

        /// <summary>Returns the start part for a name of a gallery HTM file (for instance JazzGalerie_G09)</summary>
        private static string GalleryHtmFileNameStartPart(int i_gallery_number)
        {
            string ret_file_name = GalleryHtmFileNameStartString;
            if (i_gallery_number <= 9)
            {
                ret_file_name = ret_file_name + @"0" + i_gallery_number.ToString();
            }
            else
            {
                ret_file_name = ret_file_name + i_gallery_number.ToString();
            }

            return ret_file_name;

        } // GalleryHtmFileNameStartPart

        /// <summary>Returns the name of a gallery HTM file (for instance JazzGalerie_G65.htm)</summary>
        public static string GalleryHtmFileName(int i_gallery_number)
        {
            string ret_file_name = GalleryHtmFileNameStartPart(i_gallery_number);

            ret_file_name = ret_file_name + @".htm";

            return ret_file_name;

        } // GalleryHtmFileName

        /// <summary>Returns the start part for a name of a gallery HTM photo file (for instance JazzGalerie_G19_05)</summary>
        private static string GalleryHtmPhotoFileNameStartPart(int i_gallery_number, int i_photo_number)
        {
            string ret_file_name = GalleryHtmFileNameStartPart(i_gallery_number) + @"_";

            ret_file_name = ret_file_name.Replace(GalleryHtmFileNameStartString, GalleryPhotoFileNameStartString);

            if (i_photo_number <= 9)
            {
                ret_file_name = ret_file_name + @"0" + i_photo_number.ToString();
            }
            else
            {
                // Should never occur
                ret_file_name = ret_file_name + i_photo_number.ToString();
            }

            return ret_file_name;

        } // GalleryHtmPhotoFileNameStartPart

        /// <summary>Returns the name of a gallery HTM photo file (for instance JazzGalerie_G93_03.htm)</summary>
        public static string GalleryHtmPhotoFileName(int i_gallery_number, int i_photo_number)
        {
            string ret_file_name = GalleryHtmPhotoFileNameStartPart(i_gallery_number, i_photo_number);

            ret_file_name = ret_file_name + @".htm";

            return ret_file_name;

        } // GalleryHtmPhotoFileName

        /// <summary>Returns the name of a gallery low resolution photo file (for instance JazzBild_G53_02_LowRes.jpg)</summary>
        public static string GalleryLowResPhotoFileName(int i_gallery_number, int i_photo_number)
        {
            string ret_file_name = GalleryHtmPhotoFileNameStartPart(i_gallery_number, i_photo_number);

            ret_file_name = ret_file_name + @"_LowRes.jpg";

            return ret_file_name;

        } // GalleryLowResPhotoFileName

        /// <summary>Returns the name of a gallery small photo file (for instance JazzBild_G53_02_small.jpg). Photo number equal zero (0) is allowed</summary>
        public static string GallerySmallPhotoFileName(int i_gallery_number, int i_photo_number)
        {
            string ret_file_name = GalleryHtmPhotoFileNameStartPart(i_gallery_number, i_photo_number);

            ret_file_name = ret_file_name + @"_small.jpg";

            if (ret_file_name.Contains(@"00_small.jpg"))
            {
                // i_photo_number = 0
                ret_file_name = ret_file_name.Replace(@"00_small.jpg", @"small.jpg");
            }

            return ret_file_name;

        } // GallerySmallPhotoFileName


        #endregion // Names and directories for the photo gallery files

        #region Local directory names

        /// <summary>Local directory name for photo data</summary>
        private static string m_local_photo_files_folder = "Fotos";
        /// <summary>Get the local directory name for photo data</summary>
        public static string PhotoFileLocalDir { get { return m_local_photo_files_folder; } }

        /// <summary>Local directory name for temporary photo one data</summary>
        private static string m_temp_photo_one_files_folder = "TempOne";
        /// <summary>Get the local directory name for temporary photo one data</summary>
        public static string PhotoFileTempOneDir { get { return m_temp_photo_one_files_folder; } }

        /// <summary>Local directory name for temporary photo two data</summary>
        private static string m_temp_photo_two_files_folder = "TempTwo";
        /// <summary>Get the local directory name for temporary photo two data</summary>
        public static string PhotoFileTempTwoDir { get { return m_temp_photo_two_files_folder; } }

        /// <summary>Local directory name for photo maintenance data</summary>
        private static string m_local_daten_wartung_folder = "Datenwartung";
        /// <summary>Get the local directory name for photo maintenance data</summary>
        public static string PhotoMaintenanceDir { get { return m_local_daten_wartung_folder; } }

        #endregion // Local directory names

        #region JavaScript and HTML file names

        /// <summary>Start part of the JavaScript file with data for a given year (JazzFotosDaten_)</summary>
        private static string m_jazz_fotos_daten_name_start = "JazzFotosDaten_";
        /// <summary>Get start part of the JavaScript file with data for a given year</summary>
        public static string JazzFotosDatenFileNameStart { get { return m_jazz_fotos_daten_name_start; } }

        /// <summary>Start part of the jazz image HTML file name</summary>
        private static string m_jazz_bild_name_start = "JazzBild_";
        /// <summary>Get part of the jazz image HTML file name</summary>
        public static string JazzBildFileNameStart { get { return m_jazz_bild_name_start; } }

        /// <summary>Start part of the jazz gallery HTML file name</summary>
        private static string m_jazz_gallery_name_start = "JazzGalerie_";
        /// <summary>Get part of the jazz gallery HTML file name</summary>
        public static string JazzGalleryFileNameStart { get { return m_jazz_gallery_name_start; } }

        #endregion // JavaScript and HTML file names

        #region Initialization

        /// <summary>Initialization of the season program objects and the photo gallery objects
        /// <para>Instantiate class Search (with search functions). The constructor will call JazzXml.InitXmlAllSeasons</para>
        /// <para>Object corresponding to the XML file JazzGalerieEin.xml. Call of JazzXml.InitPhotoOne</para>
        /// <para>Object corresponding to the XML file JazzGalerieZwei.xml. Call of JazzXml.InitPhotoTwo</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static public bool InitXml(out string o_error)
        {
            o_error = @"";

            if (!InitXmlPhotoOne(out o_error))
            {
                o_error = @"PhotoMain.InitXml InitXmlPhotoOne " + o_error;
                return false;
            }

            if (!InitXmlPhotoTwo(out o_error))
            {
                o_error = @"PhotoMain.InitXml InitXmlPhotoTwo " + o_error;
                return false;
            }

            return true;

        } // InitXml

        /// <summary>Initialization of search object
        /// <para>Create instance Search for m_search</para>
        /// </summary>
        static public void InitSearch()
        {
            m_search = new Search();
        }


        /// <summary>Initialization of the photo gallery one object corresponding to the XML file JazzGalerieEin.xml
        /// <para>Call of JazzXml.InitPhotoOne</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static public bool InitXmlPhotoOne(out string o_error)
        {
            o_error = @"";
            bool ret_init = true;

            string error_message = @"";

            if (!JazzXml.InitPhotoOne(PhotoFileServerDir, PhotoOneFileName, out error_message))
            {
                o_error = @"PhotoMain.InitXmlPhotoOne JazzXml.InitPhotoOne failed " + error_message;
                return false;
            }

            return ret_init;

        } // InitXmlPhotoOne

        /// <summary>Initialization of the photo gallery two object corresponding to the XML file JazzGalerieZwei.xml
        /// <para>Call of JazzXml.InitPhotoTwo</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static public bool InitXmlPhotoTwo(out string o_error)
        {
            o_error = @"";
            bool ret_init = true;

            string error_message = @"";

            if (!JazzXml.InitPhotoTwo(PhotoFileServerDir, PhotoTwoFileName, out error_message))
            {
                o_error = @"PhotoMain.InitXmlPhotoTwo JazzXml.InitPhotoTwo failed " + error_message;
                return false;
            }

            return ret_init;

        } // InitXmlPhotoTwo

        #endregion // Initialization

        #region Get HTML file names for photo gallery two

        /// <summary>Returns the server names for the photo gallery one HTM files
        /// <para>Not yet implemented</para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static string[] GetPhotoOneHtmFileNames(out string o_error)
        {
            o_error = @"";

            string[] ret_file_names = null;

            string concert_server_dir = @"/www/" + GalleryOneServerDir + @"/";

            return ret_file_names;

        } // GetPhotoOneHtmFileNames

        /// <summary>Returns the server names for the photo gallery two HTM files
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static string[] GetPhotoTwoHtmFileNames(out string o_error)
        {
            o_error = @"";

            string[] ret_file_names = null;

            string concert_server_dir = @"/www/" + GalleryTwoServerDir + @"/";

            string[] photo_dir_names = GetPhotoTwoDirNames(concert_server_dir, out o_error);
            if (null == photo_dir_names)
            {
                o_error = @"PhotoMain.GetPhotoTwoHtmFileNames GetPhotoTwoDirNames failed " + o_error;
                return ret_file_names;
            }

            ArrayList file_names_string_array = new ArrayList();

            for (int index_dir = 0; index_dir < photo_dir_names.Length; index_dir++)
            {
                string current_photo_dir_name = concert_server_dir + photo_dir_names[index_dir];

                string htm_file_name = HtmFileName(current_photo_dir_name, out o_error);
                if (htm_file_name.Length > 0)
                {
                    file_names_string_array.Add(current_photo_dir_name + @"/" + htm_file_name);
                }
            }
            string[] unsorted_file_names = (string[])file_names_string_array.ToArray(typeof(string));

            ret_file_names = SortHtmFileNames(unsorted_file_names, out o_error);
            if (null == ret_file_names)
            {
                o_error = @"PhotoMain.GetPhotoTwoHtmFileNames SortHtmFileNames failed " + o_error;
                return ret_file_names;
            }

            return ret_file_names;

        } // GetPhotoTwoHtmFileNames

        /// <summary>Returns a sorted array of gallery file names
        /// <para></para>
        /// </summary>
        /// <param name="i_unsorted_file_names">Array of unsorted gallery file names with paths</param>
        /// <param name="o_error">Error message</param>
        public static string[] SortHtmFileNames(string[] i_unsorted_file_names, out string o_error)
        {
            o_error = @"";

            string[] ret_sorted_names = null;

            if (null == i_unsorted_file_names)
            {
                o_error = @"PhotoMain.SortHtmFileNames i_unsorted_file_names is null";
                return ret_sorted_names;
            }

            int n_number_names = i_unsorted_file_names.Length;
            if (n_number_names == 0)
            {
                o_error = @"PhotoMain.SortHtmFileNames n_number_names is zero (0)";
                return ret_sorted_names;
            }

            bool[] b_used = new bool[n_number_names];
            for (int index_init=0; index_init< n_number_names; index_init++)
            {
                b_used[index_init] = false;
            }

            ret_sorted_names = new string[n_number_names];

            for (int index_outer=0; index_outer< n_number_names; index_outer++)
            {
                int min_value = 500000;
                int i_index_min = -1;

                for (int index_inner = 0; index_inner < n_number_names; index_inner++)
                {
                    if (!b_used[index_inner])
                    {
                        string file_name = i_unsorted_file_names[index_inner];
                        int gallery_number = GalleryNumberInt(file_name);
                        if (gallery_number < min_value)
                        {
                            min_value = gallery_number;
                            i_index_min = index_inner;
                        }
                    } // Unused name

                } // index_inner

                if (i_index_min < 0)
                {
                    o_error = @"PhotoMain.SortHtmFileNames i_index_min < 0";
                    return null;
                }

                ret_sorted_names[index_outer] = i_unsorted_file_names[i_index_min];
                b_used[i_index_min] = true;

            } // index_outer

            return ret_sorted_names;

        } // SortHtmFileNames

        /// <summary>Returns the gallery number as int
        /// <para></para>
        /// </summary>
        /// <param name="i_file_name">Gallery file name</param>
        private static int GalleryNumberInt(string i_file_name)
        {
            string file_name = Path.GetFileName(i_file_name);

            string file_name_no_ext = Path.GetFileNameWithoutExtension(file_name);

            string number_str = file_name_no_ext.Replace(GalleryHtmFileNameStartString, @"");

            if (number_str.Substring(0, 1).Equals(@"0"))
            {
                number_str = number_str.Substring(1, 1);
            }

            return JazzUtils.StringToInt(number_str);

        } // GalleryNumberInt

        /// <summary>Returns the name of the HTM file in the photo two (concert) folder
        /// <para>1. Get file names. Call of JazzFtp.Execute. Run for Input.Case.GetFileNames</para>
        /// <para>2. Add file name to output array if name contains JazzGalerie_. Call of GalleryHtmFileNameStartString</para>
        /// </summary>
        /// <param name="i_dir_name">Server directory name</param>
        /// <param name="o_error">Error message</param>
        private static string HtmFileName(string i_dir_name, out string o_error)
        {
            o_error = @"";

            string ret_name = @"";

            string[] all_file_names = null;

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.GetFileNames);
            ftp_input.ServerDirectory = i_dir_name;

            JazzFtp.Result result_dir_file_names = JazzFtp.Execute.Run(ftp_input);
            if (!result_dir_file_names.Status)
            {
                o_error = "PhotoMain.HtmFileName JazzFtp.Execute.Run failed " + result_dir_file_names.ErrorMsg;
                return ret_name;
            }

            all_file_names = result_dir_file_names.ArrayStr;

            if (null == all_file_names ||  all_file_names.Length==0)
            {
                o_error = @"PhotoMain.HtmFileName  all_file_names is null or empty";
                return ret_name;
            }

            for (int index_name=0; index_name<all_file_names.Length; index_name++)
            {
                string current_name = all_file_names[index_name];

                if (current_name.Contains(GalleryHtmFileNameStartString))
                {
                    ret_name = current_name;

                    return ret_name;
                }
            }

            return ret_name;

        } // HtmFileName

        /// <summary>Returns the server names for the photo gallery two directories
        /// <para>1. Get all server file an directory names. Call of JazzFtp.Execute.Run for Input.Case.GetDirNames</para>
        /// <para>2. Add directory names to output array if directory name starts with Konzert.</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static string[] GetPhotoTwoDirNames(string i_server_dir, out string o_error)
        {
            o_error = @"";

            string[] ret_dir_names = null;

            string[] all_file_and_directory_names = null;

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.GetDirNames);
            ftp_input.ServerDirectory = i_server_dir;

            JazzFtp.Result result_dir_file_names = JazzFtp.Execute.Run(ftp_input);
            if (!result_dir_file_names.Status)
            {
                o_error = "PhotoMain.GetPhotoTwoDirNames JazzFtp.Execute.Run failed " + result_dir_file_names.ErrorMsg;
                return ret_dir_names;
            }
            
            all_file_and_directory_names = result_dir_file_names.ArrayStr;

            ArrayList photo_dirs_string_array = new ArrayList();

            for (int index_name=0; index_name< all_file_and_directory_names.Length; index_name++)
            {
                string current_name = all_file_and_directory_names[index_name];
                if (current_name.Contains(GalleryTwoDirStart))
                {
                    photo_dirs_string_array.Add(current_name);
                }
            }

            ret_dir_names = (string[])photo_dirs_string_array.ToArray(typeof(string));

            return ret_dir_names;

        } // GetPhotoTwoDirNames

        #endregion // Get HTML file names for photo gallery two

        #region Get JazzPhoto objects for a given year or a given date

        /// <summary> Get JazzPhoto objects for a given year or a given date (i.e. year, month, day)
        /// <para>The data (the objects) are retrieved from the XML object corresponding to the file JazzFotoGalerieZwei.xml</para>
        /// <para>1. Get number of photo seasons. Call of JazzXml.GetNumberOfPhotoSeasons</para>
        /// <para>2. Loop for all photo seasons</para>
        /// <para>2.1 Get all JazzPhoto objects for the current season. Call of JazzXml.GetPhotoTwoObjects</para>
        /// <para>2.2 Add the JazzPhoto object to the output array if criteria are fulfilled (year or date) </para>
        /// <para>3. Order the JazzPhoto objects (ascending date). Call of OrderJazzPhotoObjects.</para>
        /// </summary>
        /// <param name="i_only_year">Flag telling if JazzObjects for a given year shall be returned</param>
        /// <param name="i_year_int">Year</param>
        /// <param name="i_month_int">Month</param>
        /// <param name="i_day_int">Day</param>
        /// <param name="o_error">Error message</param>
        public static JazzPhoto[] GetJazzPhotoObjectsYearOrDate(bool i_only_year, int i_year_int, int i_month_int, int i_day_int, out string o_error)
        {
            o_error = @"";

            JazzPhoto[] ret_jazz_photos = null; 

            bool b_photo_one = false;
            int n_seasons = JazzXml.GetNumberOfPhotoSeasons(b_photo_one, out o_error);
            if (n_seasons <= 0)
            {
                o_error = @"PhotoMain.GetJazzPhotoObjectsYearOrDate JazzXml.GetNumberOfPhotoSeasons failed";
                return ret_jazz_photos;
            }

            ArrayList jazz_photos_array = new ArrayList();

            for (int season_number = n_seasons; season_number >= 1; season_number--)
            {

                JazzPhoto[] jazz_photos = JazzXml.GetPhotoTwoObjects(season_number, out o_error);
                if (null == jazz_photos || jazz_photos.Length == 0)
                {
                    o_error = @"PhotoMain.GetJazzPhotoObjectsYearOrDate JazzXml.GetPhotoTwoObjects failed " + o_error;
                    return ret_jazz_photos;
                }

                for (int index_photo = 0; index_photo < jazz_photos.Length; index_photo++)
                {
                    JazzPhoto current_jazz_photo = jazz_photos[index_photo];

                    if (current_jazz_photo.YearInt == i_year_int)
                    {
                        if (i_only_year)
                        {
                            jazz_photos_array.Add(current_jazz_photo);
                        }
                        else
                        {
                            if (current_jazz_photo.MonthInt == i_month_int && current_jazz_photo.DayInt == i_day_int)
                            {
                                jazz_photos_array.Add(current_jazz_photo);
                            }
                        } 
                    } // Year

                } // index_photo

            } // season_number

            ret_jazz_photos = (JazzPhoto[])jazz_photos_array.ToArray(typeof(JazzPhoto));

            if (!i_only_year)
            {
                if (ret_jazz_photos.Length > 1)
                {
                    o_error = @"PhotoMain.GetJazzPhotoObjectsYearOrDate The number of JazzObjects with the same date exceeds one (1). ret_jazz_photos.Length= " + ret_jazz_photos.Length.ToString();
                    return null;
                }
            }

            JazzPhoto[] ordered_jazz_photos = OrderJazzPhotoObjects(ret_jazz_photos, out o_error);

            if (null == ordered_jazz_photos || ordered_jazz_photos.Length == 0)
            {
                o_error = @"PhotoMain.GetJazzPhotoObjectsYearOrDate OrderJazzPhotoObjects failed";
                return ordered_jazz_photos;
            }

            ret_jazz_photos = ordered_jazz_photos;

            return ret_jazz_photos;

        } // GetJazzPhotoObjectsYearOrDate


        /// <summary> Order JazzPhoto objects after date
        /// <para></para>
        /// <para>1. </para>
        /// </summary>
        /// <param name="i_only_year">Flag telling if JazzObjects for a given year shall be returned</param>
        /// <param name="i_year_int">Year</param>
        /// <param name="i_month_int">Month</param>
        /// <param name="i_day_int">Day</param>
        /// <param name="o_error">Error message</param>
        private static JazzPhoto[] OrderJazzPhotoObjects(JazzPhoto[] i_unordered_jazz_photos, out string o_error)
        {
            // https://www.dotnetperls.com/sort-datetime

            o_error = @"";

            JazzPhoto[] ret_ordered_jazz_photos = null;


            if (null == i_unordered_jazz_photos || i_unordered_jazz_photos.Length == 0)
            {
                o_error = @"PhotoMain.OrderJazzPhotoObjects Input array is null or has no elements";
                return ret_ordered_jazz_photos;
            }

            var date_list_unordered = new List<DateTime>();

            for (int index_date=0; index_date< i_unordered_jazz_photos.Length; index_date++)
            {
                JazzPhoto current_photo_object = i_unordered_jazz_photos[index_date];

                int concert_year = current_photo_object.YearInt;

                int concert_month = current_photo_object.MonthInt;

                int concert_day = current_photo_object.DayInt;

                date_list_unordered.Add(new DateTime(concert_year, concert_month, concert_day));
            }

            var date_list_ordered = SortAscending(date_list_unordered);

            ArrayList ordered_jazz_photos_array = new ArrayList();

            foreach (var date_time in date_list_ordered)
            {
                for (int index_date_out = 0; index_date_out < i_unordered_jazz_photos.Length; index_date_out++)
                {
                    JazzPhoto current_photo_object_out = i_unordered_jazz_photos[index_date_out];

                    int concert_year_out = current_photo_object_out.YearInt;

                    int concert_month_out = current_photo_object_out.MonthInt;

                    int concert_day_out = current_photo_object_out.DayInt;

                    if (concert_year_out == date_time.Year && concert_month_out == date_time.Month && concert_day_out == date_time.Day)
                    {
                        ordered_jazz_photos_array.Add(current_photo_object_out);
                    }

                    // Console.WriteLine(date_time);
                }
            }

            ret_ordered_jazz_photos = (JazzPhoto[])ordered_jazz_photos_array.ToArray(typeof(JazzPhoto));

            return ret_ordered_jazz_photos;

        } // OrderJazzPhotoObjects

        /// <summary> Order DateTime objects ascending</summary>
        /// <param name="list">List with DateTime objects</param>
        private static List<DateTime> SortAscending(List<DateTime> list)
        {
            list.Sort((a, b) => a.CompareTo(b));

            return list;

        } // SortAscending


        /// <summary> Get JazzPhoto season number and concert number
        /// <para>1. Get number of seasons. Call of JazzXml.GetNumberOfPhotoSeason</para>
        /// <para>2. Loop seasons</para>
        /// <para>  2.1 Get photo objects. Call of JazzXml.GetPhotoTwoObjects</para>
        /// <para>  2.2 Loop concerts</para>
        /// <para>    2.2.1 Get date from photo object.</para>
        /// <para>    2.2.2 Compare with input date</para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto. Date (Year, Month and Day) is used </param>
        /// <param name="o_season_number">Output season number</param>
        /// <param name="o_concert_number">Output concert number</param>
        /// <param name="o_error">Error message</param>
        /// <returns>true or false for error</returns>
        public static bool GetJazzPhotoSeasonConcert(JazzPhoto i_jazz_photo, out int o_season_number, out int o_concert_number, out string o_error)
        {
            o_error = @"";
            o_season_number = -12345;
            o_concert_number = -12345;
            bool ret_bool = false;

            bool b_photo_one = false;
            int n_seasons = JazzXml.GetNumberOfPhotoSeasons(b_photo_one, out o_error);
            if (n_seasons <= 0)
            {
                o_error = @"PhotoMain.GetJazzPhotoSeasonConcert JazzXml.GetNumberOfPhotoSeasons failed";
                return ret_bool;
            }

            for (int season_number = 1; season_number <= n_seasons; season_number++)
            {
               JazzPhoto[] jazz_photos = JazzXml.GetPhotoTwoObjects(season_number, out o_error);
                if (null == jazz_photos || jazz_photos.Length == 0)
                {
                    o_error = @"PhotoMain.GetJazzPhotoSeasonConcert JazzXml.GetPhotoTwoObjects failed " + o_error;
                    return ret_bool;
                }

                for (int index_photo = 0; index_photo < jazz_photos.Length; index_photo++)
                {
                    JazzPhoto current_jazz_photo = jazz_photos[index_photo];

                    if (current_jazz_photo.YearInt == i_jazz_photo.YearInt && current_jazz_photo.MonthInt == i_jazz_photo.MonthInt && current_jazz_photo.DayInt == i_jazz_photo.DayInt)
                    {

                        o_season_number = season_number;
                        o_concert_number = index_photo + 1;
                        ret_bool = true;
                        break;
                    } 

                } // index_photo

                if (ret_bool == true)
                {
                    break;
                }

            } // season_number

            if (false == ret_bool)
            {
                o_error = @"PhotoMain.GetJazzPhotoSeasonConcert No JazzObject for Year= "
                                 + i_jazz_photo.Year + @" Month= " + i_jazz_photo.Month + @" Day= " + i_jazz_photo.Day;
            }

            return ret_bool;

        } // GetJazzPhotoSeasonConcert

        #endregion // Get JazzPhoto objects for a given year or a given date

        #region Search for ZIP files and set combobox and other controls

        /// <summary>Search zip files and set controls
        /// <para>1. Search in the photo galleries (JazzGalerieEin.xml and JazzGalerieZwei.xml). Call of Search.ExecuteGalleries</para>
        /// <para>2. Set the controls. Call of SetComboBoxZipFiles</para>
        /// </summary>
        public static bool SearchZipSetControls(TextBox i_text_box_search, ComboBox i_combo_box_zip_files, 
                              TextBox i_text_box_date_band, TextBox i_text_box_n_results, out string[] o_date_band_array, out string o_error)
        {
            o_error = @"";
            o_date_band_array = null;

            JazzPhoto[] photo_results = null;
            if (!GetSearch.ExecuteGalleries(i_text_box_search.Text, out photo_results, out o_error))
            {
                o_error = @"PhotoMain.SearchZipSetControls ExecuteGalleries failed " + o_error;
                return false;
            }

            if (null == photo_results)
            {
                o_error = @"PhotoMain.SearchZipSetControls photo_results is null";
                return false;
            }

            if (photo_results.Length == 0)
            {
                i_combo_box_zip_files.Items.Clear();
                i_combo_box_zip_files.Text = @"";
                i_text_box_date_band.Text = @"";
                i_text_box_n_results.Text = @"0";

                return true;
            }

            int n_results = photo_results.Length;

            string[] combo_box_array = new string[n_results];
            string[] date_band_array = new string[n_results];

            i_text_box_n_results.Text = n_results.ToString();

            for (int index_result = 0; index_result < n_results; index_result++)
            {
                JazzPhoto current_photo = photo_results[index_result];

                combo_box_array[index_result] = current_photo.ZipName;

                date_band_array[index_result] = GetDateBandName(current_photo);

            } // index_result

            SetComboBoxZipFiles(i_combo_box_zip_files, combo_box_array);

            i_text_box_date_band.Text = date_band_array[0];

            o_date_band_array = date_band_array;

            return true;

        } // SearchZipSetControls

        /// <summary>Set combobox zip files</summary>
        public static void SetComboBoxZipFiles(ComboBox i_combo_box_zip_files, string[] i_combo_box_array)
        {
            if (null == i_combo_box_array)
                return;
            if (0 == i_combo_box_array.Length)
                return;

            i_combo_box_zip_files.Items.Clear();

            for (int index_name = 0; index_name < i_combo_box_array.Length; index_name++)
            {
                i_combo_box_zip_files.Items.Add(i_combo_box_array[index_name]);
            }

            i_combo_box_zip_files.Text = i_combo_box_array[0];

        } // SetComboBoxZipFiles

        /// <summary>Returns date and band name</summary>
        private static string GetDateBandName(JazzPhoto i_photo)
        {
            string ret_str = @"";

            ret_str = ret_str + i_photo.Year + @"-";

            if (i_photo.Month.Length == 1)
            {
                ret_str = ret_str + @"0" + i_photo.Month + @"-";
            }
            else
            {
                ret_str = ret_str + i_photo.Month + @"-";
            }

            if (i_photo.Day.Length == 1)
            {
                ret_str = ret_str + @"0" + i_photo.Day + @" ";
            }
            else
            {
                ret_str = ret_str + i_photo.Day + @" ";
            }

            ret_str = ret_str + i_photo.BandName;

            return ret_str;

        } // GetDateBandName

        #endregion // Search for ZIP files and set combobox and other controls

        #region Gallery controls for PhotoMainForm

        /// <summary>Set the combobox galleries
        /// <para></para>
        /// <para>In search (replace mode) the input array with JazzPhoto objects also include searched (found) objects.</para>
        /// </summary>
        /// <param name="i_combo_box_gallery">Combobox gallery</param>
        /// <param name="i_text_box_gallery">The text box that displays the gallery name</param>
        /// <param name="i_objects_zip_no_gallery">Array of JazzPhoto objects that have a ZIP file but where the gallery (still) is missing</param>
        public static void SetComboBoxGallery(ComboBox i_combo_box_gallery, TextBox i_text_box_gallery, JazzPhoto[] i_objects_zip_no_gallery)
        {
            if (null == i_combo_box_gallery)
                return;
            if(null == i_text_box_gallery)
                return;

            if (0 == i_objects_zip_no_gallery.Length)
                return;

            i_combo_box_gallery.Items.Clear();

            if (i_objects_zip_no_gallery.Length == 0)
            {
                return;
            }

            string date_band_name = @"";

            for (int index_object = 0; index_object < i_objects_zip_no_gallery.Length; index_object++)
            {
                JazzPhoto current_object = i_objects_zip_no_gallery[index_object];

                date_band_name = GetDateBandName(current_object);

                i_combo_box_gallery.Items.Add(date_band_name);
            }

            JazzPhoto first_object = i_objects_zip_no_gallery[0];
            date_band_name = GetDateBandName(first_object);

            i_combo_box_gallery.Text = date_band_name;

            SetTextBoxGallery(i_text_box_gallery, i_objects_zip_no_gallery, 0);

        } // SetComboBoxGallery

        /// <summary>Set combobox zip files</summary>



        /// <summary>Set the text box with the gallery name
        /// <para>The gallery name that will be displayed is the next (not yet used) name if no gallery is selected or if a gallery that that can be added is selected</para>
        /// <para></para>
        /// <para>In search (replace mode) input array with JazzPhoto objects also include searched (found) objects.</para>
        /// </summary>
        /// <param name="i_text_box_gallery">Text box gallery</param>
        /// <param name="i_objects_zip_no_gallery">Array of JazzPhoto objects that have a ZIP file but the gallery is missing</param>
        /// <param name="i_index_photo">Index in i_objects_zip_no_gallery that defines the gallery name</param>
        public static void SetTextBoxGallery(TextBox i_text_box_gallery, JazzPhoto[] i_objects_zip_no_gallery, int i_index_photo)
        {
            if (null == i_text_box_gallery)
                return;
            if (0 == i_objects_zip_no_gallery.Length)
                return;
            if (i_index_photo < 0 || i_index_photo >= i_objects_zip_no_gallery.Length)
                return;

            string gallery_name = i_objects_zip_no_gallery[i_index_photo].GalleryName;

            i_text_box_gallery.Text = gallery_name;

        } // SetTextBoxGallery

        #endregion // Gallery controls for PhotoMainForm

        #region Set combo boxes for seasons and concerts for PhotoZipForm

        /// <summary>Set combobox seasons. Call of function GetSeasonStrings that only returns published seasons</summary>
        public static void SetComboBoxSeasons(ComboBox i_combo_box_seasons)
        {
            if (GetSeasonStrings() == null)
                return;

            i_combo_box_seasons.Items.Clear();

            for (int i_season = GetSeasonStrings().Length - 1; i_season >= 0; i_season--)
            {
                i_combo_box_seasons.Items.Add(GetSeasonStrings()[i_season]);
            }

            i_combo_box_seasons.Text = GetSeasonStrings()[GetSeasonStrings().Length - 1];

        } // SetComboBoxSeasons

        /// <summary>Set combobox concerts. Call of function GetConcertStrings that returns concerts without ZIP files.</summary>
        public static void SetComboBoxConcerts(ComboBox i_combo_box_concerts)
        {
            if (GetConcertStrings() == null)
                return;

            i_combo_box_concerts.Items.Clear();

            if (GetConcertStrings().Length == 0)
            {
                i_combo_box_concerts.Text = PhotoStrings.MsgPhotoAllHaveZipFiles;
                return;
            }

            for (int index_concert = 0; index_concert < GetConcertStrings().Length; index_concert++)
            {
                i_combo_box_concerts.Items.Add(GetConcertStrings()[index_concert]);
            }

            i_combo_box_concerts.Text = GetConcertStrings()[0];

        } // SetComboBoxConcerts

        #endregion Set combo boxes for seasons and concerts for PhotoZipForm

        #region Combobox musician names and instruments for PhotoPictureForm

        /// <summary>Get arrays for combobox musician names and instruments</summary>
        public static bool GetComboBoxMusicianInstruments(JazzPhoto i_jazz_photo, out string[] o_musicians, out string[] o_instruments, out string o_error)
        {
            o_error = @"";
            o_musicians = null;
            o_instruments = null;

            int number_bands = JazzXml.GetNumberConcertsInCurrentDocument();
            int current_band_number = -12345;
            string current_band_name = i_jazz_photo.BandName;
            for (int band_number = 1; band_number <= number_bands; band_number++)
            {
                string band_name = JazzXml.GetBandName(band_number);
                if (band_name.Equals(current_band_name))
                {
                    current_band_number = band_number;
                    break;
                }
            } // band_number

            string[] all_musicians = JazzXml.GetMusiciansAsStrings(current_band_number);
            string[] all_instruments = JazzXml.GetInstrumentsAsStrings(current_band_number);

            if (null == all_musicians)
            {
                o_error = @"PhotoMain.GetComboBoxMusicianInstruments all_musicians is null";
                return false;
            }

            if (0 == all_musicians.Length)
            {
                o_error = @"PhotoMain.GetComboBoxMusicianInstruments all_musicians length = 0";
                return false;
            }

            if (null == all_instruments)
            {
                o_error = @"PhotoMain.GetComboBoxMusicianInstruments all_instruments is null";
                return false;
            }

            if (0 == all_instruments.Length)
            {
                o_error = @"PhotoMain.GetComboBoxMusicianInstruments all_instruments length = 0";
                return false;
            }

            if (all_instruments.Length != all_musicians.Length)
            {
                o_error = @"PhotoMain.GetComboBoxMusicianInstruments all_instruments length not equal to all_musicians length";
                return false;
            }

            o_musicians = new string[all_musicians.Length + 2];
            o_instruments = new string[all_instruments.Length + 2];

            for (int index_out = 0; index_out < o_musicians.Length - 1; index_out++)
            {
                if (0 == index_out)
                {
                    o_musicians[index_out] = PhotoStrings.PromptSelectMusician;
                    o_instruments[index_out] = PhotoStrings.PromptSelectMusician;
                }
                else
                {
                    o_musicians[index_out] = all_musicians[index_out - 1];
                    o_instruments[index_out] = all_instruments[index_out - 1];
                }

            } // index_out

            o_musicians[o_musicians.Length - 1] = current_band_name;
            o_instruments[o_musicians.Length - 1] = @"";

            return true;

        } // GetComboBoxMusicianInstruments

        /// <summary>Set combobox musician names and instruments</summary>
        public static void SetComboBoxMusicianNames(ComboBox i_combo_box_picture_text, string[] i_musicians, string[] i_instruments)
        {

            i_combo_box_picture_text.Items.Clear();

            for (int index_name = 0; index_name < i_musicians.Length; index_name++)
            {
                string musician_instrument = i_musicians[index_name];
                if (0 != index_name)
                {
                    musician_instrument = musician_instrument + @" " + i_instruments[index_name];
                }
 
                i_combo_box_picture_text.Items.Add(musician_instrument);

            } // index_name

            i_combo_box_picture_text.Text = PhotoStrings.PromptSelectMusician;

        } // SetComboBoxMusicianNames

        #endregion // Combobox musician names and instruments for PhotoPictureForm

        #region Set current season

        /// <summary>Set current season</summary>
        public static bool SetCurrentSeason(string i_season, out string o_error)
        {
            o_error = @"";

            if (i_season.Trim().Length == 0)
            {
                o_error = @"PhotoMain.SetCurrentSeason i_season is empty ";
                return false;
            }

            string selected_season = i_season;

            string[] season_strings = GetSeasonStrings();
            if (null == season_strings)
            {
                o_error = @"PhotoMain.SetCurrentSeason season_strings is null";
                return false;
            }

            int index_selected_season = AdminUtils.GetIndexSelectedItem(season_strings, selected_season);
            if (index_selected_season < 0)
            {
                o_error = @"PhotoMain.SetCurrentSeason Programming error: GetIndexSelectedItem";
                return false;
            }

            XDocument[] season_documents = JazzXml.GetSeasonDocuments();
            if (null == season_documents)
            {
                o_error = @"PhotoMain.SetCurrentSeason Programmin error: GetSeasonDocuments";
                return false;
            }
            if (0 == season_documents.Length)
            {
                o_error = @"PhotoMain.SetCurrentSeason Programming error: No documents";
                return false;
            }

            if (index_selected_season >= season_documents.Length)
            {
                o_error = @"PhotoMain.SetCurrentSeason Programming error: index_selected_season";
                return false;
            }

            JazzXml.SetDocumentCurrent(season_documents[index_selected_season]);

            JazzXml.SetCurrentSeasonFileUrl();

            return true;

        } // SetCurrentSeason

        #endregion // Set current season

        #region Get Photo objects with a ZIP file but with no gallery

        /// <summary>Get galleries that have registered ZIP files and a gallery name but where the gallery is missing on the server
        /// <para>Criterion if there is a gllery is defined in function GalleryExists</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static JazzPhoto[] GetPhotoObjectsZipNoGalleryTwo(out string o_error)
        {
            o_error = @"";

            JazzPhoto[] ret_objects_zip_no_gallery = null;

            ArrayList objects_zip_no_gallery_array = new ArrayList();

            int number_photo_seasons = JazzXml.GetNumberOfPhotoTwoSeasons(out o_error);
            if (number_photo_seasons <= 0)
            {
                o_error = "PhotoMain.GetPhotoObjectsZipNoGalleryTwo Get number of seasons failed " + o_error;
                return ret_objects_zip_no_gallery;
            }

            for (int season_number = 1; season_number <= number_photo_seasons; season_number++)
            {
                JazzPhoto[] jazz_photos = JazzXml.GetPhotoTwoObjects(season_number, out o_error);
                if (null == jazz_photos)
                {
                    o_error = "PhotoMain.GetPhotoObjectsZipNoGalleryTwo Get number of photo objects failed " + o_error;
                    return ret_objects_zip_no_gallery;
                }

                for (int index_photo = 0; index_photo < jazz_photos.Length; index_photo++)
                {
                    JazzPhoto current_photo = jazz_photos[index_photo];

                    string zip_name = current_photo.ZipName;
                    string gallery_name = current_photo.GalleryName;

                    if (zip_name.Length > 0 && gallery_name.Length > 0)
                    {
                        if (!GalleryExists(current_photo))
                        {
                            objects_zip_no_gallery_array.Add(current_photo);
                        } 

                    } // ZIP name and gallery name are defined

                } // index_photo

            }// season_number

            ret_objects_zip_no_gallery = (JazzPhoto[])objects_zip_no_gallery_array.ToArray(typeof(JazzPhoto));

            return ret_objects_zip_no_gallery;

        } // GetPhotoObjectsZipNoGalleryTwo

        /// <summary>Determines if a gallery exists based on the texts for the photos
        /// <para>All texts must not be set, but it is not likely that all texts are missing</para>
        /// <para>This criterion assumes that the texts are set when the gallery is (has been) uploaded (PhotoUpload.Execute)</para>
        /// <para>There is an alternative (better) function GalleryExistsOnServer to check this. </para>
        /// <para>TODO Consider changing to this function</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_photo">Photo object</param>
        /// <returns>true if gallery exists</returns>
        private static bool GalleryExists(JazzPhoto i_photo)
        {
            if (i_photo.TextOne.Length == 0 && 
                i_photo.TextTwo.Length == 0 &&
                i_photo.TextThree.Length == 0 &&
                i_photo.TextFour.Length == 0 &&
                i_photo.TextFive.Length == 0 &&
                i_photo.TextSix.Length == 0 &&
                i_photo.TextSeven.Length == 0 &&
                i_photo.TextEight.Length == 0 &&
                i_photo.TextNine.Length == 0     )
            {
                return false;
            }
            else
            {
                return true;
            }
          
        } // GalleryExists

        /// <summary>Determines if a gallery directory exists on the server
        /// <para>Call of JazzFtp.Execute.Run for JazzFtp.Input.Case.DirExists</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_photo">Photo object</param>
        /// <param name="o_dir_exists">Flag telling if the directory exists</param>
        /// <param name="o_error">Error message</param>
        /// <returns>false for error</returns>
        public static bool GalleryExistsOnServer(JazzPhoto i_photo, out bool o_dir_exists, out string o_error)
        {
            o_dir_exists = false;
            o_error = @"";

            string server_gallery_dir = GetGalleryTwoDirServerPath(i_photo);
            if (server_gallery_dir.Length == 0)
            {
                o_error = @"PhotoMain.GalleryExistsOnServer GetGalleryTwoDirServerPath failed";
                return false;
            }

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.DirExists);

            ftp_input.ServerDirectory = server_gallery_dir;

            JazzFtp.Result result_dir_exists = JazzFtp.Execute.Run(ftp_input);

            if (!result_dir_exists.Status)
            {
                o_error = @"PhotoMain.GalleryExistsOnServer JazzFtp.Execute.Run (DirExists) failed " + result_dir_exists.ErrorMsg;
                return false;
            }

            if (result_dir_exists.BoolResult)
            {
                o_dir_exists = true;
            }
            else
            {
                o_dir_exists = false;
            }

            return true;

        } // GalleryExistsOnServer

        /// <summary>Create server gallery directory
        /// <para>Call of JazzFtp.Execute.Run for JazzFtp.Input.Case.DirExists</para>
        /// <para>It is assumed that the calling function has checked that the directory not exists</para>
        /// </summary>
        /// <param name="i_photo">Photo object</param>
        /// <param name="o_error">Error message</param>
        /// <returns>false for error</returns>
        public static bool CreateServerGalleryDirectory(JazzPhoto i_photo, out string o_error)
        {
            o_error = @"";

            string server_gallery_dir = GetGalleryTwoDirServerPath(i_photo);
            if (server_gallery_dir.Length == 0)
            {
                o_error = @"PhotoMain.CreateServerGalleryDirectory GetGalleryTwoDirServerPath failed";
                return false;
            }

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.DirCreate);

            ftp_input.ServerDirectory = server_gallery_dir;

            JazzFtp.Result result_dir_create = JazzFtp.Execute.Run(ftp_input);

            if (!result_dir_create.Status)
            {
                o_error = @"PhotoMain.CreateServerGalleryDirectory JazzFtp.Execute.Run (DirCreate) failed " + result_dir_create.ErrorMsg;
                return false;
            }

            return true;

        } // CreateServerGalleryDirectory

        /// <summary>Constructs the name of the gallery directory
        /// <para></para>
        /// </summary>
        /// <param name="i_photo">Photo object</param>
        /// <returns>The name of the gallery directory. For error is an empty string returned</returns>
        private static string GetGalleryTwoDirName(JazzPhoto i_photo)
        {
            string ret_dir_name = @"";

            string error_message = @"";
            if (!i_photo.GalleryTwoDirectoryName(out ret_dir_name, out error_message))
            {
                return ret_dir_name;
            }

            return ret_dir_name;

        } // GetGalleryTwoDirName

        /// <summary>Gets the gallery two server path
        /// <para></para>
        /// </summary>
        /// <param name="i_photo">Photo object</param>
        /// <returns>Server path to a photo gallery two. For error is an empty string returned</returns>
        public static string GetGalleryTwoDirServerPath(JazzPhoto i_photo)
        {
            string ret_dir_server_path = @"";

            string dir_name = GetGalleryTwoDirName(i_photo);
            if (dir_name.Length == 0)
            {
                return ret_dir_server_path;
            }

            ret_dir_server_path = @"www/" + GalleryTwoServerDir + @"/" + dir_name;

            return ret_dir_server_path;

        } // GetGalleryTwoDirServerPath


        #endregion // Get Photo objects with a ZIP file but with no gallery

        #region Get photo objects with registered ZIP files but where the file is missing on the server

        /// <summary>Returns true if the ZIP file is on the server
        /// <para></para>
        /// </summary>
        /// <param name="i_zip_name">ZIP file name</param>
        /// <param name="o_error">Error message</param>
        public static bool RegisteredZipExists(string i_zip_name, out string o_error)
        {
            o_error = @"";

            JazzPhoto[] missing_zip_files = PhotoMain.GetPhotoObjectsMissingRegisteredZipFiles(out o_error);
            if (null == missing_zip_files)
            {
                o_error = "PhotoMain.RegisteredZipExists PhotoMain.GetPhotoObjectsMissingRegisteredZipFiles failed " + o_error;
                return false;
            }

            int n_number_zip = missing_zip_files.Length;
            if (0 == n_number_zip)
            {
                o_error = "All registered ZIP files are also on the server";
                return true;
            }

            for (int index_zip=0; index_zip < n_number_zip; index_zip++)
            {
                JazzPhoto current_photo = missing_zip_files[index_zip];
                string zip_name = current_photo.ZipName;

                if (zip_name.Equals(i_zip_name))
                {
                    o_error = "PhotoMain.RegisteredZipExists ZIP file is not on the server";
                    return false;
                }
            }


            return true;
        } // RegisteredZipExists

        /// <summary>Get galleries that have registered ZIP files but where the ZIP files are missing on the server
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static JazzPhoto[] GetPhotoObjectsMissingRegisteredZipFiles(out string o_error)
        {
            o_error = @"";

            JazzPhoto[] missing_zip_objects = null;

            ArrayList missing_zip_objects_array = new ArrayList();

            string[] zip_file_names = null;

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.GetFileNames);
            ftp_input.ServerDirectory = PhotoMain.ZipFilesServerDir;

            JazzFtp.Result result_dir_file_names = JazzFtp.Execute.Run(ftp_input);
            if (!result_dir_file_names.Status)
            {
                o_error = "PhotoMain.GetPhotoObjectsMissingRegisteredZipFiles JazzFtp.Execute.Run failed " + result_dir_file_names.ErrorMsg;
                return missing_zip_objects;
            }

            zip_file_names = result_dir_file_names.ArrayStr;

            for (int gallery_number = 1; gallery_number <= 2; gallery_number++)
            {
                int number_photo_seasons = -12345; ;

                if (1 == gallery_number)
                {
                    number_photo_seasons = JazzXml.GetNumberOfPhotoOneSeasons(out o_error);
                }
                else
                {
                    number_photo_seasons = JazzXml.GetNumberOfPhotoTwoSeasons(out o_error);
                }
                if (number_photo_seasons <= 0)
                {
                    o_error = "PhotoMain.GetPhotoObjectsMissingRegisteredZipFiles Get number of seasons failed " + o_error;
                    return missing_zip_objects;
                }

                for (int season_number = 1; season_number <= number_photo_seasons; season_number++)
                {
                    JazzPhoto[] jazz_photos = null;

                    if (1 == gallery_number)
                    {
                        jazz_photos = JazzXml.GetPhotoOneObjects(season_number, out o_error);
                    }
                    else
                    {
                        jazz_photos = JazzXml.GetPhotoTwoObjects(season_number, out o_error);
                    }
                    if (null == jazz_photos)
                    {
                        o_error = "PhotoMain.GetPhotoObjectsMissingRegisteredZipFiles Get number of photo objects failed " + o_error;
                        return missing_zip_objects;
                    }

                    for (int index_photo = 0; index_photo < jazz_photos.Length; index_photo++)
                    {
                        JazzPhoto current_photo = jazz_photos[index_photo];

                        string zip_name = current_photo.ZipName;

                        if (zip_name.Length > 0)
                        {
                            if (!ServerZipFileExists(zip_name, zip_file_names))
                            {
                                missing_zip_objects_array.Add(current_photo);
                            } // No ZIP file on the server

                        } // ZIP name is defined

                    } // index_photo


                }// season_number


            } // number_gallery


            missing_zip_objects = (JazzPhoto[])missing_zip_objects_array.ToArray(typeof(JazzPhoto));


            return missing_zip_objects;

        } // CreateListMissingRegisteredZipFiles


        /// <summary>Returns true if the input ZIP file (name) is on the server
        /// <para></para>
        /// </summary>
        /// <param name="i_zip_name">Zip file name</param>
        /// <param name="i_zip_file_names">All Zip files (names) on the server</param>
        private static bool ServerZipFileExists(string i_zip_name, string[] i_zip_file_names)
        {
            if (null == i_zip_file_names)
                return false;

            for (int index_zip = 0; index_zip < i_zip_file_names.Length; index_zip++)
            {
                string current_name = i_zip_file_names[index_zip];
                if (i_zip_name.Equals(current_name))
                {
                    return true;
                }

            }

            return false;

        } // ServerZipFileExists

        #endregion // Get photo objects with registered ZIP files but where the file is missing on the server

        #region ZIP download

        /// <summary>Download photo zip file
        /// <para></para>
        /// </summary>
        /// <param name="i_zip_file_name">ZIP file name</param>
        /// <param name="o_error">Error message</param>
        public static bool DownloadPhotoZipFile(string i_zip_file_name, out bool i_cancel_download, out string o_error)
        {
            o_error = @"";
            i_cancel_download = false;

            if (!RegisteredZipExists(i_zip_file_name, out o_error))
            {
                o_error = PhotoStrings.ErrMsgZipFileRegisteredButExistsNot;
                return false;
            }

            //string server_file_name = @"";
            string server_directory = @"";
            string download_file_name = @"";
            string file_extensions = @"zip";
            string file_type_case = @"zip";

            server_directory = ZipFilesServerDir;
            download_file_name = i_zip_file_name;

            //server_file_name = server_directory + i_zip_file_name;

            if (!OpenSaveDialog.Download(server_directory, download_file_name, file_type_case, file_extensions, out i_cancel_download, out o_error))
            {
                o_error = @"RequestBand.DownloadPhotoZipFile OpenSaveDialog.Download failed " + o_error;
                return false;
            }

            return true;

        } // DownloadPhotoZipFile

        #endregion // ZIP download

        #region ZIP file upload 

        /// <summary>Upload the concert ZIP file to server directory fotokonzerte 
        /// <para>The function sets the zip file name in the input/output JazzPhoto object</para>
        /// <para>1. Open file dialog and get the input file name. Call of OpenSaveDialog.GetFileName</para>
        /// <para>2. Get (construct) the output file name for the zip file. Call of GetZipFileName</para>
        /// <para>3. Upload the ZIP file. Call of Upload.OnePhotoZipFile</para>
        /// </summary>
        /// <param name="io_jazz_photo">Input/output JazzPhoto object</param>
        /// <param name="o_cancel_upload">Flag telling if user cancelled the upload</param>
        /// <param name="o_error">Error message</param>
        public static bool UploadPhotoZipFile(ref JazzPhoto io_jazz_photo, out bool o_cancel_upload, out string o_error)
        {
            o_error = @"";
            o_cancel_upload = false;

            string file_name_upload = @"";
            string file_extensions = @"zip";

            if (!OpenSaveDialog.GetFileName("zip", file_extensions, out o_cancel_upload, out file_name_upload, out o_error))
            {
                o_error = @"PhotoMain.UploadPhotoZipFile OpenSaveDialog.GetFileName failed " + o_error;
                return false;
            }

            if (o_cancel_upload)
            {
                return true;
            }

            string zip_file_name = @"";
            if (!GetZipFileName(io_jazz_photo, file_name_upload, out zip_file_name, out o_error))
            {
                o_error = @"PhotoMain.UploadPhotoZipFile GetZipFileName failed " + o_error;
                return false;
            }

            bool b_warnung = OpenSaveDialog.WarningFileNamesNotEqual(zip_file_name, file_name_upload, out o_cancel_upload, out o_error);
            if (o_cancel_upload)
            {
                return true;
            }

            string zip_dir = ZipFilesServerDir;

            string server_file_name = zip_dir + zip_file_name;

            UpLoad upload = new UpLoad();

            if (!upload.OnePhotoZipFile(server_file_name, file_name_upload, out o_error))
            {
                o_error = @"OpenSaveDialog.Upload Upload.OnePhotoZipFile failed " + o_error;
                return false;
            }

            io_jazz_photo.ZipName = zip_file_name;

            return true;

        } // UploadPhotoZipFile

        /// <summary>Get (construct) the file name for the zip file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto with date, bandname, name of photographer and link to season program object</param>
        /// <param name="i_user_file_name">Name of the ZIP file selected by the user</param>
        /// <param name="o_file_name">The information file name</param>
        /// <param name="o_error">Error message</param>
        public static bool GetZipFileName(JazzPhoto i_jazz_photo, string i_user_file_name, out string o_file_name, out string o_error)
        {
            o_error = @"";
            o_file_name = @"";

            string start_part_file_name = @"";

            if (JazzUtils.IsSetSeasonProgramForCurrentSeason())
            {
                // The right document XDocument (KonzertDokumente_20XX_20YY) must be set and exist
                start_part_file_name = GetStartPartZipFileNameFromDocumentDirectoryName(i_jazz_photo, out o_error);
                if (start_part_file_name.Length == 0)
                {
                    start_part_file_name = ConstructStartPartZipFileName(i_jazz_photo);
                    //QQQ 20180304 return false;
                }
            }
            else
            {
                start_part_file_name = ConstructStartPartZipFileName(i_jazz_photo);
            }

            string end_file_name = i_jazz_photo.PhotographerName;
            int index_space = end_file_name.IndexOf(" ");
            if (index_space < 0)
            {
                o_error = @"PhotoMain.GetZipFileName Photographer name without space, i.e. not name and family name";
                return false;
            }

            end_file_name = end_file_name.Substring(0, index_space);

            o_file_name = start_part_file_name + @"_" + end_file_name + @".zip";

            return true;

        } // GetZipFileName

        /// <summary>Constructs the start part of the ZIP file name
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto with date, bandname, name of photographer and link to season program object</param>
        private static string ConstructStartPartZipFileName(JazzPhoto i_jazz_photo)
        {
            string start_file_name = @"d" + i_jazz_photo.Year;
            if (i_jazz_photo.Month.Length == 1)
            {
                start_file_name = start_file_name + @"0" + i_jazz_photo.Month;
            }
            else
            {
                start_file_name = start_file_name + i_jazz_photo.Month;
            }
            if (i_jazz_photo.Day.Length == 1)
            {
                start_file_name = start_file_name + @"0" + i_jazz_photo.Day;
            }
            else
            {
                start_file_name = start_file_name + i_jazz_photo.Day;
            }

            string mod_band_name = AdminUtils.ModifyBandNameForDirectory(i_jazz_photo.BandName);

            start_file_name = start_file_name + @"_" + mod_band_name;

            return start_file_name;

        } // ConstructStartPartZipFileName

        /// <summary>Constructs the start part of the ZIP file name
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto with date, bandname, name of photographer and link to season program object</param>
        private static string GetStartPartZipFileNameFromDocumentDirectoryName(JazzPhoto i_jazz_photo, out string o_error)
        {
            o_error = @"";
            string ret_string = @"";

            JazzDoc[] all_concert_documents = JazzXml.GetAllConcertDocumentsAsArrayBandName(i_jazz_photo.BandName, out o_error);
            if (null == all_concert_documents || all_concert_documents.Length == 0)
            {
                o_error = @"PhotoMain.GetStartPartZipFileNameFromDocumentDirectoryName JazzXml.GetAllConcertDocumentsAsArrayBandName failed " + o_error;
                return ret_string;
            }

            JazzDoc any_document = all_concert_documents[0];

            string dir_name = any_document.FilePath;

            ret_string = dir_name;

            return ret_string;

        } // GetStartPartZipFileNameFromDocumentDirectoryName

        #endregion // ZIP file upload 

        #region Exit ZIP form

        /// <summary>Set the XML data for the ZIP file that was uploaded
        /// <para>Photo data for a (the new) concert will be added to the photo two gallery XML object, corresponding to file JazzFotoGalerieZwei.xml</para>
        /// <para>The photo data is in a JazzPhoto (input) object that will become the added XML element of the photo two gallery XML object.</para>
        /// <para>The following members of JazzPhoto must be set: BandName, Year, Month, Day, GalleryName, PhotographerName, ZipName and ConcertNumber</para>
        /// <para>The other member variables (TextOne, TextTwo. ..., TextNine) will be set when the gallery HTM files are uploaded</para>
        /// <para>The season concert XML object (JazzProgramm_20xx_20yy.xml) will also be set when the gallery HTM files are uploaded</para>
        /// <para></para>
        /// <para>1. Get gallery number GXXX for the new photo element. Call of JazzXml.GetGalleryNumberNewPhoto</para>
        /// <para>2. Get season start year for the new photo element. Call of JazzUtils.GetSeasonStartYear</para>
        /// <para>3. Add the new photo XML element to gallery two XML object. Call of AddDataToXmlPhotoTwo</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_zip_jazz_photo">Photo data set with the form PhotoZipForm</param>
        /// <param name="i_upload_season_str">Season string corresponding to i_zip_jazz_photo</param>
        /// <param name="o_error">Error message</param>
        public static bool SetXmlZipPhotoData(JazzPhoto i_zip_jazz_photo, string i_upload_season_str , out string o_error)
        {
            o_error = @"";

            if (!CheckInputXmlZipPhotoData(i_zip_jazz_photo, i_upload_season_str, out o_error))
            {
                o_error = @"PhotoMain.SetXmlZipPhotoData CheckInputXmlZipPhotoData failed " + o_error;
                return false;
            }

            JazzPhoto existing_jazz_photo = null;
            int existing_concert_number = -12345;
            int existing_season_number = -12345;
            if (GalleryAlreadyExists(i_zip_jazz_photo, i_upload_season_str, out existing_jazz_photo, out existing_concert_number, out existing_season_number, out  o_error))
            {
                JazzXml.SetPhotoTwoZipName(existing_season_number, existing_concert_number, i_zip_jazz_photo.ZipName);

                if (!UpdateZipSeasonXmlFile(i_zip_jazz_photo, out o_error))
                {
                    o_error = @"PhotoMain.SetXmlZipPhotoData UpdateSeasonXmlFile failed " + o_error;
                    return false;
                }

                // Only for debug QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ
                JazzXml.GetObjectPhotoTwo().Save("Debug_PhotoMainAddDataToXmlPhotoTwo.xml");

                return true;

            } // Update the existing photo XML element

            bool b_photo_one = false;
            string gallery_name = JazzXml.GetGalleryNumberNewPhoto(b_photo_one, out o_error);
            if (gallery_name.Length != 4)
            {
                o_error = @"PhotoMain.SetXmlZipPhotoData JazzXml.GetGalleryNumberNewPhoto failed";
                return false;
            }

            i_zip_jazz_photo.GalleryName = gallery_name;

            int start_season_year = JazzUtils.GetSeasonStartYear(i_upload_season_str, out o_error);
            if (start_season_year < 0)
            {
                o_error = @"PhotoMain.SetXmlZipPhotoData JazzUtils.GetSeasonStartYear failed";
                return false;
            }

            string start_season_year_str = start_season_year.ToString();           

            if (!AddDataToXmlPhotoTwo(i_zip_jazz_photo, start_season_year_str, out o_error))
            {
                o_error = @"PhotoMain.SetXmlZipPhotoData AddDataToXmlPhotoTwo failed " + o_error;
                return false;
            }

            if (!UpdateZipSeasonXmlFile(i_zip_jazz_photo, out o_error))
            {
                o_error = @"PhotoMain.SetXmlZipPhotoData UpdateSeasonXmlFile failed " + o_error;
                return false;
            }

            // Only for debug QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ
            JazzXml.GetObjectPhotoTwo().Save("Debug_PhotoMainAddDataToXmlPhotoTwo.xml");

            return true;

        } // SetXmlZipPhotoData

        /// <summary>Check input data for SetXmlZipPhotoData. This function should first be called from PhotoZipForm</summary>
        public static bool CheckInputXmlZipPhotoData(JazzPhoto i_zip_jazz_photo, string i_upload_season_str, out string o_error)
        {
            o_error = @"";

            if (i_zip_jazz_photo.ZipName.Trim().Length == 0)
            {
                o_error = PhotoStrings.ErrMsgZipFileNotUploaded;
                return false;
            }

            string photographer_name = i_zip_jazz_photo.PhotographerName.Trim();
            if (photographer_name.Length == 0)
            {
                o_error = PhotoStrings.ErrMsgPhotographerNameIsNotSet;
                return false;
            }

            int index_space = photographer_name.IndexOf(@" ");
            if (index_space < 0)
            {
                o_error = PhotoStrings.ErrMsgPhotographerNameSpace;
                return false;
            }

            if (i_upload_season_str.Trim().Length == 0)
            {
                o_error = PhotoStrings.ErrMsgZipSeasonString;
                return false;
            }

            return true;

        } // CheckInputXmlZipPhotoData


        /// <summary>Returns true if the gallery already exists in the XML photo gallery two object (JazzXml.m_xdocument_photo_two) corresponding to XML file JazzGalerieZwei.xml
        /// <para>Please note that the user only can select band names (concerts) where there are no ZIP files.</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_zip_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_upload_season_str">Start season year for the photo data in input object JazzPhoto</param>
        /// <param name="o_existing_jazz_photo">Existing JazzPhoto object</param>
        /// <param name="o_concert_number">Concert number for the existing JazzPhoto object</param>
        /// <param name="o_season_number">Season number for the existing JazzPhoto object</param>
        /// <param name="o_error">Error message</param>
        public static bool GalleryAlreadyExists(JazzPhoto i_zip_jazz_photo, string i_upload_season_str, out JazzPhoto o_existing_jazz_photo, out int o_concert_number, out int o_season_number, out string o_error)
        {
            o_error = @"";
            o_existing_jazz_photo = null;
            o_season_number = -12345;
            o_concert_number = -12345;

            if (i_zip_jazz_photo.ZipName.Trim().Length == 0)
            {
                o_error = @"PhotoMain.GalleryAlreadyExists Zip file name is not set";
                return false;
            }

            if (i_upload_season_str.Trim().Length == 0)
            {
                o_error = @"PhotoMain.GalleryAlreadyExists i_upload_season_str is not set";
                return false;
            }

            int season_start_year = JazzUtils.GetSeasonStartYear(i_upload_season_str, out o_error);
            if (season_start_year < 0)
            {
                o_error = @"PhotoMain.GalleryAlreadyExists JazzUtils.GetSeasonStartYear failed " + o_error;
                return false;
            }

            string season_start_year_str = season_start_year.ToString();

            bool b_photo_one = false;

            int season_number = JazzXml.GetSeasonNumber(b_photo_one, season_start_year_str, out o_error);
            if (season_number < -1)
            {
                o_error = "PhotoMain.GalleryAlreadyExists JazzXml.GetSeasonNumber failed for season_start_year_str= " + season_start_year_str + " season_number= " + season_number.ToString();
                return false;
            }

            JazzPhoto[] photo_objects = JazzXml.GetPhotoTwoObjects(season_number, out o_error);
            if (photo_objects == null)
            {
                o_error = "PhotoMain.GalleryAlreadyExists JazzXml.GetPhotoTwoObjects returned null";
                return false;
            }

            for (int index_photo=0; index_photo<photo_objects.Length; index_photo++)
            {
                JazzPhoto current_photo = photo_objects[index_photo];
                string current_band_name = current_photo.BandName;

                if (current_band_name.Equals(i_zip_jazz_photo.BandName))
                {
                    JazzPhoto ret_jazz_photo = new JazzPhoto();

                    o_existing_jazz_photo = ret_jazz_photo;

                    o_concert_number = index_photo + 1;

                    o_season_number = season_number;

                    return true;

                } // There is an existing gallery

            } // index_photo


            o_error = @"PhotoMain.GalleryAlreadyExists Gallery does not exist";
            return false;

        } // GalleryAlreadyExists

        /// <summary>Add an XML element defined by a photo object (JazzPhoto) to the XML photo gallery two object (JazzXml.m_xdocument_photo_two) corresponding to XML file JazzGalerieZwei.xml
        /// <para>1. Check input JazzPhoto member variables. Call of JazzPhoto.CheckParameterValues</para>
        /// <para></para>
        /// <para>2. Get season number in the JazzGalerieZwei.xml (XML object). Call of JazzXml.GetSeasonNumber</para>
        /// <para>3. If there are no seasons add the first season element and the JazzPhoto element. Call of JazzXml.PhotoSeasonAppend and JazzXml.PhotoAppend</para>
        /// <para>4. If the season element not exists add it and the JazzPhoto element. Call of JazzXml.PhotoAppend and JazzXml.PhotoAppend</para>
        /// <para>5. If the season element exists add the JazzPhoto element. Call of JazzXml.PhotoAppend</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_season_start_year_str">Start season year for the photo data in input object JazzPhoto</param>
        /// <param name="o_error">Error message</param>
        private static bool AddDataToXmlPhotoTwo(JazzPhoto i_jazz_photo, string i_season_start_year_str, out string o_error)
        {
            o_error = @"";

            if (!i_jazz_photo.CheckParameterValues(out o_error))
            {
                o_error = @"PhotoMain.AddDataToXmlPhotoTwo JazzPhoto.CheckParameterValues failed " + o_error;
                return false;
            }

            JazzPhoto jazz_photo_undef_values = i_jazz_photo.GetObjectWithUndefinedNodeValues(i_jazz_photo);

            bool b_photo_one = false;

            int season_number = JazzXml.GetSeasonNumber(b_photo_one, i_season_start_year_str, out o_error);
            if (season_number < -1)
            {
                o_error = "PhotoMain.AddDataToXmlPhotoTwo JazzXml.GetSeasonNumber failed season_number= " + season_number.ToString();
                return false;
            }

            int season_start_year = JazzUtils.StringToInt(i_season_start_year_str);

            if (0 == season_number)
            {
                // First season element shall be added
                if (!JazzXml.PhotoSeasonAppend(b_photo_one, season_start_year, out o_error))
                {
                    o_error = @"PhotoMain.AddDataToXmlPhotoTwo JazzXml.PhotoSeasonAppend failed " + o_error;
                    return false;
                }

                //QQQ  if (!JazzXml.PhotoAppend(b_photo_one, i_jazz_photo, season_number + 1, out o_error))
                if (!JazzXml.PhotoAppend(b_photo_one, jazz_photo_undef_values, season_number + 1, out o_error))
                {
                    o_error = @"PhotoMain.AddDataToXmlPhotoTwo JazzXml.PhotoAppend failed " + o_error;
                    return false;
                }

            } // First season element in the jazz gallery one XML object

            else if (-1 == season_number)
            {
                // TODO If a ZIP file is added for a season that not previously exists
                // the new season will be added at the end of the XML file. In other
                // words it is assumed, and it is likely, that a new season is the
                // youngest season. Most things will probabbly also work fine
                // if an old season is at the end of the XML file. It is just not nice
                // and can be confusing for the developer.

                // An additional season element
                if (!JazzXml.PhotoSeasonAppend(b_photo_one, season_start_year, out o_error))
                {
                    o_error = @"PhotoMain.AddDataToXmlPhotoTwo JazzXml.PhotoSeasonAppend failed " + o_error;
                    return false;
                }

                season_number = JazzXml.GetSeasonNumber(b_photo_one, i_season_start_year_str, out o_error);

                //QQQ if (!JazzXml.PhotoAppend(b_photo_one, i_jazz_photo, season_number, out o_error))
                if (!JazzXml.PhotoAppend(b_photo_one, jazz_photo_undef_values, season_number, out o_error))
                {
                    o_error = @"PhotoMain.AddDataToXmlPhotoTwo JazzXml.PhotoAppend failed " + o_error;
                    return false;
                }

            } // An additional season element
            else
            {
                // Add to existing saison element
                //QQQ if (!JazzXml.PhotoAppend(b_photo_one, i_jazz_photo, season_number, out o_error))
                if (!JazzXml.PhotoAppend(b_photo_one, jazz_photo_undef_values, season_number, out o_error))
                {
                    o_error = @"PhotoMain.AddDataToXmlPhotoTwo JazzXml.PhotoAppend failed " + o_error;
                    return false;
                }

            } // Add to existing saison element


            return true;

        } // AddDataToXmlPhotoTwo


        /// <summary>Set the photo zip data coming from the form PhotoZipForm
        /// <para>The following members of JazzPhoto are set: BandName, Year, Month, Day, PhotographerName and ConcertNumber</para>
        /// <para>1. Get the photographer name from the combo box.</para>
        /// <para>2. Get the concert number corresponding to the band name. Call of PhotoMain.GetConcertNumber</para>
        /// <para>3. Get the date from the season XML object. Calls of JazzXml.GetYear, GetMonth and GetDay</para>
        /// <para>4. Set the data in the input/output JazzPhoto object i_zip_jazz_data</para>
        /// </summary>
        /// <param name="i_zip_jazz_data">Photo data set with the form PhotoZipForm</param>
        /// <param name="i_combo_box_band_name">Combo box with the band name</param>
        /// <param name="i_text_box_photographer">Text box with the name of the photographer</param>
        /// <param name="o_error">Error message</param>
        public static void SetZipPhotoDataFromForm(ref JazzPhoto i_zip_jazz_data, ComboBox i_combo_box_band_name, TextBox i_text_box_photographer_name)
        {
            string band_name = i_combo_box_band_name.Text;          
            string photographer_str = i_text_box_photographer_name.Text;

            int concert_number = PhotoMain.GetConcertNumber(band_name);

            i_zip_jazz_data.BandName = band_name;
            i_zip_jazz_data.Year = JazzXml.GetYear(concert_number);
            i_zip_jazz_data.Month = JazzXml.GetMonth(concert_number);
            i_zip_jazz_data.Day = JazzXml.GetDay(concert_number);
            i_zip_jazz_data.ConcertNumberInt = concert_number;
            i_zip_jazz_data.PhotographerName = photographer_str;

        } // SetZipPhotoDataFromForm

        #endregion // Exit ZIP form

        #region Update XML season file JazzProgramm_20XX_20YY.xml

        /// <summary>Update the season XML file with the new photo ZIP file
        /// <para>Please note that the right current season XML object is set by form PhotoZipForm with function PhotoMain.SetSeason </para>
        /// <para>1. Get current XML season file name. Call of JazzXml.GetCurrentSeasonFileUrl</para>
        /// <para>2. Get current season XDocument. Call of JazzXml.GetDocumentCurrent</para>
        /// <para>3. Set ZIP name. Call of JazzXml.SetPhotoGalleryTwoZip</para>
        /// <para>4. Add season XML file to array for upload. Call of AddUploadPhotoXmlFile</para>
        /// </summary>
        /// <param name="i_zip_jazz_photo">Photo data set with the form PhotoZipForm</param>
        /// <param name="o_error">Error message</param>
        public static bool UpdateZipSeasonXmlFile(JazzPhoto i_zip_jazz_photo, out string o_error)
        {
            o_error = @"";

            string season_xml_file_url = JazzXml.GetCurrentSeasonFileUrl();

            string season_xml_file_name = Path.GetFileName(season_xml_file_url);

            XDocument season_xml_object = JazzXml.GetDocumentCurrent();

            JazzXml.SetPhotoGalleryTwoZip(i_zip_jazz_photo.ConcertNumberInt, i_zip_jazz_photo.ZipName);

            AddUploadPhotoXmlFile(season_xml_file_name, season_xml_object);

            // Debug Start
            XDocument[] upload_xdocs = GetUploadPhotoXmlXDocuments;
            string[] upload_files = GetUploadPhotoXmlFileNames;
            season_xml_object.Save(PhotoMaintenanceDir + @"\" + "Debug_PhotoMain_UpdateZipSeasonXmlFile.xml");
            // Debug End

            return true;

        } // UpdateZipSeasonXmlFile

        /// <summary>Update the season XML object (corresponding to file JazzFotoGalerieZwei.xml) with the uploaded (added) gallery
        /// <para>Please note that the right current season XML object is set by form PhotoZipForm with function PhotoMain.SetSeason </para>
        /// <para>1. Get current XML season file name. Call of JazzXml.GetCurrentSeasonFileUrl</para>
        /// <para>2. Get current season XDocument. Call of JazzXml.GetDocumentCurrent</para>
        /// <para>3. Set ZIP name. Call of JazzXml.SetPhotoGalleryTwoZip</para>
        /// <para>4. Add season XML file to array for upload. Call of AddUploadPhotoXmlFile</para>
        /// </summary>
        /// <param name="i_jazz_photo">Photo object for the uploaded (added) gallery</param>
        /// <param name="o_error">Error message</param>
        public static bool UpdateGallerySeasonXmlFile(JazzPhoto i_jazz_photo, out string o_error)
        {
            o_error = @"";

            string directory_name = @"";
            if (!i_jazz_photo.GalleryTwoDirectoryName(out directory_name, out o_error))
            {
                o_error = @"PhotoMain.UpdateGallerySeasonXmlFile JazzPhoto.GalleryTwoDirectoryName failed " + o_error;

                return false;
            }

            string gallery_link = GalleryTwoServerDir + @"/" + directory_name + @"/" + GalleryHtmFileNameStartString + i_jazz_photo.GalleryName + @".htm";
            // FotoKonzerte/Konzert.2017.10.07/JazzGalerie_G112.htm

            XDocument input_active_season_object = JazzXml.GetDocumentCurrent();

            int concert_number = -12345;
            XDocument xdocument_jazz_photo = GetXdocumentJazzPhoto(i_jazz_photo, out concert_number, out o_error);
            if (null == xdocument_jazz_photo)
            {
                o_error = @"PhotoMain.UpdateGallerySeasonXmlFile GetXdocumentJazzPhoto failed " + o_error;
                return false;
            }

            JazzXml.SetDocumentCurrent(xdocument_jazz_photo);
            JazzXml.SetCurrentSeasonFileUrl();

            string season_xml_file_url = JazzXml.GetCurrentSeasonFileUrl();

            string season_xml_file_name = Path.GetFileName(season_xml_file_url);

            XDocument season_xml_object = JazzXml.GetDocumentCurrent();

            JazzXml.SetPhotoGalleryTwo(concert_number, gallery_link);

            AddUploadPhotoXmlFile(season_xml_file_name, season_xml_object);

            // Debug Start
            XDocument[] upload_xdocs = GetUploadPhotoXmlXDocuments;
            string[] upload_files = GetUploadPhotoXmlFileNames;
            season_xml_object.Save(PhotoMaintenanceDir + @"\" + "Debug_PhotoMain_UpdateGallerySeasonXmlFile.xml");
            // Debug End

            JazzXml.SetDocumentCurrent(input_active_season_object);

            return true;

        } // UpdateGallerySeasonXmlFile

        /// <summary>Returns year concert numbers
        /// <para>Please note that it is not the season concert numbers that are returned.</para>
        /// <para>Start year for galleries based on JavaScripts is 2018, i.e. start season for concert years is 2017-2018</para>
        /// <para>All XML files are no longer loaded. Start season is 2019-2020.</para>
        /// <para>Bug fix 2023-02-09: Loop start changed to 2022 from 2017</para>
        /// </summary>
        /// <param name="i_jazz_photos_with_galleries">JazzPhoto objects with uploaded galleries. All for the same year. This array may have the length=0</param>
        /// <param name="o_error">Error description</param>
        /// <returns>Array with all year (not season) concert numbers</returns>
        public static XDocument GetXdocumentJazzPhoto(JazzPhoto i_jazz_photo, out int o_concert_number, out string o_error)
        {
            o_error = @"";
            XDocument ret_xdocument_jazz_photo = null;
            o_concert_number = -12345;

            int concert_year = i_jazz_photo.YearInt;
            int concert_month = i_jazz_photo.MonthInt;
            int concert_day = i_jazz_photo.DayInt;

            XDocument input_active_season_object = JazzXml.GetDocumentCurrent();

            for (int season_start_year = 2022; season_start_year <= concert_year; season_start_year++)
            {
                if (!JazzXml.SetXmlDocument(season_start_year))
                {
                    o_error = @"PhotoMain.GetXdocumentJazzPhoto JazzXml.SetXmlDocument failed for season_start_year= " + season_start_year.ToString();
                    return null;
                }

                int number_season_concerts = JazzXml.GetNumberConcertsInCurrentDocument();
                if (number_season_concerts < 1)
                {
                    o_error = @"PhotoMain.GetXdocumentJazzPhoto number_season_concerts < 1 for for season_start_year= " + season_start_year.ToString();
                    return null;
                }

                for (int concert_number = 1; concert_number <= number_season_concerts; concert_number++)
                {
                    int current_concert_year = JazzXml.GetYearInt(concert_number);
                    int current_concert_month = JazzXml.GetMonthInt(concert_number);
                    int current_concert_day = JazzXml.GetDayInt(concert_number);
                    if (concert_year == current_concert_year && concert_month == current_concert_month && concert_day == current_concert_day)
                    {
                        ret_xdocument_jazz_photo = JazzXml.GetDocumentCurrent();
                        o_concert_number = concert_number;

                        break;
                    }

                    if (ret_xdocument_jazz_photo != null)
                    {
                        break;
                    }

                } // concert_number

            } // season_start_year

            JazzXml.SetDocumentCurrent(input_active_season_object);

            if (null == ret_xdocument_jazz_photo)
            {
                o_error = @"PhotoMain.GetXdocumentJazzPhoto JazzXml.SetXmlDocument failed for concert= " + i_jazz_photo.BandName;
            }

            return ret_xdocument_jazz_photo;

        } // GetXdocumentJazzPhoto

        #endregion // Update XML season file JazzProgramm_20XX_20YY.xml

        #region Local directory for the gallery 

        /// <summary>Get the name of the local gallery directory
        /// <para>Create the directories if not existing</para>
        /// <para>Note that in the local folder Fotos there are the same subdirectories (FotoKonzerte and FotoScripts) as on the server</para>
        /// </summary>
        /// <param name="i_jazz_photo">Input gallery name and concert date.</param>
        /// <param name="o_full_directory_name">Full path to the local gallery directory</param>
        /// <param name="o_error">Error message</param>
        public static bool GetNameAndPathToLocalGalleryDirectory(JazzPhoto i_jazz_photo, out string o_full_directory_name, out string o_error)
        {
            o_error = @"";
            o_full_directory_name = @"";

            string directory_name = @"";
            if (!i_jazz_photo.GalleryTwoDirectoryName(out directory_name, out o_error))
            {
                o_error = @"PhotoMain.GetNameAndPathToLocalGalleryDirectory JazzPhoto.GalleryTwoDirectoryName failed " + o_error;

                return false;
            }

            o_full_directory_name = FileUtil.SubDirectory(PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.GalleryTwoServerDir + @"\" + directory_name, Main.m_exe_directory) + @"\";

            return true;

        } // GetNameAndPathToLocalGalleryDirectory


        #endregion // Local directory for the gallery 

        #region Get picture for gallery

        /// <summary>Copy one big picture or a small picture to the gallery directory
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_b_big">Flag telling if it is a big or small picture that shall be copied</param>
        /// <param name="i_picture_number">Picture number</param>
        /// <param name="io_jazz_photo">JazzPhoto object</param>
        /// <param name="i_picture_file_name">Picture file name</param>
        /// <param name="o_error">Error message</param>
        public static bool CopyPictureForGallery(bool i_b_big, int i_picture_number, ref JazzPhoto io_jazz_photo, string i_picture_file_name, out string o_error)
        {
            o_error = @"";

            if (!File.Exists(i_picture_file_name))
            {
                o_error = @"PhotoMain.CopyPictureForGallery Not an existing file i_picture_file_name= " + i_picture_file_name;
                return false;
            }

            // JazzPhoto.GalleryPhotoName only returns a name if boolean is set
            if (i_b_big)
            {
                io_jazz_photo.SetBigPicture(i_picture_number, true);
            }
            else
            {
                io_jazz_photo.SetSmallPicture(i_picture_number, true);
            }

            string gallery_photo_file_name = @"";
            if (!io_jazz_photo.GalleryPhotoName(i_b_big, i_picture_number, out gallery_photo_file_name, out o_error))
            {
                o_error = @"PhotoMain.CopyPictureForGallery JazzPhoto.GalleryPhotoName failed " + o_error;
                return false;
            }

            string full_directory_name = @"";
            if (!GetNameAndPathToLocalGalleryDirectory(io_jazz_photo, out full_directory_name, out o_error))
            {
                o_error = @"PhotoMain.CopyPictureForGallery GetNameAndPathToLocalGalleryDirectory failed " + o_error;
                return false;
            }

            string full_gallery_photo_file_name = full_directory_name + gallery_photo_file_name;

            if (File.Exists(full_gallery_photo_file_name))
            {
                File.Delete(full_gallery_photo_file_name);
            }

            File.Copy(i_picture_file_name, full_gallery_photo_file_name);

            return true;

        } // CopyPictureForGallery

        /// <summary>Get one big picture or a small picture for the gallery
        /// <para>Let the user select the photo. Call of OpenSaveDialog.GetFileName.</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_b_big">Flag telling if it is a big or small picture that shall be selected</param>
        /// <param name="o_error">Error message</param>
        public static bool GetPictureForGallery(bool i_b_big, out bool o_cancel_upload, out string o_picture_file_name, out string o_error)
        {
            o_error = @"";
            o_cancel_upload = false;
            o_picture_file_name = @"";

            string file_extensions = @"jpg";

            if (!OpenSaveDialog.GetFileName("jpg", file_extensions, out o_cancel_upload, out o_picture_file_name, out o_error))
            {
                o_error = @"PhotoMain.GetPictureForGallery OpenSaveDialog.GetFileName failed " + o_error;
                return false;
            }

            if (o_cancel_upload)
            {
                return true;
            }

            return true;

        } // GetPictureForGallery

        /*QQQQQQQQ
        /// <summary>Get picture size
        /// <para></para>
        /// </summary>
        /// <param name="i_picture_file_name">File name of picture</param>
        /// <param name="o_width">Width in pixel</param>
        /// <param name="o_height">Height in pixel</param>
        /// <param name="o_error">Error message</param>
        public static bool GetPictureSize(string i_picture_file_name, out int o_width, out int o_height, out string o_error)
        {
            o_width = -12345;
            o_height = -12345;
            o_error = @"";

            if (!File.Exists(i_picture_file_name))
            {
                o_error = @"PhotoMain.GetPictureSize Not existing file " + i_picture_file_name;
                return false;
            }

            Bitmap input_bitmap = (Bitmap)Image.FromFile(i_picture_file_name);

            o_width = input_bitmap.Width;
            o_height = input_bitmap.Height;

            return true;

        } // GetPictureSize
        QQQQ*/

        /// <summary>Is picture size within tolerance
        /// <para>Get picture width and height. Call of GetPictureSize</para>
        /// <para>For the big picture check size with GetBigPictureHeight and GetBigPictureTol</para>
        /// <para>For the big picture check size with GetSmallPictureHeight, GetSmallPictureWidth and GetSmallPictureTol</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_b_big">Flag telling if it is the big or the small picture</param>
        /// <param name="i_picture_file_name">File name of picture</param>
        /// <param name="o_error">Error message</param>
        public static bool IsPictureSizeWithinTol(bool i_b_big, string i_picture_file_name, out string o_error)
        {
            o_error = @"";

            int picture_height = -12345;
            int picture_width = -12345;

            if (!PhotoEdit.GetPictureSize(i_picture_file_name, out picture_width, out picture_height, out o_error))
            {
                o_error = @"PhotoMain.IsPictureSizeWithinTol GetPictureSize failed " + o_error;
                return false;
            }

            if (i_b_big)
            {
                if (picture_height < GetBigPictureHeight() - GetBigPictureTol() || picture_height > GetBigPictureHeight() + GetBigPictureTol())
                {
                    o_error = PhotoStrings.ErrMsgBigPhotoHeightNotWithinTol + GetBigPictureHeight();

                    return false;
                }
            }
            else
            {
                if (picture_height < GetSmallPictureHeight() - GetSmallPictureTol() || picture_height > GetSmallPictureHeight() + GetSmallPictureTol())
                {
                    o_error = PhotoStrings.ErrMsgSmallPhotoHeightNotWithinTol + GetSmallPictureHeight();

                    return false;
                }

                if (picture_width < GetSmallPictureWidth() - GetSmallPictureTol() || picture_width > GetSmallPictureWidth() + GetSmallPictureTol())
                {
                    o_error = PhotoStrings.ErrMsgSmallPhotoWidthNotWithinTol + GetSmallPictureWidth();

                    return false;
                }
            }

   
            return true;

        } // IsPictureSizeWithinTol

        #endregion // Get picture for gallery

        #region Picture boxes

        /// <summary>Set picture box
        /// <para></para>
        /// </summary>
        /// <param name="i_picture_box">Picture box</param>
        /// <param name="i_picture_file_name">File name of picture</param>
        public static void SetPictureBox(PictureBox i_picture_box, string i_picture_file_name)
        {
            if (!File.Exists(i_picture_file_name))
            {
                return;
            }

            FreePictureBox(i_picture_box);

            i_picture_box.Image = Image.FromFile(i_picture_file_name);

            i_picture_box.BackgroundImage = null;

        } // SetPictureBox

        /// <summary>Free picture box
        /// <para>This is necessary when the same gallery photo is selected again. File.Copy fails otherwise</para>
        /// </summary>
        /// <param name="i_picture_box">Picture box</param>
        public static void FreePictureBox(PictureBox i_picture_box)
        {

            if (i_picture_box.Image != null)
            {
                i_picture_box.Image.Dispose();
                i_picture_box.Image = null;
            }

        } // SetPictureBox

        #endregion // Picture boxes

    } // PhotoMain

} // namespace
