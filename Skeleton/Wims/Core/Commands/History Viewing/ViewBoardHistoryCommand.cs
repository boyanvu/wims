using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ViewBoardHistoryCommand : Command
    {
        /// <summary>
        /// Prints the current board history.
        /// </summary>
        /// <param name="commandLine">One parameter - the board name</param>
        /// <param name="boardProvider">We use the list of all boards to find the one that we need</param>
        public ViewBoardHistoryCommand(IList<string> commandLine, IBoardProvider boardProvider) :
            base(commandLine)
        {
            this.BoardProvider = boardProvider;
        }

        public IBoardProvider BoardProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();

            var boardName = this.CommandParameters[0];

            var findBoard = this.BoardProvider.Find(boardName);

            if (findBoard == null)
            {
                throw new Exception("Board with this name does not exist!");
            }

            builder.AppendLine(string.Join(Environment.NewLine, findBoard.History));


            return builder.ToString().TrimEnd();
        }
    }
}
