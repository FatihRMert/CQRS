using StudentInformation.Application.Teachers.RecordNewStudent;
using StudentInformation.Application.Tests.FakeRepositories;
using StudentInformation.Application.Tests.Students;
using StudentInformation.Domain.Abstractions;
using StudentInformation.Domain.Abstractions.ValueObjects;
using StudentInformation.Domain.Students;
using StudentInformation.Domain.Teachers;

namespace StudentInformation.Application.Tests.Teachers.RecordNewStudent;

public class RecordNewStudentTests
{
    private readonly IStudentRepository studentRepository = new FakeStudentRepository();
    private readonly ITeacherRepository teacherRepository = new FakeTeacherRepository();
    private readonly IUnitOfWork unitOfWork = new FakeUnitOfWork();

    [Fact]
    public async Task Should_Raised_RecordedNewStudentEvent_When_Student_Created()
    {
        var command = new RecordNewStudentCommand(
            new StudentNumber("111111111111"),
            new FirstName("Test"),
            new FamilyName("Test")
        );

        var handler = new RecordNewStudentCommandHandler(
            teacherRepository, studentRepository, unitOfWork
        );

        var result = await handler.Handle(command, default);

        var student = await studentRepository.GetByIdAsync(result);

        Assert.NotNull(student);
        Assert.Single(student.Events);
        Assert.Equal(typeof(StudentCreatedEvent), student.Events.FirstOrDefault()!.GetType());

    }    
}
