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
    /// <summary>Photo functions for the developer
    /// <para></para>
    /// </summary>
    public partial class PhotoDeveloperForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        PhotoMainForm m_photo_main_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Flag telling if controls are being initialized</summary>
        //private bool m_is_initializing = false;

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
        public PhotoDeveloperForm(PhotoMainForm i_photo_main_form)
        {
            InitializeComponent();

            if (null == i_photo_main_form)
                return;

            m_photo_main_form = i_photo_main_form;

            //m_is_initializing = true;

            _SetTexts();

            _SetToolTips();

            // m_editable must be set before _SetCaptions() is called
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetCaptions();

            //m_is_initializing = false;

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = PhotoStrings.TitlePhotoDeveloperForm;

            this.m_label_page_header.Text = PhotoStrings.LabelPhotoDeveloperForm;

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipThisForm.SetToolTip(this, PhotoStrings.ToolTipPhotoDeveloperForm);
            ToolTipUtil.SetDelays(ref ToolTipThisForm);

            ToolTipPhotoDeveloperForm.SetToolTip(m_label_page_header, PhotoStrings.ToolTipPhotoDeveloperForm);
            ToolTipUtil.SetDelays(ref ToolTipPhotoDeveloperForm);

            ToolTipReqMainCheckinCheckout.SetToolTip(m_button_edit_concert_data, PhotoStrings.ToolTipPhotoFormEdit);
            ToolTipUtil.SetDelays(ref ToolTipReqMainCheckinCheckout);

            ToolTipReqFormCancel.SetToolTip(m_button_cancel, PhotoStrings.ToolTipPhotoFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipReqFormCancel);
            ToolTipReqFormClose.SetToolTip(m_button_close, PhotoStrings.ToolTipPhotoFormClose);
            ToolTipUtil.SetDelays(ref ToolTipReqFormClose);

            ToolTipPhotoZipList.SetToolTip(m_button_list_zip, PhotoStrings.ToolTipPhotoZipList);
            ToolTipUtil.SetDelays(ref ToolTipPhotoZipList);
            
            ToolTipPhotoCheckFunctions.SetToolTip(m_button_check_data, PhotoStrings.ToolTipPhotoCheckFunctions);
            ToolTipUtil.SetDelays(ref ToolTipPhotoCheckFunctions);

            ToolTipPhotoToolTip.SetToolTip(m_button_tool_tips, PhotoStrings.ToolTipPhotoToolTip);
            ToolTipUtil.SetDelays(ref ToolTipPhotoToolTip);

            ToolTipPhotoDownloadGalleryHtm.SetToolTip(m_button_download_htm, PhotoStrings.ToolTipPhotoDownloadGalleryHtm);
            ToolTipUtil.SetDelays(ref ToolTipPhotoDownloadGalleryHtm);

            ToolTipPhotoMaintenanceHelp.SetToolTip(m_button_help, PhotoStrings.ToolTipPhotoMaintenanceHelp);
            ToolTipUtil.SetDelays(ref ToolTipPhotoMaintenanceHelp);

            ToolTipAdminBugsNewFunctions.SetToolTip(m_button_bugs, PhotoStrings.ToolTipAdminBugsNewFunctions);
            ToolTipUtil.SetDelays(ref ToolTipAdminBugsNewFunctions);

            ToolTipReqFormMsg.SetToolTip(m_textbox_message, PhotoStrings.ToolTipPhotoFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipReqFormMsg);

        } // SetToolTips

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // _SetCaptions

        #endregion // Set controls

        #region Write data

        /// <summary>Write data (texts)</summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            //TODO if (!m_photo_main_form.SetXyzDate( out o_error))
            //TODO {
            //TODO o_error = @"PhotoDeveloperForm._WriteTexts PhotoMainForm.SetXyzDate failed " + o_error;
            //TODO return false;
            //TODO }

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

            _SetCaptions();

        } // m_button_edit_concert_data_Click

        /// <summary>User clicked button cancel</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
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

        /// <summary>User clicked button test data</summary>
        private void m_button_check_data_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            string error_message = @"";

            int test_case = 0; // Set to zero for no test

            UseCheckForFunctionTest(test_case);

            if (test_case != 0)
            {
                return;
            }

            string result_message = @"";
            if (PhotoDeveloper.CheckData(m_textbox_message, out result_message, out error_message))
            {
                MessageBox.Show(result_message);
                return;
            }
            else
            {
                MessageBox.Show(error_message);
                return;
            }
   
        } // m_button_check_data_Click

        /// <summary>
        /// Function for tests of new functions
        /// </summary>
        /// <param name="i_test_case">Test case</param>
        private void UseCheckForFunctionTest(int i_test_case)
        {
            string error_message = @"";

            if (i_test_case == 1)
            {
                m_textbox_message.Text = "Download";


                if (!PhotoDeveloper.TestDownLoadFile(out error_message))
                {
                    m_textbox_message.Text = "Error downloading directory " + error_message;
                    MessageBox.Show(error_message);
                    return;
                }

                m_textbox_message.Text = "File is downloaded";
            }

            else if (i_test_case == 2)
            {
                m_textbox_message.Text = "Create JazzGalerieZwei.htm";

                bool debug_flag = true;

                PhotoUpload photo_upload = new PhotoUpload(debug_flag);

                if (!photo_upload.GenerateJazzGalleryTwoHtmlFile(out error_message))
                {
                    m_textbox_message.Text = "Error creating file " + error_message;
                    MessageBox.Show(error_message);
                    return;
                }

                if (!photo_upload.UploadGalleryFileTwo(out error_message))
                {
                    m_textbox_message.Text = "Error uploading file " + error_message;
                    MessageBox.Show(error_message);
                    return;
                }

                m_textbox_message.Text = "JazzGalerieZwei.htm is created";
            }

        } // UseCheckForFunctionTest

        /// <summary>User clicked clicked create list with tool tips</summary>
        private void m_button_tool_tips_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            string file_name = @"";
            PhotoStrings.CreateFileToolTips(out file_name);

            System.Diagnostics.Process.Start("notepad.exe", file_name);

        } // m_button_tool_tips_Click

        /// <summary>User clicked download HTM gallery files</summary>
        private void m_button_download_htm_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            string error_message = @"";
            string dir_name = @"";
            if (PhotoDeveloper.DownloadPhotoTwoHtmFiles(out dir_name, out error_message))
            {
                m_textbox_message.Text = PhotoStrings.MsgPhotoHtmGalleryFilesDownloaded + dir_name;
                return;
            }
            else
            {
                MessageBox.Show(error_message);
                return;
            }

        } // m_button_download_htm_Click

        /// <summary>User clicked the Bugs button</summary>
        private void m_button_bugs_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            string error_message = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameAdminNewFunctionsBugs() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm bugs_form = new HelpForm(HelpFiles.GetFilenameAdminNewFunctionsBugs());
                bugs_form.Owner = this;
                bugs_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }

        } // m_button_bugs_Click

        /// <summary>User clicked the Help button</summary>
        private void m_button_help_Click(object sender, EventArgs e)
        {
            m_textbox_message.Text = @"";

            string error_message = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameMaintenancePhotos() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm help_form = new HelpForm(HelpFiles.GetFilenameMaintenancePhotos());
                help_form.Owner = this;
                help_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }

        } // m_button_help_Click

        /// <summary>User clicked the button create a ZIP list</summary>
        private void m_button_list_zip_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            string zip_list_file_name = @"";
            if (!PhotoDeveloper.CreateZipListFile(out zip_list_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            if (zip_list_file_name.Length > 10)
            {
                System.Diagnostics.Process.Start("notepad.exe", zip_list_file_name);
            }

            string missing_zip_list_file_name = @"";

            if (!PhotoDeveloper.CreateListMissingRegisteredZipFiles(out missing_zip_list_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            if (missing_zip_list_file_name.Length > 10)
            {
                System.Diagnostics.Process.Start("notepad.exe", missing_zip_list_file_name);
            }

        } // m_button_list_zip_Click

        /// <summary>User clicked the button upload gallery</summary>
        private void m_button_upload_gallery_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            string debug_file_name = @"";

            if (!PhotoDeveloper.UploadGallery(m_textbox_message, out debug_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            if (debug_file_name.Length > 10)
            {
                System.Diagnostics.Process.Start("notepad.exe", debug_file_name);
            }

        } // m_button_upload_gallery_Click

        #endregion // Event handling functions 

        #region Prevent user to use some commands

        /// <summary>Tell the user to use implemented close dialog buttons
        /// <para>Call of AdminUtils.FormIsClosing Case=2</para>
        /// </summary>
        private void PhotoDeveloperForm_FormClosing(object sender, FormClosingEventArgs i_event)
        {
            if (m_user_clicked_close_window)
            {
                return;
            }

            int i_case = 2;
            AdminUtils.FormIsClosing(i_event, i_case);

        } // JazzAppAdminForm_FormClosing

        #endregion // Prevent user to use some commands

        #region Edit photo

        /// <summary>Test of photo edit functions
        /// <para></para>
        /// </summary>
        private void m_button_photo_edit_Click(object sender, EventArgs e)
        {

            string input_photo_file_name = @"d20190223_Martin_Auer_PosterGunnar.jpg";
            string output_photo_file_name = @"PlakatNewsletter20190223.jpg";
            string output_photo_small_file_name = @"PlakatNewsletter20190223_Klein.jpg";
            string develop_dir = FileUtil.SubDirectory(PhotoMain.PhotoMaintenanceDir, Main.m_exe_directory) + @"\";
            string path_input_photo_file_name = develop_dir + input_photo_file_name;
            string path_output_photo_file_name = develop_dir + output_photo_file_name;
            string path_output_photo_small_file_name = develop_dir + output_photo_small_file_name;
            bool b_big = true;
            string error_message = @"";
            if (!PhotoEdit.ImagePosterNewsletter(b_big, path_input_photo_file_name, path_output_photo_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            b_big = false;
            if (!PhotoEdit.ImagePosterNewsletter(b_big, path_input_photo_file_name, path_output_photo_small_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            string edit_result = @"Plakat                 " + path_input_photo_file_name + "\r\n" +
                                 @"PlakatNewsletter       " + path_output_photo_file_name + "\r\n" +
                                 @"PlakatNewsletter_Klein " + path_output_photo_file_name + "\r\n";

            MessageBox.Show(edit_result);

        } // m_button_photo_edit_Click

        #endregion // Edit photo

    } // PhotoDeveloperForm

} // namespace
