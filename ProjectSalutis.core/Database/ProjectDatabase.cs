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
    public class ProjectDatabase : IProjectDatabase
    {
        private SQLiteConnection database;
        public ProjectDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<JourneyEntry>();
			database.CreateTable<Goal>();
            database.CreateTable<Contact>();

            //method to fill entries manually for demo
            if (database.Table<JourneyEntry>().Count() == 0) {
                AddInitialJourneyEntries();
            }
        }

        public async void AddInitialJourneyEntries()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            await InsertJourneyEntry(new Models.JourneyEntry(new DateTime(year, month, day, 09, 16, 17).Subtract(new TimeSpan(7, 0, 0, 0)), "Exercise", 4, "Started pilates"));
            await InsertJourneyEntry(new Models.JourneyEntry(new DateTime(year, month, day, 15, 28, 42).Subtract(new TimeSpan(6, 0, 0, 0)), "Happiness", 4, "Saw a dog"));
            await InsertJourneyEntry(new Models.JourneyEntry(new DateTime(year, month, day, 12, 25, 25).Subtract(new TimeSpan(5, 0, 0, 0)), "Nutrition", 3, "Vegetable bolognaise"));
            await InsertJourneyEntry(new Models.JourneyEntry(new DateTime(year, month, day, 13, 30, 12).Subtract(new TimeSpan(4, 0, 0, 0)), "Exercise", 2, "Short walk"));
            await InsertJourneyEntry(new Models.JourneyEntry(new DateTime(year, month, day, 20, 57, 23).Subtract(new TimeSpan(4, 0, 0, 0)), "Happiness", 3, "Movie with friends"));
            await InsertJourneyEntry(new Models.JourneyEntry(new DateTime(year, month, day, 18, 43, 34).Subtract(new TimeSpan(3, 0, 0, 0)), "Nutrition", 4, "Chickpea and spinach pasta"));
            await InsertJourneyEntry(new Models.JourneyEntry(new DateTime(year, month, day, 09, 06, 59).Subtract(new TimeSpan(2, 0, 0, 0)), "Exercise", 4, "Completed pilates goal"));
            await InsertJourneyEntry(new Models.JourneyEntry(new DateTime(year, month, day, 18, 35, 51).Subtract(new TimeSpan(1, 0, 0, 0)), "Nutrition", 2, "Sushi"));
            await InsertJourneyEntry(new Models.JourneyEntry(new DateTime(year, month, day, 18, 36, 23).Subtract(new TimeSpan(1, 0, 0, 0)), "Happiness", 3, "Sushi!"));
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

        public async Task<int> InsertJourneyEntry(string category, int rating, string notes)
        {
            return await InsertJourneyEntry(new JourneyEntry(category, rating, notes));
        }

		public async Task<IEnumerable<Goal>> GetGoals()
		{
			return database.Table<Goal>().Reverse().ToList();
		}

		public async Task<int> DeleteGoal(Goal goal)
		{
			var num = database.Delete(goal);
			database.Commit();
			return num;
		}

		public async Task<int> InsertGoal(Goal goal)
		{
			var num = database.Insert(goal);
			database.Commit();
			return num;
		}

		public async Task<int> UpdateGoal(Goal goal)
		{
			var num = database.Update(goal);
			database.Commit();
			return num;
		}


        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return database.Table<Contact>().Reverse().ToList();
        }

        public async Task<int> InsertContact(Contact contact)
        {
            var num = database.Insert(contact);
            database.Commit();
            return num;
        }

        public async Task<int> DeleteContact(Contact contact)
        {
            var num = database.Delete(contact);
            database.Commit();
            return num;
        }

    }
}
