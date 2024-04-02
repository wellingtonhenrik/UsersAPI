using UserApi.Domain.Interfaces.Repositories;
using UsersApi.Infra.Data.Contexts;

namespace UsersApi.Infra.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext? _dataContext;

    public UnitOfWork(DataContext? dataContext)
    {
        _dataContext = dataContext;
    }
    public IUsersRepository UsersRepository => new UserRepository(_dataContext);

    public void Dispose()
    {
        _dataContext.Dispose();
    }

    public void SaveChanges()
    {
        _dataContext.SaveChanges();
    }
}