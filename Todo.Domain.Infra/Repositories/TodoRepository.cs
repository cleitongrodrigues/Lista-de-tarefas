using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly DataContext _context;

    public TodoRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(TodoItem todo)
    {
        _context.Todos.Add(todo); // Adiciona o item à coleção de tarefas
        _context.SaveChanges();   // Salva as alterações no banco de dados
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
        _context.Entry(todo).State = EntityState.Modified; // Marca o item como modificado
        _context.SaveChanges();       // Salva as alterações no banco de dados
    }
}