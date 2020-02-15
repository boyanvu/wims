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

            foreach (var member in members)
            {
                builder.AppendLine(member.Print());
            }

            return builder.ToString().TrimEnd();
        }
    }
}