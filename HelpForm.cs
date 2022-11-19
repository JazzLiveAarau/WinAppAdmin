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
    /// <summary>Form for the display of the help file</summary>
    public partial class HelpForm : Form
    {
        /// <summary>Constructor that gets the help file from the help directory</summary>
        public HelpForm(string i_help_file_name)
        {
            InitializeComponent();

            this.Text = JazzAppAdminSettings.Default.GuiHelpTitle;

            this.m_button_close.Text = JazzAppAdminSettings.Default.Caption_Close;

            string local_address_directory = FileUtil.SubDirectory(HelpFiles.LocalDirHelpFiles, Main.m_exe_directory);

            string file_name = local_address_directory + @"\" + i_help_file_name;

            this.m_rich_text_box_help.LoadFile(file_name, RichTextBoxStreamType.RichText);

        } // Constructor

        /// <summary>User clicked the close button</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            this.Close();

        } // m_button_close_Click

    } // HelpForm

} // namespace
