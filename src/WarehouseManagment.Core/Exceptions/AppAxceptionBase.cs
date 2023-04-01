namespace WarehouseManagment.Core.Exceptions
{
    /// <summary>
    /// Application wide used exception type
    /// </summary>
    public class AppAxceptionBase : Exception
    {
        public AppAxceptionBase(string? message) : base(message)
        {
        }
    }
}
