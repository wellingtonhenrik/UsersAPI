using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    /// <summary>
    /// Autenticar o usuário
    /// </summary>
    [HttpPost]
    [Route("login")]
    public IActionResult Login()
    {
        return Ok();
    }

    /// <summary>
    /// Recuperar senha de acesso do usuário
    /// </summary>
    [HttpPost]
    [Route("forgot-password")]
    public IActionResult ForgotPassword()
    {
        return Ok();
    }
     
    /// <summary>
    /// Reiniciar senha de acesso do usuário
    /// </summary>
    [HttpPost]
    [Route("reset-password")]
    public IActionResult ResetPassword()
    {
        return Ok();
    }
}