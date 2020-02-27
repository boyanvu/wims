using System;
using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Abstracts
{
    public class CreateTeamCommand : Command
    {
        /// <summary>
        /// Creates a new team by a given name
        /// </summary>
        /// <param name="commandLine"> Accepts one parameter which is the name of the team</param>
        /// <param name="teamProvider"> The list in which we will add the team where all created teams are kept</param>
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

            var findTeam = this.TeamProvider.Find(teamName);
            if (findTeam != null)
            {
                throw new ArgumentException($"Team {teamName} already exists."
                    + Environment.NewLine + "You could see all teams with command listteams.");
            }

            var team = this.Factory.CreateTeam(
                teamName
            );

            this.TeamProvider.Add(team);

            Commons.currentTeam = team;
            Commons.currentBoard = null;

            return $"Created Team{Environment.NewLine}{team.ToString()}" + Commons.CreateTeamText();
        }
    }
}
