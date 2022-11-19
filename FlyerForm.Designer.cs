namespace JazzAppAdmin
{
    partial class FlyerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlyerForm));
            this.m_picture_box_text_logo = new System.Windows.Forms.PictureBox();
            this.m_label_flyer_htm = new System.Windows.Forms.Label();
            this.m_button_help = new System.Windows.Forms.Button();
            this.m_progress_bar_update = new System.Windows.Forms.ProgressBar();
            this.m_textbox_message = new System.Windows.Forms.TextBox();
            this.m_button_exit = new System.Windows.Forms.Button();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_button_export_qr_codes = new System.Windows.Forms.Button();
            this.m_button_checkin_checkout = new System.Windows.Forms.Button();
            this.m_button_update_flyer = new System.Windows.Forms.Button();
            this.m_button_import_musician_texts = new System.Windows.Forms.Button();
            this.m_button_import_free_texts = new System.Windows.Forms.Button();
            this.m_group_box_export = new System.Windows.Forms.GroupBox();
            this.m_button_export_flyer_image_files = new System.Windows.Forms.Button();
            this.m_group_box_import = new System.Windows.Forms.GroupBox();
            this.ToolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipExportToFlyerApplication = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipImportFromFlyerApplication = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipExportSeasonProgramToFlyerApplication = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipExportQRCodesToFlyerApplication = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipExportFrontPageImagesToFlyerApplication = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipImportMusicianTextsFromFlyerApplication = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipImportFreeTextsFromFlyerApplication = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipCheckOut = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipIndexExit = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipIndexBack = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipIndexCancel = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_picture_box_text_logo)).BeginInit();
            this.m_group_box_export.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_picture_box_text_logo
            // 
            this.m_picture_box_text_logo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_picture_box_text_logo.BackColor = System.Drawing.Color.Black;
            this.m_picture_box_text_logo.Image = ((System.Drawing.Image)(resources.GetObject("m_picture_box_text_logo.Image")));
            this.m_picture_box_text_logo.Location = new System.Drawing.Point(-2, 1);
            this.m_picture_box_text_logo.Name = "m_picture_box_text_logo";
            this.m_picture_box_text_logo.Size = new System.Drawing.Size(302, 79);
            this.m_picture_box_text_logo.TabIndex = 15;
            this.m_picture_box_text_logo.TabStop = false;
            // 
            // m_label_flyer_htm
            // 
            this.m_label_flyer_htm.AutoSize = true;
            this.m_label_flyer_htm.BackColor = System.Drawing.Color.Black;
            this.m_label_flyer_htm.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_flyer_htm.ForeColor = System.Drawing.Color.Red;
            this.m_label_flyer_htm.Location = new System.Drawing.Point(19, 38);
            this.m_label_flyer_htm.Name = "m_label_flyer_htm";
            this.m_label_flyer_htm.Size = new System.Drawing.Size(129, 26);
            this.m_label_flyer_htm.TabIndex = 16;
            this.m_label_flyer_htm.Text = "Flyer (HTM)";
            // 
            // m_button_help
            // 
            this.m_button_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_help.BackColor = System.Drawing.Color.Black;
            this.m_button_help.ForeColor = System.Drawing.Color.White;
            this.m_button_help.Location = new System.Drawing.Point(339, 12);
            this.m_button_help.Name = "m_button_help";
            this.m_button_help.Size = new System.Drawing.Size(100, 31);
            this.m_button_help.TabIndex = 309;
            this.m_button_help.Text = "Help";
            this.m_button_help.UseVisualStyleBackColor = false;
            this.m_button_help.Click += new System.EventHandler(this.m_button_help_Click);
            // 
            // m_progress_bar_update
            // 
            this.m_progress_bar_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_progress_bar_update.BackColor = System.Drawing.Color.Black;
            this.m_progress_bar_update.ForeColor = System.Drawing.Color.Red;
            this.m_progress_bar_update.Location = new System.Drawing.Point(132, 219);
            this.m_progress_bar_update.Name = "m_progress_bar_update";
            this.m_progress_bar_update.Size = new System.Drawing.Size(178, 21);
            this.m_progress_bar_update.TabIndex = 310;
            // 
            // m_textbox_message
            // 
            this.m_textbox_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textbox_message.BackColor = System.Drawing.Color.Black;
            this.m_textbox_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textbox_message.ForeColor = System.Drawing.Color.Red;
            this.m_textbox_message.Location = new System.Drawing.Point(25, 246);
            this.m_textbox_message.Name = "m_textbox_message";
            this.m_textbox_message.ReadOnly = true;
            this.m_textbox_message.Size = new System.Drawing.Size(414, 23);
            this.m_textbox_message.TabIndex = 311;
            this.m_textbox_message.Text = "Messages of all kinds";
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
            this.m_button_exit.Location = new System.Drawing.Point(349, 279);
            this.m_button_exit.Name = "m_button_exit";
            this.m_button_exit.Size = new System.Drawing.Size(90, 26);
            this.m_button_exit.TabIndex = 312;
            this.m_button_exit.Text = "Ende";
            this.m_button_exit.UseVisualStyleBackColor = false;
            this.m_button_exit.Click += new System.EventHandler(this.m_button_exit_Click);
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
            this.m_button_close.Location = new System.Drawing.Point(265, 279);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(72, 26);
            this.m_button_close.TabIndex = 313;
            this.m_button_close.Text = "Close";
            this.m_button_close.UseVisualStyleBackColor = false;
            this.m_button_close.Click += new System.EventHandler(this.m_button_close_Click);
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
            this.m_button_cancel.Location = new System.Drawing.Point(146, 279);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(108, 26);
            this.m_button_cancel.TabIndex = 314;
            this.m_button_cancel.Text = "Cancel";
            this.m_button_cancel.UseVisualStyleBackColor = false;
            this.m_button_cancel.Click += new System.EventHandler(this.m_button_cancel_Click);
            // 
            // m_button_export_qr_codes
            // 
            this.m_button_export_qr_codes.BackColor = System.Drawing.Color.Black;
            this.m_button_export_qr_codes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_export_qr_codes.FlatAppearance.BorderSize = 0;
            this.m_button_export_qr_codes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_export_qr_codes.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_export_qr_codes.ForeColor = System.Drawing.Color.Red;
            this.m_button_export_qr_codes.Location = new System.Drawing.Point(9, 57);
            this.m_button_export_qr_codes.Name = "m_button_export_qr_codes";
            this.m_button_export_qr_codes.Size = new System.Drawing.Size(166, 23);
            this.m_button_export_qr_codes.TabIndex = 315;
            this.m_button_export_qr_codes.Text = "QR Codes";
            this.m_button_export_qr_codes.UseVisualStyleBackColor = false;
            this.m_button_export_qr_codes.Click += new System.EventHandler(this.m_button_export_qr_codes_Click);
            // 
            // m_button_checkin_checkout
            // 
            this.m_button_checkin_checkout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_checkin_checkout.BackColor = System.Drawing.Color.Black;
            this.m_button_checkin_checkout.ForeColor = System.Drawing.Color.White;
            this.m_button_checkin_checkout.Location = new System.Drawing.Point(339, 50);
            this.m_button_checkin_checkout.Name = "m_button_checkin_checkout";
            this.m_button_checkin_checkout.Size = new System.Drawing.Size(100, 31);
            this.m_button_checkin_checkout.TabIndex = 316;
            this.m_button_checkin_checkout.Text = "Checkin";
            this.m_button_checkin_checkout.UseVisualStyleBackColor = false;
            this.m_button_checkin_checkout.Click += new System.EventHandler(this.m_button_checkin_checkout_Click);
            // 
            // m_button_update_flyer
            // 
            this.m_button_update_flyer.BackColor = System.Drawing.Color.Black;
            this.m_button_update_flyer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_update_flyer.FlatAppearance.BorderSize = 0;
            this.m_button_update_flyer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_update_flyer.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_update_flyer.ForeColor = System.Drawing.Color.Red;
            this.m_button_update_flyer.Location = new System.Drawing.Point(9, 88);
            this.m_button_update_flyer.Name = "m_button_update_flyer";
            this.m_button_update_flyer.Size = new System.Drawing.Size(166, 23);
            this.m_button_update_flyer.TabIndex = 317;
            this.m_button_update_flyer.Text = "Season Programs";
            this.m_button_update_flyer.UseVisualStyleBackColor = false;
            this.m_button_update_flyer.Click += new System.EventHandler(this.m_button_update_flyer_Click);
            // 
            // m_button_import_musician_texts
            // 
            this.m_button_import_musician_texts.BackColor = System.Drawing.Color.Black;
            this.m_button_import_musician_texts.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_import_musician_texts.FlatAppearance.BorderSize = 0;
            this.m_button_import_musician_texts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_import_musician_texts.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_import_musician_texts.ForeColor = System.Drawing.Color.Red;
            this.m_button_import_musician_texts.Location = new System.Drawing.Point(257, 147);
            this.m_button_import_musician_texts.Name = "m_button_import_musician_texts";
            this.m_button_import_musician_texts.Size = new System.Drawing.Size(166, 23);
            this.m_button_import_musician_texts.TabIndex = 318;
            this.m_button_import_musician_texts.Text = "Musician Texts";
            this.m_button_import_musician_texts.UseVisualStyleBackColor = false;
            this.m_button_import_musician_texts.Click += new System.EventHandler(this.m_button_import_musician_texts_Click);
            // 
            // m_button_import_free_texts
            // 
            this.m_button_import_free_texts.BackColor = System.Drawing.Color.Black;
            this.m_button_import_free_texts.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_import_free_texts.FlatAppearance.BorderSize = 0;
            this.m_button_import_free_texts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_import_free_texts.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_import_free_texts.ForeColor = System.Drawing.Color.Red;
            this.m_button_import_free_texts.Location = new System.Drawing.Point(257, 178);
            this.m_button_import_free_texts.Name = "m_button_import_free_texts";
            this.m_button_import_free_texts.Size = new System.Drawing.Size(166, 23);
            this.m_button_import_free_texts.TabIndex = 319;
            this.m_button_import_free_texts.Text = "Free Texts";
            this.m_button_import_free_texts.UseVisualStyleBackColor = false;
            this.m_button_import_free_texts.Click += new System.EventHandler(this.m_button_import_free_texts_Click);
            // 
            // m_group_box_export
            // 
            this.m_group_box_export.Controls.Add(this.m_button_export_flyer_image_files);
            this.m_group_box_export.Controls.Add(this.m_button_update_flyer);
            this.m_group_box_export.Controls.Add(this.m_button_export_qr_codes);
            this.m_group_box_export.ForeColor = System.Drawing.Color.Red;
            this.m_group_box_export.Location = new System.Drawing.Point(23, 86);
            this.m_group_box_export.Name = "m_group_box_export";
            this.m_group_box_export.Size = new System.Drawing.Size(185, 121);
            this.m_group_box_export.TabIndex = 320;
            this.m_group_box_export.TabStop = false;
            this.m_group_box_export.Text = "Export";
            // 
            // m_button_export_flyer_image_files
            // 
            this.m_button_export_flyer_image_files.BackColor = System.Drawing.Color.Black;
            this.m_button_export_flyer_image_files.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_export_flyer_image_files.FlatAppearance.BorderSize = 0;
            this.m_button_export_flyer_image_files.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_export_flyer_image_files.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_export_flyer_image_files.ForeColor = System.Drawing.Color.Red;
            this.m_button_export_flyer_image_files.Location = new System.Drawing.Point(9, 26);
            this.m_button_export_flyer_image_files.Name = "m_button_export_flyer_image_files";
            this.m_button_export_flyer_image_files.Size = new System.Drawing.Size(166, 23);
            this.m_button_export_flyer_image_files.TabIndex = 322;
            this.m_button_export_flyer_image_files.Text = "Flyer Image Files";
            this.m_button_export_flyer_image_files.UseVisualStyleBackColor = false;
            this.m_button_export_flyer_image_files.Click += new System.EventHandler(this.m_button_export_flyer_image_files_Click);
            // 
            // m_group_box_import
            // 
            this.m_group_box_import.ForeColor = System.Drawing.Color.Red;
            this.m_group_box_import.Location = new System.Drawing.Point(247, 126);
            this.m_group_box_import.Name = "m_group_box_import";
            this.m_group_box_import.Size = new System.Drawing.Size(185, 81);
            this.m_group_box_import.TabIndex = 321;
            this.m_group_box_import.TabStop = false;
            this.m_group_box_import.Text = "Import";
            // 
            // FlyerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(451, 310);
            this.ControlBox = false;
            this.Controls.Add(this.m_group_box_export);
            this.Controls.Add(this.m_button_import_free_texts);
            this.Controls.Add(this.m_button_import_musician_texts);
            this.Controls.Add(this.m_button_checkin_checkout);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_button_exit);
            this.Controls.Add(this.m_textbox_message);
            this.Controls.Add(this.m_progress_bar_update);
            this.Controls.Add(this.m_button_help);
            this.Controls.Add(this.m_label_flyer_htm);
            this.Controls.Add(this.m_picture_box_text_logo);
            this.Controls.Add(this.m_group_box_import);
            this.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FlyerForm";
            this.Text = "Flyer";
            ((System.ComponentModel.ISupportInitialize)(this.m_picture_box_text_logo)).EndInit();
            this.m_group_box_export.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_picture_box_text_logo;
        private System.Windows.Forms.Label m_label_flyer_htm;
        private System.Windows.Forms.Button m_button_help;
        private System.Windows.Forms.ProgressBar m_progress_bar_update;
        private System.Windows.Forms.TextBox m_textbox_message;
        private System.Windows.Forms.Button m_button_exit;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Button m_button_export_qr_codes;
        private System.Windows.Forms.Button m_button_checkin_checkout;
        private System.Windows.Forms.Button m_button_update_flyer;
        private System.Windows.Forms.Button m_button_import_musician_texts;
        private System.Windows.Forms.Button m_button_import_free_texts;
        private System.Windows.Forms.GroupBox m_group_box_export;
        private System.Windows.Forms.GroupBox m_group_box_import;
        private System.Windows.Forms.Button m_button_export_flyer_image_files;
        private System.Windows.Forms.ToolTip ToolTipHelp;
        private System.Windows.Forms.ToolTip ToolTipExportToFlyerApplication;
        private System.Windows.Forms.ToolTip ToolTipImportFromFlyerApplication;
        private System.Windows.Forms.ToolTip ToolTipExportSeasonProgramToFlyerApplication;
        private System.Windows.Forms.ToolTip ToolTipExportQRCodesToFlyerApplication;
        private System.Windows.Forms.ToolTip ToolTipExportFrontPageImagesToFlyerApplication;
        private System.Windows.Forms.ToolTip ToolTipImportMusicianTextsFromFlyerApplication;
        private System.Windows.Forms.ToolTip ToolTipImportFreeTextsFromFlyerApplication;
        private System.Windows.Forms.ToolTip ToolTipCheckOut;
        private System.Windows.Forms.ToolTip ToolTipIndexExit;
        private System.Windows.Forms.ToolTip ToolTipIndexBack;
        private System.Windows.Forms.ToolTip ToolTipIndexCancel;
    }
}