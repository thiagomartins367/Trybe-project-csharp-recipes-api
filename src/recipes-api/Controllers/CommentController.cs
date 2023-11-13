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
[Route("comment")]
[Produces("application/json")]
public class CommentController : ControllerBase
{
    public readonly ICommentService _service;

    public CommentController(ICommentService service)
    {
        this._service = service;
    }

    // 10 - Sua aplicação deve ter o endpoint POST /comment
    /// <summary>
    ///     Cria um comentário de uma receita.
    /// </summary>
    /// <remarks>
    /// Request body example:
    ///
    ///     {
    ///        "email": "pessoa@email.com",
    ///        "recipeName": "Coxinha",
    ///        "CommentText": "Fiz a receita de Coxinha na minha casa. Fiz o passo a passo e funcionou."
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created</response>
    [ProducesResponseType(typeof(Comment), StatusCodes.Status201Created)]
    [HttpPost]
    public IActionResult Create([FromBody] Comment comment)
    {
        _service.AddComment(comment);
        return CreatedAtRoute("GetComment", new { name = comment.RecipeName }, comment);
    }

    // 11 - Sua aplicação deve ter o endpoint GET /comment/:recipeName
    /// <summary>
    ///     Retorna uma comentário pelo nome da receita.
    /// </summary>
    /// <response code="200">Success</response>
    [ProducesResponseType(typeof(Comment), StatusCodes.Status200OK)]
    [HttpGet("{name}", Name = "GetComment")]
    public IActionResult Get(string name)
    {
        var comment = _service.GetComments(name);
        return Ok(comment);
    }
}
