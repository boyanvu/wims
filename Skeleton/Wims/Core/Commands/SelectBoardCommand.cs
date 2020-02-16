
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class SelectBoardCommand : Command
    {
        public SelectBoardCommand(IList<string> commandLine, IBoardProvider boardProvider)
            : base(commandLine)
        {
            this.BoardProvider = boardProvider;
        }

        IBoardProvider BoardProvider { get; }
        public override string Execute()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var boardToSelect = this.CommandParameters[0];

            if (this.BoardProvider.Boards.Count == 0)
            {
                return $"There's no any team to select!{Environment.NewLine} You can create it with command: createteam {boardToSelect}.";
            }

            foreach (var board in this.BoardProvider.Boards) //TODO Linq
            {
                if (board.Name == boardToSelect)
                {
                    CurrentVariables.currentBoard = board;
                    return $"Board {boardToSelect} selected";
                }
            }

            return $"{boardToSelect} does not exists.{Environment.NewLine} You can create it with command: createboard {boardToSelect}.";
        }
    }
}

