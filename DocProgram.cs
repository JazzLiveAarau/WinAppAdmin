using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JazzApp;

namespace JazzAppAdmin
{
    /// <summary>Document season program variables and functions
    /// <para>How to add this document class is described in JAZZ_live_AARAU_Admin_Doc.rtf</para>
    /// </summary>
    public static class DocProgram
    {
        #region Backup flag

        /// <summary>Flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        private static bool m_create_backup_document = true;

        /// <summary>Set flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        public static void SetCreateBackupDocument(bool i_create_backup_document) { m_create_backup_document = i_create_backup_document; }

        /// <summary>Get flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        public static bool GetCreateBackupDocument() { return m_create_backup_document; }

        #endregion // Backup flag

        #region Objects holding document data

        /// <summary>Data for the season program document</summary>
        static private JazzDoc m_doc_data = null;

        /// <summary>Set data for the season program document</summary>
        static public void SetDocumentData(JazzDoc i_doc_data) { m_doc_data = i_doc_data; }

        /// <summary>The template for the season program document</summary>
        static private JazzDocTemplate m_doc_template = null;

        /// <summary>Set the template for the season program document</summary>
        static public void SetDocumentTemplate(JazzDocTemplate i_doc_template) { m_doc_template = i_doc_template; }

        /// <summary>Get the template for the season program document</summary>
        static public JazzDocTemplate GetDocumentTemplate() { return m_doc_template; }

        #endregion // Objects holding document data

        #region Write text functions

        /// <summary>Writes all XML data for a season document.</summary>
        static public bool WriteSeasonDoc(out string o_error)
        {
            return DocAdminUtil.WriteSeasonDoc(m_doc_data, out o_error);

        } // WriteSeasonDoc

        #endregion Write text functions

        #region Set functions

        /// <summary>Sets the file name txt</summary>
        static public void SetFileNameTxt(string i_file_name_txt) {m_doc_data.FileNameTxt = i_file_name_txt; }

        /// <summary>Sets the flag telling if the document can be published</summary>
        static public void SetPublished(bool i_publish) {m_doc_data.Published = i_publish; }

        #endregion // Set functions

        #region Get functions

        /// <summary>Returns the template name</summary>
        static public string GetTemplateName(){return DocAdminUtil.GetTemplateName(m_doc_data); } 

        /// <summary>Returns the file path</summary>
        static public string GetFilePath() { return DocAdminUtil.GetFilePath(m_doc_data); } 

        /// <summary>Returns the file name doc</summary>
        static public string GetFileNameDoc() { return DocAdminUtil.GetFileNameDoc(m_doc_data); } 

        /// <summary>Returns the file name pdf</summary>
        static public string GetFileNamePdf() { return DocAdminUtil.GetFileNamePdf(m_doc_data); } 

        /// <summary>Returns the file name txt</summary>
        static public string GetFileNameTxt() { return DocAdminUtil.GetFileNameTxt(m_doc_data); } 

        /// <summary>Returns the file name img</summary>
        static public string GetFileNameImg() { return DocAdminUtil.GetFileNameImg(m_doc_data); } 

        /// <summary>Returns the flag telling if the document can be published</summary>
        static public bool GetPublished(){return DocAdminUtil.GetPublished(m_doc_data); }

        /// <summary>Returns the template description</summary>
        static public string GetTemplateDescription() { return DocAdminUtil.GetTemplateDescription(m_doc_template); }

        /// <summary>Returns the season years</summary>
        static public string GetDocSeasonYears() { return DocAdminUtil.GetDocSeasonYears(); }

        #endregion // Get text functions

        #region Construct and set file names

        /// <summary>Construct and sets the DOC file name</summary>
        static public bool ConstructAndSetFileNameDoc(out string o_error)
        {
            return DocAdminUtil.ConstructAndSetFileNameDoc(m_doc_data, out o_error);
 
        } // ConstructAndSetFileNameDoc


        /// <summary>Construct and sets the PDF file name</summary>
        static public bool ConstructAndSetFileNamePdf(out string o_error)
        {
            return DocAdminUtil.ConstructAndSetFileNamePdf(m_doc_data, out o_error);

        } // ConstructAndSetFileNamePdf


        /// <summary>Construct and sets the TXT file name</summary>
        static public bool ConstructAndSetFileNameTxt(out string o_error)
        {
            return DocAdminUtil.ConstructAndSetFileNameTxt(m_doc_data, out o_error);

        } // ConstructAndSetFileNameTxt

        /// <summary>Construct the file name without extension and checks also that m_doc_data is set</summary>
        static private string ConstructFileNameNoExtension(out string o_error)
        {
            return DocAdminUtil.ConstructFileNameNoExtension(m_doc_data, out o_error);

        } // ConstructFileNameNoExtension

        #endregion // Construct and set file names

        #region Delete files

        /// <summary>Delete the DOC file</summary>
        static public bool DeleteFileNameDoc(out string o_error)
        {
            return DocAdminUtil.DeleteFileNameDoc(m_doc_data, out o_error);

        } // DeleteFileNameDoc

        /// <summary>Delete the PDF file</summary>
        static public bool DeleteFileNamePdf(out string o_error)
        {
            return DocAdminUtil.DeleteFileNamePdf(m_doc_data, out o_error);
 
        } // DeleteFileNamePdf

        /// <summary>Delete the TXT file</summary>
        static public bool DeleteFileNameTxt(out string o_error)
        {
            return DocAdminUtil.DeleteFileNameTxt(m_doc_data, out o_error);

        } // DeleteFileNameTxt

        #endregion // Delete files

        #region Generate saison program as text file

        /// <summary>Generate the TXT file</summary>
        static public bool GenerateFileNameTxt(out string o_file_name, out string o_error)
        {
            o_error = @"";
            o_file_name = @"";

            string error_message = @"";
            string file_name_no_extension = ConstructFileNameNoExtension(out error_message);
            if (file_name_no_extension.Length == 0)
            {
                o_error = error_message;
                return false;
            }

            string file_name_txt = file_name_no_extension + @".txt";

            string file_path = DocAdmin.GetDirectoryUpload();
            if (file_path.Length == 0)
            {
                o_error = @"DocProgram.GenerateFileNameTxt Directory GetDirectoryUpload() is not set";
                return false;
            }

            if (!SeasonProgramTxt.Generate(file_path, file_name_txt, out error_message))
            {
                o_error = @"DocProgram.GenerateFileNameTxt " + error_message;
                return false;
            }

            o_file_name = file_name_txt;

            return true;

        } // GenerateFileNameTxt

        #endregion // Generate saison program as text file

    } // DocProgram

} // namespace
