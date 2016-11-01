using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSalutis.core.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public string OfficePhone { get; set; }
        public string PersonalPhone { get; set; }
        public string Email { get; set; }

        [Ignore]
        public string OfficePhoneView
        {
            get
            {
                return "(W) " + OfficePhone;
            }
        }

        [Ignore]
        public string PersonalPhoneView
        {
            get
            {
                return "(P) " + PersonalPhone;
            }
        }


        public Contact()
        {

        }
        
    }
}
