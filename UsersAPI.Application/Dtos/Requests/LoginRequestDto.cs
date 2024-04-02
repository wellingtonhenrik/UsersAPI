using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "informe um endereço de email válido")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Informe uma senha forte com pelo menos 8 caracteres.")]
    public string? Password { get; set; }
}