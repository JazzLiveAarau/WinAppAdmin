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
    /// <summary>Export of data to application Flyer, import from Flyer and update XML season programs
    /// <para>This class has one execution class: Flyer</para>
    /// </summary>
    public partial class FlyerForm : Form
    {
        #region Constructor

        /// <summary>Constructor that initializes the control elements</summary>
        public FlyerForm()
        {
            InitializeComponent();

            SetTitles();

            SetLoginLogout();

            SetToolTips();

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set the Login/Logout button</summary>
        private void SetLoginLogout()
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_button_checkin_checkout.Text = JazzAppAdminSettings.Default.Caption_CheckIn;
            }
            else
            {
                m_button_checkin_checkout.Text = JazzAppAdminSettings.Default.Caption_CheckOut;
            }

        } // SetLoginLogout

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = JazzAppAdminSettings.Default.GuiFlyerTitle;
            this.m_label_flyer_htm.Text = JazzAppAdminSettings.Default.GuiFlyerTextTitle;

            this.m_group_box_export.Text = JazzAppAdminSettings.Default.CaptionExportToFlyerApplication;
            this.m_group_box_import.Text = JazzAppAdminSettings.Default.CaptionImportFromFlyerApplication;
            this.m_button_export_flyer_image_files.Text = JazzAppAdminSettings.Default.CaptionExportFrontPageImagesToFlyerApplication;
            this.m_button_export_qr_codes.Text = JazzAppAdminSettings.Default.CaptionExportQrCodesToFlyerApplication;
            this.m_button_update_flyer.Text = JazzAppAdminSettings.Default.CaptionExportSeasonProgramsXmlEditFilesToFlyerApplication;

            this.m_textbox_message.Text = @"";

        } // SetTitles

        #endregion // Set controls

        #region Set tooltips

        /// <summary>Set tool tips</summary>
        private void SetToolTips()
        {
            ToolTipHelp.SetToolTip(m_button_help, JazzAppAdminSettings.Default.ToolTipHelp);
            ToolTipUtil.SetDelays(ref ToolTipHelp);

            ToolTipCheckOut.SetToolTip(m_button_checkin_checkout, JazzAppAdminSettings.Default.ToolTipCheckOut);
            ToolTipUtil.SetDelays(ref ToolTipCheckOut);

            ToolTipExportToFlyerApplication.SetToolTip(m_group_box_export, JazzAppAdminSettings.Default.ToolTipExportToFlyerApplication);
            ToolTipUtil.SetDelays(ref ToolTipExportToFlyerApplication);

            ToolTipImportFromFlyerApplication.SetToolTip(m_group_box_import, JazzAppAdminSettings.Default.ToolTipImportFromFlyerApplication);
            ToolTipUtil.SetDelays(ref ToolTipImportFromFlyerApplication);

            ToolTipExportSeasonProgramToFlyerApplication.SetToolTip(m_button_update_flyer, JazzAppAdminSettings.Default.ToolTipExportSeasonProgramToFlyerApplication);
            ToolTipUtil.SetDelays(ref ToolTipExportSeasonProgramToFlyerApplication);

            ToolTipExportQRCodesToFlyerApplication.SetToolTip(m_button_export_qr_codes, JazzAppAdminSettings.Default.ToolTipExportQRCodesToFlyerApplication);
            ToolTipUtil.SetDelays(ref ToolTipExportQRCodesToFlyerApplication);

            ToolTipExportFrontPageImagesToFlyerApplication.SetToolTip(m_button_export_flyer_image_files, JazzAppAdminSettings.Default.ToolTipExportFrontPageImagesToFlyerApplication);
            ToolTipUtil.SetDelays(ref ToolTipExportFrontPageImagesToFlyerApplication);

            ToolTipImportMusicianTextsFromFlyerApplication.SetToolTip(m_button_import_musician_texts, JazzAppAdminSettings.Default.ToolTipImportMusicianTextsFromFlyerApplication);
            ToolTipUtil.SetDelays(ref ToolTipImportMusicianTextsFromFlyerApplication);

            ToolTipImportFreeTextsFromFlyerApplication.SetToolTip(m_button_import_free_texts, JazzAppAdminSettings.Default.ToolTipImportFreeTextsFromFlyerApplication);
            ToolTipUtil.SetDelays(ref ToolTipImportFreeTextsFromFlyerApplication);

            ToolTipIndexExit.SetToolTip(m_button_exit, JazzAppAdminSettings.Default.ToolTipIndexExit);
            ToolTipUtil.SetDelays(ref ToolTipIndexExit);
            ToolTipIndexBack.SetToolTip(m_button_close, JazzAppAdminSettings.Default.ToolTipIndexBack);
            ToolTipUtil.SetDelays(ref ToolTipIndexBack);
            ToolTipIndexCancel.SetToolTip(m_button_cancel, JazzAppAdminSettings.Default.ToolTipIndexCancel);
            ToolTipUtil.SetDelays(ref ToolTipIndexCancel);

        } // SetToolTips

        #endregion Set tooltips

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

        #region Checkin/Checkout

        /// <summary>Check out data and set Checkin/Checkout button to Save</summary>
        public void CheckoutData()
        {
            bool b_already_checked_out = false;
            string error_message = @"";
            string login_logout_message = @"";
            if (!JazzLoginLogout.LoginLogout.Checkout(false, out b_already_checked_out, out login_logout_message, out error_message))
            {
                if (b_already_checked_out && AdminUtils.MessageBoxYesNo(error_message, "Logout"))
                {
                    if (!JazzLoginLogout.LoginLogout.Checkout(true, out b_already_checked_out, out login_logout_message, out error_message))
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            } // failed

            SetLoginLogout();

            Main.CheckoutButNoWebsiteUpdate = true;

        } // CheckoutData

        /// <summary>Checkin XML data
        /// <para>1. Upload the changed XML files to the server. Call of Flyer.SaveUpdatedXmlSeasonProgramsCopyToFlyer</para>
        /// <para>2. Set current edit document to null. Call of AdminUtils.SetCurrentEditDocument and SetCurrentSelectedXmlFile</para>
        /// <para>3. Set Checkin/Checkout button to Save. Call of LoginLogout.Checkin and _SetLoginLogout</para>
        /// <para></para>
        /// </summary>
        /// <param name="error_message">Output error message</param>
        private void CheckinData()
        {
            string error_message = @"";
            if (!Flyer.SaveUpdatedXmlSeasonProgramsCopyToFlyer(out error_message))
            {
                error_message = @"IndexForm.CheckinData Programming error: " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }

            this.m_textbox_message.Text = @"";

            string out_message = @"";
            bool force_checkin = false;
            if (!JazzLoginLogout.LoginLogout.Checkin(force_checkin, out out_message, out error_message))
            {
                error_message = @"IndexForm.CheckinData Programming error: " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }

            SetLoginLogout();

            this.m_textbox_message.Text = JazzAppAdminSettings.Default.MsgFlyerSaisonProgramSavedAndCopiedToFlyer;

        } // CheckinData

        #endregion // Checkin/Checkout

        #region Event functions

        /// <summary>User clicked the help button</summary>
        private void m_button_help_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameAdminFlyer() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm help_form = new HelpForm(HelpFiles.GetFilenameAdminFlyer());
                help_form.Owner = this;
                help_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }

        } // m_button_help_Click

        /// <summary>Checkin-Checkout button</summary>
        private void m_button_checkin_checkout_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                CheckinData();
            }
            else
            {
                CheckoutData();
            }

        } // m_button_checkin_checkout_Click

        /// <summary>User clicked the button export QR codes to the web application Flyer</summary>
        private void m_button_export_qr_codes_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            this.m_textbox_message.Text = @"";

            InitProgressBar(27);

            this.m_progress_bar_update.Visible = true;

            this.Update();

            this.m_progress_bar_update.PerformStep(); // 1

            if (!Flyer.ExportQrCodes(m_progress_bar_update, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);

                InitProgressBar(27);

                return;
            }

            InitProgressBar(27);

            this.m_textbox_message.Text = JazzAppAdminSettings.Default.MsgQrCodesToFlyerApplicationExported;

        } // m_button_export_qr_codes_Click

        /// <summary>User clicked the button export flyer image files to the web application Flyer</summary>
        private void m_button_export_flyer_image_files_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            this.m_textbox_message.Text = @"";

            InitProgressBar(27);

            this.m_progress_bar_update.Visible = true;

            this.Update();

            this.m_progress_bar_update.PerformStep(); // 1

            if (!Flyer.ExportFlyerImages(m_progress_bar_update, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);

                InitProgressBar(27);

                return;
            }

            InitProgressBar(27);

            this.m_textbox_message.Text = JazzAppAdminSettings.Default.MsgFlyerImageFilesToFlyerApplicationExported;

        } // m_button_export_flyer_image_files_Click

        /// <summary>User clicked the button update data for the web application Flyer</summary>
        private void m_button_update_flyer_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            this.m_textbox_message.Text = @"";

            InitProgressBar(9);

            this.m_progress_bar_update.Visible = true;

            this.Update();

            this.m_progress_bar_update.PerformStep(); // 1

            if (!Flyer.UpdateFlyer(m_progress_bar_update, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);

                InitProgressBar(9);

                return;
            }

            InitProgressBar(9);

            this.m_textbox_message.Text = JazzAppAdminSettings.Default.MsgDataToFlyerApplicationExported;

        } // m_button_update_flyer_Click

        /// <summary>User clicked the button import the musician texts from the web application Flyer</summary>
        private void m_button_import_musician_texts_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            this.m_textbox_message.Text = @"";

            if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgFlyerImportCheckout);

                return;
            }

            InitProgressBar(9);

            this.m_progress_bar_update.Visible = true;

            this.Update();

            this.m_progress_bar_update.PerformStep();

            bool b_musician_texts = true;

            if (!Flyer.ImportDataFromFlyerApplication(b_musician_texts, m_progress_bar_update, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);

                InitProgressBar(9);

                return;
            }

            InitProgressBar(3);

            this.m_textbox_message.Text = JazzAppAdminSettings.Default.MsgDataFromFlyerApplicationImported;

        } // m_button_import_musician_texts_Click

        /// <summary>User clicked the button import the free texts from the web application Flyer</summary>
        private void m_button_import_free_texts_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            this.m_textbox_message.Text = @"";

            if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgFlyerImportCheckout);

                return;
            }

            InitProgressBar(9);

            this.m_progress_bar_update.Visible = true;

            this.Update();

            this.m_progress_bar_update.PerformStep();

            bool b_musician_texts = false;

            if (!Flyer.ImportDataFromFlyerApplication(b_musician_texts, m_progress_bar_update, m_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);

                InitProgressBar(9);

                return;
            }

            InitProgressBar(3);

            this.m_textbox_message.Text = JazzAppAdminSettings.Default.MsgDataFromFlyerApplicationImported;
        } // m_button_import_free_texts_Click

        #endregion // Event functions

        #region Leave page and exit application

        /// <summary>User cancelled</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Cancel))
                {
                    return; // The user did not want to exit without saving
                }
            }

            this.Close();

        } // m_button_cancel_Click

        /// <summary>User closed the window</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Close))
                {
                    return; // The user did not want to exit without saving
                }
            }

            //??? m_user_clicked_close_window = true;

            this.Close();

        } // m_button_close_Click

        /// <summary>User wants to exit the application</summary>
        private void m_button_exit_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Exit))
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

        /// <summary>Handles the user event that edited data not shall be saved
        /// <para>A message box will be displayed letting the user decide if he really wants to quit without saving</para>
        /// <para>The function returns false if the user decides not to quit without saving</para>
        /// <para>If the user decides to quit the following is done:</para>
        /// <para>- The login-logout file will register a "forced" login</para>
        /// <para>- All XML Seasons programs will be reloaded. Call of JazzXml.InitXmlAllSeasons</para>
        /// <para>- Controls will be reset</para>
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

                JazzApp.JazzXml.InitXmlAllSeasons();

                return true;
            }

            return false;

        } // QuitWithoutSaving

        #endregion // Leave page and exit application

    } // FlyerForm

} // namespace
