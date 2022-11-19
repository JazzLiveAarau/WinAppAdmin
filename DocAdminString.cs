using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Holds Document strings
    /// <para></para>
    /// </summary>
    public static class DocAdminString
    {
        #region Directory names

        /// <summary>Documents backup directory name</summary>
        static public string DirectoryBackups = @"Backups";

        #endregion // Directory names

        #region Labels, caps and names for forms

        /// <summary>GUI program title</summary>
        static public string TitleDocAdminForm = @"Dokumente (DOC)";

        /// <summary>Label for current season control</summary>
        static public string LabelCurrentSeason = @"Saison";

        /// <summary>Label for current concert control</summary>
        static public string LabelCurrentConcert = @"Konzert";

        /// <summary>GUI season program title</summary>
        static public string TitleDocProgramForm = @"Saisonprogramm";

        /// <summary>Label for select season document combobox</summary>
        static public string LabelSeasonDocument = @"Saison";

        /// <summary>Prompt for select season document combobox</summary>
        static public string PromptSeasonDocument = @"Saison-Dokument wählen";

        /// <summary>Prompt for select concert document combobox</summary>
        static public string PromptConcertDocument = @"Konzert-Dokument wählen";

        /// <summary>Prompt for select HTM or JS file combobox</summary>
        static public string PromptHtmlFile = @"Datei (htm oder js) wählen";

        /// <summary>Prompt for select help file combobox</summary>
        static public string PromptHelpFile = @"Hilfedatei wählen";

        /// <summary>Button concert ticket title</summary>
        static public string TitleButtonConcertTicket = @"Billet";

        /// <summary>Label publish title</summary>
        static public string TitleLabelPublish= @"Publizieren";

        /// <summary>Title save document</summary>
        static public string TitleSaveDocument = @"Dokument speichern";

        /// <summary>Title save document</summary>
        static public string TitleGenerateTxt = @"TXT Dokument generieren";

        /// <summary>GUI concert ticket title</summary>
        static public string TitleDocTicketForm = @"Eintrittskarte";

        /// <summary>Returns the form title for text editing</summary>
        static public string GetTitleFormDocument(string i_title_page)
        {
            return @" Herunter- und hochladen von " + i_title_page;
        } // GetTitleFormDocument

        #endregion Labels, caps and names for forms

        #region Error messages

        /// <summary>Error message: Checkout of XML file is necessary prior to uploading a document for the first time</summary>
        static public string ErrMsgCheckoutUploadDocFirstTime = @"Bitte Checkout XML Datei: ";

        /// <summary>Error message: The file is not on the server</summary>
        static public string ErrMsgDocFileIsNotOnServer = @"Diese Datei ist nicht auf dem Server gespeichert";

        /// <summary>Error message: Checkout of XML file is necessary prior to deleting the object</summary>
        static public string ErrMsgCheckoutBeforeDelete = @"Löschen ist nicht erlaubt ohne Checkout von XML Datei: ";

        /// <summary>Error message: Checkout of XML file is necessary prior to upload</summary>
        static public string ErrMsgCheckoutBeforeUpload = @"Hinaufladen zum Server ist nicht erlaubt ohne Checkout von XML Datei: ";

        /// <summary>Tool tip for the dates part of a directory (for a new season documents XML file)</summary>
        static public string ErrMsgNotAllowedCharsInDirectoryName = @"Warnung: Ordnername oder Ordernamen wurde geändert " + "\n" +
                                                  @"Leerschlag, ä, ö, ü, é und andere ähnliche Buchstaben sind nicht erlaubt.";

        #endregion Error messages

        #region Messages

        /// <summary>Message: File was uploaded to the server</summary>
        static public string MsgFileUploaded = @" ist auf dem Server gespeichert";

        /// <summary>Message: File was downloaded from the server</summary>
        static public string MsgFileDownloaded = @" ist vom Server heruntergeladen";

        /// <summary>Message: Upload was cancelled</summary>
        static public string MsgFileUploadCancelled = @"Dokument ist nicht hochgeladen";

        /// <summary>Message: Download was cancelled</summary>
        static public string MsgFileDownloadCancelled = @"Dokument ist nicht heruntergeladen";

        /// <summary>Message: The creation of a new season documents XML file was cancelled by the user</summary>
        static public string MsgCreationOfNewSeasonDocumentsXmlCancelled = @"Saison wurde nicht zugefügt.";

        /// <summary>Message: File is deleted</summary>
        static public string MsgFileDeleted = @" ist gelöscht";

        /// <summary>Message: Function is not yet implemented</summary>
        static public string MsgFunctionNotYetImplemented = @"Diese Funktion ist noch nicht implementiert";

        /// <summary>Message: Shall the existent TXT be replaced?</summary>
        static public string MsgExistentTxtReplace = @"Das existierende TXT Dokument ersetzen?";

        /// <summary>Message: The name of the selected file will be changed</summary>
        static public string MsgSelectedFileNameWillBeChanged = @"Der Name der gewählte Datei wird geändert";

        /// <summary>Message: From the name of the selected file </summary>
        static public string MsgSelectedFileNameFrom = @"Von: ";

        /// <summary>Message: To the name of the existing file </summary>
        static public string MsgSelectedFileNameTo = @"Zu: ";

        /// <summary>Message: Continue changing name? </summary>
        static public string MsgSelectedFileNameContinue = @"Fortsetzen? ";

        /// <summary>Message: Message if not continued </summary>
        static public string MsgSelectedFileNameNotContinue = @"Dateinamen waren nicht gleich. Die gewählte Datei ist nicht hochgeladen";

        /// <summary>Message: Warning </summary>
        static public string MsgWarning = @"Warnung";

        #endregion // Messages

        #region Tool tips

        /// <summary>Tool tip for the documents form</summary>
        static public string ToolTipDocumentsForm = @"Hoch- und herunterladen von Jazz-Dokumenten";

        /// <summary>Tool tip for the documents form message</summary>
        static public string ToolTipDocumentsFormMessage = @"Meldungen von den Dokumentenfunktionen";

        /// <summary>Tool tip select concert</summary>
        static public string ToolTipSelectConcert = @"Konzert wählen";

        /// <summary>Tool tip select season document</summary>
        static public string ToolTipSelectSeasonDocument = @"Saison-Dokument wählen";

        /// <summary>Tool tip select concert document</summary>
        static public string ToolTipSelectConcertDocument = @"Konzert-Dokument wählen";

        /// <summary>Tool tip for the DocProgramForm</summary>
        static public string ToolTipDocProgramForm = @"Hoch- und herunterladen von Saisonprogramm-Dokumenten";

        /// <summary>Tool tip season program edit</summary>
        static public string ToolTipDocProgramFormEdit = @"Hier klicken für Änderungen (nur möglich nach Checkout)";

        /// <summary>Tool tip season program cancel</summary>
        static public string ToolTipDocProgramFormCancel = @"Zurück zum Hauptdialog ohne Änderungen zu speichern";

        /// <summary>Tool tip season program close</summary>
        static public string ToolTipDocProgramFormClose = @"Änderungen übernehmen und zurück zum Hauptdialog";

        /// <summary>Tool tip current season</summary>
        static public string ToolTipDocProgramFormCurrentSeason = @"Zeigt die aktuelle Saison";

        /// <summary>Tool tip messages from the DocProgram functions</summary>
        static public string ToolTipDocProgramFormMsg = @"Meldungen von den Saisonprogrammfunktionen";

        /// <summary>Tool tip for a jazz document dialog like for instance DocOriginPdfForm</summary>
        static public string ToolTipDocForm = @"Hoch- und herunterladen des Jazz-Dokuments";

        /// <summary>Tool tip edit for a jazz document dialog like for instance DocOriginPdfForm</summary>
        static public string ToolTipDocFormEdit = @"Hier klicken für Änderungen (nur möglich nach Checkout)";

        /// <summary>Tool tip cancel for a jazz document dialog like for instance DocOriginPdfForm</summary>
        static public string ToolTipDocFormCancel = @"Zurück zum Hauptdialog ohne Änderungen zu speichern";

        /// <summary>Tool tip close for a jazz document dialog like for instance DocOriginPdfForm</summary>
        static public string ToolTipDocFormClose = @"Änderungen übernehmen und zurück zum Hauptdialog";

        /// <summary>Tool tip current season for a jazz document dialog like for instance DocOriginPdfForm</summary>
        static public string ToolTipDocFormCurrentSeason = @"Zeigt die aktuelle Saison";

        /// <summary>Tool tip message  for a jazz document dialog like for instance DocOriginPdfForm</summary>
        static public string ToolTipDocFormMsg = @"Meldungen von den Dokumentfunktionen";

        /// <summary>Tool tip publish the document</summary>
        static public string ToolTipDocPublish = @"Zeigt ob das Dokument freigegeben ist";

        /// <summary>Tool tip download DOC document</summary>
        static public string ToolTipDownLoadDoc = @"Herunterladen des DOC-Dokuments vom Server zum Computer";

        /// <summary>Tool tip download XLS document</summary>
        static public string ToolTipDownLoadXls = @"Herunterladen des XLS-Dokuments vom Server zum Computer";

        /// <summary>Tool tip download PDF document</summary>
        static public string ToolTipDownLoadPdf = @"Herunterladen des PDF-Dokuments vom Server zum Computer";

        /// <summary>Tool tip downloadIMG picture</summary>
        static public string ToolTipDownLoadImg = @"Herunterladen des IMG-Dokuments (Bild) vom Server zum Computer";

        /// <summary>Tool tip download TXT document</summary>
        static public string ToolTipDownLoadTxt = @"Herunterladen des TXT-Dokuments vom Server zum Computer";

        /// <summary>Tool tip download HTM page</summary>
        static public string ToolTipDownLoadHtm = @"Herunterladen der HTM-Datei vom Server zum Computer";

        /// <summary>Tool tip upload HTM page</summary>
        static public string ToolTipUpLoadHtm = @"Speichert die HTM-Datei auf dem Server";

        /// <summary>Tool tip download RTF page</summary>
        static public string ToolTipDownLoadRtf = @"Herunterladen der RTF-Datei vom Server zum Computer";

        /// <summary>Tool tip upload RTF page</summary>
        static public string ToolTipUpLoadRtf = @"Speichert die RTF Datei auf dem Server";

        /// <summary>Tool tip upload DOC document</summary>
        static public string ToolTipUpLoadDoc = @"Speichert das DOC-Dokument auf dem Server";

        /// <summary>Tool tip upload XLS document</summary>
        static public string ToolTipUpLoadXls = @"Speichert das XLS-Dokument auf dem Server";

        /// <summary>Tool tip upload PDF document</summary>
        static public string ToolTipUpLoadPdf = @"Speichert das PDF-Dokument auf dem Server";

        /// <summary>Tool tip upload IMG picture</summary>
        static public string ToolTipUpLoadImg = @"Speichert das IMG-Dokument (Bild) auf dem Server";

        /// <summary>Tool tip upload TXT document</summary>
        static public string ToolTipUpLoadTxt = @"Speichert das TXT-Dokument auf dem Server";

        /// <summary>Tool tip delete DOC document</summary>
        static public string ToolTipDeleteDoc = @"Löscht das DOC-Dokument";

        /// <summary>Tool tip delete XLS document</summary>
        static public string ToolTipDeleteXls = @"Löscht das XLS-Dokument";

        /// <summary>Tool tip delete PDF document</summary>
        static public string ToolTipDeletePdf = @"Löscht das PDF-Dokument";

        /// <summary>Tool tip delete IMG picture</summary>
        static public string ToolTipDeleteImg = @"Löscht das IMG-Dokument (Bild)";

        /// <summary>Tool tip delete TXT document</summary>
        static public string ToolTipDeleteTxt = @"Löscht das TXT-Dokument";

        /// <summary>Tool tip file name DOC document</summary>
        static public string ToolTipFilenameDoc = @"Anzeige Namen DOC-Dokument, wenn auf Server gespeichert." +  "\n" +
                                                  @"Es gibt kein Dokument auf dem server wenn Name leer ist" + "\n" +
                                                  @"Der Name wird von diesem Programm bestimmt. Der Benutzer kann einen Name nicht eingeben.";

        /// <summary>Tool tip file name XLS document</summary>
        static public string ToolTipFilenameXls = @"Zeigt der Name des XLS Dokuments, wenn es auf dem Server gespeichert ist" + "\n" +
                                                  @"Kein Dokument auf Server, wenn Anzeige leer." + "\n" +
                                                  @"Name wird vom Programm bestimmt und kann nicht vom Benutzer eingegeben werden.";

        /// <summary>Tool tip file name PDF document</summary>
        static public string ToolTipFilenamePdf = @"Anzeige Namen PDF-Dokument, wenn auf Server gespeichert." + "\n" +
                                                  @"Kein Dokument auf Server, wenn Anzeige leer." + "\n" +
                                                  @"Name wird vom Programm bestimmt und kann nicht vom Benutzer eingegeben werden.";

        /// <summary>Tool tip file name IMG picture</summary>
        static public string ToolTipFilenameImg = @"Anzeige Namen IMG-Dokument (Bild), wenn auf Server gespeichert." + "\n" +
                                                  @"Kein Dokument auf Server, wenn Anzeige leer." + "\n" +
                                                  @"Name wird vom Programm bestimmt und kann nicht vom Benutzer eingegeben werden.";

        /// <summary>Tool tip file name TXT document</summary>
        static public string ToolTipFilenameTxt = @"Anzeige Namen TXT-Dokument, wenn auf Server gespeichert." + "\n" +
                                                  @"Kein Dokument auf Server, wenn Anzeige leer." + "\n" +
                                                  @"Name wird vom Programm bestimmt und kann nicht vom Benutzer eingegeben werden.";

        /// <summary>Tool tip file name HTM page</summary>
        static public string ToolTipFilenameHtm = @"Anzeige Namen HTM-Datei, wenn auf Server gespeichert." + "\n" +
                                                  @"Name wird vom Programm bestimmt und kann nicht vom Benutzer eingegeben werden.";

        /// <summary>Tool tip file name RTF page</summary>
        static public string ToolTipFilenameRtf = @"Anzeige Namen RTF-Datei, wenn auf Server gespeichert." + "\n" +
                                                  @"Name wird vom Programm bestimmt und kann nicht vom Benutzer eingegeben werden.";

        /// <summary>Tool tip generate the TXT document automatically</summary>
        static public string ToolTipGenerateTxt = @"Generiert das TXT-Dokument automatisch";

        /// <summary>Tool tip for the dialog that creates a new season documents XML file (JazzDokumente_20xx_20yy.xml)</summary>
        static public string ToolTipDocDirNamesForm = @"Zufügen von einem neuen Saison XML Datei";

        /// <summary>Tool tip for the dates part of a directory (for a new season documents XML file)</summary>
        static public string ToolTipDirNamesDateConcert = @"Der Datum-Teil vom Ordnername" + "\n" +
                                                  @"Datum wird von der Admin Funktion: XML -> Neue Saison -> Konzert geholt. " + "\n" +
                                                  @"Mit dieser Funktion muss man das Datum ändern wenn es falsch ist. ";

        /// <summary>Tool tip for the dates part of a directory (for a new season documents XML file)</summary>
        static public string ToolTipDirNamesConcert = @"Der Bandname-Teil vom Ordnername" + "\n" +
                                                  @"Kürze gerne der Name, aber behalte so viel, dass es klar ist, um velchem Band es geht. " + "\n" +
                                                  @"Leerschlag, ä, ö, ü, é und andere ähnliche Buchstaben sind nicht erlaubt.";
        // 
        #endregion // Tool tips

        #region Create text file with all tool tips

        /// <summary>Create file with all tool tips</summary>
        public static void CreateFileToolTips()
        {
          string[] m_doc_tool_tip_names =
          {
            @"ToolTipDocumentsForm",  // 0
            @"ToolTipDocumentsFormMessage", // 1
            @"ToolTipSelectConcert", // 2
            @"ToolTipSelectSeasonDocument", // 3
            @"ToolTipSelectConcertDocument",  // 4
            @"ToolTipDocProgramForm",  // 5
            @"ToolTipDocProgramFormEdit",  // 6 
            @"ToolTipDocProgramFormCancel",  // 7 
            @"ToolTipDocProgramFormClose",  // 8
            @"ToolTipDocProgramFormCurrentSeason",  // 9 
            @"ToolTipDocProgramFormMsg",  // 10 
            @"ToolTipDocForm",  // 11 
            @"ToolTipDocFormEdit",  // 12 
            @"ToolTipDocFormCancel",  // 13 
            @"ToolTipDocFormClose",  // 14 
            @"ToolTipDocFormCurrentSeason",  // 15 
            @"ToolTipDocFormMsg",  // 16
            // ToolTipDocLetterForm (17) - ToolTipDocTicketFormMsg (28)
            // ToolTipDocLetterForm (17) - ToolTipDocTicketFormMsg (28)
			@"ToolTipDocPublish", // 17
			@"ToolTipDownLoadDoc", // 18
			@"ToolTipDownLoadPdf", // 19
			@"ToolTipDownLoadImg", // 20
			@"ToolTipDownLoadTxt", // 21
			@"ToolTipDownLoadHtm", // 22
			@"ToolTipUpLoadHtm", // 23
			@"ToolTipDownLoadRtf", // 24
			@"ToolTipUpLoadRtf", // 25
			@"ToolTipUpLoadDoc", // 26
			@"ToolTipUpLoadXls", // 27
			@"ToolTipUpLoadPdf", // 28
			@"ToolTipUpLoadImg", // 29
			@"ToolTipUpLoadTxt", // 30
			@"ToolTipDeleteDoc", // 31
			@"ToolTipDeleteXls", // 32
			@"ToolTipDeletePdf", // 33
			@"ToolTipDeleteImg", // 34
			@"ToolTipDeleteTxt", // 35
			@"ToolTipFilenameDoc", // 36
			@"ToolTipFilenameXls", // 37
            @"ToolTipFilenameImg", // 38
            @"ToolTipFilenamePdf", // 39
            @"ToolTipFilenameTxt", // 40
            @"ToolTipFilenameHtm", // 41
            @"ToolTipFilenameRtf", // 42
            @"ToolTipGenerateTxt", // 43
            @"ToolTipDocDirNamesForm", // 44
            @"ToolTipDirNamesDateConcert", // 45
            @"ToolTipDirNamesConcert", // 46

          }; // m_tool_tip_names
  
            string[] m_doc_tool_tips = new string[47];
            m_doc_tool_tips[ 0] = ToolTipDocumentsForm;  // 0
            m_doc_tool_tips[ 1] = ToolTipDocumentsFormMessage; // 1
            m_doc_tool_tips[ 2] = ToolTipSelectConcert; // 2
            m_doc_tool_tips[ 3] = ToolTipSelectSeasonDocument; // 3
            m_doc_tool_tips[ 4] = ToolTipSelectConcertDocument;  // 4
            m_doc_tool_tips[ 5] = ToolTipDocProgramForm;  // 5
            m_doc_tool_tips[ 6] = ToolTipDocProgramFormEdit;  // 6 
            m_doc_tool_tips[ 7] = ToolTipDocProgramFormCancel;  // 7 
            m_doc_tool_tips[ 8] = ToolTipDocProgramFormClose;  // 8
            m_doc_tool_tips[ 9] = ToolTipDocProgramFormCurrentSeason;  // 9 
            m_doc_tool_tips[10] = ToolTipDocProgramFormMsg;  // 10 
            m_doc_tool_tips[11] = ToolTipDocForm;  // 11 
            m_doc_tool_tips[12] = ToolTipDocFormEdit;  // 12 
            m_doc_tool_tips[13] = ToolTipDocFormCancel;  // 13 
            m_doc_tool_tips[14] = ToolTipDocFormClose;  // 14 
            m_doc_tool_tips[15] = ToolTipDocFormCurrentSeason;  // 15 
            m_doc_tool_tips[16] = ToolTipDocFormMsg;  // 16
            // ToolTipDocLetterForm (17) - ToolTipDocTicketFormMsg (28)
            // ToolTipDocLetterForm (17) - ToolTipDocTicketFormMsg (28)
            m_doc_tool_tips[17] = ToolTipDocPublish; // 17
            m_doc_tool_tips[18] = ToolTipDownLoadDoc; // 18
            m_doc_tool_tips[19] = ToolTipDownLoadPdf; // 19
            m_doc_tool_tips[20] = ToolTipDownLoadImg; // 20
            m_doc_tool_tips[21] = ToolTipDownLoadTxt; // 21
            m_doc_tool_tips[22] = ToolTipDownLoadHtm; // 22
            m_doc_tool_tips[23] = ToolTipUpLoadHtm; // 23
            m_doc_tool_tips[24] = ToolTipDownLoadRtf; // 24
            m_doc_tool_tips[25] = ToolTipUpLoadRtf; // 25
            m_doc_tool_tips[26] = ToolTipUpLoadDoc; // 26
            m_doc_tool_tips[27] = ToolTipUpLoadXls; // 27
            m_doc_tool_tips[28] = ToolTipUpLoadPdf; // 28
            m_doc_tool_tips[29] = ToolTipUpLoadImg; // 29
            m_doc_tool_tips[30] = ToolTipUpLoadTxt; // 30
            m_doc_tool_tips[31] = ToolTipDeleteDoc; // 31
            m_doc_tool_tips[32] = ToolTipDeleteXls; // 32
            m_doc_tool_tips[33] = ToolTipDeletePdf; // 33
            m_doc_tool_tips[34] = ToolTipDeleteImg; // 34
            m_doc_tool_tips[35] = ToolTipDeleteTxt; // 35
            m_doc_tool_tips[36] = ToolTipFilenameDoc; // 36
            m_doc_tool_tips[37] = ToolTipFilenameXls; // 37
            m_doc_tool_tips[38] = ToolTipFilenameImg; // 38
            m_doc_tool_tips[39] = ToolTipFilenamePdf; // 39
            m_doc_tool_tips[40] = ToolTipFilenameTxt; // 40
            m_doc_tool_tips[41] = ToolTipFilenameHtm; // 41
            m_doc_tool_tips[42] = ToolTipFilenameRtf; // 42
            m_doc_tool_tips[43] = ToolTipGenerateTxt; // 43
            m_doc_tool_tips[44] = ToolTipDocDirNamesForm; // 44
            m_doc_tool_tips[45] = ToolTipDirNamesDateConcert; // 45
            m_doc_tool_tips[46] = ToolTipDirNamesConcert; // 46


            string out_str = @"ToolTips for Document (Dokumente) functions " + TimeUtil.YearMonthDayIso() + "\n";
            out_str = out_str + @"====================================================" + "\n" + "\n";

            for (int index_tip = 0; index_tip < m_doc_tool_tip_names.Length; index_tip++)
            {
                string tip_number = @"";
                if (index_tip < 9)
                {
                    tip_number = @" " + (index_tip + 1).ToString() + @". ";
                }
                else
                {
                    tip_number = (index_tip + 1).ToString() + @". ";
                }
                out_str = out_str + tip_number + m_doc_tool_tip_names[index_tip] + @"= " + "\n" + m_doc_tool_tips[index_tip] + "\n" + "\n";
            }

            string file_name = @"ToolTipsDokumenteFunktionen_" + TimeUtil.YearMonthDay() + @".txt";

            File.WriteAllText(file_name, out_str);

        } // CreateFileToolTips

        #endregion // Create text file with all tool tips

    } // DocAdminString
} // namespace
