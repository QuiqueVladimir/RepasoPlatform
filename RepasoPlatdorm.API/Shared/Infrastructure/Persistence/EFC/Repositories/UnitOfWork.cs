using RepasoPlatdorm.API.Shared.Domain.Repositories;
using RepasoPlatdorm.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace RepasoPlatdorm.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}