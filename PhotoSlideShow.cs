using JazzApp;
using JazzFtp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Handles slide shows
    /// <para></para>
    /// </summary>
    public class PhotoSlideShow
    {
        #region Member variables

        /// <summary>TextBox for messages (may be null)</summary>
        private TextBox m_textbox_message = null;
        /// <summary>Get and set TextBox for messages (may be null)</summary>
        private TextBox TxtBoxMsg { get { return m_textbox_message; } set { m_textbox_message = value; } }

        /// <summary>Show message in TextBox control</summary>
        private void ShowMsg(string i_message)
        {
            if (null == TxtBoxMsg)
                return;

            TxtBoxMsg.Text = i_message;
            TxtBoxMsg.Refresh();

        } // ShowMsg

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor: No debug</summary>
        public PhotoSlideShow()
        {
 

        } // Constructor

        #endregion // Constructor

        #region Check that all photos exist

        /// <summary>Check that photos for the slide show exist
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public bool PhotosExist(bool i_b_photo_one, int i_season_number, TextBox  i_textbox_message, out string[] o_missing_photos, out string[] o_checked_concerts, out string o_error)
        {
            o_error = @"";
            o_missing_photos = null;
            o_checked_concerts = null;

            TxtBoxMsg = i_textbox_message;

            int number_seasons = JazzXml.GetNumberOfPhotoSeasons(i_b_photo_one, out o_error);
            if (number_seasons <= 0)
            {
                o_error = @"PhotoSlideShow.PhotosExist number_seasons= " + number_seasons.ToString() + @" <= 0. Error= " + o_error;
                return false;
            }

            if (i_season_number > number_seasons)
            {
                o_error = @"PhotoSlideShow.PhotosExist i_season_number= " + i_season_number.ToString() + @" > number_seasons = " + number_seasons.ToString();
                return false;
            }

            int number_photo_concerts = JazzXml.GetNumberOfPhotoConcerts(i_b_photo_one, i_season_number, out o_error);
            if (number_photo_concerts <= 0)
            {
                o_error = @"PhotoSlideShow.PhotosExist number_photo_concerts= " + number_photo_concerts.ToString() + @" <= 0. Error= " + o_error;
                return false;
            }

            JazzPhoto[] photo_concerts = null;
            if (i_b_photo_one)
            {
                photo_concerts = JazzXml.GetPhotoOneObjects(i_season_number, out o_error);
            }
            else
            {
                photo_concerts = JazzXml.GetPhotoTwoObjects(i_season_number, out o_error);
            }
            if (photo_concerts == null)
            {
                o_error = @"PhotoSlideShow.PhotosExist JazzXml.GetPhotoOneObjects or GetPhotoTwoObjects failed " + o_error;
                return false;
            }

            ArrayList missing_photos_array = new ArrayList();
            ArrayList checked_galleries_array = new ArrayList();

            for (int index_photo = 0; index_photo < number_photo_concerts; index_photo++)
            {
                JazzPhoto current_photo = photo_concerts[index_photo];
                int gallery_number = current_photo.GalleryNumberInt;
                string gallery_name = current_photo.GalleryName;
                string checked_gallery = gallery_name + @" " + current_photo.Day + @"/" + current_photo.Month + @" " + current_photo.Year + @" " + current_photo.BandName;
                ShowMsg(checked_gallery);
                checked_galleries_array.Add(checked_gallery);

                if (gallery_number <= 0)
                {
                    o_error = @"PhotoSlideShow.PhotosExist JazzPhoto.GalleryNumberInt failed gallery_number= " + gallery_number.ToString();
                    return false;
                }

                string server_dir = @"";
                if (i_b_photo_one)
                {
                    server_dir = @"www/" + PhotoMain.GalleryOneServerDir; 
                }
                else
                {
                    server_dir = PhotoMain.GetGalleryTwoDirServerPath(current_photo);
                    if (server_dir.Length == 0)
                    {
                        o_error = @"PhotoSlideShow.PhotosExist PhotoMain.GetGalleryTwoDirServerPath failed";
                        return false;
                    }
                }

                for (int photo_number=1; photo_number<=9; photo_number++)
                {
                    //QQ TODO This function does not work string lowres_file_name = PhotoMain.GalleryLowResPhotoFileName(gallery_number, photo_number);
                    //QQ string small_file_name = PhotoMain.GallerySmallPhotoFileName(gallery_number, photo_number);

                    // JazzBild_G03_05_LowRes.jpg  JazzBild_G03_05_small.jpg

                    string lowres_file_name = PhotoMain.GalleryPhotoFileNameStartString + gallery_name + @"_0" + photo_number.ToString() + @"_LowRes.jpg";

                    string small_file_name = PhotoMain.GalleryPhotoFileNameStartString + gallery_name + @"_0" + photo_number.ToString() + @"_small.jpg";

                    bool b_file_exists = true;
                    if (!PhotoExistsOnServer(server_dir, lowres_file_name, out b_file_exists, out o_error))
                    {
                        o_error = @"PhotoSlideShow.PhotosExist PhotoMain.PhotoExistsOnServer failed for LowRes " + o_error;
                        return false;
                    }
                    if (!b_file_exists)
                    {
                        missing_photos_array.Add(server_dir + @"/" + lowres_file_name);
                    }

                    if (!PhotoExistsOnServer(server_dir, small_file_name, out b_file_exists, out o_error))
                    {
                        o_error = @"PhotoSlideShow.PhotosExist PhotoMain.PhotoExistsOnServer failed for small " + o_error;
                        return false;
                    }
                    if (!b_file_exists)
                    {
                        missing_photos_array.Add(server_dir + @"/" + small_file_name);
                    }

                } // photo_number

            } // index_photo

            o_missing_photos = (string[])missing_photos_array.ToArray(typeof(string));
            o_checked_concerts = (string[])checked_galleries_array.ToArray(typeof(string));

            return true;

        } // PhotosExist

        /// <summary>Check if a file exists on the server
        /// <para>Call of JazzFtp.Execute.Run case JazzFtp.Input.Case.FileExists</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_server_dir">Server directory</param>
        /// <param name="i_file_name">File name</param>
        /// <param name="o_b_file_exists">Flag telling if the file exists on the server</param>
        /// <param name="o_error">Error message</param>
        /// <returns>false for error</returns>
        private bool PhotoExistsOnServer(string i_server_dir, string i_file_name, out bool o_b_file_exists, out string o_error)
        {
            o_error = @"";
            o_b_file_exists = false;

            JazzFtp.Result ret_result_file_exists = new JazzFtp.Result();

            JazzFtp.Input input_exists = new JazzFtp.Input();

            input_exists.ExecCase = JazzFtp.Input.Case.FileExists;
            input_exists.ServerDirectory = i_server_dir;
            input_exists.ServerFileName = i_file_name;
            

            ret_result_file_exists = JazzFtp.Execute.Run(input_exists);
            if (!ret_result_file_exists.Status)
            {
                o_error = @"PhotoSlideShow.PhotoExistsOnServer PhotoMain.GetGalleryTwoDirServerPath failed " + o_error;
                return false;
            }

            if (ret_result_file_exists.BoolResult)
            {
                o_b_file_exists = true;
            }
            else
            {
                o_b_file_exists = false;
            }

            return true;

        } // PhotoExistsOnServer

        #endregion // Check that all photos exist

    } // PhotoSlideShow

} // namespace
