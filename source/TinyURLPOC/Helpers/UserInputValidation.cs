using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TinyURLPOC.Helpers
{
    public class UserInputValidation
    {
        public enum ValidationType
        {
            YES = 1,
            NO = 2,
            ADD = 3,
            REMOVE = 4,
            UPDATE = 5,
            GETALL = 6,
            GET = 7,
            BACK = 0

        }
        /// <summary>
        /// Checks if the string input by the user is a valid URL 
        /// </summary>
        /// <param name="input">input string from the user</param>
        /// <returns></returns>
        public bool IsValidUrl(string input)
        {
            var inputUrl = ReadUserInput(input);
            if(String.IsNullOrEmpty(inputUrl))
                return false;

            //Checking if URL: http://[any word or number]
            Regex httpRegex = new Regex(Constants.RegexHttpPattern, RegexOptions.IgnoreCase);
            var matchHttpRegex = httpRegex.Match(inputUrl);

            //Check if URL Contains any word or letter, followed by .com
            Regex dotComRegex = new Regex(Constants.RegexDotComPattern, RegexOptions.IgnoreCase);
            var matchDotComRegex = dotComRegex.Match(inputUrl);

            //Return true if there are any matches 
            return matchHttpRegex.Success || matchDotComRegex.Success;
        }

        public bool IsValidMenuOption(string input)
        {
            var userInput = ReadUserInput(input);
            if (String.IsNullOrEmpty(userInput))
                return false;
            Regex regex = new Regex(Constants.RegexMenuOptionsPattern, RegexOptions.IgnoreCase);
            var matchRegex = regex.Match(userInput);
            return matchRegex.Success;
        }

        private string ReadUserInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            return input.Trim();
        }

        public bool IsValidTinyUrl(string input)
        {
            var inputUrl = ReadUserInput(input);
            if (String.IsNullOrEmpty(inputUrl))
                return false;

            Regex regex = new Regex(Constants.RegexTinyUrlDomain);
            var matchRegex = regex.Match(inputUrl);
            return matchRegex.Success;
        }

        public bool IsValidAlias(string input)
        {
            var userInput = ReadUserInput(input);
            if (String.IsNullOrEmpty(userInput))
                return false;
            Regex regex = new Regex(Constants.RegexAliasPattern, RegexOptions.IgnoreCase);
            var matchRegex = regex.Match(userInput);
            return matchRegex.Success;
        }


    }
}
