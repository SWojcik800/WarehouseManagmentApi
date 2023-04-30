using MapsterMapper;
using WarehouseManagment.Application.Shipment.Dtos;
using WarehouseManagment.Core.Shipment;

namespace WarehouseManagment.Application.Shipment
{
    internal class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public ShipmentService(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<List<ShipmentDto>> GetCurrentShipments()
        {
            var shipments = await _shipmentRepository.GetAll();
            var shipmentDtos = _mapper.Map<List<ShipmentDto>>(shipments);

            return shipmentDtos;
        }

        public async Task<List<ShipmentDto>> GetAcceptedShipments()
        {
            var shipments = await _shipmentRepository.GetAll();
            var shipmentDtos = _mapper.Map<List<ShipmentDto>>(shipments);

            return shipmentDtos;
        }

        public async Task RegisterIncomingShipment(CreateShipmentDto dto)
        {
            var mappedProducts = _mapper.Map<List<ShipmentProduct>>(dto.Products);
            var incomingShipment = ShipmentDomain.Create(mappedProducts, dto.ShipmentArrived);

            await _shipmentRepository.Save(incomingShipment);
        }

        public async Task AcceptIncomingShipment(long shipmentId)
        {
            var shipment = await _shipmentRepository.GetById(shipmentId);
            var acceptedShipment = shipment.Accept();

            await _shipmentRepository.Save(acceptedShipment);
        }
        public async Task IssueShipment(long shipmentId, string shipmentIssuedTo)
        {
            var shipment = await _shipmentRepository.GetById(shipmentId);
            var issuedShipment = shipment.Issue(shipmentIssuedTo);

            await _shipmentRepository.Save(issuedShipment);
        }
    }
}
