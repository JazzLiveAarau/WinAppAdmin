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
    /// <summary>Edit publish page text</summary>
    public partial class PublishForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor</summary>
        public PublishForm(IndexForm i_index_form)
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

            SetToolTips();

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set tool tips</summary>
        private void SetToolTips()
        {
            ToolTipPublish.SetToolTip(this, JazzAppAdminSettings.Default.ToolTipPublish);
            ToolTipUtil.SetDelays(ref ToolTipPublish);
            ToolTipConcertEdit.SetToolTip(m_button_edit_concert_data, JazzAppAdminSettings.Default.ToolTipConcertEdit);
            ToolTipUtil.SetDelays(ref ToolTipConcertEdit);
            ToolTipConcertCancel.SetToolTip(m_button_cancel, JazzAppAdminSettings.Default.ToolTipConcertCancel);
            ToolTipUtil.SetDelays(ref ToolTipConcertCancel);
            ToolTipConcertClose.SetToolTip(m_button_close, JazzAppAdminSettings.Default.ToolTipConcertClose);
            ToolTipUtil.SetDelays(ref ToolTipConcertClose);
            ToolTipPublish.SetToolTip(m_label_publish, JazzAppAdminSettings.Default.ToolTipPublish);
            ToolTipPublish.SetToolTip(m_check_box_publish, JazzAppAdminSettings.Default.ToolTipPublish);
            ToolTipCurrentSeason.SetToolTip(m_label_website_current_season, JazzAppAdminSettings.Default.ToolTipCurrentSeason);
            ToolTipUtil.SetDelays(ref ToolTipCurrentSeason);
            ToolTipCurrentSeason.SetToolTip(m_check_box_website_current_season, JazzAppAdminSettings.Default.ToolTipCurrentSeason);
            ToolTipAutumnSpringYear.SetToolTip(m_label_autumn_year, JazzAppAdminSettings.Default.ToolTipAutumnSpringYear);
            ToolTipUtil.SetDelays(ref ToolTipAutumnSpringYear);
            ToolTipAutumnSpringYear.SetToolTip(m_text_box_autumn_year, JazzAppAdminSettings.Default.ToolTipAutumnSpringYear);
            ToolTipAutumnSpringYear.SetToolTip(m_label_spring_year, JazzAppAdminSettings.Default.ToolTipAutumnSpringYear);
            ToolTipAutumnSpringYear.SetToolTip(m_text_box_spring_year, JazzAppAdminSettings.Default.ToolTipAutumnSpringYear);

        } // SetToolTips

        /// <summary>Set controls editable or not</summary>
        private void SetEditable()
        {
            if (m_editable)
            {
                this.m_text_box_autumn_year.Enabled = true;
                this.m_text_box_spring_year.Enabled = true;

                this.m_check_box_publish.Enabled = true;
                this.m_check_box_website_current_season.Enabled = true;

                this.m_text_box_autumn_year.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_spring_year.BackColor = AdminUtils.ColorEnable();

                this.m_check_box_publish.BackColor = AdminUtils.ColorEnable();
                this.m_check_box_website_current_season.BackColor = AdminUtils.ColorEnable();
            }
            else
            {
                this.m_text_box_autumn_year.Enabled = false;
                this.m_text_box_spring_year.Enabled = false;

                this.m_check_box_publish.Enabled = false;
                this.m_check_box_website_current_season.Enabled = false;

                this.m_text_box_autumn_year.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_spring_year.BackColor = AdminUtils.ColorDisable();

                this.m_check_box_publish.BackColor = AdminUtils.ColorDisable();
                this.m_check_box_website_current_season.BackColor = AdminUtils.ColorDisable();
            }

        } // SetEditable


        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(Publish.GetTitlePage());
            this.m_label_page_header.Text = Publish.GetTitlePage();
            this.m_label_autumn_year.Text = Publish.GetTitleYearAutumn();
            this.m_label_spring_year.Text = Publish.GetTitleYearSpring();
            this.m_label_publish.Text = Publish.GetTitlePublishProgram();
            this.m_label_website_current_season.Text = Publish.GetTitlePublishSeasonStartYear();

        } // SetTitles

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_autumn_year.Text = Publish.GetYearAutum();
            this.m_text_box_spring_year.Text = Publish.GetYearSpring();

            bool b_published = Publish.GetPublishProgram();
            if (b_published)
                this.m_check_box_publish.Checked = true;
            else
                this.m_check_box_publish.Checked = false;

            bool b_publish_start_year = Publish.GetPublishSeasonStartYear();
            if (b_publish_start_year)
                this.m_check_box_website_current_season.Checked = true;
            else
                this.m_check_box_website_current_season.Checked = false;

        } // SetTexts

        #endregion // Set controls

        #region Write data

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";
            if (!Publish.WriteYearAutum(this.m_text_box_autumn_year.Text, out o_error)) return false;

            if (!Publish.WriteYearSpring(this.m_text_box_spring_year.Text, out o_error)) return false;

            if (!Publish.WritePublishProgram(this.m_check_box_publish.Checked, out o_error)) return false;

            if (!Publish.WritePublishSeasonStartYear(this.m_check_box_website_current_season.Checked, out o_error)) return false;

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

    } // PublishForm
} // namespace
