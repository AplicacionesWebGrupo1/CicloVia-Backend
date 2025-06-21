using CicloViaPlatform.Routes.Domain.Model.Aggregate;
using CicloViaPlatform.Shared.Domain.Repositories;

namespace CicloViaPlatform.Routes.Domain.Repositories;

public interface IRouteDistanceRepository : IBaseRepository<RouteDistance>
{
    Task<IEnumerable<RouteDistance>> FindByRoutesApiKeyAsync(string routesApiKey);
    Task<RouteDistance> FindByRoutesApiKeyAndPointsAsync(string routesApiKey, string origin, string destination);

}