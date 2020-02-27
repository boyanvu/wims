using System;
using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands.Creating
{
    /// <summary>
    /// Add specific member to the list of members in the current team
    /// </summary>
    /// <param name="commandLine">Accepts one parameters - the member name</param>
    public class AddMemberToTeamCommand : Command
    {
        public AddMemberToTeamCommand(IList<string> commandLine, IMemberProvider memberProvider)
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

            var currentTeam = Commons.currentTeam;
            if (currentTeam == null)
            {
                throw new Exception($"You have to select/create team before member creation." + Environment.NewLine +
                          $"You can you use one of these commands:" + Environment.NewLine +
                          $"createteam <teamname>, selectteam <teamname>, listteams");
            }

            var memberName = this.CommandParameters[0];

            var findMember = this.MemberProvider.Find(memberName);

            findMember.History.Add($"{findMember.Name} {findMember.GetType().Name} was added to team {currentTeam.Name}!");
            currentTeam.Members.Add(findMember);

            return $"{findMember.Name} added to team {currentTeam.Name}!";
        }
    }
}
