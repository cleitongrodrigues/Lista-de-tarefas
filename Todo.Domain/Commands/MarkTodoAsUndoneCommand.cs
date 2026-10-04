using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsUndoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsUndoneCommand(){}

        public MarkTodoAsUndoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }
        public Guid Id { get; set; }
        public string User { get; set; } = string.Empty;
         public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(User, 6, "User", "Usuário deve ter no mínimo 6 caracteres")
            );
        }
    }
}