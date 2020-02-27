using System.Collections.Generic;
using Wims.Models.Contracts;

namespace Wims.Core.Contracts
{
    public interface IBoardProvider
    {
        IReadOnlyList<IBoard> Boards { get; }

        void Add(IBoard board);

        public IBoard Find(string name);
    }
}
