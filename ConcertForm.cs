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
    /// <summary>Edit concert page text</summary>
    public partial class ConcertForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor</summary>
        public ConcertForm(IndexForm i_index_form, int i_concert)
        {
            InitializeComponent();

            if (null == i_index_form)
                return;

            if (i_concert <= 0)
                return;

            m_index_form = i_index_form;

            Concert.SetConcertNumber(i_concert);

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;


            SetEditable();

            SetTitles();

            SetCaptions();

            SetTexts();

            SetToolTips();

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set tool tips</summary>
        private void SetToolTips()
        {
            ToolTipConcert.SetToolTip(this, JazzAppAdminSettings.Default.ToolTipConcert);
            ToolTipUtil.SetDelays(ref ToolTipConcert);
            ToolTipConcertEdit.SetToolTip(m_button_edit_concert_data, JazzAppAdminSettings.Default.ToolTipConcertEdit);
            ToolTipUtil.SetDelays(ref ToolTipConcertEdit);
            ToolTipConcertDelete.SetToolTip(m_button_delete_concert, JazzAppAdminSettings.Default.ToolTipConcertDelete);
            ToolTipUtil.SetDelays(ref ToolTipConcertDelete);
            ToolTipConcertCancel.SetToolTip(m_button_cancel, JazzAppAdminSettings.Default.ToolTipConcertCancel);
            ToolTipUtil.SetDelays(ref ToolTipConcertCancel);
            ToolTipConcertClose.SetToolTip(m_button_close, JazzAppAdminSettings.Default.ToolTipConcertClose);
            ToolTipUtil.SetDelays(ref ToolTipConcertClose);

        } // SetToolTips


        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set controls editable or not</summary>
        private void SetEditable()
        {
            if (m_editable)
            {
                this.m_rich_text_box_short_text.Enabled = true;
                this.m_rich_text_box_additional_text.Enabled= true;

                this.m_text_box_band_name.Enabled = true;
                this.m_text_box_sound_sample.Enabled = false; // 2021-02-22
                this.m_text_box_www_band.Enabled = true;
                this.m_text_box_www_band_qr.Enabled = false; // 2021-02-14
                this.m_text_box_photo_one.Enabled = false; // 2021-02-12
                this.m_text_box_photo_two.Enabled = false; // 2021-02-12
                this.m_text_box_photo_one_zip.Enabled = false; // 2021-02-12
                this.m_text_box_photo_two_zip.Enabled = false; // 2021-02-12
                this.m_text_box_start_time.Enabled = true;
                this.m_text_box_end_time.Enabled = true;
                this.m_text_box_poster_small.Enabled = false;  // 2021-02-22
                this.m_text_box_poster_mid.Enabled = false; // 2021-02-22

                this.m_date_time_picker_concert.Enabled = true;



                this.m_rich_text_box_short_text.BackColor = AdminUtils.ColorEnable();
                this.m_rich_text_box_additional_text.BackColor = AdminUtils.ColorEnable();

                this.m_text_box_band_name.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_sound_sample.BackColor = AdminUtils.ColorDisable(); // 2021-02-22
                this.m_text_box_www_band.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_www_band_qr.BackColor = AdminUtils.ColorDisable(); // 2021-02-14
                this.m_text_box_photo_one.BackColor = AdminUtils.ColorDisable(); // 2021-02-12
                this.m_text_box_photo_two.BackColor = AdminUtils.ColorDisable(); // 2021-02-12
                this.m_text_box_photo_one_zip.BackColor = AdminUtils.ColorDisable(); // 2021-02-12
                this.m_text_box_photo_two_zip.BackColor = AdminUtils.ColorDisable(); // 2021-02-12
                this.m_text_box_start_time.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_end_time.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_poster_small.BackColor = AdminUtils.ColorDisable(); // 2021-02-22
                this.m_text_box_poster_mid.BackColor = AdminUtils.ColorDisable(); // 2021-02-22
            }
            else
            {
                this.m_rich_text_box_short_text.Enabled = false;
                this.m_rich_text_box_additional_text.Enabled = false;

                this.m_text_box_band_name.Enabled = false;
                this.m_text_box_sound_sample.Enabled = false;
                this.m_text_box_www_band.Enabled = false;
                this.m_text_box_www_band_qr.Enabled = false;
                this.m_text_box_photo_one.Enabled = false;
                this.m_text_box_photo_two.Enabled = false;
                this.m_text_box_photo_one_zip.Enabled = false;
                this.m_text_box_photo_two_zip.Enabled = false;
                this.m_text_box_start_time.Enabled = false;
                this.m_text_box_end_time.Enabled = false;
                this.m_text_box_poster_small.Enabled = false;
                this.m_text_box_poster_mid.Enabled = false;

                this.m_date_time_picker_concert.Enabled = false;



                this.m_rich_text_box_short_text.BackColor = AdminUtils.ColorDisable(); // TODO Does not work
                this.m_rich_text_box_additional_text.BackColor = AdminUtils.ColorDisable(); // TODO Does not work

                this.m_text_box_band_name.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_sound_sample.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_www_band.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_www_band_qr.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_photo_one.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_photo_two.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_photo_one_zip.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_photo_two_zip.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_start_time.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_end_time.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_poster_small.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_poster_mid.BackColor = AdminUtils.ColorDisable();

            }

        } // SetEditable

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(Concert.GetTitlePage());
            this.m_label_page_header.Text = Concert.GetTitlePage();
            this.m_label_concert_date.Text = Concert.GetTitleDate();
            this.m_label_start_time.Text = Concert.GetTitleStartTime();
            this.m_label_end_time.Text = Concert.GetTitleEndTime();
            this.m_label_name.Text = Concert.GetTitleName();
            this.m_label_short_text.Text = Concert.GetTitleShortText();
            this.m_label_additional_text.Text = Concert.GetTitleAdditionalText();
            this.m_label_day_name.Text = Concert.GetTitleDayName();

        } // SetTitles

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_rich_text_box_short_text.Text = Concert.GetShortText();
            this.m_rich_text_box_additional_text.Text = Concert.GetAdditionalText();

            this.m_text_box_band_name.Text = Concert.GetBandName();
            this.m_text_box_sound_sample.Text = Concert.GetSoundSample();
            this.m_text_box_www_band.Text = Concert.GetBandWebsite();
            this.m_text_box_www_band_qr.Text = Path.GetFileName(Concert.GetBandWebsiteQrCode());
            this.m_text_box_photo_one.Text = Concert.GetPhotoGalleryOne();
            this.m_text_box_photo_two.Text = Concert.GetPhotoGalleryTwo();
            this.m_text_box_photo_one_zip.Text = Concert.GetPhotoGalleryOneZip();
            this.m_text_box_photo_two_zip.Text = Concert.GetPhotoGalleryTwoZip();
            this.m_text_box_start_time.Text = Concert.GetStartTime();
            this.m_text_box_end_time.Text = Concert.GetEndTime();
            this.m_text_box_poster_small.Text = Concert.GetPosterSmallSize();
            this.m_text_box_poster_mid.Text = Concert.GetPosterMidSize();

            this.m_date_time_picker_concert.Value = new DateTime(Concert.GetYearInt(), Concert.GetMonthInt(), Concert.GetDayInt());
 
        } // SetTexts

        #endregion // Set controls

        #region Write data

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            if (!Concert.WriteBandName(this.m_text_box_band_name.Text, out o_error)) return false;

            if (!Concert.WriteDate(m_date_time_picker_concert.Value.Year,
                                   m_date_time_picker_concert.Value.Month,
                                   m_date_time_picker_concert.Value.Day, out o_error)) return false;

            bool b_start = true;
            if (!Concert.WriteTime(b_start, this.m_text_box_start_time.Text, out o_error)) return false;

            b_start = false;
            if (!Concert.WriteTime(b_start, this.m_text_box_end_time.Text, out o_error)) return false;

            if (!Concert.WriteShortText(this.m_rich_text_box_short_text.Text, out o_error)) return false;

            if (!Concert.WriteAdditionalText(this.m_rich_text_box_additional_text.Text, out o_error)) return false;

            if (!Concert.WriteSoundSample(this.m_text_box_sound_sample.Text, out o_error)) return false;

            if (!Concert.WriteBandWebsite(this.m_text_box_www_band.Text, out o_error)) return false;

            if (!Concert.WritePhotoGalleryOne(this.m_text_box_photo_one.Text, out o_error)) return false;

            if (!Concert.WritePhotoGalleryTwo(this.m_text_box_photo_two.Text, out o_error)) return false;

            if (!Concert.WritePhotoGalleryOneZip(this.m_text_box_photo_one_zip.Text, out o_error)) return false;

            if (!Concert.WritePhotoGalleryTwoZip(this.m_text_box_photo_two_zip.Text, out o_error)) return false;

            if (!Concert.WritePosterSmallSize(this.m_text_box_poster_small.Text, out o_error)) return false;

            if (!Concert.WritePosterMidSize(this.m_text_box_poster_mid.Text, out o_error)) return false;

            return true;

        } // WriteTexts

        #endregion // Write data

        #region Edit

        /// <summary>User clicked the edit button</summary>
        private void m_button_edit_concert_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                m_index_form.CheckoutData();

                m_editable = true;

                SetCaptions();

                SetEditable();
            }
        } // m_button_edit_concert_data_Click

        #endregion // Edit

        #region Delete concert

        /// <summary>Delete concert</summary>
        private void m_button_delete_concert_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgCheckoutBeforeRemovingConcert);

                return;
            }

            string remove_message = @"";
            if (!Concert.ConcertMayBeDeleted(out remove_message))
            {
                MessageBox.Show(remove_message);

                return;
            }

            int n_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

            string warning_msg = JazzAppAdminSettings.Default.MsgReallyChangeNumberOfConcerts + (n_concerts-1).ToString() + @"?" + "\n" + JazzAppAdminSettings.Default.MsgContinue;

            DialogResult dialog_result = MessageBox.Show(warning_msg, DocAdminString.MsgWarning, MessageBoxButtons.YesNo);

            if (dialog_result == DialogResult.No)
            {
                return;
            }



            int stat_remove = JazzXml.RemoveConcertNode(AdminUtils.GetCurrentConcertNumber());
            if (0 == stat_remove)
            {
                AdminUtils.SetCurrentConcertNumber(1);
                this.Close();

                // Combobox in IndexForm is updated when this form is closed
            }
            else if (-1 == stat_remove)
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgRemoveLastConcert);
            }
            else
            {
                MessageBox.Show("ConcertForm Programming error: Removing concert failed stat_remove= " + stat_remove.ToString());
            }


        } // m_button_delete_concert_Click

        #endregion // Delete concert

        #region Exit event functions

        /// <summary>User clicked the cancel button</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } // m_button_cancel_Click

        /// <summary>User clicked the save/close button</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (m_editable)
            {
                string error_message = @"";
                if (!WriteTexts(out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }
            }

            this.Close();
        } // m_button_close_Click

        #endregion // Exit event functions

        #region Event date changed

        /// <summary>User changed the date</summary>
        private void m_date_time_picker_concert_ValueChanged(object sender, EventArgs e)
        {
            this.m_label_day_name.Text = Concert.GetDayName(m_date_time_picker_concert.Value.Year,
                                                            m_date_time_picker_concert.Value.Month,
                                                            m_date_time_picker_concert.Value.Day);

        } // m_date_time_picker_concert_ValueChanged

        #endregion // Event date changed

    } // ConcertForm

} // namespace
