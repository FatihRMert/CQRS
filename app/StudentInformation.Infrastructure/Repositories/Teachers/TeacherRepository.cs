using Microsoft.EntityFrameworkCore;
using StudentInformation.Domain.Teachers;
using StudentInformation.Infrastructure.Context;

namespace StudentInformation.Infrastructure.Repositories.Teachers;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext dbContext;

    public TeacherRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<Teacher?> GetByIdAsync(TeacherId id)
    {
        return dbContext.Teachers
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
