using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JazzApp;
using JazzVersion;

namespace JazzAppAdmin
{
    /// <summary>Main (start) form for the JAZZ live AARAU App Administration application
    /// <para>This is Graphical User Interface class. Commands should not be executed in this class.</para>
    /// </summary>
    public partial class JazzAppAdminForm : Form
    {
        /// <summary>Main class that executes most of the commands in this application</summary>
        private Main m_main = null;

        /// <summary>Flag telling if Internet connection is available</summary>
        bool m_internet_connection = true;

        /// <summary>Constructor: Checks the Internet connection. Sets the controls. Checks if there is a new version</summary>
        public JazzAppAdminForm()
        {
            InitializeComponent();

            string error_message = @"";

            if (!AdminUtils.IsInternetConnectionAvailable())
            {
                error_message = JazzAppAdminSettings.Default.ErrMsgNoInternetConnection + "\n" + JazzAppAdminSettings.Default.ErrMsgPleaseExitApplication;

                MessageBox.Show(error_message);

                // Application.Exit(); Does not work. With this.close there will be a crash 

                m_internet_connection = false;
            }

            if(m_internet_connection)
            {
                m_main = new Main(this);
            }
             
            _SetCaptions();

            _SetToolTips();

            if (m_internet_connection)
            {
                _VersionCheck();
            }

            if(!m_internet_connection)
            {
                this.m_textbox_message.Text = JazzAppAdminSettings.Default.ErrMsgPleaseExitApplication;
            }

            // DocAdminString.CreateFileToolTips(); // Temporary

        } // Construcor

 
        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            string tool_tip_admin_exec_dir = JazzAppAdminSettings.Default.ToolTipAdmin + Environment.CurrentDirectory;
            ToolTipAdmin.SetToolTip(this, tool_tip_admin_exec_dir);
            ToolTipAdmin.SetToolTip(m_picture_box_text_logo, tool_tip_admin_exec_dir);
            ToolTipAdmin.SetToolTip(m_label_admin, tool_tip_admin_exec_dir);
            ToolTipUtil.SetDelays(ref ToolTipAdmin);
            ToolTipHelp.SetToolTip(m_button_help, JazzAppAdminSettings.Default.ToolTipHelp);
            ToolTipUtil.SetDelays(ref ToolTipHelp);
            ToolTipDownload.SetToolTip(m_button_download, JazzAppAdminSettings.Default.ToolTipDownload);
            ToolTipUtil.SetDelays(ref ToolTipDownload);

            ToolTipEditXml.SetToolTip(m_button_index_xml, JazzAppAdminSettings.Default.ToolTipEditXml);
            ToolTipUtil.SetDelays(ref ToolTipEditXml);
            ToolTipUpdateWebsite.SetToolTip(m_button_htm, JazzAppAdminSettings.Default.ToolTipUpdateWebsite);
            ToolTipUtil.SetDelays(ref ToolTipUpdateWebsite);
            ToolTipDocuments.SetToolTip(m_button_documents, JazzAppAdminSettings.Default.ToolTipDocuments);
            ToolTipUtil.SetDelays(ref ToolTipDocuments);
            ToolTipUploadPhotos.SetToolTip(m_button_jpg, JazzAppAdminSettings.Default.ToolTipUploadPhotos);
            ToolTipUtil.SetDelays(ref ToolTipUploadPhotos);
            ToolTipRequests.SetToolTip(m_button_requests, JazzAppAdminSettings.Default.ToolTipRequests);
            ToolTipUtil.SetDelays(ref ToolTipRequests);
            ToolTipFlyer.SetToolTip(m_button_flyer, JazzAppAdminSettings.Default.ToolTipFlyer);
            ToolTipUtil.SetDelays(ref ToolTipFlyer);

            ToolTipAdminClose.SetToolTip(m_button_exit, JazzAppAdminSettings.Default.ToolTipAdminClose);
            ToolTipUtil.SetDelays(ref ToolTipAdminClose);
            ToolTipAdminMsg.SetToolTip(m_textbox_message, JazzAppAdminSettings.Default.ToolTipAdminMsg);
            ToolTipUtil.SetDelays(ref ToolTipAdminMsg);

        } // SetToolTips

        /// <summary>Checks if there is anew version is available
        /// <para>Message will be written to the message control if available.</para>
        /// </summary>
        private void _VersionCheck()
        {
            VersionInput version_input = new VersionInput();

            version_input.FtpHost = JazzAppAdminSettings.Default.FtpHost;
            version_input.FtpUser = JazzAppAdminSettings.Default.FtpUser;
            version_input.FtpPassword = Main.FtpWwwPassword;
            version_input.ExeDirectory = System.Windows.Forms.Application.StartupPath;
            version_input.VersionString = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            version_input.ServerDirectory = @"/" + JazzAppAdminSettings.Default.DirAdminServerMain + @"/" +
                                                   JazzAppAdminSettings.Default.LatestVersionInfoDir + @"/";
            version_input.LocalDirectory = JazzAppAdminSettings.Default.LatestVersionInfoDir;

            string error_message = @"";
            if (!VersionUtil.Init(version_input, out error_message))
            {
                m_label_version.Text = error_message;
                return;
            }

            string current_version_str = @"";
            if (!VersionUtil.GetCurrentVersion(out current_version_str, out error_message))
            {
                this.m_textbox_message.Text = @"JazzAppAdminForm._VersionCheck " +  error_message;
                return;
            }

            bool new_version = false;
            string new_version_str = @"";

            if (!VersionUtil.NewVersionIsAvailable(out new_version, out new_version_str, out error_message))
            {
                this.m_textbox_message.Text = error_message;
                this.m_label_version.Text = JazzAppAdminSettings.Default.Caption_ApplicationVersion + current_version_str;
                return;
            }

            this.m_label_version.Text = JazzAppAdminSettings.Default.Caption_ApplicationVersion + current_version_str;

            if (new_version)
            {
                this.m_textbox_message.Text = JazzAppAdminSettings.Default.MsgNewVersionIsAvailable + new_version_str;
            }

        } // _VersionCheck

        /// <summary>Set title and captions (labels) for this form
        /// <para>Captions are defined in the configuration file (class JazzAppAdminSettings), DocAdminString and RequestStrings.</para>
        /// </summary>
        private void _SetCaptions()
        {
            this.Text = JazzAppAdminSettings.Default.GuiTextProgramTitle;
            this.m_button_index_xml.Text = JazzAppAdminSettings.Default.GuiTextIndexTitle;
            this.m_button_documents.Text = DocAdminString.TitleDocAdminForm;
            this.m_button_requests.Text = RequestStrings.CaptionButtonRequests;
            this.m_button_jpg.Text = PhotoStrings.TitlePhotoMainForm;

            this.m_textbox_message.Text = "";
            this.m_textbox_message.Enabled= true;
            this.m_textbox_message.ReadOnly = true;

            this.m_label_version.Text = JazzAppAdminSettings.Default.Caption_ApplicationVersion;

        } // _SetCaptions()

        #region Button click events

        /// <summary>User clicked the Index (XML) button</summary>
        private void m_button_index_xml_Click(object sender, EventArgs e)
        {
            IndexForm index_xml_form = new IndexForm();
            index_xml_form.Owner = this;
            index_xml_form.ShowDialog();
        } // m_button_index_xml_Click

        /// <summary>User clicked the Website (HTM) button</summary>
        private void m_button_htm_Click(object sender, EventArgs e)
        {
            WebsiteForm index_xml_form = new WebsiteForm();
            index_xml_form.Owner = this;
            index_xml_form.ShowDialog();

        } // m_button_htm_Click

        /// <summary>User clicked the Documents (DOC, PDF) button</summary>
        private void m_button_documents_Click(object sender, EventArgs e)
        {
            DocAdminForm doc_admin_form = new DocAdminForm();
            doc_admin_form.Owner = this;
            doc_admin_form.ShowDialog();
        } // m_button_documents_Click

        /// <summary>User clicked the Photos (JPG) button</summary>
        private void m_button_jpg_Click(object sender, EventArgs e)
        {
            PhotoMainForm photo_main_form = new PhotoMainForm();
            photo_main_form.Owner = this;
            photo_main_form.ShowDialog();

            // MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgFunctionNotYetImplemented);
        } // m_button_jpg_Click

        /// <summary>User clicked the requests button</summary>
        private void m_button_requests_Click(object sender, EventArgs e)
        {
            RequestForm request_form = new RequestForm();
            request_form.Owner = this;
            request_form.ShowDialog();

        } // m_button_requests_Click

        /// <summary>User clicked the flyer button</summary>
        private void m_button_flyer_Click(object sender, EventArgs e)
        {
            FlyerForm flyer_form = new FlyerForm();
            flyer_form.Owner = this;
            flyer_form.ShowDialog();

        } // m_button_flyer_Click

        /// <summary>User clicked the news button</summary>
        private void m_button_news_Click(object sender, EventArgs e)
        {
            NewsForm news_form = new NewsForm();
            news_form.Owner = this;
            news_form.ShowDialog();

        } // m_button_news_Click

        /// <summary>User clicked the Exit button</summary>
        private void m_button_exit_Click(object sender, EventArgs e)
        {
            if (!Main.ApplicationExit())
            {
                return;
            }

            Application.Exit();

        } // m_button_exit_Click

        /// <summary>User clicked the Help button</summary>
        private void m_button_help_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameAdmin() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm help_form = new HelpForm(HelpFiles.GetFilenameAdmin());
                help_form.Owner = this;
                help_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }

        } // m_button_help_Click

        /// <summary>User clicked the Download button</summary>
        private void m_button_download_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            DownLoad down_load = new DownLoad();

            if (down_load.DownloadNewVersion(out error_message))
            {
                m_textbox_message.Text = JazzAppAdminSettings.Default.MsgInstallerDownload;
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgNewVersionDownload);
            }

        } // m_button_download_Click

        #endregion // Button click events

        #region Prevent user to use some commands

        /// <summary>Don't use Alt+f4 or close application from the taskbar
        /// <para>Call of AdminUtils.FormIsClosing Case=1</para>
        /// </summary>
        private void JazzAppAdminForm_FormClosing(object sender, FormClosingEventArgs i_event)
        {
            int i_case = 1;
            AdminUtils.FormIsClosing(i_event, i_case);
           
        } // JazzAppAdminForm_FormClosing

        #endregion // Prevent user to use some commands

        /// <summary>Event function - only - called the first time after creating the form.
        /// Unfortunately the form is not fully displayed, but the user will see that
        /// the program has started.
        /// <para>Load all season XML files. Call of JazzXml.InitXmlAllSeasons</para>
        /// </summary>
        private void JazzAppAdminForm_Shown(object sender, EventArgs e)
        {
            if (m_internet_connection)
            {
                JazzXml.InitXmlAllSeasons();
            }

        } // JazzAppAdminForm_Shown

    } // JazzAppAdminForm

} // JazzAppAdmin
