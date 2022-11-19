using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JazzApp;
using System.Windows.Forms;
using System.IO;

namespace JazzAppAdmin
{
    /// <summary>Download and upload of documents
    /// <para></para>
    /// <para>The static class DocAdmin holds the last used directory for the upload/download of a file.</para>
    /// <para>The directory for the previous session is stored by the system library function open/save.</para>
    /// <para></para>
    /// <para></para>
    /// <para></para>
    /// </summary>
    public static class OpenSaveDialog
    {
        #region Member variables

        /// <summary>Flag telling if the file shallbe uploaded or downloaded</summary>
        private static bool m_upload_document = false;

        /// <summary>Case file extension: main pdf, txt, img, htm or js</summary>
        private static string m_case_extension = @"Undefined";

        /// <summary>The extensions for the file: doc, docx,    or htm, html or js</summary>
        private static string m_file_extensions = @"Undefined";

        /// <summary>Path to the file</summary>
        static private string m_file_path = @"";

        /// <summary>Name of the download file</summary>
        private static string m_file_name_download = @"";

        /// <summary>Name of the upload file</summary>
        private static string m_file_name_upload = @"";

        /// <summary>File filter</summary>
        private static string m_file_filter = @"";

        #endregion // Member variables

        /// <summary>Download a document
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para>Filetype main: The original that can be Word, Excel, Pdf or an image.</para>
        /// <para>For type main the extensions are defined in the input document template</para>
        /// </summary>
        /// <param name="i_file_path">Path on the server to the file</param>
        /// <param name="i_file_name_download">Name of the download file</param>
        /// <param name="i_case_extension">Extension type: main, pdf, txt, img or sound</param>
        /// <param name="i_file_extensions">File extensions</param>    
        /// <param name="i_admin_file">Flag telling if the file is on the /appadmin/JazzAppAdmin/ directory on the server</param>
        /// <param name="o_cancel">Flag telling if the user cancelled the upload</param>
        /// <param name="o_error">Error message.</param>
        public static bool Download(string i_file_path, string i_file_name_download, string i_case_extension, string i_file_extensions, out bool o_cancel, out string o_error)
        {
            o_error = @"";
            o_cancel = false;

            m_upload_document = false;

            if (!CheckSetInput(m_upload_document, i_file_path, i_file_name_download, i_case_extension, i_file_extensions, out o_error))
                return false;

            if (!SetFileFilter(i_case_extension, out o_error))
                return false;

            SaveFileDialog save_file_dialog = new SaveFileDialog();
            save_file_dialog.InitialDirectory = DocAdmin.GetDirectoryDownload();
            save_file_dialog.FileName = m_file_name_download;
            save_file_dialog.Filter = m_file_filter;
            save_file_dialog.FilterIndex = 1; 
            save_file_dialog.RestoreDirectory = true; // TODO ???

            save_file_dialog.Title = DocAdminString.TitleSaveDocument;

            if (save_file_dialog.ShowDialog() != DialogResult.OK)
            {
                // User cancelled the download of the file
                o_cancel = true;
                return true;
            }

            string path_and_file_name_set_by_user = save_file_dialog.FileName.Trim();

            if (path_and_file_name_set_by_user.Length > 0)
            {
                string server_file_name = GetServerDirectory(m_file_path) + m_file_name_download;

                DocAdmin.SetDirectoryDownload(Path.GetDirectoryName(path_and_file_name_set_by_user));

                DownLoad download = new DownLoad();

                string error_message = @"";

                if (i_case_extension.Equals("rtf")) // TODO Change to FileType or a new parameter
                {
                    if (!download.OneAdminFile(m_file_name_download, m_file_path, path_and_file_name_set_by_user, out error_message))
                    {
                        o_error = @"OpenSaveDialog.Download " + error_message;
                        return false;
                    }
                }
                else if (i_case_extension.Equals("zip")) // TODO Change to FileType or a new parameter
                {
                    if (!download.AnyDirFile(m_file_name_download, m_file_path, path_and_file_name_set_by_user, out error_message))
                    {
                        o_error = @"OpenSaveDialog.Download AnyDirFile failed " + error_message;
                        return false;
                    }
                }
                else
                {
                    if (!download.OneFile(server_file_name, path_and_file_name_set_by_user, out error_message))
                    {
                        o_error = @"OpenSaveDialog.Download " + error_message;
                        return false;
                    }
                }
 
            }

            return true;

        } // Download

        /// <summary>Returns the server file path
        /// <para>The returned path is "http://www.jazzliveaarau.ch/i_file_path/ </para>
        /// <para>If the input file path is www then the returned paht is "http://www.jazzliveaarau.ch/ </para>
        /// </summary>
        ///  <param name="i_file_path">Path to a subdirectory</param>
        private static string GetServerDirectory(string i_file_path)
        {
            if (i_file_path.Equals("www"))
            {
                return @"http://" + JazzAppAdminSettings.Default.FtpHost + @"/";
            }
            return @"http://" + JazzAppAdminSettings.Default.FtpHost + @"/" + m_file_path + @"/";
        } // GetServerDirectory

        /// <summary>Upload a document
        /// <para></para>
        /// <para></para>
        /// <para>The calling function determines if the file to be uploaded already exists on the server and sets the create backup flag accordingly.</para>
        /// <para>If an upload jazz document already exists on the server a backup copy will be created in a backup directory.</para>
        /// <para>This Backups directory will be created (if not existing) in the directory where the upload document will be stored.</para>
        /// <para></para>
        /// <para>Filetype main: The original that can be Word, Excel, Pdf or an image document.</para>
        /// <para>For main the extensions are defined in the input document template</para>
        /// </summary>
        /// <param name="i_file_path">Path on the server to the file</param>
        /// <param name="i_file_name_upload">Name of the upload file</param>
        /// <param name="i_case_extension">File extension type: main, pdf, txt, img, htm or js</param>
        /// <param name="i_file_extensions">File extensions</param>
        /// <param name="i_admin_file">Flag telling if the file is an Admin file, i.e. if it shall be saved in server directory /admin/JazzAppAdmin/</param>
        /// <param name="i_create_backup_document">Flag telling if a backup shall be created. If false there is no existing file on the server</param>
        /// <param name="o_cancel">Flag telling if the user cancelled download</param>
        /// <param name="o_file_name_upload">Output file extension for i_file_name_upload may be changed for a new file</param>
        /// <param name="o_error">Error message.</param>
        public static bool Upload(string i_file_path, string i_file_name_upload, string i_case_extension, string i_file_extensions, bool i_admin_file, bool i_create_backup_document, out bool o_cancel, out string o_file_name_upload, out string o_error)
        {
            o_error = @"";
            o_cancel = false;
            o_file_name_upload = i_file_name_upload; // Output file extension may be changed in CheckModifyExtensionForNewUploadDocument for a new file

            m_upload_document = true;

            if (!CheckSetInput(m_upload_document, i_file_path, i_file_name_upload, i_case_extension, i_file_extensions, out o_error))
                return false;

            if (!SetFileFilter(i_case_extension, out o_error))
                return false;

            string file_name_with_path = @"";

            OpenFileDialog open_file_dialog = new OpenFileDialog();

            open_file_dialog.InitialDirectory = DocAdmin.GetDirectoryUpload();
            open_file_dialog.Filter = m_file_filter;
            open_file_dialog.FilterIndex = 1;
            open_file_dialog.RestoreDirectory = true; // Not setting Environment.CurrentDirectory

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                file_name_with_path = open_file_dialog.FileName;

                DocAdmin.SetDirectoryUpload(Path.GetDirectoryName(file_name_with_path));
            }
            else
            {
                // User cancelled the upload from a file
                o_cancel = true;
                return true; 
            }

            string error_message = @"";

            if (i_create_backup_document) 
            {
                if (!Backup(i_file_path, i_file_name_upload, i_admin_file, out error_message))
                {
                    o_error = @"OpenSaveDialog.Upload " + error_message;
                    return false;
                }
            }

            string file_name_without_path = Path.GetFileName(file_name_with_path);
            string file_name_extension = Path.GetExtension(file_name_with_path);

            if (!CheckModifyExtensionForNewUploadDocument(!i_create_backup_document, file_name_without_path, out o_file_name_upload, out error_message))
            {
                o_error = @"OpenSaveDialog.Upload " + error_message;
                return false;
            }

            string existing_file_name = m_file_name_upload;

            string existing_file_extension = Path.GetExtension(existing_file_name);
            if (!existing_file_extension.Equals(file_name_extension))
            {
                o_error = @"OpenSaveDialog.Upload Extension need to be equal: " + existing_file_extension + " and " + file_name_extension;
                return false; // TODO Handle this case. Checkout is necessary
            }

            if (!WarningFileNamesNotEqual(existing_file_name, file_name_without_path, out o_cancel, out o_error))
            {
                return false;
            }

            string server_file_name = @"/www/" + m_file_path + @"/" + existing_file_name;
            if (m_file_path.Equals("www"))
            {
                server_file_name = @"/www/" + existing_file_name;
            }

            UpLoad upload = new UpLoad();
            bool to_www = true;
            if (i_admin_file) 
            {
                server_file_name = JazzAppAdminSettings.Default.DirAdminServerMain + @"\" + m_file_path + @"\" + existing_file_name;
                if (!upload.OneAdminFile(server_file_name, file_name_with_path, out error_message))
                {
                    if (error_message.Contains(PhotoStrings.ErrMsgPhotoUploadLocked))
                    {
                        o_error = error_message;
                        return false;
                    }
                    else
                    {
                        o_error = @"OpenSaveDialog.Upload Upload.OneAdminFile failed " + error_message;
                        return false;
                    }
                }
            }
            else
            {
                if (!upload.OneFile(to_www, server_file_name, file_name_with_path, out error_message))
                {
                    if (error_message.Contains(PhotoStrings.ErrMsgPhotoUploadLocked))
                    {
                        o_error = error_message;
                        return false;
                    }
                    else
                    {
                        o_error = @"OpenSaveDialog.Upload Upload.OneFile failed " + error_message;
                        return false;
                    }

                }

            }

            return true;
        } // Upload

        /// <summary>Check if the existing file name is equal to the output file name. If not ask the user if OK
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_existing_file_name">Name of the existing file (set by the application)</param>
        /// <param name="i_selected_file_name_without_path">Name of the file that the user has selected for upload</param>
        /// <param name="o_error">Error message.</param>
        public static bool WarningFileNamesNotEqual(string i_existing_file_name, string i_selected_file_name, out bool o_cancel, out string o_error)
        {
            o_cancel = false;
            o_error = @"";

            string existing_file_name_no_path = Path.GetFileName(i_existing_file_name);
            string selected_file_name_no_path = Path.GetFileName(i_selected_file_name);

            if(existing_file_name_no_path.Equals(selected_file_name_no_path))
            {
                return true;
            }

            string warning_msg = DocAdminString.MsgSelectedFileNameWillBeChanged + "\n" +
                                 DocAdminString.MsgSelectedFileNameFrom + selected_file_name_no_path + "\n" +
                                 DocAdminString.MsgSelectedFileNameTo + existing_file_name_no_path + "\n" +
                                 DocAdminString.MsgSelectedFileNameContinue;


            DialogResult dialog_result = MessageBox.Show(warning_msg, DocAdminString.MsgWarning, MessageBoxButtons.YesNo);

            if (dialog_result == DialogResult.No)
            {
                o_error = DocAdminString.MsgSelectedFileNameNotContinue;
                o_cancel = true;
                return false;
            }

            return true;

        } // WarningFileNamesNotEqual

        /// <summary>Check input file name extension for the upload file. Change extension to the selected file if necessary
        /// <para></para>
        /// <para>Output is the member variable m_file_name_upload that is set to i_file_name_upload by function CheckSetInput</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_new_file">Tells if the file already exists on the server</param>
        /// <param name="i_selected_file_name_without_path">Name of the file that the user has selected for upload</param>
        /// <param name="o_error">Error message.</param>
        private static bool CheckModifyExtensionForNewUploadDocument(bool i_new_file, string i_selected_file_name_without_path, out string o_file_name_upload, out string o_error)
        {
            o_error = @"";
            o_file_name_upload = m_file_name_upload;

            if (!i_new_file)
            {
                // Not a new file. Extension must be the same as the file on the server
                return true;
            }

            // The name of the new file has been constructed
            string constructed_file_name_extension = Path.GetExtension(m_file_name_upload);

            string selected_file_name_extension = Path.GetExtension(i_selected_file_name_without_path);

            if (selected_file_name_extension.Equals(constructed_file_name_extension))
            {
                // Not necessary to change extension of m_file_name_upload
                return true;
            }

            string[] allowed_extensions = GetExtensions(out o_error);
            if (null == allowed_extensions || o_error.Length > 0)
            {
                o_error = @"OpenSaveDialog.CheckModifyExtensionForNewUploadDocument " + o_error;
                return false;
            }

            string upload_file_name_without_extension = Path.GetFileNameWithoutExtension(m_file_name_upload);
            for (int index_ext = 0; index_ext < allowed_extensions.Length; index_ext++)
            {
                string current_ext = "." + allowed_extensions[index_ext];
                if (current_ext.Equals(selected_file_name_extension))
                {
                    m_file_name_upload = upload_file_name_without_extension + current_ext;
                    o_file_name_upload = m_file_name_upload;
                    return true;
                }

            } // index_ext

            o_error = @"OpenSaveDialog.CheckModifyExtensionForNewUploadDocument File filter not OK. User has selected a file with a not allowed extension";

            return false;

        } // CheckModifyExtensionForNewUploadDocument

        /// <summary>Get file name with path from the user
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_case_extension">File extension type: main, pdf, txt, img, htm or js</param>
        /// <param name="i_file_extensions">File extensions</param>
        /// <param name="o_cancel">Flag telling if the user cancelled download</param>
        /// <param name="o_file_name">Full file name</param>
        /// <param name="o_error">Error message.</param>
        public static bool GetFileName(string i_case_extension, string i_file_extensions, out bool o_cancel, out string o_file_name, out string o_error)
        {
            o_error = @"";
            o_cancel = false;
            o_file_name = @""; 

            if (!SetFileFilter(i_case_extension, out o_error))
            {
                o_error = @"OpenSaveDialog.GetFileName SetFileFilter failed " + o_error;
                return false;
            }

            OpenFileDialog open_file_dialog = new OpenFileDialog();

            open_file_dialog.InitialDirectory = DocAdmin.GetDirectoryUpload();
            open_file_dialog.Filter = m_file_filter;
            open_file_dialog.FilterIndex = 1;
            open_file_dialog.RestoreDirectory = true; // Not setting Environment.CurrentDirectory

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                o_file_name = open_file_dialog.FileName;

                DocAdmin.SetDirectoryUpload(Path.GetDirectoryName(o_file_name));
            }
            else
            {
                // User cancelled the upload from a file
                o_cancel = true;
                return true;
            }

            return true;

        } // Upload

        /// <summary>Backup one file
        /// <para></para>
        /// <para>The backup directory will be created (if not existing) in the directory defined by the input path.</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_server_backup_file">Name of the file (with sub path) for which a backup shall be created </param>
        /// <param name="o_error">Error message.</param>
        public static bool BackupFile(string i_server_backup_file, out string o_error)
        {
            o_error = @"";

            string file_name = Path.GetFileName(i_server_backup_file);

            string server_dir = Path.GetDirectoryName(i_server_backup_file) + @"\";

            string local_directory = DocAdmin.GetNameDirectoryDocuments();
            string local_backup_file_name = _GetBackupLocalFileName(local_directory, file_name);
            string backup_local_directory = Path.GetDirectoryName(local_backup_file_name);

            server_dir = server_dir.Replace(@"\", @"/");

            string server_file = server_dir + file_name;

            Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            if (!ftp_download.DownloadFile(server_file, local_backup_file_name, out o_error))
            {
                o_error = @"OpenSaveDialog.BackupFile Ftp.DownLoad.DownloadFileServerLocal failed" + o_error;
                return false;
            }

            string error_message = @"";
            string backup_server_directory_name = @"";
            if (!CreateServerBackupDirectoryFromFileName(server_dir, out backup_server_directory_name, out error_message))
            {
                o_error = @"OpenSaveDialog.Backup " + error_message;
                return false;
            }

            string backup_server_file_name = backup_server_directory_name + Path.GetFileName(local_backup_file_name);

            UpLoad upload = new UpLoad();
            bool to_www = true;
            if (!upload.OneFile(to_www, backup_server_file_name, local_backup_file_name, out error_message))
            {
                o_error = @"OpenSaveDialog.Backup " + error_message;
                return false;
            }

            return true;

        } // Backup

        /// <summary>Backup a document
        /// <para></para>
        /// <para>The backup directory will be created (if not existing) in the directory defined by the input path.</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_file_path">Path to the file on the server where the document shall be stored</param>
        /// <param name="i_file_name">Name of file for which a backup shall be created</param>
        /// <param name="i_admin_file">Flag telling if the file is an Admin file, i.e. if it shall be saved in server directory /admin/JazzAppAdmin/Backups/</param>
        /// <param name="o_error">Error message.</param>
        private static bool Backup(string i_file_path, string i_file_name, bool i_admin_file, out string o_error)
        {
            o_error = @"";

            if (i_admin_file)
            {
                if (!BackupAdminFile(i_file_path, i_file_name, out o_error))
                {
                    o_error = @"OpenSaveDialog.Backup BackupAdminFile failed " + o_error;
                    return false;
                }

                return true;
            }

            string server_file_name = GetServerDirectory(m_file_path) + i_file_name;

            string local_directory = DocAdmin.GetNameDirectoryDocuments();
            string local_backup_file_name = _GetBackupLocalFileName(local_directory, i_file_name);

            DownLoad download = new DownLoad();

            string error_message = @"";
            if (!download.OneFile(server_file_name, local_backup_file_name, out error_message))
            {
                o_error = @"OpenSaveDialog.Backup " + error_message;
                return false;
            }

            string backup_server_directory_name = @"";

            if (CreateServerBackupDirectory(out backup_server_directory_name, out error_message))
            {
                o_error = @"OpenSaveDialog.Backup " + error_message;
                return false;
            }

            string backup_server_file_name = backup_server_directory_name + Path.GetFileName(local_backup_file_name);

            UpLoad upload = new UpLoad();
            bool to_www = true;
            if (!upload.OneFile(to_www, backup_server_file_name, local_backup_file_name, out error_message))
            {
                o_error = @"OpenSaveDialog.Backup " + error_message;
                return false;
            }

            return true;

        } // Backup

        /// <summary>Backup a document that is an /admin/JazzAppAdmin/ file
        /// <para></para>
        /// <para>The backup directory is assumed to exist</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_file_path">Path to the file on the server where the document shall be stored</param>
        /// <param name="i_file_name">Name of file for which a backup shall be created</param>
        /// <param name="o_error">Error message.</param>
        private static bool BackupAdminFile(string i_file_path, string i_file_name, out string o_error)
        {
            o_error = @"";

            // string server_file_name = @"/" + JazzAppAdminSettings.Default.DirAdminServerMain + @"/" + m_file_path + @"/" + i_file_name;
            //QQQ string server_file_name = i_file_name;

            string local_directory = DocAdmin.GetNameDirectoryDocuments();
            string local_backup_file_name = _GetBackupLocalFileName(local_directory, i_file_name);

            DownLoad download = new DownLoad();

            string error_message = @"";
            if (!download.OneAdminFile(i_file_name, i_file_path, local_backup_file_name, out error_message))
            {
                o_error = @"OpenSaveDialog.BackupAdminFile DownLoad.OneAdminFile failed " + error_message;
                return false;
            }

            string server_dir = @"/" + JazzAppAdminSettings.Default.DirAdminServerMain + @"/" + m_file_path;

            string backup_server_file_name = server_dir + @"/Backups/" + Path.GetFileName(local_backup_file_name);

            UpLoad upload = new UpLoad();
            if (!upload.OneAdminFile(backup_server_file_name, local_backup_file_name, out error_message))
            {
                o_error = @"OpenSaveDialog.BackupAdminFile Upload.OneAdminFile failed " + error_message;
                return false;
            }

            return true;

        } // BackupAdminFile

        /// <summary>Create a server backup directory if not existing
        /// <para></para>
        /// <para>The backup directory will be created (if not existing) in the directory defined by member variable m_file_path.</para>
        /// </summary>
        static private bool CreateServerBackupDirectory(out string o_backup_server_directory_name, out string o_error)
        {
            if (m_file_path.Equals("www"))
            {
                o_backup_server_directory_name = @"/www/" + DocAdminString.DirectoryBackups + @"/";
            }
            else
            {
                o_backup_server_directory_name = @"/www/" + m_file_path + @"/" + DocAdminString.DirectoryBackups + @"/";
            }
            

            UpLoad upload = new UpLoad();
            bool to_www = true;

            if (!upload.CreateServerDirectory(to_www, o_backup_server_directory_name, out o_error))
            {
                o_error = "OpenSaveDialog.GetServerBackupDirectory UpLoad.CreateServerDirectory failed " + o_error;
                
                return false;
            }

            return false;

        } // CreateServerBackupDirectory

        /// <summary>Create a server backup directory if not existing
        /// <para></para>
        /// <para>The backup directory will be created (if not existing) in the directory defined by member variable m_file_path.</para>
        /// </summary>
        static private bool CreateServerBackupDirectoryFromFileName(string i_file_name, out string o_backup_server_directory_name, out string o_error)
        {
            o_backup_server_directory_name = Path.GetDirectoryName(i_file_name) + @"/" + DocAdminString.DirectoryBackups + @"/";

            UpLoad upload = new UpLoad();
            bool to_www = true;

            if (upload.DoesDirectoryExist(to_www, o_backup_server_directory_name, out o_error))
            {
                // No error
                // o_error = "OpenSaveDialog.CreateServerBackupDirectoryFromFileName Directory already exists " + o_error;

                return true;
            }

            if (!upload.CreateServerDirectory(to_www, o_backup_server_directory_name, out o_error))
            {
                o_error = "OpenSaveDialog.CreateServerBackupDirectoryFromFileName UpLoad.CreateServerDirectory failed " + o_error;

                return false;
            }

            return true;

        } // CreateServerBackupDirectoryFromFileName

        #region Extensions

        /// <summary>Returns the full local backup file name 
        /// <para>Note that FileUtil.SubDirectory creates directories if not existing</para>
        /// </summary>
        static private string _GetBackupLocalFileName(string i_file_path_local, string i_file_name)
        {
            string backup_directory = DocAdminString.DirectoryBackups;

            string path_backup_combine = i_file_path_local + @"\" + backup_directory;

            string path_backup = FileUtil.SubDirectory(path_backup_combine, Main.ExeDirectory);

            string backup_file_name = FileUtil.AddDateAndMachineToFileName(i_file_name);

            return path_backup + @"\" + backup_file_name;

        } // _GetBackupLocalFileName

        /// <summary>Returns the member variable extensions (m_file_extensions) as a string array. Only one comma (two extensions) is implemented</summary>
        private static string[] GetExtensions(out string o_error)
        {
            o_error = @"";
            string[] ret_extensions = null;

            string extension_string = m_file_extensions;
            if (extension_string.Trim().Length < 3)
            {
                o_error = @"OpenSaveDialog.GetExtensions Extensions length < 3";
                return ret_extensions;
            }

            // It is assumed that there is only one comma,i.e. only two extensions are defined. For instance docx,doc
            int index_comma = extension_string.IndexOf(",");
            if (index_comma < 0)
            {
                ret_extensions = new string[1];
                ret_extensions[0] = extension_string.Trim();
                return ret_extensions;
            }

            int n_commas = 0;

            int[] indeces_start_end = new int[10];

            indeces_start_end[0] = 0;

            for (int index_char=0; index_char < extension_string.Length; index_char++)
            {
                string current_char = extension_string.Substring(index_char, 1);

                if (current_char.Equals(","))
                {
                    indeces_start_end[n_commas + 1] = index_char + 1;

                    n_commas = n_commas + 1;

                    if (n_commas > 10)
                    {
                        o_error = @"OpenSaveDialog.GetExtensions More than ten extensions are defined";

                        return ret_extensions;
                    }
                }
            }

            indeces_start_end[n_commas + 1] = extension_string.Length + 1; // Minus 1 below

            ret_extensions = new string[n_commas + 1];

            for (int index_ext=0; index_ext < n_commas + 1; index_ext++)
            {
                string current_substr = "Undefined";

                int start_index = indeces_start_end[index_ext];
                int n_chars = indeces_start_end[index_ext + 1] - indeces_start_end[index_ext] - 1;


                current_substr = extension_string.Substring(start_index, n_chars);

                current_substr = current_substr.Trim();

                ret_extensions[index_ext] = current_substr;

            }

            /*QQQQQ 2020-08-25
            ret_extensions = new string[2];

            ret_extensions[0] = extension_string.Substring(0, index_comma).Trim();
            ret_extensions[1] = extension_string.Substring(index_comma+1).Trim();

            if (ret_extensions[1].IndexOf(",") >= 0)
            {
                o_error = @"OpenSaveDialog.GetExtensions More than two extensions are defined";
                return ret_extensions;
            }
            QQQQ*/

            return ret_extensions;

        } // GetExtensions

        /// <summary>Sets the file filter</summary>
        private static bool SetFileFilter(string i_case_extension, out string o_error)
        {
            o_error = @"";

            if ("pdf" == i_case_extension)
            {
                m_file_filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                return true;
            }
            else if ("txt" == i_case_extension)
            {
                m_file_filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                return true;
            }
            else if ("img" == i_case_extension)
            {
                m_file_filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
                return true;
            }
            else if ("jpg" == i_case_extension)
            {
                m_file_filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                return true;
            }
            else if ("htm" == i_case_extension)
            {
                m_file_filter = "htm files (*.htm)|*.htm|All files (*.*)|*.*";
                return true;
            }
            else if ("js" == i_case_extension)
            {
                m_file_filter = "js files (*.js)|*.js|All files (*.*)|*.*";
                return true;
            }
            else if ("rtf" == i_case_extension)
            {
                m_file_filter = "rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
                return true;
            }
            else if ("zip" == i_case_extension)
            {
                m_file_filter = "zip files (*.zip)|*.zip|All files (*.*)|*.*";
                return true;
            }
            else if ("sound" == i_case_extension)
            {
                m_file_filter = "mp3 files (*.mp3)|*.mp3|mp4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
                return true;
            }

            if ("main" != i_case_extension)
            {
                o_error = @"OpenSaveDialog.SetFileFilter Not implemented i_case_file_type= " + i_case_extension;
                return false;
            }


            string error_message = @"";
            string[] doc_extensions = GetExtensions(out error_message);
            if (null == doc_extensions || error_message.Length > 0)
            {
                o_error = @"OpenSaveDialog.SetFileFilter " + error_message;
                return false;
            }

            if (doc_extensions.Length == 1)
            {
                if (doc_extensions[0].Equals("docx"))
                {
                    m_file_filter = "docx files (*.docx)|*.docx|All files (*.*)|*.*";
                }
                else if (doc_extensions[0].Equals("doc"))
                {
                    m_file_filter = "doc files (*.doc)|*.doc|All files (*.*)|*.*";
                }
                else if (doc_extensions[0].Equals("xlsx"))
                {
                    m_file_filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                }
                else if (doc_extensions[0].Equals("xls"))
                {
                    m_file_filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                }
                else if (doc_extensions[0].Equals("pdf"))
                {
                    m_file_filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                }
                else if (doc_extensions[0].Equals("txt"))
                {
                    m_file_filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                }
                else
                {
                    o_error = @"OpenSaveDialog.SetFileFilter This extensions is not implemented: " + doc_extensions[0];
                    return false;
                }

                return true;
            } // Only one extension

            /* QQQQQ 2020-01-25
            if (doc_extensions[0].Equals("docx") && doc_extensions[1].Equals("doc"))
            {
                m_file_filter = "docx files (*.docx)|*.docx|doc files (*.doc)|*.doc|All files (*.*)|*.*";
            }
            else if (doc_extensions[0].Equals("doc") && doc_extensions[1].Equals("docx"))
            {
                m_file_filter = "doc files (*.doc)|*.doc|docx files (*.docx)|*.docx|All files (*.*)|*.*";
            }
              2020-01-25 QQQQQQ*/

            if (wordExtensions(doc_extensions, false))
            {
                wordExtensions(doc_extensions, true);
            }
            else if (doc_extensions[0].Equals("xlsx") && doc_extensions[1].Equals("xls"))
            {
                m_file_filter = "xlsx files (*.xlsx)|*.xlsx|xls files (*.xls)|*.xls|All files (*.*)|*.*";
            }
            else if (doc_extensions[0].Equals("xls") && doc_extensions[1].Equals("xlsx"))
            {
                m_file_filter = "xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            }
            else
            {
                o_error = @"OpenSaveDialog.SetFileFilter This combination of extensions is not implemented: " + doc_extensions[0] + " " + doc_extensions[1];
                return false;
            }


            return true;

        } // GetExtensions

        /// <summary>Check or set file filter for Word documents
        /// </summary>
        /// <param name="i_doc_extensions">Array with extensions</param>
        /// <param name="i_b_set_filter">Flag telling if global filter variable shall be set or if function only shall return bool value</param>
        private static bool wordExtensions(string[] i_doc_extensions, bool i_b_set_filter)
        {
            bool ret_bool = false;

            bool b_docx = false;

            bool b_doc = false;

            bool b_rtf = false;

            for (int index_ext=0; index_ext < i_doc_extensions.Length; index_ext++)
            {
                string current_ext = i_doc_extensions[index_ext];

                if (current_ext == "docx")
                {
                    b_docx = true;
                }
                if (current_ext == "doc")
                {
                    b_doc = true;
                }
                if (current_ext == "rtf")
                {
                    b_rtf = true;
                }

            } // index_ext

            if (!b_docx && !b_doc && !b_rtf)
            {
                ret_bool = false;
            }
            else
            {
                ret_bool = true;
            }

            if (!ret_bool)
            {
                return ret_bool;
            }
            else
            {
                if (!i_b_set_filter)
                {
                    return ret_bool;
                }
            }

            m_file_filter = "";

            if (b_docx)
            {
                m_file_filter = m_file_filter + "docx files (*.docx)|*.docx|";
            }

            if (b_doc)
            {
                m_file_filter = m_file_filter + "doc files (*.doc)|*.doc|";
            }

            if (b_rtf)
            {
                m_file_filter = m_file_filter + "rtf files (*.rtf)|*.rtf|";
            }

            m_file_filter = m_file_filter + "All files (*.*)|*.*";

            return ret_bool;

        } // areWordExtensions

        /// <summary>Check input data and set member variables 
        /// <para>1. Extensions are checked.</para>
        /// <para>2. Member variables are set: m_case_extension = i_case_extension, m_file_extensions = i_file_extensions and  m_file_path = i_file_path</para>
        /// <para>3. Member variable  m_file_name_upload = i_file_name if i_upload_document is true and m_file_name_download = i_file_name if  i_upload_document is false</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_upload_document">Flag telling if is an upload file</param>
        /// <param name="i_file_path">Path on the server to the file</param>
        /// <param name="i_file_name_upload">Name of the upload file</param>
        /// <param name="i_case_extension">File extension type: htm, js or rtf</param>
        /// <param name="i_file_extensions">File extensions</param>
        /// <param name="o_error">Error message.</param>
        private static bool CheckSetInput(bool i_upload_document, string i_file_path, string i_file_name, string i_case_extension, string i_file_extensions, out string o_error)
        {
            o_error = @"";

            if (i_case_extension.Equals("main") || i_case_extension.Equals("pdf")
                || i_case_extension.Equals("txt") || i_case_extension.Equals("img")
                || i_case_extension.Equals("htm") || i_case_extension.Equals("js")
                || i_case_extension.Equals("zip") || i_case_extension.Equals("rtf")
                || i_case_extension.Equals("sound") )
            {
                m_case_extension = i_case_extension;
            }
            else
            {
                o_error = @"OpenSaveDialog.CheckSetInput " + i_case_extension + @" is not main, pdf, txt, img, htm, js, rtf or sound";
                return false;
            }

            if (i_file_extensions.Length >= 2)
            {
                m_file_extensions = i_file_extensions;
            }
            else
            {
                o_error = @"OpenSaveDialog.CheckSetInput File extensions has less than two characters";
                return false;
            }

            m_file_path = i_file_path;

            if (i_file_name.Length < 4)
            {
                o_error = @"OpenSaveDialog.CheckSetInput File name length < 4";
                return false;
            }

            if (i_upload_document)
            {
                m_file_name_upload = i_file_name;
            }
            else
            {
                m_file_name_download = i_file_name;
            }

            return true;

        } // CheckSetInput

        #endregion // Extensions

    } // OpenSaveDialog

} // namespace
