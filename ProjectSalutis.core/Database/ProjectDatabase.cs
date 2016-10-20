﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SQLite.Net;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;
using MvvmCross.Platform;

namespace ProjectSalutis.core.Database
{
    public class ProjectDatabase : IProjectDatabase
    {
        private SQLiteConnection database;
        public ProjectDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<JourneyEntry>();
        }

        public async Task<IEnumerable<JourneyEntry>> GetJourneyEntries()
        {
            return database.Table<JourneyEntry>().Reverse().ToList();
        }

        public async Task<int> DeleteJourneyEntry(object id)
        {
            return database.Delete<JourneyEntry>(Convert.ToInt16(id));
        }

        public async Task<int> InsertJourneyEntry(JourneyEntry entry)
        {
            var num = database.Insert(entry);
            database.Commit();
            return num;
        }

        public async Task<int> InsertJourneyEntry(string category, int rating)
        {
            return await InsertJourneyEntry(new JourneyEntry(category, rating));
        }

		public async Task<IEnumerable<Goal>> GetGoals()
		{
			throw new NotImplementedException();
		}

		public async Task<int> DeleteGoal(object id)
		{
			throw new NotImplementedException();
		}

		public async Task<int> InsertGoal(Goal goal)
		{
			throw new NotImplementedException();
		}
	}
}
