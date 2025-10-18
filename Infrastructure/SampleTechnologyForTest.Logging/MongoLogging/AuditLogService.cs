using MongoDB.Bson;
using MongoDB.Driver;

namespace SampleTechnologyForTest.Logging.MongoLogging
{
    public class AuditLogService
    {
        private readonly IMongoCollection<BsonDocument> _collection;

        public AuditLogService(IMongoDatabase database)
        {
            _collection = database.GetCollection<BsonDocument>("AuditLogs");
        }
        public async Task LogChangeAsync<T>(
            string entityName,
            string entityId,
            string action,
            T? oldData,
            T? newData,
            string? performedBy = null)
        {
            var log = new BsonDocument
            {
                { "EntityName", entityName },
                { "EntityId", entityId },
                { "ActionType", action },
                { "Timestamp", DateTime.Now },
                { "PerformedBy", performedBy ?? "unknown" },
                { "OldValues", oldData != null ? oldData.ToBsonDocument() : BsonNull.Value },
                { "NewValues", newData != null ? newData.ToBsonDocument() : BsonNull.Value }
            };

            await _collection.InsertOneAsync(log);
        }
    }
}
