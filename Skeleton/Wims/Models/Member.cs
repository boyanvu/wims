using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Contracts;

namespace Wims.Models
{
    public class Member : IMember
    {

        public Member()
        {
            this.WorkItems = new List<IWorkItem>();
            this.History = new List<string>();
        }
        string IMember.Name => throw new NotImplementedException();

        public IList<IWorkItem> WorkItems { get; }

        public IList<string> History { get; }
    }
}
