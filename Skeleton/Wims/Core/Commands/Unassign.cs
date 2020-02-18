﻿using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Core.Commands.Abstracts;
using Wims.Models.WorkItems.Contracts;

namespace Wims.Core.Commands
{
    public class UnassignCommand : Command
    {
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

            var currBoardItems = CurrentVariables.currentBoard.WorkItems;

            var workItem = currBoardItems.FirstOrDefault(wi => wi.Title == workItemTitle) ??
                throw new ArgumentException($"Work item with title {workItemTitle} does not exist in board {CurrentVariables.currentBoard.Name}.");

            var wi = workItem as IAssignable;

            if (wi == null)
                throw new ArgumentException($"Work item {workItemTitle} is of type feedback and it is not supposed to have assignee.");

            if (wi.Assignee == null)
                throw new ArgumentException($"There's no member assigned to {workItemTitle}");

            var currAssignee = wi.Assignee.Name;

            wi.Assignee = null;

            return $"{currAssignee} has been unassigned from {workItemTitle}";
        }
    }
}
