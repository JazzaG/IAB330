﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSalutis.core.Models
{
    public class JourneyEntry
    {
        public JourneyEntry() { }

        public JourneyEntry(string category, int rating, string notes)
        {
            Timestamp = DateTime.Now;
            Category = category;
            Rating = rating;
            Notes = notes;
        }

        public JourneyEntry(string category, int rating)
        {
            Timestamp = DateTime.Now;
            Category = category;
            Rating = rating;
        }

        public DateTime Timestamp { get; set; }
        public string Category { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
    }
}
