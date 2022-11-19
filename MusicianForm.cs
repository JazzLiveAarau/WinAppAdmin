using JazzApp;
using System;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Edit musician page text</summary>
    public partial class MusicianForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor</summary>
        public MusicianForm(IndexForm i_index_form, int i_concert, int i_musician)
        {
            InitializeComponent();

            if (null == i_index_form)
                return;

            if (i_concert <= 0 || i_musician <= 0)
                return;

            m_index_form = i_index_form;

            Musician.SetConcertNumber(i_concert);
            Musician.SetMusicianNumber(i_musician);

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
            ToolTipMusician.SetToolTip(this, JazzAppAdminSettings.Default.ToolTipMusician);
            ToolTipUtil.SetDelays(ref ToolTipMusician);
            ToolTipMusicianEdit.SetToolTip(m_button_edit_musician_data, JazzAppAdminSettings.Default.ToolTipMusicianEdit);
            ToolTipUtil.SetDelays(ref ToolTipMusicianEdit);
            ToolTipMusicianDelete.SetToolTip(m_button_delete_musician, JazzAppAdminSettings.Default.ToolTipMusicianDelete);
            ToolTipUtil.SetDelays(ref ToolTipMusicianDelete);
            ToolTipMusicianCancel.SetToolTip(m_button_cancel, JazzAppAdminSettings.Default.ToolTipMusicianCancel);
            ToolTipUtil.SetDelays(ref ToolTipMusicianCancel);
            ToolTipMusicianClose.SetToolTip(m_button_close, JazzAppAdminSettings.Default.ToolTipMusicianClose);
            ToolTipUtil.SetDelays(ref ToolTipMusicianClose);

        } // SetToolTips


        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(Musician.GetTitlePage());
            this.m_label_page_header.Text = Musician.GetTitlePage();
            this.m_label_name.Text = Musician.GetTitleName();
            this.m_label_instrument.Text = Musician.GetTitleInstrument();
            this.m_label_birth_year.Text = Musician.GetTitleBirthYear();
            this.m_label_female.Text = Musician.GetTitleFemail();
            this.m_label_male.Text = Musician.GetTitleMail();
        } // SetTitles

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_musician_name.Text = Musician.GetName();
            this.m_rich_text_box_musician.Text = Musician.GetText();
            this.m_text_box_instrument.Text = Musician.GetInstrument();
            this.m_text_box_birth_year.Text = Musician.GetBirthYear();
            
            if (Musician.IsGenderMale())
            {
                m_radio_button_male.Checked = true;
                m_radio_button_female.Checked = false;
            }
            else
            {
                m_radio_button_male.Checked = false;
                m_radio_button_female.Checked = true;
            }

        } // SetTexts

        /// <summary>Set controls editable or not</summary>
        private void SetEditable()
        {
            if (m_editable)
            {
                m_text_box_musician_name.Enabled = true;
                m_text_box_instrument.Enabled = true;
                m_rich_text_box_musician.Enabled = true;
                m_text_box_birth_year.Enabled = true;
                m_radio_button_male.Enabled = true;
                m_radio_button_female.Enabled = true;

                m_text_box_musician_name.BackColor = AdminUtils.ColorEnable();
                m_text_box_instrument.BackColor = AdminUtils.ColorEnable();
                m_rich_text_box_musician.BackColor = AdminUtils.ColorEnable();
                m_text_box_birth_year.BackColor = AdminUtils.ColorEnable();
                m_radio_button_male.BackColor = AdminUtils.ColorEnable();
                m_radio_button_female.BackColor = AdminUtils.ColorEnable();
            }
            else
            {
                m_text_box_musician_name.Enabled = false;
                m_text_box_instrument.Enabled = false;
                m_rich_text_box_musician.Enabled = false;
                m_text_box_birth_year.Enabled = false;
                // Text also disappears for Enabled=false. 
                // Therefore m_label_male and m_label_female
                m_radio_button_male.Enabled = false;
                m_radio_button_female.Enabled = false;

                m_text_box_musician_name.BackColor = AdminUtils.ColorDisable();
                m_text_box_instrument.BackColor = AdminUtils.ColorDisable();
                m_rich_text_box_musician.BackColor = AdminUtils.ColorDisable(); // TODO Does not work
                m_text_box_birth_year.BackColor = AdminUtils.ColorDisable();
                m_radio_button_male.BackColor = AdminUtils.ColorDisable();
                m_radio_button_female.BackColor = AdminUtils.ColorDisable();
            }

        } // SetEditable
        #endregion Set controls

        #region Write data

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            if (!Musician.WriteName(this.m_text_box_musician_name.Text, out o_error)) return false;
            if (!Musician.WriteInstrument(this.m_text_box_instrument.Text, out o_error)) return false;
            if (!Musician.WriteText(this.m_rich_text_box_musician.Text, out o_error)) return false;
            if (!Musician.WriteBirthYear(this.m_text_box_birth_year.Text, out o_error)) return false;

            if (m_radio_button_male.Checked)
            {
                Musician.WriteGenderMale();
            }
            else
            {
                Musician.WriteGenderFemale();
            }

            return true;
        } // WriteTexts

        #endregion // Write data

        #region Exit event functions

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

        /// <summary>User clicked the cancel button</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } // m_button_cancel_Click

        #endregion // Exit event functions

        #region Edit

        /// <summary>User clicked the edit button</summary>
        private void m_button_edit_musician_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                m_index_form.CheckoutData();

                m_editable = true;

                SetCaptions();

                SetEditable();
            }

        } // m_button_edit_musician_data_Click

        #endregion // Edit

        #region Delete musician

        /// <summary>Delete musician</summary>
        private void m_button_delete_musician_Click(object sender, EventArgs e)
        {
            int stat_remove = JazzXml.RemoveMusicianNode(AdminUtils.GetCurrentConcertNumber(), AdminUtils.GetCurrentMusicianNumber());
            if (0 == stat_remove)
            {
                AdminUtils.SetCurrentMusicianNumber(1);
                this.Close();
            }
            else if (-1 == stat_remove)
            {               
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgRemoveLastMusician);
            }
            else
            {
                MessageBox.Show("MusicianForm Programming error: Removing musician failed stat_remove= " + stat_remove.ToString());
            }

        } // m_button_delete_musician_Click

        #endregion Delete musician

    } // MusicianForm
} // namespace
