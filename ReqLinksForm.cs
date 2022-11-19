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
    /// <summary>Set links for a request to a video, to a sound url or to a website
    /// <para></para>
    /// <para></para>
    /// <para></para>
    /// </summary>
    public partial class ReqLinksForm : Form
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
        public ReqLinksForm(RequestBandForm i_request_band_form, RequestForm i_request_form, JazzReq i_req)
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

            _SetTexts();

            _SetToolTips();

            // m_editable must be set before _SetCaptions() and _SetEditable is called
            if (JazzLoginLogout.LoginLogout.DataCheckedOut)
                m_editable = true;

            _SetCaptions();

            _SetEditable();

        } // Constructor

        #region Set controls

        /// <summary>Set texts</summary>
        private void _SetTexts()
        {
            this.Text = RequestStrings.TitleRequestLinksForm;

            this.m_label_page_header.Text = RequestStrings.LabelLinks;

            m_text_box_link_1.Text = m_req.LinkOne;
            m_text_box_link_2.Text = m_req.LinkTwo;
            m_text_box_link_3.Text = m_req.LinkThree;
            m_text_box_link_4.Text = m_req.LinkFour;
            m_text_box_link_5.Text = m_req.LinkFive;
            m_text_box_link_6.Text = m_req.LinkSix;
            m_text_box_link_7.Text = m_req.LinkSeven;
            m_text_box_link_8.Text = m_req.LinkEight;
            m_text_box_link_9.Text = m_req.LinkNine;

            m_text_box_text_1.Text = m_req.LinkTextOne;
            m_text_box_text_2.Text = m_req.LinkTextTwo;
            m_text_box_text_3.Text = m_req.LinkTextThree;
            m_text_box_text_4.Text = m_req.LinkTextFour;
            m_text_box_text_5.Text = m_req.LinkTextFive;
            m_text_box_text_6.Text = m_req.LinkTextSix;
            m_text_box_text_7.Text = m_req.LinkTextSeven;
            m_text_box_text_8.Text = m_req.LinkTextEight;
            m_text_box_text_9.Text = m_req.LinkTextNine;

            SetRadioButtons(m_req.LinkTypeOne, ref m_radio_button_video_1, ref m_radio_button_sound_1, ref m_radio_button_website_1);
            SetRadioButtons(m_req.LinkTypeTwo, ref m_radio_button_video_2, ref m_radio_button_sound_2, ref m_radio_button_website_2);
            SetRadioButtons(m_req.LinkTypeThree, ref m_radio_button_video_3, ref m_radio_button_sound_3, ref m_radio_button_website_3);
            SetRadioButtons(m_req.LinkTypeFour, ref m_radio_button_video_4, ref m_radio_button_sound_4, ref m_radio_button_website_4);
            SetRadioButtons(m_req.LinkTypeFive, ref m_radio_button_video_5, ref m_radio_button_sound_5, ref m_radio_button_website_5);
            SetRadioButtons(m_req.LinkTypeSix, ref m_radio_button_video_6, ref m_radio_button_sound_6, ref m_radio_button_website_6);
            SetRadioButtons(m_req.LinkTypeSeven, ref m_radio_button_video_7, ref m_radio_button_sound_7, ref m_radio_button_website_7);
            SetRadioButtons(m_req.LinkTypeEight, ref m_radio_button_video_8, ref m_radio_button_sound_8, ref m_radio_button_website_8);
            SetRadioButtons(m_req.LinkTypeNine, ref m_radio_button_video_9, ref m_radio_button_sound_9, ref m_radio_button_website_9);

            m_label_link_1.Text = RequestStrings.LabelLinks + @" 1";
            m_label_link_2.Text = RequestStrings.LabelLinks + @" 2";
            m_label_link_3.Text = RequestStrings.LabelLinks + @" 3";
            m_label_link_4.Text = RequestStrings.LabelLinks + @" 4";
            m_label_link_5.Text = RequestStrings.LabelLinks + @" 5";
            m_label_link_6.Text = RequestStrings.LabelLinks + @" 6";
            m_label_link_7.Text = RequestStrings.LabelLinks + @" 7";
            m_label_link_8.Text = RequestStrings.LabelLinks + @" 8";
            m_label_link_9.Text = RequestStrings.LabelLinks + @" 9";


            m_textbox_message.Text = @"";

        } // _SetTexts

        /// <summary>Set controls editable or not</summary>
        private void _SetEditable()
        {
            if (m_editable)
            {
                this.m_text_box_link_1.Enabled = true;
                this.m_text_box_link_2.Enabled = true;
                this.m_text_box_link_3.Enabled = true;
                this.m_text_box_link_4.Enabled = true;
                this.m_text_box_link_5.Enabled = true;
                this.m_text_box_link_6.Enabled = true;
                this.m_text_box_link_7.Enabled = true;
                this.m_text_box_link_8.Enabled = true;
                this.m_text_box_link_9.Enabled = true;

                this.m_text_box_link_1.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_link_2.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_link_3.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_link_4.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_link_5.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_link_6.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_link_7.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_link_8.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_link_9.BackColor = AdminUtils.ColorEnable();

                this.m_text_box_text_1.Enabled = true;
                this.m_text_box_text_2.Enabled = true;
                this.m_text_box_text_3.Enabled = true;
                this.m_text_box_text_4.Enabled = true;
                this.m_text_box_text_5.Enabled = true;
                this.m_text_box_text_6.Enabled = true;
                this.m_text_box_text_7.Enabled = true;
                this.m_text_box_text_8.Enabled = true;
                this.m_text_box_text_9.Enabled = true;

                this.m_text_box_text_1.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_text_2.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_text_3.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_text_4.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_text_5.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_text_6.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_text_7.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_text_8.BackColor = AdminUtils.ColorEnable();
                this.m_text_box_text_9.BackColor = AdminUtils.ColorEnable();

                this.m_radio_button_video_1.Enabled = true;
                this.m_radio_button_video_2.Enabled = true;
                this.m_radio_button_video_3.Enabled = true;
                this.m_radio_button_video_4.Enabled = true;
                this.m_radio_button_video_5.Enabled = true;
                this.m_radio_button_video_6.Enabled = true;
                this.m_radio_button_video_7.Enabled = true;
                this.m_radio_button_video_8.Enabled = true;
                this.m_radio_button_video_9.Enabled = true;

                this.m_radio_button_video_1.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_video_2.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_video_3.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_video_4.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_video_5.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_video_6.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_video_7.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_video_8.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_video_9.BackColor = AdminUtils.ColorEnable();

                this.m_radio_button_sound_1.Enabled = true;
                this.m_radio_button_sound_2.Enabled = true;
                this.m_radio_button_sound_3.Enabled = true;
                this.m_radio_button_sound_4.Enabled = true;
                this.m_radio_button_sound_5.Enabled = true;
                this.m_radio_button_sound_6.Enabled = true;
                this.m_radio_button_sound_7.Enabled = true;
                this.m_radio_button_sound_8.Enabled = true;
                this.m_radio_button_sound_9.Enabled = true;

                this.m_radio_button_sound_1.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_sound_2.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_sound_3.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_sound_4.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_sound_5.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_sound_6.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_sound_7.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_sound_8.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_sound_9.BackColor = AdminUtils.ColorEnable();

                this.m_radio_button_website_1.Enabled = true;
                this.m_radio_button_website_2.Enabled = true;
                this.m_radio_button_website_3.Enabled = true;
                this.m_radio_button_website_4.Enabled = true;
                this.m_radio_button_website_5.Enabled = true;
                this.m_radio_button_website_6.Enabled = true;
                this.m_radio_button_website_7.Enabled = true;
                this.m_radio_button_website_8.Enabled = true;
                this.m_radio_button_website_9.Enabled = true;

                this.m_radio_button_website_1.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_website_2.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_website_3.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_website_4.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_website_5.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_website_6.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_website_7.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_website_8.BackColor = AdminUtils.ColorEnable();
                this.m_radio_button_website_9.BackColor = AdminUtils.ColorEnable();

            }
            else
            {
                this.m_text_box_link_1.Enabled = false;
                this.m_text_box_link_2.Enabled = false;
                this.m_text_box_link_3.Enabled = false;
                this.m_text_box_link_4.Enabled = false;
                this.m_text_box_link_5.Enabled = false;
                this.m_text_box_link_6.Enabled = false;
                this.m_text_box_link_7.Enabled = false;
                this.m_text_box_link_8.Enabled = false;
                this.m_text_box_link_9.Enabled = false;

                this.m_text_box_link_1.BackColor = AdminUtils.ColorDisable(); // TODO Does not work
                this.m_text_box_link_2.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_link_3.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_link_4.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_link_5.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_link_6.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_link_7.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_link_8.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_link_9.BackColor = AdminUtils.ColorDisable();

                this.m_text_box_text_1.Enabled = false;
                this.m_text_box_text_2.Enabled = false;
                this.m_text_box_text_3.Enabled = false;
                this.m_text_box_text_4.Enabled = false;
                this.m_text_box_text_5.Enabled = false;
                this.m_text_box_text_6.Enabled = false;
                this.m_text_box_text_7.Enabled = false;
                this.m_text_box_text_8.Enabled = false;
                this.m_text_box_text_9.Enabled = false;

                this.m_text_box_text_1.BackColor = AdminUtils.ColorDisable(); // TODO Does not work
                this.m_text_box_text_2.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_text_3.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_text_4.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_text_5.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_text_6.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_text_7.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_text_8.BackColor = AdminUtils.ColorDisable();
                this.m_text_box_text_9.BackColor = AdminUtils.ColorDisable();

                this.m_radio_button_video_1.Enabled = false;
                this.m_radio_button_video_2.Enabled = false;
                this.m_radio_button_video_3.Enabled = false;
                this.m_radio_button_video_4.Enabled = false;
                this.m_radio_button_video_5.Enabled = false;
                this.m_radio_button_video_6.Enabled = false;
                this.m_radio_button_video_7.Enabled = false;
                this.m_radio_button_video_8.Enabled = false;
                this.m_radio_button_video_9.Enabled = false;

                this.m_radio_button_video_1.BackColor = AdminUtils.ColorDisable(); // TODO Does not work
                this.m_radio_button_video_2.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_video_3.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_video_4.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_video_5.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_video_6.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_video_7.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_video_8.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_video_9.BackColor = AdminUtils.ColorDisable();

                this.m_radio_button_sound_1.Enabled = false;
                this.m_radio_button_sound_2.Enabled = false;
                this.m_radio_button_sound_3.Enabled = false;
                this.m_radio_button_sound_4.Enabled = false;
                this.m_radio_button_sound_5.Enabled = false;
                this.m_radio_button_sound_6.Enabled = false;
                this.m_radio_button_sound_7.Enabled = false;
                this.m_radio_button_sound_8.Enabled = false;
                this.m_radio_button_sound_9.Enabled = false;

                this.m_radio_button_sound_1.BackColor = AdminUtils.ColorDisable(); // TODO Does not work
                this.m_radio_button_sound_2.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_sound_3.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_sound_4.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_sound_5.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_sound_6.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_sound_7.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_sound_8.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_sound_9.BackColor = AdminUtils.ColorDisable();

                this.m_radio_button_website_1.Enabled = false;
                this.m_radio_button_website_2.Enabled = false;
                this.m_radio_button_website_3.Enabled = false;
                this.m_radio_button_website_4.Enabled = false;
                this.m_radio_button_website_5.Enabled = false;
                this.m_radio_button_website_6.Enabled = false;
                this.m_radio_button_website_7.Enabled = false;
                this.m_radio_button_website_8.Enabled = false;
                this.m_radio_button_website_9.Enabled = false;

                this.m_radio_button_website_1.BackColor = AdminUtils.ColorDisable(); // TODO Does not work
                this.m_radio_button_website_2.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_website_3.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_website_4.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_website_5.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_website_6.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_website_7.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_website_8.BackColor = AdminUtils.ColorDisable();
                this.m_radio_button_website_9.BackColor = AdminUtils.ColorDisable();

            }

        } // _SetEditable

        /// <summary>Set tool tips</summary>
        private void _SetToolTips()
        {
            TitleRequestLinksForm.SetToolTip(this, RequestStrings.TitleRequestLinksForm); // 
            TitleRequestLinksForm.SetToolTip(m_label_page_header, RequestStrings.TitleRequestLinksForm);
            ToolTipUtil.SetDelays(ref TitleRequestLinksForm);

            ToolTipReqMainCheckinCheckout.SetToolTip(m_button_edit_request_data, RequestStrings.ToolTipReqMainCheckinCheckout);
            ToolTipUtil.SetDelays(ref ToolTipReqMainCheckinCheckout);

            ToolTipReqFormCancel.SetToolTip(m_button_cancel, RequestStrings.ToolTipReqFormCancel);
            ToolTipUtil.SetDelays(ref ToolTipReqFormCancel);
            ToolTipReqFormClose.SetToolTip(m_button_close, RequestStrings.ToolTipReqFormClose);
            ToolTipUtil.SetDelays(ref ToolTipReqFormClose);

            ToolTipReqFormMsg.SetToolTip(m_textbox_message, RequestStrings.ToolTipReqFormMsg);
            ToolTipUtil.SetDelays(ref ToolTipReqFormMsg);

            ToolTipReqLink.SetToolTip(m_label_link_1, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_label_link_2, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_label_link_3, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_label_link_4, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_label_link_5, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_label_link_6, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_label_link_7, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_label_link_8, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_label_link_9, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_text_box_link_1, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_text_box_link_2, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_text_box_link_3, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_text_box_link_4, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_text_box_link_5, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_text_box_link_6, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_text_box_link_7, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_text_box_link_8, RequestStrings.ToolTipReqLink);
            ToolTipReqLink.SetToolTip(m_text_box_link_9, RequestStrings.ToolTipReqLink);
            ToolTipUtil.SetDelays(ref ToolTipReqLink);

            ToolTipReqLinkText.SetToolTip(m_text_box_text_1, RequestStrings.ToolTipReqLinkText);
            ToolTipReqLinkText.SetToolTip(m_text_box_text_2, RequestStrings.ToolTipReqLinkText);
            ToolTipReqLinkText.SetToolTip(m_text_box_text_3, RequestStrings.ToolTipReqLinkText);
            ToolTipReqLinkText.SetToolTip(m_text_box_text_4, RequestStrings.ToolTipReqLinkText);
            ToolTipReqLinkText.SetToolTip(m_text_box_text_5, RequestStrings.ToolTipReqLinkText);
            ToolTipReqLinkText.SetToolTip(m_text_box_text_6, RequestStrings.ToolTipReqLinkText);
            ToolTipReqLinkText.SetToolTip(m_text_box_text_7, RequestStrings.ToolTipReqLinkText);
            ToolTipReqLinkText.SetToolTip(m_text_box_text_8, RequestStrings.ToolTipReqLinkText);
            ToolTipReqLinkText.SetToolTip(m_text_box_text_9, RequestStrings.ToolTipReqLinkText);
            ToolTipUtil.SetDelays(ref ToolTipReqLinkText);

            ToolTipReqLinkType.SetToolTip(m_label_text, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_label_video, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_label_sound, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_label_website, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_panel_link_1, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_panel_link_2, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_panel_link_3, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_panel_link_4, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_panel_link_5, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_panel_link_6, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_panel_link_7, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_panel_link_8, RequestStrings.ToolTipReqLinkType);
            ToolTipReqLinkType.SetToolTip(m_panel_link_9, RequestStrings.ToolTipReqLinkType);
            ToolTipUtil.SetDelays(ref ToolTipReqLinkType);


        } // SetToolTips


        /// <summary>Set captions for cancel/close button</summary>
        private void _SetCaptions()
        {
            AdminUtils.SetCancelCloseButtons(this.m_button_cancel, this.m_button_close, m_editable);

        } // _SetCaptions

        #endregion // Set controls

        /// <summary>Write file name (texts)</summary>
        private bool _WriteTexts(out string o_error)
        {
            o_error = @"";

            m_req.LinkOne = m_text_box_link_1.Text.Trim();
            m_req.LinkTwo = m_text_box_link_2.Text.Trim();
            m_req.LinkThree = m_text_box_link_3.Text.Trim();
            m_req.LinkFour = m_text_box_link_4.Text.Trim();
            m_req.LinkFive = m_text_box_link_5.Text.Trim();
            m_req.LinkSix = m_text_box_link_6.Text.Trim();
            m_req.LinkSeven = m_text_box_link_7.Text.Trim();
            m_req.LinkEight = m_text_box_link_8.Text.Trim();
            m_req.LinkNine = m_text_box_link_9.Text.Trim();

            // If link not defined, the text should not be defined
            if (m_req.LinkOne.Length == 0) m_text_box_text_1.Text = @"";
            if (m_req.LinkTwo.Length == 0) m_text_box_text_2.Text = @"";
            if (m_req.LinkThree.Length == 0) m_text_box_text_3.Text = @"";
            if (m_req.LinkFour.Length == 0) m_text_box_text_4.Text = @"";
            if (m_req.LinkFive.Length == 0) m_text_box_text_5.Text = @"";
            if (m_req.LinkSix.Length == 0) m_text_box_text_6.Text = @"";
            if (m_req.LinkSeven.Length == 0) m_text_box_text_7.Text = @"";
            if (m_req.LinkEight.Length == 0) m_text_box_text_8.Text = @"";
            if (m_req.LinkNine.Length == 0) m_text_box_text_9.Text = @"";

            m_req.LinkTextOne = m_text_box_text_1.Text.Trim();
            m_req.LinkTextTwo = m_text_box_text_2.Text.Trim();
            m_req.LinkTextThree = m_text_box_text_3.Text.Trim();
            m_req.LinkTextFour = m_text_box_text_4.Text.Trim();
            m_req.LinkTextFive = m_text_box_text_5.Text.Trim();
            m_req.LinkTextSix = m_text_box_text_6.Text.Trim();
            m_req.LinkTextSeven = m_text_box_text_7.Text.Trim();
            m_req.LinkTextEight = m_text_box_text_8.Text.Trim();
            m_req.LinkTextNine = m_text_box_text_9.Text.Trim();

            string link_type_one = @"";
            if (!GetLinkType(out link_type_one, m_radio_button_video_1, m_radio_button_sound_1, m_radio_button_website_1, 1, out o_error))
                return false;     
            m_req.LinkTypeOne = link_type_one;

            string link_type_two = @"";
            if (!GetLinkType(out link_type_two, m_radio_button_video_2, m_radio_button_sound_2, m_radio_button_website_2, 2, out o_error))
                return false;
            m_req.LinkTypeTwo = link_type_two;

            string link_type_three = @"";
            if (!GetLinkType(out link_type_three, m_radio_button_video_3, m_radio_button_sound_3, m_radio_button_website_3, 3, out o_error))
                return false;
            m_req.LinkTypeThree = link_type_three;

            string link_type_four = @"";
            if (!GetLinkType(out link_type_four, m_radio_button_video_4, m_radio_button_sound_4, m_radio_button_website_4, 4, out o_error))
                return false;
            m_req.LinkTypeFour = link_type_four;

            string link_type_five = @"";
            if (!GetLinkType(out link_type_five, m_radio_button_video_5, m_radio_button_sound_5, m_radio_button_website_5, 5, out o_error))
                return false;
            m_req.LinkTypeFive = link_type_five;

            string link_type_six = @"";
            if (!GetLinkType(out link_type_six, m_radio_button_video_6, m_radio_button_sound_6, m_radio_button_website_6, 6, out o_error))
                return false;
            m_req.LinkTypeSix = link_type_six;

            string link_type_seven = @"";
            if (!GetLinkType(out link_type_seven, m_radio_button_video_7, m_radio_button_sound_7, m_radio_button_website_7, 7, out o_error))
                return false;
            m_req.LinkTypeSeven = link_type_seven;

            string link_type_eight = @"";
            if (!GetLinkType(out link_type_eight, m_radio_button_video_8, m_radio_button_sound_8, m_radio_button_website_8, 8, out o_error))
                return false;
            m_req.LinkTypeEight = link_type_eight;

            string link_type_nine = @"";
            if (!GetLinkType(out link_type_nine, m_radio_button_video_9, m_radio_button_sound_9, m_radio_button_website_9, 9, out o_error))
                return false;
            m_req.LinkTypeNine = link_type_nine;

            if (!m_request_band_form.SetReqLinks(m_req, out o_error))
            {
                o_error = @"ReqLinksForm._WriteTexts RequestBandForm.SetReqLinks failed " + o_error;
                return false;
            }

            return true;
        } // _WriteTexts

        #region Leave (close) form events

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

            _SetEditable();

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

        #endregion // Leave (close) form events

        #region Radio buttons

        /// <summary>Check that a radio button is set to Video, Sound or Website. Should not be necessary ....</summary>
        private bool CheckRadioButtons(int i_link_number, RadioButton i_radio_button_video, RadioButton i_radio_button_sound, RadioButton i_radio_button_website, out string o_error)
        {
            o_error = @"";

            if (i_link_number < 1 || i_link_number > 9)
            {
                o_error = @"ReqLinksForm.CheckRadioButtons Link number " + i_link_number.ToString() + @" is not between 1 and 9 ";

                return false;
            }

            int n_checked = 0;

            if (i_radio_button_video.Checked)
            {
                n_checked = n_checked + 1;
            }

            if (i_radio_button_sound.Checked)
            {
                n_checked = n_checked + 1;
            }

            if (i_radio_button_website.Checked)
            {
                n_checked = n_checked + 1;
            }

            if (1 == n_checked)
                return true;

            if (0 == n_checked)
            {
                o_error = RequestStrings.ErrMsgTypeOfLinkNotSet + i_link_number.ToString();
                return false;
            }

            if (n_checked > 1)
            {
                o_error = RequestStrings.ErrMsgTypeOfLinkMultiple + i_link_number.ToString();
                return false;
            }


            o_error = @"ReqLinksForm.CheckRadioButtons Error Link " + i_link_number.ToString() + @" n_checked= " + n_checked.ToString();

            return false; 

        } // CheckRadioButtons

        /// <summary>Set radio buttons Video, Sound and Website</summary>
        private void SetRadioButtons(string i_link_type, ref RadioButton io_radio_button_video, ref RadioButton io_radio_button_sound, ref RadioButton io_radio_button_website)
        {
            if (i_link_type.Equals(RequestStrings.LinkTypeVideo))
            {
                io_radio_button_video.Checked = true;
                io_radio_button_sound.Checked = false;
                io_radio_button_website.Checked = false;
            }
            else if (i_link_type.Equals(RequestStrings.LinkTypeSound))
            {
                io_radio_button_video.Checked = false;
                io_radio_button_sound.Checked = true;
                io_radio_button_website.Checked = false;
            }
            else if (i_link_type.Equals(RequestStrings.LinkTypeWebsite))
            {
                io_radio_button_video.Checked = false;
                io_radio_button_sound.Checked = false;
                io_radio_button_website.Checked = true;
            }
            else
            {
                io_radio_button_video.Checked = true;
                io_radio_button_sound.Checked = false;
                io_radio_button_website.Checked = false;
            }

        } // SetRadioButtons

        /// <summary>Set radio buttons Video, Sound and Website</summary>
        private bool GetLinkType(out string o_link_type, RadioButton i_radio_button_video, RadioButton i_radio_button_sound, RadioButton i_radio_button_website, int i_link_number, out string o_error)
        {
            o_error = @"";
            o_link_type = @"";

            if (!CheckRadioButtons(i_link_number, i_radio_button_video, i_radio_button_sound, i_radio_button_website, out o_error))
            {
                return false;
            }

            if (i_radio_button_video.Checked)
            {
                o_link_type = RequestStrings.LinkTypeVideo;
            }
            else if (i_radio_button_sound.Checked)
            {
                o_link_type = RequestStrings.LinkTypeSound;
            }
            else if (i_radio_button_website.Checked)
            {
                o_link_type = RequestStrings.LinkTypeWebsite;
            }
            else
            {
                return false;
            }

            return true;

        } // GetLinkType


        #endregion // Radio buttons


    } // ReqLinksForm
} // namespace
