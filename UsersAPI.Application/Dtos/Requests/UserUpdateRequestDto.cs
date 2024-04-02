using System.ComponentModel.DataAnnotations;
namespace UsersAPI.Application.Dtos.Requests;

public class UserUpdateRequestDto
{
    [Required(ErrorMessage = "Informe campo nome")]
    [MaxLength(150, ErrorMessage = "Informe o nome com maximo {1} caracteres")]
    [MinLength(3,ErrorMessage = "Informe o nome com no minino {1} caractes")]
    public string? Nome { get; set; }    

}