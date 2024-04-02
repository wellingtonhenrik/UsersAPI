using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests;

public class UserAddRequestDto
{
    [Required(ErrorMessage = "Informe campo nome")]
    [MaxLength(150, ErrorMessage = "Informe o nome com maximo {1} caracteres")]
    [MinLength(3,ErrorMessage = "Informe o nome com no minino {1} caractes")]
    public string? Nome { get; set; }    
    [Required(ErrorMessage = "Informe o email")]
    [EmailAddress(ErrorMessage = "informe um endereço de email válido")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Informe uma senha forte com pelo menos 8 caracteres.")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Confirme a senha de acesso")]
    [Compare("Password", ErrorMessage = "Senhas não conferem")]
    public string? PasswordConfirm  { get; set; }
}