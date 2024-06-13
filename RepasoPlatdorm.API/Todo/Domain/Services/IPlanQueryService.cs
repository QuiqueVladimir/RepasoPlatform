using RepasoPlatdorm.API.Todo.Domain.Model.Entities;
using RepasoPlatdorm.API.Todo.Domain.Model.Queries;

namespace RepasoPlatdorm.API.Todo.Domain.Services;

public interface IPlanQueryService
{
    Task<Plan?> Handle(GetPlanByIdQuery query);
    Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query);
    Task<IEnumerable<Plan>> Handle(GetPlansWithMaxUsersGreaterThanQuery query);

}