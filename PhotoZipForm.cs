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
    /// <summary>Form for upload and registration of an additional ZIP file
    /// <para>This is Graphical User Interface class. Commands should not be executed in this class.</para>
    /// </summary>
    public partial class PhotoZipForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        PhotoMainForm m_photo_main_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Holds upload photo input data from the user</summary>
        private JazzPhoto m_upload_jazz_photo = null;

        /// <summary>Season for the upload, i.e. data that corresponds to data in object m_upload_jazz_photo</summary>
        private string m_upload_season_str = @"";

        /// <summary>Flag telling if the dialog controls are being initialized</summary>
        bool m_is_initializing = false;

        /// <summary>Flag defining if the user clicked close window</summary>
        private bool m_user_clicked_close_window = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor
        /// <para>1. Sets the controls of the dialog</para>
        /// <para>2. Makes the controls editable if the XML file is checked out</para>
        /// <para>3. Sets the tool tips</para>
        /// <para>4. Sets the captions</para>
        /// </summary>
        /// <param name="i_photo_main_form">Object PhotoMainForm - the owner of this form</param>
        public PhotoZipForm(PhotoMainForm i_photo_main_form)
        {
            InitializeComponent();

            if (null == i_photo_main_form)
                return;

            m_photo_main_form = i_photo_main_form;

            m_upload_jazz_photo = new JazzPhoto();

            string error_message = @"";
            if (!PhotoMain.InitZip(out error_message))
            {
                return;
            }

            m_is_initializing = true;

            _SetTexts();

            _SetComboBoxes();

            _SetToolTips();

            // m_editable must be set before _SetCaptions() is called
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetEditable();

            _SetCaptions();

            m_is_initializing = false;

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = PhotoStrings.TitlePhotoZipForm;

            m_label_page_header.Text = PhotoStrings.TitlePhotoZipForm; ;

            m_text_box_photographer_name.Text = PhotoStrings.DefaultPhotoPhotographer;

            m_text_box_file_name_zip.Text = @"";

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipPhotoZipForm.SetToolTip(this, PhotoStrings.ToolTipPhotoZipForm);
            ToolTipPhotoZipForm.SetToolTip(m_label_page_header, PhotoStrings.ToolTipPhotoZipForm);
            ToolTipUtil.SetDelays(ref ToolTipPhotoZipForm);

            ToolTipPhotoFormEdit.SetToolTip(m_button_edit_concert_data, PhotoStrings.ToolTipPhotoFormEdit);
            ToolTipUtil.SetDelays(ref ToolTipPhotoFormEdit);

            ToolTipPhotoFormCancel.SetToolTip(m_button_cancel, PhotoStrings.ToolTipPhotoFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipPhotoFormCancel);

            ToolTipPhotoFormClose.SetToolTip(m_button_close, PhotoStrings.ToolTipPhotoFormClose);
            ToolTipUtil.SetDelays(ref ToolTipPhotoFormClose);

            ToolTipZipFormPhotographer.SetToolTip(m_text_box_photographer_name, PhotoStrings.ToolTipZipFormPhotographer);
            ToolTipZipFormPhotographer.SetToolTip(m_label_photographer_name, PhotoStrings.ToolTipZipFormPhotographer);
            ToolTipUtil.SetDelays(ref ToolTipZipFormPhotographer);

            ToolTipPhotoZipName.SetToolTip(m_text_box_file_name_zip, PhotoStrings.ToolTipPhotoZipName);
            ToolTipUtil.SetDelays(ref ToolTipPhotoZipName);

            ToolTipZipFormUpload.SetToolTip(m_button_upload_zip, PhotoStrings.ToolTipZipFormUpload);
            ToolTipUtil.SetDelays(ref ToolTipZipFormUpload);

            ToolTipPhotoZipDatei.SetToolTip(m_picture_box_zip, PhotoStrings.ToolTipPhotoZipDatei);
            ToolTipUtil.SetDelays(ref ToolTipPhotoZipDatei);

            ToolTipPhotoZipConcert.SetToolTip(m_combo_box_concert, PhotoStrings.ToolTipPhotoZipConcert);
            ToolTipUtil.SetDelays(ref ToolTipPhotoZipConcert);

            ToolTipPhotoZipSeason.SetToolTip(m_combo_box_season, PhotoStrings.ToolTipPhotoZipSeason);
            ToolTipUtil.SetDelays(ref ToolTipPhotoZipSeason);

            ToolTipPhotoZipMsg.SetToolTip(m_textbox_message, PhotoStrings.ToolTipPhotoZipMsg);
            ToolTipUtil.SetDelays(ref ToolTipPhotoZipMsg);

        } // SetToolTips

        /// <summary>Set controls editable or not</summary>
        private void _SetEditable()
        {
            if (m_editable)
            {
                this.m_text_box_photographer_name.Enabled = true;

                this.m_text_box_photographer_name.BackColor = AdminUtils.ColorEnable();

            }
            else
            {
                this.m_text_box_photographer_name.Enabled = false;

                this.m_text_box_photographer_name.BackColor = AdminUtils.ColorDisable();

            }

        } // SetEditable

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // _SetCaptions

        /// <summary>Set comboboxes</summary>
        private void _SetComboBoxes()
        {
            PhotoMain.SetComboBoxSeasons(m_combo_box_season);
            PhotoMain.SetComboBoxConcerts(m_combo_box_concert);

        } // _SetComboBoxes

        #endregion // Set controls

        #region Write data

        /// <summary>Write data (texts)</summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            if (!PhotoMain.CheckInputXmlZipPhotoData(m_upload_jazz_photo, m_upload_season_str, out o_error))
            {
                return false;
            }

            if (!PhotoMain.SetXmlZipPhotoData(m_upload_jazz_photo, m_upload_season_str, out o_error))
            {
                o_error = @"PhotoDeveloperForm._WriteTexts PhotoMain.SetXmlZipPhotoData failed " + o_error;

                return false;
            }

            return true;

        } // _WriteTexts

        #endregion // Write data

        #region Event handling functions 

        /// <summary>User clicked the edit (checkout) button</summary>
        private void m_button_edit_concert_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                bool b_user_cancelled = false;
                m_photo_main_form.CheckoutData(out b_user_cancelled);
                if (b_user_cancelled)
                {
                    return;
                }

                m_editable = true;
            }

            _SetEditable();

            _SetCaptions();

        } // m_button_edit_concert_data_Click

        /// <summary>User clicked button cancel</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            // TODO Perhaps delete ZIP file if it has been uploaded

            m_user_clicked_close_window = true;

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

            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_close_Click

        /// <summary>User clicked upload zip file
        /// <para>The data for the upload is hold by member JazzPhoto object m_upload_jazz_photo</para>
        /// <para>Set data for m_upload_jazz_photo from form and season XML object. Call of PhotoMain.SetZipPhotoDataFromForm</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        private void m_button_upload_zip_Click(object sender, EventArgs e)
        {
            
            if (!m_editable)
            {
                string error_checkout = PhotoStrings.ErrMsgCheckoutBeforeUpload;
                MessageBox.Show(error_checkout);
                return ;
            }
           

            m_text_box_file_name_zip.Text = "";

            m_upload_season_str = @"";

            PhotoMain.SetZipPhotoDataFromForm(ref m_upload_jazz_photo, m_combo_box_concert, m_text_box_photographer_name);

            string error_message = @"";

            m_textbox_message.Text = @"";

            bool cancel_upload = false;
            if (!PhotoMain.UploadPhotoZipFile(ref m_upload_jazz_photo, out cancel_upload, out error_message))
            {
                error_message = @"PhotoZipForm.m_button_upload_zip_Click PhotoMain.UploadPhotoZipFile failed " + error_message;
                MessageBox.Show(error_message);

                return;
            }

            if (cancel_upload)
            {
                m_textbox_message.Text = PhotoStrings.MsgFileUploadCancelled;
                return;
            }

            m_text_box_file_name_zip.Text = m_upload_jazz_photo.ZipName;

            m_textbox_message.Text = m_upload_jazz_photo.ZipName + PhotoStrings.MsgFileUploaded;

            m_upload_season_str = m_combo_box_season.Text;

        } // m_button_upload_zip_Click

        /// <summary>User selected a new season</summary>
        private void m_combo_box_season_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_is_initializing)
                return;

            // For the construction of the ZIP file name is the directory names for documents used
            // Therefore the active document Xdocument (JazzDokumente_20XX_20YY) also be set
            // It may fail to do that if a document XML file not yet has been created.
            // In this case a name will be constructed another way
            string error_message = @"";
            if (!JazzXml.SetActiveXmlObjectAndFile(m_combo_box_season.Text, out error_message))
            {
                error_message = @"JazzDocAll.SetActiveSeason JazzXml.SetActiveXmlObjectAndFile failed " + error_message;
            }

            PhotoMain.SetSeason(m_combo_box_season.Text);
            PhotoMain.SetAvailableConcerts();

            m_is_initializing = true;
            PhotoMain.SetComboBoxConcerts(m_combo_box_concert);
            m_is_initializing = false;

        } // m_combo_box_season_SelectedIndexChanged

        /// <summary>User selected a new concert. Nothing except removing zip name is actually done. By exit will only the set band name be used</summary>
        private void m_combo_box_concert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_is_initializing)
                return;

            m_text_box_file_name_zip.Text = "";

        } // m_combo_box_concert_SelectedIndexChanged

        #endregion // Event handling functions 

        #region Prevent user to use some commands

        /// <summary>Tell the user to use implemented close dialog buttons
        /// <para>Call of AdminUtils.FormIsClosing Case=2</para>
        /// </summary>
        private void PhotoZipForm_FormClosing(object sender, FormClosingEventArgs i_event)
        {
            if (m_user_clicked_close_window)
            {
                return;
            }

            int i_case = 2;
            AdminUtils.FormIsClosing(i_event, i_case);

        } // JazzAppAdminForm_FormClosing

        #endregion // Prevent user to use some commands

    } // PhotoZipForm

} // namespace
