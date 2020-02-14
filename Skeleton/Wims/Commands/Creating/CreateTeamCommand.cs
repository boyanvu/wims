using System;
using System.Collections.Generic;
using Wims.Commands.Contracts;
using Wims.Core.Contracts;
using Wims.Core.Factories;
using Wims.Models;
using Wims.Models.Common;
using Wims.Models.Contracts;

namespace Wims.Commands.Creating
{
    public class CreateTeamCommand : ICommand
    {
        private readonly IWimsFactory factory;
        private readonly IEngine engine;

        public CreateTeamCommand(IWimsFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            string name;

            try
            {
                name = parameters[0];

            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTeam command parameters.");
            }

            var team = this.factory.CreateTeam(name);
            this.engine.Teams.Add(team);

            return $"Team with ID {engine.Teams.Count - 1} was created.";
        }
    }

}

