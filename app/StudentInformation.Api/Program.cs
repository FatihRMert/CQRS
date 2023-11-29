using Microsoft.EntityFrameworkCore;
using StudentInformation.Api.Middlewares;
using StudentInformation.Application.Teachers.RecordNewStudent;
using StudentInformation.Domain.Abstractions;
using StudentInformation.Infrastructure;
using StudentInformation.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(x => 
{
    x.RegisterServicesFromAssemblies(
        typeof(RecordNewStudentCommand).Assembly, 
        typeof(AggregateRoot).Assembly,
        typeof(InfrastuructureDependency).Assembly);
});

builder.Services.AddInfrasturucture();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.Run();