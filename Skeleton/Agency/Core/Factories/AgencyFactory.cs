using System;
using Agency.Core.Contracts;
using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Core.Factories
{
    public class AgencyFactory : IAgencyFactory
    {
        private static IAgencyFactory instanceHolder = new AgencyFactory();

        private AgencyFactory()
        {
        }

        public static IAgencyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }
        
        public IBus CreateBus(int passengerCapacity, decimal pricePerKilometer)
        {
            throw new NotImplementedException("You are invoking a AgencyFactory method that is not yet implemented!");
        }

        public IAirplane CreateAirplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood)
        {
            throw new NotImplementedException("You are invoking a AgencyFactory method that is not yet implemented!");
        }

        public ITrain CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts)
        {
            throw new NotImplementedException("You are invoking a AgencyFactory method that is not yet implemented!");
        }
        
        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            throw new NotImplementedException("You are invoking a AgencyFactory method that is not yet implemented!");
        }

        public ITicket CreateTicket(IJourney journey, decimal administrativeCosts)
        {
            throw new NotImplementedException("You are invoking a AgencyFactory method that is not yet implemented!");
        }
    }
}
