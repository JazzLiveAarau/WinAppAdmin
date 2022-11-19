namespace JazzAppAdmin
{
    partial class DocAdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocAdminForm));
            this.m_picture_box_text_logo = new System.Windows.Forms.PictureBox();
            this.m_label_documents = new System.Windows.Forms.Label();
            this.m_button_checkin_checkout = new System.Windows.Forms.Button();
            this.m_combo_box_season = new System.Windows.Forms.ComboBox();
            this.m_combo_box_concert = new System.Windows.Forms.ComboBox();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_textbox_message = new System.Windows.Forms.TextBox();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_exit = new System.Windows.Forms.Button();
            this.m_combo_box_season_documents = new System.Windows.Forms.ComboBox();
            this.m_label_season_documents = new System.Windows.Forms.Label();
            this.m_label_concert_documents = new System.Windows.Forms.Label();
            this.m_combo_box_concert_documents = new System.Windows.Forms.ComboBox();
            this.ToolTipDocumentsForm = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipCheckOut = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipSelectConcert = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipSelectConcertDocument = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipSelectSeasonDocument = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipDocumentsFormExit = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipDocumentsFormClose = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipDocumentsFormCancel = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipDocumentsFormMessage = new System.Windows.Forms.ToolTip(this.components);
            this.m_group_box_season = new System.Windows.Forms.GroupBox();
            this.m_group_box_concert = new System.Windows.Forms.GroupBox();
            this.m_label_htm_files = new System.Windows.Forms.Label();
            this.m_combo_box_htm_file = new System.Windows.Forms.ComboBox();
            this.m_group_box_web = new System.Windows.Forms.GroupBox();
            this.m_button_help = new System.Windows.Forms.Button();
            this.m_combo_box_help_file = new System.Windows.Forms.ComboBox();
            this.m_label_help_files = new System.Windows.Forms.Label();
            this.m_group_box_help = new System.Windows.Forms.GroupBox();
            this.ToolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_picture_box_text_logo)).BeginInit();
            this.m_group_box_season.SuspendLayout();
            this.m_group_box_concert.SuspendLayout();
            this.m_group_box_web.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_picture_box_text_logo
            // 
            this.m_picture_box_text_logo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_picture_box_text_logo.BackColor = System.Drawing.Color.Black;
            this.m_picture_box_text_logo.Image = ((System.Drawing.Image)(resources.GetObject("m_picture_box_text_logo.Image")));
            this.m_picture_box_text_logo.Location = new System.Drawing.Point(-3, 0);
            this.m_picture_box_text_logo.Name = "m_picture_box_text_logo";
            this.m_picture_box_text_logo.Size = new System.Drawing.Size(385, 79);
            this.m_picture_box_text_logo.TabIndex = 12;
            this.m_picture_box_text_logo.TabStop = false;
            // 
            // m_label_documents
            // 
            this.m_label_documents.AutoSize = true;
            this.m_label_documents.BackColor = System.Drawing.Color.Black;
            this.m_label_documents.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_documents.ForeColor = System.Drawing.Color.Red;
            this.m_label_documents.Location = new System.Drawing.Point(23, 37);
            this.m_label_documents.Name = "m_label_documents";
            this.m_label_documents.Size = new System.Drawing.Size(198, 26);
            this.m_label_documents.TabIndex = 1;
            this.m_label_documents.Text = "Documents (DOC)";
            // 
            // m_button_checkin_checkout
            // 
            this.m_button_checkin_checkout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_checkin_checkout.BackColor = System.Drawing.Color.Black;
            this.m_button_checkin_checkout.ForeColor = System.Drawing.Color.White;
            this.m_button_checkin_checkout.Location = new System.Drawing.Point(315, 37);
            this.m_button_checkin_checkout.Name = "m_button_checkin_checkout";
            this.m_button_checkin_checkout.Size = new System.Drawing.Size(100, 31);
            this.m_button_checkin_checkout.TabIndex = 2;
            this.m_button_checkin_checkout.Text = "Checkin";
            this.m_button_checkin_checkout.UseVisualStyleBackColor = false;
            this.m_button_checkin_checkout.Click += new System.EventHandler(this.m_button_checkin_checkout_Click);
            // 
            // m_combo_box_season
            // 
            this.m_combo_box_season.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_season.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_season.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_season.FormattingEnabled = true;
            this.m_combo_box_season.Location = new System.Drawing.Point(224, 18);
            this.m_combo_box_season.Name = "m_combo_box_season";
            this.m_combo_box_season.Size = new System.Drawing.Size(170, 24);
            this.m_combo_box_season.TabIndex = 0;
            this.m_combo_box_season.Text = "Season 2017-2018";
            this.m_combo_box_season.SelectedIndexChanged += new System.EventHandler(this.m_combo_box_season_SelectedIndexChanged);
            // 
            // m_combo_box_concert
            // 
            this.m_combo_box_concert.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_concert.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_concert.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_concert.FormattingEnabled = true;
            this.m_combo_box_concert.Location = new System.Drawing.Point(14, 20);
            this.m_combo_box_concert.Name = "m_combo_box_concert";
            this.m_combo_box_concert.Size = new System.Drawing.Size(382, 24);
            this.m_combo_box_concert.TabIndex = 0;
            this.m_combo_box_concert.Text = "Concert 1";
            this.m_combo_box_concert.SelectedIndexChanged += new System.EventHandler(this.m_combo_box_concert_SelectedIndexChanged);
            // 
            // m_button_cancel
            // 
            this.m_button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_cancel.BackColor = System.Drawing.Color.Black;
            this.m_button_cancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_cancel.FlatAppearance.BorderSize = 0;
            this.m_button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_cancel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_cancel.ForeColor = System.Drawing.Color.Red;
            this.m_button_cancel.Location = new System.Drawing.Point(124, 478);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(108, 26);
            this.m_button_cancel.TabIndex = 10;
            this.m_button_cancel.Text = "Cancel";
            this.m_button_cancel.UseVisualStyleBackColor = false;
            this.m_button_cancel.Click += new System.EventHandler(this.m_button_cancel_Click);
            // 
            // m_textbox_message
            // 
            this.m_textbox_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textbox_message.BackColor = System.Drawing.Color.Black;
            this.m_textbox_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textbox_message.ForeColor = System.Drawing.Color.Red;
            this.m_textbox_message.Location = new System.Drawing.Point(12, 445);
            this.m_textbox_message.Name = "m_textbox_message";
            this.m_textbox_message.ReadOnly = true;
            this.m_textbox_message.Size = new System.Drawing.Size(402, 23);
            this.m_textbox_message.TabIndex = 9;
            this.m_textbox_message.Text = "Messages of all kinds";
            // 
            // m_button_close
            // 
            this.m_button_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_close.BackColor = System.Drawing.Color.Black;
            this.m_button_close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_close.FlatAppearance.BorderSize = 0;
            this.m_button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_close.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_close.ForeColor = System.Drawing.Color.Red;
            this.m_button_close.Location = new System.Drawing.Point(248, 478);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(72, 26);
            this.m_button_close.TabIndex = 11;
            this.m_button_close.Text = "Close";
            this.m_button_close.UseVisualStyleBackColor = false;
            this.m_button_close.Click += new System.EventHandler(this.m_button_close_Click);
            // 
            // m_button_exit
            // 
            this.m_button_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_exit.BackColor = System.Drawing.Color.Black;
            this.m_button_exit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_exit.FlatAppearance.BorderSize = 0;
            this.m_button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_exit.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_exit.ForeColor = System.Drawing.Color.Red;
            this.m_button_exit.Location = new System.Drawing.Point(336, 478);
            this.m_button_exit.Name = "m_button_exit";
            this.m_button_exit.Size = new System.Drawing.Size(72, 26);
            this.m_button_exit.TabIndex = 12;
            this.m_button_exit.Text = "Ende";
            this.m_button_exit.UseVisualStyleBackColor = false;
            this.m_button_exit.Click += new System.EventHandler(this.m_button_exit_Click);
            // 
            // m_combo_box_season_documents
            // 
            this.m_combo_box_season_documents.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_season_documents.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_season_documents.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_season_documents.FormattingEnabled = true;
            this.m_combo_box_season_documents.Location = new System.Drawing.Point(83, 60);
            this.m_combo_box_season_documents.Name = "m_combo_box_season_documents";
            this.m_combo_box_season_documents.Size = new System.Drawing.Size(311, 24);
            this.m_combo_box_season_documents.TabIndex = 1;
            this.m_combo_box_season_documents.Text = "Season document 1";
            this.m_combo_box_season_documents.SelectedIndexChanged += new System.EventHandler(this.m_combo_box_season_documents_SelectedIndexChanged);
            // 
            // m_label_season_documents
            // 
            this.m_label_season_documents.AutoSize = true;
            this.m_label_season_documents.BackColor = System.Drawing.Color.Black;
            this.m_label_season_documents.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_season_documents.ForeColor = System.Drawing.Color.Red;
            this.m_label_season_documents.Location = new System.Drawing.Point(7, 63);
            this.m_label_season_documents.Name = "m_label_season_documents";
            this.m_label_season_documents.Size = new System.Drawing.Size(55, 16);
            this.m_label_season_documents.TabIndex = 2;
            this.m_label_season_documents.Text = "Season";
            // 
            // m_label_concert_documents
            // 
            this.m_label_concert_documents.AutoSize = true;
            this.m_label_concert_documents.BackColor = System.Drawing.Color.Black;
            this.m_label_concert_documents.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_concert_documents.ForeColor = System.Drawing.Color.Red;
            this.m_label_concert_documents.Location = new System.Drawing.Point(11, 68);
            this.m_label_concert_documents.Name = "m_label_concert_documents";
            this.m_label_concert_documents.Size = new System.Drawing.Size(57, 16);
            this.m_label_concert_documents.TabIndex = 1;
            this.m_label_concert_documents.Text = "Konzert";
            // 
            // m_combo_box_concert_documents
            // 
            this.m_combo_box_concert_documents.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_concert_documents.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_concert_documents.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_concert_documents.FormattingEnabled = true;
            this.m_combo_box_concert_documents.Location = new System.Drawing.Point(88, 65);
            this.m_combo_box_concert_documents.Name = "m_combo_box_concert_documents";
            this.m_combo_box_concert_documents.Size = new System.Drawing.Size(307, 24);
            this.m_combo_box_concert_documents.TabIndex = 2;
            this.m_combo_box_concert_documents.Text = "Konzert Dokument wählen";
            this.m_combo_box_concert_documents.SelectedIndexChanged += new System.EventHandler(this.m_combo_box_concert_documents_SelectedIndexChanged);
            // 
            // m_group_box_season
            // 
            this.m_group_box_season.Controls.Add(this.m_label_season_documents);
            this.m_group_box_season.Controls.Add(this.m_combo_box_season_documents);
            this.m_group_box_season.Controls.Add(this.m_combo_box_season);
            this.m_group_box_season.ForeColor = System.Drawing.Color.Red;
            this.m_group_box_season.Location = new System.Drawing.Point(13, 90);
            this.m_group_box_season.Name = "m_group_box_season";
            this.m_group_box_season.Size = new System.Drawing.Size(401, 97);
            this.m_group_box_season.TabIndex = 3;
            this.m_group_box_season.TabStop = false;
            this.m_group_box_season.Text = "Saison";
            // 
            // m_group_box_concert
            // 
            this.m_group_box_concert.Controls.Add(this.m_combo_box_concert_documents);
            this.m_group_box_concert.Controls.Add(this.m_label_concert_documents);
            this.m_group_box_concert.Controls.Add(this.m_combo_box_concert);
            this.m_group_box_concert.ForeColor = System.Drawing.Color.Red;
            this.m_group_box_concert.Location = new System.Drawing.Point(13, 189);
            this.m_group_box_concert.Name = "m_group_box_concert";
            this.m_group_box_concert.Size = new System.Drawing.Size(402, 102);
            this.m_group_box_concert.TabIndex = 4;
            this.m_group_box_concert.TabStop = false;
            this.m_group_box_concert.Text = "Konzert";
            // 
            // m_label_htm_files
            // 
            this.m_label_htm_files.AutoSize = true;
            this.m_label_htm_files.BackColor = System.Drawing.Color.Black;
            this.m_label_htm_files.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_htm_files.ForeColor = System.Drawing.Color.Red;
            this.m_label_htm_files.Location = new System.Drawing.Point(6, 24);
            this.m_label_htm_files.Name = "m_label_htm_files";
            this.m_label_htm_files.Size = new System.Drawing.Size(37, 16);
            this.m_label_htm_files.TabIndex = 0;
            this.m_label_htm_files.Text = "Web";
            // 
            // m_combo_box_htm_file
            // 
            this.m_combo_box_htm_file.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_htm_file.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_htm_file.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_htm_file.FormattingEnabled = true;
            this.m_combo_box_htm_file.Location = new System.Drawing.Point(84, 21);
            this.m_combo_box_htm_file.Name = "m_combo_box_htm_file";
            this.m_combo_box_htm_file.Size = new System.Drawing.Size(311, 24);
            this.m_combo_box_htm_file.TabIndex = 1;
            this.m_combo_box_htm_file.Text = "Select web page";
            this.m_combo_box_htm_file.SelectedIndexChanged += new System.EventHandler(this.m_combo_box_htm_file_SelectedIndexChanged);
            // 
            // m_group_box_web
            // 
            this.m_group_box_web.Controls.Add(this.m_combo_box_htm_file);
            this.m_group_box_web.Controls.Add(this.m_label_htm_files);
            this.m_group_box_web.ForeColor = System.Drawing.Color.Red;
            this.m_group_box_web.Location = new System.Drawing.Point(14, 365);
            this.m_group_box_web.Name = "m_group_box_web";
            this.m_group_box_web.Size = new System.Drawing.Size(400, 63);
            this.m_group_box_web.TabIndex = 8;
            this.m_group_box_web.TabStop = false;
            this.m_group_box_web.Text = "Web";
            // 
            // m_button_help
            // 
            this.m_button_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_help.BackColor = System.Drawing.Color.Black;
            this.m_button_help.ForeColor = System.Drawing.Color.White;
            this.m_button_help.Location = new System.Drawing.Point(315, 4);
            this.m_button_help.Name = "m_button_help";
            this.m_button_help.Size = new System.Drawing.Size(100, 31);
            this.m_button_help.TabIndex = 0;
            this.m_button_help.Text = "Help";
            this.m_button_help.UseVisualStyleBackColor = false;
            this.m_button_help.Click += new System.EventHandler(this.m_button_help_Click);
            // 
            // m_combo_box_help_file
            // 
            this.m_combo_box_help_file.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_help_file.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_help_file.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_help_file.FormattingEnabled = true;
            this.m_combo_box_help_file.Location = new System.Drawing.Point(98, 316);
            this.m_combo_box_help_file.Name = "m_combo_box_help_file";
            this.m_combo_box_help_file.Size = new System.Drawing.Size(311, 24);
            this.m_combo_box_help_file.TabIndex = 7;
            this.m_combo_box_help_file.Text = "Select help file";
            this.m_combo_box_help_file.SelectedIndexChanged += new System.EventHandler(this.m_combo_box_help_file_SelectedIndexChanged);
            // 
            // m_label_help_files
            // 
            this.m_label_help_files.AutoSize = true;
            this.m_label_help_files.BackColor = System.Drawing.Color.Black;
            this.m_label_help_files.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_help_files.ForeColor = System.Drawing.Color.Red;
            this.m_label_help_files.Location = new System.Drawing.Point(20, 320);
            this.m_label_help_files.Name = "m_label_help_files";
            this.m_label_help_files.Size = new System.Drawing.Size(37, 16);
            this.m_label_help_files.TabIndex = 6;
            this.m_label_help_files.Text = "Help";
            // 
            // m_group_box_help
            // 
            this.m_group_box_help.ForeColor = System.Drawing.Color.Red;
            this.m_group_box_help.Location = new System.Drawing.Point(14, 298);
            this.m_group_box_help.Name = "m_group_box_help";
            this.m_group_box_help.Size = new System.Drawing.Size(401, 59);
            this.m_group_box_help.TabIndex = 5;
            this.m_group_box_help.TabStop = false;
            this.m_group_box_help.Text = "Help";
            // 
            // DocAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(427, 514);
            this.ControlBox = false;
            this.Controls.Add(this.m_label_help_files);
            this.Controls.Add(this.m_combo_box_help_file);
            this.Controls.Add(this.m_button_help);
            this.Controls.Add(this.m_group_box_web);
            this.Controls.Add(this.m_group_box_concert);
            this.Controls.Add(this.m_group_box_season);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_textbox_message);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_button_exit);
            this.Controls.Add(this.m_button_checkin_checkout);
            this.Controls.Add(this.m_label_documents);
            this.Controls.Add(this.m_picture_box_text_logo);
            this.Controls.Add(this.m_group_box_help);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DocAdminForm";
            this.Text = "DocAdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.m_picture_box_text_logo)).EndInit();
            this.m_group_box_season.ResumeLayout(false);
            this.m_group_box_season.PerformLayout();
            this.m_group_box_concert.ResumeLayout(false);
            this.m_group_box_concert.PerformLayout();
            this.m_group_box_web.ResumeLayout(false);
            this.m_group_box_web.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_picture_box_text_logo;
        private System.Windows.Forms.Label m_label_documents;
        private System.Windows.Forms.Button m_button_checkin_checkout;
        private System.Windows.Forms.ComboBox m_combo_box_season;
        private System.Windows.Forms.ComboBox m_combo_box_concert;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.TextBox m_textbox_message;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_exit;
        private System.Windows.Forms.ComboBox m_combo_box_season_documents;
        private System.Windows.Forms.Label m_label_season_documents;
        private System.Windows.Forms.Label m_label_concert_documents;
        private System.Windows.Forms.ComboBox m_combo_box_concert_documents;
        private System.Windows.Forms.ToolTip ToolTipDocumentsForm;
        private System.Windows.Forms.ToolTip ToolTipCheckOut;
        private System.Windows.Forms.ToolTip ToolTipSelectConcert;
        private System.Windows.Forms.ToolTip ToolTipSelectConcertDocument;
        private System.Windows.Forms.ToolTip ToolTipSelectSeasonDocument;
        private System.Windows.Forms.ToolTip ToolTipDocumentsFormExit;
        private System.Windows.Forms.ToolTip ToolTipDocumentsFormClose;
        private System.Windows.Forms.ToolTip ToolTipDocumentsFormCancel;
        private System.Windows.Forms.ToolTip ToolTipDocumentsFormMessage;
        private System.Windows.Forms.GroupBox m_group_box_season;
        private System.Windows.Forms.GroupBox m_group_box_concert;
        private System.Windows.Forms.Label m_label_htm_files;
        private System.Windows.Forms.ComboBox m_combo_box_htm_file;
        private System.Windows.Forms.GroupBox m_group_box_web;
        private System.Windows.Forms.Button m_button_help;
        private System.Windows.Forms.ComboBox m_combo_box_help_file;
        private System.Windows.Forms.Label m_label_help_files;
        private System.Windows.Forms.GroupBox m_group_box_help;
        private System.Windows.Forms.ToolTip ToolTipHelp;
    }
}