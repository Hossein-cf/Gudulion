using System.Diagnostics;
using AutoMapper;
using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Comment.DTO;
using Gudulion.BackEnd.Moduls.Comment.Model;
using Gudulion.BackEnd.Moduls.Comment.Service;
using Gudulion.BackEnd.Moduls.Request.DTO;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Moduls.Sweet.Service;
using Sweet.BackEnd.Exceprions;

namespace Gudulion.BackEnd.Moduls.Request.Service;

public class RequestService : IRequestService
{
    private readonly ICommentService _commentService;
    private readonly MainDbContext db;
    private readonly IMapper _mapper;
    private readonly ISweetService _sweetService;

    public RequestService(ICommentService commentService, MainDbContext context, IMapper mapper,
        ISweetService sweetService)
    {
        _commentService = commentService;
        db = context;
        _mapper = mapper;
        _sweetService = sweetService;
    }

    public Request.Model.Request Create(RequestDto dto)
    {
        var request = _mapper.Map<Model.Request>(dto);
        request.AddDate = DateTime.Now;
        GenerateTrackingCode(request);
        db.Requests.Add(request);
        db.SaveChanges();
        return request;
    }

    public void ChangeStatus(ChangeRequestStatusDTO dto)
    {
        var request = db.Requests.Find(dto.RequestId);
        if (request == null)
        {
            throw new NotFoundException("request not found");
        }

        request.RequestStatus = dto.NewStatus;
        request.AcceptOrRejectDate = DateTime.Now;

        db.SaveChanges();

        switch (dto.OldStatus)
        {
            case RequestStatus.Pending:
                if (dto.NewStatus == RequestStatus.Accepted)
                {
                    // در این قسمت باید با توجه به وضعیت درخواست ششیرینی ایجاد میشود 
                    _sweetService.CreateSweet(request);
                }
                else if (dto.NewStatus == RequestStatus.Rejected)
                {
                    var comment = new AddOrUpDateCommentDTO
                    {
                        UserId = request.ToUserId,
                        EntityType = CommentEntityType.Request,
                        EntityId = dto.RequestId,
                        CommentMessage = dto.Message
                    };
                    _commentService.Add(comment);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    private Comment.Model.Comment AddComment(AddOrUpDateCommentDTO dto)
    {
        dto.EntityType = CommentEntityType.Request;
        var comment = _commentService.Add(dto);
        return comment;
    }

    public void Survey(SurveyDto dto)
    {
        // نظر سنجی برای درخواست ذر این قسمت انجام میشود
        var userReqMapping = new UserRequestMapping
        {
            UserId = dto.UserId,
            RequestId = dto.RequestId,
            RequestStatus = dto.Status
        };

        if (dto.Status == RequestStatus.Rejected)
        {
            var addCommentDto = new AddOrUpDateCommentDTO
            {
                EntityId = dto.RequestId,
                EntityType = CommentEntityType.Request,
                UserId = dto.UserId,
                CommentMessage = dto.Message,
            };
            _commentService.Add(addCommentDto);
        }

        db.UserRequestMappings.Add(userReqMapping);
        db.SaveChanges();
        // throw new NotImplementedException();
    }

    private void GenerateTrackingCode(Request.Model.Request request)
    {
        var prefix = "";
        var suffix = 0;
        switch (request.RequestType)
        {
            case RequestType.Shirini:
                prefix = "RSH";
                break;
            case RequestType.Gheramat:
                prefix = "RGH";

                break;
            case RequestType.Xorma:
                prefix = "RX";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        var requestFromDb = db.Requests.Where(a => a.RequestType == request.RequestType).OrderBy(a => a.TrackingCode)
            .LastOrDefault();
        if (requestFromDb == null)
        {
            suffix = 1;
        }
        else
        {
            var args = requestFromDb.TrackingCode.Split('-');
            suffix = Int32.Parse(args[1]) + 1;
        }

        request.TrackingCode = prefix + "-" + suffix.ToString().PadLeft(4, '0');
    }
}

public interface IRequestService
{
    public Request.Model.Request Create(RequestDto dto);

    public void ChangeStatus(ChangeRequestStatusDTO dto);

    public void Survey(SurveyDto dto);
    // public Comment.Model.Comment AddComment(AddOrUpDateCommentDTO dto);
}