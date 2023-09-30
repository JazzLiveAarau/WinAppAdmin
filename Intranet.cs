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
    /// <summary>Variables and functions for update of Intranet
    /// <para>This is an execution class for the WebsiteForm class.</para>
    /// </summary>
    public static class Intranet
    {
        #region Member variables

        /// <summary>Object that holds all data for the jazz documents that are defined by XML files</summary>
        private static JazzDocAll m_jazz_doc_all_intranet = null;
        /// <summary>Returns the object that holds all data for the jazz documents that are defined by XML files</summary>
        public static JazzDocAll DocAllIntranet { get { return m_jazz_doc_all_intranet; } set { m_jazz_doc_all_intranet = value; } }

        #endregion // Member variables

        #region Main function

        /// <summary>Update the Intranet
        /// <para>1. Update season and document HTM files for current season. Call of UpdateIntranetSeasonConcertFiles.</para>
        /// <para>2. Update season and document HTM files for next season. Call of UpdateIntranetSeasonConcertFiles.</para>
        /// <para>3. Update request HTM files. Call of HtmlRequestsListCreateUpload and HtmlSelectedBandsListCreateUpload.</para>
        /// <para>4. Update QR codes HTML files. Calls of HtmlQrCodesListCreateUpload</para>
        /// <para>HTML files will not be created if XDocument documents (JazzDokumente_20XX_20YY.xml) for the next year is missing</para>
        /// <para>A new JazzDokumente_20XX_20YY.xml created by the user. A better solution is perhaps to let Admin create this file automatically. TODO Investigate</para>
        /// </summary>
        /// <param name="i_progress_bar">Progress bar</param>
        /// <param name="i_textbox_message">Text box that shows the progress</param>
        /// <param name="o_error">Error description</param>
        public static bool UpdateIntranet(ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            if (null == DocAllIntranet)
            {
                o_error = @"Intranet.UpdateIntranet DocAllFlyer = null";
            }

            if (null == i_progress_bar)
            {
                o_error = @"Intranet.UpdateIntranet Programming error i_progress_bar = null";
            }

            if (null == i_textbox_message)
            {
                o_error = @"Intranet.UpdateIntranet Programming error i_textbox_message = null";
            }

            string error_message = @"";

            int document_year = GetDocumentsYear(true);
            string publish_season_start_year = JazzXml.GetPublishSeasonStartYear();
            JazzXml.SetPublishSeasonStartYear(document_year.ToString());

            if (!UpdateIntranetSeasonConcertFiles(document_year, i_progress_bar, i_textbox_message, out o_error))
            {

                o_error = @"Intranet.UpdateIntranet UpdateIntranetSeasonConcertFiles(1) failed " + o_error;
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgUpdateInternetConcertPagesThisSeason);

            }

            document_year = GetDocumentsYear(false);
            JazzXml.SetPublishSeasonStartYear(document_year.ToString());

            if (!UpdateIntranetSeasonConcertFiles(document_year, i_progress_bar, i_textbox_message, out o_error))
            {
                o_error = @"Intranet.UpdateIntranet UpdateIntranetSeasonConcertFiles(2) failed " + o_error;
                // MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgUpdateIntranetConcertPagesNextSeason);
                i_textbox_message.Text = JazzAppAdminSettings.Default.ErrMsgUpdateIntranetConcertPagesNextSeason;
                i_textbox_message.Refresh();
            }

            JazzXml.SetPublishSeasonStartYear(publish_season_start_year);

            i_textbox_message.Text = @"Anfrageliste und ausgewählte Bands wird zum Server aufgeladen (7)";
            i_textbox_message.Refresh();

            if (!HtmlRequestsListCreateUpload(out error_message))
            {
                o_error = @"Intranet.UpdateIntranet HtmlRequestsListCreateUpload failed " + error_message;
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgCreateUploadRequestHtmlFile);
            }

            if (!HtmlSelectedBandsListCreateUpload(out error_message))
            {
                if (error_message.Equals(RequestStrings.ErrMsgNoSelectedRequests))
                {
                    // OK, if a selected band list not have been created
                }
                else
                {
                    o_error = @"Intranet.UpdateIntranet HtmlSelectedBandsListCreateUpload failed " + error_message;
                    MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgCreateUploadSelectedBandsHtmlFile);
                }
 
            }
           
            i_progress_bar.PerformStep(); // 7

            int season_start_year = GetDocumentsYear(true);

            if (!HtmlQrCodesListCreateUpload(season_start_year, out  error_message))
            {
                o_error = @"Intranet.UpdateIntranet HtmlQrCodesListCreateUpload (first year) failed " + error_message;

                MessageBox.Show(o_error);
            }

            season_start_year = GetDocumentsYear(false);

            if (!HtmlQrCodesListCreateUpload(season_start_year, out error_message))
            {
                o_error = @"Intranet.UpdateIntranet HtmlQrCodesListCreateUpload (second year) failed " + error_message;
                MessageBox.Show(o_error);
            }

            Main.CheckoutButNoWebsiteUpdate = false;

            return true;

        } // UpdateIntranet

        #endregion // Main function

        #region Update the Intranet season and concert files 

        /// <summary>Update the Intranet season and concert files 
        /// <para>1. Initialize objects needed for the update. Call of InitializeSeason and XmlToHtml.InitXmlToHtml.</para>
        /// <para>2. Set array of active season document objects. Call of SetActiveArrayOfDocAdminSeasonObjects.</para>
        /// <para>3. Create and upload concert document HTM files. Call of HtmlConcertDocumentsCreateUpload.</para>
        /// <para>3. Create and upload season document HTM files. HtmlSeasonDocumentsCreateUpload </para>
        /// <para>4. Create and upload concert web page HTM files. Call of HtmlConcertWebPagesCreateUpload.</para>
        /// </summary>
        /// <param name="i_document_year">The year for which HTML files shall be updated</param>
        /// <param name="i_progress_bar">Progress bar</param>
        /// <param name="i_textbox_message">Text box that shows the progress</param>
        /// <param name="o_error">Error description</param>
        public static bool UpdateIntranetSeasonConcertFiles(int i_document_year, ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";
            

            if (null == i_progress_bar)
            {
                o_error = @"Intranet.UpdateIntranetSeasonConcertFiles Programming error i_progress_bar = null";
            }

            if (null == i_textbox_message)
            {
                o_error = @"Intranet.UpdateIntranetSeasonConcertFiles Programming error i_textbox_message = null";
            }

            XDocument season_document = null;

            if (!InitializeSeason(i_document_year, out season_document, out o_error))
            {
                o_error = @"Intranet.UpdateIntranetSeasonConcertFiles InitializeSeason failed " + o_error;
                return false;
            }

            string error_message = @"";
            if (!XmlToHtml.InitXmlToHtml(season_document, out error_message))
            {
                o_error = @"Intranet.UpdateIntranetSeasonConcertFiles " + error_message;
                return false;
            }

            if (!SetActiveArrayOfDocAdminSeasonObjects(out error_message))
            {
                o_error = @"Intranet.UpdateIntranetSeasonConcertFiles " + error_message;
                return false;
            }

            i_progress_bar.PerformStep(); // 1

            i_textbox_message.Text = @"Konzertdokumente HTML werden zum Server aufgeladen (" + i_document_year.ToString() + @")";
            i_textbox_message.Refresh();

            if (!HtmlConcertDocumentsCreateUpload(out error_message))
            {
                o_error = @"Intranet.UpdateIntranetSeasonConcertFiles " + error_message;
                return false;
            }

            i_progress_bar.PerformStep(); // 3

            i_textbox_message.Text = @"Saisondokumente HTML werden zum Server aufgeladen (" + i_document_year.ToString() + @")";
            i_textbox_message.Refresh();

            if (!HtmlSeasonDocumentsCreateUpload(out error_message))
            {
                o_error = @"Intranet.UpdateIntranetSeasonConcertFiles " + error_message;
                return false;
            }

            i_progress_bar.PerformStep(); // 3

            i_progress_bar.PerformStep(); // 4

            return true;

        } // UpdateIntranet

        #endregion // Update the Intranet season and concert files 

        #region Initialization of XML for season programs (JazzProgramm_20XX_20YY.xml) and documents (JazzDokumente_20XX_20YY.xml)

        /// <summary>Initialize season to this season or to next season 
        /// <para>1. Call of InitializeXml that sets the current season program (JazzProgramm_20XX_20YY.xml)</para>
        /// <para>2. Call of DocAll.SetActiveSeasonToThisSeason or DocAll.SetActiveSeasonToNextSeason that sets the current Document object (JazzDokumente_20XX_20YY.xml)</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_document_year">The year for which HTML files shall be updated</param>
        /// <param name="o_season_document">Season document for this or for next year</param>
        /// <param name="o_b_documents_next_year">Documents (JazzDokumente_20XX_20YY.xml) are defined for the next year</param>
        /// <param name="o_error">Error description</param>
        private static bool InitializeSeason(int i_document_year, out XDocument o_season_document, out string o_error)
        {
            o_error = @"";
            o_season_document = null;
            
            if (!InitializeXml(i_document_year, out o_season_document, out o_error))
            {
                o_error = @"Intranet.InitializeSeason InitializeXml failed " + o_error;
                return false;
            }

            bool b_set_active_season = false;
            string called_function = @"";
            string publish_season_start_year = JazzXml.GetPublishSeasonStartYear(); // For debug

            b_set_active_season = DocAllIntranet.SetActiveSeasonToThisSeason(out o_error);
            called_function = @"DocAllFlyer.SetActiveSeasonToThisSeason i_document_year= " + i_document_year.ToString() + @" publish_season_start_year= " + publish_season_start_year;

            if (!b_set_active_season)
            {
                o_error = @"Intranet.InitializeSeason " + called_function  + @" failed " + o_error;
                return false;
            }

            return true;

        } // InitializeSeason

        /// <summary>Initialize XML for get of data from JazzProgramm_20XX_20YY.xml, i.e. set current season program object 
        /// <para>Please note that XDocument for jazz documents (JazzDokumente_20XX_20YY.xml) not is set.</para>
        /// <para>1. Get season start years for existing season program XML files (JazzProgramm_20XX_20YY.xml). Call of JazzXml.GetSeasonsStartYears</para>
        /// <para>2. Get the XDocument objects for the season program files (JazzProgramm_20XX_20YY.xml). Call of JazzXml.GetSeasonDocuments()</para>
        /// <para>3. Get start year for this (current) season. Call of JazzXml.GetPublishSeasonStartYearInt</para>
        /// <para>4. Set current season to this (current) season or to the next season. Loop for all season XDocument objects</para>
        /// <para>   4.1.1 Set current season for XDocument object. Call of JazzXml.SetDocumentCurrent</para>
        /// <para>   4.1.2 Get start year for the season. Call of JazzXml.GetYearAutum</para>
        /// <para>   4.1.3 If start (autumn) year is equal to this season year (i_current_season=true) or next year (i_current_season=true) return from function</para>
        /// <para>5. Return false if year not is "found"</para>
        /// </summary>
        /// <param name="i_document_year">The year for which HTML files shall be updated</param>
        /// <param name="o_season_document">Season document for this or for next year</param>
        /// <param name="o_error">Error description</param>
        public static bool InitializeXml(int i_document_year, out XDocument o_season_document,  out string o_error)
        {
            o_error = @"";
            o_season_document = null;

            int[] season_start_years = JazzXml.GetSeasonsStartYears();
            if (null == season_start_years)
            {
                o_error = @"Intranet.InitializeXml season_start_years is null";
                return false;
            }

            XDocument[] season_documents = JazzXml.GetSeasonDocuments();
            if (null == season_documents)
            {
                o_error = @"Intranet.InitializeXml season_documents is null";
                return false;
            }

            string year_season = i_document_year.ToString();

            for (int index_season=0; index_season< season_documents.Length; index_season++)
            {
                JazzXml.SetDocumentCurrent(season_documents[index_season]);

                string year_autumn = JazzXml.GetYearAutum();

                if (year_autumn.Equals(year_season))
                {
                    o_season_document = season_documents[index_season];
                    JazzXml.SetCurrentSeasonFileUrl(); // Don't know if this is necessary
                    return true;
                }

            } // index_season

            o_error = @"Intranet.InitializeXml Failed setting season for year_season= " + year_season;
            return false;

        } // InitializeXml

        /// <summary>Returns the year for which HTM files shall be created
        /// <para>Returned year is based on JazzXml.GetPublishSeasonStartYearInt</para>
        /// </summary>
        /// <param name="i_first_season">Flag telling if the returned year shall be for the first year</param>
        public static int GetDocumentsYear(bool i_first_season)
        {
            int ret_year = JazzXml.GetPublishSeasonStartYearInt();
            // For the generation of document HTML files it must be the season before until all documents (economy reports, etc) have been uploaded

            if (ret_year == TimeUtil.YearInt() && TimeUtil.MonthInt() < 10)
            {
                ret_year = ret_year - 1;
            }

            if (!i_first_season)
            {
                ret_year = ret_year + 1;
            }

            return ret_year;

        } // GetDocumentsYear

        #endregion // Initialization of XML for season programs (JazzProgramm_20XX_20YY.xml) and documents (JazzDokumente_20XX_20YY.xml)

        #region Create and upload concert web page html files

        /* QQ20230930
        /// <summary>Main function for create and upload of concert web page html files
        /// <para>1. Get content of template files as strings. Call of GetTemplateFilesConcertWebPagesAsStrings.</para>
        /// <para>2.</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static bool HtmlConcertWebPagesCreateUpload(out string o_error)
        {
            o_error = @"";

            string error_message = @"";

            string template_file_concert_string = @"";
            string template_file_concert_poster_string = @"";

            if (!GetTemplateFilesConcertWebPagesAsStrings(out template_file_concert_string, out template_file_concert_poster_string, out error_message))
            {
                o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                return false;
            }

            for (int concert_number=1; concert_number<=12; concert_number++)
            {
                string current_template_file_concert_string = template_file_concert_string;
                string current_template_file_concert_poster_string = template_file_concert_poster_string;

                if (!HtmlConcertWebPagesReplaceStrings(ref current_template_file_concert_string, ref current_template_file_concert_poster_string, concert_number, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                    return false;
                }

                if (!HtmlConcertWebPagesCreateUpload(current_template_file_concert_string, current_template_file_concert_poster_string, concert_number, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                    return false;
                }

           } // concert_number


            return true;

        } // HtmlConcertWebPagesCreateUpload  
        QQ20230930 */

        #endregion // Create and upload concert web page html files

        #region Create and upload the QR codes html file

        /// <summary>
        /// Creates an HTML file with QR codes for one season and uploads this file to the server (to Intranet->Dokumente)
        /// <para>1. Get the content of the HTML file. Call of SoundSample.QrCodesSoundSampleWebsiteHtmlString</para>
        /// <para>2. Get the start part of the HTML file name. Call of HtmVorlagen.GetDocumentQrCodesHtmFileName</para>
        /// <para>3. Get the name of the local directory for the HTML file. Call of HtmVorlagen.LocalDirHtmlFiles</para>
        /// <para>4. Create the local HTML file. Call of File.WriteAllText</para>
        /// <para>5. Get the server path for the HTML file. Call of HtmVorlagen.GetFullServerDocumentHtmlFileName</para>
        /// <para>6. Upload the HTML file to the server. Call of UpLoad.OneFile</para>
        /// </summary>
        /// <param name="i_season_start_year">Season start year</param>
        /// <param name="o_error">Error message</param>
        /// <returns>false for failure</returns>
        private static bool HtmlQrCodesListCreateUpload(int i_season_start_year, out string o_error)
        {
            o_error = @"";

            string error_msg = @"";

            string html_file_str = SoundSample.QrCodesSoundSampleWebsiteHtmlString(i_season_start_year);

            string local_file_name_no_ext = Path.GetFileNameWithoutExtension(HtmVorlagen.GetDocumentQrCodesHtmFileName());

            string local_file_name = local_file_name_no_ext + @"_" + i_season_start_year.ToString() + @"_" + (i_season_start_year + 1).ToString() + ".htm";

            string local_dir = HtmVorlagen.LocalDirHtmlFiles;

            string local_dir_full_path = FileUtil.SubDirectory(local_dir, Main.ExeDirectory);

            string local_file_with_path = Path.Combine(local_dir_full_path, local_file_name);

            File.WriteAllText(local_file_with_path, html_file_str, Encoding.UTF8);

            string file_server_url = HtmVorlagen.GetFullServerDocumentHtmlFileName(local_file_name);

            UpLoad htpp_upload = new UpLoad();

            bool to_www = true;

            if (!htpp_upload.OneFile(to_www, file_server_url, local_file_with_path, out error_msg))
            {
                o_error = "Intranet.HtmlQrCodesListCreateUpload Upload.OneFile failed: " + error_msg;

                return false;
            }

            return true;

        } // HtmlQrCodesListCreateUpload

        #endregion // Create and upload the QR codes html file

        #region Create and upload the requests HTM list

        /// <summary>Main function for create and upload of the requests HTM list
        /// <para>1. Initialization of requests XML. Call of Request.InitXmlReq.</para>
        /// <para>2. Create the HTM list. Call of Request.CreateHtmlRequestsList</para>
        /// <para>3. Upload the HTM file: Call of UpLoad.OneFile</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static bool HtmlRequestsListCreateUpload(out string o_error)
        {
            o_error = @"";

            if (!Request.InitXmlReq(out o_error))
            {
                o_error = @"Intranet.HtmlRequestsListCreateUpload Request.InitXmlReq failed " + o_error;
                return false;
            }

            bool b_private_notes = false;
            bool b_for_evaluation = true;
            bool b_with_cd_links = true;
            bool b_selected_bands = false;
            bool b_with_info_files = true;
            bool b_with_video_links = true;
            bool b_with_photos = true;
            bool b_sort_date = true;
            bool b_time_stamp_file_name = false;
            string local_file_with_path = @"";
            if (!Request.CreateHtmlRequestsList(b_private_notes, b_for_evaluation, b_with_cd_links, b_selected_bands, b_with_info_files, b_with_video_links, b_with_photos, b_sort_date, b_time_stamp_file_name, out local_file_with_path, out o_error))
            {
                return false;
            }

            UpLoad htpp_upload = new UpLoad();

            string file_name = Path.GetFileName(local_file_with_path);
            string file_server_document_url = HtmVorlagen.GetFullServerDocumentHtmlFileName(file_name);
            bool to_www = true;

            if (!htpp_upload.OneFile(to_www, file_server_document_url, local_file_with_path, out o_error))
            {
                o_error = "Intranet.HtmlRequestsListCreateUpload Upload.OneFile to Dokumente failed: " + o_error;
                return false;
            }

            return true;

        } // HtmlRequestsListCreateUpload  

        /// <summary>Main function for create and upload of the selected bands HTM list
        /// <para>1. Initialization of requests XML. Call of Request.InitXmlReq.</para>
        /// <para>2. Create the HTM list. Call of Request.CreateHtmlRequestsList</para>
        /// <para>3. Upload the HTM file: Call of UpLoad.OneFile</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static bool HtmlSelectedBandsListCreateUpload(out string o_error)
        {
            o_error = @"";

            if (!Request.InitXmlReq(out o_error))
            {
                o_error = @"Intranet.HtmlSelectedBandsListCreateUpload Request.InitXmlReq failed " + o_error;
                return false;
            }

            bool b_private_notes = false;
            bool b_for_evaluation = false;
            bool b_with_cd_links = true;
            bool b_selected_bands = true;
            bool b_with_info_files = true;
            bool b_with_video_links = true;
            bool b_with_photos = true;
            bool b_sort_date = false;
            bool b_time_stamp_file_name = false;
            string local_file_with_path = @"";
            if (!Request.CreateHtmlRequestsList(b_private_notes, b_for_evaluation, b_with_cd_links, b_selected_bands, b_with_info_files, b_with_video_links, b_with_photos, b_sort_date, b_time_stamp_file_name, out local_file_with_path, out o_error))
            {
                return false;
            }

            UpLoad htpp_upload = new UpLoad();

            string file_name = Path.GetFileName(local_file_with_path);
            string file_server_document_url = HtmVorlagen.GetFullServerDocumentHtmlFileName(file_name);
            bool to_www = true;

            if (!htpp_upload.OneFile(to_www, file_server_document_url, local_file_with_path, out o_error))
            {
                o_error = "Intranet.HtmlSelectedBandsListCreateUpload Upload.OneFile to Aktuell failed: " + o_error;
                return false;
            }


            return true;

        } // HtmlRequestsListCreateUpload  

        #endregion // Create and upload the requests HTM list

        #region Create and upload season document html files

        /// <summary>Main function for create and upload of season document html files
        /// <para>1. </para>
        /// <para>2. </para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static bool HtmlSeasonDocumentsCreateUpload(out string o_error)
        {
            o_error = @"";

            string error_message = @"";

            string season_start_template_file_string = @"";
            string season_header_start_template_file_string = @"";
            string season_row_start_template_file_string = @"";

            //QQ20230930 if (!XmlToHtml.GetTemplateFileAsStringForDokumentSaison(out season_start_template_file_string, out o_error))
            //QQ20230930 {
            //QQ20230930 return false;
            //QQ20230930 }

            if (!XmlToHtml.GenerateTemplateFileAsStringForDokumentSaison(out season_start_template_file_string, out o_error))
            {
                return false;
            }

            //QQ20230930 if (!XmlToHtml.GetTemplateFileAsStringForDokumentSaisonHeader(out season_header_start_template_file_string, out o_error))
            //QQ20230930 {
            //QQ20230930 return false;
            //QQ20230930 }

            if (!XmlToHtml.GenerateTemplateFileAsStringForDokumentSaisonHeader(out season_header_start_template_file_string, out o_error))
            {
                return false;
            }

            //QQ20230930 if (!XmlToHtml.GetTemplateFileAsStringForDokumentSaisonRow(out season_row_start_template_file_string, out o_error))
            //QQ20230930 {
            //QQ20230930 return false;
            //QQ20230930 }

            if (!XmlToHtml.GenerateTemplateFileAsStringForDokumentSaisonRow(out season_row_start_template_file_string, out o_error))
            {
                return false;
            }

            string output_template_file_string = season_start_template_file_string;

            if (!XmlToHtml.ReplaceDocumentSeasonYears(ref output_template_file_string, out error_message))
            {
                o_error = @"Intranet.HtmlSeasonDocumentsCreateUpload " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceSeasonHeader(ref output_template_file_string, season_header_start_template_file_string,  out error_message))
            {
                o_error = @"Intranet.HtmlSeasonDocumentsCreateUpload " + error_message;
                return false;
            }

            int number_of_season_docs = DocAllIntranet.AllSeasonDocuments.Length;
            if (number_of_season_docs <= 0)
            {
                o_error = @"Intranet.HtmlSeasonDocumentsCreateUpload " + error_message;
                return false;
            }

            for (int index_season_doc = 0; index_season_doc < number_of_season_docs; index_season_doc++)
            {
                JazzDoc current_season_doc = DocAllIntranet.AllSeasonDocuments[index_season_doc];
                if (null == current_season_doc)
                {
                    o_error = @"Intranet.HtmlSeasonDocumentsCreateUpload " + error_message;
                    return false;
                }

                if (!XmlToHtml.ReplaceSeasonRow(ref output_template_file_string, season_row_start_template_file_string, out error_message))
                {
                    o_error = @"Intranet.HtmlSeasonDocumentsCreateUpload " + error_message;
                    return false;
                }


                string template_name = current_season_doc.TemplateName;

                JazzDocTemplate template_doc = DocAllIntranet.GetDocumentTemplate(template_name, out error_message);
                if (null == template_doc)
                {
                    o_error = @"Intranet.GetTemplateFileAsString " + error_message;
                    return false;
                }

                if (!HtmlSeasonRowReplaceStrings(ref output_template_file_string, current_season_doc, template_doc, out error_message))
                {
                    o_error = @"Intranet.HtmlSeasonDocumentsCreateUpload " + error_message;
                    return false;
                }


            } // index_season_doc

            HtmlSeasonRemoveInsertRow(ref output_template_file_string);

            string local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForSeasonDocuments();

            AddSeasonToFileName(ref local_file_name_with_path);

            if (!XmlToHtml.UploadDocumentHtmlToServer(local_file_name_with_path, output_template_file_string, out error_message))
            {
                o_error = @"Intranet.HtmlSeasonDocumentsCreateUpload " + error_message;
                return false;
            }

            return true;

        } // HtmlSeasonDocumentsCreateUpload  

        /// <summary>Add season years to file name
        /// <para></para>
        /// </summary>
        /// <param name="io_local_file_name_with_path">Local file name</param>
        private static void AddSeasonToFileName(ref string io_local_file_name_with_path)
        {
            string file_path = Path.GetDirectoryName(io_local_file_name_with_path);
            string file_name_no_ext = Path.GetFileNameWithoutExtension(io_local_file_name_with_path);
            string file_ext = Path.GetExtension(io_local_file_name_with_path);

            string season_years = @"_" + JazzXml.GetYearAutum() + @"_" + JazzXml.GetYearSpring();

            io_local_file_name_with_path = file_path + @"\" + file_name_no_ext + season_years + file_ext;

        } // AddSeasonToFileName

        #endregion // Create and upload season document html files

        #region Create and upload of concert document html files

        /// <summary>Main function for create and upload of concert document html files
        /// <para>1. Get number of concert document objects. Call of NumberOfConcertDocs.</para>
        /// <para>2. Loop for all concerts</para>
        /// <para>2.1 Get current JazzDoc object. Call of DocAdmin.GetConcertDocOfActiveXmlObject.</para>
        /// <para>2.2 Loop for all JazzDoc objects.</para>
        /// <para>2.2.1 Get template surface content as a string. Call of GetTemplateFileAsString for the first concert</para>
        /// <para>2.2.2 Replace strings. Call of HtmlConcertDocumentReplaceStrings</para>
        /// <para>2.3 Create the HTM file and upload to the server. Call of HtmlConcertDocumentCreateUpload.</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static bool HtmlConcertDocumentsCreateUpload(out string o_error)
        {
            o_error = @"";

            string error_message = @"";

            int number_of_concert_docs = NumberOfConcertDocs(out error_message);
            if (number_of_concert_docs <= 0)
            {
                o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                return false;
            }

            // For each band/concert there are a number of concert documents (objects) like Billet, Poster, ..., Concert info
            // For each of these object an HTML file shall be created, so the outer loop is over these objects
            for (int index_concert_doc = 0; index_concert_doc < number_of_concert_docs; index_concert_doc++)
            {
                string template_file_string = @"";

                JazzDocTemplate template_doc = null;

                string[] band_names = DocAllIntranet.BandNames;

                int n_concerts = band_names.Length;

                // There are 12 bands/concerts (should not be hardcoded). For each band/concert there is (must be) a concert/band object
                // The inner loop is over the bands/concerts and the band/concert object for the current band/concert is retrieved with GetConcertDocOfActiveXmlObject
                for (int concert_number = 1; concert_number <= n_concerts; concert_number++)
                {
                    // If the outer loop value is Poster then the current_concert_doc should be Concert/Band 1 Poster, Concert/Band 2 Poster, ....
                    JazzDoc current_concert_doc = GetConcertDocOfActiveXmlObject(index_concert_doc, concert_number, out error_message);
                    if (null == current_concert_doc)
                    {
                        o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                        return false;
                    }

                    if (1 == concert_number)
                    {
                        if (!GetTemplateFileAsString(n_concerts, out template_file_string, out template_doc, current_concert_doc, out error_message))
                        {
                            o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                            return false;
                        }
                    }

                    if (!HtmlConcertDocumentReplaceStrings(ref template_file_string, current_concert_doc, template_doc, concert_number, out error_message))
                    {
                        o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                        return false;
                    }

                } // concert_number

                if (!HtmlConcertDocumentCreateUpload(template_file_string, template_doc, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                    return false;
                }

            } // index_concert_doc

            return true;

        } // HtmlConcertDocumentsCreateUpload  


        /// <summary>Returns the concert document for a given index of the active season documents array</summary>
        private static JazzDoc GetConcertDocOfActiveXmlObject(int i_index_doc, int concert_number, out string o_error)
        {
            JazzDoc ret_doc = null;
            o_error = @"";

            string[] band_names = DocAllIntranet.BandNames;
            if (null == band_names)
            {
                o_error = @"Intranet.GetConcertDocOfActiveXmlObject DocAll.BandNames returned null";
                return ret_doc;
            }

            int concert_index = concert_number - 1;
            if (concert_index < 0 || concert_index > band_names.Length)
            {
                o_error = @"Intranet.GetConcertDocOfActiveXmlObject Error concert_index= " + concert_index.ToString();
                return ret_doc;
            }

            DocAllIntranet.ActiveBandName = band_names[concert_index];

            if (!DocAllIntranet.SetAllConcertDocumentsForActiveBandName(out o_error))
            {
                o_error = @"Intranet.GetConcertDocOfActiveXmlObject DocAllFlyer.SetAllConcertDocuments failed " + o_error;
                return ret_doc;
            }

            JazzDoc[] all_concert_documents = DocAllIntranet.AllConcertDocuments;

            if (null == all_concert_documents || all_concert_documents.Length == 0)
            {
                o_error = @"Intranet.GetConcertDocOfActiveXmlObject Programming error: Returned array from JazzXml.GetAllSeasonDocuments is null or has no elements";
                return ret_doc;
            }

            if (i_index_doc < 0 || i_index_doc >= all_concert_documents.Length)
            {
                o_error = @"Intranet.GetConcertDocOfActiveXmlObject Programming error: all_concert_documents.Length= " + all_concert_documents.Length.ToString() + " i_index_doc= " + i_index_doc.ToString();
                return ret_doc;
            }

            ret_doc = all_concert_documents[i_index_doc];

            return ret_doc;

        } // GetConcertDocOfActiveXmlObject

        #endregion // Create and upload of concert document html files

        #region Help functions for the creation and upload of document HTM files

        /// <summary>Set current array of (activ) season documents of DocAdmin
        /// <para>The static DocAdmin object has an array of season documents (JazzDoc) that is used by this class.</para>
        /// <para>The array corresponds to the season that the user has set (TODO Check this)</para>
        /// <para>1. Set this array. Call of DocAdmin.GetSeasonDocOfActiveXmlObject</para>
        /// <para>2. Check that all objects in the array exist. Calls of GetSeasonDocOfActiveXmlObject.</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static bool SetActiveArrayOfDocAdminSeasonObjects(out string o_error)
        {
            o_error = @"";

            string error_message = @"";

            int number_of_season_docs = DocAllIntranet.AllSeasonDocuments.Length;
            if (number_of_season_docs <= 0)
            {
                o_error = @"Intranet.SetActiveArrayOfDocAdminSeasonObjects number_of_season_docs= " + number_of_season_docs.ToString();
                return false;
            }

            for (int index_season_doc = 0; index_season_doc < number_of_season_docs; index_season_doc++)
            {
                //QQ JazzDoc current_season_doc = DocAdmin.GetSeasonDocOfActiveXmlObject(index_season_doc, out error_message);
                JazzDoc current_season_doc = DocAllIntranet.AllSeasonDocuments[index_season_doc];
                if (null == current_season_doc)
                {
                    o_error = @"Intranet.SetActiveArrayOfDocAdminSeasonObjects " + error_message;
                    return false;
                }

            } // index_season_doc

            return true;

        } // SetActiveArrayOfDocAdminSeasonObjects  

        /// <summary>Get the number season documents JazzDoc
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static int NumberOfSeasonDocs(out string o_error)
        {
            o_error = @"";

            int number_of_season_docs = DocAllIntranet.AllSeasonDocuments.Length;
            if (number_of_season_docs <= 0)
            {
                o_error = @"Intranet.NumberOfSeasonDocs number_of_season_docs= " + number_of_season_docs.ToString();
                return number_of_season_docs;
            }

            return number_of_season_docs;
        } // NumberOfSeasonDocs

        /// <summary>Get the number concert documents JazzDoc
        /// <para>The number must be the same for all concerts. Returned number negative if not.</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static int NumberOfConcertDocs(out string o_error)
        {
            o_error = @"";
            int ret_number_of_concert_docs = -1;

            string[] band_names = DocAllIntranet.BandNames;
            if (null == band_names)
            {
                o_error = @"Intranet.NumberOfConcertDocs DocAllFlyer.BandNames returned null";
                return -4;
            }

            for (int concert_number = 1; concert_number <= band_names.Length; concert_number++)
            {
                int concert_index = concert_number - 1;
                if (concert_index < 0 || concert_index > band_names.Length)
                {
                    o_error = @"Intranet.NumberOfConcertDocs Error concert_index= " + concert_index.ToString();
                    return -5;
                }

                DocAllIntranet.ActiveBandName = band_names[concert_index];

                if (!DocAllIntranet.SetAllConcertDocumentsForActiveBandName(out o_error))
                {
                    o_error = @"Intranet.NumberOfConcertDocs DocAllFlyer.SetAllConcertDocuments failed " + o_error;
                    return -6;
                }

                int number_of_concert_docs = DocAllIntranet.AllConcertDocuments.Length;
                if (number_of_concert_docs <= 0)
                {
                    o_error = @"Intranet.NumberOfConcertDocs number_of_concert_docs= " + number_of_concert_docs.ToString();
                    return -2;
                }

                if (1 == concert_number)
                {
                    ret_number_of_concert_docs = number_of_concert_docs;
                }
                else
                {
                    if (ret_number_of_concert_docs != number_of_concert_docs)
                    {
                        o_error = @"Intranet.NumberOfConcertDocs number_of_concert_docs= " + number_of_concert_docs.ToString() + @" != ret_number_of_concert_docs= " + ret_number_of_concert_docs.ToString();
                        return -3;
                    }
                }

            } // concert_number

            return ret_number_of_concert_docs;

        } // NumberOfConcertDocs


        // GetNumberOfSeasonDocsOfActiveXmlObject

        /// <summary>Get template file content as a string for data that shall be displayed in an HTML table
        /// <para>Call of one of the XmlToHtml functions: GetTemplateFileAsStringForDocPdfImg, GetTemplateFileAsStringForDocPdf, GetTemplateFileAsStringForXlsPdf or ...</para>
        /// <para</para>
        /// </summary>
        /// <param name="o_template_file_string">Output file content</param>
        /// <param name="o_template_doc">Output template object corresponding to i_doc</param>
        /// <param name="i_doc">Input concert object</param>
        /// <param name="o_error">Error description</param>
        private static bool GetTemplateFileAsString(int i_n_concerts, out string o_template_file_string, out JazzDocTemplate o_template_doc, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";
            o_template_doc = null;

            if (null == i_doc)
            {
                o_error = @"Intranet.GetTemplateFileAsString Input JazzDoc is null";
                return false;
            }

            string error_message = @"";

            string template_name = i_doc.TemplateName;

            o_template_doc = DocAllIntranet.GetDocumentTemplate(template_name, out error_message);
            if (null == o_template_doc)
            {
                o_error = @"Intranet.GetTemplateFileAsString " + error_message;
                return false;
            }

            string doc_document_dialog = o_template_doc.TemplateDocumentDialog;

            if (doc_document_dialog.Equals("DocPdfImg"))
            {
                //QQ 20230930 if (!XmlToHtml.GetTemplateFileAsStringForDocPdfImg(out o_template_file_string, out error_message))
                //QQ 20230930 {
                //QQ 20230930 o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                //QQ 20230930 return false;
                //QQ 20230930 }

                if (!XmlToHtml.GenerateTemplateFileAsStringForDocPdfImg(i_n_concerts, out o_template_file_string, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                    return false;
                }
            }
            else if (doc_document_dialog.Equals("DocPdf"))
            {
                //QQ 20230930 if (!XmlToHtml.GetTemplateFileAsStringForDocPdf(out o_template_file_string, out error_message))
                //QQ 20230930 {
                //QQ 20230930 o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                //QQ 20230930 return false;
                //QQ 20230930 }

                if (!XmlToHtml.GenerateTemplateFileAsStringForDocPdf(i_n_concerts, out o_template_file_string, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                    return false;
                }
            }
            else if (doc_document_dialog.Equals("XlsPdf"))
            {
                //QQ 20230930 if (!XmlToHtml.GetTemplateFileAsStringForXlsPdf(out o_template_file_string, out error_message))
                //QQ 20230930 {
                //QQ 20230930 o_error = @"Intranet.GetTemplateFileAsStringJazzDoc " + error_message;
                //QQ 20230930 return false;
                //QQ 20230930 }

                if (!XmlToHtml.GenerateTemplateFileAsStringForXlsPdf(i_n_concerts, out o_template_file_string, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentsCreateUpload " + error_message;
                    return false;
                }
            }
            else
            {
                o_error = @"Intranet.GetTemplateFileAsStringJazzDoc Not an implemented TemplateDocumentDialog= " + doc_document_dialog;
                return false;
            }

            return true;

        } // GetTemplateFileAsStringJazzDoc

        /// <summary>Replace strings in the input/output string that will become the content of a document HTM file
        /// <para>1. Call of XmlToHtml.ReplaceBandname</para>
        /// <para>2. Call of XmlToHtml.ReplaceConcertDate</para>
        /// <para>3. Call of XmlToHtml.ReplacePublished</para>
        /// <para>4. Calls of XmlToHtml.ReplacePathFileNameDoc, ReplacePathFileNameXls, ReplacePathFileNamePdf, ReplacePathFileNameTxt, ReplacePathFileNameImg</para>
        /// <para>5. Calls of XmlToHtml.ReplaceDocumentTemplateDescription, ReplaceDocumentDialogTitle, ReplaceDocumentSeasonYears for i_concert_number=1</para>
        /// <para></para>
        /// </summary>
        /// <param name="io_template_file_string">Input/output string</param>
        /// <param name="i_doc">Object with template name, file names (DOC, XLS, PDF, TXT and IMG), publish flag, path, etc</param>
        /// <param name="i_template">Template object corresponding to i_doc</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        private static bool HtmlConcertDocumentReplaceStrings(ref string io_template_file_string, JazzDoc i_doc, JazzDocTemplate i_template, int i_concert_number, out string o_error)
        {
            o_error = @"";

            string error_message = @"";

            if (null == i_doc)
            {
                o_error = @"Intranet.HtmlConcertDocumentReplaceStrings Input JazzDoc is null";
                return false;
            }

            if (null == i_template)
            {
                o_error = @"Intranet.HtmlConcertDocumentReplaceStrings Input JazzDocTemplate is null";
                return false;
            }

            if (i_concert_number <= 0)
            {
                o_error = @"Intranet.HtmlConcertDocumentReplaceStrings Input concert number= " + i_concert_number.ToString() + @" <= 0";
                return false;
            }

            if (!XmlToHtml.ReplaceBandname(ref io_template_file_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertDocumentReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceConcertDate(ref io_template_file_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertDocumentReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplacePublished(ref io_template_file_string, i_concert_number, i_doc, out error_message))
            {
                o_error = @"Intranet.HtmlConcertDocumentCreateUpload " + error_message;
                return false;
            }

            string doc_document_dialog = i_template.TemplateDocumentDialog;

            if (doc_document_dialog.Equals("DocPdfImg") || doc_document_dialog.Equals("DocPdf"))
            {
                if (!XmlToHtml.ReplacePathFileNameDoc(ref io_template_file_string, i_concert_number, i_doc, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentReplaceStrings " + error_message;
                    return false;
                }
            }

            if (doc_document_dialog.Equals("DocPdfImg") || doc_document_dialog.Equals("DocPdf") || doc_document_dialog.Equals("XlsPdf"))
            {
                if (!XmlToHtml.ReplacePathFileNamePdf(ref io_template_file_string, i_concert_number, i_doc, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentReplaceStrings " + error_message;
                    return false;
                }
            }

            if (doc_document_dialog.Equals("DocPdfImg"))
            {
                if (!XmlToHtml.ReplacePathFileNameImg(ref io_template_file_string, i_concert_number, i_doc, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentReplaceStrings " + error_message;
                    return false;
                }
            }

            if (i_concert_number == 1)
            {
                if (!XmlToHtml.ReplaceDocumentTemplateDescription(ref io_template_file_string, i_template, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentReplaceStrings " + error_message;
                    return false;
                }

                if (!XmlToHtml.ReplaceDocumentDialogTitle(ref io_template_file_string, i_template, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentReplaceStrings " + error_message;
                    return false;
                }

                if (!XmlToHtml.ReplaceDocumentSeasonYears(ref io_template_file_string, out error_message))
                {
                    o_error = @"Intranet.HtmlConcertDocumentReplaceStrings " + error_message;
                    return false;
                }

            } // i_concert_number == 1




            return true;

        } // HtmlConcertDocumentReplaceStrings  

        /// <summary>Replace strings in the input/output string for an added season row (document)
        /// <para>1. Call of XmlToHtml.ReplaceDocumentDialogTitle</para>
        /// <para>2. Calls of XmlToHtml.ReplacePathFileNameLinkDoc, ReplacePathFileNameLinkXls, ReplacePathFileNameLinkPdf, ReplacePathFileNameLinkTxt, ReplacePathFileNameLinkImg</para>
        /// <para>3. Call of XmlToHtml.ReplaceSeasonPublish</para>
        /// <para></para>
        /// </summary>
        /// <param name="io_template_file_string">Input/output string</param>
        /// <param name="i_doc">Object with template name, file names (DOC, XLS, PDF, TXT and IMG), publish flag, path, etc</param>
        /// <param name="i_template">Template object corresponding to i_doc</param>
        /// <param name="o_error">Error description</param>
        private static bool HtmlSeasonRowReplaceStrings(ref string io_template_file_string, JazzDoc i_doc, JazzDocTemplate i_template, out string o_error)
        {
            o_error = @"";

            string error_message = @"";

            if (null == i_doc)
            {
                o_error = @"Intranet.HtmlConcertDocumentReplaceStrings Input JazzDoc is null";
                return false;
            }

            if (null == i_template)
            {
                o_error = @"Intranet.HtmlConcertDocumentReplaceStrings Input JazzDocTemplate is null";
                return false;
            }


            if (!XmlToHtml.ReplaceDocumentDialogTitle(ref io_template_file_string, i_template, out error_message))
            {
                o_error = @"Intranet.HtmlSeasonRowReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplacePathFileNameLinkDoc(ref io_template_file_string, i_doc, out error_message))
            {
                o_error = @"Intranet.HtmlSeasonRowReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplacePathFileNameLinkXls(ref io_template_file_string, i_doc, out error_message))
            {
                o_error = @"Intranet.HtmlSeasonRowReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplacePathFileNameLinkPdf(ref io_template_file_string, i_doc, out error_message))
            {
                o_error = @"Intranet.HtmlSeasonRowReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplacePathFileNameLinkTxt(ref io_template_file_string, i_doc, out error_message))
            {
                o_error = @"Intranet.HtmlSeasonRowReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplacePathFileNameLinkImg(ref io_template_file_string, i_doc, out error_message))
            {
                o_error = @"Intranet.HtmlSeasonRowReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceSeasonPublish(ref io_template_file_string, i_doc, out error_message))
            {
                o_error = @"Intranet.HtmlSeasonRowReplaceStrings " + error_message;
                return false;
            }

            return true;

        } // HtmlConcertDocumentReplaceStrings  

        /// <summary>Remove insert row
       /// <para></para>
        /// </summary>
        /// <param name="io_template_file_string">Input/output string</param>
        private static void HtmlSeasonRemoveInsertRow(ref string io_template_file_string)
        {
            XmlToHtml.RemoveInsertRow(ref io_template_file_string);

        } // HtmlSeasonRemoveInsertRow  


        /// <summary>Create the output HTM file and upload the file to the server
        /// <para>Template name from input JazzDocTemplate i_template determines which function will be used to get the local full file name</para>
        /// <para>Available HtmVorlagen functions are GetFullLocalHtmlFileNameForTicket, GetFullLocalHtmlFileNameForPoster, GetFullLocalHtmlFileNameForFlyerFront, etc.</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_template_file_string">Input string that will be the content of the HTM file</param>
        /// <param name="i_template">Template object</param>
        /// <param name="o_error">Error description</param>
        private static bool HtmlConcertDocumentCreateUpload(string i_template_file_string, JazzDocTemplate i_template, out string o_error)
        {
            o_error = @"";

            string error_message = @"";

            if (null == i_template)
            {
                o_error = @"Intranet.HtmlConcertDocumentCreateUpload Input JazzDocTemplate is null";
                return false;
            }

            string local_file_name_with_path = @"";

            if (i_template.TemplateName.Equals(JazzXml.GetTemplateNameConcertTicket()))
            {
                local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForTicket();
            }
            else if (i_template.TemplateName.Equals(JazzXml.GetTemplateNamePoster()))
            {
                local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForPoster();
            }
            else if (i_template.TemplateName.Equals(JazzXml.GetTemplateNameFlyerFront()))
            {
                local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForFlyerFront();
            }
            else if (i_template.TemplateName.Equals(JazzXml.GetTemplateNameFlyerReverse()))
            {
                local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForFlyerReverse();
            }
            else if (i_template.TemplateName.Equals(JazzXml.GetTemplateNameFlyerInfo()))
            {
                local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForFlyerInfo();
            }
            else if (i_template.TemplateName.Equals(JazzXml.GetTemplateNameFlyerPrintshop()))
            {
                local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForFlyerPrintshop();
            }
            else if (i_template.TemplateName.Equals(JazzXml.GetTemplateNameFlyerStart()))
            {
                local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForFlyerStart();
            }
            else if (i_template.TemplateName.Equals(JazzXml.GetTemplateNameContract()))
            {
                local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForContract();
            }
            else if (i_template.TemplateName.Equals(JazzXml.GetTemplateNameConcertInformation()))
            {
                local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForConcertInfo();
            }
            else if (i_template.TemplateName.Equals(JazzXml.GetTemplateNamePosterInternet()))
            {
                local_file_name_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForPosterInternet();
            }
            else
            {
                o_error = @"Intranet.HtmlConcertDocumentCreateUpload Get full file name not yet implemented for template name= " + i_template.TemplateName;
                return false;
            }

            AddSeasonToFileName(ref local_file_name_with_path);

            if (!XmlToHtml.UploadDocumentHtmlToServer(local_file_name_with_path, i_template_file_string, out error_message))
            {
                o_error = @"Intranet.HtmlTicketCreateUpload " + error_message;
                return false;
            }

            return true;

        } // HtmlConcertDocumentCreateUpload  

        #endregion // Help functions for the creation and upload of document HTM files

        #region Template file contents as a strings for concert and concert-poster web pages
        /*QQ20230930
        /// <summary>Get template file contents as a strings for concert and concert-poster web pages
        /// <para>Call of function XmlToHtml.GetTemplateFilesAsStringsForConcertWebPages</para>
        /// <para</para>
        /// </summary>
        /// <param name="o_template_file_string">Output file content</param>
        /// <param name="o_template_doc">Output template object corresponding to i_doc</param>
        /// <param name="i_doc">Input concert object</param>
        /// <param name="o_error">Error description</param>
        private static bool GetTemplateFilesConcertWebPagesAsStrings(out string o_template_file_concert_string, out string o_template_file_concert_poster_string, out string o_error)
        {
            o_error = @"";
            o_template_file_concert_string = @"";
            o_template_file_concert_poster_string = @"";

            string error_message = @"";

            if (!XmlToHtml.GetTemplateFilesAsStringsForConcertWebPages(out o_template_file_concert_string, out o_template_file_concert_poster_string, out error_message))
            {
                o_error = @"Intranet.GetTemplateFilesConcertWebPagesAsString " + error_message;
                return false;
            }

            // GetTemplateFilesAsStringsForConcertWebPage(out string o_template_file_concert_string, out string o_template_file_concert_poster_string, out string o_error)
            return true;

        } // GetTemplateFilesConcertWebPagesAsStrings
        QQ20230930*/
        /*QQ20230930
        /// <summary>Replace strings in the input/output string that will become the content of a document HTM file
        /// <para>1. Call of XmlToHtml.ReplaceBandname</para>
        /// <para>2. Call of XmlToHtml.ReplaceConcertDate</para>
        /// <para>3. Call of XmlToHtml.ReplacePublished</para>
        /// <para>4. Calls of XmlToHtml.ReplacePathFileNameDoc, ReplacePathFileNameXls, ReplacePathFileNamePdf, ReplacePathFileNameTxt, ReplacePathFileNameImg</para>
        /// <para>5. Calls of XmlToHtml.ReplaceDocumentTemplateDescription, ReplaceDocumentDialogTitle, ReplaceDocumentSeasonYears for i_concert_number=1</para>
        /// <para></para>
        /// </summary>
        /// <param name="io_template_file_concert_string">Input/output string concert</param>
        /// <param name="io_template_file_concert_poster_string">Input/output string concert-poster</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool HtmlConcertWebPagesReplaceStrings(ref string io_template_file_concert_string, ref string io_template_file_concert_poster_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            string error_message = @"";

            if (i_concert_number <= 0)
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings Input concert number= " + i_concert_number.ToString() + @" <= 0";
                return false;
            }

            if (!XmlToHtml.ReplaceBandnameLoopIndex(ref io_template_file_concert_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceConcertDateLoopIndex(ref io_template_file_concert_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplacePremisesNameAddress(ref io_template_file_concert_string, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceListMusiciansInstruments(ref io_template_file_concert_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceShortText(ref io_template_file_concert_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceListMusiciansTexts(ref io_template_file_concert_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceLinkBandWebsite(ref io_template_file_concert_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceLinkSoundSample(ref io_template_file_concert_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceLinkSmallPosterNoPath(ref io_template_file_concert_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings " + error_message;
                return false;
            }

            if (!XmlToHtml.ReplaceLinkImgPosterConcert(ref io_template_file_concert_poster_string, i_concert_number, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesReplaceStrings " + error_message;
                return false;
            }


            return true;

        } // HtmlConcertWebPagesReplaceStrings  
        QQ20230930*/
        #endregion // Template file contents as a strings for concert and concert-poster web pages

        #region Create the output concert web pages and upload the two files to the server

        /// <summary>Create the output concert web pages and upload the two files to the server
        /// <para></para>
        /// </summary>
        /// <param name="i_template_file_concert_string">Input string that will be the content of the concert HTM file</param>
        /// <param name="i_template_file_concert_poster_string">Input string that will be the content of the concert-poster HTM file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        private static bool HtmlConcertWebPagesCreateUpload(string i_template_file_concert_string, string i_template_file_concert_poster_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            string error_message = @"";

            string concert_date = XmlToHtml.ConcertDate(i_concert_number);

            string local_file_name_concert_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForConcert(concert_date);

            if (!XmlToHtml.UploadConcertHtmlToServer(local_file_name_concert_with_path, i_template_file_concert_string, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesCreateUpload " + error_message;
                return false;
            }

            string local_file_name_concert_poster_with_path = HtmVorlagen.GetFullLocalHtmlFileNameForConcertPoster(concert_date);

            if (!XmlToHtml.UploadConcertHtmlToServer(local_file_name_concert_poster_with_path, i_template_file_concert_poster_string, out error_message))
            {
                o_error = @"Intranet.HtmlConcertWebPagesCreateUpload " + error_message;
                return false;
            }

            return true;

        } // HtmlConcertWebPagesCreateUpload  

        #endregion // Create the output concert web pages and upload the two files to the server

    } // Intranet

} // namespace
