using System;
using Wims.Models.Common;
using Wims.Models.Contracts;

namespace Wims.Models
{
    public class Feedback : WorkItem, IFeedback
    {
        private int rating;
        public Feedback(string title, string description, int rating)
            : base(title, description)
        {
            this.Rating = rating;
            this.Status = StatusFeedback.New;
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

      
        public override string ToString()
        {
            return $"{this.GetType().Name}:{Environment.NewLine}  " +
                $"Title: {this.Title}{Environment.NewLine}  " +
                $"Description: {this.Description}{Environment.NewLine}  " +
                $"Rating: {this.Rating}{Environment.NewLine}  " +
                $"Status: {this.Status}{Environment.NewLine}  " +
                $"Comments: {String.Join(" ", this.Comments)}";
        }
    }



}
