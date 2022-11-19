using JazzApp;
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
    /// <summary>Set the request date
    /// <para></para>
    /// </summary>
    public partial class RequestDateForm : Form
    {
        #region Member variables

        /// <summary>The owner of this form</summary>
        RequestBandForm m_request_band_form = null;

        /// <summary>Form object for checkout</summary>
        private RequestForm m_request_form = null;

        /// <summary>Input JazzReq object</summary>
        JazzReq m_req = null;

        /// <summary>Flag defining if input controls are editable</summary>
        private bool m_editable = false;

        /// <summary>Flag telling if controls are being initialized</summary>
        private bool m_is_initializing = false;

        #endregion // Member variables

        /// <summary>Constructor
        /// <para>1. Sets the controls of the dialog</para>
        /// <para>2. Makes the controls editable if the XML file is checked out</para>
        /// <para>3. Sets the tool tips</para>
        /// <para>4. Sets the captions</para>
        /// </summary>
        /// <param name="i_request_band_form">Object RequestBandForm - the owner of this form</param>
        /// <param name="i_request_form">Form object for checkout</param>
        /// <param name="i_req">Object JazzReq</param>
        public RequestDateForm(RequestBandForm i_request_band_form, RequestForm i_request_form, JazzReq i_req)
        {
            InitializeComponent();

            if (null == i_request_band_form)
                return;

            m_request_band_form = i_request_band_form;

            if (null == i_request_form)
                return;

            m_request_form = i_request_form;

            if (null == i_req)
            {
                return;
            }

            m_req = i_req;

            m_is_initializing = true;

            _SetTexts();

            _SetDateAndRegNumber();

            _SetDateTimePicker();

            _SetToolTips();

            // m_editable must be set before _SetCaptions() is called
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetCaptions();

            m_is_initializing = false;

        } // Constructor

        #region Set controls

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = RequestStrings.TitleRequestDateForm;

            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            TitleRequestDateForm.SetToolTip(this, RequestStrings.TitleRequestDateForm);
            ToolTipUtil.SetDelays(ref TitleRequestDateForm);

            ToolTipReqMainCheckinCheckout.SetToolTip(m_button_edit_request_data, RequestStrings.ToolTipReqMainCheckinCheckout);
            ToolTipUtil.SetDelays(ref ToolTipReqMainCheckinCheckout);

            ToolTipReqFormCancel.SetToolTip(m_button_cancel, RequestStrings.ToolTipReqFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipReqFormCancel);
            ToolTipReqFormClose.SetToolTip(m_button_close, RequestStrings.ToolTipReqFormClose);
            ToolTipUtil.SetDelays(ref ToolTipReqFormClose);

            ToolTipReqDateLabel.SetToolTip(m_label_reg_date_number, RequestStrings.ToolTipReqDateLabel);
            ToolTipUtil.SetDelays(ref ToolTipReqDateLabel);

            ToolTipReqDateTimePicker.SetToolTip(m_date_time_picker, RequestStrings.ToolTipReqDateTimePicker);
            ToolTipUtil.SetDelays(ref ToolTipReqDateTimePicker);

            ToolTipReqFormMsg.SetToolTip(m_textbox_message, RequestStrings.ToolTipReqFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipReqFormMsg);

        } // SetToolTips

        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // _SetCaptions

        /// <summary>Set request date and number</summary>
        private void _SetDateAndRegNumber()
        {
            string error_message = @"";
            if (!RequestBand.SetDateAndRegnumber(m_req, null, m_label_reg_date_number, out error_message))
            {
                error_message = @"RequestBandForm._SetTitles RequestBand.SetDateAndRegnumber failed " + error_message;
                MessageBox.Show(error_message);
                return;
            }
        } // _SetDateAndRegNumber

        /// <summary>Set the date time picker 
        /// <para></para>
        /// </summary>
        private void _SetDateTimePicker()
        {
            if (null == m_req)
                return;

            m_date_time_picker.Format = DateTimePickerFormat.Custom;
            m_date_time_picker.CustomFormat = "yyyy-MM-dd"; // "d/MM";

            DateTime date_time = new DateTime(m_req.RegYearInt, m_req.RegMonthInt, m_req.RegDayInt);
            m_date_time_picker.Value = date_time;

        } // _SetDateTimePicker

        #endregion // Set controls

        /// <summary>Write file name (texts)</summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            if (!m_request_band_form.SetReqDate(m_req, out o_error))
            {
                o_error = @"ReqPdfForm._WriteTexts RequestBandForm.SetReqDate failed " + o_error;
                return false;
            }

            return true;
        } // _WriteTexts

        #region Event handling functions 

        /// <summary>User clicked the edit (checkout) button</summary>
        private void m_button_edit_request_data_Click(object sender, EventArgs e)
        {
            if (!m_editable)
            {
                bool b_user_cancelled = false;
                m_request_form.CheckoutData(out b_user_cancelled);
                if (b_user_cancelled)
                {
                    return;
                }

                m_editable = true;
            }

            _SetCaptions();

        } // m_button_edit_request_data_Click

        /// <summary>User clicked button cancel</summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        } // m_button_cancel_Click

        /// <summary>User clicked button close</summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            if (m_editable)
            {
                string error_message = @"";
                if (!_WriteTexts(out error_message))
                {
                    MessageBox.Show(error_message);
                    return;
                }
            }

            this.Close();

        } // m_button_close_Click

        /// <summary>User changed the date</summary>
        private void m_date_time_picker_ValueChanged(object sender, EventArgs e)
        {
            if (m_is_initializing)
                return;

            string error_message = @"";
            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgDateChangeOnlyAfterCheckout;
                MessageBox.Show(error_message);
                return;
            }

            DateTime set_value = this.m_date_time_picker.Value;
            int set_year = set_value.Year;
            int set_month = set_value.Month;
            int set_day = set_value.Day;

            m_req.RegYearInt = set_year;
            m_req.RegMonthInt = set_month;
            m_req.RegDayInt = set_day;

            m_is_initializing = true;
            _SetDateAndRegNumber();
            m_is_initializing = false;

        } // m_date_time_picker_ValueChanged

        /// <summary>User clicks dropdown date button</summary>
        private void m_date_time_picker_DropDown(object sender, EventArgs e)
        {
            string error_message = @"";
            if (!m_editable)
            {
                error_message = RequestStrings.ErrMsgDateChangeOnlyAfterCheckout;
                MessageBox.Show(error_message);
                return;
            }

        } // m_date_time_picker_DropDown

        #endregion // Event handling functions 

    } // RequestDateForm

} // namespace
