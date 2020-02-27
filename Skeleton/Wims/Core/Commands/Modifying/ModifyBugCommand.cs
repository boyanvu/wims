using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Core.Providers;
using Wims.Models;

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

            var currBoardItems = Commons.currentBoard.WorkItems;
            var teamBugs = currBoardItems.Where(b => b.GetType().Name == "Bug");
            var bugToModify = teamBugs.FirstOrDefault(b => b.Title == this.CommandParameters[0]) as Bug;

            if (this.CommandParameters[1] == "priority")
            {
                bugToModify.Priority = ValidateEnums.ValidatePriority(this.CommandParameters[2]);

            }
            else if (this.CommandParameters[1] == "severity")
            {
                bugToModify.Severity = ValidateEnums.ValidateSeverity(this.CommandParameters[2]);
            }
            else if (this.CommandParameters[1] == "status")
            {
                bugToModify.Status = ValidateEnums.ValidateStatusBug(this.CommandParameters[2]);
            }
            else
            {
                throw new ArgumentException("Invalid parameter to modify." + Environment.NewLine + "You can modify priority, status or severity.");
            }


            bugToModify.History.Add($"{bugToModify.Title}'s {this.CommandParameters[1]} was modified to {this.CommandParameters[2]}");
            return $"{bugToModify.Title} bug's {this.CommandParameters[1]} was modified to {this.CommandParameters[2]} in {Commons.currentBoard.Name} board!";
        }
    }
}
