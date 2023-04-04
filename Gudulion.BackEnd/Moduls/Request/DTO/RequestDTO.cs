using Gudulion.BackEnd.Moduls.Request.Model;

namespace Gudulion.BackEnd.Moduls.Request.DTO;

public class RequestDto
{
    public int FromUserId { get; set; }
    public int ToUserId { get; set; }
    public string Occasion { get; set; }
    public string Description { get; set; }
    public RequestStatus RequestStatus { get; set; }
    public RequestType RequestType { get; set; }
    public string Title { get; set; }
}

public class ChangeRequestStatusDTO
{
    public int RequestId { get; set; }
    public RequestStatus OldStatus { get; set; }
    public RequestStatus NewStatus { get; set; }

    public string Message { get; set; }
}

public class SurveyDto
{
    public int UserId { get; set; }
    public RequestStatus Status { get; set; }
    public string Message { get; set; }
    public int RequestId { get; set; }
}