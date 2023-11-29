using StudentInformation.Domain.Abstractions;
using StudentInformation.Domain.Abstractions.ValueObjects;
using StudentInformation.Domain.Students;

namespace StudentInformation.Domain.Teachers;

public class Teacher: AggregateRoot
{
    public static readonly TeacherId DefaultTeacherId = new(Guid.Parse("8df7e8ac-7b8f-4b84-8ac8-7b0e3108c243"));
    public TeacherId Id { get; private set; }

    public FirstName FirstName { get; private set; }
    public FamilyName FamilyName { get; private set; }

    public Teacher(TeacherId id, FirstName firstName, FamilyName familyName)
    {
        Id = id;
        FirstName = firstName;
        FamilyName = familyName;
    }

    public async Task RecordNewStudentAsync(
        IStudentRepository studentRepository,
        StudentId id, StudentNumber number,
        FirstName firstName, FamilyName familyName
    )
    {
        var isExistStudentWithNumber = await studentRepository.GetByNumberAsync(number);
        if(isExistStudentWithNumber != null)
        {
            throw new ApplicationException($"Already exist student with number, {number?.Value}");
        }

        var student = Student.Create(id, number, firstName, familyName);

        await studentRepository.AddAsync(student);
    }
}
