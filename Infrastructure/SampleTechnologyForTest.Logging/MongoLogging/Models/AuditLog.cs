using MongoDB.Bson;

namespace SampleTechnologyForTest.Logging.MongoLogging.Models
{
    public class AuditLog
    {
        public long Id { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public string EntityId { get; set; } = string.Empty;
        public string ActionType { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public BsonDocument? OldValues { get; set; }
        public BsonDocument? NewValues { get; set; }
        public string? PerformedBy { get; set; }
    }
}
