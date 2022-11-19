using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Holds the input and output data for DocDirNamesForm
    /// <para></para>
    /// <para></para>
    /// </summary>
    public class DocDirNames
    {
        /// <summary>Proposal for directory names</summary>
        private string[] m_proposal_dir_names = null;
        /// <summary>Get and set proposal for directory names</summary>
        public string[] ProposalDirNames { get { return m_proposal_dir_names; } set { m_proposal_dir_names = value; } }

        /// <summary>User directory names</summary>
        private string[] m_user_dir_names = null;
        /// <summary>Get and set user directory names</summary>
        public string[] UserDirNames { get { return m_user_dir_names; } set { m_user_dir_names = value; } }

        /// <summary>Object with execution functions for DocDirNamesForm</summary>
        private JazzDocAll m_jazz_doc_all = null;
        /// <summary>Get and set object with execution functions for DocDirNamesForm</summary>
        public JazzDocAll DocAll { get { return m_jazz_doc_all; } set { m_jazz_doc_all = value; } }

        /// <summary>Flag telling if the user cancelled</summary>
        private bool m_user_cancelled = false;
        /// <summary>Get and set flag telling if the user cancelled</summary>
        public bool UserCancelled { get { return m_user_cancelled; } set { m_user_cancelled = value; } }

        public void ModifyNamesForBandDirectories(ref string[] io_band_dir_names, out bool o_name_was_changed)
        {
            DocAll.ModifyNamesForBandDirectories(ref io_band_dir_names, out o_name_was_changed);

        } // ModifyNamesForBandDirectories

    } // DocDirNames

} // namespace
