using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    public class ContactListViewModel : MvxViewModel
    {
        private ObservableCollection<ContactListWrapper> contacts = new ObservableCollection<ContactListWrapper>();
        public ObservableCollection<ContactListWrapper> Contacts
        {
            get { return contacts;  }
            set { SetProperty(ref contacts, value); }
        }

        public ICommand CreateContactButtonClick
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<NewContactViewModel>());
            }        
        }

        public IProjectDatabase database;

        public ContactListViewModel(IProjectDatabase database)
        {
            this.database = database;
        }

        public void OnResume()
        {
            GetEntries();
        }

        public async void GetEntries()
        {
            var entries = await database.GetContacts();
            contacts.Clear();
            foreach (var entry in entries)
            {
                contacts.Add(new ContactListWrapper(entry, this));
            }
        }

        public void OnContactClick(Contact contact)
        {
            var parameters = new Dictionary<string, string>
            {
                { "contact-id", contact.Id + "" }
            };

            ShowViewModel<ContactInformationViewModel>(parameters);
        }
    }
}
