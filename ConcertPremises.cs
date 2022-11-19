using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Concert premises (form) variables and functions</summary>
    public static class ConcertPremises
    {
        #region Concert number

        /// <summary>Concert number</summary>
        static private int m_concert = -12345;

        /// <summary>Set concert number</summary>
        static public void SetConcertNumber(int i_concert) { m_concert = i_concert; }

        #endregion // Concert number

        #region Write text functions

        /// <summary>Writes the name of the premises</summary>
        static public bool WritePlace(string i_place, out string o_error)
        {
            o_error = @"";

            JazzXml.SetPlace(m_concert, i_place);

            return true;
        } // WritePlace

        /// <summary>Writes the premises street</summary>
        static public bool WriteStreet(string i_street, out string o_error)
        {
            o_error = @"";

            JazzXml.SetStreet(m_concert, i_street);

            return true;
        } // WriteStreet

        /// <summary>Writes the premises street</summary>
        static public bool WriteCity(string i_city, out string o_error)
        {
            o_error = @"";

            JazzXml.SetCity(m_concert, i_city);

            return true;
        } // WriteCity

        #endregion // Write text functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return JazzAppAdminSettings.Default.GuiTextConcertPremises; }

        /// <summary>Returns the concert premises name title</summary>
        static public string GetTitleConcertPremisesName() { return JazzAppAdminSettings.Default.GuiTextConcertPremisesName; }

        /// <summary>Returns the concert premises street title</summary>
        static public string GetTitleConcertPremisesStreet() { return JazzAppAdminSettings.Default.GuiTextConcertPremisesStreet; }

        /// <summary>Returns the concert premises city title</summary>
        static public string GetTitleConcertPremisesCity() { return JazzAppAdminSettings.Default.GuiTextConcertPremisesCity; }

        #endregion // Get title and caps functions

        #region Get text functions

        /// <summary>Returns the name of the concert premises</summary>
        static public string GetPlace() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPlace(m_concert)); }

        /// <summary>Returns the concert premises street</summary>
        static public string GetStreet() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetStreet(m_concert)); }

        /// <summary>Returns the concert premises city</summary>
        static public string GetCity() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetCity(m_concert)); }

        #endregion // Get text functions
    } // ConcertPremises
} // namespace
