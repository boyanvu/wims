using System.Collections.Generic;
using System.Linq;
using Wims.Core.Contracts;
using Wims.Models.Contracts;

namespace Wims.Core.Providers
{
    public class WorkItemProvider : IWorkItemProvider
    {
        private readonly List<IWorkItem> workItems = new List<IWorkItem>();
        public IReadOnlyList<IWorkItem> WorkItems
        {
            get
            {
                return this.workItems;
            }
        }

        public void Add(IWorkItem item)
        {
            workItems.Add(item);
        }

        public IWorkItem Find(string title)
        {
            var wi = workItems.FirstOrDefault(m => m.Title == title);
            return wi;
        }
    }
}
