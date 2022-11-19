using JazzApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Download and upload of the season program
    /// <para>How to add this document class is described in JAZZ_live_AARAU_Admin_Doc.rtf</para>
    /// </summary>
    public partial class DocProgramForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private DocAdminForm m_doc_admin_form = null;

        /// <summary>Holds the data for a document. In this case the season program</summary>
        private JazzDoc m_doc_data = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor
        /// <para>1. Sets the season program data of the static DocProgram object (calls DocProgram.SetDocumentData)</para>
        /// <para>2. Sets the season program template data of the static DocProgram object (calls DocProgram.SetDocumentTemplate)</para>
        /// <para>3. Sets the controls of the dialog</para>
        /// <para>4. Makes the controls editable if the XML file is checked out</para>
        /// <para>5. Sets the tool tips</para>
        /// <para>6. Sets the captions</para>
        /// </summary>
        /// <param name="i_doc_admin_form">The owner of this form</param>
        /// <param name="i_doc_data">Data about the season program documents</param>
        /// <param name="i_doc_template">The template for the season program documents</param>
        public DocProgramForm(DocAdminForm i_doc_admin_form, JazzDoc i_doc_data, JazzDocTemplate i_doc_template)
        {
            InitializeComponent();

            if (null == i_doc_admin_form)
                return;

            m_doc_admin_form = i_doc_admin_form;

            if (null == i_doc_data)
                return;

            m_doc_data = i_doc_data;

            DocProgram.SetDocumentData(m_doc_data);

            if (null == i_doc_template)
                return;

            DocProgram.SetDocumentTemplate(i_doc_template);

            _SetTexts();

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetEditable();

            _SetToolTips();

            _SetCaptions();

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipDocProgramForm.SetToolTip(this, DocAdminString.ToolTipDocProgramForm);
            ToolTipUtil.SetDelays(ref ToolTipDocProgramForm);

            ToolTipDocProgramFormEdit.SetToolTip(m_button_edit_concert_data, DocAdminString.ToolTipDocProgramFormEdit);
            ToolTipUtil.SetDelays(ref ToolTipDocProgramFormEdit);
            ToolTipDocProgramFormCancel.SetToolTip(m_button_cancel, DocAdminString.ToolTipDocProgramFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipDocProgramFormCancel);
            ToolTipDocProgramFormClose.SetToolTip(m_button_close, DocAdminString.ToolTipDocProgramFormClose);
            ToolTipUtil.SetDelays(ref ToolTipDocProgramFormClose);

            ToolTipDocProgramFormCurrentSeason.SetToolTip(m_label_page_header, DocAdminString.ToolTipDocProgramFormCurrentSeason);
            ToolTipDocProgramFormCurrentSeason.SetToolTip(m_text_box_season_name, DocAdminString.ToolTipDocProgramFormCurrentSeason);
            ToolTipUtil.SetDelays(ref ToolTipDocProgramFormCurrentSeason);
            ToolTipDocPublish.SetToolTip(m_check_box_publish, DocAdminString.ToolTipDocPublish);
            ToolTipDocPublish.SetToolTip(m_label_publish, DocAdminString.ToolTipDocPublish);
            ToolTipUtil.SetDelays(ref ToolTipDocPublish);


            ToolTipDownLoadDoc.SetToolTip(m_button_download_doc, DocAdminString.ToolTipDownLoadDoc);
            ToolTipUtil.SetDelays(ref ToolTipDownLoadDoc);
            ToolTipDownLoadPdf.SetToolTip(m_button_download_pdf, DocAdminString.ToolTipDownLoadPdf);
            ToolTipUtil.SetDelays(ref ToolTipDownLoadPdf);
            ToolTipDownLoadTxt.SetToolTip(m_button_download_txt, DocAdminString.ToolTipDownLoadTxt);
            ToolTipUtil.SetDelays(ref ToolTipDownLoadTxt);

            ToolTipUpLoadDoc.SetToolTip(m_button_upload_doc, DocAdminString.ToolTipUpLoadDoc);
            ToolTipUtil.SetDelays(ref ToolTipUpLoadDoc);
            ToolTipUpLoadPdf.SetToolTip(m_button_upload_pdf, DocAdminString.ToolTipUpLoadPdf);
            ToolTipUtil.SetDelays(ref ToolTipUpLoadPdf);
            ToolTipUpLoadTxt.SetToolTip(m_button_upload_txt, DocAdminString.ToolTipUpLoadTxt);
            ToolTipUtil.SetDelays(ref ToolTipUpLoadTxt);

            ToolTipDeleteDoc.SetToolTip(m_button_delete_doc, DocAdminString.ToolTipDeleteDoc);
            ToolTipUtil.SetDelays(ref ToolTipDeleteDoc);
            ToolTipDeletePdf.SetToolTip(m_button_delete_pdf, DocAdminString.ToolTipDeletePdf);
            ToolTipUtil.SetDelays(ref ToolTipDeletePdf);
            ToolTipDeleteTxt.SetToolTip(m_button_delete_txt, DocAdminString.ToolTipDeleteTxt);
            ToolTipUtil.SetDelays(ref ToolTipDeleteTxt);

            ToolTipFilenameDoc.SetToolTip(m_text_box_file_name_doc, DocAdminString.ToolTipFilenameDoc);
            ToolTipUtil.SetDelays(ref ToolTipFilenameDoc);
            ToolTipFilenamePdf.SetToolTip(m_text_box_file_name_pdf, DocAdminString.ToolTipFilenamePdf);
            ToolTipUtil.SetDelays(ref ToolTipFilenamePdf);
            ToolTipFilenameTxt.SetToolTip(m_text_box_file_name_txt, DocAdminString.ToolTipFilenameTxt);
            ToolTipUtil.SetDelays(ref ToolTipFilenameTxt);

            ToolTipGenerateTxt.SetToolTip(m_button_generate_txt, DocAdminString.ToolTipGenerateTxt);
            ToolTipUtil.SetDelays(ref ToolTipGenerateTxt);

            ToolTipDocProgramFormMsg.SetToolTip(m_textbox_message, DocAdminString.ToolTipDocProgramFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipDocProgramFormMsg);

        } // SetToolTips

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = DocAdminString.GetTitleFormDocument(DocAdminString.TitleDocProgramForm);
            this.m_label_page_header.Text = DocProgram.GetTemplateDescription();

            m_text_box_season_name.Text = DocProgram.GetDocSeasonYears();
            m_text_box_file_name_doc.Text = DocProgram.GetFileNameDoc();
            m_text_box_file_name_pdf.Text = DocProgram.GetFileNamePdf();
            m_text_box_file_name_txt.Text = DocProgram.GetFileNameTxt();

            bool b_publish = DocProgram.GetPublished();
            if (b_publish)
                this.m_check_box_publish.Checked = true;
            else
                this.m_check_box_publish.Checked = false;

            m_label_publish.Text = DocAdminString.TitleLabelPublish;

            m_label_current_season.Text = DocAdminString.LabelCurrentSeason;

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set captions</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set controls editable or not</summary>
        private void _SetEditable()
        {
            if (m_editable)
            {
                this.m_check_box_publish.Enabled = true;

                this.m_check_box_publish.BackColor = AdminUtils.ColorEnable();

            }
            else
            {
                this.m_check_box_publish.Enabled = false;

                this.m_check_box_publish.BackColor = AdminUtils.ColorDisable();

            }

        } // SetEditable

        #endregion // Set controls

        #region Write data

        /// <summary>Write texts</summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            if (!DocProgram.WriteSeasonDoc(out o_error)) { return false; }

            return true;
        } // _WriteTexts

        #endregion // Write data

        #region Checkout functions

        /// <summary>Returns true if it is necessary to checkout the XML file
        /// <para>The user will get a message (message box) if checkout is necessary</para>
        /// <para>The message text control is cleaned</para>
        /// </summary>
        /// <param name="i_file_name">Document file name</param>
        private bool _CheckoutXml(string i_file_name)
        {
            m_textbox_message.Text = @"";

            //QQQ if (i_file_name.Length == 0 && !m_editable)
            if (!m_editable)
            {
                string error_checkout = DocAdminString.ErrMsgCheckoutUploadDocFirstTime + Path.GetFileName(JazzXml.GetFileNameActiveObject());
                MessageBox.Show(error_checkout);
                return true;
            }

            return false;

        } // _CheckoutXml

        /// <summary>Returns true if it is necessary to checkout the XML file for delete
        /// <para>The user will get a message (message box) if checkout is necessary</para>
        /// <para>The message text control is cleaned</para>
        /// </summary>
        /// <param name="i_file_name">Document file name</param>
        private bool _CheckoutDelete(string i_file_name)
        {
            m_textbox_message.Text = @"";

            if (i_file_name.Length != 0 && !m_editable)
            {
                string error_checkout = DocAdminString.ErrMsgCheckoutBeforeDelete + Path.GetFileName(JazzXml.GetFileNameActiveObject());
                MessageBox.Show(error_checkout);
                return true;
            }

            return false;
        } // _CheckoutDelete

        #endregion // Checkout functions

        #region Download functions

        /// <summary>User clicked button download doc</summary>
        private void m_button_download_doc_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            if (DocProgram.GetFileNameDoc().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            string error_message = @"";
            bool cancel_download = false;

            string file_extensions = DocProgram.GetDocumentTemplate().TemplateExtensions;
            if (!OpenSaveDialog.Download(DocProgram.GetFilePath(), DocProgram.GetFileNameDoc(), "main", file_extensions, out cancel_download, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_download)
            {
                m_textbox_message.Text = DocAdminString.MsgFileDownloadCancelled;
                return;
            }

            m_textbox_message.Text = DocProgram.GetFileNameDoc() + DocAdminString.MsgFileDownloaded;


        } // m_button_download_doc_Click

        /// <summary>User clicked button download pdf</summary>
        private void m_button_download_pdf_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            if (DocProgram.GetFileNamePdf().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            string error_message = @"";
            bool cancel_download = false;

            string file_extensions = DocProgram.GetDocumentTemplate().TemplateExtensions; 
            if (!OpenSaveDialog.Download(DocProgram.GetFilePath(), DocProgram.GetFileNamePdf(), "pdf", file_extensions, out cancel_download, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_download)
            {
                m_textbox_message.Text = DocAdminString.MsgFileDownloadCancelled;
                return;
            }

            m_textbox_message.Text = DocProgram.GetFileNamePdf() + DocAdminString.MsgFileDownloaded;

        } // m_button_download_pdf_Click

        /// <summary>User clicked button download txt</summary>
        private void m_button_download_txt_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            if (DocProgram.GetFileNameTxt().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            string error_message = @"";
            bool cancel_download = false;

            string file_extensions = DocProgram.GetDocumentTemplate().TemplateExtensions; 
            if (!OpenSaveDialog.Download(DocProgram.GetFilePath(), DocProgram.GetFileNameTxt(), "txt", file_extensions, out cancel_download, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_download)
            {
                m_textbox_message.Text = DocAdminString.MsgFileDownloadCancelled;
                return;
            }

            m_textbox_message.Text = DocProgram.GetFileNameTxt() + DocAdminString.MsgFileDownloaded;

        } // m_button_download_txt_Click

        #endregion // Download functions

        #region Upload functions

        /// <summary>User clicked button upload doc</summary>
        private void m_button_upload_doc_Click(object sender, EventArgs e)
        {
            if (_CheckoutXml(DocProgram.GetFileNameDoc()))
                return;

            if (DocProgram.GetFileNameDoc().Length == 0)
            {
                string error_construct = @"";
                if (!DocProgram.ConstructAndSetFileNameDoc(out error_construct))
                {
                    m_textbox_message.Text = error_construct;
                    return;
                }

                m_text_box_file_name_doc.Text = DocProgram.GetFileNameDoc();

                DocProgram.SetCreateBackupDocument(false);
            }
            else
            {
                DocProgram.SetCreateBackupDocument(true);
            }

            string error_message = @"";
            bool cancel_upload = false;
            string out_file_name_upload = @""; // Output file extension may be changed in OpenSaveDialog.Upload for a new file

            string file_extensions = DocProgram.GetDocumentTemplate().TemplateExtensions;
            bool admin_file = false;
            if (!OpenSaveDialog.Upload(DocProgram.GetFilePath(), DocProgram.GetFileNameDoc(), "main", file_extensions, admin_file, DocProgram.GetCreateBackupDocument(), out cancel_upload, out out_file_name_upload, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_upload)
            {
                m_textbox_message.Text = DocAdminString.MsgFileUploadCancelled;
                return;
            }

            if (!out_file_name_upload.Equals(DocProgram.GetFileNameDoc()))
            {
                m_doc_data.FileNameDoc = out_file_name_upload;

                m_text_box_file_name_doc.Text = out_file_name_upload;

                m_textbox_message.Text = out_file_name_upload;
            }

            m_textbox_message.Text = out_file_name_upload + DocAdminString.MsgFileUploaded;

        } // m_button_upload_doc_Click

        /// <summary>User clicked button upload pdf</summary>
        private void m_button_upload_pdf_Click(object sender, EventArgs e)
        {
            if (_CheckoutXml(DocProgram.GetFileNamePdf()))
                return;

            if (DocProgram.GetFileNamePdf().Length == 0)
            {
                string error_construct = @"";
                if (!DocProgram.ConstructAndSetFileNamePdf(out error_construct))
                {
                    m_textbox_message.Text = error_construct;
                    return;
                }

                m_text_box_file_name_pdf.Text = DocProgram.GetFileNamePdf();

                DocProgram.SetCreateBackupDocument(false);
            }
            else
            {
                DocProgram.SetCreateBackupDocument(true);
            }

            string error_message = @"";
            bool cancel_upload = false;
            string out_file_name_upload = @""; // Output file extension may be changed in OpenSaveDialog.Upload for a new file

            string file_extensions = DocProgram.GetDocumentTemplate().TemplateExtensions;
            bool admin_file = false;
            if (!OpenSaveDialog.Upload(DocProgram.GetFilePath(), DocProgram.GetFileNamePdf(), "pdf", file_extensions, admin_file, DocProgram.GetCreateBackupDocument(), out cancel_upload, out out_file_name_upload, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_upload)
            {
                m_textbox_message.Text = DocAdminString.MsgFileUploadCancelled;
                return;
            }


            m_textbox_message.Text = DocProgram.GetFileNamePdf() + DocAdminString.MsgFileUploaded;

        } // m_button_upload_pdf_Click

        /// <summary>User clicked button upload txt</summary>
        private void m_button_upload_txt_Click(object sender, EventArgs e)
        {
            if (_CheckoutXml(DocProgram.GetFileNameTxt()))
                return;

            if (DocProgram.GetFileNameTxt().Length == 0)
            {
                string error_construct = @"";
                if (!DocProgram.ConstructAndSetFileNameTxt(out error_construct))
                {
                    m_textbox_message.Text = error_construct;
                    return;
                }

                m_text_box_file_name_txt.Text = DocProgram.GetFileNameTxt();

                DocProgram.SetCreateBackupDocument(false);
            }
            else
            {
                DocProgram.SetCreateBackupDocument(true);
            }
                
            string error_message = @"";
            bool cancel_upload = false;
            string out_file_name_upload = @""; // Output file extension may be changed in OpenSaveDialog.Upload for a new file
            string file_extensions = DocProgram.GetDocumentTemplate().TemplateExtensions;
            bool admin_file = false;
            if (!OpenSaveDialog.Upload(DocProgram.GetFilePath(), DocProgram.GetFileNameTxt(), "txt", file_extensions, admin_file, DocProgram.GetCreateBackupDocument(), out cancel_upload, out out_file_name_upload, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_upload)
            {
                m_textbox_message.Text = DocAdminString.MsgFileUploadCancelled;
                return;
            }


            m_textbox_message.Text = DocProgram.GetFileNameTxt() + DocAdminString.MsgFileUploaded;


        } // m_button_upload_txt_Click

        #endregion // Upload functions

        #region Delete functions

        /// <summary>User clicked button delete doc</summary>
        private void m_button_delete_doc_Click(object sender, EventArgs e)
        {
            if (DocProgram.GetFileNameDoc().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            if (_CheckoutDelete(DocProgram.GetFileNameDoc()))
                return;

            m_textbox_message.Text = DocProgram.GetFileNameDoc() + DocAdminString.MsgFileDeleted;

            string error_message = @"";
            if (!DocProgram.DeleteFileNameDoc(out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            
            m_text_box_file_name_doc.Text = @"";

        } // m_button_delete_doc_Click

        /// <summary>User clicked button delete pdf</summary>
        private void m_button_delete_pdf_Click(object sender, EventArgs e)
        {
            if (DocProgram.GetFileNamePdf().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            if (_CheckoutDelete(DocProgram.GetFileNamePdf()))
                return;

            m_textbox_message.Text = DocProgram.GetFileNamePdf() + DocAdminString.MsgFileDeleted;

            string error_message = @"";
            if (!DocProgram.DeleteFileNamePdf(out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

 
            m_text_box_file_name_pdf.Text = @"";

        } // m_button_delete_pdf_Click

        /// <summary>User clicked button delete txt</summary>
        private void m_button_delete_txt_Click(object sender, EventArgs e)
        {
            if (DocProgram.GetFileNameTxt().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            if (_CheckoutDelete(DocProgram.GetFileNameTxt()))
                return;

            m_textbox_message.Text = DocProgram.GetFileNameTxt() + DocAdminString.MsgFileDeleted;

            string error_message = @"";
            if (!DocProgram.DeleteFileNameTxt(out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            
            m_text_box_file_name_txt.Text = @"";

        } // m_button_delete_txt_Click

        #endregion // Delete functions

        #region Edit and exit functions

        /// <summary>User clicked the edit (checkout) button</summary>
        private void m_button_edit_concert_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                bool b_user_cancelled = false;
                m_doc_admin_form.CheckoutData(out b_user_cancelled);
                if (b_user_cancelled)
                {
                    return;
                }

                m_editable = true;
            }

            _SetCaptions();

            _SetEditable();

        } // m_button_edit_concert_data_Click

        /// <summary>User clicked button cancel</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked button close</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (m_editable)
            {
                string error_message = @"";
                if (!_WriteTexts(out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }
            }

            this.Close();

        } // m_button_close_Click

        #endregion // Edit and exit functions

        #region Generate text file

        /// <summary>User clicked button generate TXT season program</summary>
        private void m_button_generate_txt_Click(object sender, EventArgs e)
        {

            if (_CheckoutXml(DocProgram.GetFileNameTxt()))
                return;

            if (DocProgram.GetFileNameTxt().Length != 0)
            {
                if (!AdminUtils.MessageBoxYesNo(DocAdminString.MsgExistentTxtReplace, DocAdminString.TitleGenerateTxt))
                {
                    return;
                }
            }

            string file_name_txt = @"";
            string error_message = @"";
            if (!DocProgram.GenerateFileNameTxt(out file_name_txt, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            if (DocProgram.GetFileNameTxt().Length == 0)
            {
                DocProgram.SetFileNameTxt(file_name_txt);

                m_text_box_file_name_txt.Text = DocProgram.GetFileNameTxt();

                DocProgram.SetCreateBackupDocument(false);
            }
            else
            {
                DocProgram.SetCreateBackupDocument(true);
            }

            bool cancel_upload = false;
            string out_file_name_upload = @""; // Output file extension may be changed in OpenSaveDialog.Upload for a new file

            string file_extensions = DocProgram.GetDocumentTemplate().TemplateExtensions;
            bool admin_file = false;
            if (!OpenSaveDialog.Upload(DocProgram.GetFilePath(), DocProgram.GetFileNameTxt(), "txt", file_extensions, admin_file, DocProgram.GetCreateBackupDocument(), out cancel_upload, out out_file_name_upload, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_upload)
            {
                if (!DocProgram.GetCreateBackupDocument())
                {
                    DocProgram.SetFileNameTxt(@"");

                    m_text_box_file_name_txt.Text = DocProgram.GetFileNameTxt();
                }

                m_textbox_message.Text = DocAdminString.MsgFileUploadCancelled;

                return;
            }

            m_textbox_message.Text = DocProgram.GetFileNameTxt() + DocAdminString.MsgFileUploaded;

        } // m_button_generate_txt_Click

        #endregion // Generate text file

        #region Publish

        /// <summary>User clicked the publish check box</summary>
        private void m_check_box_publish_CheckedChanged(object sender, EventArgs e)
        {
            if (m_check_box_publish.Checked)
                DocProgram.SetPublished(true);
            else
                DocProgram.SetPublished(false);

        } // m_check_box_publish_CheckedChanged

        #endregion // Publish

    } // DocProgramForm
} // namespace
