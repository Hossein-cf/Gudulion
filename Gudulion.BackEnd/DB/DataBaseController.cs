using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.DB;

[Route("api/[controller]/[action]")]
[ApiController]
public class DataBaseController : ControllerBase
{
    private readonly MainDbContext _mainDbContext;

    public DataBaseController(MainDbContext mainDbContext)
    {
        _mainDbContext = mainDbContext;
    }

    [HttpPost]
    public IActionResult Create()
    {
        _mainDbContext.Database.EnsureCreated();
        return Ok();
    }
    [HttpDelete]
    public IActionResult Delete()
    {
        _mainDbContext.Database.EnsureDeleted();
        return Ok();
    }
}