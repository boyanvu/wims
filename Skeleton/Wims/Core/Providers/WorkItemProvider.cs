using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
