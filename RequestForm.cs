using JazzApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Main form for the handling of band requests to perform at JAZZ live AARAU
    /// <para>This is Graphical User Interface class. Commands should not be executed in this class.</para>
    /// </summary>
    public partial class RequestForm : Form
    {
        #region Member variables

        /// <summary>Flag telling if the dialog controls are being initialized</summary>
        bool m_initializing = false;

        /// <summary>Flag defining if the user clicked close window</summary>
        private bool m_user_clicked_close_window = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor that initializes the control elements</summary>
        public RequestForm()
        {
            InitializeComponent();

            string error_message = @"";

            if (!Request.InitXmlReq(out error_message))
            {

                MessageBox.Show(@"RequestForm.Constructor Request.InitXmlReq failed " + error_message);

                return;
            }

            Request.InitDeleteSoundFileNames();

            _SetControls();

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set all controls</summary>
        private void _SetControls()
        {
            _SetTitles();

            _SetCaptions();

            _SetComboBoxes();

            _SetLoginLogout();

            _SetCheckBoxes();

            _SetToolTips();
        }

        /// <summary>Set titles</summary>
        private void _SetTitles()
        {
            this.Text = RequestStrings.TitleRequestForm;

            m_label_requests.Text = RequestStrings.CaptionButtonRequests;

            m_label_with_private_notes.Text = RequestStrings.LabelPrivateNotes;

            m_label_evaluate_band.Text = RequestStrings.LabelForEvaluation;

            m_label_with_cd_links.Text = RequestStrings.LabelCdLinks;

            m_label_with_video_links.Text = RequestStrings.LabelVideoLinks;

            m_label_with_info_files.Text = RequestStrings.LabelInfoFiles;

            m_label_selected_bands.Text = RequestStrings.LabelSelectedBands;

            m_label_create_request_lists.Text = RequestStrings.LabelButtonListRequests;

            m_textbox_message.Text = @"";

        } // _SetTitles

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            m_button_create_list.Text = RequestStrings.CaptionButtonListRequests;
            m_button_create_list_htm.Text = RequestStrings.CaptionButtonListRequestsHtm;

            this.m_button_cancel.Text = JazzAppAdminSettings.Default.Caption_Cancel;
            this.m_button_close.Text = JazzAppAdminSettings.Default.Caption_Close;
            this.m_button_exit.Text = JazzAppAdminSettings.Default.Caption_Exit;

            this.m_button_developer.Text = RequestStrings.CapRequestDeveloper;

        } // SetCaptions

        /// <summary>Set check boxes</summary>
        private void _SetCheckBoxes()
        {
            m_check_box_with_private_notes.Checked = true;

            m_check_box_evaluate_band.Checked = true;

            m_check_box_with_cd_links.Checked = true;

            m_check_box_with_video_links.Checked = true;

            m_check_box_with_info_files.Checked = true;

            m_check_box_with_photos.Checked = true;

            m_check_box_selected_bands.Checked = false;

        } // _SetCheckBoxes

        /// <summary>Set combo boxes</summary>
        private void _SetComboBoxes()
        {
            m_initializing = true;
            Request.SetComboBoxRequests(m_combo_box_request);
            m_initializing = false;

        } // _SetComboBoxes

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipReqMainForm.SetToolTip(this, RequestStrings.ToolTipReqMainForm);
            ToolTipReqMainForm.SetToolTip(m_label_requests, RequestStrings.ToolTipReqMainForm);
            ToolTipUtil.SetDelays(ref ToolTipReqMainForm);

            ToolTipReqMainHelp.SetToolTip(m_button_help, RequestStrings.ToolTipReqMainHelp);
            ToolTipUtil.SetDelays(ref ToolTipReqMainHelp);

            ToolTipReqMainCheckinCheckout.SetToolTip(m_button_checkin_checkout, RequestStrings.ToolTipReqMainCheckinCheckout);
            ToolTipUtil.SetDelays(ref ToolTipReqMainCheckinCheckout);

            ToolTipReqMainSelect.SetToolTip(m_combo_box_request, RequestStrings.ToolTipReqMainSelect);
            ToolTipUtil.SetDelays(ref ToolTipReqMainSelect);

            ToolTipReqMainPrivateNotes.SetToolTip(m_label_with_private_notes, RequestStrings.ToolTipReqMainPrivateNotes);
            ToolTipReqMainPrivateNotes.SetToolTip(m_check_box_with_private_notes, RequestStrings.ToolTipReqMainPrivateNotes);
            ToolTipUtil.SetDelays(ref ToolTipReqMainPrivateNotes);

            ToolTipReqMainEvaluateBand.SetToolTip(m_label_evaluate_band, RequestStrings.ToolTipReqMainEvaluateBand);
            ToolTipReqMainEvaluateBand.SetToolTip(m_check_box_evaluate_band, RequestStrings.ToolTipReqMainEvaluateBand);
            ToolTipUtil.SetDelays(ref ToolTipReqMainEvaluateBand);

            ToolTipReqMainSelectedBands.SetToolTip(m_label_selected_bands, RequestStrings.ToolTipReqMainSelectedBands);
            ToolTipReqMainSelectedBands.SetToolTip(m_check_box_selected_bands, RequestStrings.ToolTipReqMainSelectedBands);
            ToolTipUtil.SetDelays(ref ToolTipReqMainSelectedBands);

            ToolTipReqMainVideoLinks.SetToolTip(m_label_with_video_links, RequestStrings.ToolTipReqMainVideoLinks);
            ToolTipReqMainVideoLinks.SetToolTip(m_check_box_with_video_links, RequestStrings.ToolTipReqMainVideoLinks);
            ToolTipUtil.SetDelays(ref ToolTipReqMainVideoLinks);

            ToolTipReqMainInfoFiles.SetToolTip(m_label_with_info_files, RequestStrings.ToolTipReqMainInfoFiles);
            ToolTipReqMainInfoFiles.SetToolTip(m_check_box_with_info_files, RequestStrings.ToolTipReqMainInfoFiles);
            ToolTipUtil.SetDelays(ref ToolTipReqMainInfoFiles);

            ToolTipReqMainPhotoFiles.SetToolTip(m_label_with_photos, RequestStrings.ToolTipReqMainPhotoFiles);
            ToolTipReqMainPhotoFiles.SetToolTip(m_check_box_with_photos, RequestStrings.ToolTipReqMainPhotoFiles);
            ToolTipUtil.SetDelays(ref ToolTipReqMainPhotoFiles);

            ToolTipReqMainCdUrls.SetToolTip(m_label_with_cd_links, RequestStrings.ToolTipReqMainCdUrls);
            ToolTipReqMainCdUrls.SetToolTip(m_check_box_with_cd_links, RequestStrings.ToolTipReqMainCdUrls);
            ToolTipUtil.SetDelays(ref ToolTipReqMainCdUrls);

            ToolTipReqMainCreateList.SetToolTip(m_button_create_list, RequestStrings.ToolTipReqMainCreateList);
            ToolTipReqMainCreateListHtm.SetToolTip(m_button_create_list_htm, RequestStrings.ToolTipReqMainCreateListHtm);
            ToolTipReqMainCreateLists.SetToolTip(m_label_create_request_lists, RequestStrings.ToolTipReqMainCreateLists);
            ToolTipUtil.SetDelays(ref ToolTipReqMainCreateList);
            ToolTipUtil.SetDelays(ref ToolTipReqMainCreateListHtm);
            ToolTipUtil.SetDelays(ref ToolTipReqMainCreateLists);

            ToolTipIndexExit.SetToolTip(m_button_exit, JazzAppAdminSettings.Default.ToolTipIndexExit);
            ToolTipIndexBack.SetToolTip(m_button_close, JazzAppAdminSettings.Default.ToolTipIndexBack);
            ToolTipIndexCancel.SetToolTip(m_button_cancel, JazzAppAdminSettings.Default.ToolTipIndexCancel);
            ToolTipUtil.SetDelays(ref ToolTipIndexExit);
            ToolTipUtil.SetDelays(ref ToolTipIndexBack);
            ToolTipUtil.SetDelays(ref ToolTipIndexCancel);

            ToolTipReqDeveloperButton.SetToolTip(m_button_developer, RequestStrings.ToolTipReqDeveloperButton);
            ToolTipUtil.SetDelays(ref ToolTipReqDeveloperButton);

            ToolTipReqFormMsg.SetToolTip(m_textbox_message, RequestStrings.ToolTipReqFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipReqMainForm);

        } // _SetToolTips

        #endregion // Set controls

        #region Select request

        /// <summary>User selected request
        /// <para>1. If selected string is "Add request" it is checked if a checkout has been made and then Request.AddReq is called.</para>
        /// <para>2. Dialog request band is opened. Call of OpenRequestBandDialog</para>
        /// <para>3. Comboboxes are reset</para>
        /// <para></para>
        /// </summary>
        private void m_combo_box_request_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_initializing)
                return;

            if (RequestStrings.PromptSelectRequest.Equals(m_combo_box_request.Text))
            {
                return;
            }

            string error_message = @"";

            string band_name = m_combo_box_request.Text;

            if (RequestStrings.PromptAddRequest.Equals(m_combo_box_request.Text))
            {
                if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
                {
                    error_message = RequestStrings.ErrMsgCheckoutBeforeAddingRequest;
                    MessageBox.Show(error_message);

                    return;
                }
                string added_band_name;
                if (!Request.AddReq(out added_band_name, out error_message))
                {
                    error_message = @"RequestForm.m_combo_box_request_SelectedIndexChanged Request.AddReq failed " + error_message;
                    MessageBox.Show(error_message);

                    return;
                }

                band_name = added_band_name;

            } // Add request


            OpenRequestBandDialog(band_name);

            m_initializing = true;
            Request.SetComboBoxRequests(m_combo_box_request);
            m_initializing = false;

        } // m_combo_box_request_SelectedIndexChanged

        /// <summary>Open request band dialog</summary>
        private void OpenRequestBandDialog(string i_band_name)
        {
            string error_message = @"";          

            JazzReq jazz_req = Request.GetJazzReq(i_band_name, out error_message);
            if (null == jazz_req)
            {
                error_message = @"RequestForm.OpenRequestBandDialog " + error_message;
                MessageBox.Show(error_message);
                return;
            }

            RequestBandForm request_band_form = new RequestBandForm(this, jazz_req);
            request_band_form.Owner = this;
            request_band_form.ShowDialog();

        } // OpenRequestBandDialog

        #endregion // Select request

        #region Checkin/Checkout

        /// <summary>User clicked the checkin/checkout button</summary>
        private void m_button_checkin_checkout_Click(object sender, EventArgs e)
        {

            if (m_initializing)
                return;

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                CheckinData();
            }
            else
            {
                bool b_user_cancelled = false;
                CheckoutData(out b_user_cancelled);
            }

        } // m_button_checkin_checkout_Click

        /// <summary>Check out data and set Checkin/Checkout button to Save</summary>
        public bool CheckoutData(out bool o_b_user_cancelled)
        {
            o_b_user_cancelled = false;

            // Returned value 'false' means that the somebody else already has checked out and 
            // that the user not forced a checkeout
            bool b_checkout_data = AdminUtils.CheckoutData();
            if (!b_checkout_data)
            {
                o_b_user_cancelled = true;
                return true;
            }

            _SetLoginLogout();

            bool xml_edited = false;
            string err_message = @"";

            string full_server_file_name = AdminUtils.GetFullServerNameForXmlBackup(Request.ReqFileName);

            if (Backup.BackupCurrentEditXmlFile(full_server_file_name, xml_edited, out err_message))
            {
                this.m_textbox_message.Text = Request.ReqFileName + JazzAppAdminSettings.Default.MsgBackupCurrenXml;
            }
            else
            {
                err_message = "RequestForm.CheckoutData Backup Program error: " + err_message;
                this.m_textbox_message.Text = err_message;
                return false;
            }

            return true;

        } // CheckoutData

        /// <summary>Upload changed file to the server, check in data and set Checkin/Checkout button to Save</summary>
        private void CheckinData()
        {
            string error_message = @"";
            if (!AdminUtils.UploadXmlToServer(Request.ReqFileName, JazzXml.GetObjectReq(), out error_message))
            {
                error_message = @"RequestForm.CheckinData Programming error: " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }


            if (!Request.FinalDeleteSoundFiles(out error_message))
            {
                error_message = @"RequestForm.CheckinData Request.FinalDeleteSoundFiles failed " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }

            this.m_textbox_message.Text = @"";

            string out_message = @"";
            bool force_checkin = false;
            if (!JazzLoginLogout.LoginLogout.Checkin(force_checkin, out out_message, out error_message))
            {
                error_message = @"RequestForm.CheckinData Programming error: " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }

            _SetLoginLogout();

        } // CheckinData

        /// <summary>Set the Login/Logout button</summary>
        private void _SetLoginLogout()
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_button_checkin_checkout.Text = JazzAppAdminSettings.Default.Caption_CheckIn;
            }
            else
            {
                m_button_checkin_checkout.Text = JazzAppAdminSettings.Default.Caption_CheckOut;
            }

        } // _SetLoginLogout

        #endregion // Checkin/Checkout

        #region Exit the dialog

        /// <summary>Handles the user event that edited data not shall be saved
        /// <para>A message box will be displayed letting the user decide if he really wants to quit without saving</para>
        /// <para>The function returns false if the user decides not to quit without saving</para>
        /// <para>If the user decides to quit the following is done:</para>
        /// <para>- The login-logout file will register a "forced" login. Call of LoginLogout.Checkin</para>
        /// <para>- The requests XDocument will be reset with XML data from the server. Call of ResetRequestsXDocumentAfterQuit</para>
        /// <para>- The sound files marked (named) for delete get their original names. Call of Request.RegretDeleteSoundFiles.</para>
        /// </summary>
        /// <param name="i_caption">The caption for the quit without save message box</param>
        private bool QuitWithoutSaving(string i_caption)
        {
            if (AdminUtils.MessageBoxYesNo(JazzAppAdminSettings.Default.MsgCloseWithoutSaving, i_caption))
            {
                string error_message = @"";
                string out_message = @"";
                bool force_checkin = true;

                if (!JazzLoginLogout.LoginLogout.Checkin(force_checkin, out out_message, out error_message))
                {
                    return false; // Programming error
                }

                if (!ResetRequestsXDocumentAfterQuit(out error_message))
                {
                    return false; // Programming error
                }

                if (!Request.RegretDeleteSoundFiles(out error_message))
                {
                    return false;
                }

                return true;
            }

            return false;

        } // QuitWithoutSaving


        /// <summary>Reset the requests XDocument object (corresponding to JazzAnfragen.xml) when the user has quit editing
        /// <para>This corresponds to a restart of the application.</para>
        /// <para>The controls should also be reset by the calling (WindowsForm) function</para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        public static bool ResetRequestsXDocumentAfterQuit(out string o_error)
        {
            o_error = @"";

            if (!Request.InitXmlReq(out o_error))
            {

                o_error = @"RequestForm.ResetCurrentXDocumentAfterQuit Programming error: " + o_error;

                return false;
            }

            return true;
        } // ResetRequestsXDocumentAfterQuit

        /// <summary>User clicked cancel</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Cancel))
                {
                    return; // The user did not want to exit without saving
                }
            }

            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked the close button</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Cancel))
                {
                    return; // The user did not want to exit without saving
                }
            }

            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_close_Click

        /// <summary>User clicked the exit application button</summary>
        private void m_button_exit_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Cancel))
                {
                    return; // The user did not want to exit without saving
                }

                Application.Exit();
            }

            if (!Main.ApplicationExit())
            {
                return;
            }

            Application.Exit();

        } // m_button_exit_Click

        #endregion // Exit the dialog

        #region Button events

        /// <summary>User clicked the help button</summary>
        private void m_button_help_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameAdminRequests() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm help_form = new HelpForm(HelpFiles.GetFilenameAdminRequests());
                help_form.Owner = this;
                help_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }

        } // m_button_help_Click

        /// <summary>User clicked the create TXT list button</summary>
        private void m_button_create_list_Click(object sender, EventArgs e)
        {
            string error_message = @"";
            bool b_for_evaluation = m_check_box_evaluate_band.Checked;
            bool b_selected_bands = m_check_box_selected_bands.Checked;
            bool b_private_notes = m_check_box_with_private_notes.Checked;           
            bool b_with_cd_links = m_check_box_with_cd_links.Checked;
            bool b_with_info_files = m_check_box_with_info_files.Checked;
            bool b_with_video_links = m_check_box_with_video_links.Checked;
            bool b_with_photos = m_check_box_with_photos.Checked;
            bool b_sort_date = true; // TODO

            if (!Request.CreateRequestsList(b_private_notes, b_for_evaluation, b_with_cd_links, b_selected_bands, b_with_info_files, b_with_video_links, b_with_photos, b_sort_date, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            } 

        } // m_button_create_list_Click

        /// <summary>User clicked the create HTM list button</summary>
        private void m_button_create_list_htm_Click(object sender, EventArgs e)
        {
            string error_message = @"";
            bool b_for_evaluation = m_check_box_evaluate_band.Checked;
            bool b_selected_bands = m_check_box_selected_bands.Checked;
            bool b_private_notes = m_check_box_with_private_notes.Checked;
            bool b_with_cd_links = m_check_box_with_cd_links.Checked;
            bool b_with_info_files = m_check_box_with_info_files.Checked;
            bool b_with_video_links = m_check_box_with_video_links.Checked;
            bool b_with_photos = m_check_box_with_photos.Checked;
            bool b_sort_date = true; // TODO
            bool b_time_stamp_file_name = true;
            string file_name = @"";
            if (!Request.CreateHtmlRequestsList(b_private_notes, b_for_evaluation, b_with_cd_links, b_selected_bands, b_with_info_files, b_with_video_links, b_with_photos, b_sort_date, b_time_stamp_file_name, out file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            if (!Request.OpenDefaultBrowser(file_name, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

        } // m_button_create_list_htm_Click

        /// <summary>User clicked the developer button</summary>
        private void m_button_developer_Click(object sender, EventArgs e)
        {
            RequestDeveloperForm request_developer_form = new RequestDeveloperForm(this);
            request_developer_form.Owner = this;
            request_developer_form.ShowDialog();

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                //m_editable = true;

                _SetCaptions();

                //_SetEditable();
            }

        } // m_button_developer_Click

        #endregion // Button events

        #region Checkbox events

        /// <summary>User changed the evaluation checkbox</summary>
        private void m_check_box_evaluate_band_CheckedChanged(object sender, EventArgs e)
        {
            if (m_check_box_evaluate_band.Checked)
            {
                if (m_check_box_selected_bands.Checked)
                {
                    m_check_box_selected_bands.Checked = false;
                }
            }

        } // m_check_box_evaluate_band_CheckedChanged

        /// <summary>User changed the selected band checkbox</summary>
        private void m_check_box_selected_bands_CheckedChanged(object sender, EventArgs e)
        {
            if (m_check_box_selected_bands.Checked)
            {
                if (m_check_box_evaluate_band.Checked)
                {
                    m_check_box_evaluate_band.Checked = false;
                }
            }

        } // m_check_box_selected_bands_CheckedChanged

        #endregion // Checkbox events

        #region Prevent user to use some commands

        /// <summary>Tell the user to use implemented close dialog buttons
        /// <para>Call of AdminUtils.FormIsClosing Case=2</para>
        /// </summary>
        private void RequestForm_FormClosing(object sender, FormClosingEventArgs i_event)
        {

            if (m_user_clicked_close_window)
            {
                return;
            }

            int i_case = 2;

            AdminUtils.FormIsClosing(i_event, i_case);

        } // RequestForm_FormClosing

        #endregion // Prevent user to use some commands

        #region Not used events

        /// <summary>User changed the private notes checkbox</summary>
        private void m_check_box_with_private_notes_CheckedChanged(object sender, EventArgs e)
        {
            // Do nothing
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        #endregion // Not used events


    } // RequestForm
} // namespace
