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
    /// <summary>Edit concert premises page text</summary>
    public partial class ConcertPremisesForm : Form
    {
        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Constructor</summary>
        public ConcertPremisesForm(IndexForm i_index_form, int i_concert)
        {
            InitializeComponent();

            if (null == i_index_form)
                return;

            if (i_concert <= 0)
                return;

            m_index_form = i_index_form;

            ConcertPremises.SetConcertNumber(i_concert);

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
                this.m_text_box_premises_name.Enabled = true;
                this.m_text_box_premises_street.Enabled = true;
                this.m_text_box_premises_city.Enabled = true;

                this.m_text_box_premises_name.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_premises_street.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_premises_city.BackColor = AdminUtils.ColorEnable();

            }
            else
            {
                this.m_text_box_premises_name.Enabled = false;
                this.m_text_box_premises_street.Enabled = false;
                this.m_text_box_premises_city.Enabled = false;

                this.m_text_box_premises_name.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_premises_street.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_premises_city.BackColor = AdminUtils.ColorDisable();

            }

        } // SetEditable

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(ConcertPremises.GetTitlePage());
            this.m_label_page_header.Text = ConcertPremises.GetTitlePage();
            this.m_label_premises_name.Text = ConcertPremises.GetTitleConcertPremisesName();
            this.m_label_premises_street.Text = ConcertPremises.GetTitleConcertPremisesStreet();
            this.m_label_premises_city.Text = ConcertPremises.GetTitleConcertPremisesCity();

        } // SetTitles

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_premises_name.Text = ConcertPremises.GetPlace();
            this.m_text_box_premises_street.Text = ConcertPremises.GetStreet();
            this.m_text_box_premises_city.Text = ConcertPremises.GetCity();

        } // SetTexts

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            if (!ConcertPremises.WritePlace(this.m_text_box_premises_name.Text, out o_error)) return false;

            if (!ConcertPremises.WriteStreet(this.m_text_box_premises_street.Text, out o_error)) return false;

            if (!ConcertPremises.WriteCity(this.m_text_box_premises_city.Text, out o_error)) return false;

            return true;

        } // WriteTexts

        /// <summary>User clicked the edit button</summary>
        private void m_button_edit_premises_data_Click(object sender, EventArgs e)
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
        private void m_button_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        } // m_button_cancel_Click

        /// <summary>User clicked the save/close button</summary>
        private void m_button_close_Click_1(object sender, EventArgs e)
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


    } // ConcertPremisesForm
} // namespace
