using Gudulion.BackEnd.DB;

namespace Gudulion.BackEnd.Moduls.Request;

public class Request:IEntityWithId
{
    public int Id { get; set; }
    public int FromUserId { get; set; }
    public User.User FromUser { get; set; }
    public int ToUserId { get; set; }
    public User.User ToUser { get; set; }
    public string Description { get; set; }
    public DateTime AddDate { get; set; }
    public DateTime AcceptOrRejectDate { get; set; }
    public Status Status { get; set; }
    public RequestType RequestType { get; set; }
}

public class UserRequestMapping
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User.User User { get; set; }
    
    public int RequestId { get; set; }
    public Request Request { get; set; }

    /// <summary>
    /// کاربر ای این فیلد برای این هست که هر یوزر بتونه برای درخواست ایجاد شده نظر بده و بتونه درخواست را رد کنه یا قبول کنه 
    /// </summary>
    public Status Status { get; set; }

    public string Description { get; set; }
}

public enum Status
{
    Undefined,
    Rejected,
    Accepted
}

public enum RequestType
{
}