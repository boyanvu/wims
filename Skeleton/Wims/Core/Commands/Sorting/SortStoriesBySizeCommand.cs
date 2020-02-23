using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Models.Common;

namespace Wims.Core.Commands.Sorting
{
    public class SortStoriesBySizeCommand : Command
    {
        public SortStoriesBySizeCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
            base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }
        public override string Execute()
        {

            var builder = new StringBuilder();
            var allItems = this.WorkItemProvider.WorkItems;

            if (allItems.Count == 0)
            {
                throw new ArgumentException("No items in this board!");
            }
            else
            {
                var storiesOrderedBySize = allItems
                    .Where(b => b.GetType().Name == "Story")
                    .Select(c => c as Story)
                    .OrderBy(d => d.Size);
                //.Select(e=> builder.AppendLine(e.ToString()));


                foreach (var item in storiesOrderedBySize)
                {
                    builder.AppendLine(item.ToString());
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}