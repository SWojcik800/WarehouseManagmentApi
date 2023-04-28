using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagment.Application.Shipment;

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
        public async Task<IActionResult> GetCurrentShipments()
        {
            var dtos = await _shipmentService.GetCurrentShipments();
            return Ok(dtos);
        }
    }
}
