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
            var member = this.Factory.CreateMember(
                this.CommandParameters[0]);

            if (allMembers.Count == 0)
            {
                this.MemberProvider.Add(member);
                currentTeam.Members.Add(member);
            }
            else
            {
                foreach (var cMember in allMembers)
                {
                    if (cMember.Name == member.Name)
                    {
                        throw new ArgumentException("Member already exists!");
                    }
                    else
                    {
                        this.MemberProvider.Add(member);
                        currentTeam.Members.Add(member);
                    }
                }
            }


            return $"{member.Name} added to {currentTeam.Name}!";
        }
    }
}
