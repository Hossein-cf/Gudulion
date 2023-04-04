using Gudulion.BackEnd.DB;

namespace Gudulion.BackEnd.Moduls.Sweet.Model;

public class Sweet : IEntityWithId
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Occasion { get; set; }
    public string? TrackingCode { get; set; }
    public SweetType Type { get; set; }
    public DateTime AddDate { get; set; }
    public DateTime PayDate { get; set; }
    public SweetStatus Status { get; set; }

    public Request.Model.Request Request { get; set; }
    public int RequestId { get; set; }
}

public class UserSweetMapping
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User.User User { get; set; }
    public int SweetId { get; set; }
    public Sweet Sweet { get; set; }
    public bool IsPayer { get; set; }
    public SweetAcceptance Acceptance { get; set; }
}

public enum SweetType
{
    Shirini = 0,
    Gheramat,
    Xorma,
}

public enum SweetStatus
{
    PendingForPay,
    PendingForAccept,
    Payed,
}

public enum SweetAcceptance
{
    Accepted = 0,
    Rejected,
    /// <summary>
    /// این برای زمانی هست که کابر طرف های مورد نظر را به شیرینی اضاقه میکند و منتظر تایید و یا رد آن ها هست
    /// </summary>
    Pending
}