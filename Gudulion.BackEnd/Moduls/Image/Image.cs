using Gudulion.BackEnd.DB;

namespace Gudulion.BackEnd.Moduls.Image;

public class Image : IEntityWithId
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageType { get; set; }
    
    public RelatedEntityType RelatedEntityType { get; set; }
}



public enum RelatedEntityType
{
    User,
    Sweet,
    Trip,
}