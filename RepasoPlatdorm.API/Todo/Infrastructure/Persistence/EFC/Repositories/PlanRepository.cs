using Microsoft.EntityFrameworkCore;
using RepasoPlatdorm.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using RepasoPlatdorm.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using RepasoPlatdorm.API.Todo.Domain.Model.Entities;
using RepasoPlatdorm.API.Todo.Domain.Repositories;

namespace RepasoPlatdorm.API.Todo.Infrastructure.Persistence.EFC.Repositories;

public class PlanRepository : BaseRepository<Plan>, IPlanRepository
{
    private readonly AppDbContext _context;
    
    public void Delete(Plan plan)
    {
        _context.Set<Plan>().Remove(plan);
    }
    
    public PlanRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Plan>> GetPlansWithMaxUsersGreaterThan(int minMaxUsers)
    {
        return await _context.Set<Plan>()
            .Where(plan => plan.MaxUsers > minMaxUsers)
            .ToListAsync();
    }
}