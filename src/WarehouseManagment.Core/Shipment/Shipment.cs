using WarehouseManagment.Core.Exceptions;

namespace WarehouseManagment.Core.Shipment
{
    public sealed class Shipment
    {
        public Shipment(long id, IReadOnlyList<ShipmentProduct> products, DateTime shipmentArrived)
        {
            Id = id;
            Products = products;
            ShipmentArrived = shipmentArrived;
        }

        public long Id { get; private set; }
        public IReadOnlyList<ShipmentProduct> Products { get; private set; }
        public DateTime ShipmentArrived { get; private set; }

        public AcceptedShipment Accept()
        {
            if (Products.Count() == 0)
                throw new DomainException("Cannot accept shipment with no products");
            
            return new AcceptedShipment(Id, Products, ShipmentArrived, DateTime.Now);
        }
    }
}
