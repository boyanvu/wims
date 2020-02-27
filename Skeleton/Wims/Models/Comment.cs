using System;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Models
{
    public class Comment : IComment
    {
        private string author;
        private string message;
        private DateTime createdOn;

        public Comment(string author, string message)
        {
            this.createdOn = DateTime.Now;
            this.Author = author;
            this.Message = message;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                this.author = value;
            }
        }
        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public DateTime CreatedOn { get; }

        public override string ToString()
        {
            return $"  {this.Author}: {this.Message} - Created on: {this.createdOn}";
        }

    }
}
