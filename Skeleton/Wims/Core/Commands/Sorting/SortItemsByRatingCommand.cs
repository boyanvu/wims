using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using System.Linq;
using Wims.Models;

namespace Wims.Core.Commands
{
    public class SortAllItemsByRatingCommand : Command
    {
        public SortAllItemsByRatingCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
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
                var orderedFeedbacks = allItems.Where(b => b.GetType().Name == "Feedback").Select(c => c as Feedback).OrderBy(f => f.Rating);
                foreach (var item in orderedFeedbacks)
                {
                    builder.AppendLine(item.ToString());
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
