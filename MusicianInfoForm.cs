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
    /// <summary>Edit musician information page text</summary>
    public partial class MusicianInfoForm : Form
    {
        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Constructor</summary>
        public MusicianInfoForm(IndexForm i_index_form)
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

            SetContactComboBox();

        } // Constructor

        /// <summary>Set controls editable or not</summary>
        private void SetEditable()
        {
            if (m_editable)
            {
                this.m_text_box_unload_street.Enabled = true;
                this.m_text_box_unload_city.Enabled = true;
                this.m_text_box_parking_one.Enabled = true;
                this.m_text_box_parking_two.Enabled = true;

                this.m_combo_box_contact_member.Enabled = true;

                this.m_text_box_unload_street.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_unload_city.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_parking_one.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_parking_two.BackColor = AdminUtils.ColorEnable();

                this.m_combo_box_contact_member.BackColor = AdminUtils.ColorEnable();
            }
            else
            {
                this.m_text_box_unload_street.Enabled = false;
                this.m_text_box_unload_city.Enabled = false;
                this.m_text_box_parking_one.Enabled = false;
                this.m_text_box_parking_two.Enabled = false;

                this.m_combo_box_contact_member.Enabled = false;

                this.m_text_box_unload_street.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_unload_city.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_parking_one.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_parking_two.BackColor = AdminUtils.ColorDisable();

                this.m_combo_box_contact_member.BackColor = AdminUtils.ColorDisable();
            }

        } // SetEditable

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(MusicianInfo.GetTitlePage());
            this.m_label_page_header.Text = MusicianInfo.GetTitlePage();
            this.m_label_contact_member.Text = MusicianInfo.GetTitleConcertContactMember();
            this.m_label_unload_street.Text = MusicianInfo.GetTitleUnloadStreet();
            this.m_label_unload_city.Text = MusicianInfo.GetTitleUnloadCity();
            this.m_label_parking_one.Text = MusicianInfo.GetTitleParkingOne();
            this.m_label_parking_two.Text = MusicianInfo.GetTitleParkingTwo();

        } // SetTitles

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_unload_street.Text = MusicianInfo.GetUnloadStreet();
            this.m_text_box_unload_city.Text = MusicianInfo.GetUnloadCity();
            this.m_text_box_parking_one.Text = MusicianInfo.GetParkingOne();
            this.m_text_box_parking_two.Text = MusicianInfo.GetParkingTwo();

        } // SetTexts

        /// <summary>Set combobox active members</summary>
        private void SetContactComboBox()
        {
            AdminUtils.SetComboBoxActiveMembers(this.m_combo_box_contact_member);

        } // SetContactComboBox


        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            AdminUtils.SetApplicationDocumentChangeFlag(true);

            if (!MusicianInfo.WriteUnloadStreet(this.m_text_box_unload_street.Text, out o_error)) return false;

            if (!MusicianInfo.WriteUnloadCity(this.m_text_box_unload_city.Text, out o_error)) return false;

            if (!MusicianInfo.WriteParkingOne(this.m_text_box_parking_one.Text, out o_error)) return false;

            if (!MusicianInfo.WriteParkingTwo(this.m_text_box_parking_two.Text, out o_error)) return false;

            return true;

        } // WriteTexts

        /// <summary>Write contact combobox number</summary>
        public bool WriteContactComboBox(out string o_error)
        {
            o_error = @"";

            AdminUtils.SetApplicationDocumentChangeFlag(true);

            if (!MusicianInfo.WriteContactComboBox(this.m_combo_box_contact_member.Text, out o_error)) return false;

            return true;
        } // WriteContactComboBox

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
                if (!WriteContactComboBox(out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }
            }

            this.Close();
        } // m_button_close_Click

    } // MusicianInfoForm
} // namespace
