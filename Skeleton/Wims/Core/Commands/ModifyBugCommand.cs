using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Core.Providers;
using Wims.Models;
using Wims.Models.Common;

namespace Wims.Core.Commands
{
    public class ModifyBugCommand : Command
    {
        public ModifyBugCommand(IList<string> commandLine, IWorkItemProvider workItemProvider)
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

            var currBoardItems = CurrentVariables.currentBoard.WorkItems;
            var teamBugs = currBoardItems.Where(b => b.GetType().Name == "Bug");
            var bugToModify = teamBugs.FirstOrDefault(b => b.Title == this.CommandParameters[0]) as Bug;

            if (this.CommandParameters[1] == "priority")
            {
                if (this.CommandParameters[2] == "high")
                {
                    bugToModify.Priority = Priority.High;
                }
                if (this.CommandParameters[2] == "medium")
                {
                    bugToModify.Priority = Priority.Medium;
                }
                if (this.CommandParameters[2] == "low")
                {
                    bugToModify.Priority = Priority.Low;
                }
            }
            else if (this.CommandParameters[1] == "severity")
            {
                if (this.CommandParameters[2] == "critical")
                {
                    bugToModify.Severity = Severity.Critical;
                }
                if (this.CommandParameters[2] == "major")
                {
                    bugToModify.Severity = Severity.Major;
                }
                if (this.CommandParameters[2] == "minor")
                {
                    bugToModify.Severity = Severity.Minor;
                }
            }
            else if (this.CommandParameters[1] == "status")
            {
                if (this.CommandParameters[2] == "active")
                {
                    bugToModify.Status = StatusBug.Active;
                }
                if (this.CommandParameters[2] == "fixed")
                {
                    bugToModify.Status = StatusBug.Fixed;
                }

            }

            return $"{bugToModify.Title} bug's {this.CommandParameters[1]} was modified to {this.CommandParameters[2]} {CurrentVariables.currentBoard.Name} board!";

        }


    }
}
