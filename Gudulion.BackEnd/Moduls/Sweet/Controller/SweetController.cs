using Gudulion.BackEnd.Moduls.Sweet.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Sweet.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class SweetController : ControllerBase
{
    private readonly ISweetService _sweetService;

    public SweetController(ISweetService sweetService)
    {
        _sweetService = sweetService;
    }

    [HttpGet]
    public IActionResult GetById([FromQuery] int id)
    {
        return Ok(_sweetService.getById(id));
    }
    
}