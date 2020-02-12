using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Contracts;

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
            this.Comments = new List<string>();
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
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Board name must be between 5 and 10 characters long!");
                }
                else if (value == null)
                {
                    throw new ArgumentNullException("Work item title must not be null!");
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
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentOutOfRangeException("Board name must be between 5 and 10 characters long!");
                }
                else if (value == null)
                {
                    throw new ArgumentNullException("Work item description must not be null!");
                }
                this.description = value;
            }
        }

        public IList<string> Comments { get; }
       
        public IList<string> History { get; }
        
    }
}
