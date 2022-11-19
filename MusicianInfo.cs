using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Publish (form) variables and functions</summary>
    static public class MusicianInfo
    {
        #region Write text functions

        /// <summary>Writes concert contact member number</summary>
        static public bool WriteContactComboBox(string i_member_string, out string o_error)
        {
            o_error = @"";

            string member_number = AdminUtils.ConcertContactPersonNumberAsString(i_member_string); 

            if (JazzXml.ValidNumber(member_number) < 0)
            {
                o_error = @"MusicianInfo.WriteContactConcertMemberNumber Programming error concert contact person number";
                return false;
            }

            JazzXml.SetContactConcertMemberNumber(member_number.Trim());

            return true;

        } // WriteContactConcertMemberNumber

        /// <summary>Writes concert contact telephone number</summary>
        static public bool WriteContactConcertTelephone(string i_telephone_number, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckTelephone(i_telephone_number, out o_error))
                return false;

            JazzXml.SetContactConcertTelephone(i_telephone_number.Trim());

            return true;

        } // WriteContactConcertTelephone

        /// <summary>Writes concert contact email address</summary>
        static public bool WriteContactConcertEmail(string i_email, out string o_error)
        {
            o_error = @"";

            JazzXml.SetContactConcertEmail(i_email.Trim());

            return true;

        } // WriteContactConcertEmail

        /// <summary>Writes unload street</summary>
        static public bool WriteUnloadStreet(string i_unload_street, out string o_error)
        {
            o_error = @"";

            JazzXml.SetUnloadStreet(i_unload_street.Trim());

            return true;

        } // WriteUnloadStreet

        /// <summary>Writes unload city</summary>
        static public bool WriteUnloadCity(string i_unload_city, out string o_error)
        {
            o_error = @"";

            JazzXml.SetUnloadCity(i_unload_city.Trim());

            return true;

        } // WriteUnloadCity

        /// <summary>Writes parking one</summary>
        static public bool WriteParkingOne(string i_parking_one, out string o_error)
        {
            o_error = @"";

            JazzXml.SetParkingOne(i_parking_one.Trim());

            return true;

        } // WriteParkingOne

        /// <summary>Writes parking two</summary>
        static public bool WriteParkingTwo(string i_parking_two, out string o_error)
        {
            o_error = @"";

            JazzXml.SetParkingTwo(i_parking_two.Trim());

            return true;

        } // WriteParkingTwo

        #endregion // Write text functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetCaptionMusicianInfo()); }

        /// <summary>Returns the contact person title</summary>
        static public string GetTitleConcertContactMember() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetCaptionContactPersonConcert()); }

        /// <summary>Returns the unload street title</summary>
        static public string GetTitleUnloadStreet() { return JazzAppAdminSettings.Default.GuiTextUnloadStreet; }

        /// <summary>Returns the unload city title</summary>
        static public string GetTitleUnloadCity() { return JazzAppAdminSettings.Default.GuiTextUnloadCity; }

        /// <summary>Returns the parking one title</summary>
        static public string GetTitleParkingOne() { return JazzAppAdminSettings.Default.GuiTextParkingOne; }

        /// <summary>Returns the parking two title</summary>
        static public string GetTitleParkingTwo() { return JazzAppAdminSettings.Default.GuiTextParkingTwo; }

        #endregion // Get title and caps functions

        #region Get text functions

        /// <summary>Returns the unload street</summary>
        static public string GetUnloadStreet() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetUnloadStreet()); }

        /// <summary>Returns the unload city</summary>
        static public string GetUnloadCity() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetUnloadCity()); }

        /// <summary>Returns parking one</summary>
        static public string GetParkingOne() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetParkingOne()); }

        /// <summary>Returns parking two</summary>
        static public string GetParkingTwo() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetParkingTwo()); }

        #endregion // Get text functions

 

    } // MusicianInfo

} // namespace
