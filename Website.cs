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
    /// <summary>Variables and functions for update of the homepage
    /// <para>This is an execution class for WebsiteForm</para>
    /// </summary>
    public static class Website
    {
        #region Member variables

        /// <summary>Object that holds all data for the jazz documents that are defined by XML files</summary>
        private static JazzDocAll m_jazz_doc_all_website = null;
        /// <summary>Returns or sets the object that holds all data for the jazz documents that are defined by XML files</summary>
        private static JazzDocAll DocAllWebsite { get { return m_jazz_doc_all_website; } set { m_jazz_doc_all_website = value; } }

        #endregion // Member variables

        #region Main functions
        /* No longer used
                /// <summary>Update the website
                /// <para>1 Create the JavaScript with data and functions for the homepage HTM files (JazzProgramm_Aktuell_Naechste.js)</para>
                /// <para>  1.1 Download file with jscript functions. Call of DownLoad.DownloadHtmTemplates</para>
                /// <para>  1.2 Get document XML objects (JazzDokumente_20XX_20YY.xml) for this and nex year. Call of JazzXml.GetDocumentThisYearSeason and GetDocumentNextYearSeason</para>
                /// <para>  1.3 Create an empty start JavaScript data file (JazzProgramm_Aktuell_Naechste.js). </para>
                /// <para>  1.4 Append data. Call of _AppendHeader, _AppendSeason, _AppendConcerts, _AppendApplicationData and _AppendMembers</para>
                /// <para>  1.5 Append the file with JavaScripts. Call of FileUtils.AppendFile</para>
                /// <para>  1.6 Upload the JavaScript file (JazzProgramm_Aktuell_Naechste.js). Call of _UploadJscriptFile</para>
                /// <para>2 Create and upload poster-newsletter images. Call of UploadPhotosForWebsiteApp</para>
                /// </summary>
                /// <param name="i_progress_bar">Progress bar</param>
                /// <param name="i_textbox_message">Text box for messages</param>
                /// <param name="o_error">Error description</param>
                public static bool UpdateWebsite(ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
                {
                    o_error = @"";

                    if (null == DocAllWebsite)
                    {
                        o_error = @"Website.UpdateWebsite DocAllWebsite = null";
                    }

                    if (null == i_progress_bar)
                    {
                        o_error = @"Website.UpdateWebsite Programming error i_progress_bar = null";
                    }

                    if (null == i_textbox_message)
                    {
                        o_error = @"Website.UpdateWebsite Programming error i_textbox_message = null";
                    }

                    string debug_doc_state = JazzXml.DebugGetDocStateData(true, true);

                    DownLoad down_load = new DownLoad();
                    string error_message = "";

                    if (!down_load.DownloadHtmTemplates(out error_message))
                    {
                        o_error = JazzAppAdminSettings.Default.ErrMsgHtmTemplatesDownload;
                        return false;
                    }

                    XDocument this_year_season_doc = JazzXml.GetDocumentThisYearSeason(out error_message);
                    if (null == this_year_season_doc)
                    {
                        o_error = @"Website.UpdateWebsite This year XML document is null. " + error_message;
                        return false;
                    }

                    XDocument next_year_season_doc = JazzXml.GetDocumentNextYearSeason(out error_message);
                    if (null == next_year_season_doc)
                    {
                        o_error = @"Website.UpdateWebsite Next year XML document is null. " + error_message;
                        return false;
                    }

                    string file_name_path = FileUtil.CreateFile(JazzAppAdminSettings.Default.FileJscriptFunctions, JazzAppAdminSettings.Default.DirJscripts, Main.m_exe_directory, out o_error);
                    if (file_name_path.Length == 0)
                    {
                        o_error = @"Website.UpdateWebsite " + o_error;
                        return false;
                    }

                    _AppendHeader(file_name_path);

                    // This year
                    JazzXml.SetCurrentSeasonDocument(this_year_season_doc);

                    _AppendSeason(file_name_path, false);

                    i_textbox_message.Text = @"Saison Daten für dieses Jahr zum Javacscript zugefügt (1)";
                    i_textbox_message.Refresh();

                    i_progress_bar.PerformStep(); // 1

                    _AppendConcerts(file_name_path, false);

                    // Next year
                    JazzXml.SetCurrentSeasonDocument(next_year_season_doc);

                    _AppendSeason(file_name_path, true);

                    i_textbox_message.Text = @"Saison Daten für nächstes Jahr zum Javacscript zugefügt (2)";
                    i_textbox_message.Refresh();

                    i_progress_bar.PerformStep(); // 2

                    _AppendConcerts(file_name_path, true);

                    _AppendApplicationData(file_name_path);

                    i_textbox_message.Text = @"Applikationsdaten zum Javacscript zugefügt (3)";
                    i_textbox_message.Refresh();

                    i_progress_bar.PerformStep(); // 3

                    _AppendMembers(file_name_path);

                    i_progress_bar.PerformStep(); // 4

                    i_textbox_message.Text = @"Javascript wird zum Server hinaufgeladen (4)";
                    i_textbox_message.Refresh();

                    bool b_append_file = FileUtil.AppendFile(file_name_path,
                        JazzAppAdminSettings.Default.FileHtmTemplateJscriptFunctions, 
                        JazzAppAdminSettings.Default.DirHtmTemplates, Main.m_exe_directory, out o_error);

                    if (!b_append_file)
                    {
                        o_error = @"Website.UpdateWebsite Append: " + o_error;
                        return false;
                    }

                    bool b_upload = _UploadJscriptFile(file_name_path, out o_error);
                    if (!b_append_file)
                    {
                        o_error = @"Website.UpdateWebsite Upload: " + o_error;
                        return false;
                    }

                    i_progress_bar.PerformStep(); // 6

                    Main.CheckoutButNoWebsiteUpdate = false;

                    return true;
                } // UpdateWebsite
        No longer used */

        /// <summary>Create and upload poster-newsletter images.
        /// <para>Call of UploadPhotosForWebsiteApp</para>
        /// </summary>
        /// <param name="i_progress_bar">Progress bar</param>
        /// <param name="i_textbox_message">Text box for messages</param>
        /// <param name="o_error">Error description</param>
        public static bool UpdatePosterNewsletter(ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            if (null == i_progress_bar)
            {
                o_error = @"Website.UpdatePosterNewsletter Programming error i_progress_bar = null";
            }

            if (null == i_textbox_message)
            {
                o_error = @"Website.UpdatePosterNewsletter Programming error i_textbox_message = null";
            }

            i_progress_bar.PerformStep(); // 1

            i_textbox_message.Text = @"PlakatNewsletter Bilder werden hochgeladen (1)";
            i_textbox_message.Refresh();

            if (!UploadPostersForWebsiteApp(i_progress_bar, i_textbox_message, out o_error))
            {
                o_error = @"Website.UpdateWebsite UploadPostersForWebsiteApp failed " + o_error;
                return false;
            }

            i_progress_bar.PerformStep(); // 14


            return true;

        } // UpdatePosterNewsletter

        #endregion // Main functions

        #region Load current XML

        /// <summary>Load of current XML files JazzApplication.xml, JazzProgramm_20XX_20YY.xml and JazzDokumente_20XX_20YY.xml
        /// <para>Other users may have changed data, i.e. checked out and saved.</para>
        /// <para>It is not really necessary to reload for all seasons, but for simplicity it is so implemented</para>
        /// <para></para>
        /// <para>Website and Intranet functions will set the active doc (to this or next year) but is also made here</para>
        /// <para>for the case that it has not been done at all, i.e. the Website dialog was opened directly by the user</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public static bool LoadCurrentXmlForWebsiteAndIntranet(out string o_error)
        {
            o_error = @"";

            JazzXml.SetFtpConnectionData(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword, Main.ExeDirectory);

            JazzXml.InitApplicationAndCurrentSeasonXml();
            JazzXml.InitXmlAllSeasons();

            DocAllWebsite = new JazzDocAll();

            DocAllWebsite.DebugFlag = false;

            if (!DocAllWebsite.SetActiveSeasonToThisSeason(out o_error))
            {
                o_error = @"Website.ReloadXml DocAllWebsite.SetActiveSeasonToThisSeason failed " + o_error;
                return false;
            }

            Intranet.DocAllIntranet = new JazzDocAll();

            Intranet.DocAllIntranet.DebugFlag = false;

            if (!Intranet.DocAllIntranet.SetActiveSeasonToThisSeason(out o_error))
            {
                o_error = @"Website.ReloadXml Intranet.DocAllFlyer.SetActiveSeasonToThisSeason failed " + o_error;
                return false;
            }

            Intranet.DocAllIntranet.DebugWriteState(@"DebugDocAllIntranetStateAfterInit.txt");

            return true;

        } // LoadCurrentXmlForWebsiteAndIntranet


        #endregion // Load current XML

        #region Create JavaScript file with data and functions for the homepage HTML files

/* No longer used 
        /// <summary>Upload of the java script file to the server</summary>
        private static bool _UploadJscriptFile(string i_file_name_path, out string o_error)
        {
            o_error = @"";

            UpLoad htpp_upload = new UpLoad();

            string file_name = JazzAppAdminSettings.Default.FileJscriptFunctions;
            string directory_url = @"www\" + JazzAppAdminSettings.Default.DirJscripts + @"\";
            string file_server_url = directory_url + file_name;

            bool to_www = true;
            if (!htpp_upload.OneFile(to_www, file_server_url, i_file_name_path, out o_error))
            {
                o_error = "Website._UploadJscriptFile Upload.OneFile failed: " + o_error;
                return false;
            }

            return true;
        } // _UploadJscriptFile
*/

        /// <summary>Append header to the java script file</summary>
        private static void _AppendHeader(string i_file_name_path)
        {
            FileUtil.AppendLine(i_file_name_path, @"");
            FileUtil.AppendLine(i_file_name_path, @"// This file contains data and functions in java script format");
            FileUtil.AppendLine(i_file_name_path, @"// There are htm files on the website that retrieve and the display the data");
            FileUtil.AppendLine(i_file_name_path, @"// The functions are utility functions for the data");
            FileUtil.AppendLine(i_file_name_path, @"");
            FileUtil.AppendLine(i_file_name_path, @"// This file is created by the application JAZZ live AARAU Admin");
            FileUtil.AppendLine(i_file_name_path, @"");
            FileUtil.AppendLine(i_file_name_path, @"");

        } // _AppendHeader

        /// 
        /// <summary>Append season data to the java script file
        /// </summary>
        /// <param name="i_file_name_path">Full file name_</param>
        /// <param name="i_next_season">Flag telling if it is the next season</param>
        private static void _AppendSeason(string i_file_name_path, bool i_next_season)
        {
            string var_name = @"Saison";

            if (i_next_season)
                var_name = var_name + @"_N";

            FileUtil.AppendLine(i_file_name_path, @"");
            FileUtil.AppendLine(i_file_name_path, @"var " + var_name + @" = ");
            FileUtil.AppendLine(i_file_name_path, @"{");
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagSeasonYearAutum() + @" : " + Mod(JazzXml.GetYearAutum()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagSeasonYearSpring() + @" : " + Mod(JazzXml.GetYearSpring()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagSeasonPublishProgram() + @" : " + End(JazzXml.GetPublishProgram()));
            FileUtil.AppendLine(i_file_name_path, @"};");
            FileUtil.AppendLine(i_file_name_path, @"");

        } // _AppendSeason

        /// <summary>Append concerts data to the java script file
        /// </summary>
        /// <param name="i_file_name_path">Full file name_</param>
        /// <param name="i_next_season">Flag telling if it is the next season</param>
        private static void _AppendConcerts(string i_file_name_path, bool i_next_season)
        {
            int n_number_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

            for (int i_concert = 1; i_concert <= n_number_concerts; i_concert++)
            {
                _AppendConcert(i_file_name_path, i_concert, i_next_season);

                _AppendMusicians(i_file_name_path, i_concert, i_next_season);
            }            

        } // _AppendConcerts

        /// <summary>Append concert data to the java script file
        /// </summary>
        /// <param name="i_file_name_path">Full file name_</param>
        /// <param name="i_next_season">Flag telling if it is the next season</param>
        private static void _AppendConcert(string i_file_name_path, int i_concert, bool i_next_season)
        {
            if (i_concert <= 0 || i_concert > 99)
                return;

            string var_name = @"Concert_";

            if (i_next_season)
                var_name = var_name + @"N_";

            if (i_concert < 10)
                var_name = var_name + @"0" + i_concert.ToString();
            else
                var_name = var_name + i_concert.ToString();


            FileUtil.AppendLine(i_file_name_path, @"");
            FileUtil.AppendLine(i_file_name_path, @"var " + var_name + @" = ");
            FileUtil.AppendLine(i_file_name_path, @"{");
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertDayName() + @" : " + Mod(JazzXml.GetDayName(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertDay() + @" : " + Mod(JazzXml.GetDay(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertMonth() + @" : " + Mod(JazzXml.GetMonth(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertYear() + @" : " + Mod(JazzXml.GetYear(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertTimeStartHour() + @" : " + Mod(JazzXml.GetStartHour(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertTimeStartMinute() + @" : " + Mod(JazzXml.GetStartMinute(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertTimeEndHour() + @" : " + Mod(JazzXml.GetEndHour(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertTimeEndMinute() + @" : " + Mod(JazzXml.GetEndMinute(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertPlace() + @" : " + Mod(JazzXml.GetPlace(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertStreet() + @" : " + Mod(JazzXml.GetStreet(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertCity() + @" : " + Mod(JazzXml.GetCity(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertBandName() + @" : " + Mod(JazzXml.GetBandName(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertShortText() + @" : " + Mod(JazzXml.GetShortText(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertAdditionalText() + @" : " + Mod(JazzXml.GetAdditionalText(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertPosterBigSize() + @" : " + Mod(JazzXml.GetPosterBigSize(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertPosterMidSize() + @" : " + Mod(JazzXml.GetPosterMidSize(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertPosterSmallSize() + @" : " + Mod(JazzXml.GetPosterSmallSize(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertBandWebsite() + @" : " + Mod(JazzXml.GetBandWebsite(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertSoundSample() + @" : " + Mod(JazzXml.GetSoundSample(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertBandWebsiteQrCode() + @" : " + Mod(JazzXml.GetBandWebsiteQrCode(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertSoundSampleQrCode() + @" : " + Mod(JazzXml.GetSoundSampleQrCode(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertPhotoGalleryOne() + @" : " + Mod(JazzXml.GetPhotoGalleryOne(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertPhotoGalleryTwo() + @" : " + Mod(JazzXml.GetPhotoGalleryTwo(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertPhotoGalleryOneZip() + @" : " + Mod(JazzXml.GetPhotoGalleryOneZip(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertPhotoGalleryTwoZip() + @" : " + Mod(JazzXml.GetPhotoGalleryTwoZip(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertContactPerson() + @" : " + Mod(JazzXml.GetContactPerson(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertContactEmail() + @" : " + Mod(JazzXml.GetContactEmail(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertContactTelephone() + @" : " + Mod(JazzXml.GetContactTelephone(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagConcertContactStreet() + @" : " + Mod(JazzXml.GetContactStreet(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagConcertContactPostCode() + @" : " + Mod(JazzXml.GetContactPostCode(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagConcertContactCity() + @" : " + Mod(JazzXml.GetContactCity(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagConcertLoginPassword() + @" : " + End(JazzXml.GetLoginPassword(i_concert)));
            FileUtil.AppendLine(i_file_name_path, @"};");
            FileUtil.AppendLine(i_file_name_path, @"");

        } // _AppendConcert

        /// <summary>Append application data to the java script file</summary>
        private static void _AppendApplicationData(string i_file_name_path)
        {
            string var_name = @"ApplicationData";

            FileUtil.AppendLine(i_file_name_path, @"");
            FileUtil.AppendLine(i_file_name_path, @"var " + var_name + @" = ");
            FileUtil.AppendLine(i_file_name_path, @"{");
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplAboutUsHeader() + @" : " + Mod(JazzXml.GetAboutUsHeader()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplAboutUsOne() + @" : " + Mod(JazzXml.GetAboutUsOne()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplAboutUsTwo() + @" : " + Mod(JazzXml.GetAboutUsTwo()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplAboutUsThree() + @" : " + Mod(JazzXml.GetAboutUsThree()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplPremisesHeader() + @" : " + Mod(JazzXml.GetPremisesHeader()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplPremises() + @" : " + Mod(JazzXml.GetPremises()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplPremisesStreet() + @" : " + Mod(JazzXml.GetPremisesStreet()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplPremisesCity() + @" : " + Mod(JazzXml.GetPremisesCity()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplPremisesWebsite() + @" : " + Mod(JazzXml.GetPremisesWebsite()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplPremisesTelephone() + @" : " + Mod(JazzXml.GetPremisesTelephone()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplPremisesPhoto() + @" : " + Mod(JazzXml.GetPremisesPhoto()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplPremisesMap() + @" : " + Mod(JazzXml.GetPremisesMap()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplContactsHeader() + @" : " + Mod(JazzXml.GetContactsHeader()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplMailHeader() + @" : " + Mod(JazzXml.GetMailHeader()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplEmailHeader() + @" : " + Mod(JazzXml.GetEmailHeader()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplReservationHeader() + @" : " + Mod(JazzXml.GetReservationHeader()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplNewsletterHeader() + @" : " + Mod(JazzXml.GetNewsletterHeader()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplWebmasterHeader() + @" : " + Mod(JazzXml.GetWebmasterHeader()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplClubName() + @" : " + Mod(JazzXml.GetClubName()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplMailAddress() + @" : " + Mod(JazzXml.GetMailAddress()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplEmailJazzLiveAarau() + @" : " + Mod(JazzXml.GetEmailAddress()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplEmailReservation() + @" : " + Mod(JazzXml.GetEmailReservation()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplReservationSubject() + @" : " + Mod(JazzXml.GetReservationSubject()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplReservationText() + @" : " + Mod(JazzXml.GetReservationText()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplNewsletterSubject() + @" : " + Mod(JazzXml.GetNewsletterSubject()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplNewsletterText() + @" : " + Mod(JazzXml.GetNewsletterText()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagApplTelephoneWebmaster() + @" : " + Mod(JazzXml.GetTelephoneWebmaster()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagApplEmailWebmaster() + @" : " + Mod(JazzXml.GetEmailWebmaster()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagApplContactConcertMemberNumber() + @" : " + Mod(JazzXml.GetContactConcertMemberNumber()));

            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagApplContactConcertTelephone() + @" : " + Mod(JazzXml.GetContactConcertTelephone()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagApplContactConcertEmail() + @" : " + Mod(JazzXml.GetContactConcertEmail()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagApplUnloadStreet() + @" : " + Mod(JazzXml.GetUnloadStreet()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagApplUnloadCity() + @" : " + Mod(JazzXml.GetUnloadCity()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagApplParkingOneParkingOne() + @" : " + Mod(JazzXml.GetParkingOne()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagApplParkingTwo() + @" : " + Mod(JazzXml.GetParkingTwo()));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagPublishSeasonStartYear() + @" : " + End(JazzXml.GetPublishSeasonStartYear()));
            FileUtil.AppendLine(i_file_name_path, @"};");
            FileUtil.AppendLine(i_file_name_path, @"");

        } // _AppendApplicationData


        /// <summary>Append musicians</summary>
        private static void _AppendMusicians(string i_file_name_path, int i_concert, bool i_next_season)
        {
            if (i_concert <= 0 || i_concert > 99)
                return;

            int n_number_musicians = JazzXml.GetNumberMusicians(i_concert);

            for (int i_musician=1; i_musician<=n_number_musicians; i_musician++)
            {
                _AppendMusician(i_file_name_path, i_concert, i_musician, i_next_season);
            }

        } // _AppendMusicians

        /// <summary>Append musician data to the java script file</summary>
        private static void _AppendMusician(string i_file_name_path, int i_concert, int i_musician, bool i_next_season)
        {
            if (i_concert <= 0 || i_concert > 99)
                return;

            if (i_musician <= 0 || i_musician > 99)
                return;

            string var_name = @"Musician_";

            if (i_next_season)
                var_name = var_name + @"N_";

            if (i_concert < 10)
                var_name = var_name + @"0" + i_concert.ToString() + @"_";
            else
                var_name = var_name + i_concert.ToString() + @"_";

            if (i_musician < 10)
                var_name = var_name + @"0" + i_musician.ToString();
            else
                var_name = var_name + i_musician.ToString();

            string array_name = @"musicians_";

            if (i_next_season)
                array_name = array_name + @"N_";

            if (i_concert < 10)
                array_name = array_name + @"0" + i_concert.ToString();
            else
                array_name = array_name + i_concert.ToString();

            if (1 == i_musician)
            {
                FileUtil.AppendLine(i_file_name_path, @"");
                FileUtil.AppendLine(i_file_name_path, @"var " + array_name + @" = new Array();");
                FileUtil.AppendLine(i_file_name_path, @"");
                FileUtil.AppendLine(i_file_name_path, @"");
            }

            FileUtil.AppendLine(i_file_name_path, @"");
            FileUtil.AppendLine(i_file_name_path, @"var " + var_name + @" = ");
            FileUtil.AppendLine(i_file_name_path, @"{");
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMusicianName() + @" : " + Mod(JazzXml.GetMusicianName(i_concert, i_musician)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMusicianInstrument() + @" : " + Mod(JazzXml.GetMusicianInstrument(i_concert, i_musician)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMusicianText() + @" : " + Mod(JazzXml.GetMusicianText(i_concert, i_musician)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagMusicianBirthYear() + @" : " + Mod(JazzXml.GetMusicianBirthYearStr(i_concert, i_musician)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMusicianGender() + @" : " + End(JazzXml.GetMusicianGenderStr(i_concert, i_musician)));
            FileUtil.AppendLine(i_file_name_path, @"};");

            FileUtil.AppendLine(i_file_name_path, array_name + @".push(" + var_name + @");");
            FileUtil.AppendLine(i_file_name_path, @"");

        } // _AppendMusician

        /// <summary>Append members</summary>
        private static void _AppendMembers(string i_file_name_path)
        {
            int n_number_members = JazzXml.GetNumberOfMembers();

            for (int i_member = 1; i_member <= n_number_members; i_member++)
            {
                _AppendMember(i_file_name_path, i_member);
            }

        } // _AppendMembers


        /// <summary>Append member data to the java script file</summary>
        private static void _AppendMember(string i_file_name_path, int i_member)
        {
            if (i_member <= 0 || i_member > 99)
                return;

            string var_name = @"Member_";

            if (i_member < 10)
                var_name = var_name + @"0" + i_member.ToString();
            else
                var_name = var_name + i_member.ToString();

            string array_name = @"members";

            if (1 == i_member)
            {
                FileUtil.AppendLine(i_file_name_path, @"");
                FileUtil.AppendLine(i_file_name_path, @"var " + array_name + @" = new Array();");
                FileUtil.AppendLine(i_file_name_path, @"");
                FileUtil.AppendLine(i_file_name_path, @"");
            }

            FileUtil.AppendLine(i_file_name_path, @"");
            FileUtil.AppendLine(i_file_name_path, @"var " + var_name + @" = ");
            FileUtil.AppendLine(i_file_name_path, @"{");
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberName() + @" : " + Mod(JazzXml.GetMemberName(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberFamilyName() + @" : " + Mod(JazzXml.GetMemberFamilyName(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberEmailAddress() + @" : " + Mod(JazzXml.GetMemberEmail(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagMemberEmailPrivate() + @" : " + Mod(JazzXml.GetMemberEmailPrivate(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagMemberTelephone() + @" : " + Mod(JazzXml.GetMemberTelephone(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                 JazzXml.GetTagMemberTelephoneFix() + @" : " + Mod(JazzXml.GetMemberTelephoneFix(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberStreet() + @" : " + Mod(JazzXml.GetMemberStreet(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberCity() + @" : " + Mod(JazzXml.GetMemberCity(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberPostCode() + @" : " + Mod(JazzXml.GetMemberPostCode(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberPhotoMidSize() + @" : " + Mod(JazzXml.GetMemberPhotoMidSize(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberPhotoSmallSize() + @" : " + Mod(JazzXml.GetMemberPhotoSmallSize(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberTasks() + @" : " + Mod(JazzXml.GetMemberTasks(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberTasksShort() + @" : " + Mod(JazzXml.GetMemberTasksShort(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberWhy() + @" : " + Mod(JazzXml.GetMemberWhy(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberStartYear() + @" : " + Mod(JazzXml.GetMemberStartYear(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberEndYear() + @" : " + Mod(JazzXml.GetMemberEndYear(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberPassword() + @" : " + Mod(JazzXml.GetMemberPassword(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                JazzXml.GetTagMemberVorstand() + @" : " + Mod(JazzXml.GetMemberVorstandFlag(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"    " +
                "Nummer" + @" : " + End(JazzXml.GetMemberNumberString(i_member)));
            // Number not OK JazzXml.GetTagMemberNumber() + @" : " + End(JazzXml.GetMemberNumberString(i_member)));
            FileUtil.AppendLine(i_file_name_path, @"};");

            FileUtil.AppendLine(i_file_name_path, array_name + @".push(" + var_name + @");");
            FileUtil.AppendLine(i_file_name_path, @"");

        } // _AppendMember

        #endregion // Create JavaScript file with data and functions for the homepage HTML files

        #region String utility functions

        /// <summary>Remove a not defined value, add quotes and comma</summary>
        static private string Mod(string i_xml_value)
        {
            string ret_str = "\"\",";

            if (!JazzXml.XmlNodeValueIsSet(i_xml_value))
                return ret_str;

            if (i_xml_value.Equals("TRUE"))
                return "true,";

            if (i_xml_value.Equals("FALSE"))
                return "false,";

            ret_str = "\"" + ModifyToHtmlHomepageText(i_xml_value) + "\",";

            return ret_str;

        } // Mod

        /// <summary>Remove a not defined value, add quotes and comma</summary>
        static private string End(string i_xml_value)
        {
            string ret_str = "\"\"";

            if (!JazzXml.XmlNodeValueIsSet(i_xml_value))
                return ret_str;

            if (i_xml_value.Equals("TRUE"))
                return "true";

            if (i_xml_value.Equals("FALSE"))
                return "false";

            ret_str = "\"" + ModifyToHtmlHomepageText(i_xml_value) + "\"";

            return ret_str;

        } // End

        /// <summary>Returns a string that has been modified for HTML home pages like for instance JazzProgrammNaechsteSaison.htm
        /// <para>Some characters are escaped to e.g. &amp; and &quot; and new lines <br> are added</para>
        /// <para>But not < and > because <i> and <b> in the string not will change to italic and bold</para>
        /// <para>It is assumed that the input string not is XML escaped</para>
        /// </summary>
        static public string ModifyToHtmlHomepageText(string i_xml_value)
        {
            string ret_str = i_xml_value;

            if (ret_str.Length == 0)
                return ret_str;

            ret_str = AdminUtils.RemoveJazzLiveAarauUrl(ret_str);
            if (!JazzXml.XmlNodeValueIsSet(ret_str) || ret_str.Length == 0)
                return "";

            // Before there are & that this function added
            string amp_str = "&";
            string amp_html = "&amp;";
            ret_str = ret_str.Replace(amp_str, amp_html);

            /*
             string lt_str = "<";
             string lt_html = "&lt;";
             ret_str = ret_str.Replace(lt_str, lt_html);

             string gt_str = ">";
             string gt_html = "&gt;";
             ret_str = ret_str.Replace(gt_str, gt_html);
             */

            // Add < and > after the above two calls
            string new_line = "\r\n";
            string html_new_line = "<br>";
            ret_str = ret_str.Replace(new_line, html_new_line);

            new_line = "\n";
            ret_str = ret_str.Replace(new_line, html_new_line);

            string qout_str = "\"";
            string qout_html = "&quot;";
            ret_str = ret_str.Replace(qout_str, qout_html);

            qout_str = "„";
            ret_str = ret_str.Replace(qout_str, qout_html);

            qout_str = "“";
            ret_str = ret_str.Replace(qout_str, qout_html);


            string apos_str = "'";
            string apos_html = "&apos;";
            ret_str = ret_str.Replace(apos_str, apos_html);

            return ret_str;

        } // ModifyToHtmlHomepageText

        /// <summary>Replace not allowed characters</summary>
        static public string ReplaceNotAllowedChars(string i_xml_value)
        {
            string ret_str = i_xml_value;

            if (ret_str.Length == 0)
                return ret_str;

            ret_str = AdminUtils.RemoveJazzLiveAarauUrl(ret_str);
            if (!JazzXml.XmlNodeValueIsSet(ret_str) || ret_str.Length == 0) 
                return "";

            // Before there are & that this function added
            string amp_str = "&";
            string amp_html = "&amp;";
            ret_str = ret_str.Replace(amp_str, amp_html);

            string lt_str = "<";
            string lt_html = "&lt;";
            ret_str = ret_str.Replace(lt_str, lt_html);

            string gt_str = ">";
            string gt_html = "&gt;";
            ret_str = ret_str.Replace(gt_str, gt_html);

            // Add < and > after the above two calls
            string new_line = "\r\n";
            string html_new_line = "<br>";
            ret_str = ret_str.Replace(new_line, html_new_line);

            new_line = "\n";
            ret_str = ret_str.Replace(new_line, html_new_line);

            string qout_str = "\"";
            string qout_html = "&quot;";
            ret_str = ret_str.Replace(qout_str, qout_html);

            qout_str = "„";
            ret_str = ret_str.Replace(qout_str, qout_html);

            qout_str = "“";
            ret_str = ret_str.Replace(qout_str, qout_html);


            string apos_str = "'";
            string apos_html = "&apos;";
            ret_str = ret_str.Replace(apos_str, apos_html);

            return ret_str;

        } // ReplaceNotAllowedChars

        #endregion // String utility functions

        #region Upload posters for homepage and app

        /// <summary>Upload posters for homepage and app
        /// <para></para>
        /// <para>TODO It would be necessary to checkout the XML file. Here or should it be done in another function?</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public static bool UploadPostersForWebsiteApp(ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            if (null == DocAllWebsite)
            {
                o_error = @"Website.UploadPostersForWebsiteApp DocAllWebsite = null";
            }

            // TODO Not yet used, but necessary for update of season xml objects 
            XDocument this_year_season_doc = JazzXml.GetDocumentThisYearSeason(out o_error);
            if (null == this_year_season_doc)
            {
                o_error = @"Website.UploadPostersForWebsiteApp Next year XML document is null. " + o_error;
                return false;
            }

            JazzXml.SetCurrentSeasonDocument(this_year_season_doc);

            bool b_set_active_season = false;

            for (int update_season=1; update_season <= 2; update_season++)
            {
                if (1 == update_season)
                {
                    b_set_active_season = DocAllWebsite.SetActiveSeasonToThisSeason(out o_error);
                }
                else
                {
                    b_set_active_season = DocAllWebsite.SetActiveSeasonToNextSeason(out o_error);
                }

                if (!b_set_active_season)
                {
                    o_error = @"Website.UploadPostersForWebsiteApp DocAll.SetActiveSeasonToThisSeason failed " + o_error;

                    return false;
                }

                string document_path = JazzXml.GetDocDocumentsPath();

                string[] server_dirs = null;
                string[] poster_file_names = GetPosterServerFileNames(document_path, out server_dirs, out o_error);
                if (poster_file_names.Length == 0)
                {
                    return true; // Note true
                }

                for (int index_image = 0; index_image < poster_file_names.Length; index_image++)
                {
                    string current_file_name = poster_file_names[index_image];
                    string current_server_directory = server_dirs[index_image];

                    if (JazzXml.XmlNodeValueIsSet(current_file_name))
                    {
                        i_progress_bar.PerformStep(); // 2, 3, ....13
                        i_textbox_message.Text = @"PlakatNewsletter für Plakat " + current_file_name;
                        i_textbox_message.Refresh();
                        if (!CreateUploadPosterNewsletterImages(current_server_directory, current_file_name, out o_error))
                        {
                            o_error = @"Website.UploadPostersForWebsiteApp DocAll.CreateUploadPosterNewsletterImage failed " + o_error;
                            return false;
                        }
                    }

                } // index_image

            }

            // bool b_set_active_season = DocAllWebsite.SetActiveSeasonToThisSeason(out o_error);

            // bool b_set_active_season = DocAllWebsite.SetActiveSeasonToNextSeason(out o_error);

            return true;

        } // UploadPostersForWebsiteApp

        /// <summary>Create and upload poster-newsletter big and small pictures
        /// <para>Name of the created files for instance PlakatNewsletter20190223.jpg and PlakatNewsletter20190223_Klein.jpg</para>
        /// <para>1. Download the poster picture from the server. Call of JazzFtp.Execute.Run for Input.Case.DownloadFile</para>
        /// <para>2. Create the big and small poster-newsletter images. Calls of PhotoEdit.ImagePosterNewsletter</para>
        /// <para>3. Upload the big and small poster-newsletter images. Calls of UploadPosterNewsletterImage</para>
        /// <para>4. Upload the big poster-newsletter image to the newsletter poster directory. Call of UploadPosterNewsletterImage</para>
        /// <para>5. Delete the image files on the temporary directory. Calls of File.Delete</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_server_dir">Server directory for the poster image file</param>
        /// <param name="i_server_file_name">Server file name of the poster image</param>
        /// <param name="o_error">Error description</param>
        public static bool CreateUploadPosterNewsletterImages(string i_server_dir, string i_server_file_name, out string o_error)
        {
            o_error = @"";

            // Directory must be created if not existing
            string exe_path_local_dir = FileUtil.SubDirectory(PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.PhotoTempDir, Main.m_exe_directory) + @"\";

            string file_name = Path.GetFileName(i_server_file_name);

            string path_local_dir = PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.PhotoTempDir;

            JazzFtp.Input ftp_input_download = new JazzFtp.Input(Main.ExeDirectory, Input.Case.DownloadFile);

            ftp_input_download.ServerDirectory = i_server_dir;
            ftp_input_download.ServerFileName = file_name;

            ftp_input_download.LocalDirectory = path_local_dir;
            ftp_input_download.LocalFileName = file_name;

            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input_download);

            if (!ftp_result.Status)
            {
                o_error = @"Website.CreateUploadPosterNewsletterImages JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }

            // Not a very good solution assuming that start part of name is e.g d20181006_Sandy_Patton_Poster.jpg
            string date_str = file_name.Substring(1, 8); 

            string poster_newsletter_big_file_name =  PhotoMain.PosterNewsletterNameStartString + date_str + @".jpg";
            string poster_newsletter_small_file_name = PhotoMain.PosterNewsletterNameStartString + date_str + PhotoMain.PosterNewsletterSmallNameEndString + @".jpg";
            

            string path_original_poster_file_name = exe_path_local_dir + file_name;
            string path_poster_newsletter_big_file_name = exe_path_local_dir + poster_newsletter_big_file_name;
            string path_poster_newsletter_small_file_name = exe_path_local_dir + poster_newsletter_small_file_name;

            bool b_big = true;
            if (!PhotoEdit.ImagePosterNewsletter(b_big, path_original_poster_file_name, path_poster_newsletter_big_file_name, out o_error))
            {
                o_error = @"Website.CreateUploadPosterNewsletterImages PhotoEdit.ImagePosterNewsletter (big) failed " + o_error;
                return false;
            }

            b_big = false;
            if (!PhotoEdit.ImagePosterNewsletter(b_big, path_original_poster_file_name, path_poster_newsletter_small_file_name, out o_error))
            {
                o_error = @"Website.CreateUploadPosterNewsletterImages PhotoEdit.ImagePosterNewsletter (small) failed " + o_error;
                return false;
            }

            if (!UploadPosterNewsletterImage(i_server_dir, poster_newsletter_big_file_name, path_local_dir, out o_error))
            {
                o_error = @"Website.CreateUploadPosterNewsletterImages UploadPosterNewsletterImage (big) failed " + o_error;
                return false;
            }

            if (!UploadPosterNewsletterImage(i_server_dir, poster_newsletter_small_file_name, path_local_dir, out o_error))
            {
                o_error = @"Website.CreateUploadPosterNewsletterImages UploadPosterNewsletterImage (small) failed " + o_error;
                return false;
            }

            string server_newsletter_poster_dir = PhotoMain.ServerNewsletterDir;
            if (!UploadPosterNewsletterImage(server_newsletter_poster_dir, poster_newsletter_big_file_name, path_local_dir, out o_error))
            {
                o_error = @"Website.CreateUploadPosterNewsletterImages UploadPosterNewsletterImage (small) failed " + o_error;
                return false;
            }

            // File is locked File.Delete(path_original_poster_file_name);
            // File is locked File.Delete(path_poster_newsletter_big_file_name);
            // File is locked File.Delete(path_poster_newsletter_small_file_name);

            return true;

        } // CreateUploadPosterNewsletterImages

        /// <summary>Upload a poster-newsletter picture
        /// <para>Name of the input file for instance PlakatNewsletter20190223.jpg or PlakatNewsletter20190223_Klein.jpg</para>
        /// <para>1. Upload the picture to the server. Call of JazzFtp.Execute.Run for Input.Case.UploadFile</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_server_dir">Server directory</param>
        /// <param name="i_file_name">Server and local file name</param>
        /// <param name="i_local_dir">Local directory</param>
        /// <param name="o_error">Error description</param>
        private static bool UploadPosterNewsletterImage(string i_server_dir, string i_file_name, string i_local_dir, out string o_error)
        {
            o_error = @"";

            JazzFtp.Input ftp_input_upload = new JazzFtp.Input(Main.ExeDirectory, Input.Case.UpLoadFile);

            ftp_input_upload.ServerDirectory = i_server_dir;
            ftp_input_upload.ServerFileName = i_file_name;

            ftp_input_upload.LocalDirectory = i_local_dir;
            ftp_input_upload.LocalFileName = i_file_name;

            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input_upload);

            if (!ftp_result.Status)
            {
                o_error = @"Website.UploadPosterNewsletterImage JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }

            return true;

        } // UploadPosterNewsletterImage

        /// <summary>Get poster server file names 
        /// <para>Example server directory: www/PlakateFlyersBilletsVorlagen/d20181006_Sandy_Patton/</para>
        /// <para>1. Get number of concert that have registered documents. Call of JazzXml.GetNumberDocConcerts</para>
        /// <para>2. Loop for the concerts</para>
        /// <para>   2.1 Get all concert documents for the current concert. Call of JazzXml.GetAllConcertDocumentsAsArray</para>
        /// <para>      2.1.1 Get template name. Call of JazzDoc.TemplateName</para>
        /// <para>      2.1.2 If template name equals poster (JazzXml.GetTemplateNamePoster) add file name and directory to output arrays</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_documents_path">Documents path e.g. PlakateFlyersBilletsVorlagen</param>
        /// <param name="o_server_dirs">Array with server directories www/i_documents_path/concert_directory/file name</param>
        /// <param name="o_error">Error description</param>
        /// <returns>Array with file names, e.g. d20181006_Sandy_Patton_Poster.jpg</returns>
        public static string[] GetPosterServerFileNames(string i_documents_path, out string[] o_server_dirs, out string o_error)
        {
            o_error = @"";
            
            string[] ret_poster_file_names = null;
            o_server_dirs = null;

            int n_concerts = JazzXml.GetNumberDocConcerts(out o_error);
            if (n_concerts <= 0)
            {
                o_error = @"Website.GetPosterFileNames JazzXml.GetNumberDocConcerts failed " + o_error;
                return ret_poster_file_names;
            }

            string template_name_poster = JazzXml.GetTemplateNamePoster();

            ArrayList poster_file_names_array = new ArrayList();
            ArrayList server_dirs_array = new ArrayList();

            for (int concert_number=1; concert_number<= n_concerts; concert_number++)
            {
                JazzDoc[] jazz_docs = JazzXml.GetAllConcertDocumentsAsArray(concert_number);
                if (null == jazz_docs || jazz_docs.Length == 0)
                {
                    o_error = @"Website.GetPosterFileNames JazzXml.GetAllConcertDocumentsAsArray failed " + o_error;
                    return ret_poster_file_names;
                }

                for (int index_doc = 0; index_doc < jazz_docs.Length; index_doc++)
                {
                    JazzDoc current_doc = jazz_docs[index_doc];
                    string template_name = current_doc.TemplateName;
                    
                    if (template_name.Equals(template_name_poster))
                    {
                        string poster_file_name = current_doc.FileNameImg;

                        if (poster_file_name.Length > 5)
                        {
                            string file_path = current_doc.FilePath;
                            server_dirs_array.Add(@"www/" + i_documents_path + @"/" + file_path);
                            poster_file_names_array.Add(poster_file_name);
                        }
                    }

                } // index_doc

            } // concert_number

            ret_poster_file_names = (string[])poster_file_names_array.ToArray(typeof(string));
            o_server_dirs = (string[])server_dirs_array.ToArray(typeof(string));

            return ret_poster_file_names;

        } // GetPosterServerFileNames


        #endregion // Upload posters for homepage and app

    } // Website

} // namespace
