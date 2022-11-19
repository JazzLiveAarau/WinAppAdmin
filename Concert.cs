using JazzApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Concert (form) variables and functions</summary>
    public static class Concert
    {
        #region Concert number

        /// <summary>Concert number</summary>
        static private int m_concert = -12345;

        /// <summary>Set concert number</summary>
        static public void SetConcertNumber(int i_concert) { m_concert = i_concert; }

        #endregion // Concert number

        #region Write text functions

        /// <summary>Writes the name of the band. Returns false if the band name not is set</summary>
        static public bool WriteBandName(string i_band_name, out string o_error)
        {
            o_error = @"";

            if (i_band_name.Trim().Length == 0)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgConcertNameNotSet;
                return false;
            }

            JazzXml.SetBandName(m_concert, i_band_name);

            bool b_check = checkModifyBandNameInDocumentsXml(i_band_name);

            return true;
        } // WriteName

        static private bool checkModifyBandNameInDocumentsXml(string i_band_name)
        {
            // TODO

            return true;

        } // checkModifyBandNameInDocumentsXml

        /// <summary>Writes the date for the concert</summary>
        static public bool WriteDate(int i_concert_year, int i_concert_month, int i_concert_day, out string o_error)
        {
            o_error = @"";

            JazzXml.SetYear(m_concert, i_concert_year.ToString());
            JazzXml.SetMonth(m_concert, i_concert_month.ToString());
            JazzXml.SetDay(m_concert, i_concert_day.ToString());
            string day_name = GetDayName(i_concert_year, i_concert_month, i_concert_day);
            JazzXml.SetDayName(m_concert, day_name);

            return true;
        } // WriteName

        /// <summary>Writes the start or the end time for the concert</summary>
        static public bool WriteTime(bool i_start, string i_time, out string o_error)
        {
            o_error = @"";

            string time_trim = i_time.Trim();

            int pos_colon = time_trim.IndexOf(':');
            if (pos_colon < 0)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgTimeWithoutColon + @" (" + i_time + @")"; ;
                return false;
            }

            string hour_str = time_trim.Substring(0, pos_colon);
            string minute_str = time_trim.Substring(pos_colon+1);

            if (!CheckTimeNumber(hour_str, out o_error))
                return false;

            if (!CheckTimeNumber(minute_str, out o_error))
                return false;

            if(i_start)
            {
                JazzXml.SetStartHour(m_concert, hour_str);
                JazzXml.SetStartMinute(m_concert, minute_str);
            }
            else
            {
                JazzXml.SetEndHour(m_concert, hour_str);
                JazzXml.SetEndMinute(m_concert, minute_str);
            }

            return true;

        } // WriteTime

        /// <summary>Writes the short text for the concert.</summary>
        static public bool WriteShortText(string i_short_text, out string o_error)
        {
            o_error = @"";

            JazzXml.SetShortText(m_concert, i_short_text);

            return true;
        } // WriteShortText

        /// <summary>Writes the additional text for the concert.</summary>
        static public bool WriteAdditionalText(string i_additional_text, out string o_error)
        {
            o_error = @"";

            JazzXml.SetAdditionalText(m_concert, i_additional_text);

            return true;
        } // WriteAdditionalText

        /// <summary>Writes the sound sample URL for the concert.</summary>
        static public bool WriteSoundSample(string i_sound_sample, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckFullPath(i_sound_sample, out o_error))
                return false;

            JazzXml.SetSoundSample(m_concert, i_sound_sample);

            return true;
        } // WriteSoundSample

        /// <summary>Writes the web site URL of the band.</summary>
        static public bool WriteBandWebsite(string i_band_website, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckFullPath(i_band_website, out o_error))
                return false;

            JazzXml.SetBandWebsite(m_concert, i_band_website);

            if (i_band_website.Length > 0)
            {
                if (!CreateWriteBandWebsiteQrCode(i_band_website, out o_error))
                    return false;
            }
            else
            {
                JazzXml.SetBandWebsiteQrCode(m_concert, @"");
            }
  
            return true;

        } // WriteBandWebSite

        /// <summary>
        /// Creates and writes the band website QR code
        /// </summary>
        /// <param name="i_band_website">Link to the band website</param>
        /// <param name="o_error">Weeor message</param>
        /// <returns>false for failure</returns>
        static public bool CreateWriteBandWebsiteQrCode(string i_band_website, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckFullPath(i_band_website, out o_error))
                return false;

            string error_msg = @"";

            SeasonDocInterface season_doc = new SeasonDocInterface();

            int autumn_year = JazzXml.GetYearAutumnInt();

            if (!season_doc.InitSetActiveDoc(autumn_year, out error_msg))
            {
                // Add error message TODO 2022-05-25
                return true; // Assume no error, just that it isn't possible for the input start year
            }

            string end_file_name_str = "_Website_QR_code";

            string file_extension = @"png";

            string file_name_qr_web = season_doc.GetFileNameWithConcertPath(m_concert, end_file_name_str, file_extension);

            string url_qr_web = season_doc.GetUrlToFileNameWithConcertPath(m_concert, end_file_name_str, file_extension);

            string name_temp_code_dir = FileUtil.GetFullNameLocalQrCodeDir();

            string file_name_no_ext = Path.GetFileNameWithoutExtension(file_name_qr_web);

            int image_size = 300;
            Bitmap bitmap_qr_code = QrCodeUtils.GenerateQrCodeImage(i_band_website, image_size, out error_msg);
            if (null == bitmap_qr_code)
            {
                o_error = "Concert.CreateWriteBandWebsiteQrCode QrCodeUtils.GenerateQrCodeImage failed " + error_msg;

                return false;
            }

            string mime_type = "png";
            string file_name_path = name_temp_code_dir + file_name_no_ext;
            if (!QrCodeUtils.SaveQrCode(bitmap_qr_code, file_name_path, mime_type, out error_msg))
            {
                o_error = "Concert.CreateWriteBandWebsiteQrCode QrCodeUtils.SaveQrCode failed " + error_msg;

                return false;
            }

            JazzFtp.Input ftp_upload_xml = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.UpLoadFile);

            ftp_upload_xml.LocalDirectory = FileUtil.GetQrCodeDir();
            ftp_upload_xml.LocalFileName = file_name_qr_web;

            ftp_upload_xml.ServerDirectory = season_doc.GetServerConcertPath(m_concert);
            ftp_upload_xml.ServerFileName = file_name_qr_web;

            JazzFtp.Result result_upload = JazzFtp.Execute.Run(ftp_upload_xml);

            if (!result_upload.Status)
            {
                o_error = @"Concert.CreateWriteBandWebsiteQrCode JazzFtp.Execute.Run (UpLoadFile) failed " + result_upload.ErrorMsg;
                return false;
            }

            JazzXml.SetBandWebsiteQrCode(m_concert, url_qr_web);

            return true;

        } // CreateWriteBandWebsiteQrCode

        /// <summary>Writes photo gallery one URL for the concert.</summary>
        static public bool WritePhotoGalleryOne(string i_photo_1, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckRelativePath(i_photo_1, out o_error))
                return false;

            JazzXml.SetPhotoGalleryOne(m_concert, i_photo_1);

            return true;
        } // WritePhotoGalleryOne

        /// <summary>Writes photo gallery two URL for the concert.</summary>
        static public bool WritePhotoGalleryTwo(string i_photo_2, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckRelativePath(i_photo_2, out o_error))
                return false;

            JazzXml.SetPhotoGalleryTwo(m_concert, i_photo_2);

            return true;
        } // WritePhotoGalleryTwo

        /// <summary>Writes photo gallery one ZIP URL for the concert.</summary>
        static public bool WritePhotoGalleryOneZip(string i_photo_zip_1, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckZipFileName(i_photo_zip_1, out o_error))
                return false;

            JazzXml.SetPhotoGalleryOneZip(m_concert, i_photo_zip_1);

            return true;
        } // WritePhotoGalleryOneZip

        /// <summary>Writes photo gallery two ZIP URL for the concert.</summary>
        static public bool WritePhotoGalleryTwoZip(string i_photo_zip_2, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckZipFileName(i_photo_zip_2, out o_error))
                return false;

            JazzXml.SetPhotoGalleryTwoZip(m_concert, i_photo_zip_2);

            return true;
        } // WritePhotoGalleryTwoZip

        /// <summary>Writes the small size poster.</summary>
        static public bool WritePosterSmallSize(string i_poster_small, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckRelativePath(i_poster_small, out o_error))
                return false;

            JazzXml.SetPosterSmallSize(m_concert, i_poster_small);

            return true;
        } // WritePosterSmallSize

        /// <summary>Writes the mid size poster.</summary>
        static public bool WritePosterMidSize(string i_poster_mid, out string o_error)
        {
            o_error = @"";

            if (!AdminUtils.CheckRelativePath(i_poster_mid, out o_error))
                return false;

            JazzXml.SetPosterMidSize(m_concert, i_poster_mid);

            return true;
        } // WritePosterMidSize

        /// <summary>Check time number</summary>
        static private bool CheckTimeNumber(string i_time, out string o_error)
        {
            o_error = @"";
            bool ret_check = true;

            if (i_time.Length == 0 || i_time.Length > 2)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgTimeTwoNumbers + @" (" + i_time + @")";
                return false;
            }

            int ret_status = JazzXml.ValidNumber(i_time);

            if (0 == ret_status)
            {
                ret_check = true;
            }
            else if (-1 == ret_status)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgAllCharsMustBeNumbers + @" (" + i_time + @")";
                ret_check = false;
            }
            else if (-2 == ret_status)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNumberCannotStartWithZero + @" (" + i_time + @")";
                ret_check = false;
            }
            else
            {
                o_error = @"Concert.CheckTimeNumber Error= " + ret_status.ToString() + @" (" + i_time + @")";
                ret_check = false;
            }

            if (!ret_check)
                return false;


            return ret_check;

        } // CheckTimeNumber



        #endregion // Write text functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetTitleConcert()); }

        /// <summary>Returns the name title</summary>
        static public string GetTitleName() { return JazzAppAdminSettings.Default.GuiTextConcertName; }

        /// <summary>Returns the date title</summary>
        static public string GetTitleDate() { return JazzAppAdminSettings.Default.GuiTextConcertDate; }

        /// <summary>Returns the start time title</summary>
        static public string GetTitleStartTime() { return JazzAppAdminSettings.Default.GuiTextConcertStartTime; }

        /// <summary>Returns the end time title</summary>
        static public string GetTitleEndTime() { return JazzAppAdminSettings.Default.GuiTextConcertEndTime; }

        /// <summary>Returns the short text title</summary>
        static public string GetTitleShortText() { return JazzAppAdminSettings.Default.GuiTextConcertShortText; }

        /// <summary>Returns the additional text title</summary>
        static public string GetTitleAdditionalText() { return JazzAppAdminSettings.Default.GuiTextConcertAdditionalText; }

        /// <summary>Returns the name of the day title</summary>
        static public string GetTitleDayName()
        {
            int concert_year = JazzXml.GetYearInt(m_concert);
            int concert_month = JazzXml.GetMonthInt(m_concert);
            int concert_day = JazzXml.GetDayInt(m_concert);

            string day_name = GetDayName(concert_year, concert_month, concert_day);

            return day_name;

        } // GetTitleDayName

        #endregion // Get title and caps functions

        #region Get text functions

        /// <summary>Returns the name of the band</summary>
        static public string GetBandName() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetBandName(m_concert)); }

        /// <summary>Returns the year for the concert</summary>
        static public string GetYear() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetYear(m_concert)); }

        /// <summary>Returns the month for the concert</summary>
        static public string GetMonth() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetMonth(m_concert)); }

        /// <summary>Returns the day for the concert</summary>
        static public string GetDay() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetDay(m_concert)); }

        /// <summary>Returns the year for the concert as integer</summary>
        static public int GetYearInt() { return JazzXml.GetYearInt(m_concert); }

        /// <summary>Returns the month for the concert as integer</summary>
        static public int GetMonthInt() { return JazzXml.GetMonthInt(m_concert); }

        /// <summary>Returns the day for the concert as integer</summary>
        static public int GetDayInt() { return JazzXml.GetDayInt(m_concert); }

        /// <summary>Returns the start hour for the concert</summary>
        static public string GetStartHour() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetStartHour(m_concert)); }

        /// <summary>Returns the start minute for the concert</summary>
        static public string GetStartMinute() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetStartMinute(m_concert)); }

        /// <summary>Returns the end hour for the concert</summary>
        static public string GetEndHour() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetEndHour(m_concert)); }

        /// <summary>Returns the end minute for the concert</summary>
        static public string GetEndMinute() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetEndMinute(m_concert)); }

        /// <summary>Returns the start time for the concert</summary>
        static public string GetStartTime() { return GetStartHour() + @":" + GetStartMinute(); }

        /// <summary>Returns the end time for the concert</summary>
        static public string GetEndTime() { return GetEndHour() + @":" + GetEndMinute(); }

        /// <summary>Returns the short text of the concert</summary>
        static public string GetShortText() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetShortText(m_concert)); }

        /// <summary>Returns the additional text of the concert</summary>
        static public string GetAdditionalText() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetAdditionalText(m_concert)); }

        /// <summary>Returns the sound sample URL for the concert</summary>
        static public string GetSoundSample() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetSoundSample(m_concert)); }

        /// <summary>Returns the band website URL for the concert</summary>
        static public string GetBandWebsite() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetBandWebsite(m_concert)); }

        /// <summary>Returns the sound sample URL QR code for the concert</summary>
        static public string GetSoundSampleQrCode() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetSoundSampleQrCode(m_concert)); }

        /// <summary>Returns the band website URL QR code for the concert</summary>
        static public string GetBandWebsiteQrCode() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetBandWebsiteQrCode(m_concert)); }

        /// <summary>Returns the photo gallery one URL for the concert</summary>
        static public string GetPhotoGalleryOne() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPhotoGalleryOne(m_concert)); }

        /// <summary>Returns the photo gallery two URL for the concert</summary>
        static public string GetPhotoGalleryTwo() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPhotoGalleryTwo(m_concert)); }

        /// <summary>Returns the photo gallery one URL for the concert</summary>
        static public string GetPhotoGalleryOneZip() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPhotoGalleryOneZip(m_concert)); }

        /// <summary>Returns the photo gallery two URL for the concert</summary>
        static public string GetPhotoGalleryTwoZip() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPhotoGalleryTwoZip(m_concert)); }

        /// <summary>Returns the URL to the small size poster</summary>
        static public string GetPosterSmallSize() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetPosterSmallSize(m_concert)); }

        /// <summary>Returns the URL to the mid size poster</summary>
        static public string GetPosterMidSize()
        {
            string ret_str = JazzXml.GetPosterMidSize(m_concert);
            ret_str = AdminUtils.RemoveJazzLiveAarauUrl(ret_str);
            return ret_str;
        } // GetPosterMidSize

        #endregion // Get text functions

        #region Utility functions
        /// <summary>returns true if the concert may be deleted, i.e. if it is a coming concert</summary>
        public static bool ConcertMayBeDeleted(out string o_message)
        {
            o_message = @"";

            bool b_passed = TimeUtil.PassedTime(GetYearInt(), GetMonthInt(), GetDayInt());

            if (b_passed)
            {
                o_message = JazzAppAdminSettings.Default.MsgPassedConcertCannotBeDeleted;
                return false;
            }

            return true;
        } // ConcertMayBeDeleted

        /// <summary>Returns the name of the day</summary>
        static public string GetDayName(int i_concert_year, int i_concert_month, int i_concert_day)
        {
            string day_name = TimeUtil.DayName(i_concert_year, i_concert_month, i_concert_day);

            return day_name;

        } // GetDayName

        #endregion // Utility functions

    } // Concert

} // namespace
