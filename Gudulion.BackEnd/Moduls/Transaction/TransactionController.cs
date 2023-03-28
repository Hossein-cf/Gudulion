using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Sweet;

[Authorize]
public class TransactionController : GenericController<Transaction.Transaction>
{
    public TransactionController(MainDbContext context) : base(context)
    {
    }
}