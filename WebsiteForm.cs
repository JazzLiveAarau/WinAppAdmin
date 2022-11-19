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
    /// <summary>Update of the Website and Intranet based on changes/addition of XML files
    /// <para>This class has two execution classes: Website and Intranet</para>
    /// </summary>
    public partial class WebsiteForm : Form
    {
        #region Constructor

        /// <summary>Constructor that initializes the control elements</summary>
        public WebsiteForm()
        {
            InitializeComponent();

            _LoadCurrentXmlForWebsiteAndIntranet();

            _SetTitles();

            SetToolTips();

            InitProgressBar(3);

        } // Constructor

        #endregion // Constructor

        #region Set controls


        /// <summary>Set tool tips</summary>
        private void SetToolTips()
        {
            ToolTipHelp.SetToolTip(m_button_help, JazzAppAdminSettings.Default.ToolTipHelp);
            ToolTipUtil.SetDelays(ref ToolTipHelp);

            ToolTipUpdateJavaScriptFile.SetToolTip(m_button_update_website, JazzAppAdminSettings.Default.ToolTipUpdateJavaScriptFile);
            ToolTipUtil.SetDelays(ref ToolTipUpdateJavaScriptFile);

        } // SetToolTips

        /// <summary>Set titles for the edit pages</summary>
        private void _SetTitles()
        {
            this.Text = JazzAppAdminSettings.Default.GuiWebsiteTitle;
            this.m_label_website_htm.Text = JazzAppAdminSettings.Default.GuiWebsiteTextTitle;
            this.m_button_exit.Text = JazzAppAdminSettings.Default.Caption_Exit;
            this.m_button_close.Text = JazzAppAdminSettings.Default.Caption_Close;
            this.m_button_cancel.Text = JazzAppAdminSettings.Default.Caption_Cancel;
            this.m_button_update_website.Text  = JazzAppAdminSettings.Default.CaptionHomepageIntranetUpdate;
 
            this.m_textbox_message.Text = @"";

        } // _SetTitles

        #endregion // Set controls

        #region Progress bar

        /// <summary>Initialize progress bar. Input data is the maximum number of steps</summary>
        private void InitProgressBar(int i_maximum)
        {

            this.m_progress_bar_update.Visible = false;
            if (i_maximum <= 3)
                this.m_progress_bar_update.Maximum = 3;
            else
                this.m_progress_bar_update.Maximum = i_maximum;
            this.m_progress_bar_update.Step = 1;
            this.m_progress_bar_update.Value = 0;
            // http://stackoverflow.com/questions/8032996/c-sharp-progress-bar-change-color
            // Don't work this.m_progress_bar_update.BackColor = Color.Black;
            // Don't work this.m_progress_bar_update.ForeColor = Color.Red;

        } // InitProgressBar

        #endregion // Progress bar

        #region Reload XML

        /// <summary>Load current season and concert XML objects for Website and Intranet</summary>
        private void _LoadCurrentXmlForWebsiteAndIntranet()
        {
            string error_message = @"";
            if (!Website.LoadCurrentXmlForWebsiteAndIntranet(out error_message))
            {
                return;
            }
        } // _LoadCurrentXmlForWebsiteAndIntranet

        #endregion // Reload XML

        #region Event functions

        /// <summary>User cancelled</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } // m_button_cancel_Click

        /// <summary>User closed the window</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        } // m_button_close_Click

        /// <summary>User exited the application</summary>
        private void m_button_exit_Click(object sender, EventArgs e)
        {
            if (!Main.ApplicationExit())
            {
                return;
            }

            Application.Exit();

        } // m_button_exit_Click

        /// <summary>User clicked the update website button</summary>
        private void m_button_update_website_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            this.m_textbox_message.Text = @"";

            InitProgressBar(14);

            this.m_progress_bar_update.Visible = true;

            this.Update();

            this.m_progress_bar_update.PerformStep();

            if (!Intranet.UpdateIntranet(m_progress_bar_update, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);

                InitProgressBar(14);

                return;
            }
            

            InitProgressBar(14);

            this.m_textbox_message.Text = JazzAppAdminSettings.Default.MsgWebsiteIntranetUpdated;

        } // m_button_update_website_Click

        /*QQQQQQQ No longer necessary
         private void m_button_upload_posters_Click(object sender, EventArgs e)
                     string error_message = @"";

                    this.m_textbox_message.Text = @"";

                    InitProgressBar(24);

                    this.m_progress_bar_update.Visible = true;

                    this.Update();

                    this.m_progress_bar_update.PerformStep();

                    if (!Website.UpdatePosterNewsletter(m_progress_bar_update, m_textbox_message, out error_message))
                    {
                        MessageBox.Show(error_message);

                        InitProgressBar(3);

                        return;
                    }

                    InitProgressBar(3);

                    this.m_textbox_message.Text = JazzAppAdminSettings.Default.MsgPosterNewsletterUploaded;
        No longer necessary QQQQQQQQQQQQQQ*/

        /// <summary>User clicked the help button</summary>
        private void m_button_help_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameAdminWebsite() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm help_form = new HelpForm(HelpFiles.GetFilenameAdminWebsite());
                help_form.Owner = this;
                help_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }

        } // m_button_help_Click

        #endregion // Event functions

    } // WebsiteForm

} // namespace
