using System;
using System.Collections.Generic;
using System.Text;

namespace Wims.Models.Contracts
{
    public interface IWorkItem
    {
        string Title { get; }
        string Description { get; }
        IList<string> Comments { get; }
        IList<string> History { get; }
    }
}
