﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURLPOC.Data
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(string input);
        void Add(T obj);
        bool Remove(string key);
        bool Update(T obj);
    }
}
