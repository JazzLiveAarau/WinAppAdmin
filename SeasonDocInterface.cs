using JazzApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>
    /// Functions retrieving information from the document (DOC) XML files
    /// </summary>
    class SeasonDocInterface
    {
        #region Member variables

        /// <summary>Flag telling if the active DOC XML object is set</summary>
        private bool m_active_doc_xml_is_set = false;
        /// <summary>Get and set flag telling if the active DOC XML object is set</summary>
        private bool ActiveDocIsSet { get { return m_active_doc_xml_is_set; } set { m_active_doc_xml_is_set = value; } }

        /// <summary>Documents path</summary>
        private string m_documents_path = @"";

        /// <summary>Returns the documents path</summary>
        public string DocumentsPath { get { return m_documents_path; } }

        /// <summary>Array with concert file paths. The strings are also used as start strings for files in these directories</summary>
        private string[] m_concert_file_paths = null;

        /// <summary>Start URL string for JAZZ live AARAU</summary>
        private string m_url_https_str = @"https://jazzliveaarau.ch/";

        /// <summary>Returns the start URL string for JAZZ live AARAU</summary>
        private string UrlStartJazzLiveAarau { get { return m_url_https_str; } }

        /// <summary>Season program XML object corresponding to the active DOC XML object</summary>
        private XDocument m_season_xml = null;

        /// <summary>Season program XML file name corresponding to the active DOC XML object</summary>
        string m_season_xml_file_name = @"";

        /// <summary>The active season program XML object (when this class is instantiated)</summary>
        private XDocument m_season_xml_active = null;

        /// <summary>The active season program XML file name (when this class is instantiated)</summary>
        string m_season_xml_file_name_active = @"";

        /// <summary>The input start year</summary>
        private int m_input_season_start_year = -12345;

        /// <summary>Get and set the input start year</summary>
        private int InputStartYear { get { return m_input_season_start_year; }  set { m_input_season_start_year = value; }  }

        /// <summary>Flag telling if m_season_xml is equal to the active </summary>
        private bool m_season_xml_equal_to_active = false;

        /// <summary>Returns true if there is no need to change between objects m_season_xml and m_season_xml_active</summary>
        private bool NoNeedToChangeXmlObjects { get { return m_season_xml_equal_to_active;  }  }

        #endregion // Member variables

        #region Initialization 

        /// <summary>
        /// The active DOC XML object will be used
        /// <para>1. Check that there is an active DOC XML object. Call of JazzXml.GetObjectActiveDoc</para>
        /// <para>2. Make the common intializations. Call of InitCommon.</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>false for failure</returns>
        public bool InitUseActiveDoc(out string o_error)
        {
            o_error = @"";

            string error_msg = @"";

            XDocument active_doc = JazzXml.GetObjectActiveDoc();

            if (null == active_doc)
            {
                o_error = @"SeasonDocInterface.InitUseActiveDoc There is no active XML DOC";

                ActiveDocIsSet = false;

                return false;
            }

            InputStartYear = DocAdminUtil.GetDocAutumnYearInt();

            if (!InitCommon(out error_msg))
            {
                o_error = @"SeasonDocInterface.InitUseActiveDoc InitCommon failed " + error_msg;

                return false;
            }

            return true;

        } // InitUseActiveDoc

        /// <summary>
        /// Sets the active DOC XML object. 
        /// <para>1. Set the active DOC XML object. Call of SetActiveDocXmlObject</para>
        /// <para>2. Make the common intializations. Call of InitCommon.</para>
        /// </summary>
        /// <param name="i_season_start_year">Season start year</param>
        /// <param name="o_error">Error message</param>
        /// <returns>false for failure</returns>
        public bool InitSetActiveDoc(int i_season_start_year, out string o_error)
        {
            o_error = @"";

            string error_msg = @"";

            InputStartYear = i_season_start_year;

            if (!SetActiveDocXmlObject(i_season_start_year, out error_msg))
            {
                o_error = @"SeasonDocInterface.InitSetActiveDoc SetActiveDocXmlObject failed " + error_msg;

                ActiveDocIsSet = false;

                return false;
            }

            if (!InitCommon(out error_msg))
            {
                o_error = @"SeasonDocInterface.InitSetActiveDoc InitCommon failed " + error_msg;

                return false;
            }

            return true;

        } // InitSetActiveDoc

        /// <summary>
        /// Initialization common for functions InitUseActiveDoc and InitSetActiveDoc
        /// <para>1. Set the member variable document path (m_documents_path). Call of JazzXml.GetDocDocumentsPath()</para>
        /// <para>2. Set the member variable concerts paths (m_concert_file_paths), i.e. paths to the 
        /// directories with concert documents. Call of SetConcertFilePaths</para>
        /// <para>3. Set the member variable m_season_xml that holds the season program XML object 
        /// corresponding to the active DOC XMl object. Call of SetSeasonProgramXmlObject</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>flase for failuer</returns>
        private bool InitCommon(out string o_error)
        {
            o_error = @"";

            string error_msg = @"";

            m_documents_path = JazzXml.GetDocDocumentsPath();

            if (!SetConcertFilePaths(out error_msg))
            {
                o_error = @"SeasonDocInterface.InitCommon SetConcertFilePaths failed " + error_msg;

                ActiveDocIsSet = false;

                return false;
            }

            ActiveDocIsSet = true;

            if (!SetSeasonProgramXmlObject(out error_msg))
            {
                o_error = @"SeasonDocInterface.InitCommon SetSeasonProgramXmlObject failed " + error_msg;

                return false;
            }

            if (!CheckObjects(out error_msg))
            {
                o_error = @"SeasonDocInterface.InitCommon CheckObjects failed " + error_msg;

                return false;
            }

            return true;

        } // InitCommon

        /// <summary>
        /// Sets the active (current) doc XML object
        /// </summary>
        /// <param name="i_start_year_str">Season start year</param>
        /// <param name="o_error">Error message</param>
        /// <returns>false for failure</returns>
        private bool SetActiveDocXmlObject(int i_start_year, out string o_error)
        {
            o_error = @"";

            JazzDocAll jazz_doc_all = new JazzDocAll();

            jazz_doc_all.DebugFlag = false;

            string error_msg = @"";

            string season_name = JazzUtils.SeasonName(i_start_year);

            bool b_set_active_season = JazzXml.SetActiveXmlObjectAndFile(season_name, out error_msg);

            if (!b_set_active_season)
            {
                o_error = @"SeasonDocInterface.SetActiveDocXmlObject JazzXml.SetActiveXmlObjectAndFile failed " + error_msg;

                return false;
            }

            return true;

        } // SetActiveDocXmlObject

        /// <summary>
        /// Set the file concert paths, i.e. the paths to the subdirectories where concert documents are saved
        /// <para>They are the same for all concert documents, and the path to any document may be used</para>
        /// </summary>
        /// <param name="o_error"></param>
        /// <returns></returns>
        private bool SetConcertFilePaths(out string o_error)
        {
            o_error = @"";

            string error_msg = @"";

            int n_doc_concerts = JazzXml.GetNumberDocConcerts(out error_msg);
            if (n_doc_concerts <= 0)
            {
                o_error = @"SeasonDocInterface.InitSetActiveDoc JazzXml.GetNumberDocConcerts failed " + error_msg;

                ActiveDocIsSet = false;

                return false;
            }

            m_concert_file_paths = new string[n_doc_concerts];

            for (int concert_number = 1; concert_number <= n_doc_concerts; concert_number++)
            {
                JazzDoc[] all_docs = JazzXml.GetAllConcertDocumentsAsArray(concert_number);

                JazzDoc any_doc = all_docs[0]; // Better to do it as the same as for the poster 

                string doc_file_path = any_doc.FilePath;

                m_concert_file_paths[concert_number - 1] = doc_file_path;

            } // concert_number


            return true;

        } // SetConcertFilePaths

        /// <summary>
        /// Sets the season program XML object corresponding to the active DOC XML object.
        /// <para>1. Get the season start year from the active DOC XML object. Call of DocAdminUtil.GetDocAutumnYearInt</para>
        /// <para>2. Get the XML season program object for this start year. Call of JazzXml.GetDocumentInputYearSeason</para>
        /// <para>3. Set the flag NoNeedToChangeXmlObjects. 
        /// Calls of JazzXml.GetDocumentCurrent, JazzXml.GetYearAutum and JazzXml.SetCurrentSeasonDocument</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>false for failure</returns>
        private bool SetSeasonProgramXmlObject(out string o_error)
        {
            o_error = @"";

            string error_msg = @"";

            if (!ActiveDocIsSet)
            {
                o_error = @"SeasonDocInterface.SetSeasonProgramXmlObject The active DOC XML object is not set";

                return false;
            }

            m_season_xml_active = JazzXml.GetDocumentCurrent();

            m_season_xml_file_name_active = JazzXml.GetSeasonFileName(InputStartYear); 

            int season_start_year_from_doc = InputStartYear;

            int autumn_year_active_season = JazzXml.GetYearAutumnInt();

            if (season_start_year_from_doc == autumn_year_active_season)
            {
                m_season_xml = m_season_xml_active;

                m_season_xml_file_name = m_season_xml_file_name_active;

                m_season_xml_equal_to_active = true;
            }
            else
            {
                m_season_xml = JazzXml.GetDocumentInputYearSeason(season_start_year_from_doc, out error_msg);

                if (null == m_season_xml)
                {
                    o_error = @"SeasonDocInterface.SetSeasonProgramXmlObject JazzXml.GetDocumentInputYearSeason failed " + error_msg;

                    return false;
                }

                JazzXml.SetCurrentSeasonDocument(m_season_xml);

                m_season_xml_file_name = JazzXml.GetSeasonFileName(InputStartYear);

                m_season_xml_equal_to_active = false;
            }

            return true;

        } // SetSeasonProgramXmlObject

        /// <summary>
        /// Check that the objects (XML text files) for season program and DOC correspond to each other.
        /// </summary>
        /// <param name="o_error"></param>
        /// <returns></returns>
        private bool CheckObjects(out string o_error)
        {
            o_error = @"";

            string error_msg = @"";

            if (!NoNeedToChangeXmlObjects)
            {
                JazzXml.SetCurrentSeasonDocument(m_season_xml);
            }

            int n_doc_concerts = JazzXml.GetNumberDocConcerts(out error_msg);

            int n_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

            if (n_doc_concerts != n_concerts)
            {
                o_error = @"SeasonDocInterface.CheckObjects Number of concerts not the same: n_doc_concerts= " + n_doc_concerts.ToString() +
                            @" and n_concerts= " + n_concerts.ToString();

                if (!NoNeedToChangeXmlObjects)
                {
                    JazzXml.SetCurrentSeasonDocument(m_season_xml_active);
                }

                return false;
            }

            for (int concert_number=1; concert_number <= n_concerts; concert_number++)
            {
                string doc_band_name = JazzXml.GetDocConcertBandName(concert_number);

                string band_name = JazzXml.GetBandName(concert_number);

                if (!doc_band_name.Equals(band_name))
                {
                    o_error = @"SeasonDocInterface.CheckObjects Band names not the same: doc_band_name= " + doc_band_name +
                              @" and band_name= " + band_name + @" for concert number " + concert_number.ToString() +
                              " Change <BandName> in JazzDokument_20NN_20MM.xml with an editor or in JazzProgramm_20NN_20MM.xml with Admin";

                    if (!NoNeedToChangeXmlObjects)
                    {
                        JazzXml.SetCurrentSeasonDocument(m_season_xml_active);
                    }

                    return false;
                }
            }

            if (!NoNeedToChangeXmlObjects)
            {
                JazzXml.SetCurrentSeasonDocument(m_season_xml_active);
            }

            return true;

        } // CheckObjects

        #endregion // Initialization 

        #region Create, upload and update XML for homepage, app and newsletter posters

        public bool CreateUploadUpdateXmlPosterNewsletterImages(JazzDoc i_active_doc, out bool o_b_poster, out string o_error)
        {
            o_error = @"";

            o_b_poster = false;

            if (i_active_doc == null)
            {
                o_error = @"SeasonDocInterface.CreateUploadUpdateXmlPosterNewsletterImages Input JazzDoc is null";
            }

            string template_name = i_active_doc.TemplateName;

            string template_name_poster = JazzXml.GetTemplateNamePoster();

            if (!template_name.Equals(template_name_poster))
            {
                o_b_poster = false;

                return true; // Not an error
            }
            else
            {
                o_b_poster = true;
            }

            string documents_path = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetDocDocumentsPath());

            string file_path = i_active_doc.FilePath;

            string server_dir = @"www/" + documents_path + @"/" + file_path;

            string server_file_name = i_active_doc.FileNameImg;

            string error_msg = @"";

            if (!Website.CreateUploadPosterNewsletterImages(server_dir, server_file_name, out error_msg))
            {
                o_error = @"SeasonDocInterface.CreateUploadUpdateXmlPosterNewsletterImages Website.CreateUploadPosterNewsletterImages failed " + error_msg;

                return false;
            }
            /*
                <PosterMidSize>PlakateFlyersBilletsVorlagen/d20201003_PEigenmannNonet/PlakatNewsletter20201003.jpg</PosterMidSize>
                <PosterSmallSize>PlakateFlyersBilletsVorlagen/d20201003_PEigenmannNonet/PlakatNewsletter20201003_Klein.jpg</PosterSmallSize>
            */

            // Not a very good solution assuming that start part of name is e.g d20181006_Sandy_Patton
            string date_str = file_path.Substring(1, 8);

            string poster_newsletter_big_file_name = PhotoMain.PosterNewsletterNameStartString + date_str + @".jpg";
            string poster_newsletter_small_file_name = PhotoMain.PosterNewsletterNameStartString + date_str + PhotoMain.PosterNewsletterSmallNameEndString + @".jpg";

            poster_newsletter_big_file_name = documents_path + @"/" + file_path + @"/" + poster_newsletter_big_file_name;

            poster_newsletter_small_file_name = documents_path + @"/" + file_path + @"/" + poster_newsletter_small_file_name;

            int concert_number = GetConcertNumberFromFilePath(file_path);

            string poster_newsletter_big_file_name_existing = JazzXml.GetPosterMidSize(concert_number);

            string poster_newsletter_small_file_name_existing = JazzXml.GetPosterSmallSize(concert_number);

            if (poster_newsletter_big_file_name_existing.Contains(poster_newsletter_big_file_name) &&
                poster_newsletter_small_file_name_existing.Contains(poster_newsletter_small_file_name))

            {
                return true;
            }

            if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                string warning_msg = @"Kleine Homepage-Plakate sind kreiert, aber die Saison XML Datei " +
                    Path.GetFileName(m_season_xml_file_name) + @" ist nicht aktualisiert, weil siese Datei nicht ausgechecked ist";

                MessageBox.Show(warning_msg);

                return true;
            }

            JazzXml.SetPosterMidSize(concert_number, poster_newsletter_big_file_name);

            JazzXml.SetPosterSmallSize(concert_number, poster_newsletter_small_file_name);

            XDocument current_xml_obj = m_season_xml;
            string season_xml_file_url = m_season_xml_file_name;

            AdminUtils.SetCurrentEditDocument(current_xml_obj);
            AdminUtils.SetCurrentSelectedXmlFile(season_xml_file_url);

            if (!AdminUtils.UploadXmlToServer(true, out error_msg))
            {
                o_error = @"SeasonDocInterface.CreateUploadUpdateXmlPosterNewsletterImages AdminUtils.UploadXmlToServer failed " + error_msg;

                return false;
            }

            return true;

        } // CreateUploadUpdateXmlPosterNewsletterImages

        #endregion // Create, upload and update XML for homepage, app and newsletter posters

        // m_concert_file_paths

        private int GetConcertNumberFromFilePath(string i_file_path)
        {
            int ret_concert_number = -12345;

            for (int concert_number = 1; concert_number <= m_concert_file_paths.Length; concert_number++)
            {
                string current_file_path = m_concert_file_paths[concert_number - 1];

                if (current_file_path.Equals(i_file_path))
                {
                    ret_concert_number = concert_number;

                    break;
                }
            }

            return ret_concert_number;

        } // GetConcertNumberFromFilePath

        #region Get file names and paths

        /// <summary>
        /// Returns the path to the subdirectory where the concert documents are stored on the server
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        /// <returns>Directory name</returns>
        public string GetConcertFilePath(int i_concert_number)
        {
            string ret_path = @"";

            if (i_concert_number < 1 || i_concert_number > m_concert_file_paths.Length)
            {
                return @"SeasonDocInterface.GetConcertFilePath Error: Concert number not between 1 and " + m_concert_file_paths.Length.ToString();
            }

            ret_path = m_concert_file_paths[i_concert_number - 1];

            return ret_path;

        } // GetConcertFilePath

        /// <summary>
        /// Returns a file name starting with the concert file path.
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_end_file_name_str">End of the file name</param>
        /// <param name="i_extension_str">The extension of the file</param>
        /// <returns></returns>
        public string GetFileNameWithConcertPath(int i_concert_number, string i_end_file_name_str, string i_extension_str)
        {
            string ret_file_name = @"";

            string concert_path = GetConcertFilePath(i_concert_number);

            ret_file_name = concert_path + i_end_file_name_str + @"." + i_extension_str;

            return ret_file_name;

        } // GetFileNameWithConcertPath

        /// <summary>
        /// Get the concert server path (to be used for the JazzFtp functions)
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        /// <returns>Server directory starting with www/</returns>
        public string GetServerConcertPath(int i_concert_number)
        {
            string ret_server_path = @"";

            ret_server_path = @"www/" + DocumentsPath + @"/" + GetConcertFilePath(i_concert_number);

            return ret_server_path;

        } // GetServerConcertPath

        /// <summary>
        /// Get the full server URL to the file
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_end_file_name_str">End of the file name</param>
        /// <param name="i_extension_str">The extension of the file</param>
        /// <returns></returns>
        public string GetUrlToFileNameWithConcertPath(int i_concert_number, string i_end_file_name_str, string i_extension_str)
        {
            string ret_url = @"";

            string file_name = GetFileNameWithConcertPath(i_concert_number, i_end_file_name_str, i_extension_str);

            ret_url = UrlStartJazzLiveAarau + DocumentsPath + @"/" + GetConcertFilePath(i_concert_number) + @"/" + file_name;

            return ret_url;

        } // GetUrlToFileNameWithConcertPath

        #endregion // Get file names and paths

    } // SeasonDocInterface

} // namespace
