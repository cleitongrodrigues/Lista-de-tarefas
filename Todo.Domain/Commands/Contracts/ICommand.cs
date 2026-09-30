using Todo.Domain.Validations;

namespace Todo.Domain.Commands.Contracts
{
    public interface ICommand : IValidatable
    {
    }
}