namespace SampleTechnologyForTest.Entities.Entity.Countries
{
    public class City : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public long ProvinceId { get; set; }
        public Province Province { get; set; }

        private City()
        {

        }

        private City(string title, long provinceId)
        {
            Title = title;
            ProvinceId = provinceId;
            InsertDate = DateTime.Now;
            IsDeleted = false;
        }

        public static City Create(string title, long provinceId)
        {
            return new City(title, provinceId);
        }
    }
}
