using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Transaction.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = "GroupAdmin")]
public class TransactionController:ControllerBase
{
    public TransactionController(MainDbContext context)
    {
    }
}