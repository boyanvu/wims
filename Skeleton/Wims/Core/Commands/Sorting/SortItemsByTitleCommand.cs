using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using System.Linq;

namespace Wims.Core.Commands
{
    public class SortAllItemsCommand : Command
    {
        public SortAllItemsCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
            base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();
            var allItems = this.WorkItemProvider.WorkItems;
            var sortedItems = allItems.OrderBy(n => n.Title);

            if (allItems.Count == 0)
            {
                throw new ArgumentException("No items in this board!");

            }
            else
            {
                foreach (var item in sortedItems)
                {
                    builder.AppendLine(item.ToString());
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
