using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSalutis.core.Models
{
    public class ContactsEntry
    {
        public ContactsEntry() { }

        public ContactsEntry(string name, string location, int office, int number, string email)
        {
            Name = name;
            Location = location;
            Office = office;
            Number = number;
            Email = email;
        }
        
        public string Name { get; set; }
        public string Location { get; set; }
        public int Office { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
    }
}
