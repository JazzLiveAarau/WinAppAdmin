using JazzApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Variables and execution functions for any DocXxxxForm
    /// <para>The class has objects that hold data for the file that is beeing processed.</para>
    /// <para>The file type (GetFileType) determines which object(s) that are current:</para>
    /// <para>File types 'season' and 'concert': Objects JazzDoc and JazzDocTemplate retrieved with GetDocumentData() and GetDocumentTemplate()</para>
    /// <para>File type 'web': Object JazzHtml retrieved with GetHtml()</para>
    /// <para></para>
    /// </summary>
    public class DocExeDocument
    {

        #region Backup flag

        /// <summary>Flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        private bool m_create_backup_document = true;

        /// <summary>Set flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        public void SetCreateBackupDocument(bool i_create_backup_document) { m_create_backup_document = i_create_backup_document; }

        /// <summary>Get flag telling if a backup document shall be created, i.e. if the document file exists on the server</summary>
        public bool GetCreateBackupDocument() { return m_create_backup_document; }

        #endregion // Backup flag

        #region Document type

        /// <summary>File type: season, concert or web</summary>
        private string m_file_type = @"";

        /// <summary>Set file type: season, concert or web</summary>
        public void SetFileType(string i_file_type) { m_file_type = i_file_type; }

        /// <summary>Get file type: season, concert or web</summary>
        public string GetFileType() { return m_file_type; }

        #endregion // Document type

        #region Objects holding document data

        /// <summary>Data for the current document object (JazzDoc) for file types 'season' and 'concert'</summary>
        private JazzDoc m_doc_data = null;

        /// <summary>Set data for the current document object (JazzDoc)</summary>
        public void SetDocumentData(JazzDoc i_doc_data) { m_doc_data = i_doc_data; }

        /// <summary>Get data for the current document object (JazzDoc)</summary>
        public JazzDoc GetDocumentData() { return m_doc_data; }

        /// <summary>The template for the document</summary>
        private JazzDocTemplate m_doc_template = null;

        /// <summary>Set the template for the document</summary>
        public void SetDocumentTemplate(JazzDocTemplate i_doc_template) { m_doc_template = i_doc_template; }

        /// <summary>Get the template for the document</summary>
        public JazzDocTemplate GetDocumentTemplate() { return m_doc_template; }

        /// <summary>Object that holds data for an htm or js file for filetype 'web'</summary>
        private JazzHtml m_html = null;

        /// <summary>Set the object that holds data for an htm or js file</summary>
        public void SetHtml(JazzHtml i_html) { m_html = i_html; }

        /// <summary>Get the object that holds data for an htm or js file</summary>
        public JazzHtml GetHtml() { return m_html; }

        /// <summary>Object that holds data for an rtf file for filetype 'help'</summary>
        private JazzHelp m_help = null;

        /// <summary>Set the object that holds data for an rtf file</summary>
        public void SetHelp(JazzHelp i_help) { m_help = i_help; }

        /// <summary>Get the object that holds data for an rtf file</summary>
        public JazzHelp GetHelp() { return m_help; }

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

        /// <summary>Writes all XML data for the JazzDoc object m_doc_data
        /// <para>The object m_doc_data can come from a document of type season or concert (type other is not yet implemented)</para>
        /// <para>For type season DocAdminUtil.WriteSeasonDoc(...) is called</para>
        /// <para>For type concert DocAdminUtil.WriteConcertDoc(...) is called</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public bool WriteDoc(out string o_error)
        {
            o_error = @"";

            if (GetFileType().Equals("season"))
            {
                if (!DocAdminUtil.WriteSeasonDoc(m_doc_data, out o_error))
                {
                    return false;
                }
            }
            else if (GetFileType().Equals("concert"))
            {
                if (!DocAdmin.WriteConcertDoc(m_doc_data, out o_error))
                {
                    return false;
                }
            }
            else
            {
                o_error = @"DocExeDocument.WriteDoc Not an implemented document type. GetFileType()= " + GetFileType();
                return false;
            }

            return true;
            } // WriteDoc

        #endregion Write text functions

        #region Set functions

        /// <summary>Sets the flag telling if the document can be published</summary>
        public void SetPublished(bool i_publish) { m_doc_data.Published = i_publish; }

        #endregion // Set functions

        #region Get functions

        /// <summary>Returns the template name as set in the current document object (JazzDoc m_doc_data)</summary>
        public string GetTemplateName() { return DocAdminUtil.GetTemplateName(m_doc_data); }

        /// <summary>Returns the file path as set in the current document object (JazzDoc m_doc_data)</summary>
        public string GetFilePath() { return DocAdminUtil.GetFilePath(m_doc_data); }

        /// <summary>Returns the file name doc as set in the current document object (JazzDoc m_doc_data)</summary>
        public string GetFileNameDoc() { return DocAdminUtil.GetFileNameDoc(m_doc_data); }

        /// <summary>Returns the file name xls as set in the current document object (JazzDoc m_doc_data)</summary>
        public string GetFileNameXls() { return DocAdminUtil.GetFileNameXls(m_doc_data); }

        /// <summary>Returns the file name pdf as set in the current document object (JazzDoc m_doc_data)</summary>
        public string GetFileNamePdf() { return DocAdminUtil.GetFileNamePdf(m_doc_data); }

        /// <summary>Returns the file name txt as set in the current document object (JazzDoc m_doc_data)</summary>
        public string GetFileNameTxt() { return DocAdminUtil.GetFileNameTxt(m_doc_data); }

        /// <summary>Returns the file name img as set in the current document object (JazzDoc m_doc_data)</summary>
        public string GetFileNameImg() { return DocAdminUtil.GetFileNameImg(m_doc_data); }

        /// <summary>Returns the flag (as set in the current document object JazzDoc m_doc_data) telling if the document can be published</summary>
        public bool GetPublished() { return DocAdminUtil.GetPublished(m_doc_data); }

        /// <summary>Returns the template description</summary>
        public string GetTemplateDescription() { return DocAdminUtil.GetTemplateDescription(m_doc_template); }

        /// <summary>Returns the season years</summary>
        public string GetDocSeasonYears() { return DocAdminUtil.GetDocSeasonYears(); }

        /// <summary>Returns the season autumm (start) year as string.</summary>
        public int  GetDocAutumnYearInt() { return DocAdminUtil.GetDocAutumnYearInt(); }


        #endregion // Get text functions

        #region Construct and set file names

        /// <summary>Construct and sets the DOC file name</summary>
        public bool ConstructAndSetFileNameDoc(out string o_error)
        {
            return DocAdminUtil.ConstructAndSetFileNameDoc(m_doc_data, out o_error);

        } // ConstructAndSetFileNameDoc

        /// <summary>Construct and sets the XLS file name</summary>
        public bool ConstructAndSetFileNameXls(out string o_error)
        {
            return DocAdminUtil.ConstructAndSetFileNameXls(m_doc_data, out o_error);

        } // ConstructAndSetFileNameXls

        /// <summary>Construct and sets the PDF file name</summary>
        public bool ConstructAndSetFileNamePdf(out string o_error)
        {
            return DocAdminUtil.ConstructAndSetFileNamePdf(m_doc_data, out o_error);

        } // ConstructAndSetFileNamePdf

        /// <summary>Construct and sets the TXT file name</summary>
        public bool ConstructAndSetFileNameTxt(out string o_error)
        {
            return DocAdminUtil.ConstructAndSetFileNameTxt(m_doc_data, out o_error);

        } // ConstructAndSetFileNameTxt

        /// <summary>Construct and sets the IMG file name</summary>
        public bool ConstructAndSetFileNameImg(out string o_error)
        {
            return DocAdminUtil.ConstructAndSetFileNameImg(m_doc_data, out o_error);

        } // ConstructAndSetFileNameImg

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

        /// <summary>Sets the XLS file name</summary>
        public bool SetFileNameXls(string i_file_name_doc)
        {
            string error_message = @"";
            return DocAdminUtil.SetFileNameXls(m_doc_data, i_file_name_doc, out error_message);

        } // SetFileNameXls

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

        /// <summary>Erase the DOC file name</summary>
        public bool DeleteFileNameDoc(out string o_error)
        {
            return DocAdminUtil.DeleteFileNameDoc(m_doc_data, out o_error);

        } // DeleteFileNameDoc

        /// <summary>Erase the XLS file name</summary>
        public bool DeleteFileNameXls(out string o_error)
        {
            return DocAdminUtil.DeleteFileNameXls(m_doc_data, out o_error);

        } // DeleteFileNameXls

        /// <summary>Erase the PDF file name</summary>
        public bool DeleteFileNamePdf(out string o_error)
        {
            return DocAdminUtil.DeleteFileNamePdf(m_doc_data, out o_error);

        } // DeleteFileNamePdf

        /// <summary>Erase the TXT file name</summary>
        public bool DeleteFileNameTxt(out string o_error)
        {
            return DocAdminUtil.DeleteFileNameTxt(m_doc_data, out o_error);

        } // DeleteFileNameTxt

        /// <summary>Erase the IMG file name</summary>
        public bool DeleteFileNameImg(out string o_error)
        {
            return DocAdminUtil.DeleteFileNameImg(m_doc_data, out o_error);

        } // DeleteFileNameImg

        #endregion // Delete files

        #region Click execution functions

        /// <summary>Get the click file name as defined in the the current document object (JazzDoc m_doc_data), current web object (JazzHtm m_htm) or current help object (JazzHelp m_help)</summary>
        public bool _GetClickFileName(string i_file_ext, TextBox i_textbox_message, out string o_download_file_name)
        {
            i_textbox_message.Text = @"";

            o_download_file_name = @"";

            if (i_file_ext.Equals("htm") || i_file_ext.Equals("js"))
            {
                return _GetClickFileNameWeb(i_file_ext, i_textbox_message, out o_download_file_name);
            }
            else if (i_file_ext.Equals("rtf"))
            {
                return _GetClickFileNameHelp(i_file_ext, i_textbox_message, out o_download_file_name);
            }
            else
            {
                return _GetClickFileNameDocument(i_file_ext, i_textbox_message, out o_download_file_name);
            }

        } // _GetClickFileName

        /// <summary>Get the click file name as defined in the the current document object (JazzDoc m_doc_data)</summary>
        public bool _GetClickFileNameDocument(string i_file_ext, TextBox i_textbox_message, out string o_download_file_name)
        {
            i_textbox_message.Text = @"";

            o_download_file_name = @"";

            if (i_file_ext.Equals("doc"))
            {
                o_download_file_name = GetFileNameDoc();
            }
            else if (i_file_ext.Equals("xls"))
            {
                o_download_file_name = GetFileNameXls();
            }
            else if (i_file_ext.Equals("pdf"))
            {
                o_download_file_name = GetFileNamePdf();
            }
            else if (i_file_ext.Equals("txt"))
            {
                o_download_file_name = GetFileNameTxt();
            }
            else if (i_file_ext.Equals("img"))
            {
                o_download_file_name = GetFileNameImg();
            }
            else
            {
                i_textbox_message.Text = "DocExeDocument._GetClickFileNameDocument Programming error: Unknown i_file_ext= " + i_file_ext;
                return false;
            }

            return true;

        } // _GetClickFileNameDocument

        /// <summary>Get the click file name as defined in the the current web object (JazzHtml m_htm)</summary>
        public bool _GetClickFileNameWeb(string i_file_ext, TextBox i_textbox_message, out string o_download_file_name)
        {
            i_textbox_message.Text = @"";

            o_download_file_name = @"";

            JazzHtml current_web_object = GetHtml();
            if (null == current_web_object)
            {
                i_textbox_message.Text = "DocExeDocument._GetClickFileNameWeb Programming error: JazzHtml (m_htm) object is null";
                return false;
            }

            if (i_file_ext.Equals("htm") || i_file_ext.Equals("js"))
            {
                o_download_file_name = current_web_object.FileName;
            }
            else
            {
                i_textbox_message.Text = "DocExeDocument._GetClickFileNameWeb Programming error: Unknown i_file_ext= " + i_file_ext;
                return false;
            }

            return true;

        } // _GetClickFileNameWeb

        /// <summary>Get the click file name as defined in the the current help object (JazzHelp m_help)</summary>
        public bool _GetClickFileNameHelp(string i_file_ext, TextBox i_textbox_message, out string o_download_file_name)
        {
            i_textbox_message.Text = @"";

            o_download_file_name = @"";

            JazzHelp current_help_object = GetHelp();
            if (null == current_help_object)
            {
                i_textbox_message.Text = "DocExeDocument._GetClickFileNameHelp Programming error: JazzHelp (m_help) object is null";
                return false;
            }

            if (i_file_ext.Equals("rtf"))
            {
                o_download_file_name = current_help_object.FileName;
            }
            else
            {
                i_textbox_message.Text = "DocExeDocument._GetClickFileNameHelp Programming error: Unknown i_file_ext= " + i_file_ext;
                return false;
            }

            return true;

        } // _GetClickFileNameHelp


        /// <summary>Set click file name</summary>
        public bool SetClickFileName(string i_file_ext, TextBox i_textbox_message, string i_click_file_name)
        {
            if (i_file_ext.Equals("doc"))
            {
                SetFileNameDoc(i_click_file_name);
            }
            else if (i_file_ext.Equals("xls"))
            {
                SetFileNameXls(i_click_file_name);
            }
            else if (i_file_ext.Equals("pdf"))
            {
                SetFileNamePdf(i_click_file_name);
            }
            else if (i_file_ext.Equals("txt"))
            {
                SetFileNameTxt(i_click_file_name);
            }
            else if (i_file_ext.Equals("img"))
            {
                SetFileNameImg(i_click_file_name);
            }
            else
            {
                i_textbox_message.Text = "DocExeDocument.SetClickFileName Programming error: Unknown i_file_ext= " + i_file_ext;
                return false;
            }

            return true;

        } // SetClickFileName

        /// <summary>Erase click file name</summary>
        public bool DeleteClickFileName(string i_file_ext, TextBox i_textbox_message)
        {
            string error_message = @"";

            if (i_file_ext.Equals("doc"))
            {
                if (!DeleteFileNameDoc(out error_message))
                {
                    i_textbox_message.Text = error_message;
                    return false;
                }
            }
            else if (i_file_ext.Equals("xls"))
            {
                if (!DeleteFileNameXls(out error_message))
                {
                    i_textbox_message.Text = error_message;
                    return false;
                }
            }
            else if (i_file_ext.Equals("pdf"))
            {
                if (!DeleteFileNamePdf(out error_message))
                {
                    i_textbox_message.Text = error_message;
                    return false;
                }
            }
            else if (i_file_ext.Equals("txt"))
            {
                if (!DeleteFileNameTxt(out error_message))
                {
                    i_textbox_message.Text = error_message;
                    return false;
                }
            }
            else if (i_file_ext.Equals("img"))
            {
                if (!DeleteFileNameImg(out error_message))
                {
                    i_textbox_message.Text = error_message;
                    return false;
                }
            }
            else
            {
                i_textbox_message.Text = "DocExeDocument.DeleteClickFileName Programming error: Unknown i_file_ext= " + i_file_ext;
                return false;
            }

            return true;

        } // DeleteClickFileName

        /// <summary>Construct and set file name</summary>
        public bool ConstructAndSetFileName(string i_file_ext, TextBox i_textbox_message)
        {
            string error_construct = @"";

            if (i_file_ext.Equals("doc"))
            {
                if (!ConstructAndSetFileNameDoc(out error_construct))
                {
                    i_textbox_message.Text = error_construct;
                    return false;
                }
            }
            else if (i_file_ext.Equals("xls"))
            {
                if (!ConstructAndSetFileNameXls(out error_construct))
                {
                    i_textbox_message.Text = error_construct;
                    return false;
                }
            }
            else if (i_file_ext.Equals("pdf"))
            {
                if (!ConstructAndSetFileNamePdf(out error_construct))
                {
                    i_textbox_message.Text = error_construct;
                    return false;
                }
            }
            else if (i_file_ext.Equals("txt"))
            {
                if (!ConstructAndSetFileNameTxt(out error_construct))
                {
                    i_textbox_message.Text = error_construct;
                    return false;
                }
            }
            else if (i_file_ext.Equals("img"))
            {
                if (!ConstructAndSetFileNameImg(out error_construct))
                {
                    i_textbox_message.Text = error_construct;
                    return false;
                }
            }
            else
            {
                i_textbox_message.Text = "DocExeDocument.ConstructAndSetFileName Programming error: Unknown i_file_ext= " + i_file_ext;
                return false;
            }
            return true;

        } // ConstructAndSetFileName


        /// <summary>Returns the combined path for concert documents constructed from the XML file as DocumentsPath/FilePath</summary>
        public string GetConcertDocumentsPath()
        {
            string path_combine = GetDocDocumentsPath() + @"/" + GetFilePath();

            return path_combine;
        } // GetConcertDocumentsPath

        /// <summary>Returns the path to the documents</summary>
        public string GetDocDocumentsPath() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetDocDocumentsPath()); }

        /// <summary>Returns the server path to the web file</summary>
        public string GetWebFilePath()
        {
            JazzHtml current_web_object = GetHtml();
            if (null == current_web_object)
                return @"";

            return current_web_object.ServerPath;

        } // GetWebFilePath

        /// <summary>Returns the server path to the help file</summary>
        public string GetHelpFilePath()
        {
            JazzHelp current_help_object = GetHelp();
            if (null == current_help_object)
                return @"";

            return current_help_object.ServerPath;

        } // GetWebFilePath

        /// <summary>Returns the full name to the file on the server.
        /// <para>Call of  GetFilePath() for file type "season"</para>
        /// <para>Call of  GetConcertDocumentsPath() for file type "concert"</para>
        /// <para>Call of  GetWebFilePath() for file type "web"</para>
        /// <para>Call of  GetWebFilePath() for file type "template"</para>
        /// <para>Function GetFileType() returns the file type (m_file_type)</para>
        /// </summary>
        /// <param name="o_file_path">Output full server file name</param>
        /// <param name="i_textbox_message">Message text box for error message</param>
        private bool GetFileNameWithPath(out string o_file_path, TextBox i_textbox_message)
        {
            o_file_path = @"";

            if (GetFileType().Equals("season"))
            {
                o_file_path = GetFilePath();
            }
            else if (GetFileType().Equals("concert"))
            {
                o_file_path = GetConcertDocumentsPath();
            }
            else if (GetFileType().Equals("web"))
            {
                o_file_path = GetWebFilePath();
            }
            else if (GetFileType().Equals("template"))
            {
                o_file_path = GetWebFilePath();
            }
            else if (GetFileType().Equals("help"))
            {
                o_file_path = GetHelpFilePath();
            }
            else
            {
                i_textbox_message.Text = "DocExeDocument.GetFileNameWithPath: Not an implemented file type= " + GetFileType();
                return false;
            }

            return true;

        } // GetFileNameWithPath

        /// <summary>Get extensions</summary>
        private string GetExtensions(string i_file_ext)
        {
            string ret_extensions = @"";

            if (i_file_ext.Equals("doc") || i_file_ext.Equals("xls") || i_file_ext.Equals("pdf") || i_file_ext.Equals("txt") || i_file_ext.Equals("img"))
            {
                JazzDocTemplate doc_template = GetDocumentTemplate();
                if (null == doc_template)
                    return ret_extensions;
                ret_extensions = doc_template.TemplateExtensions;
            }
            else if (i_file_ext.Equals("htm") || i_file_ext.Equals("js") )
            {
                JazzHtml html_object = GetHtml();
                if (null == html_object)
                    return ret_extensions;
                ret_extensions = html_object.Extensions;
            }
            else if (i_file_ext.Equals("rtf"))
            {
                JazzHelp jazz_object = GetHelp();
                if (null == jazz_object)
                    return ret_extensions;
                ret_extensions = jazz_object.Extensions;
            }

            return ret_extensions;
        } // GetExtensions

        /// <summary>Execution of download click</summary>
        public bool ExeDownloadClick(string i_file_ext, string i_file_type_case, TextBox i_textbox_message)
        {
            string download_file_name = @"";
            if (!_GetClickFileName(i_file_ext, i_textbox_message, out download_file_name))
            {
                return false;
            }

            if (download_file_name.Length == 0)
            {
                i_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return false;
            }

            string error_message = @"";
            bool cancel_download = false;

            string file_path = @"";
            if (!GetFileNameWithPath(out file_path, i_textbox_message))
                return false;

            string file_extensions = GetExtensions(i_file_ext);

            if (!OpenSaveDialog.Download(file_path, download_file_name, i_file_type_case, file_extensions, out cancel_download, out error_message))
            {
                i_textbox_message.Text = error_message;
                return false;
            }

            if (cancel_download)
            {
                i_textbox_message.Text = DocAdminString.MsgFileDownloadCancelled;
                return false;
            }

            i_textbox_message.Text = download_file_name + DocAdminString.MsgFileDownloaded;

            return true;

        } // ExeDownloadClick


        /// <summary>For a new file only: Delete text box file name if OpenSaveDialog.Upload failed, or if the user cancelled the upload.</summary>
        private void DeleteTextBoxFileName(TextBox i_text_box_file_name)
        {
            if (GetCreateBackupDocument())
            {
                return;
            }

            i_text_box_file_name.Text = @"";

        } // DeleteTextBoxFileName

        /// <summary>Execution of an upload click.
        /// <para>1. Get the click file name defined by current JazzDoc, JazzHtm or JazzHelp. Call of _GetClickFileName.</para>
        /// <para>2. Return false if not checked out. Call of CheckoutUpload. </para>
        /// <para>3. Construct file name if input file name not is set. Call of ConstructAndSetFileName. Set backup flag to false. Call of SetCreateBackupDocument</para>
        /// <para>4. Set backup flag to true. Call of SetCreateBackupDocument</para>
        /// <para>5. Get file name with path defined by JazzDoc, JazzHtm or JazzHelp. Call of GetFileNameWithPath.</para>
        /// <para>6. Get extensions  defined by JazzDoc, JazzHtm or JazzHelp. Call of GetExtensions.</para>
        /// <para>7. Get input file from user. Call of OpenSaveDialog.Upload.</para>
        /// <para>8. Set click filen name if extension has been changed. Call of SetClickFileName for this case.</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_file_ext">Extension doc, xls, pdf, txt, img, htm, js or rtf</param>
        /// <param name="i_case_extension">File extension type: main, pdf, txt, img, htm or js</param>
        /// <param name="i_admin_file">Flag telling if the file is an Admin file, i.e. if it shall be saved in server directory /admin/JazzAppAdmin/</param>
        /// <param name="i_editable">Flag telling if the file is checked out</param>
        /// <param name="i_text_box_file_name">Text box displaying the file name</param>
        /// <param name="i_textbox_message">Text box displaying messages</param>
        /// <param name="o_error">Error message.</param>
        public bool ExeUploadClick(string i_file_ext, string i_case_extensions, bool i_admin_file, bool i_editable, TextBox i_text_box_file_name, TextBox i_textbox_message)
        {
            string upload_file_name = @"";
            if (!_GetClickFileName(i_file_ext, i_textbox_message, out upload_file_name))
            {
                return false;
            }

            if (CheckoutUpload(upload_file_name, i_editable, i_textbox_message))
                return false;

            if (upload_file_name.Length == 0)
            {
                if (!ConstructAndSetFileName(i_file_ext, i_textbox_message))
                {
                    return false;
                }

                if (!_GetClickFileName(i_file_ext, i_textbox_message, out upload_file_name))
                {
                    return false;
                }

                i_text_box_file_name.Text = upload_file_name;

                SetCreateBackupDocument(false);
            }
            else
            {
                SetCreateBackupDocument(true);
            }

            string error_message = @"";
            bool cancel_upload = false;
            string out_file_name_upload = @""; // Output file extension may be changed in OpenSaveDialog.Upload for a new file


            string file_path = @"";
            if (!GetFileNameWithPath(out file_path, i_textbox_message))
                return false;

            string file_extensions = GetExtensions(i_file_ext);

            if (!OpenSaveDialog.Upload(file_path, upload_file_name, i_case_extensions, file_extensions, i_admin_file, GetCreateBackupDocument(), out cancel_upload, out out_file_name_upload, out error_message))
            {
                DeleteClickFileName(i_file_ext, i_text_box_file_name);
                DeleteTextBoxFileName(i_text_box_file_name);
                i_textbox_message.Text = error_message;
                return false;
            }

            if (cancel_upload)
            {
                DeleteClickFileName(i_file_ext, i_text_box_file_name);
                DeleteTextBoxFileName(i_text_box_file_name);
                i_textbox_message.Text = DocAdminString.MsgFileUploadCancelled;
                return false;
            }

            if (!out_file_name_upload.Equals(upload_file_name))
            {
                // Extension has been changed for a new file
                if (!SetClickFileName(i_file_ext, i_textbox_message, out_file_name_upload))
                    return false;

                i_text_box_file_name.Text = out_file_name_upload;
            }

            i_textbox_message.Text = out_file_name_upload + DocAdminString.MsgFileUploaded;

            return true;

        } // ExeUploadClick

        /// <summary>Execution of delete click</summary>
        public bool ExeDeleteClick(string i_file_ext, bool i_editable, TextBox i_text_box_file_name, TextBox i_textbox_message)
        {
            string delete_file_name = @"";
            if (!_GetClickFileName(i_file_ext, i_textbox_message, out delete_file_name))
            {
                return false;
            }

            if (delete_file_name.Length == 0)
            {
                i_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return false;
            }

            if (CheckoutDelete(delete_file_name, i_editable, i_textbox_message))
                return false;

            i_textbox_message.Text = delete_file_name + DocAdminString.MsgFileDeleted;

            if (!DeleteClickFileName(i_file_ext, i_textbox_message))
                return false;

            i_text_box_file_name.Text = @"";

            return true;

        } // ExeDeleteClick

        /// <summary>Execute the publish check box change</summary>
        public void ExePublishCheckedChanged(CheckBox i_check_box_publish)
        {
            if (i_check_box_publish.Checked)
                SetPublished(true);
            else
                SetPublished(false);

        } // ExeCheckedChanged


        #endregion // Click execution functions

        /// <summary>Set publish box editable or not</summary>
        public void SetPublishCheckBoxEditable(CheckBox i_check_box_publish, bool i_editable)
        {
            if (i_editable)
            {
                i_check_box_publish.Enabled = true;

                i_check_box_publish.BackColor = AdminUtils.ColorEnable();
            }
            else
            {
                i_check_box_publish.Enabled = false;

                i_check_box_publish.BackColor = AdminUtils.ColorDisable();
            }

        } // SetPublishCheckBoxEditable

        #region Checkout functions

        /// <summary>Returns true if it is necessary to checkout the XML file
        /// <para>This function should no longer be used </para>
        /// <para>Checkout is necessary if the file not yet in the XML file defined is</para>
        /// <para>The user will get a message (message box) if checkout is necessary</para>
        /// <para>The message text control is cleaned</para>
        /// </summary>
        /// <param name="i_file_name">Document file name</param>
        ///  <param name="i_editable">Flag telling if the XML file has been checked out</param>
        /// <param name="i_textbox_message">Text box for messages</param>
        public bool CheckoutXml(string i_file_name, bool i_editable, TextBox i_textbox_message)
        {
            i_textbox_message.Text = @"";

            if (i_file_name.Length == 0 && !i_editable)
            {
                string error_checkout = DocAdminString.ErrMsgCheckoutUploadDocFirstTime + Path.GetFileName(JazzXml.GetFileNameActiveObject());
                MessageBox.Show(error_checkout);
                return true;
            }

            return false;
        } // CheckoutXml

        /// <summary>Returns true if it is necessary to checkout the XML file for delete
        /// <para>The user will get a message (message box) if checkout is necessary</para>
        /// <para>The message text control is cleaned</para>
        /// </summary>
        /// <param name="i_file_name">Document file name</param>
        /// <param name="i_editable">Flag telling if the XML file has been checked out</param>
        ///  <param name="i_textbox_message">Text box for messages</param>
        public bool CheckoutDelete(string i_file_name, bool i_editable, TextBox i_textbox_message)
        {
            i_textbox_message.Text = @"";

            if (i_file_name.Length != 0 && !i_editable)
            {
                string error_checkout = DocAdminString.ErrMsgCheckoutBeforeDelete + Path.GetFileName(JazzXml.GetFileNameActiveObject());
                MessageBox.Show(error_checkout);
                return true;
            }

            return false;
        } // CheckoutDelete

        /// <summary>Returns true if it is necessary to checkout the XML file for upload
        /// <para>The user will get a message (message box) if checkout is necessary</para>
        /// <para>The message text control is cleaned</para>
        /// </summary>
        /// <param name="i_file_name">Document file name</param>
        /// <param name="i_editable">Flag telling if the XML file has been checked out</param>
        ///  <param name="i_textbox_message">Text box for messages</param>
        public bool CheckoutUpload(string i_file_name, bool i_editable, TextBox i_textbox_message)
        {
            i_textbox_message.Text = @"";

            // QQQ 2017-12-11 if (i_file_name.Length != 0 && !i_editable)
            if (!i_editable)
            {
                string error_checkout = DocAdminString.ErrMsgCheckoutBeforeUpload + Path.GetFileName(JazzXml.GetFileNameActiveObject());
                MessageBox.Show(error_checkout);
                return true;
            }

            return false;
        } // CheckoutUpload


        #endregion // Checkout functions

    } // DocExeDocument
} // namespace
