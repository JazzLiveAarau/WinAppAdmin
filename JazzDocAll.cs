using JazzApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>The class holds all data for all jazz documents that are defined by XML files JazzDokumente.xml and JazzDokumente_20XX_20YY.xml
    /// <para>Most data are actually JazzXml data or data retrieved with JazzXml functions defined in file JazzXmlDoc.cs</para>
    /// <para>This function requires that JazzXml doc objects have been initialized. The constructor therefore calls JazzXml.InitDoc.</para>
    /// <para>It is also reqired that the JazzXml active doc object is set. This is done by other member functions, i.e. the functions</para>
    /// <para>JazzXml.SetActiveXmlObjectAndFileToThisSeason and JazzXml.SetActiveXmlObjectAndFileToNextSeason are called</para>
    /// <para></para>
    /// <para>The main class that uses JazzDocAll is the class DocAdmin. One member variable (m_jazz_doc_all) creates an instance of JazzDocAll</para>
    /// <para>Also the classes Website and Intranet member variables (m_jazz_doc_all_website and m_jazz_doc_all_flyer) instantiate JazzDocAll </para>
    /// <para></para>
    /// </summary>
    public class JazzDocAll
    {
        #region Names and paths for the XML files holding document data

        /// <summary>Server path to the XML document files</summary>
        public static string m_url_xml_doc_files_folder = "XML";

        /// <summary>Name of the XML documentation template file</summary>
        public static string m_templates_xml_filename = "JazzDokumente.xml";

        /// <summary>Start year for XML document files</summary>
        public static int m_documents_start_year = 2017;

        #endregion // Names and paths for the XML files holding document data

        /// <summary>Form where this class is used TODO Should not be here</summary>
        private DocAdminForm doc_admin_form = null;
        public DocAdminForm AdminForm { get { return doc_admin_form; } set { doc_admin_form = value; } }

        #region Member variables and their get functions

        /// <summary>Active season XML object corresponding to an XML file JazzDokumente_20XX_20YY.xml</summary>
        private XDocument m_active_season_xml_object = null;
        /// <summary>Returns the active season XML object corresponding to an XML file JazzDokumente_20XX_20YY.xml</summary>
        public XDocument ActiveSeasonXmlObject { get { return m_active_season_xml_object; } }

        /// <summary>Active season name</summary>
        private string m_active_season_name = @"";
        /// <summary>Returns the active season name</summary>
        public string ActiveSeasonName { get { return m_active_season_name; }}

        /// <summary>Active season start year as string</summary>
        private string m_active_season_start_year_str = @"";
        /// <summary>Returns the active season start year as string</summary>
        public string ActiveSeasonStartYearString { get { return m_active_season_start_year_str; } }

        /// <summary>Active season file name</summary>
        private string m_active_season_file_name = @"";
        /// <summary>Returns the active season file name</summary>
        public string ActiveSeasonFileName { get { return m_active_season_file_name; } }

        /// <summary>Season names</summary>
        private string[] m_season_names = null;
        /// <summary>Returns the season names</summary>
        public string[] SeasonNames { get { return m_season_names; } }

        /// <summary>Band names (concerts) of the active XML doc object corresponding to an XML file JazzDokumente_20XX_20YY.xml</summary>
        private string[] m_band_names = null;
        /// <summary>Returns the band names (concerts) of the active XML doc object corresponding to an XML file JazzDokumente_20XX_20YY.xml</summary>
        public string[] BandNames { get { return m_band_names; } }

        /// <summary>Active band name</summary>
        private string m_active_band_name = @"";
        /// <summary>Get and set the active band name</summary>
        public string ActiveBandName { get { return m_active_band_name; } set { m_active_band_name = value; } }

        /// <summary>Get the first band name in array BandNames</summary>
        public string FirstBandName { get{ if (null == m_band_names) return "Bandnames=null)"; return m_band_names[0]; } }

        /// <summary>All season documents of the active XML doc object corresponding to an XML file JazzDokumente_20XX_20YY.xml</summary>
        private JazzDoc[] m_all_season_documents = null;
        /// <summary>Returns all season documents of the active XML doc object corresponding to an XML file JazzDokumente_20XX_20YY.xml</summary>
        public JazzDoc[] AllSeasonDocuments { get { return m_all_season_documents; } }

        /// <summary>All concert documents for a given band name of the active XML doc object corresponding to an XML file JazzDokumente_20XX_20YY.xml</summary>
        private JazzDoc[] m_all_concert_documents = null;
        /// <summary>Returns all concert documents for a given band name of the active XML doc object corresponding to an XML file JazzDokumente_20XX_20YY.xml</summary>
        public JazzDoc[] AllConcertDocuments { get { return m_all_concert_documents; } }

        /// <summary>All document templates</summary>
        private JazzDocTemplate[] m_document_templates = null;
        /// <summary>Returns all concert documents</summary>
        public JazzDocTemplate[] AllDocumentTemplates { get { return m_document_templates; } }

        #endregion // Member variables and their get functions

        #region Set functions for member variables

        /// <summary>Set active season 
        /// <para>1. Set active document objects corresponding to JazzDokumente_20nn_20mm.xml. Call of JazzXml.SetActiveXmlObjectAndFile</para>
        /// <para>2. Set document member variables with data stemming from JazzDokumente_20nn_20mm.xml. Call of SetMemberVariables</para>
        /// <para>3. Set active band name to the first band. Call of SetActiveBandNameToFirstBand</para>
        /// <para>4. Set active season (JazzProgramm_20nn_20mm.xml). Call of AdminUtils.SetCurrentSeason</para>
        /// <para>Set of active season is necessary for the generation of the season program text file</para>
        /// </summary>
        /// <param name="i_season_name">Input season name</param>
        /// <param name="o_error">Error message</param>
        public bool SetActiveSeason(string i_season_name, out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            if (!JazzXml.SetActiveXmlObjectAndFile(i_season_name, out error_message))
            {
                o_error = @"JazzDocAll.SetActiveSeason JazzXml.SetActiveXmlObjectAndFile failed " + error_message;
                return false;
            }

            SetMemberVariables();

            if (!SetActiveBandNameToFirstBand(out error_message))
            {
                o_error = @"JazzDocAll.SetActiveSeason JazzXml.SetActiveBandNameToFirstBand failed " + error_message;
                return false;
            }

            JazzUtils.SetMemberLogin(true);
            if (!AdminUtils.SetCurrentSeason(i_season_name, out o_error))
            {
                o_error = @"JazzDocAll.SetActiveSeason AdminUtils.SetCurrentSeason failed " + o_error;
                return false;
            }

            return true;
        } // SetActiveSeason

        /// <summary>Set active season to the input season defined by the start year
        /// <para>Calls JazzXml.SetActiveXmlObjectAndFileToInputSeason, SetMemberVariables and SetActiveBandNameToFirstBand</para>
        /// </summary>
        /// <param name="i_season_start_year">Season start year</param>
        /// <param name="o_error">Error message</param>
        public bool SetActiveSeasonToInputSeason(int i_season_start_year, out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            if (!JazzXml.SetActiveXmlObjectAndFileToInputSeason(i_season_start_year, out error_message))
            {
                o_error = @"JazzDocAll.SetActiveSeasonToInputSeason JazzXml.SetActiveXmlObjectAndFileToInputSeason failed " + error_message;
                return false;
            }

            SetMemberVariables();

            if (!SetActiveBandNameToFirstBand(out error_message))
            {
                o_error = @"JazzDocAll.SetActiveSeasonToInputSeason JazzXml.SetActiveBandNameToFirstBand failed " + error_message;
                return false;
            }

            return true;

        } // SetActiveSeasonToInputSeason

        /// <summary>Set active season to this (the current) season 
        /// <para>Calls JazzXml.SetActiveXmlObjectAndFileToThisSeason, SetMemberVariables and SetActiveBandNameToFirstBand</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public bool SetActiveSeasonToThisSeason(out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            if (!JazzXml.SetActiveXmlObjectAndFileToThisSeason(out error_message))
            {
                o_error = @"JazzDocAll.SetActiveSeason JazzXml.SetActiveXmlObjectAndFileToThisSeason failed " + error_message;
                return false;
            }

            SetMemberVariables();

            if (!SetActiveBandNameToFirstBand(out error_message))
            {
                o_error = @"JazzDocAll.SetActiveSeason JazzXml.SetActiveBandNameToFirstBand failed " + error_message;
                return false;
            }

            return true;

        } // SetActiveSeasonToThisSeason

        /// <summary>Set active season to the next season
        /// <para>Calls JazzXml.SetActiveXmlObjectAndFileToNextSeason, SetMemberVariables and SetActiveBandNameToFirstBand</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public bool SetActiveSeasonToNextSeason(out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            if (!JazzXml.SetActiveXmlObjectAndFileToNextSeason(out error_message))
            {
                o_error = @"JazzDocAll.SetActiveSeason JazzXml.SetActiveXmlObjectAndFileToNextSeason failed " + error_message;
                return false;
            }

            SetMemberVariables();

            if (!SetActiveBandNameToFirstBand(out error_message))
            {
                o_error = @"JazzDocAll.SetActiveSeason JazzXml.SetActiveBandNameToFirstBand failed " + error_message;
                return false;
            }

            return true;

        } // SetActiveSeasonToNextSeason

        /// <summary>Set document member variables for data from JazzDokumente_20nn_20mm.xml
        /// <para>1. Call of SetActiveSeasonXmlObject</para>
        /// <para>2. Call of SetActiveSeasonName</para>
        /// <para>3. Call of SetActiveSeasonFileName</para>
        /// <para>4. Call of SetSeasonNames</para>
        /// <para>5. Call of SetBandNames</para>
        /// <para>6. Call of SetAllSeasonDocuments</para>
        /// <para>7. Call of SetAllConcertDocuments</para>
        /// <para>8. Call of SetAllDocumentTemplates</para>
        /// <para></para>
        /// </summary>
        public void SetMemberVariables()
        {
            SetActiveSeasonXmlObject();

            SetActiveSeasonName();

            SetActiveSeasonStartYearString();

            SetActiveSeasonFileName();

            SetSeasonNames();

            string error_message = @"";
            SetBandNames(out error_message);

            SetAllSeasonDocuments(out error_message);

            //QQQ Is set by SetActiveBandnameForFirst.. SetAllConcertDocumentsForActiveBandName(out error_message);

            SetAllDocumentTemplates(out error_message);

        } // SetMemberVariables

        /// <summary>Sets the active season XML object corresponding to an XML file JazzDokumente_20XX_20YY.xml
        /// <para>The function calls JazzXml.GetObjectActiveDoc</para>
        /// <para>Please note that the original (master) is the JazzXml parameter. This is just a copy!</para>
        /// </summary>
        private void SetActiveSeasonXmlObject() { m_active_season_xml_object = JazzXml.GetObjectActiveDoc(); }

        /// <summary>Sets the active season name
        /// <para>The function calls JazzXml.GetSeasonNameActiveObject </para>
        /// <para>Please note that the original (master) is the JazzXml parameter. This is just a copy!</para>
        /// </summary>
        private void SetActiveSeasonName() { m_active_season_name = JazzXml.GetSeasonNameActiveObject(); }

        /// <summary>Sets the active season start year as string
        /// <para>The function calls JazzXml.GetYearAutum </para>
        /// <para>Please note that the original (master) is the JazzXml parameter. This is just a copy!</para>
        /// </summary>
        private void SetActiveSeasonStartYearString() 
        {
            string doc_season_years = JazzXml.GetDocSeasonYears();

            m_active_season_start_year_str = doc_season_years.Substring(0, 4); 
        }

        /// <summary>Sets the active season file name
        /// <para>The function calls JazzXml.GetFileNameActiveObject </para>
        /// <para>Please note that the original (master) is the JazzXml parameter. This is just a copy!</para>
        /// </summary>
        private void SetActiveSeasonFileName() { m_active_season_file_name = JazzXml.GetFileNameActiveObject(); }

        /// <summary>Sets the season names
        /// <para>The function calls JazzXml.GetSeasonNamesAllDocs</para>
        /// <para>Please note that the original (master) is the JazzXml function that returns the season names. Like a copy!</para>
        /// </summary>
        private void SetSeasonNames() { m_season_names = JazzXml.GetSeasonNamesAllDocs(); }

        /// <summary>Set band names retrieved from the active doc XML object corresponding to an XML file JazzDokumente_20XX_20YY.xml
        /// <para>Call of JazzXml.GetDocBandNames (and of JazzXml.GetNumberDocConcerts for program check)</para>
        /// <para>Please note that the original (master) is the JazzXml function that returns the band names. Like a copy!</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        private bool SetBandNames(out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            int n_concerts = JazzXml.GetNumberDocConcerts(out error_message);
            if (n_concerts < 0)
            {
                o_error = @"JazzDocAll.SetBandNames " + error_message;
                return false;
            }

            m_band_names = JazzXml.GetDocBandNames();
            if (m_band_names == null || m_band_names.Length != n_concerts)
            {
                o_error = @"JazzDocAll.SetBandNames Programming error: m_band_names is null or number of elements not equal to the number of bands";
                return false;
            }

            //QQQ ActiveBandName = m_band_names[0];

            return true;

        } // SetBandNames

        /// <summary>Sets the active band name to the first band in array m_band_names
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        private bool SetActiveBandNameToFirstBand(out string o_error)
        {
            o_error = @"";

            if (null == m_band_names || m_band_names.Length == 0)
            {
                o_error = @"JazzDocAll.SetActiveBandNameToFirstBand m_band_names is null or have no elements";
                return false;
            }

            ActiveBandName = m_band_names[0];

            if (!SetAllConcertDocumentsForActiveBandName(out o_error))
            {
                o_error = @"JazzDocAll.SetActiveBandNameToFirstBand SetAllConcertDocumentsForActiveBandName failed " + o_error;
                return false;
            }

            return true;
        } // SetActiveBandNameToFirstBand

        /// <summary>Set all season documents for the current season 
        /// <para>Current season means the active doc XML object corresponding to an XML file JazzDokumente_20XX_20YY.xml</para>
        /// <para>Season documents are for instance the season program and the season letter</para>
        /// <para>Data is retrieved from the XML object created with the XML file JazzDokumente_20xx_20yy.xml. Function JazzXml.GetAllSeasonDocumentsAsArray is called</para>
        /// <para></para>
        /// <para>Data is saved in the JazzDoc array m_all_season_documents</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        public bool SetAllSeasonDocuments(out string o_error)
        {
            o_error = @"";

            m_all_season_documents = JazzXml.GetAllSeasonDocumentsAsArray();

            if (null == m_all_season_documents || m_all_season_documents.Length == 0)
            {
                o_error = @"JazzDocAll.SetAllSeasonDocuments Programming error: Returned array from JazzXml.GetAllSeasonDocuments is null or has no elements";
                return false;
            }

            return true;

        } // SetAllSeasonDocuments


        /// <summary>Set all concert documents for the current season and for the active concert band name (ActiveBandName)
        /// <para>Data is retrieved from the XML object created with the XML file JazzDokumente_20xx_20yy.xml</para>
        /// <para>The function JazzXml.GetAllConcertDocumentsAsArrayBandName(band name) is called</para>
        /// <para>This JazzXml function gets the data from the current (active) season XML object (created with JazzDokumente_20xx_20yy.xml) </para>
        /// <para>Data is saved in the JazzDoc array m_all_concert_documents</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        public bool SetAllConcertDocumentsForActiveBandName(out string o_error)
        {
            o_error = @"";

            m_all_concert_documents = JazzXml.GetAllConcertDocumentsAsArrayBandName(ActiveBandName, out o_error);
            if (null == m_all_concert_documents || m_all_concert_documents.Length == 0)
            {
                o_error = @"JazzDocAll.SetAllConcertDocumentsForActiveBandName Returned array from JazzXml.GetAllConcertDocumentsAsArrayBandName is null or has no elements " + o_error;
                return false;
            }

            return true;

        } // SetAllConcertDocumentsForActiveBandName

        /// <summary>Set all document templates from the XML file on the server and set m_document_templates
        /// <para>Call of function JazzXml.GetAllDocTemplates</para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        private bool SetAllDocumentTemplates(out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            m_document_templates = JazzXml.GetAllDocTemplates(out error_message);

            if (null == m_document_templates)
            {
                error_message = @"DocAdmin.SetAllDocumentTemplates Programming error: " + error_message;
                return false;
            }

            return true;

        } // SetAllDocumentTemplates

        #endregion // Set functions for member variables

        #region Constructor

        /// <summary>Constructor 
        /// <para>Initialization of the JazzXml document arrays. Call of JazzDocAll.InitXmlDocumentArrays.</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        public JazzDocAll()
        {
            string error_message = @"";

            if (!InitXmlDocumentArrays(m_url_xml_doc_files_folder, m_templates_xml_filename, m_documents_start_year, out error_message))
                return;

        } // Constructor

        /// <summary>Initialization of the JazzXml document arrays 
        /// <para>This initialization is made by function JazzXml.InitDoc. Please refer to this function for a detailed description</para>
        /// <para></para>
        /// <para>This function must also be called if a new XML season file (JazzDokumente_20xx_20yyy.xml) has been added.</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_url_xml_doc_files_folder">Server path to the XML document files<</param>
        /// <param name="i_templates_xml_filename">Name of the XML documentation template file</param>
        /// <param name="i_documents_start_year">Start year for XML document files</param>
        /// <param name="o_error">Error message</param>
        private bool InitXmlDocumentArrays(string i_url_xml_doc_files_folder, string i_templates_xml_filename, int i_documents_start_year, out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            if (!JazzXml.InitDoc(i_url_xml_doc_files_folder, i_templates_xml_filename, i_documents_start_year, out error_message))
            {
                o_error = @"JazzDocAll.InitXmlDocumentArrays JazzXml.InitDoc failed: " + error_message;
                return false;
            }

            return true;

        } // InitXmlDocumentArrays

        #endregion // Constructor

        #region Reload before checkout

        /// <summary>Reload XML data and set member variables before checkout
        /// <para>The user has already set active doc season and active band name, i.e. has opened DocAdminForm.</para>
        /// <para>The user may also have opened a subdialog to DocAdminForm like for instance DocDocPdfImgForm</para>
        /// <para></para>
        /// <para>Use case: User one looks at data in Admin. In the meantime user two makes a checkout, makes changes and and saves the result (uploads to the server)</para>
        /// <para>User one wants to make changes, i.e. make a checkout. The XML objects must for this case be updated with the changes from user two</para>
        /// <para></para>
        /// <para>1. Call of JazzXml.InitDoc</para>
        /// <para>2. Call of SetAllSeasonDocuments</para>
        /// <para>3. Call of SetAllConcertDocuments</para>
        /// </summary>
        /// <param name="o_error">Error message</param>
        public bool ReloadXmlSetMembersBeforeCheckout(out string o_error)
        {
            o_error = @"";

            DebugFlag = false;

            DebugWriteState(@"DebugDocAllStateBeforeReload.txt");

            string input_active_band_name = ActiveBandName;

            if (ActiveSeasonXmlObject == null)
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout ActiveSeasonXmlObject is null";
                return false;
            }

            if (ActiveSeasonName.Length == 0)
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout ActiveSeasonName is not set";
                return false;
            }

            if (ActiveSeasonFileName.Length == 0)
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout ActiveSeasonFileName is not set";
                return false;
            }

            if (ActiveBandName.Length == 0)
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout ActiveBandName is not set";
                return false;
            }

            if (SeasonNames == null || SeasonNames.Length == 0)
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout SeasonNames is null or number of elements zero";
                return false;
            }

            if (BandNames == null || BandNames.Length == 0)
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout BandNames is null or number of elements zero";
                return false;
            }

            if (!JazzXml.InitDoc(m_url_xml_doc_files_folder, m_templates_xml_filename, m_documents_start_year, out o_error))
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout JazzXml.InitDoc failed: " + o_error;
                return false;
            }

            // New XML objects have been created. The active XML object must be set to the new XML object
            if (!JazzXml.SetActiveXmlObjectAndFile(ActiveSeasonName, out o_error))
            {
                o_error = @"ReloadXmlSetMembersBeforeCheckout.SetActiveSeason JazzXml.SetActiveXmlObjectAndFile failed " + o_error;
                return false;
            }

            SetActiveSeasonXmlObject(); // New XML object "copy"

            SetActiveSeasonName(); // Should be the same

            SetActiveSeasonStartYearString();

            SetActiveSeasonFileName(); // Should be the same

            SetSeasonNames(); // Should be the same

            if (!SetBandNames(out o_error))
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout SetBandNames failed: " + o_error;
                return false;
            }

            if (!SetAllSeasonDocuments(out o_error))
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout SetAllSeasonDocuments failed: " + o_error;
                return false;
            }

            if (!SetAllConcertDocumentsForActiveBandName(out o_error))
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout SetAllConcertDocuments failed: " + o_error;
                return false;
            }

            string output_active_band_name = ActiveBandName;
            if (!input_active_band_name.Equals(output_active_band_name))
            {
                o_error = @"JazzDocAll.ReloadXmlSetMembersBeforeCheckout output_active_band_name= " + output_active_band_name + @" != output_active_band_name= " + output_active_band_name;
                return false;
            }
            
            DebugWriteState(@"DebugDocAllStateAfterReload.txt");

            return true;

        } // ReloadXmlSetMembersBeforeCheckout

        #endregion // Reload before checkout

        #region Get JazzDoc and JazzDocTemplate functions

        /// <summary>Get the element from array m_all_season_documents that corresponds to the input template name</summary>
        public JazzDoc GetDocSeason(string i_template_name, out string o_error)
        {
            o_error = @"";
            JazzDoc ret_doc_object = null;

            if (null == m_all_season_documents || m_all_season_documents.Length == 0)
            {
                o_error = @"JazzDocAll.GetDocSeason Programming error: m_all_season_documents is null or has no elements";
                return ret_doc_object;
            }

            if (i_template_name.Length == 0)
            {
                o_error = @"JazzDocAll.GetDocSeason Programming error: Input template name is not set";
                return ret_doc_object;
            }

            for (int index_doc = 0; index_doc < m_all_season_documents.Length; index_doc++)
            {
                JazzDoc current_doc_object = m_all_season_documents[index_doc];

                if (current_doc_object.TemplateName.Equals(i_template_name))
                {
                    ret_doc_object = current_doc_object;
                    break;
                }
            }

            if (null == ret_doc_object)
            {
                o_error = @"JazzDocAll.GetDocSeason Programming error: There is no element with TemplateName= " + i_template_name;
            }

            return ret_doc_object;

        } // GetDocSeason

        /// <summary>Get the JazzDoc element from array m_all_concert_documents for the input template name</summary>
        public JazzDoc GetDocConcert(string i_template_name, out string o_error)
        {
            o_error = @"";
            JazzDoc ret_doc = null;

            JazzDoc[] all_concert_documents = AllConcertDocuments;

            if (null == AllConcertDocuments || AllConcertDocuments.Length == 0)
            {
                o_error = @"JazzDocAll.GetDocConcert Programming error: AllConcertDocuments null or has no elements";
                return ret_doc;
            }

            for (int index_doc = 0; index_doc < AllConcertDocuments.Length; index_doc++)
            {
                JazzDoc current_doc = AllConcertDocuments[index_doc];

                if (current_doc.TemplateName.Equals(i_template_name))
                {
                    ret_doc = current_doc;
                    break;
                }
            }

            if (null == ret_doc)
            {
                o_error = @"JazzDocAll.GetDocConcert Programming error: There is no element with TemplateName= " + i_template_name;
            }

            return ret_doc;

        } // GetDocConcert

        /// <summary>Get document template for a given template name</summary>
        public JazzDocTemplate GetDocumentTemplate(string i_template_name, out string o_error)
        {
            o_error = @"";
            JazzDocTemplate ret_template = null;

            if (null == m_document_templates)
            {
                o_error = @"JazzDocAll.GetDocumentTemplate Programming error: m_document_templates = null";
                return ret_template;
            }

            for (int index_template = 0; index_template < m_document_templates.Length; index_template++)
            {
                JazzDocTemplate current_template = m_document_templates[index_template];

                if (i_template_name.Equals(current_template.TemplateName))
                {
                    ret_template = current_template;
                    break;
                }
            }

            if (null == ret_template)
            {
                o_error = @"JazzDocAll.GetDocumentTemplate No template with the name " + i_template_name;
                return ret_template;
            }

            return ret_template;
        } // GetDocumentTemplate

        /// <summary>Get document template name for a given document template description</summary>
        public string GetDocumentTemplateName(string i_template_description)
        {
            string ret_template_name = @"";

            int n_all_templates = m_document_templates.Length;

            for (int index_template = 0; index_template < n_all_templates; index_template++)
            {
                JazzDocTemplate current_template = m_document_templates[index_template];
                if (current_template.TemplateDescription.Equals(i_template_description))
                {
                    return current_template.TemplateName;
                }
            }

            return ret_template_name;

        } // GetDocumentTemplateName

        #endregion // Get JazzDoc and JazzDocTemplate functions

        #region Add season document XML file (JazzDokumente_20xx_20yy.xml)

        /// <summary>Add season document XML file (JazzDokumente_20xx_20yy.xml)
        /// <para>1. A copy of the XML object for the last season is created and the the XML filed is created in the local XML directory</para>
        /// <para>2. Season years are retrieved from the last season and start year for the new system is determined from this string</para>
        /// <para>3. Upload the XML file to the server XML directory. Call of UpLoad.UploadOneFile</para>
        /// <para>4. Initialize XML documents. Call of JazzXml.InitDoc. This function finds the newly created XML file on the server.</para>
        /// <para>5. Set the newly created XML object as the active object. Call of JazzXml.GetObjectAllDocs() and SetActiveXmlDocAndFileName</para>
        /// <para>6. Modify the season and concert objects (JazzDoc)</para>
        /// <para></para>
        /// <para>Please note that the new file JazzDokumente_20xx_20yy.xml will be uploaded by the Checkin function (and not by this function)</para>
        /// <para></para>
        /// <para>Refer also to Index.AddSeasonProgram, Index.SetCurrentSeason and Index.AddSeason which add a season concert XML file.</para>
        /// </summary>
        ///  <param name="o_season_name">Season name that has been added</param>
        ///  <param name="o_user_cancelled">Flag telling if the user cancelled the creation of the new XML file JazzKonzerte_20xx_20yy.xml</param>
        /// <param name="o_error">Error message.</param>
        public bool AddSeasonDocumentsXML(out string o_season_name, out bool o_user_cancelled, out string o_error)
        {

            #region Initialization

            o_season_name = @"";
            o_error = @"";
            o_user_cancelled = false;

            XDocument[] all_document_objects = JazzXml.GetObjectAllDocs();
            if (null == all_document_objects)
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML Programming error:  JazzXml.GetObjectAllDocs failed";
                return false;
            }

            int index_last_season = all_document_objects.Length - 1;
            if (index_last_season < 0)
            {
                o_error = @"JazzDocAll.AddSeasonProgram Programming error: index negative";
                return false;
            }

            string season_name = GetSeasonNameForLastObject(index_last_season, out o_error);
            if (season_name.Length == 0)
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML GetSeasonNameForLastObject (1) failed " + o_error;
                return false;
            }

            if (!SetActiveSeason(season_name, out o_error))
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML SetActiveSeason (1) failed " + o_error;
                return false;
            }

            int autumn_year = GetStartYear(out o_error);
            if (autumn_year < 0)
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML GetStartYear failed " + o_error;
                return false;
            }

            int autumn_year_add = autumn_year + 1;

            #endregion // Initialization

            #region Get band names and dates (from JazzProgram_20xx_20yy.xml) for the season that shall be added

            string[] band_names_next = null;
            string[] concert_dates = null;
            if (!GetBandNamesAndDates(autumn_year_add, out band_names_next, out concert_dates, out o_error))
            {
                o_error = "JazzDocAll.AddSeasonDocumentsXML GetBandNamesAndDates failed: " + o_error;
                return false;
            }

            #endregion // Get band names and dates (from JazzProgram_20xx_20yy.xml) for the season that shall be added

            #region Create new XML local file for the next season (a copy of the latest JazzDokumente_20xx_20yy.xml)

            XDocument xml_object_add = new XDocument(all_document_objects[index_last_season]);

            string server_full_file_name = JazzXml.GetSeasonDocumentsFileName(autumn_year_add, "XML");
            string local_file_name = System.IO.Path.GetFileName(server_full_file_name);
            string server_relative_address = @"www\" + JazzAppAdminSettings.Default.XmlExistingDir + @"\" + local_file_name;
            string local_address_directory = FileUtil.SubDirectory(JazzAppAdminSettings.Default.XmlExistingDir, Main.m_exe_directory) + @"\";
            string full_local_file_name = local_address_directory + local_file_name;

            xml_object_add.Save(full_local_file_name);

            #endregion // Create new XML local file for the next season (a copy of the latest JazzDokumente_20xx_20yy.xml)

            #region Get the concert directory names from the user

            string[] o_dir_names = null;
            if (!GetConcertDirectoryNamesFromUser(band_names_next, concert_dates, out o_dir_names, out o_user_cancelled, out o_error))
            {
                o_error = "JazzDocAll.AddSeasonDocumentsXML GetConcertDirectoryNamesFromUser failed: " + o_error;
                return false;
            }

            if (o_user_cancelled)
            {
                return true;
            }


            #endregion // Get the concert directory names from the user

            #region Create the new concert directories on the server


            if (!CreateConcertDirectories(o_dir_names, out o_error))
            {
                o_error = " JazzDocAll.AddSeasonDocumentsXML CreateConcertDirectories failed: " + o_error;
                return false;
            }

            #endregion // Create the new concert directories on the server

            #region Modify the copied XML with new band names (from JazzProgram_20xx_20yy.xml)

            string[] band_names = BandNames;

            string file_as_string = @"";
            if (!FileUtil.FileToString(full_local_file_name, out file_as_string, out o_error))
            {
                o_error = "JazzDocAll.AddSeasonDocumentsXML FileUtil.FileToString failed: " + o_error;
                return false;
            }

            if (band_names.Length != band_names_next.Length)
            {
                o_error = "JazzDocAll.AddSeasonDocumentsXMLband_names.Length != band_names_next.Length";
                return false;
            }

            for (int index_band_name=0; index_band_name< band_names_next.Length; index_band_name++)
            {
                string find_string = band_names[index_band_name];
                string replace_string = band_names_next[index_band_name];

                if (!FileUtil.ReplaceBandNameInFileString(ref file_as_string, index_band_name + 1, replace_string, out o_error))
                {
                    o_error = "JazzDocAll.AddSeasonDocumentsXML FileUtil.ReplaceTextInFileString failed: " + o_error;
                    return false;
                }
            }

            // This change should be done below in XDocument object. TODO
            string season_years = autumn_year_add.ToString() + @"-" + (autumn_year_add + 1).ToString();
            if (!FileUtil.ReplaceSeasonYearsInFileString(ref file_as_string, season_years, out o_error))
            {
                o_error = "JazzDocAll.AddSeasonDocumentsXML FileUtil.ReplaceSeasonYearsInFileString failed: " + o_error;
                return false;
            }

            if (!FileUtil.StringToFile(full_local_file_name, file_as_string, out  o_error))
            {
                o_error = "JazzDocAll.AddSeasonDocumentsXML FileUtil.StringToFile failed: " + o_error;
                return false;
            }

            #endregion // Modify the copied XML with new band names (from JazzProgram_20xx_20yy.xml)

            #region Upload the new season documents file (JazzDokumente_20xx_20yy.xml) to the server

            UpLoad htpp_upload = new UpLoad();

            bool to_www = true;
            if (!htpp_upload.OneFile(to_www, server_relative_address, full_local_file_name, out o_error))
            {
                o_error = "JazzDocAll.AddSeasonDocumentsXML Upload.OneFile failed: " + o_error;
                return false;
            }

            #endregion // Upload the new season documents file (JazzDokumente_20xx_20yy.xml) to the server

            #region Make the new season documents file (JazzProgram_20xx_20yy.xml) to the active object

            if (!InitXmlDocumentArrays(m_url_xml_doc_files_folder, m_templates_xml_filename, m_documents_start_year, out o_error))
            {
                o_error = "JazzDocAll.AddSeasonDocumentsXML InitXmlDocumentArrays.OneFile failed: " + o_error;
                return false;
            }

            all_document_objects = JazzXml.GetObjectAllDocs();
            if (null == all_document_objects)
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML Programming error:  JazzXml.GetObjectAllDocs (2) failed";
                return false;
            }

            int index_season = all_document_objects.Length - 1;
            if (index_season != index_last_season + 1)
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML Programming error:  Failure adding XML file/object. ";
                return false;
            }

            string next_season_name = GetSeasonNameForLastObject(index_season, out o_error);
            if (next_season_name.Length == 0)
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML GetSeasonNameForLastObject (2) failed " + o_error;
                return false;
            }

            if (!SetActiveSeason(next_season_name, out o_error))
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML SetActiveSeason (2) failed " + o_error;
                return false;
            }

            o_season_name = next_season_name;

            #endregion // Make the new season documents file (JazzProgram_20xx_20yy.xml) to the active object

            #region Modify the season and concert objects (JazzDoc). Remove file names, set published to false, etc

            if (!InitAddedSeasonXmlObject(o_dir_names, out o_error))
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML InitAddedSeasonXmlObject failed " + o_error;
                return false;
            }

            #endregion Modify the season and concert objects (JazzDoc). Remove file names, set published to false, etc
           
            return true;

        } // AddSeasonDocumentsXML


        /// <summary>Create new concert directories
        /// <para>1. </para>
        /// <para></para>
        /// </summary>
        /// <param name="i_dir_names">Names of concert directories defined by the user</param>
        /// <param name="o_error">Error message.</param>
        private bool CreateConcertDirectories(string[] i_dir_names, out string o_error)
        {
            o_error = @"";

            if (null == i_dir_names)
            {
                o_error = @" JazzDocAll.CreateConcertDirectories i_dir_names is null";
                return false;
            }

            string documents_path = JazzXml.GetDocDocumentsPath();

            string server_path_start = @"/www/" + documents_path + @"/";

            UpLoad upload = new UpLoad();
            bool to_www = true;

            for (int index_dir=0; index_dir< i_dir_names.Length; index_dir++)
            {
                string server_dir_name = server_path_start + i_dir_names[index_dir] + @"/";

                // TODO Check if directory already exists (should not be the case ...) Failure 

                if (!upload.CreateServerDirectory(to_www, server_dir_name, out o_error))
                {
                    o_error = "JazzDocAll.CreateConcertDirectories UpLoad.CreateServerDirectory failed " + o_error;

                    return false;
                }

            } // index_dir


            return true;

        } // CreateConcertDirectories

        #endregion // Add season document XML file (JazzDokumente_20xx_20yy.xml)

        #region Get band names and dates (from JazzProgram_20xx_20yy.xml) for the season that shall be added

        /// <summary>Get directory names from the user
        /// <para>1. Construct proposal names. Call of ConstructProposalDirectoryNames.</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_band_names">Band names</param>
        /// <param name="i_dates">Dates dyyymmdd</param>
        /// <param name="o_dir_names">Names of concert directories defined by the user</param>
        /// <param name="o_user_cancelled">Flag telling if the user cancelled the creation of a new concert documents XML</param>
        /// <param name="o_error">Error message.</param>
        private bool GetConcertDirectoryNamesFromUser(string[] i_band_names, string[] i_dates, out string[] o_dir_names, out bool o_user_cancelled, out string o_error)
        {
            o_error = @"";
            o_dir_names = null;
            o_user_cancelled = false;

            string[] proposal_dir_names = null;
            if (!ConstructProposalDirectoryNames(i_band_names, i_dates, out proposal_dir_names, out o_error))
            {
                o_error = @"JazzDocAll.GetConcertDirectoryNamesFromUser ConstructProposalDirectoryNames failed " + o_error;
                return false;
            }

            if (null == AdminForm)
            {
                o_error = @"JazzDocAll.GetConcertDirectoryNamesFromUser Pointer to form owner (AdminForm) is null ";
                return false;
            }

            DocDirNames doc_dir_names = new DocDirNames();
            doc_dir_names.DocAll = this;
            doc_dir_names.ProposalDirNames = proposal_dir_names;
            doc_dir_names.UserDirNames = proposal_dir_names;

            DocDirNamesForm htm_form = new DocDirNamesForm(ref doc_dir_names);
            htm_form.Owner = AdminForm;
            htm_form.ShowDialog();

            o_dir_names = doc_dir_names.UserDirNames;

            if (doc_dir_names.UserCancelled)
            {
                o_error = @"JazzDocAll.GetConcertDirectoryNamesFromUser User cancelled defining the concert document directory names";
                o_user_cancelled = true;
                return true;
            }

            return true;

        } // GetConcertDirectoryNamesFromUser

        /// <summary>Construct directory names from dates and modified band names
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        private bool ConstructProposalDirectoryNames(string[] i_band_names, string[] i_dates, out string[] o_proposal_dir_names, out string o_error)
        {
            o_error = @"";
            o_proposal_dir_names = null;

            if (null == i_band_names || null == i_dates)
            {
                o_error = @"JazzDocAll.ConstructProposalDirectoryNames i_band_names and/or i_dates null";
                return false;
            }

            int number_of_concerts = i_band_names.Length;
            if (number_of_concerts != i_dates.Length)
            {
                o_error = @"JazzDocAll.ConstructProposalDirectoryNames i_band_names.Length != i_dates.Length";
                return false;
            }

            string[] proposal_dir_names = new string[number_of_concerts];

            for (int index_concert = 0; index_concert < number_of_concerts; index_concert++)
            {
                string current_dir = i_dates[index_concert] + "_";
                string band_name = i_band_names[index_concert];

                string mod_band_name = ModifyBandNameForDirectory(band_name);

                current_dir = current_dir + mod_band_name;

                proposal_dir_names[index_concert] = current_dir;
            }

            o_proposal_dir_names = proposal_dir_names;

            return true;

        } // ConstructProposalDirectoryNames

        /// <summary>Modifies names for band directories
        /// <para>Function ModifyBandNameForDirectory is called for every input band name.</para>
        /// <para></para>
        /// </summary>
        /// <param name="io_band_dir_names">Input and output directory names</param>
        /// <param name="o_name_was_changed">Flag telling if any name was changed</param>
        public void ModifyNamesForBandDirectories(ref string[] io_band_dir_names, out bool o_name_was_changed)
        {
            o_name_was_changed = false;

            if (null == io_band_dir_names)
                return;

            for (int index_dir_name=0; index_dir_name< io_band_dir_names.Length; index_dir_name++)
            {
                string input_name = io_band_dir_names[index_dir_name];
                string output_name = ModifyBandNameForDirectory(input_name);

                if (!input_name.Equals(output_name))
                {
                    o_name_was_changed = true;
                }

                io_band_dir_names[index_dir_name] = output_name;
            }
            
        } // ModifyNamesForBandDirectories

        /// <summary>Modifies the band name
        /// <para>Escape signs, é, etc are removed. Spaces are replaced by underscore.</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        public string ModifyBandNameForDirectory(string i_band_name)
        {
            return AdminUtils.ModifyBandNameForDirectory(i_band_name);

        } // ModifyBandNameForDirectory

        #endregion // Get band names and dates (from JazzProgram_20xx_20yy.xml) for the season that shall be added

        #region Utility functions

        /// <summary>Gets the start year from season years in the current jazz document  (JazzDokumente_20xx_20yy.xml)
        /// <para>1. Get season years. Call of JazzXml.GetDocSeasonYears</para>
        /// <para>2. Get first four characters</para>
        /// <para>3. Convert with Int32.Parse</para>
        /// </summary>
        /// <param name="o_error">Error message.</param>
        private int GetStartYear(out string o_error)
        {
            int ret_start_year = -12345;
            o_error = @"";

            string season_years = JazzXml.GetDocSeasonYears();
            string start_year_str = season_years.Substring(0, 4);
            try
            {
                ret_start_year = Int32.Parse(start_year_str);
            }
            catch (FormatException e)
            {
                o_error = @"JazzDocAll.GetStartYear Int32.Parse failed " + e.ToString();
                return -1;
            }

            return ret_start_year;
        } // GetStartYear

        /// <summary>Initialize the added season XML object corresponding to the added XML file (JazzDokumente_20xx_20yy.xml)
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_dir_names">Concert directory names</param>
        /// <param name="o_error">Error message.</param>
        private bool InitAddedSeasonXmlObject(string[] i_dir_names, out string o_error)
        {
            o_error = @"";

            JazzDoc[] all_jazz_season_docs = AllSeasonDocuments;
            if (null == all_jazz_season_docs)
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML AllSeasonDocuments is null ";
                return false;
            }

            for (int index_season=0; index_season< all_jazz_season_docs.Length; index_season++)
            {
                JazzDoc current_season_doc = all_jazz_season_docs[index_season];

                SetInitValues(current_season_doc);

                if (!WriteDoc(current_season_doc, "season", out o_error))
                {
                    o_error = @"JazzDocAll.AddSeasonDocumentsXML WriteDoc season failed " + o_error;
                    return false;
                }
            }

            string[] band_names = BandNames;
            if (null == band_names)
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML BandNames is null ";
                return false;
            }

            int n_concerts = band_names.Length;
            if (n_concerts == 0)
            {
                o_error = @"JazzDocAll.AddSeasonDocumentsXML BandNames.Length=0 ";
                return false;
            }

            for (int index_band = 0; index_band < n_concerts; index_band++)
            {
                string band_name = BandNames[index_band];

                ActiveBandName = band_name;

                JazzDoc[] all_jazz_concert_docs = AllConcertDocuments;
                if (null == all_jazz_concert_docs)
                {
                    o_error = @"JazzDocAll.AddSeasonDocumentsXML AllConcertDocuments is null ";
                    return false;
                }

                for (int index_concert = 0; index_concert < all_jazz_concert_docs.Length; index_concert++)
                {
                    JazzDoc current_concert_doc = all_jazz_concert_docs[index_concert];

                    SetInitValues(current_concert_doc);
                    current_concert_doc.FilePath = i_dir_names[index_band];

                    if (!WriteDoc(current_concert_doc, "concert", out o_error))
                    {
                        o_error = @"JazzDocAll.AddSeasonDocumentsXML WriteDoc concert failed " + o_error;
                        return false;
                    }

                } // index_concert
            } // index_band
            return true;

        } // InitAddedSeasonXmlObject

        /// <summary>Set initial values
        /// <para></para>
        /// </summary>
        private void SetInitValues(JazzDoc i_doc_dat)
        {
            i_doc_dat.FileNameDoc = "";
            i_doc_dat.FileNameXls = "";
            i_doc_dat.FileNamePdf = "";
            i_doc_dat.FileNameTxt = "";
            i_doc_dat.FileNameImg = "";
            i_doc_dat.Published = false;

        } // SetInitValues

        #endregion // Utility functions

        #region Write

        /// <summary>Writes all XML data for the JazzDoc object m_doc_data
        /// <para>The object m_doc_data can come from a document of type season or concert </para>
        /// <para>For type season DocAdminUtil.WriteSeasonDoc(...) is called</para>
        /// <para>For type concert DocAdminUtil.WriteConcertDoc(...) is called</para>
        /// </summary>
        /// <param name="i_doc_dat">Input JazzDoc</param>
        /// <param name="i_doc_type">Type season or concert</param>
        /// <param name="o_error">Error message</param>
        private bool WriteDoc(JazzDoc i_doc_dat, string i_doc_type, out string o_error)
        {
            o_error = @"";

            if (i_doc_type.Equals("season"))
            {
                if (!JazzXml.SetSeasonDoc(i_doc_dat, i_doc_dat.TemplateName, out o_error))
                {
                    return false;
                }
            }
            else if (i_doc_type.Equals("concert"))
            {
                if (!JazzXml.WriteConcertDoc(i_doc_dat, ActiveBandName, out o_error))
                {
                    return false;
                }
            }
            else
            {
                o_error = @"DocExeDocument.WriteDoc Not an implemented document type. i_doc_type= " + i_doc_type;
                return false;
            }

            return true;

        } // WriteDoc

        #endregion // Write

        #region Get functions

        /// <summary>Get season name for the last XML object (JazzDokumente_20xx_20yy.xml)
        /// <para></para>
        /// <para></para>
        /// </summary>
        ///  <param name="o_season_name">Season name that has been added</param>
        /// <param name="o_error">Error message.</param>
        private string GetSeasonNameForLastObject(int i_last_index, out string o_error)
        {
            o_error = @"";
            string ret_season_name = @"";

            string[] season_names = JazzXml.GetSeasonNamesAllDocs();
            if (null == season_names)
            {
                o_error = @"JazzDocAll.GetSeasonNameForLastObject Programming error:  JazzXml.GetSeasonNamesAllDocs failed";
                return ret_season_name;
            }

            if (i_last_index != season_names.Length - 1)
            {
                o_error = @"JazzDocAll.GetSeasonNameForLastObject i_last_index != season_names.Length";
                return ret_season_name;
            }

            ret_season_name = season_names[i_last_index];

            return ret_season_name;

        } // GetSeasonNameForLastObject

        /// <summary>Gets band names and concert dates from jazz program (JazzProgram_20xx_20yy.xml)
        /// <para>Data is taken from th</para>
        /// <para</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_start_year">Start year defining the XDocument object that shall be activated</param>
        /// <param name="i_doc_type">Type season or concert</param>
        /// <param name="o_error">Error message</param>
        private bool GetBandNamesAndDates(int i_start_year, out string[] o_band_names, out string[] o_dates, out string o_error)
        {
            o_error = @"";
            o_band_names = null;
            o_dates = null;

            int[] season_start_years = JazzXml.GetSeasonsStartYears();
            if (null == season_start_years)
            {
                o_error = @"JazzDocAll.GetBandNamesAndDates season_start_years is null";
                return false;
            }

            XDocument[] season_documents = JazzXml.GetSeasonDocuments();
            if (null == season_documents)
            {
                o_error = @"JazzDocAll.GetBandNamesAndDates season_documents is null";
                return false;
            }

            int index_xml_object = -12345;
            for (int index_start_year=0; index_start_year< season_start_years.Length; index_start_year++)
            {
                if (season_start_years[index_start_year] == i_start_year)
                {
                    index_xml_object = index_start_year;
                }
            }

            if (index_xml_object<0)
            {
                o_error = @"JazzDocAll.GetBandNamesAndDates Index XML object not found for i_start_year= " + i_start_year.ToString();
                return false;
            }

            JazzXml.SetDocumentCurrent(season_documents[index_xml_object]);
            JazzXml.SetCurrentSeasonFileUrl(); // Don't know if this is necessary

            int number_concerts = JazzXml.GetNumberConcertsInCurrentDocument();
            if (number_concerts <= 0)
            {
                o_error = @"JazzDocAll.GetBandNamesAndDates Number of concerts <= 0 " + number_concerts.ToString();
                return false;
            }

            o_band_names = new string[number_concerts];
            o_dates = new string[number_concerts];

            for (int concert_number=1; concert_number<= number_concerts; concert_number++)
            {
                o_band_names[concert_number - 1] = JazzXml.GetBandName(concert_number);

                string date_concert = @"d";
                string year_concert = JazzXml.GetYear(concert_number);
                if (year_concert.Length == 1)
                    year_concert = "0" + year_concert;
                date_concert = date_concert + year_concert;

                string month_concert = JazzXml.GetMonth(concert_number);
                if (month_concert.Length == 1)
                    month_concert = "0" + month_concert;
                date_concert = date_concert + month_concert;

                string day_concert = JazzXml.GetDay(concert_number);
                if (day_concert.Length == 1)
                    day_concert = "0" + day_concert;
                date_concert = date_concert + day_concert;

                o_dates[concert_number - 1] = date_concert;
            }


            return true;

        } // GetBandNamesAndDates

        #endregion // Get functions

        #region Debug

        /// <summary>Debug flag</summary>
        private bool m_debug_flag = false;
        /// <summary>Get and set the debug flag</summary>
        public bool DebugFlag { get { return m_debug_flag; } set { m_debug_flag = value; } }

        /// <summary>Debug output of state data
        /// <para>File will be created in the maintenance directory</para>
        /// </summary>
        /// <param name="i_file_name">File name without path</param>
        public void DebugWriteState(string i_file_name)
        {
            if (!DebugFlag)
            {
                return;
            }

            string debug_state = DebugGetDocAllStateData(true, true, true);

            string MaintenanceDir = "Datenwartung";
            string local_address_directory = FileUtil.SubDirectory(MaintenanceDir + @"\", Main.m_exe_directory);

            string debug_file_name_with_path = local_address_directory + i_file_name;

            File.WriteAllText(debug_file_name_with_path, debug_state, Encoding.UTF8);

        } // DebugWriteState

        /// <summary>Returns a string with JazzDocAll state data (member variable values)
        /// <para>Basic state data are the XML objects corresponding to XML files JazzDokumente.xml and JazzDokumente_20xx_20yy.xml </para>
        /// <para>Therefore JazzXml.DebugGetDocStateData can be called</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_b_xml_objects">Flag telling if XML objects data shall be listed</param>
        /// <param name="i_b_array_values">Flag telling if array values shall be added</param>
        /// <param name="i_b_active_xml_content">Flag telling if the content of the active XLM object shall be added</param>
        public string DebugGetDocAllStateData(bool i_b_xml_objects, bool i_b_array_values, bool i_b_active_xml_content)
        {
            string ret_string = @"";

            if (!DebugFlag)
            {
                return ret_string;
            }

            ret_string = ret_string + @"State data for JazzDocAll" + NewLine();
            ret_string = ret_string + @"" + NewLine();

            if (i_b_xml_objects)
            {
                string debug_doc_state = JazzXml.DebugGetDocStateData(i_b_array_values, i_b_active_xml_content);
                ret_string = ret_string + debug_doc_state;
            }

            ret_string = ret_string + @"URL path to the folder with the document XML files m_url_xml_doc_files_folder= " + m_url_xml_doc_files_folder + NewLine();
            ret_string = ret_string + @"The name of the document templates XML file m_templates_xml_filename= " + m_templates_xml_filename + NewLine();
            ret_string = ret_string + @"The start season year for document XML files m_documents_start_year= " + m_documents_start_year.ToString() + NewLine();
            ret_string = ret_string + @"" + NewLine();

            if (ActiveSeasonXmlObject != null)
            {
                ret_string = ret_string + @"ActiveSeasonXmlObject has been set. Pointer is not null." + NewLine();
            }
            else
            {
                ret_string = ret_string + @"ActiveSeasonXmlObject has not been set. Pointer is null " + NewLine();
            }
            ret_string = ret_string + @"" + NewLine();

            ret_string = ret_string + @"Active season name ActiveSeasonName= " + ActiveSeasonName + NewLine();
            ret_string = ret_string + @"Active season file name ActiveSeasonFileName= " + ActiveSeasonFileName + NewLine();
            ret_string = ret_string + @"Active band name ActiveBandName= " + ActiveBandName + NewLine();
            ret_string = ret_string + @"First band name in array BandNames FirstBandName= " + FirstBandName + NewLine();
            ret_string = ret_string + @"" + NewLine();

            ret_string = ret_string + DebugAppendArraySizes();

            if (i_b_array_values)
            {
                ret_string = ret_string + DebugAppenSeasonNames();

                ret_string = ret_string + DebugAppenBandNames();

                ret_string = ret_string + DebugAppenAllSeasonDocs();

                ret_string = ret_string + DebugAppendAllConcertDocs();

                ret_string = ret_string + DebugAppendAllDocTemplates();
            }

            return ret_string;

        } // DebugGetDocAllStateData

        /// <summary>Append the lengths of the member arrays</summary>
        private string DebugAppendArraySizes()
        {
            string ret_string = @"";

            if (SeasonNames != null)
            {
                ret_string = ret_string + @"Length of array SeasonNames is " + SeasonNames.Length.ToString() + NewLine();
            }
            else
            {
                ret_string = ret_string + @"SeasonNames is null" + NewLine();
            }

            if (BandNames != null)
            {
                ret_string = ret_string + @"Length of array BandNames is " + BandNames.Length.ToString() + NewLine();
            }
            else
            {
                ret_string = ret_string + @"BandNames is null" + NewLine();
            }

            if (AllSeasonDocuments != null)
            {
                ret_string = ret_string + @"Length of array AllSeasonDocuments is " + AllSeasonDocuments.Length.ToString() + NewLine();
            }
            else
            {
                ret_string = ret_string + @"AllSeasonDocuments is null" + NewLine();
            }

            if (AllConcertDocuments != null)
            {
                ret_string = ret_string + @"Length of array AllConcertDocuments is " + AllConcertDocuments.Length.ToString() + NewLine();
            }
            else
            {
                ret_string = ret_string + @"AllConcertDocuments is null" + NewLine();
            }

            if (AllDocumentTemplates != null)
            {
                ret_string = ret_string + @"Length of array AllDocumentTemplates is " + AllDocumentTemplates.Length.ToString() + NewLine();
            }
            else
            {
                ret_string = ret_string + @"AllDocumentTemplates is null" + NewLine();
            }

            ret_string = ret_string + @"" + NewLine();

            return ret_string;

        } // DebugAppendArraySizes

        /// <summary>Append season names</summary>
        private string DebugAppenSeasonNames()
        {
            string ret_string = @"";

            if (SeasonNames == null || SeasonNames.Length == 0)
            {
                return ret_string;
            }

            ret_string = ret_string + @"SeasonNames" + NewLine();

            for (int index_name = 0; index_name < SeasonNames.Length; index_name++)
            {
                ret_string = ret_string + index_name.ToString() + @"     " + SeasonNames[index_name] + NewLine();
            }

            ret_string = ret_string + @"" + NewLine();

            return ret_string;

        } // DebugAppenSeasonNames

        /// <summary>Append band names</summary>
        private string DebugAppenBandNames()
        {
            string ret_string = @"";

            if (BandNames == null || BandNames.Length == 0)
            {
                return ret_string;
            }

            ret_string = ret_string + @"BandNames" + NewLine();

            for (int index_name = 0; index_name < BandNames.Length; index_name++)
            {
                ret_string = ret_string + index_name.ToString() + @"     " + BandNames[index_name] + NewLine();
            }

            ret_string = ret_string + @"" + NewLine();

            return ret_string;

        } // DebugAppenBandNames

        /// <summary>Append all season docs</summary>
        private string DebugAppenAllSeasonDocs()
        {
            string ret_string = @"";

            if (AllSeasonDocuments == null || AllSeasonDocuments.Length == 0)
            {
                return ret_string;
            }

            ret_string = ret_string + @"AllSeasonDocuments" + NewLine();

            for (int index_name = 0; index_name < AllSeasonDocuments.Length; index_name++)
            {
                JazzDoc current_season_doc = AllSeasonDocuments[index_name];
                ret_string = ret_string + index_name.ToString() + NewLine();
                ret_string = ret_string + current_season_doc.DebugMembers();
            }

            ret_string = ret_string + @"" + NewLine();

            return ret_string;

        } // DebugAppenAllSeasonDocs

        /// <summary>Append all concert docs</summary>
        private string DebugAppendAllConcertDocs()
        {
            string ret_string = @"";

            if (AllConcertDocuments == null || AllConcertDocuments.Length == 0)
            {
                return ret_string;
            }

            ret_string = ret_string + @"AllConcertDocuments for " + ActiveBandName + NewLine();

            for (int index_name = 0; index_name < AllConcertDocuments.Length; index_name++)
            {
                JazzDoc current_concert_doc = AllConcertDocuments[index_name];
                ret_string = ret_string + index_name.ToString() + NewLine();
                ret_string = ret_string + current_concert_doc.DebugMembers();
            }

            ret_string = ret_string + @"" + NewLine();

            return ret_string;

        } // DebugAppendAllConcertDocs

        /// <summary>Append all document templates</summary>
        private string DebugAppendAllDocTemplates()
        {
            string ret_string = @"";

            if (AllDocumentTemplates == null || AllDocumentTemplates.Length == 0)
            {
                return ret_string;
            }

            ret_string = ret_string + @"AllDocumentTemplates" + NewLine();

            for (int index_name = 0; index_name < AllDocumentTemplates.Length; index_name++)
            {
                JazzDocTemplate current_template_doc = AllDocumentTemplates[index_name];
                ret_string = ret_string + index_name.ToString() + NewLine();
                ret_string = ret_string + current_template_doc.DebugMembers();
            }

            ret_string = ret_string + @"" + NewLine();

            return ret_string;

        } // DebugAppendAllDocTemplates

        /// <summary>Returns new line</summary>
        private string NewLine() { return "\r\n"; }

        #endregion // Debug

    } // JazzDocAll

} // namespace
