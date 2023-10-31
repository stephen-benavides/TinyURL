using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURLPOC.Data;
using TinyURLPOC.Helpers;

namespace TinyURLPOC.Services
{
    internal class AliasServices
    {
        private DataBaseHelper _dataBase;
        private AliasRepository AliasRepository { get; set; }
        public AliasServices(DataBaseHelper dataBase)
        {
            _dataBase = dataBase;
            AliasRepository = new AliasRepository(_dataBase);
        }

        /// <summary>
        /// Get the original URL using the alias
        /// </summary>
        /// <param name="alias">alias</param>
        /// <returns></returns>
        public string GetById(string alias)
        {
            return AliasRepository.GetById(alias);
        }
        /// <summary>
        /// Adds the alias and the original URL to the alias DB
        /// </summary>
        /// <param name="alias">alias</param>
        /// <param name="originalUrl">original url</param>
        /// <returns></returns>
        public bool Add(string alias, string originalUrl)
        {
            try
            {
                _dataBase.Aliases.Add(alias, originalUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
        /// <summary>
        /// Remove the original url assiciated with the alias
        /// </summary>
        /// <param name="id">alias</param>
        /// <returns></returns>
        public bool Remove(string alias)
        {
            return AliasRepository.Remove(alias);
        }

        /// <summary>
        /// Remove the aliases associated with the original DB
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns></returns>
        public bool RemoveAliasAssociatedWithOriginalUrl(string originalUrl)
        {
            //get wehre the long url is unique 
            try
            {
                var uniqueKeyValuePair = _dataBase.Aliases.FirstOrDefault(k => k.Value.Equals(originalUrl));
                return Remove(uniqueKeyValuePair.Key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The key does not exist in the Alias DB");
                return false;
            }
        }
    }
}
