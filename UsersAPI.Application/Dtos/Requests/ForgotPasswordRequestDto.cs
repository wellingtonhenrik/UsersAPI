using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests;

public class ForgotPasswordRequestDto
{
    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "informe um endereço de email válido")]
    public string? Email { get; set; }

}