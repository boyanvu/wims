using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class CreateMemberCommand : Command
    {
        public CreateMemberCommand(IList<string> commandLine, IMemberProvider memberProvider)
            : base(commandLine)
        {
            this.MemberProvider = memberProvider;
        }

        public IMemberProvider MemberProvider { get; }

        public override string Execute()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var allMembers = MemberProvider.Members;
            var currentTeam = CurrentVariables.currentTeam;
            if (currentTeam == null)
            {
                throw new Exception($"You have to select/create team before member creation." + Environment.NewLine +
                          $"You can you use one of these commands:" + Environment.NewLine +
                          $"createteam <teamname>, selectteam <teamname>, listteams");
            }

            var memberName = this.CommandParameters[0];


            foreach (var cMember in allMembers)
            {
                if (cMember.Name == memberName)
                {
                    throw new ArgumentException("Member already exists!");
                }
            }

            var member = this.Factory.CreateMember(
            this.CommandParameters[0]);

            this.MemberProvider.Add(member);
            currentTeam.Members.Add(member);

            return $"{member.Name} added to {currentTeam.Name}!";
        }
    }
}
