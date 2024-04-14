using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;

namespace UsersAPI.Controllers;
[Authorize(Roles = "USER_ROLE")]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserAppService _userAppService;
    public UsersController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    /// <summary>
    /// Criar conta de usuário
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(UserResponseDto), 201)]
    public IActionResult Add([FromBody] UserAddRequestDto dto)
    {
        return StatusCode(201, _userAppService.Add(dto));
    }

    /// <summary>
    /// Atualizar conta de usuário
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public IActionResult Update(Guid id, UserUpdateRequestDto dto)
    {
        return StatusCode(200,_userAppService.Update(id, dto));
    }
/// <summary>
/// Deletar conta e usuário
/// </summary>
/// <returns></returns>
    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        return StatusCode(200, _userAppService.Delete(id));
    }
/// <summary>
/// Consultar usuário
/// </summary>
/// <returns></returns>
    [HttpGet]
    public IActionResult Get(Guid id)
    {
        //capiturando o conteudo do token
        var auth = User.Identity.Name;
        return StatusCode(200,_userAppService.Get(id));
    }   
}