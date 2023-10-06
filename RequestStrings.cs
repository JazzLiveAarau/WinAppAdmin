using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Holds requests strings
    /// <para></para>
    /// </summary>
    static public class RequestStrings
    {
        #region Titles

        /// <summary>Title for requests main form</summary>
        static public string TitleRequestForm = @"Anfragen";

        /// <summary>Title for the form for edit of an JazzReq object and download/upload of mp3 files</summary>
        static public string TitleRequestBandForm = @"Anfrage editieren oder löschen. Herunter- und Hinaufladen von mp3 Dateien";

        /// <summary>Title for requests main form</summary>
        static public string TitleRequestPdfForm = @"Herunter- und Hinaufladen von einer Information Datei";

        /// <summary>Title for request links form</summary>
        static public string TitleRequestLinksForm = @"Links zu Videos, Sounds und Webseiten";

        /// <summary>Title for requests date form</summary>
        static public string TitleRequestDateForm = @"Datum der Anfrage";

        /// <summary>Title for requests developer form</summary>
        static public string TitleRequestDeveloperForm = @"Funktionen für Kontroll und Pflege von Anfragedaten";

        #endregion Titles

        #region Messages

        /// <summary>Message: Upload of file</summary>
        static public string MsgUploadFile = @"Hochladen von Datei ";

        /// <summary>Message: Delete of file</summary>
        static public string MsgDeleteFile = @"Löschen von Datei ";

        /// <summary>Message: All files uploaded</summary>
        static public string MsgAllFilesUploaded = @"Alle Audio-Dateien sind auf dem Server";

        /// <summary>Message: Download of file</summary>
        static public string MsgDownloadFile = @"Herunterladen von Datei ";

        /// <summary>Message: All files downloaded</summary>
        static public string MsgAllFilesDownloaded = @"Alle Audio-Dateien sind heruntergeladen";

        /// <summary>Message: One file downloaded</summary>
        static public string MsgOneFileDownloaded = @"Audio-Datei ist heruntergeladen";

        /// <summary>Message: Directory for upload not selected</summary>
        static public string MsgUploadDirectoryNotSelected = @"Ordner nicht gewählt";

        /// <summary>Message: Directory for download not selected</summary>
        static public string MsgDownloadDirectoryNotSelected = @"Ordner nicht gewählt";

        /// <summary>Message: Delete of sound files/summary>
        static public string MsgDeleteOfSoundFiles = @"Die Sound-Dateien (mp3) werden entgültig gelöscht." + "\n" +
                                                     @"Nach dem Löschen muss man Speichern (Checkin machen)." + "\n" +
                                                     @"Ende ohne zu speichern is möglich aber ist nicht erlaubt.";

        /// <summary>Message: Information file is downloaded</summary>
        static public string MsgInfoFileDownloaded = @" ist heruntergeladen";

        /// <summary>Message: Photo file is downloaded</summary>
        static public string MsgPhotoFileDownloaded = @" ist heruntergeladen";

        /// <summary>Message: Information file is uploaded</summary>
        static public string MsgInfoFileUploaded = @" ist hochgeladen";

        /// <summary>Message: photo file is uploaded</summary>
        static public string MsgPhotoFileUploaded = @" ist hochgeladen";

        /// <summary>Message: Information file is deleted</summary>
        static public string MsgInfoFileDeleted = @" ist gelöscht";

        /// <summary>Message: Photo file is deleted</summary>
        static public string MsgPhotoFileDeleted = @" ist gelöscht";

        /// <summary>Message: Photo file is renamed for delete</summary>
        static public string MsgPhotoFileRenamed = @" ist umbennent zu ";

        /// <summary>Message: Function is not yet implemented</summary>
        static public string MsgFunctionNotYetImplemented = @" ist noch nicht implementiert";

        #endregion // Messages

        #region Prompts

        /// <summary>Prompt for adding an additional request</summary>
        static public string PromptAddRequest = @"Anfrage zufügen";

        /// <summary>Prompt for selection of a request</summary>
        static public string PromptSelectRequest = @"Anfrage wählen";

        /// <summary>Prompt for selection of an information document</summary>
        static public string PromptSelectInfo = @"Dokument wählen";

        /// <summary>Prompt for selection of a photo</summary>
        static public string PromptSelectPhoto = @"Foto Datei wählen";

        /// <summary>Prompt for selection concert number</summary>
        static public string PromptSelectConcertNumber = @"Konzert der nächsten Saison wählen";

        /// <summary>Prompt select required data</summary>
        static public string PromptSelectRequiredData = @"Unterlage-Text wählen";

        /// <summary>Required data is not selected </summary>
        static public string RequiredDataNotSelected = @" --- ";

        /// <summary>Prompt for required data item (number)</summary>
        static public string ItemTextRequiredData = @"Unterlage ";

        #endregion // Prompts

        #region Labels

        /// <summary>Label for information</summary>
        static public string LabelInformation = @"Information";

        /// <summary>Label links</summary>
        static public string LabelLinks = @"Links";

        /// <summary>Label link</summary>
        static public string LabelLink = @"Link";

        /// <summary>Label information one file</summary>
        static public string LabelInfoOne = @"Info 1";

        /// <summary>Label information two file</summary>
        static public string LabelInfoTwo = @"Info 2";

        /// <summary>Label information three file</summary>
        static public string LabelInfoThree = @"Info 3";

        /// <summary>Label photo file</summary>
        static private string LabelPhoto = @"Bild";

        /// <summary>returns label photo file</summary>
        static public string GetPhotoLabel(int i_photo_number) { return LabelPhoto + @" " + i_photo_number.ToString(); }

        /// <summary>Label For evaluation</summary>
        static public string LabelForEvaluation = @"Zum Evaluieren";

        /// <summary>Label For selected bands</summary>
        static public string LabelSelectedBands = @"Ausgewählte";

        /// <summary>Label CD links</summary>
        static public string LabelCdLinks = @"CD Links";

        /// <summary>Label video links</summary>
        static public string LabelVideoLinks = @"Video Links";

        /// <summary>Label information files</summary>
        static public string LabelInfoFiles = @"Info Dateien";

        /// <summary>Label for band name</summary>
        static public string LabelBandName = @"Name";

        /// <summary>Label for comments</summary>
        static public string LabelComments = @"Kommentare";

        /// <summary>Label for private notes</summary>
        static public string LabelPrivateNotes = @"Eigene Notizen";

        /// <summary>Label for link to video</summary>
        static public string LabelVideoLink = @"Video Link";

        /// <summary>Label for link to video</summary>
        static public string LabelSoundLink = @"Sound Link";

        /// <summary>Label for link to website</summary>
        static public string LabelWebsiteLink = @"Website Link";

        /// <summary>Label for audio CDs</summary>
        static public string LabelAudio = @"Audio";

        /// <summary>Label for audio one CDs</summary>
        static public string LabelAudioOne = @"Audio 1";

        /// <summary>Label for audio two CDs</summary>
        static public string LabelAudioTwo = @"Audio 2";

        /// <summary>Label for audio three CDs</summary>
        static public string LabelAudioThree = @"Audio 3";

        /// <summary>Label for information 1 file</summary>
        static public string LabelInfoFileOne = @"Info Datei 1";

        /// <summary>Label for information 2 file</summary>
        static public string LabelInfoFileTwo = @"Info Datei 2";

        /// <summary>Label for information 3 file</summary>
        static public string LabelInfoFileThree = @"Info Datei 3";

        /// <summary>Label web page</summary>
        static public string LabelWebPage = @"Webseite";

        /// <summary>Label concert number</summary>
        static public string LabelConcertNumber = @"Konzert Nr";

        #endregion // Labels

        #region Error messages

        /// <summary>Error message: Checkout of requests XML is necessary for adding an additional request</summary>
        static public string ErrMsgCheckoutBeforeAddingRequest = @"Anfrage zuzufügen nur nach Checkout";

        /// <summary>Error message: Checkout of requests XML is necessary for removing a request</summary>
        static public string ErrMsgCheckoutBeforeRemovingRequest = @"Anfrage löschen nur nach Checkout";

        /// <summary>Error message: There are no files in the directory</summary>
        static public string ErrMsgDirectoryIsEmpty = @"Keine Dateien im Ordner ";

        /// <summary>Error message: There are no sound files in the directory</summary>
        static public string ErrMsgDirectoryHasNoSoundFiles = @"Keine mp3, mp4, m4a oder wav Dateien im Ordner ";

        /// <summary>Error message: Upload only after checkout</summary>
        static public string ErrMsgUploadOnlyAfterCheckout = @"Hochladen nur nach Checkout";

        /// <summary>Error message: Delete only after checkout</summary>
        static public string ErrMsgDeleteOnlyAfterCheckout = @"Löschen nur nach Checkout";

        /// <summary>Error message: Change of date only after checkout</summary>
        static public string ErrMsgDateChangeOnlyAfterCheckout = @"Änderung des Datums nur nach Checkout";

        /// <summary>Error message: Band name must be set</summary>
        static public string ErrMsgBandNameNotSet = @"Bandname darf nicht leer sein.";

        /// <summary>Error message: Band must be unique</summary>
        static public string ErrMsgBandNameNotUnique = @"Es gibt eine andere Anfrage mit dem gleichen Bandname. Das ist nicht erlaubt";

        /// <summary>Error message: Type of link must be defined</summary>
        static public string ErrMsgTypeOfLinkNotSet = @"Typ von Link (Video, Sound oder Website) muss definiert sein. Das ist nicht der Fall für Link ";

        /// <summary>Error message: Multiple type of links are not allowed </summary>
        static public string ErrMsgTypeOfLinkMultiple = @"Nur ein Typ von Link (Video, Sound oder Website) ist erlaubt. Das ist nicht der Fall für Link ";

        /// <summary>Error message: No request is selected</summary>
        static public string ErrMsgNoSelectedRequests = @"Keine Anfragen sind für Konzerte ausgewählt";

        /// <summary>Error message: Checkout of requests XML is necessary for clean</summary>
        static public string ErrMsgCheckoutBeforeCleaning = @"Clean nur nach Checkout";

        #endregion // Error messages

        #region Tool tips

        /// <summary>Tool tip for the jazz main request dialog</summary>
        static public string ToolTipReqMainForm = @"Anfragen (MP3)" + NewLine() +
                                                  @"* Anfragen registrieren" + NewLine() +
                                                  @"* Hoch- und herunterladen von Audio-Dateien" + NewLine() +
                                                  @"* Dokumente hoch- und herunterladen" + NewLine() +
                                                  @"* Fotos hoch- und herunterladen" + NewLine() +
                                                  @"* Links zu Video-, Sound- und Homepages" + NewLine() +
                                                  @"* Verschiedene Anfragelisten generieren";

        /// <summary>Tool tip for the help button in the jazz main request dialog</summary>
        static public string ToolTipReqMainHelp = @"Hier klicken um Hilfe zu erhalten." + NewLine() +
                                                  @"Ein Hilfedokument (die letzte/aktuelle Version) wird vom Server zum Ordner Help" + NewLine() +
                                                  @"heruntergeladen und in einem Popup-Fenster angezeigt." + NewLine() +
                                                  @"Das Hilfedokument kann man auch mit Word anschauen." + NewLine() +
                                                  @"Das Hilfedokument kann als Benutzer geändert und mit einer Admin Funktion zum Server" + NewLine() +
                                                  @"hochgeladen werden." + NewLine() +
                                                  @"Die Funktion ist im JAZZ live AARAU Admin -> Dokumente -> Hilfedokument zugänglich.";

        /// <summary>Tool tip for the edit button of the jazz main request dialog</summary>
        static public string ToolTipReqMainCheckinCheckout = @"Editieren von Anfragedaten erst nach Checkout möglich." + NewLine() +
                                                  @"Checkout nicht möglich, falls jemand anders gleichzeitig Anfragedaten editiert." + NewLine() +
                                                  @"Nach Checkout Anfragedaten speichern.";

        /// <summary>Tool tip for the combo box Select request in the jazz main request dialog</summary>
        static public string ToolTipReqMainSelect = @"Anfrage wählen. Die Bandnamen werden gelisted." + NewLine() +
                                                    @"Eine neue Anfrage kann zugefügt werden." + NewLine() +
                                                    @"Checkout ist notwendig für eine neue Anfrage.";

        /// <summary>Tool tip for the requests list option Private notes (in the jazz main request dialog)</summary>
        static public string ToolTipReqMainPrivateNotes = @"Option 'Eigene Notizen' für die Anfrageliste." + NewLine() +
                                                    @"Eigene Notizen werden ausschliesslich im eigenen Computer gespeichert." + NewLine() +
                                                    @"Anfrageliste kann mit oder ohne Eigene Notizen generiert werden.";

        /// <summary>Tool tip for the requests list option Evaluate band (in the jazz main request dialog)</summary>
        static public string ToolTipReqMainEvaluateBand = @"Option 'Zum Evaluieren' für die Anfrageliste." + NewLine() +
                                                    @"Generiert eine Liste mit Anfragen, die bei der nächsten Besprechung beurteilt werden sollen." + NewLine() +
                                                    @"Option 'Ausgewählte' kann nicht gleichzeitig aktiviert werden.";

        /// <summary>Tool tip for the requests list option Show URLs (in the jazz main request dialog)</summary>
        static public string ToolTipReqMainCdUrls = @"Option 'CD Links' für die Anfrageliste." + NewLine() +
                                                    @"mp3-Dateien werden auf dem Server gespeichert. " + NewLine() +
                                                    @"Mit diesen Links kann die Musik im Browser gestreamt sowie heruntergeladen werden.";

        /// <summary>Tool tip for the create of a requests TXT list (in the jazz main request dialog)</summary>
        static public string ToolTipReqMainCreateList = @"Anfragen in einer Liste als TXT-Datei zeigen." + NewLine() +
                                                        @"Die Anfrageliste ist im Computer gespeichert unter C:/Apps/JazzLiveAarau/Admin/Anfragen." + NewLine() +
                                                        @"Optionen für die Anfrageliste: Eigene Notizen, CD Links etc.";

        /// <summary>Tool tip for the create of a requests TXT list (in the jazz main request dialog)</summary>
        static public string ToolTipReqMainCreateListHtm = @"Anfragen in einer Liste als HTM-Datei zeigen." + NewLine() +
                                                           @"Die Anfrageliste ist im Computer gespeichert unter C:/Apps/JazzLiveAarau/Admin/Anfragen." + NewLine() +
                                                           @"Optionen für die Anfrageliste: Eigene Notizen, CD Links etc.";

        /// <summary>Tool tip for the create of a requests TXT list (in the jazz main request dialog)</summary>
        static public string ToolTipReqMainCreateLists = @"Anfragen in Listen als TXT- oder HTM-Datei zeigen." + NewLine() +
                                                         @"Die Anfrageliste ist im Computer gespeichert unter C:/Apps/JazzLiveAarau/Admin/Anfragen." + NewLine() +
                                                         @"Optionen für die Anfrageliste: Eigene Notizen, CD Links etc.";

        /// <summary>Tool tip for the jazz band request dialog</summary>
        static public string ToolTipReqForm = @"Hoch- und herunterladen von Audio-Dateien";

        /// <summary>Tool tip edit for the jazz band request dialog</summary>
        static public string ToolTipReqFormEdit   = @"Hier klicken für Änderungen (nur möglich nach Checkout)";

        /// <summary>Tool tip cancel for the request band dialog</summary>
        static public string ToolTipReqFormCancel = @"Zurück zum Hauptdialog ohne Änderungen zu speichern";

        /// <summary>Tool tip close for the request band dialog</summary>
        static public string ToolTipReqFormClose = @"Änderungen übernehmen und zurück zum Hauptdialog";

        /// <summary>Tool tip message the request band dialog</summary>
        static public string ToolTipReqFormMsg = @"Meldungen von den Anfragefunktionen";

        /// <summary>Tool tip delete a request</summary>
        static public string ToolTipReqDelete = @"Löschen dieser Anfrage nach Checkout (inkl. aller Daten wie Audio usw.)";

        /// <summary>Tool tip band name</summary>
        static public string ToolTipReqBandName = @"Name der Band (darf weder leer noch gleich wie bei einer anderen Anfrage sein)";

        /// <summary>Tool tip evaluate</summary>
        static public string ToolTipReqEvaluate = @"Zum Beurteilen bei der nächsten Besprechung (Eine Liste dieser Bands kann generiert werden)";
        /// <summary>Tool tip comments</summary>
        static public string ToolTipReqComments = @"Allgemeine Kommentare";

        /// <summary>Tool tip private notes</summary>
        static public string ToolTipReqPrivateNotes = @"Eigene Notizen" + NewLine() +
                                                      @"Andere Benutzer können diese persönlichen Notizen nicht einsehen." + NewLine() +
                                                      @"Sie werden ausschliesslich auf diesem Computer gespeichert.";

        /// <summary>Tool tip download audio (mp3, mp4, m4a and wav) files</summary>
        static public string ToolTipReqDownloadAudioFiles = @"Herunterladen von Audio-Dateien (mp3, mp4, m4a, wav / ganzes Album oder einzeln) ohne Checkout";

        /// <summary>Tool tip upload audio (mp3, mp4, m4a and wav) files</summary>
        static public string ToolTipReqUploadAudioFiles = @"Hochladen von Audio-Dateien (mp3, mp4, m4a, wav / ausschliesslich ganzes Album) nach Checkout";


        /// <summary>Tool tip delete audio (mp3, mp4, m4a and wav) files</summary>
        static public string ToolTipReqDeleteAudioFiles = @"Löschen von Audio-Dateien (mp3, mp4, m4a, wav / ausschliesslich ganzes Album) nach Checkout";

        /// <summary>Tool tip audio (mp3, mp4 and wav) files</summary>
        static public string ToolTipReqAudioFiles = @"Zeigt auf dem Server gespeicherte (mp3, mp4, m4a und wav) Audio-Dateien." + NewLine() +
                                                    @"Beim Herunterladen CD- (alle) oder Track-Name (einzeln) wählen.";

        /// <summary>Tool tip text info files</summary>
        static public string ToolTipReqInfoFiles = @"Text-Dateien mit zusätzlichen Informationen der Anfrage." + NewLine() +
                                                   @"Wird eine Datei ausgewählt, öffnet sich ein neuer Dialog." + NewLine() +
                                                   @"Dateiname ‘---' bedeutet, dass es keine Datei auf dem Server gibt.";


        /// <summary>Tool tip download info file</summary>
        static public string ToolTipReqDownloadInfoFile = @"Herunterladen der PDF-Datei ohne Checkout";

        /// <summary>Tool tip download info file</summary>
        static public string ToolTipReqUploadInfoFile = @"Hochladen der PDF-Datei nach Checkout";

        /// <summary>Tool tip delete info file</summary>
        static public string ToolTipReqDeleteInfoFile = @"Löschen der PDF-Datei nach Checkout";

        /// <summary>Tool tip show info file</summary>
        static public string ToolTipReqShowInfoFile = @"Zeigt Name der PDF-Datei";

        /// <summary>Tool tip request link</summary>
        static public string ToolTipReqLink = @"Wird als Text-Link in den HTM-Anfragelisten gezeigt (z.B. Name des Tracks)." + NewLine() +
                                              @"In TXT-Anfragelisten wird Adresse (URL) gezeigt." + NewLine() +
                                              @"In HTM-Anfragelisten ist Adresse verlinkt (bitte immer vergewissern, dass Link funktioniert).";

        /// <summary>Tool tip request link text</summary>
        static public string ToolTipReqLinkText = @"Dieser Text wird als Link in den HTM Anfragelisten gezeigt." + NewLine() +
                                                  @"Linktext ist 'video', 'sound' oder 'website' wenn kein Text definiert ist.";

        /// <summary>Tool tip request link type</summary>
        static public string ToolTipReqLinkType = @"Link-Typ: Video, Sound oder Web (wird in den Anfragelisten gezeigt)";

        /// <summary>Tool tip for the requests list option Selected bands (in the jazz main request dialog)</summary>
        static public string ToolTipReqMainSelectedBands = @"Option 'Ausgewählte' für die Anfrageliste." + NewLine() +
                                                           @"Generiert eine Liste mit den für Konzerte ausgewählten Bands." + NewLine() +
                                                           @"Option 'Zum Evaluieren' kann nicht gleichzeitig aktiviert werden.";

        /// <summary>Tool tip for the requests list option Video links (in the jazz main request dialog)</summary>
        static public string ToolTipReqMainVideoLinks = @"Option 'Video Links' für die Anfrageliste." + NewLine() +
                                                        @"Die Anfrageliste enthält die Video Links.";

        /// <summary>Tool tip for the requests list option Information files(in the jazz main request dialog)</summary>
        static public string ToolTipReqMainInfoFiles = @"Option 'Info Dateien' für die Anfrageliste." + NewLine() +
                                                        @"Die Anfrageliste enthält die Video Links.";

        /// <summary>Tool tip for the requests list option Photo files(in the jazz main request dialog)</summary>
        static public string ToolTipReqMainPhotoFiles = @"Option 'Fotos' für die Anfrageliste." + NewLine() +
                                                        @"Die Anfrageliste enthält die Namen der Fotodateien.";

        /// <summary>Tool tip for for the label request date and registration number</summary>
        static public string ToolTipReqDateLabel = @"Zeigt Anfragedatum und Registrierungsnummer";

        /// <summary>Tool tip for the button request date and registration number</summary>
        static public string ToolTipReqDateButton = @"Hier klicken um Anfragedatum zu ändern";

        /// <summary>Tool tip for the date-datime-picker for the request date</summary>
        static public string ToolTipReqDateTimePicker = @"Dropdown klicken nach Checkout um Anfragedatum zu ändern";

        /// <summary>Tool tip for the jazz developer request dialog</summary>
        static public string ToolTipReqDeveloperForm = @"Kontrolle und Pflege von Anfragedaten" + NewLine() +
                                                       @"* Liste mit Tooltips" + NewLine() +
                                                       @"* Liste mit Datenfehlern" + NewLine() +
                                                       @"* Nicht länger verwendete Dateien und Ordner" + NewLine() +
                                                       @"* Detaillierte Infos über Anfrage-Funktionen und Daten" + NewLine() +
                                                       @"* Liste mit Fehlern und Vorschlägen für neue Funktionen";

        /// <summary>Tool tip list all request tooltips</summary>
        static public string ToolTipReqToolTip = @"Generiert eine Liste mit allen Anfrage-Tooltips";

        /// <summary>Tool tip request test functions</summary>
        static public string ToolTipReqCheckFunctions = @"Funktion für Kontrolle von Anfragedaten";

        /// <summary>Tool tip request clean functions</summary>
        static public string ToolTipReqCleanFunction = @"Löscht nicht länger verwendete Dateien und Ordner";

        /// <summary>Tool tip download get manual for maintenance</summary>
        static public string ToolTipReqMaintenanceHelp = @"Hier klicken um Hilfe für Datenwartung zu erhalten." + "\n" +
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

        /// <summary>Tool tip for the jazz developer request button</summary>
        static public string ToolTipReqDeveloperButton = @"Kontroll und Pflege von Anfragedaten";

        /// <summary>Tool tip for the request XML form</summary>
        static public string ToolTipReqXmlForm = @"Instruktionen und Voraussetzungen einer Anfrage" + NewLine() +
                                                  @"Folgende Texte werden mit diesem Formular definiert:" + NewLine() +
                                                  @"* Text für die Konzertdaten (siehe unten)" + NewLine() +
                                                  @"* Liste mit notwendigen Unterlagen" + NewLine() +
                                                  @"* E-Mail-Adresse für Anfragen" + NewLine() +
                                                  @"* Text wenn das Programm komplett ist" + NewLine() +
                                                  @"Die Daten für die Konzerte der nächste Saison bitte zuerst eingeben" + NewLine() +
                                                  @"Diese Daten werden von der XML Datei geholt und auf der Anfrage Seite gezeigt";

        /// <summary>Tool tip for the edit button of the requests XML form</summary>
        static public string ToolTipReqXmlCheckinCheckout = @"Editieren von Texten erst nach Checkout möglich." + NewLine() +
                                                  @"Checkout nicht möglich, falls jemand anders gleichzeitig die Texte editiert." + NewLine() +
                                                  @"Nach Checkout die Texte speichern.";

        /// <summary>Tool tip for the checkbox display concert dates</summary>
        static public string ToolTipReqXmlDisplayDates = @"Bitte wählen wenn die Konzertdaten und die zugehörigen Texte gezeigt werden sollen." + NewLine() +
                                                  @"Die Daten für die Konzerte der nächste Saison bitte zuerst eingeben." + NewLine() +
                                                  @"Nicht wählen wenn der Text 'Programm komplett' gezeigt werden soll.";

        /// <summary>Tool tip for the title</summary>
        static public string ToolTipReqXmlTitle = @"Titel für die Anfrage-Instruktionen.";

        /// <summary>Tool tip for the no dates text</summary>
        static public string ToolTipReqXmlNoDates = @"Text für den Fall, dass das Programm komplett ist.";

        /// <summary>Tool tip for the dates text</summary>
        static public string ToolTipReqXmlDatesText = @"Dieser Text kommt vor die Tabelle mit Konzertdaten der nächsten Saison." + NewLine() +
                                                      @"Die Konzertdaten sollen hier nicht eingegeben werden. Die Web " + NewLine() +
                                                      @"Applikation Homepage fügt die Konzertdaten-Tabelle hinzu.";

        /// <summary>Tool tip for the text preceeding the list of compulsory data for the request</summary>
        static public string ToolTipReqXmlRequiredData = @"Text vor die Liste mit den verlangten Unterlagen der Anfrage.";

        /// <summary>Tool tip for the text of one (selected) required data item</summary>
        static public string ToolTipReqXmlRequiredItem = @"Neun obligatorische Unterlagen können definiert werden." + NewLine() +
                                                         @"Mit dem Dropdown bitte Unterlagenummer wählen unt Text eingeben.";

        /// <summary>Tool tip for the text preceeding the email address</summary>
        static public string ToolTipReqXmlEmailTitle = @"Titel für die Anfrage-E-Mail-Adresse.";

        /// <summary>Tool tip for the requests email address</summary>
        static public string ToolTipReqXmlEmailAddresse = @"E-Mail-Adresse für die Anfragen.";

        /// <summary>Tool tip for the requests email caption</summary>
        static public string ToolTipReqXmlEmailCaption = @"Beim klicken auf diesem Text wird eine E-Mail-Applikation sich öffnen.";

        /// <summary>Tool tip for the requests email remark</summary>
        static public string ToolTipReqXmlEmailRemark = @"Eine Bemerkung der E-Mail-Adresse.";

        /// <summary>Tool tip for the requests end paragraph</summary>
        static public string ToolTipReqXmlEndParagraph = @"Schluss-Kommentar des Anfragetextes.";

        #endregion // Tool tips

        #region Directory names, file names and content in text files

        /// <summary>Directory name for sound files</summary>
        static public string DirNameAudio = @"Audio";

        /// <summary>Subdirectory name for Audio One sound files (mp3)</summary>
        static public string DirNameAudioOne = @"AudioOne";

        /// <summary>Subdirectory name for Audio Two sound files (mp3)</summary>
        static public string DirNameAudioTwo = @"AudioTwo";

        /// <summary>Subdirectory name for Audio Three sound files (mp3)</summary>
        static public string DirNameAudioThree = @"AudioThree";

        /// <summary>Local sub directory for requests</summary>
        static public string LocalDirAudioFiles = @"Audio";

        /// <summary>Local sub directory for request files</summary>
        static public string LocalDirRequestFiles = @"Anfragen";

        /// <summary>Server sub directory for request files</summary>
        static public string ServerDirRequestFiles = @"Anfragen";

        /// <summary>Server sub directory for backup request files</summary>
        static public string ServerDirBackupRequestFiles = @"Backups";

        /// <summary>Local sub directory for private notes</summary>
        static public string LocalDirPrivateNotes = @"EigeneNotizen";

        /// <summary>Name for text file with all requests</summary>
        static public string RequestsTextFileNameAll = @"AnfragenAlle";

        /// <summary>Name for text file with requests that shall be evaluated</summary>
        static public string RequestsTextFileNameForEvaluation = @"AnfragenZumEvaluieren";

        /// <summary>Name for text file with requests that have been selected for a concert</summary>
        static public string RequestsTextFileNameForSelectedBands = @"AusgewaehltFuerKonzert";

        /// <summary>Header line for text file with all requests</summary>
        static public string RequestHeaderAll = @"Anfragen ";

        /// <summary>Header line for text file with requests that shall be evaluated</summary>
        static public string RequestHeaderForEvaluation = @"Anfragen zum Evaluieren";

        /// <summary>Header line for text file with requests that have been selected for concert</summary>
        static public string RequestHeaderForSelectedBands = @"Ausgewählte Bands";

        /// <summary>Extension for sound files that shall be deleted</summary>
        static public string RequestExtensionDelete = @"_to_be_deleted";

        /// <summary>Get the local directory name for request maintenance data</summary>
        public static string MaintenanceDir = "Datenwartung";

        #endregion // Directory names, file names and content in text files

        #region Captions and labels 

        /// <summary>Caption for button requests</summary>
        static public string CaptionButtonRequests = @"Anfragen (MP3)";

        /// <summary>Caption for button List requests</summary>
        static public string CaptionButtonListRequests = @"TXT";

        /// <summary>Caption for button List requests</summary>
        static public string CaptionButtonListRequestsHtm = @"HTM";

        /// <summary>Caption for button List requests</summary>
        static public string LabelButtonListRequests = @"Anfrageliste";

        /// <summary>Caption for button List requests</summary>
        static public string CaptionButtonRequestLinks = @"Links ...";

        /// <summary>Cap for the request developer button</summary>
        static public string CapRequestDeveloper = @"Datenwartung";

        #endregion // Captions and labels 

        #region Parameter values

        /// <summary>Link type video</summary>
        static public string LinkTypeVideo = @"video";

        /// <summary>Link type sound</summary>
        static public string LinkTypeSound = @"sound";

        /// <summary>Link type video</summary>
        static public string LinkTypeWebsite = @"website";

        /// <summary>Default band name for a new request</summary>
        static public string DefaultBandName = @"Bandname für Anfrage zugefügt ";

        #endregion // Parameter values

        #region Create text file with all tool tips

        /// <summary>All tool tips names</summary>
        static private string[] m_tool_tip_names =
        {
            @"ToolTipReqMainForm",  // 0
            @"ToolTipReqMainHelp", // 1
            @"ToolTipReqMainCheckinCheckout", // 2
            @"ToolTipReqMainSelect", // 3
            @"ToolTipReqMainPrivateNotes",  // 4
            @"ToolTipReqMainEvaluateBand",  // 5
            @"ToolTipReqMainCdUrls",  // 6 
            @"ToolTipReqMainCreateList",  // 7 
            @"ToolTipReqMainCreateListHtm",  // 8
            @"ToolTipReqMainCreateLists",  // 9 
            @"ToolTipReqForm",  // 10 
            @"ToolTipReqFormEdit",  // 11 
            @"ToolTipReqFormCancel",  // 12 
            @"ToolTipReqFormClose",  // 13 
            @"ToolTipReqFormMsg",  // 14 
            @"ToolTipReqDelete",  // 15 
            @"ToolTipReqBandName",  // 16
            @"ToolTipReqEvaluate", // 17
            @"ToolTipReqComments", // 18 
            @"ToolTipReqPrivateNotes", // 19
            @"ToolTipReqDownloadAudioFiles", // 20
            @"ToolTipReqUploadAudioFiles", // 21
            @"ToolTipReqDeleteAudioFiles", // 22
            @"ToolTipReqAudioFiles", // 23
            @"ToolTipReqInfoFiles", // 24
            @"ToolTipReqDownloadInfoFile", // 25
            @"ToolTipReqUploadInfoFile", // 26
            @"ToolTipReqDeleteInfoFile", // 27
            @"ToolTipReqShowInfoFile", // 28
            @"ToolTipReqLink", // 29
            @"ToolTipReqLinkText", // 30
            @"ToolTipReqLinkType", // 31
            @"ToolTipReqMainSelectedBands", // 32
            @"ToolTipReqMainVideoLinks", // 33
            @"ToolTipReqMainInfoFiles", // 34
            @"ToolTipReqMainPhotoFiles", // 35
            @"ToolTipReqDateLabel", // 36
            @"ToolTipReqDateButton", // 37
            @"ToolTipReqDateTimePicker", // 38
            @"ToolTipReqDeveloperForm", // 39
            @"ToolTipReqToolTip", // 40
            @"ToolTipReqCheckFunctions", // 41
            @"ToolTipReqCleanFunction", // 42
            @"ToolTipReqMaintenanceHelp", // 43
            @"ToolTipAdminBugsNewFunctions", // 44
            @"ToolTipReqXmlForm", // 45
            @"ToolTipReqXmlCheckinCheckout", // 46
            @"ToolTipReqXmlDisplayDates", // 47
            @"ToolTipReqXmlTitle", // 48
            @"ToolTipReqXmlNoDates", // 49
            @"ToolTipReqXmlDatesText", // 50
            @"ToolTipReqXmlRequiredData", // 51
            @"ToolTipReqXmlRequiredItem", // 52
            @"ToolTipReqXmlEmailTitle", // 53
            @"ToolTipReqXmlEmailAddresse", // 54
            @"ToolTipReqXmlEmailCaption", // 55
            @"ToolTipReqXmlEmailRemark", // 56
            @"ToolTipReqXmlEndParagraph", // 57

        }; // m_tool_tip_names

           /// <summary>Create file with all tool tips</summary>
        public static void CreateFileToolTips(out string o_file_name)
        {
            string[] m_tool_tips = new string[58];
            m_tool_tips[0] = ToolTipReqMainForm;  // 0
            m_tool_tips[1] = ToolTipReqMainHelp; // 1
            m_tool_tips[2] = ToolTipReqMainCheckinCheckout; // 2
            m_tool_tips[3] = ToolTipReqMainSelect; // 3
            m_tool_tips[4] = ToolTipReqMainPrivateNotes;  // 4
            m_tool_tips[5] = ToolTipReqMainEvaluateBand;  // 5
            m_tool_tips[6] = ToolTipReqMainCdUrls;  // 6 
            m_tool_tips[7] = ToolTipReqMainCreateList;  // 7 
            m_tool_tips[8] = ToolTipReqMainCreateListHtm;  // 8
            m_tool_tips[9] = ToolTipReqMainCreateLists;  // 9 
            m_tool_tips[10] = ToolTipReqForm;  // 10 
            m_tool_tips[11] = ToolTipReqFormEdit;  // 11 
            m_tool_tips[12] = ToolTipReqFormCancel;  // 12 
            m_tool_tips[13] = ToolTipReqFormClose;  // 13 
            m_tool_tips[14] = ToolTipReqFormMsg;  // 14 
            m_tool_tips[15] = ToolTipReqDelete;  // 15 
            m_tool_tips[16] = ToolTipReqBandName;  // 16
            m_tool_tips[17] = ToolTipReqEvaluate; // 17
            m_tool_tips[18] = ToolTipReqComments; // 18 
            m_tool_tips[19] = ToolTipReqPrivateNotes; // 19
            m_tool_tips[20] = ToolTipReqDownloadAudioFiles; // 20
            m_tool_tips[21] = ToolTipReqUploadAudioFiles; // 21
            m_tool_tips[22] = ToolTipReqDeleteAudioFiles; // 22
            m_tool_tips[23] = ToolTipReqAudioFiles; // 23
            m_tool_tips[24] = ToolTipReqInfoFiles; // 24
            m_tool_tips[25] = ToolTipReqDownloadInfoFile; // 25
            m_tool_tips[26] = ToolTipReqUploadInfoFile; // 26
            m_tool_tips[27] = ToolTipReqDeleteInfoFile; // 27
            m_tool_tips[28] = ToolTipReqShowInfoFile; // 28
            m_tool_tips[29] = ToolTipReqLink; // 29
            m_tool_tips[30] = ToolTipReqLinkText; // 30
            m_tool_tips[31] = ToolTipReqLinkType; // 31
            m_tool_tips[32] = ToolTipReqMainSelectedBands; // 32
            m_tool_tips[33] = ToolTipReqMainVideoLinks; // 33
            m_tool_tips[34] = ToolTipReqMainInfoFiles; // 34
            m_tool_tips[35] = ToolTipReqMainPhotoFiles; // 35
            m_tool_tips[36] = ToolTipReqDateLabel; // 36
            m_tool_tips[37] = ToolTipReqDateButton; // 37
            m_tool_tips[38] = ToolTipReqDateTimePicker; // 38
            m_tool_tips[39] = ToolTipReqDeveloperForm; // 39
            m_tool_tips[40] = ToolTipReqToolTip; // 40
            m_tool_tips[41] = ToolTipReqCheckFunctions; // 41
            m_tool_tips[42] = ToolTipReqCleanFunction; // 42
            m_tool_tips[43] = ToolTipReqMaintenanceHelp; // 43
            m_tool_tips[44] = ToolTipAdminBugsNewFunctions; // 44
            m_tool_tips[45] = ToolTipReqXmlForm; // 45
            m_tool_tips[46] = ToolTipReqXmlCheckinCheckout; // 46
            m_tool_tips[47] = ToolTipReqXmlDisplayDates; // 47
            m_tool_tips[48] = ToolTipReqXmlTitle; // 48
            m_tool_tips[49] = ToolTipReqXmlNoDates; // 49
            m_tool_tips[50] = ToolTipReqXmlDatesText; // 50
            m_tool_tips[51] = ToolTipReqXmlRequiredData; // 51
            m_tool_tips[52] = ToolTipReqXmlRequiredItem; // 52
            m_tool_tips[53] = ToolTipReqXmlEmailTitle; // 53
            m_tool_tips[54] = ToolTipReqXmlEmailAddresse; // 54
            m_tool_tips[55] = ToolTipReqXmlEmailCaption; // 55
            m_tool_tips[56] = ToolTipReqXmlEmailRemark; // 56
            m_tool_tips[57] = ToolTipReqXmlEndParagraph; // 57


            string out_str = @"ToolTips for Request (Anfrage) functions " + TimeUtil.YearMonthDayIso() + NewLine();
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

            string file_name = @"ToolTipsAnfrageFunktionen_" + TimeUtil.YearMonthDay() + @".txt";

            string local_address_directory = FileUtil.SubDirectory(RequestStrings.MaintenanceDir, Main.m_exe_directory) + @"\";

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

    } // RequestStrings

} // namespace
