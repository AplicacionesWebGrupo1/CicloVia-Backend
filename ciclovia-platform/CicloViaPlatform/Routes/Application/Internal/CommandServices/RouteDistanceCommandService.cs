using CicloViaPlatform.Routes.Domain.Model.Aggregate;
using CicloViaPlatform.Routes.Domain.Model.Commands;
using CicloViaPlatform.Routes.Domain.Repositories;
using CicloViaPlatform.Routes.Domain.Services;
using CicloViaPlatform.Shared.Domain.Repositories;


namespace CicloViaPlatform.Routes.Application.Internal.CommandServices;


public class RouteDistanceCommandService(IRouteDistanceRepository routeDistanceRepository, IUnitOfWork unitOfWork)
    : IRouteDistanceCommandService
{
    public async Task<RouteDistance?> Handle(CreateRouteDistanceCommand command)
    {
        var existingDistance = await routeDistanceRepository
            .FindByRoutesApiKeyAndPointsAsync(command.RoutesApiKey, command.Origin, command.Destination);

        if (existingDistance is not null)
            throw new Exception("Route distance already exists");

        var routeDistance = new RouteDistance(command);

        try
        {
            await routeDistanceRepository.AddAsync(routeDistance);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return routeDistance;
    }
}
