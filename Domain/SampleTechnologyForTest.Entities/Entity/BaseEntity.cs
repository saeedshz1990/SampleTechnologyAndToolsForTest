using System.ComponentModel.DataAnnotations.Schema;

namespace SampleTechnologyForTest.Entities.Entity
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
        [Column("IsDelete")]
        public bool IsDeleted { get; set; } = false;
        public string? UserId { get; set; }
    }
}
