using StudentInformation.Domain.Abstractions;
using StudentInformation.Domain.Abstractions.ValueObjects;

namespace StudentInformation.Domain.Students;

public class Student: AggregateRoot
{
    public StudentId Id { get; private set; }

    public StudentNumber Number { get; private set; }

    public FirstName FirstName { get; private set; }
    public FamilyName FamilyName { get; private set; }


    private Student() 
    {
        Id = null!;
        Number = null!;
        FirstName = null!;
        FamilyName = null!;
    }
    
    private Student(StudentId id, StudentNumber number, FirstName firstName, FamilyName familyName)
    {
        Id = id ?? throw new ApplicationException("Student id is required");
        Number = number ?? throw new ApplicationException("Student number is required");
        FirstName = firstName ?? throw new ApplicationException("Student first name is required");
        FamilyName = familyName ?? throw new ApplicationException("Student family name is required");
    }

    internal static Student Create(
        StudentId id, StudentNumber number,
        FirstName firstName, FamilyName familyName
    )
    {
        var student = new Student(id, number, firstName, familyName);

        student.RaiseEvent(new StudentCreatedEvent(id, number, firstName, familyName));

        return student;
    }
}
