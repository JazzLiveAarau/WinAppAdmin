using JazzApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Generates a season program txt file</summary>
    public static class SeasonProgramTxt
    {
        #region Main function

        /// <summary>Generates a season program txt file
        /// <para></para>
        /// </summary>
        /// <param name="i_local_path">Full path including exe directory to the file</param>
        /// <param name="i_file_name">File name with extension txt</param>
        /// <param name="o_error">Error message</param>
        public static bool Generate(string i_local_path, string i_file_name, out string o_error)
        {
            o_error = @"";

            if (i_local_path.Length == 0)
            {
                o_error = @"SeasonProgramTxt.Generate Input local path is empty";
                return false;
            }

            if (!i_file_name.Contains(@".txt"))
            {
                o_error = @"SeasonProgramTxt.Generate Input file name dos not have the extension txt";
                return false;
            }

            if (!Directory.Exists(i_local_path))
            {
                Directory.CreateDirectory(i_local_path);
            }

            string full_file_name = i_local_path + @"\" + i_file_name;
            Boolean append_flag = false; // Create a new file

            try
            {
                using (System.IO.StreamWriter txt_file = new System.IO.StreamWriter(full_file_name, append_flag, Encoding.UTF8))
                {
                    _AddHeader(txt_file);

                    _AddPremises(txt_file);

                    _AddReservation(txt_file);

                    _AddJazzClub(txt_file);

                    _AddConcerts(txt_file);
                }
            }
            catch (Exception ex)
            {
                o_error = @"SeasonProgramTxt.Generate " + ex.Message;
                return false;
            }

            return true;

        } // Generate

        #endregion // Main function

        #region Add functions

        /// <summary>Add header lines</summary>
        static private void _AddHeader(StreamWriter i_txt_file)
        {
            i_txt_file.WriteLine(@"JAZZ live AARAU Veranstaltungen Saison " + JazzXml.GetDocSeasonYears());
            i_txt_file.WriteLine(@"================================================");
            i_txt_file.WriteLine(@"");
            i_txt_file.WriteLine(@"");

        } // _AddHeader

        /// <summary>Add premises lines</summary>
        static private void _AddPremises(StreamWriter i_txt_file)
        {
            i_txt_file.WriteLine(JazzXml.GetPremisesHeader() + @":");
            i_txt_file.WriteLine(JazzXml.GetPremises());
            i_txt_file.WriteLine(JazzXml.GetPremisesStreet());
            i_txt_file.WriteLine(JazzXml.GetPremisesCity());
            i_txt_file.WriteLine(@"Website: " + JazzXml.GetPremisesWebsite());
            i_txt_file.WriteLine(@"");
            i_txt_file.WriteLine(@"");

        } // _AddPremises

        /// <summary>Add reservation lines</summary>
        static private void _AddReservation(StreamWriter i_txt_file)
        {
            i_txt_file.WriteLine(JazzXml.GetReservationHeader() + @": " + JazzXml.GetReservationUrl());
            i_txt_file.WriteLine(@"");
            i_txt_file.WriteLine(@"");

        } // _AddReservation

        /// <summary>Add reservation lines</summary>
        static private void _AddJazzClub(StreamWriter i_txt_file)
        {
            i_txt_file.WriteLine(@"Veranstalter: " + JazzXml.GetClubName());
            i_txt_file.WriteLine(@"Homepage: " + JazzXml.GetWebSiteUrl());
            i_txt_file.WriteLine(@"");
            i_txt_file.WriteLine(@"");

        } // _AddJazzClub


        /// <summary>Add reservation lines</summary>
        static private void _AddConcerts(StreamWriter i_txt_file)
        {
            int number_concerts = JazzXml.GetNumberConcertsInCurrentDocument();

            if (number_concerts <= 0)
                return;

            for (int concert_number=1; concert_number<=number_concerts; concert_number++)
            {
                _AddConcert(i_txt_file, concert_number);
            }

        } // _AddConcerts

        /// <summary>Add concert lines</summary>
        static private void _AddConcert(StreamWriter i_txt_file, int i_concert_number)
        {
            string concert_header = @"--------------------------- Konzert " + i_concert_number.ToString() + @" --------------------------- ";
            i_txt_file.WriteLine(concert_header);
            i_txt_file.WriteLine(@"");

            string concert_month = JazzXml.GetMonth(i_concert_number);
            if (concert_month.Length == 1)
                concert_month = @"0" + concert_month;

            string concert_day = JazzXml.GetDay(i_concert_number);
            if (concert_day.Length == 1)
                concert_day = @"0" + concert_day;

            string concert_date = JazzXml.GetYear(i_concert_number) + @"-" + concert_month + @"-" + concert_day;

            string line_1 = JazzXml.GetDayName(i_concert_number) + @" " + concert_date + @" " + JazzXml.GetBandName(i_concert_number);

            i_txt_file.WriteLine(line_1);

            i_txt_file.WriteLine(@"");
            _AddDescription(i_txt_file, i_concert_number);

            i_txt_file.WriteLine(@"");
            _AddMusicians(i_txt_file, i_concert_number);

            i_txt_file.WriteLine(@"");
            i_txt_file.WriteLine(@"");
            i_txt_file.WriteLine(@"");

        } // _AddConcert

        /// <summary>Add musicians lines</summary>
        static private void _AddMusicians(StreamWriter i_txt_file, int i_concert_number)
        {
            int number_musicians = JazzXml.GetNumberMusicians(i_concert_number);

            if (number_musicians <= 0)
                return;

            for (int musician_number=1; musician_number<= number_musicians; musician_number++)
            {
                string musician_line = JazzXml.GetMusicianName(i_concert_number, musician_number) + @" " + JazzXml.GetMusicianInstrument(i_concert_number, musician_number);

                i_txt_file.WriteLine(musician_line);
            }


        } // _AddMusicians


        /// <summary>Add description lines</summary>
        static private void _AddDescription(StreamWriter i_txt_file, int i_concert_number)
        {
            string short_text = JazzXml.GetShortText(i_concert_number);

            // QQQQ For test
            //QQQ short_text = @"Mit seinem Debütalbum «Dreaming of a Place Unseen» hält Nolan Quinn seine Auseinandersetzung mit der amerikanischen Tradition des Jazz fest. Sein aus international tätigen Musikern bestehendes Quintett strebt beim Spielen nach Virtuosität und Lebendigkeit.";

            if (!JazzXml.XmlNodeValueIsSet(short_text))
                return;

            int max_n_lines = 20;
            string[] descripion_lines = new string[max_n_lines];
            for (int index_init=0; index_init<descripion_lines.Length; index_init++)
            {
                descripion_lines[index_init] = @"";
            }

            int row_length = 75;

            int current_line_index = 0;

            for (int index_char=0; index_char< short_text.Length; index_char++)
            {
                string current_char = short_text.Substring(index_char, 1);

                descripion_lines[current_line_index] = descripion_lines[current_line_index] + current_char;

                if (current_char.Equals(@" ") && descripion_lines[current_line_index].Length >= row_length)
                {
                    current_line_index = current_line_index + 1;
                    if (current_line_index > max_n_lines-1)
                        break;
                }
            }

            for (int index_line=0; index_line<max_n_lines; index_line++)
            {
                string current_line = descripion_lines[index_line];
                if (current_line.Length == 0)
                    break;

                i_txt_file.WriteLine(current_line);
            }

        } // _AddDescription

        #endregion // Add functions

    } // SeasonProgramTxt

} // namespace
