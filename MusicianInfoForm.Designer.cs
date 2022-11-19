namespace JazzAppAdmin
{
    partial class MusicianInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicianInfoForm));
            this.m_label_page_header = new System.Windows.Forms.Label();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_edit_concert_data = new System.Windows.Forms.Button();
            this.m_label_contact_member = new System.Windows.Forms.Label();
            this.m_combo_box_contact_member = new System.Windows.Forms.ComboBox();
            this.m_text_box_unload_street = new System.Windows.Forms.TextBox();
            this.m_label_unload_street = new System.Windows.Forms.Label();
            this.m_label_unload_city = new System.Windows.Forms.Label();
            this.m_label_parking_one = new System.Windows.Forms.Label();
            this.m_label_parking_two = new System.Windows.Forms.Label();
            this.m_text_box_unload_city = new System.Windows.Forms.TextBox();
            this.m_text_box_parking_one = new System.Windows.Forms.TextBox();
            this.m_text_box_parking_two = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_label_page_header
            // 
            this.m_label_page_header.AutoSize = true;
            this.m_label_page_header.BackColor = System.Drawing.Color.Black;
            this.m_label_page_header.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_page_header.ForeColor = System.Drawing.Color.Red;
            this.m_label_page_header.Location = new System.Drawing.Point(10, 62);
            this.m_label_page_header.Name = "m_label_page_header";
            this.m_label_page_header.Size = new System.Drawing.Size(205, 22);
            this.m_label_page_header.TabIndex = 3;
            this.m_label_page_header.Text = "Musician information";
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
            this.m_button_cancel.Location = new System.Drawing.Point(127, 12);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(122, 39);
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
            this.m_button_close.Location = new System.Drawing.Point(267, 12);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(159, 39);
            this.m_button_close.TabIndex = 2;
            this.m_button_close.Text = "Save/Close";
            this.m_button_close.UseVisualStyleBackColor = false;
            this.m_button_close.Click += new System.EventHandler(this.m_button_close_Click);
            // 
            // m_button_edit_concert_data
            // 
            this.m_button_edit_concert_data.BackColor = System.Drawing.Color.Black;
            this.m_button_edit_concert_data.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_edit_concert_data.BackgroundImage")));
            this.m_button_edit_concert_data.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_edit_concert_data.FlatAppearance.BorderSize = 0;
            this.m_button_edit_concert_data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_edit_concert_data.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_edit_concert_data.ForeColor = System.Drawing.Color.Red;
            this.m_button_edit_concert_data.Location = new System.Drawing.Point(15, 9);
            this.m_button_edit_concert_data.Name = "m_button_edit_concert_data";
            this.m_button_edit_concert_data.Size = new System.Drawing.Size(36, 41);
            this.m_button_edit_concert_data.TabIndex = 0;
            this.m_button_edit_concert_data.UseVisualStyleBackColor = false;
            this.m_button_edit_concert_data.Click += new System.EventHandler(this.m_button_edit_concert_data_Click);
            // 
            // m_label_contact_member
            // 
            this.m_label_contact_member.AutoSize = true;
            this.m_label_contact_member.BackColor = System.Drawing.Color.Black;
            this.m_label_contact_member.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_contact_member.ForeColor = System.Drawing.Color.Red;
            this.m_label_contact_member.Location = new System.Drawing.Point(11, 116);
            this.m_label_contact_member.Name = "m_label_contact_member";
            this.m_label_contact_member.Size = new System.Drawing.Size(127, 19);
            this.m_label_contact_member.TabIndex = 4;
            this.m_label_contact_member.Text = "Contact person";
            // 
            // m_combo_box_contact_member
            // 
            this.m_combo_box_contact_member.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_contact_member.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_contact_member.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_contact_member.FormattingEnabled = true;
            this.m_combo_box_contact_member.Location = new System.Drawing.Point(15, 143);
            this.m_combo_box_contact_member.Name = "m_combo_box_contact_member";
            this.m_combo_box_contact_member.Size = new System.Drawing.Size(184, 24);
            this.m_combo_box_contact_member.TabIndex = 5;
            this.m_combo_box_contact_member.Text = "Member  1";
            // 
            // m_text_box_unload_street
            // 
            this.m_text_box_unload_street.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_unload_street.Location = new System.Drawing.Point(11, 203);
            this.m_text_box_unload_street.Name = "m_text_box_unload_street";
            this.m_text_box_unload_street.Size = new System.Drawing.Size(415, 23);
            this.m_text_box_unload_street.TabIndex = 7;
            this.m_text_box_unload_street.Text = "Ochsengässli";
            // 
            // m_label_unload_street
            // 
            this.m_label_unload_street.AutoSize = true;
            this.m_label_unload_street.BackColor = System.Drawing.Color.Black;
            this.m_label_unload_street.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_unload_street.ForeColor = System.Drawing.Color.Red;
            this.m_label_unload_street.Location = new System.Drawing.Point(11, 178);
            this.m_label_unload_street.Name = "m_label_unload_street";
            this.m_label_unload_street.Size = new System.Drawing.Size(111, 19);
            this.m_label_unload_street.TabIndex = 6;
            this.m_label_unload_street.Text = "Unload street";
            // 
            // m_label_unload_city
            // 
            this.m_label_unload_city.AutoSize = true;
            this.m_label_unload_city.BackColor = System.Drawing.Color.Black;
            this.m_label_unload_city.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_unload_city.ForeColor = System.Drawing.Color.Red;
            this.m_label_unload_city.Location = new System.Drawing.Point(7, 242);
            this.m_label_unload_city.Name = "m_label_unload_city";
            this.m_label_unload_city.Size = new System.Drawing.Size(95, 19);
            this.m_label_unload_city.TabIndex = 8;
            this.m_label_unload_city.Text = "Unload city";
            // 
            // m_label_parking_one
            // 
            this.m_label_parking_one.AutoSize = true;
            this.m_label_parking_one.BackColor = System.Drawing.Color.Black;
            this.m_label_parking_one.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_parking_one.ForeColor = System.Drawing.Color.Red;
            this.m_label_parking_one.Location = new System.Drawing.Point(7, 301);
            this.m_label_parking_one.Name = "m_label_parking_one";
            this.m_label_parking_one.Size = new System.Drawing.Size(106, 19);
            this.m_label_parking_one.TabIndex = 10;
            this.m_label_parking_one.Text = "Parking tone";
            // 
            // m_label_parking_two
            // 
            this.m_label_parking_two.AutoSize = true;
            this.m_label_parking_two.BackColor = System.Drawing.Color.Black;
            this.m_label_parking_two.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_parking_two.ForeColor = System.Drawing.Color.Red;
            this.m_label_parking_two.Location = new System.Drawing.Point(7, 361);
            this.m_label_parking_two.Name = "m_label_parking_two";
            this.m_label_parking_two.Size = new System.Drawing.Size(100, 19);
            this.m_label_parking_two.TabIndex = 12;
            this.m_label_parking_two.Text = "Parking two";
            // 
            // m_text_box_unload_city
            // 
            this.m_text_box_unload_city.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_unload_city.Location = new System.Drawing.Point(11, 269);
            this.m_text_box_unload_city.Name = "m_text_box_unload_city";
            this.m_text_box_unload_city.Size = new System.Drawing.Size(415, 23);
            this.m_text_box_unload_city.TabIndex = 9;
            this.m_text_box_unload_city.Text = "Aarau";
            // 
            // m_text_box_parking_one
            // 
            this.m_text_box_parking_one.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_parking_one.Location = new System.Drawing.Point(8, 328);
            this.m_text_box_parking_one.Name = "m_text_box_parking_one";
            this.m_text_box_parking_one.Size = new System.Drawing.Size(415, 23);
            this.m_text_box_parking_one.TabIndex = 11;
            this.m_text_box_parking_one.Text = "Parkhaus Flösserplatz";
            // 
            // m_text_box_parking_two
            // 
            this.m_text_box_parking_two.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_parking_two.Location = new System.Drawing.Point(8, 388);
            this.m_text_box_parking_two.Name = "m_text_box_parking_two";
            this.m_text_box_parking_two.Size = new System.Drawing.Size(415, 23);
            this.m_text_box_parking_two.TabIndex = 13;
            this.m_text_box_parking_two.Text = "Kasernen-Parking, Laurenzenvorstadt";
            // 
            // MusicianInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(435, 435);
            this.ControlBox = false;
            this.Controls.Add(this.m_text_box_parking_two);
            this.Controls.Add(this.m_text_box_parking_one);
            this.Controls.Add(this.m_text_box_unload_city);
            this.Controls.Add(this.m_label_parking_two);
            this.Controls.Add(this.m_label_parking_one);
            this.Controls.Add(this.m_label_unload_city);
            this.Controls.Add(this.m_text_box_unload_street);
            this.Controls.Add(this.m_label_unload_street);
            this.Controls.Add(this.m_combo_box_contact_member);
            this.Controls.Add(this.m_label_contact_member);
            this.Controls.Add(this.m_label_page_header);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_button_edit_concert_data);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MusicianInfoForm";
            this.Text = "Musician Info Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_label_page_header;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_edit_concert_data;
        private System.Windows.Forms.Label m_label_contact_member;
        private System.Windows.Forms.ComboBox m_combo_box_contact_member;
        private System.Windows.Forms.TextBox m_text_box_unload_street;
        private System.Windows.Forms.Label m_label_unload_street;
        private System.Windows.Forms.Label m_label_unload_city;
        private System.Windows.Forms.Label m_label_parking_one;
        private System.Windows.Forms.Label m_label_parking_two;
        private System.Windows.Forms.TextBox m_text_box_unload_city;
        private System.Windows.Forms.TextBox m_text_box_parking_one;
        private System.Windows.Forms.TextBox m_text_box_parking_two;
    }
}