using CicloViaPlatform.Shared.Domain.Repositories;
using CicloViaPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace CicloViaPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context): IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}