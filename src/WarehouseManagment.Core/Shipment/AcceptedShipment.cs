namespace WarehouseManagment.Core.Shipment
{
    public sealed class AcceptedShipment
    {
        internal AcceptedShipment(long id, IReadOnlyList<ShipmentProduct> products, DateTime shipmentArrived, DateTime acceptedDate)
        {
            Id = id;
            Products = products;
            ShipmentArrived = shipmentArrived;
            AcceptedDate = acceptedDate;
        }

        public long Id { get; private set; }
        public IReadOnlyList<ShipmentProduct> Products { get; private set; }
        public DateTime ShipmentArrived { get; private set; }
        public DateTime AcceptedDate { get; private set; }
    }
}
