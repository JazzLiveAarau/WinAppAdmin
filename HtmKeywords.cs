using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>The class HtmKeywords defines HTM template keywords used for the creation of XML to HTM files
    /// <para>For each type of XML file there is a string array with keywords:</para>
    /// <para>- m_keywords_jazz_dokument for XML file JazzDokumente.xml</para>
    /// <para>- m_keywords_jazz_saison_dokument for XML file JazzDokumente_20xx_20yy.xml</para>
    /// <para>- m_keywords_jazz_saison_program for XML file JazzProgramm_20xx_20yy.xml</para>
    /// <para></para>
    /// <para>There are get functions for all keywords and for keywords with concert number there are "find string" functions.</para>
    /// </summary>
    public static class HtmKeywords
    {
        #region Keywords corresponding to XML file JazzDokument.xml

        /// <summary>Defines the HTM keywords array corresponding to XML file JazzDokumente.xml
        /// <para>The array corresponds to array m_text_tags_template in class JazzXml.JazzXmlTags</para>
        /// <para>The keyword names are the same as in m_text_tags_template but preceeded by 'JazzDokumente.'</para>
        /// <para>For each keyword there is a get function: GetKeywordDocumentTemplateDescription, GetKeywordDocumentDocumentDialogTitle, ...</para>
        /// </summary>
        static private string[] m_keywords_jazz_dokument =
        {
            @"JazzDokumente.TemplateDescription", // 0 
            @"JazzDokumente.DocumentDialogTitle", // 1

        }; // m_keywords_jazz_dokumente

        /// <summary>Returns the keyword string for TemplateDescription corresponding to the XML tag name in thr array JazzXml.m_text_tags_template</summary>
        static public string GetKeywordDocumentTemplateDescription() { return m_keywords_jazz_dokument[0]; }
        /// <summary>Returns the keyword string for DocumentDialogTitle corresponding to the XML tag name in the array JazzXml.m_text_tags_template</summary>
        static public string GetKeywordDocumentDocumentDialogTitle() { return m_keywords_jazz_dokument[1]; }

        /// <summary>Returns find string for document template description</summary>
        static public string GetFindStringDocumentTemplateDescription() { return GetKeywordDocumentTemplateDescription(); }
        /// <summary>Returns find string for document dialog title</summary>
        static public string GetFindStringDocumentDialogTitle() { return GetKeywordDocumentDocumentDialogTitle(); }

        #endregion // Keywords corresponding to XML file JazzDokument.xml

        #region Keywords corresponding to XML file JazzDokument_20xx_20yy.xml

        /// <summary>Defines the HTM keywords array corresponding to XML file JazzDokumente.xml
        /// <para>The array corresponds to the arrays m_text_tags_doc_season and xxx in class JazzXml.JazzXmlTags</para>
        /// <para>The keyword names are the same as in m_text_tags_template but preceeded by 'JazzDokumenteSaison.'</para>
        /// <para>For each keyword there is a get function: GetKeywordSeasonDocumentSeasonYears, GetKeywordSeasonDocumentFileNameDoc, ...</para>
        /// </summary>
        static private string[] m_keywords_jazz_saison_dokument =
        {
            @"JazzDokumenteSaison.SeasonYears", // 0 
            @"JazzDokumenteSaison.FileNameDoc", // 1
            @"JazzDokumenteSaison.FileNameXls", // 2
            @"JazzDokumenteSaison.FileNamePdf", // 3
            @"JazzDokumenteSaison.FileNameTxt", // 4
            @"JazzDokumenteSaison.FileNameImg", // 5
            @"JazzDokumenteSaison.Published", // 6
            @"JazzDokumenteSaison.DocumentsPath", // 7
            @"JazzDokumenteSaison.PathFileNameDoc", // 8
            @"JazzDokumenteSaison.PathFileNameXls", // 9
            @"JazzDokumenteSaison.PathFileNamePdf", // 10
            @"JazzDokumenteSaison.PathFileNameTxt", // 11
            @"JazzDokumenteSaison.PathFileNameImg", // 12
            @"JazzDokumenteSaison.PathFileNameLinkDoc", // 13
            @"JazzDokumenteSaison.PathFileNameLinkXls", // 14
            @"JazzDokumenteSaison.PathFileNameLinkPdf", // 15
            @"JazzDokumenteSaison.PathFileNameLinkTxt", // 16
            @"JazzDokumenteSaison.PathFileNameLinkImg", // 17
            @"JazzDokumenteSaison.Publish", // 18
            @"JazzDokumenteSaison.InsertHeader", // 19
            @"JazzDokumenteSaison.InsertRow", // 20

            // 

        }; // m_keywords_jazz_saison_dokumente

        /// <summary>Returns the keyword string for SeasonYears corresponding to the XML tag name in the array JazzXml.m_text_tags_doc_season</summary>
        static public string GetKeywordSeasonDocumentSeasonYears() { return m_keywords_jazz_saison_dokument[0]; }
        /// <summary>Returns the keyword string for FileNameDoc corresponding to the XML tag name in the array JazzXml.m_text_tags_doc_season</summary>
        static public string GetKeywordSeasonDocumentFileNameDoc() { return m_keywords_jazz_saison_dokument[1]; }
        /// <summary>Returns the keyword string for FileNameDoc corresponding to the XML tag name in the array JazzXml.m_text_tags_doc_season</summary>
        static public string GetKeywordSeasonDocumentFileNameXls() { return m_keywords_jazz_saison_dokument[2]; }
        /// <summary>Returns the keyword string for FileNameXls corresponding to the XML tag name in the array JazzXml.m_text_tags_doc_season</summary>
        static public string GetKeywordSeasonDocumentFileNamePdf() { return m_keywords_jazz_saison_dokument[3]; }
        /// <summary>Returns the keyword string for FileNamePdf corresponding to the XML tag name in the array JazzXml.m_text_tags_doc_season</summary>
        static public string GetKeywordSeasonDocumentFileNameTxt() { return m_keywords_jazz_saison_dokument[4]; }
        /// <summary>Returns the keyword string for FileNameImg corresponding to the XML tag name in the array JazzXml.m_text_tags_doc_season</summary>
        static public string GetKeywordSeasonDocumentFileNameImg() { return m_keywords_jazz_saison_dokument[5]; }
        /// <summary>Returns the keyword string for Published corresponding to the XML tag name in the array JazzXml.m_text_tags_doc_season</summary>
        static public string GetKeywordSeasonDocumentPublished() { return m_keywords_jazz_saison_dokument[6]; }
        /// <summary>Returns the keyword string for DocumentsPath corresponding to the XML tag name in the array JazzXml.m_text_tags_doc_season</summary>
        static public string GetKeywordSeasonDocumentDocumentsPath() { return m_keywords_jazz_saison_dokument[7]; }
        static public string GetKeywordSeasonDocumentPathFileNameDoc() { return m_keywords_jazz_saison_dokument[8]; }
        /// <summary>Returns the keyword string for PathFileNameDoc </summary>
        static public string GetKeywordSeasonDocumentPathFileNameXls() { return m_keywords_jazz_saison_dokument[8]; }
        /// <summary>Returns the keyword string for PathFileNameXls</summary>
        static public string GetKeywordSeasonDocumentPathFileNamePdf() { return m_keywords_jazz_saison_dokument[10]; }
        /// <summary>Returns the keyword string for PathFileNamePdf</summary>
        static public string GetKeywordSeasonDocumentPathFileNameTxt() { return m_keywords_jazz_saison_dokument[11]; }
        /// <summary>Returns the keyword string for PathFileNameImg</summary>
        static public string GetKeywordSeasonDocumentPathFileNameImg() { return m_keywords_jazz_saison_dokument[12]; }
        /// <summary>Returns the keyword string for PathFileNameLinkDoc </summary>
        static public string GetKeywordSeasonDocumentPathFileNameLinkDoc() { return m_keywords_jazz_saison_dokument[13]; }
        /// <summary>Returns the keyword string for PathFileNameLinkDoc </summary>
        static public string GetKeywordSeasonDocumentPathFileNameLinkXls() { return m_keywords_jazz_saison_dokument[14]; }
        /// <summary>Returns the keyword string for PathFileNameLinkXls</summary>
        static public string GetKeywordSeasonDocumentPathFileNameLinkPdf() { return m_keywords_jazz_saison_dokument[15]; }
        /// <summary>Returns the keyword string for PathFileNameLinkPdf</summary>
        static public string GetKeywordSeasonDocumentPathFileNameLinkTxt() { return m_keywords_jazz_saison_dokument[16]; }
        /// <summary>Returns the keyword string for PathFileNameLinkImg</summary>
        static public string GetKeywordSeasonDocumentPathFileNameLinkImg() { return m_keywords_jazz_saison_dokument[17]; }
        /// <summary>Returns the keyword string for Publish</summary>
        static public string GetKeywordSeasonDocumentPublish() { return m_keywords_jazz_saison_dokument[18]; }
        /// <summary>Returns the keyword string for InsertHeader</summary>
        static public string GetKeywordSeasonDocumentInsertHeader() { return m_keywords_jazz_saison_dokument[19]; }
        /// <summary>Returns the keyword string for InsertRow</summary>
        static public string GetKeywordSeasonDocumentInsertRow() { return m_keywords_jazz_saison_dokument[20]; }

        /// <summary>Returns find string for season years</summary>
        static public string GetFindStringSeasonYears() { return GetKeywordSeasonDocumentSeasonYears(); }
        /// <summary>Returns find string for season years</summary>
        static public string GetFindStringDocumentsPath() { return GetKeywordSeasonDocumentDocumentsPath(); }
        /// <summary>Returns find string for published for a given concert number.</summary>
        static public string GetFindStringPublished(int i_concert_number) { return GetKeywordSeasonDocumentPublished() + FindStringNumber(i_concert_number); }

        /// <summary>Returns find string for a file name DOC for a given concert number.</summary>
        static public string GetFindStringFileNameDoc(int i_concert_number) { return GetKeywordSeasonDocumentFileNameDoc() + FindStringNumber(i_concert_number); }
        /// <summary>Returns find string for a file name XLS for a given concert number.</summary>
        static public string GetFindStringFileNameXls(int i_concert_number) { return GetKeywordSeasonDocumentFileNameXls() + FindStringNumber(i_concert_number); }
        /// <summary>Returns find string for a file name PDF for a given concert number.</summary>
        static public string GetFindStringFileNamePdf(int i_concert_number) { return GetKeywordSeasonDocumentFileNamePdf() + FindStringNumber(i_concert_number); }
        /// <summary>Returns find string for a file name TXT for a given concert number.</summary>
        static public string GetFindStringFileNameTxt(int i_concert_number) { return GetKeywordSeasonDocumentFileNameTxt() + FindStringNumber(i_concert_number); }
        /// <summary>Returns find string for a file name IMG for a given concert number.</summary>
        static public string GetFindStringFileNameImg(int i_concert_number) { return GetKeywordSeasonDocumentFileNameImg() + FindStringNumber(i_concert_number); }

        /// <summary>Returns find string for a path file name DOC for a given concert number.</summary>
        static public string GetFindStringPathFileNameDoc(int i_concert_number) { return GetKeywordSeasonDocumentPathFileNameDoc() + FindStringNumber(i_concert_number); }
        /// <summary>Returns find string for a path file name XLS for a given concert number.</summary>
        static public string GetFindStringPathFileNameXls(int i_concert_number) { return GetKeywordSeasonDocumentPathFileNameXls() + FindStringNumber(i_concert_number); }
        /// <summary>Returns find string for a path file name PDF for a given concert number.</summary>
        static public string GetFindStringPathFileNamePdf(int i_concert_number) { return GetKeywordSeasonDocumentPathFileNamePdf() + FindStringNumber(i_concert_number); }
        /// <summary>Returns find string for a path file name TXT for a given concert number.</summary>
        static public string GetFindStringPathFileNameTxt(int i_concert_number) { return GetKeywordSeasonDocumentPathFileNameTxt() + FindStringNumber(i_concert_number); }
        /// <summary>Returns find string for a path file name IMG for a given concert number.</summary>
        static public string GetFindStringPathFileNameImg(int i_concert_number) { return GetKeywordSeasonDocumentPathFileNameImg() + FindStringNumber(i_concert_number); }


        #endregion // Keywords corresponding to XML file JazzDokument_20xx_20yy.xml

        #region Keywords corresponding to XML file JazzProgramm_20xx_20yy.xml

        /// <summary>Defines the HTM keywords array corresponding to XML file JazzProgram_20xx_20yyy.xml
        /// <para>The array corresponds to the arrays m_text_tags_concert and xxx in class JazzXml.JazzXmlTags</para>
        /// <para>The keyword names are the same as in m_text_tags_template but preceeded by 'JazzDokumenteSaison.'</para>
        /// <para>For each keyword there is a get function: GetKeywordSeasonProgramBandNam, GetKeywordSeasonProgramYear, ...</para>
        /// <para>Some of the keywords are the same as in the Javascript template file JazzProgramm.js</para>
        /// </summary>
        static private string[] m_keywords_jazz_saison_program =
        {
            @"JazzProgrammSaison.BandName", // 0 
            @"JazzProgrammSaison.Year", // 1
            @"JazzProgrammSaison.Month", // 2
            @"JazzProgrammSaison.Day", // 3
            @"JazzProgrammSaison.SoundSample", // 4
            @"JazzProgrammSaison.ConcertDate", // 5

            @"JazzProgrammSaison.PremisesNameAddress", // 6
            @"JazzProgrammSaison.ListMusiciansInstruments", // 7
            @"JazzProgrammSaison.ShortText", // 8
            @"JazzProgrammSaison.ListMusiciansTexts", // 9
            @"JazzProgrammSaison.LinkBandWebsite", // 10
            @"JazzProgrammSaison.LinkSoundSample", // 11
            @"JazzProgrammSaison.LinkSmallPosterNoPath", // 12
            @"JazzProgrammSaison.ImgPosterConcert", // 13
            
        }; // m_keywords_jazz_saison_program

        /// <summary>Returns the keyword string for BandName corresponding to the XML tag name in the array JazzXml.m_text_tags_concert</summary>
        static public string GetKeywordSeasonProgramBandName() { return m_keywords_jazz_saison_program[0]; }
        /// <summary>Returns the keyword string for Year corresponding to the XML tag name in the array JazzXml.m_text_tags_concert</summary>
        static public string GetKeywordSeasonProgramYear() { return m_keywords_jazz_saison_program[1]; }
        /// <summary>Returns the keyword string for Month corresponding to the XML tag name in the array JazzXml.m_text_tags_concert</summary>
        static public string GetKeywordSeasonProgramMonth() { return m_keywords_jazz_saison_program[2]; }
        /// <summary>Returns the keyword string for Day corresponding to the XML tag name in the array JazzXml.m_text_tags_concert</summary>
        static public string GetKeywordSeasonProgramFileNameDay() { return m_keywords_jazz_saison_program[3]; }
        /// <summary>Returns the keyword string for SoundSample corresponding to the XML tag name in the array JazzXml.m_text_tags_concert</summary>
        static public string GetKeywordSeasonProgramSoundSample() { return m_keywords_jazz_saison_program[4]; }
        /// <summary>Returns the keyword string for ConcertDate </summary>
        static public string GetKeywordSeasonProgramConcertDate() { return m_keywords_jazz_saison_program[5]; }

        /// <summary>Returns the keyword string for PremisesNameAddress </summary>
        static public string GetKeywordSeasonProgramPremisesNameAddress() { return m_keywords_jazz_saison_program[6]; }
        /// <summary>Returns the keyword string for ListMusiciansInstruments </summary>
        static public string GetKeywordSeasonProgramListMusiciansInstruments() { return m_keywords_jazz_saison_program[7]; }
        /// <summary>Returns the keyword string for ShortText </summary>
        static public string GetKeywordSeasonProgramShortText() { return m_keywords_jazz_saison_program[8]; }
        /// <summary>Returns the keyword string for ListMusiciansTexts </summary>
        static public string GetKeywordSeasonProgramListMusiciansTexts() { return m_keywords_jazz_saison_program[9]; }
        /// <summary>Returns the keyword string for LinkBandWebsite </summary>
        static public string GetKeywordSeasonProgramLinkBandWebsite() { return m_keywords_jazz_saison_program[10]; }
        /// <summary>Returns the keyword string for PremisesNameAddress </summary>
        static public string GetKeywordSeasonProgramLinkSoundSample() { return m_keywords_jazz_saison_program[11]; }
        /// <summary>Returns the keyword string for LinkSoundSample </summary>
        static public string GetKeywordSeasonProgramLinkSmallPosterNoPath() { return m_keywords_jazz_saison_program[12]; }
        /// <summary>Returns the keyword string for PremisesNameAddress </summary>
        static public string GetKeywordSeasonProgramImgPosterConcert() { return m_keywords_jazz_saison_program[13]; }


        /// <summary>Returns find string for bandname for a given concert number.</summary>
        static public string GetFindStringBandName(int i_concert_number) {return GetKeywordSeasonProgramBandName() + FindStringNumber(i_concert_number);}
        /// <summary>Returns find string for bandname where the concert number shall be set by a function (in a loop).</summary>
        static public string GetFindStringBandNameLoopIndex() { return GetKeywordSeasonProgramBandName() + @"(i)" ; }
        /// <summary>Returns find string for concert date for a given concert number.</summary>
        static public string GetFindStringConcertDate(int i_concert_number) {return GetKeywordSeasonProgramConcertDate() + FindStringNumber(i_concert_number);}
        /// <summary>Returns find string for concert date  where the concert number shall be set by a function (in a loop)..</summary>
        static public string GetFindStringConcertDateLoopIndex() { return GetKeywordSeasonProgramConcertDate() + @"(i)"; }


        /// <summary>Returns find string for PremisesNameAddress where the concert number shall be set by an Admin function (in a loop).</summary>
        static public string GetFindStringPremisesNameAddressLoopIndex() { return GetKeywordSeasonProgramPremisesNameAddress() + @"(i)"; }
        /// <summary>Returns find string for ListMusiciansInstruments where the concert number shall be set by an Admin function (in a loop).</summary>
        static public string GetFindStringListMusiciansInstrumentsLoopIndex() { return GetKeywordSeasonProgramListMusiciansInstruments() + @"(i)"; }
        /// <summary>Returns find string for ShortText where the concert number shall be set by an Admin function (in a loop).</summary>
        static public string GetFindStringShortTextLoopIndex() { return GetKeywordSeasonProgramShortText() + @"(i)"; }
        /// <summary>Returns find string for ListMusiciansTexts where the concert number shall be set by an Admin function (in a loop).</summary>
        static public string GetFindStringListMusiciansTextsLoopIndex() { return GetKeywordSeasonProgramListMusiciansTexts() + @"(i)"; }
        /// <summary>Returns find string for LinkBandWebsite where the concert number shall be set by an Admin function (in a loop).</summary>
        static public string GetFindStringLinkBandWebsiteIndex() { return GetKeywordSeasonProgramLinkBandWebsite() + @"(i)"; }
        /// <summary>Returns find string for LinkSoundSample where the concert number shall be set by an Admin function (in a loop).</summary>
        static public string GetFindStringLinkSoundSampleLoopIndex() { return GetKeywordSeasonProgramLinkSoundSample() + @"(i)"; }
        /// <summary>Returns find string for LinkSmallPosterNoPath where the concert number shall be set by an Admin function (in a loop).</summary>
        static public string GetFindStringLinkSmallPosterNoPathLoopIndex() { return GetKeywordSeasonProgramLinkSmallPosterNoPath() + @"(i)"; }
        /// <summary>Returns find string for ImgPosterConcert where the concert number shall be set by an Admin function (in a loop).</summary>
        static public string GetFindStringImgPosterConcertLoopIndex() { return GetKeywordSeasonProgramImgPosterConcert() + @"(i)"; }


        /// <summary>Returns '(input number)' as string</summary>
        static private string FindStringNumber(int i_concert_number) {return @"(" + i_concert_number.ToString() + @")";}

        #endregion // Keywords corresponding to XML file JazzProgramm_20xx_20yy.xml

    } // HtmKeywords
} // namespace
