using System;
using System.Collections.Generic;
using Wims.Models.Contracts;

namespace Wims.Models
{
    public class Member : IMember
    {
        private string name;
        public Member(string name)
        {
            this.Name = name;
            this.WorkItems = new List<IWorkItem>();
            this.History = new List<string>();

        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Member name must not be null!");
                }
                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentException("Member name must be between 5 and 15 characters long!");
                }
                this.name = value;

            }
        }

        public IList<IWorkItem> WorkItems { get; }


        public IList<string> History { get; }


        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}