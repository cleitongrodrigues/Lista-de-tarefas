using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
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
        return _context.Todos
            .AsNoTracking() // Evita o rastreamento de alterações para melhorar o desempenho
            .Where(TodoQueries.GetAll(user))
            .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllByPeriod(string user, DateTime date, bool done)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetByPeriod(user, date, done))
            .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllUndone(user))
            .OrderBy(x => x.Date);
    }

    public TodoItem? GetById(Guid id, string user)
    {
        return _context.Todos
            .FirstOrDefault(x => x.Id == id && x.User == user);
    }

    public void Update(TodoItem todo)
    {
        _context.Entry(todo).State = EntityState.Modified; // Marca o item como modificado
        _context.SaveChanges();       // Salva as alterações no banco de dados
    }
}