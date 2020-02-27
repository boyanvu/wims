using System.Collections.Generic;
using Wims.Core.Commands.Abstracts;

namespace Wims.Core.Commands
{
    public class ViewTeamHistoryCommand : Command
    {
        public ViewTeamHistoryCommand(IList<string> commandLine) :
            base(commandLine)
        {
           
        }


        public override string Execute()
        {
            return Commons.GetTeamHistory(Commons.currentTeam).TrimEnd();
        }
    }
}
