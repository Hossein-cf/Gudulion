using AutoMapper;
using Gudulion.BackEnd.Moduls.Image.DTO;
using Gudulion.BackEnd.Moduls.Image.Model;
using Gudulion.BackEnd.Moduls.Request.DTO;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Moduls.Sweet.DTO;
using Gudulion.BackEnd.Moduls.Transaction.DTO;
using Gudulion.BackEnd.Moduls.Transaction.Model;
using Gudulion.BackEnd.Moduls.Trip.DTO;
using Gudulion.BackEnd.Moduls.Trip.Model;

namespace Gudulion.BackEnd.Helpers;

public class MyMapper : Profile
{
    public MyMapper()
    {
        CreateMap<Image, ImageWithData>();
        CreateMap<ImageWithData, Image>();
        CreateMap<RequestDto, Request>();
        CreateMap<Request, RequestDto>();
        CreateMap<AddTripDto, Trip>();
        CreateMap<AddUserToTripDto, UserTripMapping>();
        CreateMap<AddTransactionDto, Transaction>();

        CreateMap<Moduls.Sweet.Model.Sweet, SweetWithAllData>();
    }
}