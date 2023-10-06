using System;
using System.IO;
using System.Xml.Serialization;

namespace JazzAppAdmin
{
    /// <summary>Holds the settings of the application.
    /// <para>At start of the application data will be retrieved from the configuration XML file</para>
    /// <para>If configuration file is missing a new file will be created with the default settings</para>
    /// </summary>
    public sealed class JazzAppAdminSettings
    {

        #region Ftp data
        /// <summary>FTP host</summary>
        public string FtpHost = "www.jazzliveaarau.ch";

        /// <summary>FTP user</summary>
        public string FtpUser = "jazzliv1";
 
        #endregion // Ftp data

        #region File and directory names
        /// <summary>Name of the checkin-checkout logfile</summary>
        public string CheckInOutLogFileName = "CheckInCheckOut.log";

        /// <summary>Start string for checkin row in logfile</summary>
        public string CheckInLogFile = @"Checked in by:";

        /// <summary>Start string for checkout row in logfile</summary>
        public string CheckOutLogFile = @"Checked out by:";

        /// <summary>Name of the directory with the existing (downloaded) XML files</summary>
        public string XmlExistingDir = @"XML";

        /// <summary>Name of the server directory for the backup of all XML and XSD files</summary>
        public string XmlAllBackupDir = @"appdata/BackupXmlAll";

        /// <summary>Name of the server directory for the backup of a XML file that shall be changed</summary>
        public string XmlChangedBackupDir = @"appdata/BackupXmlChanged";

        /// <summary>Name of the directory with the XML files that shall replace existing files or files that shall be added</summary>
        public string XmlReplaceDir = @"ReplaceXML";

        /// <summary>Name of the directory with XML backup files</summary>
        public string XmlBackupsDir = @"Backups";

        /// <summary>Name of the directory with output files</summary>
        public string OutputDir = @"Output";

        /// <summary>Name of the directory for the help file</summary>
        //QQ public string HelpDir = @"Help";

        /// <summary>Name of the directory that has a file with the latest version info</summary>
        public string LatestVersionInfoDir = @"LatestVersionInfo";

        /// <summary>Schema file one</summary>
        public string SchemaFileOneName = @"JazzProgramm_1996_2015.xsd";

        /// <summary>Schema file two</summary>
        public string SchemaFileTwoName = @"JazzProgramm_2015_20XX.xsd";

        /// <summary>Main servers directory name for admin</summary>
        public string DirAdminServerMain = @"appadmin/JazzAppAdmin";

        /// <summary>Directory name for XML templates</summary>
        public string DirXmlTemplates = @"XmlVorlagen";

        /// <summary>Directory name for HTM templates</summary>
        //QQ20231001 public string DirHtmTemplates = @"HtmVorlagen";

        /// <summary>File name for jazz program template</summary>
        public string FileXmlTemplateSeasonProgram = @"JazzProgramm_template.xml";

        /// <summary>File name for jazz program template with jscript functions</summary>
        //QQ20231001 public string FileHtmTemplateJscriptFunctions = @"JazzProgramm.js";

        /// <summary>Directory name for the installer of a new version</summary>
        public string DirNewVersion = @"NeueVersion";

        /// <summary>Directory name java scripts</summary>
        public string DirJscripts = @"scripts";

        /// <summary>Directory name for (temporary) htm files that will be uploaded to the server</summary>
        public string DirHtml = @"HTM";

        /// <summary>Name for file with concert data and functions in jscript format</summary>
        public string FileJscriptFunctions = @"JazzProgramm_Aktuell_Naechste.js";

        //  JazzProgramm_Aktuell_Naechste.js
        #endregion // File and directory names

        #region XML data 

        /// <summary>Configuration XML root element</summary>
        public string ConfigRootElement = "JazzAppAdminSettings";

        /// <summary>Start part of the season XML file names. Season is added, i.e. JazzProgramm_1996_1997.xml (first file), 1997_1998.xml, etc.</summary>
        public string SeasonFileNameStart = @"JazzProgramm_";

        /// <summary>Application XML file containing common data for the app.</summary>
        public string ApplicationFileName = @"JazzApplication.xml";

        /// <summary>Month that defines the start of a new season. May == 5</summary>
        public int NewSeasonStartMonth = 5;

        /// <summary>Added (default) musician name</summary>
        public string AddedMusicianName = "Musiker Name";

        /// <summary>Added (default) member first name</summary>
        public string AddedMemberFirstName = "Vorname des Vorstandsmitglieds";

        /// <summary>Added (default) member family name</summary>
        public string AddedMemberFamilyName = "Familienname des Vorstandsmitglieds";

        /// <summary>Added (default) concert name</summary>
        public string AddedConcertName = "Name des Konzertes";

        #endregion // XML data 

        #region Titles for controls and forms

        /// <summary>GUI program title</summary>
        public string GuiTextProgramTitle = @"JAZZ live AARAU App Administration";

        /// <summary>GUI index dialog title</summary>
        public string GuiHelpTitle = @"Hilfe JAZZ live AARAU Administration";

        /// <summary>GUI index dialog title</summary>
        public string GuiTextIndexTitle = @"XML editieren";

        /// <summary>GUI index website title</summary>
        public string GuiWebsiteTitle = @"Website (HTML) aktualisieren";

        /// <summary>GUI index website title</summary>
        public string GuiIntranetTitle = @"Intranet (HTML) aktualisieren";

        /// <summary>GUI index flyer title</summary>
        public string GuiFlyerTitle = @"Flyer (HTML) aktualisieren";

        /// <summary>GUI index website title</summary>
        public string GuiWebsiteTextTitle = @"Website (HTML)";

        /// <summary>GUI index website title</summary>
        public string GuiFlyerTextTitle = @"Flyer (HTML)";

        /// <summary>GUI index dialog title</summary>
        public string GuiTextIcons = @"Icons";

        /// <summary>GUI page (for the app)</summary>
        public string GuiTextPage = @"Seite";

        /// <summary>GUI edit text</summary>
        public string GuiTextEditText = @"Text editieren";

        /// <summary>GUI edit titles</summary>
        public string GuiTextEditTitle = @"Titel editieren";

        /// <summary>GUI edit all seasons</summary>
        public string GuiTextEditAllSeasons = @"Alle";

        /// <summary>GUI concert name</summary>
        public string GuiTextConcertName = @"Name";

        /// <summary>GUI concert date</summary>
        public string GuiTextConcertDate = @"Datum";

        /// <summary>GUI concert start time</summary>
        public string GuiTextConcertStartTime = @"Start";

        /// <summary>GUI concert end time</summary>
        public string GuiTextConcertEndTime = @"Ende";

        /// <summary>GUI concert short text</summary>
        public string GuiTextConcertShortText = @"Kurztext";

        /// <summary>GUI concert additional text</summary>
        public string GuiTextConcertAdditionalText = @"Zusätzlich";

        /// <summary>GUI musician name</summary>
        public string GuiTextMusicianName = @"Name";

        /// <summary>GUI musician instrument</summary>
        public string GuiTextMusicianInstrument = @"Instrument";

        /// <summary>GUI musician birth year</summary>
        public string GuiTextMusicianBirthYear = @"Geburtsjahr";

        /// <summary>GUI musician male</summary>
        public string GuiTextMusicianMale = @"Mann";

        /// <summary>GUI musician female</summary>
        public string GuiTextMusicianFemale = @"Frau";

        /// <summary>GUI musician contact name</summary>
        public string GuiTextMusicianContactName = @"Name";

        /// <summary>GUI musician contact email</summary>
        public string GuiTextMusicianContactEmail = @"E-Mail";

        /// <summary>GUI musician contact street</summary>
        public string GuiTextMusicianContactStreet = @"Strasse";

        /// <summary>GUI musician contact telephone</summary>
        public string GuiTextMusicianContactTelephone = @"Telefon";

        /// <summary>GUI musician contact postal code</summary>
        public string GuiTextMusicianContactPostCode = @"Postleitzahl";

        /// <summary>GUI musician contact city</summary>
        public string GuiTextMusicianContactCity = @"Stadt";

        /// <summary>GUI musician contact IBAN</summary>
        public string GuiTextMusicianContactIban = @"IBAN";

        /// <summary>GUI musician contact remark</summary>
        public string GuiTextMusicianContactRemark = @"Bemerkung";

        /// <summary>View GUI musician contact as text</summary>
        public string GuiTextMusicianContactViewText = @"Als Text";

        /// <summary>GUI musician password</summary>
        public string GuiTextMusicianPassword = @"Passwort";

        /// <summary>GUI member name</summary>
        public string GuiTextMemberName = @"Name";

        /// <summary>GUI member email</summary>
        public string GuiTextMemberEmail = @"E-Mail Jazz";

        /// <summary>GUI member email private</summary>
        public string GuiTextMemberEmailPrivate = @"E-Mail Privat";

        /// <summary>GUI member telephone</summary>
        public string GuiTextMemberTelephone = @"Telefon";

        /// <summary>GUI member fix telephone</summary>
        public string GuiTextMemberTelephoneFix = @"Fix";

        /// <summary>GUI member address</summary>
        public string GuiTextMemberAddress = @"Postadresse";

        /// <summary>GUI member main tasks</summary>
        public string GuiTextMemberMainTasks = @"Hauptaufgabe";

        /// <summary>GUI member tasks</summary>
        public string GuiTextMemberTasks = @"Aufgaben";

        /// <summary>GUI member why</summary>
        public string GuiTextMemberWhy = @"Persönliches";

        /// <summary>GUI member photo</summary>
        public string GuiTextMemberPhoto = @"Foto";

        /// <summary>GUI member password</summary>
        public string GuiTextMemberPassword = @"Passwort";

        /// <summary>GUI member start year</summary>
        public string GuiTextMemberStartYear = @"Anfangsjahr";

        /// <summary>GUI member end year</summary>
        public string GuiTextMemberEndYear = @"Endejahr";

        /// <summary>GUI member number</summary>
        public string GuiTextMemberNumber = @"Nummer";

        /// <summary>GUI member active flag</summary>
        public string GuiTextMemberActive = @"Aktiv im Vorstand";

        /// <summary>GUI Concert premises</summary>
        public string GuiTextConcertPremises = @"Konzertlokal";

        /// <summary>GUI Concert premises name</summary>
        public string GuiTextConcertPremisesName = @"Lokal";

        /// <summary>GUI Concert premises street</summary>
        public string GuiTextConcertPremisesStreet = @"Strasse";

        /// <summary>GUI Concert premises city</summary>
        public string GuiTextConcertPremisesCity = @"Stadt";

        /// <summary>GUI Concert premises</summary>
        public string GuiTextPremisesHeader = @"Header";

        /// <summary>GUI Name of the jazz club</summary>
        public string GuiTextClubName = @"Name";

        /// <summary>GUI Reservation subject</summary>
        public string GuiTextReservationSubject = @"R-Betreff";

        /// <summary>GUI Reservation text</summary>
        public string GuiTextReservationText = @"R-Text";

        /// <summary>GUI Reservation subject</summary>
        public string GuiTextNewsletterSubject = @"N-Betreff";

        /// <summary>GUI Reservation text</summary>
        public string GuiTextNewsletterText = @"N-Text";

        /// <summary>GUI Webmaster telephone text</summary>
        public string GuiTextTelephoneWebmaster = @"Support Tel.";

        /// <summary>GUI Webmaster email text</summary>
        public string GuiTextEmailWebmaster = @"Support E-Mail";

        /// <summary>GUI About us one text</summary>
        public string GuiTextAboutUsOne = @"Konzept I";

        /// <summary>GUI About us two text</summary>
        public string GuiTextAboutUsTwo = @"Konzept II";

        /// <summary>GUI About us three text</summary>
        public string GuiTextAboutUsThree = @"Konzept III";

        /// <summary>GUI publish text</summary>
        public string GuiTextPublish = @"Publizieren";

        /// <summary>GUI publish season program text</summary>
        public string GuiTextPublishProgram = @"Saisonprogramm publizieren";

        /// <summary>GUI publish season start year text</summary>
        public string GuiTextPublishSeasonStartYear = @"Aktuelle Saison für die Website";

        /// <summary>GUI publish season program text</summary>
        public string GuiTextYearAutumn = @"Herbstjahr";

        /// <summary>GUI publish season program text</summary>
        public string GuiTextYearSpring = @"Frühlingjahr";

        /// <summary>GUI unload street text</summary>
        public string GuiTextUnloadStreet = @"Abladeplatz: Strasse";

        /// <summary>GUI unload city text</summary>
        public string GuiTextUnloadCity = @"Abladeplatz: Stadt";

        /// <summary>GUI parking one text</summary>
        public string GuiTextParkingOne = @"Parkplatz I Adresse";

        /// <summary>GUI parking two text</summary>
        public string GuiTextParkingTwo = @"Parkplatz II Adresse";

        #endregion // Titles for controls and forms

        #region Captions for labels, buttons, ...

        /// <summary>Caption for the combobox season</summary>
        public string Caption_Season = "Saison";

        /// <summary>Caption for the label search record</summary>
        public string Caption_Search = "Suchen";

        /// <summary>Caption for the button delete record</summary>
        public string Caption_Delete = "Löschen";

        /// <summary>Caption for the button add record</summary>
        public string Caption_Add = "Neu";

        /// <summary>Caption for the button Checkin/Checkout Undefined</summary>
        public string Caption_CheckInOutUndefined = "---";

        /// <summary>Caption for the button Checkin/CheckOut</summary>
        public string Caption_CheckOut = "Check out";

        /// <summary>Caption for the button Checkin/CheckOut</summary>
        public string Caption_CheckIn = "Speichern";

        /// <summary>Caption for the button apply changes</summary>
        public string Caption_Apply = "Übernehmen";

        /// <summary>Caption for the exit button</summary>
        public string Caption_Exit = "Ende";

        /// <summary>Caption for the cancel button</summary>
        public string Caption_Cancel = "Abbrechen";

        /// <summary>Caption for the close button</summary>
        public string Caption_Close = "Zurück";

        /// <summary>Caption for the save button</summary>
        public string Caption_Save = "Speichern";

        /// <summary>Caption for the backup button</summary>
        public string Caption_Backup = "Alle Daten sichern";

        /// <summary>Caption for the application version</summary>
        public string Caption_ApplicationVersion = "Version ";

        /// <summary>Caption create and upload posters for homepage, newsletter and app</summary>
        public string CaptionCreateUploadPosters = @"Plakate für Homepage und App aktualisieren";

        /// <summary>Caption update Intranet</summary>
        public string CaptionHomepageIntranetUpdate = @"Intranet aktualisieren";

        /// <summary>Caption export to Flyer application</summary>
        public string CaptionExportToFlyerApplication = @"Export";

        /// <summary>Caption export to Flyer application</summary>
        public string CaptionImportFromFlyerApplication = @"Import";

        /// <summary>Caption export QR codes to Flyer application</summary>
        public string CaptionExportQrCodesToFlyerApplication = @"QR Codes";

        /// <summary>Caption export front page images to Flyer application</summary>
        public string CaptionExportFrontPageImagesToFlyerApplication = @"Titelseite-Bilder";

        /// <summary>Caption export season programs, XML Edit files and other files to Flyer application</summary>
        public string CaptionExportSeasonProgramsXmlEditFilesToFlyerApplication = @"Saisonprogramme";


        #endregion // Captions

        #region Error messages

        /// <summary>Error message: Please exit the application</summary>
        public string ErrMsgPleaseExitApplication = @"Bitte Applikation beenden!";

        /// <summary>Error message: No connection to Internet is available</summary>
        public string ErrMsgNoInternetConnection = @"Keine Verbindung zu Internet ist vorhanden";
 
        /// <summary>Error message: Failure downloading the XML and XSD files</summary>
        public string ErrMsgXmlFilesDownload = @"XML und XSD Dateien sind nicht heruntergeladen";

        /// <summary>Error message: Failure uploading the replace XML and XSD files</summary>
        public string ErrMsgXmlFilesReplace = @"XML und XSD Dateien sind nicht hinaufgeladen";

        /// <summary>Error message: xxx file is not checked in</summary>
        public string ErrMsgXmlFileNotCheckedIn = @"ist nicht gespeichert";

        /// <summary>Error message: Only non-published season programs may be changed</summary>
        public string ErrMsgOnlyNonPublishedProgramsMayBeChanged = @"Nur nicht publizierte Saison-Programme können geändert werden";

        /// <summary>Error message: Concert name is not allowed to be empty</summary>
        public string ErrMsgConcertNameNotSet = @"Konzert/Band Name darf nicht leer sein";

        /// <summary>Error message: Musician name is not allowed to be empty</summary>
        public string ErrMsgMusicanNameNotSet = @"Musikername darf nicht leer sein";

        /// <summary>Error message: All characters of a number must be numbers</summary>
        public string ErrMsgAllCharsMustBeNumbers = @"Die Zahl enthält nicht nur Zahlen";

        /// <summary>Error message: A number cannot start with zero</summary>
        public string ErrMsgNumberCannotStartWithZero = @"Eine Zahl darf nicht mit null anfangen";

        /// <summary>Error message: A year must have 4 numbers</summary>
        public string ErrMsgYearNotFourNumbers = @"Jahr muss vier (4) Zahlen haben";

        /// <summary>Error message: The text of an item in a combobox is not alloed to change</summary>
        public string ErrMsgComboboxItemTextChange = @"Text darf nicht geändert werden";

        /// <summary>Error message: There must be a colon between hour and minute</summary>
        public string ErrMsgTimeWithoutColon = @"Kein Doppelpunkt zwischen Stunde und Minute";

        /// <summary>Error message: Time must have one or two number</summary>
        public string ErrMsgTimeTwoNumbers = @"Zeit muss ein (1) oder zwei (2) Zahlen haben";

        /// <summary>Error message: A telephone number must start with plus</summary>
        public string ErrMsgPlusTelephoneNumber = @"Eine Telefonnummer muss mit plus (+) anfangen";

        /// <summary>Error message: The file URL has no path</summary>
        public string ErrMsgFileUrlWithoutPath = @"Diese Datei hat keinen Pfad: ";

        /// <summary>Error message: A path for this file is not allowed</summary>
        public string ErrMsgFileUrlWithPath = @"Diese Datei darf keinen Pfad haben: ";

        /// <summary>Error message: Not allowed extension for a zip file</summary>
        public string ErrMsgZipFileExtension = @"Die Dateiendung für diese komprimierte Datei ist nicht erlaubt: ";

        /// <summary>Error message: The file URL has a full path with http</summary>
        public string ErrMsgFileUrlHasFullPath = @"Diese Datei hat einen Pfad mit http (ist nicht relativ): ";

        /// <summary>Error message: The file URL is not a full path with http</summary>
        public string ErrMsgFileUrlNoFullPath = @"Diese Datei hat nicht einen Pfad mit http: ";

        /// <summary>Error message: The file URL has a path name wit allowed slash</summary>
        public string ErrMsgFileUrlNotAllowedSlash = @"Diese Datei hat einen Pfad mit falschem Schrägstrich (nur / ist erlaubt): ";

        /// <summary>Error message: Checkout of saisson XML is necessary for adding an additional musician</summary>
        public string ErrMsgCheckoutBeforeAddingMusician = @"Musiker zuzufügen nur nach Checkout";

        /// <summary>Error message: Checkout of saison XML is necessary for adding an additional member</summary>
        public string ErrMsgCheckoutBeforeAddingMember = @"Vorstandsmitglied zuzufügen nur nach Checkout";

        /// <summary>Error message: Checkout of season XML is necessary for adding an additional concert</summary>
        public string ErrMsgCheckoutBeforeAddingConcert = @"Konzert zuzufügen nur nach Checkout";

        /// <summary>Error message: The last musician cannot not be removed</summary>
        public string ErrMsgRemoveLastMusician = @"Ein Konzert muss mindestens einen Musiker haben";

        /// <summary>Error message: The last concert cannot not be removed</summary>
        public string ErrMsgRemoveLastConcert = @"Ein Saison-Programm muss mindestens ein Konzert haben";

        /// <summary>Error message: The last member cannot not be removed</summary>
        public string ErrMsgRemoveLastMember = @"Es muss mindestens einen Vorstandsmitglied geben";

        /// <summary>Error message: Checkout of saison XML is necessary for removing a concert</summary>
        public string ErrMsgCheckoutBeforeRemovingConcert = @"Konzert entfernen nur nach Checkout";

        /// <summary>Error message: Checkout is necessary for removing a member</summary>
        public string ErrMsgCheckoutBeforeRemovingMember = @"Vorstadsmitglied entfernen nur nach Checkout";

        /// <summary>Error message: The selected function is not yet implemented</summary>
        public string ErrMsgFunctionNotYetImplemented = @"Diese Funktion ist noch nicht implementiert";

        /// <summary>Error message: Failure downloading the installer for the admin program</summary>
        public string ErrMsgNewVersionDownload = @"Herunterladen vom Installer hat nicht funktioniert";

        /// <summary>Error message: Failure downloading the XML templates</summary>
        public string ErrMsgXmlTemplatesDownload = @"Herunterladen von XML Vorlagen hat nicht funktioniert";

        /// <summary>Error message: Failure downloading the HTM templates</summary>
        public string ErrMsgHtmTemplatesDownload = @"Herunterladen von HTM Vorlagen hat nicht funktioniert";

        /// <summary>Error message: Failure downloading one HTM template</summary>
        public string ErrMsgHtmTemplateDownload = @"Herunterladen von HTM Vorlage hat nicht funktioniert ";

        /// <summary>Error message: Failure downloading an Admin file from the server</summary>
        public string ErrMsgAdminFileDownload = @"Herunterladen vom Server hat nicht funktioniert. Datei ";

        /// <summary>Error message: Failure downloading the help file for the admin program</summary>
        public string ErrMsgHelpFileDownload = @"Herunterladen von der Hilfe-Datei hat nicht funktioniert";

        /// <summary>Error message: Failure downloading the latest vesion info file for the admin program</summary>
        public string ErrMsgLatestVersionInfoFileDownload = @"Herunterladen von der Datei mit Versionsinformation hat nicht funktioniert";

        /// <summary>Error message: Set another season as current season and change publish start year</summary>
        public string ErrMsgPublishSeasonStartYearSetOtherSeason = @"Eine andere Saison muss geöffnet werden und als die aktuelle Saison registriert werden";

        /// <summary>Error message: The current season flag is not true</summary>
        public string ErrMsgPublishSeasonStartYearNotPublished = @"Bitte auch Saisonprogramm publizieren!";

        /// <summary>Error message: The next season must exist if this season shall become the publish start year</summary>
        public string ErrMsgPublishSeasonStartYearNextSeasonNotDefined = @"XML existiert nicht für nächste Saison ";

        /// <summary>Error message: This year cannot be set as the publish start year since the year is passed</summary>
        public string ErrMsgPublishSeasonStartYearIsPassed = @"Diese (alte) Saison kann nicht die aktuelle Saison sein";

        /// <summary>Error message: The update of the Internet program for the current season failed. Please report.</summary>
        public string ErrMsgUpdateInternetConcertPagesThisSeason = @"Die Internet Aktualisierung vom Konzertprogramm hat nicht funktioniert. Bitte melden.";

        /// <summary>Error message: The update of the Intranet program for the next season failed. Please report.</summary>
        public string ErrMsgUpdateIntranetConcertPagesNextSeason = @"Warnung. " + @"Keine Intranet Aktualisierung vom Konzertprogramm für die nächste Saison";
                                      //QQQ + "\n" + @"Vermutlich weil die Dokument XML Datei für diese Saison noch nicht existiert.";

        /// <summary>Error message: The creation and upload of the request html file failed. Please report.</summary>
        public string ErrMsgCreateUploadRequestHtmlFile = @"Die Intranet Aktualisierung von Anfragen hat nicht funktioniert. Bitte melden.";

        /// <summary>Error message: The creation and upload of the selected bands html file failed. Please report.</summary>
        public string ErrMsgCreateUploadSelectedBandsHtmlFile = @"Die Intranet Aktualisierung von der Liste mit den ausgewählten Bands hat nicht funktioniert. Bitte melden.";

        /// <summary>Error message: Save the checked out season XML file before changing the season</summary>
        public string ErrMsgSaveXmlBeforeChangeOfSeason = @"Saison wählen ist nicht erlaubt. Zuerst bitte Checkin (XML Datei speichern)";

        /// <summary>Error message: Import of flyer data only allowed after checkout</summary>
        public string ErrMsgFlyerImportCheckout = @"Import von Flyer Texten nur nach Checkout";

        /// <summary>Error message: Import of flyer data only allowed after checkout</summary>
        public string ErrMsgAdminExitedWithCheckedOutXml = @"Applikation Admin zu beenden ohne Checkin von der XML Datei ist nicht erlaubt.";

        #endregion // Error messages

        #region Messages

        /// <summary>Message: Close/quit without saving?</summary>
        public string MsgCloseWithoutSaving = @"Enden ohne die Änderungen zu speichern?";

        /// <summary>Message: A new XML file without saving the changed document?</summary>
        public string MsgNewXmlWithoutSaving = @"Ein neues XML Dokument ohne die Änderungen im ausgecheckten Dokument zu speichern?";

        /// <summary>Status message: The XML and the XSD files are downloaded</summary>
        public string MsgXmlFilesDownload = @"XML und XSD Dateien sind heruntergeladen";

        /// <summary>Status message: The installer is downloaded</summary>
        public string MsgInstallerDownload = @"Der Installer ist heruntergeladen";

        /// <summary>Status message: The help file is downloaded</summary>
        public string MsgHelpFileDownload = @" ist heruntergeladen";

        /// <summary>Status message: There were no files to be replaced or added</summary>
        public string MsgXmlNoFilesReplacedOrAdded = @"Es gab keine XML oder XSD Dateien zu ersetzen oder zufügen";

        /// <summary>Status message: xxx was replaced</summary>
        public string MsgXmlFileIsReplaced = @" wurde ersetzt";

        /// <summary>Status message: xxx was added</summary>
        public string MsgXmlFileIsAdded = @" wurde zugefügt";

        /// <summary>Status message: A passed concert cannot be deleted</summary>
        public string MsgPassedConcertCannotBeDeleted = @"Nur kommenden Konzerte dürfen gelöscht werden";

        /// <summary>Warning message: Really change the number of concerts</summary>
        public string MsgReallyChangeNumberOfConcerts = @"Anzahl Konzerte dieser Saison wirklich ändern zu ";

        /// <summary>Message: Continue</summary>
        public string MsgContinue = @"Fortsetzen?";

        /// <summary>Message: Concert was not added</summary>
        public string MsgConcertNotAdded = @"Konzert wurde nicht zugefügt";

        /// <summary>Status message: Backup is made</summary>
        public string MsgBackupIsMade = @"Alle XML-Dateien sind gesichert.";

        /// <summary>Status message: Backup is made of the current XML file</summary>
        public string MsgBackupCurrenXml = @" ist gesichert.";

        /// <summary>Status message: A new version is available</summary>
        public string MsgNewVersionIsAvailable = @"Es gibt eine neue Version ";

        /// <summary>Status message: Website is updated. Java script file with data and functions is uploaded to the server</summary>
        public string MsgWebsiteIntranetUpdated = @"Intranet ist aktualisiert";
        //QQ For the old homepage public string MsgWebsiteIntranetUpdated = @"Website und Intranet sind aktualisiert";

        /// <summary>Status message: Posters for the hompepage and app are uploaded to the server</summary>
        public string MsgPosterNewsletterUploaded = @"Plakate für Homepage, Newsletter und App sind kreiert und aufgeladen";

        /// <summary>Status message: Data to the web application Flyer is exported</summary>
        public string MsgDataToFlyerApplicationExported = @"Daten zur Web-Applikation Flyer sind exportiert";

        /// <summary>Status message: QR codes to the web application Flyer is exported</summary>
        public string MsgQrCodesToFlyerApplicationExported = @"QR Codes zur Web-Applikation Flyer sind exportiert";

        /// <summary>Status message: XML edit files to the web application Flyer is exported</summary>
        public string MsgFlyerImageFilesToFlyerApplicationExported = @"Flyer Bilder zur Web-Applikation Flyer sind exportiert";

        /// <summary>Status message: Data from the the web application Flyer is imported</summary>
        public string MsgDataFromFlyerApplicationImported = @"Daten von der Web-Applikation Flyer sind importiert";

        /// <summary>Status message: Season programs are saved an copied to the Flyer application</summary>
        public string MsgFlyerSaisonProgramSavedAndCopiedToFlyer = @"Saisonprogramm ist gespeichert und kopiert zur Flyer Applikation";

        /// <summary>Message: Exit application</summary>
        public string MsgExitApplication = @"Die Applikation bitte beenden!";

        /// <summary>Message: Really exit the application?</summary>
        public string MsgReallyExitApplication = @"Applikation beenden?";

        /// <summary>Message: Really exit?</summary>
        public string MsgReallyExit = @"Ende?";

        /// <summary>Message: Use implemented buttons to close the dialog</summary>
        public string MsgCloseDialogWithImplementedButtons = @"Dialogfenster bitte schliessen mit: ";

        #endregion // Messages

        #region Tool tips

        /// <summary>Tool tip application</summary>
        public string ToolTipApplication = @"Editieren von XML Dateien für App und Website";

        /// <summary>Tool tip checkout and checkin</summary>
        public string ToolTipCheckOut = @"Editieren von XML Dateien erst nach Checkout möglich." +
             "\r\nCheckout nicht möglich, falls jemand anders gleichzeitig XML Dateien editiert." +
             "\r\nNach Checkout XML Datei speichern.";

        /// <summary>Tool tip select season</summary>
        public string ToolTipSelectSeason = @"Saison-Programm wählen oder zufügen.";

        /// <summary>Tool tip select concert</summary>
        public string ToolTipSelectConcert = @"Konzert wählen oder zufügen." +
             "\r\nZufügen nur möglich nach Checkout..";

        /// <summary>Tool tip select member</summary>
        public string ToolTipSelectMember = @"Vorstandsmitglied wählen oder zufügen." +
             "\r\nZufügen nur möglich nach Checkout.";

        /// <summary>Tool tip select musician</summary>
        public string ToolTipSelectMusician = @"Musiker wählen oder zufügen." +
             "\r\nZufügen nur möglich nach Checkout.";

        /// <summary>Tool tip edit text or titles</summary>
        public string ToolTipEditTextOrTitle = @"Eine Funktion die noch nicht fertig ist ....Text oder Titel editieren" +
             "\r\nText zum Beispiel Musiker Name und Konzert Datum." +
             "\r\nTitel zum Beispiel Vorstandsmitglied. (In dieser Version sehr begrenzt möglich)";

        /// <summary>Tool tip edit text or titles</summary>
        public string ToolTipAllSeasonPrograms = @"Wählen um frühere (alle) Saison-Programme auszuchecken." +
             "\r\nÜblicherweise wird nur das kommende oder aktuelle Saison-Programm geändert.";

        /// <summary>Tool tip concert</summary>
        public string ToolTipConcert = @"Editieren von Konzertdaten wie (Konzert-)Datum und (Band-)Name usw.";

        /// <summary>Tool tip musician</summary>
        public string ToolTipMusician = @"Editieren von Musikerdaten";

        /// <summary>Tool tip band contact person</summary>
        public string ToolTipBandContact = @"Editieren von Bandkontaktdaten";

        /// <summary>Tool tip musicians only</summary>
        public string ToolTipMusiciansOnly = @"Editieren von Musiker Informationsdaten";

        /// <summary>Tool tip publish</summary>
        public string ToolTipPublish = @"Saisonprogramm frei geben (publizieren)";

        /// <summary>Tool tip concert premises</summary>
        public string ToolTipConcertPremises = @"Editieren von Konzertlokaldaten";

        /// <summary>Tool tip premises</summary
        public string ToolTipPremises = @"ditieren von Lokal-Daten (Haupt-Lokal für die Konzerte)";

        /// <summary>Tool tip contact</summary
        public string ToolTipContact = @"Editieren von Kontaktdaten";

        /// <summary>Tool tip about us</summary
        public string ToolTipAboutUs = @"Editieren vom Konzept-Text für die Homepage";

        /// <summary>Tool tip make a backup on the server of all data</summary>
        public string ToolTipIndexBackup = @"Hier klicken um Sicherheitskopien von allen XML-Dateien zu machen." +
             "\r\nDer Webmaster kann die Dateien zurückstellen." +
             "\r\nAnmerkung:"  +
             "\r\nJede geänderte Datei wird vor und nach einer Änderung gesichert." +
             "\r\nDiese Funktion ist im Moment für den Benutzer versteckt." +
             "\r\nIn der Zukunft wird sie vielleicht für den Entwickler (IT Supporter) zugänglich";

        /// <summary>Tool tip exit the adminstration application </summary>
        public string ToolTipIndexExit = @"JAZZ live AARAU Administration beenden";

        /// <summary>Tool tip close the index dialog</summary>
        public string ToolTipIndexBack = @"Dialog schliessen, zurück zum Hauptdialog Administration";

        /// <summary>Tool tip cancel the index dialog</summary>
        public string ToolTipIndexCancel = @"Zurück zum Hauptdialog Administration ohne Änderungen zu speichern";

        /// <summary>Tool tip concert edit</summary>
        public string ToolTipConcertEdit = @"Hier klicken für Änderungen (nur möglich nach Checkout)";

        /// <summary>Tool tip concert delete</summary>
        public string ToolTipConcertDelete = @"Konzert löschen (nur möglich für kommende Konzerte nach Checkout)";

        /// <summary>Tool tip concert cancel</summary>
        public string ToolTipConcertCancel = @"Zurück zum Hauptdialog ohne Änderungen zu speichern";

        /// <summary>Tool tip concert close</summary>
        public string ToolTipConcertClose = @"Änderungen übernehmen und zurück zum Hauptdialog";

        /// <summary>Tool tip musician edit</summary>
        public string ToolTipMusicianEdit = @"Hier klicken für Änderungen (nur möglich nach Checkout)";

        /// <summary>Tool tip musician delete</summary>
        public string ToolTipMusicianDelete = @"Musiker löschen (nach Checkout)." +
                                              "\r\nAlle Musiker können nicht gelöscht werden.";

        /// <summary>Tool tip musican cancel</summary>
        public string ToolTipMusicianCancel = @"Zurück zum Hauptdialog ohne Änderungen zu speichern";

        /// <summary>Tool tip musician close</summary>
        public string ToolTipMusicianClose = @"Änderungen übernehmen und zurück zum Hauptdialog";

        /// <summary>Tool tip member</summary>
        public string ToolTipMember = @"Editieren von Vorstandsmitglied-Daten";

        /// <summary>Tool tip member edit</summary>
        public string ToolTipMemberEdit = @"Hier klicken für Änderungen (nur möglich nach Checkout)";

        /// <summary>Tool tip member delete</summary>
        public string ToolTipMemberDelete = @"Vorstandsmitglied löschen." +
            "\r\nVorstandsmitglieder sollen normalerweise nicht gelöscht werden." +
             "\r\nDie App hat eine Funktion, die aktive wie auch bisherige Mitglieder anzeigt." +
             "\r\nDiese Funktion ist für den Benutzer versteckt."  +
             "\r\nIn der Zukunft wird sie vielleicht für den Entwickler (IT Supporter) zugänglich.";

        /// <summary>Tool tip member cancel</summary>
        public string ToolTipMemberCancel = @"Zurück zum Hauptdialog ohne Änderungen zu speichern";

        /// <summary>Tool tip member close</summary>
        public string ToolTipMemberClose = @"Änderungen übernehmen und zurück zum Hauptdialog";

        /// <summary>Tool tip musician contact</summary>
        public string ToolTipMusicianContact = @"Editieren von Musikerkontakt-Daten";

        /// <summary>Tool tip musician contact edit</summary>
        public string ToolTipMusicianContactEdit = @"Hier klicken für Änderungen (nur möglich nach Checkout)";

        /// <summary>Tool tip musician contact cancel</summary>
        public string ToolTipMusicianContactCancel = @"Zurück zum Hauptdialog ohne Änderungen zu speichern";

        /// <summary>Tool tip musician contact close</summary>
        public string ToolTipMusicianContactClose = @"Änderungen übernehmen und zurück zum Hauptdialog";

        /// <summary>Tool tip administration program</summary>
        public string ToolTipAdmin = @"Applikation für Administration von JAZZ live AARAU Daten:" +
            "\r\nXML-Dateien für App und Website, HTML-Dateien für Website" +
             "\r\nund JPG-Dateien (Fotos) für Website und Slideshow";

        /// <summary>Tool tip help</summary>
        public string ToolTipHelp = @"Hier klicken um Hilfe zu erhalten." +
            "\r\nEin Hilfedokument (die letzte/aktuelle Version) wird vom Server zum Ordner Help" +
            "\r\nheruntergeladen und in einem Popup-Fenster angezeigt." +
            "\r\nDas Hilfedokument kann man auch mit Word anschauen.";

        /// <summary>Tool tip download</summary>
        public string ToolTipDownload = @"Hier klicken wenn es eine neue Version gibt." +
            "\r\n" + @"1. Die Applikation Explorer öffnen (starten)" +
            "\r\n" + @"2. Zum Ordner C:\Apps\JazzLiveAarau\Admin\NeueVersion navigieren" +
            "\r\n" + @"3. Diese Applikation beenden" +
            "\r\n" + @"4. Doppelklick auf Setup-(Installations-)Programm" +
            "\r\n" + @"5. Alle Vorschläge des Installationsprogramms akzeptieren" +
            "\r\n" + @"6. JAZZ live AARAU Admin wieder öffnen (starten)";

        /// <summary>Tool tip edit XML</summary>
        public string ToolTipEditXml = @"Hier klicken um Saison-Programme (XML-Dateien) zu editieren." +
            "\r\nXML ist eine Datei, die Daten in Tabellenform enthält und ist sowohl von Menschen als auch von" +
            "\r\nMaschinen lesbar." +
            "\r\nAdmin XML-Daten sind z.B. ‘Name des Konzerts’, ‘Datum’ und ‘Musikernamen’ und werden auf" +
            "\r\nHomepage gezeigt.";

        /// <summary>Tool tip update website (actually only Intranet Documents</summary>

        public string ToolTipUpdateWebsite = @"Hier klicken um Intranet Dokumente (HTM-Dateien) zu aktualisieren.";
        /*QQ20231001
        @"Hier klicken um Website und Intranet (HTM-Dateien) zu aktualisieren." +
        "\r\nJede Homepage und Intranet Webseite ist von einer HTM-Datei definiert." +
         "\r\nEin HTM-Code definiert, wie z.B. Konzertdaten auf der Homepage präsentiert werden." +
        "\r\nFür viele JAZZ live AARAU Webseiten kommen die Daten von XML-Dateien.";
        QQ20231001*/

        /// <summary>Tool tip documents (DOC)</summary>
        public string ToolTipDocuments = @"Hier klicken um Jazz-Dokumente hoch- und herunterzuladen";

        /// <summary>Tool tip requests (MP3)</summary>
        public string ToolTipRequests = @"Hier klicken um Anfragen zu administrieren und MP3- sowie Textdateien hoch- und herunterzuladen";

        /// <summary>Tool tip update javascript file</summary>
        public string ToolTipUpdateJavaScriptFile = @"Intranet wird aktualisiert und folgende Inhalte zum Server hochgeladen:" +
                                                 "\r\nListen mit Konzert- und Saisondokumenten sowie Anfrageliste." +
                                                 "\r\nNach Aktualisierung bitte Intranet kontrollieren.";
        /*QQQQQQ
        For the old homepage
                public string ToolTipUpdateJavaScriptFile = @"Website wird aktualisiert (XML-Daten werden zu Javascript-Daten konvertiert)." +
                                                         "\r\nDabei wird eine ziemlich grosse Javascript-Datei generiert und hochgeladen." +
                                                         "\r\nIntranet wird auch aktualisiert und folgende Inhalte zum Server hochgeladen:" +
                                                         "\r\nListen mit Konzert- und Saisondokumenten sowie Anfrageliste." +
                                                         "\r\nDieser Prozess benötigt viel Zeit." +
                                                         "\r\nNach Aktualisierung bitte Website und Intranet kontrollieren.";
        QQQ*/


        /// <summary>Tool tip create and upload posters for homepage and newsletter</summary>
        public string ToolTipCreateUploadPosters = @"Plakate für Homepage und Newsletter werden kreiert und zum Server hochgeladen." +
                                                   "\r\nStartplakat ist das Plakat als Bild (JPG-Format), das mit der Dokument-Funktion hochgeladen ist. " +
                                                   "\r\nMit dem Start-Plakatbild wird zwei kleinere Bilder kreiert. Diese kleinere Bilder werden hochgeladen." +
                                                   "\r\nDiese Funktion muss man nur anrufen, wenn ein Plakat geändert ist." +
                                                   "\r\nNach Aktualisierung bitte Website und Newsletter kontrollieren.";

        /// <summary>Tool tip upload photos</summary>
        public string ToolTipUploadPhotos = @"Hier klicken um Fotos (JPG-Dateien) zu organisieren.";

        /// <summary>Tool tip exit the administration application</summary>
        public string ToolTipAdminClose = @"JAZZ live AARAU Administration beenden";

        /// <summary>Tool tip messages from the application</summary>
        public string ToolTipAdminMsg = @"Meldungen von der Applikation (z.B. eine neue Version verfügbar)";

        /// <summary>Tool tip current season</summary>
        public string ToolTipCurrentSeason = @"Diese Saison wird die aktuelle Saison für die Homepage." +
                                             "\r\nEine XML Datei für die nächste Saison muss definiert sein." +
                                             "\r\nEs gibt keine Funktion, die automatisch die nächste Saison XML Datei generiert." +
                                             "\r\nDie Admin Funktion 'Saison wählen' zeigt ob die XML Datei existiert." +
                                             "\r\nWenn die Datei nicht existiert, kontaktiere bitte IT Support.";

        /// <summary>Tool tip autumn and spring year</summary>
        public string ToolTipAutumnSpringYear = @"Definiert die Saison-Jahre.";

        /// <summary>Tool tip export data to web application Flyer</summary>
        public string ToolTipExportToFlyerApplication = @"Ablauf für den Export von Daten zur Webapplikation Flyer:" +
                                             "\r\n- Mit XML Editieren Bandnamen und Musikernamen erfassen" +
                                             "\r\n- Saisonprogramme exportieren" +
                                             "\r\n- QR Codes exportieren (initial und wenn erfasst/geändert)" +
                                             "\r\n- Titelseite-Bilder exportieren (initial und wenn erfasst/geändert)";

        /// <summary>Tool tip impot data from web application Flyer</summary>
        public string ToolTipImportFromFlyerApplication = @"Ablauf für den Import von Daten zur Webapplikation Flyer:" +
                                             "\r\n- Mit der Flyer Applikation Musikertexte oder freie Texte auswählen (publizieren)" +
                                             "\r\n- Musikertexte oder freie Texte importieren";

        /// <summary>Tool tip export season program and XML edit files to the web application Flyer</summary>
        public string ToolTipExportSeasonProgramToFlyerApplication = @"Folgendes wir zur Webapplikation Flyer exportiert:" +
                                             "\r\nXML Saisonprogramme für die aktuelle und nächste Saison" +
                                             "\r\nXML Edit Dateien für Kurztexte, Musikertext und freie Texte" +
                                             "\r\nEine Liste mit den Saisons, die editiert werden können" +
                                             "\r\nListe mit Login-Namen und Passwörter (einmalig)";

        /// <summary>Tool tip export QR codes to the web application Flyer</summary>
        public string ToolTipExportQRCodesToFlyerApplication = @"Exportiert QR Codes für Band Websites und Sound Beispiele" +
                                             "\r\nDie verwendete Links werden mit XML Editieren erfasst" +
                                             "\r\nWenn Links fehlen werden QR Codes zum 'noch-nicht-definiert-Bild' exportiert";

        /// <summary>Tool tip export flyer images to the web application Flyer</summary>
        public string ToolTipExportFrontPageImagesToFlyerApplication = @"Exportiert Bilder für die Frontseiten" +
                                             "\r\nDie Bilder werden zuerst mit einer Admin Dokumente funktion hochgeladen" +
                                             "\r\nWenn ein Bild fehlt wird ein 'noch-nicht-definiert-Bild' exportiert";

        /// <summary>Tool tip import musician texts from the web application Flyer</summary>
        public string ToolTipImportMusicianTextsFromFlyerApplication = @"Importiert Musikertexte von der Flyer Applikation" +
                                             "\r\nTexte müssen in der Applikation Flyer ausgewählt sein (Haken publizieren)" +
                                             "\r\nXML Saisonprogramme werden aktualisiert und hochgeladen" +
                                             "\r\nImport nur nach checkout.";

        /// <summary>Tool tip import free texts from the web application Flyer</summary>
        public string ToolTipImportFreeTextsFromFlyerApplication = @"Importiert freie Texte von der Flyer Applikation" +
                                             "\r\nTexte müssen in der Applikation Flyer ausgewählt sein (Haken publizieren)" +
                                             "\r\nXML Saisonprogramme werden aktualisiert und hochgeladen" +
                                             "\r\nImport nur nach checkout.";

        /// <summary>Tool tip for Flyer</summary>
        public string ToolTipFlyer = @"Hier klicken um Daten für die Applikation Flyer zu exportieren und importieren.";

        /// <summary>Tool tip sound sample</summary>
        public string ToolTipSoundSample = @"Aufladen von Hörbeispielen";

        /// <summary>Tool tip request text on the homepage</summary
        public string ToolTipRequestsText = @"Editieren vom Anfrage-Text für die Homepage";

        public string ToolTipSoundSampleForm = @"Hörbeispiel für die Homepage." + "\r\n" +
                                               @"Nur mp3 und mp4 Dateien können aufgeladen werden." + "\r\n" +
                                               @"Die Name der Hörbeispiel-Datei wird von dieser Funktion bestimmt." + "\r\n" +
                                               @"Beim Aufladen wird automatisch ein QR-Code kreiert und aufgeladen." + "\r\n" +
                                               @"Die QR-Code ist ein Link (URL) zum Hörbeispiel." + "\r\n" +
                                               @"QR-Codes können für Saisonprogramm und Flyer verwendet werden.";

        /// <summary>Tool tip sound sample edit</summary>
        public string ToolTipSoundSampleEdit = @"Hier klicken für Änderungen (nur möglich nach Checkout)";

        /// <summary>Tool tip sound sample delete</summary>
        public string ToolTipSoundSampleDelete = @"Hörbeispiel löschen (nur möglich nach Checkout)" + "\r\n" +
                                                 @"Die QR-Code wird auch gelöscht.";

        /// <summary>Tool tip sound sample cancel</summary>
        public string ToolTipSoundSampleCancel = @"Zurück zum Hauptdialog ohne Änderungen zu speichern.";

        /// <summary>Tool tip sound sample close</summary>
        public string ToolTipSoundSampleClose = @"Änderungen übernehmen und zurück zum Hauptdialog.";

        /// <summary>Tool tip souund sample download the sound sample file</summary>
        public string ToolTipSoundSampleDownload = @"Herunterladen von der Hörbeispiel-Datei.";

        /// <summary>Tool tip souund sample download the sound sample QR image</summary>
        public string ToolTipSoundSampleDownloadQr = @"Herunterladen vom Hörbeispiel QR-Code Bild.";

        /// <summary>Tool tip souund sample download the sound sample file</summary>
        public string ToolTipSoundSampleUpload = @"Hochladen von einer Hörbeispiel-Datei (nur möglich nach Checkout)." + "\r\n" +
                                                 @"Das QR-Code Bild wird automatisch kreiert und hochgeladen.";

        #endregion // Tool tips

        #region Save and read XML file

        /// <summary>Default settings instance</summary>
        static JazzAppAdminSettings defaultSettings = new JazzAppAdminSettings();

        /// <summary>Constructor</summary>
        public JazzAppAdminSettings() { }

        /// <summary>Gets the default settings instance.</summary>
        /// <remarks>
        /// <para>On first access, an attempt is made to load the settings from an application-specific location. If the
        /// file is not found or corrupt, then all fields of the returned instance are set to their default values.
        /// </para>
        /// </remarks>
        internal static JazzAppAdminSettings Default
        {
            get { return defaultSettings; }
        }

        /// <summary>Saves all settings.</summary>
        internal void Save()
        {
            // Always existing Directory.CreateDirectory(FileUtil.GetPathToExeDirectory());

            using (FileStream fileStream = new FileStream(FileUtil.ConfigFileName(ConfigRootElement, Main.m_exe_directory), FileMode.Create))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                new XmlSerializer(typeof(JazzAppAdminSettings)).Serialize(streamWriter, defaultSettings);
            }
        } // Save()

        /// <summary>Reads the configuration file and sets values in defaultSettings.</summary>
        internal void ReadFromConfigFile()
        {
            using (FileStream fileStream = new FileStream(FileUtil.ConfigFileName(ConfigRootElement, Main.m_exe_directory), FileMode.Open, FileAccess.Read, FileShare.Read))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                defaultSettings = (JazzAppAdminSettings)new XmlSerializer(typeof(JazzAppAdminSettings)).Deserialize(streamReader);
            }
        } // ReadFromConfigFile()

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static JazzAppAdminSettings()
        {
            try
            {
                using (FileStream fileStream = new FileStream(FileUtil.ConfigFileName(JazzAppAdminSettings.defaultSettings.ConfigRootElement, Main.m_exe_directory), FileMode.Open, FileAccess.Read, FileShare.Read))
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    defaultSettings = (JazzAppAdminSettings)new XmlSerializer(typeof(JazzAppAdminSettings)).Deserialize(streamReader);
                }
            }
            catch (FileNotFoundException) { }
            catch (DirectoryNotFoundException) { }
            catch (InvalidOperationException) { } // Thrown when there is an error in the XML document
            catch (InvalidCastException) { } // Thrown occasionally in Visual Studio when opening designer
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText(Path.Combine(Main.m_exe_directory, "Settings-debug-log.txt")))
                {
                    w.WriteLine();
                    w.WriteLine(">>> Unhandled Exception " + e.GetType() + " occurred at " + DateTime.Now + "!");
                    w.WriteLine();
                    w.WriteLine(e);
                    w.WriteLine();

                    // Close the writer and underlying file.
                    w.Close();
                }
            }
        } // JazzAppAdminSettings()

        #endregion // Save and read XML file

        #region Create text file with all tool tips


        /// <summary>All tool tips names</summary>      
        private static string[] m_tool_tip_names =
            {
            @"ToolTipApplication",  // 0
            @"ToolTipCheckOut", // 1
            @"ToolTipSelectSeason", // 2
            @"ToolTipSelectConcert", // 3
            @"ToolTipSelectMember",  // 4
            @"ToolTipSelectMusician",  // 5
            @"ToolTipEditTextOrTitle",  // 6 
            @"ToolTipAllSeasonPrograms",  // 7 
            @"ToolTipConcert",  // 8
            @"ToolTipMusician",  // 9 
            @"ToolTipBandContact",  // 10 
            @"ToolTipMusiciansOnly",  // 11 
            @"ToolTipPublish",  // 12 
            @"ToolTipConcertPremises",  // 13 
            @"ToolTipPremises",  // 14 
            @"ToolTipContact",  // 15 
            @"ToolTipAboutUs",  // 16
            @"ToolTipIndexBackup", // 17
            @"ToolTipIndexExit", // 18 
            @"ToolTipIndexBack", // 19
            @"ToolTipIndexCancel", // 20
            @"ToolTipConcertEdit", // 21
            @"ToolTipConcertDelete", // 22
            @"ToolTipConcertCancel", // 23
            @"ToolTipConcertClose", // 24
            @"ToolTipMusicianEdit", // 25
            @"ToolTipMusicianDelete", // 26
            @"ToolTipMusicianCancel", // 27
            @"ToolTipMusicianClose", // 28
			@"ToolTipMember", // 29
			@"ToolTipMemberEdit", // 30
			@"ToolTipMemberDelete", // 31
			@"ToolTipMemberCancel", // 32
			@"ToolTipMemberClose", // 33
			@"ToolTipMusicianContact", // 34
			@"ToolTipMusicianContactEdit", // 35
			@"ToolTipMusicianContactCancel", // 36
			@"ToolTipMusicianContactClose", // 37
			@"ToolTipAdmin", // 38
			@"ToolTipHelp", // 39
			@"ToolTipDownload", // 40
			@"ToolTipEditXml", // 41
			@"ToolTipUpdateWebsite", // 42
			@"ToolTipDocuments", // 43
			@"ToolTipRequests", // 44
			@"ToolTipUpdateJavaScriptFile", // 45
			@"ToolTipCreateUploadPosters", // 46
			@"ToolTipUploadPhotos", // 47
			@"ToolTipAdminClose", // 48
			@"ToolTipAdminMsg", // 49
            @"ToolTipCurrentSeason", // 50
            @"ToolTipAutumnSpringYear", // 51
            @"ToolTipExportToFlyerApplication", // 52
            @"ToolTipImportFromFlyerApplication", // 53
            @"ToolTipExportSeasonProgramToFlyerApplication", // 54
            @"ToolTipExportQRCodesToFlyerApplication", // 55
            @"ToolTipExportFrontPageImagesToFlyerApplication", // 56
            @"ToolTipImportMusicianTextsFromFlyerApplication", // 57
            @"ToolTipImportFreeTextsFromFlyerApplication", // 58
            @"ToolTipFlyer", // 59
            @"ToolTipSoundSample", // 60
            @"ToolTipRequestsText", // 61
            @"ToolTipSoundSampleEdit", // 62
            @"ToolTipSoundSampleDelete", // 63
            @"ToolTipSoundSampleCancel", // 64
            @"ToolTipSoundSampleClose", // 65
            @"ToolTipSoundSampleDownload", // 66
            @"ToolTipSoundSampleDownloadQr", // 67
            @"ToolTipSoundSampleUpload", // 68


        }; // m_tool_tip_names

        /// <summary>Create file with all tool tips</summary>
        public static void CreateFileToolTips(out string o_file_name)
        {
            o_file_name = @"";

            string[] m_tool_tips = new string[69];
            m_tool_tips[0] = defaultSettings.ToolTipApplication;  // 0
            m_tool_tips[1] = defaultSettings.ToolTipCheckOut; // 1
            m_tool_tips[2] = defaultSettings.ToolTipSelectSeason; // 2
            m_tool_tips[3] = defaultSettings.ToolTipSelectConcert; // 3
            m_tool_tips[4] = defaultSettings.ToolTipSelectMember;  // 4
            m_tool_tips[5] = defaultSettings.ToolTipSelectMusician;  // 5
            m_tool_tips[6] = defaultSettings.ToolTipEditTextOrTitle;  // 6 
            m_tool_tips[7] = defaultSettings.ToolTipAllSeasonPrograms;  // 7 
            m_tool_tips[8] = defaultSettings.ToolTipConcert;  // 8
            m_tool_tips[9] = defaultSettings.ToolTipMusician;  // 9 
            m_tool_tips[10] = defaultSettings.ToolTipBandContact;  // 10 
            m_tool_tips[11] = defaultSettings.ToolTipMusiciansOnly;  // 11 
            m_tool_tips[12] = defaultSettings.ToolTipPublish;  // 12 
            m_tool_tips[13] = defaultSettings.ToolTipConcertPremises;  // 13 
            m_tool_tips[14] = defaultSettings.ToolTipPremises;  // 14 
            m_tool_tips[15] = defaultSettings.ToolTipContact;  // 15 
            m_tool_tips[16] = defaultSettings.ToolTipAboutUs;  // 16
            m_tool_tips[17] = defaultSettings.ToolTipIndexBackup; // 17
            m_tool_tips[18] = defaultSettings.ToolTipIndexExit; // 18 
            m_tool_tips[19] = defaultSettings.ToolTipIndexBack; // 19
            m_tool_tips[20] = defaultSettings.ToolTipIndexCancel; // 20
            m_tool_tips[21] = defaultSettings.ToolTipConcertEdit; // 21
            m_tool_tips[22] = defaultSettings.ToolTipConcertDelete; // 22
            m_tool_tips[23] = defaultSettings.ToolTipConcertCancel; // 23
            m_tool_tips[24] = defaultSettings.ToolTipConcertClose; // 24
            m_tool_tips[25] = defaultSettings.ToolTipMusicianEdit; // 25
            m_tool_tips[26] = defaultSettings.ToolTipMusicianDelete; // 26
            m_tool_tips[27] = defaultSettings.ToolTipMusicianCancel; // 27
            m_tool_tips[28] = defaultSettings.ToolTipMusicianClose; // 28
            m_tool_tips[29] = defaultSettings.ToolTipMember; // 29
            m_tool_tips[30] = defaultSettings.ToolTipMemberEdit; // 30
            m_tool_tips[31] = defaultSettings.ToolTipMemberDelete; // 31
            m_tool_tips[32] = defaultSettings.ToolTipMemberCancel; // 32
            m_tool_tips[33] = defaultSettings.ToolTipMemberClose; // 33
            m_tool_tips[34] = defaultSettings.ToolTipMusicianContact; // 34
            m_tool_tips[35] = defaultSettings.ToolTipMusicianContactEdit; // 35
            m_tool_tips[36] = defaultSettings.ToolTipMusicianContactCancel; // 36
            m_tool_tips[37] = defaultSettings.ToolTipMusicianContactClose; // 37
            m_tool_tips[38] = defaultSettings.ToolTipAdmin; // 38
            m_tool_tips[39] = defaultSettings.ToolTipHelp; // 39
            m_tool_tips[40] = defaultSettings.ToolTipDownload; // 40
            m_tool_tips[41] = defaultSettings.ToolTipEditXml; // 41
            m_tool_tips[42] = defaultSettings.ToolTipUpdateWebsite; // 42
            m_tool_tips[43] = defaultSettings.ToolTipDocuments; // 43
            m_tool_tips[44] = defaultSettings.ToolTipRequests; // 44
            m_tool_tips[45] = defaultSettings.ToolTipUpdateJavaScriptFile; // 45
            m_tool_tips[46] = defaultSettings.ToolTipCreateUploadPosters; // 46
            m_tool_tips[47] = defaultSettings.ToolTipUploadPhotos; // 47
            m_tool_tips[48] = defaultSettings.ToolTipAdminClose; // 48
            m_tool_tips[49] = defaultSettings.ToolTipAdminMsg; // 49
            m_tool_tips[50] = defaultSettings.ToolTipCurrentSeason; // 50
            m_tool_tips[51] = defaultSettings.ToolTipAutumnSpringYear; // 51
            m_tool_tips[52] = defaultSettings.ToolTipExportToFlyerApplication; // 52
            m_tool_tips[53] = defaultSettings.ToolTipImportFromFlyerApplication; // 53
            m_tool_tips[54] = defaultSettings.ToolTipExportSeasonProgramToFlyerApplication; // 54
            m_tool_tips[55] = defaultSettings.ToolTipExportQRCodesToFlyerApplication; // 55
            m_tool_tips[56] = defaultSettings.ToolTipExportFrontPageImagesToFlyerApplication; // 56
            m_tool_tips[57] = defaultSettings.ToolTipImportMusicianTextsFromFlyerApplication; // 57
            m_tool_tips[58] = defaultSettings.ToolTipImportFreeTextsFromFlyerApplication; // 58
            m_tool_tips[59] = defaultSettings.ToolTipFlyer; // 59
            m_tool_tips[60] = defaultSettings.ToolTipSoundSample; // 60
            m_tool_tips[61] = defaultSettings.ToolTipRequestsText; // 61
            m_tool_tips[62] = defaultSettings.ToolTipSoundSampleEdit; // 62
            m_tool_tips[63] = defaultSettings.ToolTipSoundSampleDelete; // 63
            m_tool_tips[64] = defaultSettings.ToolTipSoundSampleCancel; // 64
            m_tool_tips[65] = defaultSettings.ToolTipSoundSampleClose; // 65
            m_tool_tips[66] = defaultSettings.ToolTipSoundSampleDownload; // 66
            m_tool_tips[67] = defaultSettings.ToolTipSoundSampleDownloadQr; // 67
            m_tool_tips[68] = defaultSettings.ToolTipSoundSampleUpload; // 68


            string out_str = @"ToolTips for XML Edit, Website and Flyer functions " + TimeUtil.YearMonthDayIso() + NewLine();
            out_str = out_str + @"================================================================" + NewLine() + NewLine();

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

            out_str = out_str + NewsStrings.WorkFlow();

            string file_name = @"ToolTipsAdminSettingsFunktionen_" + TimeUtil.YearMonthDay() + @".txt";

            string local_address_directory = FileUtil.SubDirectory(PhotoMain.PhotoMaintenanceDir, Main.m_exe_directory) + @"\";

            o_file_name = local_address_directory + file_name;

            File.WriteAllText(o_file_name, out_str);

        } // CreateFileToolTips

        /// <summary>Returns new line (for Windows)</summary>
        private static string NewLine() { return "\r\n"; }

        #endregion // Create text file with all tool tips

    } // JazzAppAdminSettings


} // JazzAppAdmin
