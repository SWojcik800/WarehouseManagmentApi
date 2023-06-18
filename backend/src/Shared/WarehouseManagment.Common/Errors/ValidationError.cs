using WarehouseManagment.Common.Exceptions;

namespace WarehouseManagment.Common.Errors
{
    public record ValidationError(string errorMessage, int statusCode = 400) {}
}
