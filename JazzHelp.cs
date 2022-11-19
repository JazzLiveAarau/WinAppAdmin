using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Holds data for a jazz help file
    /// <para></para>
    /// <para></para>
    /// <para>The key entity is the file name (FileName) like JazzProgramm.htm, i.e. the input data for a get function.</para>
    /// <para>This class correspond to the classes JazzXml.JazzDoc and JazzXml.JazzDocTemplate, which get their data from XML files.</para>
    /// <para>For help files there are no XML files. All data is hardcoded.</para>
    /// <para></para>
    /// </summary>
    public class JazzHelp
    {
        /// <summary>File name</summary>
        private string m_file_name = @"";
        /// <summary>Get and set file name</summary>
        public string FileName { get { return m_file_name; } set { m_file_name = value; } }

        /// <summary>File description</summary>
        private string m_file_description = @"";
        /// <summary>Get and set file name</summary>
        public string Description { get { return m_file_description; } set { m_file_description = value; } }

        /// <summary>File type: help</summary>
        private string m_file_type = @"";
        /// <summary>Get and set file type: help</summary>
        public string FileType { get { return m_file_type; } set { m_file_type = value; } }

        /// <summary>File extensions case: rtf</summary>
        private string m_case_extensions = @"";
        /// <summary>Get and set file extensions case: rtf</summary>
        public string ExtensionCase { get { return m_case_extensions; } set { m_case_extensions = value; } }

        /// <summary>File extensions like rtf</summary>
        private string m_file_extensions = @"";
        /// <summary>Get and set file extensions like rtf</summary>
        public string Extensions { get { return m_file_extensions; } set { m_file_extensions = value; } }

        /// <summary>Local file path for the output file</summary>
        private string m_file_local_path = @"";
        /// <summary>Get and set local file path for the output file</summary>
        public string LocalPath { get { return m_file_local_path; } set { m_file_local_path = value; } }

        /// <summary>Server file path for the output file</summary>
        private string m_file_server_path = @"";
        /// <summary>Get and set server file path for the output file</summary>
        public string ServerPath { get { return m_file_server_path; } set { m_file_server_path = value; } }

        /// <summary>File informations</summary>
        private string[] m_file_informations = null;
        /// <summary>Get and set server file informations that can be additional information or instructions </summary>
        public string[] Informations { get { return m_file_informations; } set { m_file_informations = value; } }
    } // JazzHelp

} // namespace
