using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Exceptions;
using Gudulion.BackEnd.Moduls.Comment.DTO;
using Gudulion.BackEnd.Moduls.User;
using Gudulion.BackEnd.Moduls.User.Service;

namespace Gudulion.BackEnd.Moduls.Comment.Service;

public class CommentService : ICommentService
{
    private MainDbContext db;
    private readonly IUserService _userService;


    public CommentService(MainDbContext context, IUserService userService
    )
    {
        db = context;
        _userService = userService;
    }


    public Model.Comment Add(AddOrUpDateCommentDTO dto)
    {
        var comment = new Comment.Model.Comment
        {
            Description = dto.CommentMessage,
            UserId = dto.UserId,
            Date = DateTime.Now,
            CommentEntityType = dto.EntityType,
            EntityId = dto.EntityId,
        };
        db.Comments.Add(comment);
        db.SaveChanges();
        return comment;
    }

    public Model.Comment Upadate(int id, AddOrUpDateCommentDTO dto)
    {
        var comment = db.Comments.Find(id);
        if (comment == null)
        {
            throw new NotFoundException("Comment not found");
        }

        var user = _userService.GetCurrentUser();
        if (user.Id == comment.UserId || user.Role == Role.GroupAdmin)
        {
            comment.Description = dto.CommentMessage;
            db.SaveChanges();
        }
        else
        {
            throw new UnauthorizedException("You don't have permission to edit this comment");
        }

        return comment;
    }

    public void Delete(int id)
    {
        var comment = db.Comments.Find(id);
        if (comment == null)
        {
            throw new NotFoundException("Comment not found");
        }

        var user = _userService.GetCurrentUser();
        if (user.Id == comment.UserId || user.Role == Role.GroupAdmin)
        {
            db.Remove(comment);
            db.SaveChanges();
        }
        else
        {
            throw new UnauthorizedException("You don't have permission to delete this comment");
        }
    }

    public List<Model.Comment> GetCommentsByEntityId(int entityId)
    {
        var comments = db.Comments.Where(a => a.EntityId == entityId).ToList();
        return comments;
    }
}

public interface ICommentService
{
    public Model.Comment Add(AddOrUpDateCommentDTO dto);
    public Model.Comment Upadate(int id, AddOrUpDateCommentDTO dto);
    public void Delete(int id);
    public List<Comment.Model.Comment> GetCommentsByEntityId(int entityId);
}