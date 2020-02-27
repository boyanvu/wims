using System;
using System.Collections.Generic;
using Wims.Models.Contracts;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Models
{
    public abstract class WorkItem : IWorkItem
    {
        private static int id = 1;
        private string title;
        private string description;

        public WorkItem(string title, string description)
        {
            this.Id = id++;
            this.Title = title;
            this.Description = description;
            this.Comments = new List<IComment>();
            this.History = new List<string>();
        }

        public int Id
        {
            get;

            set;

        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Work item title must not be null!");
                }
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Work item title must be between 10 and 50 characters long!");
                }
                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Work item description must not be null!");
                }
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentOutOfRangeException("Work item description must be between 10 and 500 characters long!");
                }

                this.description = value;
            }
        }

        public IList<IComment> Comments { get; }

        public IList<string> History { get; }

        public void AddComment(IComment comment)
        {
            this.Comments.Add(comment);
        }
    }
}
