using CicloViaPlatform.Routes.Domain.Model.Aggregate;
using CicloViaPlatform.Routes.Domain.Model.Queries;
using CicloViaPlatform.Routes.Domain.Model.Commands;

namespace CicloViaPlatform.Routes.Domain.Services;


/// <summary>
/// Service interface for handling route distance queries.
/// </summary>
public interface IRouteDistanceQueryService
{
    /// <summary>
    /// Retrieves all route distances for a given Routes API key.
    /// </summary>
    Task<IEnumerable<RouteDistance>> Handle(GetAllRouteDistanceByRoutesApiKeyQuery query);

    /// <summary>
    /// Retrieves a route distance by its unique identifier.
    /// </summary>
    Task<RouteDistance?> Handle(GetRouteDistanceByIdQuery query);

    /// <summary>
    /// Retrieves a specific route distance by Routes API key, origin, and destination.
    /// </summary>
    Task<RouteDistance?> Handle(GetRouteDistanceByRoutesApiKeyAndPointsQuery query);
}
