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
    public partial class PremisesForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Flag defining if the user clicked close window</summary>
        private bool m_user_clicked_close_window = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor</summary>
        public PremisesForm(IndexForm i_index_form)
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

        #endregion // Constructor

        #region Set controls

        /// <summary>Set controls editable or not</summary>
        private void SetEditable()
        {
            if (m_editable)
            {
                this.m_text_box_premises_header.Enabled = true;
                this.m_text_box_premises_name.Enabled = true;
                this.m_text_box_premises_street.Enabled = true;
                this.m_text_box_premises_city.Enabled = true;
                this.m_text_box_premises_website.Enabled = true;
                this.m_text_box_premises_telephone.Enabled = true;
                this.m_text_box_premises_photo.Enabled = true;
                this.m_text_box_premises_map.Enabled = true;

                this.m_text_box_premises_header.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_premises_name.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_premises_street.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_premises_city.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_premises_website.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_premises_telephone.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_premises_photo.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_premises_map.BackColor = AdminUtils.ColorEnable();
            }
            else
            {
                this.m_text_box_premises_header.Enabled = false;
                this.m_text_box_premises_name.Enabled = false;
                this.m_text_box_premises_street.Enabled = false;
                this.m_text_box_premises_city.Enabled = false;
                this.m_text_box_premises_website.Enabled = false;
                this.m_text_box_premises_telephone.Enabled = false;
                this.m_text_box_premises_photo.Enabled = false;
                this.m_text_box_premises_map.Enabled = false;

                this.m_text_box_premises_header.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_premises_name.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_premises_street.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_premises_city.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_premises_website.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_premises_telephone.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_premises_photo.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_premises_map.BackColor = AdminUtils.ColorDisable();
            }

        } // SetEditable

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(Premises.GetTitlePage());
            this.m_label_page_header.Text = Premises.GetTitlePage();
            this.m_label_premises_header.Text = Premises.GetTitlePremisesHeader();
            this.m_label_premises_name.Text = XmlEditStrings.LabelPremisesName;
            this.m_label_premises_street.Text = XmlEditStrings.LabelPremisesStreet;
            this.m_label_premises_city.Text = XmlEditStrings.LabelPremisesCity;
            this.m_label_premises_website.Text = XmlEditStrings.LabelPremisesWebsite;
            this.m_label_premises_telephone.Text = XmlEditStrings.LabelPremisesTelephone;
            this.m_label_premises_photo.Text = XmlEditStrings.LabelPremisesPhoto;
            this.m_label_premises_map.Text = XmlEditStrings.LabelPremisesMap;

        } // SetTitles

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_premises_header.Text = Premises.GetPremisesHeader();
            this.m_text_box_premises_name.Text = Premises.GetPremises();
            this.m_text_box_premises_street.Text = Premises.GetPremisesStreet();
            this.m_text_box_premises_city.Text = Premises.GetPremisesCity();
            this.m_text_box_premises_website.Text = Premises.GetPremisesWebsite();
            this.m_text_box_premises_telephone.Text = Premises.GetPremisesTelephone();
            this.m_text_box_premises_photo.Text = Premises.GetPremisesPhoto();
            this.m_text_box_premises_map.Text = Premises.GetPremisesMap();

        } // SetTexts

        #endregion // Set controls

        #region Write

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            AdminUtils.SetApplicationDocumentChangeFlag(true);

            if (!Premises.WritePremisesHeader(this.m_text_box_premises_header.Text, out o_error)) return false;

            if (!Premises.WritePremises(this.m_text_box_premises_name.Text, out o_error)) return false;

            if (!Premises.WritePremisesStreet(this.m_text_box_premises_street.Text, out o_error)) return false;

            if (!Premises.WritePremisesCity(this.m_text_box_premises_city.Text, out o_error)) return false;

            if (!Premises.WritePremisesWebsite(this.m_text_box_premises_website.Text, out o_error)) return false;

            if (!Premises.WritePremisesTelephone(this.m_text_box_premises_telephone.Text, out o_error)) return false;

            if (!Premises.WritePremisesPhoto(this.m_text_box_premises_photo.Text, out o_error)) return false;

            if (!Premises.WritePremisesMap(this.m_text_box_premises_map.Text, out o_error)) return false;

            return true;

        } // WriteTexts

        #endregion // Write

        #region Edit and exit event functions

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
            m_user_clicked_close_window = true;

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

            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_close_Click

        #endregion // Edit and exit event functions

        #region Prevent user to use some commands

        /// <summary>Tell the user to use implemented close dialog buttons
        /// <para>Call of AdminUtils.FormIsClosing Case=2</para>
        /// </summary>
        private void PremisesForm_FormClosing(object sender, FormClosingEventArgs i_event)
        {
            if (m_user_clicked_close_window)
            {
                return;
            }

            int i_case = 2;
            AdminUtils.FormIsClosing(i_event, i_case);

        } // JazzAppAdminForm_FormClosing

        #endregion // Prevent user to use some commands

    } // PremisesForm
} // namespace
