using JazzApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Main form for the handling of JAZZ live AARAU documents
    /// <para>This is Graphical User Interface class. Commands should not be executed in this class.</para>
    /// </summary>
    public partial class DocAdminForm : Form
    {
        #region Member variables

        /// <summary>Flag telling if the dialog controls have been initialized</summary>
        private bool m_dialog_comboboxes_initialized = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor that initializes the control elements</summary>
        public DocAdminForm()
        {
            InitializeComponent();

            string error_message = @"";

            if (!DocAdmin.DocAll.SetActiveSeasonToThisSeason(out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            // DocAdmin.DocAll (JazzDocAll) object is static. Created the first time DocAdmin is called from this dialog
            // If the dialog is closed and re-opened a reload should be done so that the object is updated 
            // with changes from other users.
            // An alternative approach could be that a new instance of DocAdmin.DocAll is created every time
            // this dialog is opened. 
            // Refer also to the classes Intranet and Website that also have JazzDocAll as member parameters.
            if (!DocAdmin.DocAll.ReloadXmlSetMembersBeforeCheckout(out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            if (!_InitHtmlFiles(out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            if (!_InitHelpFiles(out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            _SetTitles();

            _SetButtons();

            _SetComboBoxes();

            _SetToolTips();

            _SetLoginLogout();

            _HideNotUsedFunctions();

        } // Constructor

        #endregion // Constructor

        #region Set functions

        /// <summary>Initialize HTML files for upload and download</summary>
        private bool _InitHtmlFiles(out string o_error)
        {
            o_error = @"";
            if (!DocAdmin.InitHtmFiles(out o_error))
            {
                return false;
            }

            return true;
        } // _InitHtmlFiles

        /// <summary>Initialize help files for upload and download</summary>
        private bool _InitHelpFiles(out string o_error)
        {
            o_error = @"";
            if (!DocAdmin.InitHelpFiles(out o_error))
            {
                return false;
            }

            return true;
        } // _InitHelpFiles

        /// <summary>Set titles</summary>
        private void _SetTitles()
        {
            this.Text = DocAdminString.TitleDocAdminForm;
            this.m_label_documents.Text = DocAdminString.TitleDocAdminForm;

            this.m_label_season_documents.Text = DocAdminString.LabelSeasonDocument;

            this.m_textbox_message.Text = @"";

        } // _SetTitles

        /// <summary>Set combo boxes</summary>
        private void _SetComboBoxes()
        {
            m_dialog_comboboxes_initialized = false;

            DocAdmin.SetComboBoxDocumentSeasons(m_combo_box_season);

            DocAdmin.SetComboBoxConcerts(m_combo_box_concert);

            DocAdmin.SetComboBoxSeasonDocuments(m_combo_box_season_documents);

            DocAdmin.SetComboBoxConcertDocuments(m_combo_box_concert_documents);

            DocAdmin.SetComboBoxHtmFiles(m_combo_box_htm_file);  //20231001 Not used for the moment 

            DocAdmin.SetComboBoxHelpFiles(m_combo_box_help_file);

            m_dialog_comboboxes_initialized = true;

        } // _SetComboBoxes

        /// <summary>Set buttons</summary>
        private void _SetButtons()
        {
            this.m_button_cancel.Text = JazzAppAdminSettings.Default.Caption_Cancel;
            this.m_button_close.Text = JazzAppAdminSettings.Default.Caption_Close;
            this.m_button_exit.Text = JazzAppAdminSettings.Default.Caption_Exit;

        } // _SetButtons

        /// <summary>Hide no longer used functions</summary>
        private void _HideNotUsedFunctions()
        {
            this.m_combo_box_htm_file.Enabled = false;
            this.m_combo_box_htm_file.Visible = false;

            this.m_label_htm_files.Enabled = false;
            this.m_label_htm_files.Visible = false;

            this.m_group_box_web.Enabled = false;
            this.m_group_box_web.Visible = false;

        } // _HideNotUsedFunctions

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipDocumentsForm.SetToolTip(this, DocAdminString.ToolTipDocumentsForm);
            ToolTipDocumentsForm.SetToolTip(m_label_documents, DocAdminString.ToolTipDocumentsForm);
            ToolTipDocumentsForm.SetToolTip(m_picture_box_text_logo, DocAdminString.ToolTipDocumentsForm);
            ToolTipUtil.SetDelays(ref ToolTipDocumentsForm);
            ToolTipCheckOut.SetToolTip(m_button_checkin_checkout, JazzAppAdminSettings.Default.ToolTipCheckOut);
            ToolTipUtil.SetDelays(ref ToolTipCheckOut);
            ToolTipHelp.SetToolTip(m_button_help, JazzAppAdminSettings.Default.ToolTipHelp);
            ToolTipUtil.SetDelays(ref ToolTipHelp);
            ToolTipSelectConcert.SetToolTip(m_combo_box_concert, DocAdminString.ToolTipSelectConcert);
            ToolTipUtil.SetDelays(ref ToolTipSelectConcert);
            ToolTipSelectConcertDocument.SetToolTip(m_label_concert_documents, DocAdminString.ToolTipSelectConcertDocument);
            ToolTipSelectConcertDocument.SetToolTip(m_combo_box_concert_documents, DocAdminString.ToolTipSelectConcertDocument);
            ToolTipUtil.SetDelays(ref ToolTipSelectConcertDocument);
            ToolTipSelectSeasonDocument.SetToolTip(m_label_season_documents, DocAdminString.ToolTipSelectSeasonDocument);
            ToolTipSelectSeasonDocument.SetToolTip(m_combo_box_season_documents, DocAdminString.ToolTipSelectSeasonDocument);
            ToolTipUtil.SetDelays(ref ToolTipSelectSeasonDocument);
            ToolTipDocumentsFormMessage.SetToolTip(m_textbox_message, DocAdminString.ToolTipDocumentsFormMessage);
            ToolTipUtil.SetDelays(ref ToolTipDocumentsFormMessage);

            ToolTipDocumentsFormExit.SetToolTip(m_button_exit, JazzAppAdminSettings.Default.ToolTipIndexExit);
            ToolTipUtil.SetDelays(ref ToolTipDocumentsFormExit);
            ToolTipDocumentsFormClose.SetToolTip(m_button_close, JazzAppAdminSettings.Default.ToolTipIndexBack);
            ToolTipUtil.SetDelays(ref ToolTipDocumentsFormClose);
            ToolTipDocumentsFormCancel.SetToolTip(m_button_cancel, JazzAppAdminSettings.Default.ToolTipIndexCancel);
            ToolTipUtil.SetDelays(ref ToolTipDocumentsFormCancel);

        } // SetToolTips 

        /// <summary>Set the Login/Logout button</summary>
        private void _SetLoginLogout()
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                m_button_checkin_checkout.Text = JazzAppAdminSettings.Default.Caption_CheckIn;
            }
            else
            {
                m_button_checkin_checkout.Text = JazzAppAdminSettings.Default.Caption_CheckOut;
            }

        } // _SetLoginLogout

        /// <summary>Check out data and set Checkin/Checkout button to Save</summary>


        /// <summary>Check out data and set Checkin/Checkout button to Save
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="o_b_user_cancelled">Eq. true: Already checked out. User did not force a checkout, i.e. cancelled the checkout</param>
        /// <param name="i_doc_exe_document">Object with data about the document and with execution functions</param>
        public bool CheckoutData(out bool o_b_user_cancelled)
        {
            o_b_user_cancelled = false;

            ReloadXmlBeforeCheckout();

            // Returned value 'false' means that the somebody else already has checked out and 
            // that the user not forced a checkeout
            bool b_checkout_data= AdminUtils.CheckoutData();
            if (!b_checkout_data)
            {
                o_b_user_cancelled = true;
                return true;
            }

            _SetLoginLogout();

            // TODO _SetCurrentEditDocument();

            bool xml_edited = false;
            string err_message = @"";

            if (Backup.BackupCurrentEditXmlFile(DocAdmin.DocAll.ActiveSeasonFileName, xml_edited, out err_message))
            {
                string file_no_path = Path.GetFileName(DocAdmin.DocAll.ActiveSeasonFileName);
                this.m_textbox_message.Text = file_no_path + JazzAppAdminSettings.Default.MsgBackupCurrenXml;
            }
            else
            {
                err_message = "DocAdminForm.CheckoutData Backup Program error: " + err_message;
                this.m_textbox_message.Text = err_message;
                return false;
            }

            return true;
        } // CheckoutData

        /// <summary>Reload XML before checkout</summary>
        private void ReloadXmlBeforeCheckout()
        {
            AdminUtils.ReloadCurrentSeasonDocumentXml();

            string error_message = @"";
            
            if (!DocAdmin.DocAll.ReloadXmlSetMembersBeforeCheckout(out error_message))
            {
                return;
            }         

        } // _ReloadXmlBeforeCheckout

        /// <summary>Upload changed file to the server, check in data and set Checkin/Checkout button to Save</summary>
        private void CheckinData()
        {
            string error_message = @"";
            if (!DocAdmin.UploadEditedXmlToServer(out error_message))
            {
                error_message = @"DocAdminForm.CheckinData Programming error: " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }

            this.m_textbox_message.Text = @"";

            //TODO AdminUtils.SetCurrentEditDocument(null);
            //TODO  AdminUtils.SetCurrentSelectedXmlFile(@"");

            string out_message = @"";
            bool force_checkin = false;
            if (!JazzLoginLogout.LoginLogout.Checkin(force_checkin, out out_message, out error_message))
            {
                error_message = @"DocAdminForm.CheckinData Programming error: " + error_message;
                this.m_textbox_message.Text = error_message;
                return;
            }

            _SetLoginLogout();

        } // CheckinData

        #endregion // Set functions

        #region Event functions

        /// <summary>User clicked the cancel button</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Cancel))
                {
                    return; // The user did not want to exit without saving
                }
            }


            this.Close();
        } // m_button_cancel_Click

        /// <summary>User clicked the close button</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Cancel))
                {
                    return; // The user did not want to exit without saving
                }
            }

            this.Close();

        } // m_button_close_Click

        /// <summary>User clicked the exit application button</summary>
        private void m_button_exit_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                if (!QuitWithoutSaving(JazzAppAdminSettings.Default.Caption_Cancel))
                {
                    return; // The user did not want to exit without saving
                }

                Application.Exit();
            }

            if (!Main.ApplicationExit())
            {
                return;
            }

            Application.Exit();

        } // m_button_exit_Click

        /// <summary>Handles the user event that edited data not shall be saved
        /// <para>A message box will be displayed letting the user decide if he really wants to quit without saving</para>
        /// <para>The function returns false if the user decides not to quit without saving</para>
        /// <para>If the user decides to quit the following is done:</para>
        /// <para>- The login-logout file will register a "forced" login</para>
        /// <para>- The current XDocument will be reset with XML data from the server</para>
        /// <para>- Controls will be reset</para>
        /// </summary>
        /// <param name="i_caption">The caption for the quit without save message box</param>
        private bool QuitWithoutSaving(string i_caption)
        {
            if (AdminUtils.MessageBoxYesNo(JazzAppAdminSettings.Default.MsgCloseWithoutSaving, i_caption))
            {
                string error_message = @"";
                string out_message = @"";
                bool force_checkin = true;

                if (!JazzLoginLogout.LoginLogout.Checkin(force_checkin, out out_message, out error_message))
                {
                    return false; // Programming error
                }

                DocAdmin.ResetCurrentXDocumentAfterQuit(out error_message);

                DocAdmin.SetIndexActiveDoc(DocAdmin.GetIndexLatestDoc());

                DocAdmin.DocAll.ActiveBandName = DocAdmin.DocAll.FirstBandName;

                if (!DocAdmin.SetActiveXmlDocAndFileName(DocAdmin.GetIndexActiveDoc(), out error_message))
                {
                    MessageBox.Show(error_message);
                    return false;
                }

                _SetComboBoxes();

                _SetLoginLogout();

                return true;
            }

            return false;

        } // QuitWithoutSaving

        /// <summary>User changed season</summary>
        private void m_combo_box_season_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_dialog_comboboxes_initialized)
                return;

            string error_message = @"";

            string add_season = AdminUtils.GetAddSeasonString();
            if (add_season.Equals(m_combo_box_season.Text))
            {
                if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
                {
                    string error_checkout = DocAdminString.ErrMsgCheckoutBeforeUpload + Path.GetFileName(JazzXml.GetFileNameActiveObject());
                    MessageBox.Show(error_checkout);
                    return;
                }

                DocAdmin.DocAll.AdminForm = this;

                string added_season_name = @"";
                bool user_cancelled = false;
                if (!DocAdmin.DocAll.AddSeasonDocumentsXML(out added_season_name, out user_cancelled, out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }

                if (user_cancelled)
                {
                    m_textbox_message.Text = DocAdminString.MsgCreationOfNewSeasonDocumentsXmlCancelled;

                    m_dialog_comboboxes_initialized = false;

                    _SetComboBoxes();

                    m_dialog_comboboxes_initialized = true;

                    return; 
                }
                else
                {
                    m_combo_box_season.Text = added_season_name;
                }                
            }

            if (!DocAdmin.DocAll.SetActiveSeason(m_combo_box_season.Text, out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

            m_dialog_comboboxes_initialized = false;

            _SetComboBoxes();

            m_dialog_comboboxes_initialized = true;

        } // m_combo_box_season_SelectedIndexChanged

        /// <summary>User changed concert</summary>
        private void m_combo_box_concert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_dialog_comboboxes_initialized)
                return;

            string error_message = @"";

            DocAdmin.DocAll.ActiveBandName = m_combo_box_concert.Text;

            if (!DocAdmin.DocAll.SetAllConcertDocumentsForActiveBandName(out error_message))
            {
                MessageBox.Show(error_message);
                return;
            }

        } // m_combo_box_concert_SelectedIndexChanged

        /// <summary>User clicked the checkin-checkout button</summary>
        private void m_button_checkin_checkout_Click(object sender, EventArgs e)
        {
            if (!m_dialog_comboboxes_initialized)
                return;

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                CheckinData();
            }
            else
            {
                bool b_user_cancelled = false;
                CheckoutData(out b_user_cancelled);
            }

        } // m_button_checkin_checkout_Click

        /// <summary>User clicked the help button</summary>
        private void m_button_help_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            DownLoad down_load = new DownLoad();
            if (down_load.DownloadHelpFiles(out error_message))
            {
                m_textbox_message.Text = HelpFiles.GetFilenameAdminDocuments() + JazzAppAdminSettings.Default.MsgHelpFileDownload;

                HelpForm help_form = new HelpForm(HelpFiles.GetFilenameAdminDocuments());
                help_form.Owner = this;
                help_form.ShowDialog();
            }
            else
            {
                MessageBox.Show(JazzAppAdminSettings.Default.ErrMsgHelpFileDownload);
            }

        } // m_button_help_Click

        #endregion // Event functions

        #region Selection and execution of a season document

        /// <summary>User selected season document to be uploaded or downloaded</summary>
        private void m_combo_box_season_documents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_dialog_comboboxes_initialized)
                return;

            if (DocAdminString.PromptSeasonDocument.Equals(m_combo_box_season_documents.Text))
            {
                return;
            }

            OpenSeasonDialog();

            m_dialog_comboboxes_initialized = false;
            DocAdmin.SetComboBoxSeasonDocuments(m_combo_box_season_documents);
            m_dialog_comboboxes_initialized = true;

        } // m_combo_box_season_documents_SelectedIndexChanged


        /// <summary>Open season dialog</summary>
        private void OpenSeasonDialog()
        {
            string error_message = @"";

            string template_name = DocAdmin.DocAll.GetDocumentTemplateName(m_combo_box_season_documents.Text);

            JazzDoc season_document_object = DocAdmin.DocAll.GetDocSeason(template_name, out error_message);
            if (null == season_document_object)
            {
                error_message = @"DocAdminForm.OpenSeasonDialog " + error_message;
                MessageBox.Show(error_message);
                return;
            }

            JazzDocTemplate doc_template = DocAdmin.DocAll.GetDocumentTemplate(template_name, out error_message);
            if (null == doc_template)
            {
                error_message = @"DocAdminForm.OpenSeasonDialog " + error_message;
                MessageBox.Show(error_message);
                return;
            }

            DocExeDocument doc_exe_document = new DocExeDocument();
            doc_exe_document.SetDocumentData(season_document_object);
            doc_exe_document.SetDocumentTemplate(doc_template);
            string title_dialog = doc_template.TemplateDocumentDialogTitle;
            doc_exe_document.SetTitleDocument(DocAdminString.GetTitleFormDocument(title_dialog));
            doc_exe_document.SetLabelPageHeader(title_dialog);
            string file_type = doc_template.TemplateDocumentType;
            doc_exe_document.SetFileType(file_type);
            if (!file_type.Equals("season"))
            {
                error_message = @"DocAdminForm.OpenSeasonDialog Programming error. File type is not season but " + file_type;
                MessageBox.Show(error_message);
                return;
            }

            string document_dialog = doc_template.TemplateDocumentDialog;

            if (document_dialog.Equals("DocPdf"))
            {
                DocOriginPdfForm doc_pdf_form = new DocOriginPdfForm(this, doc_exe_document);
                doc_pdf_form.Owner = this;
                doc_pdf_form.ShowDialog();
            }
            else if (document_dialog.Equals("DocPdfImg"))
            {
                DocDocPdfImgForm doc_pdf_img_pdf_form = new DocDocPdfImgForm(this, doc_exe_document);
                doc_pdf_img_pdf_form.Owner = this;
                doc_pdf_img_pdf_form.ShowDialog();
            }
            else if (document_dialog.Equals("XlsPdf"))
            {
                DocXlsPdfForm xls_pdf_form = new DocXlsPdfForm(this, doc_exe_document);
                xls_pdf_form.Owner = this;
                xls_pdf_form.ShowDialog();
            }
            else if (document_dialog.Equals("Program"))
            {
                DocProgramForm doc_program_form = new DocProgramForm(this, season_document_object, doc_template);

                doc_program_form.Owner = this;
                doc_program_form.ShowDialog();
            }
            else
            {
                error_message = @"DocAdminForm.OpenSeasonDialog Programming error. Document dialog is not DocPdf, DocPdfImg, XlsPdf or Program  but " + document_dialog;
                MessageBox.Show(error_message);
                return;
            }


        }// OpenSeasonDialog

        #endregion // Selection and execution of a season document

        #region Selection and execution of a concert document

        /// <summary>Open concert dialog</summary>
        private void OpenConcertDialog()
        {
            string error_message = @"";

            string template_name = DocAdmin.DocAll.GetDocumentTemplateName(m_combo_box_concert_documents.Text);

            JazzDoc concert_document_object = DocAdmin.DocAll.GetDocConcert(template_name, out error_message);
            if (null == concert_document_object)
            {
                error_message = @"DocAdminForm.OpenConcertDialog " + error_message;
                MessageBox.Show(error_message);
                return;
            }

            JazzDocTemplate doc_template = DocAdmin.DocAll.GetDocumentTemplate(template_name, out error_message);
            if (null == doc_template)
            {
                error_message = @"DocAdminForm.OpenConcertDialog " + error_message;
                MessageBox.Show(error_message);
                return;
            }

            DocExeDocument doc_exe_document = new DocExeDocument();
            doc_exe_document.SetDocumentData(concert_document_object);
            doc_exe_document.SetDocumentTemplate(doc_template);
            string title_dialog = doc_template.TemplateDocumentDialogTitle;
            doc_exe_document.SetTitleDocument(DocAdminString.GetTitleFormDocument(title_dialog));
            doc_exe_document.SetLabelPageHeader(title_dialog);
            string file_type = doc_template.TemplateDocumentType;
            doc_exe_document.SetFileType(file_type);
            if (!file_type.Equals("concert"))
            {
                error_message = @"DocAdminForm.OpenConcertDialog Programming error. File type is not concert but " + file_type;
                MessageBox.Show(error_message);
                return;
            }

            string document_dialog = doc_template.TemplateDocumentDialog;

            if (document_dialog.Equals("DocPdf"))
            {
                DocOriginPdfForm doc_pdf_form = new DocOriginPdfForm(this, doc_exe_document);
                doc_pdf_form.Owner = this;
                doc_pdf_form.ShowDialog();
            }
            else if (document_dialog.Equals("DocPdfImg"))
            {
                DocDocPdfImgForm doc_pdf_img_pdf_form = new DocDocPdfImgForm(this, doc_exe_document);
                doc_pdf_img_pdf_form.Owner = this;
                doc_pdf_img_pdf_form.ShowDialog();
            }
            else if (document_dialog.Equals("XlsPdf"))
            {
                DocXlsPdfForm xls_pdf_form = new DocXlsPdfForm(this, doc_exe_document);
                xls_pdf_form.Owner = this;
                xls_pdf_form.ShowDialog();
            }
            else
            {
                error_message = @"DocAdminForm.OpenConcertDialog Programming error. Document dialog is not DocPdf, DocPdfImg or XlsPdf  but " + document_dialog;
                MessageBox.Show(error_message);
                return;
            }


        }// OpenConcertDialog


        /// <summary>User selected concert document to be uploaded or downloaded</summary>
        private void m_combo_box_concert_documents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_dialog_comboboxes_initialized)
                return;

            if (DocAdminString.PromptConcertDocument.Equals(m_combo_box_concert_documents.Text))
            {
                return;
            }

            OpenConcertDialog();

            m_dialog_comboboxes_initialized = false;
            DocAdmin.SetComboBoxConcertDocuments(m_combo_box_concert_documents);
            m_dialog_comboboxes_initialized = true;

        } // m_combo_box_concert_documents_SelectedIndexChanged


        #endregion // Selection and execution of a concert document

        #region Selection and execution of a web pages

        /// <summary>Open HTM dialog</summary>
        private void OpenHtmlDialog()
        {
            string error_message = @"";

            string htm_file_name = m_combo_box_htm_file.Text;

            DocExeDocument doc_exe_document = new DocExeDocument();
            JazzHtml htm_object = HtmFiles.GetHtml(htm_file_name, out error_message);
            if (null == htm_object)
            {
                error_message = @"DocAdminForm.OpenHtmlDialog " + error_message;
                MessageBox.Show(error_message);
                return;
            }
            doc_exe_document.SetHtml(htm_object);

            string title_dialog = htm_object.FileName;
            doc_exe_document.SetTitleDocument(DocAdminString.GetTitleFormDocument(title_dialog));
            doc_exe_document.SetLabelPageHeader(title_dialog);

            string file_type = htm_object.FileType;
            if (file_type.Equals("web") || file_type.Equals("template"))
            {
                doc_exe_document.SetFileType(file_type);
            }
            else
            {
                error_message = @"DocAdminForm.OpenHtmlDialog Programming error. File type is not web or template but " + file_type;
                MessageBox.Show(error_message);
                return;
            }

            JazzDoc dummy_doc = new JazzDoc();
            JazzDocTemplate dummy_template = new JazzDocTemplate();
            doc_exe_document.SetDocumentData(dummy_doc);
            doc_exe_document.SetDocumentTemplate(dummy_template);

            DocHtmForm htm_form = new DocHtmForm(this, doc_exe_document);
            htm_form.Owner = this;
            htm_form.ShowDialog();

        } // OpenHtmlDialog


        /// <summary>User selected web file to be uploaded or downloaded</summary>
        private void m_combo_box_htm_file_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_dialog_comboboxes_initialized)
                return;

            if (DocAdminString.PromptHtmlFile.Equals(m_combo_box_htm_file.Text))
            {
                return;
            }

            OpenHtmlDialog();

            m_dialog_comboboxes_initialized = false;
            DocAdmin.SetComboBoxHtmFiles(m_combo_box_htm_file);
            m_dialog_comboboxes_initialized = true;

        } // m_combo_box_htm_file_SelectedIndexChanged

        #endregion // Selection and execution of a web pages

        #region Selection and execution of a help file

        /// <summary>Open help dialog</summary>
        private void OpenHelpDialog()
        {
            string error_message = @"";

            string help_file_name = m_combo_box_help_file.Text;

            DocExeDocument doc_exe_document = new DocExeDocument();
            JazzHelp help_object = HelpFiles.GetHelp(help_file_name, out error_message);
            if (null == help_object)
            {
                error_message = @"DocAdminForm.OpenHelpDialog " + error_message;
                MessageBox.Show(error_message);
                return;
            }
            doc_exe_document.SetHelp(help_object);

            string title_dialog = help_object.FileName;
            doc_exe_document.SetTitleDocument(DocAdminString.GetTitleFormDocument(title_dialog));
            doc_exe_document.SetLabelPageHeader(title_dialog);

            string file_type = help_object.FileType;
            if (file_type.Equals("help"))
            {
                doc_exe_document.SetFileType(file_type);
            }
            else
            {
                error_message = @"DocAdminForm.OpenHelpDialog Programming error. File type is not help but " + file_type;
                MessageBox.Show(error_message);
                return;
            }

            JazzDoc dummy_doc = new JazzDoc();
            JazzDocTemplate dummy_template = new JazzDocTemplate();
            doc_exe_document.SetDocumentData(dummy_doc);
            doc_exe_document.SetDocumentTemplate(dummy_template);

            DocHelpForm help_form = new DocHelpForm(this, doc_exe_document);
            help_form.Owner = this;
            help_form.ShowDialog();

        } // OpenHelpDialog


        /// <summary>User selected help file to be uploaded or downloaded</summary>
        private void m_combo_box_help_file_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_dialog_comboboxes_initialized)
                return;

            if (DocAdminString.PromptHelpFile.Equals(m_combo_box_help_file.Text))
            {
                return;
            }

            OpenHelpDialog();

            m_dialog_comboboxes_initialized = false;
            DocAdmin.SetComboBoxHelpFiles(m_combo_box_help_file);
            m_dialog_comboboxes_initialized = true;

        }

        #endregion Selection and execution of a help file

    } // DocAdminForm
} // namespace
