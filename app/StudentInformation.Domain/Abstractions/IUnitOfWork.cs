namespace StudentInformation.Domain.Abstractions;

public interface IUnitOfWork
{
    Task CompleteAsync(CancellationToken cancellationToken = default);
}
