using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JazzAppAdmin
{
    /// <summary>Execution functions and parameters for form RequestDeveloperForm
    /// <para></para>
    /// </summary>
    public static class RequestDeveloper
    {
        /// <summary>List of not deleted sound files
        /// <para>1. Get an array of sound files that should have been deleted. Call of Request.GetNotDeletedAudioFileNames</para>
        /// <para>2. Delete the files. Call of Request.SetDeleteSoundFileNames and Request.FinalDeleteSoundFiles</para>
        /// </summary>
        /// <param name="i_text_box">Textbox for progress messages</param>
        /// <param name="o_error">Error message</param>
        public static bool CleanAudioDirectoriesAndFiles(TextBox i_text_box, out string o_error)
        {
            o_error = @"";

            string[] not_deleted_audio_files = null;
            if (!Request.GetNotDeletedAudioFileNames(out not_deleted_audio_files, i_text_box, out o_error))
            {
                o_error = @"RequestDeveloper.ListNotDeletedAudioFiles Request.GetNotDeletedAudioFileNames failed " + o_error;
                return false;
            }

            Request.SetDeleteSoundFileNames(not_deleted_audio_files);

            if (!Request.FinalDeleteSoundFiles(out o_error))
            {
                o_error = @"RequestDeveloper.ListNotDeletedAudioFiles Request.FinalDeleteSoundFiles failed " + o_error;
                return false;
            }

            // TODO Delete audio directories

            return true;

        } // CleanAudioDirectoriesAndFiles

        /// <summary>List of not deleted sound files
        /// <para>1. Get an array of sound files that should have been deleted. Call of Request.GetNotDeletedAudioFileNames</para>
        /// <para>2. Open list file and write file names</para>
        /// </summary>
        /// <param name="o_file_name">File name for the file with output data</param>
        /// <param name="i_text_box">Textbox for progress messages</param>
        /// <param name="o_error">Error message</param>
        public static bool ListNotDeletedAudioFiles(out string o_file_name, TextBox i_text_box, out string o_error)
        {
            o_error = @"";
            o_file_name = @"";

            string[] not_deleted_audio_files = null;
            if (!Request.GetNotDeletedAudioFileNames(out not_deleted_audio_files, i_text_box, out o_error))
            {
                o_error = @"RequestDeveloper.ListNotDeletedAudioFiles Request.GetNotDeletedAudioFileNames failed " + o_error;
                return false;
            }

            string out_str = @"Not deleted sound files " + TimeUtil.YearMonthDayIso() + NewLine();
            out_str = out_str + @"===================================" + NewLine() + NewLine();

            for (int index_no_zip = 0; index_no_zip < not_deleted_audio_files.Length; index_no_zip++)
            {
                out_str = out_str + not_deleted_audio_files[index_no_zip] + NewLine();
            }

            if (not_deleted_audio_files.Length == 0)
            {
                out_str = out_str + NewLine() + @"There is nothing to clean. Deleted requests have no audio files." + NewLine();
            }

            out_str = out_str + NewLine() + NewLine();

            string file_name = @"ListNotDeletedSoundFiles" + TimeUtil.YearMonthDay() + @".txt";

            string local_address_directory = FileUtil.SubDirectory(RequestStrings.MaintenanceDir, Main.m_exe_directory) + @"\";

            string full_file_name = local_address_directory + file_name;

            File.WriteAllText(full_file_name, out_str);

            o_file_name = full_file_name;

            return true;

        } // ListNotDeletedAudioFiles

        /// <summary>Returns new line (for Windows)</summary>
        private static string NewLine() { return "\r\n"; }

    } // RequestDeveloper



} // namespace
