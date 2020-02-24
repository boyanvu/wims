using System;
using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Models.Common;

namespace Wims.Core.Commands
{
    public class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand(IList<string> commandLine, IWorkItemProvider workItemProvider)
            : base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }

        public override string Execute()
        {
            //overrite parameters with step by step user input

            if (this.CommandParameters.Count != 3)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }
            var title = this.CommandParameters[0];
            var description = this.CommandParameters[1];
            var rating = int.Parse(CommandParameters[2]);

            var currBoardItems = CurrentVariables.currBoardValid().WorkItems;

            var findFeedback = this.WorkItemProvider.Find(title);
            if (findFeedback != null)
            {
                throw new ArgumentException("Feedback already exists!");

            }

            var newFeedback = this.Factory.CreateFeedback(title, description, rating);

            CurrentVariables.AddToWIHistory(newFeedback);
            CurrentVariables.AddToBoardHistory(CurrentVariables.currentBoard, newFeedback);
            this.WorkItemProvider.Add(newFeedback);
            currBoardItems.Add(newFeedback);

            return $"{newFeedback.Title} feedback added to {CurrentVariables.currentBoard.Name} board!" + CurrentVariables.CreateFeedbackText(); 

        }

    }
}

