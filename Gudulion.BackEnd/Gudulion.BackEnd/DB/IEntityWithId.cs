
namespace Gudulion.BackEnd.DB;
public interface IBaseEntity
{
}

public interface IEntityWithId : IBaseEntity
{
    public int Id { get; set; }
}