using System.Linq;
using WarehouseManagment.Core.Exceptions;

namespace WarehouseManagment.Core.Shipment
{
    public sealed class ShipmentDomain
    {
        private ShipmentDomain(IReadOnlyList<ShipmentProduct> products, DateTime shipmentArrived)
        {
            Products = products;
            ShipmentArrived = shipmentArrived;
        }
        public ShipmentDomain(long id, IReadOnlyList<ShipmentProduct> products, DateTime shipmentArrived)
        {
            Id = id;
            Products = products;
            ShipmentArrived = shipmentArrived;
        }

        public static ShipmentDomain Create(IReadOnlyList<ShipmentProduct> products, DateTime shipmentArrived)
        {
            var instance = new ShipmentDomain(products, shipmentArrived);           
            return instance;
        }

        public long Id { get; private set; }
        public IReadOnlyList<ShipmentProduct> Products { get; private set; }
        public DateTime ShipmentArrived { get; private set; }

        public AcceptedShipment Accept()
        {

            var areProductsEmpty = Products.Count() == 0;
            var isSumOfProductsEqualToZero = Products.Sum(x => x.Count) <= 0;

            var shipmentHasProducts = !areProductsEmpty && !isSumOfProductsEqualToZero;

            if (!shipmentHasProducts)
                throw new DomainException("Cannot accept shipment with no products");
            
            return new AcceptedShipment(Id, Products, ShipmentArrived, DateTime.Now);
        }

        public IssuedShipment Issue(string issuedTo)
        {
            if (string.IsNullOrEmpty(issuedTo) || string.IsNullOrWhiteSpace(issuedTo))
                throw new DomainException("Destination of issued shipment has not been set");

            var issuedShipment = new IssuedShipment(Id, Products, DateTime.Now, issuedTo);
            return issuedShipment;
        }
    }
}
