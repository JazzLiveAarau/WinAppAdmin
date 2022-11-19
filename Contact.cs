using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Contact (form) variables and functions</summary>
    public static class Contact
    {
        #region Write text functions

        /// <summary>Writes the header for the contacts</summary>
        static public bool WriteContactsHeader(string i_contacts_header, out string o_error)
        {
            o_error = @"";

            JazzXml.SetContactsHeader(i_contacts_header);

            return true;
        } // WriteContactsHeader

        /// <summary>Writes the mail header</summary>
        static public bool WriteMailHeader(string i_mail_header, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMailHeader(i_mail_header);

            return true;
        } // WriteMailHeader

        /// <summary>Writes the email header</summary>
        static public bool WriteEmailHeader(string i_email_header, out string o_error)
        {
            o_error = @"";

            JazzXml.SetEmailHeader(i_email_header);

            return true;
        } // WriteEmailHeader

        /// <summary>Writes the reservation header</summary>
        static public bool WriteReservationHeader(string i_email_header, out string o_error)
        {
            o_error = @"";

            JazzXml.SetReservationHeader(i_email_header);

            return true;
        } // WriteReservationHeader

        /// <summary>Writes the newsletter header</summary>
        static public bool WriteNewsletterHeader(string i_newsletter_header, out string o_error)
        {
            o_error = @"";

            JazzXml.SetNewsletterHeader(i_newsletter_header);

            return true;
        } // WriteNewsletterHeader

        /// <summary>Writes the webmaster header</summary>
        static public bool WriteWebmasterHeader(string i_webmaster_header, out string o_error)
        {
            o_error = @"";

            JazzXml.SetWebmasterHeader(i_webmaster_header);

            return true;
        } // WriteWebmasterHeader

        /// <summary>Writes the club name</summary>
        static public bool WriteClubName(string i_club_name, out string o_error)
        {
            o_error = @"";

            JazzXml.SetClubName(i_club_name);

            return true;
        } // WriteClubName

        /// <summary>Writes the clubs postal address</summary>
        static public bool WriteMailAddress(string i_mail_address, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMailAddress(i_mail_address);

            return true;
        } // WriteMailAddress

        /// <summary>Writes the clubs email address</summary>
        static public bool WriteEmailJazzLiveAarau(string i_email_address, out string o_error)
        {
            o_error = @"";

            JazzXml.SetEmailJazzLiveAarau(i_email_address);

            return true;
        } // WriteEmailJazzLiveAarau

        /// <summary>Writes the reservation email address</summary>
        static public bool WriteEmailReservation(string i_email_reservation, out string o_error)
        {
            o_error = @"";

            JazzXml.SetEmailReservation(i_email_reservation);

            return true;
        } // WriteEmailReservation

        /// <summary>Writes the reservation subject</summary>
        static public bool WriteReservationSubject(string i_reservation_subject, out string o_error)
        {
            o_error = @"";

            JazzXml.SetReservationSubject(i_reservation_subject);

            return true;
        } // WriteReservationSubject

        /// <summary>Writes the reservation text</summary>
        static public bool WriteReservationText(string i_reservation_text, out string o_error)
        {
            o_error = @"";

            JazzXml.SetReservationText(i_reservation_text);

            return true;
        } // WriteReservationText

        /// <summary>Writes the newsletter subject</summary>
        static public bool WriteNewsletterSubject(string i_newsletter_subject, out string o_error)
        {
            o_error = @"";

            JazzXml.SetNewsletterSubject(i_newsletter_subject);

            return true;
        } // WriteNewsletterSubject

        /// <summary>Writes the newsletter text</summary>
        static public bool WriteNewsletterText(string i_newsletter_text, out string o_error)
        {
            o_error = @"";

            JazzXml.SetNewsletterText(i_newsletter_text);

            return true;
        } // WriteNewsletterText

        /// <summary>Writes the webmaster telephone number</summary>
        static public bool WriteTelephoneWebmaster(string i_webmaster_telephone, out string o_error)
        {
            o_error = @"";

            bool ret_check = AdminUtils.CheckTelephone(i_webmaster_telephone, out o_error);
            if (!ret_check)
                return false;

            JazzXml.SetTelephoneWebmaster(i_webmaster_telephone.Trim());

            return true;
        } // WriteTelephoneWebmaster

        /// <summary>Writes the webmaster email address</summary>
        static public bool WriteEmailWebmaster(string i_webmaster_email, out string o_error)
        {
            o_error = @"";

            JazzXml.SetEmailWebmaster(i_webmaster_email);

            return true;
        } // WriteEmailWebmaster

        #endregion // Write text functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetContactsHeader()); }

        /// <summary>Returns the postal address title</summary>
        static public string GetTitleMailHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMailHeader()); }

        /// <summary>Returns the email address title</summary>
        static public string GetTitleEmailHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetEmailHeader()); }

        /// <summary>Returns the reservation title</summary>
        static public string GetTitleReservationHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetReservationHeader()); }

        /// <summary>Returns the newsletter title</summary>
        static public string GetTitleNewsletterHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsletterHeader()); }

        /// <summary>Returns the support title</summary>
        static public string GetTitleWebmasterHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetWebmasterHeader()); }

        /// <summary>Returns the club name title</summary>
        static public string GetTitleClubName() { return JazzAppAdminSettings.Default.GuiTextClubName; }

        /// <summary>Returns the reservation subject title</summary>
        static public string GetTitleReservationSubject() { return JazzAppAdminSettings.Default.GuiTextReservationSubject; }

        /// <summary>Returns the reservation text title</summary>
        static public string GetTitleReservationText() { return JazzAppAdminSettings.Default.GuiTextReservationText; }

        /// <summary>Returns the newsletter subject title</summary>
        static public string GetTitleNewsletterSubject() { return JazzAppAdminSettings.Default.GuiTextNewsletterSubject; }

        /// <summary>Returns the newsletter text title</summary>
        static public string GetTitleNewsletterText() { return JazzAppAdminSettings.Default.GuiTextNewsletterText; }

        /// <summary>Returns the webmaster telephone title</summary>
        static public string GetTitleTelephoneWebmaster() { return JazzAppAdminSettings.Default.GuiTextTelephoneWebmaster; }

        /// <summary>Returns the webmaster email title</summary>
        static public string GetTitleWebmasterEmail() { return JazzAppAdminSettings.Default.GuiTextEmailWebmaster; }


        #endregion // Get title and caps functions

        #region Get text functions

        /// <summary>Returns the name of the  jazz club</summary>
        static public string GetClubName() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetClubName()); }

        /// <summary>Returns the postal address</summary>
        static public string GetMailAddress() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMailAddress()); }

        /// <summary>Returns the email address</summary>
        static public string GetEmailJazzLiveAarau() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetEmailAddress()); }

        /// <summary>Returns the reservation email address</summary>
        static public string GetEmailReservation() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetEmailReservation()); }

        /// <summary>Returns the reservation email subject</summary>
        static public string GetReservationSubject() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetReservationSubject()); }

        /// <summary>Returns the reservation email text</summary>
        static public string GetReservationText() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetReservationText()); }

        /// <summary>Returns the newsletter email subject</summary>
        static public string GetNewsletterSubject() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsletterSubject()); }

        /// <summary>Returns the newsletter email text</summary>
        static public string GetNewsletterText() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsletterText()); }

        /// <summary>Returns the support telephone number</summary>
        static public string GetTelephoneWebmaster() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetTelephoneWebmaster()); }

        /// <summary>Returns the support email address</summary>
        static public string GetEmailWebmaster() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetEmailWebmaster()); }

        #endregion // Get text functions

    } // Contact
} // namespace
