namespace UserApi.Domain.Exceptions
{
    public class EmailJaExisteException : Exception
    {
        public EmailJaExisteException(string email) : base($"O email informado '{email}' já está cadastrado. Tente outro.")
        {
                
        }
    }
}
