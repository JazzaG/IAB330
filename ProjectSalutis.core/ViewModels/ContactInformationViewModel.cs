using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    public class ContactInformationViewModel : MvxViewModel
    {

        public Contact Contact { get; set; }

        public ICommand DeleteContactClickCommand
        {
            get
            {
                return new MvxCommand(() => OnDeleteButtonClick());
            }
        }

        private IProjectDatabase database;

        public ContactInformationViewModel(IProjectDatabase database)
        {
            this.database = database;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            int contactId = Int32.Parse(parameters.Data["contact-id"]);
            LoadContact(contactId);
        }

        private async void LoadContact(int id)
        {
            var contacts = await database.GetContacts();
            foreach (var contact in contacts)
            {
                if (contact.Id == id)
                {
                    Contact = contact;
                }
            }
        }

        private void OnDeleteButtonClick()
        {
            database.DeleteContact(Contact);
            ShowViewModel<ContactListViewModel>();
        }

    }
}
