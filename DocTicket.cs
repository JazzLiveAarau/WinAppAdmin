using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Document concert ticket (form) variables and functions. THIS CLASS IS NO LONGER USED</summary>
    static public class DocTicket
    {

        #region Set functions

        /// <summary>Band name</summary>
        static private string m_band_name = @"";

        /// <summary>Set band name</summary>
        static public void SetBandName(string i_band_name) { m_band_name = i_band_name; }

        /// <summary>Sets the flag telling if the document can be published</summary>
        static public void SetPublished(bool i_publish) { m_concert_ticket.Published = i_publish; }

        #endregion // Set  functions


        /// <summary>Flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        private static bool m_create_backup_document = true;

        /// <summary>Set flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        public static void SetCreateBackupDocument(bool i_create_backup_document) { m_create_backup_document = i_create_backup_document; }

        /// <summary>Get flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        public static bool GetCreateBackupDocument() { return m_create_backup_document; }

        #region Upload and download local directories

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

        #endregion // Upload and download local directories


        #region Write text functions

        /// <summary>Writes all XML data</summary>
        static public bool WriteConcertDoc(out string o_error)
        {
            o_error = @"";

            if (null == m_concert_ticket)
            {
                o_error = @"DocProgram.WriteFileNameDoc m_season_program is not set";
                return false;
            }

            if (!JazzXml.SetConcertDoc(m_concert_ticket, m_concert_ticket.TemplateName, out o_error))
            {
                return false;
            }

            return true;

        } // WriteConcertDoc

        #endregion Write text functions

        #region Get text functions

        /// <summary>The concert ticket document</summary>
        static private JazzDoc m_concert_ticket = null;

        /// <summary>Set the concert ticket document</summary>
        static public void SetConcertTicket(JazzDoc i_concert_ticket) { m_concert_ticket = i_concert_ticket; }

        /// <summary>The template for the concert ticket document</summary>
        static private JazzDocTemplate m_doc_template = null;

        /// <summary>Set the template for the concert ticket document</summary>
        static public void SetDocumentTemplate(JazzDocTemplate i_doc_template) { m_doc_template = i_doc_template; }

        /// <summary>Get the template for the concert ticket document</summary>
        static public JazzDocTemplate GetDocumentTemplate() { return m_doc_template; }

        /// <summary>Get the band namet</summary>
        static public string GetBandName() { return m_band_name; }

        /// <summary>Returns the template name</summary>
        static public string GetTemplateName() { return AdminUtils.RemoveXmlUndefinedValue(m_concert_ticket.TemplateName); }

        /// <summary>Returns the file path</summary>
        static public string GetFilePath() { return AdminUtils.RemoveXmlUndefinedValue(m_concert_ticket.FilePath); }

        /// <summary>Returns the file name doc</summary>
        static public string GetFileNameDoc() { return AdminUtils.RemoveXmlUndefinedValue(m_concert_ticket.FileNameDoc); }

        /// <summary>Returns the file name pdf</summary>
        static public string GetFileNamePdf() { return AdminUtils.RemoveXmlUndefinedValue(m_concert_ticket.FileNamePdf); }

        /// <summary>Returns the file name txt</summary>
        static public string GetFileNameTxt() { return AdminUtils.RemoveXmlUndefinedValue(m_concert_ticket.FileNameTxt); }

        /// <summary>Returns the file name img</summary>
        static public string GetFileNameImg() { return AdminUtils.RemoveXmlUndefinedValue(m_concert_ticket.FileNameImg); }

        /// <summary>Returns the flag telling if the document can be published</summary>
        static public bool GetPublished() { return m_concert_ticket.Published; }

        /// <summary>Returns the season years</summary>
        static public string GetDocSeasonYears() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetDocSeasonYears()); }

        /// <summary>Returns the path to the documents</summary>
        static public string GetDocDocumentsPath() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetDocDocumentsPath()); }

        /// <summary>Returns the flag telling if the path has been used</summary>
        static public string GetDocDocumentsPathUsed() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetDocDocumentsPathUsed()); }

        /// <summary>Returns the concert title</summary>
        static public string GetTitleConcert() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetTitleConcert()); }

        #endregion // Get text functions

        /// <summary>Returns the combined path for concert documents constructed from the XML file as DocumentsPath/FilePath</summary>
        static public string GetConcertDocumentsPath()
        {
            string path_combine = GetDocDocumentsPath() + @"/" + GetFilePath();

            return path_combine;
        } // GetConcertDocumentsPath

        #region Construct and set file names

        /// <summary>Construct and sets the DOC file name</summary>
        static public bool ConstructAndSetFileNameDoc(out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            string file_name_no_extension = ConstructFileNameNoExtension(out error_message);
            if (file_name_no_extension.Length == 0)
            {
                o_error = error_message;
                return false;
            }

            m_concert_ticket.FileNameDoc = file_name_no_extension + ".docx";

            return true;
        } // ConstructAndSetFileNameDoc


        /// <summary>Construct and sets the PDF file name</summary>
        static public bool ConstructAndSetFileNamePdf(out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            string file_name_no_extension = ConstructFileNameNoExtension(out error_message);
            if (file_name_no_extension.Length == 0)
            {
                o_error = error_message;
                return false;
            }

            m_concert_ticket.FileNamePdf = file_name_no_extension + ".pdf";

            return true;
        } // ConstructAndSetFileNamePdf


        /// <summary>Construct the file name without extension and checks also that m_season_program is set</summary>
        static private string ConstructFileNameNoExtension(out string o_error)
        {
            o_error = @"";

            if (null == m_doc_template)
            {
                o_error = @"DocTicket.ConstructAndSetFileNameTxt m_doc_template is not set";
                return "";
            }

            // Check also this even if it not is used in this function
            if (null == m_concert_ticket)
            {
                o_error = @"DocTicket.ConstructFileNameNoExtension m_season_program is not set";
                return "";
            }

            string template_name = GetTemplateName();

            string documents_path = GetFilePath();
            if (documents_path.Length == 0)
            {
                o_error = @"DocTicket.ConstructAndSetFileNameTxt documents path is not set";
                return "";
            }

            if (!template_name.Contains("PATH_"))
            {
                o_error = @"DocTicket.ConstructAndSetFileNameTxt document path does not contain PATH_";
                return "";
            }

            string path_replaced = template_name.Replace("PATH_", documents_path + "_");


            return path_replaced;

        } // ConstructFileNameNoExtension

        #endregion // Construct and set file names

        #region Delete files

        /// <summary>Delete the DOC file</summary>
        static public bool DeleteFileNameDoc(out string o_error)
        {
            o_error = @"";

            if (null == m_concert_ticket)
            {
                o_error = @"DocTicket.DeleteFileNameDoc m_season_program is not set";
                return false;
            }

            m_concert_ticket.FileNameDoc = @"";

            return true;

        } // DeleteFileNameDoc

        /// <summary>Delete the PDF file</summary>
        static public bool DeleteFileNamePdf(out string o_error)
        {
            o_error = @"";

            if (null == m_concert_ticket)
            {
                o_error = @"DocTicket.DeleteFileNameDoc m_season_program is not set";
                return false;
            }

            m_concert_ticket.FileNamePdf = @"";

            return true;

        } // DeleteFileNamePdf


        #endregion // Delete files

    } // DocTicket

} // namespace
