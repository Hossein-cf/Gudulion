using System.Net;
using Gudulion.BackEnd.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Test.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {

        throw new NotFoundException("this is a test not found exception");
    }
}