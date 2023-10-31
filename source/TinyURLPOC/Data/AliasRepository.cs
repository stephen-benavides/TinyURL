using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURLPOC.Helpers;
using TinyURLPOC.Models;

namespace TinyURLPOC.Data
{
    internal class AliasRepository : IRepository<string>
    {
        private readonly DataBaseHelper _dataBase;

        public AliasRepository(DataBaseHelper dataBase)
        {
            _dataBase = dataBase;
        }

        public List<string> GetAll()
        {
            throw new NotImplementedException();
        }
        
        public string GetById(string alias)
        {
            string originalUrl = string.Empty;
            try
            {
                if (_dataBase.Aliases.Count == 0)
                    return null;

                originalUrl = _dataBase.Aliases[alias];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return originalUrl;
        }
        
        public void Add(string obj)
        {

            throw new NotImplementedException();
        }
        
        public bool Remove(string id)
        {
            try
            {
                if (_dataBase.Aliases.Count == 0)
                    return false;
                _dataBase.Aliases.Remove(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public bool Update(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
