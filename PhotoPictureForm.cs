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
    /// <summary>Form for the selection of one big and one small photo
    /// <para></para>
    /// </summary>
    public partial class PhotoPictureForm : Form
    {
        #region Member variables

        /// <summary>The grandparent owner of this form</summary>
        PhotoMainForm m_photo_main_form = null;

        /// <summary>The owner of this form</summary>
        PhotoGalleryForm m_photo_gallery_form = null;

        /// <summary>Holds the input photo object</summary>
        private JazzPhoto m_input_jazz_photo = null;

        /// <summary>Input picure number</summary>
        int m_picture_number = -12345;

        /// <summary>Start background image for picture boxes </summary>
        Image m_picture_box_background_image = null;

        /// <summary>Holds photo input data from the user (from the form)</summary>
        private JazzPhoto m_output_jazz_photo = null;

        /// <summary>Musician names</summary>
        private string[] m_musicians = null;

        /// <summary>Instruments</summary>
        private string[] m_instruments = null;

        /// <summary>Full path to the local directory with gallery pictures</summary>
        private string m_local_gallery_directory = @"";

        /// <summary>Flag defining if input controls are editable (always true here)</summary>
        private bool m_editable = true;

        /// <summary>Flag telling if the dialog controls are being initialized</summary>
        bool m_is_initializing = false;

        /// <summary>Flag defining if the user clicked close window</summary>
        private bool m_user_clicked_close_window = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor
        /// <para>1. Sets the controls of the dialog</para>
        /// <para>2. Sets the tool tips</para>
        /// <para>3. Sets the picture boxes</para>
        /// </summary>
        public PhotoPictureForm(PhotoMainForm i_photo_main_form, PhotoGalleryForm i_photo_gallery_form , JazzPhoto i_photo, int i_picture_number)
        {
            InitializeComponent();

            if (null == i_photo_main_form)
                return;
            if (null == i_photo_gallery_form)
                return;
            if (null == i_photo)
                return;
            if (i_picture_number <= 0 || i_picture_number > 9)
                return;

            m_photo_main_form = i_photo_main_form;

            m_photo_gallery_form = i_photo_gallery_form;

            m_input_jazz_photo = i_photo;

            m_output_jazz_photo = new JazzPhoto();
            m_output_jazz_photo = m_input_jazz_photo;

            m_picture_number = i_picture_number;

            _LocalDirectory();

            m_is_initializing = true;

            _SetTexts();

            _SetPictureLabels();

            _SetToolTips();

            _SetCaptions();

            _SetPictureBoxes();

            _SetMusicianNameComboBox();

            _SetPhotoText();

            m_is_initializing = false;

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = PhotoStrings.TitlePictureForm;

            m_label_page_header.Text = PhotoStrings.TitlePictureForm;

            m_textbox_band_name.Text = m_input_jazz_photo.BandName;

            m_textbox_gallery_number.Text = m_input_jazz_photo.GalleryName;

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set picture labels</summary>
        private void _SetPictureLabels()
        {
            m_label_picture_1.Text = @"";
            m_label_picture_2.Text = @"";
            m_label_picture_3.Text = @"";
            m_label_picture_4.Text = @"";
            m_label_picture_5.Text = @"";
            m_label_picture_6.Text = @"";
            m_label_picture_7.Text = @"";
            m_label_picture_8.Text = @"";
            m_label_picture_9.Text = @"";

            m_label_picture_1.BorderStyle = BorderStyle.None;
            m_label_picture_2.BorderStyle = BorderStyle.None;
            m_label_picture_3.BorderStyle = BorderStyle.None;
            m_label_picture_4.BorderStyle = BorderStyle.None;
            m_label_picture_5.BorderStyle = BorderStyle.None;
            m_label_picture_6.BorderStyle = BorderStyle.None;
            m_label_picture_7.BorderStyle = BorderStyle.None;
            m_label_picture_8.BorderStyle = BorderStyle.None;
            m_label_picture_9.BorderStyle = BorderStyle.None;

            m_label_picture_1.BringToFront();
            m_label_picture_2.BringToFront();
            m_label_picture_3.BringToFront();
            m_label_picture_4.BringToFront();
            m_label_picture_5.BringToFront();
            m_label_picture_6.BringToFront();
            m_label_picture_7.BringToFront();
            m_label_picture_8.BringToFront();
            m_label_picture_9.BringToFront();

            // To set the border color to red is obviously not possible

            if (1 == m_picture_number)
            {
                m_label_picture_1.Text = m_picture_number.ToString();
            }
            else if (2 == m_picture_number)
            {
                m_label_picture_2.Text = m_picture_number.ToString();
            }
            else if (3 == m_picture_number)
            {
                m_label_picture_3.Text = m_picture_number.ToString();
            }
            else if (4 == m_picture_number)
            {
                m_label_picture_4.Text = m_picture_number.ToString();
            }
            else if (5 == m_picture_number)
            {
                m_label_picture_5.Text = m_picture_number.ToString();
            }
            else if (6 == m_picture_number)
            {
                m_label_picture_6.Text = m_picture_number.ToString();
            }
            else if (7 == m_picture_number)
            {
                m_label_picture_7.Text = m_picture_number.ToString();
            }
            else if (8 == m_picture_number)
            {
                m_label_picture_8.Text = m_picture_number.ToString();
            }
            else if (9 == m_picture_number)
            {
                m_label_picture_9.Text = m_picture_number.ToString();
            }
        } // _SetPictureLabels

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
            // TODO No übernehmen 
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // _SetCaptions

        /// <summary>Get data from the local gallery directory text file</summary>
        private bool _LocalDirectory()
        {
            string error_message = @"";

            if (!PhotoMain.GetNameAndPathToLocalGalleryDirectory(m_output_jazz_photo, out m_local_gallery_directory, out error_message))
            {
                error_message = @"PhotoPictureForm._LocalDirectory GetNameAndPathToLocalGalleryDirectory failed " + error_message;
                m_textbox_message.Text = error_message;

                return false;
            }

            return true;

        } // _LocalDirectory

        /// <summary>Set picture boxes</summary>
        private void _SetPictureBoxes()
        {
            m_picture_box_background_image = m_picture_box_big.BackgroundImage;

            string error_message = @"";

            if (m_output_jazz_photo.BigPictureIsSet(m_picture_number))
            {
                string small_picture_name = @"";
                bool b_big = false;
                if (m_output_jazz_photo.GalleryPhotoName(b_big, m_picture_number, out small_picture_name, out error_message))
                {
                    PhotoMain.SetPictureBox(m_picture_box_small, m_local_gallery_directory + small_picture_name);
                }

                string big_picture_name = @"";
                b_big = true;
                if (m_output_jazz_photo.GalleryPhotoName(b_big, m_picture_number, out big_picture_name, out error_message))
                {
                    PhotoMain.SetPictureBox(m_picture_box_big, m_local_gallery_directory + big_picture_name);
                }

            }

        } // _SetPictureBoxes

        /// <summary>Set photo text</summary>
        private void _SetPhotoText()
        {
            string picture_text =   @"";
            if (1 == m_picture_number)
                picture_text = m_output_jazz_photo.TextOne;
            else if (2 == m_picture_number)
                picture_text = m_output_jazz_photo.TextTwo;
            else if (3 == m_picture_number)
                picture_text = m_output_jazz_photo.TextThree;
            else if (4 == m_picture_number)
                picture_text = m_output_jazz_photo.TextFour;
            else if (5 == m_picture_number)
                picture_text = m_output_jazz_photo.TextFive;
            else if (6 == m_picture_number)
                picture_text = m_output_jazz_photo.TextSix;
            else if (7 == m_picture_number)
                picture_text = m_output_jazz_photo.TextSeven;
            else if (8 == m_picture_number)
                picture_text = m_output_jazz_photo.TextEight;
            else if (9 == m_picture_number)
                picture_text = m_output_jazz_photo.TextNine;

            m_text_box_picture_text.Text = picture_text;
        } // _SetPhotoText

        /// <summary>Set musician name combobox</summary>
        private void _SetMusicianNameComboBox()
        {
            string error_message = @"";
            if (!PhotoMain.GetComboBoxMusicianInstruments(m_output_jazz_photo, out m_musicians, out m_instruments, out error_message))
            {
                return;
            }

            PhotoMain.SetComboBoxMusicianNames(m_combo_box_picture_text, m_musicians, m_instruments);

        } // _SetMusicianNameComboBox


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
            bool b_big_picture = m_output_jazz_photo.BigPictureIsSet(m_picture_number);
            bool b_small_picture = m_output_jazz_photo.SmallPictureIsSet(m_picture_number);
            string error_message = @"";

            if (b_big_picture && b_small_picture)
            {
                if (!CheckIfTextIsSet())
                {
                    return;
                }

                m_photo_gallery_form.SetOutputJazzPhoto(m_output_jazz_photo);

                m_user_clicked_close_window = true;

                this.Close();

                return;
            }
            else if (!b_big_picture && !b_small_picture)
            {
                error_message = PhotoStrings.ErrMsgNoPictureSelected;
            }
            else if (b_big_picture && !b_small_picture)
            {
                error_message = PhotoStrings.ErrMsgOnlyBigPictureSelected;
            }
            else if (!b_big_picture && b_small_picture)
            {
                error_message = PhotoStrings.ErrMsgOnlySmallPictureSelected;
            }

            MessageBox.Show(error_message);

        } // m_button_close_Click

        /// <summary>Warning if there is no picture text</summary>
        private bool CheckIfTextIsSet()
        {
            string current_text = GetCurrentText();
            
            if (current_text.Trim().Length > 0)
            {
                return true;
            }

            string warning_msg = PhotoStrings.MsgNoPictureText + "\n" +
                      PhotoStrings.MsgNoPictureTextContinue;

            DialogResult dialog_result = MessageBox.Show(warning_msg, DocAdminString.MsgWarning, MessageBoxButtons.YesNo);

            if (dialog_result == DialogResult.No)
            {
                return false;
            }

            return true;

        } // CheckIfTestIsSet

        #endregion // Exit dialog

        #region Picture box events

        /// <summary>User clicked picture box big</summary>
        private void m_picture_box_small_Click(object sender, EventArgs e)
        {
            string error_message = @"";
            string small_picture_file_name = @"";
            bool b_big_picture = false;

            if (!PhotoMain.GetPictureForGallery(b_big_picture, out bool o_cancel_upload, out small_picture_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            bool b_big = false;
            if (!PhotoMain.IsPictureSizeWithinTol(b_big, small_picture_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            PhotoMain.FreePictureBox(m_picture_box_small);

            if (!IsPictureFileLocked(small_picture_file_name))
            {
                return;
            }

            if (!PhotoMain.CopyPictureForGallery(b_big_picture, m_picture_number, ref m_output_jazz_photo, small_picture_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            PhotoMain.SetPictureBox(m_picture_box_small, small_picture_file_name);

        } // m_picture_box_small_Click

        /// <summary>Is the picture file locked by another application</summary>
        private bool IsPictureFileLocked(string i_file_name)
        {
            string error_message = @"";
            if (!UpLoad.IsFileLocked(i_file_name, out error_message))
            {
                error_message = i_file_name + PhotoStrings.ErrMsgPictureFileLocked;

                MessageBox.Show(error_message);

                return false;
            }

            return true;
        }

        /// <summary>User clicked picture box big</summary>
        private void m_picture_box_big_Click(object sender, EventArgs e)
        {
            string error_message = @"";
            string big_picture_file_name = @"";
            bool b_big_picture = true;

            if (!PhotoMain.GetPictureForGallery(b_big_picture, out bool o_cancel_upload, out big_picture_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            bool b_big = true;
            if (!PhotoMain.IsPictureSizeWithinTol(b_big, big_picture_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            PhotoMain.FreePictureBox(m_picture_box_big);

            if (!IsPictureFileLocked(big_picture_file_name))
            {
                return;
            }

            if (!PhotoMain.CopyPictureForGallery(b_big_picture, m_picture_number, ref m_output_jazz_photo, big_picture_file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            PhotoMain.SetPictureBox(m_picture_box_big, big_picture_file_name);

        } // m_picture_box_big_Click

        #endregion // Picture box events

        #region Picture text

        /// <summary>User selected a musician</summary>
        private void m_combo_box_picture_text_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_is_initializing)
                return;

            int index_select = m_combo_box_picture_text.SelectedIndex;
            string musician_name = m_musicians[index_select]; 

            if (musician_name.Equals(PhotoStrings.PromptSelectMusician))
            {
                return;
            }

            SetCurrentText(musician_name);

            PhotoMain.SetComboBoxMusicianNames(m_combo_box_picture_text, m_musicians, m_instruments);

        } // m_combo_box_picture_text_SelectedIndexChanged

        /// <summary>Set current text</summary>
        private void SetCurrentText(string i_musician_name)
        {
            string current_text = GetCurrentText();
            if (current_text.Trim().Length == 0)
            {
                current_text = current_text + i_musician_name;
            }
            else
            {
                current_text = current_text + @" & " + i_musician_name;
            }

            SetJazzPhotoText(current_text);

            m_text_box_picture_text.Text = current_text;

        } // SetCurrentText

        /// <summary>Set jazz photo text</summary>
        private void SetJazzPhotoText(string i_text)
        {
            if (1 == m_picture_number)
                m_output_jazz_photo.TextOne = i_text;
            else if (2 == m_picture_number)
                m_output_jazz_photo.TextTwo = i_text;
            else if (3 == m_picture_number)
                m_output_jazz_photo.TextThree = i_text;
            else if (4 == m_picture_number)
                m_output_jazz_photo.TextFour = i_text;
            else if (5 == m_picture_number)
                m_output_jazz_photo.TextFive = i_text;
            else if (6 == m_picture_number)
                m_output_jazz_photo.TextSix = i_text;
            else if (7 == m_picture_number)
                m_output_jazz_photo.TextSeven = i_text;
            else if (8 == m_picture_number)
                m_output_jazz_photo.TextEight = i_text;
            else if (9 == m_picture_number)
                m_output_jazz_photo.TextNine = i_text;

        } // SetJazzPhotoText

        /// <summary>Get current text</summary>
        private string GetCurrentText()
        {
            if (1 == m_picture_number)
                return m_output_jazz_photo.TextOne;
            else if (2 == m_picture_number)
                return m_output_jazz_photo.TextTwo;
            else if (3 == m_picture_number)
                return m_output_jazz_photo.TextThree;
            else if (4 == m_picture_number)
                return m_output_jazz_photo.TextFour;
            else if (5 == m_picture_number)
                return m_output_jazz_photo.TextFive;
            else if (6 == m_picture_number)
                return m_output_jazz_photo.TextSix;
            else if (7 == m_picture_number)
                return m_output_jazz_photo.TextSeven;
            else if (8 == m_picture_number)
                return m_output_jazz_photo.TextEight;
            else if (9 == m_picture_number)
                return m_output_jazz_photo.TextNine;
            else
                return @"";

        } // GetCurrentText

        /// <summary>User clicked clear text</summary>
        private void m_button_clear_text_Click(object sender, EventArgs e)
        {
            m_text_box_picture_text.Text = @"";

            SetJazzPhotoText(@"");

        } // m_button_clear_text_Click

        /// <summary>User changed picture text</summary>
        private void m_text_box_picture_text_TextChanged(object sender, EventArgs e)
        {
            if (m_is_initializing)
                return;

            string picture_text = m_text_box_picture_text.Text;

            SetJazzPhotoText(picture_text);

        } // m_text_box_picture_text_TextChanged

        #endregion // Picture text

        #region Delete picture

        /// <summary>User clicked delete picture</summary>
        private void m_button_delete_picture_Click(object sender, EventArgs e)
        {
            if (this.m_picture_box_small.Image != null)
            {
                this.m_picture_box_small.Image.Dispose();
                this.m_picture_box_small.Image = null;
            }

            if (this.m_picture_box_big.Image != null)
            {
                this.m_picture_box_big.Image.Dispose();
                this.m_picture_box_big.Image = null;
            }

            m_picture_box_big.BackgroundImage = m_picture_box_background_image;
            m_picture_box_small.BackgroundImage = m_picture_box_background_image;

        } // m_button_delete_picture_Click

        #endregion // Delete picture

        #region Prevent user to use some commands

        /// <summary>Tell the user to use implemented close dialog buttons
        /// <para>Call of AdminUtils.FormIsClosing Case=2</para>
        /// </summary>
        private void PhotoPictureForm_FormClosing(object sender, FormClosingEventArgs i_event)
        {
            if (m_user_clicked_close_window)
            {
                return;
            }

            int i_case = 2;
            AdminUtils.FormIsClosing(i_event, i_case);

        } // JazzAppAdminForm_FormClosing

        #endregion // Prevent user to use some commands

    } // PhotoPictureForm

} // namespace
