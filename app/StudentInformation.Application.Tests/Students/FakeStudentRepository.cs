using StudentInformation.Domain.Students;

namespace StudentInformation.Application.Tests.Students;

public class FakeStudentRepository : IStudentRepository
{
    private readonly List<Student> students = new();
    public Task AddAsync(Student student)
    {
        students.Add(student);
        return Task.CompletedTask;
    }

    public Task<Student?> GetByIdAsync(StudentId id)
    {
        return Task.FromResult(students.FirstOrDefault(x => x.Id == id));
    }

    public Task<Student?> GetByNumberAsync(StudentNumber number)
    {
        return Task.FromResult(students.FirstOrDefault(x => x.Number == number));
    }
}
