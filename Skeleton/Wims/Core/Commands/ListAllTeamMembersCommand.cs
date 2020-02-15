using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ListAllTeamMembersCommand : Command
    {
        public ListAllTeamMembersCommand(IList<string> commandLine, ITeamProvider teamProvider) :
            base(commandLine)
        {
            this.TeamProvider = teamProvider;
        }

        public ITeamProvider TeamProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();
            var members = CurrentVariables.currentTeam.Members;

            foreach (var member in members)
            {
                builder.AppendLine(member.Print());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
