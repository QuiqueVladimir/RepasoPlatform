using RepasoPlatdorm.API.Todo.Domain.Model.ValueObjects;

namespace RepasoPlatdorm.API.Todo.Domain.Model.Commands;

public record UpdateCommand(int Id, PlanName Name, int MaxUsers, int IsDefault);