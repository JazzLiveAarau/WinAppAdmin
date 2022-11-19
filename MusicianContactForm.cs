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
    /// <summary>Edit musician contact page text</summary>
    public partial class MusicianContactForm : Form
    {
        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Constructor</summary>
        public MusicianContactForm(IndexForm i_index_form, int i_concert)
        {
            InitializeComponent();

            if (null == i_index_form)
                return;

            if (i_concert <= 0)
                return;

            m_index_form = i_index_form;

            MusicianContact.SetConcertNumber(i_concert);

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            SetEditable();

            SetTitles();

            SetCaptions();

            SetTexts();

            SetToolTips();

        } // Constructor



        /// <summary>Set tool tips</summary>
        private void SetToolTips()
        {
            ToolTipMusicianContact.SetToolTip(this, JazzAppAdminSettings.Default.ToolTipMusicianContact);
            ToolTipUtil.SetDelays(ref ToolTipMusicianContact);
            ToolTipMusicianContactEdit.SetToolTip(m_button_edit_concert_data, JazzAppAdminSettings.Default.ToolTipMusicianContactEdit);
            ToolTipUtil.SetDelays(ref ToolTipMusicianContactEdit);
            ToolTipMusicianContactCancel.SetToolTip(m_button_cancel, JazzAppAdminSettings.Default.ToolTipMusicianContactCancel);
            ToolTipUtil.SetDelays(ref ToolTipMusicianContactCancel);
            ToolTipMusicianContactClose.SetToolTip(m_button_close, JazzAppAdminSettings.Default.ToolTipMusicianContactClose);
            ToolTipUtil.SetDelays(ref ToolTipMusicianContactClose);

        } // SetToolTips


        /// <summary>Set controls editable or not</summary>
        private void SetEditable()
        {
            if (m_editable)
            {
                this.m_text_box_contact_name.Enabled = true;
                this.m_text_box_contact_email.Enabled = true;
                this.m_text_box_contact_telephone.Enabled = true;
                this.m_text_box_contact_street.Enabled = true;
                this.m_text_box_contact_post_code.Enabled = true;
                this.m_text_box_contact_city.Enabled = true;
                this.m_text_box_contact_password.Enabled = true;
                this.m_text_box_contact_iban.Enabled = true;
                this.m_text_box_contact_remark.Enabled = true;

                this.m_button_view_text.Enabled = false;
                this.m_button_view_text.Visible = false;


                this.m_text_box_contact_name.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_contact_email.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_contact_telephone.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_contact_street.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_contact_post_code.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_contact_city.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_contact_password.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_contact_iban.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_contact_remark.BackColor = AdminUtils.ColorEnable();


            }
            else
            {
                this.m_text_box_contact_name.Enabled = false;
                this.m_text_box_contact_email.Enabled = false;
                this.m_text_box_contact_telephone.Enabled = false;
                this.m_text_box_contact_street.Enabled = false;
                this.m_text_box_contact_post_code.Enabled = false;
                this.m_text_box_contact_city.Enabled = false;
                this.m_text_box_contact_password.Enabled = false;
                this.m_text_box_contact_iban.Enabled = false;
                this.m_text_box_contact_remark.Enabled = false;

                this.m_button_view_text.Enabled = true;
                this.m_button_view_text.Visible = true;

                this.m_text_box_contact_name.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_contact_email.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_contact_telephone.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_contact_street.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_contact_post_code.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_contact_city.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_contact_password.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_contact_iban.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_contact_remark.BackColor = AdminUtils.ColorDisable();

            }

        } // SetEditable

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(MusicianContact.GetTitlePage());
            this.m_label_page_header.Text = MusicianContact.GetTitlePage();
            this.m_label_name.Text = MusicianContact.GetTitleName();
            this.m_label_email.Text = MusicianContact.GetTitleEmail();
            this.m_label_telephone.Text = MusicianContact.GetTitleTelephone();
            this.m_label_street.Text = MusicianContact.GetTitleStreet();
            this.m_label_post_code.Text = MusicianContact.GetTitlePostCode();
            this.m_label_city.Text = MusicianContact.GetTitleCity();
            this.m_label_password.Text = MusicianContact.GetTitleLoginPassword();
            this.m_label_iban_number.Text = MusicianContact.GetTitleIbanNumber();
            this.m_label_remark.Text = MusicianContact.GetTitleContactRemark();
            this.m_button_view_text.Text = MusicianContact.GetCaptionViewContactDataAsText();

        } // SetTitles

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_contact_name.Text = MusicianContact.GetContactPerson();
            this.m_text_box_contact_email.Text = MusicianContact.GetContactEmail();
            this.m_text_box_contact_telephone.Text = MusicianContact.GetContactTelephone();
            this.m_text_box_contact_street.Text = MusicianContact.GetContactStreet();
            this.m_text_box_contact_post_code.Text = MusicianContact.GetContactPostCode();
            this.m_text_box_contact_city.Text = MusicianContact.GetContactCity();
            this.m_text_box_contact_password.Text = MusicianContact.GetMusicianLoginPassword();
            this.m_text_box_contact_iban.Text = MusicianContact.GetIbanNumber();
            this.m_text_box_contact_remark.Text = MusicianContact.GetContactRemark();

        } // SetTexts

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            if (!MusicianContact.WriteContactPerson(this.m_text_box_contact_name.Text, out o_error)) return false;

            if (!MusicianContact.WriteContactEmail(this.m_text_box_contact_email.Text, out o_error)) return false;

            if (!MusicianContact.WriteContactTelephone(this.m_text_box_contact_telephone.Text, out o_error)) return false;

            if (!MusicianContact.WriteContactStreet(this.m_text_box_contact_street.Text, out o_error)) return false;

            if (!MusicianContact.WriteContactPostCode(this.m_text_box_contact_post_code.Text, out o_error)) return false;

            if (!MusicianContact.WriteContactCity(this.m_text_box_contact_city.Text, out o_error)) return false;

            if (!MusicianContact.WriteLoginPassword(this.m_text_box_contact_password.Text, out o_error)) return false;

            if (!MusicianContact.WriteIbanNumber(this.m_text_box_contact_iban.Text, out o_error)) return false;

            if (!MusicianContact.WriteContactRemark(this.m_text_box_contact_remark.Text, out o_error)) return false;

            return true;

        } // WriteTexts

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

        /// <summary>User clicked the button view contact data as text</summary>
        private void m_button_view_text_Click(object sender, EventArgs e)
        {
            string file_name = @"";
            string error_message = @"";
            bool b_create_file = MusicianContact.CreateContactDataTextFile(out file_name, out error_message);

            if (b_create_file && file_name.Length > 5)
            {
                System.Diagnostics.Process.Start("notepad.exe", file_name);
            }

        } // m_button_view_text_Click


    } // MusicianContactForm
} // namespace
