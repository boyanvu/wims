using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class CreateBoardCommand : Command
    {
        public CreateBoardCommand(IList<string> commandLine, IBoardProvider boardProvider)
            : base(commandLine)
        {
            this.BoardProvider = boardProvider;
        }

        public IBoardProvider BoardProvider { get; }

        public override string Execute()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var currTeam = CurrentVariables.currentTeam;

            if (currTeam == null)
            {
                var msg = $"You have to select/create team before board creation." + Environment.NewLine +
                          $"You can you use one of these commands:" + Environment.NewLine +
                          $"createteam <teamname>, selectteam <teamname>, listteams";
                throw new Exception(msg);
            }

            var boardName = this.CommandParameters[0];
            foreach (var boardInTeam in currTeam.Boards)
            {
                if (boardInTeam.Name == boardName)
                {
                    var msg = $"Board with name {boardName} already exists in team {currTeam.Name}" + Environment.NewLine +
                              $"You can see all available boards with command listboards.";
                    throw new ArgumentException(msg);
                }
            }

            var board = this.Factory.CreateBoard(
                boardName
            );

            this.BoardProvider.Add(board);
            currTeam.Boards.Add(board);

            return $"Created Board {Environment.NewLine}{board.Print()}";
        }
    }
}