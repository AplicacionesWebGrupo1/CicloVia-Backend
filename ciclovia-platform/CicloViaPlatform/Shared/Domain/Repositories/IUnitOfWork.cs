namespace CicloViaPlatform.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}