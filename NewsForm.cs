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
    /// <summary>Main form for the handling of news
    /// <para>This is Graphical User Interface class. Commands should not be executed in this class.</para>
    /// </summary>
    /// 
    public partial class NewsForm : Form
    {
        #region Member variables

        /// <summary>Flag telling if the dialog controls are being initialized</summary>
        bool m_initializing = false;

        #endregion // Member variables

        #region Constructor

        /// <summary>Constructor that initializes the control elements
        /// <para>1. Load XML file JazzNews.xml, i.e. create an XML object from the file. Call of News.InitXmlNews</para>
        /// <para>2. Initialize the active news numbers to zero, i.e. no active number. Call of News.InitActiveNewsNumbers</para>
        /// <para>3. Set active news numbers to zero. Call of News.InitActiveNewsNumbers</para>
        /// <para>4. Set current season to this season (used for the display of band name). Call of News.SetCurrentSeason</para>
        /// <para>5. Set titles and labels. Call of _SetTitlesLabels</para>
        /// <para>6. Set tooltips. Call of _SetToolTips</para>
        /// <para>7. Set the controls. Since there is no active news number all controls will be empty. Call of _SetControls</para>
        /// </summary>
        public NewsForm()
        {
            InitializeComponent();

            string error_message = @"";

            if (!News.InitXmlNews(out error_message))
            {

                MessageBox.Show(@"NewsForm.Constructor News.InitXmlNews failed " + error_message);

                return;
            }

            News.InitActiveNewsNumbers();

            if (!News.SetCurrentSeason(out error_message))
            {
                MessageBox.Show(@"NewsForm.Constructor News.SetCurrentSeason failed " + error_message);

                return;
            }

            _SetTitlesLabels();

            _SetToolTips();

            _SetControls(true);

        } // constructor

        #endregion // Constructor

        #region Set controls

        /// <summary>Set all controls that are dependent of the active news numbers and the XML object</summary>
        private void _SetControls(bool i_b_init)
        {
            if (i_b_init)
            {
                _SetComboBoxes();
            }

            _SetStartDateTimePicker();

            _SetEndDateTimePicker();

            _SetTexts();

            _SetButtons();

            _SetCheckBoxes();

            _SetEnabled();

            m_textbox_message.Text = @"";

        } // _SetControls

        /// <summary>Set titles and labels</summary>
        private void _SetTitlesLabels()
        {
            this.Text = NewsStrings.TitleNewsForm;

            this.m_label_background_color.Text = NewsStrings.LabelBackgroundColor;

            this.m_label_text_color.Text = NewsStrings.LabelTextColor;

            this.m_label_news_header.Text = NewsStrings.LabelCurrentNewsHeader;

            this.m_label_news_content.Text = NewsStrings.LabelCurrentNewsContent;

            this.m_label_test_flag.Text = NewsStrings.LabelCurrentNewsTestFlag;

            this.m_label_image_url.Text = NewsStrings.LabelImageUrl;

            this.m_label_image_text.Text = NewsStrings.LabelImageText;

            this.m_label_image_title.Text = NewsStrings.LabelImageTitle;

            this.m_label_image_width.Text = NewsStrings.LabelImageWidth;

            this.m_label_link_url.Text = NewsStrings.LabelLinkUrl;

            this.m_label_link_caption.Text = NewsStrings.LabelLinkCaption;

            this.m_label_email_subject.Text = NewsStrings.LabelEmailSubject;

            this.m_label_email_caption.Text = NewsStrings.LabelEmailCaption;

            this.m_label_email_text.Text = NewsStrings.LabelEmailContent;

            this.m_label_start_date.Text = NewsStrings.LabelStartDate;

            this.m_label_end_date.Text = NewsStrings.LabelEndDate;

            this.m_label_news_concert_number.Text = NewsStrings.LabelConcertNewsNumber;

            this.m_label_news_concert_header.Text = NewsStrings.LabelConcertNewsHeader;

            this.m_label_concert_news_content.Text = NewsStrings.LabelConcertNewsContent;

            this.m_label_concert_test_flag.Text = NewsStrings.LabelConcertNewsTestFlag;

            this.m_label_concert_cancelled.Text = NewsStrings.LabelConcertCancelledFlag;

            this.m_group_box_news.Text = NewsStrings.LabelGroupBoxCurrentNews;

            this.m_group_box_concert_news.Text = NewsStrings.LabelGroupBoxConcertNews;

            this.m_group_box_image.Text = NewsStrings.LabelGroupBoxImage;

            this.m_group_box_link.Text = NewsStrings.LabelGroupBoxLink;

            this.m_group_box_email.Text = NewsStrings.LabelGroupBoxEmail;

            this.m_textbox_message.Text = @"";

        } // _SetTitles

        /// <summary>Set combo boxes</summary>
        private void _SetComboBoxes()
        {
            m_initializing = true;

            News.SetComboBoxCurrentNews(m_combo_box_news);

            News.SetComboBoxConcertNews(m_combo_box_news_concert);

            m_initializing = false;

        } // _SetComboBoxes

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            _SetTextsCurrentNews();

            _SetTextsConcertNews();

        } // _SetTexts

        /// <summary>Set controls enabled or disabled</summary>
        private void _SetEnabled()
        {
            this.m_text_box_band_name.Enabled = false;

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                this.m_text_box_news_header.Enabled = true;
                this.m_rich_text_box_news_text.Enabled = true;
                this.m_text_box_image_url.Enabled = true;
                this.m_text_box_image_width.Enabled = true;
                this.m_text_box_image_caption.Enabled = true;
                this.m_text_box_image_title.Enabled = true;
                this.m_text_box_link_url.Enabled = true;
                this.m_text_box_link_caption.Enabled = true;
                this.m_text_box_email_subject.Enabled = true;
                this.m_text_box_email_caption.Enabled = true;
                this.m_text_box_email_text.Enabled = true;
                this.m_check_box_test.Enabled = true;

                this.m_text_box_news_concert_number.Enabled = true;
                this.m_text_box_news_concert_header.Enabled = true;
                this.m_rich_text_box_news_concert_text.Enabled = true;
                this.m_check_box_concert_test.Enabled = true;
                this.m_check_box_concert_cancelled.Enabled = true;

            }
            else
            {
                this.m_text_box_news_header.Enabled = false;
                this.m_rich_text_box_news_text.Enabled = false;
                this.m_text_box_image_url.Enabled = false;
                this.m_text_box_image_width.Enabled = false;
                this.m_text_box_image_caption.Enabled = false;
                this.m_text_box_image_title.Enabled = false;
                this.m_text_box_link_url.Enabled = false;
                this.m_text_box_link_caption.Enabled = false;
                this.m_text_box_email_subject.Enabled = false;
                this.m_text_box_email_caption.Enabled = false;
                this.m_text_box_email_text.Enabled = false;
                this.m_check_box_test.Enabled = false;

                this.m_text_box_news_concert_number.Enabled = false;
                this.m_text_box_news_concert_header.Enabled = false;
                this.m_rich_text_box_news_concert_text.Enabled = false;
                this.m_check_box_concert_test.Enabled = false;
                this.m_check_box_concert_cancelled.Enabled = false;

            }

        } // _SetEnabled

        /// <summary>Set current news texts
        /// <para>1. Set background and text colors</para>
        /// <para>2.a Clear all controls if the user hasn't selected a news number</para>
        /// <para>2.b Set all controls if the user has selected a news number</para>
        /// </summary>
        private void _SetTextsCurrentNews()
        {
            this.m_text_box_background_color.Text = JazzXml.GetNewsBackgroundColor();

            this.m_text_box_text_color.Text = JazzXml.GetNewsTextColor();

            if (News.ActiveCurrentNewsNumber == 0)
            {
                this.m_text_box_news_header.Text = @"";
                this.m_rich_text_box_news_text.Text = @"";
                this.m_text_box_image_url.Text = @"";
                this.m_text_box_image_width.Text = @"";
                this.m_text_box_image_caption.Text = @"";
                this.m_text_box_image_title.Text = @"";
                this.m_text_box_link_url.Text = @"";
                this.m_text_box_link_caption.Text = @"";
                this.m_text_box_email_subject.Text = @"";
                this.m_text_box_email_caption.Text = @"";
                this.m_text_box_email_text.Text = @"";
            }
            else
            {
                this.m_text_box_news_header.Text = News.GetNewsHeader();
                this.m_rich_text_box_news_text.Text = News.GetNewsContent();
                this.m_text_box_image_url.Text = News.GetNewsImage();
                this.m_text_box_image_width.Text = News.GetNewsImageWidth();
                this.m_text_box_image_caption.Text = News.GetNewsImageCaption();
                this.m_text_box_image_title.Text = News.GetNewsImageTitle();
                this.m_text_box_link_url.Text = News.GetNewsLink();
                this.m_text_box_link_caption.Text = News.GetNewsLinkCaption();
                this.m_text_box_email_subject.Text = News.GetNewsEmailSubject();
                this.m_text_box_email_caption.Text = News.GetNewsEmailText();
                this.m_text_box_email_text.Text = News.GetNewsEmailCaption();
            }

        } // _SetTextsCurrentNews

        /// <summary>Set band name</summary>
        private void _SetBandName()
        {

            if (News.ActiveConcertNewsNumber == 0)
            {
                return;
            }

            string error_message = @"";

            string concert_number_str = News.GetConcertNewsNumber();

            int concert_number = Int32.Parse(concert_number_str);

            string band_name = News.GetBandName(concert_number, out error_message);

            if (error_message.Length == 0)
            {
                this.m_text_box_band_name.Text = band_name;
            }
            else
            {
                this.m_text_box_band_name.Text = error_message;
            }

        } // _SetBandName

        /// <summary>Set concert news texts</summary>
        private void _SetTextsConcertNews()
        {
            _SetTextsCurrentNews();

            if (News.ActiveConcertNewsNumber == 0)
            {
                this.m_text_box_news_concert_number.Text = @"";

                this.m_text_box_news_concert_header.Text = @"";

                this.m_rich_text_box_news_concert_text.Text = @"";

                this.m_text_box_band_name.Text = @"";

            }
            else
            {
                this.m_text_box_news_concert_number.Text = News.GetConcertNewsNumber();

                this.m_text_box_news_concert_header.Text = News.GetConcertNewsHeader();

                this.m_rich_text_box_news_concert_text.Text = News.GetConcertNewsContent();

                _SetBandName();
            }

        } // _SetTextsConcertNews

        /// <summary>Set the start date time picker 
        /// <para></para>
        /// </summary>
        private void _SetStartDateTimePicker()
        {

            m_date_time_picker_start.Format = DateTimePickerFormat.Custom;
            m_date_time_picker_start.CustomFormat = "yyyy-MM-dd"; // "d/MM";

            DateTime date_time = new DateTime(News.GetNewsStartYearInt(), News.GetNewsStartMonthInt(), News.GetNewsStartDayInt());

            m_date_time_picker_start.Value = date_time;

        } // _SetStartDateTimePicker

        /// <summary>Set the end date time picker 
        /// <para></para>
        /// </summary>
        private void _SetEndDateTimePicker()
        {

            m_date_time_picker_end.Format = DateTimePickerFormat.Custom;
            m_date_time_picker_end.CustomFormat = "yyyy-MM-dd"; // "d/MM";

            DateTime date_time = new DateTime(News.GetNewsEndYearInt(), News.GetNewsEndMonthInt(), News.GetNewsEndDayInt());

            m_date_time_picker_end.Value = date_time;

        } // _SetEndDateTimePicker

        /// <summary>Set buttons
        /// <para></para>
        /// </summary>
        private void _SetButtons()
        {
            this.m_button_cancel.Text = NewsStrings.CaptionButtonCancel;

            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                this.m_button_close.Text = NewsStrings.CaptionButtonSave;
            }
            else
            {
                this.m_button_close.Text = NewsStrings.CaptionButtonClose;
            }

        } // _SetButtons


        /// <summary>Set check boxes</summary>
        private void _SetCheckBoxes()
        {
            m_initializing = true;

            if (News.ActiveCurrentNewsNumber == 0)
            {
                m_check_box_test.Checked = false;
            }
            else
            {
                if (News.GetNewsTestFlagBool())
                {
                    m_check_box_test.Checked = true;
                }
                else
                {
                    m_check_box_test.Checked = false;
                }
            }

            if (News.ActiveConcertNewsNumber == 0)
            {
                m_check_box_concert_test.Checked = false;

                m_check_box_concert_cancelled.Checked = false;
            }
            else
            {
                if (News.GetConcertNewsTestFlagBool())
                {
                    m_check_box_concert_test.Checked = true;
                }
                else
                {
                    m_check_box_concert_test.Checked = false;
                }

                if (News.GetConcertNewsCancelledFlagBool())
                {
                    m_check_box_concert_cancelled.Checked = true;
                }
                else
                {
                    m_check_box_concert_cancelled.Checked = false;
                }
            }

            m_initializing = false;

        } // _SetCheckBoxes

        #endregion // Set controls

        #region Tooltips
        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            ToolTipNewsForm.SetToolTip(this, NewsStrings.ToolTipNewsForm);
            ToolTipNewsForm.SetToolTip(m_label_news, NewsStrings.ToolTipNewsForm);
            ToolTipUtil.SetDelays(ref ToolTipNewsForm);

            ToolTipNewsBackgroundColor.SetToolTip(m_text_box_background_color, NewsStrings.ToolTipNewsBackgroundColor);
            ToolTipNewsBackgroundColor.SetToolTip(m_label_background_color, NewsStrings.ToolTipNewsBackgroundColor);
            ToolTipUtil.SetDelays(ref ToolTipNewsBackgroundColor);

            ToolTipNewsTextColor.SetToolTip(m_text_box_text_color, NewsStrings.ToolTipNewsTextColor);
            ToolTipNewsTextColor.SetToolTip(m_label_text_color, NewsStrings.ToolTipNewsTextColor);
            ToolTipUtil.SetDelays(ref ToolTipNewsTextColor);

            ToolTipNewsCheckout.SetToolTip(m_button_edit_news_data, NewsStrings.ToolTipNewsCheckout);
            ToolTipUtil.SetDelays(ref ToolTipNewsCheckout);

            ToolTipNewsCancelButton.SetToolTip(m_button_cancel, NewsStrings.ToolTipNewsCancelButton);
            ToolTipUtil.SetDelays(ref ToolTipNewsCancelButton);

            ToolTipNewsSaveCloseButton.SetToolTip(m_button_cancel, NewsStrings.ToolTipNewsSaveCloseButton);
            ToolTipUtil.SetDelays(ref ToolTipNewsSaveCloseButton);

            ToolTipNewsDropdown.SetToolTip(m_combo_box_news, NewsStrings.ToolTipNewsDropdown);
            ToolTipUtil.SetDelays(ref ToolTipNewsDropdown);

            ToolTipNewsHeader.SetToolTip(m_text_box_news_header, NewsStrings.ToolTipNewsHeader);
            ToolTipNewsHeader.SetToolTip(m_label_news_header, NewsStrings.ToolTipNewsHeader);
            ToolTipUtil.SetDelays(ref ToolTipNewsHeader);

            ToolTipNewsContent.SetToolTip(m_rich_text_box_news_text, NewsStrings.ToolTipNewsContent);
            ToolTipNewsContent.SetToolTip(m_label_news_content, NewsStrings.ToolTipNewsContent);
            ToolTipUtil.SetDelays(ref ToolTipNewsContent);

            ToolTipNewsTestFlag.SetToolTip(m_check_box_test, NewsStrings.ToolTipNewsTestFlag);
            ToolTipNewsTestFlag.SetToolTip(m_label_test_flag, NewsStrings.ToolTipNewsTestFlag);
            ToolTipUtil.SetDelays(ref ToolTipNewsTestFlag);

            ToolTipNewsDelete.SetToolTip(m_button_delete_news, NewsStrings.ToolTipNewsDelete);
            ToolTipUtil.SetDelays(ref ToolTipNewsDelete);

            ToolTipNewsImageUrl.SetToolTip(m_text_box_image_url, NewsStrings.ToolTipNewsImageUrl);
            ToolTipNewsImageUrl.SetToolTip(m_label_image_url, NewsStrings.ToolTipNewsImageUrl);
            ToolTipUtil.SetDelays(ref ToolTipNewsImageUrl);

            ToolTipNewsImageWidth.SetToolTip(m_text_box_image_width, NewsStrings.ToolTipNewsImageWidth);
            ToolTipNewsImageWidth.SetToolTip(m_label_image_width, NewsStrings.ToolTipNewsImageWidth);
            ToolTipUtil.SetDelays(ref ToolTipNewsImageWidth);

            ToolTipNewsImageText.SetToolTip(m_text_box_image_caption, NewsStrings.ToolTipNewsImageText);
            ToolTipNewsImageText.SetToolTip(m_label_image_text, NewsStrings.ToolTipNewsImageText);
            ToolTipUtil.SetDelays(ref ToolTipNewsImageText);

            ToolTipNewsImageTitle.SetToolTip(m_text_box_image_title, NewsStrings.ToolTipNewsImageTitle);
            ToolTipNewsImageTitle.SetToolTip(m_label_image_title, NewsStrings.ToolTipNewsImageTitle);
            ToolTipUtil.SetDelays(ref ToolTipNewsImageTitle);

            ToolTipNewsLinkUrl.SetToolTip(m_text_box_link_url, NewsStrings.ToolTipNewsLinkUrl);
            ToolTipNewsLinkUrl.SetToolTip(m_label_link_url, NewsStrings.ToolTipNewsLinkUrl);
            ToolTipUtil.SetDelays(ref ToolTipNewsLinkUrl);

            ToolTipNewsLinkCaption.SetToolTip(m_text_box_link_caption, NewsStrings.ToolTipNewsLinkCaption);
            ToolTipNewsLinkCaption.SetToolTip(m_label_link_caption, NewsStrings.ToolTipNewsLinkCaption);
            ToolTipUtil.SetDelays(ref ToolTipNewsLinkCaption);

            ToolTipNewsEmailSubject.SetToolTip(m_text_box_email_subject, NewsStrings.ToolTipNewsEmailSubject);
            ToolTipNewsEmailSubject.SetToolTip(m_label_email_subject, NewsStrings.ToolTipNewsEmailSubject);
            ToolTipUtil.SetDelays(ref ToolTipNewsEmailSubject);

            ToolTipNewsEmailCaption.SetToolTip(m_text_box_email_caption, NewsStrings.ToolTipNewsEmailCaption);
            ToolTipNewsEmailCaption.SetToolTip(m_label_email_caption, NewsStrings.ToolTipNewsEmailCaption);
            ToolTipUtil.SetDelays(ref ToolTipNewsEmailCaption);

            ToolTipNewsEmailContent.SetToolTip(m_text_box_email_caption, NewsStrings.ToolTipNewsEmailContent);
            ToolTipNewsEmailContent.SetToolTip(m_label_email_caption, NewsStrings.ToolTipNewsEmailContent);
            ToolTipUtil.SetDelays(ref ToolTipNewsEmailContent);

            ToolTipNewsStartDate.SetToolTip(m_date_time_picker_start, NewsStrings.ToolTipNewsStartDate);
            ToolTipNewsStartDate.SetToolTip(m_label_start_date, NewsStrings.ToolTipNewsStartDate);
            ToolTipUtil.SetDelays(ref ToolTipNewsStartDate);

            ToolTipNewsEndDate.SetToolTip(m_date_time_picker_end, NewsStrings.ToolTipNewsEndDate);
            ToolTipNewsEndDate.SetToolTip(m_label_end_date, NewsStrings.ToolTipNewsEndDate);
            ToolTipUtil.SetDelays(ref ToolTipNewsEndDate);

            ToolTipNewsConcertDropdown.SetToolTip(m_combo_box_news_concert, NewsStrings.ToolTipNewsConcertDropdown);
            ToolTipUtil.SetDelays(ref ToolTipNewsConcertDropdown);

            ToolTipNewsConcertNumber.SetToolTip(m_text_box_news_concert_number, NewsStrings.ToolTipNewsConcertNumber);
            ToolTipNewsConcertNumber.SetToolTip(m_label_news_concert_number, NewsStrings.ToolTipNewsConcertNumber);
            ToolTipUtil.SetDelays(ref ToolTipNewsConcertNumber);

            ToolTipNewsConcertBandName.SetToolTip(m_text_box_band_name, NewsStrings.ToolTipNewsConcertBandName);
            ToolTipUtil.SetDelays(ref ToolTipNewsConcertBandName);

            ToolTipNewsConcertCancelledFlag.SetToolTip(m_check_box_concert_cancelled, NewsStrings.ToolTipNewsConcertCancelledFlag);
            ToolTipNewsConcertCancelledFlag.SetToolTip(m_label_concert_cancelled, NewsStrings.ToolTipNewsConcertCancelledFlag);
            ToolTipUtil.SetDelays(ref ToolTipNewsConcertCancelledFlag);

            ToolTipNewsConcertHeader.SetToolTip(m_text_box_news_concert_header, NewsStrings.ToolTipNewsConcertHeader);
            ToolTipNewsConcertHeader.SetToolTip(m_label_news_concert_header, NewsStrings.ToolTipNewsConcertHeader);
            ToolTipUtil.SetDelays(ref ToolTipNewsConcertHeader);

            ToolTipNewsConcertContent.SetToolTip(m_rich_text_box_news_concert_text, NewsStrings.ToolTipNewsConcertContent);
            ToolTipNewsConcertContent.SetToolTip(m_label_concert_news_content, NewsStrings.ToolTipNewsConcertContent);
            ToolTipUtil.SetDelays(ref ToolTipNewsConcertContent);

            ToolTipConcertNewsTestFlag.SetToolTip(m_check_box_concert_test, NewsStrings.ToolTipConcertNewsTestFlag);
            ToolTipConcertNewsTestFlag.SetToolTip(m_label_concert_test_flag, NewsStrings.ToolTipConcertNewsTestFlag);
            ToolTipUtil.SetDelays(ref ToolTipConcertNewsTestFlag);

            ToolTipConcertNewsDelete.SetToolTip(m_button_delete_concert_news, NewsStrings.ToolTipConcertNewsDelete);
            ToolTipUtil.SetDelays(ref ToolTipConcertNewsDelete);

            ToolTipConcertNewsMessage.SetToolTip(m_textbox_message, NewsStrings.ToolTipConcertNewsMessage);
            ToolTipUtil.SetDelays(ref ToolTipConcertNewsMessage);

        } // _SetToolTips

        #endregion // Tooltips

        #region Write data

        /// <summary>Write texts
        /// <para>1. If the user has selected a current news number set/change XML object. Call of _WriteTextsCurrentNews</para>
        /// <para>2. If the user has selected a concert news number set/change XML object. Call of _WriteTextsConcertNews</para>
        /// </summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            if (News.ActiveCurrentNewsNumber > 0)
            {
                if (!_WriteTextsCurrentNews(out o_error)) return false;
            }

            if (News.ActiveConcertNewsNumber > 0)
            {
                if (!_WriteTextsConcertNews(out o_error)) return false;
            }

            return true;

        } // WriteTexts

        /// <summary>Write current news texts to the XML object corresponding to JazzNews.xml</summary>
        private bool _WriteTextsCurrentNews(out string o_error)
        {
            o_error = @"";

            if (!News.WriteNewsHeader(this.m_text_box_news_header.Text, out o_error)) return false;

            if (!News.WriteNewsContent(this.m_rich_text_box_news_text.Text, out o_error)) return false;

            if (!News.WriteNewsImage(this.m_text_box_image_url.Text, out o_error)) return false;

            if (!News.WriteNewsImageWidth(this.m_text_box_image_width.Text, out o_error)) return false;

            if (!News.WriteNewsImageCaption(this.m_text_box_image_caption.Text, out o_error)) return false;

            if (!News.WriteNewsImageTitle(this.m_text_box_image_title.Text, out o_error)) return false;

            if (!News.WriteNewsLink(this.m_text_box_link_url.Text, out o_error)) return false;

            if (!News.WriteNewsLinkCaption(this.m_text_box_link_caption.Text, out o_error)) return false;

            if (!News.WriteNewsEmailSubject(this.m_text_box_email_subject.Text, out o_error)) return false;

            if (!News.WriteNewsEmailText(this.m_text_box_email_text.Text, out o_error)) return false;

            if (!News.WriteNewsEmailCaption(this.m_text_box_email_caption.Text, out o_error)) return false;

            if (!News.WriteDateStart(m_date_time_picker_start.Value.Year,
                                     m_date_time_picker_start.Value.Month,
                                     m_date_time_picker_start.Value.Day, out o_error)) return false;

           if (!News.WriteDateEnd(m_date_time_picker_end.Value.Year,
                                  m_date_time_picker_end.Value.Month,
                                  m_date_time_picker_end.Value.Day, out o_error)) return false;

            if (!News.WriteNewsTestFlag(this.m_check_box_test.Checked, out o_error)) return false;

            return true;

        } // WriteTextsCurrentNews

        /// <summary>Write concert news texts to the XML object corresponding to JazzNews.xml</summary>
        private bool _WriteTextsConcertNews(out string o_error)
        {
            o_error = @"";

            if (!News.WriteConcertNewsNumber(this.m_text_box_news_concert_number.Text, out o_error)) return false;

            if (!News.WriteConcertNewsHeader(this.m_text_box_news_concert_header.Text, out o_error)) return false;

            if (!News.WriteConcertNewsContent(this.m_rich_text_box_news_concert_text.Text, out o_error)) return false;

            if (!News.WriteConcertNewsTestFlag(this.m_check_box_concert_test.Checked, out o_error)) return false;

            if (!News.WriteConcertNewsCancelledFlag(this.m_check_box_concert_cancelled.Checked, out o_error)) return false;

            return true;

        } // WriteTextsConcertNews

        #endregion // Write data

        #region Checkout and checkin (save) XML file on the server

        /// <summary>Check out data, set Checkin/Checkout button to Save and create backup of file JazzNews.xml
        /// <para>1. Checkout news data. Call of AdminUtils.CheckoutData.</para>
        /// <para>2. Set button to 'Save'. Call of _SetButtons</para>
        /// <para>3. Create backup of file JazzNews.xml. Call of Backup.BackupCurrentEditXmlFile</para>
        /// </summary>
        public bool _CheckoutData(out bool o_b_user_cancelled)
        {
            o_b_user_cancelled = false;

            // Returned value 'false' means that the somebody else already has checked out and 
            // that the user not forced a checkout
            bool b_checkout_data = AdminUtils.CheckoutData();
            if (!b_checkout_data)
            {
                o_b_user_cancelled = true;
                return true;
            }

            _SetButtons();

            bool xml_edited = false;
            string err_message = @"";

            string full_server_file_name = AdminUtils.GetFullServerNameForXmlBackup(News.NewsFileName);

            if (Backup.BackupCurrentEditXmlFile(full_server_file_name, xml_edited, out err_message))
            {
                this.m_textbox_message.Text = News.NewsFileName + JazzAppAdminSettings.Default.MsgBackupCurrenXml;
            }
            else
            {
                err_message = "NewsForm.CheckoutData Backup Program error: " + err_message;
                this.m_textbox_message.Text = err_message;
                return false;
            }

            return true;

        } // _CheckoutData

        /// <summary>Upload the file JazzNews.xml to the server and check in data
        /// <para>1. Return (do nothing) if the news data not has been checked out.</para>
        /// <para>2. Upload the XML file to the server. Call of AdminUtils.UploadXmlToServer.</para>
        /// <para>3. Checkin news data. Call of LoginLogout.Checkin.</para>
        /// <para>4. Set the button to 'Close'. Call of _SetButtons.</para>
        /// </summary>
        private bool _CheckinData(out string o_error)
        {
            o_error = @"";

            if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                o_error = @"NewsForm.CheckinData Programming error: XML file has not not been checked out";

                this.m_textbox_message.Text = o_error;

                return false;
            }

            if (!AdminUtils.UploadXmlToServer(News.NewsFileName, JazzXml.GetObjectNews(), out o_error))
            {
                o_error = @"NewsForm.CheckinData Programming error: " + o_error;

                this.m_textbox_message.Text = o_error;

                return false;
            }

            this.m_textbox_message.Text = @"";

            string out_message = @"";
            bool force_checkin = false;
            if (!JazzLoginLogout.LoginLogout.Checkin(force_checkin, out out_message, out o_error))
            {
                o_error = @"News._CheckinData Programming error: " + o_error;

                this.m_textbox_message.Text = o_error;

                return false;
            }

            _SetButtons();

            return true;

        } // _CheckinData

        #endregion // Checkout and checkin (save) XML file on the server

        #region Button events

        /// <summary>User clicked the button save or close
        /// <para>1. Close the news window if the news data not has been checked out.</para>
        /// <para>2. Write data to the XML object corresponding to file JazzNews.xml. Call of _WriteTexts.</para>
        /// <para>3. Save the file JazzNews.xml on the server and checkin news data. Call of _CheckinData.</para>
        /// <para>4. Close the news window.</para>
        /// </summary>
        private void m_button_close_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                this.Close();

                return;
            }

            if (!_WriteTexts(out error_message))
            {
                MessageBox.Show(error_message);

                return;
            }

            if (!_CheckinData(out error_message))
            {
                MessageBox.Show(error_message);

                return;
            }

            this.Close();

        } // m_button_close_Click

        /// <summary>User clicked the button cancel
        /// <para>1. If news data has been checked out ask the user if data shall be saved. If not checkin the data.
        /// Call of LoginLogout.Checkin</para>
        /// <para>2. Close the news window</para>
        /// </summary>
        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                string warning_msg = NewsStrings.WarningMsgCloseWindowWithoutSaving;

                DialogResult dialog_result = MessageBox.Show(warning_msg, DocAdminString.MsgWarning, MessageBoxButtons.YesNo);

                if (dialog_result == DialogResult.No)
                {
                    return;
                }

                string o_error = @"";
                string out_message = @"";
                bool force_checkin = false;
                if (!JazzLoginLogout.LoginLogout.Checkin(force_checkin, out out_message, out o_error))
                {
                    o_error = @"News._CheckinData Programming error: " + o_error;

                    this.m_textbox_message.Text = o_error;

                    return;
                }
            }

            this.Close();

        } // m_button_cancel_Click

        #endregion // Button events

        #region Select news with comboboxes

        /// <summary>User selected a new item with the current news dropdown menu
        /// <para>1. Save data if checked out and if active number not is zero. Call of _WriteTextsCurrentNews</para>
        /// <para>2. If selected item is "Select item" set active number to zero, set controls and return. 
        /// Calls of News.InitCurrentActiveNewsNumber and _SetControls</para>
        /// <para>3. If selected string is "Add item" and data is checked out add the item, set active number to the added item, set controls and return. 
        /// Call of News.AddCurrentNewsElement, News.SetCurrentActiveNewsNumberToLastElement and _SetControls</para>
        /// <para>4. Set active number to the user selected item. Call of News.SetActiveCurrentNewsNumber.</para>
        /// <para>5. Set controls. Call of _SetControls</para>
        /// </summary>
        private void m_combo_box_news_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_initializing)
                return;

            string error_message = @"";

            if (JazzLoginLogout.LoginLogout.DataCheckedOut && News.ActiveCurrentNewsNumber > 0)
            {

                if (!_WriteTextsCurrentNews(out error_message))
                {
                    MessageBox.Show(error_message);
   
                    return;
                }

            }

            if (NewsStrings.PromptSelectCurrentNews.Equals(m_combo_box_news.Text))
            {
                News.InitCurrentActiveNewsNumber();

                _SetControls(false);

                return;
            }

            if (NewsStrings.PromptAddCurrentNews.Equals(m_combo_box_news.Text))
            {
                if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
                {
                    error_message = NewsStrings.ErrMsgNewsAddingOnlyAfterCheckout;

                    this.m_textbox_message.Text = error_message;

                    MessageBox.Show(error_message);

                    return;
                }

                if (!News.AddCurrentNewsElement(out error_message))
                {
                    error_message = @"NewsForm.m_combo_box_news_SelectedIndexChanged News.AddCurrentNewsElement failed " + error_message;

                    this.m_textbox_message.Text = error_message;

                    MessageBox.Show(error_message);

                    return;
                }

                News.SetCurrentActiveNewsNumberToLastElement();

                _SetControls(false);

                return;
            }

            News.SetActiveCurrentNewsNumber(m_combo_box_news.Text);

            _SetControls(false);

        } // m_combo_box_news_SelectedIndexChanged


        /// <summary>User selected a new item with the concert news dropdown menu
        /// <para>1. Save data if checked out and if active number not is zero. Call of _WriteTextsConcertNews</para>
        /// <para>2. If selected item is "Select item" set active number to zero, set controls and return. 
        /// Calls of News.InitConcertActiveNewsNumber and _SetControls</para>
        /// <para>3. If selected string is "Add item" and data is checked out add the item, set active number to the added item, set controls and return. 
        /// Call of News.AddConcertNewsElement, News.SetConcertActiveNewsNumberToLastElement and _SetControls</para>
        /// <para>4. Set active number to the user selected item. Call of News.SetActiveConcertNewsNumber.</para>
        /// <para>5. Set controls. Call of _SetControls</para>
        /// </summary>
        private void m_combo_box_news_concert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_initializing)
                return;

            string error_message = @"";

            if (JazzLoginLogout.LoginLogout.DataCheckedOut && News.ActiveConcertNewsNumber > 0)
            {

                if (!_WriteTextsConcertNews(out error_message))
                {
                    MessageBox.Show(error_message);

                    return;
                }

            }

            if (NewsStrings.PromptSelectConcertNews.Equals(m_combo_box_news_concert.Text))
            {
                News.InitConcertActiveNewsNumber();

                _SetControls(false);

                return;
            }

            if (NewsStrings.PromptAddConcertNews.Equals(m_combo_box_news_concert.Text))
            {
                if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
                {
                    error_message = NewsStrings.ErrMsgConcertNewsAddingOnlyAfterCheckout;

                    this.m_textbox_message.Text = error_message;

                    return;
                }

                if (!News.AddConcertNewsElement(out error_message))
                {
                    error_message = @"NewsForm.m_combo_box_news_SelectedIndexChanged News.AddConcertNewsElement failed " + error_message;

                    this.m_textbox_message.Text = error_message;

                    return;
                }

                _SetControls(true);

                News.SetConcertActiveNewsNumberToLastElement();

                _SetControls(false);

                return;
            }

            News.SetActiveConcertNewsNumber(m_combo_box_news_concert.Text);

            _SetControls(false);

        } // m_combo_box_news_concert_SelectedIndexChanged

        #endregion // Select news with comboboxes

        #region Checkout and edit news data

        /// <summary>User clicked the edit button.
        /// <para>1. Just return if the file already has been checked out</para>
        /// <para>2. Checkout news data. Call of _CheckoutData.</para>
        /// <para>3. Enable all controls. Call of _SetEnabled</para>
        /// </summary>
        private void m_button_edit_news_data_Click(object sender, EventArgs e)
        {
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                return;
            }

            bool b_user_cancelled = false;

            if (!_CheckoutData(out b_user_cancelled))
            {
                return;
            }

            _SetEnabled();

        } // m_button_edit_news_data_Click

        /// <summary>User changed the concert number and the band name will be changed
        /// <para>1. Remove band name </para>
        /// <para>2. Return if the concert number control string is empty</para>
        /// <para>3. Write the new concert number to the XML object. Call of News.WriteConcertNewsNumber.</para>
        /// <para>4. Set the band name. Call of _SetBandName.</para>
        /// </summary>
        private void m_text_box_news_concert_number_TextChanged(object sender, EventArgs e)
        {
            if (m_initializing)
            {
                return;
            }

            string error_message = @"";

            this.m_text_box_band_name.Text = @"";

            string concert_number_str = this.m_text_box_news_concert_number.Text;

            if (concert_number_str.Trim().Length == 0)
            {
                return;
            }

            if (!News.WriteConcertNewsNumber(this.m_text_box_news_concert_number.Text, out error_message))
            {
                this.m_textbox_message.Text = error_message;

                return;
            }

            _SetBandName();

        } // m_text_box_news_concert_number_TextChanged

        #endregion // Checkout and edit news data

        #region Delete news

        /// <summary>User clicked button delete current news
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        private void m_button_delete_news_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                error_message = NewsStrings.ErrMsgDeleteNewsOnlyAllowedAfterCheckout;

                MessageBox.Show(error_message);

                return;
            }

            if (News.ActiveCurrentNewsNumber == 0)
            {
                error_message = NewsStrings.ErrMsgNewsForDeleteNotSelected;

                MessageBox.Show(error_message);

                return;
            }

            if (!News.RemoveNewsElement(out error_message))
            {
                error_message = @"NewsForm.m_button_delete_news_Click News.RemoveNewsElement failed " + error_message;

                MessageBox.Show(error_message);

                return;
            }

            News.InitCurrentActiveNewsNumber();

            _SetControls(true);

        } // m_button_delete_news_Click

        /// <summary>User clicked button delete concert news
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        private void m_button_delete_concert_news_Click(object sender, EventArgs e)
        {
            string error_message = @"";

            if (!JazzLoginLogout.LoginLogout.DataCheckedOut)
            {
                error_message = NewsStrings.ErrMsgDeleteConcertNewsOnlyAllowedAfterCheckout;

                MessageBox.Show(error_message);

                return;
            }

            if (News.ActiveConcertNewsNumber == 0)
            {
                error_message = NewsStrings.ErrMsgConcertNewsForDeleteNotSelected;

                MessageBox.Show(error_message);

                return;
            }

            if (!News.RemoveConcertNewsElement(out error_message))
            {
                error_message = @"NewsForm.m_button_delete_news_Click News.RemoveConcertNewsElement failed " + error_message;

                MessageBox.Show(error_message);

                return;
            }

            News.InitConcertActiveNewsNumber();

            _SetControls(true);

        } // m_button_delete_concert_news_Click

        #endregion // Delete news

        #region Checkbox event

        /// <summary>User changed the news test checkbox. Check that only one of the news shall be shown in the Homepage test version.</summary>
        private void m_check_box_test_CheckedChanged(object sender, EventArgs e)
        {
            if (m_initializing)
            {
                return;
            }

            string error_message = @"";

            if (!News.concertNewsTestFlagCanBeSetToTrue(this.m_check_box_test.Checked, out error_message))
            {
                this.m_check_box_test.Checked = false;

                MessageBox.Show(error_message);

                return;
            }

        } // m_check_box_test_CheckedChanged

        #endregion // Checkbox event

    } // NewsForm

} // namespace
