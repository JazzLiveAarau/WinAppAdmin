namespace JazzAppAdmin
{
    partial class MusicianForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicianForm));
            this.m_label_page_header = new System.Windows.Forms.Label();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_button_edit_musician_data = new System.Windows.Forms.Button();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_text_box_birth_year = new System.Windows.Forms.TextBox();
            this.m_label_birth_year = new System.Windows.Forms.Label();
            this.m_rich_text_box_musician = new System.Windows.Forms.RichTextBox();
            this.m_text_box_instrument = new System.Windows.Forms.TextBox();
            this.m_label_instrument = new System.Windows.Forms.Label();
            this.m_text_box_musician_name = new System.Windows.Forms.TextBox();
            this.m_label_name = new System.Windows.Forms.Label();
            this.m_radio_button_male = new System.Windows.Forms.RadioButton();
            this.m_radio_button_female = new System.Windows.Forms.RadioButton();
            this.m_label_female = new System.Windows.Forms.Label();
            this.m_label_male = new System.Windows.Forms.Label();
            this.m_button_delete_musician = new System.Windows.Forms.Button();
            this.ToolTipMusician = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipMusicianEdit = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipMusicianDelete = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipMusicianCancel = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipMusicianClose = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // m_label_page_header
            // 
            this.m_label_page_header.AutoSize = true;
            this.m_label_page_header.BackColor = System.Drawing.Color.Black;
            this.m_label_page_header.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_page_header.ForeColor = System.Drawing.Color.Red;
            this.m_label_page_header.Location = new System.Drawing.Point(12, 67);
            this.m_label_page_header.Name = "m_label_page_header";
            this.m_label_page_header.Size = new System.Drawing.Size(85, 22);
            this.m_label_page_header.TabIndex = 4;
            this.m_label_page_header.Text = "Musiker";
            // 
            // m_button_cancel
            // 
            this.m_button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_cancel.BackColor = System.Drawing.Color.Black;
            this.m_button_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_button_cancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_cancel.FlatAppearance.BorderSize = 0;
            this.m_button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_cancel.ForeColor = System.Drawing.Color.Red;
            this.m_button_cancel.Location = new System.Drawing.Point(111, 15);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(122, 39);
            this.m_button_cancel.TabIndex = 2;
            this.m_button_cancel.Text = "Cancel";
            this.m_button_cancel.UseVisualStyleBackColor = false;
            this.m_button_cancel.Click += new System.EventHandler(this.m_button_cancel_Click);
            // 
            // m_button_edit_musician_data
            // 
            this.m_button_edit_musician_data.BackColor = System.Drawing.Color.Black;
            this.m_button_edit_musician_data.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_edit_musician_data.BackgroundImage")));
            this.m_button_edit_musician_data.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_edit_musician_data.FlatAppearance.BorderSize = 0;
            this.m_button_edit_musician_data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_edit_musician_data.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_edit_musician_data.ForeColor = System.Drawing.Color.Red;
            this.m_button_edit_musician_data.Location = new System.Drawing.Point(12, 9);
            this.m_button_edit_musician_data.Name = "m_button_edit_musician_data";
            this.m_button_edit_musician_data.Size = new System.Drawing.Size(36, 41);
            this.m_button_edit_musician_data.TabIndex = 0;
            this.m_button_edit_musician_data.UseVisualStyleBackColor = false;
            this.m_button_edit_musician_data.Click += new System.EventHandler(this.m_button_edit_musician_data_Click);
            // 
            // m_button_close
            // 
            this.m_button_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_close.BackColor = System.Drawing.Color.Black;
            this.m_button_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_button_close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_close.FlatAppearance.BorderSize = 0;
            this.m_button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_close.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_close.ForeColor = System.Drawing.Color.Red;
            this.m_button_close.Location = new System.Drawing.Point(239, 15);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(152, 39);
            this.m_button_close.TabIndex = 3;
            this.m_button_close.Text = "Save/Close";
            this.m_button_close.UseVisualStyleBackColor = false;
            this.m_button_close.Click += new System.EventHandler(this.m_button_close_Click);
            // 
            // m_text_box_birth_year
            // 
            this.m_text_box_birth_year.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_text_box_birth_year.Location = new System.Drawing.Point(283, 457);
            this.m_text_box_birth_year.Name = "m_text_box_birth_year";
            this.m_text_box_birth_year.Size = new System.Drawing.Size(105, 23);
            this.m_text_box_birth_year.TabIndex = 15;
            this.m_text_box_birth_year.Text = "1947";
            this.m_text_box_birth_year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_label_birth_year
            // 
            this.m_label_birth_year.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_label_birth_year.AutoSize = true;
            this.m_label_birth_year.BackColor = System.Drawing.Color.Black;
            this.m_label_birth_year.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_birth_year.ForeColor = System.Drawing.Color.Red;
            this.m_label_birth_year.Location = new System.Drawing.Point(285, 430);
            this.m_label_birth_year.Name = "m_label_birth_year";
            this.m_label_birth_year.Size = new System.Drawing.Size(83, 19);
            this.m_label_birth_year.TabIndex = 14;
            this.m_label_birth_year.Text = "Birth year";
            // 
            // m_rich_text_box_musician
            // 
            this.m_rich_text_box_musician.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rich_text_box_musician.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.m_rich_text_box_musician.Enabled = false;
            this.m_rich_text_box_musician.Location = new System.Drawing.Point(12, 271);
            this.m_rich_text_box_musician.Name = "m_rich_text_box_musician";
            this.m_rich_text_box_musician.Size = new System.Drawing.Size(383, 148);
            this.m_rich_text_box_musician.TabIndex = 9;
            this.m_rich_text_box_musician.Text = "Text about the musician ...";
            // 
            // m_text_box_instrument
            // 
            this.m_text_box_instrument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_instrument.Location = new System.Drawing.Point(12, 219);
            this.m_text_box_instrument.Name = "m_text_box_instrument";
            this.m_text_box_instrument.Size = new System.Drawing.Size(382, 23);
            this.m_text_box_instrument.TabIndex = 8;
            this.m_text_box_instrument.Text = "Musician\'s instruments";
            // 
            // m_label_instrument
            // 
            this.m_label_instrument.AutoSize = true;
            this.m_label_instrument.BackColor = System.Drawing.Color.Black;
            this.m_label_instrument.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_instrument.ForeColor = System.Drawing.Color.Red;
            this.m_label_instrument.Location = new System.Drawing.Point(12, 180);
            this.m_label_instrument.Name = "m_label_instrument";
            this.m_label_instrument.Size = new System.Drawing.Size(91, 19);
            this.m_label_instrument.TabIndex = 7;
            this.m_label_instrument.Text = "Instrument";
            // 
            // m_text_box_musician_name
            // 
            this.m_text_box_musician_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_musician_name.Location = new System.Drawing.Point(12, 138);
            this.m_text_box_musician_name.Name = "m_text_box_musician_name";
            this.m_text_box_musician_name.Size = new System.Drawing.Size(379, 23);
            this.m_text_box_musician_name.TabIndex = 6;
            this.m_text_box_musician_name.Text = "Name of the musician";
            // 
            // m_label_name
            // 
            this.m_label_name.AutoSize = true;
            this.m_label_name.BackColor = System.Drawing.Color.Black;
            this.m_label_name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_name.ForeColor = System.Drawing.Color.Red;
            this.m_label_name.Location = new System.Drawing.Point(12, 107);
            this.m_label_name.Name = "m_label_name";
            this.m_label_name.Size = new System.Drawing.Size(53, 19);
            this.m_label_name.TabIndex = 5;
            this.m_label_name.Text = "Name";
            // 
            // m_radio_button_male
            // 
            this.m_radio_button_male.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_radio_button_male.AutoSize = true;
            this.m_radio_button_male.Checked = true;
            this.m_radio_button_male.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_radio_button_male.ForeColor = System.Drawing.Color.Red;
            this.m_radio_button_male.Location = new System.Drawing.Point(135, 466);
            this.m_radio_button_male.Name = "m_radio_button_male";
            this.m_radio_button_male.Size = new System.Drawing.Size(14, 13);
            this.m_radio_button_male.TabIndex = 12;
            this.m_radio_button_male.TabStop = true;
            this.m_radio_button_male.UseVisualStyleBackColor = true;
            // 
            // m_radio_button_female
            // 
            this.m_radio_button_female.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_radio_button_female.AutoSize = true;
            this.m_radio_button_female.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_radio_button_female.ForeColor = System.Drawing.Color.Red;
            this.m_radio_button_female.Location = new System.Drawing.Point(16, 466);
            this.m_radio_button_female.Name = "m_radio_button_female";
            this.m_radio_button_female.Size = new System.Drawing.Size(14, 13);
            this.m_radio_button_female.TabIndex = 10;
            this.m_radio_button_female.UseVisualStyleBackColor = true;
            // 
            // m_label_female
            // 
            this.m_label_female.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_label_female.AutoSize = true;
            this.m_label_female.BackColor = System.Drawing.Color.Black;
            this.m_label_female.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_female.ForeColor = System.Drawing.Color.Red;
            this.m_label_female.Location = new System.Drawing.Point(38, 460);
            this.m_label_female.Name = "m_label_female";
            this.m_label_female.Size = new System.Drawing.Size(59, 16);
            this.m_label_female.TabIndex = 11;
            this.m_label_female.Text = "Female";
            // 
            // m_label_male
            // 
            this.m_label_male.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_label_male.AutoSize = true;
            this.m_label_male.BackColor = System.Drawing.Color.Black;
            this.m_label_male.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_male.ForeColor = System.Drawing.Color.Red;
            this.m_label_male.Location = new System.Drawing.Point(156, 461);
            this.m_label_male.Name = "m_label_male";
            this.m_label_male.Size = new System.Drawing.Size(42, 16);
            this.m_label_male.TabIndex = 13;
            this.m_label_male.Text = "Male";
            // 
            // m_button_delete_musician
            // 
            this.m_button_delete_musician.BackColor = System.Drawing.Color.Black;
            this.m_button_delete_musician.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_delete_musician.BackgroundImage")));
            this.m_button_delete_musician.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_delete_musician.FlatAppearance.BorderSize = 0;
            this.m_button_delete_musician.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_delete_musician.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_delete_musician.ForeColor = System.Drawing.Color.Red;
            this.m_button_delete_musician.Image = ((System.Drawing.Image)(resources.GetObject("m_button_delete_musician.Image")));
            this.m_button_delete_musician.Location = new System.Drawing.Point(65, 12);
            this.m_button_delete_musician.Name = "m_button_delete_musician";
            this.m_button_delete_musician.Size = new System.Drawing.Size(36, 41);
            this.m_button_delete_musician.TabIndex = 1;
            this.m_button_delete_musician.UseVisualStyleBackColor = false;
            this.m_button_delete_musician.Click += new System.EventHandler(this.m_button_delete_musician_Click);
            // 
            // MusicianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(406, 496);
            this.ControlBox = false;
            this.Controls.Add(this.m_button_delete_musician);
            this.Controls.Add(this.m_label_male);
            this.Controls.Add(this.m_label_female);
            this.Controls.Add(this.m_radio_button_male);
            this.Controls.Add(this.m_radio_button_female);
            this.Controls.Add(this.m_label_page_header);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_button_edit_musician_data);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_text_box_birth_year);
            this.Controls.Add(this.m_label_birth_year);
            this.Controls.Add(this.m_rich_text_box_musician);
            this.Controls.Add(this.m_text_box_instrument);
            this.Controls.Add(this.m_label_instrument);
            this.Controls.Add(this.m_text_box_musician_name);
            this.Controls.Add(this.m_label_name);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MusicianForm";
            this.Text = "Musician  Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_label_page_header;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Button m_button_edit_musician_data;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.TextBox m_text_box_birth_year;
        private System.Windows.Forms.Label m_label_birth_year;
        private System.Windows.Forms.RichTextBox m_rich_text_box_musician;
        private System.Windows.Forms.TextBox m_text_box_instrument;
        private System.Windows.Forms.Label m_label_instrument;
        private System.Windows.Forms.TextBox m_text_box_musician_name;
        private System.Windows.Forms.Label m_label_name;
        private System.Windows.Forms.RadioButton m_radio_button_male;
        private System.Windows.Forms.RadioButton m_radio_button_female;
        private System.Windows.Forms.Label m_label_female;
        private System.Windows.Forms.Label m_label_male;
        private System.Windows.Forms.Button m_button_delete_musician;
        private System.Windows.Forms.ToolTip ToolTipMusician;
        private System.Windows.Forms.ToolTip ToolTipMusicianEdit;
        private System.Windows.Forms.ToolTip ToolTipMusicianDelete;
        private System.Windows.Forms.ToolTip ToolTipMusicianCancel;
        private System.Windows.Forms.ToolTip ToolTipMusicianClose;
    }
}