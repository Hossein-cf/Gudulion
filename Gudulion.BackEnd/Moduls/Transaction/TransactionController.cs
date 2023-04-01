using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Transaction;

[Authorize]
public class TransactionController : GenericController<Transaction>
{
    public TransactionController(MainDbContext context) : base(context)
    {
    }
}