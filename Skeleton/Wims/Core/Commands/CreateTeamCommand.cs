using System;
using System.Collections.Generic;
using System.Text;
using Wims.Core.Commands.Abstracts;
using Wims.Core.Contracts;

namespace Wims.Core.Abstracts
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IList<string> commandLine, ITeamProvider teamProvider)
            : base(commandLine)
        {
            this.TeamProvider = teamProvider;
        }
        public ITeamProvider TeamProvider { get; }
        public override string Execute()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid!");
            }

            var team = this.Factory.CreateTeam(
                this.CommandParameters[0]
            );

            this.TeamProvider.Add(team);

            return $"Created Team{Environment.NewLine}{team}";
        }
    }
}
