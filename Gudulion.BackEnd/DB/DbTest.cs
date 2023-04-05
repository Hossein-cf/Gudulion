using Gudulion.BackEnd.Test;
using NUnit.Framework;

namespace Gudulion.BackEnd.Test;

[TestFixture, Order(1)]
public class DbTest : TestGeneric
{
    [Test, Order(1)]
    public void DeleteDataBase()
    {
        _db.Database.EnsureDeleted();
    }

    [Test, Order(2)]
    public void CreateDataBase()
    {
        _db.Database.EnsureCreated();
    }
}