namespace WarehouseManagment.Application.Todos
{
    public sealed class TodoDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
