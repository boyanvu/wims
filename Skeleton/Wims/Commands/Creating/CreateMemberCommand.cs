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
    public class CreateMemberCommand : ICommand
    {
        private readonly IWimsFactory factory;
        private readonly IEngine engine;

        public CreateMemberCommand(IWimsFactory factory, IEngine engine)
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
                throw new ArgumentException("Failed to parse CreateMember command parameters.");
            }

            var member = this.factory.CreateMember(name);
            this.engine.Members.Add(member);

            return $"Member with ID {engine.Members.Count - 1} was created.";
        }


    }
}
