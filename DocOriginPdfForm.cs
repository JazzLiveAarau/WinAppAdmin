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
    /// <summary>Download and upload of a doc jazz document
    /// <para>This dialog is for any doc document with a PDF copy.</para>
    /// <para></para>
    /// <para></para>
    /// <para>How to add this kind of document class is described in JAZZ_live_AARAU_Admin_Doc.rtf</para>
    /// </summary>
    public partial class DocOriginPdfForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private DocAdminForm m_doc_admin_form = null;

        /// <summary>Data about the document and execution functions</summary>
        private DocExeDocument m_doc_exe_document = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        /// <summary>Constructor
        /// <para>1. Sets the controls of the dialog</para>
        /// <para>2. Makes the controls editable if the XML file is checked out</para>
        /// <para>3. Sets the tool tips</para>
        /// <para>4. Sets the captions</para>
        /// </summary>
        /// <param name="i_doc_admin_form">The owner of this form</param>
        /// <param name="i_doc_exe_document">Object with data about the document and with execution functions</param>
        public DocOriginPdfForm(DocAdminForm i_doc_admin_form, DocExeDocument i_doc_exe_document)
        {
            InitializeComponent();

            if (null == i_doc_admin_form)
                return;

            m_doc_admin_form = i_doc_admin_form;

            if (null == i_doc_exe_document)
                return;

            m_doc_exe_document = i_doc_exe_document;

            _SetTexts();

            _SetToolTips();

            // m_editable must be set before _SetCaptions() and _SetEditable() are called
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetCaptions();

            _SetEditable();

        } // constructor

        /// <summary>Set dialog texts</summary>
        private void _SetTexts()
        {
            this.Text = m_doc_exe_document.GetTitleDocument();
            this.m_label_page_header.Text = m_doc_exe_document.GetTemplateDescription();

            m_text_box_season_name.Text = m_doc_exe_document.GetDocSeasonYears();
            m_text_box_file_name_doc.Text = m_doc_exe_document.GetFileNameDoc();
            m_text_box_file_name_pdf.Text = m_doc_exe_document.GetFileNamePdf();

            if (m_doc_exe_document.GetFileType().Equals("concert"))
            {
                // QQQ m_text_box_concert_name.Text = DocAdmin.GetCurrentBandName();
                m_text_box_concert_name.Text = DocAdmin.DocAll.ActiveBandName;
                m_label_current_concert.Text = DocAdminString.LabelCurrentConcert;
            }
            else
            {
                m_text_box_concert_name.Text = @"";
                m_label_current_concert.Text = @"";
                m_text_box_concert_name.Visible = false; ;
            }

            bool b_publish = m_doc_exe_document.GetPublished();
            if (b_publish)
                this.m_check_box_publish.Checked = true;
            else
                this.m_check_box_publish.Checked = false;

            m_label_publish.Text = DocAdminString.TitleLabelPublish;

            m_label_current_season.Text = DocAdminString.LabelCurrentSeason;

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipDocForm.SetToolTip(this, DocAdminString.ToolTipDocForm);
            ToolTipUtil.SetDelays(ref ToolTipDocForm);

            ToolTipDocFormEdit.SetToolTip(m_button_edit_concert_data, DocAdminString.ToolTipDocFormEdit);
            ToolTipUtil.SetDelays(ref ToolTipDocFormEdit);
            ToolTipDocFormCancel.SetToolTip(m_button_cancel, DocAdminString.ToolTipDocFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipDocFormCancel);
            ToolTipDocFormClose.SetToolTip(m_button_close, DocAdminString.ToolTipDocFormClose);
            ToolTipUtil.SetDelays(ref ToolTipDocFormClose);

            ToolTipDocFormCurrentSeason.SetToolTip(m_label_page_header, DocAdminString.ToolTipDocFormCurrentSeason);
            ToolTipDocFormCurrentSeason.SetToolTip(m_text_box_season_name, DocAdminString.ToolTipDocFormCurrentSeason);
            ToolTipUtil.SetDelays(ref ToolTipDocFormCurrentSeason);
            ToolTipDocPublish.SetToolTip(m_check_box_publish, DocAdminString.ToolTipDocPublish);
            ToolTipDocPublish.SetToolTip(m_label_publish, DocAdminString.ToolTipDocPublish);
            ToolTipUtil.SetDelays(ref ToolTipDocPublish);

            ToolTipDownLoadDoc.SetToolTip(m_button_download_doc, DocAdminString.ToolTipDownLoadDoc);
            ToolTipUtil.SetDelays(ref ToolTipDownLoadDoc);
            ToolTipDownLoadPdf.SetToolTip(m_button_download_pdf, DocAdminString.ToolTipDownLoadPdf);
            ToolTipUtil.SetDelays(ref ToolTipDownLoadPdf);

            ToolTipUpLoadDoc.SetToolTip(m_button_upload_doc, DocAdminString.ToolTipUpLoadDoc);
            ToolTipUtil.SetDelays(ref ToolTipUpLoadDoc);
            ToolTipUpLoadPdf.SetToolTip(m_button_upload_pdf, DocAdminString.ToolTipUpLoadPdf);
            ToolTipUtil.SetDelays(ref ToolTipUpLoadPdf);

            ToolTipDeleteDoc.SetToolTip(m_button_delete_doc, DocAdminString.ToolTipDeleteDoc);
            ToolTipUtil.SetDelays(ref ToolTipDeleteDoc);
            ToolTipDeletePdf.SetToolTip(m_button_delete_pdf, DocAdminString.ToolTipDeletePdf);
            ToolTipUtil.SetDelays(ref ToolTipDeletePdf);

            ToolTipFilenameDoc.SetToolTip(m_text_box_file_name_doc, DocAdminString.ToolTipFilenameDoc);
            ToolTipUtil.SetDelays(ref ToolTipFilenameDoc);
            ToolTipFilenamePdf.SetToolTip(m_text_box_file_name_pdf, DocAdminString.ToolTipFilenamePdf);
            ToolTipUtil.SetDelays(ref ToolTipFilenamePdf);

            ToolTipDocFormMsg.SetToolTip(m_textbox_message, DocAdminString.ToolTipDocFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipDocFormMsg);

        } // SetToolTips

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set controls editable or not</summary>
        private void _SetEditable()
        {
            m_doc_exe_document.SetPublishCheckBoxEditable(m_check_box_publish, m_editable);

        } // _SetEditable

        /// <summary>Write all texts for the current JazzDoc object. Call of DocExeDocument.WriteDoc</summary>
        private bool _WriteTexts(out string o_error)
        {
            if (!m_doc_exe_document.WriteDoc(out o_error))
            {
                return false;
            }

            return true;
        } // _WriteTexts

        #region Event handling functions 

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

        /// <summary>User clicked the publish check box</summary>
        private void m_check_box_publish_CheckedChanged(object sender, EventArgs e)
        {
            m_doc_exe_document.ExePublishCheckedChanged(m_check_box_publish);

        } // m_check_box_publish_CheckedChanged

        /// <summary>User clicked button download doc</summary>
        private void m_button_download_doc_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDownloadClick("doc", "main", m_textbox_message))
                return;

        } // m_button_download_doc_Click

        /// <summary>User clicked button download pdf</summary>
        private void m_button_download_pdf_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDownloadClick("pdf", "pdf", m_textbox_message))
                return;

        } // m_button_download_pdf_Click

        /// <summary>User clicked button upload doc</summary>
        private void m_button_upload_doc_Click(object sender, EventArgs e)
        {
            bool admin_file = false;
            if (!m_doc_exe_document.ExeUploadClick("doc", "main", admin_file, m_editable, m_text_box_file_name_doc, m_textbox_message))
                return;

        } // m_button_upload_doc_Click

        /// <summary>User clicked button upload pdf</summary>
        private void m_button_upload_pdf_Click(object sender, EventArgs e)
        {
            bool admin_file = false;
            if (!m_doc_exe_document.ExeUploadClick("pdf", "pdf", admin_file, m_editable, m_text_box_file_name_pdf, m_textbox_message))
                return;

        } // m_button_upload_pdf_Click

        /// <summary>User clicked button delete doc</summary>
        private void m_button_delete_doc_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDeleteClick("doc", m_editable, m_text_box_file_name_doc, m_textbox_message))
                return;

        } // m_button_delete_doc_Click

        /// <summary>User clicked button delete pdf</summary>
        private void m_button_delete_pdf_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDeleteClick("pdf", m_editable, m_text_box_file_name_pdf, m_textbox_message))
                return;

        } // m_button_delete_pdf_Click

        #endregion // Event handling functions 

    } // DocOriginPdfForm
} // namespace
