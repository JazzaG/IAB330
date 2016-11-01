using System;

namespace ProjectSalutis.core.Models
{
    public class JourneyEntry
    {
        public JourneyEntry() { }

        public JourneyEntry(string category, int rating, string notes)
        {
            Timestamp = DateTime.Now.ToLocalTime();
            Timestamp_string = Timestamp.ToString(); //required for the time to show as not UTC
            Category = category;
            Rating = rating;
            switch (rating)
            {
                case 0:
                    RatingDrawable = "very_dissatisfied";
                    break;
                case 1:
                    RatingDrawable = "dissatisfied";
                        break;
                case 2:
                    RatingDrawable = "neutral";
                    break;
                case 3:
                    RatingDrawable = "satisfied";
                    break;
                case 4:
                    RatingDrawable = "very_satisfied";
                    break;
            }
            Notes = notes;
        }

        public DateTime Timestamp { get; set; }
        public string Timestamp_string { get; set; }
        public string Category { get; set; }
        public int Rating { get; set; }
        public string RatingDrawable { get; set; }
        public string Notes { get; set; }
    }
}
