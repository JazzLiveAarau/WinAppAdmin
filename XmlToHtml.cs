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
    /// <summary>Functions for the creation of HTML files from XML files
    /// <para></para>
    /// <para></para>
    /// <para></para>
    /// <para></para>
    /// <para></para>
    /// </summary>
    /// <remarks>
    /// <para></para>
    /// </remarks>
    public static class XmlToHtml
    {
        private static XDocument m_season_document = null;

        /// <summary>Initialization of objects used for the creation of HTML files from XML files
        /// <para>1. Download all HTML templates. Call of DownLoad.DownloadHtmTemplates</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_season_document">The season document (this or next season)</param>
        /// <param name="o_error">Error description</param>
        public static bool InitXmlToHtml(XDocument i_season_document, out string o_error)
        {
            o_error = @"";

            if (null == i_season_document)
            {
                o_error = @"XmlToHtml.InitXmlToHtml i_season_document is null.";
                return false;
            }

            m_season_document = i_season_document;

            DownLoad down_load = new DownLoad();
            string error_message = "";

            if (!down_load.DownloadHtmTemplates(out error_message))
            {
                o_error = JazzAppAdminSettings.Default.ErrMsgHtmTemplatesDownload;
                return false;
            }

            return true;

        } // InitXmlToHtml

        #region Get the content of a web page HTM template file as a string
        /*QQ20230930
        /// <summary>Get the file content as a string from the the web page template file
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_concert_string">Output string with the content of the concert web page template file</param>
        /// <param name="o_template_file_concert_poster_string">Output string with the content of the concert-poster web page template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GetTemplateFilesAsStringsForConcertWebPages(out string o_template_file_concert_string, out string o_template_file_concert_poster_string, out string o_error)
        {
            o_error = @"";
            o_template_file_concert_string = @"";
            o_template_file_concert_poster_string = @"";

            string error_message = @"";

            string template_filename_concert = HtmVorlagen.GetFilenameKonzert();

            if (!GetTemplateFileAsString(template_filename_concert, out o_template_file_concert_string, out error_message))
            {
                o_error = @"XmlToHtml.GetTemplateFileAsStringForConcertWebPage (concert) " + error_message;
                return false;
            }

            string template_filename_concert_poster= HtmVorlagen.GetFilenameKonzertPlakat();

            if (!GetTemplateFileAsString(template_filename_concert_poster, out o_template_file_concert_poster_string, out error_message))
            {
                o_error = @"XmlToHtml.GetTemplateFileAsStringForConcertWebPage (concert-poster) " + error_message;
                return false;
            }

            return true;

        } // GetTemplateFilesAsStringsForConcertWebPages
        QQ20230930*/
        #endregion // Get the content of a web page HTM template file as a string

        #region Get the content of a web document HTM template file as a string

        /*QQ 20230930 
        /// <summary>Get template file content as a string for data that shall be displayed in a DOC-PDF-IMG HTML table
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GetTemplateFileAsStringForDocPdfImg(out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            string template_filename = HtmVorlagen.GetFilenameDocPdfImg();

            if (!GetTemplateFileAsString(template_filename, out o_template_file_string, out o_error))
            {
                return false;
            }

            return true;

        } // GetTemplateFileAsStringForDocPdfImg
        QQ 20230930 */

        /*QQ 20230930 
        /// <summary>Get template file content as a string for data that shall be displayed in a DOC-PDF HTML table
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GetTemplateFileAsStringForDocPdf(out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            string template_filename = HtmVorlagen.GetFilenameDocPdf();

            if (!GetTemplateFileAsString(template_filename, out o_template_file_string, out o_error))
            {
                return false;
            }

            return true;

        } // GetTemplateFileAsStringForDocPdf
        QQ 20230930 */

        /*QQ 20230930 
        /// <summary>Get template file content as a string for data that shall be displayed in a XSL-PDF HTML table
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GetTemplateFileAsStringForXlsPdf(out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            string template_filename = HtmVorlagen.GetFilenameXlsPdf();

            if (!GetTemplateFileAsString(template_filename, out o_template_file_string, out o_error))
            {
                return false;
            }

            return true;

        } // GetTemplateFileAsStringForXlsPdf
        20230930  */

        /*QQ 20230930 
        /// <summary>Get template file content from DokumentSaison.htm
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GetTemplateFileAsStringForDokumentSaison(out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            string template_filename = HtmVorlagen.GetFilenameDokumentSaison();

            if (!GetTemplateFileAsString(template_filename, out o_template_file_string, out o_error))
            {
                return false;
            }

            return true;

        } // GetTemplateFileAsStringForDokumentSaison

        /// <summary>Get template file content from DokumentSaisonHeader.htm
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GetTemplateFileAsStringForDokumentSaisonHeader(out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            string template_filename = HtmVorlagen.GetFilenameDokumentSaisonHeader();

            if (!GetTemplateFileAsString(template_filename, out o_template_file_string, out o_error))
            {
                return false;
            }

            return true;

        } // GetTemplateFileAsStringForDokumentSaisonHeader

        /// <summary>Get template file content from DokumentSaisonRow.htm
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GetTemplateFileAsStringForDokumentSaisonRow(out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            string template_filename = HtmVorlagen.GetFilenameDokumentSaisonRow();

            if (!GetTemplateFileAsString(template_filename, out o_template_file_string, out o_error))
            {
                return false;
            }

            return true;

        } // GetTemplateFileAsStringForDokumentSaisonRow
        QQ 20230930 */

        #endregion // Get the content of a document HTM template file as a string

        #region Generate the content of a web document HTM template file as a string

        /// <summary>Generate template file content for DokumentSaison.htm
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GenerateTemplateFileAsStringForDokumentSaison(out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            o_template_file_string += "<!DOCTYPE html>" + NewLine();

            o_template_file_string += "<html>" + NewLine();

            o_template_file_string += ConcertTemplateFileDescription();

            o_template_file_string += TabTwo() + "<head>" + NewLine();

            o_template_file_string += TabFour() + "<title>Saisondokument</title>" + NewLine();

            o_template_file_string += TdCssString();

            o_template_file_string += ParagraphCssString();

            o_template_file_string += TabTwo() + "</head>" + NewLine();

            o_template_file_string += TabTwo() + "<body>" + NewLine();

            o_template_file_string += TabFour() + "<p><b><br>" + NewLine();

            o_template_file_string += TabFour() + "&nbsp;Saisondokumente  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Saison JazzDokumenteSaison.SeasonYears" + NewLine();

            o_template_file_string += TabFour() + "</p>" + NewLine();

            o_template_file_string += TabThree() + "<table align='left' cellSpacing='0 cellPadding='0'  border='0'>" + NewLine();

            o_template_file_string += TabThree() + "JazzDokumenteSaison.InsertHeader" + NewLine();

            o_template_file_string += TabThree() + "JazzDokumenteSaison.InsertRow" + NewLine();

            o_template_file_string += ConcertTemplateFileEnd();

            return true;

        } // GenerateTemplateFileAsStringForDokumentSaison

        /// <summary>Generate template file content for DokumentSaisonHeader.htm
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GenerateTemplateFileAsStringForDokumentSaisonHeader(out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            o_template_file_string += TabFour() + "<!-- Header Start  -->" + NewLine();

            int colspan = 7;

            o_template_file_string += ConcertTemplateLine(colspan);

            o_template_file_string += TabSix() + "<tr>" + NewLine();

            o_template_file_string += TabEight() + "<td width='128'>";

            o_template_file_string += "Dokument";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "DOC";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "XLS";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "PDF";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "TXT";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "IMG";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "Publizieren";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabSix() + "</tr>" + NewLine();

            o_template_file_string += ConcertTemplateLine(colspan);

            o_template_file_string += TabFour() + "<!-- Header End  -->" + NewLine();

            return true;

        } // GenerateTemplateFileAsStringForDokumentSaisonHeader

        /// <summary>Generate template file content for DokumentSaisonRow.htm
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GenerateTemplateFileAsStringForDokumentSaisonRow(out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            o_template_file_string += TabFour() + "<!-- Document Start  -->" + NewLine();

            o_template_file_string += TabSix() + "<tr>" + NewLine();

            o_template_file_string += TabEight() + "<td style= 'color:#ff0028' width='58'>";

            o_template_file_string += "JazzDokumente.DocumentDialogTitle";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "JazzDokumenteSaison.PathFileNameLinkDoc";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "JazzDokumenteSaison.PathFileNameLinkXls";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "JazzDokumenteSaison.PathFileNameLinkPdf";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "JazzDokumenteSaison.PathFileNameLinkTxt";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "JazzDokumenteSaison.PathFileNameLinkImg";

            o_template_file_string += "</td>" + NewLine();

            o_template_file_string += TabEight() + "<td width='29'>";

            o_template_file_string += "JazzDokumenteSaison.Publish";

            o_template_file_string += "</td>" + NewLine();

            int colspan = 7;

            o_template_file_string += ConcertTemplateLine(colspan);

            o_template_file_string += TabSix() + "</tr>" + NewLine();

            o_template_file_string += TabFour() + "<!-- Document End  -->" + NewLine();

            return true;

        } // GenerateTemplateFileAsStringForDokumentSaisonRow


        /// <summary>Generate the template file content as a string for data that shall be displayed in a DOC-PDF-IMG HTML table
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GenerateTemplateFileAsStringForDocPdfImg(int i_n_concerts, out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            int colspan = 6;

            bool b_image = true;

            o_template_file_string += ConcertTemplateFileStart(colspan, b_image);

            for (int concert_number=1; concert_number <= i_n_concerts; concert_number++)
            {
                o_template_file_string += TabFour() + "<!-- Konzert " + concert_number.ToString() + " Start -->"+ NewLine();

                o_template_file_string += TabFour() + "<tr>" + NewLine();

                string case_col = "date";

                int width = 58;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "band";

                width = 128;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "doc";

                width = 29;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "pdf";

                width = 29;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "img";

                width = 29;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "publish";

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);


                o_template_file_string += TabFour() + "</tr>" + NewLine();


                o_template_file_string += ConcertTemplateLine(colspan);

                o_template_file_string += TabFour() + "<!-- Konzert " + concert_number.ToString() + " End -->" + NewLine();

            }

            o_template_file_string += ConcertTemplateFileEnd();

            return true;

        } // GenerateTemplateFileAsStringForDocPdfImg

        /// <summary>Generate template file content as a string for data that shall be displayed in a DOC-PDF HTML table
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GenerateTemplateFileAsStringForDocPdf(int i_n_concerts, out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            int colspan = 5;

            bool b_image = false;

            o_template_file_string += ConcertTemplateFileStart(colspan, b_image);

            for (int concert_number = 1; concert_number <= i_n_concerts; concert_number++)
            {
                o_template_file_string += TabFour() + TabFour() + "<!-- Konzert " + concert_number.ToString() + " Start -->" + NewLine();

                o_template_file_string += TabFour() + TabFour() + "<TR>" + NewLine();

                string case_col = "date";

                int width = 58;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "band";

                width = 128;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "doc";

                width = 29;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "pdf";

                width = 29;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "publish";

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);


                o_template_file_string += TabFour() + TabFour() + "</TR>" + NewLine();


                o_template_file_string += ConcertTemplateLine(colspan);

                o_template_file_string += TabFour() + TabFour() + "<!-- Konzert " + concert_number.ToString() + " End -->" + NewLine();

            }


            o_template_file_string += ConcertTemplateFileEnd();


            return true;

        } // GenerateTemplateFileAsStringForDocPdf

        /// <summary>Generate template file content as a string for data that shall be displayed in a XSL-PDF HTML table
        /// <para></para>
        /// </summary>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        public static bool GenerateTemplateFileAsStringForXlsPdf(int i_n_concerts, out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            int colspan = 5;

            bool b_image = false;

            o_template_file_string += ConcertTemplateFileStart(colspan, b_image);

            for (int concert_number = 1; concert_number <= i_n_concerts; concert_number++)
            {
                o_template_file_string += TabFour() + TabFour() + "<!-- Konzert " + concert_number.ToString() + " Start -->" + NewLine();

                o_template_file_string += TabFour() + TabFour() + "<TR>" + NewLine();

                string case_col = "date";

                int width = 58;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "band";

                width = 128;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "xls";

                width = 29;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "pdf";

                width = 29;

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);

                case_col = "publish";

                o_template_file_string += ConcertTemplateCol(case_col, concert_number, width);


                o_template_file_string += TabFour() + TabFour() + "</TR>" + NewLine();


                o_template_file_string += ConcertTemplateLine(colspan);

                o_template_file_string += TabFour() + TabFour() + "<!-- Konzert " + concert_number.ToString() + " End -->" + NewLine();

            }

            o_template_file_string += ConcertTemplateFileEnd();

            return true;

        } // GenerateTemplateFileAsStringForXlsPdf


        /// <summary>Returns the concert start file part</summary>
        private static string ConcertTemplateFileStart(int i_colspan, bool i_b_image)
        {
            string o_start_str = "";

            o_start_str += "<!DOCTYPE html>" + NewLine();

            o_start_str += "<html>" + NewLine();

            o_start_str += ConcertTemplateFileDescription();

            o_start_str += TabTwo() + "<head>" + NewLine(); 
            
            o_start_str += TabFour() + "<title>JazzDokumente.TemplateDescription</title>" + NewLine();

            o_start_str += TdCssString();

            o_start_str += ParagraphCssString();

            o_start_str += TabTwo() + "</head>" + NewLine();

            o_start_str += TabTwo() + "<body>" + NewLine();

            o_start_str += TabFour() + "<p><b><br>" + NewLine();

            o_start_str += TabFour() + "&nbsp;JazzDokumente.TemplateDescription  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Saison JazzDokumenteSaison.SeasonYears" + NewLine();

            o_start_str += TabFour() + "</p>" + NewLine();

            o_start_str += TabThree() + "<table align='left' cellSpacing='0 cellPadding='0'  border='0'>" + NewLine();
      
            o_start_str += ConcertTemplateLine(i_colspan);

            o_start_str += TabFour() + "<!-- Header Start  -->" + NewLine();

            o_start_str += TabSix() + "<tr>" + NewLine();

            o_start_str += TabTen() + "<td width='58'>";

            o_start_str += "&nbsp;Datum";

            o_start_str += "</td>" + NewLine();

            o_start_str += TabTen() + "<td width='128'>";

            o_start_str += "Konzert";

            o_start_str += "</td>" + NewLine();

            o_start_str += TabTen() + "<td width='29'>";

            o_start_str += "JazzDokumente.DocumentDialogTitle";

            o_start_str += "</td>" + NewLine();

            o_start_str += TabTen() + "<td width='29'>";

            o_start_str += "&nbsp;";

            o_start_str += "</td>" + NewLine();


            if (i_b_image)
            {
                o_start_str += TabTen() + "<td width='29'>";

                o_start_str += "Bild";

                o_start_str += "</td>" + NewLine();
            }

            o_start_str += TabTen() + "<td width='29'>";

            o_start_str += "Publizieren";

            o_start_str += "</td>" + NewLine();


            o_start_str += TabFour() + "</tr>" + NewLine();

            o_start_str += ConcertTemplateLine(i_colspan);

            o_start_str += TabFour() + "<!-- Header End  -->" + NewLine();

            o_start_str += "" + NewLine();

            return o_start_str;

        } // ConcertTemplateFileStart

        /// <summary>Returns the concert end file part</summary>
        private static string ConcertTemplateFileEnd()
        {
            string o_end_str = "";

            o_end_str += TabThree() + "</table>" + NewLine();

            o_end_str += TabTwo() + "</body>" + NewLine();

            o_end_str += "</html>" + NewLine();

            return o_end_str;

        }  // ConcertTemplateFileEnd

        /// <summary>Returns comment describing the file </summary>
        private static string ConcertTemplateFileDescription()
        {
            string o_comment_str = "";

            o_comment_str += TabTwo() + "<!-- The Windows application Admin has created this file -->" + NewLine();

            return o_comment_str;

        }  // ConcertTemplateFileDescription


        /// <summary>Returns the concert column </summary>
        private static string ConcertTemplateCol(string i_case_col, int i_concert_number, int i_width)
        {
            string o_col_str = "";

            if (i_case_col.Equals("date") || i_case_col.Equals("band"))
            {
                o_col_str += TabEight() + "<td style= 'color:#ff0028' width='" + i_width.ToString() + "'>";
            }
            else
            {
                o_col_str += TabEight() + "<td width='" + i_width.ToString() + "'>";
            }

            if (i_case_col.Equals("date"))
            {
                o_col_str += "&nbsp;JazzProgrammSaison.ConcertDate(" + i_concert_number.ToString() + ")";
            }
            else if (i_case_col.Equals("band"))
            {
                o_col_str += "JazzProgrammSaison.BandName(" + i_concert_number.ToString() + ")"; 
            }
            else if (i_case_col.Equals("doc"))
            {
                o_col_str += "<A href='JazzDokumenteSaison.PathFileNameDoc(" + i_concert_number.ToString() + ")'>DOC</A>"; 
            }
            else if (i_case_col.Equals("pdf"))
            {
                o_col_str += "<A href='JazzDokumenteSaison.PathFileNamePdf(" + i_concert_number.ToString() + ")'>PDF</A>"; 
            }
            else if (i_case_col.Equals("img"))
            {
                o_col_str += "<A href='JazzDokumenteSaison.PathFileNameImg(" + i_concert_number.ToString() + ")'>IMG</A>"; 
            }
            else if (i_case_col.Equals("xls"))
            {
                o_col_str += "<A href='JazzDokumenteSaison.PathFileNameXls(" + i_concert_number.ToString() + ")'>XLS</A>"; 
            }
            else if (i_case_col.Equals("publish"))
            {
                o_col_str += "JazzDokumenteSaison.Published(" + i_concert_number.ToString() + ")"; 
            }
            else
            {
                o_col_str += "ConcertTemplateCol: Undefined case= " + i_case_col; ;
            }

            o_col_str += "</td>" + NewLine();

            return o_col_str;

        }  // ConcertTemplateCol

        /// <summary>Returns the concert template line</summary>
        private static string ConcertTemplateLine(int i_colspan)
        {
            string o_line_str = "";

            o_line_str += TabFour() + "<tr>" + NewLine();

            o_line_str += TabSix() + "<td colspan='" + i_colspan.ToString() + "'>" + NewLine();

            o_line_str += TabEight() + "__________________________________________________________________________________________________________" + NewLine();

            o_line_str += TabSix() + "</td>" + NewLine();

            o_line_str += TabFour() + "</tr>" + NewLine();

            return o_line_str;


        } // ConcertTemplateLine

        /// <summary>Returns style for the TD element</summary>
        static private string TdCssString()
        {
            string o_css_str = "";

            o_css_str += TabFour() + "<style>" + NewLine();

            o_css_str += TabSix() + "td" + NewLine();

            o_css_str += TabSix() + "{" + NewLine();

            o_css_str += TabEight() + "font-family: 'Arial Narrow';" + NewLine();

            o_css_str += TabEight() + "font-size: 3;" + NewLine();

            o_css_str += TabEight() + "font-weight: bold;" + NewLine();

            o_css_str += TabEight() + "background-color: #FFFFFF;" + NewLine();

            o_css_str += TabSix() + "}" + NewLine();

            o_css_str += TabFour() + "</style>" + NewLine();

            return o_css_str;

        } // TdCssString

        /// <summary>Returns style for the P element</summary>
        static private string ParagraphCssString()
        {
            string o_css_p_str = "";

            o_css_p_str += TabFour() + "<style>" + NewLine();

            o_css_p_str += TabSix() + "p" + NewLine();

            o_css_p_str += TabSix() + "{" + NewLine();

            o_css_p_str += TabSix() + "font-family: 'Arial Narrow';" + NewLine();

            o_css_p_str += TabEight() + "font-size: 14pt;" + NewLine();

            o_css_p_str += TabEight() + "font-weight: bold;" + NewLine();

            o_css_p_str += TabEight() + "background-color: #FFFFFF;" + NewLine();

            o_css_p_str += TabSix() + "}" + NewLine();

            o_css_p_str += TabFour() + "</style>" + NewLine();

            return o_css_p_str;

        } // ParagraphCssString

        /// <summary>Returns two spaces</summary>
        static private string TabTwo() { return "  "; }

        /// <summary>Returns three spaces</summary>
        static private string TabThree() { return "   "; }

        /// <summary>Returns four spaces</summary>
        static private string TabFour() { return "    "; }

        /// <summary>Returns six spaces</summary>
        static private string TabSix() { return "      "; }

        /// <summary>Returns eight spaces</summary>
        static private string TabEight() { return "        "; }

        /// <summary>Returns ten spaces</summary>
        static private string TabTen() { return "          "; }

        /// <summary>Returns new line</summary>
        static private string NewLine() { return "\r\n"; }

        #endregion // Generate the content of a web document HTM template file as a string


        #region Functions for document and web page HTM template files

        /// <summary>Get template file content as a string
        /// <para>This function is called by GetTemplateFileAsStringForDocPdfImg, GetTemplateFileAsStringForDocPdf and GetTemplateFileAsStringForXlsPdf</para>
        /// <para>The calling functions only sets the names of the template file. This template file names are defined in class HtmVorlagen.</para>
        /// </summary>
        /// <param name="i_template_filename">Input template file name</param>
        /// <param name="o_template_file_string">Output string with the content of the template file</param>
        /// <param name="o_error">Error description</param>
        private static bool GetTemplateFileAsString(string i_template_filename, out string o_template_file_string, out string o_error)
        {
            o_error = @"";
            o_template_file_string = @"";

            DownLoad down_load = new DownLoad();
            string error_message = "XmlToHtml.GetTemplateFileAsString ";

            string full_file_name = down_load.GetLocalFullFilenameHtmTemplate(i_template_filename);

            if (!File.Exists(full_file_name))
            {
                o_error = @"XmlToHtml.GetTemplateFileAsString File: " + full_file_name + @" does not exist. Programming error";
                return false;
            }

            try
            {
                using (FileStream file_stream = new FileStream(full_file_name, FileMode.Open, FileAccess.Read, FileShare.Read))

                using (StreamReader stream_reader = new StreamReader(file_stream))
                {
                    while (stream_reader.Peek() >= 0)
                    {
                        string current_row = stream_reader.ReadLine() + "\n";
                        o_template_file_string = o_template_file_string + current_row;

                    } // while
                } // StreamReader
            } // try

            catch (FileNotFoundException) { o_error = "File not found"; return false; }
            catch (DirectoryNotFoundException) { o_error = error_message + "Directory not found"; return false; }
            catch (InvalidOperationException) { o_error = error_message + "Invalid operation"; return false; }
            catch (InvalidCastException) { o_error = error_message + "invalid cast"; return false; }
            catch (Exception e)
            {
                o_error = error_message + "Unhandled Exception " + e.GetType();
                return false;
            }

            return true;

        } // GetTemplateFileAsString

        #endregion Functions for document and web page HTM template files

        #region Replace strings

        /// <summary>Replace document template description in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_template">Template object JazzDocTemplate</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceDocumentTemplateDescription(ref string io_html_file_string, JazzDocTemplate i_template, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckJazzDocTemplate(i_template, out o_error))
                return false;

            string template_description = i_template.TemplateDescription;

            template_description = ReplaceNotAllowedCharacters(template_description);

            string find_string = HtmKeywords.GetFindStringDocumentTemplateDescription();

            string output_string = io_html_file_string.Replace(find_string, template_description);

            io_html_file_string = output_string;

            return true;

        } // ReplaceDocumentTemplateDescription

        /// <summary>Replace document title dialog in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_template">Template object JazzDocTemplate</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceDocumentDialogTitle(ref string io_html_file_string, JazzDocTemplate i_template, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckJazzDocTemplate(i_template, out o_error))
                return false;

            string dialog_title = i_template.TemplateDocumentDialogTitle;

            dialog_title = ReplaceNotAllowedCharacters(dialog_title);

            string find_string = HtmKeywords.GetFindStringDocumentDialogTitle();

            string output_string = io_html_file_string.Replace(find_string, dialog_title);

            io_html_file_string = output_string;

            return true;

        } // ReplaceDocumentDialogTitle

        /// <summary>Replace document title dialog in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_template">Template object JazzDocTemplate</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceDocumentSeasonYears(ref string io_html_file_string, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            string season_years = JazzXml.GetDocSeasonYears();

            string find_string = HtmKeywords.GetFindStringSeasonYears();

            string output_string = io_html_file_string.Replace(find_string, season_years);

            io_html_file_string = output_string;

            return true;

        } // ReplaceDocumentDialogTitle

        /// <summary>Replace band name in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceBandname(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            string band_name = JazzXml.GetBandName(i_concert_number);

            band_name = ReplaceNotAllowedCharacters(band_name);

            string find_string = HtmKeywords.GetFindStringBandName(i_concert_number);
                
            string output_string = io_html_file_string.Replace(find_string, band_name);

            io_html_file_string = output_string;

            return true;

        } // ReplaceBandname

        /// <summary>Replace band name in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceBandnameLoopIndex(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            string band_name = JazzXml.GetBandName(i_concert_number);

            band_name = ReplaceUndefinedString(band_name);

            // band_name = ReplaceNotAllowedCharacters(band_name);

            string find_string = HtmKeywords.GetFindStringBandNameLoopIndex();

            string output_string = io_html_file_string.Replace(find_string, band_name);

            io_html_file_string = output_string;

            return true;

        } // ReplaceBandnameLoopIndex

        /// <summary>Replace the concert date in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceConcertDate(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            // Don't understand why it is OK to do this here and then it works in all functions of this class
            // Maybe because some DocAdmin functions doing the same things was used? Try to take it away !!! But cannot harm anything to keep it 
            JazzXml.SetDocumentCurrent(m_season_document);
            JazzXml.SetCurrentSeasonFileUrl(); // Don't know if this is necessary

            string concert_year = JazzXml.GetYear(i_concert_number);
            string concert_month = JazzXml.GetMonth(i_concert_number);
            string concert_day = JazzXml.GetDay(i_concert_number);

            string concert_date = concert_year + @"-";
            if (concert_month.Length == 1)
            {
                concert_date = concert_date + @"0" + concert_month + @"-";
            }
            else
            {
                concert_date = concert_date + concert_month + @"-";
            }

            if (concert_day.Length == 1)
            {
                concert_date = concert_date + @"0" + concert_day;
            }
            else
            {
                concert_date = concert_date + concert_day;
            }

            string find_string = HtmKeywords.GetFindStringConcertDate(i_concert_number);

            string output_string = io_html_file_string.Replace(find_string, concert_date);

            io_html_file_string = output_string;

            return true;

        } // ReplaceConcertDate

        /// <summary>Replace the concert date in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceConcertDateLoopIndex(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            string day_name = JazzXml.GetDayName(i_concert_number);
            string concert_year = JazzXml.GetYear(i_concert_number);
            string concert_month = JazzXml.GetMonth(i_concert_number);
            string concert_day = JazzXml.GetDay(i_concert_number);
            string start_hour = JazzXml.GetStartHour(i_concert_number);
            string start_minute = JazzXml.GetStartMinute(i_concert_number);

            string concert_date = day_name + @" " + concert_year + @"-";
            if (concert_month.Length == 1)
            {
                concert_date = concert_date + @"0" + concert_month + @"-";
            }
            else
            {
                concert_date = concert_date + concert_month + @"-";
            }

            if (concert_day.Length == 1)
            {
                concert_date = concert_date + @"0" + concert_day;
            }
            else
            {
                concert_date = concert_date + concert_day;
            }

            concert_date = concert_date + @" " + start_hour + @":" + start_minute + @" h";

            string find_string = HtmKeywords.GetFindStringConcertDateLoopIndex();

            string output_string = io_html_file_string.Replace(find_string, concert_date);

            io_html_file_string = output_string;

            return true;

        } // ReplaceConcertDateLoopIndex

        /// <summary>Replace the concert date in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePremisesNameAddress(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            string concert_year = JazzXml.GetYear(i_concert_number);
            string concert_month = JazzXml.GetMonth(i_concert_number);
            string concert_day = JazzXml.GetDay(i_concert_number);

            string concert_date = concert_year + @".";
            if (concert_month.Length == 1)
            {
                concert_date = concert_date + @"0" + concert_month + @".";
            }
            else
            {
                concert_date = concert_date + concert_month + @".";
            }

            if (concert_day.Length == 1)
            {
                concert_date = concert_date + @"0" + concert_day;
            }
            else
            {
                concert_date = concert_date + concert_day;
            }

            string find_string = HtmKeywords.GetFindStringPremisesNameAddressLoopIndex();

            string output_string = io_html_file_string.Replace(find_string, concert_date);

            io_html_file_string = output_string;

            return true;

        } // ReplacePremisesNameAddress

        // GetFindStringPremisesNameAddressLoopIndex

        /// <summary>Replace the publish flag in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePublished(ref string io_html_file_string, int i_concert_number, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckJazzDoc(i_doc, out o_error))
                return false;

            string published_str = @"";
            if (i_doc.Published)
            {
                published_str = @"Ja";
            }
            else
            {
                published_str = @"Nein";
            }

            string find_string = HtmKeywords.GetFindStringPublished(i_concert_number);

            string output_string = io_html_file_string.Replace(find_string, published_str);

            io_html_file_string = output_string;

            return true;

        } // ReplacePublished

        /// <summary>Replace path file name DOC in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePathFileNameDoc(ref string io_html_file_string, int i_concert_number, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            if (!ReplacePathFileName("doc", ref io_html_file_string, i_concert_number, i_doc, out o_error))
                return false;

            return true;

        } // ReplacePathFileNameDoc

        /// <summary>Replace path file name XLS in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePathFileNameXls(ref string io_html_file_string, int i_concert_number, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            if (!ReplacePathFileName("xls", ref io_html_file_string, i_concert_number, i_doc, out o_error))
                return false;

            return true;

        } // ReplacePathFileNameXls

        /// <summary>Replace path file name PDF in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePathFileNamePdf(ref string io_html_file_string, int i_concert_number, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            if (!ReplacePathFileName("pdf", ref io_html_file_string, i_concert_number, i_doc, out o_error))
                return false;

            return true;

        } // ReplacePathFileNamePdf

        /// <summary>Replace path file name TXT in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePathFileNameTxt(ref string io_html_file_string, int i_concert_number, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            if (!ReplacePathFileName("txt", ref io_html_file_string, i_concert_number, i_doc, out o_error))
                return false;

            return true;

        } // ReplacePathFileNameTxt

        /// <summary>Replace path file name IMG in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePathFileNameImg(ref string io_html_file_string, int i_concert_number, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            if (!ReplacePathFileName("img", ref io_html_file_string, i_concert_number, i_doc, out o_error))
                return false;

            return true;

        } // ReplacePathFileNameImg

        /// <summary>Replace path file name Xxx in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_file_ext">File extension: doc, xls, pdf, txt or img</param>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        private static bool ReplacePathFileName(string i_file_ext, ref string io_html_file_string, int i_concert_number, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            if (!CheckPathFileInput(io_html_file_string, i_concert_number, i_doc, out o_error))
                return false;

            string file_name = @"";
            string find_string = @"";
            if (i_file_ext.Equals("doc"))
            {
                file_name = i_doc.FileNameDoc;
                find_string = HtmKeywords.GetFindStringPathFileNameDoc(i_concert_number);
            }
            else if (i_file_ext.Equals("xls"))
            {
                file_name = i_doc.FileNameXls;
                find_string = HtmKeywords.GetFindStringPathFileNameXls(i_concert_number);
            }
            else if (i_file_ext.Equals("pdf"))
            {
                file_name = i_doc.FileNamePdf;
                find_string = HtmKeywords.GetFindStringPathFileNamePdf(i_concert_number);
            }
            else if (i_file_ext.Equals("txt"))
            {
                file_name = i_doc.FileNameTxt;
                find_string = HtmKeywords.GetFindStringPathFileNameTxt(i_concert_number);
            }
            else if (i_file_ext.Equals("img"))
            {
                file_name = i_doc.FileNameImg;
                find_string = HtmKeywords.GetFindStringPathFileNameImg(i_concert_number);
            }
            else
            {
                o_error = @".ReplacePathFileName Not an implemented extension= " + i_file_ext;
                return false;
            }

            if (!ReplaceLink(ref io_html_file_string, file_name, find_string, i_doc, out o_error))
            {
                o_error = @"XmlToHtml.ReplacePathFileName ReplaceLink failed " + o_error;
                return false;
            }

            return true;

        } // ReplacePathFileName

        /// <summary>Replace link in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_file_name">File name</param>
        /// <param name="i_find_string">Find string</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        private static bool ReplaceLink(ref string io_html_file_string, string i_file_name, string i_find_string, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            string path_dir_concerts = JazzXml.GetDocDocumentsPath();

            string path_dir = i_doc.FilePath;

            string output_string = @"";

            if (!i_file_name.Equals(JazzXml.GetUndefinedNodeValue()))
            {
                string path_file_name_doc = @"../../" + path_dir_concerts + @"/" + path_dir + @"/" + i_file_name;

                output_string = io_html_file_string.Replace(i_find_string, path_file_name_doc);

                io_html_file_string = output_string;

                return true;
            }

            int index_find_string_start = io_html_file_string.IndexOf(i_find_string);

            int index_search_start = index_find_string_start - 20;

            int index_find_string_end = index_find_string_start + i_find_string.Length;

            string find_string_link_start = @"<A";

            string find_string_link_end = @"</A>";

            int index_remove_start = io_html_file_string.IndexOf(find_string_link_start, index_search_start);

            int index_remove_end = io_html_file_string.IndexOf(find_string_link_end, index_search_start) + find_string_link_end.Length;

            output_string = io_html_file_string.Remove(index_remove_start, index_remove_end - index_remove_start);

            string no_file = @"---";

            output_string = output_string.Insert(index_remove_start, no_file);

            io_html_file_string = output_string;

            return true;

        } // ReplaceLink

        /// <summary>Replace for any document
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_file_name">File name</param>
        /// <param name="i_find_string">Find string</param>
        /// <param name="i_file_type">Type equal to DOC, XLS, PDF, TXT or IMG</param>
        /// <param name="i_doc">The season JazzDoc object</param>
        private static void ReplaceAnyLinkDocument(ref string io_html_file_string, string i_file_name, string i_find_string, string i_file_type, JazzDoc i_doc  )
        {
            string path_dir = i_doc.FilePath;

            string path_file_name = @"../../" + path_dir + @"/" + i_file_name;
  
            string path_file_name_link = @"<A href='" + path_file_name + @"'>" + i_file_type + @"</A>";
            // <A href='JazzDokumenteSaison.PathSeasonFileNameLinkDoc'>DOC</A>

            if (i_file_name.Equals(JazzXml.GetUndefinedNodeValue()))
            {
                path_file_name_link = @"---";
            }

            string output_string = io_html_file_string.Replace(i_find_string, path_file_name_link);

            io_html_file_string = output_string;

        } // ReplaceAnyLinkDocument

        /// <summary>Replace path file name link DOC in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_doc">The season JazzDoc object</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePathFileNameLinkDoc(ref string io_html_file_string, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            string file_name = i_doc.FileNameDoc;
            string find_string = HtmKeywords.GetKeywordSeasonDocumentPathFileNameLinkDoc();

            ReplaceAnyLinkDocument(ref io_html_file_string, file_name, find_string, "DOC", i_doc);

            return true;

        } // ReplacePathFileNameLinkDoc   

        /// <summary>Replace path file name link XLS the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_doc">The season JazzDoc object</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePathFileNameLinkXls(ref string io_html_file_string, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            string file_name = i_doc.FileNameXls;
            string find_string = HtmKeywords.GetKeywordSeasonDocumentPathFileNameLinkXls();

            ReplaceAnyLinkDocument(ref io_html_file_string, file_name, find_string, "XLS", i_doc);

            return true;

        } // ReplacePathFileNameLinkXls   

        /// <summary>Replace path file name link PDF the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_doc">The season JazzDoc object</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePathFileNameLinkPdf(ref string io_html_file_string, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            string file_name = i_doc.FileNamePdf;
            string find_string = HtmKeywords.GetKeywordSeasonDocumentPathFileNameLinkPdf();

            ReplaceAnyLinkDocument(ref io_html_file_string, file_name, find_string, "PDF", i_doc);

            return true;

        } // ReplacePathFileNameLinkPdf   

        /// <summary>Replace path file name link TXT the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_doc">The season JazzDoc object</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePathFileNameLinkTxt(ref string io_html_file_string, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            string file_name = i_doc.FileNameTxt;
            string find_string = HtmKeywords.GetKeywordSeasonDocumentPathFileNameLinkTxt();

            ReplaceAnyLinkDocument(ref io_html_file_string, file_name, find_string, "TXT", i_doc);

            return true;

        } // ReplacePathFileNameLinkTxt   

        /// <summary>Replace path file name link IMG the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_doc">The season JazzDoc object</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePathFileNameLinkImg(ref string io_html_file_string, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            string file_name = i_doc.FileNameImg;
            string find_string = HtmKeywords.GetKeywordSeasonDocumentPathFileNameLinkImg();

            ReplaceAnyLinkDocument(ref io_html_file_string, file_name, find_string, "IMG", i_doc);

            return true;

        } // ReplacePathFileNameLinkImg   

        /// <summary>Replace the publish flag in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceSeasonPublish(ref string io_html_file_string, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckJazzDoc(i_doc, out o_error))
                return false;

            string published_str = @"";
            if (i_doc.Published)
            {
                published_str = @"Ja";
            }
            else
            {
                published_str = @"Nein";
            }

            string find_string = HtmKeywords.GetKeywordSeasonDocumentPublish();

            string output_string = io_html_file_string.Replace(find_string, published_str);

            io_html_file_string = output_string;

            return true;

        } // ReplaceSeasonPublish

        /// <summary>Replace the season header in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_header_html_file_string">HTML header string</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceSeasonHeader(ref string io_html_file_string, string i_header_html_file_string, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckString(i_header_html_file_string, out o_error))
                return false;

            string find_string = HtmKeywords.GetKeywordSeasonDocumentInsertHeader();

            string output_string = io_html_file_string.Replace(find_string, i_header_html_file_string);

            io_html_file_string = output_string;

            return true;

        } // ReplaceSeasonPublish

        /// <summary>Replace the season row in the input/output string that is the content of an HTML file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_row_html_file_string">HTML header string</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceSeasonRow(ref string io_html_file_string, string i_row_html_file_string, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckString(i_row_html_file_string, out o_error))
                return false;

            string find_string = HtmKeywords.GetKeywordSeasonDocumentInsertRow();

            string row_html_file_string_with_find_string = i_row_html_file_string + find_string;

            string output_string = io_html_file_string.Replace(find_string, row_html_file_string_with_find_string);

            io_html_file_string = output_string;

            return true;

        } // ReplaceSeasonPublish

        /// <summary>Remove add row
        /// <para></para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        public static void RemoveInsertRow(ref string io_html_file_string)
        {
            string find_string = HtmKeywords.GetKeywordSeasonDocumentInsertRow();

            string output_string = io_html_file_string.Replace(find_string, @"");

            io_html_file_string = output_string;

        } // ReplaceAnyLinkDocument

        /// <summary>Replace premises-name-address in the input/output string that is the content of an HTML file
        /// <para>The code is a C# copy of the Javascipt function PremisesNameAddress in the template file JazzProgramm.js</para>
        /// <para>Text is retrieved from class JazzXml with functions GetPremises, GetPremisesStreet and GetPremisesCity</para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplacePremisesNameAddress(ref string io_html_file_string,  out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            string premises_name = JazzXml.GetPremises();
            string premises_street = JazzXml.GetPremisesStreet();
            string premises_city = JazzXml.GetPremisesCity();
            premises_name = ReplaceUndefinedString(premises_name);
            premises_street = ReplaceUndefinedString(premises_street);
            premises_city = ReplaceUndefinedString(premises_city);

            string premises_street_city = premises_name + ", " + premises_street + ", " + premises_city;

            // premises_street_city = ReplaceNotAllowedCharacters(premises_street_city);

            string find_string = HtmKeywords.GetFindStringPremisesNameAddressLoopIndex();

            string output_string = io_html_file_string.Replace(find_string, premises_street_city);

            io_html_file_string = output_string;

            return true;

        } // ReplacePremisesNameAddress


        /// <summary>Replace ListMusiciansInstruments in the input/output string that is the content of an HTML file
        /// <para>The code is a C# copy of the Javascipt function ListMusiciansInstruments in the template file JazzProgramm.js</para>
        /// <para>Returns a string for a list of musicians and their instruments</para>
        /// <para>Text is retrieved from class JazzXml with functions GetMusicianName and GetMusicianInstrument</para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceListMusiciansInstruments(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            string list_musician_instrument = @"";

            int n_musicians = JazzXml.GetNumberMusicians(i_concert_number);
            for (int i_musician=1; i_musician<=n_musicians; i_musician++)
            {
                string musician_name = JazzXml.GetMusicianName(i_concert_number, i_musician);
                string musician_instrument = JazzXml.GetMusicianInstrument(i_concert_number, i_musician);

                musician_name = ReplaceUndefinedString(musician_name);
                musician_instrument = ReplaceUndefinedString(musician_instrument);

                // musician_name = ReplaceNotAllowedCharacters(musician_name);
                // musician_instrument = ReplaceNotAllowedCharacters(musician_instrument);

                list_musician_instrument = list_musician_instrument + musician_name + " " + musician_instrument + "<br>";
            }

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            string find_string = HtmKeywords.GetFindStringListMusiciansInstrumentsLoopIndex();

            string output_string = io_html_file_string.Replace(find_string, list_musician_instrument);

            io_html_file_string = output_string;


            return true;

        } // ReplaceListMusiciansInstruments

        /// <summary>Replace ShortText in the input/output string that is the content of an HTML file
        /// <para>Text is retrieved from class JazzXml with function GetShortText</para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceShortText(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            string short_text = JazzXml.GetShortText(i_concert_number);

            short_text = ReplaceUndefinedString(short_text);

            // short_text = ReplaceNotAllowedCharacters(short_text);

            string find_string = HtmKeywords.GetFindStringShortTextLoopIndex();

            string output_string = io_html_file_string.Replace(find_string, short_text);

            io_html_file_string = output_string;

            return true;

        } // ReplaceShortText

        /// <summary>Replace ListMusiciansTexts in the input/output string that is the content of an HTML file
        /// <para>The code is a C# copy of the Javascipt function ListMusiciansTexts in the template file JazzProgramm.js</para>
        /// <para>Returns a string with a list of musicians and texts</para>
        /// <para>Text is retrieved from class JazzXml with functions GetMusicianName and GetMusicianInstrument</para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceListMusiciansTexts(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            string list_musician_text = @"";

            int n_musicians = JazzXml.GetNumberMusicians(i_concert_number);
            for (int i_musician = 1; i_musician <= n_musicians; i_musician++)
            {
                string musician_name = JazzXml.GetMusicianName(i_concert_number, i_musician);
                string musician_text = JazzXml.GetMusicianText(i_concert_number, i_musician);

                musician_name = ReplaceUndefinedString(musician_name);
                musician_text = ReplaceUndefinedString(musician_text);

                // musician_name = ReplaceNotAllowedCharacters(musician_name);
               // musician_text = ReplaceNotAllowedCharacters(musician_text);

                if (musician_text.Length > 10)
                {
                    list_musician_text = list_musician_text +
                    "<b> <br>" + musician_name + "<br> </b> " +
                    musician_text + "<br>";
                }
            }

            string find_string = HtmKeywords.GetFindStringListMusiciansTextsLoopIndex();

            string output_string = io_html_file_string.Replace(find_string, list_musician_text);

            io_html_file_string = output_string;

            return true;

        } // ReplacePathFileNameImg

        /// <summary>Replace LinkBandWebsite in the input/output string that is the content of an HTML file
        /// <para>The code is a C# copy of the Javascipt function LinkBandWebsite in the template file JazzProgramm.js</para>
        /// <para>Returns a string that is a link to a band website</para>
        /// <para>Text is retrieved from class JazzXml with function GetBandWebsite</para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceLinkBandWebsite(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            string band_website_url = JazzXml.GetBandWebsite(i_concert_number);

            if (band_website_url.Length < 10)
            {
                o_error = @"";
                return true;
            }

            string band_website_url_link = "<a href=" + "'" + band_website_url + "'" +
                    " target=" + "'" + "_blank" + "'" + ">" +
                    "<img src=" + "'" + "../images/IconWWW.jpg"
                     + "'" + " alt=" + "'" + "Band Website" + "'"
                     + " height=" + "'" + "30" + "'" + " >"
                     + "</a>";


            string find_string = HtmKeywords.GetFindStringLinkBandWebsiteIndex();

            string output_string = io_html_file_string.Replace(find_string, band_website_url_link);

            io_html_file_string = output_string;

            return true;

        } // ReplaceLinkBandWebsite

        /// <summary>Replace LinkSoundSample in the input/output string that is the content of an HTML file
        /// <para>The code is a C# copy of the Javascipt function LinkSoundSample in the template file JazzProgramm.js</para>
        /// <para>Returns a string that is a link to a sound sample</para>
        /// <para>Text is retrieved from class JazzXml with function GetSoundSample</para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceLinkSoundSample(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            string sound_sample_url = JazzXml.GetSoundSample(i_concert_number);
            if (sound_sample_url.Length < 10)
            {
                o_error = @"";
                return true;
            }

            string sound_sample_url_link = "<a href=" + "'" + sound_sample_url + "'" +
                " target=" + "'" + "_blank" + "'" + ">" +
                 "<img src=" + "'" + "../images/IconVideo.jpg"
                 + "'" + " alt=" + "'" + "Band sound sample" + "'"
                                      + " height=" + "'" + "30" + "'" + " >"
                      + "</a>";

            string find_string = HtmKeywords.GetFindStringLinkSoundSampleLoopIndex();

            string output_string = io_html_file_string.Replace(find_string, sound_sample_url_link);

            io_html_file_string = output_string;

            return true;

        } // ReplaceLinkSoundSample

        /// <summary>Replace LinkSmallPosterNoPath in the input/output string that is the content of an HTML file
        /// <para>The Javascipt function LinkSmallPosterNoPath in the template file JazzProgramm.js could not be used here</para>
        /// <para>Returns the link string to a small poster</para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceLinkSmallPosterNoPath(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            string small_poster = JazzXml.GetPosterSmallSize(i_concert_number);
            if (small_poster.Length < 10)
            {
                o_error = @"";
                return true;
            }

            string concert_date = ConcertDate(i_concert_number);

            string small_poster_link = "<A href=" + "'" + "Konzert." + concert_date + ".Plakat.htm" + "'" + "><img src=" + "'" + @"../" + small_poster + "'" + " alt=" + "'" + "Plakat" + "'" + " width=" + "'" + "80" + "'" + ">  </A>";
            // <A href='Konzert.2017.03.18.Plakat.htm'><img src='../images/PlakatNewsletter20170318_Klein.jpg' alt='Plakat' width='80' > </A>

            string find_string = HtmKeywords.GetFindStringLinkSmallPosterNoPathLoopIndex();

            string output_string = io_html_file_string.Replace(find_string, small_poster_link);

            io_html_file_string = output_string;

            return true;

        } // ReplaceLinkSmallPosterNoPath

        /// <summary>Replace ImgPosterConcert in the input/output string that is the content of an HTML file
        /// <para>The code is a C# copy of the Javascipt function ImgPosterConcert in the template file JazzProgramm.js</para>
        /// <para>Returns the image string for a poster</para>
        /// <para>Text is retrieved from class JazzXml with function GetPosterMidSize</para>
        /// </summary>
        /// <param name="io_html_file_string">Input and output string with content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        public static bool ReplaceLinkImgPosterConcert(ref string io_html_file_string, int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (!CheckString(io_html_file_string, out o_error))
                return false;

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            string small_poster = JazzXml.GetPosterSmallSize(i_concert_number);
            if (small_poster.Length < 10)
            {
                o_error = @"";
                return true;
            }

            string concert_poster_path_and_name = JazzXml.GetPosterMidSize(i_concert_number);

           string concert_poster_image = "<img src=" + "'" + concert_poster_path_and_name + "'" + " alt=" + "'" + "Plakat" + "'" + " width=" + "'" + "380" + "'" + " >";

            // Full path above and not relative .... <img src='../images/PlakatNewsletter20170318.jpg' alt='Plakat' width='380' >

            string find_string = HtmKeywords.GetFindStringImgPosterConcertLoopIndex();

            string output_string = io_html_file_string.Replace(find_string, concert_poster_image);

            io_html_file_string = output_string;

            return true;

        } // ReplaceLinkImgPosterConcert

        /// <summary>Returns concert date in the form yyyy.mm.dd
        /// <para>Text is retrieved from class JazzXml with functions GetYear, GetMonth and GetDay</para>
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        public static string ConcertDate(int i_concert_number)
        {
            string error_message = @"";

            if (!CheckConcertNumber(i_concert_number, out error_message))
                return @"";

            string concert_year = JazzXml.GetYear(i_concert_number);
            string concert_month = JazzXml.GetMonth(i_concert_number);
            string concert_day = JazzXml.GetDay(i_concert_number);

            string concert_date = concert_year + @".";
            if (concert_month.Length == 1)
            {
                concert_date = concert_date + @"0" + concert_month + @".";
            }
            else
            {
                concert_date = concert_date + concert_month + @".";
            }

            if (concert_day.Length == 1)
            {
                concert_date = concert_date + @"0" + concert_day;
            }
            else
            {
                concert_date = concert_date + concert_day;
            }

            return concert_date;

        } // ConcertDate

        /// <summary>Check input to PathFileXxx files
        /// <para></para>
        /// </summary>
        /// <param name="i_html_file_string">String that is the content of an HTML file</param>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="i_doc">The JazzDoc object for the given concert number and for the given document (defined by the template name)</param>
        /// <param name="o_error">Error description</param>
        private static bool CheckPathFileInput(string i_html_file_string, int i_concert_number, JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            if (!CheckConcertNumber(i_concert_number, out o_error))
                return false;

            if (!CheckString(i_html_file_string, out o_error))
                return false;

            if (!CheckJazzDoc(i_doc, out o_error))
                return false;

            return true;
        } // CheckPathFileInput

        /// <summary>Replace not allowed characters
        /// <para>This is a workaround. The right solution would be to change the 'Kodierung' to UTF-8 for the created HTM file</para>
        /// <para>Characters ä, ü, ö, and é are replaced</para>
        /// </summary>
        /// <param name="i_text_string">Input and output string</param>
        private static string ReplaceNotAllowedCharacters(string i_text_string)
        {
            string output_str = i_text_string;

            string find_string = @"ä";

            output_str = output_str.Replace(find_string, @"ae");

            find_string = @"Ä";

            output_str = output_str.Replace(find_string, @"AE");

            find_string = @"ü";

            output_str = output_str.Replace(find_string, @"ue");

            find_string = @"Ü";

            output_str = output_str.Replace(find_string, @"UE");

            find_string = @"ö";

            output_str = output_str.Replace(find_string, @"oe");

            find_string = @"Ö";

            output_str = output_str.Replace(find_string, @"OE");

            find_string = @"é";

            output_str = output_str.Replace(find_string, @"e");

            return output_str;

        } // ReplaceNotAllowedCharacters

        /// <summary>Replace undefined string
        /// <para>Undefined string is defined by JazzXml.GetUndefinedNodeValue()</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_text_string">Input and output string</param>
        private static string ReplaceUndefinedString(string i_text_string)
        {
            string output_str = i_text_string;

            string undefined_string = JazzXml.GetUndefinedNodeValue();

            if (undefined_string.Equals(i_text_string))
            {
                output_str = @"";
            }
 
            return output_str;

        } // ReplaceUndefinedString

        /// <summary>Check that concert number is greater than null (0)
        /// <para></para>
        /// </summary>
        /// <param name="i_concert_number">Concert number</param>
        /// <param name="o_error">Error description</param>
        private static bool CheckConcertNumber(int i_concert_number, out string o_error)
        {
            o_error = @"";

            if (i_concert_number <= 0)
            {
                o_error = @"XmlToHtml.CheckConcertNumber Concert number " + i_concert_number.ToString() + @" <= 0";
                return false;
            }

            return true;
        } // CheckConcertNumber

        /// <summary>Check that the input string nicht is null or has less than ten characters
        /// <para></para>
        /// </summary>
        /// <param name="i_html_file_string">Content of an HTM file</param>
        /// <param name="o_error">Error description</param>
        private static bool CheckString(string i_html_file_string, out string o_error)
        {
            o_error = @"";

            if (i_html_file_string == null || i_html_file_string.Length < 10)
            {
                o_error = @"XmlToHtml.CheckString Less that ten characters in input string";
                return false;
            }

            return true;
        } // CheckString

        /// <summary>Check that template object not is null
        /// <para></para>
        /// </summary>
        /// <param name="i_template">Input JazzDocTemplate</param>
        /// <param name="o_error">Error description</param>
        private static bool CheckJazzDocTemplate(JazzDocTemplate i_template, out string o_error)
        {
            o_error = @"";

            if (null == i_template)
            {
                o_error = @"XmlToHtml.CheckJazzDocTemplate Template object is null";
                return false;
            }

            return true;
        } // CheckJazzDocTemplate

        /// <summary>Check that template object not is null
        /// <para></para>
        /// </summary>
        /// <param name="i_template">Input JazzDocTemplate</param>
        /// <param name="o_error">Error description</param>
        private static bool CheckJazzDoc(JazzDoc i_doc, out string o_error)
        {
            o_error = @"";

            if (null == i_doc)
            {
                o_error = @"XmlToHtml.CheckJazzDocTemplate JazzDoc object is null";
                return false;
            }

            return true;
        } // CheckJazzDoc

        #endregion // Replace strings

        #region Upload document and concert HTML file to the server

        /// <summary>Upload document HTM file to the server
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_local_file_with_path">Full name of local HTM file</param>
        /// <param name="i_htm_file_string">Input string that will be the content of the HTM file</param>
        /// <param name="o_error">Error description</param>
        public static bool UploadDocumentHtmlToServer(string i_local_file_with_path, string i_htm_file_string, out string o_error)
        {
            o_error = @"";

            if (!CheckString(i_local_file_with_path, out o_error))
                return false;
            if (!CheckString(i_htm_file_string, out o_error))
                return false;

            string error_message = @"";

            if (!CreateLocalHtmlFile(i_local_file_with_path, i_htm_file_string, out error_message))
            {
                o_error = @"XmlToHtml.UploadDocumentHtmlToServer " + error_message;
                return false;
            }

            UpLoad htpp_upload = new UpLoad();

            string file_name = Path.GetFileName(i_local_file_with_path);
            string file_server_url = HtmVorlagen.GetFullServerDocumentHtmlFileName(file_name);
            bool to_www = true;
  
            if (!htpp_upload.OneFile(to_www, file_server_url, i_local_file_with_path, out o_error))
            {
                o_error = "XmlToHtml.UploadDocumentHtmlToServer Upload.OneFile failed: " + o_error;
                return false;
            }

            return true;

        } // UploadDocumentHtmlToServer

        /// <summary>Create local HTM file
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_local_file_with_path">Full name of local HTM file</param>
        /// <param name="i_htm_file_string">Input string that will be the content of the HTM file</param>
        /// <param name="o_error">Error description</param>
        private static bool CreateLocalHtmlFile(string i_local_file_with_path, string i_htm_file_string, out string o_error)
        {
            o_error = @"";

            if (!CheckString(i_local_file_with_path, out o_error))
                return false;
            if (!CheckString(i_htm_file_string, out o_error))
                return false;

            File.WriteAllText(i_local_file_with_path, i_htm_file_string, Encoding.UTF8);

            return true;
        } // CreateLocalHtmlFile

        /// <summary>Upload concert HTM file to the server
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_local_file_with_path">Full name of local HTM file</param>
        /// <param name="i_htm_file_string">Input string that will be the content of the HTM file</param>
        /// <param name="o_error">Error description</param>
        public static bool UploadConcertHtmlToServer(string i_local_file_with_path, string i_htm_file_string, out string o_error)
        {
            o_error = @"";

            if (!CheckString(i_local_file_with_path, out o_error))
                return false;
            if (!CheckString(i_htm_file_string, out o_error))
                return false;

            string error_message = @"";

            if (!CreateLocalHtmlFile(i_local_file_with_path, i_htm_file_string, out error_message))
            {
                o_error = @"XmlToHtml.UploadConcertHtmlToServer " + error_message;
                return false;
            }

            UpLoad htpp_upload = new UpLoad();

            string file_name = Path.GetFileName(i_local_file_with_path);
            string file_server_url = HtmVorlagen.GetFullServerConcertHtmlFileName(file_name);
            bool to_www = true;

            if (!htpp_upload.OneFile(to_www, file_server_url, i_local_file_with_path, out o_error))
            {
                o_error = "XmlToHtml.UploadConcertHtmlToServer Upload.OneFile failed: " + o_error;
                return false;
            }

            return true;

        } // UploadConcertHtmlToServer

        #endregion // Upload document and concert HTML file to the server

    } // XmlToHtml

} // namespace
