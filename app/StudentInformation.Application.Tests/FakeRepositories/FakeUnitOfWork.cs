using StudentInformation.Domain.Abstractions;

namespace StudentInformation.Application.Tests.FakeRepositories;

public class FakeUnitOfWork : IUnitOfWork
{
    public Task CompleteAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
