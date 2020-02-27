using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ListAllTeamItemsCommand : Command
    {
        public ListAllTeamItemsCommand(IList<string> commandLine, IWorkItemProvider workItemProvider) :
            base(commandLine)
        {
            this.WorkItemProvider = workItemProvider;
        }

        public IWorkItemProvider WorkItemProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();
            var currBoardItems = Commons.currentBoard.WorkItems;


            if (currBoardItems.Count == 0)
            {
                throw new ArgumentException("No items in this board!");

            }
            else
            {
                foreach (var boardItem in currBoardItems)
                {
                    builder.AppendLine(boardItem.ToString());
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
