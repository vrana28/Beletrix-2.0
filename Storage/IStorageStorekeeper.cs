﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Storage
{
    public interface IStorageStorekeeper
    {
        void Add(Storekeeper s);
        void Delete(Storekeeper s);
        bool Find(string username, string password);
        List<Storekeeper> GetAll();
        void Update(Storekeeper s);
    }
}
