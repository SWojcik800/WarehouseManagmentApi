namespace WarehouseManagment.Common.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public int ErrorCode { get; private set; }
        public ValidationException(string message, int errorCode = 400)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
