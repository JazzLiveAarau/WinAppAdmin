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
using System.IO;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Edit and add XML data for the app, the homepage and Intranet
    /// <para></para>
    /// </summary>
    public partial class IndexForm : Form
    {
        #region Member variables

        /// <summary>Flag telling if controls are being initialized</summary>
        private bool m_is_initializing = false;

        /// <summary>Flag defining if the user clicked close window</summary>
        private bool m_user_clicked_close_window = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor that sets the combo boxes, the checkin/checkout button and all other elements</summary>
        public IndexForm()
        {
            InitializeComponent();

            AdminUtils.SetCurrentConcertNumber(1);
            AdminUtils.SetCurrentMusicianNumber(1);
            AdminUtils.SetCurrentMemberNumber(1);

            m_is_initializing = true;
            _InitializeControls();
            m_is_initializing = false;

            SetToolTips();

        } // Constructor

        #endregion // Constructor

        #region Set tool tips

        /// <summary>Set tool tips</summary>
        private void SetToolTips()
        {
            ToolTipApplication.SetToolTip(this, JazzAppAdminSettings.Default.ToolTipApplication);
            ToolTipUtil.SetDelays(ref ToolTipApplication);
            ToolTipCheckOut.SetToolTip(m_button_checkin_checkout, JazzAppAdminSettings.Default.ToolTipCheckOut);
            ToolTipUtil.SetDelays(ref ToolTipCheckOut);
            ToolTipHelp.SetToolTip(m_button_help, JazzAppAdminSettings.Default.ToolTipHelp);
            ToolTipUtil.SetDelays(ref ToolTipHelp);
            ToolTipSelectSeason.SetToolTip(m_combo_box_season, JazzAppAdminSettings.Default.ToolTipSelectSeason);
            ToolTipUtil.SetDelays(ref ToolTipSelectSeason);
            ToolTipSelectConcert.SetToolTip(m_combo_box_concert, JazzAppAdminSettings.Default.ToolTipSelectConcert);
            ToolTipUtil.SetDelays(ref ToolTipSelectConcert);
            ToolTipSelectMember.SetToolTip(m_combo_box_member, JazzAppAdminSettings.Default.ToolTipSelectMember);
            ToolTipUtil.SetDelays(ref ToolTipSelectMember);
            ToolTipSelectMusician.SetToolTip(m_combo_box_musician, JazzAppAdminSettings.Default.ToolTipSelectMusician);
            ToolTipUtil.SetDelays(ref ToolTipSelectMusician);
            ToolTipAllSeasonPrograms.SetToolTip(m_check_box_edit_all_seasons, JazzAppAdminSettings.Default.ToolTipAllSeasonPrograms);
            ToolTipUtil.SetDelays(ref ToolTipAllSeasonPrograms);
            ToolTipAllSeasonPrograms.SetToolTip(m_label_edit_all_seasons, JazzAppAdminSettings.Default.ToolTipAllSeasonPrograms);
            ToolTipUtil.SetDelays(ref ToolTipAllSeasonPrograms);

            ToolTipConcert.SetToolTip(m_button_open_concert, JazzAppAdminSettings.Default.ToolTipConcert);
            ToolTipUtil.SetDelays(ref ToolTipConcert);

            ToolTipSoundSample.SetToolTip(m_button_open_sound_sample, JazzAppAdminSettings.Default.ToolTipSoundSample);
            ToolTipUtil.SetDelays(ref ToolTipSoundSample);

            ToolTipMusician.SetToolTip(m_text_box_musician, JazzAppAdminSettings.Default.ToolTipMusician);
            ToolTipMusician.SetToolTip(m_button_open_musician, JazzAppAdminSettings.Default.ToolTipMusician);
            ToolTipUtil.SetDelays(ref ToolTipMusician);
            ToolTipBandContact.SetToolTip(m_button_open_musician_contact, JazzAppAdminSettings.Default.ToolTipBandContact);
            ToolTipUtil.SetDelays(ref ToolTipBandContact);
            ToolTipMember.SetToolTip(m_text_box_member, JazzAppAdminSettings.Default.ToolTipMember);
            ToolTipMember.SetToolTip(m_button_open_member, JazzAppAdminSettings.Default.ToolTipMember);
            ToolTipUtil.SetDelays(ref ToolTipMember);

            ToolTipMusiciansOnly.SetToolTip(m_button_open_musician_info, JazzAppAdminSettings.Default.ToolTipMusiciansOnly);
            ToolTipUtil.SetDelays(ref ToolTipMusiciansOnly);
            ToolTipPublish.SetToolTip(m_button_open_publish, JazzAppAdminSettings.Default.ToolTipPublish);
            ToolTipUtil.SetDelays(ref ToolTipPublish);
            ToolTipConcertPremises.SetToolTip(m_button_open_premises, JazzAppAdminSettings.Default.ToolTipConcertPremises);
            ToolTipUtil.SetDelays(ref ToolTipConcertPremises);
            ToolTipPremises.SetToolTip(m_button_open_current_premises, JazzAppAdminSettings.Default.ToolTipPremises);
            ToolTipUtil.SetDelays(ref ToolTipPremises);
            ToolTipContact.SetToolTip(m_button_open_contact, JazzAppAdminSettings.Default.ToolTipContact);
            ToolTipUtil.SetDelays(ref ToolTipContact);
            ToolTipAboutUs.SetToolTip(m_button_open_about, JazzAppAdminSettings.Default.ToolTipAboutUs);
            ToolTipUtil.SetDelays(ref ToolTipAboutUs);
            ToolTipRequestsText.SetToolTip(m_button_open_request, JazzAppAdminSettings.Default.ToolTipRequestsText);
            ToolTipUtil.SetDelays(ref ToolTipAboutUs);

            ToolTipIndexExit.SetToolTip(m_button_exit, JazzAppAdminSettings.Default.ToolTipIndexExit);
            ToolTipUtil.SetDelays(ref ToolTipIndexExit);
            ToolTipIndexBack.SetToolTip(m_button_close, JazzAppAdminSettings.Default.ToolTipIndexBack);
            ToolTipUtil.SetDelays(ref ToolTipIndexBack);
            ToolTipIndexCancel.SetToolTip(m_button_cancel, JazzAppAdminSettings.Default.ToolTipIndexCancel);
            ToolTipUtil.SetDelays(ref ToolTipIndexCancel);

            // 

        } // SetToolTips

        #endregion // Set tool tips

        #region Set comboboxes, buttons and titles

        /// <summary>Initial settings of all controls</summary>
        private void _InitializeControls()
        {
            _SetSeasons(false);

            _SetConcerts();

            _SetMusicians();

            _SetMembers();

            _SetTitles();

            _SetButtons();

            _SetEnabled();

            _SetCheckBoxes();

            _SetLoginLogout();

            m_textbox_message.Text = "";
        }

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

        /// <summary>Set buttons</summary>
        private void _SetButtons()
        {
            this.m_button_cancel.Text = JazzAppAdminSettings.Default.Caption_Cancel;
            this.m_button_close.Text = JazzAppAdminSettings.Default.Caption_Close;
            this.m_button_exit.Text = JazzAppAdminSettings.Default.Caption_Exit;

            this.m_button_open_publish.Text = XmlEditStrings.CapPublishSeasonYears;
            this.m_button_open_concert.Text = XmlEditStrings.CapConcertInformation;
            this.m_button_open_musician_contact.Text = XmlEditStrings.CapBandContactPerson;
            this.m_button_open_premises.Text = XmlEditStrings.CapConcertPremises;
            this.m_button_open_contact.Text = XmlEditStrings.CapContactJazzClub;
            this.m_button_open_musician_info.Text = XmlEditStrings.CapMusicianInfo;
            this.m_button_open_current_premises.Text = XmlEditStrings.CapPremises;
            this.m_button_open_about.Text = XmlEditStrings.CapAboutUs;
            this.m_button_open_request.Text = XmlEditStrings.CapRequests;
            this.m_button_open_sound_sample.Text = XmlEditStrings.LabelSoundSampleForm;
            this.m_button_developer.Text = XmlEditStrings.CapDeveloper;

        } // _SetButtons

        /// <summary>Set combobox seasons
        /// <para>1. Call of AdminUtils.SetComboBoxSeasons. Flag i_season_added is used to set the last added season program</para>
        /// </summary>
        /// <param name="i_season_added">Flag telling if a season has been added by the user</param>
        private void _SetSeasons(bool i_season_added)
        {
            AdminUtils.SetComboBoxSeasons(this.m_combo_box_season, i_season_added);
 
        } // _SetSeasons

        /// <summary>Set combobox concerts</summary>
        private void _SetConcerts()
        {
            AdminUtils.SetComboBoxConcerts(this.m_combo_box_concert);

        } // _SetConcerts

        /// <summary>Set combobox musicians
        /// <para>The current musician number must exist, i.e. must be set in the case that for instance the concert was changed</para>
        /// </summary>
        private void _SetMusicians()
        {
            AdminUtils.SetComboBoxMusicians(this.m_combo_box_musician);

        } // _SetMusicians

        /// <summary>Set combobox members</summary>
        private void _SetMembers()
        {
            string[] members_strings = JazzXml.GetMembersAsStrings();

            AdminUtils.SetComboBoxMembers(this.m_combo_box_member);

        } // _SetMembers

        /// <summary>Set titles for the edit pages</summary>
        private void _SetTitles()
        {
            this.m_text_box_musician.Text = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetTitleMusician());
            this.m_text_box_member.Text = XmlEditStrings.LabelMember;
            this.Text = JazzAppAdminSettings.Default.GuiTextIndexTitle;
            this.m_label_index_xml.Text = JazzAppAdminSettings.Default.GuiTextIndexTitle;

        } // _SetTitles

        /// <summary>Set checkboxes</summary>
        private void _SetCheckBoxes()
        {
            this.m_check_box_edit_all_seasons.Text = "";
            this.m_label_edit_all_seasons.Text = JazzAppAdminSettings.Default.GuiTextEditAllSeasons;
            this.m_check_box_edit_all_seasons.Checked = false;
        }

        /// <summary>Set enable for the open page buttons</summary>
        private void _SetEnabled()
        {
            m_button_open_musician_info.Enabled = true;
            m_button_open_about.Enabled = true;
            m_button_open_member.Enabled = true;
            m_button_open_current_premises.Enabled = true;
            m_button_open_contact.Enabled = true;
            m_button_open_premises.Enabled = true;
            m_button_open_musician.Enabled = true;
            m_button_open_concert.Enabled = true;
            m_button_open_musician_contact.Enabled = true;
            m_button_open_publish.Enabled = true;

            // Change of XML season document or application XML document is 
            // not allowed when data has been checked out
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_combo_box_season.Enabled = false;
            }
            else
            {
                m_combo_box_season.Enabled = true;
            }

        } // _SetEnabled

        #endregion Set comboboxes, buttons and labels

        #region Exit from this dialog

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

            m_user_clicked_close_window = true;

            this.Close();

        } // m_button_close_Click

        /// <summary>User exited the application</summary>
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

        /// <summary>User canceled the input</summary>
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

        /// <summary>Handles the user event that edited data not shall be saved
        /// <para>A message box will be displayed letting the user decide if he really wants to quit without saving</para>
        /// <para>The function returns false if the user decides not to quit without saving</para>
        /// <para>If the user decides to quit the following is done:</para>
        /// <para>- The login-logout file will register a "forced" login</para>
        /// <para>- The current XDocument will be reset with XML data from the server</para>
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

                Index.ResetCurrentXDocumentAfterQuit(out error_message);

                AdminUtils.SetCurrentConcertNumber(1);
                AdminUtils.SetCurrentMusicianNumber(1);
                AdminUtils.SetCurrentMemberNumber(1);

                _InitializeControls();

                return true;
            }

            return false;

        } // QuitWithoutSaving


        #endregion // Exit from this dialog

        #region Prevent user to use some commands

        /// <summary>Tell the user to use implemented close dialog buttons
        /// <para>Call of AdminUtils.FormIsClosing Case=2</para>
        /// </summary>
        private void IndexForm_FormClosing(object sender, FormClosingEventArgs i_event)
        {
            if (m_user_clicked_close_window)
            {
                return;
            }

            int i_case = 2;
            AdminUtils.FormIsClosing(i_event, i_case);

        } // JazzAppAdminForm_FormClosing

        #endregion // Prevent user to use some commands

        #region User clicked open page

        /// <summary>User clicked open Main</summary>
        private void m_button_open_main_Click(object sender, EventArgs e)
        {
            PublishForm publish_form = new PublishForm(this);
            publish_form.Owner = this;
            publish_form.ShowDialog();

        } // m_button_open_main_Click

        /// <summary>User clicked open Concert</summary>
        private void m_button_open_concert_Click(object sender, EventArgs e)
        {
            OpenConcertEditTextForm();

        } // m_button_open_concert_Click

        /// <summary>Open concert text edit form</summary>
        private void OpenConcertEditTextForm()
        {
            ConcertForm concert_form = new ConcertForm(this, AdminUtils.GetCurrentConcertNumber());
            concert_form.Owner = this;
            concert_form.FormClosing += new FormClosingEventHandler(ConcertFormIsClosing);
            concert_form.ShowDialog();

        } // OpenConcertEditTextForm

        /// <summary>Open sound sample form</summary>
        private void m_button_open_sound_sample_Click(object sender, EventArgs e)
        {
            int current_season_start_year = JazzUtils.GetCurrentSeasonStartYear();

            int autumn_year = JazzXml.GetYearAutumnInt();

            if (autumn_year != current_season_start_year && autumn_year != current_season_start_year + 1)
            {
                MessageBox.Show("Nur möglich für Saison " + current_season_start_year.ToString() + @"-" + (current_season_start_year + 1).ToString()
                            + @" und Saison " + (current_season_start_year + 1).ToString() + @"-" + (current_season_start_year + 2).ToString());
                return;
            }

            SoundSampleForm sound_sample_form = new SoundSampleForm(this, AdminUtils.GetCurrentConcertNumber());
            sound_sample_form.Owner = this;
            sound_sample_form.ShowDialog();

        } // m_button_open_sound_sample_Click

        /// <summary>Concert form is closing. Combobox concerts must be updated if concert name is changed or if concert is removed</summary>
        void ConcertFormIsClosing(object sender, FormClosingEventArgs e)
        {
            _SetConcerts();

        } // ConcertFormIsClosing

        /// <summary>User clicked open Musician</summary>
        private void m_button_open_musician_Click(object sender, EventArgs e)
        {
            OpenMusicianEditTextForm();
 
        } // m_button_open_musician_Click

        /// <summary>Open musician text edit form</summary>
        private void OpenMusicianEditTextForm()
        {
            MusicianForm musician_form = new MusicianForm(this, AdminUtils.GetCurrentConcertNumber(), AdminUtils.GetCurrentMusicianNumber());
            musician_form.Owner = this;
            musician_form.FormClosing += new FormClosingEventHandler(MusicianFormIsClosing);
            musician_form.ShowDialog();

        } // OpenMusicianEditTextForm

        /// <summary>Musician form is closing. Combobox musicians must be updated if musician name is changed</summary>
        void MusicianFormIsClosing(object sender, FormClosingEventArgs e)
        {
            _SetMusicians();

        } // MusicianFormIsClosing

        /// <summary>User clicked open Musician contact</summary>
        private void m_button_open_musician_contact_Click(object sender, EventArgs e)
        {
                MusicianContactForm concert_form = new MusicianContactForm(this, AdminUtils.GetCurrentConcertNumber());
                concert_form.Owner = this;
                concert_form.ShowDialog();

        } // m_button_open_musician_contact_Click

        /// <summary>User clicked open Concert premises</summary>
        private void m_button_open_premises_Click(object sender, EventArgs e)
        {
                ConcertPremisesForm concert_premises_form = new ConcertPremisesForm(this, AdminUtils.GetCurrentConcertNumber());
                concert_premises_form.Owner = this;
                concert_premises_form.ShowDialog();

        } // m_button_open_premises_Click

        /// <summary>User clicked open Contact</summary>
        private void m_button_open_contact_Click(object sender, EventArgs e)
        {
            ContactForm contact_form = new ContactForm(this);
            contact_form.Owner = this;
            contact_form.ShowDialog();

        } // m_button_open_contact_Click

        /// <summary>User clicked open Premises</summary>
        private void m_button_open_members_Click(object sender, EventArgs e)
        {  // Wrong name on this event function
            PremisesForm premises_form = new PremisesForm(this);
            premises_form.Owner = this;
            premises_form.ShowDialog();

        } // m_button_open_members_Click

        /// <summary>User clicked open Member</summary>
        private void m_button_open_member_Click(object sender, EventArgs e)
        {
            OpenMemberEditTextForm();

        } // m_button_open_member_Click

        /// <summary>Open member text edit form</summary>
        private void OpenMemberEditTextForm()
        {
            MemberForm member_form = new MemberForm(this, AdminUtils.GetCurrentMemberNumber());
            member_form.Owner = this;
            member_form.FormClosing += new FormClosingEventHandler(MemberFormIsClosing);
            member_form.ShowDialog();

        } // OpenMemberEditTextForm

        /// <summary>Member form is closing. Combobox members must be updated if member name is changed or if a member is removed</summary>
        void MemberFormIsClosing(object sender, FormClosingEventArgs e)
        {
            _SetMembers();

        } // MemberFormIsClosing

        /// <summary>User clicked open Concept (About)</summary>
        private void m_button_open_about_Click(object sender, EventArgs e)
        {
            AboutUsForm about_us_form = new AboutUsForm(this);
            about_us_form.Owner = this;
            about_us_form.ShowDialog();

        } // m_button_open_about_Click

        /// <summary>User clicked open Requests</summary>
        private void m_button_open_request_Click(object sender, EventArgs e)
        {
            RequestXmlForm request_form = new RequestXmlForm(this);
            request_form.Owner = this;
            request_form.ShowDialog();

        } // m_button_open_request_Click

        /// <summary>User clicked open Musician Information</summary>
        private void m_button_open_musician_info_Click(object sender, EventArgs e)
        {
            MusicianInfoForm musician_info_form = new MusicianInfoForm(this);
            musician_info_form.Owner = this;
            musician_info_form.ShowDialog();

        } // m_button_open_musician_info_Click

        #endregion // User clicked open page

        #region  User change of season, concert, musician and member

        // It is difficult to make the combobox items only selectable not letting the user change the text
        // http://stackoverflow.com/questions/3061042/how-do-i-set-combobox-read-only-or-user-cannot-write-in-a-combo-box-only-can-sel
        //https://msdn.microsoft.com/de-de/library/system.windows.forms.combobox.dropdownstyle(v=vs.110).aspx


        /// <summary>User changed season
        /// <para>Before setting the musician combobox it is necessary set the current musician number</para>
        /// <para>1. Check if user is editing another XML file. For this case the file has first to be saved. Call of Index.ChangeOfSeasonIsAllowed</para>
        /// <para>2. Set the selected season to the active seson. Call of Index.SetCurrentSeason. </para>
        /// <para>3. Set the seasons combobox. Call of _SetSeasons. </para>
        /// </summary>
        private void m_combo_box_season_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_season = this.m_combo_box_season.Text;
            string error_message = @"";
            string current_season = @"";

            if (!Index.ChangeOfSeasonIsAllowed(selected_season, out current_season, out error_message))
            {
                this.m_combo_box_season.Text = current_season;

                return;
            }
           
            bool b_season_added = false;
            bool b_set_season = Index.SetCurrentSeason(selected_season, out b_season_added, out error_message);

            if (!b_set_season)
            {
                MessageBox.Show(error_message);

                _SetSeasons(false);
            }

            if (b_season_added)
            {
                // Avoiding infinite loop

                _SetSeasons(b_season_added);

                b_season_added = false;
            }


            _SetConcerts();

            AdminUtils.SetCurrentMusicianNumber(1);

            _SetMusicians();

         

        } // m_combo_box_season_SelectedIndexChanged

        /// <summary>User changed concert</summary>
        private void m_combo_box_concert_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_concert = this.m_combo_box_concert.Text;

            bool b_concert_added = false;
            string error_message = @"";
            bool b_set_concert = Index.SetCurrentConcert(selected_concert, out b_concert_added, out error_message);
            if (!b_set_concert)
            {
                MessageBox.Show(error_message);

                _SetConcerts();
            }

            if (b_concert_added)
            {
                _SetConcerts();

                OpenConcertEditTextForm();
            }

            AdminUtils.SetCurrentMusicianNumber(1);

            _SetMusicians();

        } // m_combo_box_concert_SelectedIndexChanged

        /// <summary>User changed musician</summary>
        private void m_combo_box_musician_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_musician = this.m_combo_box_musician.Text;

            bool b_musician_added = false;
            string error_message = @"";
            if (!Index.SetCurrentMusician(selected_musician, out b_musician_added, out error_message))
            {
                MessageBox.Show(error_message);
                AdminUtils.SetComboBoxMusicians(this.m_combo_box_musician);
                return;
            }

            if (b_musician_added)
            {
                AdminUtils.SetComboBoxMusicians(this.m_combo_box_musician);

                OpenMusicianEditTextForm();
            }
                

        } // m_combo_box_musician_SelectedIndexChanged

        /// <summary>User changed member</summary>
        private void m_combo_box_member_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_is_initializing)
                return;

            string selected_member = this.m_combo_box_member.Text;
            //if (selected_member.Equals(AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetCaptionMember())))
                // return;

            bool b_member_added = false;
            string error_message = @"";
            bool b_set_member = Index.SetCurrentMember(selected_member, out b_member_added, out error_message);

            if (!b_set_member)
            {
                MessageBox.Show(error_message);

                _SetMembers();

                return;
            }

            if (b_member_added)
            {
                _SetMembers();

                OpenMemberEditTextForm();
            }

            // OpenMemberEditTextForm();

        } // m_combo_box_member_SelectedIndexChanged

        #endregion // User change of season, concert, musician and member

        #region Checkout/Checkin

        /// <summary>User clicked the Checkout/Checkin button</summary>
        private void m_button_checkin_checkout_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                CheckinData();
            }
            else
            {
                if (!AllowCheckout())
                {
                    MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgOnlyNonPublishedProgramsMayBeChanged);
                    return;
                }

                CheckoutData();
            }

            _SetEnabled();

        } // m_button_checkin_checkout_Click

        /// <summary>Only non-published season programs are allowed to be changed
        /// <para>1. Return true if the user wants to edit old published (all) season programs</para>
        /// <para>2. Return true if the user wants to edit the current season season program. Call of JazzUtils.IsSetSeasonProgramForCurrentSeason</para>
        /// <para>3. Return true if the season not have been published. Reurn false if published. Call of AdminUtils.SeasonProgramNotPublished</para>
        /// </summary>
        private bool AllowCheckout()
        {

            if (m_check_box_edit_all_seasons.Checked)
                return true;

            if (JazzUtils.IsSetSeasonProgramForCurrentSeason())
                return true;

            if (AdminUtils.SeasonProgramNotPublished())
                return true;
            else
                return false;

        } // AllowCheckout

        /// <summary>Check out data and set Checkin/Checkout button to Save</summary>
        public void CheckoutData()
        {
            _ReloadXmlBeforeCheckout();

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

            Main.CheckoutButNoWebsiteUpdate = true;

            _SetLoginLogout();

            _SetCurrentEditDocument();

            bool xml_edited = false;
            string err_message = @"";
            if (Backup.BackupCurrentEditXmlFile(AdminUtils.GetCurrentSelectedXmlFile(), xml_edited, out err_message))
            {
                string file_no_path = Path.GetFileName(AdminUtils.GetCurrentSelectedXmlFile());
                this.m_textbox_message.Text = file_no_path + JazzAppAdminSettings.Default.MsgBackupCurrenXml;
            }
            else
            {
                err_message = "IndexForm.CheckoutData Backup Program error: " + err_message;
                this.m_textbox_message.Text = err_message;

            }

            // Make also always a copy of the application XMLfile. A backup is made when titles are edited
            // But the application don't know when member data is changed. TODO
            if (!Backup.BackupCurrentEditXmlFile(AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetApplicationFileName()), xml_edited, out err_message))
            {
                err_message = "IndexForm.CheckoutData Program error (aaplication): " + err_message;
            }

        } // CheckoutData

        /// <summary>Reload XML before checkout</summary>
        private void _ReloadXmlBeforeCheckout()
        {
            AdminUtils.ReloadApplicationXml();
            AdminUtils.ReloadCurrentSeasonProgramXml();

        } // _ReloadXmlBeforeCheckout

        /// <summary>Set the current edit document</summary>
        private void _SetCurrentEditDocument()
        {
            AdminUtils.SetCurrentEditDocument(JazzXml.GetDocumentCurrent());
            AdminUtils.SetCurrentSelectedXmlFile(JazzXml.GetCurrentSeasonFileUrl());

        } // _SetCurrentEditDocument

        /// <summary>Checkin XML data
        /// <para>1. Upload the changed XML file to the server. Call of AdminUtils.UploadEditedXmlToServer</para>
        /// <para>2. Reload all seasons XML documents. Call of JazzXml.InitXmlAllSeasons</para>
        /// <para>   At startup of this application all season XML objects are created and stored in an array.</para>
        /// <para>   This array is used (call of JazzXml.GetSeasonDocuments) when the user changes the season</para>
        /// <para>   An alternative (better) solution would be to update the changed element in the array</para>
        /// <para>3. Set current edit document to null. Call of AdminUtils.SetCurrentEditDocument and SetCurrentSelectedXmlFile</para>
        /// <para>4. Set Checkin/Checkout button to Save. Call of LoginLogout.Checkin and _SetLoginLogout</para>
        /// <para></para>
        /// </summary>
        /// <param name="error_message">Output error message</param>
        private void CheckinData()
        {
            string error_message = @"";
            if (!AdminUtils.UploadEditedXmlToServer(out error_message))
            {
                error_message = @"IndexForm.CheckinData Programming error: " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }

            JazzXml.InitXmlAllSeasons();

            this.m_textbox_message.Text = @"";

            AdminUtils.SetCurrentEditDocument(null);
            AdminUtils.SetCurrentSelectedXmlFile(@"");

            string out_message = @"";
            bool force_checkin = false;
            if (!JazzLoginLogout.LoginLogout.Checkin(force_checkin, out out_message, out error_message))
            {
                error_message = @"IndexForm.CheckinData Programming error: " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }

            _SetLoginLogout();
        } // CheckinData

        #endregion // Checkout/Checkin

        #region Changes of combobox item texts

        /// <summary>User tries to change item text of the musician combobox</summary>
        private void m_combo_box_musician_KeyDown(object sender, KeyEventArgs e)
        {
            // Disturbing for the user MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgComboboxItemTextChange);
        }
        /// <summary>User tries to change item text of the concert combobox</summary>
        private void m_combo_box_concert_KeyDown(object sender, KeyEventArgs e)
        {
            // TODO Does not work????  AdminUtils.ResetComboboxConcertsText(m_combo_box_concert);
            // Disturbing for the user MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgComboboxItemTextChange);
        }
        /// <summary>User tries to change item text of the season combobox</summary>
        private void m_combo_box_season_KeyDown(object sender, KeyEventArgs e)
        {
            // Disturbing for the user MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgComboboxItemTextChange);
        }
        /// <summary>User tries to change item text of the member combobox</summary>
        private void m_combo_box_member_KeyDown(object sender, KeyEventArgs e)
        {
            // Disturbing for the user MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgComboboxItemTextChange);
        }


        #endregion Changes of combobox item texts

        #region Not used events

        /// <summary>Not yet used event</summary>
        private void IndexFormLoad(object sender, EventArgs e)
        {
            // string out_message = @"";
        } // IndexFormLoad

        /// <summary>Handler for event Shown</summary>
        private void JazzAppAdminForm_Shown(object sender, EventArgs e)
        {
            // Do not work TODO  _SetTitles();
        } // JazzAppAdminForm_Shown

        #endregion // Not used events

        #region Help and develop

        /// <summary>User clicked the help button</summary>
        private void m_button_help_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameAdminXmlEdit() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm help_form = new HelpForm(HelpFiles.GetFilenameAdminXmlEdit());
                help_form.Owner = this;
                help_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }

        } // m_button_help_Click

        /// <summary>User clicked the developer button</summary>
        private void m_button_developer_Click(object sender, EventArgs e)
        {
            XmlEditDeveloperForm xml_edit_developer_form = new XmlEditDeveloperForm(this);
            xml_edit_developer_form.Owner = this;
            xml_edit_developer_form.ShowDialog();

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                // m_editable = true;

               

               
            }

        } // m_button_developer_Click

        #endregion // Help and develop

    } // IndexForm

} // namespace
