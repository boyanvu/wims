using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Core.Commands.Abstracts;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Core.Commands
{
    public class UnassignCommand : Command
    {

        /// <summary>
        /// Unassigning a work item to a member
        /// </summary>
        /// <param name="commandLine">Accepts one parameter - the member name and the work item title with which </param>
        public UnassignCommand(IList<string> commandLine)
            : base(commandLine)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var workItemTitle = this.CommandParameters[0];

            var currBoardItems = Commons.currentBoard.WorkItems;

            var workItem = currBoardItems.FirstOrDefault(wi => wi.Title == workItemTitle) ??
                throw new ArgumentException($"Work item with title {workItemTitle} does not exist in board {Commons.currentBoard.Name}.");

            var wi = workItem as ICommon;

            if (wi == null)
                throw new ArgumentException($"Work item {workItemTitle} is of type feedback and it is not supposed to have assignee.");

            if (wi.Assignee == null)
                throw new ArgumentException($"There's no member assigned to {workItemTitle}");

            var currAssignee = wi.Assignee.Name;

            wi.Assignee.History.Add($"{workItem.Title} {workItem.GetType().Name.ToLower()} has been unassigned from {currAssignee}");
            wi.Assignee = null;

            workItem.History.Add($"{workItem.Title} {workItem.GetType().Name.ToLower()} has been unassigned from {currAssignee}");
            Commons.currentBoard.History.Add($"{workItem.Title} {workItem.GetType().Name.ToLower()} has been assigned to {currAssignee}");


            return $"{currAssignee} has been unassigned from {workItemTitle}";
        }
    }
}
