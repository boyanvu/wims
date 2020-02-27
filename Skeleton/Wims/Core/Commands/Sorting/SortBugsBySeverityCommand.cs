using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using System.Linq;
using Wims.Models;

namespace Wims.Core.Commands
{
    public class SortBugsBySeverityCommand : Command
    {

        /// <summary>
        /// Prints all bugs ordered by severity
        /// </summary>
        /// <param name="commandLine"></param>
        /// <param name="workItemProvider">Search in the full list of work items, all which are bugs.</param>
        public SortBugsBySeverityCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
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
                var bugsOrderedByseverity = allItems
                    .Where(b => b.GetType().Name == "Bug")
                    .Select(c => c as Bug)
                    .OrderBy(d => d.Severity);
                //.Select(e=> builder.AppendLine(e.ToString()));


                foreach (var item in bugsOrderedByseverity)
                {
                    builder.AppendLine(item.ToString());
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}

