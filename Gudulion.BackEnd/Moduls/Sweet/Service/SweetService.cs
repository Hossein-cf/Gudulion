using AutoMapper;
using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Exceptions;
using Gudulion.BackEnd.Moduls.Image.Model;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Moduls.Sweet.DTO;
using Gudulion.BackEnd.Moduls.Sweet.Model;
using Microsoft.EntityFrameworkCore;

namespace Gudulion.BackEnd.Moduls.Sweet.Service;

public class SweetService : ISweetService
{
    private readonly MainDbContext _db;
    private readonly IMapper _mapper;

    public SweetService(MainDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public Model.Sweet CreateSweet(Request.Model.Request request)
    {
        var requestFromDb = _db.Sweets.FirstOrDefault(x => x.RequestId == request.Id);
        if (requestFromDb != null)
        {
            throw new Exception("Sweet already exists");
        }

        var sweet = new Model.Sweet();
        sweet.Title = request.Title;
        sweet.Occasion = request.Occasion;
        sweet.AddDate = DateTime.Now;
        sweet.Type = GetSweetType(request.RequestType);
        sweet.Status = SweetStatus.PendingForPay;
        sweet.TrackingCode = GenerateTrackingCode(request);
        sweet.RequestId = request.Id;
        _db.Sweets.Add(sweet);
        _db.SaveChanges();

        AddUserToSweet(new SweetUserMappingDto
        {
            UserId = request.ToUserId,
            IsPayer = true,
            Acceptance = SweetAcceptance.Accepted,
            SweetId = sweet.Id
        });
        return sweet;
    }

    private string GenerateTrackingCode(Request.Model.Request request)
    {
        var code = request.TrackingCode;
        switch (request.RequestType)
        {
            case RequestType.Shirini:
                code = code.Replace("RSH", "SH");
                break;
            case RequestType.Gheramat:
                code = code.Replace("RGH", "GH");

                break;
            case RequestType.Xorma:
                code = code.Replace("RX", "X");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return code;
    }


    public Model.Sweet ChangeStatus(SweetChangeStatusDto dto)
    {
        var sweet = _db.Sweets.FirstOrDefault(x => x.Id == dto.Id);
        sweet.Status = dto.NewStatus;
        if (dto.NewStatus == SweetStatus.Payed)
        {
            sweet.PayDate = DateTime.Now;
        }

        _db.SaveChanges();
        return sweet;
    }

    public void Survey(SweetSurveyDto dto)
    {
        var userSweetMapp =
            _db.UserSweetMappigns.FirstOrDefault(a => a.SweetId == dto.SweetId && a.UserId == dto.UserId);
        if (userSweetMapp != null)
        {
            userSweetMapp.Acceptance = dto.Acceptance;
            _db.SaveChanges();
        }
        else
        {
            throw new Exception("کاربر قبلا نظر داده است.");
        }
    }

    public void AddUserToSweet(List<SweetUserMappingDto> dtos)
    {
        // todo edit list of mapped does not work currently
        // because when user want to edit list this method does not work.
        // i should to edit this method to handel edit action 
        dtos.ForEach(dto => { AddUserToSweetCore(dto); });
        _db.SaveChanges();
    }

    public void AddUserToSweet(SweetUserMappingDto dto)
    {
        AddUserToSweetCore(dto);
        _db.SaveChanges();
    }

    public SweetWithAllData getById(int id)
    {
        var sweetWithAllData = new SweetWithAllData();
        var sweet = _db.Sweets.FirstOrDefault(x => x.Id == id);
        if (sweet == null)
        {
            throw new NotFoundException("Sweet not found");
        }

        sweetWithAllData = _mapper.Map<SweetWithAllData>(sweet);

        var userMappings = _db.UserSweetMappigns.Where(a => a.SweetId == id).Include(a => a.User).ToList();
        sweetWithAllData.Users = userMappings;
        var images = _db.Images.Where(a => a.EntityType == RelatedEntityType.Sweet && a.EntityId == id).ToList();
        sweetWithAllData.Images = images;
        return sweetWithAllData;
    }

    public List<Model.Sweet> GetAll()
    {
        return _db.Sweets.ToList();
    }


    private void AddUserToSweetCore(SweetUserMappingDto dto)
    {
        var obj = _db.UserSweetMappigns.FirstOrDefault(a => a.UserId == dto.UserId && a.SweetId == dto.SweetId);
        if (obj != null)
        {
            obj.IsPayer = dto.IsPayer;
            obj.Acceptance = dto.Acceptance;
        }
        else
        {
            var userSweetMapping = new UserSweetMapping
            {
                SweetId = dto.SweetId,
                UserId = dto.UserId,
                IsPayer = dto.IsPayer,
                Acceptance = dto.Acceptance
            };
            _db.UserSweetMappigns.Add(userSweetMapping);
        }
    }

    private SweetType GetSweetType(RequestType requestType)
    {
        switch (requestType)
        {
            case RequestType.Shirini:
                return SweetType.Shirini;
            case RequestType.Gheramat:
                return SweetType.Gheramat;

            case RequestType.Xorma:
                return SweetType.Xorma;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public interface ISweetService
{
    public Model.Sweet CreateSweet(Request.Model.Request request);
    public Model.Sweet ChangeStatus(SweetChangeStatusDto dto);
    public void Survey(SweetSurveyDto dto);

    public void AddUserToSweet(List<SweetUserMappingDto> dtos);
    public void AddUserToSweet(SweetUserMappingDto dto);
    public SweetWithAllData getById(int id);
    public List<Model.Sweet> GetAll();
}