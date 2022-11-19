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
    /// <summary>Form for registration of nine gallery photos
    /// <para></para>
    /// </summary>
    public partial class PhotoGalleryForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        PhotoMainForm m_photo_main_form = null;

        /// <summary>The input photo object that holds the number of the gallery, the date and the name of the concert</summary>
        private JazzPhoto m_input_jazz_photo = null;

        /// <summary>The output photo object with photo file names and photo texts</summary>
        private JazzPhoto m_output_jazz_photo = null;

        /// <summary>Set the output photo object with photo file names and photo texts</summary>
        public void SetOutputJazzPhoto(JazzPhoto i_jazz_photo) { m_output_jazz_photo = i_jazz_photo; }

        /// <summary>Full path to the local directory with gallery pictures</summary>
        private string m_local_gallery_directory = @"";

        /// <summary>Flag defining if input controls are editable (always true for this dialog)</summary>
        private bool m_editable = true;

        /// <summary>Flag telling if the dialog controls are being initialized</summary>
        // bool m_is_initializing = false;

        /// <summary>Flag defining if the user clicked close window</summary>
        private bool m_user_clicked_close_window = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor
        /// <para>1. Set </para>
        /// <para>1. </para>
        /// <para>1. </para>
        /// <para>1. Sets the controls of the dialog</para>
        /// <para>2. Sets the tool tips</para>
        /// <para>3. Sets the picture boxes</para>
        /// </summary>
        /// <param name="i_photo_main_form">Object PhotoMainForm - the owner of this form</param>
        /// <param name="i_photo">Input object photo that holds the number of the gallery, the date and the name of the concert</param>
        public PhotoGalleryForm(PhotoMainForm i_photo_main_form, JazzPhoto i_photo)
        {
            InitializeComponent();

            if (null == i_photo_main_form)
                return;
            if (null == i_photo)
                return;

            m_photo_main_form = i_photo_main_form;

            m_input_jazz_photo = i_photo;

            m_output_jazz_photo = new JazzPhoto();
            m_output_jazz_photo = m_input_jazz_photo;

            if (!_LocalDirectory())
            {
                return;
            }

            if (!_SetCurrentSeason())
            {
                return;
            }

            _SetTexts();

            _SetToolTips();

            _SetCaptions();

            _SetPictureBoxes();

        } // Constructor

        #endregion // Constructor

        #region Local gallery directory

        /// <summary>Get data from the local gallery directory text file</summary>
        private bool _LocalDirectory()
        {
            string error_message = @"";

            if (!PhotoMain.GetNameAndPathToLocalGalleryDirectory(m_output_jazz_photo, out m_local_gallery_directory, out error_message))
            {
                error_message = @"PhotoGalleryForm._LocalDirectory GetNameAndPathToLocalGalleryDirectory failed " + error_message;
                m_textbox_message.Text = error_message;

                return false;
            }

            if (!m_output_jazz_photo.GetDataFromLocalGalleryDirectory(m_local_gallery_directory, out error_message))
            {
                error_message = @"PhotoGalleryForm._LocalDirectory JazzPhoto.GetDataFromLocalGalleryDirectory failed " + error_message;
                m_textbox_message.Text = error_message;

                return false;
            }

            return true;

        } // _LocalDirectory

        #endregion // Local gallery directory

        #region Current season

        /// <summary>Set current season</summary>
        private bool _SetCurrentSeason()
        {
            string error_message = @"";
            if (!PhotoMain.SetGallerySeason(m_output_jazz_photo, out error_message))
            {
                error_message = @"PhotoGalleryForm._SetCurrentSeason PhotoMain.SetGallerySeason failed " + error_message;
                m_textbox_message.Text = error_message;

                return false;
            }

            return true;
        }

        #endregion Current season

        #region Set controls

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = PhotoStrings.TitleGalleryForm;

            m_label_page_header.Text = PhotoStrings.TitleGalleryForm;

            m_textbox_band_name.Text = m_input_jazz_photo.BandName;

            m_textbox_gallery_number.Text = m_input_jazz_photo.GalleryName;

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            /*
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
            */
        } // SetToolTips

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // _SetCaptions

        /// <summary>Set picture boxes</summary>
        private void _SetPictureBoxes()
        {
            string error_message = @"";

            string small_picture_name = @"";

            bool b_big = false;

            int picture_number = 1;
            if (m_output_jazz_photo.GalleryPhotoName(b_big, picture_number, out small_picture_name, out error_message))
            {
                PhotoMain.SetPictureBox(m_picture_box_one, m_local_gallery_directory + small_picture_name);
            }

            picture_number = 2;
            if (m_output_jazz_photo.GalleryPhotoName(b_big, picture_number, out small_picture_name, out error_message))
            {
                PhotoMain.SetPictureBox(m_picture_box_two, m_local_gallery_directory + small_picture_name);
            }

            picture_number = 3;
            if (m_output_jazz_photo.GalleryPhotoName(b_big, picture_number, out small_picture_name, out error_message))
            {
                PhotoMain.SetPictureBox(m_picture_box_three, m_local_gallery_directory + small_picture_name);
            }

            picture_number = 4;
            if (m_output_jazz_photo.GalleryPhotoName(b_big, picture_number, out small_picture_name, out error_message))
            {
                PhotoMain.SetPictureBox(m_picture_box_four, m_local_gallery_directory + small_picture_name);
            }

            picture_number = 5;
            if (m_output_jazz_photo.GalleryPhotoName(b_big, picture_number, out small_picture_name, out error_message))
            {
                PhotoMain.SetPictureBox(m_picture_box_five, m_local_gallery_directory + small_picture_name);
            }

            picture_number = 6;
            if (m_output_jazz_photo.GalleryPhotoName(b_big, picture_number, out small_picture_name, out error_message))
            {
                PhotoMain.SetPictureBox(m_picture_box_six, m_local_gallery_directory + small_picture_name);
            }

            picture_number = 7;
            if (m_output_jazz_photo.GalleryPhotoName(b_big, picture_number, out small_picture_name, out error_message))
            {
                PhotoMain.SetPictureBox(m_picture_box_seven, m_local_gallery_directory + small_picture_name);
            }

            picture_number = 8;
            if (m_output_jazz_photo.GalleryPhotoName(b_big, picture_number, out small_picture_name, out error_message))
            {
                PhotoMain.SetPictureBox(m_picture_box_eight, m_local_gallery_directory + small_picture_name);
            }

            picture_number = 9;
            if (m_output_jazz_photo.GalleryPhotoName(b_big, picture_number, out small_picture_name, out error_message))
            {
                PhotoMain.SetPictureBox(m_picture_box_nine, m_local_gallery_directory + small_picture_name);
            }

        } // _SetPictureBoxes

        /// <summary>Get picture names for a given picture number. Returned names will be empty if they not are defined</summary>
        private bool _GetPictureNames(int i_picture_number, out string o_big_picture_name, out string o_small_picture_name, out string o_error)
        {
            o_error = @"";
            o_big_picture_name = @"";
            o_small_picture_name = @"";

            bool b_big = true;
            if (!m_output_jazz_photo.GalleryPhotoName(b_big, i_picture_number, out o_big_picture_name, out o_error))
            {
                o_error = "PhotoGalleryForm._GetPictureNames JazzPhoto.GalleryPhotoName(1) failed " + o_error;
                return false;
            }

            b_big = false;
            if (!m_output_jazz_photo.GalleryPhotoName(b_big, i_picture_number, out o_small_picture_name, out o_error))
            {
                o_error = "PhotoGalleryForm._GetPictureNames JazzPhoto.GalleryPhotoName(2) failed " + o_error;
                return false;
            }

            if (o_big_picture_name.Length > 0)
            {
                if (o_small_picture_name.Length == 0)
                {
                    o_error = "PhotoGalleryForm._GetPictureNames o_big_picture_name exists but not o_small_picture_name";
                    return false;
                }
            }

            if (o_big_picture_name.Length == 0)
            {
                if (o_small_picture_name.Length > 0)
                {
                    o_error = "PhotoGalleryForm._GetPictureNames o_small_picture_name exists but not o_big_picture_name";
                    return false;
                }
            }

            return true;

        } // _GetPictureNames


        #endregion // Set controls

        #region Exit dialog

        /// <summary>User clicked button cancel</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked button close</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            // Check data TODO
            string error_message = @"";
 
            if (!m_output_jazz_photo.WriteLocalGalleryDirectoryTxtFile(m_local_gallery_directory, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_close_Click

        #endregion // Exit dialog

        #region Picture box events

        /// <summary>Open PhotoPictureForm for the given photo number</summary>
        private void OpenPhotoPictureForm(int i_photo_number)
        {
            RemoveImage(i_photo_number);

            PhotoPictureForm photo_picture_form = new PhotoPictureForm(m_photo_main_form, this, m_output_jazz_photo, i_photo_number);
            photo_picture_form.Owner = this;
            photo_picture_form.ShowDialog();

            // In PhotoPictureForm must SetOutputJazzPhoto be called at close 
            _SetPictureBoxes();

        } // OpenPhotoPictureForm

        /// <summary>Remove image that shall be replaced</summary>
        private void RemoveImage(int i_photo_number)
        {
            if (!m_output_jazz_photo.SmallPictureIsSet(i_photo_number))
            {
                return;
            }

            if (1 == i_photo_number)
            {
                PhotoMain.FreePictureBox(m_picture_box_one);
            }
            else if (2 == i_photo_number)
            {
                PhotoMain.FreePictureBox(m_picture_box_two);
            }
            else if (3 == i_photo_number)
            {
                PhotoMain.FreePictureBox(m_picture_box_three);
            }
            else if (4 == i_photo_number)
            {
                PhotoMain.FreePictureBox(m_picture_box_four);
            }
            else if (5 == i_photo_number)
            {
                PhotoMain.FreePictureBox(m_picture_box_five);
            }
            else if (6 == i_photo_number)
            {
                PhotoMain.FreePictureBox(m_picture_box_six);
            }
            else if (7 == i_photo_number)
            {
                PhotoMain.FreePictureBox(m_picture_box_seven);
            }
            else if (8 == i_photo_number)
            {
                PhotoMain.FreePictureBox(m_picture_box_eight);
            }
            else if (9 == i_photo_number)
            {
                PhotoMain.FreePictureBox(m_picture_box_nine);
            }

        } // RemoveImage

        /// <summary>User clicked picture box one</summary>
        private void m_picture_box_one_Click(object sender, EventArgs e)
        {
            OpenPhotoPictureForm(1);

        } // m_picture_box_one_Click

        /// <summary>User clicked picture box two</summary>
        private void m_picture_box_two_Click(object sender, EventArgs e)
        {
            OpenPhotoPictureForm(2);

        } // m_picture_box_two_Click

        /// <summary>User clicked picture box three</summary>
        private void m_picture_box_three_Click(object sender, EventArgs e)
        {
            OpenPhotoPictureForm(3);

        } // m_picture_box_three_Click

        /// <summary>User clicked picture box four</summary>
        private void m_picture_box_four_Click(object sender, EventArgs e)
        {
            OpenPhotoPictureForm(4);

        } // m_picture_box_four_Click

        /// <summary>User clicked picture box five</summary>
        private void m_picture_box_five_Click(object sender, EventArgs e)
        {
            OpenPhotoPictureForm(5);

        } // m_picture_box_five_Click

        /// <summary>User clicked picture box six</summary>
        private void m_picture_box_six_Click(object sender, EventArgs e)
        {
            OpenPhotoPictureForm(6);

        } // m_picture_box_six_Click

        /// <summary>User clicked picture box seven</summary>
        private void m_picture_box_seven_Click(object sender, EventArgs e)
        {
            OpenPhotoPictureForm(7);

        } // m_picture_box_seven_Click

        /// <summary>User clicked picture box eight</summary>
        private void m_picture_box_eight_Click(object sender, EventArgs e)
        {
            OpenPhotoPictureForm(8);

        } // m_picture_box_eight_Click

        /// <summary>User clicked picture box nine</summary>
        private void m_picture_box_nine_Click(object sender, EventArgs e)
        {
            OpenPhotoPictureForm(9);

        } // m_picture_box_nine_Click

        #endregion // Picture box events

        #region Prevent user to use some commands

        /// <summary>Tell the user to use implemented close dialog buttons
        /// <para>Call of AdminUtils.FormIsClosing Case=2</para>
        /// </summary>
        private void PhotoGalleryForm_FormClosing(object sender, FormClosingEventArgs i_event)
        {
            if (m_user_clicked_close_window)
            {
                return;
            }

            int i_case = 2;
            AdminUtils.FormIsClosing(i_event, i_case);

        } // JazzAppAdminForm_FormClosing

        #endregion // Prevent user to use some commands
 
    } // PhotoGalleryForm
} // namespace
