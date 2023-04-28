namespace WarehouseManagment.Core.Shipment
{
    public interface IShipmentRepository
    {
        public Task<List<Shipment>> GetAll();
        public Task<List<AcceptedShipment>> GetAccepted();
        public Task<List<Shipment>> GetById();
        public Task Save(Shipment shipment);
        public Task Save(AcceptedShipment acceptedShipment);
    }
}
