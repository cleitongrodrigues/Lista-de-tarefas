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
        _items.Add(new TodoItem("Tarefa 1", "usuario1", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "usuario2", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "cleiton", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "douglas", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "cleiton", DateTime.Now));
    }
    
    [TestMethod]
    public void Deve_retornar_apenas_tarefas_do_usuario_especifico()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("cleiton"));        
        Assert.AreEqual(2, result.Count());        
    }
}

