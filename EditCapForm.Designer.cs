namespace JazzAppAdmin
{
    partial class EditCapForm
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
            this.m_label_xml_tag = new System.Windows.Forms.Label();
            this.m_text_box_xml_value = new System.Windows.Forms.TextBox();
            this.m_button_save = new System.Windows.Forms.Button();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_label_xml_tag
            // 
            this.m_label_xml_tag.AutoSize = true;
            this.m_label_xml_tag.BackColor = System.Drawing.Color.Black;
            this.m_label_xml_tag.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_xml_tag.ForeColor = System.Drawing.Color.Red;
            this.m_label_xml_tag.Location = new System.Drawing.Point(3, 21);
            this.m_label_xml_tag.Name = "m_label_xml_tag";
            this.m_label_xml_tag.Size = new System.Drawing.Size(149, 33);
            this.m_label_xml_tag.TabIndex = 10;
            this.m_label_xml_tag.Text = "<XmlTag>";
            // 
            // m_text_box_xml_value
            // 
            this.m_text_box_xml_value.Location = new System.Drawing.Point(9, 68);
            this.m_text_box_xml_value.Name = "m_text_box_xml_value";
            this.m_text_box_xml_value.Size = new System.Drawing.Size(621, 27);
            this.m_text_box_xml_value.TabIndex = 11;
            this.m_text_box_xml_value.Text = "Caption for a button (xml tag value)";
            // 
            // m_button_save
            // 
            this.m_button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_save.BackColor = System.Drawing.Color.Black;
            this.m_button_save.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_save.FlatAppearance.BorderSize = 0;
            this.m_button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_save.ForeColor = System.Drawing.Color.Red;
            this.m_button_save.Location = new System.Drawing.Point(561, 117);
            this.m_button_save.Name = "m_button_save";
            this.m_button_save.Size = new System.Drawing.Size(69, 26);
            this.m_button_save.TabIndex = 21;
            this.m_button_save.Text = "Save";
            this.m_button_save.UseVisualStyleBackColor = false;
            this.m_button_save.Click += new System.EventHandler(this.m_button_save_Click);
            // 
            // m_button_cancel
            // 
            this.m_button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_cancel.BackColor = System.Drawing.Color.Black;
            this.m_button_cancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_cancel.FlatAppearance.BorderSize = 0;
            this.m_button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_cancel.ForeColor = System.Drawing.Color.Red;
            this.m_button_cancel.Location = new System.Drawing.Point(469, 117);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(69, 26);
            this.m_button_cancel.TabIndex = 22;
            this.m_button_cancel.Text = "Cancel";
            this.m_button_cancel.UseVisualStyleBackColor = false;
            this.m_button_cancel.Click += new System.EventHandler(this.m_button_cancel_Click);
            // 
            // EditCapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(638, 155);
            this.ControlBox = false;
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_button_save);
            this.Controls.Add(this.m_text_box_xml_value);
            this.Controls.Add(this.m_label_xml_tag);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditCapForm";
            this.Text = "Edit Cap Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_label_xml_tag;
        private System.Windows.Forms.TextBox m_text_box_xml_value;
        private System.Windows.Forms.Button m_button_save;
        private System.Windows.Forms.Button m_button_cancel;
    }
}