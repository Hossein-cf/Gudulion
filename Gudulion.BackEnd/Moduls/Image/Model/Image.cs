using Gudulion.BackEnd.DB;

namespace Gudulion.BackEnd.Moduls.Image.Model;

public class Image : IEntityWithId
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageType { get; set; }
    public int EntityId { get; set; }
    public RelatedEntityType EntityType { get; set; }
}

public enum RelatedEntityType
{
    User,
    Sweet,
    Trip,
}