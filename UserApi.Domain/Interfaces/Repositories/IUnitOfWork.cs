namespace UserApi.Domain.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUsersRepository UsersRepository { get;}
    void SaveChanges();
 }