using System;
using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class SelectTeamCommand : Command
    {

        /// <summary>
        /// Selects a team with which we are going to work with.
        /// </summary>
        /// <param name="commandLine">One parameter - the name of the team</param>
        /// <param name="teamProvider">The list of all teams where we are going to search for this team.</param>
        public SelectTeamCommand(IList<string> commandLine, ITeamProvider teamProvider)
            : base(commandLine)
        {
            this.TeamProvider = teamProvider;
        }

        ITeamProvider TeamProvider { get; }
        public override string Execute()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var teamToSelect = this.CommandParameters[0];

            if (this.TeamProvider.Teams.Count == 0)
            {
                return $"There's no any team to select!{Environment.NewLine} " +
                    $"You can create it with command: createteam {teamToSelect}.";
            }

            var findTeam = this.TeamProvider.Find(teamToSelect);

            Commons.currentTeam = findTeam ?? throw new Exception 
                ($"{teamToSelect} does not exists.{Environment.NewLine} " +
                $"You can create it with command: createteam {teamToSelect}.");

            Commons.currentBoard = null;

            return $"Team {teamToSelect} selected";          
        }
    }
}
