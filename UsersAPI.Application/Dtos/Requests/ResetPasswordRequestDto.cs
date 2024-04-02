using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests;

public class ResetPasswordRequestDto
{
    [Required(ErrorMessage = "Informe a senha atual")]
    public string? PasswordAnterior { get; set; }

    [Required(ErrorMessage = "Informe nova senha")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Informe uma senha forte com pelo menos 8 caracteres.")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Confirme a nova senha")]
    [Compare("Password", ErrorMessage = "Senhas não conferem")]
    public string? PasswordConfirm  { get; set; }
}