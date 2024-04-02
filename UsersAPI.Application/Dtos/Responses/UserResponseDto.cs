namespace UsersAPI.Application.Dtos.Responses;

public class UserResponseDto
{
    public Guid? Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public DateTime? DataCadastro { get; set; }
}