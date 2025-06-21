using CicloViaPlatform.Routes.Domain.Model.Commands;

namespace CicloViaPlatform.Routes.Domain.Model.Aggregate;
/// <summary>
/// this class represents a distanceRoute  aggregate.
/// </summary>

public class RouteDistance
{
    public int Id { get; private set; }
    public string RoutesApiKey { get; private set; }
    public string Origin { get; private set; }
    public string Destination { get; private set; }
    public double DistanceKm { get; private set; }

    protected RouteDistance()
    {
        RoutesApiKey=string.Empty;
        Origin=string.Empty;
        Destination=string.Empty;
        DistanceKm=0;
    }
    
    public RouteDistance(CreateRouteDistanceCommand command)
    {
        RoutesApiKey = command.RoutesApiKey;
        Origin = command.Origin;
        Destination = command.Destination;
        DistanceKm = command.DistanceKm;
    }

    
}
