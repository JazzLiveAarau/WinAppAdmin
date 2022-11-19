using JazzApp;
using JazzFtp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Download and upload of a doc jazz document
    /// <para>This dialog is for any doc document with a PDF and a IMG copy.</para>
    /// <para></para>
    /// <para></para>
    /// <para>How to add this kind of document class is described in JAZZ_live_AARAU_Admin_Doc.rtf</para>
    /// </summary>
    public partial class DocDocPdfImgForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private DocAdminForm m_doc_admin_form = null;

        /// <summary>Data about the document and execution functions</summary>
        private DocExeDocument m_doc_exe_document = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor
        /// <para>1. Sets the controls of the dialog</para>
        /// <para>2. Makes the controls editable if the XML file is checked out</para>
        /// <para>3. Sets the tool tips</para>
        /// <para>4. Sets the captions</para>
        /// </summary>
        /// <param name="i_doc_admin_form">The owner of this form</param>
        /// <param name="i_doc_exe_document">Object with data about the document and with execution functions</param>
        public DocDocPdfImgForm(DocAdminForm i_doc_admin_form, DocExeDocument i_doc_exe_document)
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

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set dialog texts</summary>
        private void _SetTexts()
        {
            this.Text = m_doc_exe_document.GetTitleDocument();
            this.m_label_page_header.Text = m_doc_exe_document.GetTemplateDescription();

            m_text_box_season_name.Text = m_doc_exe_document.GetDocSeasonYears();
            m_text_box_file_name_doc.Text = m_doc_exe_document.GetFileNameDoc();
            m_text_box_file_name_pdf.Text = m_doc_exe_document.GetFileNamePdf();
            m_text_box_file_name_img.Text = m_doc_exe_document.GetFileNameImg();

            if (m_doc_exe_document.GetFileType().Equals("concert"))
            {
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
            ToolTipDocFormCancel.SetToolTip(m_button_cancel, DocAdminString.ToolTipDocFormCancel);
            ToolTipDocFormClose.SetToolTip(m_button_close, DocAdminString.ToolTipDocFormClose);
            ToolTipUtil.SetDelays(ref ToolTipDocFormEdit);
            ToolTipUtil.SetDelays(ref ToolTipDocFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipDocFormClose);

            ToolTipDocFormCurrentSeason.SetToolTip(m_label_page_header, DocAdminString.ToolTipDocFormCurrentSeason);
            ToolTipDocFormCurrentSeason.SetToolTip(m_text_box_season_name, DocAdminString.ToolTipDocFormCurrentSeason);
            ToolTipUtil.SetDelays(ref ToolTipDocFormCurrentSeason);
            ToolTipDocPublish.SetToolTip(m_check_box_publish, DocAdminString.ToolTipDocPublish);
            ToolTipDocPublish.SetToolTip(m_label_publish, DocAdminString.ToolTipDocPublish);
            ToolTipUtil.SetDelays(ref ToolTipDocPublish);

            ToolTipDownLoadDoc.SetToolTip(m_button_download_doc, DocAdminString.ToolTipDownLoadDoc);
            ToolTipDownLoadPdf.SetToolTip(m_button_download_pdf, DocAdminString.ToolTipDownLoadPdf);
            ToolTipDownLoadImg.SetToolTip(m_button_download_img, DocAdminString.ToolTipDownLoadImg);
            ToolTipUtil.SetDelays(ref ToolTipDownLoadDoc);
            ToolTipUtil.SetDelays(ref ToolTipDownLoadPdf);
            ToolTipUtil.SetDelays(ref ToolTipDownLoadImg);

            ToolTipUpLoadDoc.SetToolTip(m_button_upload_doc, DocAdminString.ToolTipUpLoadDoc);
            ToolTipUpLoadPdf.SetToolTip(m_button_upload_pdf, DocAdminString.ToolTipUpLoadPdf);
            ToolTipUpLoadImg.SetToolTip(m_button_upload_img, DocAdminString.ToolTipUpLoadImg);
            ToolTipUtil.SetDelays(ref ToolTipUpLoadDoc);
            ToolTipUtil.SetDelays(ref ToolTipUpLoadPdf);
            ToolTipUtil.SetDelays(ref ToolTipUpLoadImg);

            ToolTipDeleteDoc.SetToolTip(m_button_delete_xls, DocAdminString.ToolTipDeleteXls);
            ToolTipDeletePdf.SetToolTip(m_button_delete_pdf, DocAdminString.ToolTipDeletePdf);
            ToolTipDeleteImg.SetToolTip(m_button_delete_img, DocAdminString.ToolTipDeleteImg);
            ToolTipUtil.SetDelays(ref ToolTipDeleteDoc);
            ToolTipUtil.SetDelays(ref ToolTipDeletePdf);
            ToolTipUtil.SetDelays(ref ToolTipDeleteImg);

            ToolTipFilenameDoc.SetToolTip(m_text_box_file_name_doc, DocAdminString.ToolTipFilenameDoc);
            ToolTipFilenamePdf.SetToolTip(m_text_box_file_name_pdf, DocAdminString.ToolTipFilenamePdf);
            ToolTipFilenameImg.SetToolTip(m_text_box_file_name_img, DocAdminString.ToolTipFilenameImg);
            ToolTipUtil.SetDelays(ref ToolTipFilenameDoc);
            ToolTipUtil.SetDelays(ref ToolTipFilenamePdf);
            ToolTipUtil.SetDelays(ref ToolTipFilenameImg);

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

        #endregion // Set controls

        #region Write

        /// <summary>Write all texts for the current JazzDoc object. Call of DocExeDocument.WriteDoc</summary>
        private bool _WriteTexts(out string o_error)
        {
            if (!m_doc_exe_document.WriteDoc(out o_error))
            {
                return false;
            }

            return true;
        } // _WriteTexts

        #endregion // Write

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

        /// <summary>User clicked the cancel button.</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked the Save/Close button. If checked out (m_editable) data will be saved to the XML object corresponding to JazzDokumente_20xx_20yy.xml</summary>
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

        private void m_check_box_publish_CheckedChanged(object sender, EventArgs e)
        {
            m_doc_exe_document.ExePublishCheckedChanged(m_check_box_publish);

        } // m_check_box_publish_CheckedChanged

        private void m_button_download_doc_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDownloadClick("doc", "main", m_textbox_message))
                return;

        } // m_button_download_doc_Click

        private void m_button_download_pdf_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDownloadClick("pdf", "pdf", m_textbox_message))
                return;

        } // m_button_download_pdf_Click

        private void m_button_download_img_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDownloadClick("img", "img", m_textbox_message))
                return;

        } // m_button_download_img_Click

        private void m_button_upload_doc_Click(object sender, EventArgs e)
        {
            bool admin_file = false;
            if (!m_doc_exe_document.ExeUploadClick("doc", "main", admin_file, m_editable, m_text_box_file_name_doc, m_textbox_message))
                return;

        } // m_button_upload_doc_Click

        private void m_button_upload_pdf_Click(object sender, EventArgs e)
        {
            bool admin_file = false;
            if (!m_doc_exe_document.ExeUploadClick("pdf", "pdf", admin_file, m_editable, m_text_box_file_name_pdf, m_textbox_message))
                return;

        } // m_button_upload_pdf_Click

        /// <summary>
        /// User clicked the button upload the poster image
        /// <para>1. Upload the poster image. Call of DocExeDocument.ExeUploadClick</para>
        /// <para>2. Get image file server directory and name. Call of DocExeDocument.GetConcertDocumentsPath and .GetFileNameImg</para>
        /// <para>3. Create the poster images for the homepage/app and for Newsletter. Call of Website.CreateUploadPosterNewsletterImages</para>
        /// <para>Please note that </para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_button_upload_img_Click(object sender, EventArgs e)
        {
            bool admin_file = false;
            if (!m_doc_exe_document.ExeUploadClick("img", "img", admin_file, m_editable, m_text_box_file_name_img, m_textbox_message))
                return;


            JazzDoc active_doc = m_doc_exe_document.GetDocumentData();

            string error_msg = @"";

            SeasonDocInterface season_doc = new SeasonDocInterface();

            if (!season_doc.InitUseActiveDoc(out error_msg))
            {
                error_msg = @"SeasonDocInterface.Init failed " + error_msg;

                m_textbox_message.Text = m_textbox_message.Text + @" ERROR: Die kleine Homepage-Plakate sind nicht kreiert";

                MessageBox.Show(error_msg);

                return;
            }

            bool b_poster = false;

            if (!season_doc.CreateUploadUpdateXmlPosterNewsletterImages(active_doc, out b_poster, out error_msg))
            {
                error_msg = @"SeasonDocInterface.CreateUploadUpdateXmlPosterNewsletterImages failed " + error_msg;

                m_textbox_message.Text = m_textbox_message.Text + @" ERROR: Die kleine Homepage-Plakate sind nicht kreiert";

                MessageBox.Show(error_msg);

                return;
            }
     
            string output_msg = active_doc.FileNameImg + @" ist auf dem Server gespeichert";

            if (b_poster)
            {
                output_msg = active_doc.FileNameImg + @" und Homepage Plakate sind auf dem Server gespeichert";
            }

            m_textbox_message.Text = output_msg;

        } // m_button_upload_img_Click

        private void m_button_delete_doc_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDeleteClick("doc", m_editable, m_text_box_file_name_doc, m_textbox_message))
                return;

        } // m_button_delete_doc_Click

        private void m_button_delete_pdf_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDeleteClick("pdf", m_editable, m_text_box_file_name_pdf, m_textbox_message))
                return;

        } // m_button_delete_pdf_Click

        private void m_button_delete_img_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDeleteClick("img", m_editable, m_text_box_file_name_img, m_textbox_message))
                return;

        } // m_button_delete_img_Click

        #endregion // Event handling functions 

    } // DocDocPdfImgForm
} // namespace
