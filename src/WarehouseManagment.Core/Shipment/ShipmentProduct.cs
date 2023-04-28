namespace WarehouseManagment.Core.Shipment
{
    public sealed class ShipmentProduct
    {
        public ShipmentProduct(long id, string name, string description, string manufactureraName, uint count)
        {
            Id = id;
            Name = name;
            Description = description;
            ManufactureraName = manufactureraName;
            Count = count;
        }
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ManufactureraName { get; private set; }
        public uint Count { get; private set; }
    }
}
