namespace JazzAppAdmin
{
    partial class SelectSeasonForm
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
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_add_season = new System.Windows.Forms.Button();
            this.m_combo_box_season = new System.Windows.Forms.ComboBox();
            this.m_label_select_season = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_button_close
            // 
            this.m_button_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_close.BackColor = System.Drawing.Color.Black;
            this.m_button_close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_close.FlatAppearance.BorderSize = 0;
            this.m_button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_close.ForeColor = System.Drawing.Color.Red;
            this.m_button_close.Location = new System.Drawing.Point(270, 174);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(65, 26);
            this.m_button_close.TabIndex = 26;
            this.m_button_close.Text = "Close";
            this.m_button_close.UseVisualStyleBackColor = false;
            this.m_button_close.Click += new System.EventHandler(this.m_button_close_Click);
            // 
            // m_button_add_season
            // 
            this.m_button_add_season.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_add_season.BackColor = System.Drawing.Color.Black;
            this.m_button_add_season.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_button_add_season.FlatAppearance.BorderSize = 0;
            this.m_button_add_season.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_button_add_season.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_button_add_season.ForeColor = System.Drawing.Color.Red;
            this.m_button_add_season.Location = new System.Drawing.Point(0, 103);
            this.m_button_add_season.Name = "m_button_add_season";
            this.m_button_add_season.Size = new System.Drawing.Size(347, 46);
            this.m_button_add_season.TabIndex = 27;
            this.m_button_add_season.Text = "Add Season XML";
            this.m_button_add_season.UseVisualStyleBackColor = false;
            this.m_button_add_season.Click += new System.EventHandler(this.m_button_add_season_Click);
            // 
            // m_combo_box_season
            // 
            this.m_combo_box_season.FormattingEnabled = true;
            this.m_combo_box_season.Location = new System.Drawing.Point(12, 42);
            this.m_combo_box_season.Name = "m_combo_box_season";
            this.m_combo_box_season.Size = new System.Drawing.Size(309, 27);
            this.m_combo_box_season.TabIndex = 28;
            this.m_combo_box_season.Text = "Season_2015_2016";
            // 
            // m_label_select_season
            // 
            this.m_label_select_season.AutoSize = true;
            this.m_label_select_season.BackColor = System.Drawing.Color.Black;
            this.m_label_select_season.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_select_season.ForeColor = System.Drawing.Color.Red;
            this.m_label_select_season.Location = new System.Drawing.Point(12, 9);
            this.m_label_select_season.Name = "m_label_select_season";
            this.m_label_select_season.Size = new System.Drawing.Size(142, 24);
            this.m_label_select_season.TabIndex = 29;
            this.m_label_select_season.Text = "Select season";
            // 
            // SelectSeasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(347, 212);
            this.ControlBox = false;
            this.Controls.Add(this.m_label_select_season);
            this.Controls.Add(this.m_combo_box_season);
            this.Controls.Add(this.m_button_add_season);
            this.Controls.Add(this.m_button_close);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SelectSeasonForm";
            this.Text = "Select Season Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_add_season;
        private System.Windows.Forms.ComboBox m_combo_box_season;
        private System.Windows.Forms.Label m_label_select_season;
    }
}