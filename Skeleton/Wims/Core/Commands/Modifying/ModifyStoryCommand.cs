using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Core.Providers;
using Wims.Models.Common;

namespace Wims.Core.Commands
{
    public class ModifyStoryCommand : Command
    {
        public ModifyStoryCommand(IList<string> commandLine, IWorkItemProvider workItemProvider)
            : base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }

        public override string Execute()
        {
            if (this.CommandParameters.Count != 3)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var currBoardItems = Commons.currentBoard.WorkItems;
            var teamStories = currBoardItems.Where(b => b.GetType().Name == "Story");
            var storyToModify = teamStories.FirstOrDefault(b => b.Title == this.CommandParameters[0]) as Story;

            if (this.CommandParameters[1].ToLower() == "priority")
            {
                storyToModify.Priority = ValidateEnums.ValidatePriority(this.CommandParameters[2]);

            }
            else if (this.CommandParameters[1].ToLower() == "size")
            {
                storyToModify.Size = ValidateEnums.ValidateStorySize(this.CommandParameters[2]);
            }
            else if (this.CommandParameters[1].ToLower() == "status")
            {
                storyToModify.Status = ValidateEnums.ValidateStatusStory(this.CommandParameters[2]);
            }
            else
            {
                throw new ArgumentException("Invalid parameter to modify." + Environment.NewLine + "You can modify priority, status or size.");
            }


            storyToModify.History.Add($"{storyToModify.Title}'s {this.CommandParameters[1]} was modified to {this.CommandParameters[2]}");
            return $"{storyToModify.Title} story's {this.CommandParameters[1]} was modified to {this.CommandParameters[2]} in {Commons.currentBoard.Name} board!";
        }
    }
}