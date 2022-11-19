using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazzAppAdmin
{
    /// <summary>Internet utility functions</summary>
    public static class InternetUtil
    {
        /// <summary>Checks if an Internet server is available</summary>
        /// <param name="i_str_uri">Web address like for instance http://www.jazzliveaarau.ch </param>
        /// <param name="o_error">Error from Webresponse if there is no connection</param>
        /// <returns>Returns true if connection is available to the FTP host</returns>
        public static bool IsConnectionAvailable(string i_str_uri, out string o_error)
        {
            o_error = "";

            System.Uri objUrl = new System.Uri(i_str_uri);
            System.Net.WebRequest objWebReq;
            objWebReq = System.Net.WebRequest.Create(objUrl);
            System.Net.WebResponse objResp;
            try
            {
                objResp = objWebReq.GetResponse();
                objResp.Close();
                objWebReq = null;
                return true;
            }
            catch (Exception e)
            {
                objWebReq = null;

                o_error = e.Message;

                return false;
            }
        } // IsConnectionAvailable

    } // InternetUtil
} // JazzAppAdmin
