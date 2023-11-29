using Microsoft.EntityFrameworkCore;
using StudentInformation.Domain.Students;
using StudentInformation.Infrastructure.Context;

namespace StudentInformation.Infrastructure.Repositories.Students;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext dbContext;

    public StudentRepository(ApplicationDbContext applicationDbContext)
    {
        dbContext = applicationDbContext;
    }

    public async Task AddAsync(Student student)
    {
        await dbContext.Students.AddAsync(student);
    }

    public Task<Student?> GetByIdAsync(StudentId id)
    {
        return dbContext.Students
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Student?> GetByNumberAsync(StudentNumber number)
    {
        return dbContext.Students
            .FirstOrDefaultAsync(x => x.Number == number);
    }
}
