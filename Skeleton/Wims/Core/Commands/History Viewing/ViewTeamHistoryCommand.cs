using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Commands
{
    public class ViewTeamHistoryCommand : Command
    {
        public ViewTeamHistoryCommand(IList<string> commandLine, ITeamProvider teamProvider) :
            base(commandLine)
        {
            this.TeamProvider = teamProvider;
        }

        public ITeamProvider TeamProvider { get; }


        public override string Execute()
        {
            return Commons.GetTeamHistory(Commons.currentTeam).TrimEnd();
        }
    }
}
