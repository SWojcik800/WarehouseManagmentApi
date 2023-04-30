namespace WarehouseManagment.Infrastructure.Entities
{
    internal sealed class Shipment
    {
        public long Id { get; set; }
        public List<Product> Products { get; set; }
        public DateTime ShipmentArrived { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public DateTime? ShipmentIssued { get; set; }
        public string? ShipmentIssuedTo { get; set; }

    }
}
