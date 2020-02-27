using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ListAllTeamBoardsCommand : Command
    {
        public ListAllTeamBoardsCommand(IList<string> commandLine, IBoardProvider boardProvider) :
            base(commandLine)
        {
            this.BoardProvider = boardProvider;
        }

        public IBoardProvider BoardProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();
            var boards = Commons.currentTeam.Boards;


            if (boards.Count == 0)
            {
                throw new ArgumentException("No boards in this team!" + Environment.NewLine +
                          $"To add a new board in the team, use the following command:" + Environment.NewLine +
                          $"createboard <boardname>");
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
