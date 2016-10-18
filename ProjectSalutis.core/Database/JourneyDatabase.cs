using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SQLite.Net;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;
using MvvmCross.Platform;

namespace ProjectSalutis.core.Database
{
    public class JourneyDatabase : IJourneyDatabase
    {
        private SQLiteConnection database;
        public JourneyDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<JourneyEntry>();
        }

        public async Task<IEnumerable<JourneyEntry>> GetEntries()
        {
            return database.Table<JourneyEntry>().ToList();
        }

        public async Task<int> DeleteEntry(object id)
        {
            return database.Delete<JourneyEntry>(Convert.ToInt16(id));
        }

        public async Task<int> InsertEntry(JourneyEntry entry)
        {
            var num = database.Insert(entry);
            database.Commit();
            return num;
        }

        public async Task<int> InsertEntry(string category, int rating)
        {
            return await InsertEntry(new JourneyEntry(category, rating));
        }
    }
}
