using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    /// <summary>
    /// Criar conta de usuário
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Add()
    {
        return Ok();
    }

    /// <summary>
    /// Atualizar conta de usuário
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }
/// <summary>
/// Deletar conta e usuário
/// </summary>
/// <returns></returns>
    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
/// <summary>
/// Consultar usuário
/// </summary>
/// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }   
}