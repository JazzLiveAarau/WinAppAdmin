using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>About us (form) variables and functions</summary>
    public static class AboutUs
    {
        #region Write text functions

        /// <summary>Writes the header for about us</summary>
        static public bool WriteAboutUsHeader(string i_about_us_header, out string o_error)
        {
            o_error = @"";

            JazzXml.SetAboutUsHeader(i_about_us_header);

            return true;

        } // WriteAboutUsHeader

        /// <summary>Writes the about one text</summary>
        static public bool WriteAboutUsOne(string i_about_us_one, out string o_error)
        {
            o_error = @"";

            JazzXml.SetAboutUsOne(i_about_us_one);

            return true;

        } // WriteAboutUsOne

        /// <summary>Writes the about two text</summary>
        static public bool WriteAboutUsTwo(string i_about_us_two, out string o_error)
        {
            o_error = @"";

            JazzXml.SetAboutUsTwo(i_about_us_two);

            return true;

        } // WriteAboutUsTwo

        /// <summary>Writes the about three text</summary>
        static public bool WriteAboutUsThree(string i_about_us_three, out string o_error)
        {
            o_error = @"";

            JazzXml.SetAboutUsThree(i_about_us_three);

            return true;

        } // WriteAboutUsThree


        #endregion // Write text functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetAboutUsHeader()); }

        /// <summary>Returns the about us title</summary>
        static public string GetTitleAboutUsHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetAboutUsHeader()); }

        /// <summary>Returns the about us one text title</summary>
        static public string GetTitleAboutUsOne() { return JazzAppAdminSettings.Default.GuiTextAboutUsOne; }

        /// <summary>Returns the about us two text title</summary>
        static public string GetTitleAboutUsTwo() { return JazzAppAdminSettings.Default.GuiTextAboutUsTwo; }

        /// <summary>Returns the about us three text title</summary>
        static public string GetTitleAboutUsThree() { return JazzAppAdminSettings.Default.GuiTextAboutUsThree; }

        #endregion // Get title and caps functions

        #region Get text functions

        /// <summary>Returns the about us header</summary>
        static public string GetAboutUsHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetAboutUsHeader()); }

        /// <summary>Returns the about one text</summary>
        static public string GetAboutUsOne() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetAboutUsOne()); }

        /// <summary>Returns the about two text</summary>
        static public string GetAboutUsTwo() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetAboutUsTwo()); }

        /// <summary>Returns the about three text</summary>
        static public string GetAboutUsThree() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetAboutUsThree()); }

        #endregion // Get text functions

    } // AboutUs
} // namespace
