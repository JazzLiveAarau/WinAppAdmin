using JazzApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Utility functions for the JazzAppAdmin document classes</summary>
    public static class DocAdminUtil
    {
        /// <summary>Writes all XML data for a season document.</summary>
        static public bool WriteSeasonDoc(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            if (null == i_doc_data)
            {
                o_error = @"DocAdminUtil.WriteSeasonDoc m_doc_data is not set";
                return false;
            }

            if (!JazzXml.SetSeasonDoc(i_doc_data, i_doc_data.TemplateName, out o_error))
            {
                return false;
            }

            return true;

        } // WriteSeasonDoc


        #region Get data from object JazzDoc

        /// <summary>Returns the template name</summary>
        /// <param name="i_doc_data">Document data</param>
        static public string GetTemplateName(JazzDoc i_doc_data) { return AdminUtils.RemoveXmlUndefinedValue(i_doc_data.TemplateName); }

        /// <summary>Returns the file path</summary>
        /// <param name="i_doc_data">Document data</param>
        static public string GetFilePath(JazzDoc i_doc_data) { return AdminUtils.RemoveXmlUndefinedValue(i_doc_data.FilePath); }

        /// <summary>Returns the file name doc</summary>
        /// <param name="i_doc_data">Document data</param>
        static public string GetFileNameDoc(JazzDoc i_doc_data) { return AdminUtils.RemoveXmlUndefinedValue(i_doc_data.FileNameDoc); }

        /// <summary>Returns the file name xls</summary>
        /// <param name="i_doc_data">Document data</param>
        static public string GetFileNameXls(JazzDoc i_doc_data) { return AdminUtils.RemoveXmlUndefinedValue(i_doc_data.FileNameXls); }

        /// <summary>Returns the file name pdf</summary>
        /// <param name="i_doc_data">Document data</param>
        static public string GetFileNamePdf(JazzDoc i_doc_data) { return AdminUtils.RemoveXmlUndefinedValue(i_doc_data.FileNamePdf); }

        /// <summary>Returns the file name txt</summary>
        /// <param name="i_doc_data">Document data</param>
        static public string GetFileNameTxt(JazzDoc i_doc_data) { return AdminUtils.RemoveXmlUndefinedValue(i_doc_data.FileNameTxt); }

        /// <summary>Returns the file name img</summary>
        /// <param name="i_doc_data">Document data</param>
        static public string GetFileNameImg(JazzDoc i_doc_data) { return AdminUtils.RemoveXmlUndefinedValue(i_doc_data.FileNameImg); }

        /// <summary>Returns the flag telling if the document can be published</summary>
        /// <param name="i_doc_data">Document data</param>
        static public bool GetPublished(JazzDoc i_doc_data) { return i_doc_data.Published; }

        #endregion // Get data from object JazzDoc

        #region Get data from object JazzDocTemplate

        /// <summary>Returns the template name</summary>
        /// <param name="i_doc_template">Document template data</param>
        static public string GetTemplateDescription(JazzDocTemplate i_doc_template) { return AdminUtils.RemoveXmlUndefinedValue(i_doc_template.TemplateDescription); }

        #endregion // Get data from object JazzDocTemplate

        /// <summary>Returns the season years</summary>
        static public string GetDocSeasonYears() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetDocSeasonYears()); }

        /// <summary>
        /// Returns the autumn (start) year. The year is retrieved from GetDocSeasonYears
        /// </summary>
        /// <returns>Autumn year as integer. Negative value for failure</returns>
        static public int GetDocAutumnYearInt()
        {
            int ret_autumn_year_int = -12345;

            string season_years = GetDocSeasonYears();

            if (season_years.Length != 9)
            {
                ret_autumn_year_int = -1;

                return ret_autumn_year_int;
            }

            string autumn_year = season_years.Substring(0, 4);

            ret_autumn_year_int = JazzUtils.StringToInt(autumn_year);

            return ret_autumn_year_int;

        } // GetDocAutumnYearInt

        #region Construct and set file names of object JazzDoc

        /// <summary>Construct and sets the DOC file name</summary>
        static public bool ConstructAndSetFileNameDoc(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            string file_name_no_extension = ConstructFileNameNoExtension(i_doc_data, out error_message);
            if (file_name_no_extension.Length == 0)
            {
                o_error = error_message;
                return false;
            }

            // The case .doc is handled by OpenSaveDialog.Upload
            i_doc_data.FileNameDoc = file_name_no_extension + ".docx";

            return true;
        } // ConstructAndSetFileNameDoc

        /// <summary>Construct and sets the XLS file name</summary>
        static public bool ConstructAndSetFileNameXls(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            string file_name_no_extension = ConstructFileNameNoExtension(i_doc_data, out error_message);
            if (file_name_no_extension.Length == 0)
            {
                o_error = error_message;
                return false;
            }

            // The case .doc is handled by OpenSaveDialog.Upload
            i_doc_data.FileNameXls = file_name_no_extension + ".xlsx";

            return true;
        } // ConstructAndSetFileNameXls


        /// <summary>Construct and sets the PDF file name</summary>
        static public bool ConstructAndSetFileNamePdf(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            string file_name_no_extension = ConstructFileNameNoExtension(i_doc_data, out error_message);
            if (file_name_no_extension.Length == 0)
            {
                o_error = error_message;
                return false;
            }

            i_doc_data.FileNamePdf = file_name_no_extension + ".pdf";

            return true;
        } // ConstructAndSetFileNamePdf


        /// <summary>Construct and sets the TXT file name</summary>
        static public bool ConstructAndSetFileNameTxt(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            string file_name_no_extension = ConstructFileNameNoExtension(i_doc_data, out error_message);
            if (file_name_no_extension.Length == 0)
            {
                o_error = error_message;
                return false;
            }

            i_doc_data.FileNameTxt = file_name_no_extension + ".txt";

            return true;
        } // ConstructAndSetFileNameTxt

        /// <summary>Construct and sets the IMG file name</summary>
        static public bool ConstructAndSetFileNameImg(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            string error_message = @"";
            string file_name_no_extension = ConstructFileNameNoExtension(i_doc_data, out error_message);
            if (file_name_no_extension.Length == 0)
            {
                o_error = error_message;
                return false;
            }

            i_doc_data.FileNameImg = file_name_no_extension + ".jpg";

            return true;
        } // ConstructAndSetFileNameImg

        /// <summary>Construct the file name without extension and checks also that m_doc_data is set</summary>
        static public string ConstructFileNameNoExtension(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            if (null == i_doc_data)
            {
                o_error = @"DocAdminUtil.ConstructFileNameNoExtension i_doc_data is not set";
                return "";
            }

            string template_name = GetTemplateName(i_doc_data);

            if (template_name.Contains("PATH_"))
            {
                string documents_path = GetFilePath(i_doc_data);
                if (documents_path.Length == 0)
                {
                    o_error = @"DocAdminUtil.ConstructFileNameNoExtension: Documents path is not set";
                    return "";
                }

                string path_replaced = template_name.Replace("PATH_", documents_path + "_");

                return path_replaced;
            }

            string season_years = GetDocSeasonYears();

            string underscore_season_years = season_years.Replace("-", "_");

            return template_name + underscore_season_years;

        } // ConstructFileNameNoExtension

        #endregion // Construct and set file names of object JazzDoc

        #region Set file names of object JazzDoc

        /// <summary>Sets the DOC file name</summary>
        static public bool SetFileNameDoc(JazzDoc i_doc_data, string i_file_name_doc, out string o_error)
        {
            o_error = @"";

            string extension = Path.GetExtension(i_file_name_doc);

            if (extension.Equals(".doc") || extension.Equals(".docx"))
            {
                i_doc_data.FileNameDoc = i_file_name_doc;

                return true;
            }

            o_error = @"Programming error SetFileNameDoc: Extension not doc or docx but " + extension;

            return false;

        } // SetFileNameDoc

        /// <summary>Sets the XLS file name</summary>
        static public bool SetFileNameXls(JazzDoc i_doc_data, string i_file_name_doc, out string o_error)
        {
            o_error = @"";

            string extension = Path.GetExtension(i_file_name_doc);

            if (extension.Equals(".xls") || extension.Equals(".xlsx"))
            {
                i_doc_data.FileNameXls = i_file_name_doc;

                return true;
            }

            o_error = @"Programming error SetFileNameXls: Extension not xls or xlsx but " + extension;

            return false;

        } // SetFileNameXls

        /// <summary>Sets the PDF file name of JazzDoc</summary>
        static public bool SetFileNamePdf(JazzDoc i_doc_data, string i_file_name_pdf, out string o_error)
        {
            o_error = @"";

            string extension = Path.GetExtension(i_file_name_pdf);

            if (extension.Equals(".pdf"))
            {
                i_doc_data.FileNamePdf = i_file_name_pdf;

                return true;
            }

            o_error = @"Programming error SetFileNamePdf: Extension not pdf but " + extension;

            return false;

        } // SetFileNamePdf

        /// <summary>Sets the TXT file name of JazzDoc</summary>
        static public bool SetFileNameTxt(JazzDoc i_doc_data, string i_file_name_txt, out string o_error)
        {
            o_error = @"";

            string extension = Path.GetExtension(i_file_name_txt);

            if (extension.Equals(".pdf"))
            {
                i_doc_data.FileNameTxt = i_file_name_txt;

                return true;
            }

            o_error = @"Programming error SetFileNameTxt: Extension not txt but " + extension;

            return false;

        } // SetFileNameTxt

        /// <summary>Sets the IMG file name of JazzDoc</summary>
        static public bool SetFileNameImg(JazzDoc i_doc_data, string i_file_name_img, out string o_error)
        {
            o_error = @"";

            string extension = Path.GetExtension(i_file_name_img);

            if (extension.Equals(".jpg") || extension.Equals(".JPG"))
            {
                i_doc_data.FileNameImg = i_file_name_img;

                return true;
            }

            o_error = @"Programming error SetFileNameTxt: Extension not jpg or JPG but " + extension;

            return false;

        } // SetFileNameImg

        #endregion // Set file names of object JazzDoc

        #region Delete file names in object JazzDoc

        /// <summary>Erase the DOC file name</summary>
        static public bool DeleteFileNameDoc(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            if (null == i_doc_data)
            {
                o_error = @"DocProgram.DeleteFileNameDoc m_doc_data is not set";
                return false;
            }

            i_doc_data.FileNameDoc = @"";

            return true;

        } // DeleteFileNameDoc

        /// <summary>Erase the XLS file name</summary>
        static public bool DeleteFileNameXls(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            if (null == i_doc_data)
            {
                o_error = @"DocProgram.DeleteFileNameXls m_doc_data is not set";
                return false;
            }

            i_doc_data.FileNameXls = @"";

            return true;

        } // DeleteFileNameXls

        /// <summary>Erase the PDF file name</summary>
        static public bool DeleteFileNamePdf(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            if (null == i_doc_data)
            {
                o_error = @"DocProgram.DeleteFileNameDoc m_doc_data is not set";
                return false;
            }

            i_doc_data.FileNamePdf = @"";

            return true;

        } // DeleteFileNamePdf

        /// <summary>Erase the TXT file name</summary>
        static public bool DeleteFileNameTxt(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            if (null == i_doc_data)
            {
                o_error = @"DocProgram.DeleteFileNameDoc m_doc_data is not set";
                return false;
            }

            i_doc_data.FileNameTxt = @"";

            return true;

        } // DeleteFileNameTxt

        /// <summary>Erase the IMG file name</summary>
        static public bool DeleteFileNameImg(JazzDoc i_doc_data, out string o_error)
        {
            o_error = @"";

            if (null == i_doc_data)
            {
                o_error = @"DocProgram.DeleteFileNameImg m_doc_data is not set";
                return false;
            }

            i_doc_data.FileNameImg = @"";

            return true;

        } // DeleteFileNameImg

        #endregion // Delete file names in object JazzDoc

    } // DocAdminUtil

} // namespace
