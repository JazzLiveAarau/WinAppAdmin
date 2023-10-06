using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>The class HtmFiles defines all html files that can downloaded from or uploaded to the server
    /// <para>These files are defined as an array of JazzHtml objects.</para>
    /// <para>The handling of htm data is similar as for the jazz documents which are defined as JazzXml.JazzDoc and JazzXml.JazzDocTemplate objects.</para>
    /// <para>The JazzXml document objects get their data from XML files. The data for the JazzHtml objects are hardcoded in this application. </para>
    /// <para></para>
    /// <para></para>
    /// </summary>
    public static class HtmFiles
    {
        /// <summary>Array of all htm and js files that can be uploaded to or downloaded from the server</summary>
        static private JazzHtml[] m_html_files = null;
        /// <summary>Get and set the array of all htm and js files that can be uploaded to or downloaded from the server</summary>
        static public JazzHtml[] HtmlFiles { get { return m_html_files; } set { m_html_files = value; } }

        /// <summary>Get JazzHtml object with a given file name (FileName)</summary>
        static public JazzHtml GetHtml(string i_file_name, out string o_error)
        {
            JazzHtml ret_html = null;
            o_error = @"";

            JazzHtml[] html_files = HtmlFiles;
            if (null == html_files || html_files.Length == 0)
            {
                o_error = @"HtmFile.GetHtml HtmlFiles (m_html_files) is null or has no elements";

                return ret_html;
            }
            
            for (int index_htm=0; index_htm< html_files.Length; index_htm++)
            {
                JazzHtml current_html = html_files[index_htm];
                string current_file_name = current_html.FileName;

                if (current_file_name.Equals(i_file_name))
                {
                    return current_html;
                }
            }


            o_error = @"HtmFile.GetHtml There is no JazzHtml with FileName= " + i_file_name;

            return ret_html;

        } //GetHtml

        /// <summary>Defines the names of HTM files that can be uploaded and downloaded 
        /// <para></para>
        /// <para></para>
        /// </summary>
        static private string[] m_htm_file_names =
        {
            @"JazzBisher.htm", // 20231001 No longer used

        }; // m_htm_file_names

        /// <summary>Returns the filename for the jazz-concerts-up-to-now  file. The name is defined in the array HtmFiles.m_htm_file_names</summary>
        //QQ QQ20231001 static public string GetFilenameBisher() { return m_htm_file_names[0]; }

        /// <summary>Local directory for HTM files</summary>
        private static string m_local_dir_htm_files = @"HtmFiles";
        /// <summary>Local directory for HTM files</summary>
        public static string LocalDirHtmlFiles { get { return m_local_dir_htm_files; } }

        /// <summary>Server directory for www HTM files.</summary>
        private static string m_server_dir_www_htm_files = @"www";
        /// <summary>Server directory for www HTM files</summary>
        public static string ServerWwwDirHtmlFiles { get { return m_server_dir_www_htm_files; } }

        /*QQ20231001
        /// <summary>Returns the full file name for the local HTM file.</summary>
        private static string GetFullLocalHtmlFileName(string i_filename)
        {
            string ret_filename = @"";

            string local_address_directory = FileUtil.SubDirectory(LocalDirHtmlFiles, Main.m_exe_directory) + @"\";

            ret_filename = local_address_directory + i_filename;

            return ret_filename;
        } // GetFullLocalHtmlFileName

        
        /// <summary>Returns the full file name for the local jazz-concerts-up-to-now file HTM file</summary>
        public static string GetFullLocalHtmlFileNameForBisher()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetFilenameBisher());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForBisher
        

        /// <summary>Returns the full URL name for the jazz-concerts-up-to-now file HTM file</summary>
        public static string GetFullServerBisherHtmlFileName(string i_filename)
        {
            string ret_url = @"";

            ret_url = ServerWwwDirHtmlFiles + i_filename;

            return ret_url;
        } // GetFullServerBisherHtmlFileName
        QQ20231001*/

        /// <summary>Initialization of the array HtmlFiles (m_html_files)
        /// <para></para>
        /// <para></para>
        /// </summary>
        static public bool Init(out string o_error)
        {
            o_error = @"";

            // Number of elements
            m_html_files = new JazzHtml[1];
            
            // Start JazzHtml index 0
            JazzHtml BisherHtml = new JazzHtml();
            BisherHtml.FileName = "BisherNoLongerUsed.htm"; // QQ20231001 GetFilenameBisher();
            BisherHtml.Description = @"Die Datei BisherNoLongerUsed.htm " + @"zeigt alle vorherige Konzerte auf der Homepage";
            BisherHtml.FileType = @"web";
            BisherHtml.ExtensionCase = @"htm";
            BisherHtml.Extensions = @"htm";
            BisherHtml.LocalPath = LocalDirHtmlFiles;
            BisherHtml.ServerPath = ServerWwwDirHtmlFiles;
            string[] infos_bisher = new string[1];
            infos_bisher[0] = @"Die Datei BisherNoLongerUsed.htm " + @" soll mit Microsoft Word geändert werden";
            BisherHtml.Informations = infos_bisher;
            BisherHtml.TemplateFlag = false;
            BisherHtml.TemplateServerPath = @"";
            BisherHtml.FileNameForTemplate = @"";
            m_html_files[0] = BisherHtml;
            // End JazzHtml index 0

            /*C
            // Start JazzHtml index 1
            JazzHtml SeasonProgramHtml = new JazzHtml();
            SeasonProgramHtml.FileName = HtmVorlagen.GetSeasonProgramHtmFileName();
            SeasonProgramHtml.Description = @"Diese Datei zeigt das aktuelle Saisonprogramm auf der Homepage";
            SeasonProgramHtml.FileType = @"web";
            SeasonProgramHtml.ExtensionCase = @"htm";
            SeasonProgramHtml.Extensions = @"htm";
            SeasonProgramHtml.LocalPath = HtmVorlagen.LocalDirHtmlFiles;
            SeasonProgramHtml.ServerPath = HtmVorlagen.ServerWwwDirHtmlFiles;
            string[] infos_season_program = new string[2];
            infos_season_program[0] = @"... ";
            infos_season_program[1] = @"...";
            SeasonProgramHtml.Informations = infos_season_program;
            SeasonProgramHtml.TemplateFlag = false;
            SeasonProgramHtml.TemplateServerPath = @"";
            SeasonProgramHtml.FileNameForTemplate = @"";
            m_html_files[1] = SeasonProgramHtml;
            // End JazzHtml index 1
            QQ20231001 */

            /*TODO  Other FTP upload and download functions must be used 
            // Start JazzHtml index 2
            JazzHtml ScriptSeasonProgramHtml = new JazzHtml();
            ScriptSeasonProgramHtml.FileName = HtmVorlagen.GetFilenameScriptJazzProgram();
            ScriptSeasonProgramHtml.Description = @"JavaScript für " +  HtmVorlagen.GetSeasonProgramHtmFileName() + @", d.h. das Saisonprogramm auf der Homepage";
            ScriptSeasonProgramHtml.FileType = @"template";
            ScriptSeasonProgramHtml.ExtensionCase = @"js";
            ScriptSeasonProgramHtml.Extensions = @"js";
            ScriptSeasonProgramHtml.LocalPath = HtmVorlagen.LocalDirHtmlFiles;
            ScriptSeasonProgramHtml.ServerPath = HtmVorlagen.ServerTemplateDirHtmlFiles;
            string[] infos_season_script_program = new string[4];
            infos_season_script_program[0] = @"Diese Datei wird in Datei JazzProgramm_Aktuell_Naechste.js (im Server Ordner scripts) inkludiert";
            infos_season_script_program[1] = @"Datei JazzProgramm_Aktuell_Naechste.js enthält aktuelle Daten über Jazz Konzerte";
            infos_season_script_program[1] = @"Diese Konzertdaten kommen von XML Dateien die im Programm Admin definiert werden";
            infos_season_script_program[1] = @"Nach einer Änderung und Hinaufladen von " + HtmVorlagen.GetFilenameScriptJazzProgram() + " muss man die Website aktualisieren mit Programm Admin";
            ScriptSeasonProgramHtml.Informations = infos_season_script_program;
            ScriptSeasonProgramHtml.TemplateFlag = true;
            ScriptSeasonProgramHtml.TemplateServerPath = @"TODO Not really used or ...";
            ScriptSeasonProgramHtml.FileNameForTemplate = HtmVorlagen.GetSeasonProgramHtmFileName();
            m_html_files[2] = ScriptSeasonProgramHtml;
            // End JazzHtml index 2
            TODO */

            return true;
        } // Init

    } // HtmFiles

} // namespace
