namespace JazzAppAdmin
{
    partial class PhotoPictureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoPictureForm));
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_label_page_header = new System.Windows.Forms.Label();
            this.m_textbox_gallery_number = new System.Windows.Forms.TextBox();
            this.m_textbox_band_name = new System.Windows.Forms.TextBox();
            this.m_textbox_message = new System.Windows.Forms.TextBox();
            this.m_picture_box_big = new System.Windows.Forms.PictureBox();
            this.m_picture_box_small = new System.Windows.Forms.PictureBox();
            this.m_text_box_picture_text = new System.Windows.Forms.TextBox();
            this.m_combo_box_picture_text = new System.Windows.Forms.ComboBox();
            this.m_button_delete_picture = new System.Windows.Forms.Button();
            this.m_button_clear_text = new System.Windows.Forms.Button();
            this.m_label_picture_1 = new System.Windows.Forms.Label();
            this.m_label_picture_2 = new System.Windows.Forms.Label();
            this.m_label_picture_3 = new System.Windows.Forms.Label();
            this.m_label_picture_4 = new System.Windows.Forms.Label();
            this.m_label_picture_5 = new System.Windows.Forms.Label();
            this.m_label_picture_6 = new System.Windows.Forms.Label();
            this.m_label_picture_7 = new System.Windows.Forms.Label();
            this.m_label_picture_8 = new System.Windows.Forms.Label();
            this.m_label_picture_9 = new System.Windows.Forms.Label();
            this.m_panel_picture_labels = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_picture_box_big)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picture_box_small)).BeginInit();
            this.m_panel_picture_labels.SuspendLayout();
            this.SuspendLayout();
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
            this.m_button_close.Location = new System.Drawing.Point(394, 13);
            this.m_button_close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(168, 48);
            this.m_button_close.TabIndex = 271;
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
            this.m_button_cancel.Location = new System.Drawing.Point(230, 13);
            this.m_button_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(159, 48);
            this.m_button_cancel.TabIndex = 270;
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
            this.m_label_page_header.Location = new System.Drawing.Point(12, 80);
            this.m_label_page_header.Name = "m_label_page_header";
            this.m_label_page_header.Size = new System.Drawing.Size(167, 29);
            this.m_label_page_header.TabIndex = 290;
            this.m_label_page_header.Text = "Add a picture";
            // 
            // m_textbox_gallery_number
            // 
            this.m_textbox_gallery_number.BackColor = System.Drawing.Color.Black;
            this.m_textbox_gallery_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textbox_gallery_number.ForeColor = System.Drawing.Color.Red;
            this.m_textbox_gallery_number.Location = new System.Drawing.Point(436, 140);
            this.m_textbox_gallery_number.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_textbox_gallery_number.Name = "m_textbox_gallery_number";
            this.m_textbox_gallery_number.ReadOnly = true;
            this.m_textbox_gallery_number.Size = new System.Drawing.Size(46, 27);
            this.m_textbox_gallery_number.TabIndex = 341;
            this.m_textbox_gallery_number.Text = "G123";
            // 
            // m_textbox_band_name
            // 
            this.m_textbox_band_name.BackColor = System.Drawing.Color.Black;
            this.m_textbox_band_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textbox_band_name.ForeColor = System.Drawing.Color.Red;
            this.m_textbox_band_name.Location = new System.Drawing.Point(97, 140);
            this.m_textbox_band_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_textbox_band_name.Name = "m_textbox_band_name";
            this.m_textbox_band_name.ReadOnly = true;
            this.m_textbox_band_name.Size = new System.Drawing.Size(333, 27);
            this.m_textbox_band_name.TabIndex = 340;
            this.m_textbox_band_name.Text = "Band name";
            // 
            // m_textbox_message
            // 
            this.m_textbox_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textbox_message.BackColor = System.Drawing.Color.Black;
            this.m_textbox_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textbox_message.ForeColor = System.Drawing.Color.Red;
            this.m_textbox_message.Location = new System.Drawing.Point(12, 580);
            this.m_textbox_message.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_textbox_message.Name = "m_textbox_message";
            this.m_textbox_message.ReadOnly = true;
            this.m_textbox_message.Size = new System.Drawing.Size(550, 27);
            this.m_textbox_message.TabIndex = 342;
            this.m_textbox_message.Text = "Messages of all kinds";
            // 
            // m_picture_box_big
            // 
            this.m_picture_box_big.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_picture_box_big.BackgroundImage")));
            this.m_picture_box_big.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_picture_box_big.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_picture_box_big.ErrorImage = null;
            this.m_picture_box_big.InitialImage = ((System.Drawing.Image)(resources.GetObject("m_picture_box_big.InitialImage")));
            this.m_picture_box_big.Location = new System.Drawing.Point(17, 185);
            this.m_picture_box_big.Name = "m_picture_box_big";
            this.m_picture_box_big.Size = new System.Drawing.Size(319, 316);
            this.m_picture_box_big.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.m_picture_box_big.TabIndex = 343;
            this.m_picture_box_big.TabStop = false;
            this.m_picture_box_big.Click += new System.EventHandler(this.m_picture_box_big_Click);
            // 
            // m_picture_box_small
            // 
            this.m_picture_box_small.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_picture_box_small.BackgroundImage")));
            this.m_picture_box_small.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_picture_box_small.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_picture_box_small.ErrorImage = null;
            this.m_picture_box_small.InitialImage = ((System.Drawing.Image)(resources.GetObject("m_picture_box_small.InitialImage")));
            this.m_picture_box_small.Location = new System.Drawing.Point(372, 313);
            this.m_picture_box_small.Name = "m_picture_box_small";
            this.m_picture_box_small.Size = new System.Drawing.Size(140, 136);
            this.m_picture_box_small.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.m_picture_box_small.TabIndex = 344;
            this.m_picture_box_small.TabStop = false;
            this.m_picture_box_small.Click += new System.EventHandler(this.m_picture_box_small_Click);
            // 
            // m_text_box_picture_text
            // 
            this.m_text_box_picture_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_picture_text.Location = new System.Drawing.Point(17, 531);
            this.m_text_box_picture_text.Name = "m_text_box_picture_text";
            this.m_text_box_picture_text.Size = new System.Drawing.Size(495, 27);
            this.m_text_box_picture_text.TabIndex = 345;
            this.m_text_box_picture_text.Text = "Bildtext";
            this.m_text_box_picture_text.TextChanged += new System.EventHandler(this.m_text_box_picture_text_TextChanged);
            // 
            // m_combo_box_picture_text
            // 
            this.m_combo_box_picture_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_combo_box_picture_text.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_picture_text.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_picture_text.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_picture_text.FormattingEnabled = true;
            this.m_combo_box_picture_text.Location = new System.Drawing.Point(360, 474);
            this.m_combo_box_picture_text.Name = "m_combo_box_picture_text";
            this.m_combo_box_picture_text.Size = new System.Drawing.Size(199, 27);
            this.m_combo_box_picture_text.TabIndex = 346;
            this.m_combo_box_picture_text.Text = " Musiker wählen";
            this.m_combo_box_picture_text.SelectedIndexChanged += new System.EventHandler(this.m_combo_box_picture_text_SelectedIndexChanged);
            // 
            // m_button_delete_picture
            // 
            this.m_button_delete_picture.BackColor = System.Drawing.Color.Black;
            this.m_button_delete_picture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_delete_picture.BackgroundImage")));
            this.m_button_delete_picture.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_delete_picture.FlatAppearance.BorderSize = 0;
            this.m_button_delete_picture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_delete_picture.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_delete_picture.ForeColor = System.Drawing.Color.Red;
            this.m_button_delete_picture.Image = ((System.Drawing.Image)(resources.GetObject("m_button_delete_picture.Image")));
            this.m_button_delete_picture.Location = new System.Drawing.Point(81, 15);
            this.m_button_delete_picture.Name = "m_button_delete_picture";
            this.m_button_delete_picture.Size = new System.Drawing.Size(36, 41);
            this.m_button_delete_picture.TabIndex = 347;
            this.m_button_delete_picture.UseVisualStyleBackColor = false;
            this.m_button_delete_picture.Click += new System.EventHandler(this.m_button_delete_picture_Click);
            // 
            // m_button_clear_text
            // 
            this.m_button_clear_text.BackColor = System.Drawing.Color.Black;
            this.m_button_clear_text.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_button_clear_text.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_clear_text.FlatAppearance.BorderSize = 0;
            this.m_button_clear_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_clear_text.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_clear_text.ForeColor = System.Drawing.Color.Red;
            this.m_button_clear_text.Location = new System.Drawing.Point(518, 529);
            this.m_button_clear_text.Name = "m_button_clear_text";
            this.m_button_clear_text.Size = new System.Drawing.Size(45, 29);
            this.m_button_clear_text.TabIndex = 348;
            this.m_button_clear_text.Text = "X";
            this.m_button_clear_text.UseVisualStyleBackColor = false;
            this.m_button_clear_text.Click += new System.EventHandler(this.m_button_clear_text_Click);
            // 
            // m_label_picture_1
            // 
            this.m_label_picture_1.AutoSize = true;
            this.m_label_picture_1.BackColor = System.Drawing.Color.Transparent;
            this.m_label_picture_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_label_picture_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_picture_1.ForeColor = System.Drawing.Color.Red;
            this.m_label_picture_1.Location = new System.Drawing.Point(8, 5);
            this.m_label_picture_1.Name = "m_label_picture_1";
            this.m_label_picture_1.Size = new System.Drawing.Size(23, 26);
            this.m_label_picture_1.TabIndex = 349;
            this.m_label_picture_1.Text = "1";
            // 
            // m_label_picture_2
            // 
            this.m_label_picture_2.AutoSize = true;
            this.m_label_picture_2.BackColor = System.Drawing.Color.Black;
            this.m_label_picture_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_label_picture_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_picture_2.ForeColor = System.Drawing.Color.Red;
            this.m_label_picture_2.Location = new System.Drawing.Point(37, 5);
            this.m_label_picture_2.Name = "m_label_picture_2";
            this.m_label_picture_2.Size = new System.Drawing.Size(23, 26);
            this.m_label_picture_2.TabIndex = 350;
            this.m_label_picture_2.Text = "2";
            // 
            // m_label_picture_3
            // 
            this.m_label_picture_3.AutoSize = true;
            this.m_label_picture_3.BackColor = System.Drawing.Color.Black;
            this.m_label_picture_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_label_picture_3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_picture_3.ForeColor = System.Drawing.Color.Red;
            this.m_label_picture_3.Location = new System.Drawing.Point(66, 5);
            this.m_label_picture_3.Name = "m_label_picture_3";
            this.m_label_picture_3.Size = new System.Drawing.Size(23, 26);
            this.m_label_picture_3.TabIndex = 351;
            this.m_label_picture_3.Text = "3";
            // 
            // m_label_picture_4
            // 
            this.m_label_picture_4.AutoSize = true;
            this.m_label_picture_4.BackColor = System.Drawing.Color.Black;
            this.m_label_picture_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_label_picture_4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_picture_4.ForeColor = System.Drawing.Color.Red;
            this.m_label_picture_4.Location = new System.Drawing.Point(9, 38);
            this.m_label_picture_4.Name = "m_label_picture_4";
            this.m_label_picture_4.Size = new System.Drawing.Size(23, 26);
            this.m_label_picture_4.TabIndex = 352;
            this.m_label_picture_4.Text = "4";
            // 
            // m_label_picture_5
            // 
            this.m_label_picture_5.AutoSize = true;
            this.m_label_picture_5.BackColor = System.Drawing.Color.Black;
            this.m_label_picture_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_label_picture_5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_picture_5.ForeColor = System.Drawing.Color.Red;
            this.m_label_picture_5.Location = new System.Drawing.Point(37, 38);
            this.m_label_picture_5.Name = "m_label_picture_5";
            this.m_label_picture_5.Size = new System.Drawing.Size(23, 26);
            this.m_label_picture_5.TabIndex = 353;
            this.m_label_picture_5.Text = "5";
            // 
            // m_label_picture_6
            // 
            this.m_label_picture_6.AutoSize = true;
            this.m_label_picture_6.BackColor = System.Drawing.Color.Black;
            this.m_label_picture_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_label_picture_6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_picture_6.ForeColor = System.Drawing.Color.Red;
            this.m_label_picture_6.Location = new System.Drawing.Point(66, 38);
            this.m_label_picture_6.Name = "m_label_picture_6";
            this.m_label_picture_6.Size = new System.Drawing.Size(23, 26);
            this.m_label_picture_6.TabIndex = 354;
            this.m_label_picture_6.Text = "6";
            // 
            // m_label_picture_7
            // 
            this.m_label_picture_7.AutoSize = true;
            this.m_label_picture_7.BackColor = System.Drawing.Color.Black;
            this.m_label_picture_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_label_picture_7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_picture_7.ForeColor = System.Drawing.Color.Red;
            this.m_label_picture_7.Location = new System.Drawing.Point(9, 67);
            this.m_label_picture_7.Name = "m_label_picture_7";
            this.m_label_picture_7.Size = new System.Drawing.Size(23, 26);
            this.m_label_picture_7.TabIndex = 355;
            this.m_label_picture_7.Text = "7";
            // 
            // m_label_picture_8
            // 
            this.m_label_picture_8.AutoSize = true;
            this.m_label_picture_8.BackColor = System.Drawing.Color.Black;
            this.m_label_picture_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_label_picture_8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_picture_8.ForeColor = System.Drawing.Color.Red;
            this.m_label_picture_8.Location = new System.Drawing.Point(37, 67);
            this.m_label_picture_8.Name = "m_label_picture_8";
            this.m_label_picture_8.Size = new System.Drawing.Size(23, 26);
            this.m_label_picture_8.TabIndex = 356;
            this.m_label_picture_8.Text = "8";
            // 
            // m_label_picture_9
            // 
            this.m_label_picture_9.AutoSize = true;
            this.m_label_picture_9.BackColor = System.Drawing.Color.Black;
            this.m_label_picture_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_label_picture_9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_picture_9.ForeColor = System.Drawing.Color.Red;
            this.m_label_picture_9.Location = new System.Drawing.Point(66, 67);
            this.m_label_picture_9.Name = "m_label_picture_9";
            this.m_label_picture_9.Size = new System.Drawing.Size(23, 26);
            this.m_label_picture_9.TabIndex = 357;
            this.m_label_picture_9.Text = "9";
            // 
            // m_panel_picture_labels
            // 
            this.m_panel_picture_labels.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_panel_picture_labels.BackgroundImage")));
            this.m_panel_picture_labels.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panel_picture_labels.Controls.Add(this.m_label_picture_6);
            this.m_panel_picture_labels.Controls.Add(this.m_label_picture_9);
            this.m_panel_picture_labels.Controls.Add(this.m_label_picture_1);
            this.m_panel_picture_labels.Controls.Add(this.m_label_picture_8);
            this.m_panel_picture_labels.Controls.Add(this.m_label_picture_2);
            this.m_panel_picture_labels.Controls.Add(this.m_label_picture_7);
            this.m_panel_picture_labels.Controls.Add(this.m_label_picture_3);
            this.m_panel_picture_labels.Controls.Add(this.m_label_picture_4);
            this.m_panel_picture_labels.Controls.Add(this.m_label_picture_5);
            this.m_panel_picture_labels.Location = new System.Drawing.Point(397, 196);
            this.m_panel_picture_labels.Name = "m_panel_picture_labels";
            this.m_panel_picture_labels.Size = new System.Drawing.Size(92, 92);
            this.m_panel_picture_labels.TabIndex = 358;
            // 
            // PhotoPictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(574, 620);
            this.ControlBox = false;
            this.Controls.Add(this.m_panel_picture_labels);
            this.Controls.Add(this.m_button_clear_text);
            this.Controls.Add(this.m_button_delete_picture);
            this.Controls.Add(this.m_combo_box_picture_text);
            this.Controls.Add(this.m_text_box_picture_text);
            this.Controls.Add(this.m_picture_box_small);
            this.Controls.Add(this.m_picture_box_big);
            this.Controls.Add(this.m_textbox_message);
            this.Controls.Add(this.m_textbox_gallery_number);
            this.Controls.Add(this.m_textbox_band_name);
            this.Controls.Add(this.m_label_page_header);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_button_cancel);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PhotoPictureForm";
            this.Text = "PhotoPictureForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhotoPictureForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.m_picture_box_big)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picture_box_small)).EndInit();
            this.m_panel_picture_labels.ResumeLayout(false);
            this.m_panel_picture_labels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Label m_label_page_header;
        private System.Windows.Forms.TextBox m_textbox_gallery_number;
        private System.Windows.Forms.TextBox m_textbox_band_name;
        private System.Windows.Forms.TextBox m_textbox_message;
        private System.Windows.Forms.PictureBox m_picture_box_big;
        private System.Windows.Forms.PictureBox m_picture_box_small;
        private System.Windows.Forms.TextBox m_text_box_picture_text;
        private System.Windows.Forms.ComboBox m_combo_box_picture_text;
        private System.Windows.Forms.Button m_button_delete_picture;
        private System.Windows.Forms.Button m_button_clear_text;
        private System.Windows.Forms.Label m_label_picture_1;
        private System.Windows.Forms.Label m_label_picture_2;
        private System.Windows.Forms.Label m_label_picture_3;
        private System.Windows.Forms.Label m_label_picture_4;
        private System.Windows.Forms.Label m_label_picture_5;
        private System.Windows.Forms.Label m_label_picture_6;
        private System.Windows.Forms.Label m_label_picture_7;
        private System.Windows.Forms.Label m_label_picture_8;
        private System.Windows.Forms.Label m_label_picture_9;
        private System.Windows.Forms.Panel m_panel_picture_labels;
    }
}