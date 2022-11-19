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
    /// <summary>Edit contacts page text</summary>
    public partial class ContactForm : Form
    {
        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Constructor</summary>
        public ContactForm(IndexForm i_index_form)
        {
            InitializeComponent();

            if (null == i_index_form)
                return;

            m_index_form = i_index_form;

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            SetEditable();

            SetTitles();

            SetCaptions();

            SetTexts();

        } // Constructor

        /// <summary>Set controls editable or not</summary>
        private void SetEditable()
        {
            if (m_editable)
            {
                this.m_text_box_club_name.Enabled = true;
                this.m_text_box_club_mail_address.Enabled = true;
                this.m_text_box_club_email_address.Enabled = true;
                this.m_text_box_reservation_email_address.Enabled = true;
                this.m_text_box_newsletter_address.Enabled = false;
                this.m_text_box_support_email_address.Enabled = true;
                this.m_text_box_reservation_subject.Enabled = true;
                this.m_text_box_reservation_text.Enabled = true;
                this.m_text_box_newsletter_text.Enabled = true;
                this.m_text_box_newsletter_subject.Enabled = true;
                this.m_text_box_support_telephone.Enabled = true;

                this.m_text_box_club_name.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_club_mail_address.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_club_email_address.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_reservation_email_address.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_newsletter_address.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_support_email_address.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_reservation_subject.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_reservation_text.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_newsletter_text.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_newsletter_subject.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_support_telephone.BackColor = AdminUtils.ColorEnable();
            }
            else
            {
                this.m_text_box_club_name.Enabled = false;
                this.m_text_box_club_mail_address.Enabled = false;
                this.m_text_box_club_email_address.Enabled = false;
                this.m_text_box_reservation_email_address.Enabled = false;
                this.m_text_box_newsletter_address.Enabled = false;
                this.m_text_box_support_email_address.Enabled = false;
                this.m_text_box_reservation_subject.Enabled = false;
                this.m_text_box_reservation_text.Enabled = false;
                this.m_text_box_newsletter_text.Enabled = false;
                this.m_text_box_newsletter_subject.Enabled = false;
                this.m_text_box_support_telephone.Enabled = false;

                this.m_text_box_club_name.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_club_mail_address.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_club_email_address.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_reservation_email_address.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_newsletter_address.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_support_email_address.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_reservation_subject.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_reservation_text.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_newsletter_text.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_newsletter_subject.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_support_telephone.BackColor = AdminUtils.ColorDisable();
            }

        } // SetEditable

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(Contact.GetTitlePage());
            this.m_label_page_header.Text = Contact.GetTitlePage();
            this.m_label_jazzclub_name.Text = Contact.GetTitleClubName();
            this.m_label_jazzclub_address.Text = Contact.GetTitleMailHeader();
            this.m_label_jazzclub_email.Text = Contact.GetTitleEmailHeader();
            this.m_label_jazzclub_reservation.Text = Contact.GetTitleReservationHeader();
            this.m_label_jazzclub_support_email.Text = Contact.GetTitleWebmasterEmail();
            this.m_label_reservation_subject.Text = Contact.GetTitleReservationSubject();
            this.m_label_reservation_text.Text = Contact.GetTitleReservationText();
            this.m_label_newsletter_text.Text = Contact.GetTitleNewsletterText();
            this.m_label_newsletter_subject.Text = Contact.GetTitleNewsletterSubject();
            this.m_label_jazzclub_support_telephone.Text = Contact.GetTitleTelephoneWebmaster();

        } // SetTitles

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_club_name.Text = Contact.GetClubName();
            this.m_text_box_club_mail_address.Text = Contact.GetMailAddress();
            this.m_text_box_club_email_address.Text = Contact.GetEmailJazzLiveAarau();
            this.m_text_box_reservation_email_address.Text = Contact.GetEmailReservation();
            this.m_text_box_newsletter_address.Text = Contact.GetEmailJazzLiveAarau();
            this.m_text_box_support_email_address.Text = Contact.GetEmailWebmaster();
            this.m_text_box_reservation_subject.Text = Contact.GetReservationSubject();
            this.m_text_box_reservation_text.Text = Contact.GetReservationText();
            this.m_text_box_newsletter_text.Text = Contact.GetNewsletterText();
            this.m_text_box_newsletter_subject.Text = Contact.GetReservationSubject();
            this.m_text_box_support_telephone.Text = Contact.GetTelephoneWebmaster();

        } // SetTexts

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            AdminUtils.SetApplicationDocumentChangeFlag(true);

            if (!Contact.WriteClubName(this.m_text_box_club_name.Text, out o_error)) return false;

            if (!Contact.WriteMailAddress(this.m_text_box_club_mail_address.Text, out o_error)) return false;

            if (!Contact.WriteEmailJazzLiveAarau(this.m_text_box_club_email_address.Text, out o_error)) return false;

            if (!Contact.WriteEmailReservation(this.m_text_box_reservation_email_address.Text, out o_error)) return false;

            if (!Contact.WriteEmailJazzLiveAarau(this.m_text_box_newsletter_address.Text, out o_error)) return false;

            if (!Contact.WriteEmailWebmaster(this.m_text_box_support_email_address.Text, out o_error)) return false;

            if (!Contact.WriteReservationSubject(this.m_text_box_reservation_subject.Text, out o_error)) return false;

            if (!Contact.WriteReservationText(this.m_text_box_reservation_text.Text, out o_error)) return false;

            if (!Contact.WriteNewsletterText(this.m_text_box_newsletter_text.Text, out o_error)) return false;

            if (!Contact.WriteNewsletterSubject(this.m_text_box_newsletter_subject.Text, out o_error)) return false;

            if (!Contact.WriteTelephoneWebmaster(this.m_text_box_support_telephone.Text, out o_error)) return false;

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

    } // ContactForm
} // namespace
