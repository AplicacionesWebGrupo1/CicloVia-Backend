using CicloViaPlatform.Routes.Domain.Model.Aggregate;
using CicloViaPlatform.Routes.Domain.Model.Commands;
namespace CicloViaPlatform.Routes.Domain.Services;


/// <summary>
/// Service interface to handle commands related to route distances.
/// </summary>
public interface IRouteDistanceCommandService
{
    /// <summary>
    /// Handle the command to create a route distance.
    /// </summary>
    /// <remarks>
    /// This method handles the creation of a route distance.
    /// It checks if the distance already exists for the given Routes API key, origin, and destination.
    /// If it doesn't, it creates a new entry and persists it to the database.
    /// </remarks>
    /// <param name="command">CreateRouteDistanceCommand</param>
    /// <returns>The created RouteDistance entity, or null if an error occurred.</returns>
    Task<RouteDistance?> Handle(CreateRouteDistanceCommand command);
}
