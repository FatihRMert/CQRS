using MediatR;
using StudentInformation.Domain.Abstractions;
using StudentInformation.Domain.Abstractions.ValueObjects;
using StudentInformation.Domain.Students;
using StudentInformation.Domain.Teachers;

namespace StudentInformation.Application.Teachers.RecordNewStudent;

public sealed record RecordNewStudentCommand(
StudentNumber StudentNumber,
FirstName FirstName,
FamilyName FamilyName
): IRequest<StudentId>;

public class RecordNewStudentCommandHandler : IRequestHandler<RecordNewStudentCommand, StudentId>
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RecordNewStudentCommandHandler(ITeacherRepository teacherRepository, IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _teacherRepository = teacherRepository;
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<StudentId> Handle(RecordNewStudentCommand request, CancellationToken cancellationToken)
    {
        var number = request.StudentNumber;
        var firstName = request.FirstName;
        var familyName = request.FamilyName;

        var teacher = await _teacherRepository.GetByIdAsync(Teacher.DefaultTeacherId)
                    ?? throw new ApplicationException($"Teacher not found by {Teacher.DefaultTeacherId} id");

        var studentId = new StudentId(Guid.NewGuid());
        await teacher.RecordNewStudentAsync(
            _studentRepository,
            studentId, number, firstName, familyName
        );

        await _unitOfWork.CompleteAsync(cancellationToken);

        return studentId;
    }
}
