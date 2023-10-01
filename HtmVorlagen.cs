using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>The class HtmVorlagen defines the names of HTM template files used for the creation of XML to HTM files
    /// <para>Also the output HTM files and path are defined in this class. TODO Define the output name also in the template file JazzDokumente.xml. Add also "name" UseAdminName.</para>
    /// <para></para>
    /// </summary>
    /// <remarks>
    /// <para></para>
    /// </remarks>
    public static class HtmVorlagen
    {
        #region HTM template file names

        /// <summary>Defines the names of HTM template and JavaScript files used for the creation of XML to HTM files
        /// <para></para>
        /// <para></para>
        /// </summary>
        static private string[] m_htm_template_file_names =
        {
            @"Dokument_doc_pdf_img.htm", // 0 
            @"Dokument_doc_pdf.htm", // 1 
            @"Dokument_xls_pdf.htm", // 2 
            @"Konzert.htm", // 3 
            @"KonzertPlakat.htm", // 4 
            @"DokumentSaison.htm", // 5
            @"DokumentSaisonHeader.htm", // 6 
            @"DokumentSaisonRow.htm", // 7
            @"JazzProgramm.js", // 8

        }; // m_htm_template_file_names

        /// <summary>Returns the filename for the DOC-PDF-IMG template file. The name is defined in the array HtmVorlagen.m_htm_template_file_names</summary>
        //QQ 20230930 static public string GetFilenameDocPdfImg() { return m_htm_template_file_names[0]; }
        /// <summary>Returns the filename for the DOC-PDF template file. The name is defined in the array HtmVorlagen.m_htm_template_file_names</summary>
        //QQ 20230930 static public string GetFilenameDocPdf() { return m_htm_template_file_names[1]; }
        /// <summary>Returns the filename for the XLS-PDF template file. The name is defined in the array HtmVorlagen.m_htm_template_file_names</summary>
        //QQ 20230930 static public string GetFilenameXlsPdf() { return m_htm_template_file_names[2]; }
        /// <summary>Returns the filename for the Konzert template file. The name is defined in the array HtmVorlagen.m_htm_template_file_names</summary>
        //QQ 20230930 static public string GetFilenameKonzert() { return m_htm_template_file_names[3]; }
        /// <summary>Returns the filename for the KonzertPlakat template file. The name is defined in the array HtmVorlagen.m_htm_template_file_names</summary>
        //QQ 20230930 static public string GetFilenameKonzertPlakat() { return m_htm_template_file_names[4]; }
        /// <summary>Returns the filename for the DokumentSaison template file. The name is defined in the array HtmVorlagen.m_htm_template_file_names</summary>
        //QQ 20230930 static public string GetFilenameDokumentSaison() { return m_htm_template_file_names[5]; }
        /// <summary>Returns the filename for the DokumentSaisonHeader template file. The name is defined in the array HtmVorlagen.m_htm_template_file_names</summary>
        //QQ 20230930 static public string GetFilenameDokumentSaisonHeader() { return m_htm_template_file_names[6]; }
        /// <summary>Returns the filename for the DokumentSaisonRow template file. The name is defined in the array HtmVorlagen.m_htm_template_file_names</summary>
        //QQ 20230930 static public string GetFilenameDokumentSaisonRow() { return m_htm_template_file_names[7]; }
        /// <summary>Returns the filename for the JavaScript file used to create the season jazz program web page. The name is defined in the array HtmVorlagen.m_htm_template_file_names</summary>
        static public string GetFilenameScriptJazzProgram() { return m_htm_template_file_names[8]; }

        #endregion // HTM template file names
   
        #region Output document HTM file names and local path

        /// <summary>Defines the names of document HTM output files
        /// <para></para>
        /// <para></para>
        /// </summary>
        static private string[] m_htm_file_names =
        {
            @"DokumentBillete.htm", // 0 
            @"DokumentPlakate.htm", // 1
            @"DokumentFlyersFront.htm", // 2 
            @"DokumentFlyersReverse.htm", // 3
            @"DokumentFlyersStart.htm", // 4
            @"DokumentVertraege.htm", // 5 
            @"DokumenteSaison.htm", // 6 
            @"JazzProgramm.htm", // 7
            @"DokumentKonzertInfo.htm", // 8
            @"DokumentFlyersInfo.htm", // 9
            @"DokumentQrCodes.htm", // 10
            @"DokumentPostersInternet.htm", // 11
            @"DokumentFlyersPrintshop.htm", // 12
            @"DokumentPostersInternetB.htm", // 13

        }; // m_htm_file_names

        /// <summary>Returns the name of the ticket html file</summary>
        static public string GetDocumentTicketsHtmFileName() { return m_htm_file_names[0]; }
        /// <summary>Returns the name of the poster html file</summary>
        static public string GetDocumentPostersHtmFileName() { return m_htm_file_names[1]; }
        /// <summary>Returns the name of the flyer front html file</summary>
        static public string GetDocumentFlyersFrontHtmFileName() { return m_htm_file_names[2]; }
        /// <summary>Returns the name of the flyer reverse html file</summary>
        static public string GetDocumentFlyersReverseHtmFileName() { return m_htm_file_names[3]; }
        /// <summary>Returns the name of the flyer start html file</summary>
        static public string GetDocumentFlyersStartHtmFileName() { return m_htm_file_names[4]; }
        /// <summary>Returns the name of the contract html file</summary>
        static public string GetDocumentContractsHtmFileName() { return m_htm_file_names[5]; }
        /// <summary>Returns the name of the season documents html file</summary>
        static public string GetDocumentsSeasonHtmFileName() { return m_htm_file_names[6]; }
        /// <summary>Returns the name of the season program html file</summary>
        static public string GetSeasonProgramHtmFileName() { return m_htm_file_names[7]; }
        /// <summary>Returns the name of the concert information html file</summary>
        static public string GetDocumentConcertInfoHtmFileName() { return m_htm_file_names[8]; }
        /// <summary>Returns the name of the flyer info html file</summary>
        static public string GetDocumentFlyersInfoHtmFileName() { return m_htm_file_names[9]; }
        /// <summary>Returns the name of the QR codes html file</summary>
        static public string GetDocumentQrCodesHtmFileName() { return m_htm_file_names[10]; }

        /// <summary>Returns the name of the posters Internet html file</summary>
        static public string GetDocumentPostersInternetHtmFileName() { return m_htm_file_names[11]; }

        /// <summary>Returns the name of the flyer info html file</summary>
        static public string GetDocumentFlyersPrintshopHtmFileName() { return m_htm_file_names[12]; }

        /// <summary>Returns the name of the posters Internet html file</summary>
        static public string GetDocumentPostersInternetBHtmFileName() { return m_htm_file_names[13]; }

        /// <summary>Local directory for HTM files</summary>
        private static string m_local_dir_htm_files = @"HtmFiles";
        /// <summary>Local directory for HTM files</summary>
        public static string LocalDirHtmlFiles { get { return m_local_dir_htm_files; }  }

        /// <summary>Returns the full file name for the season documents HTM file</summary>
        public static string GetFullLocalHtmlFileNameForSeasonDocuments()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentsSeasonHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForSeasonDocuments

        /// <summary>Returns the full file name for the local ticket HTM file</summary>
        public static string GetFullLocalHtmlFileNameForTicket()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentTicketsHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileName

        /// <summary>Returns the full file name for the local concert info HTM file</summary>
        public static string GetFullLocalHtmlFileNameForConcertInfo()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentConcertInfoHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForConcertInfo

        /// <summary>Returns the full file name for the local poster HTM file</summary>
        public static string GetFullLocalHtmlFileNameForPoster()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentPostersHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForPoster

        /// <summary>Returns the full file name for the local flyer front HTM file</summary>
        public static string GetFullLocalHtmlFileNameForFlyerFront()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentFlyersFrontHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForFlyerFront

        /// <summary>Returns the full file name for the local flyer reverse HTM file</summary>
        public static string GetFullLocalHtmlFileNameForFlyerReverse()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentFlyersReverseHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForFlyerReverse

        /// <summary>Returns the full file name for the local flyer info HTM file</summary>
        public static string GetFullLocalHtmlFileNameForFlyerInfo()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentFlyersInfoHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForFlyerInfo

        /// <summary>Returns the full file name for the local flyer printshop HTM file</summary>
        public static string GetFullLocalHtmlFileNameForFlyerPrintshop()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentFlyersPrintshopHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForFlyerPrintshop

        /// <summary>Returns the full file name for the local flyer start HTM file</summary>
        public static string GetFullLocalHtmlFileNameForFlyerStart()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentFlyersStartHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForFlyerStart

        /// <summary>Returns the full file name for the local contract HTM file</summary>
        public static string GetFullLocalHtmlFileNameForContract()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentContractsHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForContract

        /// <summary>Returns the full file name for the poster A Internet HTM file</summary>
        public static string GetFullLocalHtmlFileNameForPosterInternet()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentPostersInternetHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForPosterInternet

        /// <summary>Returns the full file name for the poster B Internet HTM file</summary>
        public static string GetFullLocalHtmlFileNameForPosterInternetB()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetDocumentPostersInternetBHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForPosterInternetB

        /// <summary>Returns the full file name for the local season program HTM file</summary>
        public static string GetFullLocalHtmlFileNameForSeasonProgram()
        {
            string ret_full_filename = @"";

            ret_full_filename = GetFullLocalHtmlFileName(GetSeasonProgramHtmFileName());

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForSeasonProgram

        /// <summary>Returns the full file name for the local HTM file. TODO Move to utilities</summary>
        private static string GetFullLocalHtmlFileName(string i_filename)
        {
            string ret_filename = @"";

            string local_address_directory = FileUtil.SubDirectory(LocalDirHtmlFiles, Main.m_exe_directory) + @"\";

            ret_filename = local_address_directory + i_filename;

            return ret_filename;
        } // GetFullLocalHtmlFileName

        /// <summary>Server directory for document HTM files</summary>
        private static string m_server_dir_document_htm_files = @"www\Administration\Dokumente\";
        /// <summary>Server directory for document HTM files</summary>
        public static string ServerDocumentDirHtmlFiles { get { return m_server_dir_document_htm_files; } }

        /// <summary>Returns the full URL name for the server document HTM file</summary>
        public static string GetFullServerDocumentHtmlFileName(string i_filename)
        {
            string ret_url = @"";

            ret_url = ServerDocumentDirHtmlFiles + i_filename;

            return ret_url;
        } // GetFullServerHtmlFileName

        /// <summary>Returns the full file name for the local concert HTM file
        /// <para></para>
        /// </summary>
        /// <param name="i_date">Input date yyyy.mm.dd</param>
        public static string GetFullLocalHtmlFileNameForConcert(string i_date)
        {
            string ret_full_filename = @"";

            string file_name = @"Konzert" + @"." + i_date + @".htm";

            ret_full_filename = GetFullLocalHtmlFileName(file_name);

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForConcert

        /// <summary>Returns the full file name for the local concert-poster HTM file
        /// <para></para>
        /// </summary>
        /// <param name="i_date">Input date yyyy.mm.dd</param>
        public static string GetFullLocalHtmlFileNameForConcertPoster(string i_date)
        {
            string ret_full_filename = @"";

            string file_name = @"Konzert" + @"." + i_date + @".Plakat" + @".htm";

            ret_full_filename = GetFullLocalHtmlFileName(file_name);

            return ret_full_filename;

        } // GetFullLocalHtmlFileNameForConcertPoster

        #endregion // Output document HTM file names and local path

        #region  Output document HTM file names and server path

        /// <summary>Server directory for concert HTM files</summary>
        private static string m_server_dir_concert_htm_files = @"www\Konzerte\";
        /// <summary>Server directory for concert HTM files</summary>
        public static string ServerConcertDirHtmlFiles { get { return m_server_dir_concert_htm_files; } }

        /// <summary>Server directory for www HTM files</summary>
        private static string m_server_dir_www_htm_files = @"www";
        /// <summary>Server directory for www HTM files</summary>
        public static string ServerWwwDirHtmlFiles { get { return m_server_dir_www_htm_files; } }

        /// <summary>Server directory for template HTM files</summary>
        private static string m_server_dir_template_htm_files = @"/HtmVorlagen/";
        /// <summary>Server directory for template HTM files</summary>
        public static string ServerTemplateDirHtmlFiles { get { return m_server_dir_template_htm_files; } }

        /// <summary>Returns the full URL name for the server document HTM file</summary>
        public static string GetFullServerConcertHtmlFileName(string i_filename)
        {
            string ret_url = @"";

            ret_url = ServerConcertDirHtmlFiles + i_filename;

            return ret_url;
        } // GetFullServerHtmlFileName

        /// <summary>Returns the full URL name for the saison program HTM file</summary>
        public static string GetFullServerSaisonProgramHtmlFileName(string i_filename)
        {
            string ret_url = @"";

            ret_url = ServerWwwDirHtmlFiles + i_filename;

            return ret_url;
        } // GetFullServerSaisonProgramHtmlFileName

        #endregion // Output concert HTM file names and server path

    } // HtmVorlagen

} // namespace
