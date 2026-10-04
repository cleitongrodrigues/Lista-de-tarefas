using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;

[TestClass]
public class TodoQueryTests
{
    private List<TodoItem> _items;

    public TodoQueryTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "usuario1"));
        _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "usuario2"));
        _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "cleiton"));
        _items.Add(new TodoItem("Tarefa 4", DateTime.Now, "douglas"));
        _items.Add(new TodoItem("Tarefa 5", DateTime.Now, "cleiton"));
    }
    
    [TestMethod]
    public void Deve_retornar_apenas_tarefas_do_usuario_especifico()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("cleiton"));        
        Assert.AreEqual(2, result.Count());        
    }
}

