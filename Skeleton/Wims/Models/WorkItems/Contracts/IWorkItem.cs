using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Models.Contracts
{
    public interface IWorkItem
    {
        int Id { get; set; }
        string Title { get; }
        string Description { get; }
        IList<IComment> Comments { get; }
        IList<string> History { get; }

        void AddComment(IComment comment);
    }
}
