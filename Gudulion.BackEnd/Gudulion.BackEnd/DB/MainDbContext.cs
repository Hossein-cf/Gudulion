using Gudulion.BackEnd.Moduls.Comment;
using Gudulion.BackEnd.Moduls.Image;
using Gudulion.BackEnd.Moduls.Request;
using Gudulion.BackEnd.Moduls.Sweet;
using Gudulion.BackEnd.Moduls.Transaction;
using Gudulion.BackEnd.Moduls.Trip;
using Gudulion.BackEnd.Moduls.User;
using Microsoft.EntityFrameworkCore;

namespace Gudulion.BackEnd.DB;

public class MainDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Sweet> Sweets { get; set; }
    public DbSet<TransactionItem> TransactionItems { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Trip> Trips { get; set; }

    public MainDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Gudulion;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Request>().HasOne(a => a.FromUser).WithMany().HasForeignKey(a=>a.FromUserId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Request>().HasOne(a => a.ToUser).WithMany().HasForeignKey(a=>a.FromUserId).OnDelete(DeleteBehavior.NoAction);
    }
}