using System;
using System.Collections.Generic;
using System.Text;

namespace Agency.Models.Contracts
{
    interface ITeam
    {
        string Name { get; }
        IList<IMember> Members { get; }
        IList<IBoard> Boards { get; }

    }
}
