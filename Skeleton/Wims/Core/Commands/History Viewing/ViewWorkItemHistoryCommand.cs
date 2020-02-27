using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ViewWorkItemHistoryCommand : Command
    {

        /// <summary>
        /// Prints the history of a given work item.
        /// </summary>
        /// <param name="commandLine">One parameter - the name of the work item.</param>
        /// <param name="workItemProvider">We search by name the given work item.</param>
        public ViewWorkItemHistoryCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
            base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();

            var workItemName = this.CommandParameters[0];

            var findWi = this.WorkItemProvider.Find(workItemName);

            if (findWi == null)
            {
                throw new Exception("WorkItem with this title not found!");
            }

            builder.AppendLine(string.Join(Environment.NewLine, findWi.History));


            return builder.ToString().TrimEnd();
        }
    }
}
