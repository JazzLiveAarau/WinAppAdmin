namespace JazzAppAdmin
{
    partial class RequestBandForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestBandForm));
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_delete_request = new System.Windows.Forms.Button();
            this.m_button_edit_request_data = new System.Windows.Forms.Button();
            this.m_label_name = new System.Windows.Forms.Label();
            this.m_text_box_band_name = new System.Windows.Forms.TextBox();
            this.m_label_comments = new System.Windows.Forms.Label();
            this.m_rich_text_box_comments = new System.Windows.Forms.RichTextBox();
            this.m_text_box_www_band = new System.Windows.Forms.TextBox();
            this.m_text_box_sound_sample = new System.Windows.Forms.TextBox();
            this.m_combo_box_audio_1 = new System.Windows.Forms.ComboBox();
            this.m_button_delete_audio_1 = new System.Windows.Forms.Button();
            this.m_button_upload_audio_1 = new System.Windows.Forms.Button();
            this.m_button_download_audio_1 = new System.Windows.Forms.Button();
            this.m_text_box_audio_1 = new System.Windows.Forms.TextBox();
            this.m_combo_box_audio_2 = new System.Windows.Forms.ComboBox();
            this.m_button_delete_audio_2 = new System.Windows.Forms.Button();
            this.m_button_upload_audio_2 = new System.Windows.Forms.Button();
            this.m_button_download_audio_2 = new System.Windows.Forms.Button();
            this.m_text_box_audio_2 = new System.Windows.Forms.TextBox();
            this.m_combo_box_audio_3 = new System.Windows.Forms.ComboBox();
            this.m_button_delete_audio_3 = new System.Windows.Forms.Button();
            this.m_button_upload_audio_3 = new System.Windows.Forms.Button();
            this.m_button_download_audio_3 = new System.Windows.Forms.Button();
            this.m_text_box_audio_3 = new System.Windows.Forms.TextBox();
            this.m_textbox_message = new System.Windows.Forms.TextBox();
            this.m_label_evaluate_band = new System.Windows.Forms.Label();
            this.m_check_box_evaluate_band = new System.Windows.Forms.CheckBox();
            this.m_label_private_notes = new System.Windows.Forms.Label();
            this.m_rich_text_box_private_notes = new System.Windows.Forms.RichTextBox();
            this.m_folder_browser_dialog_audio = new System.Windows.Forms.FolderBrowserDialog();
            this.ToolTipReqForm = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqFormEdit = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqFormCancel = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqFormClose = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqDelete = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqBandName = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqComments = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqPrivateNotes = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqDownloadAudioFiles = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqUploadAudioFiles = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqDeleteAudioFiles = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqAudioFiles = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqFormMsg = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqEvaluate = new System.Windows.Forms.ToolTip(this.components);
            this.m_combo_box_info_files = new System.Windows.Forms.ComboBox();
            this.m_label_info_files = new System.Windows.Forms.Label();
            this.ToolTipReqInfoFiles = new System.Windows.Forms.ToolTip(this.components);
            this.m_button_links = new System.Windows.Forms.Button();
            this.m_combo_box_photo_files = new System.Windows.Forms.ComboBox();
            this.m_label_photo_files = new System.Windows.Forms.Label();
            this.m_combo_box_concert_number = new System.Windows.Forms.ComboBox();
            this.m_label_concert_number = new System.Windows.Forms.Label();
            this.m_button_reg_date_number = new System.Windows.Forms.Button();
            this.ToolTipReqDateButton = new System.Windows.Forms.ToolTip(this.components);
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
            this.m_button_cancel.Location = new System.Drawing.Point(390, 9);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(122, 39);
            this.m_button_cancel.TabIndex = 57;
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
            this.m_button_close.Location = new System.Drawing.Point(528, 9);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(151, 39);
            this.m_button_close.TabIndex = 56;
            this.m_button_close.Text = "Save/Close";
            this.m_button_close.UseVisualStyleBackColor = false;
            this.m_button_close.Click += new System.EventHandler(this.m_button_close_Click);
            // 
            // m_button_delete_request
            // 
            this.m_button_delete_request.BackColor = System.Drawing.Color.Black;
            this.m_button_delete_request.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_delete_request.BackgroundImage")));
            this.m_button_delete_request.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_delete_request.FlatAppearance.BorderSize = 0;
            this.m_button_delete_request.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_delete_request.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_delete_request.ForeColor = System.Drawing.Color.Red;
            this.m_button_delete_request.Image = ((System.Drawing.Image)(resources.GetObject("m_button_delete_request.Image")));
            this.m_button_delete_request.Location = new System.Drawing.Point(76, 9);
            this.m_button_delete_request.Name = "m_button_delete_request";
            this.m_button_delete_request.Size = new System.Drawing.Size(36, 41);
            this.m_button_delete_request.TabIndex = 55;
            this.m_button_delete_request.UseVisualStyleBackColor = false;
            this.m_button_delete_request.Click += new System.EventHandler(this.m_button_delete_request_Click);
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
            this.m_button_edit_request_data.Location = new System.Drawing.Point(8, 9);
            this.m_button_edit_request_data.Name = "m_button_edit_request_data";
            this.m_button_edit_request_data.Size = new System.Drawing.Size(36, 41);
            this.m_button_edit_request_data.TabIndex = 54;
            this.m_button_edit_request_data.UseVisualStyleBackColor = false;
            this.m_button_edit_request_data.Click += new System.EventHandler(this.m_button_edit_request_data_Click);
            // 
            // m_label_name
            // 
            this.m_label_name.AutoSize = true;
            this.m_label_name.BackColor = System.Drawing.Color.Black;
            this.m_label_name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_name.ForeColor = System.Drawing.Color.Red;
            this.m_label_name.Location = new System.Drawing.Point(4, 75);
            this.m_label_name.Name = "m_label_name";
            this.m_label_name.Size = new System.Drawing.Size(63, 24);
            this.m_label_name.TabIndex = 59;
            this.m_label_name.Text = "Name";
            // 
            // m_text_box_band_name
            // 
            this.m_text_box_band_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_text_box_band_name.Location = new System.Drawing.Point(74, 75);
            this.m_text_box_band_name.Name = "m_text_box_band_name";
            this.m_text_box_band_name.Size = new System.Drawing.Size(404, 26);
            this.m_text_box_band_name.TabIndex = 58;
            this.m_text_box_band_name.Text = "  Bandname";
            // 
            // m_label_comments
            // 
            this.m_label_comments.AutoSize = true;
            this.m_label_comments.BackColor = System.Drawing.Color.Black;
            this.m_label_comments.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_comments.ForeColor = System.Drawing.Color.Red;
            this.m_label_comments.Location = new System.Drawing.Point(4, 115);
            this.m_label_comments.Name = "m_label_comments";
            this.m_label_comments.Size = new System.Drawing.Size(130, 24);
            this.m_label_comments.TabIndex = 61;
            this.m_label_comments.Text = "Kommentare";
            // 
            // m_rich_text_box_comments
            // 
            this.m_rich_text_box_comments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rich_text_box_comments.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.m_rich_text_box_comments.Enabled = false;
            this.m_rich_text_box_comments.Location = new System.Drawing.Point(8, 142);
            this.m_rich_text_box_comments.Name = "m_rich_text_box_comments";
            this.m_rich_text_box_comments.Size = new System.Drawing.Size(667, 60);
            this.m_rich_text_box_comments.TabIndex = 60;
            this.m_rich_text_box_comments.Text = "Kommentare, Informationen, ...";
            // 
            // m_text_box_www_band
            // 
            this.m_text_box_www_band.Enabled = false;
            this.m_text_box_www_band.Location = new System.Drawing.Point(634, 552);
            this.m_text_box_www_band.Name = "m_text_box_www_band";
            this.m_text_box_www_band.Size = new System.Drawing.Size(25, 26);
            this.m_text_box_www_band.TabIndex = 93;
            this.m_text_box_www_band.Text = "Webaddress of the band";
            this.m_text_box_www_band.Visible = false;
            // 
            // m_text_box_sound_sample
            // 
            this.m_text_box_sound_sample.Enabled = false;
            this.m_text_box_sound_sample.Location = new System.Drawing.Point(634, 530);
            this.m_text_box_sound_sample.Name = "m_text_box_sound_sample";
            this.m_text_box_sound_sample.Size = new System.Drawing.Size(26, 26);
            this.m_text_box_sound_sample.TabIndex = 92;
            this.m_text_box_sound_sample.Text = "Sound sample";
            this.m_text_box_sound_sample.Visible = false;
            // 
            // m_combo_box_audio_1
            // 
            this.m_combo_box_audio_1.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_audio_1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_audio_1.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_audio_1.FormattingEnabled = true;
            this.m_combo_box_audio_1.Location = new System.Drawing.Point(205, 368);
            this.m_combo_box_audio_1.Name = "m_combo_box_audio_1";
            this.m_combo_box_audio_1.Size = new System.Drawing.Size(406, 27);
            this.m_combo_box_audio_1.TabIndex = 286;
            this.m_combo_box_audio_1.Text = " Ordner, existierende oder neue Datei  wählen";
            // 
            // m_button_delete_audio_1
            // 
            this.m_button_delete_audio_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_delete_audio_1.BackColor = System.Drawing.Color.Black;
            this.m_button_delete_audio_1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_delete_audio_1.FlatAppearance.BorderSize = 0;
            this.m_button_delete_audio_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_delete_audio_1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_delete_audio_1.ForeColor = System.Drawing.Color.Red;
            this.m_button_delete_audio_1.Image = ((System.Drawing.Image)(resources.GetObject("m_button_delete_audio_1.Image")));
            this.m_button_delete_audio_1.Location = new System.Drawing.Point(630, 357);
            this.m_button_delete_audio_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_delete_audio_1.Name = "m_button_delete_audio_1";
            this.m_button_delete_audio_1.Size = new System.Drawing.Size(42, 50);
            this.m_button_delete_audio_1.TabIndex = 285;
            this.m_button_delete_audio_1.UseVisualStyleBackColor = false;
            this.m_button_delete_audio_1.Click += new System.EventHandler(this.m_button_delete_audio_1_Click);
            // 
            // m_button_upload_audio_1
            // 
            this.m_button_upload_audio_1.BackColor = System.Drawing.Color.Black;
            this.m_button_upload_audio_1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_upload_audio_1.FlatAppearance.BorderSize = 0;
            this.m_button_upload_audio_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_upload_audio_1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_upload_audio_1.ForeColor = System.Drawing.Color.Red;
            this.m_button_upload_audio_1.Image = ((System.Drawing.Image)(resources.GetObject("m_button_upload_audio_1.Image")));
            this.m_button_upload_audio_1.Location = new System.Drawing.Point(154, 352);
            this.m_button_upload_audio_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_upload_audio_1.Name = "m_button_upload_audio_1";
            this.m_button_upload_audio_1.Size = new System.Drawing.Size(42, 50);
            this.m_button_upload_audio_1.TabIndex = 284;
            this.m_button_upload_audio_1.UseVisualStyleBackColor = false;
            this.m_button_upload_audio_1.Click += new System.EventHandler(this.m_button_upload_audio_1_Click);
            // 
            // m_button_download_audio_1
            // 
            this.m_button_download_audio_1.BackColor = System.Drawing.Color.Black;
            this.m_button_download_audio_1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_download_audio_1.BackgroundImage")));
            this.m_button_download_audio_1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_download_audio_1.FlatAppearance.BorderSize = 0;
            this.m_button_download_audio_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_download_audio_1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_download_audio_1.ForeColor = System.Drawing.Color.Red;
            this.m_button_download_audio_1.Location = new System.Drawing.Point(10, 357);
            this.m_button_download_audio_1.Name = "m_button_download_audio_1";
            this.m_button_download_audio_1.Size = new System.Drawing.Size(36, 41);
            this.m_button_download_audio_1.TabIndex = 283;
            this.m_button_download_audio_1.UseVisualStyleBackColor = false;
            this.m_button_download_audio_1.Click += new System.EventHandler(this.m_button_download_audio_1_Click);
            // 
            // m_text_box_audio_1
            // 
            this.m_text_box_audio_1.BackColor = System.Drawing.Color.Black;
            this.m_text_box_audio_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_text_box_audio_1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_text_box_audio_1.ForeColor = System.Drawing.Color.Red;
            this.m_text_box_audio_1.Location = new System.Drawing.Point(50, 370);
            this.m_text_box_audio_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_text_box_audio_1.Name = "m_text_box_audio_1";
            this.m_text_box_audio_1.ReadOnly = true;
            this.m_text_box_audio_1.Size = new System.Drawing.Size(101, 23);
            this.m_text_box_audio_1.TabIndex = 282;
            this.m_text_box_audio_1.Text = "Audio 1";
            this.m_text_box_audio_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_combo_box_audio_2
            // 
            this.m_combo_box_audio_2.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_audio_2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_audio_2.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_audio_2.FormattingEnabled = true;
            this.m_combo_box_audio_2.Location = new System.Drawing.Point(205, 426);
            this.m_combo_box_audio_2.Name = "m_combo_box_audio_2";
            this.m_combo_box_audio_2.Size = new System.Drawing.Size(406, 27);
            this.m_combo_box_audio_2.TabIndex = 291;
            this.m_combo_box_audio_2.Text = " Ordner, existierende oder neue Datei  wählen";
            // 
            // m_button_delete_audio_2
            // 
            this.m_button_delete_audio_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_delete_audio_2.BackColor = System.Drawing.Color.Black;
            this.m_button_delete_audio_2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_delete_audio_2.FlatAppearance.BorderSize = 0;
            this.m_button_delete_audio_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_delete_audio_2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_delete_audio_2.ForeColor = System.Drawing.Color.Red;
            this.m_button_delete_audio_2.Image = ((System.Drawing.Image)(resources.GetObject("m_button_delete_audio_2.Image")));
            this.m_button_delete_audio_2.Location = new System.Drawing.Point(630, 415);
            this.m_button_delete_audio_2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_delete_audio_2.Name = "m_button_delete_audio_2";
            this.m_button_delete_audio_2.Size = new System.Drawing.Size(42, 50);
            this.m_button_delete_audio_2.TabIndex = 290;
            this.m_button_delete_audio_2.UseVisualStyleBackColor = false;
            this.m_button_delete_audio_2.Click += new System.EventHandler(this.m_button_delete_audio_2_Click);
            // 
            // m_button_upload_audio_2
            // 
            this.m_button_upload_audio_2.BackColor = System.Drawing.Color.Black;
            this.m_button_upload_audio_2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_upload_audio_2.FlatAppearance.BorderSize = 0;
            this.m_button_upload_audio_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_upload_audio_2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_upload_audio_2.ForeColor = System.Drawing.Color.Red;
            this.m_button_upload_audio_2.Image = ((System.Drawing.Image)(resources.GetObject("m_button_upload_audio_2.Image")));
            this.m_button_upload_audio_2.Location = new System.Drawing.Point(154, 410);
            this.m_button_upload_audio_2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_upload_audio_2.Name = "m_button_upload_audio_2";
            this.m_button_upload_audio_2.Size = new System.Drawing.Size(42, 50);
            this.m_button_upload_audio_2.TabIndex = 289;
            this.m_button_upload_audio_2.UseVisualStyleBackColor = false;
            this.m_button_upload_audio_2.Click += new System.EventHandler(this.m_button_upload_audio_2_Click);
            // 
            // m_button_download_audio_2
            // 
            this.m_button_download_audio_2.BackColor = System.Drawing.Color.Black;
            this.m_button_download_audio_2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_download_audio_2.BackgroundImage")));
            this.m_button_download_audio_2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_download_audio_2.FlatAppearance.BorderSize = 0;
            this.m_button_download_audio_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_download_audio_2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_download_audio_2.ForeColor = System.Drawing.Color.Red;
            this.m_button_download_audio_2.Location = new System.Drawing.Point(10, 415);
            this.m_button_download_audio_2.Name = "m_button_download_audio_2";
            this.m_button_download_audio_2.Size = new System.Drawing.Size(36, 41);
            this.m_button_download_audio_2.TabIndex = 288;
            this.m_button_download_audio_2.UseVisualStyleBackColor = false;
            this.m_button_download_audio_2.Click += new System.EventHandler(this.m_button_download_audio_2_Click);
            // 
            // m_text_box_audio_2
            // 
            this.m_text_box_audio_2.BackColor = System.Drawing.Color.Black;
            this.m_text_box_audio_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_text_box_audio_2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_text_box_audio_2.ForeColor = System.Drawing.Color.Red;
            this.m_text_box_audio_2.Location = new System.Drawing.Point(50, 428);
            this.m_text_box_audio_2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_text_box_audio_2.Name = "m_text_box_audio_2";
            this.m_text_box_audio_2.ReadOnly = true;
            this.m_text_box_audio_2.Size = new System.Drawing.Size(101, 23);
            this.m_text_box_audio_2.TabIndex = 287;
            this.m_text_box_audio_2.Text = "Audio 2";
            this.m_text_box_audio_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_combo_box_audio_3
            // 
            this.m_combo_box_audio_3.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_audio_3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_audio_3.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_audio_3.FormattingEnabled = true;
            this.m_combo_box_audio_3.Location = new System.Drawing.Point(205, 484);
            this.m_combo_box_audio_3.Name = "m_combo_box_audio_3";
            this.m_combo_box_audio_3.Size = new System.Drawing.Size(406, 27);
            this.m_combo_box_audio_3.TabIndex = 296;
            this.m_combo_box_audio_3.Text = " Ordner, existierende oder neue Datei  wählen";
            // 
            // m_button_delete_audio_3
            // 
            this.m_button_delete_audio_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_delete_audio_3.BackColor = System.Drawing.Color.Black;
            this.m_button_delete_audio_3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_delete_audio_3.FlatAppearance.BorderSize = 0;
            this.m_button_delete_audio_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_delete_audio_3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_delete_audio_3.ForeColor = System.Drawing.Color.Red;
            this.m_button_delete_audio_3.Image = ((System.Drawing.Image)(resources.GetObject("m_button_delete_audio_3.Image")));
            this.m_button_delete_audio_3.Location = new System.Drawing.Point(630, 473);
            this.m_button_delete_audio_3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_delete_audio_3.Name = "m_button_delete_audio_3";
            this.m_button_delete_audio_3.Size = new System.Drawing.Size(42, 50);
            this.m_button_delete_audio_3.TabIndex = 295;
            this.m_button_delete_audio_3.UseVisualStyleBackColor = false;
            this.m_button_delete_audio_3.Click += new System.EventHandler(this.m_button_delete_audio_3_Click);
            // 
            // m_button_upload_audio_3
            // 
            this.m_button_upload_audio_3.BackColor = System.Drawing.Color.Black;
            this.m_button_upload_audio_3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_upload_audio_3.FlatAppearance.BorderSize = 0;
            this.m_button_upload_audio_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_upload_audio_3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_upload_audio_3.ForeColor = System.Drawing.Color.Red;
            this.m_button_upload_audio_3.Image = ((System.Drawing.Image)(resources.GetObject("m_button_upload_audio_3.Image")));
            this.m_button_upload_audio_3.Location = new System.Drawing.Point(154, 468);
            this.m_button_upload_audio_3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_upload_audio_3.Name = "m_button_upload_audio_3";
            this.m_button_upload_audio_3.Size = new System.Drawing.Size(42, 50);
            this.m_button_upload_audio_3.TabIndex = 294;
            this.m_button_upload_audio_3.UseVisualStyleBackColor = false;
            this.m_button_upload_audio_3.Click += new System.EventHandler(this.m_button_upload_audio_3_Click);
            // 
            // m_button_download_audio_3
            // 
            this.m_button_download_audio_3.BackColor = System.Drawing.Color.Black;
            this.m_button_download_audio_3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_button_download_audio_3.BackgroundImage")));
            this.m_button_download_audio_3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_download_audio_3.FlatAppearance.BorderSize = 0;
            this.m_button_download_audio_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_download_audio_3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_download_audio_3.ForeColor = System.Drawing.Color.Red;
            this.m_button_download_audio_3.Location = new System.Drawing.Point(10, 473);
            this.m_button_download_audio_3.Name = "m_button_download_audio_3";
            this.m_button_download_audio_3.Size = new System.Drawing.Size(36, 41);
            this.m_button_download_audio_3.TabIndex = 293;
            this.m_button_download_audio_3.UseVisualStyleBackColor = false;
            this.m_button_download_audio_3.Click += new System.EventHandler(this.m_button_download_audio_3_Click);
            // 
            // m_text_box_audio_3
            // 
            this.m_text_box_audio_3.BackColor = System.Drawing.Color.Black;
            this.m_text_box_audio_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_text_box_audio_3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_text_box_audio_3.ForeColor = System.Drawing.Color.Red;
            this.m_text_box_audio_3.Location = new System.Drawing.Point(50, 486);
            this.m_text_box_audio_3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_text_box_audio_3.Name = "m_text_box_audio_3";
            this.m_text_box_audio_3.ReadOnly = true;
            this.m_text_box_audio_3.Size = new System.Drawing.Size(101, 23);
            this.m_text_box_audio_3.TabIndex = 292;
            this.m_text_box_audio_3.Text = "Audio 3";
            this.m_text_box_audio_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_textbox_message
            // 
            this.m_textbox_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textbox_message.BackColor = System.Drawing.Color.Black;
            this.m_textbox_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textbox_message.ForeColor = System.Drawing.Color.Red;
            this.m_textbox_message.Location = new System.Drawing.Point(5, 632);
            this.m_textbox_message.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_textbox_message.Name = "m_textbox_message";
            this.m_textbox_message.ReadOnly = true;
            this.m_textbox_message.Size = new System.Drawing.Size(667, 26);
            this.m_textbox_message.TabIndex = 297;
            this.m_textbox_message.Text = "Messages of all kinds";
            // 
            // m_label_evaluate_band
            // 
            this.m_label_evaluate_band.AutoSize = true;
            this.m_label_evaluate_band.BackColor = System.Drawing.Color.Black;
            this.m_label_evaluate_band.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_evaluate_band.ForeColor = System.Drawing.Color.Red;
            this.m_label_evaluate_band.Location = new System.Drawing.Point(568, 84);
            this.m_label_evaluate_band.Name = "m_label_evaluate_band";
            this.m_label_evaluate_band.Size = new System.Drawing.Size(117, 16);
            this.m_label_evaluate_band.TabIndex = 302;
            this.m_label_evaluate_band.Text = "Zum Evaluieren";
            // 
            // m_check_box_evaluate_band
            // 
            this.m_check_box_evaluate_band.AutoSize = true;
            this.m_check_box_evaluate_band.BackColor = System.Drawing.Color.Black;
            this.m_check_box_evaluate_band.Checked = true;
            this.m_check_box_evaluate_band.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_check_box_evaluate_band.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_check_box_evaluate_band.ForeColor = System.Drawing.Color.Red;
            this.m_check_box_evaluate_band.Location = new System.Drawing.Point(548, 83);
            this.m_check_box_evaluate_band.Name = "m_check_box_evaluate_band";
            this.m_check_box_evaluate_band.Size = new System.Drawing.Size(18, 17);
            this.m_check_box_evaluate_band.TabIndex = 301;
            this.m_check_box_evaluate_band.UseVisualStyleBackColor = false;
            this.m_check_box_evaluate_band.CheckedChanged += new System.EventHandler(this.m_check_box_evaluate_band_CheckedChanged);
            // 
            // m_label_private_notes
            // 
            this.m_label_private_notes.AutoSize = true;
            this.m_label_private_notes.BackColor = System.Drawing.Color.Black;
            this.m_label_private_notes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_private_notes.ForeColor = System.Drawing.Color.Red;
            this.m_label_private_notes.Location = new System.Drawing.Point(6, 213);
            this.m_label_private_notes.Name = "m_label_private_notes";
            this.m_label_private_notes.Size = new System.Drawing.Size(151, 24);
            this.m_label_private_notes.TabIndex = 304;
            this.m_label_private_notes.Text = "Eigene Notizen";
            // 
            // m_rich_text_box_private_notes
            // 
            this.m_rich_text_box_private_notes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rich_text_box_private_notes.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.m_rich_text_box_private_notes.Enabled = false;
            this.m_rich_text_box_private_notes.Location = new System.Drawing.Point(10, 240);
            this.m_rich_text_box_private_notes.Name = "m_rich_text_box_private_notes";
            this.m_rich_text_box_private_notes.Size = new System.Drawing.Size(667, 60);
            this.m_rich_text_box_private_notes.TabIndex = 303;
            this.m_rich_text_box_private_notes.Text = "Eigene (private) Notizen";
            // 
            // m_combo_box_info_files
            // 
            this.m_combo_box_info_files.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_info_files.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_info_files.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_info_files.FormattingEnabled = true;
            this.m_combo_box_info_files.Location = new System.Drawing.Point(205, 535);
            this.m_combo_box_info_files.Name = "m_combo_box_info_files";
            this.m_combo_box_info_files.Size = new System.Drawing.Size(406, 27);
            this.m_combo_box_info_files.TabIndex = 305;
            this.m_combo_box_info_files.Text = "Dokument wählen";
            this.m_combo_box_info_files.SelectedIndexChanged += new System.EventHandler(this.m_combo_box_info_files_SelectedIndexChanged);
            // 
            // m_label_info_files
            // 
            this.m_label_info_files.AutoSize = true;
            this.m_label_info_files.BackColor = System.Drawing.Color.Black;
            this.m_label_info_files.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_info_files.ForeColor = System.Drawing.Color.Red;
            this.m_label_info_files.Location = new System.Drawing.Point(44, 536);
            this.m_label_info_files.Name = "m_label_info_files";
            this.m_label_info_files.Size = new System.Drawing.Size(118, 24);
            this.m_label_info_files.TabIndex = 306;
            this.m_label_info_files.Text = "Information";
            // 
            // m_button_links
            // 
            this.m_button_links.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_links.BackColor = System.Drawing.Color.Black;
            this.m_button_links.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_links.FlatAppearance.BorderSize = 0;
            this.m_button_links.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_links.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_links.ForeColor = System.Drawing.Color.Red;
            this.m_button_links.Location = new System.Drawing.Point(9, 311);
            this.m_button_links.Name = "m_button_links";
            this.m_button_links.Size = new System.Drawing.Size(184, 39);
            this.m_button_links.TabIndex = 307;
            this.m_button_links.Text = "Links";
            this.m_button_links.UseVisualStyleBackColor = false;
            this.m_button_links.Click += new System.EventHandler(this.m_button_links_Click);
            // 
            // m_combo_box_photo_files
            // 
            this.m_combo_box_photo_files.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_photo_files.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_photo_files.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_photo_files.FormattingEnabled = true;
            this.m_combo_box_photo_files.Location = new System.Drawing.Point(205, 585);
            this.m_combo_box_photo_files.Name = "m_combo_box_photo_files";
            this.m_combo_box_photo_files.Size = new System.Drawing.Size(406, 27);
            this.m_combo_box_photo_files.TabIndex = 308;
            this.m_combo_box_photo_files.Text = "Foto wählen";
            this.m_combo_box_photo_files.SelectedIndexChanged += new System.EventHandler(this.m_combo_box_photo_files_SelectedIndexChanged);
            // 
            // m_label_photo_files
            // 
            this.m_label_photo_files.AutoSize = true;
            this.m_label_photo_files.BackColor = System.Drawing.Color.Black;
            this.m_label_photo_files.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_photo_files.ForeColor = System.Drawing.Color.Red;
            this.m_label_photo_files.Location = new System.Drawing.Point(70, 585);
            this.m_label_photo_files.Name = "m_label_photo_files";
            this.m_label_photo_files.Size = new System.Drawing.Size(64, 24);
            this.m_label_photo_files.TabIndex = 309;
            this.m_label_photo_files.Text = "Fotos";
            // 
            // m_combo_box_concert_number
            // 
            this.m_combo_box_concert_number.BackColor = System.Drawing.Color.Black;
            this.m_combo_box_concert_number.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_combo_box_concert_number.ForeColor = System.Drawing.Color.Red;
            this.m_combo_box_concert_number.FormattingEnabled = true;
            this.m_combo_box_concert_number.Location = new System.Drawing.Point(311, 321);
            this.m_combo_box_concert_number.Name = "m_combo_box_concert_number";
            this.m_combo_box_concert_number.Size = new System.Drawing.Size(355, 27);
            this.m_combo_box_concert_number.TabIndex = 310;
            this.m_combo_box_concert_number.Text = "11";
            this.m_combo_box_concert_number.SelectedIndexChanged += new System.EventHandler(this.m_combo_box_concert_number_SelectedIndexChanged);
            // 
            // m_label_concert_number
            // 
            this.m_label_concert_number.AutoSize = true;
            this.m_label_concert_number.BackColor = System.Drawing.Color.Black;
            this.m_label_concert_number.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_concert_number.ForeColor = System.Drawing.Color.Red;
            this.m_label_concert_number.Location = new System.Drawing.Point(201, 323);
            this.m_label_concert_number.Name = "m_label_concert_number";
            this.m_label_concert_number.Size = new System.Drawing.Size(112, 24);
            this.m_label_concert_number.TabIndex = 311;
            this.m_label_concert_number.Text = "Konzert Nr";
            // 
            // m_button_reg_date_number
            // 
            this.m_button_reg_date_number.BackColor = System.Drawing.Color.Black;
            this.m_button_reg_date_number.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_button_reg_date_number.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_reg_date_number.FlatAppearance.BorderSize = 0;
            this.m_button_reg_date_number.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_reg_date_number.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_reg_date_number.ForeColor = System.Drawing.Color.Red;
            this.m_button_reg_date_number.Location = new System.Drawing.Point(152, 16);
            this.m_button_reg_date_number.Name = "m_button_reg_date_number";
            this.m_button_reg_date_number.Size = new System.Drawing.Size(211, 29);
            this.m_button_reg_date_number.TabIndex = 312;
            this.m_button_reg_date_number.Text = "2017-12-28   REQ00001";
            this.m_button_reg_date_number.UseVisualStyleBackColor = false;
            this.m_button_reg_date_number.Click += new System.EventHandler(this.m_button_reg_date_number_Click);
            // 
            // RequestBandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(682, 662);
            this.ControlBox = false;
            this.Controls.Add(this.m_button_reg_date_number);
            this.Controls.Add(this.m_label_concert_number);
            this.Controls.Add(this.m_combo_box_concert_number);
            this.Controls.Add(this.m_label_photo_files);
            this.Controls.Add(this.m_combo_box_photo_files);
            this.Controls.Add(this.m_button_links);
            this.Controls.Add(this.m_label_info_files);
            this.Controls.Add(this.m_combo_box_info_files);
            this.Controls.Add(this.m_label_private_notes);
            this.Controls.Add(this.m_rich_text_box_private_notes);
            this.Controls.Add(this.m_label_evaluate_band);
            this.Controls.Add(this.m_check_box_evaluate_band);
            this.Controls.Add(this.m_textbox_message);
            this.Controls.Add(this.m_combo_box_audio_3);
            this.Controls.Add(this.m_button_delete_audio_3);
            this.Controls.Add(this.m_button_upload_audio_3);
            this.Controls.Add(this.m_button_download_audio_3);
            this.Controls.Add(this.m_text_box_audio_3);
            this.Controls.Add(this.m_combo_box_audio_2);
            this.Controls.Add(this.m_button_delete_audio_2);
            this.Controls.Add(this.m_button_upload_audio_2);
            this.Controls.Add(this.m_button_download_audio_2);
            this.Controls.Add(this.m_text_box_audio_2);
            this.Controls.Add(this.m_combo_box_audio_1);
            this.Controls.Add(this.m_button_delete_audio_1);
            this.Controls.Add(this.m_button_upload_audio_1);
            this.Controls.Add(this.m_button_download_audio_1);
            this.Controls.Add(this.m_text_box_audio_1);
            this.Controls.Add(this.m_text_box_www_band);
            this.Controls.Add(this.m_text_box_sound_sample);
            this.Controls.Add(this.m_label_comments);
            this.Controls.Add(this.m_rich_text_box_comments);
            this.Controls.Add(this.m_label_name);
            this.Controls.Add(this.m_text_box_band_name);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_button_delete_request);
            this.Controls.Add(this.m_button_edit_request_data);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RequestBandForm";
            this.Text = "RequestBandForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_delete_request;
        private System.Windows.Forms.Button m_button_edit_request_data;
        private System.Windows.Forms.Label m_label_name;
        private System.Windows.Forms.TextBox m_text_box_band_name;
        private System.Windows.Forms.Label m_label_comments;
        private System.Windows.Forms.RichTextBox m_rich_text_box_comments;
        private System.Windows.Forms.TextBox m_text_box_www_band;
        private System.Windows.Forms.TextBox m_text_box_sound_sample;
        private System.Windows.Forms.ComboBox m_combo_box_audio_1;
        private System.Windows.Forms.Button m_button_delete_audio_1;
        private System.Windows.Forms.Button m_button_upload_audio_1;
        private System.Windows.Forms.Button m_button_download_audio_1;
        private System.Windows.Forms.TextBox m_text_box_audio_1;
        private System.Windows.Forms.ComboBox m_combo_box_audio_2;
        private System.Windows.Forms.Button m_button_delete_audio_2;
        private System.Windows.Forms.Button m_button_upload_audio_2;
        private System.Windows.Forms.Button m_button_download_audio_2;
        private System.Windows.Forms.TextBox m_text_box_audio_2;
        private System.Windows.Forms.ComboBox m_combo_box_audio_3;
        private System.Windows.Forms.Button m_button_delete_audio_3;
        private System.Windows.Forms.Button m_button_upload_audio_3;
        private System.Windows.Forms.Button m_button_download_audio_3;
        private System.Windows.Forms.TextBox m_text_box_audio_3;
        private System.Windows.Forms.TextBox m_textbox_message;
        private System.Windows.Forms.Label m_label_evaluate_band;
        private System.Windows.Forms.CheckBox m_check_box_evaluate_band;
        private System.Windows.Forms.Label m_label_private_notes;
        private System.Windows.Forms.RichTextBox m_rich_text_box_private_notes;
        private System.Windows.Forms.FolderBrowserDialog m_folder_browser_dialog_audio;
        private System.Windows.Forms.ToolTip ToolTipReqForm;
        private System.Windows.Forms.ToolTip ToolTipReqFormEdit;
        private System.Windows.Forms.ToolTip ToolTipReqFormCancel;
        private System.Windows.Forms.ToolTip ToolTipReqFormClose;
        private System.Windows.Forms.ToolTip ToolTipReqDelete;
        private System.Windows.Forms.ToolTip ToolTipReqBandName;
        private System.Windows.Forms.ToolTip ToolTipReqComments;
        private System.Windows.Forms.ToolTip ToolTipReqPrivateNotes;
        private System.Windows.Forms.ToolTip ToolTipReqDownloadAudioFiles;
        private System.Windows.Forms.ToolTip ToolTipReqUploadAudioFiles;
        private System.Windows.Forms.ToolTip ToolTipReqDeleteAudioFiles;
        private System.Windows.Forms.ToolTip ToolTipReqAudioFiles;
        private System.Windows.Forms.ToolTip ToolTipReqFormMsg;
        private System.Windows.Forms.ToolTip ToolTipReqEvaluate;
        private System.Windows.Forms.ComboBox m_combo_box_info_files;
        private System.Windows.Forms.Label m_label_info_files;
        private System.Windows.Forms.ToolTip ToolTipReqInfoFiles;
        private System.Windows.Forms.Button m_button_links;
        private System.Windows.Forms.ComboBox m_combo_box_photo_files;
        private System.Windows.Forms.Label m_label_photo_files;
        private System.Windows.Forms.ComboBox m_combo_box_concert_number;
        private System.Windows.Forms.Label m_label_concert_number;
        private System.Windows.Forms.Button m_button_reg_date_number;
        private System.Windows.Forms.ToolTip ToolTipReqDateButton;
    }
}