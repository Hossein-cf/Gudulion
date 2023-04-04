using Gudulion.BackEnd.DB;

namespace Gudulion.BackEnd.Moduls.Request.Model;

public class Request : IEntityWithId
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int FromUserId { get; set; }
    public User.User FromUser { get; set; }
    public int ToUserId { get; set; }
    public User.User ToUser { get; set; }
    public string Occasion { get; set; }

    public string Description { get; set; }
    public string TrackingCode { get; set; }

    public DateTime AddDate { get; set; }
    public DateTime? AcceptOrRejectDate { get; set; }
    public RequestStatus RequestStatus { get; set; }
    public RequestType RequestType { get; set; }
}

public class UserRequestMapping
{
    public int Id { get; set; }
    public int UserId { get; set; }

    // public User.User User { get; set; }
    public int RequestId { get; set; }

    // public Request Request { get; set; }

    /// <summary>
    /// کاربر ای این فیلد برای این هست که هر یوزر بتونه برای درخواست ایجاد شده نظر بده و بتونه درخواست را رد کنه یا قبول کنه 
    /// </summary>
    public RequestStatus RequestStatus { get; set; }

    // 
    /// این فیلد به قسمت کامنت انتقال یافت به صورتی که این ففیلد به صورت کامنت ذخیره میشود 
    // 
    // public string Description { get; set; }
}

public enum RequestStatus
{
    Pending,
    Rejected,
    Accepted,
}

public enum RequestType
{
    Shirini = 0,
    Gheramat,
    Xorma,
}