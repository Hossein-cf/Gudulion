using AutoMapper;
using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Exceptions;
using Gudulion.BackEnd.Moduls.Comment.DTO;
using Gudulion.BackEnd.Moduls.Comment.Model;
using Gudulion.BackEnd.Moduls.Comment.Service;
using Gudulion.BackEnd.Moduls.Trip.DTO;
using Gudulion.BackEnd.Moduls.Trip.Model;

namespace Gudulion.BackEnd.Moduls.Trip.Service;

public class TripService : ITripService
{
    private MainDbContext _db;
    private ICommentService _commentService;
    private readonly IMapper _mapper;

    public TripService(MainDbContext db, ICommentService commentService, IMapper mapper)
    {
        _db = db;
        _commentService = commentService;
        _mapper = mapper;
    }

    public Trip.Model.Trip Create(AddTripDto dto)
    {
        var trip = _mapper.Map<Trip.Model.Trip>(dto);
        trip.Status = TripStatus.Created;
        _db.Trips.Add(trip);
        _db.SaveChanges();
        return trip;
    }

    public void AddUserToTrip(List<AddUserToTripDto> dtos)
    {
        dtos.ForEach(dto =>
        {
            var obj = _mapper.Map<UserTripMapping>(dto);
            _db.UserTripMappings.Add(obj);
        });
        _db.SaveChanges();
    }

    public void ChangeTripStatus(ChangeTripStatusDto dto)
    {
        var tripFromDb = _db.Trips.FirstOrDefault(x => x.Id == dto.TripId);
        if (tripFromDb == null)
        {
            throw new NotFoundException("Trip not found");
        }

        tripFromDb.Status = dto.NewStatus;
        if (dto.NewStatus == TripStatus.Started)
        {
            tripFromDb.StartDate = DateTime.Now;
        }
        else if (dto.NewStatus == TripStatus.Finished)
        {
            tripFromDb.EndDate = DateTime.Now;
        }

        _db.SaveChanges();
    }

    public Comment.Model.Comment AddComment(AddOrUpDateCommentDTO dto)
    {
        dto.EntityType = CommentEntityType.Trip;
        var comment = _commentService.Add(dto);
        return comment;
    }
}

public interface ITripService
{
    public Comment.Model.Comment AddComment(AddOrUpDateCommentDTO dto);
    public Trip.Model.Trip Create(AddTripDto dto);
    public void AddUserToTrip(List<AddUserToTripDto> dtos);
    public void ChangeTripStatus(ChangeTripStatusDto dto);
}