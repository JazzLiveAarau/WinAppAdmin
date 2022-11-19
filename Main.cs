using System.IO;
using System.Collections;
using JazzApp;


namespace JazzAppAdmin
{
    /// <summary>Main class for the application JAZZ live AARAU Admin: Administration of the data for the Jazz App, Website and Photos
    /// <para>The JAZZ live AARAU Admin and JAZZ live AARAU App are based on XML files on the server.</para>
    /// <para>For the App it is the the season concert XML files (JazzProgramm_20xx_20yy.xml) and the application XML file(JazzApplication.xml).</para>
    /// <para>For the (this) Admin application it is the document XML files (JazzDokumente_20xx_20yy.xml).</para>
    /// <para>At start of the application all XML objects will be initialized. i.e. the XML objects corresponding to the XML files will be created.</para>
    /// <para></para>
    /// <para>Changes, adding or replacing of an XML file can only be done if the XML files have been checked out.</para>
    /// <para>Checkout means that the user will be registered in an checkin/checkout file on the server.</para>
    /// <para>Only one person at a time can checkout the XML files.</para>
    /// </summary>
    public class Main
    {
        #region Passwords and paths

        // Handling of the Server password
        // ===============================
        // 1. Add cs file with this content
        //    public static class PassWord
        //    {
        //        public static string Server
        //        { get { return "ServerPassword"; } }
        //    } 
        // 2. Add the following line to the GitHub file .gitignore (in Notepad++)
        //    PassWord.cs
		
        /// <summary>The main form for this application. Commands are coming from controls (edit fields, buttons, ..) of this form.</summary>
        private JazzAppAdminForm m_main_form = null;

        /// <summary>Path to the exe directory. Used to get the paths to the application subdirectories (XML, Output, etc)</summary>
        static public string m_exe_directory = System.Windows.Forms.Application.StartupPath;

        /// <summary>Get path to the exe directory</summary>
        static public string ExeDirectory
        { get { return m_exe_directory; } }

        /// <summary>Password for www directories</summary>
        static private string m_ftp_www_password = PassWord.Server;;

        /// <summary>Get password for www directories</summary>
        static public string FtpWwwPassword
        { get { return m_ftp_www_password; } }

        #endregion // Passwords and paths

        #region Ask user if update of website and intranet shall be done

        /// <summary>Flag telling if a checkout has been made but no update of website is done</summary>
        static private bool m_checkout_but_no_web_intranet_update = false;
        /// <summary>Get and set flag telling if a checkout has been made but no update of website is done</summary>
        static public bool CheckoutButNoWebsiteUpdate { get { return m_checkout_but_no_web_intranet_update; } set { m_checkout_but_no_web_intranet_update = value; } }

        /// <summary>Prompt string</summary>
        static private string m_checkout_but_no_web_intranet_update_prompt = @"Checkout wurde gemacht aber nachher keine Aktualisierung von Intranet im Hauptmenü Website (HTM)" + "\n" + @"Applikation beenden ohne Aktualisierung?";
        /// <summary>Get prompt string</summary>
        static private string CheckoutButNoWebsiteUpdateString
        { get { return m_checkout_but_no_web_intranet_update_prompt; } }

        /// <summary>Ask the user if exit from application is OK although a checkout has been done</summary>
        static public bool ApplicationExit()
        {
            if (!CheckoutButNoWebsiteUpdate)
            {
                return true;
            }

            if (!AdminUtils.MessageBoxYesNo(CheckoutButNoWebsiteUpdateString, @"?"))
            {
                return false;
            }

            return true;

        } // ApplicationExit

        #endregion // Ask user if update of website and intranet shall be done

        #region Constructor

        /// <summary>Constructor 
        /// <para>The config file will be created by a function in class AddressesJazzSettings if not existing in the exe directory. </para>
        /// <para>After the installation of a new version of the application Jazz App Administration the config file must be created.</para>
        /// <para>Initializes JazzXml and the Login/Logout (checkin/checkout) data.</para>
        /// </summary>
        /// <param name="i_main_form">The main form for the application JAZZ live AARAU Admin</param>
        public Main(JazzAppAdminForm i_main_form)
        {
            this.m_main_form = i_main_form;

            string config_file = FileUtil.ConfigFileName(JazzAppAdminSettings.Default.ConfigRootElement, Main.m_exe_directory);
            if (!File.Exists(config_file))
            {
                JazzAppAdminSettings.Default.Save();
            }

            JazzXml.SetFtpConnectionData(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword, Main.ExeDirectory);
            JazzXml.InitApplicationAndCurrentSeasonXml();
            // Moved to event function Shown JazzXml.InitXmlAllSeasons();
            string error_message = @"";
            if (!JazzXml.InitAdmin(out error_message))
            {
                return; // Programming error
            }

            if (!InitLoginLogout()) { return; }


        } // constructor JazzAppAdminMain

        #endregion // Constructor

        #region Login/logout

        /// <summary>Initialize data for the login and logout (checkin and checkout)
        /// <para>Create object, set password to directory for the login/logout file and set the application execution directory</para>
        /// <para>Please note that LoginLogout is a static class, i.e. the object is available for every function of the application</para>
        /// </summary>
        private bool InitLoginLogout()
        {
            JazzLoginLogout.LoginLogoutInput login_logout_input = new JazzLoginLogout.LoginLogoutInput();
            login_logout_input.FtpUser = JazzAppAdminSettings.Default.FtpUser;
            login_logout_input.FtpPassword = FtpWwwPassword;
            login_logout_input.ExeDirectory = m_exe_directory;

            string error_message = @"";
            if (!JazzLoginLogout.LoginLogout.Init(login_logout_input, out error_message))
            {
                return false;
            }

            return true;

        } // InitLoginLogout

        #endregion // Login/logout

    } // class Main

} // namespace
