using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Member (form) variables and functions</summary>
    class Member
    {
        #region Member number

        /// <summary>Concert number</summary>
        static private int m_member = -12345;

        /// <summary>Set concert number</summary>
        static public void SetMemberNumber(int i_member) { m_member = i_member; }

        #endregion // Member number

        #region Write text functions

        /// <summary>Writes the name of the member</summary>
        static public bool WriteMemberName(string i_member_name, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberName(m_member, i_member_name);

            return true;
        } // WriteMemberName

        /// <summary>Writes the family name of the member</summary>
        static public bool WriteMemberFamilyName(string i_member_family_name, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberFamilyName(m_member, i_member_family_name);

            return true;
        } // WriteMemberFamilyName

        /// <summary>Writes the member email address</summary>
        static public bool WriteMemberEmailAddress(string i_member_email, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberEmailAddress(m_member, i_member_email);

            return true;
        } // WriteMemberEmailAddress

        /// <summary>Writes the member private email address</summary>
        static public bool WriteMemberEmailPrivate(string i_member_email_private, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberEmailPrivate(m_member, i_member_email_private);

            return true;
        } // WriteMemberEmailPrivate

        /// <summary>Writes the member telephone</summary>
        static public bool WriteMemberTelephone(string i_member_telephone, out string o_error)
        {
            o_error = @"";

            bool ret_check = AdminUtils.CheckTelephone(i_member_telephone, out o_error);
            if (!ret_check)
                return false;

            JazzXml.SetMemberTelephone(m_member, i_member_telephone.Trim());

            return true;
        } // WriteMemberTelephone

        /// <summary>Writes the member fix telephone</summary>
        static public bool WriteMemberTelephoneFix(string i_member_telephone_fix, out string o_error)
        {
            o_error = @"";

            bool ret_check = AdminUtils.CheckTelephone(i_member_telephone_fix, out o_error);
            if (!ret_check)
                return false;

            JazzXml.SetMemberTelephoneFix(m_member, i_member_telephone_fix.Trim());

            return true;
        } // WriteMemberTelephoneFix

        /// <summary>Writes the member street</summary>
        static public bool WriteMemberStreet(string i_member_street, out string o_error)
        {
            o_error = @"";
            
            JazzXml.SetMemberStreet(m_member, i_member_street);

            return true;
        } // WriteMemberStreet

        /// <summary>Writes the member city</summary>
        static public bool WriteMemberCity(string i_member_city, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberCity(m_member, i_member_city);

            return true;
        } // WriteMemberCity

        /// <summary>Writes the member postal code</summary>
        static public bool WriteMemberPostCode(string i_member_post_code, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberPostCode(m_member, i_member_post_code);

            return true;
        } // WriteMemberPostCode

        /// <summary>Writes the member mid size photo</summary>
        static public bool WriteMemberPhotoMidSize(string i_photo_mid, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckRelativePath(i_photo_mid, out o_error))
                return false;

            JazzXml.SetMemberPhotoMidSize(m_member, i_photo_mid);

            return true;
        } // WriteMemberPhotoMidSize

        /// <summary>Writes the member small size photo</summary>
        static public bool WriteMemberPhotoSmallSize(string i_photo_small, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckRelativePath(i_photo_small, out o_error))
                return false;

            JazzXml.SetMemberPhotoSmallSize(m_member, i_photo_small);

            return true;
        } // WriteMemberPhotoSmallSize

        /// <summary>Writes the member tasks</summary>
        static public bool WriteMemberTasks(string i_member_tasks, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberTasks(m_member, i_member_tasks);

            return true;
        } // WriteMemberTasks

        /// <summary>Writes the member tasks,short description</summary>
        static public bool WriteMemberTasksShort(string i_member_tasks_short, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberTasksShort(m_member, i_member_tasks_short);

            return true;
        } // WriteMemberTasksShort

        /// <summary>Writes the member why</summary>
        static public bool WriteMemberWhy(string i_member_why, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberWhy(m_member, i_member_why);

            return true;
        } // WriteMemberWhy

        /// <summary>Writes the member start year</summary>
        static public bool WriteMemberStartYear(string i_member_start_year, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckYear(i_member_start_year, out o_error))
                return false;

            JazzXml.SetMemberStartYear(m_member, i_member_start_year.Trim());

            return true;
        } // WriteMemberStartYear

        /// <summary>Writes the member end year</summary>
        static public bool WriteMemberEndYear(string i_member_end_year, out string o_error)
        {
            o_error = @"";

            if (i_member_end_year.Trim().Length > 0)
            {
                if (!AdminUtils.CheckYear(i_member_end_year, out o_error))
                    return false;
            }

            JazzXml.SetMemberEndYear(m_member, i_member_end_year.Trim());

            return true;
        } // WriteMemberEndYear

        /// <summary>Writes the member password</summary>
        static public bool WriteMemberPassword(string i_member_password, out string o_error)
        {
            o_error = @"";
            
            JazzXml.SetMemberPassword(m_member, i_member_password);

            return true;
        } // WriteMemberPassword

        /// <summary>Writes the member number (identity)</summary>
        static public bool WriteMemberNumber(string i_member_number, out string o_error)
        {
            o_error = @"";

            // TODO Check
            JazzXml.SetMemberNumber(m_member, i_member_number);

            return true;
        } // WriteMemberNumber

        /// <summary>Writes the flag telling if the member is active</summary>
        static public bool WriteMemberVorstand(string i_member_vorstand, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberVorstand(m_member, i_member_vorstand);

            return true;
        } // WriteMemberVorstand

        /// <summary>Writes the flag telling if the member is active</summary>
        static public bool WriteMemberActiveFlag(bool i_member_active, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMemberActiveFlag(m_member, i_member_active);

            return true;
        } // WriteMemberActiveFlag

        #endregion // Write text functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetCaptionMember()); }

        /// <summary>Returns the member name title</summary>
        static public string GetTitleName() { return JazzAppAdminSettings.Default.GuiTextMemberName; }

        /// <summary>Returns the member email title</summary>
        static public string GetTitleEmail() { return JazzAppAdminSettings.Default.GuiTextMemberEmail; }

        /// <summary>Returns the member email private title</summary>
        static public string GetTitleEmailPrivate() { return JazzAppAdminSettings.Default.GuiTextMemberEmailPrivate; }

        /// <summary>Returns the member telephone title</summary>
        static public string GetTitleTelephone() { return JazzAppAdminSettings.Default.GuiTextMemberTelephone; }

        /// <summary>Returns the member fix telephone title</summary>
        static public string GetTitleTelephoneFix() { return JazzAppAdminSettings.Default.GuiTextMemberTelephoneFix; }

        /// <summary>Returns the member address title</summary>
        static public string GetTitleAddress() { return JazzAppAdminSettings.Default.GuiTextMemberAddress; }

        /// <summary>Returns the member main tasks title</summary>
        static public string GetTitleMainTasks() { return JazzAppAdminSettings.Default.GuiTextMemberMainTasks; }

        /// <summary>Returns the member tasks title</summary>
        static public string GetTitleTasks() { return JazzAppAdminSettings.Default.GuiTextMemberTasks; }

        /// <summary>Returns the member why title</summary>
        static public string GetWhy() { return JazzAppAdminSettings.Default.GuiTextMemberWhy; }

        /// <summary>Returns the photo title</summary>
        static public string GetTitlePhoto() { return JazzAppAdminSettings.Default.GuiTextMemberPhoto; }

        /// <summary>Returns the member password title</summary>
        static public string GetTitleLoginPassword() { return JazzAppAdminSettings.Default.GuiTextMemberPassword; }

        /// <summary>Returns the member start year title</summary>
        static public string GetTitleStartYear() { return JazzAppAdminSettings.Default.GuiTextMemberStartYear; }

        /// <summary>Returns the member end year title</summary>
        static public string GetTitleEndYear() { return JazzAppAdminSettings.Default.GuiTextMemberEndYear; }

        /// <summary>Returns the member number title</summary>
        static public string GetTitleNumber() { return JazzAppAdminSettings.Default.GuiTextMemberNumber; }

        /// <summary>Returns the member active flag title</summary>
        static public string GetTitleActive() { return JazzAppAdminSettings.Default.GuiTextMemberActive; }

        #endregion // Get title and caps functions

        #region Get text functions

        /// <summary>Returns the member name</summary>
        static public string GetMemberName() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberName(m_member)); }

        /// <summary>Returns the member family name</summary>
        static public string GetMemberFamilyName() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberFamilyName(m_member)); }

        /// <summary>Returns the member Email address</summary>
        static public string GetMemberEmail() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberEmail(m_member)); }

        /// <summary>Returns the member private Email address</summary>
        static public string GetMemberEmailPrivate() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberEmailPrivate(m_member)); }

        /// <summary>Returns the member telephone number</summary>
        static public string GetMemberTelephone() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberTelephone(m_member)); }

        /// <summary>Returns the member fix telephone number</summary>
        static public string GetMemberTelephoneFix() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberTelephoneFix(m_member)); }

        /// <summary>Returns the member street</summary>
        static public string GetMemberStreet() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberStreet(m_member)); }

        /// <summary>Returns the member city</summary>
        static public string GetMemberCity() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberCity(m_member)); }

        /// <summary>Returns the member postal code</summary>
        static public string GetMemberPostCode() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberPostCode(m_member)); }

        /// <summary>Returns the member password</summary>
        static public string GetMemberPassword() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberPassword(m_member)); }

        /// <summary>Returns the member mid size photo</summary>
        static public string GetMemberPhotoMidSize() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberPhotoMidSize(m_member)); }

        /// <summary>Returns the member small size photo</summary>
        static public string GetMemberPhotoSmallSize() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberPhotoSmallSize(m_member)); }

        /// <summary>Returns the member tasks</summary>
        static public string GetMemberTasks() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberTasks(m_member)); }

        /// <summary>Returns the member main tasks</summary>
        static public string GetMemberTasksShort() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberTasksShort(m_member)); }

        /// <summary>Returns the member why</summary>
        static public string GetMemberWhy() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberWhy(m_member)); }

        /// <summary>Returns the member start year</summary>
        static public string GetMemberStartYear() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberStartYear(m_member)); }

        /// <summary>Returns the member end year</summary>
        static public string GetMemberEndYear() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberEndYear(m_member)); }

        /// <summary>Returns the member number as string</summary>
        static public string GetMemberNumberString() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberNumberString(m_member)); }

        /// <summary>Returns the member active flag</summary>
        static public string GetMemberVorstandFlag() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMemberVorstandFlag(m_member)); }

        /// <summary>Returns the member active flag</summary>
        static public bool GetMemberActiveFlag() { return JazzXml.GetMemberActiveFlag(m_member); }

        #endregion // Get text functions

    } // Member

} // namespace
