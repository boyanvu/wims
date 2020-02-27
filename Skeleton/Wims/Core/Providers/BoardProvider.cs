using System.Collections.Generic;
using System.Linq;
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

        public IBoard Find(string name)
        {
            var board = boards.FirstOrDefault(b => b.Name == name);
            return board;
        }
    }
}
