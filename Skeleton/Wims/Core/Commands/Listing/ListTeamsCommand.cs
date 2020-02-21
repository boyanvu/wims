using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ListTeamsCommand : Command
    {
        public ListTeamsCommand(IList<string> commandLine, ITeamProvider teamProvider) :
            base(commandLine)
        {
            this.TeamProvider = teamProvider;
        }

        ITeamProvider TeamProvider { get; }
        public override string Execute()
        {
            var builder = new StringBuilder();
            var teams = this.TeamProvider.Teams;

            if(teams.Count == 0)
            {
                throw new ArgumentException("No teams registered!" + Environment.NewLine +
                          $"To register a new team use the following command:" + Environment.NewLine +
                          $"createteam <teamname>");
            }
            else
            {
                foreach (var team in teams)
                {
                    builder.AppendLine(team.ToString());
                }
            }
           
            return builder.ToString().TrimEnd();
        }
    }
}
