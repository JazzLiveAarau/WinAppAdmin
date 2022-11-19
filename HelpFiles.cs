using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>The class HelpFiles defines all Admin help files that can downloaded from or uploaded to the server
    /// <para>These files are defined as an array of JazzHelp objects.</para>
    /// <para>The handling of help documents is similar as for the jazz documents which are defined as JazzXml.JazzDoc and JazzXml.JazzDocTemplate objects.</para>
    /// <para>The JazzXml document objects get their data from XML files. The data for the JazzHelp objects are hardcoded in this application. </para>
    /// <para></para>
    /// <para></para>
    /// </summary>
    public static class HelpFiles
    {
        /// <summary>Array of all help files that can be uploaded to or downloaded from the server</summary>
        static private JazzHelp[] m_help_files = null;
        /// <summary>Get and set the array of all help files that can be uploaded to or downloaded from the server</summary>
        static public JazzHelp[] AllHelpFiles { get { return m_help_files; } set { m_help_files = value; } }

        /// <summary>Get JazzHelp object with a given file name (FileName)</summary>
        static public JazzHelp GetHelp(string i_file_name, out string o_error)
        {
            JazzHelp ret_help = null;
            o_error = @"";

            JazzHelp[] help_files = AllHelpFiles;
            if (null == help_files || help_files.Length == 0)
            {
                o_error = @"HelpFiles.GetHelp AllHelpFiles (m_help_files) is null or has no elements";

                return ret_help;
            }

            for (int index_htm = 0; index_htm < help_files.Length; index_htm++)
            {
                JazzHelp current_help = help_files[index_htm];
                string current_file_name = current_help.FileName;

                if (current_file_name.Equals(i_file_name))
                {
                    return current_help;
                }
            }


            o_error = @"HelpFiles.GetHelp There is no JazzHelp with FileName= " + i_file_name;

            return ret_help;

        } //GetHelp

        /// <summary>Defines the names of help files that can be uploaded and downloaded 
        /// <para></para>
        /// <para></para>
        /// </summary>
        static private string[] m_help_file_names =
        {
            @"JAZZ_live_AARAU_Admin.rtf", // 0 
            @"JAZZ_live_AARAU_AdminDokumente.rtf", // 1 
            @"JAZZ_live_AARAU_AdminAnfragen.rtf", // 2 
            @"JAZZ_live_AARAU_AdminWebsite.rtf", // 3 
            @"JAZZ_live_AARAU_AdminXmlEdit.rtf", // 4
            @"JAZZ_live_AARAU_AdminFotos.rtf", // 5
            @"Help_Admin_Anfragen_Datenwartung.rtf", // 6
            @"Help_Admin_Dokumente_Datenwartung.rtf", // 7
            @"Help_Admin_Fotos_Datenwartung.rtf", // 8
            @"Help_Admin_Website_Datenwartung.rtf", // 9
            @"Help_Admin_XmlEdit_Datenwartung.rtf", // 10
            @"Admin_NeueFunktionen_Bugs.rtf", // 11
            @"JAZZ_live_AARAU_AdminFlyer.rtf", // 12

        }; // m_help_file_names


        /// <summary>Returns the filename for the Admin help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameAdmin() { return m_help_file_names[0]; }

        /// <summary>Returns the filename for the Admin Documents help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameAdminDocuments() { return m_help_file_names[1]; }

        /// <summary>Returns the filename for the Admin Requests help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameAdminRequests() { return m_help_file_names[2]; }

        /// <summary>Returns the filename for the Admin Website help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameAdminWebsite() { return m_help_file_names[3]; }

        /// <summary>Returns the filename for the Admin XML Edit help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameAdminXmlEdit() { return m_help_file_names[4]; }

        /// <summary>Returns the filename for the Admin Photos help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameAdminXmlPhotos() { return m_help_file_names[5]; }

        /// <summary>Returns the filename for the Admin requests maintenance help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameMaintenanceReqs() { return m_help_file_names[6]; }

        /// <summary>Returns the filename for the Admin maintenance documents help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameMaintenanceDocs() { return m_help_file_names[7]; }

        /// <summary>Returns the filename for the Admin maintenance photos help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameMaintenancePhotos() { return m_help_file_names[8]; }

        /// <summary>Returns the filename for the Admin maintenance website help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameMaintenanceWebsite() { return m_help_file_names[9]; }

        /// <summary>Returns the filename for the Admin maintenance XML edit help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameMaintenanceXmlEdit() { return m_help_file_names[10]; }

        /// <summary>Returns the filename for the Admin file with requests for new functions, changes and bugs. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameAdminNewFunctionsBugs() { return m_help_file_names[11]; }

        /// <summary>Returns the filename for the Admin Flyer help file. The name is defined in the array HelpFiles.m_help_file_names</summary>
        static public string GetFilenameAdminFlyer() { return m_help_file_names[12]; }


        /// <summary>Local directory for help files</summary>
        private static string m_local_dir_help_files = @"Help";
        /// <summary>Get local directory for help files</summary>
        public static string LocalDirHelpFiles { get { return m_local_dir_help_files; } }
        
        /// <summary>Server directory for help files.</summary>
        private static string m_server_dir_help_files = LocalDirHelpFiles;
        /// <summary>Get server directory for help files</summary>
        public static string ServerDirHelpFiles { get { return m_server_dir_help_files; } }

        /// <summary>Returns the full file name for the local help file.</summary>
        private static string GetFullLocalHelpFileName(string i_filename)
        {
            string ret_filename = @"";

            string local_address_directory = FileUtil.SubDirectory(LocalDirHelpFiles, Main.m_exe_directory) + @"\";

            ret_filename = local_address_directory + i_filename;

            return ret_filename;
        } // GetFullLocalHelpFileName

        /// <summary>Returns the full file name for the Admin help file</summary>
        public static string GetFullLocalHelpFileNameForAdmin()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHelpFileName(GetFilenameAdmin());

            return ret_full_filename;

        } // GetFullLocalHelpFileNameForAdmin

        /// <summary>Returns the full URL (server) name for the Admin help file</summary>
        public static string GetFullServerFileNameAdmin(string i_filename)
        {
            string ret_url = @"";

            ret_url = ServerDirHelpFiles + i_filename;

            return ret_url;
        } // GetFullServerFileNameAdmin


        /// <summary>Initialization of the array HtmlFiles (m_html_files)
        /// <para></para>
        /// <para></para>
        /// </summary>
        static public bool Init(out string o_error)
        {
            o_error = @"";

            // Number of elements
            m_help_files = new JazzHelp[13];

            // Start JazzHelp index 0
            JazzHelp AdminHelp = new JazzHelp();
            AdminHelp.FileName = GetFilenameAdmin();
            AdminHelp.Description = @"Die Datei " + GetFilenameAdmin() + @" enthält Hilfe für die JAZZ live AARAU Admin Applikation";
            AdminHelp.FileType = @"help";
            AdminHelp.ExtensionCase = @"rtf";
            AdminHelp.Extensions = @"rtf";
            AdminHelp.LocalPath = LocalDirHelpFiles;
            AdminHelp.ServerPath = ServerDirHelpFiles;
            string[] infos_admin = new string[1];
            infos_admin[0] = @"Die Datei .........";
            AdminHelp.Informations = infos_admin;
            m_help_files[0] = AdminHelp;
            // End JazzHelp index 0

            // Start JazzHelp index 1
            JazzHelp AdminHelpDocs = new JazzHelp();
            AdminHelpDocs.FileName = GetFilenameAdminDocuments();
            AdminHelpDocs.Description = @"Die Datei " + GetFilenameAdminDocuments() + @" enthält Hilfe für die Dokumenten Funktionen der JAZZ live AARAU Admin Applikation";
            AdminHelpDocs.FileType = @"help";
            AdminHelpDocs.ExtensionCase = @"rtf";
            AdminHelpDocs.Extensions = @"rtf";
            AdminHelpDocs.LocalPath = LocalDirHelpFiles;
            AdminHelpDocs.ServerPath = ServerDirHelpFiles;
            string[] infos_admin_docs = new string[1];
            infos_admin_docs[0] = @"Die Datei ....";
            AdminHelpDocs.Informations = infos_admin_docs;
            m_help_files[1] = AdminHelpDocs;
            // End JazzHelp index 1

            // Start JazzHelp index 2
            JazzHelp AdminHelpReqs = new JazzHelp();
            AdminHelpReqs.FileName = GetFilenameAdminRequests();
            AdminHelpReqs.Description = @"Die Datei " + GetFilenameAdminRequests() + @" enthält Hilfe für die Anfrage Funktionen der JAZZ live AARAU Admin Applikation";
            AdminHelpReqs.FileType = @"help";
            AdminHelpReqs.ExtensionCase = @"rtf";
            AdminHelpReqs.Extensions = @"rtf";
            AdminHelpReqs.LocalPath = LocalDirHelpFiles;
            AdminHelpReqs.ServerPath = ServerDirHelpFiles;
            string[] infos_admin_reqs = new string[1];
            infos_admin_reqs[0] = @"Die Datei ....";
            AdminHelpReqs.Informations = infos_admin_reqs;
            m_help_files[2] = AdminHelpReqs;
            // End JazzHelp index 2

            // Start JazzHelp index 3
            JazzHelp AdminHelpWebsite = new JazzHelp();
            AdminHelpWebsite.FileName = GetFilenameAdminWebsite();
            AdminHelpWebsite.Description = @"Die Datei " + GetFilenameAdminWebsite() + @" enthält Hilfe für die Website Funktionen der JAZZ live AARAU Admin Applikation";
            AdminHelpWebsite.FileType = @"help";
            AdminHelpWebsite.ExtensionCase = @"rtf";
            AdminHelpWebsite.Extensions = @"rtf";
            AdminHelpWebsite.LocalPath = LocalDirHelpFiles;
            AdminHelpWebsite.ServerPath = ServerDirHelpFiles;
            string[] infos_admin_website = new string[1];
            infos_admin_website[0] = @"Die Datei ....";
            AdminHelpWebsite.Informations = infos_admin_website;
            m_help_files[3] = AdminHelpWebsite;
            // End JazzHelp index 3

            // Start JazzHelp index 4
            JazzHelp AdminHelpXmlEdit = new JazzHelp();
            AdminHelpXmlEdit.FileName = GetFilenameAdminXmlEdit();
            AdminHelpXmlEdit.Description = @"Die Datei " + GetFilenameAdminXmlEdit() + @" enthält Hilfe für die XML Editierungs Funktionen der JAZZ live AARAU Admin Applikation";
            AdminHelpXmlEdit.FileType = @"help";
            AdminHelpXmlEdit.ExtensionCase = @"rtf";
            AdminHelpXmlEdit.Extensions = @"rtf";
            AdminHelpXmlEdit.LocalPath = LocalDirHelpFiles;
            AdminHelpXmlEdit.ServerPath = ServerDirHelpFiles;
            string[] infos_admin_xml_edit = new string[1];
            infos_admin_xml_edit[0] = @"Die Datei ....";
            AdminHelpXmlEdit.Informations = infos_admin_xml_edit;
            m_help_files[4] = AdminHelpXmlEdit;
            // End JazzHelp index 4

            // Start JazzHelp index 5
            JazzHelp AdminHelpPhotos = new JazzHelp();
            AdminHelpPhotos.FileName = GetFilenameAdminXmlPhotos();
            AdminHelpPhotos.Description = @"Die Datei " + GetFilenameAdminXmlPhotos() + @" enthält Hilfe für die Fotos Funktionen der JAZZ live AARAU Admin Applikation";
            AdminHelpPhotos.FileType = @"help";
            AdminHelpPhotos.ExtensionCase = @"rtf";
            AdminHelpPhotos.Extensions = @"rtf";
            AdminHelpPhotos.LocalPath = LocalDirHelpFiles;
            AdminHelpPhotos.ServerPath = ServerDirHelpFiles;
            string[] infos_admin_photos = new string[1];
            infos_admin_photos[0] = @"Die Datei ....";
            AdminHelpPhotos.Informations = infos_admin_photos;
            m_help_files[5] = AdminHelpPhotos;
            // End JazzHelp index 5

            // Start JazzHelp index 6
            JazzHelp MaintenanceReqs = new JazzHelp();
            MaintenanceReqs.FileName = GetFilenameMaintenanceReqs();
            MaintenanceReqs.Description = @"Die Datei " + GetFilenameMaintenanceReqs() + @" enthält Hilfe für die Datenwartung für Anfragen";
            MaintenanceReqs.FileType = @"help";
            MaintenanceReqs.ExtensionCase = @"rtf";
            MaintenanceReqs.Extensions = @"rtf";
            MaintenanceReqs.LocalPath = LocalDirHelpFiles;
            MaintenanceReqs.ServerPath = ServerDirHelpFiles;
            string[] infos_maintain_reqs = new string[1];
            infos_maintain_reqs[0] = @"Die Datei ....";
            MaintenanceReqs.Informations = infos_maintain_reqs;
            m_help_files[6] = MaintenanceReqs;
            // End JazzHelp index 6

            // Start JazzHelp index 7
            JazzHelp MaintenanceDocs = new JazzHelp();
            MaintenanceDocs.FileName = GetFilenameMaintenanceDocs();
            MaintenanceDocs.Description = @"Die Datei " + GetFilenameMaintenanceDocs() + @" enthält Hilfe für die Datenwartung für Dokumente";
            MaintenanceDocs.FileType = @"help";
            MaintenanceDocs.ExtensionCase = @"rtf";
            MaintenanceDocs.Extensions = @"rtf";
            MaintenanceDocs.LocalPath = LocalDirHelpFiles;
            MaintenanceDocs.ServerPath = ServerDirHelpFiles;
            string[] infos_maintain_docs = new string[1];
            infos_maintain_docs[0] = @"Die Datei ....";
            MaintenanceDocs.Informations = infos_maintain_docs;
            m_help_files[7] = MaintenanceDocs;
            // End JazzHelp index 7

            // Start JazzHelp index 8
            JazzHelp MaintenancePhotos = new JazzHelp();
            MaintenancePhotos.FileName = GetFilenameMaintenancePhotos();
            MaintenancePhotos.Description = @"Die Datei " + GetFilenameMaintenancePhotos() + @" enthält Hilfe für die Datenwartung für Fotos";
            MaintenancePhotos.FileType = @"help";
            MaintenancePhotos.ExtensionCase = @"rtf";
            MaintenancePhotos.Extensions = @"rtf";
            MaintenancePhotos.LocalPath = LocalDirHelpFiles;
            MaintenancePhotos.ServerPath = ServerDirHelpFiles;
            string[] infos_maintain_photos = new string[1];
            infos_maintain_photos[0] = @"Die Datei ....";
            MaintenancePhotos.Informations = infos_maintain_photos;
            m_help_files[8] = MaintenancePhotos;
            // End JazzHelp index 8

            // Start JazzHelp index 9
            JazzHelp MaintenanceWebsite = new JazzHelp();
            MaintenanceWebsite.FileName = GetFilenameMaintenanceWebsite();
            MaintenanceWebsite.Description = @"Die Datei " + GetFilenameMaintenanceWebsite() + @" enthält Hilfe für die Datenwartung für Website";
            MaintenanceWebsite.FileType = @"help";
            MaintenanceWebsite.ExtensionCase = @"rtf";
            MaintenanceWebsite.Extensions = @"rtf";
            MaintenanceWebsite.LocalPath = LocalDirHelpFiles;
            MaintenanceWebsite.ServerPath = ServerDirHelpFiles;
            string[] infos_maintain_website = new string[1];
            infos_maintain_website[0] = @"Die Datei ....";
            MaintenanceWebsite.Informations = infos_maintain_website;
            m_help_files[9] = MaintenanceWebsite;
            // End JazzHelp index 9

            // Start JazzHelp index 10
            JazzHelp MaintenanceXmlEdit = new JazzHelp();
            MaintenanceXmlEdit.FileName = GetFilenameMaintenanceXmlEdit();
            MaintenanceXmlEdit.Description = @"Die Datei " + GetFilenameMaintenanceXmlEdit() + @" enthält Hilfe für die Datenwartung für XML Edit";
            MaintenanceXmlEdit.FileType = @"help";
            MaintenanceXmlEdit.ExtensionCase = @"rtf";
            MaintenanceXmlEdit.Extensions = @"rtf";
            MaintenanceXmlEdit.LocalPath = LocalDirHelpFiles;
            MaintenanceXmlEdit.ServerPath = ServerDirHelpFiles;
            string[] infos_maintain_xml_edit = new string[1];
            infos_maintain_xml_edit[0] = @"Die Datei ....";
            MaintenanceXmlEdit.Informations = infos_maintain_xml_edit;
            m_help_files[10] = MaintenanceXmlEdit;
            // End JazzHelp index 10

            // Start JazzHelp index 11
            JazzHelp NewFunctionsBugs = new JazzHelp();
            NewFunctionsBugs.FileName = GetFilenameAdminNewFunctionsBugs();
            NewFunctionsBugs.Description = @"Die Datei " + GetFilenameAdminNewFunctionsBugs() + @" enthält wünsche für neue Funktionen und Fehlern (Bugs)";
            NewFunctionsBugs.FileType = @"help";
            NewFunctionsBugs.ExtensionCase = @"rtf";
            NewFunctionsBugs.Extensions = @"rtf";
            NewFunctionsBugs.LocalPath = LocalDirHelpFiles;
            NewFunctionsBugs.ServerPath = ServerDirHelpFiles;
            string[] infos_new_functions_bugs = new string[1];
            infos_new_functions_bugs[0] = @"Die Datei ....";
            NewFunctionsBugs.Informations = infos_new_functions_bugs;
            m_help_files[11] = NewFunctionsBugs;
            // End JazzHelp index 11

            // Start JazzHelp index 12
            JazzHelp AdminHelpFlyer = new JazzHelp();
            AdminHelpFlyer.FileName = GetFilenameAdminFlyer();
            AdminHelpFlyer.Description = @"Die Datei " + GetFilenameAdminFlyer() + @" enthält Hilfe für die Flyer Funktionen der JAZZ live AARAU Admin Applikation";
            AdminHelpFlyer.FileType = @"help";
            AdminHelpFlyer.ExtensionCase = @"rtf";
            AdminHelpFlyer.Extensions = @"rtf";
            AdminHelpFlyer.LocalPath = LocalDirHelpFiles;
            AdminHelpFlyer.ServerPath = ServerDirHelpFiles;
            string[] infos_admin_flyer = new string[1];
            infos_admin_flyer[0] = @"Die Datei ....";
            AdminHelpWebsite.Informations = infos_admin_flyer;
            m_help_files[12] = AdminHelpFlyer;
            // End JazzHelp index 12

            return true;
        } // Init



    } // HelpFiles

} // namespace
