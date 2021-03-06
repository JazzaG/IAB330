﻿using ProjectSalutis.core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectSalutis.core.Interfaces
{
    public interface IProjectDatabase
    {
        Task<IEnumerable<JourneyEntry>> GetJourneyEntries();
        Task<int> DeleteJourneyEntry(object id);
        Task<int> InsertJourneyEntry(JourneyEntry entry);
        Task<int> InsertJourneyEntry(string category, int rating, string notes);

		Task<IEnumerable<Goal>> GetGoals();
		Task<int> DeleteGoal(Goal goal);
		Task<int> InsertGoal(Goal goal);
		Task<int> UpdateGoal(Goal goal);

        Task<IEnumerable<Contact>> GetContacts();
        Task<int> InsertContact(Contact contact);
        Task<int> DeleteContact(Contact contact);
    }
}
