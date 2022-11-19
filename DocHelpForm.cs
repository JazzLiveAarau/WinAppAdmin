using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Download and upload of a help files
    /// <para>This dialog is for any help page</para>
    /// <para></para>
    /// <para></para>
    /// <para>How to add this kind of document class is described in JAZZ_live_AARAU_Admin_Doc.rtf</para>
    /// </summary>
    public partial class DocHelpForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private DocAdminForm m_doc_admin_form = null;

        /// <summary>Data about the document and execution functions</summary>
        private DocExeDocument m_doc_exe_document = null;

        /// <summary>Data about a help file</summary>
        private JazzHelp m_help = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor
        /// <para>1. Sets the controls of the dialog</para>
        /// <para>2. Makes the controls editable if the XML file is checked out</para>
        /// <para>3. Sets the tool tips</para>
        /// <para>4. Sets the captions</para>
        /// </summary>
        /// <param name="i_doc_admin_form">The owner of this form</param>
        /// <param name="i_doc_exe_document">Object with data about the document and with execution functions</param>
        public DocHelpForm(DocAdminForm i_doc_admin_form, DocExeDocument i_doc_exe_document)
        {
            InitializeComponent();

            if (null == i_doc_admin_form)
                return;

            m_doc_admin_form = i_doc_admin_form;

            if (null == i_doc_exe_document)
                return;

            m_doc_exe_document = i_doc_exe_document;

            m_help = m_doc_exe_document.GetHelp();
            if (null == m_help)
                return;

            _SetTexts();

            _SetToolTips();

            // m_editable must be set before _SetCaptions() is called
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetCaptions();

        } // Constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = m_doc_exe_document.GetTitleDocument();
            this.m_label_page_header.Text = m_help.FileName;

            m_text_box_file_name_rtf.Text = m_help.FileName;

            m_text_box_rtf.Text = @"RTF";

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipDocForm.SetToolTip(this, DocAdminString.ToolTipDocForm);

            ToolTipDocFormEdit.SetToolTip(m_button_edit_concert_data, DocAdminString.ToolTipDocFormEdit);
            ToolTipDocFormCancel.SetToolTip(m_button_cancel, DocAdminString.ToolTipDocFormCancel);
            ToolTipDocFormClose.SetToolTip(m_button_close, DocAdminString.ToolTipDocFormClose);

            ToolTipDownLoadRtf.SetToolTip(m_button_download_rtf, DocAdminString.ToolTipDownLoadRtf);

            ToolTipUpLoadRtf.SetToolTip(m_button_upload_rtf, DocAdminString.ToolTipUpLoadRtf);

            ToolTipFilenameRtf.SetToolTip(m_text_box_file_name_rtf, DocAdminString.ToolTipFilenameRtf);

            ToolTipDocFormMsg.SetToolTip(m_textbox_message, DocAdminString.ToolTipDocFormMsg);

        } // SetToolTips

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        #endregion // Set controls

        #region Write data

        /// <summary>Write all texts for the current JazzHelp object is not applicable. Data is hardcoded in HelpFiles and cannot be changed. This function does nothing!</summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            // Function only kept to show the difference to the document dialogs where data shall be written to XML

            return true;
        } // _WriteTexts

        #endregion // Write data

        #region Event handling functions 

        /// <summary>User clicked the edit (checkout) button</summary>
        private void m_button_edit_concert_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                bool b_user_cancelled = false;
                m_doc_admin_form.CheckoutData(out b_user_cancelled);
                if (b_user_cancelled)
                {
                    return;
                }

                m_editable = true;
            }

            _SetCaptions();

        } // m_button_edit_concert_data_Click

        /// <summary>User clicked button cancel</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked button close</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (m_editable)
            {
                string error_message = @"";
                if (!_WriteTexts(out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }
            }

            this.Close();

        } // m_button_close_Click

        /// <summary>User clicked button download rtf</summary>
        private void m_button_download_rtf_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDownloadClick(m_help.ExtensionCase, m_help.ExtensionCase, m_textbox_message))
                return;

        } // m_button_download_rtf_Click

        /// <summary>User clicked button upload rtf</summary>
        private void m_button_upload_rtf_Click(object sender, EventArgs e)
        {
            bool admin_file = true;
            if (!m_doc_exe_document.ExeUploadClick(m_help.ExtensionCase, m_help.ExtensionCase, admin_file, m_editable, m_text_box_file_name_rtf, m_textbox_message))
                return;

        } // m_button_upload_rtf_Click

        #endregion // Event handling functions 

    } // DocHelpForm
} // namespace
