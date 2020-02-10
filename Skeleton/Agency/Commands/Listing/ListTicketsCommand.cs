using System;
using System.Collections.Generic;
using System.Linq;
using Wims.Commands.Contracts;
using Wims.Core.Contracts;

namespace Wims.Commands.Creating
{
    public class ListTicketsCommand : ICommand
    {
        private readonly IAgencyFactory factory;
        private readonly IEngine engine;

        public ListTicketsCommand(IAgencyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var tickets = this.engine.Tickets;

            if (tickets.Count == 0)
            {
                return "There are no registered tickets.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, tickets);
        }
    }
}
