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
    public class FilterAllFeedbacksByStatusCommand : Command
    {
        /// <summary>
        /// Prints all feedbacks with specific status
        /// </summary>
        /// <param name="commandLine">feedback status to filter by </param>
        /// <param name="workItemProvider">list of the work items</param>
        public FilterAllFeedbacksByStatusCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
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

            var feedbacks = allItems.Where(b => b.GetType().Name == "Feedback").Select(c => c as Feedback);


            if (feedbacks.Count() == 0)
            {
                throw new ArgumentException("No bugs available!");
            }

            var feedStts = ValidateEnums.ValidateStatusFeedback(this.CommandParameters[0]);

            {
                foreach (var feedback in feedbacks)
                {
                    if (feedback.Status == feedStts)
                    {
                        builder.AppendLine(feedback.ToString());
                    }
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
