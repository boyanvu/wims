using System.Collections.Generic;
using Wims.Models.Contracts;

namespace Wims.Core.Contracts
{
    public interface ITeamProvider
    {
        IReadOnlyList<ITeam> Teams { get; }

        void Add(ITeam team);

        ITeam Find(string name);
    }
}
