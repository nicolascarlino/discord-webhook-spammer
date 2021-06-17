using System;
using System.Collections.Specialized;
using System.Net;

namespace Hyuga
{
    internal class Http
    {
        public Http()
        {
        }

        public static byte[] Post(string uri, NameValueCollection pairs)
        {
            byte[] numArray;
            using (WebClient webClient = new WebClient())
            {
                numArray = webClient.UploadValues(uri, pairs);
            }
            return numArray;
        }
    }
}