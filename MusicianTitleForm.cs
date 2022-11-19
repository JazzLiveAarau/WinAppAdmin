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
    /// <summary>Edit musician page titles</summary>
    public partial class MusicianTitleForm : Form
    {
        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Constructor</summary>
        public MusicianTitleForm()
        {
            InitializeComponent();

            SetTitles();

            SetEditable();

            SetTexts();

            SetCaptions();

        } // Constructor

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormTitle(Musician.GetTitlePage());
            this.m_label_page_header.Text = Musician.GetTitlePage();
            this.m_label_page_header_tag.Text = Musician.GetPageTitleTag();

        } // SetTitles

        /// <summary>Set controls editable or not</summary>
        private void SetEditable()
        {
            if (m_editable)
            {
                m_text_box_page_title.Enabled = true;
            }
            else
            {
                m_text_box_page_title.Enabled = false;
            }

        } // SetEditable

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_page_title.Text = Musician.GetTitlePage();

        } // SetTexts

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Write texts</summary>
        private void WriteTexts()
        {
            Musician.WritePageTitle(this.m_text_box_page_title.Text);

        } // WriteTexts

        /// <summary>User clicked the cancel button</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked the save/close button</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (m_editable)
            {
                WriteTexts();
            }

            this.Close();

        } // m_button_close_Click

        /// <summary>User clicked the edit button</summary>
        private void m_button_edit_musician_data_Click(object sender, EventArgs e)
        {
            // TODO Checkout data

            m_editable = true;

            SetEditable();

            SetCaptions();

        } // m_button_edit_musician_data_Click

    } // MusicianTitleForm
} // namespace
