using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand // SÓ PODE SER USADO COM COMANDOS, POR ISSO O "WHERE T : ICommand"
    {
        ICommandResult Handle(T command);
    }
}