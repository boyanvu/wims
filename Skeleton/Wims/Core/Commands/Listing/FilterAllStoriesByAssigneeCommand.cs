using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using System.Linq;
using Wims.Models.Common;

namespace Wims.Core.Commands
{
    public class FilterAllStoriesByAssigneeCommand : Command
    {
        /// <summary>
        /// Prints all stories where specific member is assigned
        /// </summary>
        /// <param name="commandLine">the name of the member</param>
        /// <param name="workItemProvider">list of the work items</param>
        /// <param name="memberProvider">list of the members</param>
        public FilterAllStoriesByAssigneeCommand(IList<string> commandLine, IWorkItemProvider workItemProvider, IMemberProvider memberProvider)
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

            var stories = allItems.Where(b => b.GetType().Name == "Story").Select(c => c as Story);


            if (stories.Count() == 0)
            {
                throw new ArgumentException("No stories available!");
            }

            var assigneeToLookFor = this.CommandParameters[0];
            if (!(allMembers.Any(m => m.Name == assigneeToLookFor)))
            {
                throw new ArgumentException($"{assigneeToLookFor} does not exist.");
            }


            foreach (var story in stories)
            {
                if (story.Assignee != null)
                {
                    if (story.Assignee.Name == assigneeToLookFor)
                    {
                        builder.AppendLine(story.ToString());
                    }
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}