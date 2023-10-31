using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TinyURLPOC.Helpers;

namespace TinyURLPOC.Parser
{
    public class ParseUrl
    {
        private readonly IURLEncoding<string> _enconding;

        public ParseUrl(IURLEncoding<string> enconding)
        {
            _enconding = enconding;
        }

       
        /// <summary>
        /// Encode the valid URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string EncodeUrl(string url)
        {
            return _enconding.Encode(url);
        }
        /// <summary>
        /// Return the URL with the domain name included
        /// </summary>
        /// <param name="encodedUrl">encoded URL or valid alias</param>
        /// <returns></returns>
        public string GetTinyUrl(string encodedUrl)
        {
            return Constants.TinyUrlDomain + encodedUrl;
        }
        /// <summary>
        /// Decode URL
        /// </summary>
        /// <param name="tinyUrl"></param>
        /// <returns></returns>
        public string DecodeTinyUrl(string tinyUrl)
        {
            var uri = GetUri(tinyUrl, Constants.TinyUrlDomain);
            //return _enconding.Decode(uri);
            return uri;
        }
        /// <summary>
        /// Mocked method to get the 'URI' of the request
        /// </summary>
        /// <param name="input">Entire URL</param>
        /// <param name="initialSubstring">Domain Name</param>
        /// <returns>the URI</returns>
        private string GetUri(string input, string initialSubstring)
        {
            //First instance of the substring
            int startIndex = input.IndexOf(initialSubstring);
            if (startIndex == -1)
                return null;

            int substringLength = initialSubstring.Length;
            int endIndex = startIndex + substringLength;

            //If the substring exists within the giving length
            if (endIndex < input.Length)
                return input.Substring(endIndex);

            return null;

        }
    }
}
