namespace StudentInformation.Domain.Students;

public interface IStudentRepository
{
    Task AddAsync(Student student);
    Task<Student?> GetByNumberAsync(StudentNumber number);
    Task<Student?> GetByIdAsync(StudentId id);
}