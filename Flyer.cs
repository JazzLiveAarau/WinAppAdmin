using JazzFtp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Variables and functions for update of web application Flyer
    /// <para>This is an execution class for the FlyerForm class.</para>
    /// </summary>
    public static class Flyer
    {
        #region Member variables

        /// <summary>Object that holds all data for the jazz documents that are defined by XML files</summary>
        private static JazzDocAll m_jazz_doc_all_flyer = null;
        /// <summary>Returns the object that holds all data for the jazz documents that are defined by XML files</summary>
        public static JazzDocAll DocAllFlyer { get { return m_jazz_doc_all_flyer; } set { m_jazz_doc_all_flyer = value; } }

        /// <summary>Name of the copied XML season programm file</summary>
        private static string m_file_name_copied_season_program = "SaisonProgramm.xml";

        /// <summary>Server directory name for web application Flyer</summary>
        private static string m_flyer_server_dir = "Flyer";

        /// <summary>Server subdirectory name for the application and season programs XML files</summary>
        private static string m_flyer_admin_xml_dir = "AdminXml";

        /// <summary>Server subdirectory name for the flyer XML edit files</summary>
        private static string m_flyer_edit_text_dir = "EditTexts";

        /// <summary>Server subdirectory name for the flyer XML edit original (created from season program) files</summary>
        private static string m_flyer_edit_text_original_dir = "SeasonProgramNotEditedXmlFiles";

        /// <summary>Name of the application file</summary>
        static private string m_application_xml_filename = "JazzApplication.xml";

        /// <summary>Name of the XML file with the names of the updated subdirectories</summary>
        static private string m_flyer_xml_subdirs_file_name = "SubDirectoryNames.xml";

        /// <summary>Name of the XML file with user names and passwords</summary>
        static private string m_flyer_xml_users_passwords_file_name = "UsersPasswords.xml";

        /// <summary>Name start part of the XML Edit file </summary>
        static private string m_flyer_xml_edit_file_name_start = "EditTextBand_";

        /// <summary>Name of the local directory where QR Code images are stored temporarely</summary>
        static private string m_dir_qr_code_name = "QRCodes";

        /// <summary>Name of the local directory where flyer images are stored temporarely</summary>
        static private string m_dir_flyer_images_name = "FlyerImages";

        /// <summary>Start part of the export flyer image name</summary>
        static private string m_start_part_export_flyer_image_name = "FlyerBild_";

        /// <summary>Path for image file "not-yet-set"</summary>
        static string m_path_not_yet_set_image = "www/Flyer/FlyerImages";

        /// <summary>Path for image file "not-yet-set"</summary>
        static string m_name_not_yet_set_image = "FlyerBild_Undefined.jpg";

        /// <summary>XML tag name subdirectories</summary>
        static private string m_tag_subdirectories = "SubdirectoryNames";

        /// <summary>XML tag name subdirectory</summary>
        static private string m_tag_subdirectory = "SubdirectoryName";

        /// <summary>XML tag name subdirectories</summary>
        static private string m_tag_users_passwords = "UserNamesPasswords";

        /// <summary>XML tag user name</summary>
        static private string m_tag_user_name = "UserName";

        /// <summary>XML tag user password</summary>
        static private string m_tag_user_password = "UserPassword";

        /// <summary>XML tag season start year</summary>
        static private string m_tag_season_start_year = "SeasonStartYear";

        /// <summary>XML tag concert texts</summary>
        static private string m_tag_xml_concert_texts = "ConcertTexts";

        /// <summary>XML tag musicians</summary>
        static private string m_tag_xml_musicians = "Musicians";

        /// <summary>XML tag musician</summary>
        static private string m_tag_xml_musician = "Musician";

        /// <summary>Start part user name</summary>
        static private string m_start_user_name = "Band";

        /// <summary>Start part user password</summary>
        static private string m_start_user_password = "musiker_";

        /// <summary>User name administrator</summary>
        static private string m_admin_name = "Administrator";

        /// <summary>User password administrator</summary>
        static private string m_admin_password = "admin";

        /// <summary>User name tester</summary>
        static private string m_tester_name = "Tester";

        /// <summary>User password for tester</summary>
        static private string m_tester_password = "admin";

        /// <summary>User name printer</summary>
        static private string m_printer_name = "Drucker";

        /// <summary>User password for printer</summary>
        static private string m_printer_password = "drucker";

        /// <summary>XML header</summary>
        static private string m_xml_subdirectory_header = "<?xml version='1.0' encoding='UTF-8'?>";

        /// <summary>XML comment</summary>
        static private string m_xml_subdirectory_comment = "<!-- JAZZ live AARAU Flyer List of updated subdirectories -->";

        /// <summary>XML comment</summary>
        static private string m_xml_users_passwords_comment = "<!-- JAZZ live AARAU Flyer List of users and passwords for login -->";

        /// <summary>XML comment</summary>
        static private string m_xml_edit_comment = "<!-- JAZZ live AARAU Flyer Texts for one concert -->";

        /// <summary>Returns new line</summary>
        static private string NewLine() { return "\r\n"; }

        /// <summary>Returns new Four spaces</summary>
        static private string TabFour() { return "    "; }

        /// <summary>XML tag name publish flyer text</summary>
        static private string m_tag_publish_flyer_text = "FlyerTextHomepagePublish";

        /// <summary>Default short text in the XML Edit files</summary>
        static private string m_short_text_default = "Band Text ...";

        /// <summary>Default musician text in the XML Edit files</summary>
        static private string m_musician_text_default = "Musiker/Musikerin Text ...";

        /// <summary>Current XML object created from an XML edit file</summary>
        private static XDocument m_document_xml_edit = null;

        /// <summary>The XML objects that shall be uploaded for Checkin (Save)</summary>
        static private XDocument[] m_upload_season_objects = null;

        /// <summary>The corresponding files of the XML objects that shall be uploaded for Checkin (Save)</summary>
        static private string[] m_upload_season_object_files = null;

        #endregion //Member variables

        #region Main functions

        /// <summary>Update data for the web application Flyer
        /// <para>1. Copy XML season files to Flyer application directory. Call of CopyXmlSeasonFilesToFlyer</para>
        /// <para>2. Copy XML application file to Flyer application directory. Call of CopyXmlApplicationFileToFlyer</para>
        /// <para>3. Create XML Edit subdirectories on the Flyer application directory. Call of CreateXmlEditSubdirectories</para>
        /// <para>4. Create and save XML file with updated directory names. Call of CreateAndSaveXmlListOfSubdirectories</para>
        /// <para>5. Create and upload XML edit files. Call of CreateUploadXmlEditFiles</para>
        /// </summary>
        /// <param name="i_progress_bar">Progress bar</param>
        /// <param name="i_textbox_message">Text box that shows the progress</param>
        /// <param name="o_error">Error description</param>
        public static bool UpdateFlyer(ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            string error_message = "";

            if (null == i_progress_bar)
            {
                o_error = @"Flyer.UpdateFlyer Programming error i_progress_bar = null";
            }

            if (null == i_textbox_message)
            {
                o_error = @"Flyer.UpdateFlyer Programming error i_textbox_message = null";
            }

            i_progress_bar.PerformStep(); // 1

            i_textbox_message.Text = @"Daten werden zur Web-Applikation Flyer exportiert (1)";
            i_textbox_message.Refresh();

            i_progress_bar.PerformStep(); // 2

            i_textbox_message.Text = @"XML Saisonprogramm-Dateien kopieren";
            i_textbox_message.Refresh();

            if (!CopyXmlSeasonFilesToFlyer(out error_message))
            {
                o_error = "Flyer.UpdateFlyer CopyXmlSeasonFilesToFlyer failed " + error_message;

                return false;
            }

            i_progress_bar.PerformStep(); // 3

            i_textbox_message.Text = @"XML Applikations-Datei kopieren";
            i_textbox_message.Refresh();

            if (!CopyXmlApplicationFileToFlyer(out error_message))
            {
                o_error = "Flyer.UpdateFlyer CopyXmlApplicationFileToFlyer failed " + error_message;

                return false;
            }

            i_progress_bar.PerformStep(); // 4

            i_textbox_message.Text = @"XML Edit Ordner kreieren";
            i_textbox_message.Refresh();

            if (!CreateXmlEditSubdirectories(out error_message))
            {
                o_error = "Flyer.UpdateFlyer CreateXmlEditSubdirectories failed " + error_message;

                return false;
            }

            i_progress_bar.PerformStep(); // 5

            i_textbox_message.Text = @"XML List von XML Edit Ordnern kreieren";
            i_textbox_message.Refresh();

            if (!CreateAndSaveXmlListOfSubdirectories(out error_message))
            {
                o_error = "Flyer.UpdateFlyer CreateAndSaveXmlListOfSubdirectories failed " + error_message;

                return false;
            }

            i_progress_bar.PerformStep(); // 6

            i_textbox_message.Text = @"XML List mit Login-Namen und Passwörter kreieren";
            i_textbox_message.Refresh();

            if (!CreateAndSaveXmlListOfUsersPasswords(out error_message))
            {
                o_error = "Flyer.UpdateFlyer CreateAndSaveXmlListOfUsersPasswords failed " + error_message;

                return false;
            }

            i_progress_bar.PerformStep(); // 7
            i_progress_bar.PerformStep(); // 8

           
            i_textbox_message.Text = @"XML Edit Dateien generieren und hochladen";
            i_textbox_message.Refresh();

            if (!CreateUploadXmlEditFiles(i_textbox_message, out error_message))
            {
                o_error = "Flyer.UpdateFlyer CreateUploadXmlEditFiles failed " + error_message;

                return false;
            }
            
            i_progress_bar.PerformStep(); // 9

            return true;

        } // UpdateFlyer

        /// <summary>Copy QR codes to the Flyer application directory with FTP
        /// <para>Input data are the sound and band links defined in the XML season programs</para>
        /// <para>For undefined links QR codes to an "undefined-image" on the homepage will be created</para>
        /// <para>1. Get XML objects for the seasons that shall be updated. Call of GetXmlSeasonObjectsToCopy</para>
        /// <para>2. Get the subdirectory names for the seasons that shall be updated. Call of GetXmlSeasonSubdirectoryNames</para>
        /// <para>3. Loop for XML objects</para>
        /// <para>3.1 Set the current season document. Call of JazzApp.JazzXml.SetCurrentSeasonDocument</para>
        /// <para>3.2 Loop for all concerts </para>
        /// <para>3.2.1  Get website link. Call of JazzApp.JazzXml.GetBandWebsite</para>
        /// <para>3.2.2  Generate QR Code for website and save in local subdirectory QRCodes. Call of GenerateQrCodeAndSave</para>
        /// <para>3.2.3  Upload QR Code image for website. Call of UploadQrCodeImage</para>
        /// <para>3.2.4  Get sound link. Call of JazzApp.JazzXml.GetSoundSample</para>
        /// <para>3.2.5  Generate QR Code for sound and save in local subdirectory QRCodes. Call of GenerateQrCodeAndSave</para>
        /// <para>3.2.6  Upload QR Code image for sound. Call of UploadQrCodeImage</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public static bool ExportQrCodes(ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            string error_message = "";

            i_progress_bar.PerformStep(); // 2

            i_textbox_message.Text = @"Export QR Codes";
            i_textbox_message.Refresh();

            XDocument[] xml_season_objects = GetXmlSeasonObjectsToCopy(out error_message);
            if (null == xml_season_objects)
            {
                o_error = "Flyer.ExportQrCodes GetXmlSeasonObjectsToCopy failed " + error_message;
                return false;
            }

            string[] season_subdirectory_names = GetXmlSeasonSubdirectoryNames(out error_message);
            if (null == season_subdirectory_names)
            {
                o_error = "Flyer.ExportQrCodes GetXmlSeasonSubdirectoryNames failed " + error_message;
                return false;
            }

            if (xml_season_objects.Length != season_subdirectory_names.Length)
            {
                o_error = "Flyer.ExportQrCodes Number of season XML objects is not equal to number of subdirectory names";
                return false;
            }

            XDocument input_active_object = JazzApp.JazzXml.GetObjectActiveDoc();

            for (int index_obj = 0; index_obj < xml_season_objects.Length; index_obj++)
            {
                XDocument current_xml_obj = xml_season_objects[index_obj];

                JazzApp.JazzXml.SetCurrentSeasonDocument(current_xml_obj);

                string current_server_dir = season_subdirectory_names[index_obj];

                int n_concerts = JazzApp.JazzXml.GetNumberConcertsInCurrentDocument();

                for (int i_concert = 1; i_concert <= n_concerts; i_concert++)
                {

                    i_progress_bar.PerformStep(); 

                    i_textbox_message.Text = current_server_dir + @" Konzert " + i_concert.ToString();
                    i_textbox_message.Refresh();

                    string link_web_site = JazzApp.JazzXml.GetBandWebsite(i_concert);
                    if (!GenerateQrCodeAndSave(link_web_site, i_concert, "website", out error_message))
                    {
                        o_error = "GenerateAndSaveQrCodeImagesForFlyer.CopyXmlSeasonFilesToFlyer GenerateQrCodeAndSave (website) failed " + error_message;
                        return false;
                    }

                    if (!UploadQrCodeImage(current_server_dir, i_concert, "website", out error_message))
                    {
                        o_error = "GenerateAndSaveQrCodeImagesForFlyer.CopyXmlSeasonFilesToFlyer UploadQrCodeImage (website) failed " + error_message;
                        return false;
                    }

                    string link_sound_sample = JazzApp.JazzXml.GetSoundSample(i_concert);
                    if (!GenerateQrCodeAndSave(link_sound_sample, i_concert, "sound", out error_message))
                    {
                        o_error = "GenerateAndSaveQrCodeImagesForFlyer.CopyXmlSeasonFilesToFlyer GenerateQrCodeAndSave (sound) failed " + error_message;
                        return false;
                    }

                    if (!UploadQrCodeImage(current_server_dir, i_concert, "sound", out error_message))
                    {
                        o_error = "GenerateAndSaveQrCodeImagesForFlyer.CopyXmlSeasonFilesToFlyer UploadQrCodeImage (sound) failed " + error_message;
                        return false;
                    }
                }

            } // index_obj


            if (null != input_active_object)
            {
                // JazzApp.JazzXml.SetObjectActiveDoc(input_active_object);
                JazzApp.JazzXml.SetCurrentSeasonDocument(input_active_object);
            }


            return true;

        } // ExportQrCodes

        /// <summary>Copy flyer images to the Flyer application directory with FTP
        /// <para>Input data are paths and names to the flyer images defined in the XML document files</para>
        /// <para>For undefined names undefined-images will be exported</para>
        /// <para>1. Initialize object withh documents. Create instance of JazzDocAll</para>
        /// <para>2. Get XML objects for the seasons that shall be updated. Call of GetXmlSeasonObjectsToCopy</para>
        /// <para>3. Get the subdirectory names for the seasons that shall be updated. Call of GetXmlSeasonSubdirectoryNames</para>
        /// <para>4. Loop for XML objects</para>
        /// <para>4.1 End of loop if documents (JazzDokumente_2021_2022.xml) not yet exist. Call of JazzXml.SeasonDocumentsExists</para>
        /// <para>4.2 Set the active season document. Call of JazzDocAll.SetActiveSeasonToInputSeason</para>
        /// <para>4.3 Loop for all concerts </para>
        /// <para>4.3.1  Get the path and the name of the image file. Call of GetImagePathFilename</para>
        /// <para>4.3.2  Construct the name of the exported file. Call of ConstructExportFlyerFileName</para>
        /// <para>4.3.3  Download flyer image file to temporary directory. Call of JazzFtp.Execute.Run</para>
        /// <para>4.3.4  Upload image file to flyer directory. Call of JazzFtp.Execute.Run</para>
        /// <para>4.3.5  Delete temporary downloade file</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public static bool ExportFlyerImages(ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            string error_message = "";

            i_progress_bar.PerformStep(); // 2

            i_textbox_message.Text = @"Export Flyer images";
            i_textbox_message.Refresh();

            DocAllFlyer = new JazzDocAll();

            DocAllFlyer.DebugFlag = false;

            string local_temp_dir_flyer_images = GetNameLocalTemporaryFlyerImagesDir();

            XDocument[] xml_season_objects = GetXmlSeasonObjectsToCopy(out error_message);
            if (null == xml_season_objects)
            {
                o_error = "Flyer.ExportQrCodes GetXmlSeasonObjectsToCopy failed " + error_message;
                return false;
            }

            string[] season_subdirectory_names = GetXmlSeasonSubdirectoryNames(out error_message);
            if (null == season_subdirectory_names)
            {
                o_error = "Flyer.ExportQrCodes GetXmlSeasonSubdirectoryNames failed " + error_message;
                return false;
            }

            if (xml_season_objects.Length != season_subdirectory_names.Length)
            {
                o_error = "Flyer.ExportQrCodes Number of season XML objects is not equal to number of subdirectory names";
                return false;
            }

            for (int index_obj = 0; index_obj < xml_season_objects.Length; index_obj++)
            {
                XDocument current_xml_obj = xml_season_objects[index_obj];

                JazzApp.JazzXml.SetCurrentSeasonDocument(current_xml_obj);

                string current_server_dir = season_subdirectory_names[index_obj];

                int n_concerts = JazzApp.JazzXml.GetNumberConcertsInCurrentDocument();

                int season_start_year = JazzApp.JazzXml.GetYearAutumnInt();

                string[] all_band_names = null;

                if (!JazzApp.JazzXml.SeasonDocumentsExists(season_start_year))
                {
                    i_textbox_message.Text = @"Bilder für Saison " + 
                        season_start_year.ToString() + @"-" + (season_start_year+1).ToString() +
                        " sind nicht vorhanden";
                    i_textbox_message.Refresh();

                    break;
                }

                if (!DocAllFlyer.SetActiveSeasonToInputSeason(season_start_year, out o_error))
                {
                    o_error = @"Flyer.ExportFlyerImages DocAllFlyer.SetActiveSeasonToInputSeason failed " + o_error;
                    return false;
                }

                all_band_names = DocAllFlyer.BandNames;

                /*QQQQQ 2021-05-25 
                if (index_obj == 0)
                {
                    if (!DocAllFlyer.SetActiveSeasonToThisSeason(out o_error))
                    {
                        o_error = @"Flyer.ExportFlyerImages DocAllFlyer.SetActiveSeasonToThisSeason failed " + o_error;
                        return false;
                    }

                    all_band_names = DocAllFlyer.BandNames;
                }
                else if (index_obj == 1)
                {
                    if (!DocAllFlyer.SetActiveSeasonToNextSeason(out o_error))
                    {
                        all_band_names = null;
                    }

                    all_band_names = DocAllFlyer.BandNames;
                }
                else
                {
                    o_error = @"Flyer.ExportFlyerImages Only current and next season are implemented";
                    return false;
                }

                2021-05-25  QQQQ*/

                if (all_band_names != null)
                {
                    if (all_band_names.Length != n_concerts)
                    {
                        o_error = @"Flyer.ExportFlyerImages Not the same number of concerts ";
                        return false;
                    }
                }
 
                for (int i_concert = 1; i_concert <= n_concerts; i_concert++)
                {

                    i_progress_bar.PerformStep();

                    i_textbox_message.Text = current_server_dir + @" Konzert " + i_concert.ToString();
                    i_textbox_message.Refresh();

                    string image_file_path = "";
                    string image_file_name = "";

                    if (!GetImagePathFilename(i_concert - 1, all_band_names, ref image_file_path, ref image_file_name, out o_error))
                    {
                        o_error = @"Flyer.ExportFlyerImages GetImagePathFilename failed " + o_error;
                        return false;
                    }

                    string server_dir = "";
                    if (FlyerImageIsUndefined(image_file_path, image_file_name))
                    {
                        server_dir = image_file_path;
                    }
                    else if (all_band_names == null)
                    {
                        server_dir = image_file_path;
                    }
                    else
                    {
                        server_dir = @"www/PlakateFlyersBilletsVorlagen/" + image_file_path;
                    }

                    string file_name = ConstructExportFlyerFileName(i_concert);

                    JazzFtp.Input ftp_input_download = new JazzFtp.Input(Main.ExeDirectory, Input.Case.DownloadFile);

                    ftp_input_download.ServerDirectory = server_dir;
                    ftp_input_download.ServerFileName = image_file_name;

                    ftp_input_download.LocalDirectory = m_dir_flyer_images_name;
                    ftp_input_download.LocalFileName = file_name;

                    JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input_download);

                    if (!ftp_result.Status)
                    {
                        o_error = @"Flyer.ExportFlyerImages JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                        return false;
                    }

                    string season_directory_name_mod = current_server_dir.Replace(" ", "_");

                    string upload_server_dir = "www/" + m_flyer_server_dir + "/" + m_flyer_admin_xml_dir + "/" + season_directory_name_mod;

                    if (!CreateFlyerSubdirIfNotExisting(upload_server_dir, out error_message))
                    {
                        o_error = @"Flyer.ExportFlyerImages CreateFlyerSubdirIfNotExisting failed " + error_message;
                        return false;
                    }

                    JazzFtp.Input ftp_input_upload = new JazzFtp.Input(Main.ExeDirectory, Input.Case.UpLoadFile);

                    ftp_input_upload.ServerDirectory = upload_server_dir;
                    ftp_input_upload.ServerFileName = file_name;

                    ftp_input_upload.LocalDirectory = m_dir_flyer_images_name;
                    ftp_input_upload.LocalFileName = file_name;

                    JazzFtp.Result ftp_result_htm = JazzFtp.Execute.Run(ftp_input_upload);

                    if (!ftp_result_htm.Status)
                    {
                        o_error = @"Flyer.ExportFlyerImages JazzFtp.Execute.Run for htm file failed " + ftp_result_htm.ErrorMsg;
                        return false;
                    }

                    string full_temp_file_name = local_temp_dir_flyer_images + file_name;
                    if (File.Exists(full_temp_file_name))
                    {
                        File.Delete(full_temp_file_name);
                    }

                } // i_concert

            } // index_obj

            return true;

        } // ExportFlyerImages

        // Returns true if the image not yet is defined
        private static bool FlyerImageIsUndefined(string i_image_file_path, string i_image_file_name)
        {
            if (i_image_file_path.Equals(m_path_not_yet_set_image) && i_image_file_name.Equals(m_name_not_yet_set_image))
            {
                return true;
            }
            else
            {
                return false;
            }

        } // FlyerImageIsUndefined

        /// <summary>Import data from web application Flyer
        /// <para>Call of GetAndUpdateFlyer</para>
        /// </summary>
        /// <param name="i_b_musician_texts">Flag Eq. true: Import Musician texts Eq. false: Import free text</param>
        /// <param name="i_progress_bar">Progress bar</param>
        /// <param name="i_textbox_message">Text box for messages</param>
        /// <param name="o_error">Error description</param>
        public static bool ImportDataFromFlyerApplication(bool i_b_musician_texts, ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            if (null == i_progress_bar)
            {
                o_error = @"Flyer.ImportDataFromFlyerApplication Programming error i_progress_bar = null";
            }

            if (null == i_textbox_message)
            {
                o_error = @"Flyer.ImportDataFromFlyerApplication Programming error i_textbox_message = null";
            }

            i_progress_bar.PerformStep(); // 1

            i_textbox_message.Text = @"Daten werden von der Web-Applikation Flyer importiert (1)";
            i_textbox_message.Refresh();

            string error_message = "";

            if (!Flyer.GetAndUpdateFlyer(i_b_musician_texts, i_progress_bar, i_textbox_message, out error_message))
            {
                MessageBox.Show(error_message);

                return false;
            }

            i_progress_bar.PerformStep(); // 14


            return true;

        } // ImportDataFromFlyerApplication

        /// <summary>Import data from the web application Flyer
        /// <para>1. Get the XML season objects that shall be updated. Call of GetXmlSeasonObjectsToCopy</para>
        /// <para>2. Get the Flyer application edit subdirectories for these XML objects. Call of GetXmlEditSubdirectoryNames</para>
        /// <para>3. Loop for the these objects/subdirectories</para>
        /// <para>3.1 Set current (active) season object and corresponding file. Call of JazzXml.SetCurrentSeasonDocument and JazzXml.SetCurrentSeasonFileUrl</para>
        /// <para>3.2 Reload current XML object. Call of AdminUtils.ReloadCurrentSeasonProgramXml</para>
        /// <para>3.3 Get text data for one concert from Flyer, set season program XML and update XML edit data. Call of GetXmlDataUpdateFlyerOneConcert.</para>
        /// <para>3. </para>
        /// </summary>
        /// <param name="i_b_musician_texts">Flag Eq. true: Import Musician texts Eq. false: Import free text</param>
        /// <param name="i_progress_bar">Progress bar</param>
        /// <param name="i_textbox_message">Text box that shows the progress</param>
        /// <param name="o_error">Error description</param>
        public static bool GetAndUpdateFlyer(bool i_b_musician_texts, ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            string error_message = "";

            i_progress_bar.PerformStep(); // 2
            i_textbox_message.Text = @"Texte von Flyer importieren";
            i_textbox_message.Refresh();

            XDocument[] xml_season_objects = GetXmlSeasonObjectsToCopy(out error_message);
            if (null == xml_season_objects)
            {
                o_error = "Flyer.GetAndUpdateFlyer failed " + error_message;
                return false;
            }

            string[] xml_edit_subdir_names = GetXmlEditSubdirectoryNames(out error_message);
            if (null == xml_edit_subdir_names)
            {
                o_error = "Flyer.GetAndUpdateFlyer failed " + error_message;
                return false;
            }

            if (xml_season_objects.Length != xml_edit_subdir_names.Length)
            {
                o_error = "Flyer.GetAndUpdateFlyer Number of objects in xml_season_objects and  xml_edit_subdir_names not equal";
                return false;
            }

            m_upload_season_objects = new XDocument[xml_season_objects.Length];
            m_upload_season_object_files = new string[xml_season_objects.Length];


            for (int index_dir = 0; index_dir < xml_edit_subdir_names.Length; index_dir++)
            {
                string edit_text_season_server_subdir = xml_edit_subdir_names[index_dir];

                XDocument current_xml_obj = xml_season_objects[index_dir];

                m_upload_season_objects[index_dir] = current_xml_obj;

                JazzApp.JazzXml.SetCurrentSeasonDocument(current_xml_obj);

                JazzApp.JazzXml.SetCurrentSeasonFileUrl();

                string season_xml_file_url = JazzApp.JazzXml.GetCurrentSeasonFileUrl();

                m_upload_season_object_files[index_dir] = season_xml_file_url;

                // For the uploading of the season XML file (function AdminUtils.UploadXmlToServer)
                AdminUtils.SetCurrentEditDocument(current_xml_obj);
                AdminUtils.SetCurrentSelectedXmlFile(season_xml_file_url);
                AdminUtils.ReloadCurrentSeasonProgramXml();

                i_progress_bar.PerformStep(); // 
                string file_name = Path.GetFileName(season_xml_file_url);
                i_textbox_message.Text = @"Saison Datei: " + file_name;
                i_textbox_message.Refresh();

                int n_concerts = JazzApp.JazzXml.GetNumberConcertsInCurrentDocument();

                for (int concert_number=1; concert_number <= n_concerts; concert_number++)
                {
                    string xml_edit_file_name = XmlEditFileName(concert_number);

                    string full_local_file_name = GetXmlEditLocalFilePath(concert_number);

                    string local_directory = JazzAppAdminSettings.Default.XmlExistingDir;

                    if (!GetXmlDataUpdateFlyerOneConcert(concert_number, i_b_musician_texts, edit_text_season_server_subdir, xml_edit_file_name, local_directory, full_local_file_name, out error_message))
                    {
                        o_error = "Flyer.GetXmlDataUpdateFlyerOneConcert GetXmlObjectFlyerXmlEditFile failed " + error_message;
                    }

                } // concert_number

            } // index_dir

            return true;

        } // GetAndUpdateFlyer

        #endregion // Main functions

        #region Save season programs and copy to Flyer

        /// <summary>Save (checkin) the updated XML season programs and copy them to the application Flyer
        /// <para>Input data are the arrays m_upload_season_object_files and m_upload_season_object_files</para>
        /// <para>1. Loop for the elements of the input arrays</para>
        /// <para>1.1 Set current edit XML document and corresponding file . Call of SetCurrentEditDocument and SetCurrentSelectedXmlFile</para>
        /// <para>1.2 Upload to server and create backup. Call of AdminUtils.UploadXmlToServer</para>
        /// </summary>
        /// <param name="i_b_musician_texts">Flag Eq. true: Import Musician texts Eq. false: Import free text</param>
        /// <param name="i_progress_bar">Progress bar</param>
        /// <param name="i_textbox_message">Text box that shows the progress</param>
        /// <param name="o_error">Error description</param>
        public static bool SaveUpdatedXmlSeasonProgramsCopyToFlyer(out string o_error)
        {
            o_error = @"";

            string error_message = @"";

            if (m_upload_season_objects == null || m_upload_season_objects.Length == 0)
            {
                o_error = @"Flyer.SaveUpdatedXmlSeasonProgramsCopyToFlyer m_upload_season_objects not defined";
                return false;
            }

            if (m_upload_season_object_files == null || m_upload_season_object_files.Length == 0)
            {
                o_error = @"Flyer.SaveUpdatedXmlSeasonProgramsCopyToFlyer m_upload_season_object_files not defined";
                return false;
            }

            if (m_upload_season_objects.Length != m_upload_season_object_files.Length)
            {
                o_error = @"Flyer.SaveUpdatedXmlSeasonProgramsCopyToFlyer Number of m_upload_season_objects is not equal to number of m_upload_season_object_files";
                return false;
            }

            for (int index_upload=0; index_upload< m_upload_season_objects.Length; index_upload++)
            {

                XDocument current_xml_obj = m_upload_season_objects[index_upload];
                string season_xml_file_url = m_upload_season_object_files[index_upload];

                AdminUtils.SetCurrentEditDocument(current_xml_obj);
                AdminUtils.SetCurrentSelectedXmlFile(season_xml_file_url);

                if (!AdminUtils.UploadXmlToServer(true, out error_message))
                {
                    o_error = @"Flyer.SaveXmlSeasonPrograms UploadXmlToServer failed " + error_message;

                    return false;
                }

            } // index_upload

            AdminUtils.SetCurrentEditDocument(null);
            AdminUtils.SetCurrentSelectedXmlFile(@"");

            if (!CopyXmlSeasonFilesToFlyer(out error_message))
            {
                o_error = @"Flyer.SaveXmlSeasonPrograms CopyXmlSeasonFilesToFlyer failed " + error_message;

                return false;
            }

            return true;

        } // SaveUpdatedXmlSeasonProgramsCopyToFlyer

        #endregion // Save season programs and copy to Flyer

        #region Get Flyer data and update Flyer

        /// <summary>Get XML musician text data for one concert from Flyer, set season program XML and update concert flyer XML edit data
        /// <para>It is assumed that the correct XML season object is set</para>
        /// <para>1. Get the XML object for a Flyer XML edit file on the server. Call of GetXmlObjectFlyerXmlEditFile.</para>
        /// <para>2. Determine if the edit file text shall be published. Quit function if not. Call of PublishFlyerText.</para>
        /// <para>3. Get the XML edit texts and set the XML season object. Call of GetXmlEditTextSetXmlSeason.</para>
        /// <para>4. Change the publish flag of the text file string from TRUE to FALSE. Call of string.Replace </para>
        /// <para>5. Create temporary XML edit text file. Call of File.WriteAllText</para>
        /// <para>6. Upload an XML file for the Flyer application. Call of UploadOneXmlFileForFlyer</para>
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_b_musician_texts">Flag Eq. true: Import Musician texts Eq. false: Import free text</param>
        /// <param name="i_server_dir">Server directory for the XML edit file</param>
        /// <param name="i_server_file_name">The XML edit file name</param>
        /// <param name="i_local_dir">A local directory where the downloaded XML edit file temporarely will be stored</param>
        /// <param name="i_full_local_file_name">Local XML edit file name with full path</param>
        /// <param name="o_error">Error description</param>
        public static bool GetXmlDataUpdateFlyerOneConcert(int i_concert_number, bool i_b_musician_texts, string i_server_dir, string i_server_file_name, string i_local_dir, string i_full_local_file_name, out string o_error)
        {
            o_error = "";

            string error_message = "";

            XDocument xml_edit_object = null;

            if (!GetXmlObjectFlyerXmlEditFile(i_server_dir, i_server_file_name, i_local_dir, i_full_local_file_name, out xml_edit_object, out error_message))
            {
                o_error = "Flyer.GetXmlDataUpdateFlyerOneConcert GetXmlObjectFlyerXmlEditFile failed " + error_message;

                return false;
            }

            // Set the global variable XML edit object
            m_document_xml_edit = xml_edit_object;

            if (!PublishFlyerText())
            {
                // Do nothing
                return true;
            }

            if (!GetXmlEditTextSetXmlSeason(i_concert_number, i_b_musician_texts))
            {
                o_error = "Flyer.GetXmlDataUpdateFlyerOneConcert GetXmlEditTextSetXmlSeason failed ";

                return false;
            }

            string content_xml_edit_file = xml_edit_object.ToString();

            content_xml_edit_file = content_xml_edit_file.Replace(">TRUE<", ">FALSE<");

            string full_local_file_name = GetXmlEditLocalFilePath(i_concert_number);
           
            File.WriteAllText(full_local_file_name, content_xml_edit_file);

            if (!UploadOneXmlFileForFlyer(XmlEditFileName(i_concert_number), JazzAppAdminSettings.Default.XmlExistingDir, XmlEditFileName(i_concert_number), i_server_dir, out error_message))
            {
                o_error = @"Flyer.GetXmlDataUpdateFlyerOneConcert UploadOneXmlFileForFlyer failed " + error_message;
                return false;
            }

            if (File.Exists(full_local_file_name))
            {
                File.Delete(full_local_file_name);
            }
    


            return true;

        } // GetXmlDataUpdateFlyerOneConcert

        /// <summary>Get the XML edit texts and set the XML season object
        /// <para>1. Get the XML edit short text and set the text. Call GetShortText and JazzXml.SetShortText</para>
        /// <para>2. Get the XML edit additional text and set the text. Call GetFlyerText and JazzXml.SetFlyerText</para>
        /// <para>3. Get the XML edit label additional text and set the text. Call GetLabelFlyerText and JazzXml.SetLabelFlyerText</para>
        /// <para>3. Loop for all musicians. Call of GetNumberMusicians</para>
        /// <para>3.1 Get the XML edit musician text and set the text. Call GetMusicianText and JazzXml.SetMusicianText</para>
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        ///  <param name="i_b_musician_texts">Flag Eq. true: Import Musician texts Eq. false: Import free text</param>
        private static bool GetXmlEditTextSetXmlSeason(int i_concert_number, bool i_b_musician_texts)
        {
            string update_edit_case = "";

            if (!DetermineUpdateEditTextCase(i_concert_number, out update_edit_case))
            {
                return false;
            }

            //QQif (update_edit_case.Equals("Both"))
            //QQ{
            //QQ    MessageBox.Show("Nichts wurde importiert weil KurzText, MusikerText und freier Text haben Text für Konzert " + i_concert_number.ToString());
            //QQ    return false;
            //QQ}

            //QQ if (update_edit_case.Equals("ShortMusician"))


            if (i_b_musician_texts)
            {
                string short_text_edit_xml = GetShortText();
                JazzApp.JazzXml.SetShortText(i_concert_number, short_text_edit_xml);

                int number_musicians = GetNumberMusicians(m_concert_number_xml_edit);

                for (int musician_number = 1; musician_number <= number_musicians; musician_number++)
                {
                    string musician_text = GetMusicianText(musician_number);
                    JazzApp.JazzXml.SetMusicianText(i_concert_number, musician_number, musician_text);
                }
            }

            //QQ if (update_edit_case.Equals("Flyer"))
            else
            {
                string flyer_text_edit_xml = GetFlyerText();
                JazzApp.JazzXml.SetFlyerText(i_concert_number, flyer_text_edit_xml);

                string label_flyer_text_edit_xml = GetLabelFlyerText();
                JazzApp.JazzXml.SetLabelFlyerText(i_concert_number, label_flyer_text_edit_xml);
            }

            return true;

        } // GetXmlEditTextSetXmlSeason

        /// <summary>Determine the update edit case 
        /// <para>Only the free flyer (non-concert) text or the short text/musicians texts may be changed</para>
        /// <para>2. Get the XML edit additional text and set the text. Call GetFlyerText and JazzXml.SetFlyerText</para>
        /// <para>3. Get the XML edit label additional text and set the text. Call GetLabelFlyerText and JazzXml.SetLabelFlyerText</para>
        /// <para>3. Loop for all musicians. Call of GetNumberMusicians</para>
        /// <para>3.1 Get the XML edit musician text and set the text. Call GetMusicianText and JazzXml.SetMusicianText</para>
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        private static bool DetermineUpdateEditTextCase(int i_concert_number, out string o_update_edit_case)
        {
            o_update_edit_case = "Undefined";

            string flyer_text_edit_xml = GetFlyerText();

            string label_flyer_text_edit_xml = GetLabelFlyerText();

            bool flyer_texts_set = false;

            if (JazzApp.JazzXml.XmlNodeValueIsSet(flyer_text_edit_xml) || JazzApp.JazzXml.XmlNodeValueIsSet(label_flyer_text_edit_xml))
            {
                flyer_texts_set = true;
            }

                /*
                        /// <summary>Default short text in the XML Edit files</summary>
                        static private string m_short_text_default = "Band Text ...";

                        /// <summary>Default musician text in the XML Edit files</summary>
                        static private string m_musician_text_default = "Musiker/Musikerin Text ...";
                */

                bool short_text_is_set = false;

            string short_text_edit_xml = GetShortText();
            if (short_text_edit_xml.Equals(m_short_text_default))
            {
                short_text_is_set = false;
            }
            else if (!JazzApp.JazzXml.XmlNodeValueIsSet(short_text_edit_xml))
            {
                short_text_is_set = false;
            }
            else
            {
                short_text_is_set = true;
            }

            int number_musicians = GetNumberMusicians(m_concert_number_xml_edit);

            bool musician_text_is_set = false;
            for (int musician_number = 1; musician_number <= number_musicians; musician_number++)
            {
                string musician_text = GetMusicianText(musician_number);

                if (musician_text.Equals(m_musician_text_default))
                {
                    musician_text_is_set = false;
                }
                else if (!JazzApp.JazzXml.XmlNodeValueIsSet(musician_text))
                {
                    musician_text_is_set = false;
                }
                else
                {
                    musician_text_is_set = true;
                    break;
                }
            }

            if (flyer_texts_set && short_text_is_set)
            {
                o_update_edit_case = "Both";
            }
            else if (flyer_texts_set && musician_text_is_set)
            {
                o_update_edit_case = "Both";
            }
            else if (flyer_texts_set)
            {
                o_update_edit_case = "Flyer";
            }
            else if (short_text_is_set || musician_text_is_set)
            {
                o_update_edit_case = "ShortMusician";
            }
            else
            {
                o_update_edit_case = "None";
            }

            return true;

        } // DetermineUpdateEditTextCase



        /// <summary>Get the XML object for a Flyer XML edit file on the server
        /// <para>1. Download the XML edit file. Call of JazzFtp.Execute.Run for Input.Case.DownloadFile </para>
        /// <para>2. Load the XML object. Call of XDocument.Load</para>
        /// <para>3. Delete the downloaded file. Call of File.Delete</para>
        /// </summary>
        /// <param name="i_server_dir">Server directory for the XML edit file</param>
        /// <param name="i_server_file_name">The XML edit file name</param>
        /// <param name="i_local_dir">A local directory where the downloaded XML edit file temporarely will be stored</param>
        /// <param name="i_full_local_file_name">Local XML edit file name with full path</param>
        /// <param name="o_xml_edit_object">Output XML object for the Flyer XML edit file</param>
        /// <param name="o_error">Error description</param>
        private static bool GetXmlObjectFlyerXmlEditFile(string i_server_dir, string i_server_file_name, string i_local_dir, string i_full_local_file_name, out XDocument o_xml_edit_object, out string o_error)
        {
            o_xml_edit_object = null;
            o_error = "";

            JazzFtp.Input ftp_download_xml = new JazzFtp.Input(Main.ExeDirectory, Input.Case.DownloadFile);

            string download_server_dir = i_server_dir;

            ftp_download_xml.ServerDirectory = download_server_dir;
            ftp_download_xml.ServerFileName = i_server_file_name;

            string local_file_name = i_server_file_name;
            ftp_download_xml.LocalDirectory = i_local_dir;
            ftp_download_xml.LocalFileName = local_file_name;

            JazzFtp.Result ftp_result_download = JazzFtp.Execute.Run(ftp_download_xml);

            if (!ftp_result_download.Status)
            {
                o_error = @"Flyer.GetXmlObjectFlyerXmlEditFile JazzFtp.Execute.Run case DownloadFile failed " + ftp_result_download.ErrorMsg;
                return false;
            }

            o_xml_edit_object = XDocument.Load(i_full_local_file_name);
            if (null == o_xml_edit_object)
            {
                o_error = @"Flyer.GetXmlObjectFlyerXmlEditFile XDocument.Load failed ";
                return false;
            }

            if (File.Exists(i_full_local_file_name))
            {
                File.Delete(i_full_local_file_name);
            }

            return true;

        } // GetXmlObjectFlyerXmlEditFile


        #endregion // Get Flyer data and update Flyer

        #region Flyer Edit XML functions

        /// <summary>The XML edit files are like the XML season files, but there is only on concert</summary>
        private static int m_concert_number_xml_edit = 1;

        /// <summary>Returns true if the concert Flyer musician text shall be imported, i.e. if the texts can be published</summary>
        private static bool PublishFlyerText()
        {
            string publish_flyer_text_value = GetInnerTextForNode(m_concert_number_xml_edit, m_tag_publish_flyer_text);

            if (publish_flyer_text_value.Equals("TRUE"))
            {
                return true;
            }
            else
            {
                return false;
            }

        } // PublishFlyerText

        // 

        /// <summary>Returns the short text from the XML edit object</summary>
        private static string GetShortText()
        {
            string ret_short_text = GetInnerTextForNode(m_concert_number_xml_edit, JazzApp.JazzXml.GetTagConcertShortText());

            return ret_short_text;

        } // GetShortText

        /// <summary>Returns the additional text from the XML edit object</summary>
        private static string GetAdditionalText()
        {
            string ret_additional_text = GetInnerTextForNode(m_concert_number_xml_edit, JazzApp.JazzXml.GetTagConcertAdditionalText());

            return ret_additional_text;

        } // GetAdditionalText

        /// <summary>Returns the label for the additional text from the XML edit object</summary>
        private static string GetLabelAdditionalText()
        {
            string ret_label_additional_text = GetInnerTextForNode(m_concert_number_xml_edit, JazzApp.JazzXml.GetTagConcertLabelAdditionalText());

            return ret_label_additional_text;

        } // GetLabelAdditionalText

        /// <summary>Returns the flyer (free non-concert) text from the XML edit object</summary>
        private static string GetFlyerText()
        {
            string ret_flyer_text = GetInnerTextForNode(m_concert_number_xml_edit, JazzApp.JazzXml.GetTagConcertFlyerText());

            return ret_flyer_text;

        } // GetFlyerText

        /// <summary>Returns the label for the flyer text from the XML edit object</summary>
        private static string GetLabelFlyerText()
        {
            string ret_label_flyer_text = GetInnerTextForNode(m_concert_number_xml_edit, JazzApp.JazzXml.GetTagConcertLabelFlyerText());

            return ret_label_flyer_text;

        } // GetLabelFlyerText

        /// <summary>Returns the text about a musician</summary>
        private static string GetMusicianText(int i_musician)
        {
            string musician_text = GetMusicianInnerText(m_concert_number_xml_edit, i_musician, JazzApp.JazzXml.GetTagMusicianText());

            return musician_text;

        } // GetMusicianText

        /// <summary>Returns the inner text of the node for the current concert XML document</summary>
        ///  <param name="i_concert">Concert number 1, 2, 3, 4, 5, ....</param>
        ///  <param name="i_musician">Musician number 1, 2, 3, ....</param>
        ///  <param name="i_tag_name">Tag name</param>
        static private string GetMusicianInnerText(int i_concert, int i_musician, String i_tag_name)
        {
            String ret_inner_text = "";

            if (null == m_document_xml_edit)
                return "Programming error Flyer.GetMusicianInnerText: Current XML document is null";

            if (i_concert <= 0)
                return "Programming error Flyer.GetMusicianInnerText: Concert number <= 0";

            if (i_musician <= 0)
                return "Programming error Flyer.GetMusicianInnerText: Musician number <= 0";

            int current_concert_number = 0;
            int current_musician_number = 0;
            foreach (XElement element_concert in m_document_xml_edit.Descendants("Concert"))
            {
                current_concert_number = current_concert_number + 1;
                if (i_concert == current_concert_number)
                {
                    foreach (XElement element_musician in element_concert.Descendants("Musician"))
                    {
                        current_musician_number = current_musician_number + 1;
                        if (i_musician == current_musician_number)
                        {
                            XElement first_element = (from el in element_musician.Descendants(i_tag_name)
                                                      select el).First();
                            ret_inner_text = first_element.Value;

                            // Not necessary ret_inner_text = JazzApp.JazzXml.ModifyReadXml(ret_inner_text);

                            return ret_inner_text;
                        } // Musician exists

                    } // element_musician
                } // Concert exists
            } // element_concert

            return ret_inner_text;

        } // GetMusicianInnerText

        /// <summary>Returns the number of musicians for a given concert (here always 1)</summary>
        private static int GetNumberMusicians(int i_concert)
        {
            int ret_number_musicians = 0;

            if (null == m_document_xml_edit)
                return -1;

            int current_concert_number = 0;
            foreach (XElement element_concert in m_document_xml_edit.Descendants("Concert"))
            {
                current_concert_number = current_concert_number + 1;
                if (i_concert == current_concert_number)
                {
                    foreach (XElement element_musician in element_concert.Descendants("Musician"))
                    {
                        ret_number_musicians = ret_number_musicians + 1;
                    } // element_musician
                } // Concert exists
            } // element_concert

            return ret_number_musicians;

        } // GetNumberMusicians

        /// <summary>Returns the inner text of the node for the current concert XML document
        /// <para>Please note that the called function XElement.Vakue unescapes &, <, > and "</para>
        /// </summary>
        ///  <param name="i_concert">Concert number</param>
        ///  <param name="i_tag_name">Tag name</param>
        static private string GetInnerTextForNode(int i_concert, String i_tag_name)
        {
            String ret_inner_text = "";

            if (null == m_document_xml_edit)
                return "Error JazzXml.GetInnerTextForNode: Current XML document is null";

            int current_concert_number = 0;
            foreach (XElement element_concert in m_document_xml_edit.Descendants("Concert"))
            {
                current_concert_number = current_concert_number + 1;
                if (i_concert == current_concert_number)
                {
                    XElement first_element = (from el in element_concert.Descendants(i_tag_name)
                                              select el).First();

                    ret_inner_text = first_element.Value;

                    //QQ 2019-08-19 ret_inner_text = JazzApp.JazzXml.ModifyReadXml(ret_inner_text);

                    return ret_inner_text;
                }
            }

            return "Error Flyer.GetInnerTextForNode: No node for the given concert number";

        } // GetInnerTextForNode

        #endregion // Flyer Edit XML functions

        #region Copy files with FTP

        /// <summary>Copy XML season files to the Flyer application directory with FTP
        /// <para>1. Get file names for the XML season files that shall be copied. Call of GetXmlSeasonFileNamesToCopy</para>
        /// <para>2. Get Flyer subdirectory names for the XML files that shall be copied. Call of GetXmlSeasonSubdirectoryNames</para>
        /// <para>3. Loop file names</para>
        /// <para>3.1 Copy XML season file to Flyer application directory. Call of CopyOneXmlSeasonFileToFlyer</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public static bool CopyXmlSeasonFilesToFlyer(out string o_error)
        {
            o_error = "";

            string error_message = "";

            string[] xml_season_file_names_to_copy = GetXmlSeasonFileNamesToCopy(out error_message);
            if (null == xml_season_file_names_to_copy)
            {
                o_error = "Flyer.CopyXmlSeasonFilesToFlyer failed " + error_message;
                return false;
            }

            string[] season_subdirectory_names = GetXmlSeasonSubdirectoryNames(out error_message);
            if (null == season_subdirectory_names)
            {
                o_error = "Flyer.GetXmlSeasonSubdirectoryNames failed " + error_message;
                return false;
            }

            if (xml_season_file_names_to_copy.Length != season_subdirectory_names.Length)
            {
                o_error = "Flyer.CopyXmlSeasonFilesToFlyer Number of season files to copy is not equal to number of subdirectory names";
                return false;
            }

            int n_files_to_copy = xml_season_file_names_to_copy.Length;

            for (int index_file = 0; index_file < n_files_to_copy; index_file++)
            {
                string season_file_name = xml_season_file_names_to_copy[index_file];

                string season_directory_name = season_subdirectory_names[index_file];

                if (!CopyOneXmlSeasonFileToFlyer(season_file_name, season_directory_name, out error_message))
                {
                    o_error = "Flyer.CopyXmlSeasonFilesToFlyer CopyOneXmlSeasonFileToFlyer failed " + error_message;

                    return false;
                }
            }

            return true;

        } // CopyXmlSeasonFilesToFlyer


        /// <summary>Copy one season XML file to the Flyer application directory with FTP
        /// <para>The name of copied season XML file is changed to SaisonProgramm.xml. The name for any file will be the same, but directory not.</para>
        /// <para>1. Get the name of the local directory for the downloaded XML files. Call of GetNameLocalTemporaryXmlDir</para>
        /// <para>2. Download the input season program XML file. DownloadOneXmlFileForFlyer</para>
        /// <para>3. Create server directory for the Flyer season program XML file. Call of CreateFlyerSubdirIfNotExisting</para>
        /// <para>4. Upload the input season program XML file.Call of UploadOneXmlFileForFlyer</para>
        /// <para>5. Delete the temporary used local file. Call of File.Delete.</para>
        /// </summary>
        /// <param name="i_season_file_name">Full name of the XML file that shall be copied</param>
        /// <param name="i_season_directory_name">Name of the subdirectory for the copied file</param>
        /// <param name="o_error">Error description</param>
        public static bool CopyOneXmlSeasonFileToFlyer(string i_full_season_file_name, string i_season_directory_name, out string o_error)
        {
            o_error = "";

            string error_message = "";

            string exe_path_local_dir = GetNameLocalTemporaryXmlDir();

            string download_server_file = Path.GetFileName(i_full_season_file_name);

            if (!DownloadOneXmlFileForFlyer(download_server_file, JazzAppAdminSettings.Default.XmlExistingDir, m_file_name_copied_season_program, JazzAppAdminSettings.Default.XmlExistingDir, out error_message))
            {
                o_error = @"Flyer.CopyOneXmlSeasonFileToFlyer DownloadOneXmlFileForFlyer failed " + error_message;
                return false;
            }

            string season_directory_name_mod = i_season_directory_name.Replace(" ", "_");

            string upload_server_dir = "www/" + m_flyer_server_dir + "/" + m_flyer_admin_xml_dir + "/" + season_directory_name_mod;


            if (!CreateFlyerSubdirIfNotExisting(upload_server_dir, out error_message))
            {
                o_error = @"Flyer.CopyOneXmlSeasonFileToFlyer CreateFlyerSubdirIfNotExisting failed " + error_message;
                return false;
            }

            if (!UploadOneXmlFileForFlyer(m_file_name_copied_season_program, JazzAppAdminSettings.Default.XmlExistingDir, m_file_name_copied_season_program, upload_server_dir, out error_message))
            {
                o_error = @"Flyer.CopyOneXmlSeasonFileToFlyer UploadOneXmlFileForFlyer failed " + error_message;
                return false;
            }

            string temp_full_file_name = exe_path_local_dir + m_file_name_copied_season_program;
            if (File.Exists(temp_full_file_name))
            {
                File.Delete(temp_full_file_name);
            }

            return true;

        } // CopyOneXmlSeasonFileToFlyer


        /// <summary>Copy the application XML file to the Flyer web application directory with FTP
        /// <para>1. Get the name of the local directory for the downloaded XML files. Call of GetNameLocalTemporaryXmlDir</para>
        /// <para>2. Download the application XML file. DownloadOneXmlFileForFlyer</para>
        /// <para>4. Upload the application XML file. Call of UploadOneXmlFileForFlyer</para>
        /// <para>5. Delete the temporary used local file. Call of File.Delete.</para>
        /// </summary>
        /// <param name="i_season_file_name">Full name of the XML file that shall be copied</param>
        /// <param name="i_season_directory_name">Name of the subdirectory for the copied file</param>
        /// <param name="o_error">Error description</param>
        private static bool CopyXmlApplicationFileToFlyer(out string o_error)
        {
            o_error = "";

            string error_message = "";

            string exe_path_local_dir = GetNameLocalTemporaryXmlDir();

            if (!DownloadOneXmlFileForFlyer(m_application_xml_filename, JazzAppAdminSettings.Default.XmlExistingDir, m_application_xml_filename, JazzAppAdminSettings.Default.XmlExistingDir, out error_message))
            {
                o_error = @"Flyer.CopyOneXmlSeasonFileToFlyer DownloadOneXmlFileForFlyer failed " + error_message;
                return false;
            }

            string upload_server_dir = "www/" + m_flyer_server_dir + "/" + m_flyer_admin_xml_dir;

            if (!UploadOneXmlFileForFlyer(m_application_xml_filename, JazzAppAdminSettings.Default.XmlExistingDir, m_application_xml_filename, upload_server_dir, out error_message))
            {
                o_error = @"Flyer.CopyXmlApplicationFileToFlyer UploadOneXmlFileForFlyer failed " + error_message;
                return false;
            }

            string temp_full_file_name = exe_path_local_dir + m_application_xml_filename;
            if (File.Exists(temp_full_file_name))
            {
                File.Delete(temp_full_file_name);
            }

            return true;

        } // CopyXmlApplicationFileToFlyer

        /// <summary>Download a temporary XML file for the Flyer application 
        /// <para>1. Download the XML file. Call of JazzFtp.Execute.Run for case DownloadFile</para>
        /// </summary>
        /// <param name="i_server_file_name">Name of the server XML file </param>
        /// <param name="i_server_dir">Server directory for i_server_file_name</param>
        /// <param name="i_local_name">Name of the local temporary file</param>
        /// <param name="i_local_dir">Local directory for i_local_name</param>
        /// <param name="o_error">Error description</param>
        private static bool DownloadOneXmlFileForFlyer(string i_server_file_name, string i_server_dir, string i_local_name, string i_local_dir, out string o_error)
        {
            o_error = "";

            JazzFtp.Input ftp_download_xml = new JazzFtp.Input(Main.ExeDirectory, Input.Case.DownloadFile);

            string download_server_dir = "www/" + i_server_dir;

            ftp_download_xml.ServerDirectory = download_server_dir;
            ftp_download_xml.ServerFileName = i_server_file_name;

            ftp_download_xml.LocalDirectory = i_local_dir;
            ftp_download_xml.LocalFileName = i_local_name;

            JazzFtp.Result ftp_result_download = JazzFtp.Execute.Run(ftp_download_xml);

            if (!ftp_result_download.Status)
            {
                o_error = @"Flyer.DownloadOneXmlFileForFlyer JazzFtp.Execute.Run case DownloadFile failed " + ftp_result_download.ErrorMsg;
                return false;
            }

            return true;

        } // DownloadOneXmlFileForFlyer


        /// <summary>Upload an XML file for the Flyer application 
        /// <para>1. Upload the XML file. Call of JazzFtp.Execute.Run for case DownloadFile</para>
        /// </summary>
        /// <param name="i_local_name">Name of the local temporary file</param>
        /// <param name="i_local_dir">Local directory for i_local_name</param>
        /// <param name="i_server_file_name">Name of the server XML file </param>
        /// <param name="i_server_dir">Server directory for i_server_file_name</param>
        /// <param name="o_error">Error description</param>
        private static bool UploadOneXmlFileForFlyer(string i_local_name, string i_local_dir, string i_server_file_name, string i_server_dir, out string o_error)
        {
            o_error = "";

            JazzFtp.Input ftp_upload_xml = new JazzFtp.Input(Main.ExeDirectory, Input.Case.UpLoadFile);

            ftp_upload_xml.LocalDirectory = i_local_dir;
            ftp_upload_xml.LocalFileName = i_local_name;

            ftp_upload_xml.ServerDirectory = i_server_dir;
            ftp_upload_xml.ServerFileName = i_server_file_name;

            JazzFtp.Result result_upload = JazzFtp.Execute.Run(ftp_upload_xml);

            if (!result_upload.Status)
            {
                o_error = @"Flyer.UploadOneXmlFileForFlyer JazzFtp.Execute.Run (UpLoadFile) failed " + result_upload.ErrorMsg;
                return false;
            }

            return true;

        } // UploadOneXmlFileForFlyer

        #endregion // Copy files with FTP

        #region Generate and save QR Codes

        /// <summary>Copy XML season files to the Flyer application directory with FTP
        /// <para>1. Get XML objects for the seasons that shall be updated. Call of GetXmlSeasonObjectsToCopy</para>
        /// <para>2. Get the subdirectory names for the seasons that shall be updated. Call of GetXmlSeasonSubdirectoryNames</para>
        /// <para>3. Loop for XML objects</para>
        /// <para>3.1 Set the current season document. Call of JazzApp.JazzXml.SetCurrentSeasonDocument</para>
        /// <para>3.2 Loop for all concerts </para>
        /// <para>3.2.1  Get website link. Call of JazzApp.JazzXml.GetBandWebsite</para>
        /// <para>3.2.2  Generate QR Code for website and save in local subdirectory QRCodes. Call of GenerateQrCodeAndSave</para>
        /// <para>3.2.3  Upload QR Code image for website. Call of UploadQrCodeImage</para>
        /// <para>3.2.4  Get sound link. Call of JazzApp.JazzXml.GetSoundSample</para>
        /// <para>3.2.5  Generate QR Code for sound and save in local subdirectory QRCodes. Call of GenerateQrCodeAndSave</para>
        /// <para>3.2.6  Upload QR Code image for sound. Call of UploadQrCodeImage</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public static bool GenerateAndSaveQrCodeImagesForFlyer(out string o_error)
        {
            o_error = "";

            string error_message = "";

            XDocument[] xml_season_objects = GetXmlSeasonObjectsToCopy(out error_message);
            if (null == xml_season_objects)
            {
                o_error = "GenerateAndSaveQrCodeImagesForFlyer.GetXmlSeasonObjectsToCopy failed " + error_message;
                return false;
            }

            string[] season_subdirectory_names = GetXmlSeasonSubdirectoryNames(out error_message);
            if (null == season_subdirectory_names)
            {
                o_error = "GenerateAndSaveQrCodeImagesForFlyer.GetXmlSeasonSubdirectoryNames failed " + error_message;
                return false;
            }

            if (xml_season_objects.Length != season_subdirectory_names.Length)
            {
                o_error = "GenerateAndSaveQrCodeImagesForFlyer.CopyXmlSeasonFilesToFlyer Number of season XML objects is not equal to number of subdirectory names";
                return false;
            }

            XDocument input_active_object = JazzApp.JazzXml.GetObjectActiveDoc();

            for (int index_obj = 0; index_obj < xml_season_objects.Length; index_obj++)
            {
                XDocument current_xml_obj = xml_season_objects[index_obj];

                JazzApp.JazzXml.SetCurrentSeasonDocument(current_xml_obj);

                string current_server_dir = season_subdirectory_names[index_obj];

                int n_concerts = JazzApp.JazzXml.GetNumberConcertsInCurrentDocument();

                for (int i_concert = 1; i_concert <= n_concerts; i_concert++)
                {

                    string link_web_site = JazzApp.JazzXml.GetBandWebsite(i_concert);
                    if (!GenerateQrCodeAndSave(link_web_site, i_concert, "website", out error_message))
                    {
                        o_error = "GenerateAndSaveQrCodeImagesForFlyer.CopyXmlSeasonFilesToFlyer GenerateQrCodeAndSave (website) failed " + error_message;
                        return false;
                    }

                    if (!UploadQrCodeImage(current_server_dir, i_concert, "website", out error_message))
                    {
                        o_error = "GenerateAndSaveQrCodeImagesForFlyer.CopyXmlSeasonFilesToFlyer UploadQrCodeImage (website) failed " + error_message;
                        return false;
                    }

                    string link_sound_sample = JazzApp.JazzXml.GetSoundSample(i_concert);
                    if (!GenerateQrCodeAndSave(link_sound_sample, i_concert, "sound", out error_message))
                    {
                        o_error = "GenerateAndSaveQrCodeImagesForFlyer.CopyXmlSeasonFilesToFlyer GenerateQrCodeAndSave (sound) failed " + error_message;
                        return false;
                    }

                    if (!UploadQrCodeImage(current_server_dir, i_concert, "sound", out error_message))
                    {
                        o_error = "GenerateAndSaveQrCodeImagesForFlyer.CopyXmlSeasonFilesToFlyer UploadQrCodeImage (sound) failed " + error_message;
                        return false;
                    }
                }

            } // index_obj


            if (null != input_active_object)
            {
                // JazzApp.JazzXml.SetObjectActiveDoc(input_active_object);
                JazzApp.JazzXml.SetCurrentSeasonDocument(input_active_object);
            }


            return true;

        } // GenerateAndSaveQrCodeImagesForFlyer


        /// <summary>Upload the QR Code image to the Flyer season subdirectory
        /// <para>1. Return if the link value not (yet) is set</para>
        /// <para>2. Create the input server subdirectory if not existing. Call of CreateFlyerSubdirIfNotExisting</para>
        /// <para>3. Get the name of the QR Code image file. Call of GetQrCodeFileNameNoExtension</para>
        /// <para>4. Upload the QR Code image. Call of UploadOneXmlFileForFlyer</para>
        /// <para>5. Delete the QR Code image in local ordner QRCodes. Call of File.Delete</para>
        /// </summary>
        /// <param name="i_link_str">Link to band website or sound sample</param>
        /// <param name="i_current_server_dir">Flyer season directory name</param>
        /// <param name="i_concert">Concert number</param>
        /// <param name="name_case">Case website or sound. Defines the QR Code Image file name</param>
        /// <param name="o_error">Error description</param>
        private static bool UploadQrCodeImage(string i_current_server_dir, int i_concert, string i_name_case, out string o_error)
        {
            o_error = "";

            string error_message = "";

            if (i_name_case.Equals("website") || i_name_case.Equals("sound"))
            {

            }
            else
            {
                o_error = "Flyer.UploadQrCodeImage Unvalid i_name_case= " + i_name_case;
                return false;
            }

            string upload_server_dir = "www/" + m_flyer_server_dir + "/" + m_flyer_admin_xml_dir + "/" + i_current_server_dir;

            if (!CreateFlyerSubdirIfNotExisting(upload_server_dir, out error_message))
            {
                o_error = @"Flyer.UploadQrCodeImage CreateFlyerSubdirIfNotExisting failed " + error_message;
                return false;
            }

            string mime_type = "png";

            string file_name_website_no_ext = GetQrCodeFileNameNoExtension(i_concert, i_name_case);

            string file_name_website = file_name_website_no_ext + "." + mime_type;

            if (!UploadOneXmlFileForFlyer(file_name_website, m_dir_qr_code_name, file_name_website, upload_server_dir, out error_message))
            {
                o_error = @"Flyer.UploadQrCodeImage UploadOneXmlFileForFlyer failed " + error_message;
                return false;
            }

            string name_temp_code_dir = GetNameLocalTemporaryQrCodeDir();

            string temp_full_file_name = name_temp_code_dir + file_name_website;
            if (File.Exists(temp_full_file_name))
            {
                File.Delete(temp_full_file_name);
            }

            return true;

        } // UploadQrCodeImage

        /// <summary>Returns the QR Code image file without extension
        /// <para></para>
        /// </summary>
        /// <param name="i_concert">Concert number</param>
        /// <param name="name_case">Case website or sound. Defines the QR Code Image file name</param>
        private static string GetQrCodeFileNameNoExtension(int i_concert, string name_case)
        {
            string ret_name = "";

            string file_name = "QrCode_Band_";
            if (i_concert <= 9)
            {
                file_name = file_name + "0" + i_concert.ToString();
            }
            else
            {
                file_name = file_name + i_concert.ToString();
            }

            if (name_case.Equals("website"))
            {
                file_name = file_name + "_Website";
            }
            else if (name_case.Equals("sound"))
            {
                file_name = file_name + "_Sound";
            }
            else
            {
                return ret_name;
            }

            ret_name = file_name;

            return ret_name;

        } // GetQrCodeFileNameNoExtension

        /// <summary>Generate QR Code and save the image in the local subdirectory QRCodes
        /// <para>1. If the input link value not (yet) is set: Set the link to an "undefined-image" on the homepage</para>
        /// <para>2. Get filename without extension. Call of GetQrCodeFileNameNoExtension</para>
        /// <para>3. Create the QR Code Bitmap (image). Call of QrCodeUtils.GenerateQrCodeImage</para>
        /// <para>4. Save the QR code image (format png). Call of QrCodeUtils.SaveQrCode </para>
        /// </summary>
        /// <param name="i_link_str">Link to band website or sound sample</param>
        /// <param name="i_concert">Concert number</param>
        /// <param name="name_case">Case website or sound. Defines the QR Code Image file name</param>
        /// <param name="o_error">Error description</param>
        private static bool GenerateQrCodeAndSave(string i_link_str, int i_concert, string name_case, out string o_error)
        {
            o_error = "";

            string mod_link_str = i_link_str;
            if (!JazzApp.JazzXml.XmlNodeValueIsSet(i_link_str))
            {
                mod_link_str = "http://jazzliveaarau.ch/Flyer/QrCodes/error_qr_code.png";
            }

            string file_name = GetQrCodeFileNameNoExtension(i_concert, name_case);

            string error_message = "";
            int image_size = 300;
            Bitmap bitmap_qr_code = QrCodeUtils.GenerateQrCodeImage(mod_link_str, image_size, out error_message);
            if (null == bitmap_qr_code)
            {
                o_error = "Flyer.GenerateQrCodeAndSave QrCodeUtils.GenerateQrCodeImage failed " + error_message;
                return false;
            }

            string name_temp_code_dir = GetNameLocalTemporaryQrCodeDir();

            string mime_type = "png";
            string file_name_path = name_temp_code_dir + file_name;
            if (!QrCodeUtils.SaveQrCode(bitmap_qr_code, file_name_path, mime_type, out error_message))
            {
                o_error = "Flyer.GenerateQrCodeAndSave QrCodeUtils.SaveQrCode failed " + error_message;
                return false;
            }

            return true;

        } // GenerateQrCodeAndSave

        #endregion // Generate and save QR Codes

        #region Files to copy

        /// <summary>Get the names of the season XML files that shall be copied
        /// <para>1. Get season start years for existing XML files. Call of JazzApp.JazzUtils.GetSeasonStartYearsForExistingXmlFiles()</para>
        /// <para>2. Loop all season start years</para>
        /// <para>2.1 Determine if XML season file shall be copied. Call of SeasonCopyCriterion</para>
        /// <para>2.2 If copy, get XML season file name. Call of JazzApp.JazzXml.GetSeasonFileName </para>
        /// <para>2.3 If copy, add XML season file name</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        static private string[] GetXmlSeasonSubdirectoryNames(out string o_error)
        {
            o_error = "";
            string[] ret_subdir_names = null;

            ArrayList array_list_subdir_names = new ArrayList();

            int[] seasons_start_years = JazzApp.JazzUtils.GetSeasonStartYearsForExistingXmlFiles();
            if (null == seasons_start_years)
            {
                o_error = "Flyer.GetXmlSeasonSubdirectoryNames JazzUtils.GetSeasonStartYearsForExistingXmlFiles failed";
                return ret_subdir_names;
            }

            string[] seasons_strings = JazzApp.JazzUtils.GetSeasonNamesForExistingXmlFiles(seasons_start_years);
            if (null == seasons_strings)
            {
                o_error = "Flyer.GetXmlSeasonSubdirectoryNames JazzUtils.GetSeasonNamesForExistingXmlFiles failed";
                return ret_subdir_names;
            }

            if (seasons_start_years.Length != seasons_strings.Length)
            {
                o_error = "Flyer.GetXmlSeasonSubdirectoryNames Number of season files is not equal to number of season names";
                return ret_subdir_names;
            }

            int size_seasons_files = seasons_start_years.Length;
            if (0 == size_seasons_files)
            {
                o_error = "Flyer.GetXmlSeasonSubdirectoryNames Number of season files is zero (0)";
                return ret_subdir_names;
            }

            for (int index_file = 0; index_file < size_seasons_files; index_file++)
            {
                int start_year = seasons_start_years[index_file];

                if (SeasonCopyCriterion(start_year))
                {
                    string season_name = seasons_strings[index_file];
                    string season_directory_name = season_name.Replace(" ", "_");

                    array_list_subdir_names.Add(season_directory_name);
                }

            }


            ret_subdir_names = (string[])array_list_subdir_names.ToArray(typeof(string));

            return ret_subdir_names;

        } // GetXmlSeasonSubdirectoryNames


        /// <summary>Get the names of the season XML files that shall be copied
        /// <para>1. Get season start years for existing XML files. Call of JazzApp.JazzUtils.GetSeasonStartYearsForExistingXmlFiles()</para>
        /// <para>2. Loop all season start years</para>
        /// <para>2.1 Determine if XML season file shall be copied. Call of SeasonCopyCriterion</para>
        /// <para>2.2 If copy, get XML season file name. Call of JazzApp.JazzXml.GetSeasonFileName </para>
        /// <para>2.3 If copy, add XML season file name</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        static private string[] GetXmlSeasonFileNamesToCopy(out string o_error)
        {
            o_error = "";
            string[] ret_file_names = null;

            ArrayList array_list_file_names = new ArrayList();

            int[] seasons_start_years = JazzApp.JazzUtils.GetSeasonStartYearsForExistingXmlFiles();
            if (null == seasons_start_years)
            {
                o_error = "Flyer.GetXmlSeasonFileNamesToCopy JazzUtils.GetSeasonStartYearsForExistingXmlFiles failed";
                return ret_file_names;
            }

            int size_seasons_files = seasons_start_years.Length;
            if (0 == size_seasons_files)
            {
                o_error = "Flyer.GetXmlSeasonFileNamesToCopy Number of season files is zero (0)";
                return ret_file_names;
            }

            for (int index_file = 0; index_file < size_seasons_files; index_file++)
            {
                int start_year = seasons_start_years[index_file];

                if (SeasonCopyCriterion(start_year))
                {
                    string season_file_name = JazzApp.JazzXml.GetSeasonFileName(seasons_start_years[index_file]);

                    array_list_file_names.Add(season_file_name);
                }

            }

            ret_file_names = (string[])array_list_file_names.ToArray(typeof(string));

            return ret_file_names;

        } // GetXmlSeasonFileNamesToCopy

        /// <summary>Get the season XML document objects for the files that have been copied to Flyer 
        /// <para>1. Get season start years for existing XML files. Call of JazzApp.JazzUtils.GetSeasonStartYearsForExistingXmlFiles()</para>
        /// <para>2. Get all XML document objects. Call of JazzApp.JazzXml.GetSeasonDocuments</para>
        /// <para>3. Loop all season start years</para>
        /// <para>3.1 Determine if XML season object shall be added. Call of SeasonCopyCriterion</para>
        /// <para>3.2 If to add, add the object to the output array </para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        static private XDocument[] GetXmlSeasonObjectsToCopy(out string o_error)
        {
            o_error = "";
            XDocument[] ret_xml_objects = null;

            ArrayList array_list_file_names = new ArrayList();

            XDocument[] season_xml_document_objects = JazzApp.JazzXml.GetSeasonDocuments();
            if (null == season_xml_document_objects)
            {
                o_error = @"Intranet.InitializeXml season_documents is null";
                return ret_xml_objects;
            }

            int[] seasons_start_years = JazzApp.JazzUtils.GetSeasonStartYearsForExistingXmlFiles();
            if (null == seasons_start_years)
            {
                o_error = "Flyer.GetXmlSeasonFileNamesToCopy JazzUtils.GetSeasonStartYearsForExistingXmlFiles failed";
                return ret_xml_objects;
            }

            if (season_xml_document_objects.Length != seasons_start_years.Length)
            {
                o_error = "Flyer.GetXmlSeasonFileNamesToCopy Number of season files is not equal to number of season XML objects";
                return ret_xml_objects;
            }

            int size_seasons_files = seasons_start_years.Length;
            if (0 == size_seasons_files)
            {
                o_error = "Flyer.GetXmlSeasonFileNamesToCopy Number of season files is zero (0)";
                return ret_xml_objects;
            }

            for (int index_file = 0; index_file < size_seasons_files; index_file++)
            {
                int start_year = seasons_start_years[index_file];

                if (SeasonCopyCriterion(start_year))
                {
                    XDocument season_xml_object = season_xml_document_objects[index_file];

                    array_list_file_names.Add(season_xml_object);
                }
            }

            ret_xml_objects = (XDocument[])array_list_file_names.ToArray(typeof(XDocument));

            return ret_xml_objects;

        } // GetXmlSeasonObjectsToCopy


        /// <summary>Returns true if season XML file for the input season shall be copied
        /// <para>1. Get current season start year. Call JazzApp.JazzUtils.GetCurrentSeasonStartYear</para>
        /// <para>2. If start year is greater or equal to current year return true, else false</para>
        /// </summary>
        /// <param name="i_start_year">Input season start year</param>
        private static bool SeasonCopyCriterion(int i_start_year)
        {
            //QQ 2021-01-24 int current_year = JazzApp.JazzUtils.GetCurrentYear();

            int current_season_start_year = JazzApp.JazzUtils.GetCurrentSeasonStartYear();

            if (i_start_year >= current_season_start_year)
            {
                return true;
            }
            else
            {
                return false;
            }

        } // SeasonCopyCriterion

        #endregion // Files to copy

        #region XML Edit subdirectories

        /// <summary>Create XML Edit directories for the Flyer application
        /// <para>1. Get XML edit subdirectory names. Call of GetXmlEditSubdirectoryNames</para>
        /// <para>2. Loop subdirectory names</para>
        /// <para>2.1 Create subdirectory if it doesn't exist. Call of CreateFlyerSubdirIfNotExisting</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        static private bool CreateXmlEditSubdirectories(out string o_error)
        {
            o_error = "";

            string error_message = "";

            string[] xml_edit_subdir_names = GetXmlEditSubdirectoryNames(out error_message);
            if (null == xml_edit_subdir_names)
            {
                o_error = "Flyer.CreateXmlEditSubdirectories failed " + error_message;
                return false;
            }

            for (int index_dir = 0; index_dir < xml_edit_subdir_names.Length; index_dir++)
            {
                string edit_text_season_server_subdir = xml_edit_subdir_names[index_dir];

                if (!CreateFlyerSubdirIfNotExisting(edit_text_season_server_subdir, out error_message))
                {
                    o_error = "Flyer.CreateXmlEditSubdirectories CreateFlyerSubdirIfNotExisting failed " + error_message;

                    return false;
                }
            }

            return true;

        } // CreateXmlEditSubdirectories


        /// <summary>Get the names of the Flyer (server) XML Edit subdirectory names 
        /// <para>1. Get season subdirectory names. Call of GetXmlSeasonSubdirectoryNames</para>
        /// <para>2. Loop all season subdirectory names</para>
        /// <para>2.1 Get season subdirectory name</para>
        /// <para>2.2 Add full path for the XML edit subdirectory name</para>
        /// <para>2.3 Add name to output array</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        static private string[] GetXmlEditSubdirectoryNames(out string o_error)
        {
            o_error = "";

            string[] ret_xml_edit_subdir_names = null;

            ArrayList array_list_xml_edit_subdir_names = new ArrayList();

            string error_message = "";

            string[] season_subdirectory_names = GetXmlSeasonSubdirectoryNames(out error_message);
            if (null == season_subdirectory_names)
            {
                o_error = "Flyer.GetXmlEditSubdirectoryNames failed " + error_message;
                return ret_xml_edit_subdir_names;
            }

            for (int index_dir = 0; index_dir < season_subdirectory_names.Length; index_dir++)
            {
                string season_subdir_name = season_subdirectory_names[index_dir];

                string xml_edit_subdir_name = "www/" + m_flyer_server_dir + "/" + m_flyer_edit_text_dir + "/" + season_subdir_name;

                array_list_xml_edit_subdir_names.Add(xml_edit_subdir_name);

            }

            ret_xml_edit_subdir_names = (string[])array_list_xml_edit_subdir_names.ToArray(typeof(string));


            return ret_xml_edit_subdir_names;

        } // GetXmlEditSubdirectoryNames

        #endregion // XML Edit subdirectories

        #region Create and upload XML Edit files

        /// <summary>Create and upload XML Edit files
        /// Not allowed XML value characters like '&' are removed. Calls of Website.ReplaceNotAllowedChars
        /// <para>1. Get XML season objects for which XML Edit files shall be created. Call of GetXmlSeasonObjectsToCopy</para>
        /// <para>2. Get XML subdirectory names for the XML Edit files. Call of GetXmlEditSubdirectoryNames</para></para>
        /// <para>3. Loop seasons (objects and subdirectories)</para>
        /// <para>3.1 Set current season document. Call of SetCurrentSeasonDocument </para>
        /// <para>3.2 Get number of concerts. Call of JazzApp.JazzXml.GetNumberConcertsInCurrentDocument </para>
        /// <para>3.3 Loop concerts. Call of JazzApp.JazzXml.GetNumberConcertsInCurrentDocument</para>
        /// <para>3.3.1 Get bandname. Call of  JazzApp.JazzXml.GetBandName</para>
        /// <para>3.3.2 Get all musician names. Call of JazzApp.JazzXml.GetMusiciansAsStrings</para>
        /// <para>3.3.3 Get all instruments. Call of JazzApp.JazzXml.GetInstrumentsAsStrings</para>
        /// <para>3.3.2 Get content for the XML Edit file. Call of GetContentXmlEditFile</para>
        /// <para>3.3.3 Get the file name with path for the XML Edit file. Call of GetXmlEditLocalFilePath</para>
        /// <para>3.3.4 Save the local the XML Edit file. Call of File.WriteAllText</para>
        /// <para>3.3.5 Upload the XML Edit file. Call of UploadOneXmlFileForFlyer</para>
        /// <para>3.3.6 Delete the temporary local XML Edit file. Call of File.Delete</para>
        /// </summary>
        /// <param name="i_progress_bar">Progress bar</param>
        /// <param name="i_textbox_message">Text box for messages</param>
        /// <param name="o_error">Error description</param>
        public static bool ExportXmlEditFilesToFlyer(ProgressBar i_progress_bar, TextBox i_textbox_message, out string o_error)
        {
            o_error = "";

            string error_message = "";

            i_progress_bar.PerformStep(); //1

            i_textbox_message.Text = @"XML Edit Dateien generieren und hochladen";
            i_textbox_message.Refresh();

            XDocument[] season_xml_objects = GetXmlSeasonObjectsToCopy(out error_message);
            if (null == season_xml_objects)
            {
                o_error = "Flyer.ExportXmlEditFilesToFlyer GetXmlSeasonObjectsToCopy failed " + error_message;

                return false;
            }

            string[] subdirectory_names = GetXmlEditSubdirectoryNames(out error_message);
            if (null == subdirectory_names)
            {
                o_error = "Flyer.ExportXmlEditFilesToFlyer GetXmlEditSubdirectoryNames failed " + error_message;

                return false;
            }

            if (season_xml_objects.Length != subdirectory_names.Length)
            {
                o_error = "Flyer.ExportXmlEditFilesToFlyer Number objects not equal to number of subdirectory names ";

                return false;
            }

            for (int index_season = 0; index_season < season_xml_objects.Length; index_season++)
            {
                XDocument current_xml_object = season_xml_objects[index_season];

                string current_subdirectory_name = subdirectory_names[index_season];

                JazzApp.JazzXml.SetCurrentSeasonDocument(current_xml_object);

                int n_concerts = JazzApp.JazzXml.GetNumberConcertsInCurrentDocument();

                for (int concert_number = 1; concert_number <= n_concerts; concert_number++)
                {

                    i_progress_bar.PerformStep();

                    i_textbox_message.Text = current_subdirectory_name + @" Konzert " + concert_number.ToString();
                    i_textbox_message.Refresh();

                    string band_name = Website.ReplaceNotAllowedChars(JazzApp.JazzXml.GetBandName(concert_number));

                    string[] all_musicians = SetEmptyStringXmlValuesToUndefined(ReplaceNotAllowedCharsArray(JazzApp.JazzXml.GetMusiciansAsStrings(concert_number)));

                    string[] all_instruments = SetEmptyStringXmlValuesToUndefined(ReplaceNotAllowedCharsArray(JazzApp.JazzXml.GetInstrumentsAsStrings(concert_number)));

                    string content_xml_edit_file = GetContentXmlEditFile(band_name, all_musicians, all_instruments, out error_message);

                    string full_local_file_name = GetXmlEditLocalFilePath(concert_number);

                    bool upload_xml_edit_file = false;
                    if (!DetermineIfXmlEditFileShallBeUploaded(XmlEditFileName(concert_number), JazzAppAdminSettings.Default.XmlExistingDir, XmlEditFileName(concert_number), current_subdirectory_name, concert_number, out upload_xml_edit_file, out error_message))
                    {
                        o_error = @"Flyer.ExportXmlEditFilesToFlyer UploadOneXmlFileForFlyer failed " + error_message;
                        return false;
                    }

                    if (upload_xml_edit_file)
                    {
                        File.WriteAllText(full_local_file_name, content_xml_edit_file);

                        if (!UploadOneXmlFileForFlyer(XmlEditFileName(concert_number), JazzAppAdminSettings.Default.XmlExistingDir, XmlEditFileName(concert_number), current_subdirectory_name, out error_message))
                        {
                            o_error = @"Flyer.ExportXmlEditFilesToFlyer UploadOneXmlFileForFlyer failed " + error_message;
                            return false;
                        }

                        if (File.Exists(full_local_file_name))
                        {
                            File.Delete(full_local_file_name);
                        }
                    }


                } // concert_number

            } // index_season


            return true;

        } // ExportXmlEditFilesToFlyer

        /// <summary>Create and upload XML Edit files TODO Remove Remove Remove
        /// Not allowed XML value characters like '&' are removed. Calls of Website.ReplaceNotAllowedChars
        /// <para>1. Get XML season objects for which XML Edit files shall be created. Call of GetXmlSeasonObjectsToCopy</para>
        /// <para>2. Get XML subdirectory names for the XML Edit files. Call of GetXmlEditSubdirectoryNames</para></para>
        /// <para>3. Loop seasons (objects and subdirectories)</para>
        /// <para>3.1 Set current season document. Call of SetCurrentSeasonDocument </para>
        /// <para>3.2 Get number of concerts. Call of JazzApp.JazzXml.GetNumberConcertsInCurrentDocument </para>
        /// <para>3.3 Loop concerts. Call of JazzApp.JazzXml.GetNumberConcertsInCurrentDocument</para>
        /// <para>3.3.1 Get bandname. Call of  JazzApp.JazzXml.GetBandName</para>
        /// <para>3.3.2 Get all musician names. Call of JazzApp.JazzXml.GetMusiciansAsStrings</para>
        /// <para>3.3.3 Get all instruments. Call of JazzApp.JazzXml.GetInstrumentsAsStrings</para>
        /// <para>3.3.2 Get content for the XML Edit file. Call of GetContentXmlEditFile</para>
        /// <para>3.3.3 Get the file name with path for the XML Edit file. Call of GetXmlEditLocalFilePath</para>
        /// <para>3.3.4 Save the local the XML Edit file. Call of File.WriteAllText</para>
        /// <para>3.3.5 Determine if the XML edit file shall be uploaded. Call of DetermineIfXmlEditFileShallBeUploaded</para>
        /// <para>3.3.6 Upload the XML Edit file. Call of UploadOneXmlFileForFlyer</para>
        /// <para>3.3.7 Delete the temporary local XML Edit file. Call of File.Delete</para>
        /// </summary>
        /// <param name="i_textbox_message">Message box</param>
        /// <param name="o_error">Error description</param>
        private static bool CreateUploadXmlEditFiles(TextBox i_textbox_message, out string o_error)
        {
            o_error = "";

            string error_message = "";

            XDocument[] season_xml_objects = GetXmlSeasonObjectsToCopy(out error_message);
            if (null == season_xml_objects)
            {
                o_error = "Flyer.CreateUploadXmlEditFiles GetXmlSeasonObjectsToCopy failed " + error_message;

                return false;
            }

            string[] subdirectory_names = GetXmlEditSubdirectoryNames(out error_message);
            if (null == subdirectory_names)
            {
                o_error = "Flyer.CreateUploadXmlEditFiles GetXmlEditSubdirectoryNames failed " + error_message;

                return false;
            }

            if (season_xml_objects.Length != subdirectory_names.Length)
            {
                o_error = "Flyer.CreateUploadXmlEditFiles Number objects not equal to number of subdirectory names ";

                return false;
            }

            for (int index_season = 0; index_season < season_xml_objects.Length; index_season++)
            {
                XDocument current_xml_object = season_xml_objects[index_season];

                string current_subdirectory_name = subdirectory_names[index_season];

                JazzApp.JazzXml.SetCurrentSeasonDocument(current_xml_object);

                int n_concerts = JazzApp.JazzXml.GetNumberConcertsInCurrentDocument();

                for (int concert_number = 1; concert_number <= n_concerts; concert_number++)
                {
                   
                    string band_name = Website.ReplaceNotAllowedChars(JazzApp.JazzXml.GetBandName(concert_number));

                    string[] all_musicians = SetEmptyStringXmlValuesToUndefined(ReplaceNotAllowedCharsArray(JazzApp.JazzXml.GetMusiciansAsStrings(concert_number)));

                    string[] all_instruments = SetEmptyStringXmlValuesToUndefined(ReplaceNotAllowedCharsArray(JazzApp.JazzXml.GetInstrumentsAsStrings(concert_number)));

                    string content_xml_edit_file = GetContentXmlEditFile(band_name, all_musicians, all_instruments, out error_message);

                    string full_local_file_name = GetXmlEditLocalFilePath(concert_number);

                    /* Temporary
                    if (!UploadXmlEditFileToFlyerNonEditDirectory(full_local_file_name, content_xml_edit_file, XmlEditFileName(concert_number), JazzAppAdminSettings.Default.XmlExistingDir, XmlEditFileName(concert_number), current_subdirectory_name, out error_message))
                    {
                        o_error = @"Flyer.CreateUploadXmlEditFiles UploadXmlEditFileToFlyerNonEditDirectory failed " + error_message;
                        return false;
                    }
                    Temporary */

                    bool upload_xml_edit_file = false;
                    if (!DetermineIfXmlEditFileShallBeUploaded(XmlEditFileName(concert_number), JazzAppAdminSettings.Default.XmlExistingDir, XmlEditFileName(concert_number), current_subdirectory_name, concert_number, out upload_xml_edit_file, out error_message))
                    {
                        o_error = @"Flyer.CreateUploadXmlEditFiles UploadOneXmlFileForFlyer failed " + error_message;
                        return false;
                    }

                    if (upload_xml_edit_file)
                    {
                        i_textbox_message.Text = XmlEditFileName(concert_number) + @" Ordner " + current_subdirectory_name;
                        i_textbox_message.Refresh();

                        File.WriteAllText(full_local_file_name, content_xml_edit_file);

                        if (!UploadOneXmlFileForFlyer(XmlEditFileName(concert_number), JazzAppAdminSettings.Default.XmlExistingDir, XmlEditFileName(concert_number), current_subdirectory_name, out error_message))
                        {
                            o_error = @"Flyer.CreateUploadXmlEditFiles UploadOneXmlFileForFlyer failed " + error_message;
                            return false;
                        }

                        if (File.Exists(full_local_file_name))
                        {
                            File.Delete(full_local_file_name);
                        }
                    }


                } // concert_number

            } // index_season


            return true;

        } // CreateUploadXmlEditFiles

        /// <summary>Upload an XML edit file to the directory m_flyer_edit_text_original_dir.
        /// This file will make it possible for the user to change band name, musician name
        /// and instruments (lineup data) in the flyer application when edit data has been 
        /// changed (written).
        /// <para>1. Create the subdirectory m_flyer_edit_text_original_dir. Call of CreateFlyerSubdirIfNotExisting</para>
        /// <para>2. Upload he file to this directory. Call of </para>
        /// </summary>
        /// <param name="i_local_name">Name of the local temporary file</param>
        /// <param name="i_local_dir">Local directory for i_local_name</param>
        /// <param name="i_server_file_name">Name of the server XML file </param>
        /// <param name="i_parent_server_dir">Parent server directory for i_server_file_name</param>
        /// <param name="o_error">Error description</param>
        private static bool UploadXmlEditFileToFlyerNonEditDirectory(string i_full_local_file_name, string i_content_xml_edit_file, string i_local_name, string i_local_dir, string i_server_file_name, string i_parent_server_dir, out string o_error)
        {
            o_error = "";

            string error_message = "";

            string upload_server_original_dir = i_parent_server_dir + "/" + m_flyer_edit_text_original_dir;

            if (!CreateFlyerSubdirIfNotExisting(upload_server_original_dir, out error_message))
            {
                o_error = @"Flyer.UploadXmlEditFileToFlyerNonEditDirectory Failed creating subdirectory " + upload_server_original_dir;
                return false;
            }

            File.WriteAllText(i_full_local_file_name, i_content_xml_edit_file);

            if (!UploadOneXmlFileForFlyer(i_local_name, i_local_dir, i_server_file_name, upload_server_original_dir, out error_message))
            {
                o_error = @"Flyer.UploadXmlEditFileToFlyerNonEditDirectory UploadOneXmlFileForFlyer failed " + error_message;
                return false;
            }

            if (File.Exists(i_full_local_file_name))
            {
                File.Delete(i_full_local_file_name);
            }

            return true;

        } // UploadXmlEditFileToFlyerNonEditDirectory


        /// <summary>Determines if the XML Edit shall be uploaded to the Flyer web application
        /// <para>Do not upload criterion: The short text, musician text or additional text have been set.</para>
		/// <para>1. Determine if the file exists on the server. Call of XmlEditFileExists</para>
		/// <para>2. Set output boolean o_upload_file to true and return if file not exists. </para>
		/// <para>3. Download the XML file. Call of JazzFtp.Execute.Run for case DownloadFile</para>
		/// <para>4. Set output boolean o_upload_file to true if texts not have been set. Calls of File.Contains</para>
        /// <para>5. Delete the temporary downloaded XML file. Call of File.Delete</para>
        /// </summary>
        /// <param name="i_local_name">Name of the local temporary file</param>
        /// <param name="i_local_dir">Local directory for i_local_name</param>
        /// <param name="i_server_file_name">Name of the server XML file </param>
        /// <param name="i_server_dir">Server directory for i_server_file_name</param>
        /// <param name="i_concert_number">Concert number</param>
		/// <param name="o_upload_file">Flag telling if the file shall be uploaded</param>
        /// <param name="o_error">Error description</param>
        private static bool DetermineIfXmlEditFileShallBeUploaded(string i_local_name, string i_local_dir, string i_server_file_name, string i_server_dir, int i_concert_number, out bool o_upload_file, out string o_error)
        {
            o_error = "";

            string error_message = "";

            o_upload_file = false;

            bool xml_edit_file_exists = false;

            if (!XmlEditFileExists(i_local_name, i_local_dir, i_server_file_name, i_server_dir, out xml_edit_file_exists, out error_message))
            {
                o_error = "Flyer.DetermineIfXmlEditFileShallBeUploaded XmlEditFileExists failed";
                return false;
            }

            if (!xml_edit_file_exists)
            {
                o_upload_file = true;
                return true;
            }

            JazzFtp.Input ftp_download_xml = new JazzFtp.Input(Main.ExeDirectory, Input.Case.DownloadFile);

            ftp_download_xml.LocalDirectory = i_local_dir;
            ftp_download_xml.LocalFileName = i_local_name;

            ftp_download_xml.ServerDirectory = i_server_dir;
            ftp_download_xml.ServerFileName = i_server_file_name;

            JazzFtp.Result result_download = JazzFtp.Execute.Run(ftp_download_xml);

            if (!result_download.Status)
            {
                o_error = @"Flyer.DetermineIfXmlEditFileShallBeUploaded JazzFtp.Execute.Run (DownloadFile) failed " + result_download.ErrorMsg;
                return false;
            }

            string full_local_file_name = GetXmlEditLocalFilePath(i_concert_number);

            string xml_file_content = File.ReadAllText(full_local_file_name, Encoding.UTF8);

            bool short_text_not_set = xml_file_content.Contains(GetXmlElementUndefinedShortText());

            bool free_flyer_text_not_set = xml_file_content.Contains(GetXmlElementUndefinedFlyerText());

            bool musician_text_not_set = xml_file_content.Contains(GetXmlElementUndefinedMusicianText());

            if (short_text_not_set && free_flyer_text_not_set && musician_text_not_set)
            {
                o_upload_file = true;
            }
            else
            {
                o_upload_file = false;
            }

            if (File.Exists(full_local_file_name))
            {
                File.Delete(full_local_file_name);
            }

            return true;

        } // DetermineIfXmlEditFileShallBeUploaded

        /// <summary>Determines if the XML Edit file exits
		/// <para>1. Check existance of the XML file. Call of JazzFtp.Execute.Run for case FileExists</para>
        /// </summary>
        /// <param name="i_local_name">Name of the local temporary file</param>
        /// <param name="i_local_dir">Local directory for i_local_name</param>
        /// <param name="i_server_file_name">Name of the server XML file </param>
        /// <param name="i_server_dir">Server directory for i_server_file_name</param>
        /// <param name="o_file_exists">Returns true if the file already exists on the server</param>
        /// <param name="o_error">Error description</param>
        private static bool XmlEditFileExists(string i_local_name, string i_local_dir, string i_server_file_name, string i_server_dir, out bool o_file_exists, out string o_error)
        {
            o_error = "";

            o_file_exists = false;

            JazzFtp.Input ftp_file_exists_xml = new JazzFtp.Input(Main.ExeDirectory, Input.Case.FileExists);

            ftp_file_exists_xml.LocalDirectory = i_local_dir;
            ftp_file_exists_xml.LocalFileName = i_local_name;

            ftp_file_exists_xml.ServerDirectory = i_server_dir;
            ftp_file_exists_xml.ServerFileName = i_server_file_name;

            JazzFtp.Result result_check_existance = JazzFtp.Execute.Run(ftp_file_exists_xml);

            if (!result_check_existance.Status)
            {
                o_error = @"Flyer.XmlEditFileExists JazzFtp.Execute.Run (FileExists) failed " + result_check_existance.ErrorMsg;
                return false;
            }

            o_file_exists = result_check_existance.BoolResult;
 
            return true;

        } // XmlEditFileExists	

        /// <summary>Returns an array where '&' and other characters that not are allowed as an XML value</summary>
        /// <param name="i_str_array">Input string array</param>
        private static string[] ReplaceNotAllowedCharsArray(string[] i_str_array)
        {
            string[] ret_str_array = null;
            if (null == i_str_array)
            {
                return ret_str_array;
            }

            int array_length = i_str_array.Length;

            ret_str_array = new string[array_length];

            for (int index_repl=0; index_repl<array_length; index_repl++)
            {
                ret_str_array[index_repl] = Website.ReplaceNotAllowedChars(i_str_array[index_repl]);
            }

            return ret_str_array;

        } // ReplaceNotAllowedCharsArray

        /// <summary>Returns an array where empty strings are replaced with GetUndefinedNodeValue()</summary>
        /// <param name="i_str_array">Input string array</param>
        private static string[] SetEmptyStringXmlValuesToUndefined(string[] i_str_array)
        {
            string[] ret_str_array = null;
            if (null == i_str_array)
            {
                return ret_str_array;
            }

            int array_length = i_str_array.Length;

            ret_str_array = new string[array_length];

            for (int index_repl = 0; index_repl < array_length; index_repl++)
            {
                if (i_str_array[index_repl].Length == 0)
                {
                    ret_str_array[index_repl] = JazzApp.JazzXml.GetUndefinedNodeValue();
                }
                else
                {
                    ret_str_array[index_repl] = i_str_array[index_repl];
                }               
            }

            return ret_str_array;

        } // SetEmptyStringXmlValuesToUndefined

        /// <summary>Returns the full name of the local XML Edit file</summary>
        private static string GetXmlEditLocalFilePath(int i_concert_number)
        {
            string local_dir = GetNameLocalTemporaryXmlDir();

            string file_name = XmlEditFileName(i_concert_number);

            return local_dir + file_name;

        } // GetXmlEditLocalFilePath

        /// <summary>Returns the name of the XML Edit file</summary>
        private static string XmlEditFileName(int i_concert_number)
        {
            return m_flyer_xml_edit_file_name_start + i_concert_number.ToString() + ".xml";

        } // XmlEditFileName


        /// <summary>Returns the content for an XML Edit file
        /// <para>1. Check input data. Call of GetContentXmlEditFileCheckInput</para>
        /// </summary>
        /// <param name="i_band_name">Band name</param>
        /// <param name="i_musician_names">Musician name array</param>
        /// <param name="i_musician_instruments">Instrument array</param>
        /// <param name="o_error">Error description</param>
        private static string GetContentXmlEditFile(string i_band_name, string[] i_musician_names, string[] i_musician_instruments, out string o_error)
        {
            string ret_content_xml_edit = "";

            o_error = "";

            if (!GetContentXmlEditFileCheckInput(i_band_name, i_musician_names, i_musician_instruments, out o_error))
            {
                return ret_content_xml_edit;
            }

            int n_musicians = i_musician_names.Length;

            ret_content_xml_edit = ret_content_xml_edit + m_xml_subdirectory_header + NewLine();

            ret_content_xml_edit = ret_content_xml_edit + NewLine();

            ret_content_xml_edit = ret_content_xml_edit + m_xml_edit_comment + NewLine();

            ret_content_xml_edit = ret_content_xml_edit + NewLine();

            // Start tag
            ret_content_xml_edit = ret_content_xml_edit + "<" + m_tag_xml_concert_texts + ">" + NewLine();

            // Concert tag
            ret_content_xml_edit = ret_content_xml_edit + "  <" + JazzApp.JazzXml.GetTagDocConcert() + ">" + NewLine();

            // Publish text flag
            ret_content_xml_edit = ret_content_xml_edit + TabFour() + "<" + m_tag_publish_flyer_text + ">";

            ret_content_xml_edit = ret_content_xml_edit + "FALSE" + "</" + m_tag_publish_flyer_text + ">" + NewLine();

            // Band name
            ret_content_xml_edit = ret_content_xml_edit + TabFour() + "<" + JazzApp.JazzXml.GetTagConcertBandName() + ">";

            ret_content_xml_edit = ret_content_xml_edit + i_band_name + "</" + JazzApp.JazzXml.GetTagConcertBandName() + ">" + NewLine();

            // Short text
            ret_content_xml_edit = ret_content_xml_edit + TabFour() + GetXmlElementUndefinedShortText() + NewLine();

            // Label additional text
            ret_content_xml_edit = ret_content_xml_edit + TabFour() + "<" + JazzApp.JazzXml.GetTagConcertLabelAdditionalText() + ">";

            ret_content_xml_edit = ret_content_xml_edit + JazzApp.JazzXml.GetUndefinedNodeValue() + "</" + JazzApp.JazzXml.GetTagConcertLabelAdditionalText() + ">" + NewLine();

            // Additional text
            ret_content_xml_edit = ret_content_xml_edit + TabFour() + GetXmlElementUndefinedAdditionalText() + NewLine();

            // Label flyer text
            ret_content_xml_edit = ret_content_xml_edit + TabFour() + "<" + JazzApp.JazzXml.GetTagConcertLabelFlyerText() + ">";

            ret_content_xml_edit = ret_content_xml_edit + JazzApp.JazzXml.GetUndefinedNodeValue() + "</" + JazzApp.JazzXml.GetTagConcertLabelFlyerText() + ">" + NewLine();

            // Flyer text
            ret_content_xml_edit = ret_content_xml_edit + TabFour() + GetXmlElementUndefinedFlyerText() + NewLine();

            // Musicians start tag
            ret_content_xml_edit = ret_content_xml_edit + TabFour() + "<" + m_tag_xml_musicians + ">" + NewLine();

            for (int index_musician=0; index_musician<n_musicians; index_musician++)
            {
                // Musician start tag
                ret_content_xml_edit = ret_content_xml_edit + TabFour() + TabFour() + "<" + m_tag_xml_musician + ">" + NewLine();

                // Musician name
                ret_content_xml_edit = ret_content_xml_edit + TabFour() + TabFour() + TabFour() + "<" + JazzApp.JazzXml.GetTagMusicianName() + ">";

                ret_content_xml_edit = ret_content_xml_edit + i_musician_names[index_musician] + "</" + JazzApp.JazzXml.GetTagMusicianName() + ">" + NewLine();

                // Instrument
                ret_content_xml_edit = ret_content_xml_edit + TabFour() + TabFour() + TabFour() + "<" + JazzApp.JazzXml.GetTagMusicianInstrument() + ">";

                ret_content_xml_edit = ret_content_xml_edit + i_musician_instruments[index_musician] + "</" + JazzApp.JazzXml.GetTagMusicianInstrument() + ">" + NewLine();
                    
                // Musician text
                ret_content_xml_edit = ret_content_xml_edit + TabFour() + TabFour() + TabFour() + GetXmlElementUndefinedMusicianText() + NewLine();

                // Musician end tag
                ret_content_xml_edit = ret_content_xml_edit + TabFour() + TabFour() + "</" + m_tag_xml_musician + ">" + NewLine();

            } // index_musician

            // Musicians end tag
            ret_content_xml_edit = ret_content_xml_edit + TabFour() + "</" + m_tag_xml_musicians + ">" + NewLine();

            // Concert end tag
            ret_content_xml_edit = ret_content_xml_edit + "  </" + JazzApp.JazzXml.GetTagDocConcert() + ">" + NewLine();

            // End tag
            ret_content_xml_edit = ret_content_xml_edit + "</" + m_tag_xml_concert_texts + ">" + NewLine();

            return ret_content_xml_edit;

        } // GetContentXmlEditFile

        /// <summary>Returns undefined XML element short text</summary>
        private static string GetXmlElementUndefinedShortText()
        {
            return "<" + JazzApp.JazzXml.GetTagConcertShortText() + ">" + m_short_text_default + "</" + JazzApp.JazzXml.GetTagConcertShortText() + ">";

        } // GetXmlElementUndefinedShortText

        /// <summary>Returns undefined XML element additional text</summary>
        private static string GetXmlElementUndefinedAdditionalText()
        {
            return "<" + JazzApp.JazzXml.GetTagConcertAdditionalText() + ">" + JazzApp.JazzXml.GetUndefinedNodeValue() + "</" + JazzApp.JazzXml.GetTagConcertAdditionalText() + ">";

        } // GetXmlElementUndefinedAdditionalText

        /// <summary>Returns undefined XML element flyer text</summary>
        private static string GetXmlElementUndefinedFlyerText()
        {
            return "<" + JazzApp.JazzXml.GetTagConcertFlyerText() + ">" + JazzApp.JazzXml.GetUndefinedNodeValue() + "</" + JazzApp.JazzXml.GetTagConcertFlyerText() + ">";

        } // GetXmlElementUndefinedFlyerText

        /// <summary>Returns undefined XML element musician text</summary>
        private static string GetXmlElementUndefinedMusicianText()
        {
            return "<" + JazzApp.JazzXml.GetTagMusicianText() + ">" + m_musician_text_default + "</" + JazzApp.JazzXml.GetTagMusicianText() + ">";

        } // GetXmlElementUndefinedMusicianText

        /// <summary>Checks the input data for function GetContentXmlEditFile </summary>
        /// <param name="i_band_name">Band name</param>
        /// <param name="i_musician_names">Musician name array</param>
        /// <param name="i_musician_instruments">Instrument array</param>
        /// <param name="o_error">Error description</param>
        private static bool GetContentXmlEditFileCheckInput(string i_band_name, string[] i_musician_names, string[] i_musician_instruments, out string o_error)
        {
            o_error = "";

            if (i_band_name.Length == 0)
            {
                o_error = "Flyer.GetContentXmlEditFileCheckInput i_band_name not set";

                return false;
            }

            if (i_musician_names == null || i_musician_names.Length == 0)
            {
                o_error = "Flyer.GetContentXmlEditFileCheckInput i_musician_names null or has length 0";

                return false;
            }

            if (i_musician_instruments == null || i_musician_instruments.Length == 0)
            {
                o_error = "Flyer.GetContentXmlEditFileCheckInput i_musician_instruments null or has length 0";

                return false;
            }

            if (i_musician_names.Length != i_musician_instruments.Length)
            {
                o_error = "Flyer.GetContentXmlEditFileCheckInput Number of musicians and instruments are not equal";

                return false;
            }

            return true;

        } // GetContentXmlEditFileCheckInput


        #endregion // Create and upload XML Edit files

        #region Export Flyer Images

        /// <summary>Get server path and name for the flyer image 
        /// <para>If document XML object not yet exists for the season (bandnames=null) return path and name for "undefined-flyer-image"</para>
        /// <para>1. Set active bandname. Call of  DocAllFlyer.ActiveBandName</para>
        /// <para>2. Get all documents for the active bandname. Call of DocAllFlyer.SetAllConcertDocumentsForActiveBandName</para>
        /// <para>3. Set documents for the active bandname. Call of DocAllFlyer.AllConcertDocuments</para>
        /// <para>4. Loop for XML objects</para>
        /// <para>4.1 Get template name for the current document. Call of JazzDoc.TemplateName</para>
        /// <para>4.2 If template name equals PATH_Flyer_Start</para>
        /// <para>4.2.1  Get path and file name. Calls of JazzDoc.FilePath and JazzDoc.FileNameImg</para>
        /// </summary>
        /// <param name="i_index_doc">Index for concert</param>
        /// <param name="i_all_band_names">All bandnames</param>
        /// <param name="o_image_file_path">Output server path</param>
        /// <param name="o_image_file_name">Output server name</param>
        /// <param name="o_error">Error description</param>
        private static bool GetImagePathFilename(int i_index_doc, string[] i_all_band_names, ref string o_image_file_path, ref string o_image_file_name, out string o_error)
        {
            o_error = @"";

            o_image_file_path = "";

            o_image_file_name = "";

            if (i_all_band_names == null)
            {
                o_image_file_path = m_path_not_yet_set_image;

                o_image_file_name = m_name_not_yet_set_image;

                return true;
            }

            DocAllFlyer.ActiveBandName = i_all_band_names[i_index_doc];

            if (!DocAllFlyer.SetAllConcertDocumentsForActiveBandName(out o_error))
            {
                o_error = @"Flyer.GetImagePathFilename DocAllFlyer.SetAllConcertDocuments failed " + o_error;
                return false;
            }

            JazzApp.JazzDoc[] all_concert_docs = DocAllFlyer.AllConcertDocuments;

            int n_all_concert_docs = all_concert_docs.Length;

            for (int index_doc = 0; index_doc < n_all_concert_docs; index_doc++)
            {
                JazzApp.JazzDoc current_doc = all_concert_docs[index_doc];

                string template_name = current_doc.TemplateName;

                if (template_name.Equals("PATH_Flyer_Start"))
                {
                    o_image_file_path = current_doc.FilePath;

                    o_image_file_name = current_doc.FileNameImg;

                    if (!JazzApp.JazzXml.XmlNodeValueIsSet(o_image_file_name))
                    {
                        o_image_file_path = m_path_not_yet_set_image;

                        o_image_file_name = m_name_not_yet_set_image;

                    }

                    break;
                }

            } // index_doc

            if (o_image_file_path.Length == 0 || o_image_file_name.Length == 0)
            {
                o_error = @"Flyer.GetImagePathFilename Image name and/or File path has no value";
                return false;
            }

            return true;

        } // GetImagePathFilename

        /// <summary>Returns the server image file name 
        /// <para></para>
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        private static string ConstructExportFlyerFileName(int i_concert_number)
        {
            string ret_name = "";

            ret_name = ret_name + m_start_part_export_flyer_image_name;

            if (i_concert_number <= 9)
            {
                ret_name = ret_name + "0" + i_concert_number.ToString();
            }
            else
            {
                ret_name = ret_name + i_concert_number.ToString();
            }

            ret_name = ret_name + ".jpg";

            return ret_name;

        } // ConstructExportFlyerFileName

        #endregion // Export Flyer Images

        #region List of subdirectories

        /// <summary>Create XML file that lists the subdirectories that have been updated
        /// <para>1. Get season subdirectory names. Call of GetXmlSeasonSubdirectoryNames</para>
        /// <para>2. Write XML content to a string.</para>
        /// <para>3. Create temporary XML file in subdirectory XML. Call of File.WriteAllText</para>
        /// <para>4. Upload file to the Flyer subdirectory XmlAdmin. Call of UploadOneXmlFileForFlyer</para>
        /// <para>5. Delete the temporary XML file in subdirectory XML. Call of File.Delete</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static bool CreateAndSaveXmlListOfSubdirectories(out string o_error)
        {
            o_error = "";

            string error_message = "";

            string[] season_subdir_names = GetXmlSeasonSubdirectoryNames(out error_message);

            string content_xml_file = "";

            content_xml_file = content_xml_file + m_xml_subdirectory_header + NewLine();

            content_xml_file = content_xml_file + NewLine();

            content_xml_file = content_xml_file + m_xml_subdirectory_comment + NewLine();

            content_xml_file = content_xml_file + NewLine();

            content_xml_file = content_xml_file + "<" + m_tag_subdirectories + ">" + NewLine();

            for (int index_dir=0; index_dir< season_subdir_names.Length; index_dir++)
            {
                content_xml_file = content_xml_file + "    ";
                content_xml_file = content_xml_file + "<" + m_tag_subdirectory + ">";
                string dir_name = season_subdir_names[index_dir];
                content_xml_file = content_xml_file + dir_name;
                content_xml_file = content_xml_file + "</" + m_tag_subdirectory + ">";
                content_xml_file = content_xml_file + NewLine();
            }

            content_xml_file = content_xml_file + "</" + m_tag_subdirectories + ">" + NewLine();

            string file_name_relative_path = JazzAppAdminSettings.Default.XmlExistingDir + @"\" + m_flyer_xml_subdirs_file_name;

            File.WriteAllText(file_name_relative_path, content_xml_file);

            string upload_server_dir = "www/" + m_flyer_server_dir + "/" + m_flyer_admin_xml_dir;

            if (!UploadOneXmlFileForFlyer(m_flyer_xml_subdirs_file_name, JazzAppAdminSettings.Default.XmlExistingDir, m_flyer_xml_subdirs_file_name, upload_server_dir, out error_message))
            {
                o_error = @"Flyer.CopyXmlApplicationFileToFlyer UploadOneXmlFileForFlyer failed " + error_message;
                return false;
            }

            if (File.Exists(file_name_relative_path))
            {
                File.Delete(file_name_relative_path);
            }

            return true;

        } // CreateAndSaveXmlListOfSubdirectories

        #endregion // List of subdirectories

        #region List of users and passwords

        /// <summary>Create XML file that lists the users and passwords
        /// <para>1. Get user names. Call of GetUserNames</para>
		/// <para>2. Get user passwords. Call of GetUserPasswords</para>
        /// <para>3. Write XML content to a string.</para>
        /// <para>4. Create temporary XML file in subdirectory XML. Call of File.WriteAllText</para>
        /// <para>5. Delete the temporary XML file in subdirectory XML. Call of File.Delete</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static bool CreateAndSaveXmlListOfUsersPasswords(out string o_error)
        {
            o_error = "";

            string error_message = "";

            string[] user_names = GetUserNames();

            string[] user_passwords = GetUserPasswords();

            string content_users_xml_file = "";

            content_users_xml_file = content_users_xml_file + m_xml_subdirectory_header + NewLine();

            content_users_xml_file = content_users_xml_file + NewLine();

            content_users_xml_file = content_users_xml_file + m_xml_users_passwords_comment + NewLine();

            content_users_xml_file = content_users_xml_file + NewLine();

            content_users_xml_file = content_users_xml_file + "<" + m_tag_users_passwords + ">" + NewLine();

            for (int index_dir = 0; index_dir < user_names.Length; index_dir++)
            {
                content_users_xml_file = content_users_xml_file + "    ";
                content_users_xml_file = content_users_xml_file + "<" + m_tag_user_name + ">";
                string user_name = user_names[index_dir];
                content_users_xml_file = content_users_xml_file + user_name;
                content_users_xml_file = content_users_xml_file + "</" + m_tag_user_name + ">";
                content_users_xml_file = content_users_xml_file + NewLine();

                content_users_xml_file = content_users_xml_file + "    ";
                content_users_xml_file = content_users_xml_file + "<" + m_tag_user_password + ">";
                string user_password = user_passwords[index_dir];
                content_users_xml_file = content_users_xml_file + user_password;
                content_users_xml_file = content_users_xml_file + "</" + m_tag_user_password + ">";
                content_users_xml_file = content_users_xml_file + NewLine();

            }

            content_users_xml_file = content_users_xml_file + "    ";
            content_users_xml_file = content_users_xml_file + "<" + m_tag_season_start_year + ">";
            string season_start_year = JazzApp.JazzUtils.GetCurrentYear().ToString();
            content_users_xml_file = content_users_xml_file + season_start_year;
            content_users_xml_file = content_users_xml_file + "</" + m_tag_season_start_year + ">";
            content_users_xml_file = content_users_xml_file + NewLine();

            content_users_xml_file = content_users_xml_file + "</" + m_tag_users_passwords + ">" + NewLine();

            string file_name_users_relative_path = JazzAppAdminSettings.Default.XmlExistingDir + @"\" + m_flyer_xml_users_passwords_file_name;

            File.WriteAllText(file_name_users_relative_path, content_users_xml_file);

            string upload_server_dir = "www/" + m_flyer_server_dir + "/" + m_flyer_admin_xml_dir;

            bool b_upload_file = XmlListOfUsersPasswordsShallBeUploaded(upload_server_dir, m_flyer_xml_users_passwords_file_name, out error_message);

            if (!b_upload_file)
            {
                return true;
            }

            if (!UploadOneXmlFileForFlyer(m_flyer_xml_users_passwords_file_name, JazzAppAdminSettings.Default.XmlExistingDir, m_flyer_xml_users_passwords_file_name, upload_server_dir, out error_message))
            {
                o_error = @"Flyer.CopyXmlApplicationFileToFlyer UploadOneXmlFileForFlyer failed " + error_message;
                return false;
            }

            if (File.Exists(file_name_users_relative_path))
            {
                File.Delete(file_name_users_relative_path);
            }

            return true;

        } // CreateAndSaveXmlListOfUsersPasswords

        /// <summary>Returns true if the XML file that lists the users and passwords shall be uploaded
        /// <para>Criterion is (for the moment) if the file already exists, do not upload</para>
		/// <para>2. Get user passwords. Call of GetUserPasswords</para>
        /// <para>3. Write XML content to a string.</para>
        /// <para>4. Create temporary XML file in subdirectory XML. Call of File.WriteAllText</para>
        /// <para>5. Delete the temporary XML file in subdirectory XML. Call of File.Delete</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        private static bool XmlListOfUsersPasswordsShallBeUploaded(string i_upload_server_dir, string i_upload_server_file_name, out string o_error)
        {
            o_error = "";

            bool file_exists = false;

            JazzFtp.Input ftp_file_exists_xml = new JazzFtp.Input(Main.ExeDirectory, Input.Case.FileExists);

            ftp_file_exists_xml.ServerDirectory = i_upload_server_dir;
            ftp_file_exists_xml.ServerFileName = i_upload_server_file_name;

            JazzFtp.Result result_check_existance = JazzFtp.Execute.Run(ftp_file_exists_xml);

            if (!result_check_existance.Status)
            {
                o_error = @"Flyer.XmlListOfUsersPasswordsShallBeUploaded JazzFtp.Execute.Run (FileExists) failed " + result_check_existance.ErrorMsg;
                return file_exists;
            }

            file_exists = result_check_existance.BoolResult;

            if (file_exists)
            {
                return false;
            }
            else
            {
                return true;
            }

        } // XmlListOfUsersPasswordsShallBeUploaded

        /// <summary>Returns user names</summary>
        private static string[] GetUserNames()
        {
            string[] ret_user_names = null;

            ArrayList array_list_user_names = new ArrayList();

            for (int concert_number=1; concert_number <= 12; concert_number++)
            {
                string concert_number_formatted = concert_number.ToString();
                if (concert_number_formatted.Length == 1)
                {
                    concert_number_formatted = "0" + concert_number_formatted;
                }

                string user_name = m_start_user_name + " " + concert_number_formatted;

                array_list_user_names.Add(user_name);

            }

            array_list_user_names.Add(m_admin_name);

            array_list_user_names.Add(m_printer_name);

            array_list_user_names.Add(m_tester_name);


            ret_user_names = (string[])array_list_user_names.ToArray(typeof(string));

            return ret_user_names;

        } // GetUserNames

        /// <summary>Returns user passwords</summary>
        private static string[] GetUserPasswords()
        {
            string[] ret_user_passwords = null;

            ArrayList array_list_user_passwords = new ArrayList();

            for (int concert_number = 1; concert_number <= 12; concert_number++)
            {
                string user_password = m_start_user_password + concert_number.ToString();

                array_list_user_passwords.Add(user_password);

            }

            array_list_user_passwords.Add(m_admin_password);

            array_list_user_passwords.Add(m_printer_password);

            array_list_user_passwords.Add(m_tester_password);


            ret_user_passwords = (string[])array_list_user_passwords.ToArray(typeof(string));

            return ret_user_passwords;

        } // GetUserPasswords

        #endregion // List of users and passwords

        #region Utility functions

        /// <summary>Returns the name of the local subdirectory for downloading application and season program XML files
        /// <para>The directory will be created if not existing</para>
        /// </summary>
        private static string GetNameLocalTemporaryXmlDir()
        {
            return FileUtil.SubDirectory(JazzAppAdminSettings.Default.XmlExistingDir, Main.m_exe_directory) + @"\";

        } // GetNameLocalTemporaryXmlDir

        /// <summary>Returns the name of the local subdirectory for QR Code images
        /// <para>The directory will be created if not existing</para>
        /// </summary>
        private static string GetNameLocalTemporaryQrCodeDir()
        {
            return FileUtil.SubDirectory(m_dir_qr_code_name, Main.m_exe_directory) + @"\";

        } // GetFullNameLocalQrCodeDir

        /// <summary>Returns the name of the local subdirectory for QR Code images
        /// <para>The directory will be created if not existing</para>
        /// </summary>
        private static string GetNameLocalTemporaryFlyerImagesDir()
        {
            return FileUtil.SubDirectory(m_dir_flyer_images_name, Main.m_exe_directory) + @"\";

        } // GetNameLocalTemporaryFlyerImagesDir

        /// <summary>Creates a server directory if it doesn't exist
        /// <para>The name of copied season XML file is changed to SaisonProgramm.xml. The name for any file will be the same, but directory not.</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_upload_server_dir">Server directory name</param>
        /// <param name="o_error">Error description</param>
        private static bool CreateFlyerSubdirIfNotExisting(string i_upload_server_dir, out string o_error)
        {
            o_error = "";

            JazzFtp.Input ftp_input_dir_exists = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.DirExists);

            ftp_input_dir_exists.ServerDirectory = i_upload_server_dir;

            JazzFtp.Result result_dir_exists = JazzFtp.Execute.Run(ftp_input_dir_exists);
            if (!result_dir_exists.Status)
            {
                o_error = @"Flyer.CreateFlyerSubdirIfNotExisting JazzFtp.Execute.Run (DirExists) failed " + result_dir_exists.ErrorMsg;
                return false;
            }

            if (result_dir_exists.BoolResult)
            {
                return true;
            }

            JazzFtp.Input ftp_input_create_dir = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.DirCreate);

            ftp_input_create_dir.ServerDirectory = ftp_input_dir_exists.ServerDirectory;

            JazzFtp.Result result_dir_create = JazzFtp.Execute.Run(ftp_input_create_dir);

            if (!result_dir_create.Status)
            {
                o_error = @"Flyer.CreateFlyerSubdirIfNotExisting JazzFtp.Execute.Run (DirCreate) failed " + result_dir_create.ErrorMsg;
                return false;
            }


            return true;

        } // CreateFlyerSubdirIfNotExisting


        #endregion // Utility functions

    } // Flyer

} // Namespace
