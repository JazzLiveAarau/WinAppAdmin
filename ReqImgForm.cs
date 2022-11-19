using JazzApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Download and upload of an image (IMG) file
    /// <para>Please note that not only IMG files can be uploaded and dowloaded</para>
    /// <para></para>
    /// <para></para>
    /// </summary>
    public partial class ReqImgForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        RequestBandForm m_request_band_form = null;

        /// <summary>Form object for checkout</summary>
        private RequestForm m_request_form = null;

        /// <summary>Input JazzReq object</summary>
        JazzReq m_req = null;

        /// <summary>Photo file number 1-9</summary>
        int m_photo_file_number = -12345;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        /// <summary>Constructor
        /// <para>1. Sets the controls of the dialog</para>
        /// <para>2. Makes the controls editable if the XML file is checked out</para>
        /// <para>3. Sets the tool tips</para>
        /// <para>4. Sets the captions</para>
        /// </summary>
        /// <param name="i_request_band_form">Object RequestBandForm - the owner of this form</param>
        /// <param name="i_request_form">Form object for checkout</param>
        /// <param name="i_req">Object JazzReq</param>
        /// <param name="i_photo_file_number">Photo file number 1-9 </param>
        public ReqImgForm(RequestBandForm i_request_band_form, RequestForm i_request_form, JazzReq i_req, int i_photo_file_number)
        {
            InitializeComponent();

            if (null == i_request_band_form)
                return;

            m_request_band_form = i_request_band_form;

            if (null == i_request_form)
                return;

            m_request_form = i_request_form;

            if (null == i_req)
            {
                return;
            }

            m_req = i_req;

            if (i_photo_file_number < 1 || i_photo_file_number > 9)
            {
                return;
            }
            m_photo_file_number = i_photo_file_number;

            _SetTexts();

            _SetToolTips();

            // m_editable must be set before _SetCaptions() is called
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetCaptions();

        } // Constructor

        #region Set controls

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = RequestStrings.TitleRequestPdfForm;

            this.m_label_page_header.Text = RequestStrings.GetPhotoLabel(m_photo_file_number);

            m_text_box_file_name_img.Text = m_req.PhotoOne;
            if (2 == m_photo_file_number)
                m_text_box_file_name_img.Text = m_req.PhotoTwo;
            else if (3 == m_photo_file_number)
                m_text_box_file_name_img.Text = m_req.PhotoThree;
            else if (4 == m_photo_file_number)
                m_text_box_file_name_img.Text = m_req.PhotoFour;
            else if (5 == m_photo_file_number)
                m_text_box_file_name_img.Text = m_req.PhotoFive;
            else if (6 == m_photo_file_number)
                m_text_box_file_name_img.Text = m_req.PhotoSix;
            else if (7 == m_photo_file_number)
                m_text_box_file_name_img.Text = m_req.PhotoSeven;
            else if (8 == m_photo_file_number)
                m_text_box_file_name_img.Text = m_req.PhotoEight;
            else if (9 == m_photo_file_number)
                m_text_box_file_name_img.Text = m_req.PhotoNine;

            m_text_box_img.Text = @"IMG";

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {/*
            TitleRequestPdfForm.SetToolTip(this, RequestStrings.TitleRequestPdfForm);
            ToolTipUtil.SetDelays(ref TitleRequestPdfForm);

            ToolTipReqMainCheckinCheckout.SetToolTip(m_button_edit_request_data, RequestStrings.ToolTipReqMainCheckinCheckout);
            ToolTipUtil.SetDelays(ref ToolTipReqMainCheckinCheckout);

            ToolTipReqFormCancel.SetToolTip(m_button_cancel, RequestStrings.ToolTipReqFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipReqFormCancel);
            ToolTipReqFormClose.SetToolTip(m_button_close, RequestStrings.ToolTipReqFormClose);
            ToolTipUtil.SetDelays(ref ToolTipReqFormClose);

            ToolTipReqDownloadInfoFile.SetToolTip(m_button_download_htm, RequestStrings.ToolTipReqDownloadInfoFile);
            ToolTipUtil.SetDelays(ref ToolTipReqDownloadInfoFile);

            ToolTipReqUploadInfoFile.SetToolTip(m_button_upload_htm, RequestStrings.ToolTipReqUploadInfoFile);
            ToolTipUtil.SetDelays(ref ToolTipReqUploadInfoFile);

            ToolTipReqShowInfoFile.SetToolTip(m_text_box_file_name_pdf, RequestStrings.ToolTipReqShowInfoFile);
            ToolTipUtil.SetDelays(ref ToolTipReqShowInfoFile);

            ToolTipReqDeleteInfoFile.SetToolTip(m_button_delete_pdf, RequestStrings.ToolTipReqDeleteInfoFile);
            ToolTipUtil.SetDelays(ref ToolTipReqDeleteInfoFile);

            ToolTipReqFormMsg.SetToolTip(m_textbox_message, RequestStrings.ToolTipReqFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipReqFormMsg);
            */
        } // SetToolTips

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // _SetCaptions

        #endregion // Set controls

        /// <summary>Write file name (texts)</summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            if (!m_request_band_form.SetReqImgFiles(m_req, out o_error))
            {
                o_error = @"ReqPdfForm._WriteTexts RequestBandForm.SetReqImgFiles failed " + o_error;
                return false;
            }

            return true;
        } // _WriteTexts

        #region Event handling functions 

        /// <summary>User clicked the edit (checkout) button</summary>
        private void m_button_edit_request_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                bool b_user_cancelled = false;
                m_request_form.CheckoutData(out b_user_cancelled);
                if (b_user_cancelled)
                {
                    return;
                }

                m_editable = true;
            }

            _SetCaptions();

        } // m_button_edit_request_data_Click

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

        /// <summary>User clicked button download img</summary>
        private void m_button_download_img_Click(object sender, EventArgs e)
        {
            if (m_req.PhotoOne.Length == 0 && 1 == m_photo_file_number)
                return;
            else if (m_req.PhotoTwo.Length == 0 && 2 == m_photo_file_number)
                return;
            else if (m_req.PhotoThree.Length == 0 && 3 == m_photo_file_number)
                return;
            else if (m_req.PhotoFour.Length == 0 && 4 == m_photo_file_number)
                return;
            else if (m_req.PhotoFive.Length == 0 && 5 == m_photo_file_number)
                return;
            else if (m_req.PhotoSix.Length == 0 && 6 == m_photo_file_number)
                return;
            else if (m_req.PhotoSeven.Length == 0 && 7 == m_photo_file_number)
                return;
            else if (m_req.PhotoEight.Length == 0 && 8 == m_photo_file_number)
                return;
            else if (m_req.PhotoNine.Length == 0 && 9 == m_photo_file_number)
                return;

            string error_message = @"";
            bool cancel_download = false;

            if (!RequestBand.DownloadPhotoFile(m_req, m_photo_file_number, out cancel_download, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            if (cancel_download)
                return;
            string file_name = @"";

            if (!RequestBand.GetPhotoFileName(m_req, m_photo_file_number, out file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            m_textbox_message.Text = file_name + RequestStrings.MsgPhotoFileDownloaded;

        } // m_button_download_img_Click

        /// <summary>User clicked button upload img</summary>
        private void m_button_upload_img_Click(object sender, EventArgs e)
        {
            string error_message = @"";
            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgUploadOnlyAfterCheckout;
                MessageBox.Show(error_message);
                return;
            }

            bool cancel_upload = false;
            if (!RequestBand.UploadPhotoFile(ref m_req, m_photo_file_number, out cancel_upload, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            if (cancel_upload)
                return;

            string file_name = @"";
            if (!RequestBand.GetPhotoFileName(m_req, m_photo_file_number, out file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            m_textbox_message.Text = file_name + RequestStrings.MsgPhotoFileUploaded;

            m_text_box_file_name_img.Text = file_name;


        } // m_button_upload_img_Click

        /// <summary>User clicked button delete img</summary>
        private void m_button_delete_img_Click(object sender, EventArgs e)
        {
            string error_message = @"";
            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgDeleteOnlyAfterCheckout;
                MessageBox.Show(error_message);
                return;
            }

            if (!RequestBand.DeletePhotoFile(ref m_req, m_photo_file_number, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            m_textbox_message.Text = m_text_box_file_name_img.Text + RequestStrings.MsgPhotoFileDeleted;

            m_text_box_file_name_img.Text = @"";

        } // m_button_delete_img_Click

        #endregion // Event handling functions

    } // ReqImgForm
} // namespace
