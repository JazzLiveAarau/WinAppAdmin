using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Handles backups of XML and XSD files
    /// <para></para>
    /// </summary>
    public static class Backup
    {
        /// <summary>Backup the input current XML file</summary>

        /// <summary>Backup the input (current) XML file
        /// <para>It is assumed that the XML file is in the XML directory on the server</para>           
        /// <param name="i_current_xml_url">URL for the current XML file (document)</param>
        /// <param name="i_edited">Set to true if file has been edited</param>
        /// <param name="o_error">Error message</param>
        static public bool BackupCurrentEditXmlFile(string i_current_xml_url, bool i_edited, out string o_error)
        {
            o_error = @"";

            if (i_current_xml_url.Trim().Length == 0)
            {
                o_error = @"Backup.BackupCurrentEditXmlFile Programming error: Input URL is empty";
                return false;
            }

            string file_name_local = @"";

            if (!DownloadXmlFile(i_current_xml_url, out file_name_local, out o_error))
            {
                o_error = @"Backup.BackupCurrentEditXmlFile " + o_error;
                return false;
            }

 
            UpLoad htpp_upload = new UpLoad();

            string server_full_file_name_time_stamped = BackupEditedServerFileUrl(file_name_local, i_edited);

            bool to_www = false;
            if (!htpp_upload.OneFile(to_www, server_full_file_name_time_stamped, file_name_local, out o_error))
            {
                o_error = "Backup.BackupCurrentEditXmlFile Upload.OneFile failed: " + o_error;
                return false;
            }

            File.Delete(file_name_local);

            return true;

        } // BackupCurrentEditXmlFile


        /// <summary>Returns the full server file URL for a backup of an edited XML file
        /// <para>It is assumed that the directory XmlChangedBackupDir exists on the server</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        static private string BackupEditedServerFileUrl(string i_file_name, bool i_edited)
        {
            string server_xml_directory = JazzAppAdminSettings.Default.XmlChangedBackupDir + @"\";

            string local_name_no_no_ext = Path.GetFileNameWithoutExtension(i_file_name);
            string local_name_ext = Path.GetExtension(i_file_name);
            string edited_original = @"_Origin";
            if (i_edited)
                edited_original = @"_Edited";

            string server_full_file_name_time_stamped = server_xml_directory + local_name_no_no_ext + edited_original +
                @"_" + TimeUtil.YearMonthDayHourMinSec() + local_name_ext;

            return server_full_file_name_time_stamped;
        } // BackupEditedServerFileUrl

        /// <summary>Download one XML file from the server
        /// <para>1. The function checks if there is an Internet connection.</para>
        /// <para>2. The XML file is saved in a subdirectory XML to the exe directory.</para>
        /// </summary>
        /// <param name="i_current_xml_url">File URL</param>
        /// <param name="o_error">Error description</param>
        /// <returns>true if succeeded</returns>
        static public bool DownloadXmlFile(string i_current_xml_url, out string o_file_name_local, out string o_error)
        {
            o_error = @"";
            o_file_name_local = @"";

            if (i_current_xml_url.Trim().Length == 0)
            {
                o_error = @"Backup.DownloadXmlFile Programming error: Input URL is empty";
                return false;
            }

            string str_uri = @"http://" + JazzAppAdminSettings.Default.FtpHost;
            if (!InternetUtil.IsConnectionAvailable(str_uri, out o_error))
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNoInternetConnection;
                return false;
            }

            o_file_name_local = AdminUtils.GetFileNameExeDir(i_current_xml_url);

            DownLoad http_download = new DownLoad();

            if (!http_download.OneFile(i_current_xml_url, o_file_name_local, out o_error))
            {
                o_error = "Backup.DownloadXmlFile Programming error: " + o_error;
                return false;
            }

            return true;
        } // DownloadXmlFile


        /// <summary>Backup all files if not already made</summary>
        static public bool BackupAll(out string o_error)
        {
            o_error = "";

            if (BackupAllFlag)
                return true;

            if (!DownloadXmlFiles(out o_error))
                return false;

            if (!BackupAllXmlAndXsdFiles(out o_error))
                return false;

            BackupAllFlag = true;

            return true;
        } // BackupAll

        #region Private functions for backup of all XML and XSD function

        /// <summary>Flag telling if all files on the server XML directory have been backed up</summary>
        static private bool m_backup_all = false;

        /// <summary>Set or get the flag telling if all files on the server XML directory have been backed up</summary>
        static private bool BackupAllFlag
        { get { return m_backup_all; } set { m_backup_all = value; } }


        /// <summary>Download all XML and XSD files from the server
        /// <para>1. The function checks if there is an Internet connection.</para>
        /// <para>2. The XML application and XML season files are saved in a subdirectory XML to the exe directory.</para>
        /// <para>3. Also the schema XSD files are downloaded to this XML subdirectory.</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        /// <returns>true if succeeded</returns>
        static public bool DownloadXmlFiles(out string o_error)
        {
            o_error = "";

            string str_uri = @"http://" + JazzAppAdminSettings.Default.FtpHost;
            if (!InternetUtil.IsConnectionAvailable(str_uri, out o_error))
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNoInternetConnection;
                return false;
            }

            bool b_down_load = true;

            DownLoad http_download = new DownLoad();

            if (!http_download.AllSeasonXmlFiles(out o_error))
            {
                b_down_load = false;
                return b_down_load;
            }

            if (!http_download.ApplicationXmlFile(out o_error))
            {
                b_down_load = false;
                return b_down_load;
            }

            if (!http_download.ApplicationXsdFile(out o_error))
            {
                b_down_load = false;
                return b_down_load;
            }

            if (!http_download.SchemaXsdFiles(out o_error))
            {
                b_down_load = false;
                return b_down_load;
            }

            return b_down_load;
        } // DownloadXmlFiles

        /// <summary>Backup all XML and XSD files on the server in a time stamped directory
        /// <para>1. Get all XML and XSD files that were downloaded. Call of DownLoad.GetDownLoadedFiles</para>
        /// <para>2. Create the time stamped backup directory on the server. Call of Upload.CreateServerDirectory</para>
        /// <para>3. Copy all downloaded XML and XSD files to the time stamped server directory. Calls of Upload.OneFile</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        /// <returns>true if function succeeded</returns>
        static private bool BackupAllXmlAndXsdFiles(out string o_error)
        {
            o_error = "";
            bool b_backup = true;

            DownLoad http_download = new DownLoad();

            string[] down_loaded_files = http_download.GetDownLoadedFiles(out o_error);
            if (null == down_loaded_files)
            {
                o_error = "Backup.BackupAllXmlAndXsdFiles Programming error: " + o_error;
                b_backup = false;
                return b_backup;
            }

            string server_xml_directory = JazzAppAdminSettings.Default.XmlAllBackupDir + @"\";
            string backup_local_file_name_time = _GetBackupXmlLocalFileName("backup.txt");
            string server_backupdirectory = Path.GetFileNameWithoutExtension(backup_local_file_name_time);
            string server_xml_backup_directory_time_machine = server_xml_directory + server_backupdirectory;

            UpLoad htpp_upload = new UpLoad();

            bool to_www = false;

            if (!htpp_upload.CreateServerDirectory(to_www, server_xml_backup_directory_time_machine, out o_error))
            {
                o_error = "Backup.BackupAllXmlAndXsdFiles UpLoad.CreateServerDirectory failed " + o_error;
                b_backup = false;
                return b_backup;
            }

            for (int i_backup = 0; i_backup < down_loaded_files.Length; i_backup++)
            {
                string local_full_file_name = down_loaded_files[i_backup];

                string local_file_name_without_dir = Path.GetFileName(local_full_file_name);
                string server_file_url = server_xml_backup_directory_time_machine + @"\" + local_file_name_without_dir;

                
                if (!htpp_upload.OneFile(to_www, server_file_url, local_full_file_name, out o_error))
                {
                    o_error = "Backup.BackupAllXmlAndXsdFiles Upload.OneFile failed: " + o_error;
                    b_backup = false;
                    return b_backup;
                }

                File.Delete(local_full_file_name);
            }

            return b_backup;

        } // BackupAllXmlAndXsdFiles



        /// <summary>Returns the full file name for a backup XML or XSD file
        /// <para>1. Subdirectory name from the configuration file (JazzAppAdminSettings).</para>
        /// <para>2. Create the combined full name. Call of function FileUtil.BackupAddressesFileName.</para>
        /// </summary>
        static private string _GetBackupXmlLocalFileName(string i_xml_file_name)
        {
            string backup_directory = JazzAppAdminSettings.Default.XmlBackupsDir;
            string local_time_address_file = FileUtil.BackupAddressesFileName(i_xml_file_name, backup_directory, Main.m_exe_directory);

            return local_time_address_file;
        } // _GetBackupXmlLocalFileName

        #endregion // Private functions for backup of all XML and XSD function

    } // Backup

} // namespace
