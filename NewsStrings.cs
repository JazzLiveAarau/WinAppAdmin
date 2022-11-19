using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Holds news strings
    /// <para></para>
    /// </summary>
    public static class NewsStrings
    {
        #region Titles and labels

        /// <summary>Title for news main form</summary>
        static public string TitleNewsForm = @"News";

        /// <summary>Label background color</summary>
        static public string LabelBackgroundColor = @"Hintergrundfarbe";

        /// <summary>Label text color</summary>
        static public string LabelTextColor = @"Textfarbe";

        /// <summary>Label current news header</summary>
        static public string LabelCurrentNewsHeader = @"Header";

        /// <summary>Label current news content</summary>
        static public string LabelCurrentNewsContent = @"Text";

        /// <summary>Label current news test flag</summary>
        static public string LabelCurrentNewsTestFlag = @"Test";

        /// <summary>Label image URL</summary>
        static public string LabelImageUrl = @"URL";

        /// <summary>Label image text</summary>
        static public string LabelImageText = @"Text";

        /// <summary>Label image title</summary>
        static public string LabelImageTitle = @"Titel";

        /// <summary>Label image width</summary>
        static public string LabelImageWidth = @"Breite";

        /// <summary>Label link URL</summary>
        static public string LabelLinkUrl = @"URL";

        /// <summary>Label link caption</summary>
        static public string LabelLinkCaption = @"Caption";

        /// <summary>Label email subject</summary>
        static public string LabelEmailSubject = @"Betreff";

        /// <summary>Label email caption</summary>
        static public string LabelEmailCaption = @"Caption";

        /// <summary>Label email content</summary>
        static public string LabelEmailContent = @"Text";

        /// <summary>Label start date</summary>
        static public string LabelStartDate = @"Start Datum";

        /// <summary>Label end date</summary>
        static public string LabelEndDate = @"Ende Datum";

        /// <summary>Label concert news number</summary>
        static public string LabelConcertNewsNumber = @"Nummer";

        /// <summary>Label concert news header</summary>
        static public string LabelConcertNewsHeader = @"Header";

        /// <summary>Label concert news content</summary>
        static public string LabelConcertNewsContent = @"Text";

        /// <summary>Label concert news test flag</summary>
        static public string LabelConcertNewsTestFlag = @"Test";

        /// <summary>Label concert news cancelled flag</summary>
        static public string LabelConcertCancelledFlag = @"Abgesagt";

        /// <summary>Label group box current news</summary>
        static public string LabelGroupBoxCurrentNews = @"News";

        /// <summary>Label group box concert news</summary>
        static public string LabelGroupBoxConcertNews = @"Konzert";

        /// <summary>Label group box image</summary>
        static public string LabelGroupBoxImage = @"Bild";

        /// <summary>Label group box link</summary>
        static public string LabelGroupBoxLink = @"Link";

        /// <summary>Label group box email</summary>
        static public string LabelGroupBoxEmail = @"E-Mail";


        #endregion // Titles and labels

        #region Prompts

        /// <summary>Prompt for adding news</summary>
        static public string PromptAddCurrentNews = @"Eintrag zufügen";

        /// <summary>Prompt for selection of news</summary>
        static public string PromptSelectCurrentNews = @"Eintrag wählen";

        static public string ItemTextCurrentNews = @"Eintrag ";

        /// <summary>Prompt for adding concert news</summary>
        static public string PromptAddConcertNews = @"Eintrag zufügen";

        /// <summary>Prompt for selection of concert news</summary>
        static public string PromptSelectConcertNews = @"Eintrag wählen";

        static public string ItemTextConcertNews = @"Eintrag ";

        #endregion // Prompts

        #region Error messages

        /// <summary>Error message: Current news content must be set</summary>
        static public string ErrMsgCurrentNewsContentNotSet = @"Text darf nicht leer sein";

        /// <summary>Error message: Concert news number must be set</summary>
        static public string ErrMsgConcertNewsNumberNotSet = @"Konzert-Nummer darf nicht leer sein";

        /// <summary>Error message: Concert news number is unvalid</summary>
        static public string ErrMsgConcertNewsNumberNotNotValid = @"Konzert-Nummer ist ungültig";

        /// <summary>Error message: Concert news content must be set</summary>
        static public string ErrMsgConcertNewsContentNotSet = @"Konzert-Text darf nicht leer sein";

        /// <summary>Error message: Delete of curren news only allowed after checkout</summary>
        static public string ErrMsgDeleteNewsOnlyAllowedAfterCheckout = @"Löschen ist nur möglich nach Checkout";

        /// <summary>Error message: Delete of concert news only allowed after checkout</summary>
        static public string ErrMsgDeleteConcertNewsOnlyAllowedAfterCheckout = @"Löschen ist nur möglich nach Checkout";

        /// <summary>Error message: Current news is not selected and delete cannot be executed</summary>
        static public string ErrMsgNewsForDeleteNotSelected = @"Zuerst bitte Eintrag wählen und danach löschen";

        /// <summary>Error message: Concert news is not selected and delete cannot be executed</summary>
        static public string ErrMsgConcertNewsForDeleteNotSelected = @"Zuerst bitte Eintrag wählen und danach löschen";

        /// <summary>Error message: Adding of current news only allowed after checkout</summary>
        static public string ErrMsgNewsAddingOnlyAfterCheckout = @"Eintrag zufügen nur nach Checkout";

        /// <summary>Error message: Adding of concert news only allowed after checkout</summary>
        static public string ErrMsgConcertNewsAddingOnlyAfterCheckout = @"Eintrag zufügen nur nach Checkout";

        /// <summary>Error message: Only one concert news item can be displayed on the homepage test version</summary>
        static public string ErrMsgConcertNewsRemoveTestFlagForNewsItem = @"Nur ein Eintrag kann in der Testversion gezeigt werden. Bitte Testflagge wegnehmen für Eintrag: ";

        #endregion // Error messages

        #region Warning messages

        /// <summary>Warning message: Close news window without saving?</summary>
        static public string WarningMsgCloseWindowWithoutSaving = @"Möchten sie das Fenster zumachen ohne die Daten zu speichern?";


        #endregion // Warning messages

        #region Captions and labels 

        /// <summary>Caption for button save</summary>
        static public string CaptionButtonSave = @"Speichern";

        /// <summary>Caption for button close</summary>
        static public string CaptionButtonClose = @"Close";

        /// <summary>Caption for button cancel</summary>
        static public string CaptionButtonCancel = @"Cancel";

        #endregion // Captions and labels 

        #region Tool tips

        /// <summary>Tool tip for the jazz main request dialog</summary>
        static public string ToolTipNewsForm =    @"Homepage News (XML)" + NewLine() +
                                                  @"Es gibt zwei Typen von News: Allgemeine und für einzelne Konzerte." + NewLine() +
                                                  @"Allgemeine News sind zum Beispiel:" + NewLine() +
                                                  @"- Information über eine neue Funktion auf der Homepage" + NewLine() +
                                                  @"- Ein Supporter-Angebot" + NewLine() +
                                                  @"Konzert-News ist vor allem für den Fall, dass ein Konzert abgesagt ist." + NewLine() +
                                                  @"Mehrere Allgemein-News-Einträge können in voraus definiert werden." + NewLine() +
                                                  @"Mit der Homepage Testversion und dem Test Parameter kann Einträge in voraus kontrolliert werden.";

        /// <summary>Tool tip for the background color</summary>
        static public string ToolTipNewsBackgroundColor = @"Definiert die Hintergrundfarbe für das News Fenster" + NewLine() +
                                                          @"Anteile der Grundfarben Rot, Grün und Blau bestimmen die Farbe.";

        /// <summary>Tool tip for the background color</summary>
        static public string ToolTipNewsTextColor = @"Definiert die Textfarbe für das News Fenster" + NewLine() +
                                                    @"Anteile der Grundfarben Rot, Grün und Blau bestimmen die Farbe.";

        /// <summary>Tool tip for the checkout/edit button</summary>
        static public string ToolTipNewsCheckout = @"Hier klicken für Änderungen (nur möglich nach Checkout).";

        /// <summary>Tool tip cancel for the cancel button</summary>
        static public string ToolTipNewsCancelButton = @"Zurück zum Hauptdialog ohne Änderungen zu speichern";

        /// <summary>Tool tip for the save/close button</summary>
        static public string ToolTipNewsSaveCloseButton = @"Änderungen speichern nach Checkout (Save)." + NewLine() +
                                                          @"Zurück zum Hauptdialog (Close).";

        /// <summary>Tool tip for the current news dropdown menu</summary>
        static public string ToolTipNewsDropdown = @"Eintrag wählen oder zufügen." + NewLine() +
                                                   @"Zufügen nur nach Checkout möglich.";

        /// <summary>Tool tip for the current news header</summary>
        static public string ToolTipNewsHeader = @"Titel für den Text." + NewLine() +
                                                 @"Erfassen nur nach Checkout möglich.";

        /// <summary>Tool tip for the current news text</summary>
        static public string ToolTipNewsContent = @"News Text." + NewLine() +
                                                  @"Erfassen nur nach Checkout möglich.";

        /// <summary>Tool tip for the current news test flag</summary>
        static public string ToolTipNewsTestFlag = @"News werden nur auf der Testversion angezeigt wenn die entsprechende Check-Box gesetzt ist." + NewLine() +
                                                   @"Dieses Flag wird benötigt, um die Admin-News-Funktion zu testen " + NewLine() +
                                                   @"und um News die erst später gezeigt werden sollen vorzubereiten und zu testen." + NewLine() +
                                                   @"Wenn die Check Box NICHT gesetzt ist, werden die News auf der Homepage gezeigt.";

        /// <summary>Tool tip for the current news delete</summary>
        static public string ToolTipNewsDelete = @"Eintrag löschen." + NewLine() +
                                                 @"Löschen ist nur nach Checkout möglich.";

        /// <summary>Tool tip for the current news image URL</summary>
        static public string ToolTipNewsImageUrl = @"Web-Adresse (URL) für ein Bild." + NewLine() +
                                                   @"Normalerweise Homepage/News/Yyz.png." + NewLine() +
                                                   @"Das Bild muss mit einem FTP Programm aufgeladen werden.";

        /// <summary>Tool tip for the current news image width</summary>
        static public string ToolTipNewsImageWidth = @"Breite des Bildes." + NewLine() +
                                                     @"Bitte auch px oder mm eingeben";

        /// <summary>Tool tip for the current news image text</summary>
        static public string ToolTipNewsImageText = @"Text unterm Bild." + NewLine();

        /// <summary>Tool tip for the current news image title</summary>
        static public string ToolTipNewsImageTitle = @"Titel des Bildes. Wird gezeigt als Tooltip" + NewLine();

        /// <summary>Tool tip for the current news link URL</summary>
        static public string ToolTipNewsLinkUrl = @"Link Web-Adresse (URL)." + NewLine() +
                                                  @"Normalerweise Homepage/News/Yyz.htm." + NewLine() +
                                                  @"Möglich ist aber auch www.Xyz.com.";

        /// <summary>Tool tip for the current news link caption</summary>
        static public string ToolTipNewsLinkCaption = @"Text für den Link-Button." + NewLine();

        /// <summary>Tool tip for the current news email subject</summary>
        static public string ToolTipNewsEmailSubject = @"Betreff für eine E-Mail" + NewLine() +
                                                       @"";

        /// <summary>Tool tip for the current news email caption</summary>
        static public string ToolTipNewsEmailCaption = @"Text für den E-Mail-Button." + NewLine() +
                                                       @"";

        /// <summary>Tool tip for the current news email email</summary>
        static public string ToolTipNewsEmailContent = @"E-Mail Text." + NewLine() +
                                                       @"";

        /// <summary>Tool tip for the current news start date</summary>
        static public string ToolTipNewsStartDate = @"Start Datum." + NewLine() +
                                                    @"";

        /// <summary>Tool tip for the current news end date</summary>
        static public string ToolTipNewsEndDate = @"Ende Datum." + NewLine() +
                                                  @"";

        /// <summary>Tool tip for the concert news dropdown menu</summary>
        static public string ToolTipNewsConcertDropdown = @"Eintrag wählen oder zufügen." + NewLine() +
                                                          @"Bestehende Einträge stehen lassen." + NewLine() +
                                                          @"Zufügen nur nach Checkout möglich.";

        /// <summary>Tool tip for the concert news number</summary>
        static public string ToolTipNewsConcertNumber = @"Bitte Konzertnummer (1-12) eingeben." + NewLine() +
                                                        @"Bandname wird gezeigt.";

        /// <summary>Tool tip for the concert news band name</summary>
        static public string ToolTipNewsConcertBandName = @"Bitte Konzertnummer (1-12) eingeben." + NewLine() +
                                                          @"Bandname wird gezeigt.";

        /// <summary>Tool tip for the concert news cancellation flag</summary>
        static public string ToolTipNewsConcertCancelledFlag = @"Hier klicken wenn Konzert abgesagt ist" + NewLine() +
                                                               @"";

        /// <summary>Tool tip for the concert news header</summary>
        static public string ToolTipNewsConcertHeader = @"Titel für den Konzerttext" + NewLine() +
                                                        @"Dies ist ein fakultativer Eintrag" + NewLine() +
                                                        @"";


        /// <summary>Tool tip for the concert news content</summary>
        static public string ToolTipNewsConcertContent = @"Text zum gewählten Konzert eingeben." + NewLine() +
                                                         @"Text kann mit HTML-Syntax formatiert werden (z.B. <b> </b> für Fett)" + NewLine() +
                                                         @"";

        /// <summary>Tool tip for the concert news test flag</summary>
        static public string ToolTipConcertNewsTestFlag = @"News werden auf der Homepage-Testversion nur gezeigt, wenn die Check-Box gesetzt ist." + NewLine() +
                                                          @"Dieses Flag wird gebraucht, um die Admin-News-Funktionen zu testen." + NewLine() +
                                                          @"Wenn die Check Box NICHT gesetzt ist, werden die News auf der Homepage gezeigt.";

        /// <summary>Tool tip for the concert news delete</summary>
        static public string ToolTipConcertNewsDelete = @"Eintrag löschen." + NewLine() +
                                                        @"Löschen ist nur nach Checkout möglich.";

        /// <summary>Tool tip for the concert news message</summary>
        static public string ToolTipConcertNewsMessage = @"Meldungen von News Funktionen" + NewLine() +
                                                         @"";


        #endregion // Tool tips

        #region Create text file with all tool tips

        /// <summary>All tool tips names</summary>
        static private string[] m_tool_tip_names =
        {
            @"ToolTipNewsForm",  // 0
            @"ToolTipNewsBackgroundColor", // 1
            @"ToolTipNewsTextColor", // 2
            @"ToolTipNewsCheckout", // 3
            @"ToolTipNewsCancelButton",  // 4
            @"ToolTipNewsSaveCloseButton",  // 5
            @"ToolTipNewsDropdown",  // 6 
            @"ToolTipNewsHeader",  // 7 
            @"ToolTipNewsContent",  // 8
            @"ToolTipNewsTestFlag",  // 9 
            @"ToolTipNewsDelete",  // 10 
            @"ToolTipNewsImageUrl",  // 11 
            @"ToolTipNewsImageWidth",  // 12 
            @"ToolTipNewsImageText",  // 13 
            @"ToolTipNewsImageTitle",  // 14 
            @"ToolTipNewsLinkUrl",  // 15 
            @"ToolTipNewsLinkCaption",  // 16
            @"ToolTipNewsEmailSubject", // 17
            @"ToolTipNewsEmailCaption", // 18 
            @"ToolTipNewsEmailContent", // 19
            @"ToolTipNewsStartDate", // 20
            @"ToolTipNewsEndDate", // 21
            @"ToolTipNewsConcertDropdown", // 22
            @"ToolTipNewsConcertNumber", // 23
            @"ToolTipNewsConcertBandName", // 24
            @"ToolTipNewsConcertCancelledFlag", // 25
            @"ToolTipNewsConcertHeader", // 26
            @"ToolTipNewsConcertContent", // 27
            @"ToolTipConcertNewsTestFlag", // 28
            @"ToolTipConcertNewsDelete", // 29
            @"ToolTipConcertNewsMessage", // 30

        }; // m_tool_tip_names

        /// <summary>Create file with all tool tips</summary>
        public static void CreateFileToolTips(out string o_file_name)
        {
            string[] m_tool_tips = new string[45];
            m_tool_tips[0] = ToolTipNewsForm;  // 0
            m_tool_tips[1] = ToolTipNewsBackgroundColor; // 1
            m_tool_tips[2] = ToolTipNewsTextColor; // 2
            m_tool_tips[3] = ToolTipNewsCheckout; // 3
            m_tool_tips[4] = ToolTipNewsCancelButton;  // 4
            m_tool_tips[5] = ToolTipNewsSaveCloseButton;  // 5
            m_tool_tips[6] = ToolTipNewsDropdown;  // 6 
            m_tool_tips[7] = ToolTipNewsHeader;  // 7 
            m_tool_tips[8] = ToolTipNewsContent;  // 8
            m_tool_tips[9] = ToolTipNewsTestFlag;  // 9 
            m_tool_tips[10] = ToolTipNewsDelete;  // 10 
            m_tool_tips[11] = ToolTipNewsImageUrl;  // 11 
            m_tool_tips[12] = ToolTipNewsImageWidth;  // 12 
            m_tool_tips[13] = ToolTipNewsImageText;  // 13 
            m_tool_tips[14] = ToolTipNewsImageTitle;  // 14 
            m_tool_tips[15] = ToolTipNewsLinkUrl;  // 15 
            m_tool_tips[16] = ToolTipNewsLinkCaption;  // 16
            m_tool_tips[17] = ToolTipNewsEmailSubject; // 17
            m_tool_tips[18] = ToolTipNewsEmailCaption; // 18 
            m_tool_tips[19] = ToolTipNewsEmailContent; // 19
            m_tool_tips[20] = ToolTipNewsStartDate; // 20
            m_tool_tips[21] = ToolTipNewsEndDate; // 21
            m_tool_tips[22] = ToolTipNewsConcertDropdown; // 22
            m_tool_tips[23] = ToolTipNewsConcertNumber; // 23
            m_tool_tips[24] = ToolTipNewsConcertBandName; // 24
            m_tool_tips[25] = ToolTipNewsConcertCancelledFlag; // 25
            m_tool_tips[26] = ToolTipNewsConcertHeader; // 26
            m_tool_tips[27] = ToolTipNewsConcertContent; // 27
            m_tool_tips[28] = ToolTipConcertNewsTestFlag; // 28
            m_tool_tips[29] = ToolTipConcertNewsDelete; // 29
            m_tool_tips[30] = ToolTipConcertNewsMessage; // 30

            string out_str = @"ToolTips for News functions " + TimeUtil.YearMonthDayIso() + NewLine();
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

            string file_name = @"ToolTipsNewsFunktionen_" + TimeUtil.YearMonthDay() + @".txt";

            string local_address_directory = FileUtil.SubDirectory(RequestStrings.MaintenanceDir, Main.m_exe_directory) + @"\";

            string full_file_name = local_address_directory + file_name;

            File.WriteAllText(full_file_name, out_str);

            o_file_name = full_file_name;

        } // CreateFileToolTips

        /// <summary>Returns new line (for Windows)</summary>
        private static string NewLine() { return "\r\n"; }

        /// <summary>Returns the work flow for a change of tooltips</summary>
        public static string WorkFlow()
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

    } // NewsStrings

} // namespace
