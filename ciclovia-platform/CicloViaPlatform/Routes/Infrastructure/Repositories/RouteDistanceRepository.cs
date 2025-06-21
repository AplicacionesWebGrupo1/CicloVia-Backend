using CicloViaPlatform.Routes.Domain.Model.Aggregate;
using CicloViaPlatform.Routes.Domain.Repositories;
using CicloViaPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using CicloViaPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CicloViaPlatform.Routes.Infrastructure.Repositories;


public class RouteDistanceRepository(AppDbContext context)
    : BaseRepository<RouteDistance>(context), IRouteDistanceRepository
{
    public async Task<IEnumerable<RouteDistance>> FindByRoutesApiKeyAsync(string routesApiKey)
    {
        return await Context.Set<RouteDistance>()
            .Where(r => r.RoutesApiKey == routesApiKey)
            .ToListAsync();
    }

    public async Task<RouteDistance> FindByRoutesApiKeyAndPointsAsync(string routesApiKey, string origin, string destination)
    {
        return await Context.Set<RouteDistance>()
            .FirstOrDefaultAsync(r =>
                r.RoutesApiKey == routesApiKey &&
                r.Origin == origin &&
                r.Destination == destination);
    }
}