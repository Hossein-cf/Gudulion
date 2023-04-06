using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Exceptions;
using Gudulion.BackEnd.Moduls.Image.DTO;

namespace Gudulion.BackEnd.Moduls.Image.Service;

public class ImageService : IImageService
{
    private readonly MainDbContext _dbContext;

    public ImageService(MainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Model.Image Save(ImageWithData imageWithData)
    {
        try
        {
            var image = new Model.Image();
            image.ImageType = imageWithData.ImageType;
            image.EntityType = imageWithData.RelatedEntityType;
            image.EntityId = imageWithData.EntityId;
            image.Name = $"{Guid.NewGuid()}{GetImageSuffix(image.ImageType)}";

            // Combine the file path with the generated filename
            string filePath = Path.Combine("Assets/Images", image.Name);

            // Write the image data to the file system
            using (var imageFileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFileStream.Write(imageWithData.ImageData, 0, imageWithData.ImageData.Length);
            }

            _dbContext.Images.Add(image);
            _dbContext.SaveChanges();
            // Return a success response
            return image;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private string GetImageSuffix(string imageType)
    {
        switch (imageType)
        {
            case "image/png":
                return ".png";
            case "image/jpeg":
                return ".jpeg";
        }

        return "";
    }

    public ImageWithData Get(ImageEntity imageEntity)
    {
        //todo
        var image = _dbContext.Images
            .FirstOrDefault(x =>
                x.Id == imageEntity.ImageId && x.EntityId == imageEntity.EntityId &&
                x.EntityType == imageEntity.RelatedEntityType);
        if (image == null)
        {
            throw new NotFoundException("Image not found");
        }
        try
        {
            // Combine the file path with the requested filename
            string filePath = Path.Combine("Assets/Images", image.Name);

            // Read the image data from the file system
            var imageData = System.IO.File.ReadAllBytes(filePath);

            // Return the image as a response with the appropriate content type
            // return File(imageData, $"image/{Path.GetExtension(filePath).Replace(".", "")}");
            var imageWithData = new ImageWithData
            {
                ImageType = image.ImageType,
                ImageData = imageData
            };
            return imageWithData;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Delete(ImageEntity imageEntity)
    {
        var image = _dbContext.Images
            .FirstOrDefault(a =>
                a.Id == imageEntity.ImageId && a.EntityId == imageEntity.EntityId &&
                a.EntityType == imageEntity.RelatedEntityType);
        if (image == null)
        {
            throw new NotFoundException("Image not found");
        }

        try
        {
            var imagePath = Path.Combine("Assets/Images", image.Name);
            System.IO.File.Delete(imagePath);
            _dbContext.Images.Remove(image);
            _dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public List<Model.Image> GetImageByEntityId(int entityId)
    {
        var images = _dbContext.Images.Where(a => a.EntityId == entityId).ToList();
        return images;
    }
}

public interface IImageService
{
    public Model.Image Save(ImageWithData image);
    public ImageWithData Get(ImageEntity imageEntity);
    public void Delete(ImageEntity imageEntity);
    public List<Model.Image> GetImageByEntityId(int entityId);
}