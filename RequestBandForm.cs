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
    /// <summary>Form for the editing of a request (to play in the jazz club)
    /// <para>This is Graphical User Interface class. Commands should not be executed in this class.</para>
    /// </summary>
    public partial class RequestBandForm : Form
    {
        #region Member variables

        /// <summary>Owner of this dialog</summary>
        RequestForm m_request_form = null;

        /// <summary>Object JazzReq with data bout the request</summary>
        JazzReq m_band_req = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Flag telling if the dialog combo boxes have been initialized</summary>
        private bool m_dialog_comboboxes_initialized = false;

        /// <summary>Set member variable JazzReq m_band_req for parameters changed/set by ReqPdfForm
        /// <para>This function will be called by the write function of ReqPdfForm </para>
        /// <para></para>
        /// </summary>
        /// <param name="i_info_files_req">Object JazzReq from ReqPdfForm</param>
        /// <param name="o_error">Error message</param>
        public bool SetReqInfoFile(JazzReq i_info_files_req, out string o_error)
        {
            o_error = @"";

            if (m_band_req == null)
            {
                o_error = @"RequestBandForm.SetReqInfoFile m_band_req is null";
                return false;
            }

            if (i_info_files_req == null)
            {
                o_error = @"RequestBandForm.SetReqInfoFile i_info_files_req is null";
                return false;
            }

            m_band_req.InfoOne = i_info_files_req.InfoOne;
            m_band_req.InfoTwo = i_info_files_req.InfoTwo;
            m_band_req.InfoThree = i_info_files_req.InfoThree;

            return true;

        } // SetReqInfoFile

        /// <summary>Set member variable JazzReq m_band_req for parameters changed/set by ReqDateForm
        /// <para>This function will be called by the write function of ReqDateForm </para>
        /// <para></para>
        /// </summary>
        /// <param name="i_date_req">Object JazzReq from ReqDateForm</param>
        /// <param name="o_error">Error message</param>
        public bool SetReqDate(JazzReq i_date_req, out string o_error)
        {
            o_error = @"";

            if (m_band_req == null)
            {
                o_error = @"RequestBandForm.SetReqDate m_band_req is null";
                return false;
            }

            if (i_date_req == null)
            {
                o_error = @"RequestBandForm.SetReqDate i_date_req is null";
                return false;
            }

            m_band_req.RegYear = i_date_req.RegYear;
            m_band_req.RegMonth = i_date_req.RegMonth;
            m_band_req.RegDay = i_date_req.RegDay;

            return true;

        } // SetReqDate

        /// <summary>Set member variable JazzReq m_band_req for parameters changed/set by ReqImgForm
        /// <para>This function will be called by the write function of ReqPdfForm </para>
        /// <para></para>
        /// </summary>
        /// <param name="i_info_photo_req">Object JazzReq from ReqImgForm</param>
        /// <param name="o_error">Error message</param>
        public bool SetReqImgFiles(JazzReq i_photo_req, out string o_error)
        {
            o_error = @"";

            if (m_band_req == null)
            {
                o_error = @"RequestBandForm.SetReqImgFiles m_band_req is null";
                return false;
            }

            if (i_photo_req == null)
            {
                o_error = @"RequestBandForm.SetReqImgFiles i_photo_req is null";
                return false;
            }

            m_band_req.PhotoOne = i_photo_req.PhotoOne;
            m_band_req.PhotoTwo = i_photo_req.PhotoTwo;
            m_band_req.PhotoThree = i_photo_req.PhotoThree;
            m_band_req.PhotoFour = i_photo_req.PhotoFour;
            m_band_req.PhotoFive = i_photo_req.PhotoFive;
            m_band_req.PhotoSix = i_photo_req.PhotoSix;
            m_band_req.PhotoSeven = i_photo_req.PhotoSeven;
            m_band_req.PhotoEight = i_photo_req.PhotoEight;
            m_band_req.PhotoNine = i_photo_req.PhotoNine;

            return true;

        } // SetReqImgFiles

        /// <summary>Set member variable JazzReq m_band_req for parameters changed/set by ReqLinksForm
        /// <para>This function will be called by the write function of ReqLinksForm </para>
        /// <para></para>
        /// </summary>
        /// <param name="i_info_files_req">Object JazzReq from ReqLinksForm</param>
        /// <param name="o_error">Error message</param>
        public bool SetReqLinks(JazzReq i_links_req, out string o_error)
        {
            o_error = @"";

            if (m_band_req == null)
            {
                o_error = @"RequestBandForm.SetReqLinks m_band_req is null";
                return false;
            }

            if (i_links_req == null)
            {
                o_error = @"RequestBandForm.SetReqLinks i_links_req is null";
                return false;
            }

            m_band_req.LinkOne = i_links_req.LinkOne;
            m_band_req.LinkTwo = i_links_req.LinkTwo;
            m_band_req.LinkThree = i_links_req.LinkThree;
            m_band_req.LinkFour = i_links_req.LinkFour;
            m_band_req.LinkFive = i_links_req.LinkFive;
            m_band_req.LinkSix = i_links_req.LinkSix;
            m_band_req.LinkSeven = i_links_req.LinkSeven;
            m_band_req.LinkEight = i_links_req.LinkEight;
            m_band_req.LinkNine = i_links_req.LinkNine;

            m_band_req.LinkTextOne = i_links_req.LinkTextOne;
            m_band_req.LinkTextTwo = i_links_req.LinkTextTwo;
            m_band_req.LinkTextThree = i_links_req.LinkTextThree;
            m_band_req.LinkTextFour = i_links_req.LinkTextFour;
            m_band_req.LinkTextFive = i_links_req.LinkTextFive;
            m_band_req.LinkTextSix = i_links_req.LinkTextSix;
            m_band_req.LinkTextSeven = i_links_req.LinkTextSeven;
            m_band_req.LinkTextEight = i_links_req.LinkTextEight;
            m_band_req.LinkTextNine = i_links_req.LinkTextNine;

            m_band_req.LinkTypeOne = i_links_req.LinkTypeOne;
            m_band_req.LinkTypeTwo = i_links_req.LinkTypeTwo;
            m_band_req.LinkTypeThree = i_links_req.LinkTypeThree;
            m_band_req.LinkTypeFour = i_links_req.LinkTypeFour;
            m_band_req.LinkTypeFive = i_links_req.LinkTypeFive;
            m_band_req.LinkTypeSix = i_links_req.LinkTypeSix;
            m_band_req.LinkTypeSeven = i_links_req.LinkTypeSeven;
            m_band_req.LinkTypeEight = i_links_req.LinkTypeEight;
            m_band_req.LinkTypeNine = i_links_req.LinkTypeNine;

            return true;

        } // SetReqLinks

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor that initializes all controls
        /// <para></para>
        /// </summary>
        /// <param name="i_request_form">Owner of this dialog</param>
        /// <param name="i_band_req">Object JazzReq that can be edited or deleted</param>
        public RequestBandForm(RequestForm i_request_form, JazzReq i_band_req)
        {
            InitializeComponent();

            string error_message = @"";

            if (null == i_request_form)
            {
                error_message = @"RequestBandForm.Constructor Input RequestForm is null";
                MessageBox.Show(error_message);
                return;
            }

            m_request_form = i_request_form;

            if (null == i_band_req)
            {
                error_message = @"RequestBandForm.Constructor Input JazzReq is null";
                MessageBox.Show(error_message);
                return;
            }

            m_band_req = i_band_req;

            // m_editable must be set before _SetCaptions() and _SetEditable() are called
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetTitles();

            _SetTexts();

            _SetToolTips();

            _SetComboBoxes();

            _SetCaptions();

            _SetEditable();

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set titles</summary>
        private void _SetTitles()
        {
            this.Text = RequestStrings.TitleRequestBandForm;

            _SetDateAndRegNumber();

            m_label_name.Text = RequestStrings.LabelBandName;

            m_label_comments.Text = RequestStrings.LabelComments;

            m_label_private_notes.Text = RequestStrings.LabelPrivateNotes;

            m_label_evaluate_band.Text = RequestStrings.LabelForEvaluation;

            this.m_textbox_message.Text = @"";

        } // _SetTitles

        /// <summary>Set request date and number</summary>
        private void _SetDateAndRegNumber()
        {
            string error_message = @"";
            if (!RequestBand.SetDateAndRegnumber(m_band_req, m_button_reg_date_number, null, out error_message))
            {
                error_message = @"RequestBandForm._SetTitles RequestBand.SetDateAndRegnumber failed " + error_message;
                MessageBox.Show(error_message);
                return;
            }
        } // _SetDateAndRegNumber

        /// <summary>Set texts from the input JazzReq (m_band_req)</summary>
        private void _SetTexts()
        {
            m_text_box_band_name.Text = m_band_req.BandName;
            m_rich_text_box_comments.Text = m_band_req.Comments;
            m_text_box_sound_sample.Text = m_band_req.SoundSample;
            m_text_box_www_band.Text = m_band_req.BandWebsite;
            this.m_label_info_files.Text = RequestStrings.LabelInformation;

            m_label_concert_number.Text = RequestStrings.LabelConcertNumber;

            string error_message = @"";
            if (!RequestBand.ReadPrivateNotes(ref m_band_req, out error_message))
            {
                error_message = @"RequestBandForm._SetTexts " + error_message;
                return;
            }
            m_rich_text_box_private_notes.Text = m_band_req.PrivateNotes;

            if (m_band_req.ToBeEvaluatedBoolean)
            {
                m_check_box_evaluate_band.Checked = true;
            }
            else
            {
                m_check_box_evaluate_band.Checked = false;
            }

        } // _SetTexts

        /// <summary>Set audio und info combo boxes</summary>
        private void _SetComboBoxes()
        {
            m_dialog_comboboxes_initialized = false;

            RequestBand.SetComboboxAudioOne(m_band_req, this.m_combo_box_audio_1);
            RequestBand.SetComboboxAudioTwo(m_band_req, this.m_combo_box_audio_2);
            RequestBand.SetComboboxAudioThree(m_band_req, this.m_combo_box_audio_3);
            RequestBand.SetComboboxInfoFiles(m_band_req, this.m_combo_box_info_files);
            RequestBand.SetComboboxPhotoFiles(m_band_req, this.m_combo_box_photo_files);
            RequestBand.SetComboboxConcertNumber(m_band_req, this.m_combo_box_concert_number);
        
            m_dialog_comboboxes_initialized = true;

        } // _SetComboBoxes 

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

            m_button_links.Text = RequestStrings.CaptionButtonRequestLinks;

        } // SetCaptions

        /// <summary>Set controls editable or not</summary>
        private void _SetEditable()
        {
            RequestBand.SetToEvaluateCheckBoxEditable(m_check_box_evaluate_band, m_editable);

            if (m_editable)
            {
                this.m_rich_text_box_comments.Enabled = true;
                this.m_rich_text_box_private_notes.Enabled = true;

                this.m_text_box_band_name.Enabled = true;
                this.m_text_box_sound_sample.Enabled = true;
                this.m_text_box_www_band.Enabled = true;

                this.m_combo_box_concert_number.Enabled = true;

                this.m_rich_text_box_comments.BackColor = AdminUtils.ColorEnable();
                this.m_rich_text_box_private_notes.BackColor = AdminUtils.ColorEnable();

                this.m_text_box_band_name.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_sound_sample.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_www_band.BackColor = AdminUtils.ColorEnable();

            }
            else
            {
                this.m_rich_text_box_comments.Enabled = false;
                this.m_rich_text_box_private_notes.Enabled = false;

                this.m_rich_text_box_comments.BackColor = AdminUtils.ColorDisable(); // TODO Does not work
                this.m_rich_text_box_private_notes.BackColor = AdminUtils.ColorDisable(); // TODO Does not work

                this.m_text_box_band_name.Enabled = false;
                this.m_text_box_sound_sample.Enabled = false;
                this.m_text_box_www_band.Enabled = false;

                this.m_combo_box_concert_number.Enabled = false;

                this.m_text_box_band_name.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_sound_sample.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_www_band.BackColor = AdminUtils.ColorDisable();

            }

        } // _SetEditable

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipReqForm.SetToolTip(this, RequestStrings.ToolTipReqForm);

            ToolTipReqFormEdit.SetToolTip(m_button_edit_request_data, RequestStrings.ToolTipReqFormEdit);
            ToolTipReqFormCancel.SetToolTip(m_button_cancel, RequestStrings.ToolTipReqFormCancel);
            ToolTipReqFormClose.SetToolTip(m_button_close, RequestStrings.ToolTipReqFormClose);
            ToolTipUtil.SetDelays(ref ToolTipReqFormEdit);
            ToolTipUtil.SetDelays(ref ToolTipReqFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipReqFormClose);

            ToolTipReqDelete.SetToolTip(m_button_delete_request, RequestStrings.ToolTipReqDelete);
            ToolTipUtil.SetDelays(ref ToolTipReqDelete);

            ToolTipReqDateButton.SetToolTip(m_button_reg_date_number, RequestStrings.ToolTipReqDateButton);
            ToolTipUtil.SetDelays(ref ToolTipReqDateButton);

            ToolTipReqBandName.SetToolTip(m_text_box_band_name, RequestStrings.ToolTipReqBandName);
            ToolTipReqBandName.SetToolTip(m_label_name, RequestStrings.ToolTipReqBandName);
            ToolTipUtil.SetDelays(ref ToolTipReqBandName);

            ToolTipReqEvaluate.SetToolTip(m_check_box_evaluate_band, RequestStrings.ToolTipReqEvaluate);
            ToolTipReqEvaluate.SetToolTip(m_label_evaluate_band, RequestStrings.ToolTipReqEvaluate);
            ToolTipUtil.SetDelays(ref ToolTipReqEvaluate);

            ToolTipReqComments.SetToolTip(m_rich_text_box_comments, RequestStrings.ToolTipReqComments);
            ToolTipReqComments.SetToolTip(m_label_comments, RequestStrings.ToolTipReqComments);
            ToolTipUtil.SetDelays(ref ToolTipReqComments);

            ToolTipReqPrivateNotes.SetToolTip(m_rich_text_box_private_notes, RequestStrings.ToolTipReqPrivateNotes);
            ToolTipReqPrivateNotes.SetToolTip(m_label_private_notes, RequestStrings.ToolTipReqPrivateNotes);
            ToolTipUtil.SetDelays(ref ToolTipReqPrivateNotes);

            ToolTipReqDownloadAudioFiles.SetToolTip(m_button_download_audio_1, RequestStrings.ToolTipReqDownloadAudioFiles);
            ToolTipReqDownloadAudioFiles.SetToolTip(m_button_download_audio_2, RequestStrings.ToolTipReqDownloadAudioFiles);
            ToolTipReqDownloadAudioFiles.SetToolTip(m_button_download_audio_3, RequestStrings.ToolTipReqDownloadAudioFiles);
            ToolTipUtil.SetDelays(ref ToolTipReqDownloadAudioFiles);

            ToolTipReqUploadAudioFiles.SetToolTip(m_button_upload_audio_1, RequestStrings.ToolTipReqUploadAudioFiles);
            ToolTipReqUploadAudioFiles.SetToolTip(m_button_upload_audio_2, RequestStrings.ToolTipReqUploadAudioFiles);
            ToolTipReqUploadAudioFiles.SetToolTip(m_button_upload_audio_3, RequestStrings.ToolTipReqUploadAudioFiles);
            ToolTipUtil.SetDelays(ref ToolTipReqUploadAudioFiles);

            ToolTipReqDeleteAudioFiles.SetToolTip(m_button_delete_audio_1, RequestStrings.ToolTipReqDeleteAudioFiles);
            ToolTipReqDeleteAudioFiles.SetToolTip(m_button_delete_audio_2, RequestStrings.ToolTipReqDeleteAudioFiles);
            ToolTipReqDeleteAudioFiles.SetToolTip(m_button_delete_audio_3, RequestStrings.ToolTipReqDeleteAudioFiles);
            ToolTipUtil.SetDelays(ref ToolTipReqDeleteAudioFiles);

            ToolTipReqAudioFiles.SetToolTip(m_combo_box_audio_1, RequestStrings.ToolTipReqAudioFiles);
            ToolTipReqAudioFiles.SetToolTip(m_combo_box_audio_2, RequestStrings.ToolTipReqAudioFiles);
            ToolTipReqAudioFiles.SetToolTip(m_combo_box_audio_3, RequestStrings.ToolTipReqAudioFiles);
            ToolTipUtil.SetDelays(ref ToolTipReqAudioFiles);

            ToolTipReqInfoFiles.SetToolTip(m_label_info_files, RequestStrings.ToolTipReqInfoFiles);
            ToolTipReqInfoFiles.SetToolTip(m_combo_box_info_files, RequestStrings.ToolTipReqInfoFiles);
            ToolTipUtil.SetDelays(ref ToolTipReqInfoFiles);

            ToolTipReqFormMsg.SetToolTip(m_textbox_message, RequestStrings.ToolTipReqFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipReqFormMsg);

        } // SetToolTips

        #endregion // Set controls

        #region Close dialog functions

        /// <summary>Set the input JazzReq (m_band_req) with data from the controls and save the data to the requests XML object corresponding to JazzAnfragen.xml. Call of RequestBand.WriteReq</summary>
        private bool _WriteTexts(out string o_error)
        {
            m_band_req.BandName = m_text_box_band_name.Text.Trim();
            m_band_req.Comments = m_rich_text_box_comments.Text;
            m_band_req.PrivateNotes = m_rich_text_box_private_notes.Text;
            m_band_req.SoundSample = m_text_box_sound_sample.Text.Trim();
            m_band_req.BandWebsite = m_text_box_www_band.Text;

            int selected_concert = m_combo_box_concert_number.SelectedIndex;
            m_band_req.ConcertNumberInt = selected_concert;

            if (m_check_box_evaluate_band.Checked)
            {
                m_band_req.ToBeEvaluatedBoolean = true;
            }
            else
            {
                m_band_req.ToBeEvaluatedBoolean = false;
            }

            if (!RequestBand.WriteReq(m_band_req, out o_error))
            {
                o_error = @"RequestBandForm._WriteTexts RequestBand.WriteReq failed " + o_error;
                MessageBox.Show(o_error);
                return false;
            }

            return true;

        } // _WriteTexts

        /// <summary>User clicked the cancel button. Changes made to the data will not be saved.</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } // m_button_cancel_Click

        /// <summary>User clicked the Save/Close button. If checked out (m_editable) data will be saved to the XML object corresponding to JazzAnfragen.xml</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (m_editable)
            {
                string error_message = @"";

                if (!RequestBand.IsBandNameUnique(m_text_box_band_name.Text, m_band_req.RegNumberInt, out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }
                
                if (!_WriteTexts(out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }
            }

            this.Close();
        } // m_button_close_Click

        #endregion // Close dialog functions

        #region Checkout functions

        /// <summary>User clicked edit request data</summary>
        private void m_button_edit_request_data_Click(object sender, EventArgs e)
        {
            if (m_editable)
                return;

            CheckoutData();

            _SetCaptions();

            _SetEditable();

        } // m_button_edit_request_data_Click

        /// <summary>Check out data and set Checkin/Checkout button to Save</summary>
        public void CheckoutData()
        {
            //QQQQ m_request_form.CheckoutData(); // Note that owner object will be changed (Checkout is changed to Save and message) 
            bool b_user_cancelled = false;
            m_request_form.CheckoutData(out b_user_cancelled); // Note that owner object will be changed (Checkout is changed to Save and message) 
            if (b_user_cancelled)
            {
                return;
            }

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

        } // CheckoutData

        #endregion // Checkout functions

        #region Download audio files

        /// <summary>User clicked download audio one (mp3) files</summary>
        private void m_button_download_audio_1_Click(object sender, EventArgs e)
        {
            if (m_band_req.AudioOne.Length == 0)
                return;

            string error_message = @"";
            string file_name = this.m_combo_box_audio_1.Text;

            if (!RequestBand.DownloadAudioOne(m_band_req, m_folder_browser_dialog_audio, file_name, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            RequestBand.SetComboboxAudioOne(m_band_req, this.m_combo_box_audio_1);

        } // m_button_download_audio_1_Click

        /// <summary>User clicked download audio two (mp3) files</summary>
        private void m_button_download_audio_2_Click(object sender, EventArgs e)
        {
            if (m_band_req.AudioTwo.Length == 0)
                return;

            string error_message = @"";
            string file_name = this.m_combo_box_audio_2.Text;

            if (!RequestBand.DownloadAudioTwo(m_band_req, m_folder_browser_dialog_audio, file_name, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            RequestBand.SetComboboxAudioTwo(m_band_req, this.m_combo_box_audio_2);

        } // m_button_download_audio_2_Click

        /// <summary>User clicked download audio three (mp3) files</summary>
        private void m_button_download_audio_3_Click(object sender, EventArgs e)
        {
            if (m_band_req.AudioThree.Length == 0)
                return;

            string error_message = @"";
            string file_name = this.m_combo_box_audio_3.Text;

            if (!RequestBand.DownloadAudioThree(m_band_req, m_folder_browser_dialog_audio, file_name, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            RequestBand.SetComboboxAudioThree(m_band_req, this.m_combo_box_audio_3);

        } // m_button_download_audio_3_Click

        #endregion // Download audio files

        #region Upload audio files

        /// <summary>User clicked upload audio one (mp3) files</summary>
        private void m_button_upload_audio_1_Click(object sender, EventArgs e)
        {
            string error_message = @"";
            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgUploadOnlyAfterCheckout;
                MessageBox.Show(error_message);
                return;
            }
            // TODO Add check if already uploaded
            
            if (!RequestBand.UploadAudioOne(ref m_band_req, m_folder_browser_dialog_audio, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            _SetComboBoxes();

        } // m_button_upload_audio_1_Click

        /// <summary>User clicked upload audio two (mp3) files</summary>
        private void m_button_upload_audio_2_Click(object sender, EventArgs e)
        {
            string error_message = @"";
            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgUploadOnlyAfterCheckout;
                MessageBox.Show(error_message);
                return;
            }

            // TODO Add check if already uploaded 
           
            if (!RequestBand.UploadAudioTwo(ref m_band_req, m_folder_browser_dialog_audio, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            _SetComboBoxes();

        } // m_button_upload_audio_2_Click

        /// <summary>User clicked upload audio three (mp3) files</summary>
        private void m_button_upload_audio_3_Click(object sender, EventArgs e)
        {
            string error_message = @"";
            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgUploadOnlyAfterCheckout;
                MessageBox.Show(error_message);
                return;
            }

            // TODO Add check if already uploaded 

            if (!RequestBand.UploadAudioThree(ref m_band_req, m_folder_browser_dialog_audio, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            _SetComboBoxes();

        } // m_button_upload_audio_3_Click

        #endregion // Upload audio files

        #region Delete audio files

        /// <summary>User clicked delete (rename for delete) audio one (mp3) files</summary>
        private void m_button_delete_audio_1_Click(object sender, EventArgs e)
        {
            if (m_band_req.AudioOne.Length == 0)
                return;

            string error_message = @"";
            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgDeleteOnlyAfterCheckout;
                MessageBox.Show(error_message);
                return;
            }

            // Delete here means renaming the audio files. The final deletion is done when the user saves the XML file 
            if (!RequestBand.DeleteAudioOne(ref m_band_req, m_textbox_message, out error_message))
            {
                error_message = @"RequestBandForm.m_button_delete_audio_1_Click RequestBand.DeleteAudioOne failed " + error_message;
                MessageBox.Show(error_message);
                return;
            }

            _SetComboBoxes();

        } // m_button_delete_audio_1_Click

        /// <summary>User clicked delete (rename for delete) audio two (mp3) files</summary>
        private void m_button_delete_audio_2_Click(object sender, EventArgs e)
        {
            if (m_band_req.AudioTwo.Length == 0)
                return;

            string error_message = @"";
            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgDeleteOnlyAfterCheckout;
                MessageBox.Show(error_message);
                return;
            }

            // Delete here means renaming the audio files. The final deletion is done when the user saves the XML file 
            if (!RequestBand.DeleteAudioTwo(ref m_band_req, m_textbox_message, out error_message))
            {
                error_message = @"RequestBandForm.m_button_delete_audio_2_Click RequestBand.DeleteAudioTwo failed " + error_message;
                MessageBox.Show(error_message);
                return;
            }

            _SetComboBoxes();

        } // m_button_delete_audio_2_Click

        /// <summary>User clicked delete (rename for delete) audio three (mp3) files</summary>
        private void m_button_delete_audio_3_Click(object sender, EventArgs e)
        {
            if (m_band_req.AudioThree.Length == 0)
                return;

            string error_message = @"";
            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgDeleteOnlyAfterCheckout;
                MessageBox.Show(error_message);
                return;
            }

            // Delete here means renaming the audio files. The final deletion is done when the user saves the XML file 
            if (!RequestBand.DeleteAudioThree(ref m_band_req, m_textbox_message, out error_message))
            {
                error_message = @"RequestBandForm.m_button_delete_audio_3_Click RequestBand.DeleteAudioThree failed " + error_message;
                MessageBox.Show(error_message);
                return;
            }

            _SetComboBoxes();

        } // m_button_delete_audio_3_Click

        #endregion // Delete audio files

        #region Comboboxes

        /// <summary>User selected information file</summary>
        private void m_combo_box_info_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_dialog_comboboxes_initialized)
                return;

            if (RequestStrings.PromptSelectInfo.Equals(m_combo_box_info_files.Text))
            {
                return;
            }

            string error_message = @"";

            int info_file_number = -1;
            if (m_combo_box_info_files.Text.Contains(RequestStrings.LabelInfoOne))
                info_file_number = 1;
            else if (m_combo_box_info_files.Text.Contains(RequestStrings.LabelInfoTwo))
                info_file_number = 2;
            else if (m_combo_box_info_files.Text.Contains(RequestStrings.LabelInfoThree))
                info_file_number = 3;
            else
            {
                error_message = @"RequestBandForm.m_combo_box_info_files_SelectedIndexChanged Failed setting info_file_number";
                MessageBox.Show(error_message);
                return;
            }

            ReqPdfForm request_pdf_form = new ReqPdfForm(this, m_request_form, m_band_req, info_file_number);
            request_pdf_form.Owner = this;
            request_pdf_form.ShowDialog();

            m_dialog_comboboxes_initialized = false;
            RequestBand.SetComboboxInfoFiles(m_band_req, this.m_combo_box_info_files);
            m_dialog_comboboxes_initialized = true;

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_editable = true;

                _SetCaptions();

                _SetEditable();
            }

        } // m_combo_box_info_files_SelectedIndexChanged

        /// <summary>User selected photo file</summary>
        private void m_combo_box_photo_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_dialog_comboboxes_initialized)
                return;

            if (RequestStrings.PromptSelectPhoto.Equals(m_combo_box_photo_files.Text))
            {
                return;
            }

            int photo_file_number = m_combo_box_photo_files.SelectedIndex;

            ReqImgForm request_img_form = new ReqImgForm(this, m_request_form, m_band_req, photo_file_number);
            request_img_form.Owner = this;
            request_img_form.ShowDialog();

            m_dialog_comboboxes_initialized = false;
            RequestBand.SetComboboxPhotoFiles(m_band_req, this.m_combo_box_photo_files);
            m_dialog_comboboxes_initialized = true;

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_editable = true;

                _SetCaptions();

                _SetEditable();
            }

        } // m_combo_box_photo_files_SelectedIndexChanged

        /// <summary>User selected concert number</summary>
        private void m_combo_box_concert_number_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_dialog_comboboxes_initialized)
                return;

            int selected_concert = m_combo_box_concert_number.SelectedIndex;
            selected_concert = selected_concert + 0;

        } // m_combo_box_concert_number_SelectedIndexChanged

        /// <summary>User clicked the registration date button</summary>
        private void m_button_reg_date_number_Click(object sender, EventArgs e)
        {
            RequestDateForm request_date_form = new RequestDateForm(this, m_request_form, m_band_req);
            request_date_form.Owner = this;
            request_date_form.ShowDialog();

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_editable = true;

                _SetDateAndRegNumber();

                _SetCaptions();

                _SetEditable();
            }

        } // m_button_reg_date_number_Click

        #endregion // Comboboxes

        #region Buttons delete request and request links

        /// <summary>User clicked remove this JazzReq (m_band_req) object</summary>
        private void m_button_delete_request_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgCheckoutBeforeRemovingRequest;
                MessageBox.Show(error_message);

                return;
            }

            // The mp3 files will no longer be deleted. TODO A new function should be implemented that deletes all non-used .mp3 files
            // error_message = RequestStrings.MsgDeleteOfSoundFiles;
            // MessageBox.Show(error_message);

            if (!RequestBand.RemoveReq(m_band_req, m_textbox_message, out error_message))
            {
                error_message = @"RequestBandForm.m_button_delete_request_Click Request.RemoveReq failed " + error_message;
                MessageBox.Show(error_message);
                return;
            }

            this.Close();

        } // m_button_delete_request_Click

        /// <summary>User clicked the button links</summary>
        private void m_button_links_Click(object sender, EventArgs e)
        {
            ReqLinksForm request_links_form = new ReqLinksForm(this, m_request_form, m_band_req);
            request_links_form.Owner = this;
            request_links_form.ShowDialog();

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_editable = true;

                _SetCaptions();

                _SetEditable();
            }

        } // m_button_links_Click

        #endregion // Buttons delete request and request links

        #region Not used events

        /// <summary>User changed the "to be evaluated" flag. Do nothing ....</summary>
        private void m_check_box_evaluate_band_CheckedChanged(object sender, EventArgs e)
        {
            // Do not do anything

        } // m_check_box_evaluate_band_CheckedChanged

        #endregion // Not used events

    } // RequestBandForm

} // namespace
