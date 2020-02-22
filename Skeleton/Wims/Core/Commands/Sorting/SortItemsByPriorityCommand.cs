using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using System.Linq;
using Wims.Models;
using Wims.Models.Common;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Core.Commands
{
    public class SortAllItemsByPriority : Command
    {
        public SortAllItemsByPriority(IList<string> commandLine, IWorkItemProvider workItemProvider) :
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
                var priorityBugs = allItems.Where(b => b.GetType().Name == "Bug").Select(c => c as Bug);
                var priorityStories = allItems.Where(b => b.GetType().Name == "Story").Select(c => c as Story);
                var priorityResult = priorityBugs.Cast<ICommon>()
                            .Concat(priorityStories.Cast<ICommon>())
                            .OrderBy(q => q.Priority);

                foreach (var item in priorityResult)
                {
                    builder.AppendLine(item.ToString());
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
