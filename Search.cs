using JazzApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Has functions for search in season programs (JazzProgramm_aaaa_ssss.xml) and holds results from the search
    /// <para>Functions in class JazzSearch are called. In JazzMobile the class SearchPage is calling the same JazzSearch functions</para>
    /// <para></para>
    /// <para></para>
    /// <para></para>
    /// </summary>
    public class Search
    {
        #region Member variables

        /// <summary>Defines the number of text search results in a batch that shall be returned, i.e. the maximum size of the returned  arrays</summary>
        static private int m_n_text_search_results = 100;
        /// <summary>Get the number of text search results in a batch that shall be returned, i.e. the maximum size of the returned  arrays</summary>
        public int ResultBatchSize { get { return m_n_text_search_results; }  }

        /// <summary>Number of batches from the text search with function JazzSearch.Execute</summary>
        private static int m_n_text_search_result_batches = -12345;
        /// <summary>Get and set the number of batches from the text search with function JazzSearch.Execute</summary>
        public static int NumberBatches { get { return m_n_text_search_result_batches; } set { m_n_text_search_result_batches = value; } }

        #endregion // Member variables

        /// <summary>Constructor initializes JazzXml objects
        /// <para>1. Create XML objects corresponding to all the XML files JazzProgramm_aaaa_ssss.xml. Call of JazzXml.InitXmlAllSeasons</para>
        /// <para>2. Set the batch size for the text search with function JazzSearch.Execute. Call of JazzSearch.SetResultBatchSize(ResultBatchSize).</para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name=""></param>
        public Search()
        {
            if (!JazzXml.SeasonDocumentsInitialized())
            {
                JazzXml.InitXmlAllSeasons();
            }

            string error_message = @"";
            if (!PhotoMain.InitXml(out error_message))
            {
                return;
            }

            JazzSearch.SetResultBatchSize(ResultBatchSize);
            NumberBatches = 0;

        } // Constructor

        #region Search in seasons programs

        /// <summary>Search in season programs (JazzProgramm_aaaa_ssss.xml)
        /// <para>1. Create XML objects corresponding to all the XML files JazzProgramm_aaaa_ssss.xml. Call of JazzXml.InitXmlAllSeasons</para>
        /// <para>2. Set the batch size for the text search with function JazzSearch.Execute. Call of JazzSearch.SetResultBatchSize(ResultBatchSize).</para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_input">Input data for the search (object SearchInput)</param>
        /// <param name="o_results">Array of result SearchResult objects</param>
        /// <param name="o_error">Error message</param>
        public bool Execute(SearchInput i_input, out SearchResult[] o_results, out string o_error)
        {
            o_error = @"";
            o_results = null;

            XDocument current_season_document = JazzXml.GetDocumentCurrent();
            if (null == current_season_document)
            {
                o_error = @"Search.Execute current_season_document is null";
                return false;
            }

            bool b_member_login = true;
            XDocument[] season_documents = JazzXml.GetAvailableSeasonDocuments(b_member_login);
            if (null == season_documents)
            {
                o_error = @"Search.Execute season_documents is null";
                return false;
            }
            if (0 == season_documents.Length)
            {
                o_error = @"Search.Execute season_documents has no elements";
                return false;
            }

            ArrayList results_array = new ArrayList();

            for (int i_doc_index = season_documents.Length - 1; i_doc_index >= 0; i_doc_index--)
            {
                JazzXml.SetDocumentCurrent(season_documents[i_doc_index]);

                int number_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

                for (int concert_number=1; concert_number<=number_concerts; concert_number++)
                {
                    SearchResult search_result = null;
                    if (!SearchConcert.Execute(i_input, concert_number, out search_result, out o_error))
                    {
                        o_error = @"Search.Execute SearchConcert.Execute failed " + o_error;
                        return false;
                    }

                    if (search_result != null)
                    {
                        results_array.Add(search_result);
                    }

                } // concert_number

            } // i_doc_index


            o_results = (SearchResult[])results_array.ToArray(typeof(SearchResult));

            JazzXml.SetDocumentCurrent(current_season_document);

            return true;

        } // Execute

        #endregion // Search in seasons programs

        #region Search in photo galleries

        /// <summary>Search in the photo galleries (JazzGalerieEin.xml and JazzGalerieZwei.xml)
        /// <para>Search is only made if there is a ZIP file</para>
        /// <para>Empty input search string will return all objects with a ZIP file</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_search_str">Search string</param>
        /// <param name="o_results">Array of result JazzPhoto objects</param>
        /// <param name="o_error">Error message</param>
        public bool ExecuteGalleries(string i_search_str, out JazzPhoto[] o_results, out string o_error)
        {
            o_error = @"";
            o_results = null;

            ArrayList results_array = new ArrayList();

            for (int i_gallery=1; i_gallery<=2; i_gallery++)
            {
                int number_seasons = -12345;

                bool b_photo_one = true;
                if (2 == i_gallery)
                    b_photo_one = false;

                number_seasons = JazzXml.GetNumberOfPhotoSeasons(b_photo_one, out o_error);
                if (number_seasons < 0)
                {
                    o_error = @"Search.ExecuteGalleries number_seasons < 0";
                    return false;
                }

                for (int season_number = 1; season_number <= number_seasons; season_number++)
                {
                    JazzPhoto[] photo_objects = null;

                    int number_concerts = JazzXml.GetNumberOfPhotoConcerts(b_photo_one, season_number, out o_error);
                    if (number_concerts < 0)
                    {
                        o_error = @"Search.ExecuteGalleries number_concerts < 0";
                        return false;
                    }

                    if (1 == i_gallery)
                    {
                        photo_objects = JazzXml.GetPhotoOneObjects(season_number, out o_error);
                    }
                    else
                    {
                        photo_objects = JazzXml.GetPhotoTwoObjects(season_number, out o_error);
                    }
                    if (null == photo_objects)
                    {
                        o_error = @"Search.ExecuteGalleries photo_objects is null";
                        return false;
                    }

                    for (int concert_number = 1; concert_number <= number_concerts; concert_number++)
                    {
                        JazzPhoto current_photo = photo_objects[concert_number - 1];

                        JazzPhoto current_result = ExecutePhoto(i_search_str, current_photo, out o_error);
                        if (current_result != null)
                        {
                            results_array.Add(current_result);
                        }

                    } // concert_number


                } // season_number


            } // i_gallery


            o_results = (JazzPhoto[])results_array.ToArray(typeof(JazzPhoto));

            return true;

        } // ExecuteGalleries

        /// <summary>Search in one photo gallery object (JazzPhoto)
        /// <para>A result JazzPhoto is returned if there is a hit</para>>
        /// </summary>
        /// <param name="i_search_str">Search string</param>
        /// <param name="o_error">Error message</param>
        private static JazzPhoto ExecutePhoto(string i_search_str, JazzPhoto i_photo, out string o_error)
        {
            o_error = @"";
            JazzPhoto ret_result = null;

            // Only with ZIP file
            if (i_photo.ZipName.Length == 0)
                return ret_result;

            // Empty string is always a hit
            if (i_search_str.Length == 0)
            {
                ret_result = new JazzPhoto();
                ret_result = i_photo;
                return ret_result;
            }

            ret_result = TextContains(i_search_str, i_photo.BandName, i_photo);
            if (ret_result != null)
                return ret_result;

            ret_result = TextContains(i_search_str, i_photo.TextOne, i_photo);
            if (ret_result != null)
                return ret_result;

            ret_result = TextContains(i_search_str, i_photo.TextTwo, i_photo);
            if (ret_result != null)
                return ret_result;

            ret_result = TextContains(i_search_str, i_photo.TextThree, i_photo);
            if (ret_result != null)
                return ret_result;

            ret_result = TextContains(i_search_str, i_photo.TextFour, i_photo);
            if (ret_result != null)
                return ret_result;

            ret_result = TextContains(i_search_str, i_photo.TextFive, i_photo);
            if (ret_result != null)
                return ret_result;

            ret_result = TextContains(i_search_str, i_photo.TextSix, i_photo);
            if (ret_result != null)
                return ret_result;

            ret_result = TextContains(i_search_str, i_photo.TextSeven, i_photo);
            if (ret_result != null)
                return ret_result;

            ret_result = TextContains(i_search_str, i_photo.TextEight, i_photo);
            if (ret_result != null)
                return ret_result;

            ret_result = TextContains(i_search_str, i_photo.TextNine, i_photo);
            if (ret_result != null)
                return ret_result;

            ret_result = TextContains(i_search_str, i_photo.Year, i_photo);
            if (ret_result != null)
                return ret_result;


            o_error = @"Search.ExecutePhoto No hit";

            return ret_result;

        } // ExecutePhoto

        /// <summary>Returns a result object (JazzPhoto) if there is a "hit"
        /// <para></para>
        /// </summary>
        /// <param name="i_search_str">Search string</param>
        /// <param name="i_photo_str">String from a member parameter in JazzPhoto</param>
        /// <param name="o_error">Error message</param>
        private static JazzPhoto TextContains(string i_search_str, string i_photo_str, JazzPhoto i_photo)
        {
            JazzPhoto ret_photo = null;

            // bool contains = Regex.IsMatch("StRiNG to search", "string", RegexOptions.IgnoreCase);
            // StringComparison.OrdinalIgnoreCase
            // StringComparison comp = StringComparison.Ordinal;

            //StringComparison comp = StringComparison.OrdinalIgnoreCase;
            //i_photo_str.Contains(i_search_str)

            if (Regex.IsMatch(i_photo_str, i_search_str, RegexOptions.IgnoreCase))
            {
                ret_photo = new JazzPhoto();

                ret_photo = i_photo;
            }

            return ret_photo;

        } // TextContains


        #endregion // Search in photo galleries

        #region Search as in the mobile app

        /// <summary>Execute text search (the way it is done in the mobile telephone)
        /// <para>1. Call of JazzSearch.Execute</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_search_string">Search string</param>
        /// <param name="i_b_musician">Flag telling if the search shall include musician names</param>
        /// <param name="i_b_band">Flag telling if the search shall include band names</param>
        /// <param name="i_b_text">Flag telling if the search shall include concert texts</param>
        /// <param name="i_b_member_login">Flag telling if the search shall include non-published concerts (i.e. information availbale only for the members)</param>
        /// <param name="o_error">Error message</param>
        public bool ExecuteMusicianBandText(string i_search_string, bool i_b_musician, bool i_b_band, bool i_b_text, bool i_b_member_login, out string o_error)
        {
            o_error = @"";

            NumberBatches = 0;

            string search_string_trimmed = i_search_string.Trim();
            if (search_string_trimmed.Length == 0)
            {
                o_error = @"Search.ExecuteMusicianBandText Search string is empty";
                return false;
            }

            NumberBatches = JazzSearch.Execute(search_string_trimmed, i_b_musician, i_b_band, i_b_text, i_b_member_login);

            return true;

        } // ExecuteMusicianBandText

        /// <summary>Get the result from the text search
        /// <para>1. Call of JazzSearch.GetBatchStrings</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_index_batch">Result batch index</param>
        /// <param name="o_date_year_band_array"String array with date, year and band name</param>
        /// <param name="o_error">Error message</param>
        public bool ResultMusicianBandText(int i_index_batch, out string[] o_date_year_band_array, out string o_error)
        {
            o_error = @"";

            o_date_year_band_array = null;

            if (i_index_batch < 0)
            {
                o_error = @"Search.ResultMusicianBandText i_index_batch= " + i_index_batch.ToString() + @" < 0 ";
                return false;
            }

            if (0 == NumberBatches)
            {
                o_error = @"Search.ResultMusicianBandText No results or Search.ExecuteMusicianBandText is not called";
                return false;
            }

            if (i_index_batch >= NumberBatches)
            {
                o_error = @"Search.ResultMusicianBandText i_index_batch= " + i_index_batch.ToString() + @" >= NumberBatches= " + NumberBatches.ToString();
                return false;
            }

            o_date_year_band_array = JazzSearch.GetBatchStrings(i_index_batch);

            return true;

        } // ResultMusicianBandText

        #endregion // Search as in the mobile app

    } // Search

    /// <summary>Holds input data for a search
    /// <para>All the search flags have the default values false</para>
    /// </summary>
    public class SearchInput
    {
        /// <summary>Search string</summary>
        private string m_search_str = @"";
        /// <summary>Get and set search string</summary>
        public string SearchString { get { return m_search_str; } set { m_search_str = value; } }

        /// <summary>Flag telling that the search criterion is if an element has a value or not, i.e. the search shall not be made with the SearchString (m_search_str)</summary>
        private bool m_flag_element_set = false;
        /// <summary>Get and set flag telling that the search criterion is if an element has a value or not, i.e. the search shall not be made with the SearchString (m_search_str)</summary>
        public bool FlagIsElementSet { get { return m_flag_element_set; } set { m_flag_element_set = value; } }

        /// <summary>Flag telling if the search shall include musician names</summary>
        private bool m_flag_musician = false;
        /// <summary>Get and set flag telling if the search shall include musician names</summary>
        public bool FlagMusician { get { return m_flag_musician; } set { m_flag_musician = value; } }

        /// <summary>Flag telling if the search shall include band names</summary>
        private bool m_flag_band = false;
        /// <summary>Get and set flag telling if the search shall include band names</summary>
        public bool FlagBand { get { return m_flag_band; } set { m_flag_band = value; } }

        /// <summary>Flag telling if the search shall include concert texts</summary>
        private bool m_flag_text = false;
        /// <summary>Get and set flag telling if the search shall include concert texts</summary>
        public bool FlagText { get { return m_flag_text; } set { m_flag_text = value; } }

        /// <summary>Flag telling if the search shall include photo gallery one name/path</summary>
        private bool m_flag_photo_one = false;
        /// <summary>Get and set flag telling if the search shall include photo gallery one name/path</summary>
        public bool FlagPhotoOne { get { return m_flag_photo_one; } set { m_flag_photo_one = value; } }

        /// <summary>Flag telling if the search shall include photo gallery two</summary>
        private bool m_flag_photo_two = false;
        /// <summary>Get and set flag telling if the search shall include photo gallery two name/path</summary>
        public bool FlagPhotoTwo { get { return m_flag_photo_two; } set { m_flag_photo_two = value; } }

        /// <summary>Flag telling if the search shall include photo zip file name one</summary>
        private bool m_flag_zip_file_one = false;
        /// <summary>Get and set flag telling if the search shall include photo zip file name one</summary>
        public bool FlagZipFileOne { get { return m_flag_zip_file_one; } set { m_flag_zip_file_one = value; } }

        /// <summary>Flag telling if the search shall include photo zip file name two</summary>
        private bool m_flag_zip_file_two = false;
        /// <summary>Get and set flag telling if the search shall include photo zip file name two</summary>
        public bool FlagZipFileTwo { get { return m_flag_zip_file_two; } set { m_flag_zip_file_two = value; } }

    } // SearchInput

    /// <summary>Search execute functions for a concert
    /// <para></para>
    /// </summary>
    public static class SearchConcert
    {
        /// <summary>Get the result from the text search
        /// <para>Call of ExecMusician, ExecBandName, ExecTexts, ExecPhotoOne and ExecPhotoTwo.</para>
        /// <para>For a hit create and set the output object. Call of GetResult.</para>
        /// </summary>
        /// <param name="i_search_input">Input data for the search</param>
        /// <param name="i_concert_number>"Concert number</param>
        /// <param name="o_result>"Result from the search</param>
        /// <param name="o_error">Error message</param>
        public static bool Execute(SearchInput i_search_input, int i_concert_number, out SearchResult o_result, out string o_error)
        {
            o_error = @"";
            o_result = null;

            if (ExecMusician(i_search_input, i_concert_number))
            {
                o_result = GetResult(i_concert_number);
                return true;
            }

            if (ExecBandName(i_search_input, i_concert_number))
            {
                o_result = GetResult(i_concert_number);
                return true;
            }

            if (ExecTexts(i_search_input, i_concert_number))
            {
                o_result = GetResult(i_concert_number);
                return true;
            }

            if (ExecPhotoOne(i_search_input, i_concert_number))
            {
                o_result = GetResult(i_concert_number);
                return true;
            }

            if (ExecPhotoTwo(i_search_input, i_concert_number))
            {
                o_result = GetResult(i_concert_number);
                return true;
            }

            if (ExecZipOne(i_search_input, i_concert_number))
            {
                o_result = GetResult(i_concert_number);
                return true;
            }

            if (ExecZipTwo(i_search_input, i_concert_number))
            {
                o_result = GetResult(i_concert_number);
                return true;
            }

            return true;

        } // Execute

        /// <summary>Returns a result object with set concert data</summary>
        /// <param name="i_search_input">Input data for the search</param>
        /// <param name="i_concert_number>"Concert number</param>
        private static SearchResult GetResult(int i_concert_number)
        {
            SearchResult ret_result = new SearchResult();

            ret_result.BandName = EmptyStringIfValueNotYetSet(JazzXml.GetBandName(i_concert_number));

            ret_result.Year = EmptyStringIfValueNotYetSet(JazzXml.GetYear(i_concert_number));
            ret_result.Month = EmptyStringIfValueNotYetSet(JazzXml.GetMonth(i_concert_number));
            ret_result.Day = EmptyStringIfValueNotYetSet(JazzXml.GetDay(i_concert_number));

            ret_result.ConcertNumber = i_concert_number.ToString();

            ret_result.GalleryPathOne = EmptyStringIfValueNotYetSet(JazzXml.GetPhotoGalleryOne(i_concert_number));
            ret_result.GalleryPathTwo = EmptyStringIfValueNotYetSet(JazzXml.GetPhotoGalleryTwo(i_concert_number));

            ret_result.ZipNameOne = EmptyStringIfValueNotYetSet(JazzXml.GetPhotoGalleryOneZip(i_concert_number));
            ret_result.ZipNameTwo = EmptyStringIfValueNotYetSet(JazzXml.GetPhotoGalleryTwoZip(i_concert_number));

            ret_result.StartYearSeason = EmptyStringIfValueNotYetSet(JazzXml.GetYearAutum());

            return ret_result;

        } // GetResult


        /// <summary>Returns true if the search criterion is fulfilled</summary>
        /// <param name="i_search_input">Input data for the search</param>
        /// <param name="i_value_str>"XML element value</param>
        private static bool CriterionFulfilled(SearchInput i_search_input, string i_value_str)
        {
            string value_str = EmptyStringIfValueNotYetSet(i_value_str);

            if (i_search_input.FlagIsElementSet)
            {
                if (value_str.Trim().Length > 0)
                {
                    return true;
                }
            }
            else
            {
                if (value_str.Contains(i_search_input.SearchString))
                {
                    return true;
                }
            }

            return false;

        } // CriterionFulfilled

        /// <summary>Returns true if search string is contained in the musician names</summary>
        /// <param name="i_search_input">Input data for the search</param>
        /// <param name="i_concert_number>"Concert number</param>
        private static bool ExecMusician(SearchInput i_search_input, int i_concert_number)
        {
            if (!i_search_input.FlagMusician)
                return false;

            int n_number_musicians = JazzXml.GetNumberMusicians(i_concert_number);

            for (int index_musician=0; index_musician<n_number_musicians; index_musician++)
            {
                string musician_name = JazzXml.GetMusicianName(i_concert_number, index_musician + 1);

                if (CriterionFulfilled(i_search_input, musician_name))
                {
                    return true;
                }

            }

            return false;
        } // ExecMusician

        /// <summary>Returns true if search string is contained in the band name</summary>
        /// <param name="i_search_input">Input data for the search</param>
        /// <param name="i_concert_number>"Concert number</param>
        private static bool ExecBandName(SearchInput i_search_input, int i_concert_number)
        {
            if (!i_search_input.FlagBand)
                return false;

            string band_name = JazzXml.GetBandName(i_concert_number);

            if (CriterionFulfilled(i_search_input, band_name))
            {
                return true;
            }
            else
            {
                return false;
            }

        } // ExecBandName

        /// <summary>Returns true if search string is contained in the concert texts</summary>
        /// <param name="i_search_input">Input data for the search</param>
        /// <param name="i_concert_number>"Concert number</param>
        private static bool ExecTexts(SearchInput i_search_input, int i_concert_number)
        {
            if (!i_search_input.FlagText)
                return false;

            string short_text = JazzXml.GetShortText(i_concert_number);

            string add_text = JazzXml.GetAdditionalText(i_concert_number);

            if (CriterionFulfilled(i_search_input, short_text) || CriterionFulfilled(i_search_input, add_text))
            {
                return true;
            }
            else
            {
                return false;
            }

        } // ExecTexts

        /// <summary>Returns true if search string is contained in the photo gallery one file name</summary>
        /// <param name="i_search_input">Input data for the search</param>
        /// <param name="i_concert_number>"Concert number</param>
        private static bool ExecPhotoOne(SearchInput i_search_input, int i_concert_number)
        {
            if (!i_search_input.FlagPhotoOne)
                return false;

            string gallery_one_name = JazzXml.GetPhotoGalleryOne(i_concert_number);

            if (CriterionFulfilled(i_search_input, gallery_one_name))
            {
                return true;
            }
            else
            {
                return false;
            }

        } // ExecPhotoOne

        /// <summary>Returns true if search string is contained in the photo gallery one file name</summary>
        /// <param name="i_search_input">Input data for the search</param>
        /// <param name="i_concert_number>"Concert number</param>
        private static bool ExecPhotoTwo(SearchInput i_search_input, int i_concert_number)
        {
            if (!i_search_input.FlagPhotoTwo)
                return false;

            string gallery_two_name = JazzXml.GetPhotoGalleryTwo(i_concert_number);

            if (CriterionFulfilled(i_search_input, gallery_two_name))
            {
                return true;
            }
            else
            {
                return false;
            }

        } // ExecPhotoTwo

        /// <summary>Returns true if search string is contained in the zip file one name</summary>
        /// <param name="i_search_input">Input data for the search</param>
        /// <param name="i_concert_number>"Concert number</param>
        private static bool ExecZipOne(SearchInput i_search_input, int i_concert_number)
        {
            if (!i_search_input.FlagZipFileOne)
                return false;

            string zip_one_name = JazzXml.GetPhotoGalleryOneZip(i_concert_number);

            if (CriterionFulfilled(i_search_input, zip_one_name))
            {
                return true;
            }
            else
            {
                return false;
            }

        } // ExecZipOne

        /// <summary>Returns true if search string is contained in the zip file two name</summary>
        /// <param name="i_search_input">Input data for the search</param>
        /// <param name="i_concert_number>"Concert number</param>
        private static bool ExecZipTwo(SearchInput i_search_input, int i_concert_number)
        {
            if (!i_search_input.FlagZipFileTwo)
                return false;

            string zip_two_name = JazzXml.GetPhotoGalleryTwoZip(i_concert_number);

            if (CriterionFulfilled(i_search_input, zip_two_name))
            {
                return true;
            }
            else
            {
                return false;
            }

        } // ExecZipTwo

        /// <summary>Returns empty string if value not yet is set</summary>
        private static string EmptyStringIfValueNotYetSet(string i_value)
        {
            string ret_string = i_value;

            if (!JazzXml.XmlNodeValueIsSet(i_value))
            {
                ret_string = @"";
            }

            return ret_string;

        } // EmptyStringIfValueNotYetSet

    } // SearchConcert


    /// <summary>Holds the result from a search 
    /// <para>Result is data from a concert</para>
    /// </summary>
    public class SearchResult
    {
        /// <summary>Band name</summary>
        private string m_band_name = @"";
        /// <summary>Get and set band name</summary>
        public string BandName { get { return m_band_name; } set { m_band_name = value; } }

        /// <summary>Year as string</summary>
        private string m_year_str = @"";
        /// <summary>Get and set year as string</summary>
        public string Year { get { return m_year_str; } set { m_year_str = value; } }

        /// <summary>Month as string</summary>
        private string m_month_str = @"";
        /// <summary>Get and set month as string</summary>
        public string Month { get { return m_month_str; } set { m_month_str = value; } }

        /// <summary>Day as string</summary>
        private string m_day_str = @"";
        /// <summary>Get and set day as string</summary>
        public string Day { get { return m_day_str; } set { m_day_str = value; } }

        /// <summary>Gallery one path</summary>
        private string m_gallery_path_one = @"";
        /// <summary>Get and set gallery one path</summary>
        public string GalleryPathOne { get { return m_gallery_path_one; } set { m_gallery_path_one = value; } }

        /// <summary>Gallery one path</summary>
        private string m_gallery_path_two = @"";
        /// <summary>Get and set gallery one path</summary>
        public string GalleryPathTwo { get { return m_gallery_path_two; } set { m_gallery_path_two = value; } }

        /// <summary>Zip file one name</summary>
        private string m_zip_name_one = @"";
        /// <summary>Get and set zip file one name</summary>
        public string ZipNameOne { get { return m_zip_name_one; } set { m_zip_name_one = value; } }

        /// <summary>Zip file two name</summary>
        private string m_zip_name_two = @"";
        /// <summary>Get and set zip file two name</summary>
        public string ZipNameTwo { get { return m_zip_name_two; } set { m_zip_name_two = value; } }

        /// <summary>Concert number as string</summary>
        private string m_concert_number_str = @"";
        /// <summary>Get and set concert number as string</summary>
        public string ConcertNumber { get { return m_concert_number_str; } set { m_concert_number_str = value; } }

        /// <summary>Season start year as a string</summary>
        private string m_start_year_season_str = @"";
        /// <summary>Get and set season start year as string</summary>
        public string StartYearSeason { get { return m_start_year_season_str; } set { m_start_year_season_str = value; } }

    } // SearchResult


} // namespace
