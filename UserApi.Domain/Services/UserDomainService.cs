using UserApi.Domain.Exceptions;
using UserApi.Domain.Interfaces.Messages;
using UserApi.Domain.Interfaces.Repositories;
using UserApi.Domain.Interfaces.Security;
using UserApi.Domain.Interfaces.Services;
using UserApi.Domain.Models;
using UserApi.Domain.ValueObjects;

namespace UserApi.Domain.Services;

public class UserDomainService : IUserDomainService
{
    private readonly IUnitOfWork? _unitOfWork;
    private readonly IUserMessageProducer? _userMessageProducer;
    private readonly ITokenService? _tokenService;
    public UserDomainService(IUnitOfWork? unitOfWork, IUserMessageProducer? userMessageProducer, ITokenService? tokenService)
    {
        _unitOfWork = unitOfWork;
        _userMessageProducer = userMessageProducer;
        _tokenService = tokenService;
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

        _userMessageProducer?.Send(new UserMessageVO
        {
            Body = @$"Olá {user.Nome}, seu cadastro foi realizado com sucesso em nosso sistema",
            SendedAt = DateTime.UtcNow,
            Id = user.id,
            Subject = "Parabéns, sua conta de usuário foi criada com sucesso",
            To = user.Email,
        });
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

    public string Authenticate(string email, string password)
    {
        var user = Get(email, password);
        if (user == null)
            throw new AcessDeniedException();

        var userAuthVO = new UserAuthVO
        {
            Email = user.Email,
            Nome = user.Nome,
            id = user.id,
            SignedAt = DateTime.UtcNow,
            Roles = "USER_ROLE",
        };
        
        return _tokenService?.CreateToken(userAuthVO);
    }
}