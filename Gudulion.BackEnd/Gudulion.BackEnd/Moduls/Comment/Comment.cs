using Gudulion.BackEnd.DB;

namespace Gudulion.BackEnd.Moduls.Comment;

public class Comment:IEntityWithId
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public User.User User { get; set; }
    public EntityType EntityType { get; set; }
    public int EntityId { get; set; }
}

public enum EntityType
{
    Trip,
    Request
}