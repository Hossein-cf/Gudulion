using Gudulion.BackEnd.Moduls.Request.DTO;
using Gudulion.BackEnd.Moduls.Request.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Request.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class RequestController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    [HttpPost]
    public ActionResult<Model.Request> Create(RequestDto dto)
    {
        _requestService.Create(dto);
        return Ok();
    }

    [HttpPut]
    public IActionResult ChangeStatus([FromBody] ChangeRequestStatusDTO dto)
    {
        _requestService.ChangeStatus(dto);
        return Ok();
    }

    [HttpPost]
    public IActionResult Survey([FromBody] SurveyDto dto)
    {
        _requestService.Survey(dto);
        return Ok();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Model.Request>> GetUserRequest([FromQuery] int userId)
    {
        var usersRequests = _requestService.GetUsersRequests(userId);
        return usersRequests;
    }
}