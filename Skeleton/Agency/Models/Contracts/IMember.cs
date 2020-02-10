using System;
using System.Collections.Generic;
using System.Text;
using Agency.Models.Common;

namespace Agency.Models.Contracts
{
    public interface IMember
    {
        string Name { get; }
        IList<IWorkItem> WorkItems { get; }
        IList<string> History { get; }
    }
}
