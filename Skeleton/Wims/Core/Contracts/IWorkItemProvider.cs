using System.Collections.Generic;
using Wims.Models.Contracts;

namespace Wims.Core.Contracts
{
    public interface IWorkItemProvider
    {
        IReadOnlyList<IWorkItem> WorkItems { get; }

        void Add(IWorkItem item);

        public IWorkItem Find(string title);

    }
}
