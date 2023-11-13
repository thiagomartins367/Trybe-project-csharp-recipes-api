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
[Route("recipe")]
[Produces("application/json")]
public class RecipesController : ControllerBase
{
    public readonly IRecipeService _service;

    public RecipesController(IRecipeService service)
    {
        this._service = service;
    }

    // 1 - Sua aplicação deve ter o endpoint GET /recipe
    //Read
    /// <summary>
    ///     Retorna lista de todas as receitas da base de dados.
    /// </summary>
    /// <response code="200">Success</response>
    [ProducesResponseType(typeof(List<Recipe>), StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult Get()
    {
        var recipes = _service.GetRecipes();
        return Ok(recipes);
    }

    // 2 - Sua aplicação deve ter o endpoint GET /recipe/:name
    //Read
    /// <summary>
    ///     Retorna uma receita pelo parâmetro name.
    /// </summary>
    /// <response code="200">Success</response>
    /// <response code="404">Not Found</response>
    [ProducesResponseType(typeof(Recipe), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {
        if (!_service.RecipeExists(name)) return NotFound();
        var recipe = _service.GetRecipe(name);
        return Ok(recipe);
    }

    // 3 - Sua aplicação deve ter o endpoint POST /recipe
    /// <summary>
    ///     Cria uma receita na base de dados.
    /// </summary>
    /// <remarks>
    /// Request body example:
    ///
    ///     {
    ///        "Name": "Mousse de maracuja",
    ///        "RecipeType": 0,
    ///        "PreparationTime": "0.2",
    ///        "Ingredients": [
	///            "1 lata de leite condensado",
    ///            "1 lata de creme de leite",
    ///            "1 xícara (chá) de suco de maracujá concentrado",
    ///            "1 envelope de gelatina em pó sem sabor",
    ///            "1/2 xícara (chá) de água"
    ///        ],
    ///        "Directions": "Em um liquidificador, ...",
    ///        "Rating": "9"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created</response>
    [ProducesResponseType(typeof(Recipe), StatusCodes.Status201Created)]
    [HttpPost]
    public IActionResult Create([FromBody] Recipe recipe)
    {
        _service.AddRecipe(recipe);
        return Created(recipe.Name, recipe);
    }

    // 4 - Sua aplicação deve ter o endpoint PUT /recipe
    /// <summary>
    ///     Atualiza dados de uma receita pelo parâmetro name.
    /// </summary>
    /// <remarks>
    /// Request body example:
    ///
    ///     {
    ///        "Name": "Mousse de maracuja",
    ///        "RecipeType": 0,
    ///        "PreparationTime": "0.3",
    ///        "Ingredients": [
	///            "2 lata de leite condensado",
    ///            "1 lata de creme de leite",
    ///            "2 xícara (chá) de suco de maracujá concentrado",
    ///            "1 envelope de gelatina em pó sem sabor",
    ///            "1/2 xícara (chá) de água"
    ///        ],
    ///        "Directions": "Em um liquidificador, bata os ingredientes ...",
    ///        "Rating": "10"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">No Content</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody] Recipe recipe)
    {
        if (name.ToLower() != recipe.Name.ToLower()) return BadRequest();
        if (!_service.RecipeExists(name)) return NotFound();
        _service.UpdateRecipe(recipe);
        return NoContent();
    }

    // 5 - Sua aplicação deve ter o endpoint DELETE /recipe
    /// <summary>
    ///     Remove uma receita da base de dados pelo parâmetro name.
    /// </summary>
    /// <response code="204">No Content</response>
    /// <response code="404">Not Found</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        if (!_service.RecipeExists(name)) return NotFound();
        _service.DeleteRecipe(name);
        return NoContent();
    }
}
