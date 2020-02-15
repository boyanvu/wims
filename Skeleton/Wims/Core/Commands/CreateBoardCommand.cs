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

            var board = this.Factory.CreateBoard(
                this.CommandParameters[0]
            );

            this.BoardProvider.Add(board);

            return $"Created Board {Environment.NewLine}{board.Print()}";
        }
    }
}