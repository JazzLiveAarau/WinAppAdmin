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
    public partial class JazzAdminAppForm : Form
    {
        public JazzAdminAppForm()
        {
            InitializeComponent();
        }

        private void m_button_download_Click(object sender, EventArgs e)
        {

        }

        private void m_button_select_season_Click(object sender, EventArgs e)
        {
            SelectSeasonForm select_saison_form = new SelectSeasonForm();
            select_saison_form.Owner = this;
            select_saison_form.ShowDialog();
        }

        /*QQQQQQ
        private void m_button_season_program_Click(object sender, EventArgs e)
        {
            JazzSaisonConcertsForm saison_concerts_form = new JazzSaisonConcertsForm();
            saison_concerts_form.Owner = this;
            saison_concerts_form.ShowDialog();
        }
        QQQ*/

        private void m_button_premises_Click(object sender, EventArgs e)
        {

        }

        private void m_button_contact_Click(object sender, EventArgs e)
        {
 
        }

        private void m_button_about_Click(object sender, EventArgs e)
        {

        }

        private void m_button_musician_info_Click(object sender, EventArgs e)
        {

        }

        private void m_button_members_only_Click(object sender, EventArgs e)
        {

        }

        private void m_button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_button_edit_program_Click(object sender, EventArgs e)
        {
            EditCapForm edit_cap_form = new EditCapForm();
            edit_cap_form.Owner = this;
            edit_cap_form.ShowDialog();
        }

        private void m_button_edit_premises_Click(object sender, EventArgs e)
        {
            EditCapForm edit_cap_form = new EditCapForm();
            edit_cap_form.Owner = this;
            edit_cap_form.ShowDialog();
        }

        private void m_button_edit_contact_Click(object sender, EventArgs e)
        {
            EditCapForm edit_cap_form = new EditCapForm();
            edit_cap_form.Owner = this;
            edit_cap_form.ShowDialog();
        }

        private void m_button_edit_about_Click(object sender, EventArgs e)
        {
            EditCapForm edit_cap_form = new EditCapForm();
            edit_cap_form.Owner = this;
            edit_cap_form.ShowDialog();
        }

        private void m_button_edit_musician_Click(object sender, EventArgs e)
        {
            EditCapForm edit_cap_form = new EditCapForm();
            edit_cap_form.Owner = this;
            edit_cap_form.ShowDialog();
        }

        private void m_button_edit_member_Click(object sender, EventArgs e)
        {
            EditCapForm edit_cap_form = new EditCapForm();
            edit_cap_form.Owner = this;
            edit_cap_form.ShowDialog();
        }
    }
}
