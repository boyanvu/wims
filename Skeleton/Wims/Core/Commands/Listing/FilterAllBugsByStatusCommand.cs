using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;
using System.Linq;
using Wims.Core.Providers;
using Wims.Models;

namespace Wims.Core.Commands
{
    public class FilterAllBugsByStatusCommand : Command
    {
        public FilterAllBugsByStatusCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
            base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();
            var allItems = this.WorkItemProvider.WorkItems;

            if (CommandParameters.Count == 0)
            {
                throw new ArgumentException("You must provide bug status to filter by.");
            }

            var bugs = allItems.Where(b => b.GetType().Name == "Bug").Select(c => c as Bug);


            if (bugs.Count() == 0)
            {
                throw new ArgumentException("No bugs available!");
            }

            var bugStts = ValidateEnums.ValidateStatusBug(this.CommandParameters[0]);

            {
                foreach (var bug in bugs)
                {
                    if (bug.Status == bugStts)
                    {
                        builder.AppendLine(bug.ToString());
                    }
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
