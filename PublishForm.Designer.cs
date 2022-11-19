namespace JazzAppAdmin
{
    partial class PublishForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublishForm));
            this.m_label_page_header = new System.Windows.Forms.Label();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_edit_concert_data = new System.Windows.Forms.Button();
            this.m_text_box_autumn_year = new System.Windows.Forms.TextBox();
            this.m_label_autumn_year = new System.Windows.Forms.Label();
            this.m_label_spring_year = new System.Windows.Forms.Label();
            this.m_text_box_spring_year = new System.Windows.Forms.TextBox();
            this.m_label_publish = new System.Windows.Forms.Label();
            this.m_check_box_publish = new System.Windows.Forms.CheckBox();
            this.m_label_website_current_season = new System.Windows.Forms.Label();
            this.m_check_box_website_current_season = new System.Windows.Forms.CheckBox();
            this.ToolTipPublish = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipConcertEdit = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipConcertCancel = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipConcertClose = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipCurrentSeason = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipAutumnSpringYear = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // m_label_page_header
            // 
            this.m_label_page_header.AutoSize = true;
            this.m_label_page_header.BackColor = System.Drawing.Color.Black;
            this.m_label_page_header.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_page_header.ForeColor = System.Drawing.Color.Red;
            this.m_label_page_header.Location = new System.Drawing.Point(14, 62);
            this.m_label_page_header.Name = "m_label_page_header";
            this.m_label_page_header.Size = new System.Drawing.Size(80, 22);
            this.m_label_page_header.TabIndex = 119;
            this.m_label_page_header.Text = "Publish";
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
            this.m_button_cancel.Location = new System.Drawing.Point(118, 12);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(122, 39);
            this.m_button_cancel.TabIndex = 118;
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
            this.m_button_close.Location = new System.Drawing.Point(258, 12);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(162, 39);
            this.m_button_close.TabIndex = 117;
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
            this.m_button_edit_concert_data.Location = new System.Drawing.Point(19, 9);
            this.m_button_edit_concert_data.Name = "m_button_edit_concert_data";
            this.m_button_edit_concert_data.Size = new System.Drawing.Size(36, 41);
            this.m_button_edit_concert_data.TabIndex = 116;
            this.m_button_edit_concert_data.UseVisualStyleBackColor = false;
            this.m_button_edit_concert_data.Click += new System.EventHandler(this.m_button_edit_concert_data_Click);
            // 
            // m_text_box_autumn_year
            // 
            this.m_text_box_autumn_year.Location = new System.Drawing.Point(271, 165);
            this.m_text_box_autumn_year.Name = "m_text_box_autumn_year";
            this.m_text_box_autumn_year.Size = new System.Drawing.Size(63, 23);
            this.m_text_box_autumn_year.TabIndex = 121;
            this.m_text_box_autumn_year.Text = "2017";
            // 
            // m_label_autumn_year
            // 
            this.m_label_autumn_year.AutoSize = true;
            this.m_label_autumn_year.BackColor = System.Drawing.Color.Black;
            this.m_label_autumn_year.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_autumn_year.ForeColor = System.Drawing.Color.Red;
            this.m_label_autumn_year.Location = new System.Drawing.Point(98, 164);
            this.m_label_autumn_year.Name = "m_label_autumn_year";
            this.m_label_autumn_year.Size = new System.Drawing.Size(106, 19);
            this.m_label_autumn_year.TabIndex = 120;
            this.m_label_autumn_year.Text = "Autumn year";
            // 
            // m_label_spring_year
            // 
            this.m_label_spring_year.AutoSize = true;
            this.m_label_spring_year.BackColor = System.Drawing.Color.Black;
            this.m_label_spring_year.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_spring_year.ForeColor = System.Drawing.Color.Red;
            this.m_label_spring_year.Location = new System.Drawing.Point(98, 205);
            this.m_label_spring_year.Name = "m_label_spring_year";
            this.m_label_spring_year.Size = new System.Drawing.Size(97, 19);
            this.m_label_spring_year.TabIndex = 122;
            this.m_label_spring_year.Text = "Spring year";
            // 
            // m_text_box_spring_year
            // 
            this.m_text_box_spring_year.Location = new System.Drawing.Point(271, 202);
            this.m_text_box_spring_year.Name = "m_text_box_spring_year";
            this.m_text_box_spring_year.Size = new System.Drawing.Size(63, 23);
            this.m_text_box_spring_year.TabIndex = 123;
            this.m_text_box_spring_year.Text = "2018";
            // 
            // m_label_publish
            // 
            this.m_label_publish.AutoSize = true;
            this.m_label_publish.BackColor = System.Drawing.Color.Black;
            this.m_label_publish.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_publish.ForeColor = System.Drawing.Color.Red;
            this.m_label_publish.Location = new System.Drawing.Point(133, 106);
            this.m_label_publish.Name = "m_label_publish";
            this.m_label_publish.Size = new System.Drawing.Size(196, 19);
            this.m_label_publish.TabIndex = 190;
            this.m_label_publish.Text = "Publish season program";
            // 
            // m_check_box_publish
            // 
            this.m_check_box_publish.AutoSize = true;
            this.m_check_box_publish.BackColor = System.Drawing.Color.Black;
            this.m_check_box_publish.Checked = true;
            this.m_check_box_publish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_check_box_publish.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_check_box_publish.ForeColor = System.Drawing.Color.Red;
            this.m_check_box_publish.Location = new System.Drawing.Point(102, 109);
            this.m_check_box_publish.Name = "m_check_box_publish";
            this.m_check_box_publish.Size = new System.Drawing.Size(15, 14);
            this.m_check_box_publish.TabIndex = 189;
            this.m_check_box_publish.UseVisualStyleBackColor = false;
            // 
            // m_label_website_current_season
            // 
            this.m_label_website_current_season.AutoSize = true;
            this.m_label_website_current_season.BackColor = System.Drawing.Color.Black;
            this.m_label_website_current_season.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_website_current_season.ForeColor = System.Drawing.Color.Red;
            this.m_label_website_current_season.Location = new System.Drawing.Point(133, 259);
            this.m_label_website_current_season.Name = "m_label_website_current_season";
            this.m_label_website_current_season.Size = new System.Drawing.Size(190, 19);
            this.m_label_website_current_season.TabIndex = 191;
            this.m_label_website_current_season.Text = "Current website season";
            // 
            // m_check_box_website_current_season
            // 
            this.m_check_box_website_current_season.AutoSize = true;
            this.m_check_box_website_current_season.BackColor = System.Drawing.Color.Black;
            this.m_check_box_website_current_season.Checked = true;
            this.m_check_box_website_current_season.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_check_box_website_current_season.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_check_box_website_current_season.ForeColor = System.Drawing.Color.Red;
            this.m_check_box_website_current_season.Location = new System.Drawing.Point(97, 263);
            this.m_check_box_website_current_season.Name = "m_check_box_website_current_season";
            this.m_check_box_website_current_season.Size = new System.Drawing.Size(15, 14);
            this.m_check_box_website_current_season.TabIndex = 192;
            this.m_check_box_website_current_season.UseVisualStyleBackColor = false;
            // 
            // PublishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(432, 308);
            this.ControlBox = false;
            this.Controls.Add(this.m_check_box_website_current_season);
            this.Controls.Add(this.m_label_website_current_season);
            this.Controls.Add(this.m_label_publish);
            this.Controls.Add(this.m_check_box_publish);
            this.Controls.Add(this.m_text_box_spring_year);
            this.Controls.Add(this.m_label_spring_year);
            this.Controls.Add(this.m_text_box_autumn_year);
            this.Controls.Add(this.m_label_autumn_year);
            this.Controls.Add(this.m_label_page_header);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_button_edit_concert_data);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PublishForm";
            this.Text = "Publish Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_label_page_header;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_edit_concert_data;
        private System.Windows.Forms.TextBox m_text_box_autumn_year;
        private System.Windows.Forms.Label m_label_autumn_year;
        private System.Windows.Forms.Label m_label_spring_year;
        private System.Windows.Forms.TextBox m_text_box_spring_year;
        private System.Windows.Forms.Label m_label_publish;
        private System.Windows.Forms.CheckBox m_check_box_publish;
        private System.Windows.Forms.Label m_label_website_current_season;
        private System.Windows.Forms.CheckBox m_check_box_website_current_season;
        private System.Windows.Forms.ToolTip ToolTipPublish;
        private System.Windows.Forms.ToolTip ToolTipConcertEdit;
        private System.Windows.Forms.ToolTip ToolTipConcertCancel;
        private System.Windows.Forms.ToolTip ToolTipConcertClose;
        private System.Windows.Forms.ToolTip ToolTipCurrentSeason;
        private System.Windows.Forms.ToolTip ToolTipAutumnSpringYear;
    }
}