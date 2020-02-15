using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Abstracts
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IList<string> commandLine, ITeamProvider teamProvider)
            : base(commandLine)
        {
            this.TeamProvider = teamProvider;
        }

        public ITeamProvider TeamProvider { get; }
        public override string Execute()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var teamName = this.CommandParameters[0];
            foreach (var teamToCheck in this.TeamProvider.Teams)
            {
                if (teamToCheck.Name == teamName)
                {
                    throw new ArgumentException($"Team {teamName} already exists." + Environment.NewLine + "You could see all teams with command listteams.");
                }
            }

            var team = this.Factory.CreateTeam(
                teamName
            );

            this.TeamProvider.Add(team);

            CurrentVariables.currentTeam = team;

            return $"Created Team{Environment.NewLine}{team.Print()}";
        }
    }
}
