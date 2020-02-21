using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ListAllMembersCommand : Command
    {

        public ListAllMembersCommand(IList<string> commandLine, IMemberProvider memberProvider) :
            base(commandLine)
        {
            this.MemberProvider = memberProvider;
        }

        IMemberProvider MemberProvider { get; }
        public override string Execute()
        {
            var builder = new StringBuilder();
            var members = this.MemberProvider.Members;

            if (members.Count == 0)
            {
                throw new ArgumentException("No members added!" + Environment.NewLine +
                          $"To add a new member, first create a team! Use the following commands:" + Environment.NewLine +
                          $"createteam <teamname> -> createmember <membername>");
            }
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