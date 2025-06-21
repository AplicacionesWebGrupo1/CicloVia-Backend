namespace CicloViaPlatform.Routes.Domain.Model.Queries;

/// <summary>
/// Query to get all route distances associated with a specific Routes API key.
/// </summary>
/// <param name="RoutesApiKey">Unique key identifying the user or client.</param>
public record GetAllRouteDistanceByRoutesApiKeyQuery( string RouteApiKey );

