using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Core.Providers;
using Wims.Models;

namespace Wims.Core.Commands
{
    public class ModifyFeedbackCommand : Command
    {
        public ModifyFeedbackCommand(IList<string> commandLine, IWorkItemProvider workItemProvider)
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
            var teamFeedbacks = currBoardItems.Where(b => b.GetType().Name == "Feedback");
            var feedbackToModify = teamFeedbacks.FirstOrDefault(b => b.Title == this.CommandParameters[0]) as Feedback;

            if (this.CommandParameters[1] == "rating")
            {
                feedbackToModify.Rating = int.Parse(this.CommandParameters[2]);
            }
            else if (this.CommandParameters[1] == "status")
            {
                feedbackToModify.Status = ValidateEnums.ValidateStatusFeedback(this.CommandParameters[2]);
            }
            else
            {
                throw new ArgumentException("Invalid parameter to modify." + Environment.NewLine + "You can modify rating or status.");
            }

            feedbackToModify.History.Add($"{feedbackToModify.Title}'s {this.CommandParameters[1]} was modified to {this.CommandParameters[2]}");
            return $"{feedbackToModify.Title} feedback's {this.CommandParameters[1]} was modified to {this.CommandParameters[2]} in {Commons.currentBoard.Name} board!";

        }
    }
}
