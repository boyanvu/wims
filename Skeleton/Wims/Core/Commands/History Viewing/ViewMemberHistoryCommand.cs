
using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ViewMemberHistoryCommand : Command
    {
        public ViewMemberHistoryCommand(IList<string> commandLine, IMemberProvider memberProvider) :
            base(commandLine)
        {
            this.MemberProvider = memberProvider;
        }

        public IMemberProvider MemberProvider { get; }


        public override string Execute()
        {

            var builder = new StringBuilder();

            var memberName = this.CommandParameters[0];

            var findMember = this.MemberProvider.Find(memberName);

            if (findMember == null)
            {
                throw new Exception("Member with this name does not exist!");
            }

            builder.AppendLine(string.Join(Environment.NewLine, findMember.History));


            return builder.ToString().TrimEnd();
        }
    }
}
