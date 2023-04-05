using Gudulion.BackEnd.Moduls.Transaction.DTO;
using Gudulion.BackEnd.Moduls.Transaction.Model;
using Gudulion.BackEnd.Test;
using NUnit.Framework;

namespace Gudulion.BackEnd.Test;
[TestFixture,Order(6)]
public class TransactionTest : TestGeneric
{
    [Test, Order(1)]
    public void CreateTransaction()
    {
        var dto = new AddTransactionDto
        {
            TripId = 1,
            UserId = 2,
            TransactionItems = new List<TransactionItem>()
            {
                new TransactionItem()
                {
                    Amount = 2000,
                    Title = "پفک",
                },
                new TransactionItem()
                {
                    Amount = 3000,
                    Title = "Chips",
                },
                new TransactionItem()
                {
                    Amount = 4000,
                    Title = "Drinks",
                },
            }
        };
        _transactionService?.Create(dto);
    }

    [Test, Order(2)]
    public void ChangeTransactionStatus()
    {
        var dto = new ChangeTransactionStatusDto
        {
            NewStatus = TransactionStatus.Confirmed,
            TransactionId = 1
        };
        _transactionService?.ChangeTransactionStatus(dto);
    }
}