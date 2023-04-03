using System.Transactions;
using AutoMapper;
using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Comment.DTO;
using Gudulion.BackEnd.Moduls.Comment.Model;
using Gudulion.BackEnd.Moduls.Comment.Service;
using Gudulion.BackEnd.Moduls.Request.DTO;
using Gudulion.BackEnd.Moduls.Request.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Sweet.BackEnd.Exceprions;

namespace Gudulion.BackEnd.Moduls.Request.Service;

public class RequestService : IRequestService
{
    private readonly ICommentService _commentService;
    private readonly MainDbContext db;
    private readonly IMapper _mapper;

    public RequestService(ICommentService commentService, MainDbContext context, IMapper mapper)
    {
        _commentService = commentService;
        db = context;
        _mapper = mapper;
    }

    public Request.Model.Request Create(RequestDto dto)
    {
        var request = _mapper.Map<Model.Request>(dto);

        db.Requests.Add(request);
        db.SaveChanges();
        return request;
    }

    public void ChangeStatus(ChangeRequestStatusDTO dto)
    {
        var request = db.Requests.Find(dto.Id);
        if (request == null)
        {
            // todo throw exception 
        }

        switch (dto.OldStatus)
        {
            case RequestStatus.Pending:
                if (dto.NewStatus == RequestStatus.Accepted)
                {
                    //todo در این قسمت باید با توجه به وضعیت درخواست ششیرینی ایجاد میشود 
                }
                else if (dto.NewStatus == RequestStatus.Rejected)
                {
                    var comment = new AddOrUpDateCommentDTO
                    {
                        UserId = request.ToUserId,
                        EntityType = CommentEntityType.Request,
                        EntityId = dto.Id,
                        CommentMessage = dto.Message
                    };
                    _commentService.Add(comment);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        ChangeStatusCore(dto);
    }

    private void ChangeStatusCore(ChangeRequestStatusDTO dto)
    {
        var request = db.Requests.Find(dto.Id);
        if (request == null)
        {
            throw new NotFoundException("request not found");
        }

        request.RequestStatus = dto.NewStatus;
        request.AcceptOrRejectDate = new DateTime();

        db.SaveChanges();
    }

    public Comment.Model.Comment AddComment(AddOrUpDateCommentDTO dto)
    {
        dto.EntityType = CommentEntityType.Request;
        var comment = _commentService.Add(dto);
        return comment;
    }

    public void Survey(SurveyDto dto)
    {
        //todo نظر سنجی برای درخواست ذر این قسمت انجام میشود
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

        db.RequestMappings.Add(userReqMapping);
        db.SaveChanges();
        throw new NotImplementedException();
    }
}

public interface IRequestService
{
    public Request.Model.Request Create(RequestDto dto);

    public void ChangeStatus(ChangeRequestStatusDTO dto);

    public void Survey(SurveyDto dto);
    public Comment.Model.Comment AddComment(AddOrUpDateCommentDTO dto);
}