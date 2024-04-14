using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;

namespace UsersAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthAppService _authAppService;

    public AuthController(IAuthAppService authAppService)
    {
        _authAppService = authAppService;
    }

    /// <summary>
    /// Autenticar o usuário
    /// </summary>
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(typeof(LoginResponseDto), 200)]
    public IActionResult Login(LoginRequestDto dto)
    {
        return StatusCode(200,_authAppService?.Login(dto)); 
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
    [Authorize]
    [HttpPost]
    [Route("reset-password")]
    public IActionResult ResetPassword()
    {
        return Ok();
    }
}