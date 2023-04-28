namespace WarehouseManagment.Core.Exceptions
{
    /// <summary>
    /// Application wide used exception type
    /// </summary>
    public class ApplicationException : Exception
    {
        public ApplicationException(string? message) : base(message)
        {
        }
    }
}
