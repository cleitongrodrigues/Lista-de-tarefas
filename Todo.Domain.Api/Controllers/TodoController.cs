using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers;

[ApiController]
[Route("v1/todos")]
[Authorize]
public class TodoController : ControllerBase
{
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(
        [FromServices] ITodoRepository repository
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAll(user);
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(
        [FromServices] ITodoRepository repository
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAllDone(user);
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone(
        [FromServices] ITodoRepository repository
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAllUndone(user);
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday(
        [FromServices] ITodoRepository repository
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAllByPeriod(
            user,
            DateTime.Now.Date,
            true
        );
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForToday(
        [FromServices] ITodoRepository repository
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAllByPeriod(
            user,
            DateTime.Now.Date,
            false
        );
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        command.User = user;
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(
        [FromBody] UpdateTodoCommand command,
        [FromServices] TodoHandler handler
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        command.User = user;
        return (GenericCommandResult)handler.Handle(command);
    }

    [HttpPut("{id:guid}/done")]
    public GenericCommandResult MarkAsDone(
        Guid id,
        [FromServices] TodoHandler handler
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        var command = new MarkTodoAsDoneCommand(id, user);
        return (GenericCommandResult)handler.Handle(command);
    }

    [HttpPut("{id:guid}/undone")]
    public GenericCommandResult MarkAsUndone(
        Guid id,
        [FromServices] TodoHandler handler
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        var command = new MarkTodoAsUndoneCommand(id, user);
        return (GenericCommandResult)handler.Handle(command);
    }
}