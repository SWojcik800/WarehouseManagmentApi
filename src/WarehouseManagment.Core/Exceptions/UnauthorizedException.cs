namespace WarehouseManagment.Core.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string? message) : base(message)
        {
        }
    }
}
