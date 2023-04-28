using WarehouseManagment.Application.Shipment.Dtos;

namespace WarehouseManagment.Application.Shipment
{
    public interface IShipmentService
    {
        Task<List<ShipmentDto>> GetCurrentShipments();
    }
}