using AutoMapper;
using Gudulion.BackEnd.Moduls.Image;
using Gudulion.BackEnd.Moduls.Image.DTO;
using Gudulion.BackEnd.Moduls.Image.Model;
using Gudulion.BackEnd.Moduls.Request.DTO;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Moduls.User;

namespace Gudulion.BackEnd.Helpers;

public class MyMapper : Profile
{
    public MyMapper()
    {
        CreateMap<Image, ImageWithData>();
        CreateMap<ImageWithData, Image>();
        CreateMap<RequestDto, Request>();
        CreateMap<Request, RequestDto>();
    }
}