using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    public void Create(TodoItem todo)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllByPeriod(string user, DateTime date)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        throw new NotImplementedException();
    }

    public TodoItem GetById(Guid id, string user)
    {
        throw new NotImplementedException();
    }

    public void Update(TodoItem todo)
    {
        throw new NotImplementedException();
    }
}