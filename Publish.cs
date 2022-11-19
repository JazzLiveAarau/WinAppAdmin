using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Publish (form) variables and functions</summary>
    static public class Publish
    {
        #region Write text functions

        /// <summary>Writes publish program flag</summary>
        static public bool WritePublishProgram(bool i_publish_program, out string o_error)
        {
            o_error = @"";

            JazzXml.SetPublishProgram(i_publish_program);

            return true;

        } // WritePublishProgram

        /// <summary>Writes autumn year</summary>
        static public bool WriteYearAutum(string i_year_autumn, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckYear(i_year_autumn, out o_error))
                return false;

            JazzXml.SetYearAutum(i_year_autumn.Trim());

            return true;

        } // WriteYearAutum

        /// <summary>Writes autumn year</summary>
        static public bool WriteYearSpring(string i_year_spring, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckYear(i_year_spring, out o_error))
                return false;

            JazzXml.SetYearSpring(i_year_spring.Trim());

            return true;

        } // WriteYearSpring


        /// <summary>Writes the publish season start year that defines the current (this year script) season on the website</summary>
        static public bool WritePublishSeasonStartYear(bool i_website_current_season, out string o_error)
        {
            o_error = @"";

            int publish_season_start_year = JazzXml.GetPublishSeasonStartYearInt();
            if (publish_season_start_year < 0)
                return false; // Programming error

            int year_autumn = JazzXml.GetYearAutumnInt();
            if (year_autumn < 0)
                return false; // Programming error

            if (TimeUtil.PassedYear(year_autumn+1))
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgPublishSeasonStartYearIsPassed;
                return false;
            }

            if (!i_website_current_season)
            {
                if (publish_season_start_year == year_autumn)
                {
                    o_error = JazzAppAdminSettings.Default.ErrMsgPublishSeasonStartYearSetOtherSeason;
                    return false;
                }

                return true;
            }

            if (!GetPublishProgram())
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgPublishSeasonStartYearNotPublished;
                return false;
            }

            if (!JazzXml.NextSeasonExists(year_autumn))
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgPublishSeasonStartYearNextSeasonNotDefined + 
                    (year_autumn+1).ToString() + "-" + (year_autumn + 2).ToString();
                return false;
            }

            JazzXml.SetPublishSeasonStartYear(year_autumn.ToString());

            AdminUtils.SetApplicationDocumentChangeFlag(true);

            return true;

        } // WritePublishSeasonStartYear

        #endregion // Write text functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return JazzAppAdminSettings.Default.GuiTextPublish; }

        /// <summary>Returns the publish program title</summary>
        static public string GetTitlePublishProgram() { return JazzAppAdminSettings.Default.GuiTextPublishProgram; }

        /// <summary>Returns the year autumn title</summary>
        static public string GetTitleYearAutumn() { return JazzAppAdminSettings.Default.GuiTextYearAutumn; }

        /// <summary>Returns the year spring title</summary>
        static public string GetTitleYearSpring() { return JazzAppAdminSettings.Default.GuiTextYearSpring; }

        /// <summary>Returns the publish season start year title</summary>
        static public string GetTitlePublishSeasonStartYear() { return JazzAppAdminSettings.Default.GuiTextPublishSeasonStartYear; }


        #endregion // Get title and caps functions

        #region Get text functions

        /// <summary>Returns true if the season program can be published</summary>
        static public bool GetPublishProgram() { return JazzXml.GetPublishProgramBool(); }

        /// <summary>Returns the autumn year</summary>
        static public string GetYearAutum() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetYearAutum()); }

        /// <summary>Returns the spring year</summary>
        static public string GetYearSpring() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetYearSpring()); }

        /// <summary>Returns true if this season is the current (this year) season on the website</summary>
        static public bool GetPublishSeasonStartYear()
        {
            int publish_season_start_year = JazzXml.GetPublishSeasonStartYearInt();
            if (publish_season_start_year < 0)
                return false; // Programming error

            int year_autumn = JazzXml.GetYearAutumnInt();
            if (year_autumn < 0)
                return false; // Programming error

            if (publish_season_start_year == year_autumn)
            {
                return true;
            }
            else
            {
                return false;
            }

        } // GetPublishSeasonStartYear

        #endregion // Get text functions

    } // Publish
} // namespace
