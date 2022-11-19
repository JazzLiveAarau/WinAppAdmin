using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Holds photo strings
    /// <para></para>
    /// </summary>
    public static class PhotoStrings
    {
        #region Titles

        /// <summary>Title for the photo main form</summary>
        static public string TitlePhotoMainForm = @"Fotos (JPG)";

        /// <summary>Title for the add zip file form</summary>
        static public string TitlePhotoZipForm = @"ZIP-Datei zufügen";

        /// <summary>Title for the photo developer form</summary>
        static public string TitlePhotoDeveloperForm = @"Funktionen für Kontroll und Pflege von Fotodaten";

        /// <summary>Title for the add gallery form</summary>
        static public string TitleGalleryForm = @"Galerie zufügen";

        /// <summary>Title for the add picture form</summary>
        static public string TitlePictureForm = @"Foto zufügen";

        #endregion Titles

        #region Labels

        /// <summary>Label for the photo developer form</summary>
        static public string LabelPhotoDeveloperForm = @"Pflege von Fotofunktionen und Fotodaten";

        #endregion // Labels

        #region Caps

        /// <summary>Cap for the photo developer button</summary>
        static public string CapPhotoDeveloper = @"Datenwartung";

        #endregion // Caps

        #region Default strings

        /// <summary>Default photographer name</summary>
        static public string DefaultPhotoPhotographer = @"Markus Meier";

        #endregion // Default strings

        #region Messages

        /// <summary>Each concert this season has a ZIP file</summary>
        static public string MsgPhotoAllHaveZipFiles = @"Für jedes Konzert gibt es eine ZIP-Datei";

        /// <summary>Gallery files are downloaded</summary>
        static public string MsgPhotoHtmGalleryFilesDownloaded = @"Galerie HTM Dateien im Ordner: ";

        /// <summary>Message: File was uploaded to the server</summary>
        static public string MsgFileUploaded = @" ist auf dem Server gespeichert";

        /// <summary>Message: File was downloaded from the server</summary>
        static public string MsgFileDownloaded = @" ist vom Server heruntergeladen";

        /// <summary>Message: Upload was cancelled</summary>
        static public string MsgFileUploadCancelled = @"Eine ZIP-Datei wurde nicht hochgeladen";

        /// <summary>Message: Download was cancelled</summary>
        static public string MsgFileDownloadCancelled = @"Datei ist nicht heruntergeladen";

        /// <summary>Message: Continue (without setting the picture text) </summary>
        static public string MsgNoPictureTextContinue = @"Fortsetzen? ";

        /// <summary>Message: No picture text </summary>
        static public string MsgNoPictureText = @"Kein Text für das Foto!";

        /// <summary>Message: Gallery upload: Start </summary>
        static public string MsgUploadGalleryStart = @"Aufladen von Galerie";

        /// <summary>Message: Gallery upload: Get and check local picture data </summary>
        static public string MsgUploadGalleryGetCheckLocalData = @"Galeriefotos im Computer holen und kontrollieren";

        /// <summary>Message: Gallery upload: Generate HTML and JavaScript files</summary>
        static public string MsgUploadGalleryGenerateHtmlJavaScriptFiles = @"HTML und JavaScript Dateien generieren";

        /// <summary>Message: Gallery upload: Upload all files</summary>
        static public string MsgUploadAllGalleryFiles = @"Alle Fotos, alle HTML und JavaScript Dateien hochladen";

        /// <summary>Message: Gallery upload: Upload all big photos</summary>
        static public string MsgUploadGalleryBigPhotos = @"Grosse Fotos hochladen";

        /// <summary>Message: Gallery upload: Upload all small photos</summary>
        static public string MsgUploadGallerySmallPhotos = @"Kleine Fotos hochladen";

        /// <summary>Message: Gallery upload: Upload HTML files</summary>
        static public string MsgUploadGalleryHtml = @"HTML Dateien hochladen";

        /// <summary>Message: Gallery upload: Upload JavaScript files</summary>
        static public string MsgUploadGalleryJavaScript = @"JavaScript Dateien hochladen";

        /// <summary>Message: Gallery upload: Upload JazzGalerieZwei.htm</summary>
        static public string MsgUploadGalleryTwoHtml = @"JazzGalerieZwei.htm hochladen";

        /// <summary>Message: Gallery upload: Update XML objec</summary>
        static public string MsgUploadGalleryUpdateXml = @"XML aktualisieren";

        /// <summary>Message: Gallery upload: Update season program XML</summary>
        static public string MsgUploadGalleryUpdateSeasonProgramXml = @"Aktualisierung von Saisonprogramm XML";

        /// <summary>Message: Gallery upload: Exit (finished)</summary>
        static public string MsgUploadGalleryFinished = @"Galerie ist hochgeladen";


        #endregion // Messages

        #region Error messages

        /// <summary>File is locked by another process</summary>
        static public string ErrMsgPhotoUploadLocked = @" wurde nicht aufgeladen, weil sie (von Word?) gesperrt ist.";

        /// <summary>Error message: Checkout is necessary prior to upload</summary>
        static public string ErrMsgCheckoutBeforeUpload = @"Hinaufladen zum Server ist nicht erlaubt ohne Checkout";

        /// <summary>Error message: ZIP file is not uploaded</summary>
        static public string ErrMsgZipFileNotUploaded = @"Eine ZIP-Datei ist nicht hochgeladen.";

        /// <summary>Error message: Photographer name is not set</summary>
        static public string ErrMsgPhotographerNameIsNotSet = @"Name des Fotografens fehlt";

        /// <summary>Error message: Photographer name not name and family name</summary>
        static public string ErrMsgPhotographerNameSpace = @"Vorname oder Nachname des Fotografens fehlt";

        /// <summary>Error message: Season string is not set</summary>
        static public string ErrMsgZipSeasonString = @"Programming error: Season string is not set. Report to the developer";

        /// <summary>Error message: Replace a ZIP file is not yet implemented</summary>
        static public string ErrMsgReplaceZipNotImplemented = @"Ersezten von einer ZIP-Datei ist noch nicht implementiert";

        /// <summary>Error message: Upload of gallery is not yet implemented</summary>
        static public string ErrMsgUploadGalleryNotImplemented = @"Hochladen von Galerie ist noch nicht implementiert";

        /// <summary>Error message: ZIP file is registered but is missing on the server</summary>
        static public string ErrMsgZipFileRegisteredButExistsNot = @"Die gewählte ZIP-Datei ist nicht auf dem Server!" + NewLine() +
                                                                   @"Oder es gibt ein Problem mit ä, ü or ö im Dateiname";

        /// <summary>Error message: Height of the big photo is not within tolerance</summary>
        static public string ErrMsgBigPhotoHeightNotWithinTol = @"Höhe von Foto ist nicht (pixel): ";

        /// <summary>Error message: Width of the small photo is not within tolerance</summary>
        static public string ErrMsgSmallPhotoWidthNotWithinTol = @"Breite von Foto ist nicht (pixel): ";

        /// <summary>Error message: Height of the small photo is not within tolerance</summary>
        static public string ErrMsgSmallPhotoHeightNotWithinTol = @"Höhe von Foto ist nicht (pixel): ";

        /// <summary>Error message: No picture is selected</summary>
        static public string ErrMsgNoPictureSelected = @"Das grosse und das kleine Foto fehlen";

        /// <summary>Error message: Only the big picture is selected</summary>
        static public string ErrMsgOnlyBigPictureSelected = @"Das kleine Foto fehlt";

        /// <summary>Error message: Only the small picture is selected</summary>
        static public string ErrMsgOnlySmallPictureSelected = @"Das grosse Foto fehlt";

        /// <summary>Error message: Picture file is locked</summary>
        static public string ErrMsgPictureFileLocked = @" Bild kann nicht kopiert werden (file is locked). Versuch noch einmal!";

        /// <summary>Error message: Missing picture(s) in the the local gallery directory text file (flags that pictures exixt)</summary>
        static public string ErrMsgMissingPicturesInGallery = @"Aufladen von der Galerie nicht möglich. Bild fehlt oder Bilder fehlen. Zum Beispiel Bild nummer ";

        /// <summary>Error message: Missing picture file in the the local gallery directory</summary>
        static public string ErrMsgMissingPictureFileInGallery = @"Aufladen von der Galerie nicht möglich. Diese (Bild-) Datei fehlt: ";

        /// <summary>Error message: Gallery is already uploaded</summary>
        static public string ErrMsgGalleryIsAlreadyUploaded = @"Galerie ist schon aufgeladen. Ersetzen von einer Galerie ist nicht implementiert.";

        #endregion // Error messages

        #region Prompt strings

        /// <summary>Prompt: Select musician</summary>
        static public string PromptSelectMusician = @"Musiker wählen";

        /// <summary>Prompt: Select gallery</summary>
        static public string PromptSelectGallery = @" Galerie wählen";

        #endregion // Prompt strings

        #region Tool tips

        /// <summary>Tool tip for the jazz main photo dialog</summary>
        static public string ToolTipPhotoMainForm = @"Fotos (JPG)" + NewLine() +
                                                    @"* Hoch- und herunterladen von ZIP-Dateien" + NewLine() +
                                                    @"* Galerie zufügen" + NewLine() +
                                                    @"* Slideshows administrieren";

        /// <summary>Tool tip for the help button in the jazz main photo dialog</summary>
        static public string ToolTipPhotoMainHelp = @"Hier klicken um Hilfe zu erhalten." + "\n" +
                                                    @"Ein Hilfedokument (die letzte/aktuelle Version) wird vom Server zum Ordner Help" + NewLine() +
                                                    @"heruntergeladen und in einem Popup-Fenster angezeigt." + NewLine() +
                                                    @"Das Hilfedokument kann man auch mit Word anschauen." + NewLine() +
                                                    @"Das Hilfedokument kann als Benutzer geändert und mit einer Admin Funktion zum Server" + NewLine() +
                                                    @"hochgeladen werden." + NewLine() +
                                                    @"Die Funktion ist im JAZZ live AARAU Admin -> Dokumente -> Hilfedokument zugänglich.";

        /// <summary>Tool tip for the help button in the jazz main photo dialog</summary>
        static public string ToolTipPhotoMainCheckinCheckout = @"Editieren von Fotodaten erst nach Checkout möglich." + NewLine() +
                                                               @"Nach Klick auf dem Pfeil nach oben (Galerie hochladen) mit 'Speichern' bestätigen." + NewLine() +
                                                               @"Checkout nicht möglich, falls jemand anders gleichzeitig Fotodaten editiert.";

        /// <summary>Tool tip message the main photo dialog</summary>
        static public string ToolTipPhotoFormMsg = @"Meldungen von den Fotofunktionen";

        /// <summary>Tool tip download compressed (ZIP) files with photos</summary>
        static public string ToolTipPhotoDownloadZipFiles = @"Herunterladen von ZIP-Dateien ohne Checkout";

        /// <summary>Tool tip upload compressed (ZIP) files with photos</summary>
        static public string ToolTipPhotoUploadZipFiles = @"Ersetzen von ZIP-Dateien nach Checkout";

        /// <summary>Tool tip add compressed (ZIP) files with photos</summary>
        static public string ToolTipPhotoAddZipFiles = @"Zufügen von einer ZIP-Datei nach Checkout";

        /// <summary>Tool tip search (ZIP) files with photos</summary>
        static public string ToolTipPhotoSearchZipFiles = @"Suchen - mit Bandname, Musikername oder Jahr - nach einer Zip-Datei";

        /// <summary>Tool tip shows number of (ZIP) files with photos</summary>
        static public string ToolTipPhotoNumberOfZipFiles = @"Zeigt Anzahl gefundene Zip-Dateien";

        /// <summary>Tool tip shows date and bandname for the selected ZIP file</summary>
        static public string ToolTipDateBandZipFiles = @"Zeigt Datum und Bandname für die gewählte Zip-Datei";

        /// <summary>Tool tip functions for maintenace, check and clean of photo data</summary>
        static public string ToolTipPhotoDeveloper = @"Funktionen für Kontroll und Pflege von den Fotodaten";

        /// <summary>Tool tip edit for a photo dialog</summary>
        static public string ToolTipPhotoFormEdit = @"Hier klicken für Änderungen (nur möglich nach Checkout)";

        /// <summary>Tool tip cancel for a photo dialog</summary>
        static public string ToolTipPhotoFormCancel = @"Zurück zum Hauptdialog ohne Änderungen zu speichern";

        /// <summary>Tool tip close for a photo dialog</summary>
        static public string ToolTipPhotoFormClose = @"Änderungen übernehmen und zurück zum Hauptdialog";

        /// <summary>Tool tip photo test functions</summary>
        static public string ToolTipPhotoCheckFunctions = @"Funktion für Kontrolle von Fotodaten und Fotofunktionen";

        /// <summary>Tool tip for the jazz developer photo dialog</summary>
        static public string ToolTipPhotoDeveloperForm = @"Kontroll und Pflege von Fotodaten" + NewLine() +
                                                         @"* Test Foto-Funktionen" + NewLine() +
                                                         @"* Liste mit Tooltips" + NewLine() +
                                                         @"* Herunterladen von Galerie HTM Dateien" + NewLine() +
                                                         @"* Detaillierte Infos über Foto-Funktionen und Daten" + NewLine() +
                                                         @"* Liste mit Fehlern und Vorschlägen für neue Funktionen";

        /// <summary>Tool tip list all photo tooltips</summary>
        static public string ToolTipPhotoToolTip = @"Generiert eine Liste mit allen Foto-Tooltips";

        /// <summary>Tool tip download all photo gallery two HTM files</summary>
        static public string ToolTipPhotoDownloadGalleryHtm = @"Herunterladen von allen Galerie HTM Dateien";

        /// <summary>Tool tip download get manual for maintenance</summary>
        static public string ToolTipPhotoMaintenanceHelp = @"Hier klicken um Hilfe für Datenwartung zu erhalten." + "\n" +
                                                           @"Ein Hilfedokument (die letzte/aktuelle Version) wird vom Server zum Ordner Help" + NewLine() +
                                                           @"heruntergeladen und in einem Popup-Fenster angezeigt." + NewLine() +
                                                           @"Das Hilfedokument kann auch mit Word angeschaut werden." + NewLine() +
                                                           @"Das Hilfedokument kann als Benutzer geändert und mit einer Admin Funktion zum Server" + NewLine() +
                                                           @"hochgeladen werden (diese Funktion ist im JAZZ live AARAU Admin -> Dokumente -> Hilfedokument " + NewLine() +
                                                           @"zugänglich).";

        /// <summary>Tool tip download list with bugs and proposals for new Admin functions</summary>
        static public string ToolTipAdminBugsNewFunctions = @"Hier klicken um eine Liste mit Fehlern und Vorschlägen für neue Funktionen zu erhalten." + "\n" +
                                                            @"Die Liste (die letzte/aktuelle Version) wird vom Server zum Ordner Help" + NewLine() +
                                                            @"heruntergeladen und in einem Popup-Fenster angezeigt." + NewLine() +
                                                            @"Die Liste kann auch mit Word angeschaut werden." + NewLine() +
                                                            @"Die Liste kann als Benutzer geändert und mit einer Admin Funktion zum Server" + NewLine() +
                                                            @"hochgeladen werden (diese Funktion ist im JAZZ live AARAU Admin -> Dokumente -> Hilfedokument " + NewLine() +
                                                            @"zugänglich).";


        /// <summary>Tool tip for the jazz ZIP photo dialog</summary>
        static public string ToolTipPhotoZipForm = @"Aufladen von einer neuen ZIP Datei mit Fotos von einem Konzert" + NewLine() +
                                                   @"Die Namen der Fotos (JPG-Dateien) sollten mit den Musikernamen konstruiert werden." + NewLine() +
                                                   @"Es sollen die Originalfotos sein, d.h. Fotos mit hoher Auflösung." + NewLine() +
                                                   @"Ein neuer Galeriename (zum Beispiel G121) für die Fotos wird generiert." + NewLine() +
                                                   @"Die ZIP Datei wird in der Foto XML-Datei auf dem Server registriert";

        /// <summary>Tool tip for the jazz ZIP photo dialog</summary>
        static public string ToolTipPhotoZipMsg = @"Meldungen von den ZIP-Fotofunktionen";

        /// <summary>Tool tip photographer name</summary>
        static public string ToolTipZipFormPhotographer = @"Name des Fotografens. Vorname und Nachname eingeben";

        /// <summary>Tool tip for the ZIP file name</summary>
        static public string ToolTipPhotoZipName = @"Zeigt den Namen der aufgeladenen ZIP-Datei" + NewLine() +
                                                   @"Der Name wird vom Admin-Programm bestimmt";

        /// <summary>Tool tip upload ZIP file</summary>
        static public string ToolTipZipFormUpload = @"Hochladen von ZIP-Datei mit Fotos nach Checkout";

        /// <summary>Tool tip for the jazz ZIP photo icon</summary>
        static public string ToolTipPhotoZipDatei = @"ZIP-Datei (von englisch zipper ‚Reißverschluss‘) ist ein Format für komprimierte Dateien." + NewLine() +
                                                    @"Es gibt zahlreiche Programme die ZIP-Dateien generieren und bearbeiten können." + NewLine() +
                                                    @"Zum Beispiel WinZip und 7-Zip";


        /// <summary>Tool tip for the jazz ZIP concert combobox</summary>
        static public string ToolTipPhotoZipConcert = @"Mit der Dropdown-Liste Konzert wählen." + NewLine() +
                                                      @"Nur Konzerte ohne ZIP-Dateien werden gezeigt.";

        /// <summary>Tool tip for the jazz ZIP season combobox</summary>
        static public string ToolTipPhotoZipSeason = @"Mit der Dropdown-Liste Saison wählen." + NewLine() +
                                                     @"Normalerweise ist es die aktuelle Saison.";

        /// <summary>Tool tip for the jazz ZIP season combobox</summary>
        static public string ToolTipPhotoZipList = @"Generiert zwei Listen:" + NewLine() +
                                                   @"- Galerien ohne ZIP-Dateien" + NewLine() +
                                                   @"- Fehlende ZIP Dateien auf dem Server";

        /// <summary>Tool tip add a gallery</summary>
        static public string ToolTipPhotoAddGallery = @"Zufügen von einer Galerie." + NewLine() +
                                                      @"Zuerst wird Ordner und Dateien im Computer kreiert." + NewLine() +
                                                      @"Danach wird die Galerie hochladen (nach Checkout).";

        /// <summary>Tool tip gallery</summary>
        static public string ToolTipPhotoGallery = @"Eine Galerie besteht aus neun Fotos und zehn HTML Dateien." + NewLine() +
                                                   @"Alle Dateien werden in einem Konzert-Ordner auf dem Server gespeichert.";

        /// <summary>Tool tip upload gallery</summary>
        static public string ToolTipGalleryUpload = @"Hochladen von Galerie mit Fotos nach Checkout";

        /// <summary>Tool tip for the gallery combobox</summary>
        static public string ToolTipGallerySelection = @"Mit der Dropdown-Liste Galerie (Konzert) wählen." + NewLine() +
                                                       @"Nur Konzerte mit einer ZIP-Datei sind in der Liste.";

        /// <summary>Tool tip for the gallery number</summary>
        static public string ToolTipGalleryNumber = @"Jede Galerie hat eine Registrierungsnummer." + NewLine() +
                                                    @"Diese Nummer ist ein Teil von jedem Foto und HTML Datei-Name";

        #endregion // Tool tips

        #region Create text file with all tool tips


        /// <summary>All tool tips names</summary>
        static private string[] m_tool_tip_names =
        {
            @"ToolTipPhotoMainForm",  // 0
            @"ToolTipPhotoMainHelp", // 1
            @"ToolTipPhotoMainCheckinCheckout", // 2
            @"ToolTipPhotoFormMsg", // 3
            @"ToolTipPhotoDownloadZipFiles",  // 4
            @"ToolTipPhotoUploadZipFiles",  // 5
            @"ToolTipPhotoAddZipFiles",  // 6 
            @"ToolTipPhotoSearchZipFiles",  // 7 
            @"ToolTipPhotoNumberOfZipFiles",  // 8
            @"ToolTipDateBandZipFiles",  // 9 
            @"ToolTipPhotoDeveloper",  // 10 
            @"ToolTipPhotoFormEdit",  // 11 
            @"ToolTipPhotoFormCancel",  // 12 
            @"ToolTipPhotoFormClose",  // 13 
            @"ToolTipPhotoCheckFunctions",  // 14 
            @"ToolTipPhotoDeveloperForm",  // 15 
            @"ToolTipPhotoToolTip",  // 16 
            @"ToolTipPhotoDownloadGalleryHtm",  // 17 
            @"ToolTipPhotoMaintenanceHelp",  // 18 
            @"ToolTipAdminBugsNewFunctions",  // 19 
            @"ToolTipPhotoZipForm",  // 20
            @"ToolTipPhotoZipMsg",  // 21
            @"ToolTipZipFormPhotographer",  // 22
            @"ToolTipPhotoZipName",  // 23
            @"ToolTipZipFormUpload",  // 24
            @"ToolTipPhotoZipConcert",  // 25
            @"ToolTipPhotoZipSeason",  // 26
            @"ToolTipPhotoZipList",  // 27
            @"ToolTipPhotoAddGallery",  // 28
            @"ToolTipPhotoGallery",  // 29
            @"ToolTipGalleryUpload",  // 30
            @"ToolTipGallerySelection",  // 31
            @"ToolTipGalleryNumber",  // 32

        }; // m_tool_tip_names

        /// <summary>Create file with all tool tips</summary>
        public static void CreateFileToolTips(out string o_file_name)
        {
            o_file_name = @"";

            string[] m_tool_tips = new string[33];
            m_tool_tips[0] = ToolTipPhotoMainForm;  // 0
            m_tool_tips[1] = ToolTipPhotoMainHelp; // 1
            m_tool_tips[2] = ToolTipPhotoMainCheckinCheckout; // 2
            m_tool_tips[3] = ToolTipPhotoFormMsg; // 3
            m_tool_tips[4] = ToolTipPhotoDownloadZipFiles;  // 4
            m_tool_tips[5] = ToolTipPhotoUploadZipFiles;  // 5
            m_tool_tips[6] = ToolTipPhotoAddZipFiles;  // 6 
            m_tool_tips[7] = ToolTipPhotoSearchZipFiles;  // 7 
            m_tool_tips[8] = ToolTipPhotoNumberOfZipFiles;  // 8
            m_tool_tips[9] = ToolTipDateBandZipFiles;  // 9 
            m_tool_tips[10] = ToolTipPhotoDeveloper;  // 10 
            m_tool_tips[11] = ToolTipPhotoFormEdit;  // 11 
            m_tool_tips[12] = ToolTipPhotoFormCancel;  // 12 
            m_tool_tips[13] = ToolTipPhotoFormClose;  // 13 
            m_tool_tips[14] = ToolTipPhotoCheckFunctions;  // 14 
            m_tool_tips[15] = ToolTipPhotoDeveloperForm;  // 15 
            m_tool_tips[16] = ToolTipPhotoToolTip;  // 16
            m_tool_tips[17] = ToolTipPhotoDownloadGalleryHtm;  // 17
            m_tool_tips[18] = ToolTipPhotoMaintenanceHelp;  // 18
            m_tool_tips[19] = ToolTipAdminBugsNewFunctions;  // 19
            m_tool_tips[20] = ToolTipPhotoZipForm;  // 20
            m_tool_tips[21] = ToolTipPhotoZipMsg;  // 21
            m_tool_tips[22] = ToolTipZipFormPhotographer;  // 22
            m_tool_tips[23] = ToolTipPhotoZipName;  // 23
            m_tool_tips[24] = ToolTipZipFormUpload;  // 24
            m_tool_tips[25] = ToolTipPhotoZipConcert;  // 25
            m_tool_tips[26] = ToolTipPhotoZipSeason;  // 26
            m_tool_tips[27] = ToolTipPhotoZipList;  // 27
            m_tool_tips[28] = ToolTipPhotoAddGallery;  // 28
            m_tool_tips[29] = ToolTipPhotoGallery;  // 29
            m_tool_tips[30] = ToolTipGalleryUpload;  // 30
            m_tool_tips[31] = ToolTipGallerySelection;  // 31
            m_tool_tips[32] = ToolTipGalleryNumber;  // 32


            string out_str = @"ToolTips for Photo (Fotos (JPG)) functions " + TimeUtil.YearMonthDayIso() + NewLine();
            out_str = out_str + @"====================================================" + NewLine() + NewLine();

            for (int index_tip = 0; index_tip < m_tool_tip_names.Length; index_tip++)
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
                out_str = out_str + tip_number + m_tool_tip_names[index_tip] + @"= " + NewLine() + m_tool_tips[index_tip] + NewLine() + NewLine();
            }

            out_str = out_str + WorkFlow();

            string file_name = @"ToolTipsFotoFunktionen" + TimeUtil.YearMonthDay() + @".txt";

            string local_address_directory = FileUtil.SubDirectory(PhotoMain.PhotoMaintenanceDir, Main.m_exe_directory) + @"\";

            string full_file_name = local_address_directory + file_name;

            File.WriteAllText(full_file_name, out_str);

            o_file_name = full_file_name;

        } // CreateFileToolTips

        /// <summary>Returns new line (for Windows)</summary>
        private static string NewLine() { return "\r\n"; }

        /// <summary>Returns the work flow for a change of tooltips</summary>
        private static string WorkFlow()
        {
            string work_flow = @"";

            work_flow = work_flow + NewLine();

            work_flow = work_flow + @"Arbeitsablauf für Änderungen an Tooltips:" + NewLine();
            work_flow = work_flow + @"* Generiere diese Tooltips-Liste im Programm Admin" + NewLine();
            work_flow = work_flow + @"* Öffne ein neues Dokument zum Beispiel ToolTipsAenderungen.docx" + NewLine();
            work_flow = work_flow + @"* Kopiere die Texte, die geändert werden sollen, von der Tooltips-Liste zu ToolTipsAenderungen.docx" + NewLine();
            work_flow = work_flow + @"* Ändere die Tooltips - Texte" + NewLine();
            work_flow = work_flow + @"* Schicke das Dokument ToolTipsAenderungen.docx an den Admin-Entwickler" + NewLine();
            work_flow = work_flow + @"* Kontrolliere, dass die Änderungen in der nächsten Admin - Version eingeführt sind" + NewLine();

            work_flow = work_flow + NewLine();

            return work_flow;

        } // WorkFlow

        #endregion // Create text file with all tool tips

    } // PhotoStrings
} // namespace
