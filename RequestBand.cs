using JazzApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JazzAppAdmin
{
    /// <summary>Execution functions and parameters for form RequestBandForm
    /// <para></para>
    /// </summary>
    public static class RequestBand
    {
        #region Upload and download folders

        /// <summary>Latest used audio folder upload</summary>
        private static string m_audio_folder_upload = @"";

        /// <summary>Get latest used audio folder upload</summary>
        public static void SetAudioFolderUpload(string i_audio_folder_upload) { m_audio_folder_upload = i_audio_folder_upload; }

        /// <summary>Get latest used audio folder upload</summary>
        public static string GetAudioFolderUpload()
        {
            if (m_audio_folder_upload.Length > 0)
            {
                return m_audio_folder_upload;
            }
            else
            {
                return FileUtil.SubDirectory(RequestStrings.LocalDirAudioFiles, Main.m_exe_directory);
            }
        }// GetAudioFolderUpload

        /// <summary>Latest used audio folder download</summary>
        private static string m_audio_folder_download = @"";

        /// <summary>Get latest used audio folder download</summary>
        public static void SetAudioFolderDownload(string i_audio_folder_download) { m_audio_folder_download = i_audio_folder_download; }

        /// <summary>Get latest used audio folder download</summary>
        public static string GetAudioFolderDownload()
        {
            if (m_audio_folder_download.Length > 0)
            {
                return m_audio_folder_download;
            }
            else
            {
                return FileUtil.SubDirectory(RequestStrings.LocalDirAudioFiles, Main.m_exe_directory);
            }
        }// GetAudioFolderDownload

        #endregion // Upload and download folders

        #region Set controls

        /// <summary>Set date and registration number string for the button control 
        /// <para</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_req">Object JazzReq</param>
        /// <param name="i_button_reg_date_number">Button control</param>
        /// <param name="o_error">Error message</param>
        public static bool SetDateAndRegnumber(JazzReq i_req, Button i_button_reg_date_number, Label i_label_reg_date_number, out string o_error)
        {
            o_error = @"";
            bool ret_set = true;

            if (null == i_req)
            {
                o_error = @"RequestBand.SetDateAndRegnumber i_req is null";
                return false;
            }
            if (null == i_button_reg_date_number && null == i_label_reg_date_number)
            {
                o_error = @"RequestBand.SetDateAndRegnumber i_button_reg_date_number and i_label_reg_date_number are null";
                return false;
            }

            string label_str = i_req.RegYear + @"-";
            if (i_req.RegMonth.Length == 1)
            {
                label_str = label_str + @"0";
            }
            label_str = label_str + i_req.RegMonth + @"-";


            if (i_req.RegDay.Length == 1)
            {
                label_str = label_str + @"0";
            }
            label_str = label_str + i_req.RegDay + @"          ";

            label_str = label_str + i_req.RegNumberName();

            if (null != i_button_reg_date_number)
            {
                i_button_reg_date_number.Text = label_str;
            }
            else if (null != i_label_reg_date_number)
            {
                i_label_reg_date_number.Text = label_str;
            }

            return ret_set;

        } // SetDateAndRegnumber

        /// <summary>Set "to evaluate" box editable or not</summary>
        public static void SetToEvaluateCheckBoxEditable(CheckBox i_check_box_evaluate_band, bool i_editable)
        {
            if (i_editable)
            {
                i_check_box_evaluate_band.Enabled = true;

                i_check_box_evaluate_band.BackColor = AdminUtils.ColorEnable();
            }
            else
            {
                i_check_box_evaluate_band.Enabled = false;

                i_check_box_evaluate_band.BackColor = AdminUtils.ColorDisable();
            }

        } // SetToEvaluateCheckBoxEditable

        #endregion // Set controls

        #region Private notes

        /// <summary>Read private notes from a local file
        /// <para>Private notes are not saved on the server. They are only saved in the computer.</para>
        /// <para>1. File name </para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output object JazzReq</param>
        /// <param name="o_error">Error message</param>
        public static bool ReadPrivateNotes(ref JazzReq io_jazz_req, out string o_error)
        {
            o_error = @"";

            if (io_jazz_req.PrivateNotes.Length > 0)
            {
                o_error = @"RequestBand.ReadPrivateNotes Not empty  PrivateNotes= " + io_jazz_req.PrivateNotes;

                return false;
            }

            string file_name = GetPrivateNotesFileName(ref io_jazz_req);

            if (!File.Exists(file_name))
            {
                return true;
            }

            string private_notes = File.ReadAllText(file_name);

            io_jazz_req.PrivateNotes = private_notes;

            return true;

        } // ReadPrivateNotes

        #endregion // Private notes

        #region Write data

        /// <summary>Write JazzReq data to the requests XML object corresponding to file JazzAnfragen.xml</summary>
        public static bool WriteReq(JazzReq i_jazz_req, out string o_error)
        {
            if (!WritePrivateNotes(ref i_jazz_req, out  o_error))
            {
                o_error = @"RequestBand.WriteReq WritePrivateNotes.WritePrivateNotes failed " + o_error;

                return false;
            }

            if (!JazzXml.SetRequest(i_jazz_req, out o_error))
            {
                o_error = @"RequestBand.WriteReq JazzXml.SetRequest failed " + o_error;

                return false;
            }

            return true;

        } // WriteReq

        /// <summary>Write private notes to a local file
        /// <para>Private notes are not saved on the server. They are only saved in the computer.</para>
        /// <para>1. File name </para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_req">Input/output object JazzReq</param>
        /// <param name="o_error">Error message</param>
        private static bool WritePrivateNotes(ref JazzReq io_jazz_req, out string o_error)
        {
            o_error = @"";

            string file_name = GetPrivateNotesFileName(ref io_jazz_req);

            bool file_exists = File.Exists(file_name);

            if (io_jazz_req.PrivateNotes.Length == 0 && !file_exists)
                return true;

            if (io_jazz_req.PrivateNotes.Equals(JazzXml.GetUndefinedNodeValue()))
            {
                string error_message = @"RequestBand.WritePrivateNotes Private Notes= " + JazzXml.GetUndefinedNodeValue() + "\n" +
                    @"Programming error! Please report to Gunnar" + "\n" +
                    @"Private notes was changed to 'nothing'. Just continue working!";

                MessageBox.Show(error_message);

                io_jazz_req.PrivateNotes = @"";

                if (!file_exists)
                    return true;
            }

            string private_notes = io_jazz_req.PrivateNotes;

            io_jazz_req.PrivateNotes = @"";

            
            File.WriteAllText(file_name, private_notes);

            return true;

        } // WritePrivateNotes

        /// <summary>Returns the full file name for the local file that holds the private notes</summary>
        private static string GetPrivateNotesFileName(ref JazzReq io_jazz_req)
        {
            string file_name = io_jazz_req.RegNumberName() + @".txt";

            string local_sub_dir = RequestStrings.LocalDirRequestFiles + @"\" + RequestStrings.LocalDirPrivateNotes;

            file_name = FileUtil.SubDirectory(local_sub_dir, Main.m_exe_directory) + @"\" + file_name;

            return file_name;
        }

        /// <summary>Returns true if the band name is set and if the name is unique</summary>
        public static bool IsBandNameUnique(string i_band_name, int i_reg_number, out string o_error)
        {
            string user_message = @"";

            o_error = @"";

            if (i_band_name.Trim().Length == 0)
            {
                user_message = RequestStrings.ErrMsgBandNameNotSet;

                o_error = user_message;

                return false;
            }

            if (!JazzXml.CheckRequestBandName(i_band_name, i_reg_number, out o_error))
            {
                o_error = @"RequestBand.WriteReq JazzXml.SetRequest failed " + o_error;

                user_message = RequestStrings.ErrMsgBandNameNotUnique;

                o_error = user_message;

                return false;
            }

            return true;

        } // IsBandNameUnique

        #endregion // Write data

        #region Remove request

        /// <summary>Remove JazzReq object of the requests XML object corresponding to the file JazzAnfragen.xml
        /// <para>1. Delete sound (mp3) files. Call of DeleteAudioOne, DeleteAudioTwo and DeleteAudioThree if files exist</para>
        /// <para>2. Remove rhe request. Call of JazzXml.RemoveRequest</para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_textbox_message">Text box for messages</param>
        /// <param name="o_error">Error message</param>
        public static bool RemoveReq(JazzReq i_jazz_req, TextBox i_textbox_message, out string o_error)
        {
            string error_message = @"";
            if (i_jazz_req.AudioOne.Length != 0)
            {
                // Please note that the mp3 files will no longer be deleted. They will first only be marked (renamed) that they shall be deleted
                if (!DeleteAudioOne(ref i_jazz_req, i_textbox_message, out error_message))
                {
                    o_error = @"RequestBand.RemoveReq DeleteAudioOne failed " + error_message;
                    return false;
                }
            }

            if (i_jazz_req.AudioTwo.Length != 0)
            {
                // Please note that the mp3 files will no longer be deleted. They will first only be marked (renamed) that they shall be deleted
                if (!DeleteAudioTwo(ref i_jazz_req, i_textbox_message, out error_message))
                {
                    o_error = @"RequestBand.RemoveReq DeleteAudioTwo failed " + error_message;
                    return false;
                }
            }

            if (i_jazz_req.AudioThree.Length != 0)
            {
                // Please note that the mp3 files will no longer be deleted. They will first only be marked (renamed) that they shall be deleted
                if (!DeleteAudioThree(ref i_jazz_req, i_textbox_message, out error_message))
                {
                    o_error = @"RequestBand.RemoveReq DeleteAudioThree failed " + error_message;
                    return false;
                }
            }

            if (!JazzXml.RemoveRequest(i_jazz_req, out o_error))
            {
                o_error = @"RequestBand.RemoveReq JazzXml.SetRequest failed " + o_error;

                return false;
            }

            return true;

        } // RemoveReq

        #endregion // Remove request

        #region Upload of mp3 files

        /// <summary>Upload of AudioOne mp3 files</summary>
        public static bool UploadAudioOne(ref JazzReq io_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, TextBox i_textbox_message, out string o_error)
        {
            return UploadAudio(ref io_jazz_req, i_folder_browser_dialog_audio, 1 , i_textbox_message, out o_error);

        } // UploadAudioOne

        /// <summary>Upload of AudioTwo mp3 files</summary>
        public static bool UploadAudioTwo(ref JazzReq io_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, TextBox i_textbox_message, out string o_error)
        {
            return UploadAudio(ref io_jazz_req, i_folder_browser_dialog_audio, 2, i_textbox_message, out o_error);

        } // UploadAudioTwo

        /// <summary>Upload of AudioThree mp3 files</summary>
        public static bool UploadAudioThree(ref JazzReq io_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, TextBox i_textbox_message, out string o_error)
        {
            return UploadAudio(ref io_jazz_req, i_folder_browser_dialog_audio, 3, i_textbox_message, out o_error);

        } // UploadAudioThree

        /// <summary>Upload of Audio mp3 files 
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_folder_browser_dialog_audio">Folder browser dialog</param>
        /// <param name="i_audio_number">Audio number Eq. 1: AudioOne Eq. 2: AudioTwo Eq. 3: AudioThree</param>
        /// <param name="o_error">Error message</param>
        private static bool UploadAudio(ref JazzReq io_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, int i_audio_number, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            if (!UploadAudioInputCheck(io_jazz_req, i_folder_browser_dialog_audio, i_audio_number, i_textbox_message, out o_error))
            {
                return false;
            }

            string cd_dir_name = @"";
            string[] sound_files = null;

            if (!UploadAudioGetFiles(i_folder_browser_dialog_audio, out cd_dir_name, out sound_files, out o_error))
            {
                return false;
            }

            string server_dir_name = @"";
            if (!UploadAudioCreateServerDirectory(io_jazz_req, i_audio_number, out server_dir_name, out o_error))
            {
                return false;
            }

            if (!UploadAudioFiles(sound_files, server_dir_name,  i_textbox_message, out o_error))
            {
                return false;
            }

            if (1 == i_audio_number)
            {
                io_jazz_req.AudioOne = server_dir_name;
                io_jazz_req.AudioOneCd = cd_dir_name;
            }
            else if (2 == i_audio_number)
            {
                io_jazz_req.AudioTwo = server_dir_name;
                io_jazz_req.AudioTwoCd = cd_dir_name;
            }
            else if (3 == i_audio_number)
            {
                io_jazz_req.AudioThree = server_dir_name;
                io_jazz_req.AudioThreeCd = cd_dir_name;
            }

            return true;

        } // UploadAudio

        /// <summary>Upload all the mp3 files
        /// <para>1. Upload files. Calls of UpLoad.UploadOneFile</para>
        /// <para>If file name contains escape characters a copy will be created. Call of CopyFile</para>
        /// <para>The copied file will be deleted. Call of DeleteCopiedFile</para>
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_sound_files">All mp3 files</param>
        /// <param name="i_server_dir_name">Name of the server directory</param>
        /// <param name="i_textbox_message">Text box control for the showing of progress messages</param>
        /// <param name="o_error">Error message</param>
        private static bool UploadAudioFiles(string[] i_sound_files, string i_server_dir_name, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            if (null == i_sound_files || 0  == i_sound_files.Length)
            {
                o_error = "RequestBand.UploadAudioFiles Input file names null or no file names";
                return false;
            }

            i_textbox_message.Text = @"";
            i_textbox_message.Refresh();

            UpLoad htpp_upload = new UpLoad();
            bool to_www = true;

            string server_dir_name = RemoveSlashInDirName(i_server_dir_name);
            
            for (int index_file=0; index_file< i_sound_files.Length; index_file++)
            {
                string local_file_name_orig = i_sound_files[index_file];

                bool b_copied = false;
                string local_file_name = @"";
                if (!CopyFile(local_file_name_orig, out local_file_name, out b_copied, out  o_error))
                {
                    o_error = @"RequestBand.UploadAudioFiles CopyFile failed:" + o_error;
                    return false;
                }

                string server_file_name = server_dir_name + Path.GetFileName(local_file_name);

                i_textbox_message.Text = RequestStrings.MsgUploadFile + Path.GetFileName(local_file_name);
                i_textbox_message.Refresh();

                if (!htpp_upload.OneFile(to_www, server_file_name, local_file_name, out o_error))
                {
                    o_error = "RequestBand.UploadAudioFiles Upload.OneFile failed: " + o_error;
                    return false;
                }

                if (!DeleteCopiedFile(b_copied, local_file_name, out o_error))
                {
                    o_error = @"RequestBand.UploadAudioFiles DeleteCopiedFile failed:" + o_error;
                    return false;
                }
            }

            i_textbox_message.Text = RequestStrings.MsgAllFilesUploaded;
            i_textbox_message.Refresh();

            return true;

        } // UploadAudioFiles

        /// <summary>Creates a file copy if the file name has characters like ä, ö, ü, é,  etc
        /// <para></para>
        /// </summary>
        /// <param name="i_local_file_name_orig">Original full file name</param>
        /// <param name="o_local_file_name">Full file name</param>
        /// <param name="o_copied">Flag telling if the file is copied</param>
        /// <param name="o_error">Error message</param>
        private static bool CopyFile(string i_local_file_name_orig, out string o_local_file_name, out bool o_copied, out string o_error)
        {
            o_error = @"";
            o_local_file_name = @"";
            o_copied = false;

            string file_name_orig = Path.GetFileName(i_local_file_name_orig);
            string dir_name_orig = Path.GetDirectoryName(i_local_file_name_orig) + @"\";

            string file_name_mod = ModifyFileName(file_name_orig);

            if (file_name_mod.Equals(file_name_orig))
            {
                o_local_file_name = i_local_file_name_orig;
                o_copied = false;
                return true;
            }

            string local_file_name_copy = dir_name_orig + file_name_mod;

            try
            {
                File.Copy(i_local_file_name_orig, local_file_name_copy);
            }
            catch
            {
                o_local_file_name = i_local_file_name_orig;
                o_copied = false;
                return true;
                // o_error = "RequestBand.CopyFile Failed copying file ";
                //return false;
            }
    

            o_local_file_name = local_file_name_copy;

            o_copied = true;

            return true;

        } // CopyFile

        /// <summary>Deletes the copied file
        /// <para></para>
        /// </summary>
        /// <param name="i_copied">Flag telling if the file is copied</param>
        /// <param name="i_local_file_name">Full file name</param>
        /// <param name="o_error">Error message</param>
        private static bool DeleteCopiedFile(bool i_copied, string i_local_file_name, out string o_error)
        {
            o_error = @"";

            if (!i_copied)
                return true;

            try
            {
                File.Delete(i_local_file_name);
            }
            catch
            {
                o_error = "RequestBand.DeleteCopiedFile Failed deleting file ";
                return false;
            }

            return true;
        } // DeleteCopiedFile

        /// <summary>Modifies the file name
        /// <para>Escape signs, é, etc are removed. Spaces are kept.</para>
        /// <para>Refer also to AdminUtils.ModifyBandNameForDirectory</para>
        /// </summary>
        private static string ModifyFileName(string i_file_name)
        {
            string mod_str_1 = i_file_name;

            string mod_str_2 = @"";
            
            for (int index_char = 0; index_char < mod_str_1.Length; index_char++)
            {
                string current_char = mod_str_1.Substring(index_char, 1);

                if (current_char.Equals(" "))
                {
                    mod_str_2 = mod_str_2 + " ";   // Don't change
                }
                else if (current_char.Equals("'"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ʻ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ʼ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ʽ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ʾ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ʿ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ˈ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ˊ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ˋ"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("’"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("\""))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals(@","))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("â"))
                {
                    mod_str_2 = mod_str_2 + @"a";
                }
                else if (current_char.Equals("ā"))
                {
                    mod_str_2 = mod_str_2 + @"a";
                }
                else if (current_char.Equals("á"))
                {
                    mod_str_2 = mod_str_2 + @"a";
                }
                else if (current_char.Equals("ê"))
                {
                    mod_str_2 = mod_str_2 + @"e";
                }
                else if (current_char.Equals("é"))
                {
                    mod_str_2 = mod_str_2 + @"e";
                }
                else if (current_char.Equals("è"))
                {
                    mod_str_2 = mod_str_2 + @"e";
                }
                else if (current_char.Equals("ç"))
                {
                    mod_str_2 = mod_str_2 + @"c";
                }
                else if (current_char.Equals("Ã"))
                {
                    mod_str_2 = mod_str_2 + @"A";
                }
                else if (current_char.Equals("&"))
                {
                    mod_str_2 = mod_str_2 + @"";
                }
                else if (current_char.Equals("ä"))
                {
                    mod_str_2 = mod_str_2 + @"ae";
                }
                else if (current_char.Equals("å"))
                {
                    mod_str_2 = mod_str_2 + @"ao";
                }
                else if (current_char.Equals("Å"))
                {
                    mod_str_2 = mod_str_2 + @"AO";
                }
                else if (current_char.Equals("à"))
                {
                    mod_str_2 = mod_str_2 + @"a";
                }
                else if (current_char.Equals("À"))
                {
                    mod_str_2 = mod_str_2 + @"A";
                }
                else if (current_char.Equals("ü"))
                {
                    mod_str_2 = mod_str_2 + @"ue";
                }
                else if (current_char.Equals("ö"))
                {
                    mod_str_2 = mod_str_2 + @"oe";
                }
                else if (current_char.Equals("ø"))
                {
                    mod_str_2 = mod_str_2 + @"oe";
                }
                else if (current_char.Equals("Ä"))
                {
                    mod_str_2 = mod_str_2 + @"AE";
                }
                else if (current_char.Equals("Ü"))
                {
                    mod_str_2 = mod_str_2 + @"UE";
                }
                else if (current_char.Equals("Ö"))
                {
                    mod_str_2 = mod_str_2 + @"OE";
                }
                else if (current_char.Equals("Ø"))
                {
                    mod_str_2 = mod_str_2 + @"OE";
                }
                else if (current_char.Equals("À"))
                {
                    mod_str_2 = mod_str_2 + @"A";
                }
                else
                {
                    mod_str_2 = mod_str_2 + current_char;
                }
            }

            mod_str_2 = KeepOnlyAcceptedCharsInFileName(mod_str_2);

            return mod_str_2;

        } // ModifyFileName

        /// <summary>Modifies the file name
        /// <para>Only the characters defined in this function is kept</para>
        /// <para>Other characters are replaced with underscore (_)</para>
        /// </summary>
        private static string KeepOnlyAcceptedCharsInFileName(string i_file_name)
        {
            string mod_str_1 = i_file_name;

            string mod_str_2 = @"";

            for (int index_char = 0; index_char < mod_str_1.Length; index_char++)
            {
                string current_char = mod_str_1.Substring(index_char, 1);

                if ( current_char.Equals(" ") || current_char.Equals(".") || // Space und . normally preceeding the file extension
                     current_char.Equals("0") || current_char.Equals("1") ||
                     current_char.Equals("2") || current_char.Equals("3") ||
                     current_char.Equals("4") || current_char.Equals("5") ||
                     current_char.Equals("6") || current_char.Equals("7") ||
                     current_char.Equals("8") || current_char.Equals("9") ||
                     current_char.Equals("a") || current_char.Equals("A") ||
                     current_char.Equals("b") || current_char.Equals("B") ||
                     current_char.Equals("c") || current_char.Equals("C") ||
                     current_char.Equals("d") || current_char.Equals("D") ||
                     current_char.Equals("e") || current_char.Equals("E") ||
                     current_char.Equals("f") || current_char.Equals("F") ||
                     current_char.Equals("g") || current_char.Equals("G") ||
                     current_char.Equals("h") || current_char.Equals("H") ||
                     current_char.Equals("i") || current_char.Equals("I") ||
                     current_char.Equals("j") || current_char.Equals("J") ||
                     current_char.Equals("k") || current_char.Equals("K") ||
                     current_char.Equals("l") || current_char.Equals("L") ||
                     current_char.Equals("m") || current_char.Equals("M") ||
                     current_char.Equals("n") || current_char.Equals("N") ||
                     current_char.Equals("o") || current_char.Equals("O") ||
                     current_char.Equals("p") || current_char.Equals("P") ||
                     current_char.Equals("q") || current_char.Equals("Q") ||
                     current_char.Equals("r") || current_char.Equals("R") ||
                     current_char.Equals("s") || current_char.Equals("S") ||
                     current_char.Equals("t") || current_char.Equals("T") ||
                     current_char.Equals("u") || current_char.Equals("U") ||
                     current_char.Equals("v") || current_char.Equals("V") ||
                     current_char.Equals("w") || current_char.Equals("W") ||
                     current_char.Equals("x") || current_char.Equals("X") ||
                     current_char.Equals("y") || current_char.Equals("Y") ||
                     current_char.Equals("z") || current_char.Equals("Z"))
                {
                    mod_str_2 = mod_str_2 + current_char;
                }
                else
                {
                    mod_str_2 = mod_str_2 + "_";
                }

            } // index_char

            return mod_str_2;

        } // KeepOnlyAcceptedCharsInFileName


        /// <summary>Removes the first slash in the server directory name
        /// </summary>
        /// <param name="i_server_dir_name">Server directory name</param>
        private static string RemoveSlashInDirName(string i_server_dir_name)
        {
            string ret_server_dir_name = i_server_dir_name;

            string first_char = ret_server_dir_name.Substring(0, 1);
            if (first_char.Equals("/"))
            {
                ret_server_dir_name = ret_server_dir_name.Substring(1);
            }

            return ret_server_dir_name;

        } // RemoveSlashInDirName

        /// <summary>Create server directory for the mp3 files
        /// <para>1. Create request directory. Call of JazzReq.RegNumberName, upload.DoesDirectoryExist and upload.CreateServerDirectory</para>
        /// <para>2. Create request subdirectory AudioOne, AudioTwo or AudioThree. Call of upload.DoesDirectoryExist and upload.CreateServerDirectory</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_req">Object JazzReq</param>
        /// <param name="i_audio_number">Audio number Eq. 1: AudioOne Eq. 2: AudioTwo Eq. 3: AudioThree</param>
        /// <param name="o_server_dir_name">The server directory name for the mp3 files</param>
        /// <param name="o_error">Error message</param>
        private static bool UploadAudioCreateServerDirectory(JazzReq i_jazz_req, int i_audio_number, out string o_server_dir_name, out string o_error)
        {
            o_error = @"";
            o_server_dir_name = @"";

            string req_dir_audio = @"/www/" + RequestStrings.DirNameAudio + @"/" + i_jazz_req.RegNumberName() + @"/";

            UpLoad upload = new UpLoad();
            bool to_www = true;

            string ftp_response = @"";

            if (!upload.DoesDirectoryExist(to_www, req_dir_audio, out ftp_response))
            {
                if (!upload.CreateServerDirectory(to_www, req_dir_audio, out o_error))
                {
                    o_error = "RequestBand.UploadAudioCreateServerDirectory UpLoad.CreateServerDirectory failed req_dir_audio " + o_error;

                    return false;
                }
            }

            string sub_dir_cd = req_dir_audio;

            if (1 == i_audio_number)
            {
                sub_dir_cd = sub_dir_cd + RequestStrings.DirNameAudioOne + @"/";
            }
            else if (2 == i_audio_number)
            {
                sub_dir_cd = sub_dir_cd + RequestStrings.DirNameAudioTwo + @"/";
            }
            else if (3 == i_audio_number)
            {
                sub_dir_cd = sub_dir_cd + RequestStrings.DirNameAudioThree + @"/";
            }


            if (!upload.DoesDirectoryExist(to_www, sub_dir_cd, out ftp_response))
            {
                if (!upload.CreateServerDirectory(to_www, sub_dir_cd, out o_error))
                {
                    o_error = "RequestBand.UploadAudioCreateServerDirectory UpLoad.CreateServerDirectory failed sub_dir_cd " + o_error;

                    return false;
                }
            }

            o_server_dir_name = sub_dir_cd;

            return true;

        } // UploadAudioInputCheck

        /// <summary>Get the sound (mp3) files that shall be uploaded
        /// <para>1. User input of directory. Call of FolderBrowserDialog.ShowDialog</para>
        /// <para>2. Determine the number of sound files. Calls of IsSoundFile</para>
        /// <para>3. Create and return the array of sound file names.</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_folder_browser_dialog_audio">Folder browser dialog</param>
        /// <param name="o_cd_dir_name">The directory name that is assumed to be the name of the CD</param>
        /// <param name="o_sound_files">All sound files (.mp3)</param>
        /// <param name="i_audio_number">Audio number Eq. 1: AudioOne Eq. 2: AudioTwo Eq. 3: AudioThree</param>
        /// <param name="o_error">Error message</param>
        private static bool UploadAudioGetFiles(FolderBrowserDialog i_folder_browser_dialog_audio, out string o_cd_dir_name, out string[] o_sound_files, out string o_error)
        {
            o_error = @"";
            o_cd_dir_name = @"";

            o_sound_files = null;

            i_folder_browser_dialog_audio.SelectedPath = GetAudioFolderUpload();
            DialogResult result = i_folder_browser_dialog_audio.ShowDialog();
            string cd_dir_name = @"";
            if (result == DialogResult.OK)
            {
                cd_dir_name = i_folder_browser_dialog_audio.SelectedPath;
                SetAudioFolderUpload(cd_dir_name);
            }
            else
            {
                o_error = RequestStrings.MsgUploadDirectoryNotSelected;
                return false;
            }

            string[] all_files = Directory.GetFiles(cd_dir_name);
            if (all_files.Length == 0)
            {
                o_error = RequestStrings.ErrMsgDirectoryIsEmpty;
                return false;
            }

            int n_number_sound_files = 0;

            for (int index_file_all=0; index_file_all < all_files.Length; index_file_all++)
            {
                string current_file_name = all_files[index_file_all];
                if (IsSoundFile(current_file_name))
                {
                    n_number_sound_files = n_number_sound_files + 1;
                }
            }

            if (n_number_sound_files == 0)
            {
                o_error = RequestStrings.ErrMsgDirectoryHasNoSoundFiles;
                return false;
            }

            o_sound_files = new string[n_number_sound_files];

            int index_add_file_name = -1;
            for (int index_file = 0; index_file < all_files.Length; index_file++)
            {
                string file_name = all_files[index_file];
                if (IsSoundFile(file_name))
                {
                    index_add_file_name = index_add_file_name + 1;
                    o_sound_files[index_add_file_name] = file_name;
                }
            }

            // GetFileName returns the folder name
            o_cd_dir_name = Path.GetFileName(cd_dir_name);

            return true;

        } // UploadAudioGetFiles

        /// <summary>Returns true if it is a sound file
        /// <para>A sound file has extension mp3, mp4, m4a or wav. Other file formats are not yet implemented</para>
        /// </summary>
        /// <param name="i_file_name">File name</param>
        private static bool IsSoundFile(string i_file_name)
        {
            string file_extension = Path.GetExtension(i_file_name);

            if (file_extension.Equals(".mp3"))
            {
                return true;
            }
            else if (file_extension.Equals(".mp4"))
            {
                return true;
            }
            else if (file_extension.Equals(".m4a"))
            {
                return true;
            }
            else if (file_extension.Equals(".wav"))
            {
                return true;
            }
            else
            {
                return false;
            }           

        } // IsSoundFile

        /// <summary>Check of input for function UploadAudio
        /// </summary>
        /// <param name="i_folder_browser_dialog_audio">Folder browser dialog</param>
        /// <param name="i_audio_number">Audio number Eq. 1: AudioOne Eq. 2: AudioTwo Eq. 3: AudioThree</param>
        /// <param name="o_error">Error message</param>
        private static bool UploadAudioInputCheck(JazzReq i_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, int i_audio_number, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            if (null == i_jazz_req)
            {
                o_error = @"RequestBand.UploadAudioInputCheck Input i_jazz_req is null";

                return false;
            }

            if (null == i_folder_browser_dialog_audio)
            {
                o_error = @"RequestBand.UploadAudioInputCheck Input FolderBrowserDialog is null";

                return false;
            }

            if (i_audio_number < 1 || i_audio_number > 3)
            {
                o_error = @"RequestBand.UploadAudioInputCheck i_audio_number= " + i_audio_number.ToString() + @" is not 1, 2 or 3";

                return false;
            }

            return true;

        } // UploadAudioInputCheck

        #endregion // Upload of mp3 files

        #region Delete mp3 files

        /// <summary>Delete (rename for delete) AudioOne mp3 files</summary>
        public static bool DeleteAudioOne(ref JazzReq i_jazz_req, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            string server_dir = i_jazz_req.AudioOne;

            if (server_dir.Length == 0)
            {
                o_error = "RequestBand.DeleteAudioOne Nothing to delete. Note that true is returned";
                return true;
            }

            if (!DeleteAudio(server_dir, i_textbox_message, out o_error))
            {
                o_error = "RequestBand.DeleteAudioOne DeleteAudio failed " + o_error;
                return false;
            }

            i_jazz_req.AudioOne = @"";
            i_jazz_req.AudioOneCd = @"";

            return true;

        } // DeleteAudioOne

        /// <summary>Delete (rename for delete) AudioTwo mp3 files</summary>
        public static bool DeleteAudioTwo(ref JazzReq i_jazz_req, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            string server_dir = i_jazz_req.AudioTwo;

            if (server_dir.Length == 0)
            {
                o_error = "RequestBand.DeleteAudioTwo Nothing to delete. Note that true is returned";
                return true;
            }

            if (!DeleteAudio(server_dir, i_textbox_message, out o_error))
            {
                o_error = "RequestBand.DeleteAudioTwo DeleteAudio failed " + o_error;
                return false;
            }

            i_jazz_req.AudioTwo = @"";
            i_jazz_req.AudioTwoCd = @"";

            return true;

        } // DeleteAudioTwo

        /// <summary>Delete (rename for delete) AudioThree mp3 files</summary>
        public static bool DeleteAudioThree(ref JazzReq i_jazz_req, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            string server_dir = i_jazz_req.AudioThree;

            if (server_dir.Length == 0)
            {
                o_error = "RequestBand.DeleteAudioThree Nothing to delete. Note that true is returned";
                return true;
            }

            if (!DeleteAudio(server_dir, i_textbox_message, out o_error))
            {
                o_error = "RequestBand.DeleteAudioThree DeleteAudio failed " + o_error;
                return false;
            }

            i_jazz_req.AudioThree = @"";
            i_jazz_req.AudioThreeCd = @"";

            return true;

        } // DeleteAudioThree

        /// <summary>Delete audio (mp3) files.
        /// <para>1. Get file names. Call of AudioGetFileNames.</para>
        /// <para>2. Delete (rename for delete) all files. Call of DeleteAudioFiles.</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_server_dir_name">The server directory name for the mp3 files</param>
        /// <param name="i_textbox_message">Message text box</param>
        /// <param name="o_error">Error message</param>
        public static bool DeleteAudio(string i_server_dir, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            string[] sound_files = null;

            if (!AudioGetFileNames(i_server_dir, out sound_files, out o_error))
            {
                o_error = "RequestBand.DeleteAudio AudioGetFileNames failed " + o_error;
                return false;
            }

            if (!DeleteAudioFiles(sound_files, i_server_dir, i_textbox_message, out o_error))
            {
                o_error = "RequestBand.DeleteAudio DeleteAudioFiles failed " + o_error;
                return false;
            }

            return true;

        } // DeleteAudio

        /// <summary>Delete all sound files by marking them that they shall be (finally) deleted 
        /// <para>The audio files will get a new extension (.mp3_to_be_deleted). Calls of JazzFtp.Execute.Run</para>
        /// <para>The for delete renamed file names are added to array Request.GetDeleteSoundFileNames. Calls of Request.AddDeleteSoundFileName</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_sound_files">Array of sound file names</param>
        /// <param name="i_server_dir_name">The server directory name for the sound files</param>
        /// <param name="i_textbox_message">Message text box</param>
        /// <param name="o_error">Error message</param>
        private static bool DeleteAudioFiles(string[] i_sound_files, string i_server_dir_name, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            if (null == i_sound_files || 0 == i_sound_files.Length)
            {
                o_error = "RequestBand.DeleteAudioFiles Input file names null or no file names";
                return false;
            }

            i_textbox_message.Text = @"";
            i_textbox_message.Refresh();

            int n_names = i_sound_files.Length;

            string[] file_names_delete = new string[n_names];

            for (int index_rename=0; index_rename< n_names; index_rename++)
            {
                string file_name_with_ext = i_sound_files[index_rename];
                string file_name = Path.GetFileNameWithoutExtension(file_name_with_ext);
                string file_ext = Path.GetExtension(file_name_with_ext);
                string file_name_del = file_name + file_ext + RequestStrings.RequestExtensionDelete;
                file_names_delete[index_rename] = file_name_del;
            }

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.RenameFile);
            ftp_input.ServerDirectory = i_server_dir_name;

            for (int index_delete = 0; index_delete < n_names; index_delete++)
            {
                string file_name_current = i_sound_files[index_delete];
                string file_name_new = file_names_delete[index_delete];

                ftp_input.ExecCase = JazzFtp.Input.Case.RenameFile; // ftp_input is re-used. TODO Should be changed
                ftp_input.ServerFileName = file_name_current;
                ftp_input.ServerRenameFileName = file_name_new;

                JazzFtp.Result result_rename = JazzFtp.Execute.Run(ftp_input);

                if (!result_rename.Status)
                {
                    o_error = @"RequestBand.DeleteAudioFiles JazzFtp.Execute.Run failed " + result_rename.ErrorMsg;
                    return false;
                }

                string file_name_final_delete = i_server_dir_name + file_name_new;
                file_name_final_delete = file_name_final_delete.Substring(1); // Remove the first slash
                Request.AddDeleteSoundFileName(file_name_final_delete);

                i_textbox_message.Text = file_name_current + RequestStrings.MsgPhotoFileRenamed + file_name_new;
                i_textbox_message.Refresh();

            } // index_delete

            i_textbox_message.Text = @"";
            i_textbox_message.Refresh();

            return true;

        } // DeleteAudioFiles

        #endregion // Delete mp3 files

        #region Download of mp3 files

        /// <summary>Download of AudioOne mp3 files</summary>
        public static bool DownloadAudioOne(JazzReq i_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, string i_file_name, TextBox i_textbox_message, out string o_error)
        {
            return DownloadAudio(i_jazz_req, i_folder_browser_dialog_audio, i_file_name, 1, i_textbox_message, out o_error);

        } // DownloadAudioOne

        /// <summary>Download of DownloadAudioTwo mp3 files</summary>
        public static bool DownloadAudioTwo(JazzReq i_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, string i_file_name, TextBox i_textbox_message, out string o_error)
        {
            return DownloadAudio(i_jazz_req, i_folder_browser_dialog_audio, i_file_name, 2, i_textbox_message, out o_error);

        } // DownloadAudioTwo

        /// <summary>Download of DownloadAudioThree mp3 files</summary>
        public static bool DownloadAudioThree(JazzReq i_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, string i_file_name, TextBox i_textbox_message, out string o_error)
        {
            return DownloadAudio(i_jazz_req, i_folder_browser_dialog_audio, i_file_name, 3, i_textbox_message, out o_error);

        } // DownloadAudioThree

        /// <summary>Download of Audio mp3 files 
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_folder_browser_dialog_audio">Folder browser dialog</param>
        /// <param name="i_file_name">File name for the case that only one file shall be downloaded</param>
        /// <param name="i_audio_number">Audio number Eq. 1: AudioOne Eq. 2: AudioTwo Eq. 3: AudioThree</param>
        /// <param name="o_error">Error message</param>
        public static bool DownloadAudio(JazzReq i_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, string i_file_name, int i_audio_number, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            if (!DownloadAudioInputCheck(i_jazz_req, i_folder_browser_dialog_audio, i_file_name, i_audio_number, i_textbox_message, out o_error))
            {
                return false;
            }

            string local_dir = @"";

            if (!DownloadAudioGetLocalDir(i_jazz_req, i_folder_browser_dialog_audio, i_audio_number, out local_dir, out o_error))
            {
                return false;
            }

            string server_dir = @"";
            string[] sound_files = null;

            if (!DownloadAudioGetFileNames(i_jazz_req, i_audio_number, out server_dir, out sound_files, out o_error))
            {
                return false;
            }

            // DownloadAudioIsOneFile(sound_files, i_file_name, out only_one_file,  out o_error)
            bool only_one_file = false;

            if (!DownloadAudioIsOneFile(sound_files, i_file_name, out only_one_file, out o_error))
            {
                return false;
            }

            if (only_one_file)
            {
                if (!DownloadAudioOneFile(i_jazz_req, local_dir, server_dir, i_file_name, i_audio_number, i_textbox_message, out o_error))
                {
                    return false;
                }
            }
            else
            {
                if (!DownloadAudioAllFiles(i_jazz_req, local_dir, server_dir, sound_files, i_audio_number, i_textbox_message, out o_error))
                {
                    return false;
                }
            }

            return true;

        } // DownloadAudio

        /// <summary>Determines if only one file shall be downloaded or all files
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="i_sound_files">Names of all sound files</param>
        /// <param name="i_file_name">File name for the case that only one file shall be downloaded</param>
        /// <param name="o_only_one_file">Output flag telling if only one file shall be downloaded</param>
        /// <param name="o_error">Error message</param>
        public static bool DownloadAudioIsOneFile(string[] i_sound_files, string i_file_name, out bool o_only_one_file,  out string o_error)
        {
            o_error = @"";

            o_only_one_file = false;

            if (null == i_sound_files || i_sound_files.Length == 0)
            {
                o_error = @"RequestBand.DownloadAudioIsOneFile i_sound_files is null";
                return false;
            }

            if (i_file_name.Length < 4)
            {
                o_only_one_file = false;
                return true;
            }

            for (int index_name=0; index_name< i_sound_files.Length; index_name++)
            {
                string file_name = i_sound_files[index_name];

                if (file_name.Equals(i_file_name))
                {
                    o_only_one_file = true;
                    break;
                }
            }

            return true;

        } // DownloadAudioIsOneFile

        /// <summary>Download one Audio mp3 files 
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_local_dir">Local (to) directory for the sound files selected by the user</param>
        /// <param name="i_server_dir">Server (from) directory for the sound files</param>
        /// <param name="i_sound_file_names">File names</param>
        /// <param name="i_audio_number">Audio number Eq. 1: AudioOne Eq. 2: AudioTwo Eq. 3: AudioThree</param>
        /// <param name="i_textbox_message">Text box messages</param>
        /// <param name="o_error">Error message</param>
        private static bool DownloadAudioOneFile(JazzReq i_jazz_req, string i_local_dir, string i_server_dir, string i_sound_file_name, int i_audio_number, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";


            string cd_sub_directory = @"";

            if (1 == i_audio_number)
            {
                cd_sub_directory = i_jazz_req.AudioOneCd;
            }
            else if (2 == i_audio_number)
            {
                cd_sub_directory = i_jazz_req.AudioTwoCd;
            }
            else if (3 == i_audio_number)
            {
                cd_sub_directory = i_jazz_req.AudioThreeCd;
            }

            string save_local_dir = FileUtil.SubDirectory(cd_sub_directory, i_local_dir);

            Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            i_textbox_message.Text = RequestStrings.MsgDownloadFile + i_sound_file_name;
            i_textbox_message.Refresh();

            if (!ftp_download.DownloadFileServerLocal(i_server_dir, save_local_dir, i_sound_file_name, out o_error))
            {
                return false;
            }

            i_textbox_message.Text = RequestStrings.MsgOneFileDownloaded;
            i_textbox_message.Refresh();

            return true;

        } // DownloadAudioOneFile

        /// <summary>Download all Audio mp3 files 
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_local_dir">Local (to) directory for the sound files selected by the user</param>
        /// <param name="i_server_dir">Server (from) directory for the sound files</param>
        /// <param name="i_sound_file_names">File names</param>
        /// <param name="i_audio_number">Audio number Eq. 1: AudioOne Eq. 2: AudioTwo Eq. 3: AudioThree</param>
        /// <param name="i_textbox_message">Text box messages</param>
        /// <param name="o_error">Error message</param>
        private static bool DownloadAudioAllFiles(JazzReq i_jazz_req, string i_local_dir, string i_server_dir, string[] i_sound_file_names, int i_audio_number, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";


            string cd_sub_directory = @"";

            if (1 == i_audio_number)
            {
                cd_sub_directory = i_jazz_req.AudioOneCd;
            }
            else if (2 == i_audio_number)
            {
                cd_sub_directory = i_jazz_req.AudioOneCd;
            }
            else if (3 == i_audio_number)
            {
                cd_sub_directory = i_jazz_req.AudioOneCd;
            }

            string save_local_dir = FileUtil.SubDirectory(cd_sub_directory, i_local_dir);

            Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            for (int index_file = 0; index_file < i_sound_file_names.Length; index_file++)
            {
                string file_name = i_sound_file_names[index_file];

                i_textbox_message.Text = RequestStrings.MsgDownloadFile + file_name;
                i_textbox_message.Refresh();

                if (!ftp_download.DownloadFileServerLocal(i_server_dir, save_local_dir, file_name, out o_error))
                {
                    return false;
                }
            }

            i_textbox_message.Text = RequestStrings.MsgAllFilesDownloaded;
            i_textbox_message.Refresh();

            return true;

        } // DownloadAudioAllFiles

        /// <summary>Get the local directory from the user
        /// <para>Open folder browser dialog. Call of FolderBrowserDialog.ShowDialog</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_req">Object JazzReq</param>
        /// <param name="i_folder_browser_dialog_audio">Folder browser dialog</param>
        /// <param name="i_audio_number">Audio number Eq. 1: AudioOne Eq. 2: AudioTwo Eq. 3: AudioThree</param>
        /// <param name="o_local_dir">Local directory for the download</param>
        /// <param name="o_error">Error message</param>
        private static bool DownloadAudioGetLocalDir(JazzReq i_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, int i_audio_number, out string o_local_dir, out string o_error)
        {
            o_error = @"";
            o_local_dir = @"";

            i_folder_browser_dialog_audio.SelectedPath = GetAudioFolderDownload();
            DialogResult result = i_folder_browser_dialog_audio.ShowDialog();
            if (result == DialogResult.OK)
            {
                o_local_dir = i_folder_browser_dialog_audio.SelectedPath;
                SetAudioFolderDownload(o_local_dir);
            }
            else
            {
                o_error = RequestStrings.MsgDownloadDirectoryNotSelected;
                return false;
            }

            return true;

        } // DownloadAudioGetLocalDir

        /// <summary>Get the sound (mp3) file names that can be downloaded
        /// <para>Get the file name. Call of Ftp.DownLoad.GetServerDirectoryFileNames</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_req">Object JazzReq</param>
        /// <param name="i_audio_number">Audio number Eq. 1: AudioOne Eq. 2: AudioTwo Eq. 3: AudioThree</param>
        /// <param name="o_server_dir">Server directory for the files</param>
        /// <param name="o_sound_files">All sound files (.mp3)</param>
        /// <param name="o_error">Error message</param>
        public static bool DownloadAudioGetFileNames(JazzReq i_jazz_req, int i_audio_number, out string o_server_dir, out string[] o_sound_files, out string o_error)
        {
            o_error = @"";
            o_server_dir = @"";
            o_sound_files = null;

            string server_address_directory = @"";

            if (1 == i_audio_number)
            {
                server_address_directory = i_jazz_req.AudioOne;
            }
            else if (2 == i_audio_number)
            {
                server_address_directory = i_jazz_req.AudioTwo;
            }
            else if (3 == i_audio_number)
            {
                server_address_directory = i_jazz_req.AudioThree;
            }

            o_server_dir = server_address_directory;
 
            if (!AudioGetFileNames(server_address_directory, out o_sound_files, out o_error))
            {
                o_error = @"RequestBand.DownloadAudioGetFileNames AudioGetFileNames failed " + o_error;
                return false;
            }

            return true;

        } // DownloadAudioGetFileNames

        /// <summary>Get the sound (mp3) file names that can be downloaded or deleted
        /// <para>Get the file name. Call of Ftp.DownLoad.GetServerDirectoryFileNames</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_server_dir">Server directory for the files</param>
        /// <param name="o_sound_files">All sound files (.mp3)</param>
        /// <param name="o_error">Error message</param>
        private static bool AudioGetFileNames(string i_server_dir, out string[] o_sound_files, out string o_error)
        {
            o_error = @"";
            o_sound_files = null;

            /*QQQQQ
            Ftp.DownLoad ftp_download = new Ftp.DownLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            if (!ftp_download.GetServerDirectoryFileNames(i_server_dir, out o_sound_files, out o_error))
            {
                o_error = @"RequestBand.DownloadAudioGetFileNames Ftp.Download.AudioGetFileNames failed " + o_error;
                return false;
            }
    QQQ*/

            JazzFtp.Input ftp_input = new JazzFtp.Input(Main.ExeDirectory, JazzFtp.Input.Case.GetFileNames);
            ftp_input.ServerDirectory = i_server_dir;

            JazzFtp.Result result_dir_file_names = JazzFtp.Execute.Run(ftp_input);
            if (!result_dir_file_names.Status)
            {
                o_error = "RequestBand.DownloadAudioGetFileNames JazzFtp.Execute.Run failed " + result_dir_file_names.ErrorMsg;
                return false;
            }

            o_sound_files = result_dir_file_names.ArrayStr;

            o_sound_files = RemoveDeletedAudioFiles(o_sound_files, out o_error);
            if (null == o_sound_files)
            {
                o_error = "AudioGetFileNames " + o_error;

                return false;
            }

            return true;

        } // AudioGetFileNames

        /// <summary>Returns a string array where deleted audio files have been removed
        /// <para>There should be no such files!</para>
        /// <para>The user has probably closed the application when the request XML file was checked out</para>
        /// <para>TODO Perhaps: Add warning and remove the deleted files from the server</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_sound_files">Input string array with audio file names</param>
        /// <param name="o_error">Error message</param>
        private static string[] RemoveDeletedAudioFiles(string[] i_sound_files, out string o_error)
        {
            o_error = @"";

            if (null == i_sound_files)
            {
                o_error = "RequestBand.RemoveDeletedAudioFiles Input array is null";
                return null;
            }

            int n_delete_files = 0;


            for (int index_name=0; index_name< i_sound_files.Length; index_name++)
            {
                string current_file_name = i_sound_files[index_name];

                if (current_file_name.Contains(RequestStrings.RequestExtensionDelete))
                {
                    n_delete_files = n_delete_files + 1;
                }
            }

            if (n_delete_files == 0)
            {
                return i_sound_files;
            }

            int n_sound_files = i_sound_files.Length - n_delete_files;

            if (0 == n_sound_files)
            {
                o_error = "RequestBand.RemoveDeletedAudioFiles Only deleted audio files";

                return null;
            }

            string[] ret_sound_files = new string[n_sound_files];

            int index_out = 0;
            for (int index_file=0; index_file < i_sound_files.Length; index_file++)
            {
                string file_name = i_sound_files[index_file];

                if (!file_name.Contains(RequestStrings.RequestExtensionDelete))
                {
                    ret_sound_files[index_out] = file_name;

                    index_out = index_out + 1;
                }
            }

            return ret_sound_files;

        } // RemoveDeletedAudioFiles

        /// <summary>Check of input data to function DownloadAudio
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_folder_browser_dialog_audio">Folder browser dialog</param>
        /// <param name="i_file_name">File name for the case that only one file shall be downloaded</param>
        /// <param name="i_audio_number">Audio number Eq. 1: AudioOne Eq. 2: AudioTwo Eq. 3: AudioThree</param>
        /// <param name="o_error">Error message</param>
        public static bool DownloadAudioInputCheck(JazzReq i_jazz_req, FolderBrowserDialog i_folder_browser_dialog_audio, string i_file_name, int i_audio_number, TextBox i_textbox_message, out string o_error)
        {
            o_error = @"";

            if (null == i_jazz_req)
            {
                o_error = @"RequestBand.DownloadAudioInputCheck Input i_jazz_req is null";

                return false;
            }

            if (null == i_folder_browser_dialog_audio)
            {
                o_error = @"RequestBand.DownloadAudioInputCheck Input FolderBrowserDialog is null";

                return false;
            }

            if (i_audio_number < 1 || i_audio_number > 3)
            {
                o_error = @"RequestBand.DownloadAudioInputCheck i_audio_number= " + i_audio_number.ToString() + @" is not 1, 2 or 3";

                return false;
            }

            if (1 == i_audio_number)
            {
                if (i_jazz_req.AudioOne.Length == 0)
                {
                    o_error = @"RequestBand.DownloadAudioInputCheck AudioOne not set";

                    return false;
                }

                if (i_jazz_req.AudioOneCd.Length == 0)
                {
                    o_error = @"RequestBand.DownloadAudioInputCheck AudioOneCd not set";

                    return false;
                }
            }
            else if (2 == i_audio_number)
            {
                if (i_jazz_req.AudioTwo.Length == 0)
                {
                    o_error = @"RequestBand.DownloadAudioInputCheck AudioTwo not set";

                    return false;
                }

                if (i_jazz_req.AudioTwoCd.Length == 0)
                {
                    o_error = @"RequestBand.DownloadAudioInputCheck AudioTwoCd not set";

                    return false;
                }
            }
            else if (3 == i_audio_number)
            {
                if (i_jazz_req.AudioThree.Length == 0)
                {
                    o_error = @"RequestBand.DownloadAudioInputCheck AudioThree not set";

                    return false;
                }

                if (i_jazz_req.AudioThreeCd.Length == 0)
                {
                    o_error = @"RequestBand.DownloadAudioInputCheck AudioThreeCd not set";

                    return false;
                }
            }

            return true;

        } // DownloadAudioInputCheck

        #endregion // Download of mp3 files

        #region Download, upload and delete of information file

        /// <summary>Download information PDF file
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_info_file_number">Info file number Eq. 1: InfoOne Eq. 2: InfoTwo Eq. 3: InfoThree</param>
        /// <param name="o_error">Error message</param>
        public static bool DownloadInfoPdfFile(JazzReq i_jazz_req, int i_info_file_number, out bool i_cancel_download, out string o_error)
        {
            o_error = @"";
            i_cancel_download = false;

            if (!CheckInputInfoPdfFile(i_jazz_req, i_info_file_number, out o_error))
            {
                o_error = @"RequestBand.DownloadInfoPdfFile CheckInputInfoPdfFile failed " + o_error;
                return false;
            }

            string server_file_name = @"";
            if (!GetServerAddressInfoFile(i_jazz_req, i_info_file_number, out server_file_name, out o_error))
            {
                o_error = @"RequestBand.DownloadInfoPdfFile GetServerAddressInfoFile failed " + o_error;
                return false;
            }

            string file_extensions = @"pdf";
            string server_directory = Path.GetDirectoryName(server_file_name);
            server_directory = server_directory.Replace(@"\", @"/");
            if (server_directory.Contains(@"/www/"))
                server_directory = server_directory.Substring(5);

            string download_file_name = Path.GetFileName(server_file_name);
            string file_type_case = @"pdf";

            if (!OpenSaveDialog.Download(server_directory, download_file_name, file_type_case, file_extensions, out i_cancel_download, out o_error))
            {
                o_error = @"RequestBand.DownloadInfoPdfFile OpenSaveDialog.Download failed " + o_error;
                return false;
            }

            return true;

        } // DownloadInfoPdfFile

        /// <summary>Upload information PDF file
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_info_file_number">Info file number Eq. 1: InfoOne Eq. 2: InfoTwo Eq. 3: InfoThree</param>
        /// <param name="o_error">Error message</param>
        public static bool UploadInfoPdfFile(ref JazzReq io_jazz_req, int i_info_file_number, out bool o_cancel_upload, out string o_error)
        {
            o_error = @"";
            o_cancel_upload = false;

            if (!CheckInputInfoPdfFile(io_jazz_req, i_info_file_number, out o_error))
            {
                o_error = @"RequestBand.UploadInfoPdfFile CheckInputInfoPdfFile failed " + o_error;
                return false;
            }

            string file_name_upload = @"";
            string file_extensions = @"pdf";

            if (!OpenSaveDialog.GetFileName("pdf", file_extensions, out o_cancel_upload, out file_name_upload, out o_error))
            {
                o_error = @"RequestBand.UploadInfoPdfFile OpenSaveDialog.GetFileName failed " + o_error;
                return false;
            }

            if (o_cancel_upload)
            {
                return true;
            }

            string file_name_input = @"";

            if (!GetInfoFileName(io_jazz_req, i_info_file_number, out file_name_input, out o_error))
            {
                file_name_input = @""; // TODO Add function IfDefined or ... TODO
                // o_error = @"RequestBand.UploadInfoPdfFile GetInfoFileName failed " + o_error;

                //return false;
            }

            string file_name_without_path = Path.GetFileName(file_name_upload);

            if (!SetInfoFileName(ref io_jazz_req, i_info_file_number, file_name_without_path, out o_error))
            {
                o_error = @"RequestBand.UploadInfoPdfFile SetInfoFileName failed " + o_error;

                return false;
            }

            string server_file_name = @"";
            if (!GetServerAddressInfoFile(io_jazz_req, i_info_file_number, out server_file_name, out o_error))
            {
                o_error = @"RequestBand.UploadInfoPdfFile GetServerAddressInfoFile failed " + o_error;
                return false;
            }

            if (file_name_input.Equals(Path.GetFileName(server_file_name)))
            {
                if (!OpenSaveDialog.BackupFile(server_file_name, out o_error))
                {
                    o_error = @"RequestBand.UploadInfoPdfFile OpenSaveDialog.BackupFile failed " + o_error;

                    return false;
                }
            }

            if (!UploadOneFile(file_name_upload, server_file_name, out o_error))
            {
                o_error = @"RequestBand.UploadInfoPdfFile UploadOneFile failed " + o_error;

                return false;
            }


            return true;

        } // UploadInfoPdfFile

        /// <summary>Upload one information file
        /// <para>1. Upload file. Call of Upload.OneFile</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_local_file_name">Local file name with path</param>
        /// <param name="i_server_file_name">Server file name with path</param>
        /// <param name="o_error">Error message</param>
        private static bool UploadOneFile(string i_local_file_name, string i_server_file_name, out string o_error)
        {
            o_error = @"";

            if (0 == i_local_file_name.Length)
            {
                o_error = "RequestBand.UploadOneFile Input local file name not set";
                return false;
            }

            if (0 == i_server_file_name.Length)
            {
                o_error = "RequestBand.UploadOneFile Input server file name not set";
                return false;
            }

            string dir_local_file = Path.GetDirectoryName(i_local_file_name);
            if (dir_local_file.Length == 0)
            {
                o_error = "RequestBand.UploadOneFile Input local file name has no path";
                return false;
            }

            string dir_server_file = Path.GetDirectoryName(i_server_file_name);
            if (dir_server_file.Length == 0)
            {
                o_error = "RequestBand.UploadOneFile Input server file name has no path";
                return false;
            }

            UpLoad htpp_upload = new UpLoad();
            bool to_www = true;

            string server_file_name_mod = RemoveSlashInDirName(i_server_file_name);

            if (!htpp_upload.OneFile(to_www, server_file_name_mod, i_local_file_name, out o_error))
            {
                o_error = "RequestBand.UploadOneFile Upload.OneFile failed: " + o_error;
                return false;
            }

            return true;

        } // UploadOneFile

        /// <summary>Delete information PDF file
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_info_file_number">Info file number Eq. 1: InfoOne Eq. 2: InfoTwo Eq. 3: InfoThree</param>
        /// <param name="o_error">Error message</param>
        public static bool DeleteInfoPdfFile(ref JazzReq io_jazz_req, int i_info_file_number, out string o_error)
        {
            o_error = @"";

            if (!CheckInputInfoPdfFile(io_jazz_req, i_info_file_number, out o_error))
            {
                o_error = @"RequestBand.DeleteInfoPdfFile CheckInputInfoPdfFile failed " + o_error;
                return false;
            }

            string server_file_name = @"";
            if (!GetServerAddressInfoFile(io_jazz_req, i_info_file_number, out server_file_name, out o_error))
            {
                o_error = @"RequestBand.DeleteInfoPdfFile GetServerAddressInfoFile failed " + o_error;
                return false;
            }

            // TODO Backup

            string server_dir = Path.GetDirectoryName(server_file_name);
            server_dir = server_dir.Replace(@"\", @"/") + @"/";

            string file_name = Path.GetFileName(server_file_name);

            Ftp.UpLoad htpp_upload = new Ftp.UpLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            if (!htpp_upload.DeleteFile(server_dir, file_name, out o_error))
            {
                o_error = "RequestBand.DeleteInfoPdfFile Upload.DeleteFile failed: " + o_error;
                return false;
            }

            if (!SetInfoFileName(ref io_jazz_req, i_info_file_number, @"", out o_error))
            {
                o_error = "RequestBand.DeleteInfoPdfFile SetInfoFileName failed: " + o_error;
                return false;
            }

            return true;

        } // DeleteInfoPdfFile

        /// <summary>Get full server name for the information file
        /// <para>1. Create request directory. Call of GetServerAddressInfoFile</para>
        /// <para>2. Get file name. Call of GetServerDirInfoFile</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_req">Object JazzReq</param>
        /// <param name="i_info_file_number">Info file number Eq. 1: InfoOne Eq. 2: InfoTwo Eq. 3: InfoThree</param>
        /// <param name="o_server_file_name">The full server file name for the information file</param>
        /// <param name="o_error">Error message</param>
        private static bool GetServerAddressInfoFile(JazzReq i_jazz_req, int i_info_file_number, out string o_server_file_name, out string o_error)
        {
            o_error = @"";
            o_server_file_name = @"";

            string req_dir_info = @"";

            if (!GetServerDirInfoFile(i_jazz_req, out req_dir_info, out o_error))
            {
                o_error = "RequestBand.GetServerAddressInfoFile GetServerDirInfoFile failed " + o_error;

                return false;
            }

            string file_name = @"";

            if (!GetInfoFileName(i_jazz_req, i_info_file_number, out file_name, out o_error))
            {
                o_error = "RequestBand.GetServerAddressInfoFile GetInfoFileName failed " + o_error;

                return false;
            }

            o_server_file_name = req_dir_info + file_name;

            return true;

        } // GetServerAddressInfoFile

        /// <summary>Get file name for the information file
        /// <para>2. Get file name InfoOne, InfoTwo or InfoThree from JazzReq</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_req">Object JazzReq</param>
        /// <param name="i_info_file_number">Info file number Eq. 1: InfoOne Eq. 2: InfoTwo Eq. 3: InfoThree</param>
        /// <param name="o_file_name">The information file name</param>
        /// <param name="o_error">Error message</param>
        public static bool GetInfoFileName(JazzReq i_jazz_req, int i_info_file_number, out string o_file_name, out string o_error)
        {
            o_error = @"";
            o_file_name = @"";

            if (1 == i_info_file_number)
            {
                o_file_name = i_jazz_req.InfoOne;
            }
            else if (2 == i_info_file_number)
            {
                o_file_name = i_jazz_req.InfoTwo;
            }
            else if (3 == i_info_file_number)
            {
                o_file_name = i_jazz_req.InfoThree;
            }
            else
            {
                o_error = "RequestBand.GetInfoFileName File number not 1, 2 or three";

                return false;
            }

            return true;

        } // GetInfoFileName

        /// <summary>Set file name for the information file
        /// <para>2. Set file name InfoOne, InfoTwo or InfoThree in JazzReq</para>
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Object JazzReq</param>
        /// <param name="i_info_file_number">Info file number Eq. 1: InfoOne Eq. 2: InfoTwo Eq. 3: InfoThree</param>
        /// <param name="i_file_name">The information file name without path</param>
        /// <param name="o_error">Error message</param>
        public static bool SetInfoFileName(ref JazzReq io_jazz_req, int i_info_file_number, string i_file_name, out string o_error)
        {
            o_error = @"";

            if (i_file_name.Length != 0)
            {
                string path_file = Path.GetDirectoryName(i_file_name);
                if (path_file.Length > 0)
                {
                    o_error = "RequestBand.SetInfoFileName Remove path " + path_file;

                    return false;
                }
            }

            if (1 == i_info_file_number)
            {
                io_jazz_req.InfoOne = i_file_name;
            }
            else if (2 == i_info_file_number)
            {
                io_jazz_req.InfoTwo = i_file_name;
            }
            else if (3 == i_info_file_number)
            {
                io_jazz_req.InfoThree = i_file_name;
            }
            else
            {
                o_error = "RequestBand.SetInfoFileName File number not 1, 2 or three";

                return false;
            }

            return true;

        } // SetInfoFileName

        /// <summary>Create/get server directory for an information file
        /// <para>1. Create request directory if not existing. Call of JazzReq.RegNumberName, upload.DoesDirectoryExist and upload.CreateServerDirectory</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_req">Object JazzReq</param>
        /// <param name="o_server_dir">The server directory name for an information file</param>
        /// <param name="o_error">Error message</param>
        private static bool GetServerDirInfoFile(JazzReq i_jazz_req, out string o_server_dir, out string o_error)
        {
            o_error = @"";
            o_server_dir = @"";

            string req_dir_info = @"/www/" + RequestStrings.LocalDirRequestFiles + @"/" + i_jazz_req.RegNumberName() + @"/";

            UpLoad upload = new UpLoad();
            bool to_www = true;

            string ftp_response = @"";

            if (!upload.DoesDirectoryExist(to_www, req_dir_info, out ftp_response))
            {
                if (!upload.CreateServerDirectory(to_www, req_dir_info, out o_error))
                {
                    o_error = "RequestBand.GetServerDirInfoFile UpLoad.CreateServerDirectory failed req_dir_info " + o_error;

                    return false;
                }
            }

            o_server_dir = req_dir_info;

            return true;

        } // GetServerDirInfoFile

        /// <summary>Check input data for the information PDF file
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_info_file_number">Info file number Eq. 1: InfoOne Eq. 2: InfoTwo Eq. 3: InfoThree</param>
        /// <param name="o_error">Error message</param>
        private static bool CheckInputInfoPdfFile(JazzReq i_jazz_req, int i_info_file_number, out string o_error)
        {
            o_error = @"";

            if (null == i_jazz_req)
            {
                o_error = @"RequestBand.CheckInputInfoPdfFile Input JazzReq is null";
                return false;
            }
            if (i_info_file_number < 1 || i_info_file_number > 3)
            {
                o_error = @"RequestBand.CheckInputInfoPdfFile Input file number is not 1, 2 or 3";
                return false;
            }

            return true;

        } // CheckInputInfoPdfFile

        #endregion // Download, upload and delete information file

        #region Download, upload and delete photo file

        /// <summary>Download photo file
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_photo_file_number">Photo file number</param>
        /// <param name="o_error">Error message</param>
        public static bool DownloadPhotoFile(JazzReq i_jazz_req, int i_photo_file_number, out bool i_cancel_download, out string o_error)
        {
            o_error = @"";
            i_cancel_download = false;

            if (!CheckInputPhotoFile(i_jazz_req, i_photo_file_number, out o_error))
            {
                o_error = @"RequestBand.DownloadPhotoFile CheckInputPhotoFile failed " + o_error;
                return false;
            }

            string server_file_name = @"";
            if (!GetServerAddressPhotoFile(i_jazz_req, i_photo_file_number, out server_file_name, out o_error))
            {
                o_error = @"RequestBand.DownloadPhotoFile GetServerAddressPhotoFile failed " + o_error;
                return false;
            }

            string file_extensions = @"img";
            string server_directory = Path.GetDirectoryName(server_file_name);
            server_directory = server_directory.Replace(@"\", @"/");
            if (server_directory.Contains(@"/www/"))
                server_directory = server_directory.Substring(5);

            string download_file_name = Path.GetFileName(server_file_name);
            string file_type_case = @"img";

            if (!OpenSaveDialog.Download(server_directory, download_file_name, file_type_case, file_extensions, out i_cancel_download, out o_error))
            {
                o_error = @"RequestBand.DownloadPhotoFile OpenSaveDialog.Download failed " + o_error;
                return false;
            }

            return true;

        } // DownloadPhotoFile

        /// <summary>Upload photo file
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_photo_file_number">Photo file number</param>
        /// <param name="o_error">Error message</param>
        public static bool UploadPhotoFile(ref JazzReq io_jazz_req, int i_photo_file_number, out bool o_cancel_upload, out string o_error)
        {
            o_error = @"";
            o_cancel_upload = false;

            if (!CheckInputPhotoFile(io_jazz_req, i_photo_file_number, out o_error))
            {
                o_error = @"RequestBand.UploadPhotoFile CheckInputPhotoFile failed " + o_error;
                return false;
            }

            string file_name_upload = @"";
            string file_extensions = @"img";

            if (!OpenSaveDialog.GetFileName("img", file_extensions, out o_cancel_upload, out file_name_upload, out o_error))
            {
                o_error = @"RequestBand.UploadPhotoFile OpenSaveDialog.GetFileName failed " + o_error;
                return false;
            }

            if (o_cancel_upload)
            {
                return true;
            }

            string file_name_input = @"";

            if (!GetPhotoFileName(io_jazz_req, i_photo_file_number, out file_name_input, out o_error))
            {
                file_name_input = @""; // TODO Add function IfDefined or ... TODO
                // o_error = @"RequestBand.UploadPhotoFile GetInfoFileName failed " + o_error;

                //return false;
            }

            string file_name_without_path = Path.GetFileName(file_name_upload);

            if (!SetPhotoFileName(ref io_jazz_req, i_photo_file_number, file_name_without_path, out o_error))
            {
                o_error = @"RequestBand.UploadPhotoFile SetPhotoFileName failed " + o_error;

                return false;
            }

            string server_file_name = @"";
            if (!GetServerAddressPhotoFile(io_jazz_req, i_photo_file_number, out server_file_name, out o_error))
            {
                o_error = @"RequestBand.UploadPhotoFile GetServerAddressPhotoFile failed " + o_error;
                return false;
            }

            if (file_name_input.Equals(Path.GetFileName(server_file_name)))
            {
                if (!OpenSaveDialog.BackupFile(server_file_name, out o_error))
                {
                    o_error = @"RequestBand.UploadPhotoFile OpenSaveDialog.BackupFile failed " + o_error;

                    return false;
                }
            }

            if (!UploadOneFile(file_name_upload, server_file_name, out o_error))
            {
                o_error = @"RequestBand.UploadPhotoFile UploadOneFile failed " + o_error;

                return false;
            }

            return true;

        } // UploadPhotoFile

        /// <summary>Delete photo IMG file
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_photo_file_number">Photo file number</param>
        /// <param name="o_error">Error message</param>
        public static bool DeletePhotoFile(ref JazzReq io_jazz_req, int i_photo_file_number, out string o_error)
        {
            o_error = @"";

            if (!CheckInputPhotoFile(io_jazz_req, i_photo_file_number, out o_error))
            {
                o_error = @"RequestBand.DeletePhotoFile CheckInputPhotoFile failed " + o_error;
                return false;
            }

            string server_file_name = @"";
            if (!GetServerAddressPhotoFile(io_jazz_req, i_photo_file_number, out server_file_name, out o_error))
            {
                o_error = @"RequestBand.DeletePhotoFile GetServerAddressPhotoFile failed " + o_error;
                return false;
            }

            // TODO Backup

            string server_dir = Path.GetDirectoryName(server_file_name);
            server_dir = server_dir.Replace(@"\", @"/") + @"/";

            string file_name = Path.GetFileName(server_file_name);

            Ftp.UpLoad htpp_upload = new Ftp.UpLoad(JazzAppAdminSettings.Default.FtpHost, JazzAppAdminSettings.Default.FtpUser, Main.FtpWwwPassword);

            if (!htpp_upload.DeleteFile(server_dir, file_name, out o_error))
            {
                o_error = "RequestBand.DeletePhotoFile Upload.DeleteFile failed: " + o_error;
                return false;
            }

            if (!SetPhotoFileName(ref io_jazz_req, i_photo_file_number, @"", out o_error))
            {
                o_error = "RequestBand.DeletePhotoFile SetPhotoFileName failed: " + o_error;
                return false;
            }

            return true;

        } // DeletePhotoFile

        /// <summary>Get full server name for the photo file
        /// <para>1. Create request directory. Call of GetServerDirPhotoFile</para>
        /// <para>2. Get file name. Call of GetServerDirInfoFile</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_req">Object JazzReq</param>
        /// <param name="i_photo_file_number">Photo file number</param>
        /// <param name="o_server_file_name">The full server file name for the photo file</param>
        /// <param name="o_error">Error message</param>
        private static bool GetServerAddressPhotoFile(JazzReq i_jazz_req, int i_photo_file_number, out string o_server_file_name, out string o_error)
        {
            o_error = @"";
            o_server_file_name = @"";

            string req_dir_info = @"";

            if (!GetServerDirPhotoFile(i_jazz_req, out req_dir_info, out o_error))
            {
                o_error = "RequestBand.GetServerAddressInfoFile GetServerDirPhotoFile failed " + o_error;

                return false;
            }

            string file_name = @"";

            if (!GetPhotoFileName(i_jazz_req, i_photo_file_number, out file_name, out o_error))
            {
                o_error = "RequestBand.GetServerAddressInfoFile GetInfoFileName failed " + o_error;

                return false;
            }

            o_server_file_name = req_dir_info + file_name;

            return true;

        } // GetServerAddressPhotoFile

        /// <summary>Get file name for the photo file
        /// <para>2. Get file name PhotoOne, PhotoTwo, ...  or PhotoThree from JazzReq</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_req">Object JazzReq</param>
        /// <param name="i_photo_file_number">Photo file number 1-9</param>
        /// <param name="o_file_name">The photo file name</param>
        /// <param name="o_error">Error message</param>
        public static bool GetPhotoFileName(JazzReq i_jazz_req, int i_photo_file_number, out string o_file_name, out string o_error)
        {
            o_error = @"";
            o_file_name = @"";

            if (1 == i_photo_file_number)
            {
                o_file_name = i_jazz_req.PhotoOne;
            }
            else if (2 == i_photo_file_number)
            {
                o_file_name = i_jazz_req.PhotoTwo;
            }
            else if (3 == i_photo_file_number)
            {
                o_file_name = i_jazz_req.PhotoThree;
            }
            else if (4 == i_photo_file_number)
            {
                o_file_name = i_jazz_req.PhotoFour;
            }
            else if (5 == i_photo_file_number)
            {
                o_file_name = i_jazz_req.PhotoFive;
            }
            else if (6 == i_photo_file_number)
            {
                o_file_name = i_jazz_req.PhotoSix;
            }
            else if (7 == i_photo_file_number)
            {
                o_file_name = i_jazz_req.PhotoSeven;
            }
            else if (8 == i_photo_file_number)
            {
                o_file_name = i_jazz_req.PhotoEight;
            }
            else if (9 == i_photo_file_number)
            {
                o_file_name = i_jazz_req.PhotoNine;
            }
            else
            {
                o_error = "RequestBand.GetPhotoFileName File number not between 1 and 9";

                return false;
            }

            return true;

        } // GetPhotoFileName

        /// <summary>Set file name for the photo file
        /// <para>2. Set file name PhotoOne, PhotoTwo, .... or PhotoNine in JazzReq</para>
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Object JazzReq</param>
        /// <param name="i_photo_file_number">Info file number</param>
        /// <param name="i_file_name">The photo file name without path</param>
        /// <param name="o_error">Error message</param>
        public static bool SetPhotoFileName(ref JazzReq io_jazz_req, int i_photo_file_number, string i_file_name, out string o_error)
        {
            o_error = @"";

            if (i_file_name.Length != 0)
            {
                string path_file = Path.GetDirectoryName(i_file_name);
                if (path_file.Length > 0)
                {
                    o_error = "RequestBand.SetPhotoFileName Remove path " + path_file;

                    return false;
                }
            }

            if (1 == i_photo_file_number)
            {
                io_jazz_req.PhotoOne = i_file_name;
            }
            else if (2 == i_photo_file_number)
            {
                io_jazz_req.PhotoTwo = i_file_name;
            }
            else if (3 == i_photo_file_number)
            {
                io_jazz_req.PhotoThree = i_file_name;
            }
            else if (4 == i_photo_file_number)
            {
                io_jazz_req.PhotoFour = i_file_name;
            }
            else if (5 == i_photo_file_number)
            {
                io_jazz_req.PhotoFive = i_file_name;
            }
            else if (6 == i_photo_file_number)
            {
                io_jazz_req.PhotoSix = i_file_name;
            }
            else if (7 == i_photo_file_number)
            {
                io_jazz_req.PhotoSeven = i_file_name;
            }
            else if (8 == i_photo_file_number)
            {
                io_jazz_req.PhotoEight = i_file_name;
            }
            else if (9 == i_photo_file_number)
            {
                io_jazz_req.PhotoNine = i_file_name;
            }
            else
            {
                o_error = "RequestBand.SetPhotoFileName File number not between 1 and 9";

                return false;
            }

            return true;

        } // SetPhotoFileName

        /// <summary>Create/get server directory for an image (photo) file
        /// <para>The function GetServerDirInfoFile is called, i.e. the same directory as for the information files will be used</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_req">Object JazzReq</param>
        /// <param name="o_server_dir">The server directory name for an image (photo) file</param>
        /// <param name="o_error">Error message</param>
        private static bool GetServerDirPhotoFile(JazzReq i_jazz_req, out string o_server_dir, out string o_error)
        {
            if (!GetServerDirInfoFile(i_jazz_req, out o_server_dir, out o_error))
            {
                o_error = "RequestBand.GetServerAddressInfoFile GetServerDirPhotoFile failed " + o_error;

                return false;
            }

            return true;

        } // GetServerDirPhotoFile

        /// <summary>Create/get server directory for an information file
        /// <para>1. Create request directory if not existing. Call of JazzReq.RegNumberName, upload.DoesDirectoryExist and upload.CreateServerDirectory</para>
        /// <para></para>
        /// </summary>
        /// <param name="i_jazz_req">Object JazzReq</param>
        /// <param name="o_server_dir">The server directory name for an information file</param>
        /// <param name="o_error">Error message</param>
        private static bool GetServerDirBackupInfoFile(JazzReq i_jazz_req, out string o_server_dir, out string o_error)
        {
            o_error = @"";
            o_server_dir = @"";

            string req_dir_info = @"";

            if (!GetServerDirInfoFile(i_jazz_req, out req_dir_info, out o_error))
            {
                o_error = "RequestBand.GetServerDirBackupInfoFile UpLoad.GetServerDirInfoFile failed " + o_error;

                return false;
            }

            string req_dir_backup_info = req_dir_info + RequestStrings.ServerDirBackupRequestFiles + @"/";

            UpLoad upload = new UpLoad();
            bool to_www = true;

            string ftp_response = @"";

            if (!upload.DoesDirectoryExist(to_www, req_dir_backup_info, out ftp_response))
            {
                if (!upload.CreateServerDirectory(to_www, req_dir_backup_info, out o_error))
                {
                    o_error = "RequestBand.GetServerDirBackupInfoFile UpLoad.CreateServerDirectory failed req_dir_info " + o_error;

                    return false;
                }
            }

            o_server_dir = req_dir_backup_info;

            return true;

        } // GetServerDirBackupInfoFile

        /// <summary>Check input data for the photo IMG file
        /// <para></para>
        /// </summary>
        /// <param name="io_jazz_req">Input/output JazzReq object</param>
        /// <param name="i_photo_file_number">Photo file number</param>
        /// <param name="o_error">Error message</param>
        private static bool CheckInputPhotoFile(JazzReq i_jazz_req, int i_photo_file_number, out string o_error)
        {
            o_error = @"";

            if (null == i_jazz_req)
            {
                o_error = @"RequestBand.CheckInputInfoPdfFile Input JazzReq is null";
                return false;
            }
            if (i_photo_file_number < 1 || i_photo_file_number > 9)
            {
                o_error = @"RequestBand.CheckInputPhotoFile Input file number is not between 1 and 9";
                return false;
            }

            return true;

        } // CheckInputPhotoFile

        #endregion // Download, upload and delete photo file

        #region Set combo boxes

        /// <summary>Set combobox AudioOne</summary>
        public static void SetComboboxAudioOne(JazzReq i_jazz_req, ComboBox i_combo_box)
        {
            string audio_dir = i_jazz_req.AudioOne;
            string audio_cd = i_jazz_req.AudioOneCd;

            if (audio_dir.Length == 0 || audio_cd.Length == 0)
            {
                // Nothing to set
                i_combo_box.Text = @"";
                i_combo_box.Items.Clear(); // After delete of audio files the list must also be removed
                return;
            }

            string[] sound_files = null;
            string error_message = @"";

            if (!AudioGetFileNames(audio_dir, out sound_files, out error_message))
            {
                error_message = @"RequestBand.SetComboboxAudioOne AudioGetFileNames failed " + error_message;
                i_combo_box.Text = error_message;

                return;
            }

            SetComboboxAudio(audio_cd, sound_files, i_combo_box);

        } // SetComboboxAudioOne

        /// <summary>Set combobox AudioTwo</summary>
        public static void SetComboboxAudioTwo(JazzReq i_jazz_req, ComboBox i_combo_box)
        {
            string audio_dir = i_jazz_req.AudioTwo;
            string audio_cd = i_jazz_req.AudioTwoCd;

            if (audio_dir.Length == 0 || audio_cd.Length == 0)
            {
                // Nothing to set
                i_combo_box.Text = @"";
                return;
            }

            string[] sound_files = null;
            string error_message = @"";

            if (!AudioGetFileNames(audio_dir, out sound_files, out error_message))
            {
                error_message = @"RequestBand.SetComboboxAudioTwo AudioGetFileNames failed " + error_message;
                i_combo_box.Text = error_message;

                return;
            }

            SetComboboxAudio(audio_cd, sound_files, i_combo_box);

        } // SetComboboxAudioTwo

        /// <summary>Set combobox AudioThree</summary>
        public static void SetComboboxAudioThree(JazzReq i_jazz_req, ComboBox i_combo_box)
        {
            string audio_dir = i_jazz_req.AudioThree;
            string audio_cd = i_jazz_req.AudioThreeCd;

            if (audio_dir.Length == 0 || audio_cd.Length == 0)
            {
                // Nothing to set
                i_combo_box.Text = @"";
                return;
            }

            string[] sound_files = null;
            string error_message = @"";

            if (!AudioGetFileNames(audio_dir, out sound_files, out error_message))
            {
                error_message = @"RequestBand.SetComboboxAudioThree AudioGetFileNames failed " + error_message;
                i_combo_box.Text = error_message;

                return;
            }

            SetComboboxAudio(audio_cd, sound_files, i_combo_box);

        } // SetComboboxAudioThree

        /// <summary>Set combobox AudioOne</summary>
        private static void SetComboboxAudio(string i_audio_cd, string[] i_sound_files, ComboBox i_combo_box)
        {
            if (i_sound_files == null || i_sound_files.Length == 0)
            {
                // Nothing to set
                return;
            }

            if (i_audio_cd.Length == 0)
                return;

            i_combo_box.Items.Clear();

            i_combo_box.Items.Add(i_audio_cd);

            for (int index_name=0; index_name< i_sound_files.Length; index_name++)
            {
                string file_name = i_sound_files[index_name];

                i_combo_box.Items.Add(file_name);
            }

            i_combo_box.Text = i_audio_cd;

        } // SetComboboxAudio

        /// <summary>Set combobox information files</summary>
        public static void SetComboboxInfoFiles(JazzReq i_jazz_req, ComboBox i_combo_box)
        {
            i_combo_box.Items.Clear();

            i_combo_box.Items.Add(RequestStrings.PromptSelectInfo);

            string info_1 = RequestStrings.LabelInfoOne + @": ";
            if (i_jazz_req.InfoOne.Length != 0)
            {
                info_1 = info_1 + i_jazz_req.InfoOne;
            }
            else
            {
                info_1 = info_1 + @"---";
            }
            i_combo_box.Items.Add(info_1);

            string info_2 = RequestStrings.LabelInfoTwo + @": ";
            if (i_jazz_req.InfoTwo.Length != 0)
            {
                info_2 = info_2 + i_jazz_req.InfoTwo;
            }
            else
            {
                info_2 = info_2 + @"---";
            }
            i_combo_box.Items.Add(info_2);

            string info_3 = RequestStrings.LabelInfoThree + @": ";
            if (i_jazz_req.InfoThree.Length != 0)
            {
                info_3 = info_3 + i_jazz_req.InfoThree;
            }
            else
            {
                info_3 = info_3 + @"---";
            }
            i_combo_box.Items.Add(info_3);

            i_combo_box.Text = RequestStrings.PromptSelectInfo;

        } // SetComboboxInfoFiles

        /// <summary>Set combobox photo files</summary>
        public static void SetComboboxPhotoFiles(JazzReq i_jazz_req, ComboBox i_combo_box)
        {
            i_combo_box.Items.Clear();

            i_combo_box.Items.Add(RequestStrings.PromptSelectPhoto);

            AddComboBoxPhoto(i_combo_box, 1, i_jazz_req.PhotoOne);
            AddComboBoxPhoto(i_combo_box, 2, i_jazz_req.PhotoTwo);
            AddComboBoxPhoto(i_combo_box, 3, i_jazz_req.PhotoThree);
            AddComboBoxPhoto(i_combo_box, 4, i_jazz_req.PhotoFour);
            AddComboBoxPhoto(i_combo_box, 5, i_jazz_req.PhotoFive);
            AddComboBoxPhoto(i_combo_box, 6, i_jazz_req.PhotoSix);
            AddComboBoxPhoto(i_combo_box, 7, i_jazz_req.PhotoSeven);
            AddComboBoxPhoto(i_combo_box, 8, i_jazz_req.PhotoEight);
            AddComboBoxPhoto(i_combo_box, 9, i_jazz_req.PhotoNine);

            i_combo_box.Text = RequestStrings.PromptSelectPhoto;

        } // SetComboboxPhotoFiles

        /// <summary>Add one photo to the combobox</summary>
        private static void AddComboBoxPhoto(ComboBox i_combo_box, int i_photo_number, string i_photo_file)
        {
            string add_str = RequestStrings.GetPhotoLabel(i_photo_number) + @": ";

            if (i_photo_file.Length != 0)
            {
                add_str = add_str + i_photo_file;
            }
            else
            {
                add_str = add_str + @"---";
            }

            i_combo_box.Items.Add(add_str);

        } // AddComboBoxPhoto

        /// <summary>Set combobox concert number</summary>
        public static void SetComboboxConcertNumber(JazzReq i_jazz_req, ComboBox i_combo_box)
        {
            i_combo_box.Items.Clear();

            i_combo_box.Items.Add(RequestStrings.PromptSelectConcertNumber);

            for (int concert_number=1; concert_number<=12; concert_number++)
            {
                i_combo_box.Items.Add(GetNumberDateBandName(concert_number));
            }

            int set_concert_number = i_jazz_req.ConcertNumberInt;
            if (set_concert_number > 0)
            {
                i_combo_box.Text = GetNumberDateBandName(set_concert_number);
            }
            else
            {
                i_combo_box.Text = RequestStrings.PromptSelectConcertNumber;
            }

        } // SetComboboxPhotoFiles

        /// <summary>Returns concert number, date and band name</summary>
        private static string GetNumberDateBandName(int i_concert_number)
        {
            // It doesn't help adding space for Arial
            string number_str = i_concert_number.ToString();
            if (i_concert_number > 0 && i_concert_number <= 9)
                number_str = @" " + number_str;

            string day_str = JazzXml.GetDay(i_concert_number);
            if (1 == day_str.Length)
                day_str = @" " + day_str;

            string month_str = JazzXml.GetMonth(i_concert_number);
            if (1 == month_str.Length)
                month_str = month_str + @" ";

            return number_str + @".     " + day_str + @"/" + month_str + @"  " + JazzXml.GetYear(i_concert_number) + @"  " +  JazzXml.GetBandName(i_concert_number);

        } // GetNumberDateBandName

        #endregion // Set combo boxes

    } // RequestBand

} // namespace
