namespace UserApi.Domain.Models;

public class User
{
    public Guid id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime DataCadastro { get; set; }  
}