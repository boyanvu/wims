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

            foreach (var team in teams)
            {
                builder.AppendLine(team.Print());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
