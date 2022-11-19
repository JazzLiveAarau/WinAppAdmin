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
    /// <summary>Edit concept (about us) page text</summary>
    public partial class AboutUsForm : Form
    {
        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Constructor</summary>
        public AboutUsForm(IndexForm i_index_form)
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
                this.m_text_box_about_us_header.Enabled = true;

                this.m_rich_text_box_about_us_one.Enabled = true;
                this.m_rich_text_box_about_us_two.Enabled = true;
                this.m_rich_text_box_about_us_three.Enabled = true;

                this.m_text_box_about_us_header.BackColor = AdminUtils.ColorEnable();

                this.m_rich_text_box_about_us_one.BackColor = AdminUtils.ColorEnable();
                this.m_rich_text_box_about_us_two.BackColor = AdminUtils.ColorEnable();
                this.m_rich_text_box_about_us_three.BackColor = AdminUtils.ColorEnable();
            }
            else
            {
                this.m_text_box_about_us_header.Enabled = false;

                this.m_rich_text_box_about_us_one.Enabled = false;
                this.m_rich_text_box_about_us_two.Enabled = false;
                this.m_rich_text_box_about_us_three.Enabled = false;

                this.m_text_box_about_us_header.BackColor = AdminUtils.ColorDisable();

                this.m_rich_text_box_about_us_one.BackColor = AdminUtils.ColorDisable(); // Does not work
                this.m_rich_text_box_about_us_two.BackColor = AdminUtils.ColorDisable(); // Does not work
                this.m_rich_text_box_about_us_three.BackColor = AdminUtils.ColorDisable(); // Does not work
            }

        } // SetEditable

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(AboutUs.GetTitlePage());
            this.m_label_page_header.Text = AboutUs.GetTitlePage();
            this.m_label_about_us_header.Text = AboutUs.GetTitleAboutUsHeader();
            this.m_label_about_us_one.Text = AboutUs.GetTitleAboutUsOne();
            this.m_label_about_us_two.Text = AboutUs.GetTitleAboutUsTwo();
            this.m_label_about_us_three.Text = AboutUs.GetTitleAboutUsThree();

        } // SetTitles

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_about_us_header.Text = AboutUs.GetAboutUsHeader();
            this.m_rich_text_box_about_us_one.Text = AboutUs.GetAboutUsOne();
            this.m_rich_text_box_about_us_two.Text = AboutUs.GetAboutUsTwo();
            this.m_rich_text_box_about_us_three.Text = AboutUs.GetAboutUsThree();

        } // SetTexts

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            AdminUtils.SetApplicationDocumentChangeFlag(true);

            if (!AboutUs.WriteAboutUsHeader(this.m_text_box_about_us_header.Text, out o_error)) return false;

            if (!AboutUs.WriteAboutUsOne(this.m_rich_text_box_about_us_one.Text, out o_error)) return false;

            if (!AboutUs.WriteAboutUsTwo(this.m_rich_text_box_about_us_two.Text, out o_error)) return false;

            if (!AboutUs.WriteAboutUsThree(this.m_rich_text_box_about_us_three.Text, out o_error)) return false;


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

    } // AboutUsForm
} // namespace
