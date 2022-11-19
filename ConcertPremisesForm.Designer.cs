namespace JazzAppAdmin
{
    partial class ConcertPremisesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConcertPremisesForm));
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_edit_premises_data = new System.Windows.Forms.Button();
            this.m_label_page_header = new System.Windows.Forms.Label();
            this.m_text_box_premises_name = new System.Windows.Forms.TextBox();
            this.m_label_premises_name = new System.Windows.Forms.Label();
            this.m_text_box_premises_city = new System.Windows.Forms.TextBox();
            this.m_label_premises_city = new System.Windows.Forms.Label();
            this.m_text_box_premises_street = new System.Windows.Forms.TextBox();
            this.m_label_premises_street = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.m_button_cancel.Location = new System.Drawing.Point(126, 12);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(122, 39);
            this.m_button_cancel.TabIndex = 63;
            this.m_button_cancel.Text = "Cancel";
            this.m_button_cancel.UseVisualStyleBackColor = false;
            this.m_button_cancel.Click += new System.EventHandler(this.m_button_cancel_Click_1);
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
            this.m_button_close.Location = new System.Drawing.Point(266, 12);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(153, 39);
            this.m_button_close.TabIndex = 62;
            this.m_button_close.Text = "Save/Close";
            this.m_button_close.UseVisualStyleBackColor = false;
            this.m_button_close.Click += new System.EventHandler(this.m_button_close_Click_1);
            // 
            // m_button_edit_premises_data
            // 
            this.m_button_edit_premises_data.BackColor = System.Drawing.Color.Black;
            this.m_button_edit_premises_data.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_edit_premises_data.BackgroundImage")));
            this.m_button_edit_premises_data.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_edit_premises_data.FlatAppearance.BorderSize = 0;
            this.m_button_edit_premises_data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_edit_premises_data.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_edit_premises_data.ForeColor = System.Drawing.Color.Red;
            this.m_button_edit_premises_data.Location = new System.Drawing.Point(9, 9);
            this.m_button_edit_premises_data.Name = "m_button_edit_premises_data";
            this.m_button_edit_premises_data.Size = new System.Drawing.Size(36, 41);
            this.m_button_edit_premises_data.TabIndex = 61;
            this.m_button_edit_premises_data.UseVisualStyleBackColor = false;
            this.m_button_edit_premises_data.Click += new System.EventHandler(this.m_button_edit_premises_data_Click);
            // 
            // m_label_page_header
            // 
            this.m_label_page_header.AutoSize = true;
            this.m_label_page_header.BackColor = System.Drawing.Color.Black;
            this.m_label_page_header.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_page_header.ForeColor = System.Drawing.Color.Red;
            this.m_label_page_header.Location = new System.Drawing.Point(12, 75);
            this.m_label_page_header.Name = "m_label_page_header";
            this.m_label_page_header.Size = new System.Drawing.Size(214, 29);
            this.m_label_page_header.TabIndex = 103;
            this.m_label_page_header.Text = "Concert premises";
            // 
            // m_text_box_premises_name
            // 
            this.m_text_box_premises_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_premises_name.Location = new System.Drawing.Point(7, 149);
            this.m_text_box_premises_name.Name = "m_text_box_premises_name";
            this.m_text_box_premises_name.Size = new System.Drawing.Size(412, 27);
            this.m_text_box_premises_name.TabIndex = 104;
            this.m_text_box_premises_name.Text = "Spaghetti Factory Salmen";
            // 
            // m_label_premises_name
            // 
            this.m_label_premises_name.AutoSize = true;
            this.m_label_premises_name.BackColor = System.Drawing.Color.Black;
            this.m_label_premises_name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_premises_name.ForeColor = System.Drawing.Color.Red;
            this.m_label_premises_name.Location = new System.Drawing.Point(5, 122);
            this.m_label_premises_name.Name = "m_label_premises_name";
            this.m_label_premises_name.Size = new System.Drawing.Size(154, 24);
            this.m_label_premises_name.TabIndex = 105;
            this.m_label_premises_name.Text = "Premises name";
            // 
            // m_text_box_premises_city
            // 
            this.m_text_box_premises_city.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_premises_city.Location = new System.Drawing.Point(7, 285);
            this.m_text_box_premises_city.Name = "m_text_box_premises_city";
            this.m_text_box_premises_city.Size = new System.Drawing.Size(412, 27);
            this.m_text_box_premises_city.TabIndex = 109;
            this.m_text_box_premises_city.Text = "Aarau";
            // 
            // m_label_premises_city
            // 
            this.m_label_premises_city.AutoSize = true;
            this.m_label_premises_city.BackColor = System.Drawing.Color.Black;
            this.m_label_premises_city.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_premises_city.ForeColor = System.Drawing.Color.Red;
            this.m_label_premises_city.Location = new System.Drawing.Point(7, 258);
            this.m_label_premises_city.Name = "m_label_premises_city";
            this.m_label_premises_city.Size = new System.Drawing.Size(137, 24);
            this.m_label_premises_city.TabIndex = 108;
            this.m_label_premises_city.Text = "Premises city";
            // 
            // m_text_box_premises_street
            // 
            this.m_text_box_premises_street.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_premises_street.Location = new System.Drawing.Point(7, 215);
            this.m_text_box_premises_street.Name = "m_text_box_premises_street";
            this.m_text_box_premises_street.Size = new System.Drawing.Size(412, 27);
            this.m_text_box_premises_street.TabIndex = 107;
            this.m_text_box_premises_street.Text = "Metzgergasse 8";
            // 
            // m_label_premises_street
            // 
            this.m_label_premises_street.AutoSize = true;
            this.m_label_premises_street.BackColor = System.Drawing.Color.Black;
            this.m_label_premises_street.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_premises_street.ForeColor = System.Drawing.Color.Red;
            this.m_label_premises_street.Location = new System.Drawing.Point(7, 188);
            this.m_label_premises_street.Name = "m_label_premises_street";
            this.m_label_premises_street.Size = new System.Drawing.Size(158, 24);
            this.m_label_premises_street.TabIndex = 106;
            this.m_label_premises_street.Text = "Premises street";
            // 
            // ConcertPremisesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(431, 339);
            this.ControlBox = false;
            this.Controls.Add(this.m_text_box_premises_city);
            this.Controls.Add(this.m_label_premises_city);
            this.Controls.Add(this.m_text_box_premises_street);
            this.Controls.Add(this.m_label_premises_street);
            this.Controls.Add(this.m_label_premises_name);
            this.Controls.Add(this.m_text_box_premises_name);
            this.Controls.Add(this.m_label_page_header);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_button_edit_premises_data);
            this.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConcertPremisesForm";
            this.Text = "ConcertPremisesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_edit_premises_data;
        private System.Windows.Forms.Label m_label_page_header;
        private System.Windows.Forms.TextBox m_text_box_premises_name;
        private System.Windows.Forms.Label m_label_premises_name;
        private System.Windows.Forms.TextBox m_text_box_premises_city;
        private System.Windows.Forms.Label m_label_premises_city;
        private System.Windows.Forms.TextBox m_text_box_premises_street;
        private System.Windows.Forms.Label m_label_premises_street;
    }
}