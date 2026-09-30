using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class CreateTodoCommand : Notifiable, ICommand
{
    public CreateTodoCommand(){}
    public CreateTodoCommand(string title, DateTime date, string user)
    {
        Title = title;
        Date  = date;
        User  = user;
    }
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
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