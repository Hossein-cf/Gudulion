using Gudulion.BackEnd.DB;

namespace Gudulion.BackEnd.Moduls.Transaction.Model;

public class Transaction : IEntityWithId
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ConfirmedDate { get; set; }
    public virtual User.User User { get; set; }
    public int TripId { get; set; }
    public virtual Trip.Model.Trip Trip { get; set; }
    public virtual ICollection<TransactionItem> TransactionItems { get; set; }
    public TransactionStatus TransactionStatus { get; set; }
}

public class TransactionItem : IEntityWithId
{
    public int Id { get; set; }
    public int TransactionId { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
}

public enum TransactionStatus
{
    Draft = 0,
    Confirmed,
}