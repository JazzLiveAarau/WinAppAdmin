using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Execution functions and parameters for the form NewsForm
    /// <para></para>
    /// </summary>
    public static class News
    {
        #region Active news variables

        /// <summary>Number for active current news</summary>
        private static int m_active_current_news = 0;

        /// <summary>Get the active current news number</summary>
        public static int ActiveCurrentNewsNumber { get { return m_active_current_news; } }

        /// <summary>Set the active current news number</summary>
        public static void SetActiveCurrentNewsNumber(string i_combobox_item_name)
        {
            string[] current_news_array = GetArrayForComboBoxCurrentNews();

            for (int index_news=0; index_news < current_news_array.Length; index_news++)
            {
                string item_name = current_news_array[index_news];

                if (item_name.Equals(i_combobox_item_name))
                {
                    m_active_current_news = index_news + 1;

                    break;
                }
            }

        } // SetActiveCurrentNewsNumber

        /// <summary>Number for active concert news</summary>
        private static int m_active_concert_news = 0;

        /// <summary>Get the active concert news number</summary>
        public static int ActiveConcertNewsNumber { get { return m_active_concert_news; } }

        /// <summary>Set the active concert news number</summary>
        public static void SetActiveConcertNewsNumber(string i_combobox_item_name)
        {
            string[] concert_news_array = GetArrayForComboBoxConcertNews();

            for (int index_news = 0; index_news < concert_news_array.Length; index_news++)
            {
                string item_name = concert_news_array[index_news];

                if (item_name.Equals(i_combobox_item_name))
                {
                    m_active_concert_news = index_news + 1;

                    break;
                }
            }

        } // SetActiveConcertNewsNumber

        /// <summary>Initialization of active news numbers</summary>
        public static void InitActiveNewsNumbers()
        {
            InitCurrentActiveNewsNumber();

            InitConcertActiveNewsNumber();

        } // InitActiveNewsNumbers

        /// <summary>Initialization of current active news number</summary>
        public static void InitCurrentActiveNewsNumber()
        {
            m_active_current_news = 0;

        } // InitCurrentActiveNewsNumber

        /// <summary>Initialization of concert active news number</summary>
        public static void InitConcertActiveNewsNumber()
        {
            m_active_concert_news = 0;

        } // InitConcertActiveNewsNumber

        /// <summary>Set current active news number to the last element</summary>
        public static void SetCurrentActiveNewsNumberToLastElement()
        {
            string error_message = @"";

            int n_current_news = JazzXml.GetNumberOfCurrentNews(out error_message);

            if (error_message.Length == 0)
            {
                m_active_current_news = n_current_news;
            }
            else
            {
                m_active_current_news = 0;
            }

        } // SetCurrentActiveNewsNumberToLastElement

        /// <summary>Set concert active news number to the last element</summary>
        public static void SetConcertActiveNewsNumberToLastElement()
        {
            string error_message = @"";

            int n_concert_news = JazzXml.GetNumberOfConcertNews(out error_message);

            if (error_message.Length == 0)
            {
                m_active_concert_news = n_concert_news;
            }
            else
            {
                m_active_concert_news = 0;
            }

        } // SetConcertActiveNewsNumberToLastElement



        #endregion // Active news variables

        #region Names and paths for the XML file holding news data

        /// <summary>Server path to the XML news file (JazzNews.xml)</summary>
        private static string m_url_xml_news_files_folder = "XML";

        /// <summary>Get the server path to the XML news file (JazzNews.xml)</summary>
        public static string NewsFileServerDir { get { return m_url_xml_news_files_folder; } }

        /// <summary>Name of the XML news file.</summary>
        private static string m_news_xml_filename = "JazzNews.xml";

        /// <summary>Get the name of the XML news file</summary>
        public static string NewsFileName { get { return m_news_xml_filename; } }

        #endregion // Names and paths for the XML file holding news data

        #region Init XML object and set dropdown menus

        /// <summary>Initialization (creation) of the news object corresponding to the XML file JazzNews.xml
        /// <para>Call of JazzXml.InitNews</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static public bool InitXmlNews(out string o_error)
        {
            o_error = @"";
            bool ret_init = true;

            string error_message = @"";

            if (!JazzXml.InitNews(NewsFileServerDir, NewsFileName, out error_message))
            {
                o_error = @"News.InitXmlNews JazzXml.InitNews failed " + error_message;
                return false;
            }

            return ret_init;

        } // InitXmlNews

        /// <summary>Set combobox (dropdown menu) current news
        /// <para>1. Get the item array for the dropdown. Call of GetArrayForComboBoxCurrentNews.</para>
        /// <para>2. Set the items for the dropdown menu. First item is 'Add item' and second item is 'Select item'.</para>
        /// <para>3. Set active dropdown menu item to 'Select item'</para>
        /// </summary>
        public static void SetComboBoxCurrentNews(ComboBox i_combo_box)
        {
            string[] current_news_array = GetArrayForComboBoxCurrentNews();

            i_combo_box.Items.Clear();

            i_combo_box.Items.Add(NewsStrings.PromptAddCurrentNews);

            i_combo_box.Items.Add(NewsStrings.PromptSelectCurrentNews);

            if (current_news_array != null)
            {
                for (int index_name = 0; index_name < current_news_array.Length; index_name++)
                {
                    i_combo_box.Items.Add(current_news_array[index_name]);
                }
            }

            i_combo_box.Text = NewsStrings.PromptSelectCurrentNews;

        } // SetComboBoxCurrentNews

        /// <summary>Set combobox (dropdown menu) concert news
        /// <para>1. Get the item array for the dropdown. Call of GetArrayForComboBoxConcertNews.</para>
        /// <para>2. Set the items for the dropdown menu. First item is 'Add item' and second item is 'Select item'.</para>
        /// <para>3. Set active dropdown menu item to 'Select item'</para>
        /// </summary>
        public static void SetComboBoxConcertNews(ComboBox i_combo_box)
        {
            string[] concert_news_array = GetArrayForComboBoxConcertNews();

            i_combo_box.Items.Clear();

            i_combo_box.Items.Add(NewsStrings.PromptAddConcertNews);

            i_combo_box.Items.Add(NewsStrings.PromptSelectConcertNews);

            if (concert_news_array != null)
            {
                for (int index_name = 0; index_name < concert_news_array.Length; index_name++)
                {
                    i_combo_box.Items.Add(concert_news_array[index_name]);
                }
            }

            i_combo_box.Text = NewsStrings.PromptSelectConcertNews;

        } // SetComboBoxConcertNews

        /// <summary>Get item names for the current news dropdown menu</summary>
        private static string[] GetArrayForComboBoxCurrentNews()
        {
            string[] ret_array = null;

            String error_message = @"";

            int n_current_news = JazzXml.GetNumberOfCurrentNews(out error_message);

            ret_array = new string[n_current_news];

            for (int index_news=0; index_news < n_current_news; index_news++)
            {
                ret_array[index_news] = NewsStrings.ItemTextCurrentNews + (index_news + 1).ToString();
            }

            return ret_array;

        } // GetArrayForComboBoxCurrentNews

        /// <summary>Get item names for the concert news dropdown menu</summary>
        private static string[] GetArrayForComboBoxConcertNews()
        {
            string[] ret_array = null;

            String error_message = @"";

            int n_concert_news = JazzXml.GetNumberOfConcertNews(out error_message);

            ret_array = new string[n_concert_news];

            for (int index_news = 0; index_news < n_concert_news; index_news++)
            {
                ret_array[index_news] = NewsStrings.ItemTextConcertNews + (index_news + 1).ToString();
            }

            return ret_array;

        } // GetArrayForComboBoxConcertNews

        #endregion // Init XML object and set dropdown menus

        #region Current season functions

        /// <summary>Set current season to this season</summary>
        static public bool SetCurrentSeason(out string o_error)
        {
            o_error = @"";

            XDocument this_year_season_doc = JazzXml.GetDocumentThisYearSeason(out o_error);

            if (null == this_year_season_doc)
            {
                o_error = @"Website.UpdateWebsite This year XML document is null. " + o_error;

                return false;
            }

            JazzXml.SetCurrentSeasonDocument(this_year_season_doc);

            return true;

        } // SetCurrentSeason

        /// <summary>Returns the name of the band for a given concert number</summary>
        static public string GetBandName(int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckConcertNumber(i_concert_number, out o_error))
            {
                return @"";
            }

            return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetBandName(i_concert_number));

        } // GetBandName

        /// <summary>Returns false if concert number not exists</summary>
        public static bool CheckConcertNumber(int i_concert_number, out string o_error)
        {
            o_error = @"";

            int n_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

            if (i_concert_number <= 0 || i_concert_number > n_concerts)
            {
                o_error = NewsStrings.ErrMsgConcertNewsNumberNotNotValid;

                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion // Current season functions

        #region Get text functions

        /// <summary>Returns the current news header</summary>
        static public string GetNewsHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsHeader(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news content</summary>
        static public string GetNewsContent() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsContent(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news image URL</summary>
        static public string GetNewsImage() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsImage(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news image width</summary>
        static public string GetNewsImageWidth() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsImageWidth(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news image caption</summary>
        static public string GetNewsImageCaption() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsImageCaption(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news image title</summary>
        static public string GetNewsImageTitle() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsImageTitle(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news link (URL)</summary>
        static public string GetNewsLink() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsLink(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news link caption</summary>
        static public string GetNewsLinkCaption() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsLinkCaption(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news eamail subject/summary>
        static public string GetNewsEmailSubject() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsEmailSubject(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news email text</summary>
        static public string GetNewsEmailText() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsEmailText(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news email caption</summary>
        static public string GetNewsEmailCaption() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsEmailCaption(ActiveCurrentNewsNumber)); }

        /// <summary>Returns the current news test flag</summary>
        static public bool GetNewsTestFlagBool() { return JazzXml.GetNewsTestFlagBool(ActiveCurrentNewsNumber); }


        /// <summary>Returns the concert news concert number</summary>
        static public string GetConcertNewsNumber() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetConcertNewsNumber(ActiveConcertNewsNumber)); }

        /// <summary>Returns the concert news header</summary>
        static public string GetConcertNewsHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetConcertNewsHeader(ActiveConcertNewsNumber)); }

        /// <summary>Returns the concert news content</summary>
        static public string GetConcertNewsContent() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetConcertNewsContent(ActiveConcertNewsNumber)); }

        /// <summary>Returns the concert current news test flag</summary>
        static public bool GetConcertNewsTestFlagBool() { return JazzXml.GetConcertNewsTestFlagBool(ActiveConcertNewsNumber); }

        /// <summary>Returns the concert current news cancelled flag</summary>
        static public bool GetConcertNewsCancelledFlagBool() { return JazzXml.GetConcertNewsCancelledFlagBool(ActiveConcertNewsNumber); }

        #endregion // Get text functions

        #region Get date functions

        /// <summary>Returns the concert news start year</summary>
        static public int GetNewsStartYearInt()
        {
            int start_year_int = 2000;

            if (ActiveCurrentNewsNumber == 0)
            {
                return start_year_int;
            }

            string start_year_str = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsStartYear(ActiveCurrentNewsNumber));

            if (start_year_str.Length > 0)
            {
                start_year_int = Int32.Parse(start_year_str);
            }

            return start_year_int;

        } // GetNewsStartYearInt

        /// <summary>Returns the concert news start month</summary>
        static public int GetNewsStartMonthInt()
        {
            int start_month_int = 1;

            if (ActiveCurrentNewsNumber == 0)
            {
                return start_month_int;
            }

            string start_month_str = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsStartMonth(ActiveCurrentNewsNumber));

            if (start_month_str.Length > 0)
            {
                start_month_int = Int32.Parse(start_month_str);
            }

            return start_month_int;

        } // GetNewsStartMonthInt

        /// <summary>Returns the concert news start day</summary>
        static public int GetNewsStartDayInt()
        {
            int start_day_int = 1;

            if (ActiveCurrentNewsNumber == 0)
            {
                return start_day_int;
            }

            string start_day_str = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsStartDay(ActiveCurrentNewsNumber));

            if (start_day_str.Length > 0)
            {
                start_day_int = Int32.Parse(start_day_str);
            }

            return start_day_int;

        } // GetNewsStartDayInt

        /// <summary>Returns the concert news end year</summary>
        static public int GetNewsEndYearInt()
        {
            int end_year_int = 2000;

            if (ActiveCurrentNewsNumber == 0)
            {
                return end_year_int;
            }

            string end_year_str = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsEndYear(ActiveCurrentNewsNumber));

            if (end_year_str.Length > 0)
            {
                end_year_int = Int32.Parse(end_year_str);
            }

            return end_year_int;

        } // GetNewsEndYearInt

        /// <summary>Returns the concert news end month</summary>
        static public int GetNewsEndMonthInt()
        {
            int end_month_int = 1;

            if (ActiveCurrentNewsNumber == 0)
            {
                return end_month_int;
            }

            string end_month_str = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsEndMonth(ActiveCurrentNewsNumber));

            if (end_month_str.Length > 0)
            {
                end_month_int = Int32.Parse(end_month_str);
            }

            return end_month_int;

        } // GetNewsEndMonthInt

        /// <summary>Returns the concert news end day</summary>
        static public int GetNewsEndDayInt()
        {
            int end_day_int = 1;

            if (ActiveCurrentNewsNumber == 0)
            {
                return end_day_int;
            }

            string end_day_str = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetNewsEndDay(ActiveCurrentNewsNumber));

            if (end_day_str.Length > 0)
            {
                end_day_int = Int32.Parse(end_day_str);
            }

            return end_day_int;

        } // GetNewsEndDayInt

        #endregion // Get date functions

        #region Write text functions

        /// <summary>Writes the current news header. </summary>
        static public bool WriteNewsHeader(string i_news_header_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsHeader", out o_error)) return false;

            // Undefined value will be set. Do not do it here
            JazzXml.SetNewsHeader(ActiveCurrentNewsNumber, i_news_header_str);

            return true;

        } // WriteNewsHeader

        /// <summary>Writes the current news content. Returns false if content not is set</summary>
        static public bool WriteNewsContent(string i_news_content_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsContent", out o_error)) return false;

            if (i_news_content_str.Trim().Length == 0)
            {
                o_error = NewsStrings.ErrMsgCurrentNewsContentNotSet;

                return false;
            }

            JazzXml.SetNewsContent(ActiveCurrentNewsNumber, i_news_content_str);

            return true;

        } // WriteNewsContent

        /// <summary>Writes the current news image URL </summary>
        static public bool WriteNewsImage(string i_news_image_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsImage", out o_error)) return false;

            JazzXml.SetNewsImage(ActiveCurrentNewsNumber, i_news_image_str);

            return true;

        } // WriteNewsImage

        /// <summary>Writes the current news image width </summary>
        static public bool WriteNewsImageWidth(string i_news_image_width_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsImageWidth", out o_error)) return false;

            JazzXml.SetNewsImageWidth(ActiveCurrentNewsNumber, i_news_image_width_str);

            return true;

        } // WriteNewsImageWidth

        /// <summary>Writes the current news image caption</summary>
        static public bool WriteNewsImageCaption(string i_news_image_caption_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsImageCaption", out o_error)) return false;

            JazzXml.SetNewsImageCaption(ActiveCurrentNewsNumber, i_news_image_caption_str);

            return true;

        } // WriteNewsImageCaption

        /// <summary>Writes the current news image title</summary>
        static public bool WriteNewsImageTitle(string i_news_image_title_str, out string o_error)
        {
            o_error = @"";

            JazzXml.SetNewsImageTitle(ActiveCurrentNewsNumber, i_news_image_title_str);

            return true;

        } // WriteNewsImageTitle

        /// <summary>Writes the current news link URL</summary>
        static public bool WriteNewsLink(string i_news_link_url_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsLink", out o_error)) return false;

            JazzXml.SetNewsLink(ActiveCurrentNewsNumber, i_news_link_url_str);

            return true;

        } // WriteNewsLink

        /// <summary>Writes the current news link caption</summary>
        static public bool WriteNewsLinkCaption(string i_news_link_caption_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsLinkCaption", out o_error)) return false;

            JazzXml.SetNewsLinkCaption(ActiveCurrentNewsNumber, i_news_link_caption_str);

            return true;

        } // WriteNewsLinkCaption

        /// <summary>Writes the current news email subject</summary>
        static public bool WriteNewsEmailSubject(string i_news_email_subject_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsEmailSubject", out o_error)) return false;

            JazzXml.SetNewsEmailSubject(ActiveCurrentNewsNumber, i_news_email_subject_str);

            return true;

        } // WriteNewsEmailSubject

        /// <summary>Writes the current news email text</summary>
        static public bool WriteNewsEmailText(string i_news_email_text_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsEmailText", out o_error)) return false;

            JazzXml.SetNewsEmailText(ActiveCurrentNewsNumber, i_news_email_text_str);

            return true;

        } // WriteNewsEmailText

        /// <summary>Writes the current news email caption</summary>
        static public bool WriteNewsEmailCaption(string i_news_email_caption_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsEmailCaption", out o_error)) return false;

            JazzXml.SetNewsEmailCaption(ActiveCurrentNewsNumber, i_news_email_caption_str);

            return true;

        } // WriteNewsEmailCaption

        /// <summary>Writes the current news test flag</summary>
        static public bool WriteNewsTestFlag(bool i_news_test_flag_bool, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteNewsTestFlag", out o_error)) return false;

            JazzXml.SetNewsTestFlagBool(ActiveCurrentNewsNumber, i_news_test_flag_bool);

            return true;

        } // WriteNewsTestFlag


        /// <summary>Writes the concert news number</summary>
        static public bool WriteConcertNewsNumber(string i_concert_news_number_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveConcertNewsNumber("WriteConcertNewsNumber", out o_error)) return false;

            if (i_concert_news_number_str.Trim().Length == 0)
            {
                o_error = NewsStrings.ErrMsgConcertNewsNumberNotSet;

                return false;
            }

            int concert_news_number_int = Int32.Parse(i_concert_news_number_str);

            if (!CheckConcertNumber(concert_news_number_int, out o_error))
            {
                return false;
            }

            JazzXml.SetConcertNewsNumber(ActiveConcertNewsNumber, i_concert_news_number_str);

            return true;

        } // WriteConcertNewsNumber

        /// <summary>Writes the concert news header</summary>
        static public bool WriteConcertNewsHeader(string i_concert_news_header_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveConcertNewsNumber("WriteConcertNewsHeader", out o_error)) return false;

            JazzXml.SetConcertNewsHeader(ActiveConcertNewsNumber, i_concert_news_header_str);

            return true;

        } // WriteConcertNewsHeader

        /// <summary>Writes the concert news content. Returns false if content not is set.</summary>
        static public bool WriteConcertNewsContent(string i_concert_news_content_str, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveConcertNewsNumber("WriteConcertNewsContent", out o_error)) return false;

            if (i_concert_news_content_str.Trim().Length == 0)
            {
                o_error = NewsStrings.ErrMsgConcertNewsContentNotSet;

                return false;
            }

            JazzXml.SetConcertNewsContent(ActiveConcertNewsNumber, i_concert_news_content_str);

            return true;

        } // WriteConcertNewsContent

        /// <summary>Writes the concert news test flag</summary>
        static public bool WriteConcertNewsTestFlag(bool i_concert_news_test_flag_bool, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveConcertNewsNumber("WriteConcertNewsTestFlag", out o_error)) return false;

            JazzXml.SetConcertNewsTestFlagBool(ActiveConcertNewsNumber, i_concert_news_test_flag_bool);

            return true;

        } // WriteConcertNewsTestFlag

        /// <summary>Writes the concert news cancelled flag</summary>
        static public bool WriteConcertNewsCancelledFlag(bool i_concert_news_cancelled_flag_bool, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveConcertNewsNumber("WriteConcertNewsCancelledFlag", out o_error)) return false;

            JazzXml.SetConcertNewsCancelledFlagBool(ActiveConcertNewsNumber, i_concert_news_cancelled_flag_bool);

            return true;

        } // WriteConcertNewsCancelledFlag

        #endregion // Write text functions

        #region Write date functions

        /// <summary>Writes the date for the start date</summary>
        static public bool WriteDateStart(int i_concert_year, int i_concert_month, int i_concert_day, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteDateStart", out o_error)) return false;

            JazzXml.SetNewsStartYear(ActiveCurrentNewsNumber, i_concert_year.ToString());
            JazzXml.SetNewsStartMonth(ActiveCurrentNewsNumber, i_concert_month.ToString());
            JazzXml.SetNewsStartDay(ActiveCurrentNewsNumber, i_concert_day.ToString());

            return true;

        } // WriteDateStart

        /// <summary>Writes the date for the end date</summary>
        static public bool WriteDateEnd(int i_concert_year, int i_concert_month, int i_concert_day, out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("WriteDateEnd", out o_error)) return false;

            JazzXml.SetNewsEndYear(ActiveCurrentNewsNumber, i_concert_year.ToString());
            JazzXml.SetNewsEndMonth(ActiveCurrentNewsNumber, i_concert_month.ToString());
            JazzXml.SetNewsEndDay(ActiveCurrentNewsNumber, i_concert_day.ToString());

            return true;

        } // WriteDateEnd

        #endregion // Write date functions

        #region Delete news element

        /// <summary>Removes the active current news. Returns false for failure
        /// <para>1. Remove news element. Call of JazzXml.RemoveNewsElement.</para>
        /// </summary>
        public static bool RemoveNewsElement(out string o_error)
        {
            o_error = @"";

            if (!CheckActiveCurrentNewsNumber("RemoveNewsElement", out o_error)) return false;

            if (!JazzXml.RemoveNewsElement(ActiveCurrentNewsNumber, out o_error))
            {
                o_error = @"News.RemoveNewsElement JazzXml.RemoveConcertNewsElement failed " + o_error;

                return false;
            }

            return true;

        } // RemoveNewsElement

        /// <summary>Removes the active concert news. Returns false for failure
        /// <para>1. Remove news element. Call of JazzXml.RemoveConcertNewsElement.</para>
        /// </summary>
        public static bool RemoveConcertNewsElement(out string o_error)
        {
            o_error = @"";

            if (!CheckActiveConcertNewsNumber("RemoveConcertNewsElement", out o_error)) return false;

            if (!JazzXml.RemoveConcertNewsElement(ActiveConcertNewsNumber, out o_error))
            {
                o_error = @"News.RemoveConcertNewsElement JazzXml.RemoveConcertNewsElement failed " + o_error;

                return false;
            }

            return true;

        } // RemoveConcertNewsElement

        #endregion // Delete news element

        #region Add news element

        /// <summary>Adds a current news element. Returns false for failure
        /// <para>1. Add element. Call of JazzXml.AddCurrentNewsElement.</para>
        /// </summary>
        public static bool AddCurrentNewsElement(out string o_error)
        {
            o_error = @"";

            if (!JazzXml.AddCurrentNewsElement(out o_error))
            {
                o_error = @"News.AddCurrentNewsElement JazzXml.AddCurrentNewsElement failed " + o_error;

                return false;
            }

            return true;

        } // AddCurrentNewsElement

        /// <summary>Adds a concert news element. Returns false for failure
        /// <para>1. Add element. Call of JazzXml.AddConcertNewsElement.</para>
        /// </summary>
        public static bool AddConcertNewsElement(out string o_error)
        {
            o_error = @"";

            if (!JazzXml.AddConcertNewsElement(out o_error))
            {
                o_error = @"News.AddConcertNewsElement JazzXml.AddConcertNewsElement failed " + o_error;

                return false;
            }

            return true;

        } // AddConcertNewsElement

        #endregion // Add news element

        #region Check functions

        /// <summary>Check that only one of the news shall be shown in the Homepage test version.
        /// Returns true if the concert test flag can be set to true</summary>
        static public bool concertNewsTestFlagCanBeSetToTrue(bool i_b_test_flag, out string o_error)
        {
            o_error = @"";

            if (false == i_b_test_flag)
            {
                return true;
            }

            string error_message = @"";

            int n_concert_news = JazzXml.GetNumberOfConcertNews(out error_message);

            int test_flag_news_number = 0;

            for (int news_number = 1; news_number <= n_concert_news; news_number++)
            {
                bool current_test_flag = JazzXml.GetNewsTestFlagBool(news_number);

                if (current_test_flag)
                {
                    if (test_flag_news_number > 0)
                    {
                        o_error = @"News.concertNewsTestFlagCanBeSetToTrue More than one test flag is set to true";

                        return false;
                    }

                    test_flag_news_number = news_number;

                }
            }

            if (test_flag_news_number == 0)
            {
                return true;
            }

            if (test_flag_news_number == ActiveCurrentNewsNumber)
            {
                return true;
            }
            else
            {
                string news_header = JazzXml.GetNewsHeader(test_flag_news_number);

                o_error = NewsStrings.ErrMsgConcertNewsRemoveTestFlagForNewsItem + news_header;

                return false;
            }

        } // concertNewsTestFlagCanBeSetToTrue

        #endregion // Check functions

        #region Utility functions

        /// <summary>Returns false if active current news number is zero</summary>
        static private bool CheckActiveCurrentNewsNumber(string i_function_name, out string o_error)
        {
            o_error = @"";

            if (ActiveCurrentNewsNumber == 0)
            {
                o_error = @"News." + i_function_name + @" Programming error. ActiveCurrentNewsNumber= 0";

                return false;
            }

            return true;

        } // CheckActiveCurrentNewsNumber

        /// <summary>Returns false if active concert news number is zero</summary>
        static private bool CheckActiveConcertNewsNumber(string i_function_name, out string o_error)
        {
            o_error = @"";

            if (ActiveConcertNewsNumber == 0)
            {
                o_error = @"News." + i_function_name + @" Programming error. ActiveConcertNewsNumber= 0";

                return false;
            }

            return true;

        } // CheckActiveConcertNewsNumber

        #endregion // Utility functions

    } // News

} // namespace
