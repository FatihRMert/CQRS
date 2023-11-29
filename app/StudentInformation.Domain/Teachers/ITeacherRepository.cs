namespace StudentInformation.Domain.Teachers;

public interface ITeacherRepository
{
    Task<Teacher?> GetByIdAsync(TeacherId id);    
}
