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
            var members = Commons.currentTeam.Members;

            if (members.Count == 0)
            {
                throw new ArgumentException("No members in this team!" + Environment.NewLine +
                          $"To add a new member in the team, use the following command:" + Environment.NewLine +
                          $"createmember <membername>");
            }
            else
            {
                foreach (var member in members)
                {
                    builder.AppendLine(member.ToString());
                }
            }
           

            return builder.ToString().TrimEnd();
        }
    }
}
