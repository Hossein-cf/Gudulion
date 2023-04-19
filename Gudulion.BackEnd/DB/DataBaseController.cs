using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.DB;

[Route("api/[controller]/[action]")]
[ApiController]
public class DataBaseController : ControllerBase
{
    private readonly IDbService _dbService;

    public DataBaseController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public IActionResult Create()
    {
        _dbService.CreateDb();
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        _dbService.DeleteDb();
        return Ok();
    }
}