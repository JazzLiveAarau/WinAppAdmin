using JazzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Request XML (form) variables and functions</summary>
    public static class RequestXml
    {
        #region Required data items

        /// <summary>Number for the active required data</summary>
        private static int m_active_required_data = 0;

        /// <summary>Get the active required data</summary>
        public static int ActiveRequiredDataNumber { get { return m_active_required_data; } }

        /// <summary>Array with the required data for an application</summary>
        static public string[] m_required_data = new string[9];

        /// <summary>Set the required data array</summary>
        static public void SetRequiredDataArray()
        {
            m_required_data[0] = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestContentOne());

            m_required_data[1] = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestContentTwo());

            m_required_data[2] = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestContentThree());

            m_required_data[3] = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestContentFour());

            m_required_data[4] = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestContentFive());

            m_required_data[5] = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestContentSix());

            m_required_data[6] = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestContentSeven());

            m_required_data[7] = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestContentEight());

            m_required_data[8] = AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestContentNine());

        } // SetRequiredDataArray

        /// <summary>Write the required data array</summary>
        static public bool WriteRequiredDataArray(out string o_error)
        {
            o_error = @"";

            JazzXml.SetRequestContentOne(m_required_data[0]);

            JazzXml.SetRequestContentTwo(m_required_data[1]);

            JazzXml.SetRequestContentThree(m_required_data[2]);

            JazzXml.SetRequestContentFour(m_required_data[3]);

            JazzXml.SetRequestContentFive(m_required_data[4]);

            JazzXml.SetRequestContentSix(m_required_data[5]);

            JazzXml.SetRequestContentSeven(m_required_data[6]);

            JazzXml.SetRequestContentEight(m_required_data[7]);

            JazzXml.SetRequestContentNine(m_required_data[8]);

            return true;

        } // WriteRequiredDataArray

        #endregion // Required data items

        #region Write text functions

        /// <summary>Writes the request header</summary>
        static public bool WriteRequestXmlHeader(string i_request_header, out string o_error)
        {
            o_error = @"";

            JazzXml.SetRequestHeader(i_request_header);

            return true;

        } // WriteRequestXmlHeader

        /// <summary>Writes the request no dates text</summary>
        static public bool WriteRequestNoDates(string i_request_no_dates_text, out string o_error)
        {
            o_error = @"";

            JazzXml.SetRequestNoDatesText(i_request_no_dates_text);

            // SetRequestDatesDisplayBool(bool i_display_dates)

            return true;

        } // WriteRequestXmlHeader

        /// <summary>Writes the request dates text</summary>
        static public bool WriteRequestDatesText(string i_request_dates_text, out string o_error)
        {
            o_error = @"";

            JazzXml.SetRequestDatesText(i_request_dates_text);

            return true;

        } // WriteRequestDatesText

        /// <summary>Writes the required data text</summary>
        static public bool WriteRequiredDataText(string i_required_data_text, out string o_error)
        {
            o_error = @"";

            JazzXml.SetRequestContentHeader(i_required_data_text);

            return true;

        } // WriteRequiredDataText

        /// <summary>Writes the request end paragraph</summary>
        static public bool WriteRequestEndParagraph(string i_request_end_paragraph, out string o_error)
        {
            o_error = @"";

            JazzXml.SetRequestEndParagraph(i_request_end_paragraph);

            return true;

        } // WriteRequestEndParagraph

        /// <summary>Writes the request email title</summary>
        static public bool WriteRequestEmailTitle(string i_request_email_title, out string o_error)
        {
            o_error = @"";

            JazzXml.SetRequestEmailTitle(i_request_email_title);

            return true;

        } // WriteRequestEmailTitle

        /// <summary>Writes the request email remark</summary>
        static public bool WriteRequestEmailRemark(string i_request_email_remark, out string o_error)
        {
            o_error = @"";

            JazzXml.SetRequestEmailRemark(i_request_email_remark);

            return true;

        } // WriteRequestEmailRemark

        /// <summary>Writes the request email address</summary>
        static public bool WriteRequestEmailAddress(string i_request_mail_address, out string o_error)
        {
            o_error = @"";

            JazzXml.SetRequestEmailAddress(i_request_mail_address);

            return true;

        } // WriteRequestEmailAddress

        /// <summary>Writes the request email caption</summary>
        static public bool WriteRequestEmailCaption(string i_request_mail_caption, out string o_error)
        {
            o_error = @"";

            JazzXml.SetRequestEmailCaption(i_request_mail_caption);

            return true;

        } // WriteRequestEmailCaption

        #endregion // Write text functions

        #region Check boxes

        /// <summary>Returns the flag telling if the next season concert dates shall be displayed</summary>
        static public bool GetDisplayConcertsFlag() { return JazzXml.GetRequestDatesDisplayBool(); }

        /// <summary>Write the flag telling if the next season concert dates shall be displayed</summary>
        static public bool WriteDisplayConcertsFlag(bool i_display_dates, out string o_error) 
        {
            o_error = @"";

            JazzXml.SetRequestDatesDisplayBool(i_display_dates);

            return true;

        } // WriteDisplayConcertsFlag

        #endregion //Check boxes

        #region Combobox

        #region Get text functions

        /// <summary>Returns the request header - the page title</summary>
        static public string GetRequestXmlHeader() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestHeader()); }

        /// <summary>Returns the request no dates text</summary>
        static public string GetRequestNoDates() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestNoDatesText()); }

        /// <summary>Returns the request dates text</summary>
        static public string GetRequestDatesText() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestDatesText()); }

        /// <summary>Returns the required data text</summary>
        static public string GetRequiredDataText() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestContentHeader()); }

        /// <summary>Returns the request email title</summary>
        static public string GetRequestEmailTitle() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestEmailTitle()); }

        /// <summary>Returns the request email address</summary>
        static public string GetRequestEmailAddress() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestEmailAddress()); }

        /// <summary>Returns the request email caption</summary>
        static public string GetRequestEmailCaption() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestEmailCaption()); }

        /// <summary>Returns the request email remark</summary>
        static public string GetRequestEmailRemark() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestEmailRemark()); }

        /// <summary>Returns the request end paragraph</summary>
        static public string GetRequestEndParagraph() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestEndParagraph()); }

        #endregion // Get text functions

        #region Get title and caps functions

        /// <summary>Returns the page title</summary>
        static public string GetTitlePage() { return AdminUtils.RemoveXmlUndefinedValue(JazzXml.GetRequestHeader()); }

        /// <summary>Returns the label for the request title</summary>
        static public string GetLabelDisplayNextSeasonConcertDates() { return XmlEditStrings.LabelRequestDisplayConcertDates; }

        /// <summary>Returns the label for the request title</summary>
        static public string GetLabelRequestHeader() { return XmlEditStrings.LabelRequestXmlTitle;  }

        /// <summary>Returns the label for the no dates text</summary>
        static public string GetLabelNoDates() { return XmlEditStrings.LabelRequestXmlNoDates; }

        /// <summary>Returns the label for the dates text</summary>
        static public string GetLabelDatesText() { return XmlEditStrings.LabelRequestXmlDatesText; }

        /// <summary>Returns the label for the required data</summary>
        static public string GetLabelRequiredData() { return XmlEditStrings.LabelRequestXmlRequiredData; }

        /// <summary>Returns the label for the email title</summary>
        static public string GetLabelEmailTitle() { return XmlEditStrings.LabelRequestXmlEmailTitle; }

        /// <summary>Returns the label for the email address</summary>
        static public string GetLabelEmailAddress() { return XmlEditStrings.LabelRequestXmlEmailAddress; }

        /// <summary>Returns the label for the email caption</summary>
        static public string GetLabelEmailCaption() { return XmlEditStrings.LabelRequestXmlEmailCaption; }

        /// <summary>Returns the label for the email remark</summary>
        static public string GetLabelEmailRemark() { return XmlEditStrings.LabelRequestXmlEmailRemark; }
 
        /// <summary>Returns the label for the end paragraph text</summary>
        static public string GetLabelEndParagraph() { return XmlEditStrings.LabelRequestXmlEndParagraphText; }

        #endregion // Get title and caps functions

        /// <summary>Set combobox (dropdown menu) required data
        /// <para>1. Get the item array for the dropdown. Call of GetArrayForComboBoxRequiredData.</para>
        /// <para>2. Set the items for the dropdown menu. First item is 'Select item'.</para>
        /// <para>3. Set active dropdown menu item to 'Select item'</para>
        /// </summary>
        public static void SetComboBoxRequiredData(ComboBox i_combo_box)
        {
            string[] requiered_data_array = GetArrayForComboBoxRequiredData();

            i_combo_box.Items.Clear();

            i_combo_box.Items.Add(RequestStrings.PromptSelectRequiredData);

            if (requiered_data_array != null)
            {
                for (int index_name = 0; index_name < requiered_data_array.Length; index_name++)
                {
                    i_combo_box.Items.Add(requiered_data_array[index_name]);
                }
            }

            i_combo_box.Text = RequestStrings.PromptSelectRequiredData;

            m_active_required_data = 0;

        } // SetComboBoxRequiredData

        /// <summary>Save current required data and set text box for the selected required data 
        /// <para>1. Get the item array for the dropdown. Call of GetArrayForComboBoxRequiredData.</para>
        /// <para>2. Set the items for the dropdown menu. First item is 'Select item'.</para>
        /// <para>3. Set active dropdown menu item to 'Select item'</para>
        /// </summary>
        public static void SaveItemSetRequiredDataTextBox(RichTextBox i_rich_text_box_required_item, string i_selected_item)
        {
            if (ActiveRequiredDataNumber > 0)
            {
                int current_required_data_index = ActiveRequiredDataNumber - 1;

                m_required_data[current_required_data_index] = i_rich_text_box_required_item.Text;
            }

            int reguired_data_index = GetIndexRequiredData(i_selected_item);

            if (reguired_data_index < 0)
            {
                m_active_required_data = 0;

                i_rich_text_box_required_item.Text = RequestStrings.RequiredDataNotSelected;

                return;
            }

            i_rich_text_box_required_item.Text = m_required_data[reguired_data_index];

            m_active_required_data = reguired_data_index + 1;

        } // SaveItemSetRequiredDataTextBox

        /// <summary>Returns the required data index for the selected item. Returns negative value for none-selected data</summary>
        private static int GetIndexRequiredData(string i_selected_item)
        {
            int ret_index = -1;

            int n_required_data = 9;

            for (int index_data = 0; index_data < n_required_data; index_data++)
            {
                string item_str = RequestStrings.ItemTextRequiredData + (index_data + 1).ToString();

                if (i_selected_item.Equals(item_str))
                {
                    ret_index = index_data;

                    break;
                }
            }

            return ret_index;

        } // GetIndexRequiredData


        /// <summary>Get item names for the required data dropdown menu</summary>
        private static string[] GetArrayForComboBoxRequiredData()
        {
            string[] ret_array = null;

            int n_required_data = 9;

            ret_array = new string[n_required_data];

            for (int index_data = 0; index_data < n_required_data; index_data++)
            {
                ret_array[index_data] = RequestStrings.ItemTextRequiredData + (index_data + 1).ToString();
            }

            return ret_array;

        } // GetArrayForComboBoxRequiredData

        #endregion // Combobox

    } // RequestXml

} // namespace
