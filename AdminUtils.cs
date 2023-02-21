using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JazzApp;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace JazzAppAdmin
{
    /// <summary>Utility functions for the JazzAppAdmin application</summary>
    public static class AdminUtils
    {
        #region Member parameters holding the current edit document, concert, the current musician and the current member

        /// <summary>Current XDocument that is being edited: A season document or the application document</summary>
        static private XDocument m_current_edit_document = null;

        /// <summary>Current selected season XML file URL. Corresponds to m_current_edit_document except when JazzApplication.xml is edited</summary>
        static private string m_current_selected_xml_file = "";

        /// <summary>Flag telling if the application document has been changed</summary>
        static private bool m_application_document_changed = false;

        /// <summary>Current concert number</summary>
        static private int m_current_concert_number = -12345;

        /// <summary>Current musician number</summary>
        static private int m_current_musician_number = -12345;

        /// <summary>Current member number</summary>
        static private int m_current_member_number = -12345;

        /// <summary>Returns the current XDocument that is beeing edited: A season document or the application document</summary>
        static public XDocument GetCurrentEditDocument() { return m_current_edit_document; }

        /// <summary>Returns the current selected season XML file URL. Corresponds to GetCurrentEditDocument except when JazzApplication.xml is edited</summary>
        static public string GetCurrentSelectedXmlFile() { return m_current_selected_xml_file; }

        /// <summary>Sets the current selected season XML file. Corresponds to GetCurrentEditDocument except when JazzApplication.xml is edited</summary>
        static public void SetCurrentSelectedXmlFile(string i_current_selected_xml_file) { m_current_selected_xml_file = i_current_selected_xml_file; }

        /// <summary>Sets the current XDocument that is beeing edited: A season document or the application document</summary>
        static public void SetCurrentEditDocument(XDocument i_current_edit_document) { m_current_edit_document = i_current_edit_document; }

        /// <summary>Returns the current concert number</summary>
        static public int GetCurrentConcertNumber() { return m_current_concert_number; }

        /// <summary>Sets the current concert number</summary>
        static public void SetCurrentConcertNumber(int i_current_concert_number) { m_current_concert_number = i_current_concert_number; }

        /// <summary>Returns the current musician number</summary>
        static public int GetCurrentMusicianNumber() { return m_current_musician_number; }

        /// <summary>Sets the current musician number</summary>
        static public void SetCurrentMusicianNumber(int i_current_musician_number) { m_current_musician_number = i_current_musician_number; }

        /// <summary>Returns the current member number</summary>
        static public int GetCurrentMemberNumber() { return m_current_member_number; }

        /// <summary>Sets the current member number</summary>
        static public void SetCurrentMemberNumber(int i_current_member_number) { m_current_member_number = i_current_member_number; }

        /// <summary>Returns flag telling if the application document has been changed</summary>
        static public bool GetApplicationDocumentChangeFlag( ) { return m_application_document_changed; }

        /// <summary>Sets flag telling if the application document has been changed</summary>
        static public void SetApplicationDocumentChangeFlag(bool i_application_document_changed) { m_application_document_changed = i_application_document_changed; }

        #endregion // Member parameters holding the current concert, the current musician and the current member

        #region Strings for adding a season, concert, musician and a member
        /// <summary>Add season string</summary>
        private static string m_add_season = @"Saison zufügen";

        /// <summary>returns the add season string</summary>
        public static string GetAddSeasonString() { return m_add_season; }

        /// <summary>Add concert string</summary>
        private static string m_add_concert = @"Konzert zufügen";

        /// <summary>returns the add concert string</summary>
        public static string GetAddConcertString() { return m_add_concert; }

        /// <summary>Add musician string</summary>
        private static string m_add_musician = @"Musiker zufügen";

        /// <summary>returns the add musician string</summary>
        public static string GetAddMusicianString() { return m_add_musician; }

        /// <summary>Add member string</summary>
        private static string m_add_member = @"Mitglied zufügen";

        /// <summary>returns the add member string</summary>
        public static string GetAddMemberString() { return m_add_member; }

        #endregion // Strings for adding a season, concert, musician and a member

        #region Construct directory names

        /// <summary>Modifies a band name so that it can be used as directory name
        /// <para>Escape signs, é, etc are removed. Spaces are replaced by underscore.</para>
        /// <para>Refer also to RequestBand.ModifyFileName</para>
        /// <para></para>
        /// </summary>
        public static string ModifyBandNameForDirectory(string i_band_name)
        {
            string mod_band_name = @"";

            string mod_str_1 = JazzXml.ModifyReadXml(i_band_name);

            string mod_str_2 = @"";
            for (int index_char = 0; index_char < mod_str_1.Length; index_char++)
            {
                string current_char = mod_str_1.Substring(index_char, 1);

                if (current_char.Equals(" "))
                {
                    mod_str_2 = mod_str_2 + "_";
                }
                else if (current_char.Equals("'"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ʻ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ʼ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ʽ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ʾ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ʿ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ˈ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ˊ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ˋ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("’"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("\""))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("/"))
                {
                    mod_str_2 = mod_str_2 + @"_";
                }
                else if (current_char.Equals(":"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals(";"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("â"))
                {
                    mod_str_2 = mod_str_2 + @"a";
                }
                else if (current_char.Equals("á"))
                {
                    mod_str_2 = mod_str_2 + @"a";
                }
                else if (current_char.Equals("ê"))
                {
                    mod_str_2 = mod_str_2 + @"e";
                }
                else if (current_char.Equals("é"))
                {
                    mod_str_2 = mod_str_2 + @"e";
                }
                else if (current_char.Equals("&"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ä"))
                {
                    mod_str_2 = mod_str_2 + @"ae";
                }
                else if (current_char.Equals("ü"))
                {
                    mod_str_2 = mod_str_2 + @"ue";
                }
                else if (current_char.Equals("ö"))
                {
                    mod_str_2 = mod_str_2 + @"oe";
                }
                else if (current_char.Equals("Ä"))
                {
                    mod_str_2 = mod_str_2 + @"Ae";
                }
                else if (current_char.Equals("Ü"))
                {
                    mod_str_2 = mod_str_2 + @"Ue";
                }
                else if (current_char.Equals("Ö"))
                {
                    mod_str_2 = mod_str_2 + @"Oe";
                }
                else if (current_char.Equals("à"))
                {
                    mod_str_2 = mod_str_2 + @"a";
                }
                else if (current_char.Equals("À"))
                {
                    mod_str_2 = mod_str_2 + @"A";
                }
                else if (current_char.Equals("."))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else
                {
                    mod_str_2 = mod_str_2 + current_char;
                }
            }

            mod_band_name = mod_str_2;

            return mod_band_name;

        } // ModifyBandNameForDirectory

        #endregion // Construct directory names

        #region Set active season (JazzProgramm_20nn_20mm.xml)

        /// <summary>Set current season for a given season string 'Saison 20nn-20mm' (corresponding to a JazzProgramm_20nn_20mm.xml file)
        /// <para>1. Get all available season strings (20xx-20yy). Call of JazzXml.GetAvailableSeasons</para>
        /// <para>2. Get index for the input season string. Call of AdminUtils.GetIndexSelectedItem</para>
        /// <para>3. Get all XDocument objects corresponding to the JazzProgramm_20nn_20mm.xml files. Call of JazzXml.GetSeasonDocuments</para>
        /// <para>4. Set current active XDocument object. Call of JazzXml.SetDocumentCurrent</para>
        /// <para>5. Set the URL to the JazzProgramm_20nn_20mm.xml file corresponding to the current active XDocument object. Call of JazzXml.SetCurrentSeasonFileUrl</para>
        /// </summary>
        /// <param name="i_season">Season string, e.g. Saison 2017-2018</param>
        /// <param name="o_error">Error description</param>
        public static bool SetCurrentSeason(string i_season, out string o_error)
        {
            o_error = @"";

            if (i_season.Trim().Length == 0)
                return false;

            string[] season_strings = JazzXml.GetAvailableSeasons(JazzUtils.GetMemberLogin());

            int index_selected_season = AdminUtils.GetIndexSelectedItem(season_strings, i_season);
            if (index_selected_season < 0)
            {
                o_error = @"AdminUtils.SetCurrentSeason Programming error: GetIndexSelectedItem";
                return false;
            }

            XDocument[] season_documents = JazzXml.GetSeasonDocuments();
            if (null == season_documents)
            {
                o_error = @"AdminUtils.SetCurrentSeason Programming error: GetSeasonDocuments";
                return false;
            }
            if (0 == season_documents.Length)
            {
                o_error = @"AdminUtils.SetCurrentSeason Programming error: No documents";
                return false;
            }

            if (index_selected_season >= season_documents.Length)
            {
                o_error = @"AdminUtils.SetCurrentSeason Programming error: index_selected_season";
                return false;
            }

            JazzXml.SetDocumentCurrent(season_documents[index_selected_season]);

            JazzXml.SetCurrentSeasonFileUrl();

            return true;

        } // SetCurrentSeason

        #endregion // Set active season (JazzProgramm_20nn_20mm.xml)

        #region Set and get combo boxes for seasons, concerts, musicians and members

        /// <summary>Set combobox seasons</summary>
        /// <param name="i_combo_box">The season combo box</param>
        /// <param name="i_season_added">Flag telling if a season has been added by the user</param>
        public static void SetComboBoxSeasons(ComboBox i_combo_box, bool i_season_added)
        {
            // Available seasons, including the un-published seasons since member is logged in
            JazzUtils.SetMemberLogin(true);
            string[] season_strings = JazzXml.GetAvailableSeasons(JazzUtils.GetMemberLogin());
            if (null == season_strings)
                return;
            if (0 == season_strings.Length)
                return;

            i_combo_box.Items.Clear();

            if (NewSeasonProgramCanBeAdded())
            {
                i_combo_box.Items.Add(AdminUtils.GetAddSeasonString());
            }

            for (int i_season = season_strings.Length - 1; i_season >= 0; i_season--)
            {
                i_combo_box.Items.Add(season_strings[i_season]);
            }

            if (i_season_added)
            {
                i_combo_box.Text = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetLastSeasonName());
            }
            else
            {
                i_combo_box.Text = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetSeasonName());
            }
            

        } // SetComboBoxSeasons

        /// <summary>Returns true if a new season program can be added
        /// <para>There is a limit of files after current year (NewSeasonProgramCanBeAdded)</para>
        /// </summary>
        static public bool NewSeasonProgramCanBeAdded()
        {
            bool b_ret_can_be_added = true;

            int n_allowed = JazzUtils.MaxNumberOfNewSeasonPrograms;

            int[] start_years = JazzXml.GetSeasonsStartYears();

            int array_last_start_year = start_years[start_years.Length - 1];

            int current_start_year = JazzUtils.GetCurrentSeasonStartYear();

            int n_existing_new_seasons = array_last_start_year - current_start_year;

            if (n_existing_new_seasons >= n_allowed)
            {
                b_ret_can_be_added = false;
            }

            return b_ret_can_be_added;

        } // NewSeasonProgramCanBeAdded

        /// <summary>Returns the index in the array for the selected item. Returns negative value for error</summary>
        static public int GetIndexSelectedItem(string[] i_strings, string i_selected)
        {
            int ret_int = -12345;

            if (null == i_strings)
                return ret_int;
            if (0 == i_strings.Length)
                return ret_int;

            if (i_selected.Trim().Length == 0)
                return ret_int;

            for (int index_string = 0; index_string < i_strings.Length; index_string++)
            {
                if (i_selected.Equals(i_strings[index_string]))
                {
                    ret_int = index_string;
                    break;
                }
            }

            return ret_int;
        } // GetIndexSelectedItem

        /// <summary>Returns true if current season program not is published</summary>
        public static bool SeasonProgramNotPublished()
        {
            // Exception
            int autumn_year = JazzXml.GetYearAutumnInt();
            bool passed_year = TimeUtil.PassedYear(autumn_year);
            if (!passed_year)
            {
                return true;
            }

            bool is_not_published = true;

            if (JazzXml.PublishProgram())
                is_not_published = false;

            return is_not_published;
        } // SeasonProgramNotPublished

        /// <summary>Set combobox concerts</summary>
        public static void SetComboBoxConcerts(ComboBox i_combo_box)
        {
            string[] displayed_concerts = GetConcertStrings();

            SetComboBox(i_combo_box, displayed_concerts, GetAddConcertString(), GetCurrentConcertNumber() - 1);

        } // SetComboBoxConcerts

        /// <summary>Reset the combobox concerts text (when the user has tried to change the text)</summary>
        public static void ResetComboboxConcertsText(ComboBox i_combo_box)
        {
            string[] displayed_concerts = GetConcertStrings();

            ResetComboBoxText(i_combo_box, displayed_concerts, GetCurrentConcertNumber() - 1);
        } // ResetComboboxConcertsText

        /// <summary>Get concert strings</summary>
        static public string[] GetConcertStrings()
        {
            int n_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

            string[] ret_concerts = new string[n_concerts];
            for (int i_concert = 0; i_concert < ret_concerts.Length; i_concert++)
            {
                ret_concerts[i_concert] = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetBandName(i_concert + 1));
            }

            return ret_concerts;

        } // GetConcertStrings

        /// <summary>Set combobox musician</summary>
        public static void SetComboBoxMusicians(ComboBox i_combo_box)
        {
            string[] musicians_strings = JazzXml.GetMusiciansAsStrings(GetCurrentConcertNumber());

            int index_musician = GetCurrentMusicianNumber() - 1;
            if (GetCurrentMusicianNumber() > musicians_strings.Length)
            {
                // Programming error. Current musician number has not been set correctly
                SetCurrentMusicianNumber(1);
                index_musician = 0;
            }

            SetComboBox(i_combo_box, musicians_strings, GetAddMusicianString(), index_musician);

        } // SetComboBoxMusicians

        /// <summary>Set combobox members</summary>
        public static void SetComboBoxMembers(ComboBox i_combo_box)
        {
            string[] members_strings = JazzXml.GetMembersAsStrings();

            int index_member = GetCurrentMemberNumber() - 1;
            if (GetCurrentMemberNumber() > members_strings.Length)
            {
                // Programming error. Current member number has not been set correctly
                SetCurrentMemberNumber(1);
                index_member = 0;
            }

            SetComboBox(i_combo_box, members_strings, GetAddMemberString(), index_member);

        } // SetComboBoxMembers

        /// <summary>Set combobox active members</summary>
        public static void SetComboBoxActiveMembers(ComboBox i_combo_box)
        {
            string[] active_members_strings = GetActiveMembersAsStrings();

            int index_contact_person =  GetContactPersonAsIndex();
            if (index_contact_person < 0)
                index_contact_person = 0; // Programming error

            SetComboBox(i_combo_box, active_members_strings, @"", index_contact_person);

        } // SetComboBoxActiveMembers

        /// <summary>Returns the number (id) of the concert contact person as a string</summary>
        public static string ConcertContactPersonNumberAsString(string i_selected_active_member)
        {
            string ret_number_str = "";

            if (i_selected_active_member.Trim().Length == 0)
                return ret_number_str;

            string[] active_members_strings = GetActiveMembersAsStrings();
            if (null == active_members_strings)
                return ret_number_str;

            MemberData[] active_members = JazzXml.GetActiveMembers();
            if (null == active_members)
                return ret_number_str;

            if (active_members_strings.Length != active_members.Length)
                return ret_number_str;

            for (int index_active = 0; index_active < active_members.Length; index_active++)
            {
                string avtive_member_str = active_members_strings[index_active];               

                if (i_selected_active_member.Equals(avtive_member_str))
                {
                    MemberData active_member = active_members[index_active];
                    int member_number = active_member.Number;

                    ret_number_str = member_number.ToString();
                    break;
                }
            } // index_active


            return ret_number_str;
        } // ConcertContactPersonNumberAsString

        /// <summary>Returns the active members as strings (first name and family name)</summary>
        static private string[] GetActiveMembersAsStrings()
        {
            string[] ret_string = null;

            MemberData[] active_members = JazzXml.GetActiveMembers();
            if (null == active_members)
                return ret_string;

            ret_string = new string[active_members.Length];

            for (int index_active = 0; index_active < ret_string.Length; index_active++)
            {
                MemberData active_member = active_members[index_active];
                ret_string[index_active] = active_member.Name + @" " + active_member.FamilyName;
            }

            return ret_string;
        } // GetActiveMembersAsStrings

        /// <summary>Returns the concert contact person as index in array all active members</summary>
        static private int GetContactPersonAsIndex()
        {
            int ret_index =-12345;

            MemberData[] active_members = JazzXml.GetActiveMembers();
            if (null == active_members)
                return ret_index;

            int contact_member_number = JazzXml.GetContactConcertMemberNumberInt();
            for (int index_active = 0; index_active < active_members.Length; index_active++)
            {
                MemberData active_member = active_members[index_active];

                if (active_member.Number == contact_member_number)
                {
                    ret_index = index_active;
                    break;
                }
            } // index_active

            return ret_index;

        } // GetContactPersonAsIndex



        /// <summary>Set combobox</summary>
        private static void SetComboBox(ComboBox i_combo_box, string[] i_strings, string i_add_string, int i_index)
        {
            i_combo_box.Items.Clear();

            if (null == i_strings)
                return;
            if (0 == i_strings.Length)
                return;

            if (i_index < 0 || i_index >= i_strings.Length)
                return;

            // i_combo_box.Items.Add(AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetCaptionMember()));

            for (int index_string = 0; index_string < i_strings.Length; index_string++)
            {
                string current_string = i_strings[index_string];
                if (!JazzXml.XmlNodeValueIsSet(current_string))
                    current_string = "...";

                i_combo_box.Items.Add(current_string);
            }

            if (i_add_string.Length > 0)
            {
                i_combo_box.Items.Add(i_add_string);
            }
            
            string current_set_string = i_strings[i_index];
            if (!JazzXml.XmlNodeValueIsSet(current_set_string))
                current_set_string = "...";

            i_combo_box.Text = current_set_string;

        } // SetComboBox

        /// <summary>Reset the combobox text (when the user has tried to change the displayed text) TODO Does not work??</summary>
        private static void ResetComboBoxText(ComboBox i_combo_box, string[] i_strings, int i_index)
        {
            if (null == i_strings)
                return;
            if (0 == i_strings.Length)
                return;

            if (i_index < 0 || i_index >= i_strings.Length)
                return;

            string current_set_string = i_strings[i_index];
            if (!JazzXml.XmlNodeValueIsSet(current_set_string))
                current_set_string = "...";

            i_combo_box.Text = current_set_string;

        } // ResetComboBoxText

        #endregion // Set and get combo boxes for seasons, concerts, musicians and members

        #region Common get caption and title functions

        /// <summary>Returns the form title for text editing</summary>
        static public string GetTitleFormText(string i_title_page)
        {
            return i_title_page + @" " + JazzAppAdminSettings.Default.GuiTextPage + @": " + JazzAppAdminSettings.Default.GuiTextEditText;
        } // SetTitleFormText

        /// <summary>Returns the form title for text editing</summary>
        static public string GetTitleFormTitle(string i_title_page)
        {
            return i_title_page + @" " + JazzAppAdminSettings.Default.GuiTextPage + @": " + JazzAppAdminSettings.Default.GuiTextEditTitle;
        } // SetTitleFormTitle

        /// <summary>Returns the caption close</summary>
        static private string GetCaptionClose() { return JazzAppAdminSettings.Default.Caption_Close; }

        /// <summary>Returns the caption save</summary>
        static private string GetCaptionApply() { return JazzAppAdminSettings.Default.Caption_Apply; }

        /// <summary>Returns the caption cancel</summary>
        static private string GetCaptionCancel() { return JazzAppAdminSettings.Default.Caption_Cancel; }

        /// <summary>Sets button cancel and close for edit text and title forms</summary>
        static public void SetCancelCloseButtons(Button i_button_cancel, Button i_button_close, bool i_editable)
        {
            i_button_close.Text = GetCaptionClose();
            if (i_editable)
                i_button_close.Text = GetCaptionApply();
            i_button_cancel.Text = GetCaptionCancel();

        } // SetCancelCloseButtons




        #endregion // Common get caption and title functions

        #region Upload XML

        /// <summary>Uploads the edited XML file to the server
        /// <para>If the application document has changed also this XML file will be uploaded</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static public bool UploadEditedXmlToServer(out string o_error)
        {
            o_error = @"";

            if (!UploadXmlToServer(true, out o_error))
            {
                return false;
            }

            if (AdminUtils.GetApplicationDocumentChangeFlag())
            {
                SetApplicationDocumentChangeFlag(false);

                if (!UploadXmlToServer(false, out o_error))
                {
                    return false;
                }
            }

            return true;
        } // UploadEditedXmlToServer

        /// <summary>Uploads an XML file to the server
        /// <para>A backup file is also created</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <param name="i_current_selected_xml">Eq. true: Current selected XML is uploaded Eq. false: Application XML</param>
        static public bool UploadXmlToServer(bool i_current_selected_xml, out string o_error)
        {
            o_error = @"";

            string server_file_url = GetCurrentSelectedXmlFile();
            XDocument edited_doc = GetCurrentEditDocument();

            if (!i_current_selected_xml)
            {
                server_file_url = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetApplicationFileName());
                edited_doc = JazzXml.GetApplicationDocument();
            }

            string file_name_exe_dir = GetFileNameExeDir(server_file_url);
            if (!JazzXml.WriteToFile(edited_doc, file_name_exe_dir, out o_error))
            {
                o_error = @"AdminUtils.UploadXmlToServer Programming error: " + o_error;
                return false;
            }

            UpLoad htpp_upload = new UpLoad();

            string file_server_url = GetFileNameWwwUrl(file_name_exe_dir);

            bool to_www = true;
            if (!htpp_upload.OneFile(to_www, file_server_url, file_name_exe_dir, out o_error))
            {
                o_error = "AdminUtils.UploadEditedXmlToServer Upload.OneFile failed: " + o_error;
                return false;
            }

            bool edited_file = true;
            if (!Backup.BackupCurrentEditXmlFile(server_file_url, edited_file, out o_error))
            {
                o_error = @"AdminUtils.UploadXmlToServer Programming error: " + o_error;
                return false;
            }

            return true;
        } // UploadXmlToServer

        /// <summary>Uploads an XML file to the server
        /// <para>1. Gets a local file name. Call of AdminUtils.GetFileNameExeDir</para>
        /// <para>2. Create a local XML file. Call of JazzXml.WriteToFile</para>
        /// <para>3. Get full server file name (URL). Call of AdminUtils.GetFileNameWwwUrl that assumes that the XML file is in directory /www/XML/ TODO</para>
        /// <para>4. Upload the file to the server. Call of Upload.OneFile</para>
        /// <para>5. Create a backup file. Call of Backup.BackupCurrentEditXmlFile</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_server_file_url">Only server file name is OK</param>
        /// <param name="i_edited_doc">XML object corresponding to the input XML file</param>
        /// <param name="o_error">Error message</param>
        static public bool UploadXmlToServer(string i_server_file_url, XDocument i_edited_doc, out string o_error)
        {
            o_error = @"";

            string file_name_exe_dir = AdminUtils.GetFileNameExeDir(i_server_file_url); // If input file has a path it will be removed
            if (!JazzXml.WriteToFile(i_edited_doc, file_name_exe_dir, out o_error))
            {
                o_error = @"DocAdmin.UploadXmlToServer Programming error: " + o_error;
                return false;
            }

            UpLoad htpp_upload = new UpLoad();

            string file_server_url = AdminUtils.GetFileNameWwwUrl(file_name_exe_dir); // TODO Assumes that XML is as for concerts and not using m_url_xml_doc_files_folder

            bool to_www = true;
            if (!htpp_upload.OneFile(to_www, file_server_url, file_name_exe_dir, out o_error))
            {
                o_error = "AdminUtils.UploadEditedXmlToServer Upload.OneFile failed: " + o_error;
                return false;
            }

            bool edited_file = true;
            string backup_file_name_with_path = AdminUtils.GetFullServerNameForXmlBackup(i_server_file_url);
            if (!Backup.BackupCurrentEditXmlFile(backup_file_name_with_path, edited_file, out o_error))
            {
                o_error = @"AdminUtils.UploadXmlToServer Programming error: " + o_error;
                return false;
            }

            return true;
        } // UploadXmlToServer


        #endregion // Upload XML

        #region Get full path file names

        /// <summary>Returns the file name to the local (XmlExistingDir) directory on the Exe directory</summary>
        static public string GetFileNameExeDir(string i_file_url)
        {
            string local_address_directory = FileUtil.SubDirectory(JazzAppAdminSettings.Default.XmlExistingDir, Main.m_exe_directory) + @"\";
            string file_name_no_path = Path.GetFileName(i_file_url);
            string file_name_local = local_address_directory + file_name_no_path;
            return file_name_local;
        } // GetFileNameExeUrl

        /// <summary>Returns the server file URL directory (XmlExistingDir) on the www directory for a file to be uploaded</summary>
        static public string GetFileNameWwwUrl(string i_file_url_or_exe)
        {
            string file_name_no_path = Path.GetFileName(i_file_url_or_exe);
            string directory_url =  @"www\" + JazzAppAdminSettings.Default.XmlExistingDir + @"\";
            string ret_url = directory_url + file_name_no_path;

            return ret_url;

        } // GetFileNameWwwUrl

        /// <summary>Returns the server file URL directory (XmlExistingDir) on the www directory for a file to be uploaded</summary>
        static public string GetFullServerNameForXmlBackup(string i_file_name)
        {
            string file_name_no_path = Path.GetFileName(i_file_name); // In case the file name has a path
            string directory_url = @"http://" + JazzAppAdminSettings.Default.FtpHost + @"/" + JazzAppAdminSettings.Default.XmlExistingDir + @"/";
            string ret_url = directory_url + file_name_no_path;

            return ret_url;

        } // GetFullServerNameForXmlBackup

        #endregion // Get full path file names

        #region Prevent user to close application with for instance Alt+f4

        /// <summary>Handling of the event that the form is closing
        /// <para>This application has no windows control box with an exit button. The user should always use the Exit (Ende) button (m_button_exit)</para>
        /// <para>The user can however use Alt+f4 or close the application from the task bar </para>
        /// <para>i_case=1: Ask user if he really wants to exit the application. Call FormIsClosingReallyExit</para>
        /// <para>i_case=2: Tell the user to use the implemented buttons to close the dialog. Call of FormIsClosingUseImplementedButtons</para>
        /// <para>i_case=3: Neglect the close command. Call FormIsClosingNeglectCloseCommand</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_event">Form is closing event</param>
        /// <param name="i_case">Execution case</param>
        public static void FormIsClosing(FormClosingEventArgs i_event, int i_case)
        {
            // http://www.daveoncsharp.com/2009/06/prevent-users-closing-your-windows-form/

            int close_reason = -12345;
            if (i_event.CloseReason == CloseReason.ApplicationExitCall)
            {
                close_reason = 1;
            }
            else if (i_event.CloseReason == CloseReason.TaskManagerClosing)
            {
                close_reason = 2;
            }
            else if (i_event.CloseReason == CloseReason.WindowsShutDown)
            {
                close_reason = 3;
            }
            else if (i_event.CloseReason == CloseReason.UserClosing)
            {
                close_reason = 4;
            }

            bool xml_is_checked_out = JazzLoginLogout.LoginLogout.DataCheckedOut;

            if (close_reason >= 1 && close_reason <=3 && xml_is_checked_out)
            {
                ApplicationIsExitingWithoutCheckin(i_event);
            }

            if (4 == close_reason)
            {
                if (1 == i_case)
                {
                    FormIsClosingReallyExit(i_event);
                }
                else if (2 == i_case)
                {
                    FormIsClosingUseImplementedButtons(i_event);
                }
                else if (3 == i_case)
                {
                    FormIsClosingNeglectCloseCommand(i_event);
                }
                else
                {
                    FormIsClosingCaseNotImplemented(i_case);
                }
            }

        } // FormIsClosing

        /// <summary>Ask user if he really wants to exit the application
        /// <para>Message box with a yes button and a no button is displayed</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_event">Form is closing event</param>
        public static void FormIsClosingReallyExit(FormClosingEventArgs i_event)
        {
            if (MessageBox.Show(JazzAppAdminSettings.Default.MsgReallyExitApplication,
                               JazzAppAdminSettings.Default.MsgReallyExit,
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) == DialogResult.No)
            {
                i_event.Cancel = true;
            }

        } // FormIsClosingReallyExit

        /// <summary>Tell the user to use the implemented buttons to close the dialog
        /// <para>Message box is diplayed</para>
        /// <para></para>
        /// </summary>
        public static void FormIsClosingUseImplementedButtons(FormClosingEventArgs i_event)
        {
            string use_implemented_buttons = JazzAppAdminSettings.Default.MsgCloseDialogWithImplementedButtons +
                JazzAppAdminSettings.Default.Caption_Exit + @", " +
                JazzAppAdminSettings.Default.Caption_Apply + @", " +
                JazzAppAdminSettings.Default.Caption_Close + @" oder " +
                JazzAppAdminSettings.Default.Caption_Cancel;

            MessageBox.Show(use_implemented_buttons);

            i_event.Cancel = true;

        } // FormIsClosingUseImplementedButtons

        // ErrMsgAdminExitedWithCheckedOutXml

        /// <summary>Tell the user to use the implemented buttons to close the dialog
        /// <para>Message box is diplayed</para>
        /// <para></para>
        /// </summary>
        public static void ApplicationIsExitingWithoutCheckin(FormClosingEventArgs i_event)
        {
            MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgAdminExitedWithCheckedOutXml);

            i_event.Cancel = true;

        } // AppicationIsExitingWithoutCheckin


        /// <summary>Neglect the close command
        /// <para></para>
        /// </summary>
        /// <param name="i_event">Form is closing event</param>
        public static void FormIsClosingNeglectCloseCommand(FormClosingEventArgs i_event)
        {
            i_event.Cancel = true;

        } // FormIsClosingNeglectCloseCommand

        /// <summary>Error: Closing case is not implemented
        /// <para>Message box is diplayed with error message</para>
        /// <para></para>
        /// </summary>
        public static void FormIsClosingCaseNotImplemented(int i_case)
        {
            string error_message = @"AdminUtils.FormIsClosing Case " + i_case.ToString() + @" is not implemented";

            MessageBox.Show(error_message);

        } // FormIsClosingCaseNotImplemented


        #endregion // Prevent user to close application with for instance Alt+f4

        #region Message box

        /// <summary>Returns true if the user selected yes in the message box</summary>
        static public bool MessageBoxYesNo(string i_message, string i_caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(i_message, i_caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        } // MessageBoxYesNo

        #endregion // Message box

        #region Enable and disable colors

        /// <summary>Returns the background color for an enabled control</summary>
        static public Color ColorEnable()
        {
            return System.Drawing.SystemColors.Window;
        } // ColorEnable

        /// <summary>Returns the background color for a disabled control</summary>
        static public Color ColorDisable()
        {
            return Color.LightGoldenrodYellow;

        } // ColorDisable

        #endregion // Enable and disable colors

        #region Check input strings

        /// <summary>Returns true if the telephone number is OK</summary>
        public static bool CheckTelephone(string i_telephone, out string o_error)
        {
            o_error = @"";

            string telephone_trim = i_telephone.Trim();

            int ret_status = JazzXml.ValidTelephoneNumber(telephone_trim);

            bool ret_check = true;

            if (0 == ret_status)
            {
                ret_check = true;
            }
            else if (-1 == ret_status)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgAllCharsMustBeNumbers + @" (" + telephone_trim + @")";
                ret_check = false;
            }
            else if (-3 == ret_status)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgPlusTelephoneNumber + @" (" + telephone_trim + @")";
                ret_check = false;
            }
            else
            {
                o_error = @"Premises.WritePremisesTelephone Error= " + ret_status.ToString() + @" (" + telephone_trim + @")";
                ret_check = false;
            }

            if (!ret_check)
                return false;

            return true;

        } // CheckTelephone

        /// <summary>Returns true if the year is OK</summary>
        public static bool CheckYear(string i_year, out string o_error)
        {
            o_error = @"";

            bool year_ok = true;

            string year_trim = i_year.Trim();
            if (year_trim.Length > 0)
            {
                int ret_status = JazzXml.ValidNumber(year_trim);
                if (0 == ret_status)
                {
                    if (year_trim.Length != 4)
                    {
                        o_error = JazzAppAdminSettings.Default.ErrMsgYearNotFourNumbers + @" (" + year_trim + @")";
                        year_ok = false;
                    }
                    else
                    {
                        year_ok = true;
                    }
                }
                else if (-1 == ret_status)
                {
                    o_error = JazzAppAdminSettings.Default.ErrMsgAllCharsMustBeNumbers + @" (" + year_trim + @")";
                    year_ok = false;
                }
                else if (-2 == ret_status)
                {
                    o_error = JazzAppAdminSettings.Default.ErrMsgNumberCannotStartWithZero + @" (" + year_trim + @")";
                    year_ok = false;
                }
                else
                {
                    o_error = @"AdminUtils.CheckYear Error= " + ret_status.ToString();
                    year_ok = false;
                }

            } // Value is set, i.e.length > 0

            return year_ok;
        } // CheckYear


        /// <summary>Returns true if the relative URL file path is OK</summary>
        public static bool CheckRelativePath(string i_filename_with_relative_path, out string o_error)
        {
            o_error = @"";

            bool path_ok = true;

            if (i_filename_with_relative_path.Trim().Length == 0)
                return path_ok;

            if (i_filename_with_relative_path.Contains("http"))
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgFileUrlHasFullPath + i_filename_with_relative_path;
                path_ok = false;
                return path_ok;
            }

            string path = Path.GetDirectoryName(i_filename_with_relative_path);
            if (path.Length == 0)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgFileUrlWithoutPath + i_filename_with_relative_path;
                path_ok = false;
                return path_ok;
            }

            if (i_filename_with_relative_path.Contains(@"\"))
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgFileUrlNotAllowedSlash + i_filename_with_relative_path;
                path_ok = false;
                return path_ok;
            }

            return path_ok;
        } // CheckRelativePath

        /// <summary>Returns true if the full URL path is OK</summary>
        public static bool CheckFullPath(string i_filename_path, out string o_error)
        {
            o_error = @"";

            bool path_ok = true;

            if (i_filename_path.Trim().Length == 0)
                return path_ok;

            if (!i_filename_path.Contains("http"))
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgFileUrlNoFullPath + i_filename_path;
                path_ok = false;
                return path_ok;
            }

            if (i_filename_path.Contains(@"\"))
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgFileUrlNotAllowedSlash + i_filename_path;
                path_ok = false;
                return path_ok;
            }

            return path_ok;
        } // CheckFullPath

        /// <summary>Returns true if the zip file OK</summary>
        public static bool CheckZipFileName(string i_filename_zip, out string o_error)
        {
            o_error = @"";

            bool path_ok = true;

            if (i_filename_zip.Trim().Length == 0)
                return path_ok;

            string path = Path.GetDirectoryName(i_filename_zip);
            if (path.Length > 0)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgFileUrlWithPath + i_filename_zip;
                path_ok = false;
                return path_ok;
            }

            string extension = Path.GetExtension(i_filename_zip);
            if (extension == ".zip" || extension == ".ZIP" )
            {
                path_ok = true;
            }
            else
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgZipFileExtension + i_filename_zip;
                path_ok = false;
                return path_ok;
            }

            return path_ok;
        } // CheckZipFileName

        #endregion // Check input strings

        #region Temporary (TODO) string functions

        /// <summary>removes the website url from the input string
        /// <para>Some functions (GetPremisesPhoto, GetPremisesMap, ..) adds the web site URL. In the XML file there is only the subdirectory and file name</para>
        /// <para>This is a special thing that breaks the pattern. It would be better to take that away. TODO</para>
        /// </summary>
        public static string RemoveWebsiteUrl(string i_url_with_website_url)
        {
            string ret_url = i_url_with_website_url;
            string website_url = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetWebSiteUrl());
            if (ret_url.Contains(website_url))
            {
                int n_website_url = website_url.Length;

                ret_url = ret_url.Substring(n_website_url);
            }
            return ret_url;
        } // RemoveWebsiteUrl

        /// <summary>Remove JAZZ live AARAU Url. TODO Temporary fix</summary>
        public static string RemoveJazzLiveAarauUrl(string i_xml_value)
        {
            string ret_str = @"";

            string jazz_url = @"http://www.jazzliveaarau.ch/";

            // Very dirty fix
            string sound_sample_mp3_ext = @".mp3";
            bool b_sound_sample_mp3 = i_xml_value.Contains(sound_sample_mp3_ext);
            string sound_sample_mp4_ext = @".mp4";
            bool b_sound_sample_mp4 = i_xml_value.Contains(sound_sample_mp4_ext);

            bool b_sound_sample = false;
            if (b_sound_sample_mp3 || b_sound_sample_mp4)
            {
                b_sound_sample = true;
            }

            if (i_xml_value.Contains(jazz_url) && !b_sound_sample)
            {
                int url_length = jazz_url.Length;

                ret_str = i_xml_value.Substring(url_length);
                ret_str = RemoveXmlUndefinedValue(ret_str);
            }
            else if (b_sound_sample)
            {
                ret_str = i_xml_value;
            }
            else
            {
                ret_str = i_xml_value;
            }

            return ret_str;

        } // RemoveJazzLiveAarauUrl

        #endregion // Temporary (TODO) string functions

        #region Undefined XML value

        /// <summary>Remove the value undefined and return empty string</summary>
        public static string RemoveXmlUndefinedValue(string i_xml_value)
        {
            if (!JazzXml.XmlNodeValueIsSet(i_xml_value))
                return @"";
            else
                return i_xml_value;

        } // RemoveXmlUndefinedValue

        #endregion // Undefined XML value

        #region Checkout

        /// <summary>Check out data. Force checkout possible
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <returns>false if the user selects not to force the checkout (and for error)</returns>
        public static bool CheckoutData()
        {
            bool b_already_checked_out = false;
            string error_message = @"";
            string login_logout_message = @"";
            if (!JazzLoginLogout.LoginLogout.Checkout(false, out b_already_checked_out, out login_logout_message, out error_message))
            {
                if (b_already_checked_out && AdminUtils.MessageBoxYesNo(error_message, "Logout"))
                {
                    // User forced logout
                    if (!JazzLoginLogout.LoginLogout.Checkout(true, out b_already_checked_out, out login_logout_message, out error_message))
                    {
                        return false;
                    } // (Already checked out by another user or) Error
                }
                else
                {
                    // User did not force logout
                    return false;
                }
            } // Already checked out by another user or error

            Main.CheckoutButNoWebsiteUpdate = true;

            return true;
        } // CheckoutData

        #endregion // Checkout

        #region Reload XML before checkout

        /// <summary>Reload the application XML (JazzApplication.xml)</summary>
        static public void ReloadApplicationXml()
        {
            // After checkout own changes may be overwritten
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                return;

            JazzXml.ReloadApplicationXml();

        } // ReloadApplicationXml

        /// <summary>Reload the current season program XML (JazzProgramm_20YY_20YY.xml)</summary>
        static public void ReloadCurrentSeasonProgramXml()
        {
            // After checkout own changes may be overwritten
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                return;

            JazzXml.ReloadCurrentSeasonProgramXml();

        } // ReloadCurrentSeasonProgramXml

        /// <summary>Reload the current season document XML (JazzDokumente_20YY_20YY.xml)</summary>
        static public void ReloadCurrentSeasonDocumentXml()
        {
            // After checkout own changes may be overwritten
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                return;

            JazzXml.ReloadCurrentSeasonDocumentXml();

        } // ReloadCurrentSeasonDocumentXml


        #endregion // Reload XML before checkout

        /// <summary>Returns true if Internet connection is available.</summary>
        static public bool IsInternetConnectionAvailable()
        {
            string status_message = @"";

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.CheckInternetConnection);

            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

            if (!ftp_result.Status)
            {
                // Programming error
                status_message = @"AdminUtils.IsInternetConnectionAvailable JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                
                return false;
            }

            return ftp_result.BoolResult;

        } // IsInternetConnectionAvailable

    } // AdminUtils

    /// <summary>Tooltip utility functions</summary>
    public static class ToolTipUtil
    {
        /// <summary>Set the time the tool tip shall be shown, how quick, etc.</summary>
        public static void SetDelays(ref ToolTip io_tool_tip)
        {
            // Set up the delays for the ToolTip.
            io_tool_tip.AutoPopDelay = 500000000; // Default is 5000
            io_tool_tip.InitialDelay = 500;  // Default is 1000
            io_tool_tip.ReshowDelay = 100; // Default is 500
            // Force the ToolTip text to be displayed whether or not the form is active.
            io_tool_tip.ShowAlways = true;

        } // SetDelays


    } // ToolTipUtil

} // namespace
