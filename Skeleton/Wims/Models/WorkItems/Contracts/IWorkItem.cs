using System;
using System.Collections.Generic;
using System.Text;

namespace Wims.Models.Contracts
{
    public interface IWorkItem
    {
        int Id { get; set; }
        string Title { get; }
        string Description { get; }
        IList<string> Comments { get; }
        IList<string> History { get; }

        string Print();
    }
}
