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
    /// <summary>Download and upload of the season letter
    /// <para>How to add this document class is described in JAZZ_live_AARAU_Admin_Doc.rtf</para>
    /// </summary>
    public partial class DocLetterForm : Form
    {
        /// <summary>The owner of this form</summary>
        private DocAdminForm m_doc_admin_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Constructor
        /// <para>1. Sets the season letter data of the static DocLetter object (calls DocLetter.SetSeasonProgram)</para>
        /// <para>2. Sets the season letter template data of the static DocLetter object (calls DocLetter.SetDocumentTemplate)</para>
        /// <para>3. Sets the controls of the dialog</para>
        /// <para>4. Makes the controls editable if the XML file is checked out</para>
        /// <para>5. Sets the tool tips</para>
        /// <para>6. Sets the captions</para>
        /// </summary>
        /// <param name="i_doc_admin_form">The owner of this form</param>
        /// <param name="i_doc_data">Data about the season letter document</param>
        /// <param name="i_doc_template">The template for the season letter document</param>
        public DocLetterForm(DocAdminForm i_doc_admin_form, JazzDoc i_doc_data, JazzDocTemplate i_doc_template)
        {
            InitializeComponent();

            if (null == i_doc_admin_form)
                return;

            m_doc_admin_form = i_doc_admin_form;

            if (null == i_doc_data)
                return;

            DocLetter.SetDocumentData(i_doc_data);

            if (null == i_doc_template)
                return;

            DocLetter.SetDocumentTemplate(i_doc_template);

            _SetTexts();

            _SetToolTips();

            _SetCaptions();

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetEditable();

        } // DocLetterForm

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipDocLetterForm.SetToolTip(this, DocAdminString.ToolTipDocLetterForm);

            ToolTipDocLetterFormEdit.SetToolTip(m_button_edit_concert_data, DocAdminString.ToolTipDocLetterFormEdit);
            ToolTipDocLetterFormCancel.SetToolTip(m_button_cancel, DocAdminString.ToolTipDocLetterFormCancel);
            ToolTipDocLetterFormClose.SetToolTip(m_button_close, DocAdminString.ToolTipDocLetterFormClose);

            ToolTipDocLetterFormCurrentSeason.SetToolTip(m_label_page_header, DocAdminString.ToolTipDocLetterFormCurrentSeason);
            ToolTipDocLetterFormCurrentSeason.SetToolTip(m_text_box_season_name, DocAdminString.ToolTipDocLetterFormCurrentSeason);
            ToolTipDocPublish.SetToolTip(m_check_box_publish, DocAdminString.ToolTipDocPublish);
            ToolTipDocPublish.SetToolTip(m_label_publish, DocAdminString.ToolTipDocPublish);

            ToolTipDownLoadDoc.SetToolTip(m_button_download_doc, DocAdminString.ToolTipDownLoadDoc);
            ToolTipDownLoadPdf.SetToolTip(m_button_download_pdf, DocAdminString.ToolTipDownLoadPdf);

            ToolTipUpLoadDoc.SetToolTip(m_button_upload_doc, DocAdminString.ToolTipUpLoadDoc);
            ToolTipUpLoadPdf.SetToolTip(m_button_upload_pdf, DocAdminString.ToolTipUpLoadPdf);

            ToolTipDeleteDoc.SetToolTip(m_button_delete_doc, DocAdminString.ToolTipDeleteDoc);
            ToolTipDeletePdf.SetToolTip(m_button_delete_pdf, DocAdminString.ToolTipDeletePdf);

            ToolTipFilenameDoc.SetToolTip(m_text_box_file_name_doc, DocAdminString.ToolTipFilenameDoc);
            ToolTipFilenamePdf.SetToolTip(m_text_box_file_name_pdf, DocAdminString.ToolTipFilenamePdf);

            ToolTipDocLetterFormMsg.SetToolTip(m_textbox_message, DocAdminString.ToolTipDocLetterFormMsg);

        } // SetToolTips

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = DocAdminString.GetTitleFormDocument(DocAdminString.TitleDocLetterForm);
            this.m_label_page_header.Text = DocAdminString.TitleDocLetterForm;

            m_text_box_season_name.Text = DocLetter.GetDocSeasonYears();
            m_text_box_file_name_doc.Text = DocLetter.GetFileNameDoc();
            m_text_box_file_name_pdf.Text = DocLetter.GetFileNamePdf();
 
            bool b_publish = DocLetter.GetPublished();
            if (b_publish)
                this.m_check_box_publish.Checked = true;
            else
                this.m_check_box_publish.Checked = false;

            m_label_publish.Text = DocAdminString.TitleLabelPublish;

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

        /// <summary>Write texts</summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            if (!DocLetter.WriteSeasonDoc(out o_error)) { return false; }

            return true;
        } // _WriteTexts

        #region Checkout functions

        /// <summary>Returns true if it is necessary to checkout the XML file
        /// <para>The user will get a message (message box) if checkout is necessary</para>
        /// <para>The message text control is cleaned</para>
        /// </summary>
        /// <param name="i_file_name">Document file name</param>
        private bool _CheckoutXml(string i_file_name)
        {
            m_textbox_message.Text = @"";

            if (i_file_name.Length == 0 && !m_editable)
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

        #region Event handling functions 

        /// <summary>User clicked the edit (checkout) button</summary>
        private void m_button_edit_concert_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                m_doc_admin_form.CheckoutData();

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

        /// <summary>User clicked the publish check box</summary>
        private void m_check_box_publish_CheckedChanged(object sender, EventArgs e)
        {
            if (m_check_box_publish.Checked)
                DocLetter.SetPublished(true);
            else
                DocLetter.SetPublished(false);

        } // m_check_box_publish_CheckedChanged

        /// <summary>User clicked button download doc</summary>
        private void m_button_download_doc_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            if (DocLetter.GetFileNameDoc().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            string error_message = @"";
            bool cancel_download = false;

            if (!OpenSaveDialog.Download(DocLetter.GetFilePath(), DocLetter.GetFileNameDoc(), DocLetter.GetDocumentTemplate(), "main", out cancel_download, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_download)
            {
                m_textbox_message.Text = DocAdminString.MsgFileDownloadCancelled;
                return;
            }

            m_textbox_message.Text = DocLetter.GetFileNameDoc() + DocAdminString.MsgFileDownloaded;

        } // m_button_download_doc_Click

        /// <summary>User clicked button download pdf</summary>
        private void m_button_download_pdf_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            if (DocLetter.GetFileNamePdf().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            string error_message = @"";
            bool cancel_download = false;

            if (!OpenSaveDialog.Download(DocLetter.GetFilePath(), DocLetter.GetFileNamePdf(), DocLetter.GetDocumentTemplate(), "pdf", out cancel_download, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_download)
            {
                m_textbox_message.Text = DocAdminString.MsgFileDownloadCancelled;
                return;
            }

            m_textbox_message.Text = DocLetter.GetFileNamePdf() + DocAdminString.MsgFileDownloaded;

        } // m_button_download_pdf_Click

        /// <summary>User clicked button upload doc</summary>
        private void m_button_upload_doc_Click(object sender, EventArgs e)
        {
            if (_CheckoutXml(DocLetter.GetFileNameDoc()))
                return;

            if (DocLetter.GetFileNameDoc().Length == 0)
            {
                string error_construct = @"";
                if (!DocLetter.ConstructAndSetFileNameDoc(out error_construct))
                {
                    m_textbox_message.Text = error_construct;
                    return;
                }

                m_text_box_file_name_doc.Text = DocLetter.GetFileNameDoc();

                DocLetter.SetCreateBackupDocument(false);
            }
            else
            {
                DocLetter.SetCreateBackupDocument(true);
            }

            string error_message = @"";
            bool cancel_upload = false;

            if (!OpenSaveDialog.Upload(DocLetter.GetFilePath(), DocLetter.GetFileNameDoc(), DocLetter.GetDocumentTemplate(), "main", DocLetter.GetCreateBackupDocument(), out cancel_upload, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_upload)
            {
                m_textbox_message.Text = DocAdminString.MsgFileUploadCancelled;
                return;
            }


            m_textbox_message.Text = DocLetter.GetFileNameDoc() + DocAdminString.MsgFileUploaded;

        } // m_button_upload_doc_Click

        /// <summary>User clicked button upload pdf</summary>
        private void m_button_upload_pdf_Click(object sender, EventArgs e)
        {
            if (_CheckoutXml(DocLetter.GetFileNamePdf()))
                return;

            if (DocLetter.GetFileNamePdf().Length == 0)
            {
                string error_construct = @"";
                if (!DocLetter.ConstructAndSetFileNamePdf(out error_construct))
                {
                    m_textbox_message.Text = error_construct;
                    return;
                }

                m_text_box_file_name_pdf.Text = DocLetter.GetFileNamePdf();

                DocLetter.SetCreateBackupDocument(false);
            }
            else
            {
                DocLetter.SetCreateBackupDocument(true);
            }

            string error_message = @"";
            bool cancel_upload = false;

            if (!OpenSaveDialog.Upload(DocLetter.GetFilePath(), DocLetter.GetFileNamePdf(), DocLetter.GetDocumentTemplate(), "pdf", DocLetter.GetCreateBackupDocument(), out cancel_upload, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_upload)
            {
                m_textbox_message.Text = DocAdminString.MsgFileUploadCancelled;
                return;
            }


            m_textbox_message.Text = DocLetter.GetFileNamePdf() + DocAdminString.MsgFileUploaded;

        } // m_button_upload_pdf_Click

        /// <summary>User clicked button delete doc</summary>
        private void m_button_delete_doc_Click(object sender, EventArgs e)
        {
            if (DocLetter.GetFileNameDoc().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            if (_CheckoutDelete(DocLetter.GetFileNameDoc()))
                return;

            m_textbox_message.Text = DocLetter.GetFileNameDoc() + DocAdminString.MsgFileDeleted;

            string error_message = @"";
            if (!DocLetter.DeleteFileNameDoc(out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }


            m_text_box_file_name_doc.Text = @"";

        } // m_button_delete_doc_Click

        /// <summary>User clicked button delete pdf</summary>
        private void m_button_delete_pdf_Click(object sender, EventArgs e)
        {
            if (DocLetter.GetFileNamePdf().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            if (_CheckoutDelete(DocLetter.GetFileNamePdf()))
                return;

            m_textbox_message.Text = DocLetter.GetFileNamePdf() + DocAdminString.MsgFileDeleted;

            string error_message = @"";
            if (!DocLetter.DeleteFileNamePdf(out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            m_text_box_file_name_pdf.Text = @"";

        } // m_button_delete_pdf_Click

        #endregion // Event handling functions 

    } // DocLetterForm
} // namespace
