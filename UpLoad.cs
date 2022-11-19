using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.IO;

namespace JazzAppAdmin
{
    /// <summary>Upload of files to the server</summary>
    class UpLoad
    {

        /// <summary>Upload one file
        /// <para>To server appadmin directory</para>
        /// </summary>
        /// <param name="i_url">The file server URL (to-address)</param>
        /// <param name="i_local_filename">The local file name with path (from-address)</param>
        /// <param name="o_error">Error message</param>
        public bool OneAdminFile(string i_url, string i_local_filename, out string o_error)
        {
            o_error = "";

            if (IsFileLocked(i_local_filename, out o_error))
            {
                return false;
            }

            Ftp.UpLoad ftp_upload = new Ftp.UpLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            if (!ftp_upload.UploadFile(i_url, i_local_filename, out o_error))
            {
                o_error = "OneAdminFile.OneFile " + o_error;
                return false;
            }

            return true;

        } // OneAdminFile


        /// <summary>Upload one file
        /// <para>To server www directory: FtpUser and FtpWwwPassword</para>
        /// <para>To server appdata directory: FtpUserAppdata and FtpAdminPassword</para>
        /// </summary>
        /// <param name="i_to_www">Flag telling if the file shall be uploaded to the www directory</param>
        /// <param name="i_url">The file server URL (to-address)</param>
        /// <param name="i_local_filename">The local file name with path (from-address)</param>
        /// <param name="o_error">Error message</param>
        public bool OneFile(bool i_to_www, string i_url, string i_local_filename, out string o_error)
        {
            o_error = "";

            if (IsFileLocked(i_local_filename, out o_error))
            {
                return false;
            }

            Ftp.UpLoad ftp_upload = new Ftp.UpLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            if (!ftp_upload.UploadFile(i_url, i_local_filename, out o_error))
            {
                o_error = "UpLoad.OneFile " + o_error;
                return false;
            }

            return true;
            
        } // OneFile

        /// <summary>Upload one file
        /// <para>To for instance server directory: konzerte (that not is a FTP directory like appdata, appadmin </para>
        /// </summary>
        /// <param name="i_url">The file server URL (to-address)</param>
        /// <param name="i_local_filename">The local file name with path (from-address)</param>
        /// <param name="o_error">Error message</param>
        public bool OnePhotoZipFile(string i_url, string i_local_filename, out string o_error)
        {
            o_error = "";

            if (IsFileLocked(i_local_filename, out o_error))
            {
                return false;
            }

            Ftp.UpLoad ftp_upload = new Ftp.UpLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            if (!ftp_upload.UploadFile(i_url, i_local_filename, out o_error))
            {
                o_error = "OnePhotoZipFile.OneFile " + o_error;
                return false;
            }

            return true;

        } // OnePhotoZipFile

        /// <summary>Create directory on the server</summary>
        public bool CreateServerDirectory(bool i_to_www, string server_directory_path, out string o_error)
        {
            o_error = "";

            Ftp.UpLoad ftp_upload = new Ftp.UpLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            if (!ftp_upload.CreateDirectory(server_directory_path, out o_error))
            {
                o_error = "UpLoad.CreateServerDirectory failed.Error " + o_error;
                return false;
            }


            return true;
        } // CreateServerDirectory

        /// <summary>Create directory on the server</summary>
        public bool DoesDirectoryExist(bool i_to_www, string server_directory_path, out string o_error)
        {
            o_error = "";

            Ftp.UpLoad ftp_upload = new Ftp.UpLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            if (!ftp_upload.DoesDirectoryExist(server_directory_path, out o_error))
            {
                o_error = "UpLoad.DoesDirectoryExist Directory does not exist " + o_error;
                return false;
            }

            return true;

        } // DoesDirectoryExist

        /// <summary>
        /// This function is used to check specified file being used or not
        /// <para>It is normally Word that is locking the file. If a file is opened in Notepad++ there is no problem</para>
        /// <para>This function first checks if the file exists.</para>
        /// </summary>
        /// <param name="i_file_name">Input file name</param>
        /// <returns>true if the file is locked by another application</returns>
        public static bool IsFileLocked(string i_file_name, out string o_error)
        {
            // http://dotnet-assembly.blogspot.ch/2012/10/c-check-file-is-being-used-by-another.html

            o_error = @"";

            if (!File.Exists(i_file_name))
            {
                o_error = @"Upload.IsFileLocked There is no file " + i_file_name;
                return true;
            }

            FileInfo file_info = new FileInfo(i_file_name);

            FileStream stream = null;

            try
            {
                //Don't change FileAccess to ReadWrite, 
                //because if a file is in readOnly, it fails.
                stream = file_info.Open
                (
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.None
                );
            }
            catch (IOException exp)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread

                o_error = @"Upload.CheckIfFileIsBeingUsed File is probably opened by another application " + exp.ToString();

                string file_name_no_path = Path.GetFileName(i_file_name);

                o_error = file_name_no_path + PhotoStrings.ErrMsgPhotoUploadLocked;

                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        } // IsFileLocked


    } // UpLoad

} // JazzAppAdmin
