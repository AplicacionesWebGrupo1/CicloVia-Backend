namespace CicloViaPlatform.Routes.Domain.Model.Queries;

/// <summary>
/// Query to get a specific route distance by RoutesApiKey, origin, and destination.
/// </summary>
/// <param name="RoutesApiKey">API key identifying the user or client.</param>
/// <param name="Origin">Starting location of the route.</param>
/// <param name="Destination">Ending location of the route.</param>
public record GetRouteDistanceByRoutesApiKeyAndPointsQuery(string RoutesApiKey, string Origin, string Destination);
