using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Models.Common;

namespace Wims.Core.Commands
{
    public class CreateBugCommand : Command
    {
        public CreateBugCommand(IList<string> commandLine, IWorkItemProvider workItemProvider)
            : base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }

        public override string Execute()
        {
            if (this.CommandParameters.Count != 5)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }
            var title = this.CommandParameters[0];
            var description = this.CommandParameters[1];
            var priority = this.GetPriority(CommandParameters[2]);
            var severity = this.GetSeverity(CommandParameters[3]);
            var statusBug = this.GetBugStatus(CommandParameters[4]);

            var workItems = this.WorkItemProvider.WorkItems;
            var currBoardItems = CurrentVariables.currentBoard.WorkItems;

            foreach (var boardItem in currBoardItems)
            {
                if (boardItem.Title == title)
                {
                    throw new Exception("Bug already exists!");
                }
            }

            var newBug = this.Factory.CreateBug(title, description, priority, severity, statusBug);


            currBoardItems.Add(newBug);

            return $"{newBug.Title} bug added to {CurrentVariables.currentBoard.Name} board!";

        }

        private StatusBug GetBugStatus(string bugAsString)
        {
            switch (bugAsString)
            {
                case "active":
                    return StatusBug.Active;
                case "fixed":
                    return StatusBug.Fixed;
                default:
                    throw new InvalidOperationException("InvalidBugStatusType! Bug status must be active or fixed!");
            }
        }

        private Priority GetPriority(string priorityAsString)
        {
            switch (priorityAsString)
            {
                case "high":
                    return Priority.High;
                case "medium":
                    return Priority.Medium;
                case "low":
                    return Priority.Low;
                default:
                    throw new InvalidOperationException("InvalidBugPriorityType! Bug priority must be high, medium or low!");
            }
        }

        private Severity GetSeverity(string severityAsString)
        {
            switch (severityAsString)
            {
                case "critical":
                    return Severity.Critical;
                case "major":
                    return Severity.Major;
                case "minor":
                    return Severity.Minor;
                default:
                    throw new InvalidOperationException("InvalidBugSeverityType! Bug severity must be critical, major or minor!");
            }
        }

    }
}
