using System;
using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using Wims.Core.Providers;

namespace Wims.Core.Commands
{
    public class CreateBugCommand : Command
    {

        /// <summary>
        /// Creates a bug in the the current team and the current board.
        /// </summary>
        /// <param name="commandLine">Accepts 4 parameters - bug title, bug description, priortity and severity</param>
        /// <param name="workItemProvider">Adds the created bug to the list of all work items created in the program.
        /// We also add to the team, board and work item history.</param>
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


            var currBoardItems = Commons.CurrBoardValid().WorkItems;

            var findBug = this.WorkItemProvider.Find(title);
            if (findBug != null)
            {
                throw new ArgumentException("Bug already exists!");

            }

            var newBug = this.Factory.CreateBug(title, description, priority, severity);

            Commons.AddToWIHistory(newBug);
            this.WorkItemProvider.Add(newBug);
            currBoardItems.Add(newBug);

            return $"{newBug.Title} bug added to {Commons.currentBoard.Name} board!" + Commons.CreateBugText();

        }
    }
}
