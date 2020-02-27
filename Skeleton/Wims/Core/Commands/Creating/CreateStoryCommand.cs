using System;
using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Core.Providers;

namespace Wims.Core.Commands
{
    public class CreateStoryCommand : Command
    {
        /// <summary>
        /// Creates a story in the the current team and the current board.
        /// </summary>
        /// <param name="commandLine">Accepts 4 parameters - story title, story description, priortity and size</param>
        /// <param name="workItemProvider">Adds the created story to the list of all work items created in the program.
        /// We also add to the team, board and work item history.</param>
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


            var currBoardItems = Commons.CurrBoardValid().WorkItems;

            var findStory = this.WorkItemProvider.Find(title);
            if (findStory != null)
            {
                throw new ArgumentException("Story already exists!");

            }

            var newStory = this.Factory.CreateStory(title, description, priority, size);


            Commons.AddToWIHistory(newStory);
            this.WorkItemProvider.Add(newStory);
            currBoardItems.Add(newStory);

            return $"{newStory.Title} story added to {Commons.currentBoard.Name} board!" + Commons.CreateStoryText();

        }

    }
}

