namespace JazzAppAdmin
{
    partial class RequestDateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestDateForm));
            this.m_button_edit_request_data = new System.Windows.Forms.Button();
            this.m_button_close = new System.Windows.Forms.Button();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_textbox_message = new System.Windows.Forms.TextBox();
            this.m_label_reg_date_number = new System.Windows.Forms.Label();
            this.TitleRequestDateForm = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqMainCheckinCheckout = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqFormCancel = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqFormClose = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqFormMsg = new System.Windows.Forms.ToolTip(this.components);
            this.m_date_time_picker = new System.Windows.Forms.DateTimePicker();
            this.ToolTipReqDateTimePicker = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTipReqDateLabel = new System.Windows.Forms.ToolTip(this.components);
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
            this.m_button_edit_request_data.Location = new System.Drawing.Point(4, 7);
            this.m_button_edit_request_data.Name = "m_button_edit_request_data";
            this.m_button_edit_request_data.Size = new System.Drawing.Size(36, 41);
            this.m_button_edit_request_data.TabIndex = 268;
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
            this.m_button_close.Location = new System.Drawing.Point(374, 5);
            this.m_button_close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_close.Name = "m_button_close";
            this.m_button_close.Size = new System.Drawing.Size(168, 48);
            this.m_button_close.TabIndex = 267;
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
            this.m_button_cancel.Location = new System.Drawing.Point(210, 5);
            this.m_button_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(159, 48);
            this.m_button_cancel.TabIndex = 266;
            this.m_button_cancel.Text = "Cancel";
            this.m_button_cancel.UseVisualStyleBackColor = false;
            this.m_button_cancel.Click += new System.EventHandler(this.m_button_cancel_Click);
            // 
            // m_textbox_message
            // 
            this.m_textbox_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textbox_message.BackColor = System.Drawing.Color.Black;
            this.m_textbox_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_textbox_message.ForeColor = System.Drawing.Color.Red;
            this.m_textbox_message.Location = new System.Drawing.Point(4, 128);
            this.m_textbox_message.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_textbox_message.Name = "m_textbox_message";
            this.m_textbox_message.ReadOnly = true;
            this.m_textbox_message.Size = new System.Drawing.Size(532, 27);
            this.m_textbox_message.TabIndex = 273;
            this.m_textbox_message.Text = "Messages of all kinds";
            // 
            // m_label_reg_date_number
            // 
            this.m_label_reg_date_number.AutoSize = true;
            this.m_label_reg_date_number.BackColor = System.Drawing.Color.Black;
            this.m_label_reg_date_number.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_label_reg_date_number.ForeColor = System.Drawing.Color.Red;
            this.m_label_reg_date_number.Location = new System.Drawing.Point(12, 81);
            this.m_label_reg_date_number.Name = "m_label_reg_date_number";
            this.m_label_reg_date_number.Size = new System.Drawing.Size(189, 19);
            this.m_label_reg_date_number.TabIndex = 274;
            this.m_label_reg_date_number.Text = "2017-12-28   REQ00001";
            // 
            // m_date_time_picker
            // 
            this.m_date_time_picker.CalendarFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_date_time_picker.CalendarForeColor = System.Drawing.Color.Red;
            this.m_date_time_picker.CalendarTitleForeColor = System.Drawing.Color.Red;
            this.m_date_time_picker.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_date_time_picker.Location = new System.Drawing.Point(244, 77);
            this.m_date_time_picker.Name = "m_date_time_picker";
            this.m_date_time_picker.Size = new System.Drawing.Size(111, 26);
            this.m_date_time_picker.TabIndex = 275;
            this.m_date_time_picker.Value = new System.DateTime(2018, 2, 4, 0, 0, 0, 0);
            this.m_date_time_picker.ValueChanged += new System.EventHandler(this.m_date_time_picker_ValueChanged);
            this.m_date_time_picker.DropDown += new System.EventHandler(this.m_date_time_picker_DropDown);
            // 
            // RequestDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(546, 168);
            this.ControlBox = false;
            this.Controls.Add(this.m_date_time_picker);
            this.Controls.Add(this.m_label_reg_date_number);
            this.Controls.Add(this.m_textbox_message);
            this.Controls.Add(this.m_button_edit_request_data);
            this.Controls.Add(this.m_button_close);
            this.Controls.Add(this.m_button_cancel);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RequestDateForm";
            this.Text = "RequestDateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_button_edit_request_data;
        private System.Windows.Forms.Button m_button_close;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.TextBox m_textbox_message;
        private System.Windows.Forms.Label m_label_reg_date_number;
        private System.Windows.Forms.ToolTip TitleRequestDateForm;
        private System.Windows.Forms.ToolTip ToolTipReqMainCheckinCheckout;
        private System.Windows.Forms.ToolTip ToolTipReqFormCancel;
        private System.Windows.Forms.ToolTip ToolTipReqFormClose;
        private System.Windows.Forms.ToolTip ToolTipReqFormMsg;
        private System.Windows.Forms.DateTimePicker m_date_time_picker;
        private System.Windows.Forms.ToolTip ToolTipReqDateTimePicker;
        private System.Windows.Forms.ToolTip ToolTipReqDateLabel;
    }
}