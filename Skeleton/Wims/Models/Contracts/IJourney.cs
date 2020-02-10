using Wims.Models.Vehicles.Contracts;

namespace Wims.Models.Contracts
{
    public interface IJourney
    {
        string Destination { get; }

        int Distance { get; }

        string StartLocation { get;}

        IVehicle Vehicle { get; }

        decimal CalculateTravelCosts();
    }
}