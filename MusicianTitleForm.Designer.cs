namespace JazzAppAdmin
{
    partial class MusicianTitleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicianTitleForm));
            this.m_label_page_header = new System.Windows.Forms.Label();
            this.m_button_edit_musician_data = new System.Windows.Forms.Button();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_text_box_page_title = new System.Windows.Forms.TextBox();
            this.m_label_page_header_tag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_label_page_header
            // 
            this.m_label_page_header.AutoSize = true;
            this.m_label_page_header.BackColor = System.Drawing.Color.Black;
            this.m_label_page_header.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_page_header.ForeColor = System.Drawing.Color.Red;
            this.m_label_page_header.Location = new System.Drawing.Point(12, 72);
            this.m_label_page_header.Name = "m_label_page_header";
            this.m_label_page_header.Size = new System.Drawing.Size(65, 16);
            this.m_label_page_header.TabIndex = 3;
            this.m_label_page_header.Text = "Musiker";
            // 
            // m_button_edit_musician_data
            // 
            this.m_button_edit_musician_data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_edit_musician_data.BackColor = System.Drawing.Color.Black;
            this.m_button_edit_musician_data.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_edit_musician_data.BackgroundImage")));
            this.m_button_edit_musician_data.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_edit_musician_data.FlatAppearance.BorderSize = 0;
            this.m_button_edit_musician_data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_edit_musician_data.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_edit_musician_data.ForeColor = System.Drawing.Color.Red;
            this.m_button_edit_musician_data.Location = new System.Drawing.Point(16, 12);
            this.m_button_edit_musician_data.Name = "m_button_edit_musician_data";
            this.m_button_edit_musician_data.Size = new System.Drawing.Size(36, 41);
            this.m_button_edit_musician_data.TabIndex = 0;
            this.m_button_edit_musician_data.UseVisualStyleBackColor = false;
            this.m_button_edit_musician_data.Click += new System.EventHandler(this.m_button_edit_musician_data_Click);
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
            this.m_button_cancel.Location = new System.Drawing.Point(135, 13);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(92, 39);
            this.m_button_cancel.TabIndex = 1;
            this.m_button_cancel.Text = "Cancel";
            this.m_button_cancel.UseVisualStyleBackColor = false;
            this.m_button_cancel.Click += new System.EventHandler(this.m_button_cancel_Click);
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
            this.m_button_close.Location = new System.Drawing.Point(257, 13);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(160, 39);
            this.m_button_close.TabIndex = 2;
            this.m_button_close.Text = "Save/Close";
            this.m_button_close.UseVisualStyleBackColor = false;
            this.m_button_close.Click += new System.EventHandler(this.m_button_close_Click);
            // 
            // m_text_box_page_title
            // 
            this.m_text_box_page_title.Location = new System.Drawing.Point(12, 94);
            this.m_text_box_page_title.Name = "m_text_box_page_title";
            this.m_text_box_page_title.Size = new System.Drawing.Size(405, 23);
            this.m_text_box_page_title.TabIndex = 5;
            this.m_text_box_page_title.Text = "Page title";
            // 
            // m_label_page_header_tag
            // 
            this.m_label_page_header_tag.AutoSize = true;
            this.m_label_page_header_tag.BackColor = System.Drawing.Color.Black;
            this.m_label_page_header_tag.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_page_header_tag.ForeColor = System.Drawing.Color.Red;
            this.m_label_page_header_tag.Location = new System.Drawing.Point(269, 72);
            this.m_label_page_header_tag.Name = "m_label_page_header_tag";
            this.m_label_page_header_tag.Size = new System.Drawing.Size(66, 16);
            this.m_label_page_header_tag.TabIndex = 4;
            this.m_label_page_header_tag.Text = "XML Tag";
            // 
            // MusicianTitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(430, 163);
            this.ControlBox = false;
            this.Controls.Add(this.m_label_page_header_tag);
            this.Controls.Add(this.m_text_box_page_title);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_label_page_header);
            this.Controls.Add(this.m_button_edit_musician_data);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MusicianTitleForm";
            this.Text = "MusicianTitleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_label_page_header;
        private System.Windows.Forms.Button m_button_edit_musician_data;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.TextBox m_text_box_page_title;
        private System.Windows.Forms.Label m_label_page_header_tag;
    }
}