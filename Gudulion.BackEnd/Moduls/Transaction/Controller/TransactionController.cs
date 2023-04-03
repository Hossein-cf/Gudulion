﻿using Gudulion.BackEnd.Controllers;
using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Authorization;

namespace Gudulion.BackEnd.Moduls.Transaction.Controller;

[Authorize(Roles = "GroupAdmin")]
public class TransactionController : GenericController<Model.Transaction>
{
    public TransactionController(MainDbContext context) : base(context)
    {
    }
}