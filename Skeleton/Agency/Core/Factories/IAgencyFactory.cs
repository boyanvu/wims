using Wims.Models.Contracts;
using Wims.Models.Vehicles.Contracts;

namespace Wims.Core.Contracts
{
    public interface IAgencyFactory
    {
        IBus CreateBus(int passengerCapacity, decimal pricePerKilometer);
        
        ITrain CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts);

        IJourney CreateJourney(string startingLocation, string destination, int distance, IVehicle vehicle);

        ITicket CreateTicket(IJourney journey, decimal administrativeCosts);
    }
}
