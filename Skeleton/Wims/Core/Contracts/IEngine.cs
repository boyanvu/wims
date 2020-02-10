using System.Collections.Generic;
using Wims.Models.Contracts;
using Wims.Models.Vehicles.Contracts;

namespace Wims.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }

        // TODO Modify
        IList<IVehicle> Vehicles { get; }

        IList<IJourney> Journeys { get; }

        IList<ITicket> Tickets { get; }
    }
}
