using System;
using Wims.Models.Common;

namespace Wims.Models
{
    public class Feedback : WorkItem
    {
        private int rating;
        public Feedback(string title, string description, int rating, StatusFeedback status)
            : base(title, description)
        {
            this.Rating = rating;
            this.Status = status;
        }

        public int Rating
        {
            get => this.rating;
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Rating must be number between 1 and 10");
                }
                this.rating = value;
            }
        }

        public StatusFeedback Status { get; set; }
    }
}
