using Command.Application;
using Command.Persistence.Common;
using Microsoft.EntityFrameworkCore.Storage;
using SampleTechnologyForTest.Entities.Entity.Outbox;

namespace SampleTechnologyForTest.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleCommandContext _context;
        private IDbContextTransaction? _currentTransaction;

        public UnitOfWork( SampleCommandContext context)
        {
            _context = context;
        }

        public bool HasActiveTransaction => _currentTransaction != null;

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction != null)
                return;

            _currentTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction == null)
                throw new InvalidOperationException("No active transaction to commit.");

            try
            {
                await _currentTransaction.CommitAsync(cancellationToken);
            }
            finally
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_currentTransaction == null)
                return;

            await _currentTransaction.RollbackAsync();
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAndCommitAsync(CancellationToken cancellationToken = default)
        {
            await BeginTransactionAsync(cancellationToken);

            try
            {
                var result = await SaveChangesAsync(cancellationToken);

                await CommitTransactionAsync(cancellationToken);

                return result;
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        public async Task AddOutboxMessageAsync(OutboxMessage message,CancellationToken cancellationToken = default)
        {
            await _context.OutboxMessages.AddAsync(message,cancellationToken);
        }
    }
}
