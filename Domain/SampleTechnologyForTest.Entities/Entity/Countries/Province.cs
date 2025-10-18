namespace SampleTechnologyForTest.Entities.Entity.Countries
{
    public class Province : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public long CountryId { get; set; }
        public Country Country { get; set; }

        public List<City> Cities { get; set; } = [];

        private Province()
        {

        }

        private Province(string title, long countryId)
        {
            Title = title;
            CountryId = countryId;
            UserId = Guid.NewGuid().ToString();
            InsertDate = DateTime.Now;
            IsDelete = false;
        }

        public static Province Create(string title, long countryId)
        {
            return new Province(title, countryId);
        }
    }
}
