namespace WarehouseManagment.Core.Shipment
{
    public interface IShipmentRepository
    {
        public Task<List<ShipmentDomain>> GetAll();
        public Task<List<AcceptedShipment>> GetAccepted();
        public Task<ShipmentDomain> GetById(long id);
        public Task Save(ShipmentDomain shipment);
        public Task Save(AcceptedShipment acceptedShipment);
        Task Save(IssuedShipment issuedShipment);
    }
}
