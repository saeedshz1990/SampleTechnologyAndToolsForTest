using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SampleTechnologyForTest.Logging.MongoLogging;

namespace Command.Persistence.Interceptors
{
    public class AuditLogInterceptor : SaveChangesInterceptor
    {
        private readonly AuditLogService _auditLog;

        public AuditLogInterceptor(AuditLogService auditLog)
        {
            _auditLog = auditLog;
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            if (context == null)
            {
                return await base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            var entries = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || 
                            e.State == EntityState.Added || 
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in entries)
            {
                var entityName = entry.Entity.GetType().Name;
                var entityId = entry.Properties
                    .FirstOrDefault(p => p.Metadata.IsPrimaryKey())?
                    .CurrentValue?.ToString();

                object? oldValues = null;
                object? newValues = null;
                string action = "";

                switch (entry.State)
                {
                    case EntityState.Added:
                        action = "Insert";
                        newValues = entry.CurrentValues.ToObject();
                        break;
                    case EntityState.Modified:
                        action = "Update";
                        oldValues = entry.OriginalValues.ToObject();
                        newValues = entry.CurrentValues.ToObject();
                        break;
                    case EntityState.Deleted:
                        action = "Delete";
                        oldValues = entry.OriginalValues.ToObject();
                        break;
                }

                await _auditLog.LogChangeAsync(
                    entityName,
                    entityId ?? "N/A",
                    action,
                    oldValues,
                    newValues,
                    "system" // یا از Context بگیر
                );
            }

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
