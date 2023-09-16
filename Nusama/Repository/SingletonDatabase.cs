using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Repository
{
    public class SingletonDatabase
    {
        private static DatabaseEntities db = null;

        private SingletonDatabase()
        {

        }

        public static DatabaseEntities GetInstance()
        {
            if (db == null)
            {
                db = new DatabaseEntities();
            }
            return db;
        }
    }
}