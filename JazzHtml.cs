using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Holds data for a jazz html file
    /// <para>The html file may be a page for the website or a template file used for the creation of a web page.</para>
    /// <para>The object can also hold information about a JavaScript file used for the creation of web pages</para>
    /// <para>The key entity is the file name (FileName) like JazzProgramm.htm, i.e. the input data for a get function.</para>
    /// <para>This class correspond to the classes JazzXml.JazzDoc and JazzXml.JazzDocTemplate, which get their data from XML files.</para>
    /// <para>For html files there are no XML files. All data is hardcoded.</para>
    /// <para></para>
    /// </summary>
    public class JazzHtml
    {
        /// <summary>File name</summary>
        private string m_file_name = @"";
        /// <summary>Get and set file name</summary>
        public string FileName { get { return m_file_name; } set { m_file_name = value; } }

        /// <summary>File description</summary>
        private string m_file_description = @"";
        /// <summary>Get and set file name</summary>
        public string Description { get { return m_file_description; } set { m_file_description = value; } }

        /// <summary>File type: web</summary>
        private string m_file_type = @"";
        /// <summary>Get and set file type: web</summary>
        public string FileType { get { return m_file_type; } set { m_file_type = value; } }

        /// <summary>File extensions case: htm or js</summary>
        private string m_case_extensions = @"";
        /// <summary>Get and set file extensions case: htm or js</summary>
        public string ExtensionCase { get { return m_case_extensions; } set { m_case_extensions = value; } }

        /// <summary>File extensions like htm, html or js</summary>
        private string m_file_extensions = @"";
        /// <summary>Get and set file extensions like htm, html or js</summary>
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

        /// <summary>Template flag telling if the file is used for the creation of a web page</summary>
        private bool m_template_flag = false;
        /// <summary>Get and set the template flag telling if the file is used for the creation of a web page</summary>
        public bool TemplateFlag { get { return m_template_flag; } set { m_template_flag = value; } }

        /// <summary>Server path for this (input) template file. TODO Not really used. All tempaltes should be downloaded to local directory</summary>
        private string m_template_file_server_path = @"";
        /// <summary>Get and set the server path for this (input) template file</summary>
        public string TemplateServerPath { get { return m_template_file_server_path; } set { m_template_file_server_path = value; } }

        /// <summary>Name of the output html file that is using this file as a template</summary>
        private string m_file_name_for_template = @"";
        /// <summary>Get and set the name of the output html file that is using this file as a template</summary>
        public string FileNameForTemplate { get { return m_file_name_for_template; } set { m_file_name_for_template = value; } }


    } // JazzHtml

} // namespace
