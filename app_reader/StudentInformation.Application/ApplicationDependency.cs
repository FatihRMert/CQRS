using Microsoft.Extensions.DependencyInjection;
using StudentInformation.Application.Repositories;

namespace StudentInformation.Application;

public static class ApplicationDependency
{
    public static void AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ApplicationDependency).Assembly));

        services.AddSingleton<StudentRepository>();
    }
}
