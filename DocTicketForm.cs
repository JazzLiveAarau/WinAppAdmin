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
    /// <summary>Download and upload of the season program. THIS CLASS IS NO LONGER USED</summary>
    public partial class DocTicketForm : Form
    {
        /// <summary>The owner of this form</summary>
        private DocAdminForm m_doc_admin_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Constructor
        /// <para></para>
        /// </summary>
        /// <param name="i_doc_admin_form">The owner of this form</param>
        /// <param name="i_concert_ticket">Data about the concert ticket documents</param>
        /// <param name="i_doc_template">The template for the concert ticket documents</param>
        public DocTicketForm(DocAdminForm i_doc_admin_form, string i_band_name, JazzDoc i_concert_ticket, JazzDocTemplate i_doc_template)
        {

            InitializeComponent();

            if (null == i_doc_admin_form)
                return;

            m_doc_admin_form = i_doc_admin_form;

            DocTicket.SetBandName(i_band_name);

            if (null == i_concert_ticket)
                return;

            DocTicket.SetConcertTicket(i_concert_ticket);

            if (null == i_doc_template)
                return;

            DocTicket.SetDocumentTemplate(i_doc_template);

            _SetTexts();

            _SetEditable();

            _SetToolTips();

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            SetCaptions();

        } // Constructor


        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipDocTicketForm.SetToolTip(this, DocAdminString.ToolTipDocTicketForm);

            ToolTipDocTicketFormEdit.SetToolTip(m_button_edit_ticket_data, DocAdminString.ToolTipDocTicketFormEdit);
            ToolTipDocTicketFormCancel.SetToolTip(m_button_cancel, DocAdminString.ToolTipDocTicketFormCancel);
            ToolTipDocTicketFormClose.SetToolTip(m_button_close, DocAdminString.ToolTipDocTicketFormClose);

            ToolTipDocTicketFormCurrentSeason.SetToolTip(m_label_page_header, DocAdminString.ToolTipDocTicketFormCurrentSeason);
            ToolTipDocTicketFormCurrentSeason.SetToolTip(m_text_box_season_name, DocAdminString.ToolTipDocTicketFormCurrentSeason);
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

            ToolTipBandname.SetToolTip(m_text_box_concert, DocAdminString.ToolTipBandname);
            ToolTipBandname.SetToolTip(m_label_concert, DocAdminString.ToolTipBandname);

            ToolTipDocTicketFormMsg.SetToolTip(m_textbox_message, DocAdminString.ToolTipDocTicketFormMsg);

        } // SetToolTips


        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = DocAdminString.GetTitleFormDocument(DocAdminString.TitleDocTicketForm);
            this.m_label_page_header.Text = DocAdminString.TitleDocTicketForm;

            m_text_box_season_name.Text = DocTicket.GetDocSeasonYears();
            m_label_concert.Text = DocTicket.GetTitleConcert();
            m_text_box_concert.Text = DocTicket.GetBandName();
            m_text_box_file_name_doc.Text = DocTicket.GetFileNameDoc();
            m_text_box_file_name_pdf.Text = DocTicket.GetFileNamePdf();

            bool b_publish = DocTicket.GetPublished();
            if (b_publish)
                this.m_check_box_publish.Checked = true;
            else
                this.m_check_box_publish.Checked = false;

            m_label_publish.Text = DocAdminString.TitleLabelPublish;

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            if (!DocTicket.WriteConcertDoc(out o_error)) { return false; }

            return true;
        } // WriteTexts

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

        /// <summary>User clicked button download doc</summary>
        private void m_button_download_doc_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            if (DocTicket.GetFileNameDoc().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            string error_message = @"";
            bool cancel_download = false; 

            if (!OpenSaveDialog.Download(DocTicket.GetConcertDocumentsPath(), DocTicket.GetFileNameDoc(), DocTicket.GetDocumentTemplate(), "main", out cancel_download, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_download)
            {
                m_textbox_message.Text = DocAdminString.MsgFileDownloadCancelled;
                return;
            }

            m_textbox_message.Text = DocTicket.GetFileNameDoc() + DocAdminString.MsgFileDownloaded;

        } // m_button_download_doc_Click

        /// <summary>User clicked button download pdf</summary>
        private void m_button_download_pdf_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            if (DocTicket.GetFileNamePdf().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            string error_message = @"";
            bool cancel_download = false;

            if (!OpenSaveDialog.Download(DocTicket.GetConcertDocumentsPath(), DocTicket.GetFileNamePdf(), DocTicket.GetDocumentTemplate(), "pdf", out cancel_download, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_download)
            {
                m_textbox_message.Text = DocAdminString.MsgFileDownloadCancelled;
                return;
            }

            m_textbox_message.Text = DocTicket.GetFileNamePdf() + DocAdminString.MsgFileDownloaded;

        } // m_button_download_pdf_Click

        /// <summary>User clicked button upload doc</summary>
        private void m_button_upload_doc_Click(object sender, EventArgs e)
        {
            if (_CheckoutXml(DocTicket.GetFileNameDoc()))
                return;

            if (DocTicket.GetFileNameDoc().Length == 0)
            {
                string error_construct = @"";
                if (!DocTicket.ConstructAndSetFileNameDoc(out error_construct))
                {
                    m_textbox_message.Text = error_construct;
                    return;
                }

                m_text_box_file_name_doc.Text = DocTicket.GetFileNameDoc();

                DocTicket.SetCreateBackupDocument(false);
            }
            else
            {
                DocTicket.SetCreateBackupDocument(true);
            }

            string error_message = @"";
            bool cancel_upload = false;
            string out_file_name_upload = @""; // Output file extension may be changed in OpenSaveDialog.Upload for a new file

            if (!OpenSaveDialog.Upload(DocTicket.GetConcertDocumentsPath(), DocTicket.GetFileNameDoc(), DocTicket.GetDocumentTemplate(), "main", DocTicket.GetCreateBackupDocument(), out cancel_upload, out out_file_name_upload, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_upload)
            {
                m_textbox_message.Text = DocAdminString.MsgFileUploadCancelled;
                return;
            }


            m_textbox_message.Text = DocTicket.GetFileNameDoc() + DocAdminString.MsgFileUploaded;

        } // m_button_upload_doc_Click

        /// <summary>User clicked button upload pdf</summary>
        private void m_button_upload_pdf_Click(object sender, EventArgs e)
        {
            if (_CheckoutXml(DocTicket.GetFileNamePdf()))
                return;

            if (DocTicket.GetFileNamePdf().Length == 0)
            {
                string error_construct = @"";
                if (!DocTicket.ConstructAndSetFileNamePdf(out error_construct))
                {
                    m_textbox_message.Text = error_construct;
                    return;
                }

                m_text_box_file_name_pdf.Text = DocTicket.GetFileNamePdf();

                DocTicket.SetCreateBackupDocument(false);
            }
            else
            {
                DocTicket.SetCreateBackupDocument(true);
            }

            string error_message = @"";
            bool cancel_upload = false;
            string out_file_name_upload = @""; // Output file extension may be changed in OpenSaveDialog.Upload for a new file

            if (!OpenSaveDialog.Upload(DocTicket.GetConcertDocumentsPath(), DocTicket.GetFileNamePdf(), DocTicket.GetDocumentTemplate(), "pdf", DocTicket.GetCreateBackupDocument(), out cancel_upload, out out_file_name_upload, out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            if (cancel_upload)
            {
                m_textbox_message.Text = DocAdminString.MsgFileUploadCancelled;
                return;
            }


            m_textbox_message.Text = DocTicket.GetFileNamePdf() + DocAdminString.MsgFileUploaded;

        } // m_button_upload_pdf_Click


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


        /// <summary>User clicked button delete doc</summary>
        private void m_button_delete_doc_Click(object sender, EventArgs e)
        {
            if (DocTicket.GetFileNameDoc().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            if (_CheckoutDelete(DocTicket.GetFileNameDoc()))
                return;

            m_textbox_message.Text = DocTicket.GetFileNameDoc() + DocAdminString.MsgFileDeleted;

            string error_message = @"";
            if (!DocTicket.DeleteFileNameDoc(out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }


            m_text_box_file_name_doc.Text = @"";
        } // m_button_delete_doc_Click

        /// <summary>User clicked button delete pdf</summary>
        private void m_button_delete_pdf_Click(object sender, EventArgs e)
        {
            if (DocTicket.GetFileNamePdf().Length == 0)
            {
                m_textbox_message.Text = DocAdminString.ErrMsgDocFileIsNotOnServer;
                return;
            }

            if (_CheckoutDelete(DocTicket.GetFileNamePdf()))
                return;

            m_textbox_message.Text = DocTicket.GetFileNamePdf() + DocAdminString.MsgFileDeleted;

            string error_message = @"";
            if (!DocTicket.DeleteFileNamePdf(out error_message))
            {
                m_textbox_message.Text = error_message;
                return;
            }

            m_text_box_file_name_pdf.Text = @"";

        } // m_button_delete_pdf_Click

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

        /// <summary>User clicked the publish check box</summary>
        private void m_check_box_publish_CheckedChanged(object sender, EventArgs e)
        {
            if (m_check_box_publish.Checked)
                DocTicket.SetPublished(true);
            else
                DocTicket.SetPublished(false);

        } // m_check_box_publish_CheckedChanged

        /// <summary>User clicked the edit (checkout) button</summary>
        private void m_button_edit_ticket_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                m_doc_admin_form.CheckoutData();

                m_editable = true;
            }

            SetCaptions();

            _SetEditable();
        } // m_button_edit_ticket_data_Click

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
                if (!WriteTexts(out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }
            }

            this.Close();
        } // m_button_close_Click


    } // DocTicketForm
} // namespace
