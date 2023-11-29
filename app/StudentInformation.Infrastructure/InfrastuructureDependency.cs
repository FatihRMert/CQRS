using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentInformation.Application.Abstractions;
using StudentInformation.Domain.Abstractions;
using StudentInformation.Domain.Students;
using StudentInformation.Domain.Teachers;
using StudentInformation.Infrastructure.Context;
using StudentInformation.Infrastructure.EventHandlers;
using StudentInformation.Infrastructure.Repositories;
using StudentInformation.Infrastructure.Repositories.Students;
using StudentInformation.Infrastructure.Repositories.Teachers;

namespace StudentInformation.Infrastructure;

public static class InfrastuructureDependency
{
    public static void AddInfrasturucture(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(x =>
        {
            var connection = "User ID=postgres;Password=password;Host=cqrs_writer_db;Port=5432;Database=cqrs;";
            x.UseNpgsql(connection, opt => opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<IDomainEventHandler, DomainEventHandler>();
    }
}
