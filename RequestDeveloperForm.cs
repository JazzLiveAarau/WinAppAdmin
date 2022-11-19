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
    /// <summary>Request functions for the developer
    /// <para></para>
    /// </summary>
    public partial class RequestDeveloperForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        RequestForm m_request_main_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Flag telling if controls are being initialized</summary>
        //private bool m_is_initializing = false;

        /// <summary>Flag defining if the user clicked close window</summary>
        private bool m_user_clicked_close_window = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor
        /// <para>1. Sets the controls of the dialog</para>
        /// <para>2. Makes the controls editable if the XML file is checked out</para>
        /// <para>3. Sets the tool tips</para>
        /// <para>4. Sets the captions</para>
        /// </summary>
        /// <param name="i_request_main_form">Object RequestForm - the owner of this form</param>
        public RequestDeveloperForm(RequestForm i_request_main_form)
        {
            InitializeComponent();

            if (null == i_request_main_form)
                return;

            m_request_main_form = i_request_main_form;

            //m_is_initializing = true;

            _SetTexts();

            _SetToolTips();

            // m_editable must be set before _SetCaptions() is called
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetCaptions();

            //m_is_initializing = false;

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = RequestStrings.TitleRequestDeveloperForm;

            this.m_label_page_header.Text = RequestStrings.TitleRequestDeveloperForm;

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipThisForm.SetToolTip(this, RequestStrings.ToolTipReqDeveloperForm);
            ToolTipUtil.SetDelays(ref ToolTipThisForm);

            ToolTipReqDeveloperForm.SetToolTip(m_label_page_header, RequestStrings.ToolTipReqDeveloperForm);
            ToolTipUtil.SetDelays(ref ToolTipReqDeveloperForm);

            ToolTipReqMainCheckinCheckout.SetToolTip(m_button_edit_data, RequestStrings.ToolTipReqMainCheckinCheckout);
            ToolTipUtil.SetDelays(ref ToolTipReqMainCheckinCheckout);

            ToolTipReqFormCancel.SetToolTip(m_button_cancel, RequestStrings.ToolTipReqFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipReqFormCancel);
            ToolTipReqFormClose.SetToolTip(m_button_close, RequestStrings.ToolTipReqFormClose);
            ToolTipUtil.SetDelays(ref ToolTipReqFormClose);

            ToolTipReqToolTip.SetToolTip(m_button_tool_tips, RequestStrings.ToolTipReqToolTip);
            ToolTipUtil.SetDelays(ref ToolTipReqToolTip);

            ToolTipReqCheckFunctions.SetToolTip(m_button_check_data, RequestStrings.ToolTipReqCheckFunctions);
            ToolTipUtil.SetDelays(ref ToolTipReqCheckFunctions);

            ToolTipReqCleanFunction.SetToolTip(m_button_clean, RequestStrings.ToolTipReqCleanFunction);
            ToolTipUtil.SetDelays(ref ToolTipReqCleanFunction);

            ToolTipReqMaintenanceHelp.SetToolTip(m_button_help, RequestStrings.ToolTipReqMaintenanceHelp);
            ToolTipUtil.SetDelays(ref ToolTipReqMaintenanceHelp);


            ToolTipAdminBugsNewFunctions.SetToolTip(m_button_bugs, RequestStrings.ToolTipAdminBugsNewFunctions);
            ToolTipUtil.SetDelays(ref ToolTipAdminBugsNewFunctions);

            ToolTipReqFormMsg.SetToolTip(m_textbox_message, RequestStrings.ToolTipReqFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipReqFormMsg);

        } // SetToolTips

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // _SetCaptions

        #endregion // Set controls

        #region Write data

        /// <summary>Write data (texts)</summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            //TODO if (!m_photo_main_form.SetXyzDate( out o_error))
            //TODO {
            //TODO o_error = @"RequestDeveloperForm._WriteTexts RequestForm.SetXyzDate failed " + o_error;
            //TODO return false;
            //TODO }

            return true;

        } // _WriteTexts

        #endregion // Write data

        #region Events checkout and exit form 

        /// <summary>User clicked the edit (checkout) button</summary>
        private void m_button_edit_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                bool b_user_cancelled = false;
                m_request_main_form.CheckoutData(out b_user_cancelled);
                if (b_user_cancelled)
                {
                    return;
                }

                m_editable = true;
            }

            _SetCaptions();

        } // m_button_edit_data_Click

        /// <summary>User clicked button cancel</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked button close</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (m_editable)
            {
                string error_message = @"";
                if (!_WriteTexts(out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }
            }

            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_close_Click

        #endregion // Events checkout and exit form 

        #region Prevent user to use some commands

        /// <summary>Tell the user to use implemented close dialog buttons
        /// <para>Call of AdminUtils.FormIsClosing Case=2</para>
        /// </summary>
        private void PhotoMainForm_FormClosing(object sender, FormClosingEventArgs i_event)
        {
            if (m_user_clicked_close_window)
            {
                return;
            }

            int i_case = 2;
            AdminUtils.FormIsClosing(i_event, i_case);

        } // JazzAppAdminForm_FormClosing

        #endregion // Prevent user to use some commands

        #region Events tooltips, bug list, maintenace help, check data, ... 

        /// <summary>User clicked clicked create list with tool tips</summary>
        private void m_button_tool_tips_Click(object sender, EventArgs e)
        {
            string file_name = @"";

            m_textbox_message.Text = @"";

            RequestStrings.CreateFileToolTips(out file_name);

            System.Diagnostics.Process.Start("notepad.exe", file_name);

        } // m_button_tool_tips_Click

        /// <summary>User clicked button test data</summary>
        private void m_button_check_data_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            m_textbox_message.Text = @"Daten kontrollieren";

            string file_name = @"";
            if (!RequestDeveloper.ListNotDeletedAudioFiles(out file_name, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            m_textbox_message.Text = @"Daten sind kontrolliert";

            if (file_name.Length > 5)
            {
                System.Diagnostics.Process.Start("notepad.exe", file_name);
            }

        } // m_button_check_data_Click

        /// <summary>User clicked the Clean button</summary>
        private void m_button_clean_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            if (!m_editable)
            {
                string error_checkout = RequestStrings.ErrMsgCheckoutBeforeCleaning;
                MessageBox.Show(error_checkout);
                return;
            }

            if (!RequestDeveloper.CleanAudioDirectoriesAndFiles(m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

        } // m_button_clean_Click

        /// <summary>User clicked the Bugs button</summary>
        private void m_button_bugs_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            m_textbox_message.Text = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameAdminNewFunctionsBugs() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm bugs_form = new HelpForm(HelpFiles.GetFilenameAdminNewFunctionsBugs());
                bugs_form.Owner = this;
                bugs_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }

        } // m_button_bugs_Click

        /// <summary>User clicked the Help button</summary>
        private void m_button_help_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            m_textbox_message.Text = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameMaintenanceReqs() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm help_form = new HelpForm(HelpFiles.GetFilenameMaintenanceReqs());
                help_form.Owner = this;
                help_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }

        } // m_button_help_Click

        #endregion // Events tooltips, bug list, maintenace help, check data, ... 


    } // RequestDeveloperForm

} // namespace
