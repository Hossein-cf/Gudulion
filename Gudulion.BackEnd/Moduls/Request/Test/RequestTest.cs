using Gudulion.BackEnd.Moduls.Request.DTO;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Test;
using NUnit.Framework;

namespace Gudulion.BackEnd.Test;

[TestFixture, Order(3)]
public class RequestTest : TestGeneric
{
    [Test, Order(1)]
    public void AddRequest()
    {
        var dto = new RequestDto
        {
            Description = "Fore apply to university",
            Title = "University",
            Occasion = "Occasion",
            RequestType = RequestType.Gheramat,
            FromUserId = 1,
            ToUserId = 6,
            RequestStatus = RequestStatus.Pending,
        };

        var dto1 = new RequestDto
        {
            Description = "Fore apply to university",
            Title = "University",
            Occasion = "Occasion",
            RequestType = RequestType.Shirini,
            FromUserId = 1,
            ToUserId = 7,
            RequestStatus = RequestStatus.Pending,
        };

        _requestService?.Create(dto);
        _requestService?.Create(dto1);
        Assert.IsNotNull(dto);
    }

    [Test, Order(2)]
    public void SurveyRequest()
    {
        var dtos = new List<SurveyDto>()
        {
            new SurveyDto
            {
                UserId = 3,
                Status = RequestStatus.Accepted,
                RequestId = 1
            },
            new SurveyDto
            {
                UserId = 4,
                Status = RequestStatus.Rejected,
                RequestId = 1,
                Message = "This is a message For Reject Request 1"
            }
        };
        dtos.ForEach(dto => _requestService?.Survey(dto));
    }

    [Test, Order(3)]
    public void ChangeRequestStatus()
    {
        var dto = new ChangeRequestStatusDTO
        {
            RequestId = 1,
            NewStatus = RequestStatus.Accepted,
            OldStatus = RequestStatus.Pending,
        };
        _requestService?.ChangeStatus(dto);
    }
}