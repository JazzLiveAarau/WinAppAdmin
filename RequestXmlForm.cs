using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Edit requests page text</summary>
    public partial class RequestXmlForm : Form
    {
        /// <summary>The owner of this form</summary>
        private IndexForm m_index_form = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Flag telling if the dialog controls are being initialized</summary>
        private bool m_initializing = false;

        /// <summary>Constructor</summary>
        public RequestXmlForm(IndexForm i_index_form)
        {
            InitializeComponent();

            if (null == i_index_form)
                return;

            m_index_form = i_index_form;

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            SetTitles();

            _SetCheckBoxes();

            SetTexts();

            _SetComboBoxes();

            SetEditable();

            SetCaptions();

            _SetToolTips();

        } // constructor

        /// <summary>Set captions</summary>
        private void SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // SetCaptions

        /// <summary>Set titles</summary>
        private void SetTitles()
        {
            this.Text = AdminUtils.GetTitleFormText(RequestXml.GetTitlePage());
            this.m_label_page_header.Text = RequestXml.GetTitlePage();
            this.m_label_request_header.Text = RequestXml.GetLabelRequestHeader();
            this.m_label_request_display_dates.Text = RequestXml.GetLabelDisplayNextSeasonConcertDates();
            this.m_label_no_dates_text.Text = RequestXml.GetLabelNoDates();
            this.m_label_dates_text.Text = RequestXml.GetLabelDatesText();
            this.m_label_required_data.Text = RequestXml.GetLabelRequiredData();
            this.m_label_end_paragraph.Text = RequestXml.GetLabelEndParagraph();
            this.m_label_email_title.Text = RequestXml.GetLabelEmailTitle();
            this.m_label_email_address.Text = RequestXml.GetLabelEmailAddress();
            this.m_label_email_caption.Text = RequestXml.GetLabelEmailCaption();
            this.m_label_email_remark.Text = RequestXml.GetLabelEmailRemark();

        } // SetTitles

        /// <summary>Set texts</summary>
        private void SetTexts()
        {
            this.m_text_box_request_header.Text = RequestXml.GetRequestXmlHeader();
            this.m_rich_text_box_no_dates.Text = RequestXml.GetRequestNoDates();
            this.m_rich_text_box_dates_text.Text = RequestXml.GetRequestDatesText();
            this.m_rich_text_box_required_data_text.Text = RequestXml.GetRequiredDataText();
            this.m_rich_text_box_end_paragraph.Text = RequestXml.GetRequestEndParagraph();
            this.m_rich_text_box_required_item.Text = RequestStrings.RequiredDataNotSelected;
            this.m_text_box_email_title.Text = RequestXml.GetRequestEmailTitle();
            this.m_text_box_email_address.Text = RequestXml.GetRequestEmailAddress();
            this.m_text_box_email_caption.Text = RequestXml.GetRequestEmailCaption();
            this.m_rich_text_box_email_remark.Text = RequestXml.GetRequestEmailRemark();

        } // SetTexts

        /// <summary>Set check boxes</summary>
        private void _SetCheckBoxes()
        {
            m_initializing = true;

            if (RequestXml.GetDisplayConcertsFlag())
            {
                m_check_box_dates_display.Checked = true;
            }
            else
            {
                m_check_box_dates_display.Checked = false;
            }

            m_initializing = false;

        } // _SetCheckBoxes

        /// <summary>Set combo boxes</summary>
        private void _SetComboBoxes()
        {
            m_initializing = true;

            RequestXml.SetRequiredDataArray();

            RequestXml.SetComboBoxRequiredData(m_combo_box_req_item);

            this.m_rich_text_box_required_item.Text = RequestStrings.RequiredDataNotSelected;

            m_initializing = false;

        } // _SetComboBoxes

        /// <summary>Set controls editable or not</summary>
        private void SetEditable()
        {
            // User is not allowed to change the text of the dropdown items
            // This style changes the color, therefore standard colors are
            // changed to black and white. Not equal to other dropdowns in Admin ...
            this.m_combo_box_req_item.DropDownStyle = ComboBoxStyle.DropDownList;
            this.m_combo_box_req_item.BackColor = Color.White;
            this.m_combo_box_req_item.ForeColor = Color.Black;

            if (m_editable)
            {
                this.m_text_box_request_header.Enabled = true;
                this.m_text_box_email_title.Enabled = true;
                this.m_text_box_email_address.Enabled = true;
                this.m_text_box_email_caption.Enabled = true;

                this.m_rich_text_box_no_dates.Enabled = true;
                this.m_rich_text_box_dates_text.Enabled = true;
                this.m_rich_text_box_required_data_text.Enabled = true;
                this.m_rich_text_box_end_paragraph.Enabled = true;
                this.m_rich_text_box_required_item.Enabled = true;
                this.m_rich_text_box_email_remark.Enabled = true;

                this.m_check_box_dates_display.Enabled = true;

                this.m_text_box_request_header.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_email_title.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_email_address.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_email_caption.BackColor = AdminUtils.ColorEnable();

                this.m_rich_text_box_no_dates.BackColor = AdminUtils.ColorEnable();
                this.m_rich_text_box_dates_text.BackColor = AdminUtils.ColorEnable();
                this.m_rich_text_box_required_data_text.BackColor = AdminUtils.ColorEnable();
                this.m_rich_text_box_end_paragraph.BackColor = AdminUtils.ColorEnable();
                this.m_rich_text_box_required_item.BackColor = AdminUtils.ColorEnable();
                this.m_rich_text_box_email_remark.BackColor = AdminUtils.ColorEnable();
            }
            else
            {
                this.m_text_box_request_header.Enabled = false;
                this.m_text_box_email_title.Enabled = false;
                this.m_text_box_email_address.Enabled = false;
                this.m_text_box_email_caption.Enabled = false;

                this.m_rich_text_box_no_dates.Enabled = false;
                this.m_rich_text_box_dates_text.Enabled = false;
                this.m_rich_text_box_required_data_text.Enabled = false;
                this.m_rich_text_box_end_paragraph.Enabled = false;
                this.m_rich_text_box_required_item.Enabled = false;
                this.m_rich_text_box_email_remark.Enabled = false;

                this.m_check_box_dates_display.Enabled = false;

                this.m_text_box_request_header.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_email_title.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_email_address.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_email_caption.BackColor = AdminUtils.ColorDisable();

                this.m_rich_text_box_no_dates.BackColor = AdminUtils.ColorDisable(); // Does not work
                this.m_rich_text_box_dates_text.BackColor = AdminUtils.ColorDisable(); // Does not work
                this.m_rich_text_box_required_data_text.BackColor = AdminUtils.ColorDisable(); // Does not work
                this.m_rich_text_box_end_paragraph.BackColor = AdminUtils.ColorDisable(); // Does not work
                this.m_rich_text_box_required_item.BackColor = AdminUtils.ColorDisable(); // Does not work
                this.m_rich_text_box_email_remark.BackColor = AdminUtils.ColorDisable(); // Does not work
            }

        } // SetEditable

        /// <summary>Write texts</summary>
        private bool WriteTexts(out string o_error)
        {
            o_error = @"";

            AdminUtils.SetApplicationDocumentChangeFlag(true);

            if (!RequestXml.WriteRequestXmlHeader(this.m_text_box_request_header.Text, out o_error)) return false;

            if (!RequestXml.WriteRequestEmailTitle(this.m_text_box_email_title.Text, out o_error)) return false;

            if (!RequestXml.WriteRequestEmailAddress(this.m_text_box_email_address.Text, out o_error)) return false;

            if (!RequestXml.WriteRequestEmailCaption(this.m_text_box_email_caption.Text, out o_error)) return false;

            if (!RequestXml.WriteRequestNoDates(this.m_rich_text_box_no_dates.Text, out o_error)) return false;

            if (!RequestXml.WriteRequestDatesText(this.m_rich_text_box_dates_text.Text, out o_error)) return false;

            if (!RequestXml.WriteRequiredDataText(this.m_rich_text_box_required_data_text.Text, out o_error)) return false;

            if (!RequestXml.WriteRequestEndParagraph(this.m_rich_text_box_end_paragraph.Text, out o_error)) return false;

            if (!RequestXml.WriteRequestEmailRemark(this.m_rich_text_box_email_remark.Text, out o_error)) return false;

            RequestXml.SaveItemSetRequiredDataTextBox(m_rich_text_box_required_item, m_combo_box_req_item.Text);

            if (!RequestXml.WriteRequiredDataArray(out o_error)) return false;

            if (!RequestXml.WriteDisplayConcertsFlag(this.m_check_box_dates_display.Checked, out o_error)) return false;

            return true;

        } // WriteTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipReqXmlForm.SetToolTip(this, RequestStrings.ToolTipReqXmlForm);
            ToolTipReqXmlForm.SetToolTip(this.m_label_page_header, RequestStrings.ToolTipReqXmlForm);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlForm);

            ToolTipReqXmlCheckinCheckout.SetToolTip(this.m_button_edit_request_data, RequestStrings.ToolTipReqXmlCheckinCheckout);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlCheckinCheckout);

            ToolTipReqFormCancel.SetToolTip(this.m_button_cancel, RequestStrings.ToolTipReqFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipReqFormCancel);

            ToolTipReqFormClose.SetToolTip(this.m_button_close, RequestStrings.ToolTipReqFormClose);
            ToolTipUtil.SetDelays(ref ToolTipReqFormClose);

            ToolTipReqXmlDisplayDates.SetToolTip(this.m_label_request_display_dates, RequestStrings.ToolTipReqXmlDisplayDates);
            ToolTipReqXmlDisplayDates.SetToolTip(this.m_check_box_dates_display, RequestStrings.ToolTipReqXmlDisplayDates);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlDisplayDates);

            ToolTipReqXmlTitle.SetToolTip(this.m_text_box_request_header, RequestStrings.ToolTipReqXmlTitle);
            ToolTipReqXmlTitle.SetToolTip(this.m_label_request_header, RequestStrings.ToolTipReqXmlTitle);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlTitle);

            ToolTipReqXmlNoDates.SetToolTip(this.m_rich_text_box_no_dates, RequestStrings.ToolTipReqXmlNoDates);
            ToolTipReqXmlNoDates.SetToolTip(this.m_label_no_dates_text, RequestStrings.ToolTipReqXmlNoDates);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlNoDates);

            ToolTipReqXmlDatesText.SetToolTip(this.m_rich_text_box_dates_text, RequestStrings.ToolTipReqXmlDatesText);
            ToolTipReqXmlDatesText.SetToolTip(this.m_label_dates_text, RequestStrings.ToolTipReqXmlDatesText);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlDatesText);

            ToolTipReqXmlRequiredData.SetToolTip(this.m_rich_text_box_required_data_text, RequestStrings.ToolTipReqXmlRequiredData);
            ToolTipReqXmlRequiredData.SetToolTip(this.m_label_required_data, RequestStrings.ToolTipReqXmlRequiredData);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlRequiredData);

            ToolTipReqXmlRequiredItem.SetToolTip(this.m_rich_text_box_required_item, RequestStrings.ToolTipReqXmlRequiredItem);
            ToolTipReqXmlRequiredItem.SetToolTip(this.m_combo_box_req_item, RequestStrings.ToolTipReqXmlRequiredItem);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlRequiredItem);

            ToolTipReqXmlEmailTitle.SetToolTip(this.m_text_box_email_title, RequestStrings.ToolTipReqXmlEmailTitle);
            ToolTipReqXmlEmailTitle.SetToolTip(this.m_label_email_title, RequestStrings.ToolTipReqXmlEmailTitle);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlEmailTitle);

            ToolTipReqXmlEmailAddresse.SetToolTip(this.m_text_box_email_address, RequestStrings.ToolTipReqXmlEmailAddresse);
            ToolTipReqXmlEmailAddresse.SetToolTip(this.m_label_email_address, RequestStrings.ToolTipReqXmlEmailAddresse);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlEmailAddresse);

            ToolTipReqXmlEmailCaption.SetToolTip(this.m_text_box_email_caption, RequestStrings.ToolTipReqXmlEmailCaption);
            ToolTipReqXmlEmailCaption.SetToolTip(this.m_label_email_caption, RequestStrings.ToolTipReqXmlEmailCaption);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlEmailCaption);

            ToolTipReqXmlEmailRemark.SetToolTip(this.m_rich_text_box_email_remark, RequestStrings.ToolTipReqXmlEmailRemark);
            ToolTipReqXmlEmailRemark.SetToolTip(this.m_label_email_remark, RequestStrings.ToolTipReqXmlEmailRemark);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlEmailRemark);

            ToolTipReqXmlEndParagraph.SetToolTip(this.m_rich_text_box_end_paragraph, RequestStrings.ToolTipReqXmlEndParagraph);
            ToolTipReqXmlEndParagraph.SetToolTip(this.m_label_end_paragraph, RequestStrings.ToolTipReqXmlEndParagraph);
            ToolTipUtil.SetDelays(ref ToolTipReqXmlEndParagraph);

        } // _SetToolTips

        /// <summary>User selected a new required data item
        /// <para>1. </para>
        /// </summary>
        private void m_combo_box_req_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_initializing)
                return;

            RequestXml.SaveItemSetRequiredDataTextBox(m_rich_text_box_required_item, m_combo_box_req_item.Text);

        } // m_combo_box_req_item_SelectedIndexChanged

        /// <summary>User clicked the edit button</summary>
        private void m_button_edit_request_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                m_index_form.CheckoutData();

                m_editable = true;

                SetEditable();

                SetCaptions();
            }

        } // m_button_edit_request_data_Click

        /// <summary>User clicked the cancel button</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked the save/close button</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (m_editable)
            {
                string error_message = @"";
                if (!WriteTexts(out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }
            }

            this.Close();

        } // m_button_close_Click
    } // RequestXmlForm

} // namespace
