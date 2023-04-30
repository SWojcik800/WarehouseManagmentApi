using Microsoft.AspNetCore.Mvc;
using WarehouseManagment.Application.Shipment;
using WarehouseManagment.Application.Shipment.Dtos;

namespace WarehouseManagment.Api.Shipment
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dtos = await _shipmentService.GetCurrentShipments();
            return Ok(dtos);
        }

        [HttpPost("RegisterIncomingShipment")]
        public async Task RegisterIncomingShipment(CreateShipmentDto createShipmentDto)
            => await _shipmentService.RegisterIncomingShipment(createShipmentDto);

        [HttpPost("AcceptIncomingShipment")]
        public async Task AcceptIncomingShipment(long shipmentId)
            => await _shipmentService.AcceptIncomingShipment(shipmentId);

        [HttpPost("IssueShipment")]
        public async Task IssueShipment(long shipmentId, string shipmentIssuedTo)
            => await _shipmentService.IssueShipment(shipmentId, shipmentIssuedTo);
    }
}
