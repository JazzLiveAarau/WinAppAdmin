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
    /// <summary>Documents (DOC) variables and functions</summary>
    static public class DocAdmin
    {
        #region Member variables for the active season document and the active concert document

        /// <summary>Index for the active season document</summary>
        private static int m_index_active_doc = -12345;

        /// <summary>Set index for the active season document</summary>
        public static void SetIndexActiveDoc(int i_index_active_doc) { m_index_active_doc = i_index_active_doc; }

        /// <summary>Get index for the active season document</summary>
        public static int GetIndexActiveDoc() { return m_index_active_doc; }

        #endregion // Member variables for the active season document and the active concert document

        #region Names and paths for the XML files holding document data
       
        /// <summary>Server path to the XML document files</summary>
        public static string m_url_xml_doc_files_folder = "XML";

        /// <summary>Name of the XML documentation template file</summary>
        public static string m_templates_xml_filename = "JazzDokumente.xml";

        /// <summary>Start year for XML document files</summary>
        public static int m_documents_start_year = 2017;
       
        /// <summary>Local directory for documents</summary>
        private static string m_name_dir_documents = @"Dokumente";

        /// <summary>Returns the directory name for documents</summary>
        public static string GetNameDirectoryDocuments() { return m_name_dir_documents; }

        #endregion // Names and paths for the XML files holding document data

        #region Object JazzDocAll

        /// <summary>Object that holds all data for the jazz documents that are defined by XML files</summary>
        private static JazzDocAll m_jazz_doc_all = new JazzDocAll();
        /// <summary>Returns the object that holds all data for the jazz documents that are defined by XML files</summary>
        public static JazzDocAll DocAll { get { return m_jazz_doc_all; } }

        #endregion // Object JazzDocAll

        #region Set and get upload and download local directory names

        /// <summary>Default directory for upload of files</summary>
        private static string m_directory_upload = Main.ExeDirectory + "\\" + DocAdmin.GetNameDirectoryDocuments();

        /// <summary>Set default directory for upload of files</summary>
        public static void SetDirectoryUpload(string i_directory_upload) { m_directory_upload = i_directory_upload; }

        /// <summary>Get default directory for upload of files</summary>
        public static string GetDirectoryUpload() { return m_directory_upload; }

        /// <summary>Default directory for upload of files</summary>
        private static string m_directory_download = Main.ExeDirectory + "\\" + DocAdmin.GetNameDirectoryDocuments();

        /// <summary>Set default directory for download of files</summary>
        public static void SetDirectoryDownload(string i_directory_download) { m_directory_download = i_directory_download; }

        /// <summary>Get default directory for download of files</summary>
        public static string GetDirectoryDownload() { return m_directory_download; }

        #endregion // Set and get upload and download local directory names

        #region HTM (web) files

        /// <summary>Initialise HTM files for upload and download</summary>
        static public bool InitHtmFiles(out string o_error)
        {
            if (!HtmFiles.Init(out o_error))
                return false;

            return true;
        } // InitHtmFiles

        /// <summary>Returns the names of the HTM or JavaScript files that can be uploaded or downloaded</summary>
        static private string[] GetHmlFileNames(out string o_error)
        {
            string[] ret_file_names = null;
            o_error = @"";

            JazzHtml[] jazz_html = HtmFiles.HtmlFiles;
            if (null == jazz_html || jazz_html.Length == 0)
            {
                o_error = @"DocAdmin.GetHmlFileNames HtmFiles.HtmlFiles returns null or has no elements";
            }

            ret_file_names = new string[jazz_html.Length];

            for (int index_htm=0; index_htm< jazz_html.Length; index_htm++)
            {
                ret_file_names[index_htm] = jazz_html[index_htm].FileName;
            }

            return ret_file_names;
        } // GetHmlFileNames

        #endregion // HTM (web) files

        #region Help files

        /// <summary>Initialise help files for upload and download</summary>
        static public bool InitHelpFiles(out string o_error)
        {
            if (!HelpFiles.Init(out o_error))
                return false;

            return true;
        } // InitHelpFiles

        /// <summary>Returns the names of the help files that can be uploaded or downloaded</summary>
        static private string[] GetHelpFileNames(out string o_error)
        {
            string[] ret_file_names = null;
            o_error = @"";

            JazzHelp[] jazz_help = HelpFiles.AllHelpFiles;
            if (null == jazz_help || jazz_help.Length == 0)
            {
                o_error = @"DocAdmin.GetHelpFileNames HelpFiles.AllHelpFiles returns null or has no elements";
            }

            ret_file_names = new string[jazz_help.Length];

            for (int index_htm = 0; index_htm < jazz_help.Length; index_htm++)
            {
                ret_file_names[index_htm] = jazz_help[index_htm].FileName;
            }

            return ret_file_names;
        } // GetHelpFileNames

        #endregion // Help files

        #region Set concert JazzDoc object

        /// <summary>Writes all XML data for a concert JazzDoc object to the active XML document object</summary>
        static public bool WriteConcertDoc(JazzDoc i_doc_data, out string o_error)
        {
            return JazzXml.WriteConcertDoc(i_doc_data, DocAll.ActiveBandName, out o_error);

        } // WriteConcertDoc

        #endregion // Set concert JazzDoc object

        #region Reset and set active XML object

        /// <summary>Reset the current XDocument when the user has quit editing
        /// <para>This corresponds to a restart of the application.</para>
        /// <para>The controls should also be reset by the calling (WindowsForm) function</para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        public static bool ResetCurrentXDocumentAfterQuit(out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            if (!JazzXml.InitDoc(m_url_xml_doc_files_folder, m_templates_xml_filename, m_documents_start_year, out error_message))
            {
                o_error = @"DocAdmin.InitXmlDoc Programming error: " + error_message;
                return false;
            }

            return true;
        } // ResetCurrentXDocumentAfterQuit

        /// <summary>Return index for the latest (youngest) XML document</summary>
        static public int GetIndexLatestDoc()
        {
            XDocument[] objects_all_documents = JazzXml.GetObjectAllDocs();
            if (objects_all_documents == null)
                return -1;

            if (objects_all_documents.Length == 0)
                return -2;

            return objects_all_documents.Length - 1;
        } // GetIndexLatestDoc

        /// <summary>Set the active XML XDocument
        /// <para>The arrays JazzXml.GetObjectAllDocs, JazzXml.GetFileNamesAllDocs and JazzXml.GetSeasonNamesAllDocs correspond to each other</para>
        /// <para>The input index is normally the index for JazzXml.GetSeasonNamesAllDocs (that the user has selected)</para>
        /// <para>This function calls JazzXml.SetObjectActiveDoc and JazzXml.SetFileNameActiveObject</para>
        /// </summary>
        /// <param name="i_index_xdocument">Index JazzXml.GetObjectAllDocs</param>
        /// <param name="o_error">Error message.</param>
        static public bool SetActiveXmlDocAndFileName(int i_index_xdocument, out string o_error)
        {
            o_error = @"";

            XDocument[] objects_all_documents = JazzXml.GetObjectAllDocs();

            string[] xml_file_names = JazzXml.GetFileNamesAllDocs();

            string[] season_names = JazzXml.GetSeasonNamesAllDocs();

            if (objects_all_documents == null || xml_file_names == null || objects_all_documents == null)
            {
                o_error = @"DocAdmin.SetActiveXmlDocAndFileName Programming error: Array or arrays null";
                return false;
            }

            if (objects_all_documents.Length != xml_file_names.Length || objects_all_documents.Length != season_names.Length)
            {
                o_error = @"DocAdmin.SetActiveXmlDocAndFileName Programming error: Array lengths not equal";
                return false;
            }

            if (i_index_xdocument > objects_all_documents.Length || i_index_xdocument < 0)
            {
                o_error = @"DocAdmin.SetActiveXmlDocAndFileName Programming error: Input index= " + i_index_xdocument.ToString();
                return false;
            }

            JazzXml.SetObjectActiveDoc(objects_all_documents[i_index_xdocument]);

            JazzXml.SetFileNameActiveObject(xml_file_names[i_index_xdocument]);

            return true;

        } // SetActiveXmlDocAndFileName

        #endregion // Reset and set active XML object

        #region Upload

        /// <summary>Uploads the edited XML file to the server
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static public bool UploadEditedXmlToServer(out string o_error)
        {
            o_error = @"";

            string server_file_url = DocAll.ActiveSeasonFileName;
            XDocument edited_doc = DocAll.ActiveSeasonXmlObject;

            if (!AdminUtils.UploadXmlToServer(server_file_url, edited_doc, out o_error))
            {
                return false;
            }

            return true;
        } // UploadEditedXmlToServer

        #endregion // Upload

        #region Set comboxes

        /// <summary>Set combobox document seasons</summary>
        public static void SetComboBoxDocumentSeasons(ComboBox i_combo_box)
        {
            string[] season_names = DocAll.SeasonNames;
            if (null == season_names)
                return;
            if (0 == season_names.Length)
                return;

            i_combo_box.Items.Clear();

            bool next_season_xml_exists_already = JazzXml.ExistsXmlObjectForNextSeason();

            if (!next_season_xml_exists_already)
            {
                i_combo_box.Items.Add(AdminUtils.GetAddSeasonString());
            }
            
            for (int i_season = season_names.Length - 1; i_season >= 0; i_season--)
            {
                i_combo_box.Items.Add(season_names[i_season]);
            }

            i_combo_box.Text = DocAll.ActiveSeasonName;

        } // SetComboBoxDocumentSeasons

        /// <summary>Set combobox concerts</summary>
        public static void SetComboBoxConcerts(ComboBox i_combo_box_concerts)
        {
            string[] band_names = DocAll.BandNames;
            if (band_names == null || band_names.Length == 0)
                return;

            i_combo_box_concerts.Items.Clear();

            for (int index_band = 0; index_band < band_names.Length; index_band++)
            {
                i_combo_box_concerts.Items.Add(band_names[index_band]);
            }

            i_combo_box_concerts.Text = DocAll.ActiveBandName;

        } // SetComboBoxConcerts

        /// <summary>Set combobox season documents</summary>
        public static void SetComboBoxSeasonDocuments(ComboBox i_combo_box_season_documents)
        {
            string error_message = @"";

            int n_season_documents = DocAll.AllSeasonDocuments.Length;
            if (n_season_documents <= 0)
                return;

            i_combo_box_season_documents.Items.Clear();

            string selection_prompt = DocAdminString.PromptSeasonDocument;

            i_combo_box_season_documents.Items.Add(selection_prompt);

            for (int index_season_document = 0; index_season_document < n_season_documents; index_season_document++)
            {
                JazzDoc season_document = DocAll.AllSeasonDocuments[index_season_document];
                string template_name = season_document.TemplateName;
                JazzDocTemplate season_document_template = DocAll.GetDocumentTemplate(template_name, out error_message);

                if (null == i_combo_box_season_documents)
                {
                    i_combo_box_season_documents.Text = error_message;
                    return;
                }

                string template_description = season_document_template.TemplateDescription;

                i_combo_box_season_documents.Items.Add(template_description);

            }

            i_combo_box_season_documents.Text = selection_prompt;

        } // SetComboBoxSeasonDocuments

        /// <summary>Set combobox season documents</summary>
        public static void SetComboBoxConcertDocuments(ComboBox i_combo_box_concert_documents)
        {
            JazzDoc[] all_concert_documents = DocAll.AllConcertDocuments;
            int n_concert_documents = all_concert_documents.Length; ;
            if (n_concert_documents <= 0)
                return;

            string error_message = @"";

            i_combo_box_concert_documents.Items.Clear();

            string selection_prompt = DocAdminString.PromptConcertDocument;

            i_combo_box_concert_documents.Items.Add(selection_prompt);

            for (int index_concert_document = 0; index_concert_document < n_concert_documents; index_concert_document++)
            {
                JazzDoc concert_document = all_concert_documents[index_concert_document];
                string template_name = concert_document.TemplateName;
                JazzDocTemplate concert_document_template = DocAll.GetDocumentTemplate(template_name, out error_message);

                if (null == concert_document_template)
                {
                    i_combo_box_concert_documents.Text = error_message;
                    return;
                }

                string template_description = concert_document_template.TemplateDescription;

                i_combo_box_concert_documents.Items.Add(template_description);

            }

            i_combo_box_concert_documents.Text = selection_prompt;

        } // SetComboBoxConcertDocuments

        /// <summary>Set combobox HTM (web) files</summary>
        public static void SetComboBoxHtmFiles(ComboBox i_combo_box_htm_file)
        {
            string error_message = @"";

            string[] html_file_names = GetHmlFileNames(out error_message);
            if (null == html_file_names || html_file_names.Length == 0)
            {
                return;
            }
            int n_html_files = html_file_names.Length;

            i_combo_box_htm_file.Items.Clear();

            string selection_prompt = DocAdminString.PromptHtmlFile;

            i_combo_box_htm_file.Items.Add(selection_prompt);

            for (int index_htm_file_name = 0; index_htm_file_name < n_html_files; index_htm_file_name++)
            {
                string current_name = html_file_names[index_htm_file_name];

                i_combo_box_htm_file.Items.Add(current_name);

            }

            i_combo_box_htm_file.Text = selection_prompt;

        } // SetComboBoxHtmFiles

        /// <summary>Set combobox help files</summary>
        public static void SetComboBoxHelpFiles(ComboBox i_combo_box_help_file)
        {
            string error_message = @"";

            string[] help_file_names = GetHelpFileNames(out error_message);
            if (null == help_file_names || help_file_names.Length == 0)
            {
                return;
            }
            int n_help_files = help_file_names.Length;

            i_combo_box_help_file.Items.Clear();

            string selection_prompt = DocAdminString.PromptHelpFile;

            i_combo_box_help_file.Items.Add(selection_prompt);

            for (int index_help_file_name = 0; index_help_file_name < n_help_files; index_help_file_name++)
            {
                string current_name = help_file_names[index_help_file_name];

                i_combo_box_help_file.Items.Add(current_name);

            }

            i_combo_box_help_file.Text = selection_prompt;

        } // SetComboBoxHelpFiles

        #endregion // Set comboxes

    } // DocAdmin


} // namespace
