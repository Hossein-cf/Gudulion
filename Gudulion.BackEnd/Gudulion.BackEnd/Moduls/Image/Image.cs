namespace Gudulion.BackEnd.Moduls.Image;

public class Image
{
    public int Id { get; set; }
    public string path { get; set; }
    public int EntityId { get; set; }
    public EntityType EntityType { get; set; }
}

public enum EntityType
{
    User,
    Sweet
}