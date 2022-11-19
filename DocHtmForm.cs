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
    /// <summary>Download and upload of a htm pages
    /// <para>This dialog is for any htm page</para>
    /// <para></para>
    /// <para></para>
    /// <para>How to add this kind of document class is described in JAZZ_live_AARAU_Admin_Doc.rtf</para>
    /// </summary>
    public partial class DocHtmForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        private DocAdminForm m_doc_admin_form = null;

        /// <summary>Data about the document and execution functions</summary>
        private DocExeDocument m_doc_exe_document = null;

        /// <summary>Data about html file</summary>
        private JazzHtml m_html = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        #endregion // Member variables

        /// <summary>Constructor
        /// <para>1. Sets the controls of the dialog</para>
        /// <para>2. Makes the controls editable if the XML file is checked out</para>
        /// <para>3. Sets the tool tips</para>
        /// <para>4. Sets the captions</para>
        /// </summary>
        /// <param name="i_doc_admin_form">The owner of this form</param>
        /// <param name="i_doc_exe_document">Object with data about the document and with execution functions</param>
        public DocHtmForm(DocAdminForm i_doc_admin_form, DocExeDocument i_doc_exe_document)
        {
            InitializeComponent();

            if (null == i_doc_admin_form)
                return;

            m_doc_admin_form = i_doc_admin_form;

            if (null == i_doc_exe_document)
                return;

            m_doc_exe_document = i_doc_exe_document;

            m_html = m_doc_exe_document.GetHtml();
            if (null == m_html)
                return;

            _SetTexts();

            _SetToolTips();

            // m_editable must be set before _SetCaptions() is called
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetCaptions();

        } // Constructor

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = m_doc_exe_document.GetTitleDocument();
            this.m_label_page_header.Text = m_html.FileName;

            m_text_box_file_name_htm.Text = m_html.FileName;

            m_text_box_htm.Text = @"HTM";

            string file_extension = Path.GetExtension(m_html.FileName);

            if (file_extension.Equals(".js"))
                m_text_box_htm.Text = @" JS";

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipDocForm.SetToolTip(this, DocAdminString.ToolTipDocForm);
            ToolTipUtil.SetDelays(ref ToolTipDocForm);

            ToolTipDocFormEdit.SetToolTip(m_button_edit_concert_data, DocAdminString.ToolTipDocFormEdit);
            ToolTipUtil.SetDelays(ref ToolTipDocFormEdit);
            ToolTipDocFormCancel.SetToolTip(m_button_cancel, DocAdminString.ToolTipDocFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipDocFormCancel);
            ToolTipDocFormClose.SetToolTip(m_button_close, DocAdminString.ToolTipDocFormClose);
            ToolTipUtil.SetDelays(ref ToolTipDocFormClose);

            ToolTipDownLoadHtm.SetToolTip(m_button_download_htm, DocAdminString.ToolTipDownLoadHtm);
            ToolTipUtil.SetDelays(ref ToolTipDownLoadHtm);

            ToolTipUpLoadHtm.SetToolTip(m_button_upload_htm, DocAdminString.ToolTipUpLoadHtm);
            ToolTipUtil.SetDelays(ref ToolTipUpLoadHtm);

            ToolTipFilenameHtm.SetToolTip(m_text_box_file_name_htm, DocAdminString.ToolTipFilenameHtm);
            ToolTipUtil.SetDelays(ref ToolTipFilenameHtm);

            ToolTipDocFormMsg.SetToolTip(m_textbox_message, DocAdminString.ToolTipDocFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipDocFormMsg);

        } // SetToolTips

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Write all texts for the current JazzHtml object is not applicable. Data is hardcoded in HtmFiles and cannot be changed. This function does nothing!</summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            // Function only kept to show the difference to the document dialogs where data shall be written to XML

            return true;
        } // _WriteTexts

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

        /// <summary>User clicked button download htm</summary>
        private void m_button_download_htm_Click(object sender, EventArgs e)
        {
            if (!m_doc_exe_document.ExeDownloadClick(m_html.ExtensionCase, m_html.ExtensionCase, m_textbox_message)) 
                return;

        } // m_button_download_htm_Click

        /// <summary>User clicked button upload htm</summary>
        private void m_button_upload_htm_Click(object sender, EventArgs e)
        {
            bool admin_file = false; // TODO But not always
            if (!m_doc_exe_document.ExeUploadClick(m_html.ExtensionCase, m_html.ExtensionCase, admin_file, m_editable, m_text_box_file_name_htm, m_textbox_message))
                return;

        } // m_button_upload_htm_Click

        #endregion Event handling functions 

    } // DocHtmForm
} // namespace
