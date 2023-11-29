using StudentInformation.Domain.Abstractions.ValueObjects;
using StudentInformation.Domain.Teachers;

namespace StudentInformation.Application.Tests.FakeRepositories;

public class FakeTeacherRepository : ITeacherRepository
{
    private readonly List<Teacher> teachers = new();

    public FakeTeacherRepository()
    {
        teachers.Add(new Teacher(Teacher.DefaultTeacherId, new FirstName("Test Name"), new FamilyName("Test Family Name")));
    }

    public Task<Teacher?> GetByIdAsync(TeacherId id)
    {
        return Task.FromResult(teachers.FirstOrDefault(x => x.Id == id));
    }
}
