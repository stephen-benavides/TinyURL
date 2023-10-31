using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURLPOC.Helpers
{
    public class Constants
    {
        #region Domain

        public const string Http = "http:";
        public const string Https = "https:";
        public const string DotCom = ".com";
        public const string TinyUrlDomain = @"https://tinyurl.com/";

        #endregion

        #region Regex

        public const string RegexTinyUrlDomain = @"^https://tinyurl.com/[\w-]+=*$";
        public const string RegexHttpPattern = @"^https?:///?[A-Za-z0-9]+$";
        public const string RegexDotComPattern = @"^\S+[A-Za-z0-9]+\S*\.com\S*$";
        public const string RegexMenuOptionsPattern = @"^[0-9]$";
        public const string RegexAliasPattern = @"^[A-Za-z0-9]+$";

        #endregion
    }
}
