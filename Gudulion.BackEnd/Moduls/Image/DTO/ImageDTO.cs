using Gudulion.BackEnd.Moduls.Image.Model;

namespace Gudulion.BackEnd.Moduls.Image.DTO;

public class ImageWithData 
{
    public string ImageType { get; set; }
    
    public RelatedEntityType RelatedEntityType { get; set; }
    public byte[] ImageData { get; set; }
}

public class ImageEntity
{
    public int Id { get; set; }
    public RelatedEntityType RelatedEntityType { get; set; }
}