using System;
using System.Collections.Generic;
using System.Text;
using Wims.Models.Contracts;

namespace Wims.Core.Contracts
{
    interface IBoardProvider
    {
        IReadOnlyList<IBoard> Boards { get; }

        void Add(IBoard board);
    }
}
