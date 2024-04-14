namespace UserApi.Domain.Exceptions;

public class AcessDeniedException : Exception
{
    public override string Message => "Acesso negado, Usuário ou senha inválida";
}