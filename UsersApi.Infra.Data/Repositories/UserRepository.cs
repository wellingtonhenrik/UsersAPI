using UserApi.Domain.Interfaces.Repositories;
using UserApi.Domain.Models;
using UsersApi.Infra.Data.Contexts;

namespace UsersApi.Infra.Data.Repositories;

public class UserRepository : BaseRepository<User, Guid>, IUsersRepository
{
    private readonly DataContext? _dataContext;

    public UserRepository(DataContext? dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
}