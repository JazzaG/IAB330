using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.Interfaces;
using ProjectSalutis.core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectSalutis.core.ViewModels
{
    public class ContactsViewModel
        :MvxViewModel
    {
        private ObservableCollection<ContactsEntry> usercontact = new ObservableCollection<ContactsEntry>();

        public ObservableCollection<ContactsEntry> Usercontact
        {
            get { return usercontact; }
            set { SetProperty(ref usercontact, value); }
        }
    }
}
