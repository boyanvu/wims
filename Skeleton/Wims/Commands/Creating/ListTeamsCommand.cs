using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wims.Commands.Contracts;
using Wims.Core.Contracts;
using Wims.Core.Factories;

namespace Agency.Commands.Creating
{
    public class ListTeamsCommand : ICommand
    {
        private readonly IWimsFactory factory;
        private readonly IEngine engine;

        public ListTeamsCommand(IWimsFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var str = new StringBuilder();
            var teams = this.engine.Teams;

            if (teams.Count == 0)
            {
                return "There are no registered members.";
            }

            for (int i = 0; i < teams.Count; i++)
            {

                str.AppendLine(teams[i].Print());

            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, str.ToString().TrimEnd());
        }
    }
}