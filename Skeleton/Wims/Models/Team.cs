using System;
using System.Collections.Generic;
using Wims.Models.Contracts;

namespace Wims.Models
{
    public class Team : ITeam
    {
        private string name;

        public Team(string name)
        {
            this.Name = name;
            this.Members = new List<IMember>();
            this.Boards = new List<IBoard>();
        }
        public string Name 
        { 
            get => this.name;
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("Name of the team must be provided.");
                }
                this.name = value;
            }
        }

        public IList<IMember> Members { get; }

        public IList<IBoard> Boards { get; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
