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

        public List<UrlMapping> GetAll()
        {
            throw new NotImplementedException();
        }
       

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
        
        public bool Remove(string key)
        {
            try
            {
                if (_dataBase.URLMappings.Count == 0)
                {
                    Console.WriteLine("No records in the DB to remove");
                    return false;
                }
                //Remove URl that has the associated key
                return _dataBase.URLMappings.Remove(key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public bool Update(UrlMapping obj)
        {
            throw new NotImplementedException();
        }
    }
}
