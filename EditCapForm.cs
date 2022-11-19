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
    public partial class EditCapForm : Form
    {
        public EditCapForm()
        {
            InitializeComponent();
        }

        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_button_save_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
