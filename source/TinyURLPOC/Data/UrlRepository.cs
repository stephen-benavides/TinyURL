using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURLPOC.Helpers;
using TinyURLPOC.Models;
using TinyURLPOC.Parser;

namespace TinyURLPOC.Data
{
    public class UrlRepository : IRepository<UrlMapping>
    {
        private readonly DataBaseHelper _dataBase;

        public UrlRepository(DataBaseHelper dataBase)
        {
            _dataBase = dataBase;
        }

        /*private readonly List<UrlMapping> _dataBase;
        public UrlRepository(List<UrlMapping> dataBase)
        {
            _dataBase = dataBase;
        }*/
        public List<UrlMapping> GetAll()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Retrieve the short / tiny url associated with the original url
        /// </summary>
        /// <param name="userInput">Original URL</param>
        /// <returns></returns>
        public UrlMapping GetById(string userInput)
        {
            UrlMapping originalMapping = null;
            try
            {
                
                if (_dataBase.URLMappings.Count == 0)
                    return null;

                originalMapping = _dataBase.URLMappings[userInput];

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return originalMapping;
        }

        /// <summary>
        /// Add new object into the DB
        /// </summary>
        /// <param name="obj">Original URL</param>
        public void Add(UrlMapping obj)
        {
            try
            {
                _dataBase.URLMappings.Add(obj.OriginalUrl, obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public UrlMapping Update(UrlMapping obj)
        {
            throw new NotImplementedException();
        }






        /****** SERVICE LAYER *******/

        /// <summary>
        /// Add new object into the DB with an alias 
        /// </summary>
        /// <param name="obj">Original URL</param>
        /// <param name="objAlias">User Alias</param>
        public void Add(UrlMapping objOriginalUrl, Alias objAlias)
        {
            
            //***** PART OF SERVICE LAYER *******
            try
            {
                _dataBase.URLMappings.Add(objOriginalUrl.OriginalUrl, objOriginalUrl);
                _dataBase.Aliases.Add(objAlias.Name, objOriginalUrl.OriginalUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        /******* Alias REPO *********/

        /// <summary>
        /// Retrieve the short / tiny url associated with the original url
        /// </summary>
        /// <param alias="user alias"></param>
        /// <returns>the original url associated with the tiny url</returns>
        public string GetAliasById(string alias)
        {
            /******** Part Of Alias Repo ***********/
            string originalMapping = null;
            try
            {

                if (_dataBase.Aliases.Count == 0)
                    return null;

                originalMapping = _dataBase.Aliases[alias];

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return originalMapping;

        }

    }
}
