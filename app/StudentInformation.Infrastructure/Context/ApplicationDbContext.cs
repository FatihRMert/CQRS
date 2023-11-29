using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using StudentInformation.Domain.Abstractions;
using StudentInformation.Domain.Students;
using StudentInformation.Domain.Teachers;

namespace StudentInformation.Infrastructure.Context;

public sealed class ApplicationDbContext: DbContext
{

    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;


    private readonly IPublisher publisher;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
        this.publisher = publisher;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries() ?? new List<EntityEntry>();

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var entry in entries)
        {
            if (entry.Entity is AggregateRoot aggregateRoot)
            {
                if(aggregateRoot.HasRaisedEvent())
                {
                    foreach (var domainEvent in aggregateRoot.Events)
                    {
                        Console.WriteLine($"Save Changes Entry Name {entry.Entity.GetType().Name}, DomainEventName: {domainEvent.GetType().Name}");
                        await publisher.Publish(domainEvent, cancellationToken);
                    }
                }
            }
        }

        return result;
    }
}


public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connection = "User ID=postgres;Password=password;Host=localhost;Port=5435;Database=cqrs;";
        optionsBuilder.UseNpgsql(connection, opt => opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                .UseSnakeCaseNamingConvention();

        return new ApplicationDbContext(optionsBuilder.Options, null!);
    }
}
