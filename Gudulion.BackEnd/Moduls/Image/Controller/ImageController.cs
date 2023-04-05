using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Image.DTO;
using Gudulion.BackEnd.Moduls.Image.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Image.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(MainDbContext context, IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost]
    public IActionResult Save([FromBody] ImageWithData image)
    {
        return Ok(_imageService.Save(image));
    }

    [HttpGet]
    public IActionResult Get([FromBody] ImageEntity imageEntity)
    {
        return Ok(_imageService.Get(imageEntity));
    }

    [HttpDelete]
    [Authorize(Roles = "GroupAdmin")]
    public IActionResult Delete([FromBody] ImageEntity imageEntity)
    {
        _imageService.Delete(imageEntity);
        return Ok();
    }
}