namespace CicloViaPlatform.Routes.Domain.Model.Commands;

/// <summary>
/// Command to create a route distance between two locations.
/// </summary>
/// <param name="RoutesApiKey">Unique key identifying the user or client registering the route.</param>
/// <param name="Origin">Starting point of the route.</param>
/// <param name="Destination">Ending point of the route.</param>
/// <param name="DistanceKm">Distance in kilometers between origin and destination.</param>
public record CreateRouteDistanceCommand(string RoutesApiKey, string Origin, string Destination, double DistanceKm);

