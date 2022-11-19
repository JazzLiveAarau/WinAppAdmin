using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace JazzAppAdmin
{
    /// <summary>QR Code utility functions</summary>
    class QrCodeUtils
    {

        #region Generate QR Code

        /// <summary>Generates and returns a QR Code image (Bitmap)
        /// <para>1. Check input data</para>
        /// <para>2. Set encoding options like size, margin, .... Create EncodingOptions</para>
        /// <para>3. Set barcode format (QR_CODE) and the encoding options. Create BarcodeWriter</para>
        /// <para>4. Create the output bitmap image. Call of BarcodeWriter.Write</para>
        /// </summary>
        /// <param name="i_text_url">Link (URL) to a website or to Youtube</param>
        /// <param name="i_image_size">Width and height of the QR Code image</param>
        /// <param name="o_error">Error message</param>
        public static Bitmap GenerateQrCodeImage(string i_text_url, int i_image_size, out string o_error)
        {
            // https://csharp.hotexamples.com/examples/ZXing/BarcodeWriter/-/php-barcodewriter-class-examples.html
            // SAMPLE 5

            o_error = "";

            if (string.IsNullOrEmpty(i_text_url))
            {
                o_error = "QrCodeUtils.GenerateQrCodeImage Input string is empty or null";
                return null;
            }

            if (i_image_size < 10)
            {
                o_error = "QrCodeUtils.GenerateQrCodeImage Image size < 10";
                return null;
            }

            int image_width = i_image_size;
            int image_height = i_image_size;

            EncodingOptions encoding_options = null;
            BarcodeWriter barcode_writer = null;
            encoding_options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = image_width,
                Height = image_height,
                ErrorCorrection = ErrorCorrectionLevel.H,
                Margin = 0
            };
            barcode_writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = encoding_options
            };

            Bitmap bitmap_ret = barcode_writer.Write(i_text_url);

            return bitmap_ret;

        } // GenerateQrCodeImage

        #endregion Generate QR Code

        #region Save QR Code

        /// <summary>Save a QR Code image 
        /// <para></para>
        /// </summary>
        /// <param name="i_bitmap_qr_code">QR code image mage that shall be saved</param>
        /// <param name="i_file_name">File name for the QR Code (without extension)</param>
        /// <param name="i_mime_type">Output type of picture: jpg, png, bmp, ...</param>
        /// <param name="o_error">Error message</param>
        public static bool SaveQrCode(Bitmap i_bitmap_qr_code, string i_file_name, string i_mime_type, out string o_error)
        {
            // https://docs.microsoft.com/de-de/dotnet/api/system.drawing.image.save?view=netframework-4.8

            o_error = "";

            if (null == i_bitmap_qr_code)
            {
                o_error = "QrCodeUtils.SaveQrCode Input image is null";
                return false;
            }

            if (i_file_name.Length == 0)
            {
                o_error = "QrCodeUtils.SaveQrCode Input string is not defined";
                return false;
            }

            string file_name_extension = Path.GetExtension(i_file_name);
            if (file_name_extension.Length > 0)
            {
                o_error = "QrCodeUtils.SaveQrCode Input file name has the extension " + file_name_extension;
                return false;
            }

            // Get an ImageCodecInfo object that represents the input codec.
            string codec_str = "image/" + i_mime_type;
            ImageCodecInfo image_codec_info = GetEncoderInfo(codec_str);
            if (image_codec_info == null)
            {
                o_error = "QrCodeUtils.SaveQrCode Returned ImageCodecInfo is null for i_image_type= " + i_mime_type;
                return false;
            }

            string file_name_with_extension = i_file_name + "." + i_mime_type;

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder encoder_quallity = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one

            // EncoderParameter object in the array.
            EncoderParameters encoder_parameters = new EncoderParameters(1);

            // Save the bitmap as an image file with quality level 25.
            EncoderParameter encoder_parameter = new EncoderParameter(encoder_quallity, 25L);
            encoder_parameters.Param[0] = encoder_parameter;
            i_bitmap_qr_code.Save(file_name_with_extension, image_codec_info, encoder_parameters);

            return true;

        } // SaveQrCode

        /// <summary>Returns ImageCodecInfo for a given MimeType
        /// <para></para>
        /// </summary>
        /// <param name="i_image_mime_type">Output mime type : image/jpg, image/png, image/bmp, ...</param>
        private static ImageCodecInfo GetEncoderInfo(String i_image_mime_type)
        {
            int index_type;
            ImageCodecInfo[] all_encoders;
            all_encoders = ImageCodecInfo.GetImageEncoders();
            for (index_type = 0; index_type < all_encoders.Length; ++index_type)
            {
                if (all_encoders[index_type].MimeType == i_image_mime_type)
                {
                    return all_encoders[index_type];
                }
            }

            return null;

        } // GetEncoderInfo

        #endregion //Save QR Code

    } // QrCodeUtils

} // namespace
