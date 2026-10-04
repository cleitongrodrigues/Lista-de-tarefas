using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todo)
    {
        
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        return Array.Empty<TodoItem>();
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return Array.Empty<TodoItem>();
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        return Array.Empty<TodoItem>();
    }

    public IEnumerable<TodoItem> GetAllByPeriod(string user, DateTime date, bool done)
    {
        return Array.Empty<TodoItem>();
    }

    public TodoItem? GetById(Guid id, string user)
    {
        return new TodoItem("Titulo", DateTime.Now, user);
    }

    public void Update(TodoItem todo)
    {
        
    }
}