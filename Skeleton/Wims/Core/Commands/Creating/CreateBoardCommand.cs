using System;
using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    /// <summary>
    /// Creates new board and add it to the current team
    /// </summary>
    /// <param name="commandLine">Accepts one parameter - the board name</param>
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

            var currTeam = Commons.CurrTeamValid();

            var boardName = this.CommandParameters[0];

            var findBoard = this.BoardProvider.Find(boardName);

            if (findBoard != null)
            {
                throw new ArgumentException($"Board with name {boardName} already exists in team {currTeam.Name}" + Environment.NewLine +
                              $"You can see all available boards with command listboards.");
            }

            var board = this.Factory.CreateBoard(
                boardName
            );

            this.BoardProvider.Add(board);
            currTeam.Boards.Add(board);

            Commons.currentBoard = board;
            Commons.currentBoard.History.Add($"{boardName} board created!");

            return $"Created Board {Environment.NewLine}{board.ToString()}" + Commons.CreateBoardText();
        }
    }
}