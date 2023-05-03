namespace WarehouseManagment.Core.Products.Queries
{
    public sealed record GetPaginatedProductListQuery( string? Name, string? Description, string? ManufacturerName, int Offset = 0, int Limit = 10)
    {

    }
}
