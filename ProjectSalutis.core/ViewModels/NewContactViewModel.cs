using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Models;
using System.Windows.Input;
using ProjectSalutis.core.Interfaces;

namespace ProjectSalutis.core.ViewModels
{
    public class NewContactViewModel
		: MvxViewModel
    {
		public Contact Contact { get; set; }

        public ICommand AddButtonClickCommand
        {
            get
            {
                return new MvxCommand(() => AddButtonClicked());
            }           
        }

        private IProjectDatabase database;

        public NewContactViewModel(IProjectDatabase database)
        {
            this.database = database;
            Contact = new Contact();
        }

        private void AddButtonClicked()
        {
            // Store model in database
            this.database.InsertContact(Contact);

            // Go to contact list view
            ShowViewModel<ContactListViewModel>();
        }
    }
}
