namespace Command.Application
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync();

        bool HasActiveTransaction { get; }

        Task<int> SaveChangesAndCommitAsync(CancellationToken cancellationToken = default);
    }
}
