namespace CicloViaPlatform.Routes.Domain.Model.Queries;

/// <summary>
/// Query to get a route distance by its unique identifier.
/// </summary>
/// <param name="Id">The unique identifier of the route distance.</param>
public record GetRouteDistanceByIdQuery(int Id);
