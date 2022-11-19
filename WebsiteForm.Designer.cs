namespace JazzAppAdmin
{
    partial class WebsiteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebsiteForm));
            this.m_label_website_htm = new System.Windows.Forms.Label();
            this.m_picture_box_text_logo = new System.Windows.Forms.PictureBox();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_exit = new System.Windows.Forms.Button();
            this.m_button_update_website = new System.Windows.Forms.Button();
            this.m_textbox_message = new System.Windows.Forms.TextBox();
            this.ToolTipUpdateJavaScriptFile = new System.Windows.Forms.ToolTip(this.components);
            this.m_progress_bar_update = new System.Windows.Forms.ProgressBar();
            this.m_button_help = new System.Windows.Forms.Button();
            this.ToolTipCreateUploadPosters = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipExportToFlyerApplication = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipImportFromFlyerApplication = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_picture_box_text_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // m_label_website_htm
            // 
            this.m_label_website_htm.AutoSize = true;
            this.m_label_website_htm.BackColor = System.Drawing.Color.Black;
            this.m_label_website_htm.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_website_htm.ForeColor = System.Drawing.Color.Red;
            this.m_label_website_htm.Location = new System.Drawing.Point(18, 42);
            this.m_label_website_htm.Name = "m_label_website_htm";
            this.m_label_website_htm.Size = new System.Drawing.Size(211, 33);
            this.m_label_website_htm.TabIndex = 13;
            this.m_label_website_htm.Text = "Website (HTM)";
            // 
            // m_picture_box_text_logo
            // 
            this.m_picture_box_text_logo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_picture_box_text_logo.BackColor = System.Drawing.Color.Black;
            this.m_picture_box_text_logo.Image = ((System.Drawing.Image)(resources.GetObject("m_picture_box_text_logo.Image")));
            this.m_picture_box_text_logo.Location = new System.Drawing.Point(-1, 3);
            this.m_picture_box_text_logo.Name = "m_picture_box_text_logo";
            this.m_picture_box_text_logo.Size = new System.Drawing.Size(302, 79);
            this.m_picture_box_text_logo.TabIndex = 14;
            this.m_picture_box_text_logo.TabStop = false;
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
            this.m_button_cancel.Location = new System.Drawing.Point(118, 198);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(108, 26);
            this.m_button_cancel.TabIndex = 187;
            this.m_button_cancel.Text = "Cancel";
            this.m_button_cancel.UseVisualStyleBackColor = false;
            this.m_button_cancel.Click += new System.EventHandler(this.m_button_cancel_Click);
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
            this.m_button_close.Location = new System.Drawing.Point(242, 198);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(72, 26);
            this.m_button_close.TabIndex = 186;
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
            this.m_button_exit.Location = new System.Drawing.Point(330, 198);
            this.m_button_exit.Name = "m_button_exit";
            this.m_button_exit.Size = new System.Drawing.Size(72, 26);
            this.m_button_exit.TabIndex = 185;
            this.m_button_exit.Text = "Ende";
            this.m_button_exit.UseVisualStyleBackColor = false;
            this.m_button_exit.Click += new System.EventHandler(this.m_button_exit_Click);
            // 
            // m_button_update_website
            // 
            this.m_button_update_website.BackColor = System.Drawing.Color.Black;
            this.m_button_update_website.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_update_website.FlatAppearance.BorderSize = 0;
            this.m_button_update_website.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_update_website.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_update_website.ForeColor = System.Drawing.Color.Red;
            this.m_button_update_website.Location = new System.Drawing.Point(23, 89);
            this.m_button_update_website.Name = "m_button_update_website";
            this.m_button_update_website.Size = new System.Drawing.Size(356, 23);
            this.m_button_update_website.TabIndex = 192;
            this.m_button_update_website.Text = "Update  Intranet";
            this.m_button_update_website.UseVisualStyleBackColor = false;
            this.m_button_update_website.Click += new System.EventHandler(this.m_button_update_website_Click);
            // 
            // m_textbox_message
            // 
            this.m_textbox_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textbox_message.BackColor = System.Drawing.Color.Black;
            this.m_textbox_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textbox_message.ForeColor = System.Drawing.Color.Red;
            this.m_textbox_message.Location = new System.Drawing.Point(12, 171);
            this.m_textbox_message.Name = "m_textbox_message";
            this.m_textbox_message.ReadOnly = true;
            this.m_textbox_message.Size = new System.Drawing.Size(396, 27);
            this.m_textbox_message.TabIndex = 193;
            this.m_textbox_message.Text = "Messages of all kinds";
            // 
            // m_progress_bar_update
            // 
            this.m_progress_bar_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_progress_bar_update.BackColor = System.Drawing.Color.Black;
            this.m_progress_bar_update.ForeColor = System.Drawing.Color.Red;
            this.m_progress_bar_update.Location = new System.Drawing.Point(93, 134);
            this.m_progress_bar_update.Name = "m_progress_bar_update";
            this.m_progress_bar_update.Size = new System.Drawing.Size(178, 21);
            this.m_progress_bar_update.TabIndex = 194;
            // 
            // m_button_help
            // 
            this.m_button_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_help.BackColor = System.Drawing.Color.Black;
            this.m_button_help.ForeColor = System.Drawing.Color.White;
            this.m_button_help.Location = new System.Drawing.Point(307, 12);
            this.m_button_help.Name = "m_button_help";
            this.m_button_help.Size = new System.Drawing.Size(100, 31);
            this.m_button_help.TabIndex = 308;
            this.m_button_help.Text = "Help";
            this.m_button_help.UseVisualStyleBackColor = false;
            this.m_button_help.Click += new System.EventHandler(this.m_button_help_Click);
            // 
            // WebsiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(412, 229);
            this.ControlBox = false;
            this.Controls.Add(this.m_button_help);
            this.Controls.Add(this.m_progress_bar_update);
            this.Controls.Add(this.m_textbox_message);
            this.Controls.Add(this.m_button_update_website);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_button_exit);
            this.Controls.Add(this.m_label_website_htm);
            this.Controls.Add(this.m_picture_box_text_logo);
            this.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WebsiteForm";
            this.Text = "Website";
            ((System.ComponentModel.ISupportInitialize)(this.m_picture_box_text_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_label_website_htm;
        private System.Windows.Forms.PictureBox m_picture_box_text_logo;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_exit;
        private System.Windows.Forms.Button m_button_update_website;
        private System.Windows.Forms.TextBox m_textbox_message;
        private System.Windows.Forms.ToolTip ToolTipUpdateJavaScriptFile;
        private System.Windows.Forms.ProgressBar m_progress_bar_update;
        private System.Windows.Forms.Button m_button_help;
        private System.Windows.Forms.ToolTip ToolTipCreateUploadPosters;
        private System.Windows.Forms.ToolTip ToolTipHelp;
        private System.Windows.Forms.ToolTip ToolTipExportToFlyerApplication;
        private System.Windows.Forms.ToolTip ToolTipImportFromFlyerApplication;
    }
}