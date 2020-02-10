namespace Agency.Models.Vehicles.Contracts
{
    public interface ITrain
    {
        int PassangerCapacity { get; }

        decimal PricePerKilometer { get; }

        // Please, please, please implement me
        VehicleType Type { get; set; }

        int Carts { get; }
    }
}