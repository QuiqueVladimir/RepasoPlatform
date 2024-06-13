using RepasoPlatdorm.API.Todo.Domain.Model.Entities;
using RepasoPlatdorm.API.Todo.Domain.Model.Queries;
using RepasoPlatdorm.API.Todo.Domain.Repositories;
using RepasoPlatdorm.API.Todo.Domain.Services;

namespace RepasoPlatdorm.API.Todo.Application.Internal.QueryServices;

public class PlanQueryService(IPlanRepository planRepository) : IPlanQueryService
{
    public async Task<Plan?> Handle(GetPlanByIdQuery query)
    {
        return await planRepository.FindAsync(query.Id);
    }

    public async Task<IEnumerable<Plan>> Handle(GetAllPlansQuery query)
    {
        return await planRepository.ListAsync();
    }

    public async Task<IEnumerable<Plan>> Handle(GetPlansWithMaxUsersGreaterThanQuery query)
    {
        return await planRepository.GetPlansWithMaxUsersGreaterThan(query.MaxUsers);
    }
}