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
    public partial class JazzConcertForm : Form
    {
        public JazzConcertForm()
        {
            InitializeComponent();
        }

        private void m_button_musiker_1_Click(object sender, EventArgs e)
        {
            JazzMusicianForm musician_form = new JazzMusicianForm();
            musician_form.Owner = this;
            musician_form.ShowDialog();
        }
        private void m_button_musiker_2_Click(object sender, EventArgs e)
        {
            JazzMusicianForm musician_form = new JazzMusicianForm();
            musician_form.Owner = this;
            musician_form.ShowDialog();
        }

        private void m_button_musiker_3_Click(object sender, EventArgs e)
        {
            JazzMusicianForm musician_form = new JazzMusicianForm();
            musician_form.Owner = this;
            musician_form.ShowDialog();
        }

        private void m_button_musiker_4_Click(object sender, EventArgs e)
        {
            JazzMusicianForm musician_form = new JazzMusicianForm();
            musician_form.Owner = this;
            musician_form.ShowDialog();
        }

        private void m_button_musiker_5_Click(object sender, EventArgs e)
        {
            JazzMusicianForm musician_form = new JazzMusicianForm();
            musician_form.Owner = this;
            musician_form.ShowDialog();
        }

        private void m_button_musiker_6_Click(object sender, EventArgs e)
        {
            JazzMusicianForm musician_form = new JazzMusicianForm();
            musician_form.Owner = this;
            musician_form.ShowDialog();
        }

        private void m_button_musiker_7_Click(object sender, EventArgs e)
        {
            JazzMusicianForm musician_form = new JazzMusicianForm();
            musician_form.Owner = this;
            musician_form.ShowDialog();
        }

        private void m_button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
