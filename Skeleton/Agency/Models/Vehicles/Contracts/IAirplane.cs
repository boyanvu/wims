namespace Agency.Models.Vehicles.Contracts
{
    public interface IAirplane
    {
        int PassangerCapacity { get; }

        decimal PricePerKilometer { get; }

        bool HasFreeFood { get; }
    }
}