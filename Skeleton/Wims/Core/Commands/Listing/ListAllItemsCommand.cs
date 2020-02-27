using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ListAllItemsCommand : Command
    {
        /// <summary>
        /// Prints all available work items(bugs, stories and feedbacks)
        /// </summary>
        /// <param name="commandLine"></param>
        /// <param name="workItemProvider">list of work items</param>
        public ListAllItemsCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
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
                foreach (var item in allItems)
                {
                    builder.AppendLine(item.ToString());
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
