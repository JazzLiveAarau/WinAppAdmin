using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Edit of photos
    /// <para></para>
    /// </summary>
    public static class PhotoEdit
    {
        #region Create poster-newsletter images

        /// <summary>Create the poster-newsletter image
        /// <para></para>
        /// </summary>
        /// <param name="i_b_big">Eq. true: Width=860 Eq. false: Width=60 </param>
        /// <param name="i_path_input_photo_file_name">Input image file name (poster in original format)</param>
        /// <param name="i_path_output_photo_file_name"Output poster-newsletter image file name</param>
        /// <param name="o_error">Error message</param>
        public static bool ImagePosterNewsletter(bool i_b_big, string i_path_input_photo_file_name, string i_path_output_photo_file_name, out string o_error)
        {
            o_error = @"";

            if (!File.Exists(i_path_input_photo_file_name))
            {
                o_error = @"PhotoEdit.ImagePosterNewsletter Not existing file " + i_path_input_photo_file_name;
                return false;
            }

            if (i_path_output_photo_file_name.Length < 10)
            {
                o_error = @"PhotoEdit.ImagePosterNewsletter i_path_output_photo_file_name.Length < 10";
                return false;
            }

            if (File.Exists(i_path_output_photo_file_name))
            {
                File.Delete(i_path_output_photo_file_name);
            }

            int original_width = -12345;
            int original_height = -12345;
            if (!GetPictureSize(i_path_input_photo_file_name, out original_width, out original_height, out o_error))
            {
                o_error = @"PhotoEdit.CalculateSizeForWidth GetPictureSize failed " + o_error;
                return false;
            }

            int target_width = PhotoMain.GetBigPosterNewsletterPictureWidth();
            if (!i_b_big)
            {
                target_width = PhotoMain.GetSmallPosterNewsletterPictureWidth();
            }

            int output_height = -12345;

            if (!CalculateSizeForWidth(original_width, original_height, target_width, ref output_height, out o_error))
            {
                o_error = @"PhotoEdit.CalculateSizeForWidth CalculateSizeForWidth failed " + o_error;
                return false;
            }

            ResizeJpg(i_path_input_photo_file_name, i_path_output_photo_file_name, target_width, output_height);

            return true;

        } // ImagePosterNewsletter

        /// <summary>Calculate output height for a given width
        /// <para></para>
        /// </summary>
        /// <param name="i_width">Width of the original photo in pixels</param>
        /// <param name="i_height">Height of the original photo in pixels</param>
        /// <param name="i_target_width"Target width of the output photo in pixels</param>
        /// <param name="o_height">Height of the output photo in pixels</param>
        /// <param name="o_error">Error message</param>
        private static bool CalculateSizeForWidth(int i_width, int i_height, int i_target_width, ref int o_height, out string o_error)
        {
            o_error = @"";
            if (i_width < 10 || i_height < 10)
            {
                o_error = @"PhotoEdit.CalculateSizeForWidth i_width < 10 or i_height < 10";
                return false;
            }

            if (i_target_width > i_width)
            {
                o_error = @"PhotoEdit.CalculateSizeForWidth i_target_width > i_width";
                return false;
            }

            double x_ratio = (double)i_target_width / (double)i_width;
            double o_height_double = (double)i_height * x_ratio;

            o_height = (int)Math.Floor(o_height_double);

            return true;

        } // CalculateSizeForWidth

        #endregion // Create poster-newsletter images

        #region Resize image

        /// <summary>Resize JPG image
        /// <para></para>
        /// </summary>
        /// <param name="i_path_input_photo_file_name">Input image file name </param>
        /// <param name="i_path_output_photo_file_name"Output image file name</param>
        /// <param name="i_width">Input width in pixels</param>
        /// <param name="i_height">Input height in pixels</param>
        public static void ResizeJpg(string i_path_input_photo_file_name, string i_path_output_photo_file_name, int i_width, int i_height)
        {
            // https://stackoverflow.com/questions/3075906/using-c-sharp-how-can-i-resize-a-jpeg-image

            using (var result_bmp = new Bitmap(i_width, i_height))
            {
                using (var input_bmp = new Bitmap(i_path_input_photo_file_name))
                {
                    using (Graphics g = Graphics.FromImage((System.Drawing.Image)result_bmp))
                    {
                        g.DrawImage(input_bmp, 0, 0, i_width, i_height);
                    }
                }

                var ici = ImageCodecInfo.GetImageEncoders().FirstOrDefault(ie => ie.MimeType == "image/jpeg");
                var eps = new EncoderParameters(1);
                eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                result_bmp.Save(i_path_output_photo_file_name, ici, eps);

            } // using

        } // ResizeJpg

        #endregion // Resize image

        #region Size of image

        /// <summary>Get picture size
        /// <para></para>
        /// </summary>
        /// <param name="i_picture_file_name">File name of picture</param>
        /// <param name="o_width">Width in pixel</param>
        /// <param name="o_height">Height in pixel</param>
        /// <param name="o_error">Error message</param>
        public static bool GetPictureSize(string i_picture_file_name, out int o_width, out int o_height, out string o_error)
        {
            o_width = -12345;
            o_height = -12345;
            o_error = @"";

            if (!File.Exists(i_picture_file_name))
            {
                o_error = @"PhotoEdit.GetPictureSize Not existing file " + i_picture_file_name;
                return false;
            }

            Bitmap input_bitmap = (Bitmap)Image.FromFile(i_picture_file_name);

            o_width = input_bitmap.Width;
            o_height = input_bitmap.Height;

            return true;

        } // GetPictureSize

        #endregion // Size of image

    } // PhotoEdit

} // namespace
