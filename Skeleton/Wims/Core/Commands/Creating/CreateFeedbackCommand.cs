using System;
using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class CreateFeedbackCommand : Command
    {
        /// <summary>
        /// Creates a feedback in the the current team and the current board.
        /// </summary>
        /// <param name="commandLine">Accepts 3 parameters - feedback title, feedback description and rating</param>
        /// <param name="workItemProvider">Adds the created feedback to the list of all work items created in the program.
        /// We also add to the team, board and work item history.</param>
        public CreateFeedbackCommand(IList<string> commandLine, IWorkItemProvider workItemProvider)
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
            var title = this.CommandParameters[0];
            var description = this.CommandParameters[1];
            var rating = int.Parse(CommandParameters[2]);

            var currBoardItems = Commons.CurrBoardValid().WorkItems;

            var findFeedback = this.WorkItemProvider.Find(title);
            if (findFeedback != null)
            {
                throw new ArgumentException("Feedback already exists!");

            }

            var newFeedback = this.Factory.CreateFeedback(title, description, rating);

            Commons.AddToWIHistory(newFeedback);        
            this.WorkItemProvider.Add(newFeedback);
            currBoardItems.Add(newFeedback);

            return $"{newFeedback.Title} feedback added to {Commons.currentBoard.Name} board!" + Commons.CreateFeedbackText();

        }

    }
}

