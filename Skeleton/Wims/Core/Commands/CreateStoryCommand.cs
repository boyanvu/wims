using System;
using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Core.Providers;
using Wims.Models.Common;

namespace Wims.Core.Commands
{
    public class CreateStoryCommand : Command
    {
        public CreateStoryCommand(IList<string> commandLine, IWorkItemProvider workItemProvider)
            : base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }

        public override string Execute()
        {
            //overrite parameters with step by step user input

            if (this.CommandParameters.Count != 4)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }
            var title = this.CommandParameters[0];
            var description = this.CommandParameters[1];
            var priority = ValidateEnums.ValidatePriority(CommandParameters[2]);
            var size = ValidateEnums.ValidateStorySize(CommandParameters[3]);
            var status = StatusStory.NotDone;

            var currBoardItems = CurrentVariables.currentBoard.WorkItems;

            foreach (var boardItem in currBoardItems)
            {
                if (boardItem.Title == title)
                {
                    throw new Exception("Story already exists!");
                }
            }

            var newStory = this.Factory.CreateStory(title, description, priority, size, status);

            this.WorkItemProvider.Add(newStory);
            currBoardItems.Add(newStory);

            return $"{newStory.Title} story added to {CurrentVariables.currentBoard.Name} board!";

        }

    }
}

