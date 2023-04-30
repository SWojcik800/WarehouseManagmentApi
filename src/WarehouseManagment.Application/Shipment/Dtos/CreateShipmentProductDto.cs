namespace WarehouseManagment.Application.Shipment.Dtos
{
    public class CreateShipmentProductDto
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufactureraName { get; set; }
        public uint Count { get; set; }     
    }
}
