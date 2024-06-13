using RepasoPlatdorm.API.Shared.Domain.Repositories;
using RepasoPlatdorm.API.Todo.Domain.Model.Entities;

namespace RepasoPlatdorm.API.Todo.Domain.Repositories;

public interface IPlanRepository : IBaseRepository<Plan>
{
    Task<IEnumerable<Plan>> GetPlansWithMaxUsersGreaterThan(int maxUsers);
    void Delete(Plan plan);
}