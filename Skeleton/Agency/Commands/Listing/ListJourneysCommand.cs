using System;
using System.Collections.Generic;
using Wims.Commands.Contracts;
using Wims.Core.Contracts;

namespace Wims.Commands.Creating
{
    public class ListJourneysCommand : ICommand
    {
        private readonly IAgencyFactory factory;
        private readonly IEngine engine;

        public ListJourneysCommand(IAgencyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var journeys = this.engine.Journeys;

            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}
