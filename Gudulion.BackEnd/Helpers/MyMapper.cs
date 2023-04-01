using AutoMapper;
using Gudulion.BackEnd.Moduls.Image;
using Gudulion.BackEnd.Moduls.User;

namespace Gudulion.BackEnd.Helpers;

public class MyMapper : Profile
{
    public MyMapper()
    {
        CreateMap<Image, ImageWithData>();
        CreateMap<ImageWithData, Image>();
    }
}