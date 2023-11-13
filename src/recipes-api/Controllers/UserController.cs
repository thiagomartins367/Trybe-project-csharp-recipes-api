using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("user")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    public readonly IUserService _service;

    public UserController(IUserService service)
    {
        this._service = service;
    }

    // 6 - Sua aplicação deve ter o endpoint GET /user/:email
    /// <summary>
    ///     Retorna usuário pelo parâmetro email.
    /// </summary>
    /// <response code="200" cref="User">Success</response>
    /// <response code="404">Not Found</response>
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{email}", Name = "GetUser")]
    public IActionResult Get(string email)
    {
        if (!_service.UserExists(email)) return NotFound();
        var user = _service.GetUser(email);
        return Ok(user);
    }

    // 7 - Sua aplicação deve ter o endpoint POST /user
    /// <summary>
    ///     Cria um usuário na base de dados.
    /// </summary>
    /// <remarks>
    /// Request body example:
    ///
    ///     {
    ///        "email": "pessoa@email.com",
    ///        "name": "Pessoa Nova",
    ///        "password": "senhaDaPessoaNova"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created</response>
    [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
        _service.AddUser(user);
        return CreatedAtRoute("GetUser", new { email = user.Email }, user);
    }

    // "8 - Sua aplicação deve ter o endpoint PUT /user
    /// <summary>
    ///     Atualiza dados de um usuário pelo parâmetro email.
    /// </summary>
    /// <remarks>
    /// Request body example:
    ///
    ///     {
    ///        "email": "pessoa@email.com",
    ///        "name": "Pessoa",
    ///        "password": "senhaDaPessoa"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{email}")]
    public IActionResult Update(string email, [FromBody] User user)
    {
        if (email.ToLower() != user.Email.ToLower()) return BadRequest();
        if (!_service.UserExists(email)) return NotFound();
        _service.UpdateUser(user);
        return Ok(user);
    }

    // 9 - Sua aplicação deve ter o endpoint DELETE /user
    /// <summary>
    ///     Remove um usuário da base de dados pelo parâmetro email.
    /// </summary>
    /// <response code="204">No Content</response>
    /// <response code="404">Not Found</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{email}")]
    public IActionResult Delete(string email)
    {
        if (!_service.UserExists(email)) return NotFound();
        _service.DeleteUser(email);
        return NoContent();
    }
}
