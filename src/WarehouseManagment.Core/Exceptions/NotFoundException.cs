namespace WarehouseManagment.Core.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string entityName, object key) 
            : base($"{entityName} entity with id ${key} was not found")
        {
        }
    }
}
