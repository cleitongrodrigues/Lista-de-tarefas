using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

public class UpdateTodoCommand : Notifiable, ICommand
{
    public UpdateTodoCommand(){}
    public UpdateTodoCommand(Guid id, string title, string user)
    {
        Id = id;
        Title = title;
        User = user;
    }
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Título deve ter no mínimo 3 caracteres")
                .HasMinLen(User, 6, "User", "Usuário deve ter no mínimo 6 caracteres")
        );
    }
}