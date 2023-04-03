using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Moduls.Sweet.DTO;
using Gudulion.BackEnd.Moduls.Sweet.Model;

namespace Gudulion.BackEnd.Moduls.Sweet.Service;

public class SweetService : ISweetService
{
    private readonly MainDbContext _context;

    public SweetService(MainDbContext context)
    {
        _context = context;
    }

    public Model.Sweet CreateSweet(Request.Model.Request request)
    {
        var sweet = new Model.Sweet();
        sweet.Title = request.Title;
        sweet.Occasion = request.Occasion;
        sweet.AddDate = new DateTime();
        sweet.Type = GetSweetType(request.RequestType);
        sweet.Status = SweetStatus.PendingForPay;
        _context.Sweets.Add(sweet);
        _context.SaveChanges();
        return sweet;
    }

    public Model.Sweet ChangeStatus(SweetChangeStatusDto dto)
    {
        var sweet = _context.Sweets.FirstOrDefault(x => x.Id == dto.Id);
        sweet.Status = dto.NewStatus;
        if (dto.NewStatus == SweetStatus.Payed)
        {
            sweet.PayDate = new DateTime();
        }

        _context.SaveChanges();
        return sweet;
    }

    public void Survey(SweetSurveyDto dto)
    {
        var userSweetMapp =
            _context.UserSweetMappigns.FirstOrDefault(a => a.SweetId == dto.SweetId && a.UserId == dto.UserId);
        if (userSweetMapp != null)
        {
            userSweetMapp.Acceptance = dto.Acceptance;
            _context.SaveChanges();
        }
    }

    public void AddUserToSweet(List<SweetUserMappingDto> dtos)
    {
        dtos.ForEach(a =>
        {
            var userSweetMapping = new UserSweetMapping
            {
                SweetId = a.SweetId,
                UserId = a.UserId,
                IsPayer = a.IsPayer,
                Acceptance = a.Acceptance
            };
            _context.UserSweetMappigns.Add(userSweetMapping);
        });
        _context.SaveChanges();
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
}