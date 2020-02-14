using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Contracts;
using Wims.Models.Contracts;

namespace Wims.Core.Providers
{
    public class BoardProvider : IBoardProvider
    {
        private readonly List<IBoard> boards = new List<IBoard>();

        public IReadOnlyList<IBoard> Boards
        {
            get
            {
                return this.boards;
            }
        }

        public void Add(IBoard board)
        {
            boards.Add(board);
        }
    }
}
