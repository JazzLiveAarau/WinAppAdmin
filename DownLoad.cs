using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;


namespace JazzAppAdmin
{
    /// <summary>Download of files from the server</summary>
    class DownLoad
    {
        /// <summary>Download one file</summary>
        public bool OneFile(string i_url, string i_local_filename, out string o_error)
        {
            o_error = "";

            WebClient webClient = new WebClient();

            try
            {
                webClient.DownloadFile(i_url, i_local_filename);
            }
            catch (Exception ex)
            {

                o_error = ex.Message;

                return false;
            }
            return true;
        } // OneFile


        /// <summary>All Season XML files</summary>
        public bool AllSeasonXmlFiles(out string o_error)
        {
            o_error =  "";

            string[] all_possible_local_file_names = SeasonUtil.GetAllPossibleXmlSeasonLocalFileNames();
            string[] all_possible_url_file_names = SeasonUtil.GetAllPossibleXmlSeasonFileUrls();

            int n_possible_files = all_possible_local_file_names.Length;
            if(n_possible_files != all_possible_url_file_names.Length)
            {
                o_error = "DownLoad.AllSeasonXmlFiles Programming error";
                return false;
            }

            for (int i_index_file = 0; i_index_file < n_possible_files; i_index_file++)
            {
                string file_url = all_possible_url_file_names[i_index_file];
                string file_local = all_possible_local_file_names[i_index_file];

                if (!OneFile(file_url, file_local, out o_error))
                {
                    o_error = ""; // Expeczted error when there is no file
                    break;
                }
            } // i_index_file


            return true;

        } // AllSeasonXmlFiles

        /// <summary>One season XML file</summary>
        public bool SeasonXmlFile(string i_server_file_url, out string o_error)
        {
            o_error = "";

            if (i_server_file_url.Trim().Length == 0)
            {
                o_error = @"Download.SeasonXmlFile Programming error: Input URL is empty";
                return false;
            }

            string local_address_directory = FileUtil.SubDirectory(JazzAppAdminSettings.Default.XmlExistingDir, Main.m_exe_directory) + @"\";
            string local_file_name = local_address_directory + JazzAppAdminSettings.Default.ApplicationFileName;

            if (!OneFile(i_server_file_url, local_file_name, out o_error))
            {
                o_error = "Download.SeasonXmlFile Programming error: " + o_error;
                return false;
            }


            return true;

        } // SeasonXmlFile

        /// <summary>Application XML file</summary>
        public bool ApplicationXmlFile(out string o_error)
        {
            o_error = "";

            string server_address_directory = @"http://" + JazzAppAdminSettings.Default.FtpHost + @"/" + JazzAppAdminSettings.Default.XmlExistingDir + @"/";
            string server_file_url = server_address_directory + JazzAppAdminSettings.Default.ApplicationFileName;
            string local_address_directory = FileUtil.SubDirectory(JazzAppAdminSettings.Default.XmlExistingDir, Main.m_exe_directory) + @"\";
            string local_file_name = local_address_directory + JazzAppAdminSettings.Default.ApplicationFileName;

            if (!OneFile(server_file_url, local_file_name, out o_error))
            {
                o_error = "Download.ApplicationXmlFile Programming error: " + o_error;
                return false;
            }

            return true;
        } // ApplicationXmlFile

        /// <summary>Application XSD file</summary>
        public bool ApplicationXsdFile(out string o_error)
        {
            o_error = "";

            string server_address_directory = @"http://" + JazzAppAdminSettings.Default.FtpHost + @"/" + JazzAppAdminSettings.Default.XmlExistingDir + @"/";
            string server_file_url = server_address_directory + JazzAppAdminSettings.Default.ApplicationFileName;
            string local_address_directory = FileUtil.SubDirectory(JazzAppAdminSettings.Default.XmlExistingDir, Main.m_exe_directory) + @"\";
            string local_file_name_xsd = Path.GetFileNameWithoutExtension(JazzAppAdminSettings.Default.ApplicationFileName) + @".xsd";
            string local_file_name = local_address_directory + local_file_name_xsd;

            if (!OneFile(server_file_url, local_file_name, out o_error))
            {
                o_error = "Download.ApplicationXmlFile Programming error: " + o_error;
                return false;
            }

            return true;
        } // ApplicationXmlFile

        /// <summary>Schema XSD files</summary>
        public bool SchemaXsdFiles(out string o_error)
        {
            o_error = "";

            string server_address_directory = @"http://" + JazzAppAdminSettings.Default.FtpHost + @"/" + JazzAppAdminSettings.Default.XmlExistingDir + @"/";
            string local_address_directory = FileUtil.SubDirectory(JazzAppAdminSettings.Default.XmlExistingDir, Main.m_exe_directory) + @"\";

            string server_file_one_url = server_address_directory + JazzAppAdminSettings.Default.SchemaFileOneName;
            string local_file_one_name = local_address_directory + JazzAppAdminSettings.Default.SchemaFileOneName;

            if (!OneFile(server_file_one_url, local_file_one_name, out o_error))
            {
                o_error = "Download.SchemaXsdFiles XSD One file Programming error: " + o_error;
                return false;
            }

            string server_file_two_url = server_address_directory + JazzAppAdminSettings.Default.SchemaFileTwoName;
            string local_file_two_name = local_address_directory + JazzAppAdminSettings.Default.SchemaFileTwoName;

            if (!OneFile(server_file_two_url, local_file_two_name, out o_error))
            {
                o_error = "Download.SchemaXsdFiles XSD Two file Programming error: " + o_error;
                return false;
            }

            return true;
        } // SchemaXsdFiles


        /// <summary>Get files that are downloaded</summary>
        public string[] GetDownLoadedFiles(out string o_error)
        {
            o_error = "";
            string[] ret_file_names = null;

            ArrayList array_list_extensions = new ArrayList();
            array_list_extensions.Add("xml");
            array_list_extensions.Add("xsd");
            string[] list_extensions = (string[])array_list_extensions.ToArray(typeof(string));

            string xml_replace_dir = FileUtil.SubDirectory(JazzAppAdminSettings.Default.XmlExistingDir, Main.m_exe_directory) + @"\";

            if (!FileUtil.GetFilesDirectory(list_extensions, xml_replace_dir, out ret_file_names))
            {
                o_error = "UpLoad.GetFilesForUpload failed. Programming error";
                return ret_file_names;
            }

            return ret_file_names;
        } // GetDownLoadedFiles



        /// <summary>Download an installer for a new version of the Jazz Admin application from the server with FTP
        /// <para>1. The function checks if there is an Internet connection.</para>
        /// <para>2. The installer is downloaded with function Getfiles in class Ftp.DownLoad.</para>
        /// <para>3. The installer is saved in a subdirectory (NeueVersion) to the exe directory.</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public bool DownloadNewVersion(out string o_error)
        {
            o_error = "";

            if (!AdminUtils.IsInternetConnectionAvailable())
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNoInternetConnection;

                return false;
            }

            bool b_down_load = true;

            Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            string server_address_directory = @"/" + JazzAppAdminSettings.Default.DirAdminServerMain + @"/" + 
                                                     JazzAppAdminSettings.Default.DirNewVersion + @"/";
            string local_address_directory = FileUtil.SubDirectory(JazzAppAdminSettings.Default.DirNewVersion, Main.m_exe_directory);

            if (!ftp_download.GetFiles(server_address_directory, local_address_directory, out o_error))
            {
                b_down_load = false;
            }

            if (!b_down_load)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNewVersionDownload;
            }

            return b_down_load;
        } // DownloadNewVersion

        /// <summary>Download all the help files for the Jazz Admin application from the server with FTP
        /// <para>1. The function checks if there is an Internet connection.</para>
        /// <para>2. The help files are downloaded with function Getfiles in class Ftp.DownLoad.</para>
        /// <para>3. The help files are saved in a subdirectory (Help) to the exe directory.</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public bool DownloadHelpFiles(out string o_error)
        {
            o_error = "";

            if (!AdminUtils.IsInternetConnectionAvailable())
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNoInternetConnection;

                return false;
            }

            bool b_down_load = true;

            Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            string server_address_directory = @"/" + JazzAppAdminSettings.Default.DirAdminServerMain + @"/" + HelpFiles.LocalDirHelpFiles + @"/"; ;

            string local_address_directory = FileUtil.SubDirectory(HelpFiles.LocalDirHelpFiles, Main.m_exe_directory);

            if (!ftp_download.GetFiles(server_address_directory, local_address_directory, out o_error))
            {
                b_down_load = false;
            }

            if (!b_down_load)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgLatestVersionInfoFileDownload;
                b_down_load = false;
            }

            return b_down_load;
        } // DownloadHelpFiles


        /// <summary>Download all XML template from the server with FTP
        /// <para>1. The function checks if there is an Internet connection.</para>
        /// <para>2. The XML templates are downloaded with function Getfiles in class Ftp.DownLoad.</para>
        /// <para>3. The XML templates are saved in a subdirectory (XmlTemplates) on the exe directory.</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public bool DownloadXmlTemplates(out string o_error)
        {
            o_error = "";

            if (!AdminUtils.IsInternetConnectionAvailable())
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNoInternetConnection;

                return false;
            }

            bool b_down_load = true;

            Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            string server_address_directory = @"/" + JazzAppAdminSettings.Default.DirAdminServerMain + @"/" +
                                                      JazzAppAdminSettings.Default.DirXmlTemplates + @"/";
            string local_address_directory = FileUtil.SubDirectory(JazzAppAdminSettings.Default.DirXmlTemplates, Main.m_exe_directory);

            if (!ftp_download.GetFiles(server_address_directory, local_address_directory, out o_error))
            {
                b_down_load = false;
            }

            if (!b_down_load)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNewVersionDownload;
            }

            return b_down_load;
        } // DownloadXmlTemplates

        /// <summary>Download all HTM template from the server with FTP
        /// <para>1. The function checks if there is an Internet connection.</para>
        /// <para>2. The HTM templates are downloaded with function Getfiles in class Ftp.DownLoad.</para>
        /// <para>3. The HTM templates are saved in a subdirectory (HtmTemplates) on the exe directory.</para>
        /// </summary>
        /// <param name="o_error">Error description</param>
        public bool DownloadHtmTemplates(out string o_error)
        {
            o_error = "";

            if (!AdminUtils.IsInternetConnectionAvailable())
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNoInternetConnection;

                return false;
            }

            bool b_down_load = true;

            Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            string server_address_directory = @"/" + JazzAppAdminSettings.Default.DirAdminServerMain + @"/" +
                                                      JazzAppAdminSettings.Default.DirHtmTemplates + @"/";
            string local_address_directory = GetLocalPathHtmTemplate();

            if (!ftp_download.GetFiles(server_address_directory, local_address_directory, out o_error))
            {
                b_down_load = false;
            }

            if (!b_down_load)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgHtmTemplatesDownload;
            }

            return b_down_load;
        } // DownloadHtmTemplates

        /// <summary>Download one HTM template file from the server with FTP
        /// <para>1. The function checks if there is an Internet connection.</para>
        /// <para>2. The HTM templates are downloaded with function DownloadFile in class Ftp.DownLoad.</para>
        /// <para>3. The HTM templates are saved in a subdirectory (HtmTemplates) on the exe directory.</para>
        /// </summary>
        /// <param name="i_template_file_name">Template file name</param>
        /// <param name="i_local_address_directory">Local address to which the template shall be downloaded</param>
        /// <param name="o_error">Error description</param>
        public bool DownloadOneHtmTemplate(string i_template_file_name, string i_local_address_directory, out string o_error)
        {
            o_error = "";

            if (!AdminUtils.IsInternetConnectionAvailable())
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNoInternetConnection;

                return false;
            }

            bool b_down_load = true;

           Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            string server_address_directory = @"/" + JazzAppAdminSettings.Default.DirAdminServerMain + @"/" +
                                                      JazzAppAdminSettings.Default.DirHtmTemplates + @"/";

            string server_file_name = server_address_directory + i_template_file_name;

            if (!ftp_download.DownloadFile(server_file_name, i_local_address_directory, out o_error))
            {
                b_down_load = false;
            }

            if (!b_down_load)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgHtmTemplateDownload + i_template_file_name;
            }

            return b_down_load;
        } // DownloadOneHtmTemplate


        /// <summary>Returns the path to the local HTM template files directory
        /// <para></para>
        /// </summary>
        public string GetLocalPathHtmTemplate()
        {
            string ret_path = FileUtil.SubDirectory(JazzAppAdminSettings.Default.DirHtmTemplates, Main.m_exe_directory);

            return ret_path;
        } // GetLocalFullFilenameHtmTemplate

        /// <summary>Returns the local full file name (i.e. with path) to an HTM template file
        /// <para></para>
        /// </summary>
        /// <param name="i_template_filename">Template file name</param>
        public string GetLocalFullFilenameHtmTemplate(string i_template_filename)
        {
            string ret_full_name = GetLocalPathHtmTemplate();

            ret_full_name = ret_full_name + @"\" + i_template_filename;

            return ret_full_name;

        } // GetLocalFullFilenameHtmTemplate


        /// <summary>FTP download of one file that is in a subdirectory to /appadmin/JazzAppAdmin/ on the server. 
        /// <para>The FTP host name and directory are retrived from JazzAppAdminSettings. Password is hardcoded (Main.FtpAdminPassword)</para>
        /// <para>An Ftp.DownLoad object with this data is created. File is downloaded with Ftp.DownLoad.DownloadFile</para>
        /// <para>The function first checks if there is an Internet connection (Ftp.InternetUtil.IsConnectionAvailable)</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_file_name">Server file name (without path), e.g. JAZZ_live_AARAU_AdminDokumente.rtf</param>
        /// <param name="i_server_admin_directory">Server subdirectory (without start and end slashes) from which the file shall be downloaded, e.g. Help</param>
        /// <param name="i_full_local_file_name">Local filename with path</param>
        /// <param name="o_error">Error description</param>
        public bool OneAdminFile(string i_file_name, string i_server_admin_directory, string i_full_local_file_name, out string o_error)
        {
            o_error = "";

            if (!AdminUtils.IsInternetConnectionAvailable())
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgNoInternetConnection;

                return false;
            }

            bool b_down_load = true;

            Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            string server_address_directory = @"/" + JazzAppAdminSettings.Default.DirAdminServerMain + @"/" +
                                                      i_server_admin_directory + @"/";

            string full_server_file_name = server_address_directory + i_file_name;

            if (!ftp_download.DownloadFile(full_server_file_name, i_full_local_file_name, out o_error))
            {
                b_down_load = false;
            }

            if (!b_down_load)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgAdminFileDownload + i_file_name;
            }

            return b_down_load;

        } // OneAdminFile

        /// <summary>FTP download of one file that is in any subdirectory on the server. 
        /// <para>The FTP host name and directory are retrived from JazzAppAdminSettings. Password is hardcoded (Main.FtpAdminPassword)</para>
        /// <para>An Ftp.DownLoad object with this data is created. File is downloaded with Ftp.DownLoad.DownloadFile</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_file_name">Server file name (without path), e.g. JAZZ_live_AARAU_AdminDokumente.rtf</param>
        /// <param name="i_server_admin_directory">Server subdirectory (without start and end slashes) from which the file shall be downloaded, e.g. Help</param>
        /// <param name="i_full_local_file_name">Local filename with path</param>
        /// <param name="o_error">Error description</param>
        public bool AnyDirFile(string i_file_name, string i_server_admin_directory, string i_full_local_file_name, out string o_error)
        {
            o_error = "";
 
            bool b_down_load = true;

            Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            string full_server_file_name = i_server_admin_directory + i_file_name;
            if (full_server_file_name.Substring(0,1).Equals("/"))
            {
                full_server_file_name = full_server_file_name.Substring(1);
            }

            if (!ftp_download.DownloadFile(full_server_file_name, i_full_local_file_name, out o_error))
            {
                b_down_load = false;
            }

            if (!b_down_load)
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgAdminFileDownload + i_file_name;
            }

            return b_down_load;

        } // AnyDirFile

        /// <summary>Download multiple file from the server to a local directory. 
        /// <para>The file names will be the same for the local files</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_server_file_names">Server file names with paths, e.g. /www/FotoKonzerte/Konzert.2012.11.03/JazzGalerie_G57.htm</param>
        /// <param name="i_local_dir_path">Path to the local directory, e.g. Fotos\Temp</param>
        /// <param name="o_error">Error description</param>
        public bool MultipleFiles(string[] i_server_file_names, string i_local_dir_path, out string o_error)
        {
            o_error = "";

            if (null == i_server_file_names || i_server_file_names.Length == 0)
            {
                o_error = "DownLoad.MultipleFiles i_server_file_names = null or number of names is zero (0)";
                return false;
            }

            string local_address_directory = FileUtil.SubDirectory(i_local_dir_path, Main.m_exe_directory) + @"\";
            string start_server_address_directory = @"http://" + JazzAppAdminSettings.Default.FtpHost;

            for (int i_index_file = 0; i_index_file < i_server_file_names.Length; i_index_file++)
            {
                string current_url_name = i_server_file_names[i_index_file];
                string file_name_no_www = current_url_name.Substring(4);
                string file_url = start_server_address_directory + file_name_no_www;
                string file_local = local_address_directory + Path.GetFileName(file_url);

                if (!OneFile(file_url, file_local, out o_error))
                {
                    o_error = "DownLoad.MultipleFiles OneFile failed " + o_error;
                    return false;
                }

            } // i_index_file

            return true;

        } // MultipleFiles

    } // Download
}
