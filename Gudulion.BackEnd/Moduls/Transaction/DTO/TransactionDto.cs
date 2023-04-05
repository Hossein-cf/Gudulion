using Gudulion.BackEnd.Moduls.Transaction.Model;

namespace Gudulion.BackEnd.Moduls.Transaction.DTO;

public class TransactionDto
{
}

public class AddTransactionDto
{
    public int UserId { get; set; }
    public int TripId { get; set; }
    public List<TransactionItem> TransactionItems { get; set; }
}

public class ChangeTransactionStatusDto
{
    public int TransactionId { get; set; }
    public TransactionStatus NewStatus { get; set; }
}