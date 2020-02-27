using System;
using System.Collections.Generic;
using Wims.Models.Contracts;

namespace Wims.Models
{
    public class Board : IBoard
    {
        private string name;
        
        public Board(string name)
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
                    throw new ArgumentNullException("Board name must not be null!");
                }
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Board name must be between 5 and 10 characters long!");
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
