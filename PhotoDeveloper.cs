using JazzApp;
using JazzFtp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Execution functions and parameters for form PhotoDeveloperForm
    /// <para></para>
    /// </summary>
    static public class PhotoDeveloper
    {
        #region Names and paths for the XML files holding photo data

        // Defined by PhotoMain


        #endregion // Names and paths for the XML files holding photo data

        #region Check data

        /// <summary>Check of photo data
        /// <para>Call of TestSearchMobile</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static public bool CheckData(TextBox i_textbox_message, out string o_result, out string o_error)
        {
            o_error = @"";
            o_result = @"";

            PhotoSlideShow slide_show = new PhotoSlideShow();

            bool b_gallery_one = false;
            string[] missing_photos = null;
            string[] checked_concerts = null;
            int season_number = 9;
            if (slide_show.PhotosExist(b_gallery_one, season_number, i_textbox_message, out missing_photos, out checked_concerts, out o_error))
            {
                string gallery_name = @"Gallery One";
                if (!b_gallery_one)
                    gallery_name = @"Gallery Two";

                o_result = o_result + @"Test: In " + gallery_name + @" Saison-Nummer " + season_number.ToString() + @" fehlen folgende Fotos für die Slideshow:" + "\n";
                o_result = o_result + "\n";

                if (null == missing_photos)
                {
                    o_result = o_result + @"Returned array is null" + "\n";
                }
                else if (missing_photos.Length > 0)
                {
                    for (int index_photo = 0; index_photo < missing_photos.Length; index_photo++)
                    {
                        o_result = o_result + missing_photos[index_photo] + "\n";
                    }

                }
                else
                {
                    o_result = o_result + @"Keine fotos fehlen" + "\n";
                }
            }
            else
            {
                o_error = @"PhotoDeveloper.CheckData PhotoSlideShow.AllPhotosExist failed: " + o_error;
                return false;
            }

            o_result = o_result + "\n";
            o_result = o_result + @"Folgende Konzerte wurde kontrolliert:" + "\n";
            o_result = o_result + "\n";

            for (int index_checked = 0; index_checked < checked_concerts.Length; index_checked++)
            {
                o_result = o_result + checked_concerts[index_checked] + "\n";
            }


            string[] date_year_band_array = null;
            if (TestSearchMobile(out date_year_band_array, out o_error))
            {
                o_result = o_result + "\n";
                o_result = o_result + "\n";
                o_result = o_result + @"Test: Suche wie mit der Mobiltelefon-Funktion" + "\n";
                o_result = o_result + @"Suchwort: Laura  Option: Musikernamen" + "\n";
                o_result = o_result + @"Resultat:" + "\n";

                for (int index_result=0; index_result< date_year_band_array.Length; index_result++)
                {
                    o_result = o_result + date_year_band_array[index_result] + "\n";
                }
            }
            else
            {
                o_error = @"PhotoDeveloper.CheckData TestSearchMobile failed: " + o_error;
                return false;
            }

            // if (!FileNameChecks(out o_error))
            // if (!ProgrammingChecks(out o_error))
            //if (!InitPhotoTwoXmlFile(out o_error))
            // if (!InitPhotoOneXmlFile(out o_error))


            return true;

        } // CheckData

        #endregion // Check data

        #region Create Internet connection directory and file

        /// <summary>Create Internet connection directory and file
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>Returns true if execution is succesful</returns>
        static public bool CreateInternetConnectionDirFile(out string o_error)
        {
            o_error = @"";

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, Input.Case.CreateCheckInternetConnection);

            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

            if (!ftp_result.Status)
            {
                o_error = @"PhotoDeveloper.CreateInternetConnectionDirFile JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }

            return true;

        } // CreateInternetConnectionDirFile

        /// <summary>Check Internet connection 
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>Returns true if there is connection</returns>
        static public bool CheckInternetConnection(out string o_error)
        {
            o_error = @"";

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, Input.Case.CheckInternetConnection);

            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

            if (!ftp_result.Status)
            {
                o_error = @"PhotoDeveloper.CheckInternetConnection JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }

            bool there_is_internet_connection = false;

            if (ftp_result.BoolResult)
                there_is_internet_connection = true;

            return there_is_internet_connection;

        } // CheckInternetConnection

        #endregion // Create Internet connection directory and file

        #region Test FTP functions

        /// <summary>Test the FTP renaming function
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>Returns true if renaming was sucessful</returns>
        static public bool TestFtpRename(out string o_error)
        {
            o_error = @"";

            // appdata/XxxxDevelopTestDirectoryOne
            // appdata/XxxxDevelopTestDirectoryTwo

            // Adhan.mp3
            // For Bra Herb.mp3  
            // Jones' Tones.mp3  
            // Links.htm

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, Input.Case.RenameFile);

            ftp_input.ServerDirectory = "appdata/XxxxDevelopTestDirectoryOne";
            ftp_input.ServerFileName = "Jones' Tones.mp3";

            ftp_input.ServerRenameDirectory = @"";
            ftp_input.ServerRenameFileName = @"Sven Svensson.mp3";

            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

            if (!ftp_result.Status)
            {
                o_error = @"PhotoDeveloper.TestFtpRename JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }  

            return true;

        } // TestFtpRename

        /// <summary>Test the FTP download file function
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>Returns true if the download sucessful</returns>
        static public bool TestDownLoadFile(out string o_error)
        {
            o_error = @"";

            // appdata/XxxxDevelopTestDirectoryOne
            // appdata/XxxxDevelopTestDirectoryTwo

            // Adhan.mp3
            // For Bra Herb.mp3  
            // Jones' Tones.mp3  
            // Links.htm

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, Input.Case.DownloadFile);

            ftp_input.ServerDirectory = "appdata/XxxxDevelopTestDirectoryTwo";
            ftp_input.ServerFileName = "Links.htm";

            ftp_input.LocalDirectory = @"";
            ftp_input.LocalFileName = @"JazzEcho.htm";

            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

            if (!ftp_result.Status)
            {
                o_error = @"PhotoDeveloper.TestDownLoadFile JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }

            return true;

        } // TestDownLoadFile

        /// <summary>Test the FTP delete file function
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>Returns true if the delete sucessful</returns>
        static public bool TestDeleteFile(out string o_error)
        {
            o_error = @"";

            // appdata/XxxxDevelopTestDirectoryOne
            // appdata/XxxxDevelopTestDirectoryTwo

            // Adhan.mp3
            // For Bra Herb.mp3  
            // Jones' Tones.mp3  
            // Links.htm

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, Input.Case.DeleteFile);

            ftp_input.ServerDirectory = "appdata/XxxxDevelopTestDirectoryOne";
            ftp_input.ServerFileName = "Gunnar.mp3";

            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

            if (!ftp_result.Status)
            {
                o_error = @"PhotoDeveloper.TestDeleteFile JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }

            return true;

        } // TestDeleteFile

        /// <summary>Test the FTP delete file function
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>Returns true if the delete sucessful</returns>
        static public bool TestDeleteFiles(out string o_error)
        {
            o_error = @"";

            // appdata/XxxxDevelopTestDirectoryOne
            // appdata/XxxxDevelopTestDirectoryTwo

            // Adhan.mp3
            // For Bra Herb.mp3  
            // Jones' Tones.mp3  
            // Links.htm

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, Input.Case.DeleteFiles);

            ftp_input.ServerDirectory = "appdata/XxxxDevelopTestDirectoryTwo";


            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

            if (!ftp_result.Status)
            {
                o_error = @"PhotoDeveloper.TestDeleteFiles JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }

            return true;

        } // TestDeleteFiles

        /// <summary>Test the FTP delete file function
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>Returns true if the delete sucessful</returns>
        static public bool TestListFiles(out string o_error)
        {
            o_error = @"";

            // appdata/XxxxDevelopTestDirectoryOne
            // appdata/XxxxDevelopTestDirectoryTwo

            // Adhan.mp3
            // For Bra Herb.mp3  
            // Jones' Tones.mp3  
            // Links.htm

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, Input.Case.GetFileNames);

            ftp_input.ServerDirectory = "appdata/XxxxDevelopTestDirectoryTwo";


            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

            if (!ftp_result.Status)
            {
                o_error = @"PhotoDeveloper.TestDeleteFiles JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }

            string[] output_array = ftp_result.ArrayStr;

            return true;

        } // TestListFiles

        /// <summary>Test the FTP delete directory function
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>Returns true if the delete sucessful</returns>
        static public bool TestDeleteDirectory(out string o_error)
        {
            o_error = @"";

            // appdata/XxxxDevelopTestDirectoryOne
            // appdata/XxxxDevelopTestDirectoryTwo

            // Adhan.mp3
            // For Bra Herb.mp3  
            // Jones' Tones.mp3  
            // Links.htm

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, Input.Case.DeleteDir);

            ftp_input.ServerDirectory = "appdata/XxxxDevelopTestDirectoryThree";


            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

            if (!ftp_result.Status)
            {
                o_error = @"PhotoDeveloper.TestDeleteDirectory JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }

            return true;

        } // TestDeleteDirectory

        /// <summary>Test the FTP delete directory function
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        /// <returns>Returns true if the delete sucessful</returns>
        static public bool TestRenameDirectory(out string o_error)
        {
            o_error = @"";

            // appdata/XxxxDevelopTestDirectoryOne
            // appdata/XxxxDevelopTestDirectoryTwo

            // Adhan.mp3
            // For Bra Herb.mp3  
            // Jones' Tones.mp3  
            // Links.htm

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, Input.Case.RenameDir);

            ftp_input.ServerDirectory = "appdata/XxxxDevelopTestDirectoryThree";
            ftp_input.ServerRenameDirectory = "appdata/XxxxDevelopTestDirectoryNameChanged";

            JazzFtp.Result ftp_result = JazzFtp.Execute.Run(ftp_input);

            if (!ftp_result.Status)
            {
                o_error = @"PhotoDeveloper.TestRenameDirectory JazzFtp.Execute.Run failed " + ftp_result.ErrorMsg;
                return false;
            }

            return true;

        } // TestRenameDirectory

        #endregion // Test FTP functions

        #region Initialization of gallery photo one XML files

        /// <summary>Initialization of the gallery photo XML file JazzFotoGalerieEin.xml
        /// <para>Get the HTM file names. Call of PhotoMain.GetDownLoadedHtmFilesOne</para>
        /// <para></para>
        /// <para></para>
        /// <para>This is a function that is called only once</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static private bool InitPhotoOneXmlFile(out string o_error)
        {
            o_error = @"";

            string[] all_file_names = GetDownLoadedHtmFilesOne(out o_error);
            if (null == all_file_names)
            {
                o_error = "PhotoDeveloper.InitPhotoOneXmlFile GetDownLoadedHtmFiles failed " + o_error;
                return false;
            }

            string[] all_file_names_sorted = PhotoMain.SortHtmFileNames(all_file_names, out o_error);
            if (null == all_file_names_sorted)
            {
                o_error = "PhotoDeveloper.InitPhotoOneXmlFile PhotoMain.SortHtmFileNames failed " + o_error;
                return false;
            }

            for (int index_name = 0; index_name < all_file_names_sorted.Length; index_name++)
            {
                string current_file_name = all_file_names_sorted[index_name];

                string content_file = File.ReadAllText(current_file_name);

                JazzPhoto jazz_photo = new JazzPhoto();

                if (!GetGalleryName(ref jazz_photo, current_file_name, out o_error))
                {
                    o_error = "PhotoDeveloper.InitPhotoOneXmlFile GetGalleryName failed " + o_error;
                    return false;
                }

                if (!GetTexts(ref jazz_photo, content_file, out o_error))
                {
                    o_error = "PhotoDeveloper.InitPhotoOneXmlFile GetTexts failed " + o_error;
                    return false;
                }

                if (!GetPhotographer(ref jazz_photo, content_file, out o_error))
                {
                    o_error = "PhotoDeveloper.InitPhotoOneXmlFile GetPhotographer failed " + o_error;
                    return false;
                }

                bool b_photo_one = true;
                string season_start_year_str = @"";
                if (!GetSeasonProgramData(ref jazz_photo, b_photo_one, current_file_name, out season_start_year_str, out o_error))
                {
                    o_error = "PhotoDeveloper.InitPhotoOneXmlFile GetSeasonProgramData failed " + o_error;
                    return false;
                }

                if (!AddDataToXmlPhotoOne(jazz_photo, current_file_name, season_start_year_str, out o_error))
                {
                    o_error = "PhotoDeveloper.InitPhotoOneXmlFile AddDataToXmlPhotoTwo failed " + o_error;
                    return false;
                }


            } // index_name

            JazzXml.GetObjectPhotoOne().Save("InitPhotoOneXmlFile.xml");

            return true;

        } // InitPhotoOneXmlFile

        /// <summary>Add data from object JazzPhoto to the XML photo gallery one object corresponding to XML file JazzGalerieEin.xml
        /// <para>1. </para>
        /// <para>2. </para>
        /// <para>3. </para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_file_name">HTM photo gallery file</param>
        /// <param name="i_season_start_year_str">Start season year for the photo data in input object JazzPhoto</param>
        /// <param name="o_error">Error message</param>
        private static bool AddDataToXmlPhotoOne(JazzPhoto i_jazz_photo, string i_file_name, string i_season_start_year_str, out string o_error)
        {
            o_error = @"";

            bool b_photo_one = true;

            int season_number = JazzXml.GetSeasonNumber(b_photo_one, i_season_start_year_str, out o_error);
            if (season_number < -1)
            {
                o_error = "PhotoDeveloper.AddDataToXmlPhotoOne JazzXml.GetSeasonNumber failed season_number= " + season_number.ToString();
                return false;
            }

            int season_start_year = JazzUtils.StringToInt(i_season_start_year_str);

            if (0 == season_number)
            {
                // First season element shall be added
                if (!JazzXml.PhotoSeasonAppend(b_photo_one, season_start_year, out o_error))
                {
                    o_error = @"PhotoDeveloper.AddDataToXmlPhotoOne JazzXml.PhotoSeasonAppend failed " + o_error;
                    return false;
                }

                if (!JazzXml.PhotoAppend(b_photo_one, i_jazz_photo, season_number + 1, out o_error))
                {
                    o_error = @"PhotoDeveloper.AddDataToXmlPhotoOne JazzXml.PhotoAppend failed " + o_error;
                    return false;
                }

            } // First season element in the jazz gallery one XML object

            else if (-1 == season_number)
            {
                // An additional season element
                if (!JazzXml.PhotoSeasonAppend(b_photo_one, season_start_year, out o_error))
                {
                    o_error = @"PhotoDeveloper.AddDataToXmlPhotoOne JazzXml.PhotoSeasonAppend failed " + o_error;
                    return false;
                }

                season_number = JazzXml.GetSeasonNumber(b_photo_one, i_season_start_year_str, out o_error);

                if (!JazzXml.PhotoAppend(b_photo_one, i_jazz_photo, season_number, out o_error))
                {
                    o_error = @"PhotoDeveloper.AddDataToXmlPhotoOne JazzXml.PhotoAppend failed " + o_error;
                    return false;
                }

            } // An additional season element
            else
            {
                // Add to existing saison element
                if (!JazzXml.PhotoAppend(b_photo_one, i_jazz_photo, season_number, out o_error))
                {
                    o_error = @"PhotoDeveloper.AddDataToXmlPhotoOne JazzXml.PhotoAppend failed " + o_error;
                    return false;
                }

            } // Add to existing saison element


            return true;

        } // AddDataToXmlPhotoOne

        #endregion // Initialization of gallery photo one XML files

        #region Initialization of gallery photo two XML files

        /// <summary>Initialization of the gallery photo XML file JazzFotoGalerieZwei.xml
        /// <para>Get the HTM file names. Call of PhotoMain.GetPhotoTwoHtmFileNames</para>
        /// <para></para>
        /// <para></para>
        /// <para>This is a function that is called only once</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static private bool InitPhotoTwoXmlFile(out string o_error)
        {
            o_error = @"";

            string[] all_file_names = GetDownLoadedHtmFilesOne(out o_error);
            if (null == all_file_names)
            {
                o_error = "PhotoDeveloper.InitPhotoTwoXmlFile GetDownLoadedHtmFiles failed " + o_error;
                return false;
            }

            string[] all_file_names_sorted = PhotoMain.SortHtmFileNames(all_file_names, out o_error);
            if (null == all_file_names_sorted)
            {
                o_error = "PhotoDeveloper.InitPhotoTwoXmlFile PhotoMain.SortHtmFileNames failed " + o_error;
                return false;
            }

            for (int index_name=0; index_name< all_file_names_sorted.Length; index_name++)
            {
                string current_file_name = all_file_names_sorted[index_name];

                string content_file = File.ReadAllText(current_file_name);

                JazzPhoto jazz_photo = new JazzPhoto();

                if (!GetGalleryName(ref jazz_photo, current_file_name, out o_error))
                {
                    o_error = "PhotoDeveloper.InitPhotoTwoXmlFile GetGalleryName failed " + o_error;
                    return false;
                }

                if (!GetTexts(ref jazz_photo, content_file, out o_error))
                {
                    o_error = "PhotoDeveloper.InitPhotoTwoXmlFile GetTexts failed " + o_error;
                    return false;
                }

                if (!GetPhotographer(ref jazz_photo, content_file, out o_error))
                {
                    o_error = "PhotoDeveloper.InitPhotoTwoXmlFile GetPhotographer failed " + o_error;
                    return false;
                }

                bool b_photo_one = false;
                string season_start_year_str = @"";
                if (!GetSeasonProgramData(ref jazz_photo, b_photo_one, current_file_name, out season_start_year_str, out o_error))
                {
                    o_error = "PhotoDeveloper.InitPhotoTwoXmlFile GetSeasonProgramData failed " + o_error;
                    return false;
                }

                if (!AddDataToXmlPhotoTwo(jazz_photo, current_file_name, season_start_year_str, out o_error))
                {
                    o_error = "PhotoDeveloper.InitPhotoTwoXmlFile AddDataToXmlPhotoTwo failed " + o_error;
                    return false;
                }


            } // index_name

            JazzXml.GetObjectPhotoTwo().Save("InitPhotoTwoXmlFile.xml");

            return true;

        } // InitPhotoTwoXmlFile


        /// <summary>Add data from object JazzPhoto to the XML photo gallery two object corresponding to XML file JazzGalerieZwei.xml
        /// <para>1. </para>
        /// <para>2. </para>
        /// <para>3. </para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_file_name">HTM photo gallery file</param>
        /// <param name="i_season_start_year_str">Start season year for the photo data in input object JazzPhoto</param>
        /// <param name="o_error">Error message</param>
        private static bool AddDataToXmlPhotoTwo(JazzPhoto i_jazz_photo, string i_file_name, string i_season_start_year_str, out string o_error)
        {
            o_error = @"";

            bool b_photo_one = false;

            int season_number = JazzXml.GetSeasonNumber(b_photo_one, i_season_start_year_str, out o_error);
            if (season_number < -1)
            {
                o_error = "PhotoDeveloper.AddDataToXmlPhotoTwo JazzXml.GetSeasonNumber failed season_number= " + season_number.ToString();
                return false;
            }

            int season_start_year = JazzUtils.StringToInt(i_season_start_year_str);

            if (0 == season_number)
            {
                // First season element shall be added
                if (!JazzXml.PhotoSeasonAppend(false, season_start_year, out o_error))
                {
                    o_error = @"PhotoDeveloper.AddDataToXmlPhotoTwo JazzXml.AddSeasonTwo failed " + o_error;
                    return false;
                }

                if (!JazzXml.PhotoAppend(false, i_jazz_photo, season_number + 1,  out o_error))
                {
                    o_error = @"PhotoDeveloper.AddDataToXmlPhotoTwo JazzXml.PhotoAppend failed " + o_error;
                    return false;
                }

            } // First season element in the jazz gallery two XML object

            else if (-1 == season_number)
            {
                // An additional season element
                if (!JazzXml.PhotoSeasonAppend(false, season_start_year, out o_error))
                {
                    o_error = @"PhotoDeveloper.AddDataToXmlPhotoTwo JazzXml.AddSeasonTwo failed " + o_error;
                    return false;
                }

                season_number = JazzXml.GetSeasonNumber(b_photo_one, i_season_start_year_str, out o_error);

                if (!JazzXml.PhotoAppend(false, i_jazz_photo, season_number, out o_error))
                {
                    o_error = @"PhotoDeveloper.AddDataToXmlPhotoTwo JazzXml.PhotoAppend failed " + o_error;
                    return false;
                }

            } // An additional season element
            else
            {
                // Add to existing saison element
                if (!JazzXml.PhotoAppend(false, i_jazz_photo, season_number, out o_error))
                {
                    o_error = @"PhotoDeveloper.AddDataToXmlPhotoTwo JazzXml.PhotoAppend failed " + o_error;
                    return false;
                }

            } // Add to existing saison element


            return true;

        } // AddDataToXmlPhotoTwo

        /// <summary>Get season program data like bandname, date, etc. 
        /// <para>1. Set input data (object SearchInput) for a search that returns the concert (as a SearchResult object) that has registered the HTM photo gallery file.</para>
        /// <para>2. Make the search. Call of PhotoMain.GetSearch.Execute</para>
        /// <para>3. Get the data from the returned object SearchResult and set the input/output object JazzPhoto</para>
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_b_photo_one">Flag telling if the search is for photo gallery one. Eq. false: Photo gallery two</param>
        /// <param name="i_file_name">HTM photo gallery file</param>
        /// <param name="o_season_start_year_str">Start season year for the returned concert (result object SearchResult)</param>
        /// <param name="o_error">Error message</param>
        private static bool GetSeasonProgramData(ref JazzPhoto io_jazz_photo, bool i_b_photo_one, string i_file_name, out string o_season_start_year_str, out string o_error)
        {
            o_error = @"";
            o_season_start_year_str = @"";

            SearchInput search_input = new SearchInput();
            if (i_b_photo_one)
            {
                search_input.FlagPhotoOne = true;
            }
            else
            {
                search_input.FlagPhotoTwo = true;
            }

            search_input.SearchString = Path.GetFileName(i_file_name);

            SearchResult[] search_results = null;

            if (!PhotoMain.GetSearch.Execute(search_input, out search_results, out o_error))
            {
                o_error = "PhotoDeveloper.GetSeasonProgramData PhotoMain.GetSearch.Execute failed " + o_error;
                return false;
            }

            if (search_results.Length > 0)
            {
                // Assume that there is only one 
                SearchResult search_result = search_results[0];

                io_jazz_photo.BandName = SetToValueNotYetSetIfEmptyString(search_result.BandName);

                io_jazz_photo.Year = SetToValueNotYetSetIfEmptyString(search_result.Year);
                io_jazz_photo.Month = SetToValueNotYetSetIfEmptyString(search_result.Month);
                io_jazz_photo.Day = SetToValueNotYetSetIfEmptyString(search_result.Day);

                if (i_b_photo_one)
                {
                    io_jazz_photo.ZipName = SetToValueNotYetSetIfEmptyString(search_result.ZipNameOne);
                }
                else
                {
                    io_jazz_photo.ZipName = SetToValueNotYetSetIfEmptyString(search_result.ZipNameTwo);
                }

                io_jazz_photo.ConcertNumber = SetToValueNotYetSetIfEmptyString(search_result.ConcertNumber);

                o_season_start_year_str = SetToValueNotYetSetIfEmptyString(search_result.StartYearSeason);

            } // search_results.Length > 0

            return true;

        } // GetSeasonProgramData

        /// <summary>Returns not yet set value if string is empty</summary>
        private static string SetToValueNotYetSetIfEmptyString(string i_value)
        {
            string ret_string = i_value;

            if (i_value.Length == 0)
            {
                ret_string = JazzXml.GetUndefinedNodeValue();
            }

            return ret_string;

        } // SetToValueNotYetSetIfEmptyString

        /// <summary>Get photographer name
        /// </summary>
        /// <param name="io_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_content_file">Content of the HTM file</param>
        /// <param name="o_error">Error message</param>
        private static bool GetPhotographer(ref JazzPhoto io_jazz_photo, string i_content_file, out string o_error)
        {
            o_error = @"";

            string search_str = @"Fotograf:";

            string end_row = "\n";

            string search_content_file = i_content_file;

            int index_start = search_content_file.IndexOf(search_str);
            if (index_start < 0)
            {
                o_error = "PhotoDeveloper.GetPhotographer Search string not found for index_start= " + index_start.ToString();
                return false;
            }

            index_start = index_start + search_str.Length;

            search_content_file = search_content_file.Substring(index_start);

            int index_end = search_content_file.IndexOf(end_row);
            if (index_end < 0)
            {
                o_error = "PhotoDeveloper.GetPhotographer Search string not found for index_end= " + index_end.ToString();
                return false;
            }

            string photographer_name = search_content_file.Substring(0, index_end - 1);

            photographer_name = photographer_name.Trim();

            io_jazz_photo.PhotographerName = photographer_name;

            return true;

        } // GetPhotographer

        /// <summary>Get photo texts
        /// </summary>
        /// <param name="io_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_content_file">Content of the HTM file</param>
        /// <param name="o_error">Error message</param>
        private static bool GetTexts(ref JazzPhoto io_jazz_photo, string i_content_file, out string o_error)
        {
            o_error = @"";

            string[] photo_texts = new string[9];

            for (int text_number=1; text_number<=9; text_number++)
            {
                string photo_text = GetText(text_number, i_content_file, out o_error);
                if (o_error.Length > 0)
                    return false;

                photo_texts[text_number - 1] = photo_text;

            }

            io_jazz_photo.TextOne = photo_texts[0];
            io_jazz_photo.TextTwo= photo_texts[1];
            io_jazz_photo.TextThree = photo_texts[2];
            io_jazz_photo.TextFour = photo_texts[3];
            io_jazz_photo.TextFive = photo_texts[4];
            io_jazz_photo.TextSix = photo_texts[5];
            io_jazz_photo.TextSeven = photo_texts[6];
            io_jazz_photo.TextEight = photo_texts[7];
            io_jazz_photo.TextNine = photo_texts[8];

            return true;

        } // GetTexts

        /// <summary>Get photo texts
        /// </summary>
        /// <param name="i_text_number">Photo text number</param>
        /// <param name="content_file">Content of the HTM file</param>
        /// <param name="o_error">Error message</param>
        private static string GetText(int i_text_number, string i_content_file, out string o_error)
        {
            o_error = @"";

            string ret_str = @"";

            string search_str_1 = "<IMG";
            string search_str_2 = "alt=";
            string search_str_3 = "\"";

            string search_content_file = i_content_file;
            for (int text_number=1; text_number<=9; text_number++)
            {
                int index_start_1 = search_content_file.IndexOf(search_str_1);
                if (index_start_1 < 0)
                {
                    o_error = "PhotoDeveloper.GetText Search string not found for index_start_1= " + index_start_1.ToString();
                    return ret_str;
                }

                index_start_1 = index_start_1 + search_str_1.Length;

                search_content_file = search_content_file.Substring(index_start_1);
                int index_start_2 = search_content_file.IndexOf(search_str_2);
                if (index_start_2 < 0)
                {
                    o_error = "PhotoDeveloper.GetText Search string not found for index_start_1= " + index_start_2.ToString();
                    return ret_str;
                }

                index_start_2 = index_start_2 + search_str_2.Length;

                search_content_file = search_content_file.Substring(index_start_2);

                int index_start_3 = search_content_file.IndexOf(search_str_3);
                if (index_start_3 < 0)
                {
                    o_error = "PhotoDeveloper.GetText Search string not found for index_start_3= " + index_start_3.ToString();
                    return ret_str;
                }

                index_start_3 = index_start_3 + search_str_3.Length;

                search_content_file = search_content_file.Substring(index_start_3);


                int index_end = search_content_file.IndexOf(search_str_3);
                string photo_text = search_content_file.Substring(0, index_end);

                if (text_number == i_text_number)
                {
                    ret_str = photo_text;
                    return ret_str;
                }

            }

            o_error = "PhotoDeveloper.GetText No text for i_text_number= " + i_text_number.ToString();
            return ret_str;

        } // GetText

        /// <summary>Get gallery name
        /// </summary>
        /// <param name="io_jazz_photo">Object JazzPhoto</param>
        /// <param name="i_file_name">HTM file name</param>
        /// <param name="o_error">Error message</param>
        private static bool GetGalleryName(ref JazzPhoto io_jazz_photo, string i_file_name, out string o_error)
        {
            o_error = @"";

            string file_name = Path.GetFileNameWithoutExtension(i_file_name);
            int index_start = PhotoMain.GalleryHtmFileNameStartString.Length - 1;

            string gallery_name = file_name.Substring(index_start);

            io_jazz_photo.GalleryName = gallery_name;

            return true;

        } // GetGalleryName

        /// <summary>Get downloade HTM files</summary>
        static private string[] GetDownLoadedHtmFilesOne(out string o_error)
        {
            o_error = "";
            string[] ret_file_names = null;

            ArrayList array_list_extensions = new ArrayList();
            array_list_extensions.Add("htm");
            string[] list_extensions = (string[])array_list_extensions.ToArray(typeof(string));

            string htm_local_dir = FileUtil.SubDirectory(PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.PhotoFileTempOneDir, Main.m_exe_directory) + @"\";

            if (!FileUtil.GetFilesDirectory(list_extensions, htm_local_dir, out ret_file_names))
            {
                o_error = "PhotoDeveloper.GetDownLoadedHtmFilesOne FileUtil.GetFilesDirector failed";
                return ret_file_names;
            }

            return ret_file_names;

        } // GetDownLoadedHtmFilesOne

        #endregion // Initialization of gallery photo two XML files

        #region Download of photo gallery HTM files

        /// <summary>Download all photo gallery two HTM files
        /// <para>Get the names of all the gallery two HTM files. Call of PhotoMain.GetPhotoTwoHtmFileNames</para>
        /// <para>Download the files. Call of Download.MultipleFiles</para>
        /// <para></para>
        /// <para>This is a function that is called once for the initialization of the file JazzFotoGalerieZwei.xml</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static public bool DownloadPhotoTwoHtmFiles(out string o_dir_name, out string o_error)
        {
            o_error = @"";
            o_dir_name = @"";

            string[] photo_two_file_names = PhotoMain.GetPhotoTwoHtmFileNames(out o_error);
            if (null == photo_two_file_names)
            {
                o_error = @"PhotoDeveloper.DownloadPhotoTwoHtmFiles PhotoMain.GetPhotoTwoHtmFileNames failed " + o_error;
                return false;
            }

            DownLoad down_load = new DownLoad();

            if (!down_load.MultipleFiles(photo_two_file_names, PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.PhotoFileTempTwoDir, out o_error))
            {
                o_error = @"PhotoDeveloper.DownloadPhotoTwoHtmFiles DownLoad.MultipleFiles failed " + o_error;
                return false;
            }

            o_dir_name = @"\" + PhotoMain.PhotoFileLocalDir + @"\" + PhotoMain.PhotoFileTempTwoDir + @"\";

            return true;

        } // DownloadPhotoTwoHtmFiles

        #endregion // Download of photo gallery HTM files

        #region Check of photo directory names and file names

        /// <summary>Check of photo file names
        /// <para>Calls of PhotoMain functions that are constructing the names</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        private static bool FileNameChecks(out string o_error)
        {
            o_error = @"";

            string html_existing_1 = @"JazzGalerie_G06.htm";
            string html_1 = PhotoMain.GalleryHtmFileName(6);
            if (!html_existing_1.Equals(html_1))
            {
                o_error = @"PhotoDeveloper.FileNameChecks " + html_existing_1 + @" not equal " + html_1;
                return false;
            }

            string html_existing_2 = @"JazzGalerie_G97.htm";
            string html_2 = PhotoMain.GalleryHtmFileName(97);
            if (!html_existing_2.Equals(html_2))
            {
                o_error = @"PhotoDeveloper.FileNameChecks " + html_existing_2 + @" not equal " + html_2;
                return false;
            }

            string html_existing_3 = @"JazzGalerie_G110.htm";
            string html_3 = PhotoMain.GalleryHtmFileName(110);
            if (!html_existing_3.Equals(html_3))
            {
                o_error = @"PhotoDeveloper.FileNameChecks " + html_existing_3 + @" not equal " + html_3;
                return false;
            }

            string html_photo_existing_1 = @"JazzBild_G15_06.htm";
            string html_photo_1 = PhotoMain.GalleryHtmPhotoFileName(15, 6);
            if (!html_photo_existing_1.Equals(html_photo_1))
            {
                o_error = @"PhotoDeveloper.FileNameChecks " + html_photo_existing_1 + @" not equal " + html_photo_1;
                return false;
            }

            string lowres_photo_existing_1 = @"JazzBild_G21_03_LowRes.jpg";
            string lowres_photo_1 = PhotoMain.GalleryLowResPhotoFileName(21, 3);
            if (!lowres_photo_existing_1.Equals(lowres_photo_1))
            {
                o_error = @"PhotoDeveloper.FileNameChecks " + lowres_photo_existing_1 + @" not equal " + lowres_photo_1;
                return false;
            }

            string small_photo_existing_1 = @"JazzBild_G21_04_small.jpg";
            string small_photo_1 = PhotoMain.GallerySmallPhotoFileName(21, 4);
            if (!small_photo_existing_1.Equals(small_photo_1))
            {
                o_error = @"PhotoDeveloper.FileNameChecks " + small_photo_existing_1 + @" not equal " + small_photo_1;
                return false;
            }

            string small_photo_existing_2 = @"JazzBild_G21_small.jpg";
            string small_photo_2 = PhotoMain.GallerySmallPhotoFileName(21, 0);
            if (!small_photo_existing_2.Equals(small_photo_2))
            {
                o_error = @"PhotoDeveloper.FileNameChecks " + small_photo_existing_2 + @" not equal " + small_photo_2;
                return false;
            }

            return true;

        } // FileNameChecks

        #endregion // Check of photo directory names and file names

        #region List ZIP data

        /// <summary>Get galleries where the ZIP file is missing
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static bool CreateZipListFile(out string o_file_name, out string o_error)
        {
            o_file_name = @"";
            o_error = @"";

            SearchInput search_input = new SearchInput();

            search_input.FlagIsElementSet = true;
            search_input.FlagPhotoTwo = true;

            Search search_object = new Search();

            SearchResult[] search_results = null;

            if (!search_object.Execute(search_input, out search_results, out o_error))
            {
                o_error = "PhotoDeveloper.CreateZipListFile Search.Execute failed " + o_error;
                return false;
            }

            ArrayList galleries_without_zip_array = new ArrayList();

            for (int index_result=0; index_result<search_results.Length; index_result++)
            {
                SearchResult current_result = search_results[index_result];

                if (current_result.ZipNameTwo.Trim().Length == 0)
                {
                    string row_str = current_result.Day + "/" + current_result.Month + " " + current_result.Year + " " + current_result.BandName;

                    galleries_without_zip_array.Add(row_str);

                } // No ZIP file

            } // index_result

            string[] galleries_without_zip = (string[])galleries_without_zip_array.ToArray(typeof(string));

            string out_str = @"Concerts with photo gallery but with no ZIP file " + TimeUtil.YearMonthDayIso() + NewLine();
            out_str = out_str + @"================================================================" + NewLine() + NewLine();

            for (int index_no_zip = 0; index_no_zip < galleries_without_zip.Length; index_no_zip++)
            {
                out_str = out_str + galleries_without_zip[index_no_zip] + NewLine();
            }

            out_str = out_str + NewLine() + NewLine();

            string file_name = @"ConcertsGalleryNoZip" + TimeUtil.YearMonthDay() + @".txt";

            string local_address_directory = FileUtil.SubDirectory(PhotoMain.PhotoMaintenanceDir, Main.m_exe_directory) + @"\";

            string full_file_name = local_address_directory + file_name;

            File.WriteAllText(full_file_name, out_str);

            o_file_name = full_file_name;

            return true;

        } // CreateZipListFile

        /// <summary>Get galleries that have registered ZIP files but where the ZIP files are missing on the server
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static bool CreateListMissingRegisteredZipFiles(out string o_file_name, out string o_error)
        {
            o_file_name = @"";
            o_error = @"";

            JazzPhoto[] missing_zip_files = PhotoMain.GetPhotoObjectsMissingRegisteredZipFiles(out o_error);
            if (null == missing_zip_files)
            {
                o_error = "PhotoDeveloper.CreateListMissingRegisteredZipFiles PhotoMain.GetPhotoObjectsMissingRegisteredZipFiles failed " + o_error;
                return false;
            }

            int n_number_zip = missing_zip_files.Length;
            if (0 == n_number_zip)
            {
                o_error = "All registered ZIP files are also on the server";
                return false;
            }

            string[] missing_registered_zip_files = new string[n_number_zip];

            for (int index_zip=0; index_zip<n_number_zip; index_zip++)
            {
                JazzPhoto current_photo = missing_zip_files[index_zip];
                string to_file_str = GetConcertData(current_photo);
                missing_registered_zip_files[index_zip] = to_file_str; 

            }

            string out_str = @"Concerts with a registered ZIP file where the file is missing on the server" + TimeUtil.YearMonthDayIso() + NewLine();
            out_str = out_str + @"===================================================================================" + NewLine() + NewLine();

            for (int index_no_zip = 0; index_no_zip < missing_registered_zip_files.Length; index_no_zip++)
            {
                out_str = out_str + missing_registered_zip_files[index_no_zip] + NewLine();
            }

            out_str = out_str + NewLine() + NewLine();

            string file_name = @"ListMissingRegisteredZipFiles" + TimeUtil.YearMonthDay() + @".txt";

            string local_address_directory = FileUtil.SubDirectory(PhotoMain.PhotoMaintenanceDir, Main.m_exe_directory) + @"\";

            string full_file_name = local_address_directory + file_name;

            File.WriteAllText(full_file_name, out_str);

            o_file_name = full_file_name;

            return true;

        } // CreateListMissingRegisteredZipFiles

        private static string GetConcertData(JazzPhoto i_jazz_photo)
        {
            string ret_str = @"";

            ret_str = ret_str + i_jazz_photo.Day + "/" + i_jazz_photo.Month + " " + i_jazz_photo.Year + " " + i_jazz_photo.BandName + NewLine();

            ret_str = ret_str + @"'" + i_jazz_photo.ZipName + @"' ZIP file name  Gallery " + i_jazz_photo.GalleryName;
           
            return ret_str;
        }

        private static bool ServerZipFileExists(string i_zip_name, string[] i_zip_file_names)
        {
            if (null == i_zip_file_names)
                return false;

            for (int index_zip = 0; index_zip < i_zip_file_names.Length; index_zip++)
            {
                string current_name = i_zip_file_names[index_zip];
                if (i_zip_name.Equals(current_name))
                {
                    return true;
                }

            }

            return false;

        } // ServerZipFileExists

        /// <summary>Returns new line (for Windows)</summary>
        private static string NewLine() { return "\r\n"; }

        #endregion // List ZIP data

        #region Programming checks

        /// <summary>Programming checks
        /// <para>The functions of JazzXmlPhoto are tested</para>
        /// </summary>
        private static bool ProgrammingChecks(out string o_error)
        {
            o_error = @"";
            bool ret_check = true;


            if (!SetAddPhotoData(out o_error))
            {
                ret_check = false;
                return ret_check;
            }


            JazzPhoto[] photo_one_objects = JazzXml.GetPhotoOneObjects(1, out o_error);
            if (null == photo_one_objects)
            {
                ret_check = false;
                return ret_check;
            }

            JazzPhoto[] photo_two_objects = JazzXml.GetPhotoTwoObjects(1, out o_error);
            if (null == photo_two_objects)
            {
                ret_check = false;
                return ret_check;
            }

            JazzPhoto[] photo_two_objects_season_two = JazzXml.GetPhotoTwoObjects(2, out o_error);
            if (null == photo_two_objects_season_two)
            {
                ret_check = false;
                return ret_check;
            }

            JazzPhoto[] photo_two_objects_season_nine = JazzXml.GetPhotoTwoObjects(9, out o_error);
            if (null == photo_two_objects_season_nine)
            {
                ret_check = false;
                return ret_check;
            }

            return ret_check;

        } // ProgrammingChecks

        /// <summary>Set and add photo data
        /// <para></para>
        /// </summary>
        private static bool SetAddPhotoData(out string o_error)
        {
            o_error = @"";
            bool ret_check = true;

            bool b_photo_one = true;


            if (!TestSetPhotoOne(1, 1, out o_error))
            {
                ret_check = false;
                return ret_check;
            }

            b_photo_one = true;
            if (!JazzXml.PhotoSeasonAppend(b_photo_one, 1998, out o_error))
            {
                o_error = @"PhotoDeveloper.SetAddPhotoData JazzXml.PhotoSeasonAppend failed " + o_error;
                return false;
            }



            b_photo_one = true;
            if (!JazzXml.PhotoSeasonInsertAfter(b_photo_one, 2006, 2, out o_error))
            {
                o_error = @"PhotoDeveloper.SetAddPhotoData JazzXml.PhotoSeasonInsertAfter failed " + o_error;
                return false;
            }


            if (!TestAddPhotoOne(1, out o_error))
            {
                ret_check = false;
                return ret_check;
            }

            if (!TestReadWritePhotoOne(1, 1, out o_error))
            {
                ret_check = false;
                return ret_check;
            }

            b_photo_one = true;
            if (!JazzXml.PhotoSeasonInsertBefore(b_photo_one, 2001, 1, out o_error))
            {
                o_error = @"PhotoDeveloper.SetAddPhotoData JazzXml.PhotoSeasonInsertAfter failed " + o_error;
                return false;
            }

            if (!JazzXml.DeletePhotoOne(2, 1, out o_error))
            {
                o_error = @"PhotoDeveloper.SetAddPhotoData JazzXml.DeletePhotoOne failed " + o_error;
                return false;
            }

 
            return true;
        } // SetAddPhotoData

        /// <summary>Add photo one
        /// <para></para>
        /// </summary>
        /// <param name="i_season_number">Season number</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error message</param>
        private static bool TestAddPhotoOne(int i_season_number,  out string o_error)
        {
            o_error = @"";

            JazzPhoto jazz_photo_one = new JazzPhoto();
            jazz_photo_one.BandName = "Band Xxx";
            jazz_photo_one.GalleryName = @"G221";
            jazz_photo_one.Year = @"2016";
            jazz_photo_one.MonthInt = 1;
            jazz_photo_one.DayInt = 19;
            jazz_photo_one.TextOne = @"Text add one for photo one";
            jazz_photo_one.TextTwo = @"Text add two for photo one";
            jazz_photo_one.TextThree = @"Text add three for photo one";
            jazz_photo_one.TextFour = @"Text add four for photo one";
            jazz_photo_one.TextFive = @"Text add five for photo one";
            jazz_photo_one.TextSix = @"Text add six for photo one";
            jazz_photo_one.TextSeven = @"Text add seven for photo one";
            jazz_photo_one.TextEight = @"Text add eight for photo one";
            jazz_photo_one.TextNine = @"Text add nine for photo one";
            jazz_photo_one.TextNine = @"Text add nine for photo one";
            jazz_photo_one.PhotographerName = @"Sven Svensson";
            jazz_photo_one.ZipName = @"d20160119_Lenas_Band_Sven.zip";
            jazz_photo_one.ConcertNumberInt = 2;

            if (!jazz_photo_one.CheckParameterValues(out o_error))
            {
                o_error = @"PhotoDeveloper.TestAddPhotoOne CheckParameterValues failed " + o_error;
                return false;
            }

            if (!JazzXml.PhotoAppend(true, jazz_photo_one, 1, out o_error))
            {
                o_error = @"PhotoDeveloper.TestAddPhotoOne JazzXml.PhotoInsertAfter failed " + o_error;
                return false;
            }

            if (!JazzXml.PhotoInsertAfter(true, jazz_photo_one, 1, 1, out o_error))
            {
                o_error = @"PhotoDeveloper.TestAddPhotoOne JazzXml.PhotoInsertAfter failed " + o_error;
                return false;
            }

            JazzPhoto jazz_photo_two = new JazzPhoto();
            jazz_photo_two.BandName = "Band Yyyy";
            jazz_photo_two.GalleryName = @"G221";
            jazz_photo_two.Year = @"2016";
            jazz_photo_two.MonthInt = 1;
            jazz_photo_two.DayInt = 19;
            jazz_photo_two.TextOne = @"Text add one for photo one";
            jazz_photo_two.TextTwo = @"Text add two for photo one";
            jazz_photo_two.TextThree = @"Text add three for photo one";
            jazz_photo_two.TextFour = @"Text add four for photo one";
            jazz_photo_two.TextFive = @"Text add five for photo one";
            jazz_photo_two.TextSix = @"Text add six for photo one";
            jazz_photo_two.TextSeven = @"Text add seven for photo one";
            jazz_photo_two.TextEight = @"Text add eight for photo one";
            jazz_photo_two.TextNine = @"Text add nine for photo one";
            jazz_photo_two.TextNine = @"Text add nine for photo one";
            jazz_photo_two.PhotographerName = @"Gustav Svensson";
            jazz_photo_two.ZipName = @"d20160119_Yyyy_Band_Gustav.zip";
            jazz_photo_two.ConcertNumberInt = 2;

            if (!jazz_photo_two.CheckParameterValues(out o_error))
            {
                o_error = @"PhotoDeveloper.TestAddPhotoTwo CheckParameterValues failed " + o_error;
                return false;
            }

            if (!JazzXml.PhotoAppend(true, jazz_photo_one, 2, out o_error))
            {
                o_error = @"PhotoDeveloper.TestAddPhotoOne JazzXml.PhotoInsertAfter failed " + o_error;
                return false;
            }

            if (!JazzXml.PhotoInsertBefore(true, jazz_photo_two, 2, 1, out o_error))
            {
                o_error = @"PhotoDeveloper.TestAddPhotoOne JazzXml.PhotoInsertBefore failed " + o_error;
                return false;
            }



            return true;
        } // TestAddPhotoOne

 

        /// <summary>Check set function for photo one
        /// <para></para>
        /// </summary>
        /// <param name="i_season_number">Season number</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error message</param>
        private static bool TestSetPhotoOne(int i_season_number, int i_concert_number, out string o_error)
        {
            o_error = @"";

            JazzPhoto jazz_photo_one = new JazzPhoto();
            jazz_photo_one.BandName = @"Ingrids band";
            jazz_photo_one.GalleryName = @"G120";
            jazz_photo_one.Year = @"2016";
            jazz_photo_one.MonthInt = 7;
            jazz_photo_one.DayInt = 22;
            jazz_photo_one.TextOne = @"Text one for photo one";
            jazz_photo_one.TextTwo = @"Text two for photo one";
            jazz_photo_one.TextThree = @"Text three for photo one";
            jazz_photo_one.TextFour = @"Text four for photo one";
            jazz_photo_one.TextFive = @"Text five for photo one";
            jazz_photo_one.TextSix = @"Text six for photo one";
            jazz_photo_one.TextSeven = @"Text seven for photo one";
            jazz_photo_one.TextEight = @"Text eight for photo one";
            jazz_photo_one.TextNine = @"Text nine for photo one";
            jazz_photo_one.TextNine = @"Text nine for photo one";
            jazz_photo_one.PhotographerName = @"Gustav Gustavsson";
            jazz_photo_one.ZipName = @"d20160722_Ingrids_Band_Gustav.zip";
            jazz_photo_one.ConcertNumberInt = 11;

            if (!jazz_photo_one.CheckParameterValues(out o_error))
            {
                o_error = @"PhotoDeveloper.TestSetPhotoOne CheckParameterValues failed " + o_error;
                return false;
            }

            if (!JazzXml.SetPhotoOne(i_season_number, i_concert_number, jazz_photo_one, out o_error))
            {
                o_error = @"PhotoDeveloper.TestSetPhotoOne JazzXml.SetPhotoOne failed " + o_error;
                return false;
            }

            return true;
        } // TestSetPhotoOne



        /// <summary>Check that read and write functions for photo one
        /// <para></para>
        /// </summary>
        /// <param name="i_season_number">Season number</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error message</param>
        private static bool TestReadWritePhotoOne(int i_season_number, int i_concert_number, out string o_error)
        {
            o_error = @"";

            int n_number_season_one = JazzXml.GetNumberOfPhotoOneSeasons(out o_error);
            if (n_number_season_one <= 0)
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne JazzXml.GetNumberOfPhotoOneSeasons failed " + o_error;
                return false;
            }

            if (i_season_number > n_number_season_one)
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne i_season_number > n_number_season_one";
                return false;
            }


            int n_number_concerts_one = JazzXml.GetNumberOfPhotoOneConcerts(i_season_number, out o_error);
            if (n_number_concerts_one <= 0)
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne JazzXml.GetNumberOfPhotoOneConcerts failed " + o_error;
                return false;
            }

            if (i_concert_number > n_number_concerts_one)
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOnei_concert_number > n_number_concerts_one";
                return false;
            }

            string season_start_year = JazzXml.GetPhotoOneStartYearSeason(i_season_number);
            JazzXml.SetPhotoOneStartYearSeason(i_season_number, "2018");
            season_start_year = JazzXml.GetPhotoOneStartYearSeason(i_season_number);
            if (!season_start_year.Equals("2018"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne StartYearSeason failed";
                return false;
            }

            string band_name = JazzXml.GetPhotoOneBandName(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneBandName(i_season_number, i_concert_number, "Kalles band");
            band_name = JazzXml.GetPhotoOneBandName(i_season_number, i_concert_number);
            if (!band_name.Equals("Kalles band"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne BandName failed";
                return false;
            }

            string concert_year = JazzXml.GetPhotoOneYear(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneYear(i_season_number, i_concert_number, "2017");
            concert_year = JazzXml.GetPhotoOneYear(i_season_number, i_concert_number);
            if (!concert_year.Equals("2017"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne Year failed";
                return false;
            }

            string concert_month = JazzXml.GetPhotoOneMonth(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneMonth(i_season_number, i_concert_number, "12");
            concert_month = JazzXml.GetPhotoOneMonth(i_season_number, i_concert_number);
            if (!concert_month.Equals("12"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne Month failed";
                return false;
            }

            string concert_day = JazzXml.GetPhotoOneDay(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneDay(i_season_number, i_concert_number, "7");
            concert_day = JazzXml.GetPhotoOneDay(i_season_number, i_concert_number);
            if (!concert_day.Equals("7"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne Day failed";
                return false;
            }

            string gallery_name = JazzXml.GetPhotoOneGalleryName(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneGalleryName(i_season_number, i_concert_number, "G114");
            gallery_name = JazzXml.GetPhotoOneGalleryName(i_season_number, i_concert_number);
            if (!gallery_name.Equals("G114"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne GalleryName failed";
                return false;
            }

            string text_one = JazzXml.GetPhotoOneTextOne(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneTextOne(i_season_number, i_concert_number, "Text 1");
            text_one = JazzXml.GetPhotoOneTextOne(i_season_number, i_concert_number);
            if (!text_one.Equals("Text 1"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne TextOne failed";
                return false;
            }

            string text_two = JazzXml.GetPhotoOneTextTwo(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneTextTwo(i_season_number, i_concert_number, "Text 2");
            text_two = JazzXml.GetPhotoOneTextTwo(i_season_number, i_concert_number);
            if (!text_two.Equals("Text 2"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne TextTwo failed";
                return false;
            }

            string text_three = JazzXml.GetPhotoOneTextThree(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneTextThree(i_season_number, i_concert_number, "Text 3");
            text_three = JazzXml.GetPhotoOneTextThree(i_season_number, i_concert_number);
            if (!text_three.Equals("Text 3"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne TextThree failed";
                return false;
            }

            string text_four = JazzXml.GetPhotoOneTextFour(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneTextFour(i_season_number, i_concert_number, "Text 4");
            text_four = JazzXml.GetPhotoOneTextFour(i_season_number, i_concert_number);
            if (!text_four.Equals("Text 4"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne TextFour failed";
                return false;
            }

            string text_five = JazzXml.GetPhotoOneTextFive(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneTextFive(i_season_number, i_concert_number, "Text 5");
            text_five = JazzXml.GetPhotoOneTextFive(i_season_number, i_concert_number);
            if (!text_five.Equals("Text 5"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne TextFive failed";
                return false;
            }

            string text_six = JazzXml.GetPhotoOneTextSix(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneTextSix(i_season_number, i_concert_number, "Text 6");
            text_six = JazzXml.GetPhotoOneTextSix(i_season_number, i_concert_number);
            if (!text_six.Equals("Text 6"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne TextSix failed";
                return false;
            }

            string text_seven = JazzXml.GetPhotoOneTextSeven(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneTextSeven(i_season_number, i_concert_number, "Text 7");
            text_seven = JazzXml.GetPhotoOneTextSeven(i_season_number, i_concert_number);
            if (!text_seven.Equals("Text 7"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne TextSeven failed";
                return false;
            }

            string text_eight = JazzXml.GetPhotoOneTextEight(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneTextEight(i_season_number, i_concert_number, "Text 8");
            text_eight = JazzXml.GetPhotoOneTextEight(i_season_number, i_concert_number);
            if (!text_eight.Equals("Text 8"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne TextEight failed";
                return false;
            }

            string text_nine = JazzXml.GetPhotoOneTextNine(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneTextNine(i_season_number, i_concert_number, "Text 9");
            text_nine = JazzXml.GetPhotoOneTextNine(i_season_number, i_concert_number);
            if (!text_nine.Equals("Text 9"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne TextNine failed";
                return false;
            }

            string photographer_name = JazzXml.GetPhotoOnePhotographerName(i_season_number, i_concert_number);
            JazzXml.SetPhotoOnePhotographerName(i_season_number, i_concert_number, "Markus Meier");
            photographer_name = JazzXml.GetPhotoOnePhotographerName(i_season_number, i_concert_number);
            if (!photographer_name.Equals("Markus Meier"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne PhotographerName failed";
                return false;
            }

            string zip_name = JazzXml.GetPhotoOneZipName(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneZipName(i_season_number, i_concert_number, "Xyz_Markus.zip");
            zip_name = JazzXml.GetPhotoOneZipName(i_season_number, i_concert_number);
            if (!zip_name.Equals("Xyz_Markus.zip"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne ZipName failed";
                return false;
            }

            string concert_nr = JazzXml.GetPhotoOneConcertNumber(i_season_number, i_concert_number);
            JazzXml.SetPhotoOneConcertNumber(i_season_number, i_concert_number, "8");
            concert_nr = JazzXml.GetPhotoOneConcertNumber(i_season_number, i_concert_number);
            if (!concert_nr.Equals("8"))
            {
                o_error = @"PhotoDeveloper.TestReadWritePhotoOne ConcertNumber failed";
                return false;
            }

            return true;

        } // TestReadWritePhotoOne



        #endregion // Programming checks

        #region Test search function for the mobile phone

        /// <summary>Test the search function that is used in the mobile telephone
        /// <para>Call of PhotoMain.GetSearch.ExecuteMusicianBandText</para>
        /// <para>Call of !PhotoMain.GetSearch.ResultMusicianBandText</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static public bool TestSearchMobile(out string[] o_date_year_band_array, out string o_error)
        {
            o_error = @"";
            o_date_year_band_array = null;

            string search_string = @"Laura";
            bool b_musician = true;
            bool b_band = false;
            bool b_text = false;
            bool b_member_login = false;

            if (!PhotoMain.GetSearch.ExecuteMusicianBandText(search_string, b_musician, b_band, b_text, b_member_login, out o_error))
            {
                return false;
            }

            int index_batch = 0;
            string[] date_year_band_array = null;
            if (!PhotoMain.GetSearch.ResultMusicianBandText(index_batch, out date_year_band_array, out o_error))
            {
                return false;
            }

            o_date_year_band_array = date_year_band_array;

            return true;

        }  // TestSearchMobile

        #endregion // Test search function for the mobile phone

        #region Upload gallery

        /// <summary>Test upload of one gallery to the server
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public static bool UploadGallery(TextBox i_text_box, out string o_file_name, out string o_error)
        {
            o_file_name = @"";
            o_error = @"";

            bool b_debug = true;
            PhotoUpload photo_upload = new PhotoUpload(b_debug);

            bool only_year = false;
            int year_int = 2023;
            int month_int = 2;
            int day_int = 4;

            JazzPhoto[] jazz_photos = PhotoMain.GetJazzPhotoObjectsYearOrDate(only_year, year_int, month_int, day_int, out o_error);
           if (null == jazz_photos || jazz_photos.Length != 1)
           {
               o_error = @"PhotoDeveloper.UploadGallery test_jazz_photo not found for Year " + year_int.ToString() + @" Month " + month_int.ToString() + @" Day " + day_int.ToString();
               return false;
           }

           JazzPhoto test_jazz_photo = jazz_photos[0];

           if (!photo_upload.Execute(test_jazz_photo, i_text_box, out o_error))
           {
               o_error = @"PhotoDeveloper.UploadGallery PhotoUpload.Execute failed " + o_error;
               return false;
           }

           System.Diagnostics.Process.Start("notepad.exe", photo_upload.DebugGetFileName());

            return true;

        } // UploadGallery

        #endregion // Upload gallery

    } // PhotoDeveloper

} // namespace
