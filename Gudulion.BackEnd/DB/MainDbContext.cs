using Gudulion.BackEnd.Moduls.Comment.Model;
using Gudulion.BackEnd.Moduls.Image.Model;
using Gudulion.BackEnd.Moduls.Request.Model;
using Gudulion.BackEnd.Moduls.Sweet.Model;
using Gudulion.BackEnd.Moduls.Transaction.Model;
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
    public DbSet<UserRequestMapping> UserRequestMappings { get; set; }
    public DbSet<Moduls.Sweet.Model.Sweet> Sweets { get; set; }
    public DbSet<UserSweetMapping> UserSweetMappigns { get; set; }
    public DbSet<TransactionItem> TransactionItems { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<UserTripMapping> UserTripMappings { get; set; }


    public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
    {
        // Database.Migrate();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Request>().HasOne(a => a.FromUser).WithMany().HasForeignKey(a => a.FromUserId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Request>().HasOne(a => a.ToUser).WithMany().HasForeignKey(a => a.ToUserId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder
            .Entity<Request>()
            .Property(d => d.RequestStatus)
            .HasConversion(new EnumToStringConverter<RequestStatus>());
        modelBuilder
            .Entity<Request>()
            .Property(d => d.RequestType)
            .HasConversion(new EnumToStringConverter<RequestType>());

        modelBuilder
            .Entity<UserRequestMapping>()
            .Property(d => d.RequestStatus)
            .HasConversion(new EnumToStringConverter<RequestStatus>());

        modelBuilder
            .Entity<UserRequestMapping>().HasOne<Request>().WithMany().HasForeignKey(a => a.RequestId);

        modelBuilder
            .Entity<UserRequestMapping>().HasOne<User>().WithMany().HasForeignKey(a => a.UserId);


        modelBuilder
            .Entity<Comment>()
            .Property(d => d.CommentEntityType)
            .HasConversion(new EnumToStringConverter<CommentEntityType>());


        modelBuilder
            .Entity<Moduls.Sweet.Model.Sweet>()
            .Property(d => d.Status)
            .HasConversion(new EnumToStringConverter<SweetStatus>());
        modelBuilder
            .Entity<UserSweetMapping>()
            .Property(d => d.Acceptance)
            .HasConversion(new EnumToStringConverter<SweetAcceptance>());


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
            .Property(d => d.EntityType)
            .HasConversion(new EnumToStringConverter<RelatedEntityType>());

        modelBuilder
            .Entity<Trip>()
            .Property(d => d.Status)
            .HasConversion(new EnumToStringConverter<TripStatus>());
        modelBuilder
            .Entity<UserTripMapping>()
            .HasOne<User>().WithMany().HasForeignKey(a => a.UserId);
        modelBuilder
            .Entity<UserTripMapping>()
            .HasOne<Trip>().WithMany().HasForeignKey(a => a.TripId);

        modelBuilder
            .Entity<Transaction>()
            .Property(a => a.TransactionStatus
            ).HasConversion(new EnumToStringConverter<TransactionStatus>());
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}