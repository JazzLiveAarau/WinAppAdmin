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
    /// <summary>Set the directory names for a new concert documents XML file (JazzDokumente_20xx_20yy.xml)
    /// <para>The directory must always start with dyyyymmdd_. The band name may (should) be shortened but one should understand which band it is.</para>
    /// <para></para>
    /// <para></para>
    /// </summary>
    public partial class DocDirNamesForm : Form
    {
        #region Member variables

        /// <summary>Holds input and output data and a link to the object (class) with execution functions</summary>
        private DocDirNames m_doc_dir_names = null;

        private int m_date_chars = 10;

        private string m_proposal_date_01 = @"";
        private string m_proposal_date_02 = @"";
        private string m_proposal_date_03 = @"";
        private string m_proposal_date_04 = @"";
        private string m_proposal_date_05 = @"";
        private string m_proposal_date_06 = @"";
        private string m_proposal_date_07 = @"";
        private string m_proposal_date_08 = @"";
        private string m_proposal_date_09 = @"";
        private string m_proposal_date_10 = @"";
        private string m_proposal_date_11 = @"";
        private string m_proposal_date_12 = @"";

        #endregion // Member variables

        /// <summary>Constructor</summary>
        public DocDirNamesForm(ref DocDirNames io_doc_dir_names)
        {
            InitializeComponent();

            if (null == io_doc_dir_names)
                return;

            m_doc_dir_names = io_doc_dir_names;

            SetTexts(m_doc_dir_names.ProposalDirNames);

            _SetCaptions();

            _SetToolTips();

        } // Constructor

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, true);
            }
            else
            {
                // Programming error
            }

        } // SetCaptions

        /// <summary>Set texts</summary>
        private void SetTexts(string[] i_dir_names)
        {
            if (null == i_dir_names)
                return;

            string proposal_01 = i_dir_names[0];
            m_proposal_date_01 = proposal_01.Substring(0, m_date_chars);
            string proposal_dir_01 = proposal_01.Substring(m_date_chars);
            m_text_box_dir_date_01.Text = m_proposal_date_01;
            m_text_box_dir_01.Text = proposal_dir_01;

            string proposal_02 = i_dir_names[1];
            m_proposal_date_02 = proposal_02.Substring(0, m_date_chars);
            string proposal_dir_02 = proposal_02.Substring(m_date_chars);
            m_text_box_dir_date_02.Text = m_proposal_date_02;
            m_text_box_dir_02.Text = proposal_dir_02;

            string proposal_03 = i_dir_names[2];
            m_proposal_date_03 = proposal_03.Substring(0, m_date_chars);
            string proposal_dir_03 = proposal_03.Substring(m_date_chars);
            m_text_box_dir_date_03.Text = m_proposal_date_03;
            m_text_box_dir_03.Text = proposal_dir_03;

            string proposal_04 = i_dir_names[3];
            m_proposal_date_04 = proposal_04.Substring(0, m_date_chars);
            string proposal_dir_04 = proposal_04.Substring(m_date_chars);
            m_text_box_dir_date_04.Text = m_proposal_date_04;
            m_text_box_dir_04.Text = proposal_dir_04;

            string proposal_05 = i_dir_names[4];
            m_proposal_date_05 = proposal_05.Substring(0, m_date_chars);
            string proposal_dir_05 = proposal_05.Substring(m_date_chars);
            m_text_box_dir_date_05.Text = m_proposal_date_05;
            m_text_box_dir_05.Text = proposal_dir_05;

            string proposal_06 = i_dir_names[5];
            m_proposal_date_06 = proposal_06.Substring(0, m_date_chars);
            string proposal_dir_06 = proposal_06.Substring(m_date_chars);
            m_text_box_dir_date_06.Text = m_proposal_date_06;
            m_text_box_dir_06.Text = proposal_dir_06;

            string proposal_07 = i_dir_names[6];
            m_proposal_date_07 = proposal_07.Substring(0, m_date_chars);
            string proposal_dir_07 = proposal_07.Substring(m_date_chars);
            m_text_box_dir_date_07.Text = m_proposal_date_07;
            m_text_box_dir_07.Text = proposal_dir_07;

            string proposal_08 = i_dir_names[7];
            m_proposal_date_08 = proposal_08.Substring(0, m_date_chars);
            string proposal_dir_08 = proposal_08.Substring(m_date_chars);
            m_text_box_dir_date_08.Text = m_proposal_date_08;
            m_text_box_dir_08.Text = proposal_dir_08;

            string proposal_09 = i_dir_names[8];
            m_proposal_date_09 = proposal_09.Substring(0, m_date_chars);
            string proposal_dir_09 = proposal_09.Substring(m_date_chars);
            m_text_box_dir_date_09.Text = m_proposal_date_09;
            m_text_box_dir_09.Text = proposal_dir_09;

            string proposal_10 = i_dir_names[9];
            m_proposal_date_10 = proposal_10.Substring(0, m_date_chars);
            string proposal_dir_10 = proposal_10.Substring(m_date_chars);
            m_text_box_dir_date_10.Text = m_proposal_date_10;
            m_text_box_dir_10.Text = proposal_dir_10;

            string proposal_11 = i_dir_names[10];
            m_proposal_date_11 = proposal_11.Substring(0, m_date_chars);
            string proposal_dir_11 = proposal_11.Substring(m_date_chars);
            m_text_box_dir_date_11.Text = m_proposal_date_11;
            m_text_box_dir_11.Text = proposal_dir_11;

            string proposal_12 = i_dir_names[11];
            m_proposal_date_12 = proposal_12.Substring(0, m_date_chars);
            string proposal_dir_12 = proposal_12.Substring(m_date_chars);
            m_text_box_dir_date_12.Text = m_proposal_date_12;
            m_text_box_dir_12.Text = proposal_dir_12;


            m_textbox_message.Text = @"";

        } // SetTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipDocForm.SetToolTip(this, DocAdminString.ToolTipDocDirNamesForm);
            ToolTipUtil.SetDelays(ref ToolTipDocForm);

            ToolTipDocFormCancel.SetToolTip(m_button_cancel, DocAdminString.ToolTipDocFormCancel);
            ToolTipDocFormClose.SetToolTip(m_button_close, DocAdminString.ToolTipDocFormClose);
            ToolTipUtil.SetDelays(ref ToolTipDocFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipDocFormClose);

            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_01, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_02, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_03, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_04, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_05, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_06, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_07, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_08, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_09, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_10, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_11, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipDirNamesDateConcert.SetToolTip(m_text_box_dir_date_12, DocAdminString.ToolTipDirNamesDateConcert);
            ToolTipUtil.SetDelays(ref ToolTipDirNamesDateConcert);

            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_01, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_02, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_03, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_04, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_05, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_06, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_07, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_08, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_09, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_10, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_11, DocAdminString.ToolTipDirNamesConcert);
            ToolTipDirNamesConcert.SetToolTip(m_text_box_dir_12, DocAdminString.ToolTipDirNamesConcert);
            ToolTipUtil.SetDelays(ref ToolTipDirNamesConcert);

            ToolTipDocFormMsg.SetToolTip(m_textbox_message, DocAdminString.ToolTipDocFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipDocFormMsg);

        } // SetToolTips

        /// <summary>User cancelled</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            m_doc_dir_names.UserCancelled = true;;

            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked close </summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            m_doc_dir_names.UserCancelled = false;

            m_doc_dir_names.UserDirNames[0] = m_proposal_date_01 + m_text_box_dir_01.Text;
            m_doc_dir_names.UserDirNames[1] = m_proposal_date_02 + m_text_box_dir_02.Text;
            m_doc_dir_names.UserDirNames[2] = m_proposal_date_03 + m_text_box_dir_03.Text;
            m_doc_dir_names.UserDirNames[3] = m_proposal_date_04 + m_text_box_dir_04.Text;
            m_doc_dir_names.UserDirNames[4] = m_proposal_date_05 + m_text_box_dir_05.Text;
            m_doc_dir_names.UserDirNames[5] = m_proposal_date_06 + m_text_box_dir_06.Text;
            m_doc_dir_names.UserDirNames[6] = m_proposal_date_07 + m_text_box_dir_07.Text;
            m_doc_dir_names.UserDirNames[7] = m_proposal_date_08 + m_text_box_dir_08.Text;
            m_doc_dir_names.UserDirNames[8] = m_proposal_date_09 + m_text_box_dir_09.Text;
            m_doc_dir_names.UserDirNames[9] = m_proposal_date_10 + m_text_box_dir_10.Text;
            m_doc_dir_names.UserDirNames[10] = m_proposal_date_11 + m_text_box_dir_11.Text;
            m_doc_dir_names.UserDirNames[11] = m_proposal_date_12 + m_text_box_dir_12.Text;

            bool name_was_changed = false;
            string[] dir_names = m_doc_dir_names.UserDirNames;
            m_doc_dir_names.ModifyNamesForBandDirectories(ref dir_names, out name_was_changed);

            if (name_was_changed)
            {
                SetTexts(dir_names);

                string warning_message = DocAdminString.ErrMsgNotAllowedCharsInDirectoryName;
                MessageBox.Show(warning_message);

                return;
            }

            this.Close();

        } // m_button_close_Click

    } // DocDirNamesForm

} // namespace
