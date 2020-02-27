using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using System.Linq;
using Wims.Models;

namespace Wims.Core.Commands
{
    public class FilterAllBugsByAssigneeCommand : Command
    {
        /// <summary>
        /// Prints all bugs where specific member is assigned
        /// </summary>
        /// <param name="commandLine">the name of the member</param>
        /// <param name="workItemProvider">list of the work items</param>
        /// <param name="memberProvider">list of the members</param>
        public FilterAllBugsByAssigneeCommand(IList<string> commandLine, IWorkItemProvider workItemProvider, IMemberProvider memberProvider)
            : base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
            this.MemberProvider = memberProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }
        public IMemberProvider MemberProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();
            var allItems = this.WorkItemProvider.WorkItems;
            var allMembers = this.MemberProvider.Members;

            if (CommandParameters.Count == 0)
            {
                throw new ArgumentException("You must provide person name to filter by.");
            }

            var bugs = allItems.Where(b => b.GetType().Name == "Bug").Select(c => c as Bug);


            if (bugs.Count() == 0)
            {
                throw new ArgumentException("No bugs available!");
            }

            var assigneeToLookFor = this.CommandParameters[0];
            if (!(allMembers.Any(m => m.Name == assigneeToLookFor)))
            {
                throw new ArgumentException($"{assigneeToLookFor} does not exist.");
            }


            foreach (var bug in bugs)
            {
                if (bug.Assignee != null)
                {
                    if (bug.Assignee.Name == assigneeToLookFor)
                    {
                        builder.AppendLine(bug.ToString());
                    }
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
