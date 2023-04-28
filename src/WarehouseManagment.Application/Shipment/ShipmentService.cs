using WarehouseManagment.Application.Shipment.Dtos;
using WarehouseManagment.Core.Shipment;

namespace WarehouseManagment.Application.Shipment
{
    internal class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<List<ShipmentDto>> GetCurrentShipments()
        {
            var shipments = await _shipmentRepository.GetAll();
            var shipmentDtos = shipments.Select(x => new ShipmentDto()
            {
                Id = x.Id,
                ShipmentArrived = x.ShipmentArrived,
                Products = x.Products.Select(sp => new ShipmentProductDto()
                {
                    Id = sp.Id,
                    Name = sp.Name,
                    Description = sp.Description,
                    ManufactureraName = sp.ManufactureraName,
                    Count = sp.Count
                }).ToList(),
            });

            return shipmentDtos.ToList();
        }
    }
}
