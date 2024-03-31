using UserApi.Domain.Models;

namespace UserApi.Domain.Interfaces.Repositories;

public interface IUsersRepository : IBaseRepository<User, Guid>
{
     
}