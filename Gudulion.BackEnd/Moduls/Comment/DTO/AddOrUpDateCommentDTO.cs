using Gudulion.BackEnd.Moduls.Comment.Model;

namespace Gudulion.BackEnd.Moduls.Comment.DTO;

public class AddOrUpDateCommentDTO
{
    public int EntityId { get; set; }
    public CommentEntityType EntityType { get; set; }
    public string CommentMessage { get; set; }
    public int UserId { get; set; }
}