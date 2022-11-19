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
    public partial class JazzMusicianForm : Form
    {
        bool m_editable = false;

        public JazzMusicianForm()
        {
            InitializeComponent();

            SetEditable();
        }

        private void SetEditable()
        {
            if (m_editable)
            {
                m_text_box_musician_name.Enabled = true;
                m_text_box_instrument.Enabled = true;
                m_rich_text_box_musician.Enabled = true;
                m_text_box_birth_year.Enabled = true;
                m_radio_button_female.Enabled = true;
                m_radio_button_male.Enabled = true;
            }
            else
            {
                m_text_box_musician_name.Enabled = false;
                m_text_box_instrument.Enabled = false;
                m_rich_text_box_musician.Enabled = false;
                m_text_box_birth_year.Enabled = false;
                m_radio_button_female.Enabled = false;
                m_radio_button_male.Enabled = false;
            }
        }

        private void m_button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_button_edit_page_header_Click(object sender, EventArgs e)
        {
            EditCapForm edit_cap_form = new EditCapForm();
            edit_cap_form.Owner = this;
            edit_cap_form.ShowDialog();
        }

        private void m_button_edit_musician_data_Click(object sender, EventArgs e)
        {
            m_editable = true;

            SetEditable();
        }
    }
}
