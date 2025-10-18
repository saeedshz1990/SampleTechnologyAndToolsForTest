namespace SampleTechnologyForTest.Entities.Entity
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public bool IsDelete { get; set; } = false;
        public string? UserId { get; set; } = "-1";
    }
}
