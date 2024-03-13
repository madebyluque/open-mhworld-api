using Microsoft.AspNetCore.Mvc;
using OpenMHWorld.API.Responses;
using OpenMHWorld.API.Services;
using Serilog;

namespace OpenMHWorld.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]

public class MonstersController(IMonsterService monsterService) : Controller
{
    /// <summary>
    /// Gets a monster by its id.
    /// </summary>
    /// <param name="id">An integer representing the monster's id.</param>
    /// <returns>Status 200 case the monster has been found, 400 otherwise.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(CustomResponse))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(CustomResponse))]
    public async Task<IActionResult> GetMonsterById([FromRoute] int id = 1)
    {
        var monster = await monsterService.GetMonsterById(id);

        if (monster == null)
        {
            Log.Error("[GetMonsterById]: it was not possible to find a monster with id {id}.", id);
            return BadRequest(new CustomResponse(false, null, "Monster does not exist."));
        }

        return Ok(new CustomResponse(true, monster));
    }

    /// <summary>
    /// Gets a list of monsters (limited to 20).
    /// </summary>
    /// <param name="page">CurrentPage for pagination.</param>
    /// <param name="pageSize">Current page size.</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(CustomResponse))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(CustomResponse))]
    public async Task<IActionResult> GetMonsters([FromQuery] int page = 1, int pageSize = 10)
    {
        if (pageSize > 20)
        {
            Log.Warning("[GetMonsters]: pageSize of {pageSize} exceeded the limit of 20 entries.", pageSize);
            pageSize = 20;
        }

        var paginatedResponse = await monsterService.GetMonsters(page, pageSize);
        ConfigurePaginationHeader(paginatedResponse);

        return Ok(paginatedResponse.Response);
    }

    private void ConfigurePaginationHeader(PaginatedResponse response)
    {
        HttpContext.Response.Headers.Append("X-Pagination", response.ToString());
    }
}
