namespace WarehouseManagment.Application.Todos
{
    public interface ITodoService
    {
        Task<List<TodoDto>> GetAll();
    }
}