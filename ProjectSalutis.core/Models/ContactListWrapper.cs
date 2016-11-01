using MvvmCross.Core.ViewModels;
using ProjectSalutis.core.ViewModels;
using System.Windows.Input;

namespace ProjectSalutis.core.Models
{
    public class ContactListWrapper
    {

        private ContactListViewModel parent;
        
        public Contact Contact { get; set; }

        public ContactListWrapper(Contact contact, ContactListViewModel parent)
        {
            this.Contact = contact;
            this.parent = parent;
        }

        public ICommand ClickCommand
        {
            get
            {
                return new MvxCommand(() => this.parent.OnContactClick(this.Contact));
            }
        }

    }
}
