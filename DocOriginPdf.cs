using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Document variables and execution functions for form DocOriginPdfForm
    /// <para>This class is no longer used !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!</para>
    /// <para>How to add this kind of a document class is described in JAZZ_live_AARAU_Admin_Doc.rtf</para>
    /// </summary>
    public class DocOriginPdf
    {
        #region Backup flag

        /// <summary>Flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        private bool m_create_backup_document = true;

        /// <summary>Set flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        public void SetCreateBackupDocument(bool i_create_backup_document) { m_create_backup_document = i_create_backup_document; }

        /// <summary>Get flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        public bool GetCreateBackupDocument() { return m_create_backup_document; }

        #endregion // Backup flag

        #region Objects holding document data

        /// <summary>Data for the document</summary>
        private JazzDoc m_doc_data = null;

        /// <summary>Set data for the document</summary>
        public void SetDocumentData(JazzDoc i_doc_data) { m_doc_data = i_doc_data; }

        /// <summary>Get data for the document</summary>
        public JazzDoc GetDocumentData() { return m_doc_data; }

        /// <summary>The template for the document</summary>
        private JazzDocTemplate m_doc_template = null;

        /// <summary>Set the template for the document</summary>
        public void SetDocumentTemplate(JazzDocTemplate i_doc_template) { m_doc_template = i_doc_template; }

        /// <summary>Get the template for the document</summary>
        public JazzDocTemplate GetDocumentTemplate() { return m_doc_template; }

        #endregion // Objects holding document data

        #region Dialog texts

        /// <summary>Title for the document</summary>
        private string m_title_document = @"";

        /// <summary>Set title for the document</summary>
        public void SetTitleDocument(string i_title_document) { m_title_document = i_title_document; }

        /// <summary>Get title for the document</summary>
        public string GetTitleDocument() { return m_title_document; }

        /// <summary>Name of the document</summary>
        private string m_label_page_header = @"";

        /// <summary>Set name of the document</summary>
        public void SetLabelPageHeader(string i_label_page_header) { m_label_page_header = i_label_page_header; }

        /// <summary>Get name of the document</summary>
        public string GetLabelPageHeader() { return m_label_page_header; }

        #endregion // Dialog texts

        #region Write text functions

        /// <summary>Writes all XML data for a season document.</summary>
        public bool WriteSeasonDoc(out string o_error)
        {

            return DocAdminUtil.WriteSeasonDoc(m_doc_data, out o_error);

        } // WriteSeasonDoc

        #endregion Write text functions

        #region Set functions

        /// <summary>Sets the flag telling if the document can be published</summary>
        public void SetPublished(bool i_publish) { m_doc_data.Published = i_publish; }

        #endregion // Set functions

        #region Get functions

        /// <summary>Returns the template name</summary>
        public string GetTemplateName() { return DocAdminUtil.GetTemplateName(m_doc_data); }

        /// <summary>Returns the file path</summary>
        public string GetFilePath() { return DocAdminUtil.GetFilePath(m_doc_data); }

        /// <summary>Returns the file name doc</summary>
        public string GetFileNameDoc() { return DocAdminUtil.GetFileNameDoc(m_doc_data); }

        /// <summary>Returns the file name doc</summary>
        public string GetFileNameXls() { return DocAdminUtil.GetFileNameXls(m_doc_data); }

        /// <summary>Returns the file name pdf</summary>
        public string GetFileNamePdf() { return DocAdminUtil.GetFileNamePdf(m_doc_data); }

        /// <summary>Returns the file name txt</summary>
        public string GetFileNameTxt() { return DocAdminUtil.GetFileNameTxt(m_doc_data); }

        /// <summary>Returns the file name img</summary>
        public string GetFileNameImg() { return DocAdminUtil.GetFileNameImg(m_doc_data); }

        /// <summary>Returns the flag telling if the document can be published</summary>
        public bool GetPublished() { return DocAdminUtil.GetPublished(m_doc_data); }

        /// <summary>Returns the template description</summary>
        public string GetTemplateDescription() { return DocAdminUtil.GetTemplateDescription(m_doc_template); }

        /// <summary>Returns the season years</summary>
        public string GetDocSeasonYears() { return DocAdminUtil.GetDocSeasonYears(); }

        #endregion // Get text functions

        #region Construct and set file names

        /// <summary>Construct and sets the DOC file name</summary>
        public bool ConstructAndSetFileNameDoc(out string o_error)
        {
            return DocAdminUtil.ConstructAndSetFileNameDoc(m_doc_data, out o_error);

        } // ConstructAndSetFileNameDoc

        /// <summary>Construct and sets the PDF file name</summary>
        public bool ConstructAndSetFileNamePdf(out string o_error)
        {
            return DocAdminUtil.ConstructAndSetFileNamePdf(m_doc_data, out o_error);

        } // ConstructAndSetFileNamePdf

        /// <summary>Construct the file name without extension and checks also that m_doc_data is set</summary>
        private string ConstructFileNameNoExtension(out string o_error)
        {
            return DocAdminUtil.ConstructFileNameNoExtension(m_doc_data, out o_error);

        } // ConstructFileNameNoExtension

        #endregion // Construct and set file names

        #region Set file names

        /// <summary>Sets the DOC file name</summary>
        public bool SetFileNameDoc(string i_file_name_doc)
        {
            string error_message = @"";
            return DocAdminUtil.SetFileNameDoc(m_doc_data, i_file_name_doc, out error_message);

        } // SetFileNameDoc

        /// <summary>Sets the PDF file name</summary>
        public bool SetFileNamePdf(string i_file_name_pdf)
        {
            string error_message = @"";
            return DocAdminUtil.SetFileNamePdf(m_doc_data, i_file_name_pdf, out error_message);

        } // SetFileNamePdf

        /// <summary>Sets the TXT file name</summary>
        public bool SetFileNameTxt(string i_file_name_txt)
        {
            string error_message = @"";
            return DocAdminUtil.SetFileNameTxt(m_doc_data, i_file_name_txt, out error_message);

        } // SetFileNameTxt

        /// <summary>Sets the IMG file name</summary>
        public bool SetFileNameImg(string i_file_name_img)
        {
            string error_message = @"";
            return DocAdminUtil.SetFileNameImg(m_doc_data, i_file_name_img, out error_message);

        } // SetFileNameImg

        #endregion // Set file names

        #region Delete files

        /// <summary>Delete the origin file</summary>
        public bool DeleteFileNameOrigin(out string o_error)
        {
            return DocAdminUtil.DeleteFileNameDoc(m_doc_data, out o_error);

        } // DeleteFileNameOrigin

        /// <summary>Delete the PDF file</summary>
        public bool DeleteFileNamePdf(out string o_error)
        {
            return DocAdminUtil.DeleteFileNamePdf(m_doc_data, out o_error);

        } // DeleteFileNamePdf

        #endregion // Delete files

    } // DocOriginPdf

} // namespace
