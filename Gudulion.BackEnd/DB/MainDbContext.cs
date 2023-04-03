using Gudulion.BackEnd.Moduls.Comment;
using Gudulion.BackEnd.Moduls.Comment.Model;
using Gudulion.BackEnd.Moduls.Image;
using Gudulion.BackEnd.Moduls.Image.Model;
using Gudulion.BackEnd.Moduls.Request;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Moduls.Sweet;
using Gudulion.BackEnd.Moduls.Sweet.Model;
using Gudulion.BackEnd.Moduls.Transaction;
using Gudulion.BackEnd.Moduls.Transaction.Model;
using Gudulion.BackEnd.Moduls.Trip;
using Gudulion.BackEnd.Moduls.Trip.Model;
using Gudulion.BackEnd.Moduls.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gudulion.BackEnd.DB;

public class MainDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<UserRequestMapping> RequestMappings { get; set; }
    public DbSet<Moduls.Sweet.Model.Sweet> Sweets { get; set; }
    public DbSet<UserSweetMapping> UserSweetMappigns { get; set; }
    public DbSet<TransactionItem> TransactionItems { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Trip> Trips { get; set; }


    public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
    {
        // Database.Migrate();
        Database.EnsureCreated();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Request>().HasOne(a => a.FromUser).WithMany().HasForeignKey(a => a.FromUserId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Request>().HasOne(a => a.ToUser).WithMany().HasForeignKey(a => a.FromUserId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder
            .Entity<User>()
            .Property(d => d.Role)
            .HasConversion(new EnumToStringConverter<Role>());
        modelBuilder
            .Entity<User>()
            .Property(d => d.Gender)
            .HasConversion(new EnumToStringConverter<Gender>());
        modelBuilder
            .Entity<Image>()
            .Property(d => d.RelatedEntityType)
            .HasConversion(new EnumToStringConverter<RelatedEntityType>());
    }
}