using Newtonsoft.Json;

namespace WarehouseManagment.Application.Todos
{
    internal class TodoService : ITodoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TodoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<TodoDto>> GetAll()
        {
            using(var httpClient = _httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");
                var json = await response.Content.ReadAsStringAsync();
                var todos = JsonConvert.DeserializeObject<List<TodoDto>>(json);
                return todos;
            }
        }
    }
}
