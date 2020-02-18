using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Core.Providers;
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
            if (this.CommandParameters.Count != 4)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }
            var title = this.CommandParameters[0];
            var description = this.CommandParameters[1];
            var priority = ValidateEnums.ValidatePriority(CommandParameters[2]);
            var severity = ValidateEnums.ValidateSeverity(CommandParameters[3]);


            var currBoardItems = CurrentVariables.currentBoard.WorkItems;

            foreach (var boardItem in currBoardItems)
            {
                if (boardItem.Title == title)
                {
                    throw new Exception("Bug already exists!");
                }
            }

            var newBug = this.Factory.CreateBug(title, description, priority, severity);

            this.WorkItemProvider.Add(newBug);
            currBoardItems.Add(newBug);

            return $"{newBug.Title} bug added to {CurrentVariables.currentBoard.Name} board!";

        }



    }
}
