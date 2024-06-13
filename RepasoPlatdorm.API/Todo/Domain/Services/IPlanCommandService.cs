using RepasoPlatdorm.API.Todo.Domain.Model.Commands;
using RepasoPlatdorm.API.Todo.Domain.Model.Entities;

namespace RepasoPlatdorm.API.Todo.Domain.Services;

public interface IPlanCommandService
{
    Task<Plan?> Handle(CreatePlanCommand command);
    Task<Plan?> Handle(UpdateCommand command);
    Task Handle(DeletePlanCommand command);
}