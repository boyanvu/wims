using System;
using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class CreateMemberCommand : Command
    {

        /// <summary>
        /// Creates a new member by a given name
        /// </summary>
        /// <param name="commandLine"> In the command line we accept one parameter which is the name of the member</param>
        /// <param name="memberProvider"> The list in which we will add the member where all created members are kept
        /// and adds him to the members to the current team selected.</param>
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

            var memberName = this.CommandParameters[0];

            var findMember = this.MemberProvider.Find(memberName);

            if (findMember != null)
            {
                throw new ArgumentException("Member already exists!");
            }

            var member = this.Factory.CreateMember(
            this.CommandParameters[0]);


            member.History.Add($"{member.Name} {member.GetType().Name} was created!");
            this.MemberProvider.Add(member);        

            return $"{member.Name} {member.GetType().Name} created!";
        }
    }
}
