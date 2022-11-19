using JazzApp;
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
    /// <summary>Edit musician contact page text</summary>
    public partial class MemberForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor</summary>
        public MemberForm(IndexForm i_index_form, int i_member)
        {
            InitializeComponent();

            if (null == i_index_form)
                return;

            if (i_member <= 0)
                return;

            m_index_form = i_index_form;

            Member.SetMemberNumber(i_member);

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
            ToolTipMember.SetToolTip(this, JazzAppAdminSettings.Default.ToolTipMember);
            ToolTipUtil.SetDelays(ref ToolTipMember);
            ToolTipMemberEdit.SetToolTip(m_button_edit_concert_data, JazzAppAdminSettings.Default.ToolTipMemberEdit);
            ToolTipUtil.SetDelays(ref ToolTipMemberEdit);
            ToolTipMemberDelete.SetToolTip(m_button_delete_member, JazzAppAdminSettings.Default.ToolTipMemberDelete);
            ToolTipUtil.SetDelays(ref ToolTipMemberDelete);
            ToolTipMemberCancel.SetToolTip(m_button_cancel, JazzAppAdminSettings.Default.ToolTipMemberCancel);
            ToolTipUtil.SetDelays(ref ToolTipMemberCancel);
            ToolTipMemberClose.SetToolTip(m_button_close, JazzAppAdminSettings.Default.ToolTipMemberClose);
            ToolTipUtil.SetDelays(ref ToolTipMemberClose);

        } // SetToolTips

        /// <summary>Set controls editable or not</summary>
        private void SetEditable()
        {
            if (m_editable)
            {
                this.m_text_box_first_name.Enabled = true;
                this.m_text_box_family_name.Enabled = true;
                this.m_text_box_main_task.Enabled = true;
                this.m_text_box_email.Enabled = true;
                this.m_text_box_email_private.Enabled = true;
                this.m_text_box_street.Enabled = true;
                this.m_text_box_area_code.Enabled = true;
                this.m_text_box_city.Enabled = true;
                this.m_text_box_telephone.Enabled = true;
                this.m_text_box_telephone_fix.Enabled = true;
                this.m_text_box_photo_small.Enabled = true;
                this.m_text_box_start_year.Enabled = true;
                this.m_text_box_end_year.Enabled = true;
                this.m_text_box_password.Enabled = true;
                this.m_text_box_number.Enabled = true;

                this.m_rich_text_box_tasks.Enabled = true;
                this.m_rich_text_box_why.Enabled = true;
                this.m_text_box_number.Enabled = true;
                this.m_check_box_active.Enabled = true;

                this.m_text_box_first_name.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_family_name.BackColor = AdminUtils.ColorEnable(); ;
                this.m_text_box_main_task.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_email.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_email_private.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_street.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_area_code.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_city.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_telephone.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_telephone_fix.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_photo_small.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_start_year.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_end_year.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_password.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_number.BackColor = AdminUtils.ColorEnable();

                this.m_rich_text_box_tasks.BackColor = AdminUtils.ColorEnable();
                this.m_rich_text_box_why.BackColor = AdminUtils.ColorEnable();
                this.m_check_box_active.BackColor = AdminUtils.ColorEnable();

            }
            else
            {
                this.m_text_box_first_name.Enabled = false;
                this.m_text_box_family_name.Enabled = false;
                this.m_text_box_main_task.Enabled = false;
                this.m_text_box_email.Enabled = false;
                this.m_text_box_email_private.Enabled = false;
                this.m_text_box_street.Enabled = false;
                this.m_text_box_area_code.Enabled = false;
                this.m_text_box_city.Enabled = false;
                this.m_text_box_telephone.Enabled = false;
                this.m_text_box_telephone_fix.Enabled = false;
                this.m_text_box_photo_small.Enabled = false;
                this.m_text_box_start_year.Enabled = false;
                this.m_text_box_end_year.Enabled = false;
                this.m_text_box_password.Enabled = false;
                this.m_text_box_number.Enabled = false;

                this.m_rich_text_box_tasks.Enabled = false;
                this.m_rich_text_box_why.Enabled = false;
                this.m_text_box_number.Enabled = false;
                this.m_check_box_active.Enabled = false;

                // this.m_text_box_contact_name.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_first_name.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_family_name.BackColor = AdminUtils.ColorDisable(); ;
                this.m_text_box_main_task.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_email.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_email_private.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_street.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_area_code.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_city.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_telephone.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_telephone_fix.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_photo_small.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_start_year.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_end_year.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_password.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_number.BackColor = AdminUtils.ColorDisable();

                this.m_rich_text_box_tasks.BackColor = AdminUtils.ColorDisable();
                this.m_rich_text_box_why.BackColor = AdminUtils.ColorDisable();
                this.m_check_box_active.BackColor = AdminUtils.ColorDisable();

            }

            // The delete function is implemented and tested, but members shall normally not be deleted
            // The members statistics function shows all persons that have been working in the jazz club
            m_button_delete_member.Enabled = false;
            m_button_delete_member.Visible = false;

        } // SetEditable

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(Member.GetTitlePage());
            this.m_label_page_header.Text = Member.GetTitlePage();
            this.m_label_name.Text = Member.GetTitleName();
            this.m_label_email.Text = Member.GetTitleEmail();
            this.m_label_email_private.Text = Member.GetTitleEmailPrivate();
            this.m_label_telephone.Text = Member.GetTitleTelephone();
            this.m_label_telephone_fix.Text = Member.GetTitleTelephoneFix();
            this.m_label_address.Text = Member.GetTitleAddress();
            this.m_label_start_year.Text = Member.GetTitleStartYear();
            this.m_label_end_year.Text = Member.GetTitleEndYear();
            this.m_label_password.Text = Member.GetTitleLoginPassword();
            this.m_label_main_task.Text = Member.GetTitleMainTasks();
            this.m_label_tasks.Text = Member.GetTitleTasks();
            this.m_label_why.Text = Member.GetWhy();
            this.m_label_photo_small.Text = Member.GetTitlePhoto();
            this.m_label_number.Text = Member.GetTitleNumber();
            this.m_check_box_active.Text = Member.GetTitleActive();

        } // SetTitles

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_first_name.Text = Member.GetMemberName();
            this.m_text_box_family_name.Text = Member.GetMemberFamilyName();
            this.m_text_box_main_task.Text = Member.GetMemberTasksShort();
            this.m_text_box_email.Text = Member.GetMemberEmail();
            this.m_text_box_email_private.Text = Member.GetMemberEmailPrivate();
            this.m_text_box_street.Text = Member.GetMemberStreet();
            this.m_text_box_area_code.Text = Member.GetMemberPostCode();
            this.m_text_box_city.Text = Member.GetMemberCity();
            this.m_text_box_telephone.Text = Member.GetMemberTelephone();
            this.m_text_box_telephone_fix.Text = Member.GetMemberTelephoneFix();
            this.m_text_box_photo_small.Text = Member.GetMemberPhotoSmallSize();
            this.m_text_box_start_year.Text = Member.GetMemberStartYear();
            this.m_text_box_end_year.Text = Member.GetMemberEndYear();
            this.m_text_box_password.Text = Member.GetMemberPassword();
            this.m_text_box_number.Text = Member.GetMemberNumberString();

            this.m_rich_text_box_tasks.Text = Member.GetMemberTasks();
            this.m_rich_text_box_why.Text = Member.GetMemberWhy();

            if (Member.GetMemberActiveFlag())
                this.m_check_box_active.Checked = true;
            else
                this.m_check_box_active.Checked = false;

        } // SetTexts

        #endregion // Set controls

        #region Write data

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            AdminUtils.SetApplicationDocumentChangeFlag(true);

            if (!Member.WriteMemberName(this.m_text_box_first_name.Text, out o_error)) return false;

            if (!Member.WriteMemberFamilyName(this.m_text_box_family_name.Text, out o_error)) return false;

            if (!Member.WriteMemberTasksShort(this.m_text_box_main_task.Text, out o_error)) return false;

            if (!Member.WriteMemberEmailAddress(this.m_text_box_email.Text, out o_error)) return false;

            if (!Member.WriteMemberEmailPrivate(this.m_text_box_email_private.Text, out o_error)) return false;

            if (!Member.WriteMemberStreet(this.m_text_box_street.Text, out o_error)) return false;

            if (!Member.WriteMemberPostCode(this.m_text_box_area_code.Text, out o_error)) return false;

            if (!Member.WriteMemberCity(this.m_text_box_city.Text, out o_error)) return false;

            if (!Member.WriteMemberPhotoSmallSize(this.m_text_box_photo_small.Text, out o_error)) return false;

            if (!Member.WriteMemberTelephone(this.m_text_box_telephone.Text, out o_error)) return false;

            if (!Member.WriteMemberTelephoneFix(this.m_text_box_telephone_fix.Text, out o_error)) return false;

            if (!Member.WriteMemberStartYear(this.m_text_box_start_year.Text, out o_error)) return false;

            if (!Member.WriteMemberEndYear(this.m_text_box_end_year.Text, out o_error)) return false;

            if (!Member.WriteMemberPassword(this.m_text_box_password.Text, out o_error)) return false;

            if (!Member.WriteMemberNumber(this.m_text_box_number.Text, out o_error)) return false;

            if (!Member.WriteMemberTasks(this.m_rich_text_box_tasks.Text, out o_error)) return false;

            if (!Member.WriteMemberWhy(this.m_rich_text_box_why.Text, out o_error)) return false;

            if (this.m_check_box_active.Checked)
                Member.WriteMemberActiveFlag(true, out o_error);
            else
                Member.WriteMemberActiveFlag(false, out o_error);

            return true;

        } // WriteTexts

        #endregion // Write data

        #region Event functions

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

        /// <summary>Delete member</summary>
        private void m_button_delete_member_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgCheckoutBeforeRemovingMember);

                return;
            }

            int stat_remove = JazzXml.RemoveMemberNode(AdminUtils.GetCurrentMemberNumber());
            if (0 == stat_remove)
            {
                AdminUtils.SetCurrentMemberNumber(1);
                this.Close();

                // Combobox in IndexForm is updated when this form is closed
            }
            else if (-1 == stat_remove)
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgRemoveLastMember);
            }
            else
            {
                MessageBox.Show("MemberForm Programming error: Removing member failed stat_remove= " + stat_remove.ToString());
            }

        } // m_button_delete_member_Click

        #endregion // Event functions

    } // MemberForm
} // namespace
