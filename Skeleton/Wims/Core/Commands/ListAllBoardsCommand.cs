﻿using System;
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

            foreach (var board in boards)
            {
                builder.AppendLine(board.Print());
            }

            return builder.ToString().TrimEnd();
        }
    }
}