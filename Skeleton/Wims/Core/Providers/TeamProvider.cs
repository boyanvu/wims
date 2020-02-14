using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Contracts;
using Wims.Models.Contracts;

namespace Wims.Core.Providers
{
    public class TeamProvider : ITeamProvider
    {
        private readonly List<ITeam> teams = new List<ITeam>();

        public IReadOnlyList<ITeam> Teams
        {
            get
            {
                return this.teams;
            }
        }

        public void Add(ITeam team)
        {
            teams.Add(team);
        }
    }
}
