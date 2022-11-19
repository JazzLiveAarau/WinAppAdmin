using JazzApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Musician contact (form) variables and functions</summary>
    class MusicianContact
    {
        #region Concert number

        /// <summary>Concert number</summary>
        static private int m_concert = -12345;

        /// <summary>Set concert number</summary>
        static public void SetConcertNumber(int i_concert) { m_concert = i_concert; }

        #endregion // Concert number

        #region Write text functions

        /// <summary>Writes the name of the contact person</summary>
        static public bool WriteContactPerson(string i_contact_name, out string o_error)
        {
            o_error = @"";

            JazzXml.SetContactPerson(m_concert, i_contact_name);

            return true;
        } // WriteContactPerson

        /// <summary>Writes the email address to the contact person</summary>
        static public bool WriteContactEmail(string i_contact_email, out string o_error)
        {
            o_error = @"";

            JazzXml.SetContactEmail(m_concert, i_contact_email);

            return true;
        } // WriteContactEmail

        /// <summary>Writes the email address to the contact person</summary>
        static public bool WriteContactTelephone(string i_contact_telephone, out string o_error)
        {
            o_error = @"";

            bool ret_check = AdminUtils.CheckTelephone(i_contact_telephone, out o_error);
            if (!ret_check)
                return false;

            JazzXml.SetContactTelephone(m_concert, i_contact_telephone.Trim());

            return true;
        } // WriteContactTelephone


        /// <summary>Writes the street address to the contact person</summary>
        static public bool WriteContactStreet(string i_contact_street, out string o_error)
        {
            o_error = @"";

            JazzXml.SetContactStreet(m_concert, i_contact_street);

            return true;
        } // WriteContactStreet

        /// <summary>Writes the post code to the contact person</summary>
        static public bool WriteContactPostCode(string i_contact_code, out string o_error)
        {
            o_error = @"";

            JazzXml.SetContactPostCode(m_concert, i_contact_code);

            return true;
        } // WriteContactPostCode

        /// <summary>Writes the city to the contact person</summary>
        static public bool WriteContactCity(string i_contact_city, out string o_error)
        {
            o_error = @"";

            JazzXml.SetContactCity(m_concert, i_contact_city);

            return true;
        } // WriteContactCity

        /// <summary>Writes the IBAN number for the contact person</summary>
        static public bool WriteIbanNumber(string i_iban_number, out string o_error)
        {
            o_error = @"";

            JazzXml.SetIbanNumber(m_concert, i_iban_number);

            return true;
        } // WriteIbanNumber

        /// <summary>Writes the remark for the contact person</summary>
        static public bool WriteContactRemark(string i_contact_remark, out string o_error)
        {
            o_error = @"";

            JazzXml.SetContactRemark(m_concert, i_contact_remark);

            return true;
        } // WriteContactRemark

        /// <summary>Writes the for the band</summary>
        static public bool WriteLoginPassword(string i_musician_password, out string o_error)
        {
            o_error = @"";

            JazzXml.SetLoginPassword(m_concert, i_musician_password);

            return true;
        } // WriteLoginPassword

        #endregion // Write text functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetCaptionMusicianContacts()); }

        /// <summary>Returns the musician contact name title</summary>
        static public string GetTitleName() { return JazzAppAdminSettings.Default.GuiTextMusicianContactName; }

        /// <summary>Returns the musician contact email title</summary>
        static public string GetTitleEmail() { return JazzAppAdminSettings.Default.GuiTextMusicianContactEmail; }

        /// <summary>Returns the musician contact telephone title</summary>
        static public string GetTitleTelephone() { return JazzAppAdminSettings.Default.GuiTextMusicianContactTelephone; }

        /// <summary>Returns the musician contact street title</summary>
        static public string GetTitleStreet() { return JazzAppAdminSettings.Default.GuiTextMusicianContactStreet; }

        /// <summary>Returns the musician contact postal code title</summary>
        static public string GetTitlePostCode() { return JazzAppAdminSettings.Default.GuiTextMusicianContactPostCode; }

        /// <summary>Returns the musician contact city title</summary>
        static public string GetTitleCity() { return JazzAppAdminSettings.Default.GuiTextMusicianContactCity; }

        /// <summary>Returns the musician contact IBAN title</summary>
        static public string GetTitleIbanNumber() { return JazzAppAdminSettings.Default.GuiTextMusicianContactIban; }

        /// <summary>Returns the musician contact remark title</summary>
        static public string GetTitleContactRemark() { return JazzAppAdminSettings.Default.GuiTextMusicianContactRemark; }

        /// <summary>Returns the caption for the view as text button</summary>
        static public string GetCaptionViewContactDataAsText() { return JazzAppAdminSettings.Default.GuiTextMusicianContactViewText; }

        /// <summary>Returns the musician contact password</summary>
        static public string GetTitleLoginPassword() { return JazzAppAdminSettings.Default.GuiTextMusicianPassword; }

        #endregion // Get title and caps functions

        #region Get text functions

        /// <summary>Returns the name of the contact person</summary>
        static public string GetContactPerson() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetContactPerson(m_concert)); }

        /// <summary>Returns the email to the contact person</summary>
        static public string GetContactEmail() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetContactEmail(m_concert)); }

        /// <summary>Returns the telephone to the contact person</summary>
        static public string GetContactTelephone() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetContactTelephone(m_concert)); }

        /// <summary>Returns the street to the contact person</summary>
        static public string GetContactStreet() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetContactStreet(m_concert)); }

        /// <summary>Returns the postal code to the contact person</summary>
        static public string GetContactPostCode() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetContactPostCode(m_concert)); }

        /// <summary>Returns the city to the contact person</summary>
        static public string GetContactCity() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetContactCity(m_concert)); }

        /// <summary>Returns the IBAN number for the contact person</summary>
        static public string GetIbanNumber() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetIbanNumber(m_concert)); }

        /// <summary>Returns the remark for the contact person</summary>
        static public string GetContactRemark() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetContactRemark(m_concert)); }

        /// <summary>Returns the musician</summary>
        static public string GetMusicianLoginPassword() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetLoginPassword(m_concert)); }

        #endregion // Get text functions

        #region List contact data as plain text

        /// <summary>Create text file with contact data</summary>
        static public bool CreateContactDataTextFile(out string o_file_name, out string o_error)
        {
            o_error = @"";
            o_file_name = @"";

            string out_str = NewLine() + GetTitlePage() + " " + TimeUtil.YearMonthDayIso() + NewLine();
            out_str = out_str + @"===================================" + NewLine() + NewLine();

            out_str = out_str + GetTitleName() + NewLine();
            out_str = out_str + GetContactPerson() + NewLine() + NewLine();

            out_str = out_str + GetTitleEmail() + NewLine();
            out_str = out_str + GetContactEmail() + NewLine() + NewLine();

            out_str = out_str + GetTitleTelephone() + NewLine();
            out_str = out_str + GetContactTelephone() + NewLine() + NewLine();

            out_str = out_str + GetTitleStreet() + NewLine();
            out_str = out_str + GetContactStreet() + NewLine() + NewLine();

            out_str = out_str + GetTitlePostCode() + NewLine();
            out_str = out_str + GetContactPostCode() + NewLine() + NewLine();

            out_str = out_str + GetTitleCity() + NewLine();
            out_str = out_str + GetContactCity() + NewLine() + NewLine();

            out_str = out_str + GetTitleIbanNumber() + NewLine();
            out_str = out_str + GetIbanNumber() + NewLine() + NewLine();

            out_str = out_str + GetTitleContactRemark() + NewLine();
            out_str = out_str + GetContactRemark() + NewLine() + NewLine();

            string file_name = ReplaceSpaces(GetContactPerson()) + TimeUtil.YearMonthDay() + @".txt";

            string local_address_directory = FileUtil.SubDirectory(DocAdmin.GetNameDirectoryDocuments(), Main.m_exe_directory) + @"\";

            string full_file_name = local_address_directory + file_name;

            File.WriteAllText(full_file_name, out_str);

            o_file_name = full_file_name;

            return true;

        } // CreateContactDataTextFile

        /// <summary>Returns new line (for Windows)</summary>
        private static string NewLine() { return "\r\n"; }

        /// <summary>Replaces spaces in string (name)</summary>
        private static string ReplaceSpaces(string i_name_str)
        {
            string o_no_space_str = @"";

            o_no_space_str = i_name_str.Replace(" ", "_");

            return o_no_space_str;

        } // ReplaceSpaces

        #endregion // List contact data as plain text

    } // MusicianContact
} // namespace
