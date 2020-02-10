namespace Agency.Models.Vehicles.Contracts
{
    public interface IBus
    {
        int PassangerCapacity { get; }

        decimal PricePerKilometer { get; }
    }
}