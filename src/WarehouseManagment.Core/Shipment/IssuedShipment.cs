namespace WarehouseManagment.Core.Shipment
{
    public sealed class IssuedShipment
    {
        internal IssuedShipment(long id, IReadOnlyList<ShipmentProduct> products, DateTime shipmentIssued, string shipmentIssuedTo)
        {
            Id = id;
            Products = products;
            ShipmentIssued = shipmentIssued;
            ShipmentIssuedTo = shipmentIssuedTo;
        }

        public long Id { get; private set; }
        public IReadOnlyList<ShipmentProduct> Products { get; private set; }
        public DateTime ShipmentIssued { get; private set; }
        public string ShipmentIssuedTo { get; private set; }
    }
}
