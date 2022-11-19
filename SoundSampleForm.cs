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
    /// <summary>Form for the upload of a sound sample file
    /// <para>This is a Graphical User Interface class. Commands should not be executed in this class.</para>
    /// </summary>
    public partial class SoundSampleForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor that initializes the control elements
        /// <para>1. Set the m_editable parameter. Call of JazzLoginLogout.LoginLogout.DataCheckedOut
        /// (makes it possible to edit multiple concerts)</para>
        /// <para>2. Set member variables for upload of sound samples for the input concert number. Call of SoundSample.Init</para>
        /// <para>3. Set the controls. Call of _SetTitlesLabels, _SetControls, _SetToolTips, _SetCaptions and _SetEnabled</para>
        /// </summary>
        public SoundSampleForm(IndexForm i_index_form, int i_concert_number)
        {
            InitializeComponent();

            if (null == i_index_form)
                return;

            if (i_concert_number <= 0)
                return;

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            m_index_form = i_index_form;

            string error_msg = @"";

            if (!SoundSample.Init(i_concert_number, out error_msg))
            {
                MessageBox.Show("SoundSampleForm SoundSample.Init failed " + error_msg);

                return;
            }

            _SetTitlesLabels();

            _SetToolTips();

            _SetControls();

            _SetCaptions();

            _SetEnabled();

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set all controls</summary>
        private void _SetControls()
        {
            this.m_text_box_season_name.Text = SoundSample.GetSeasonName();

            this.m_text_box_concert_name.Text = SoundSample.GetBandName();

            this.m_text_box_file_name_audio.Text = SoundSample.DownloadSoundSampleFileName;

            this.m_text_box_file_name_qr_code.Text = SoundSample.DownloadSoundSampleQrCodeFileName;

            this.m_textbox_message.Text = @"";

        } // _SetControls

        /// <summary>Set titles and labels</summary>
        private void _SetTitlesLabels()
        {
            this.Text = XmlEditStrings.TitleSoundSampleForm;

            this.m_label_page_header.Text = XmlEditStrings.LabelSoundSampleForm;

            this.m_label_current_season.Text = DocAdminString.LabelCurrentSeason;

            this.m_label_current_concert.Text = DocAdminString.LabelCurrentConcert;

            this.m_text_box_audio.Text = XmlEditStrings.LabelSoundSampleAudio;

        } // _SetTitlesLabels

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set controls enabled or disabled
        /// <para>Do not display the download icon if link is undefined or not to a valid audio/video file. 
        /// Call of SoundSample.DisplayDownloadSoundFileIcon</para>
        /// </summary>
        private void _SetEnabled()
        {
            if (SoundSample.DisplayDownloadSoundFileIcon())
            {
                this.m_button_download_audio.Enabled = true;

                this.m_button_download_audio.Visible = true;
            }
            else
            {
                this.m_button_download_audio.Enabled = false;

                this.m_button_download_audio.Visible = false;
            }

            if (SoundSample.DisplayDownloadSoundQrIcon())
            {
                this.m_button_download_qr_code.Enabled = true;

                this.m_button_download_qr_code.Visible = true;
            }
            else
            {
                this.m_button_download_qr_code.Enabled = false;

                this.m_button_download_qr_code.Visible = false;
            }

        } // _SetEnabled

        #endregion // Set controls

        #region Tooltips

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipSoundSampleForm.SetToolTip(this, JazzAppAdminSettings.Default.ToolTipSoundSampleForm);
            ToolTipSoundSampleForm.SetToolTip(this.m_label_page_header, JazzAppAdminSettings.Default.ToolTipSoundSampleForm);
            ToolTipUtil.SetDelays(ref ToolTipSoundSampleForm);

            ToolTipSoundSampleEdit.SetToolTip(this.m_button_edit_musician_data, JazzAppAdminSettings.Default.ToolTipSoundSampleEdit);
            ToolTipUtil.SetDelays(ref ToolTipSoundSampleEdit);

            ToolTipSoundSampleDelete.SetToolTip(this.m_button_delete_audio, JazzAppAdminSettings.Default.ToolTipSoundSampleDelete);
            ToolTipUtil.SetDelays(ref ToolTipSoundSampleDelete);

            ToolTipSoundSampleCancel.SetToolTip(this.m_button_cancel, JazzAppAdminSettings.Default.ToolTipSoundSampleCancel);
            ToolTipUtil.SetDelays(ref ToolTipSoundSampleCancel);

            ToolTipSoundSampleClose.SetToolTip(this.m_button_close, JazzAppAdminSettings.Default.ToolTipSoundSampleClose);
            ToolTipUtil.SetDelays(ref ToolTipSoundSampleClose);

            ToolTipSoundSampleDownload.SetToolTip(this.m_button_download_audio, JazzAppAdminSettings.Default.ToolTipSoundSampleDownload);
            ToolTipUtil.SetDelays(ref ToolTipSoundSampleDownload);

            ToolTipSoundSampleDownloadQr.SetToolTip(this.m_button_download_qr_code, JazzAppAdminSettings.Default.ToolTipSoundSampleDownloadQr);
            ToolTipUtil.SetDelays(ref ToolTipSoundSampleDownloadQr);

            ToolTipSoundSampleUpload.SetToolTip(this.m_button_upload_audio, JazzAppAdminSettings.Default.ToolTipSoundSampleUpload);
            ToolTipUtil.SetDelays(ref ToolTipSoundSampleUpload);

        } // _SetToolTips

        #endregion // Tooltips

        #region Close and cancel events

        /// <summary>User clicked the button save or close
        /// <para>1. Close the news window if the news data not has been checked out.</para>
        /// <para>2. Write data to the XML object corresponding to file JazzNews.xml. Call of _WriteTexts.</para>
        /// <para>3. Save the file JazzNews.xml on the server and checkin news data. Call of _CheckinData.</para>
        /// <para>4. Close the news window.</para>
        /// </summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (m_editable)
            {
                string error_message = @"";
                if (!SoundSample.WriteSoundSample(out error_message))
                {
                    MessageBox.Show(error_message);

                    // return;
                }
            }

            this.Close();

        } // m_button_close_Click

        /// <summary>User clicked the button cancel
        /// </summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        } // m_button_cancel_Click

        #endregion // Close and cancel events

        #region Checkout and edit sound sample data

        /// <summary>User clicked the edit button.
        /// <para>1. Just return if the file already has been checked out</para>
        /// <para>2. Checkout data. Call of IndexForm.CheckoutData</para>
        /// <para>3. Enable controls. Call of _SetEnabled</para>
        /// </summary>
        private void m_button_edit_musician_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                m_index_form.CheckoutData();

                m_editable = true;

                _SetCaptions();

                _SetEnabled();

            }

        } // m_button_edit_musician_data_Click

        #endregion // Checkout and edit sound sample data

        #region Sound sample file events

        /// <summary>
        /// User clicked the button download sound sample file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_button_download_audio_Click(object sender, EventArgs e)
        {
            bool cancel_download = false;

            string error_msg = @"";

            this.m_textbox_message.Text = @"";

            if (!SoundSample.DownloadAudioVideoFile(out cancel_download, out error_msg))
            {

                this.m_textbox_message.Text = @"" + error_msg;

                return;
            }

            if (cancel_download)
            {
                this.m_textbox_message.Text = DocAdminString.MsgFileDownloadCancelled;

                return;
            }

            this.m_textbox_message.Text = SoundSample.DownloadSoundSampleFileName + DocAdminString.MsgFileDownloaded;

        } // m_button_download_audio_Click

        /// <summary>
        /// User clicked the button upload sound sample file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_button_upload_audio_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                string error_checkout = DocAdminString.ErrMsgCheckoutBeforeUpload;

                MessageBox.Show(error_checkout);

                return;
            }

            bool cancel_upload = false;

            string error_msg = @"";

            this.m_textbox_message.Text = @"";

            if (!SoundSample.UploadAudioVideoFile(out cancel_upload, out error_msg))
            {
                this.m_textbox_message.Text = @"" + error_msg;

                return;
            }

            if (cancel_upload)
            {
                this.m_textbox_message.Text = DocAdminString.MsgFileUploadCancelled;

                return;
            }

            this.m_text_box_file_name_audio.Text = SoundSample.UploadSoundSampleFileName;

            this.m_text_box_file_name_qr_code.Text = SoundSample.UploadSoundSampleQrCodeFileName;

            this.m_textbox_message.Text = SoundSample.UploadSoundSampleFileName + @" & " + 
                SoundSample.UploadSoundSampleQrCodeFileName + DocAdminString.MsgFileUploaded;

        } // m_button_upload_audio_Click

        /// <summary>
        /// User clicked the button delete sound sample file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_button_delete_audio_Click(object sender, EventArgs e)
        {

            if (SoundSample.DownloadSoundSampleFileName.Length == 0)
            {
                return;
            }

            if (!m_editable)
            {
                string error_checkout = DocAdminString.ErrMsgCheckoutBeforeDelete; 

                MessageBox.Show(error_checkout);

                return;
            }

            string error_msg = @"";

            this.m_textbox_message.Text = @"";

            if (!SoundSample.DeleteAudioVideoFile(out error_msg))
            {
                this.m_textbox_message.Text = @"" + error_msg;

                return;
            }

            this.m_textbox_message.Text = SoundSample.DownloadSoundSampleFileName + DocAdminString.MsgFileDeleted;

            this.m_text_box_file_name_audio.Text = SoundSample.GetSoundSampleToSaveUrl();

            this.m_text_box_file_name_qr_code.Text = SoundSample.GetSoundSampleQrCodeToSaveUrl();

        } // m_button_delete_audio_Click

        /// <summary>
        /// User clicked download sound sample QR code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_button_download_qr_code_Click(object sender, EventArgs e)
        {
            bool cancel_download = false;

            string error_msg = @"";

            this.m_textbox_message.Text = @"";

            if (!SoundSample.DownloadAudioVideoQrFile(out cancel_download, out error_msg))
            {
                this.m_textbox_message.Text = @"" + error_msg;

                return;
            }

            if (cancel_download)
            {
                this.m_textbox_message.Text = DocAdminString.MsgFileDownloadCancelled;

                return;
            }

            this.m_textbox_message.Text = SoundSample.DownloadSoundSampleQrCodeFileName + DocAdminString.MsgFileDownloaded;

        } // m_button_download_qr_code_Click

        #endregion // Sound sample file events

    } // SoundSampleForm

} // namespace
