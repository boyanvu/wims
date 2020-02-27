using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ListAllBoardsCommand : Command
    {
        public ListAllBoardsCommand(IList<string> commandLine, IBoardProvider boardProvider) :
            base(commandLine)
        {
            this.BoardProvider = boardProvider;
        }

        IBoardProvider BoardProvider { get; }
        public override string Execute()
        {
            var builder = new StringBuilder();
            var boards = this.BoardProvider.Boards;


            if (boards.Count == 0)
            {
                throw new ArgumentException("There's no boards available!" + Environment.NewLine +
                          $"To add a new board, first create a team! Use the following commands:" + Environment.NewLine +
                          $"createteam <teamname> -> createboard <membername>");
            }
            else
            {
                foreach (var board in boards)
                {
                    builder.AppendLine(board.ToString());
                }
            }
           
            return builder.ToString().TrimEnd();
        }
    }
}
