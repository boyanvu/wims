using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Common;

namespace Wims.Models.Contracts
{
    public interface IMember
    {
        string Name { get; }
        IList<IWorkItem> WorkItems { get; }
        IList<string> History { get; }

       
    }
}
