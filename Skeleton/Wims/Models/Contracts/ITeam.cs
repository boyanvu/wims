using System.Collections.Generic;

namespace Wims.Models.Contracts
{
    public interface ITeam
    {
        string Name { get; }
        IList<IMember> Members { get; }
        IList<IBoard> Boards { get; }

        

    }
}
