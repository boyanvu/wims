using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;

namespace Wims.Core.Commands
{
    public class ViewBoardHistoryCommand : Command
    {
        /// <summary>
        /// Prints the current board history.
        /// </summary>
        /// <param name="commandLine"></param>
        
        public ViewBoardHistoryCommand(IList<string> commandLine) :
            base(commandLine)
        {
          
        }

  
        public override string Execute()
        {

            var builder = new StringBuilder();

            builder.AppendLine(string.Join(Environment.NewLine, Commons.AddToBoardHistory(Commons.currentBoard)));

            return builder.ToString().TrimEnd();
        }
    }
}
