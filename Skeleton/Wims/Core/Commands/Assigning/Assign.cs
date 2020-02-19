using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Core.Commands.Abstracts;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Core.Commands
{
    public class AssignCommand : Command
    {
        public AssignCommand(IList<string> commandLine)
            : base(commandLine)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count != 2)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var assigneeName = this.CommandParameters[0];
            var workItemTitle = this.CommandParameters[1];

            var currTeamMembers = CurrentVariables.currentTeam.Members;
            var currBoardItems = CurrentVariables.currentBoard.WorkItems;

            var assignee = currTeamMembers.FirstOrDefault(m => m.Name == assigneeName) ??
                throw new ArgumentException($"Member with name {assigneeName} does not exist in team {CurrentVariables.currentTeam.Name}.");

            var workItem = currBoardItems.FirstOrDefault(wi => wi.Title == workItemTitle) ??
                throw new ArgumentException($"Work item with title {workItemTitle} does not exist in board {CurrentVariables.currentBoard.Name}.");

            var wi = workItem as IAssignable;

            if (wi == null)
                throw new ArgumentException($"Work item {workItemTitle} is of type feedback and it is not supposed to have assignee.");

            wi.Assignee = assignee;

            workItem.History.Add($"{workItem.Title} {workItem.GetType().Name.ToLower()} has been assigned to {assigneeName}");
            CurrentVariables.currentBoard.History.Add($"{workItem.Title} {workItem.GetType().Name.ToLower()} has been assigned to {assigneeName}");

            return $"{assigneeName} has been assigned to {workItemTitle}";
        }
    }
}
