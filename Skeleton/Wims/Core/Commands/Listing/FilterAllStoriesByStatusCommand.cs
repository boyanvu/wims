using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using System.Linq;
using Wims.Core.Providers;
using Wims.Models.Common;

namespace Wims.Core.Commands
{
    public class FilterAllStoriesByStatusCommand : Command
    {
        /// <summary>
        /// Prints all stories with specific status
        /// </summary>
        /// <param name="commandLine">storie status to filter by </param>
        /// <param name="workItemProvider">list of the work items</param>
        public FilterAllStoriesByStatusCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
            base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();
            var allItems = this.WorkItemProvider.WorkItems;

            if (CommandParameters.Count == 0)
            {
                throw new ArgumentException("You must provide story status to filter by.");
            }

            var stories = allItems.Where(b => b.GetType().Name == "Story").Select(c => c as Story);


            if (stories.Count() == 0)
            {
                throw new ArgumentException("No stories available!");
            }

            var storyVal = ValidateEnums.ValidateStatusStory(this.CommandParameters[0]);

            {
                foreach (var story in stories)
                {
                    if (story.Status == storyVal)
                    {
                        builder.AppendLine(story.ToString());
                    }
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
