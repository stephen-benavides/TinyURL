using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURLPOC.Helpers
{
    public sealed class Base64Encoding : IURLEncoding<string>
    {
        public  string Encode(string plainText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
            
        }

        public  string Decode(string base64EncodedText)
        {
            var base64EncondedBytes =  Convert.FromBase64String(base64EncodedText);
            return Encoding.UTF8.GetString(base64EncondedBytes);
        }
    }
}
