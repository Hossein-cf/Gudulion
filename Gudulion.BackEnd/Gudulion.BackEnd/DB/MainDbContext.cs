using Gudulion.BackEnd.Moduls.User;
using Microsoft.EntityFrameworkCore;

namespace Gudulion.BackEnd.DB;

public class MainDbContext:DbContext
{
    public DbSet<User> Users { get; set; }
    public MainDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Gudulion;Integrated Security=True");

    }
}