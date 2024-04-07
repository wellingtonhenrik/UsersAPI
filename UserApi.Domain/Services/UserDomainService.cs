using UserApi.Domain.Exceptions;
using UserApi.Domain.Interfaces.Repositories;
using UserApi.Domain.Interfaces.Services;
using UserApi.Domain.Models;

namespace UserApi.Domain.Services;

public class UserDomainService : IUserDomainService
{
    private readonly IUnitOfWork _unitOfWork;
    public UserDomainService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Dispose()
    {
        _unitOfWork?.Dispose();
    }

    public void Add(User user)
    {
        if (Get(user.Email) != null)
           throw new EmailJaExisteException(user.Email);

        _unitOfWork?.UsersRepository.Add(user);
        _unitOfWork?.SaveChanges();
    }

    public void Update(User user)
    {
        _unitOfWork?.UsersRepository.Update(user);
        _unitOfWork?.SaveChanges();
    }

    public void Delete(User user)
    {
        _unitOfWork?.UsersRepository.Delete(user);
        _unitOfWork?.SaveChanges();
    }

    public User? Get(Guid id)
    {
        return _unitOfWork?.UsersRepository.GetById(id);
    }

    public User? Get(string email)
    {
       return _unitOfWork?.UsersRepository.Get(u => u.Email.Equals(email));
    }

    public User? Get(string email, string password)
    {
        return _unitOfWork?.UsersRepository.Get(u => u.Email.Equals(email) && u.Password.Equals(password));
    }
}