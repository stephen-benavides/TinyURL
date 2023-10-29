using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURLPOC.Data;
using TinyURLPOC.Models;

namespace TinyURLPOC.Helpers
{
    public class DataBaseHelper
    {
        public Dictionary<string, UrlMapping> URLMappings { get; set; }
        public Dictionary<string, string> Aliases { get; set; }
        public Dictionary<string, int> UrlMappingsCalls { get; set; }

        public DataBaseHelper()
        {
            //K - original URL 
            //V - UrlMapping Model
            URLMappings = new Dictionary<string, UrlMapping>();


            //K - unique alias 
            //V - original URL 
            Aliases = new Dictionary<string, string>();


            //K - original URL 
            //V - NumberOftimesInvoked
            UrlMappingsCalls = new Dictionary<string, int>();


            #region DEBUG Populating Dummy Values

            var testAlias = new Alias()
            {
                Name = "Test123.com"
            };
            var testUrlMapping = new UrlMapping()
            {
                OriginalUrl = "ORIGINALURLtest.com",
                Alias = new List<Alias>()
                {
                    testAlias
                }
            };
            
            URLMappings.Add(testUrlMapping.OriginalUrl, testUrlMapping);
            Aliases.Add(testAlias.Name, testUrlMapping.OriginalUrl);

            #endregion

        }

    }
}
