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
    /// <summary>Main form for the handling of photos
    /// <para>This is Graphical User Interface class. Commands should not be executed in this class.</para>
    /// </summary>
    public partial class PhotoMainForm : Form
    {
        #region Member variables

        /// <summary>Flag telling if the dialog controls are being initialized</summary>
        bool m_initializing = false;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Data for text box m_text_box_date_band. Corresponds to array for combobox m_combo_box_zip_files</summary>
        string[] m_date_band_array = null;

        /// <summary>Flag defining if the user clicked close window</summary>
        private bool m_user_clicked_close_window = false;


        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor that initializes the control elements</summary>
        public PhotoMainForm()
        {
            InitializeComponent();

            string error_message = @"";

            if (!PhotoMain.InitXml(out error_message))
            {
                MessageBox.Show(@"RequestForm.Constructor PhotoMain.InitXml failed " + error_message);
                return;
            }

            // In order to be able to get subdirectory names that will be used for the ZIP file names
            if (!DocAdmin.DocAll.SetActiveSeasonToThisSeason(out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            PhotoMain.InitSearch();

            // PhotoMain.InitXml must be called before calling this function
            PhotoMain.InitUploadPhotoXmlFiles();

            _SetControls();

        } // constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set all controls</summary>
        private void _SetControls()
        {
            _SetTitles();

            _SetComboBoxes();

            _SetLoginLogout();

            _SetCaptions();

            _SetEditable();

            _SetButtonImages();

            _SetToolTips();

        } // _SetControls

        /// <summary>Set titles</summary>
        private void _SetTitles()
        {
            this.Text = PhotoStrings.TitlePhotoMainForm;

            m_label_photo.Text = PhotoStrings.TitlePhotoMainForm;

            m_text_box_n_results.Text = @"";

            m_text_box_date_band.Text = @"";

            m_text_box_search.Text = @"";

            m_textbox_message.Text = @"";

            // Not used as string. Only displayed when there are no bands that can be selected
            m_combo_box_gallery.Text = PhotoStrings.PromptSelectGallery;

        } // _SetTitles

        /// <summary>Set controls editable or not</summary>
        private void _SetEditable()
        {
            if (m_editable)
            {
                // this.m_text_box_photographer_name.Enabled = true;

                // this.m_text_box_photographer_name.BackColor = AdminUtils.ColorEnable();

            }
            else
            {
                //this.m_text_box_photographer_name.Enabled = false;

                //this.m_text_box_photographer_name.BackColor = AdminUtils.ColorDisable();
            }

        } // _SetEditable

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            this.m_button_cancel.Text = JazzAppAdminSettings.Default.Caption_Cancel;
            this.m_button_close.Text = JazzAppAdminSettings.Default.Caption_Close;
            this.m_button_exit.Text = JazzAppAdminSettings.Default.Caption_Exit;

            this.m_button_developer.Text = PhotoStrings.CapPhotoDeveloper;

        } // SetCaptions

        /// <summary>Set combo boxes
        /// <para>Settings are based on the XML object corresponding to the file JazzFotoGalerieZwei.xml</para>
        /// <para>1. Search ZIP files and set controls. Call of PhotoMain.SearchZipSetControls</para>
        /// <para>2. Set the combo box gallery. Call of _SetComboBoxGallery</para>
        /// <para></para>
        /// </summary>
        private void _SetComboBoxes()
        {
            m_initializing = true;
 
            string error_message = @"";

            if (!PhotoMain.SearchZipSetControls(m_text_box_search, m_combo_box_zip_file, m_text_box_date_band, m_text_box_n_results, out m_date_band_array, out error_message))
            {

            }

            _SetComboBoxGallery();

            m_initializing = false;

        } // _SetComboBoxes

        /// <summary>Set the combo box gallery
        /// <para>Settings are based on the XML object corresponding to the file JazzFotoGalerieZwei.xml</para>
        /// <para>1. Get the JazzPhoto objects with ZIP files but with no galleries. Call of PhotoMain.GetPhotoObjectsZipNoGalleryTwo</para>
        /// <para>2. Set the combo box gallery. Call of PhotoMain.SetComboBoxGallery</para>
        /// </summary>
        private void _SetComboBoxGallery()
        {
            string error_message = @"";

            JazzPhoto[] objects_zip_no_gallery = PhotoMain.GetPhotoObjectsZipNoGalleryTwo(out error_message);
            if (null == objects_zip_no_gallery)
            {
                return;
            }

            PhotoMain.SetComboBoxGallery(m_combo_box_gallery, m_text_box_gallery, objects_zip_no_gallery);

        } // _SetComboBoxGallery

        /// <summary>Set background image for the add and download gallery buttons</summary>
        private void _SetButtonImages()
        {
            // TODO QQQQQQQQQ
            // Properties.Resources.IconEdit;
            m_button_add_gallery.BackgroundImage = Properties.Resources.IconPhotoPlus;

            // Properties.Resources.IconDownload;
            m_button_download_gallery.BackgroundImage = Properties.Resources.IconBlack;

        } // _SetButtonImages

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipPhotoMainForm.SetToolTip(this, PhotoStrings.ToolTipPhotoMainForm);
            ToolTipPhotoMainForm.SetToolTip(m_label_photo, PhotoStrings.ToolTipPhotoMainForm);
            ToolTipPhotoMainForm.SetToolTip(m_picture_box_text_logo, PhotoStrings.ToolTipPhotoMainForm);
            ToolTipUtil.SetDelays(ref ToolTipPhotoMainForm);

            ToolTipPhotoMainHelp.SetToolTip(m_button_help, PhotoStrings.ToolTipPhotoMainHelp);
            ToolTipUtil.SetDelays(ref ToolTipPhotoMainHelp);

            ToolTipPhotoMainCheckinCheckout.SetToolTip(m_button_checkin_checkout, PhotoStrings.ToolTipPhotoMainCheckinCheckout);
            ToolTipUtil.SetDelays(ref ToolTipPhotoMainCheckinCheckout);

            ToolTipIndexExit.SetToolTip(m_button_exit, JazzAppAdminSettings.Default.ToolTipIndexExit);
            ToolTipIndexBack.SetToolTip(m_button_close, JazzAppAdminSettings.Default.ToolTipIndexBack);
            ToolTipIndexCancel.SetToolTip(m_button_cancel, JazzAppAdminSettings.Default.ToolTipIndexCancel);
            ToolTipUtil.SetDelays(ref ToolTipIndexExit);
            ToolTipUtil.SetDelays(ref ToolTipIndexBack);
            ToolTipUtil.SetDelays(ref ToolTipIndexCancel);

            ToolTipPhotoSearchZipFiles.SetToolTip(m_text_box_search, PhotoStrings.ToolTipPhotoSearchZipFiles);
            ToolTipPhotoSearchZipFiles.SetToolTip(m_picture_box_search, PhotoStrings.ToolTipPhotoSearchZipFiles);
            ToolTipUtil.SetDelays(ref ToolTipPhotoSearchZipFiles);

            ToolTipPhotoNumberOfZipFiles.SetToolTip(m_text_box_n_results, PhotoStrings.ToolTipPhotoNumberOfZipFiles);
            ToolTipUtil.SetDelays(ref ToolTipPhotoNumberOfZipFiles);

            ToolTipDateBandZipFiles.SetToolTip(m_text_box_date_band, PhotoStrings.ToolTipDateBandZipFiles);
            ToolTipUtil.SetDelays(ref ToolTipDateBandZipFiles);

            ToolTipPhotoDeveloper.SetToolTip(m_button_developer, PhotoStrings.ToolTipPhotoDeveloper);
            ToolTipUtil.SetDelays(ref ToolTipPhotoDeveloper);

            ToolTipPhotoDownloadZipFiles.SetToolTip(m_button_download_zip, PhotoStrings.ToolTipPhotoDownloadZipFiles);
            ToolTipUtil.SetDelays(ref ToolTipPhotoDownloadZipFiles);

            ToolTipPhotoZipDatei.SetToolTip(m_picture_box_zip, PhotoStrings.ToolTipPhotoZipDatei);
            ToolTipUtil.SetDelays(ref ToolTipPhotoZipDatei);

            ToolTipPhotoUploadZipFiles.SetToolTip(m_button_upload_zip, PhotoStrings.ToolTipPhotoUploadZipFiles);
            ToolTipUtil.SetDelays(ref ToolTipPhotoUploadZipFiles);

            ToolTipPhotoAddZipFiles.SetToolTip(m_button_add_zip, PhotoStrings.ToolTipPhotoAddZipFiles);
            ToolTipUtil.SetDelays(ref ToolTipPhotoAddZipFiles);

            ToolTipPhotoAddGallery.SetToolTip(m_button_add_gallery, PhotoStrings.ToolTipPhotoAddGallery);
            ToolTipUtil.SetDelays(ref ToolTipPhotoAddGallery);

            ToolTipPhotoGallery.SetToolTip(m_picture_box_gallery, PhotoStrings.ToolTipPhotoGallery);
            ToolTipUtil.SetDelays(ref ToolTipPhotoGallery);

            ToolTipGalleryUpload.SetToolTip(m_button_upload_gallery, PhotoStrings.ToolTipGalleryUpload);
            ToolTipUtil.SetDelays(ref ToolTipGalleryUpload);

            ToolTipGallerySelection.SetToolTip(m_combo_box_gallery, PhotoStrings.ToolTipGallerySelection);
            ToolTipUtil.SetDelays(ref ToolTipGallerySelection);

            ToolTipGalleryNumber.SetToolTip(m_text_box_gallery, PhotoStrings.ToolTipGalleryNumber);
            ToolTipUtil.SetDelays(ref ToolTipGalleryNumber);

            ToolTipPhotoFormMsg.SetToolTip(m_textbox_message, PhotoStrings.ToolTipPhotoFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipPhotoFormMsg);

        } // _SetToolTips

        #endregion // Set controls

        #region Help

        /// <summary>User clicked the help button</summary>
        private void m_button_help_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameAdminXmlPhotos() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm help_form = new HelpForm(HelpFiles.GetFilenameAdminXmlPhotos());
                help_form.Owner = this;
                help_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }
        } // m_button_help_Click

        #endregion // Help

        #region Checkin/Checkout

        /// <summary>User clicked the checkin/checkout button</summary>
        private void m_button_checkin_checkout_Click(object sender, EventArgs e)
        {
            if (m_initializing)
                return;

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                CheckinData();
            }
            else
            {
                bool b_user_cancelled = false;
                CheckoutData(out b_user_cancelled);
            }

        } // m_button_checkin_checkout_Click

        /// <summary>Check out data and set Checkin/Checkout button to Save</summary>
        public bool CheckoutData(out bool o_b_user_cancelled)
        {
            o_b_user_cancelled = false;

            // Returned value 'false' means that the somebody else already has checked out and 
            // that the user not forced a checkeout
            bool b_checkout_data = AdminUtils.CheckoutData();
            if (!b_checkout_data)
            {
                o_b_user_cancelled = true;
                return true;
            }

            PhotoMain.InitUploadPhotoXmlFiles();

            _SetLoginLogout();

            return true;

        } // CheckoutData

        /// <summary>Upload changed file to the server, check in data and set Checkin/Checkout button to Save</summary>
        private void CheckinData()
        {
            string error_message = @"";
           
            if (!PhotoMain.UploadXmlFiles(out error_message))
            {
                error_message = @"Upload of XML files failed: " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }
           
            this.m_textbox_message.Text = @"";

            string out_message = @"";
            bool force_checkin = false;
            if (!JazzLoginLogout.LoginLogout.Checkin(force_checkin, out out_message, out error_message))
            {
                error_message = @"PhotoMainForm.CheckinData Programming error: " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }

            _SetLoginLogout();

        } // CheckinData

        /// <summary>Set the Login/Logout button</summary>
        private void _SetLoginLogout()
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_button_checkin_checkout.Text = JazzAppAdminSettings.Default.Caption_CheckIn;
            }
            else
            {
                m_button_checkin_checkout.Text = JazzAppAdminSettings.Default.Caption_CheckOut;
            }

        } // _SetLoginLogout

        #endregion // Checkin/Checkout

        #region ZIP event functions

        /// <summary>User clicked the download ZIP button</summary>
        private void m_button_download_zip_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            string error_message = @"";
            bool b_cancel_download = false;
            string zip_file_name = m_combo_box_zip_file.Text;

            if (!PhotoMain.DownloadPhotoZipFile(zip_file_name, out b_cancel_download, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            if (b_cancel_download)
            {
                return;
            }

            m_textbox_message.Text = zip_file_name + PhotoStrings.MsgFileDownloaded;

        } // m_button_download_zip_Click

        /// <summary>User clicked the upload ZIP button</summary>
        private void m_button_upload_zip_Click(object sender, EventArgs e)
        {
            bool b_implemented = false;
            if (!b_implemented)
            {
                MessageBox.Show(PhotoStrings.ErrMsgReplaceZipNotImplemented);
                return;
            }
 
            if (!m_editable)
            {
                string error_checkout = PhotoStrings.ErrMsgCheckoutBeforeUpload;
                MessageBox.Show(error_checkout);
                return;
            }

        } // m_button_upload_zip_Click

        /// <summary>User clicked the developer button</summary>
        private void m_button_developer_Click(object sender, EventArgs e)
        {
            PhotoDeveloperForm photo_developer_form = new PhotoDeveloperForm(this);
            photo_developer_form.Owner = this;
            photo_developer_form.ShowDialog();

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_editable = true;

                _SetCaptions();

                _SetEditable();
            }

        } // m_button_developer_Click

        /// <summary>User clicked add ZIP file</summary>
        private void m_button_add_zip_Click(object sender, EventArgs e)
        {
            PhotoZipForm photo_zip_form = new PhotoZipForm(this);
            photo_zip_form.Owner = this;
            photo_zip_form.ShowDialog();

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_editable = true;

                _SetCaptions();

                _SetEditable();

                m_initializing = true;
                _SetComboBoxes();
                m_initializing = false;
            }

        } // m_button_add_zip_Click

        /// <summary>User changed search text</summary>
        private void m_text_box_search_TextChanged(object sender, EventArgs e)
        {
            _SetComboBoxes();

        } // m_text_box_search_TextChanged

        #endregion // ZIP event functions

        #region Gallery event functions

        /// <summary>User selected gallery</summary>
        private void m_combo_box_gallery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_initializing)
                return;

            int index_photo = m_combo_box_gallery.SelectedIndex;

            string error_message = @"";
            JazzPhoto[] objects_zip_no_gallery = PhotoMain.GetPhotoObjectsZipNoGalleryTwo(out error_message);
            if (null == objects_zip_no_gallery)
            {
                return;
            }

            PhotoMain.SetTextBoxGallery(m_text_box_gallery, objects_zip_no_gallery, index_photo);

        } // m_combo_box_gallery_SelectedIndexChanged

        /// <summary>User clicked the add gallery button</summary>
        private void m_button_add_gallery_Click(object sender, EventArgs e)
        {
            if (m_combo_box_gallery.Text.Equals(PhotoStrings.PromptSelectGallery))
                return;

            int index_photo = m_combo_box_gallery.SelectedIndex;

            string error_message = @"";
            JazzPhoto[] objects_zip_no_gallery = PhotoMain.GetPhotoObjectsZipNoGalleryTwo(out error_message);
            if (null == objects_zip_no_gallery)
            {
                return;
            }

            JazzPhoto input_photo = objects_zip_no_gallery[index_photo];

            PhotoGalleryForm photo_gallery_form = new PhotoGalleryForm(this, input_photo);
            photo_gallery_form.Owner = this;
            photo_gallery_form.ShowDialog();

            m_initializing = true;
            _SetComboBoxGallery();
            m_initializing = false;

        } // m_button_add_gallery_Click

        /// <summary>Get selected JazzPhoto object</summary>
        private JazzPhoto GetJazzPhotoFromTextBox()
        {
            JazzPhoto selected_jazz_photo = null;

            int index_photo = m_combo_box_gallery.SelectedIndex;

            string error_message = @"";
            JazzPhoto[] objects_zip_no_gallery = PhotoMain.GetPhotoObjectsZipNoGalleryTwo(out error_message);
            if (null == objects_zip_no_gallery)
            {
                return selected_jazz_photo;
            }

            selected_jazz_photo = objects_zip_no_gallery[index_photo];

            return selected_jazz_photo;
        }

        /// <summary>User clicked upload gallery
        /// <para>1. Checkout check. Call of JazzLoginLogout.LoginLogout.DataCheckedOut</para>
        /// <para>2. Get selected JazzPhoto object from text box. Call of GetJazzPhotoFromTextBox</para>
        /// <para>3. Upload the gallery. Call of PhotoUpload.Execute</para>
        /// </summary>
        private void m_button_upload_gallery_Click(object sender, EventArgs e)
        {
            if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                string error_checkout = PhotoStrings.ErrMsgCheckoutBeforeUpload;
                MessageBox.Show(error_checkout);
                return;
            }

            JazzPhoto input_jazz_photo = GetJazzPhotoFromTextBox();
            if (null == input_jazz_photo)
            {
                return;
            }
           
            PhotoUpload photo_upload = new PhotoUpload();

            string error_message = @"";
            if (!photo_upload.Execute(input_jazz_photo, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

        } // m_button_upload_gallery_Click

        #endregion // Gallery event functions

        #region Prevent user to use some commands

        /// <summary>Tell the user to use implemented close dialog buttons
        /// <para>Call of AdminUtils.FormIsClosing Case=2</para>
        /// </summary>
        private void PhotoMainForm_FormClosing(object sender, FormClosingEventArgs i_event)
        {
            if (m_user_clicked_close_window)
            {
                return;
            }

            int i_case = 2;
            AdminUtils.FormIsClosing(i_event, i_case);

        } // JazzAppAdminForm_FormClosing

        #endregion // Prevent user to use some commands

        #region Select ZIP file

        /// <summary>User selected ZIP file
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        private void m_combo_box_zip_file_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_initializing)
                return;

            int sel_index = m_combo_box_zip_file.SelectedIndex;

            if (null == m_date_band_array)
                return;

            m_text_box_date_band.Text = m_date_band_array[sel_index];

        } // m_combo_box_zip_file_SelectedIndexChanged

        #endregion // Select ZIP file

        #region Exit the dialog

        /// <summary>Handles the user event that edited data not shall be saved
        /// <para>A message box will be displayed letting the user decide if he really wants to quit without saving</para>
        /// <para>The function returns false if the user decides not to quit without saving</para>
        /// <para>If the user decides to quit the following is done:</para>
        /// <para>- The login-logout file will register a "forced" login. Call of LoginLogout.Checkin</para>
        /// <para>- The requests XDocument will be reset with XML data from the server. Call of ResetRequestsXDocumentAfterQuit</para>
        /// <para>- Controls will be reset</para>
        /// </summary>
        /// <param name="i_caption">The caption for the quit without save message box</param>
        private bool QuitWithoutSaving(string i_caption)
        {
            if (AdminUtils.MessageBoxYesNo(JazzAppAdminSettings.Default.MsgCloseWithoutSaving, i_caption))
            {
                string error_message = @"";
                string out_message = @"";
                bool force_checkin = true;

                if (!JazzLoginLogout.LoginLogout.Checkin(force_checkin, out out_message, out error_message))
                {
                    return false; // Programming error
                }

                if (!ResetRequestsXDocumentAfterQuit(out error_message))
                {
                    return false; // Programming error
                }

                return true;
            }

            return false;

        } // QuitWithoutSaving


        /// <summary>Reset the requests XDocument object (corresponding to JazzAnfragen.xml) when the user has quit editing
        /// <para>This corresponds to a restart of the application.</para>
        /// <para>The controls should also be reset by the calling (WindowsForm) function</para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        public static bool ResetRequestsXDocumentAfterQuit(out string o_error)
        {
            o_error = @"";
            /* TODO
            if (!Request.InitXmlReq(out o_error))
            {

                o_error = @"RequestForm.ResetCurrentXDocumentAfterQuit Programming error: " + o_error;

                return false;
            }
            TODO */
            return true;
        } // ResetRequestsXDocumentAfterQuit

        /// <summary>User clicked cancel</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Cancel))
                {
                    return; // The user did not want to exit without saving
                }
            }

            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked the close button</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Cancel))
                {
                    return; // The user did not want to exit without saving
                }
            }

            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_close_Click

        /// <summary>User clicked the exit application button</summary>
        private void m_button_exit_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Cancel))
                {
                    return; // The user did not want to exit without saving
                }

                Application.Exit();
            }

            if (!Main.ApplicationExit())
            {
                return;
            }

            Application.Exit();

        } // m_button_exit_Click


        #endregion // Exit the dialog

    } // PhotoMainForm
} // Namespace
