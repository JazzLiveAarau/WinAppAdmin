using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Concert premises (form) variables and functions</summary>
    public static class Premises
    {
        #region Write text functions

        /// <summary>Writes the header for the premises</summary>
        static public bool WritePremisesHeader(string i_premises_header, out string o_error)
        {
            o_error = @"";

            JazzXml.SetPremisesHeader(i_premises_header);

            return true;
        } // WritePremisesHeader

        /// <summary>Writes the name of the premises</summary>
        static public bool WritePremises(string i_premises, out string o_error)
        {
            o_error = @"";

            JazzXml.SetPremises(i_premises);

            return true;
        } // WritePremises

        /// <summary>Writes the premises street</summary>
        static public bool WritePremisesStreet(string i_street, out string o_error)
        {
            o_error = @"";

            JazzXml.SetPremisesStreet(i_street);

            return true;
        } // WritePremisesStreet

        /// <summary>Writes the premises city</summary>
        static public bool WritePremisesCity(string i_city, out string o_error)
        {
            o_error = @"";

            JazzXml.SetPremisesCity(i_city);

            return true;
        } // WritePremisesCity

        /// <summary>Writes the premises website</summary>
        static public bool WritePremisesWebsite(string i_website, out string o_error)
        {
            o_error = @"";

            JazzXml.SetPremisesWebsite(i_website);

            return true;
        } // WritePremisesWebsite

        /// <summary>Writes the premises telephone</summary>
        static public bool WritePremisesTelephone(string i_telephone, out string o_error)
        {
            o_error = @"";

            bool ret_check = AdminUtils.CheckTelephone(i_telephone, out o_error);
            if (!ret_check)
                return false;

            JazzXml.SetPremisesTelephone(i_telephone.Trim());

            return true;
        } // WritePremisesTelephone

        /// <summary>Writes the premises photo</summary>
        static public bool WritePremisesPhoto(string i_photo_url, out string o_error)
        {
            o_error = @"";
            // Web URL is removed. Please refer to GetPremisesPhoto()

            return true;
        } // WritePremisesPhoto

        /// <summary>Writes the premises map</summary>
        static public bool WritePremisesMap(string i_map_url, out string o_error)
        {
            o_error = @"";
            // Web URL is removed. Please refer to GetPremisesMap()

            return true;
        } // WritePremisesMap

        #endregion // Write text functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPremisesHeader()); }

        /// <summary>Returns the premises name title</summary>
        static public string GetTitlePremisesHeader() { return JazzAppAdminSettings.Default.GuiTextPremisesHeader; }

        #endregion // Get title and caps functions

        #region Get text functions

        /// <summary>Returns the premises street</summary>
        static public string GetPremisesHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPremisesHeader()); }

        /// <summary>Returns the name of the  premises</summary>
        static public string GetPremises() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPremises()); }

        /// <summary>Returns the premises street</summary>
        static public string GetPremisesStreet() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPremisesStreet()); }

        /// <summary>Returns the premises city</summary>
        static public string GetPremisesCity() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPremisesCity()); }

        /// <summary>Returns the premises website</summary>
        static public string GetPremisesWebsite() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPremisesWebsite()); }

        /// <summary>Returns the premises telephone</summary>
        static public string GetPremisesTelephone() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPremisesTelephone()); }

        /// <summary>Returns the premises photo
        /// <para>The function GetPremisesPhoto adds the web site URL. In the XML file there is only the subdirectory and file name</para>
        /// <para>This is a special thing that breaks the pattern. It would be better to take that away. TODO</para>
        /// <para>Temporary solution here is to take the website URL away with function GetWebSiteUrl</para>
        /// </summary>
        static public string GetPremisesPhoto()
        {
            string ret_url = AdminUtils.RemoveXmlUndefinedValue(AdminUtils.RemoveWebsiteUrl(JazzXml.GetPremisesPhoto()));

            return ret_url;
        } // GetPremisesPhoto

        /// <summary>Returns the premises map
        /// <para>The function GetPremisesMap adds the web site URL. In the XML file there is only the subdirectory and file name</para>
        /// <para>This is a special thing that breaks the pattern. It would be better to take that away. TODO</para>
        /// <para>Temporary solution here is to take the website URL away with function GetWebSiteUrl</para>
        /// </summary>
        static public string GetPremisesMap()
        {
            string ret_url = AdminUtils.RemoveXmlUndefinedValue(AdminUtils.RemoveWebsiteUrl(JazzXml.GetPremisesMap()));

            return ret_url;
        } // GetPremisesMap

        #endregion // Get text functions

    } // Premises

} // namespace
