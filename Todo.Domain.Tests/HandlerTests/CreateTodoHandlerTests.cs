using Todo.Domain.Handlers;
using Todo.Domain.Commands;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class CreateTodoHandlerTests
{
    [TestMethod]
    public void Dado_um_comando_invalido_deve_interromper_a_execucao()
    {
        var command = new CreateTodoCommand("", DateTime.Now, "user");
        var handler = new TodoHandler(new FakeTodoRepository());
        var result = (GenericCommandResult)handler.Handle(command);
        Assert.AreEqual(false, result.Success);
    }

    
    [TestMethod]
    public void Dado_um_comando_valido_deve_criar_a_tarefa()
    {
        var command = new CreateTodoCommand("Tarefa válida", DateTime.Now, "usuario123");
        var handler = new TodoHandler(new FakeTodoRepository());
        var result = (GenericCommandResult)handler.Handle(command);
        Assert.AreEqual(true, result.Success);
    }
}
