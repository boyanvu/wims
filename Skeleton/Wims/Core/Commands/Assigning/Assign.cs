using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Core.Commands.Abstracts;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Core.Commands
{
    public class AssignCommand : Command
    {
        /// <summary>
        /// Assigning a work item to a member
        /// </summary>
        /// <param name="commandLine">Accepts two parameters - the member name and the work item title with which
        /// we find the given member and assign him the given work item.</param>
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

            var currTeamMembers = Commons.currentTeam.Members;
            var currBoardItems = Commons.currentBoard.WorkItems;

            var assignee = currTeamMembers.FirstOrDefault(m => m.Name == assigneeName) ??
                throw new ArgumentException($"Member with name {assigneeName} does not exist in team {Commons.currentTeam.Name}.");

            var workItem = currBoardItems.FirstOrDefault(wi => wi.Title == workItemTitle) ??
                throw new ArgumentException($"Work item with title {workItemTitle} does not exist in board {Commons.currentBoard.Name}.");

            var wi = workItem as ICommon;

            if (wi == null)
                throw new ArgumentException($"Work item {workItemTitle} is of type feedback and it is not supposed to have assignee.");

            wi.Assignee = assignee;

            assignee.History.Add($"{workItem.Title} {workItem.GetType().Name.ToLower()} has been assigned to {assigneeName}");
            workItem.History.Add($"{workItem.Title} {workItem.GetType().Name.ToLower()} has been assigned to {assigneeName}");
            Commons.currentBoard.History.Add($"{workItem.Title} {workItem.GetType().Name.ToLower()} has been assigned to {assigneeName}");

            return $"{assigneeName} has been assigned to {workItemTitle}";
        }
    }
}
