using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Comment.DTO;
using Gudulion.BackEnd.Moduls.User;
using Gudulion.BackEnd.Moduls.User.Service;
using Sweet.BackEnd.Exceprions;

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
            Date = new DateTime(),
            CommentEntityType = dto.EntityType,
            EntityId = dto.EntityId,
        };
        db.Comments.Add(comment);
        db.SaveChanges();
        return comment;
    }

    public Model.Comment Edit(int id, AddOrUpDateCommentDTO dto)
    {
        var user = _userService.GetCurrentUser();

        var comment = db.Comments.Find(id);
        if (comment == null)
        {
            throw new NotFoundException("Comment not found");
        }

        if (user.Id == comment.UserId || user.Role == Role.GroupAdmin)
        {
            comment.Description = dto.CommentMessage;
            db.SaveChanges();
        }
        else
        {
            throw new Exception("You don't have permission to edit this comment");
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
            throw new Exception("You don't have permission to delete this comment");
        }
    }
}

public interface ICommentService
{
    public Model.Comment Add(AddOrUpDateCommentDTO dto);
    public Model.Comment Edit(int id, AddOrUpDateCommentDTO dto);
    public void Delete(int id);
}