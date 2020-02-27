using System.Collections.Generic;
using System.Linq;
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

        public ITeam Find(string name)
        {
            var team = teams.FirstOrDefault(m => m.Name == name);
            return team;
        }
    }
}
