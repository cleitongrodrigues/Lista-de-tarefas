using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : 
    Notifiable, 
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
{
    private readonly ITodoRepository _repository;
    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }
    public ICommandResult Handle(CreateTodoCommand command)
    {
        // FAIL FAST VALIDATION É UMA BOA PRÁTICA DE PROGRAMAÇÃO, POIS SE O COMANDO FOR INVÁLIDO, NÃO PRECISA EXECUTAR NADA EX: NÃO PRECISA SALVAR NO BANCO DE DADOS, NEM CHAMAR OUTROS MÉTODOS, ETC...
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, algo deu errado!", command.Notifications);

        var todo = new TodoItem(command.Title, command.Date, command.User);

        _repository.Create(todo);

        return new GenericCommandResult(true, "Tarefa salva com sucesso!", todo);
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, algo deu errado!", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);
        todo.UpdateTitle(command.Title);
        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa atualizada com sucesso!", todo);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, algo deu errado!", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        todo.MarkAsDone();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa marcada como concluída com sucesso!", todo);
    }

    public ICommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, algo deu errado!", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        todo.MarkAsUndone();
        
        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa marcada como não concluída com sucesso!", todo);
    }
}