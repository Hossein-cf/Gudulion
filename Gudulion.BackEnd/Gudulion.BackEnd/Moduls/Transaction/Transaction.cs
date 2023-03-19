namespace Gudulion.BackEnd.Moduls.Transaction;

public class Transaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User.User User { get; set; }

    public int TripId { get; set; }
    public Trip.Trip Trip { get; set; }

    public List<TransactionItem> TransactionItems { get; set; }
}

public class TransactionItem
{
    public int Id { get; set; }
    public int TransactionId { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
}