using JazzApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Index (form) variables and functions</summary>
    public static class Index
    {
        #region Add and set season program

        /// <summary>Set current season corresponding to the selected JazzProgramm_20nn_20mm.xml file
        /// <para>1. If input season string is 'Add season', call of AddNewSeasonProgramXmlFileOnServer</para>
        /// <para>2. Get all available season strings (Saison 20xx-20yy). Call of JazzXml.GetAvailableSeasons</para>
        /// <para>3. Get index for the input season string. Call of AdminUtils.GetIndexSelectedItem</para>
        /// <para>4. Get all XDocument objects corresponding to the JazzProgramm_20nn_20mm.xml files. Call of JazzXml.GetSeasonDocuments</para>
        /// <para>5. Set current active XDocument object. Call of JazzXml.SetDocumentCurrent</para>
        /// <para>6. Set the URL to the JazzProgramm_20nn_20mm.xml file corresponding to the current active XDocument object. Call of JazzXml.SetCurrentSeasonFileUrl</para>
        /// </summary>
        /// <param name="i_season">Season string, e.g. Saison 2017-2018 or Add season</param>
        /// <param name="o_season_added">Flag telling if a season was added (if adding was succesfull)</param>
        /// <param name="o_error">Error description</param>
        public static bool SetCurrentSeason(string i_season, out bool o_season_added,  out string o_error)
        {
            o_error = @"";
            o_season_added = false;

            if (i_season.Trim().Length == 0)
                return false;

            string selected_season = i_season;

            if (i_season.Equals(AdminUtils.GetAddSeasonString()))
            {
                if (!AdminUtils.NewSeasonProgramCanBeAdded())
                {
                    o_error = @"Index.SetCurrentSeason Not possible to add a season program. Maximum number will be exceeded ";

                    return false;
                }

                int autumn_start_year = -12345;

                string error_add = @"";

                //QQ 2021-01-24 if (!AddSeason(out autumn_start_year, out error_add))
                if (!AddNewSeasonProgramXmlFileOnServer(out autumn_start_year, out error_add))
                {
                    o_error = @"Index.SetCurrentSeason " + error_add;

                    return false;
                }

                selected_season = JazzUtils.SeasonName(autumn_start_year);

                JazzXml.InitXmlAllSeasons();

                string error_init_admin = @"";
                if (!JazzXml.InitAdmin(out error_init_admin))
                {
                    o_error = @"Index.SetCurrentSeason " + error_init_admin;

                    return false;
                }

                o_season_added = true;
            }

            if (!AdminUtils.SetCurrentSeason(selected_season, out o_error))
            {
                o_error = @"Index.SetCurrentSeason AdminUtils.SetCurrentSeason failed " + o_error;

                return false;
            }

            return true;

        } // SetCurrentSeason

        /// <summary>Returns true if the user may change the season. It is not allowed if the user has checked out a season program.
        /// For this case the user must first save the checked ou season program.
        /// <para>1. Determine if a season XML file has been checked out. Call of JazzLoginLogout.LoginLogout.DataCheckedOut</para>
        /// <para>2. Return true if not checked out.</para>
        /// <para>3. Get current season. Call of JazzXml functions GetYearAutum, GetYearSpring and GetAvailableSeasons</para>
        /// <para>2. Return true if selected season is equal to current season.</para>
        /// <para>3. Display error message. Call of MessageBox</para>
        /// <para>4. Return false</para>
        /// An alternative solution would be to disable the season selection combobox when the user checks out
        /// If user makes the checkout in the IndexForm this is also what happens, but normally the user
        /// checks out in a "subform" like for instance MusicianForm
        /// </summary>
        /// <param name="i_selected_season">Selected season</param>
        /// <param name="o_current_season">Current season</param>
        /// <param name="o_error">Error description</param>
        public static bool ChangeOfSeasonIsAllowed(string i_selected_season, out string o_current_season, out string o_error)
        {
            o_error = @"";
            o_current_season = @"";

            bool b_data_checked_out = JazzLoginLogout.LoginLogout.DataCheckedOut;

            if (!b_data_checked_out)
            {
                return true;
            }

            string autumn_year = JazzXml.GetYearAutum();
            string spring_year = JazzXml.GetYearSpring();

            string[] season_strings = JazzXml.GetAvailableSeasons(JazzUtils.GetMemberLogin());
            for (int index_season=0; index_season< season_strings.Length; index_season++)
            {
                string current_season = season_strings[index_season];

                if (current_season.Contains(autumn_year) && current_season.Contains(spring_year))
                {
                    o_current_season = current_season;
                    break;
                }
            }

            if (i_selected_season.Equals(o_current_season))
            {
                return true;
            }

            MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgSaveXmlBeforeChangeOfSeason);

            return false;

        } // ChangeOfSeasonIsAllowed

        /*QQQQQQQQQQQQQQQQQQQQQ  2021-01-23
        /// <summary>Add season
        /// <para>1. Add a season XML file to directory XML. Call of AddSeasonProgram</para>
        /// </summary>
        /// <param name="o_year_autumn">Output: Start year for the new season program</param>
        /// <param name="o_error">Error description</param>
        private static bool AddSeason(out int o_year_autumn, out string o_error)
        {
            o_error = @"";

            if (!AddSeasonProgram(out o_year_autumn, out o_error))
            {
                return false;
            }

            return true;

        } // AddSeason


        /// <summary>Add an additional season program for a new season
        /// <para>Please note that an additional XML only must be added to the XML directory. Any "registration" is not necessary.</para>
        /// <para>If an XML element must be added (e.g. AdditionalTextHeader) the template JazzProgramm_template.xml must be changed and uploaded.</para>
        /// <para>The JazzProgramm_template.xml is in source code directory. Existing XML season files must of course also be updated.</para>
        /// <para>1. The XML template for a season program is downloaded. Call of DownLoad.DownloadXmlTemplates</para>
        /// <para>2. Set an array with now existing season XML objects. Call of  JazzXml.GetSeasonDocuments</para>
        /// <para>3. Set the last XML object in the array as the current (active) object. Call of JazzXml.SetCurrentSeasonDocument</para>
        /// <para>4. Determine the start year from the current autumn year (+1). Call of JazzXml.GetYearAutumnInt()</para>
        /// <para>5. Construct the output XML file with path. Call of JazzXml.GetSeasonLocalFileName</para>
        /// <para>6. Upload the new XML season program file. Call of Upload.OneFile</para>
        /// </summary>
        /// <param name="o_year_autumn">Output: Start year for the new season program</param>
        /// <param name="o_error">Error description</param>
        private static bool AddSeasonProgram(out int o_year_autumn, out string o_error)
        {
            o_year_autumn = 1;
            o_error = @"";

            DownLoad down_load = new DownLoad();
            string error_message = "";

            if (!down_load.DownloadXmlTemplates(out error_message))
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgXmlTemplatesDownload;
                return false;
            }

            XDocument[] season_documents = JazzXml.GetSeasonDocuments();
            if (null == season_documents)
            {
                o_error = @"Index.AddSeasonProgram Programming error: Getting season programs failed";
                return false;
            }

            int index_last_season = season_documents.Length - 1;
            if (index_last_season < 0)
            {
                o_error = @"Index.AddSeasonProgram Programming error: index negative";
                return false;
            }

            JazzXml.SetCurrentSeasonDocument(season_documents[index_last_season]);

            int autumn_year_add = JazzXml.GetYearAutumnInt() + 1;
            int spring_year_add = JazzXml.GetYearSpringInt() + 1;

            o_year_autumn = autumn_year_add;

            string local_address_directory = FileUtil.SubDirectory(JazzAppAdminSettings.Default.DirXmlTemplates, Main.m_exe_directory);

            string file_name_add_with_path = local_address_directory + @"\" + JazzAppAdminSettings.Default.FileXmlTemplateSeasonProgram;

            string file_name_add = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetSeasonLocalFileName(autumn_year_add));
            string directory_url = @"www\" + JazzAppAdminSettings.Default.XmlExistingDir + @"\";
            string file_server_url = directory_url + file_name_add;

            UpLoad htpp_upload = new UpLoad();

            bool to_www = true;
            if (!htpp_upload.OneFile(to_www, file_server_url, file_name_add_with_path, out o_error))
            {
                o_error = "Index.AddSeasonProgram Upload.OneFile failed: " + o_error;
                return false;
            }

            return true;

        } // AddSeasonProgram

        QQQQQQQQQQQQQQQ  2021-01-23 */

        #endregion // Add and set season program

        #region Add an additional XML season program file

        /// <summary>Create a new season program XML file
        /// <para>1. Get autumn year for the next season. Call of GetYearAutumnForNewConcertSeason</para>
        /// <para>2. Get concert dates where all concerts are on a Saturday. Call of GetSaturdaySeasonConcertDates</para>
        /// <para>3. Create a (start) season concert XML object. </para>
        /// <para>4. Loop for all concerts</para>
        /// <para>4.1 Get JazzConcert object. Call of JazzSeason.GetJazzConcert</para>
        /// <para>4.2 Set premises, address, concert date and time, day name and musician login password</para>
        /// <para>5. Set empty strings to NotYetSetNodeValue. Call of JazzSeason.SetToValuesNotYetSetForEmptyStrings</para>
        /// <para>6. Create season program XML object. Call of JazzXml.SeasonProgramXml</para>
        /// <para>7. Construct the name for the output XML file and local directory. 
        /// Call of JazzXml.GetSeasonLocalFileName and FileUtil.SubDirectory</para>
        /// <para>8. Create the local concert season XML file. Call of XDocument.Save</para>
        /// <para>9. Upload of file to server directory XML. Call of JazzFtp.Input and JazzFtp.Execute</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static bool AddNewSeasonProgramXmlFileOnServer(out int o_year_autumn, out string o_error)
        {
            o_error = @"";

            string error_msg = @"";

            o_year_autumn = GetYearAutumnForNewConcertSeason();

            int n_concerts = -12345;

            int[,] concert_dates = GetSaturdaySeasonConcertDates(o_year_autumn, out n_concerts, out error_msg);
            if (concert_dates == null)
            {
                o_error = @"Index.AddNewSeasonProgramXmlFileOnServer GetSaturdaySeasonConcertDates failed " + error_msg;

                return false;
            }

            string season_comment = @"  JAZZ live AARAU Saisonprogramm " + o_year_autumn.ToString() + "-" + (o_year_autumn + 1).ToString();

            JazzSeason jazz_season = new JazzSeason(o_year_autumn, season_comment, n_concerts);
            if (null == jazz_season)
            {
                o_error = @"Index.AddNewSeasonProgramXmlFileOnServer Creation of a JazzSeason object failed ";

                return false;
            }

            for (int concert_number = 1; concert_number <= n_concerts; concert_number++)
            {
                JazzConcert jazz_concert = jazz_season.GetJazzConcert(concert_number, out error_msg);
                if (null == jazz_concert)
                {
                    o_error = @"Index.AddNewSeasonProgramXmlFileOnServer JazzSeason.GetJazzConcert failed for concert_number= " + concert_number.ToString() + @" " + error_msg;

                    return false;
                }
                 
                jazz_concert.ConcertPlace = JazzXml.GetPremises();

                jazz_concert.ConcertStreet = JazzXml.GetPremisesStreet();

                jazz_concert.ConcertCity = JazzXml.GetPremisesCity();

                jazz_concert.ConcertBandName = @"Band " + concert_number.ToString();

                jazz_concert.ConcertYearInt = concert_dates[concert_number - 1, 0];

                jazz_concert.ConcertMonthInt = concert_dates[concert_number - 1, 1];

                jazz_concert.ConcertDayInt = concert_dates[concert_number - 1, 2];

                jazz_concert.ConcertDayName = TimeUtil.DayName(jazz_concert.ConcertYearInt, jazz_concert.ConcertMonthInt, jazz_concert.ConcertDayInt);

                jazz_concert.ConcertTimeStartHourInt = 15;

                jazz_concert.ConcertTimeStartMinuteInt = 30;

                jazz_concert.ConcertTimeEndHourInt = 17;

                jazz_concert.ConcertTimeEndMinuteInt = 15;

                jazz_concert.ConcertLoginPassword = @"musiker";
            }

            if (!jazz_season.CheckParameterValues(out error_msg))
            {
                o_error = @"Index.AddNewSeasonProgramXmlFileOnServer JazzSeason.CheckParameterValues failed " + error_msg;

                return false;
            }

            jazz_season.SetToValuesNotYetSetForEmptyStrings(out error_msg);
            if (error_msg.Length > 0)
            {
                o_error = @"Index.AddNewSeasonProgramXmlFileOnServer JazzSeason.SetToValuesNotYetSetForEmptyStrings failed " + error_msg;

                return false;
            }

            XDocument season_program_xml = JazzXml.SeasonProgramXml(jazz_season);

            if (null == season_program_xml)
            {
                o_error = @"Index.AddNewSeasonProgramXmlFileOnServer Failure creating season program XML";

                return false;
            }

            string file_name_str = JazzXml.GetSeasonLocalFileName(o_year_autumn);

            string local_sub_dir = FileUtil.SubDirectory("XML", Main.m_exe_directory);

            string file_name_path = Path.Combine(local_sub_dir, file_name_str);

            season_program_xml.Save(file_name_path);

            string upload_server_dir = "www/XML";

            JazzFtp.Input ftp_input_upload = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.UpLoadFile);

            ftp_input_upload.ServerDirectory = upload_server_dir;

            ftp_input_upload.ServerFileName = file_name_str;

            ftp_input_upload.LocalDirectory = @"XML";

            ftp_input_upload.LocalFileName = file_name_str;

            JazzFtp.Result ftp_result_htm = JazzFtp.Execute.Run(ftp_input_upload);

            if (!ftp_result_htm.Status)
            {
                o_error = @"Index.AddNewSeasonProgramXmlFileOnServer JazzFtp.Execute.Run failed " + ftp_result_htm.ErrorMsg;

                return false;
            }

            return true;

        } // AddNewSeasonProgramXmlFileOnServer

        /// <summary>Returns the autumn (start) year for a new season
        /// <para>1. Get all season start years. Call of JazzXml.GetSeasonsStartYears</para>
        /// <para>2. Return the last start year (last element value) and add one (1)</para>
        /// </summary>
        static private int GetYearAutumnForNewConcertSeason() 
        {
            int ret_year = -12345;

            int[] season_start_years = JazzXml.GetSeasonsStartYears();

            int n_start_years = season_start_years.Length;

            ret_year = season_start_years[n_start_years - 1] + 1;

            return ret_year;

        } // GetYearAutumnForNewConcertSeason

        /// <summary>Returns the saturday concert dates for a season
        /// <para>1. Get number of concerts for the current season. Call of JazzXml.GetNumberConcertsInCurrentDocument</para>
        /// <para>2. Create (instantiate) the return array. Dimension n_concerts,3</para>
        /// <para>3. Calculate the number of years that shall be added to the current season start year</para>
        /// <para>4. Loop for all concerts of the current (active)season</para>
        /// <para>4.1 Get concert year, month and day. Call of JazzXml.GetYearInt, JazzXml.GetMonthInt and JazzXml.GetDayInt</para>
        /// <para>4.2 Get the sunday concert date for the output year. Call of TimeUtil.GetClosestSaturdayDate</para>
        /// <para>4.3 Set the output array element</para>
        /// </summary>
        /// <param name="i_year_autumn">Output: Start year for the new season program</param>
        /// <param name="o_n_concerts">Number of concerts (for the current season)</param>
        /// <param name="o_error">Error description</param>
        /// <returns>Array with concert dates. Concert is always on a saturday</returns>
        private static int[,] GetSaturdaySeasonConcertDates(int i_year_autumn, out int o_n_concerts, out string o_error)
        {
            o_error = @"";

            o_n_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

            int[,] ret_dates = new int[o_n_concerts, 3];

            int year_autumn = JazzXml.GetYearAutumnInt();

            int concert_year_add = i_year_autumn - year_autumn;

            if (concert_year_add <= 0)
            {
                o_error = @"GetSaturdaySeasonConcertDates concert_year_add= " + concert_year_add.ToString() + @" <= 0";

                return null;
            }

            for (int concert_number = 1; concert_number <= o_n_concerts; concert_number++)
            {
                int concert_year = JazzXml.GetYearInt(concert_number);

                int concert_month = JazzXml.GetMonthInt(concert_number);

                int concert_day = JazzXml.GetDayInt(concert_number);

                int out_concert_year = -12345;

                int out_concert_month = -12345;

                int out_concert_day = -12345;

                TimeUtil.GetClosestSaturdayDate(concert_year + concert_year_add, concert_month, concert_day, 
                        out out_concert_year, out out_concert_month, out out_concert_day);

                ret_dates[concert_number - 1, 0] = out_concert_year;

                ret_dates[concert_number - 1, 1] = out_concert_month;

                ret_dates[concert_number - 1, 2] = out_concert_day;


            } // concert_number


            return ret_dates;

        } // GetSaturdaySeasonConcertDates

        #endregion // Add an additional XML season program file

        #region Add and set member

        /// <summary>Set current member</summary>
        public static bool SetCurrentMember(string i_member, out bool o_member_added, out string o_error)
        {
            o_member_added = false;
            o_error = @"";

            if (i_member.Trim().Length == 0)
            {
                o_error = @"AdminUtils.SetCurrentMember Programming error: Member string is empty";
                return false;
            }

            string member_name = i_member;

            if (i_member.Equals(AdminUtils.GetAddMemberString()))
            {
                if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
                {
                    o_error = JazzAppAdminSettings.Default.ErrMsgCheckoutBeforeAddingMember;
                    return false;
                }

                string added_member_first_name = JazzAppAdminSettings.Default.AddedMemberFirstName;
                string added_member_family_name = JazzAppAdminSettings.Default.AddedMemberFamilyName;

                AddMember(added_member_first_name, added_member_family_name);
               
                member_name = added_member_first_name + @" " + added_member_family_name; 

                o_member_added = true;

            } // Add member

            string[] members_strings = JazzXml.GetMembersAsStrings();

            int index_selected_member = AdminUtils.GetIndexSelectedItem(members_strings, member_name);
            if (index_selected_member < 0)
            {
                o_error = @"AdminUtils.SetCurrentMember Programming error: Failed finding current member index";
                return false;
            }

            AdminUtils.SetCurrentMemberNumber(index_selected_member + 1);

            return true;
        } // SetCurrentMember


        /// <summary>Add member</summary>
        private static void AddMember(string i_member_name, string i_added_member_family_name)
        {
            if (i_member_name.Trim().Length == 0)
                return;

            JazzXml.AddMemberNode(i_member_name, i_added_member_family_name);

        } // AddMember


        #endregion // Add and set member

        #region Add and set concert

        /// <summary>Set current concert</summary>
        public static bool SetCurrentConcert(string i_concert, out bool o_concert_added, out string o_error)
        {
            o_concert_added = false;
            o_error = @"";

            if (i_concert.Trim().Length == 0)
            {
                o_error = @"AdminUtils.SetCurrentConcert Programming error: Concert string is empty";
                return false;
            }

            string concert_name = i_concert;

            if (i_concert.Equals(AdminUtils.GetAddConcertString()))
            {
                if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
                {
                    o_error = JazzAppAdminSettings.Default.ErrMsgCheckoutBeforeAddingConcert;
                    return false;
                }

                int n_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

                string warning_msg = JazzAppAdminSettings.Default.MsgReallyChangeNumberOfConcerts + (n_concerts + 1).ToString() + @"?" + "\n" + JazzAppAdminSettings.Default.MsgContinue;

                DialogResult dialog_result = MessageBox.Show(warning_msg, DocAdminString.MsgWarning, MessageBoxButtons.YesNo);

                if (dialog_result == DialogResult.No)
                {
                    o_error = JazzAppAdminSettings.Default.MsgConcertNotAdded;
                    return false;
                }

                string added_concert_name = JazzAppAdminSettings.Default.AddedConcertName;
                string added_musician_name = JazzAppAdminSettings.Default.AddedMusicianName;

                if (!AddConcert(added_concert_name, added_musician_name, out o_error))
                {
                    o_error = @"Index.SetCurrentConcert " + o_error;
                    return false;
                }

                concert_name = added_concert_name;

                o_concert_added = true;

            } // Add concert

            string[] displayed_concerts = AdminUtils.GetConcertStrings();

            int index_selected_concert = AdminUtils.GetIndexSelectedItem(displayed_concerts, concert_name);
            if (index_selected_concert < 0)
            {
                o_error = @"AdminUtils.SetCurrentConcert Programming error: Failed finding current concert index";
                return false;
            }

            AdminUtils.SetCurrentConcertNumber(index_selected_concert + 1);

            return true;
        } // SetCurrentConcert

        /// <summary>Add concert</summary>
        private static bool AddConcert(string i_concert_name, string i_musician_name, out string o_error)
        {
            o_error = @"";

            if (i_concert_name.Trim().Length == 0)
                return false;

            if (!JazzXml.AddConcertNode(i_concert_name, i_musician_name, out o_error))
                return false;

            return true;

        } // AddConcert

        #endregion // Add and set concert

        #region Add and set musician

        /// <summary>Sets the current musician
        /// <para>A musician may also be added. This is however only possible after checkout</para>
        /// </summary>
        /// <param name="i_musician">Musician name</param>
        /// <param name="o_musician_added">Flag telling if a musician has been added</param>
        /// <param name="o_error">Error message. For instance that logout is necessary before adding musician</param>
        public static bool SetCurrentMusician(string i_musician, out bool o_musician_added, out string o_error)
        {

            o_musician_added = false;

            o_error = @"";

            if (i_musician.Trim().Length == 0)
            {
                o_error = @"AdminUtils.SetCurrentMusician Programming error: Musician string is empty";
                return false;
            }

            string musician_name = i_musician;


            if (i_musician.Equals(AdminUtils.GetAddMusicianString()))
            {
                if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
                {
                    o_error = JazzAppAdminSettings.Default.ErrMsgCheckoutBeforeAddingMusician;
                    return false;
                }

                string added_musician_name = JazzAppAdminSettings.Default.AddedMusicianName;

                AddMusician(added_musician_name);

                musician_name = added_musician_name;
                o_musician_added = true;
            }

            string[] musicians_strings = JazzXml.GetMusiciansAsStrings(AdminUtils.GetCurrentConcertNumber());


            int index_selected_musician = AdminUtils.GetIndexSelectedItem(musicians_strings, musician_name);
            if (index_selected_musician < 0)
            {
                o_error = @"AdminUtils.SetCurrentMusician Programming error: Failed finding current musician index";
                return false;
            }

            AdminUtils.SetCurrentMusicianNumber(index_selected_musician + 1);

            return true;

        } // SetCurrentMusician


        /// <summary>Add musician</summary>
        private static void AddMusician(string i_musician_name)
        {
            if (i_musician_name.Trim().Length == 0)
                return;

            JazzXml.AddMusicianNode(AdminUtils.GetCurrentConcertNumber(), i_musician_name);

        } // AddMusician

        #endregion // Add and set musician


        /// <summary>Reset the current XDocument when the user has quit editing
        /// <para>The current XDocument can be a season document and/or the application document</para>
        /// <para>The current XDocument could be reloaded with the data from the corresponding XML file on the server</para>
        /// <para>A more simple solution is however implemented:  All season and the application XDocuments are reloaded</para>
        /// <para>This corresponds to a restart of the application.</para>
        /// <para>The controls should also be reset by the calling (WindowsForm) function</para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        public static bool ResetCurrentXDocumentAfterQuit(out string o_error)
        {
            o_error = @"";

            JazzXml.SetFtpConnectionData(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword, Main.ExeDirectory);

            JazzXml.InitApplicationAndCurrentSeasonXml();
            JazzXml.InitXmlAllSeasons();

            return true;
        } // ResetCurrentXDocumentAfterQuit





    } // Index

} // namespace
