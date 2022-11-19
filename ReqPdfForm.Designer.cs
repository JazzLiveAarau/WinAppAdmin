namespace JazzAppAdmin
{
    partial class ReqPdfForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReqPdfForm));
            this.m_button_edit_request_data = new System.Windows.Forms.Button();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_label_page_header = new System.Windows.Forms.Label();
            this.m_button_download_htm = new System.Windows.Forms.Button();
            this.m_text_box_file_name_pdf = new System.Windows.Forms.TextBox();
            this.m_button_upload_htm = new System.Windows.Forms.Button();
            this.m_text_box_pdf = new System.Windows.Forms.TextBox();
            this.m_textbox_message = new System.Windows.Forms.TextBox();
            this.m_button_delete_pdf = new System.Windows.Forms.Button();
            this.TitleRequestPdfForm = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqMainCheckinCheckout = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqFormCancel = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqFormClose = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqFormMsg = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqDownloadInfoFile = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqUploadInfoFile = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqShowInfoFile = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqDeleteInfoFile = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // m_button_edit_request_data
            // 
            this.m_button_edit_request_data.BackColor = System.Drawing.Color.Black;
            this.m_button_edit_request_data.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_edit_request_data.BackgroundImage")));
            this.m_button_edit_request_data.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_edit_request_data.FlatAppearance.BorderSize = 0;
            this.m_button_edit_request_data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_edit_request_data.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_edit_request_data.ForeColor = System.Drawing.Color.Red;
            this.m_button_edit_request_data.Location = new System.Drawing.Point(9, 5);
            this.m_button_edit_request_data.Name = "m_button_edit_request_data";
            this.m_button_edit_request_data.Size = new System.Drawing.Size(36, 41);
            this.m_button_edit_request_data.TabIndex = 265;
            this.m_button_edit_request_data.UseVisualStyleBackColor = false;
            this.m_button_edit_request_data.Click += new System.EventHandler(this.m_button_edit_request_data_Click);
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
            this.m_button_close.Location = new System.Drawing.Point(379, 3);
            this.m_button_close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(168, 48);
            this.m_button_close.TabIndex = 264;
            this.m_button_close.Text = "Save/Close";
            this.m_button_close.UseVisualStyleBackColor = false;
            this.m_button_close.Click += new System.EventHandler(this.m_button_close_Click);
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
            this.m_button_cancel.Location = new System.Drawing.Point(215, 3);
            this.m_button_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(159, 48);
            this.m_button_cancel.TabIndex = 263;
            this.m_button_cancel.Text = "Cancel";
            this.m_button_cancel.UseVisualStyleBackColor = false;
            this.m_button_cancel.Click += new System.EventHandler(this.m_button_cancel_Click);
            // 
            // m_label_page_header
            // 
            this.m_label_page_header.AutoSize = true;
            this.m_label_page_header.BackColor = System.Drawing.Color.Black;
            this.m_label_page_header.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_page_header.ForeColor = System.Drawing.Color.Red;
            this.m_label_page_header.Location = new System.Drawing.Point(4, 67);
            this.m_label_page_header.Name = "m_label_page_header";
            this.m_label_page_header.Size = new System.Drawing.Size(199, 29);
            this.m_label_page_header.TabIndex = 266;
            this.m_label_page_header.Text = "Document name";
            // 
            // m_button_download_htm
            // 
            this.m_button_download_htm.BackColor = System.Drawing.Color.Black;
            this.m_button_download_htm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_download_htm.BackgroundImage")));
            this.m_button_download_htm.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_download_htm.FlatAppearance.BorderSize = 0;
            this.m_button_download_htm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_download_htm.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_download_htm.ForeColor = System.Drawing.Color.Red;
            this.m_button_download_htm.Location = new System.Drawing.Point(15, 123);
            this.m_button_download_htm.Name = "m_button_download_htm";
            this.m_button_download_htm.Size = new System.Drawing.Size(36, 41);
            this.m_button_download_htm.TabIndex = 270;
            this.m_button_download_htm.UseVisualStyleBackColor = false;
            this.m_button_download_htm.Click += new System.EventHandler(this.m_button_download_htm_Click);
            // 
            // m_text_box_file_name_pdf
            // 
            this.m_text_box_file_name_pdf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_file_name_pdf.BackColor = System.Drawing.Color.Black;
            this.m_text_box_file_name_pdf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_text_box_file_name_pdf.ForeColor = System.Drawing.Color.Red;
            this.m_text_box_file_name_pdf.Location = new System.Drawing.Point(165, 136);
            this.m_text_box_file_name_pdf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_text_box_file_name_pdf.Name = "m_text_box_file_name_pdf";
            this.m_text_box_file_name_pdf.ReadOnly = true;
            this.m_text_box_file_name_pdf.Size = new System.Drawing.Size(331, 27);
            this.m_text_box_file_name_pdf.TabIndex = 269;
            this.m_text_box_file_name_pdf.Text = "File name";
            // 
            // m_button_upload_htm
            // 
            this.m_button_upload_htm.BackColor = System.Drawing.Color.Black;
            this.m_button_upload_htm.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_upload_htm.FlatAppearance.BorderSize = 0;
            this.m_button_upload_htm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_upload_htm.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_upload_htm.ForeColor = System.Drawing.Color.Red;
            this.m_button_upload_htm.Image = ((System.Drawing.Image)(resources.GetObject("m_button_upload_htm.Image")));
            this.m_button_upload_htm.Location = new System.Drawing.Point(117, 119);
            this.m_button_upload_htm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_upload_htm.Name = "m_button_upload_htm";
            this.m_button_upload_htm.Size = new System.Drawing.Size(42, 50);
            this.m_button_upload_htm.TabIndex = 268;
            this.m_button_upload_htm.UseVisualStyleBackColor = false;
            this.m_button_upload_htm.Click += new System.EventHandler(this.m_button_upload_htm_Click);
            // 
            // m_text_box_pdf
            // 
            this.m_text_box_pdf.BackColor = System.Drawing.Color.Black;
            this.m_text_box_pdf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_text_box_pdf.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_text_box_pdf.ForeColor = System.Drawing.Color.Red;
            this.m_text_box_pdf.Location = new System.Drawing.Point(51, 133);
            this.m_text_box_pdf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_text_box_pdf.Name = "m_text_box_pdf";
            this.m_text_box_pdf.ReadOnly = true;
            this.m_text_box_pdf.Size = new System.Drawing.Size(68, 23);
            this.m_text_box_pdf.TabIndex = 271;
            this.m_text_box_pdf.Text = "PDF";
            this.m_text_box_pdf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_textbox_message
            // 
            this.m_textbox_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textbox_message.BackColor = System.Drawing.Color.Black;
            this.m_textbox_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textbox_message.ForeColor = System.Drawing.Color.Red;
            this.m_textbox_message.Location = new System.Drawing.Point(12, 191);
            this.m_textbox_message.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_textbox_message.Name = "m_textbox_message";
            this.m_textbox_message.ReadOnly = true;
            this.m_textbox_message.Size = new System.Drawing.Size(532, 27);
            this.m_textbox_message.TabIndex = 272;
            this.m_textbox_message.Text = "Messages of all kinds";
            // 
            // m_button_delete_pdf
            // 
            this.m_button_delete_pdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_delete_pdf.BackColor = System.Drawing.Color.Black;
            this.m_button_delete_pdf.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_delete_pdf.FlatAppearance.BorderSize = 0;
            this.m_button_delete_pdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_delete_pdf.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_delete_pdf.ForeColor = System.Drawing.Color.Red;
            this.m_button_delete_pdf.Image = ((System.Drawing.Image)(resources.GetObject("m_button_delete_pdf.Image")));
            this.m_button_delete_pdf.Location = new System.Drawing.Point(502, 123);
            this.m_button_delete_pdf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_delete_pdf.Name = "m_button_delete_pdf";
            this.m_button_delete_pdf.Size = new System.Drawing.Size(42, 50);
            this.m_button_delete_pdf.TabIndex = 273;
            this.m_button_delete_pdf.UseVisualStyleBackColor = false;
            this.m_button_delete_pdf.Click += new System.EventHandler(this.m_button_delete_pdf_Click);
            // 
            // ReqPdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(552, 231);
            this.ControlBox = false;
            this.Controls.Add(this.m_button_delete_pdf);
            this.Controls.Add(this.m_textbox_message);
            this.Controls.Add(this.m_text_box_pdf);
            this.Controls.Add(this.m_button_download_htm);
            this.Controls.Add(this.m_text_box_file_name_pdf);
            this.Controls.Add(this.m_button_upload_htm);
            this.Controls.Add(this.m_label_page_header);
            this.Controls.Add(this.m_button_edit_request_data);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_button_cancel);
            this.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ReqPdfForm";
            this.Text = "ReqPdfForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_button_edit_request_data;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Label m_label_page_header;
        private System.Windows.Forms.Button m_button_download_htm;
        private System.Windows.Forms.TextBox m_text_box_file_name_pdf;
        private System.Windows.Forms.Button m_button_upload_htm;
        private System.Windows.Forms.TextBox m_text_box_pdf;
        private System.Windows.Forms.TextBox m_textbox_message;
        private System.Windows.Forms.Button m_button_delete_pdf;
        private System.Windows.Forms.ToolTip TitleRequestPdfForm;
        private System.Windows.Forms.ToolTip ToolTipReqMainCheckinCheckout;
        private System.Windows.Forms.ToolTip ToolTipReqFormCancel;
        private System.Windows.Forms.ToolTip ToolTipReqFormClose;
        private System.Windows.Forms.ToolTip ToolTipReqFormMsg;
        private System.Windows.Forms.ToolTip ToolTipReqDownloadInfoFile;
        private System.Windows.Forms.ToolTip ToolTipReqUploadInfoFile;
        private System.Windows.Forms.ToolTip ToolTipReqShowInfoFile;
        private System.Windows.Forms.ToolTip ToolTipReqDeleteInfoFile;
    }
}