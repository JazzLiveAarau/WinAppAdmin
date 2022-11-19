using JazzApp;

namespace JazzAppAdmin
{
    /// <summary>Musician (form) variables and functions</summary>
    public static class Musician
    {
        #region Concert and musician number

        /// <summary>Concert number</summary>
        static private int m_concert = -12345;

        /// <summary>Musician number</summary>
        static private int m_musician = -12345;

        /// <summary>Set concert number</summary>
        static public void SetConcertNumber(int i_concert) { m_concert = i_concert; }

        /// <summary>Set musician number</summary>
        static public void SetMusicianNumber(int i_musician) { m_musician = i_musician; }

        #endregion // Concert and musician number

        #region Write text functions

        /// <summary>Writes the name of the musician. Returns false if the musician name not is set</summary>
        static public bool WriteName(string i_musician_name, out string o_error)
        {
            o_error = @"";

            if (i_musician_name.Trim().Length == 0)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgMusicanNameNotSet;
                return false;
            }

            JazzXml.SetMusicianData(m_concert, m_musician, JazzXml.m_text_tags_musician[0], i_musician_name);

            return true;
        } // WriteName

        /// <summary>Writes the musician's instrument</summary>
        static public bool WriteInstrument(string i_musician_instrument, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMusicianData(m_concert, m_musician, JazzXml.m_text_tags_musician[1], i_musician_instrument);

            return true;
        } // WriteInstrument

        /// <summary>Writes the musician's text</summary>
        static public bool WriteText(string i_musician_text, out string o_error)
        {
            o_error = @"";

            JazzXml.SetMusicianData(m_concert, m_musician, JazzXml.m_text_tags_musician[2], i_musician_text);

            return true;
        } // WriteText

        /// <summary>Writes the musician's birth year</summary>
        static public bool WriteBirthYear(string i_musician_birth_year, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckYear(i_musician_birth_year, out o_error))
                return false;

            JazzXml.SetMusicianData(m_concert, m_musician, JazzXml.m_text_tags_musician[3], i_musician_birth_year.Trim());

            return true;
        } // WriteBirthYear

        /// <summary>Writes the musician's gender for male</summary>
        static public void WriteGenderMale()
        {
            JazzXml.SetMusicianData(m_concert, m_musician, JazzXml.m_text_tags_musician[4], JazzXml.GetGenderMaleValue());
        } // WriteGenderMale

        /// <summary>Writes the musician's gender for female</summary>
        static public void WriteGenderFemale()
        {
            JazzXml.SetMusicianData(m_concert, m_musician, JazzXml.m_text_tags_musician[4], JazzXml.GetGenderFemaleValue());
        } // WriteGenderFemale

        #endregion // Write text functions

        #region Write title functions

        /// <summary>Writes the title of the musician page</summary>
        static public void WritePageTitle(string i_musician_page_title)
        {
            JazzXml.SetTitleData(JazzXml.m_title_tags[0], i_musician_page_title);

        } // WritePageTitle
        #endregion // Write title functions

        #region Get text functions

        /// <summary>Returns the name of the musician</summary>
        static public string GetName()
        {
            string ret_name = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMusicianName(m_concert, m_musician));

            return ret_name;
        } // GetName

        /// <summary>Returns the musician instruments</summary>
        static public string GetInstrument()
        {
            string ret_instrument = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMusicianInstrument(m_concert, m_musician));

            return ret_instrument;
        } // GetInstrument

        /// <summary>Returns the musician text</summary>
        static public string GetText()
        {
            string ret_text = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMusicianText(m_concert, m_musician));

            return ret_text;
        } // GetText

        /// <summary>Returns the musician birth year</summary>
        static public string GetBirthYear()
        {
            string ret_year = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMusicianBirthYearStr(m_concert, m_musician));

            return ret_year;
        } // GetBirthYear

        /// <summary>Returns true if the musician gender is male</summary>
        static public bool IsGenderMale()
        {
            string musician_gender = JazzXml.GetMusicianGenderStr(m_concert, m_musician);

            if (!JazzXml.XmlNodeValueIsSet(musician_gender))
                return true;

            if (musician_gender.Equals(JazzXml.GetGenderMaleValue()))
                return true;
            else
                return false;

        } // GetGender

        #endregion // Get text functions

        #region Get tags functions

        /// <summary>Returns the XML tag for the page title</summary>
        static public string GetPageTitleTag()
        {
            return @"<" + JazzXml.m_title_tags[0] + @">";
        } // GetPageTitleTag

        #endregion // Get tags functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetTitleMusician()); }

        /// <summary>Returns the name title</summary>
        static public string GetTitleName() { return JazzAppAdminSettings.Default.GuiTextMusicianName; }

        /// <summary>Returns the instrument title</summary>
        static public string GetTitleInstrument() { return JazzAppAdminSettings.Default.GuiTextMusicianInstrument; }

        /// <summary>Returns the birth year title</summary>
        static public string GetTitleBirthYear() { return JazzAppAdminSettings.Default.GuiTextMusicianBirthYear; }

        /// <summary>Returns the mail title</summary>
        static public string GetTitleMail() { return JazzAppAdminSettings.Default.GuiTextMusicianMale; }

        /// <summary>Returns the femail title</summary>
        static public string GetTitleFemail() { return JazzAppAdminSettings.Default.GuiTextMusicianFemale; }

        #endregion // Get title and caps functions

        #region Utility functions
        /// <summary>Empty string if value not is set</summary>
        static private string NotYetSetValue(string i_string)
        {
            string ret_string = i_string;

            if (!JazzXml.XmlNodeValueIsSet(i_string))
                ret_string = @"";

            return ret_string;
        } // NotYetSetValue

        #endregion // Utility functions

    } // Musician
} // namespace
