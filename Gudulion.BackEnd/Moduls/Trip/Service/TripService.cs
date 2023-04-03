using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Comment.DTO;
using Gudulion.BackEnd.Moduls.Comment.Model;
using Gudulion.BackEnd.Moduls.Comment.Service;

namespace Gudulion.BackEnd.Moduls.Trip.Service;

public class TripService : ITripService
{
    private MainDbContext _db;
    private ICommentService _commentService;

    public TripService(MainDbContext db, ICommentService commentService)
    {
        _db = db;
        _commentService = commentService;
    }

    public Comment.Model.Comment AddComment(AddOrUpDateCommentDTO dto)
    {
        dto.EntityType = CommentEntityType.Trip;
        var comment = _commentService.Add(dto);
        return comment;
    }
}

public interface ITripService
{
    public Comment.Model.Comment AddComment(AddOrUpDateCommentDTO dto);
}