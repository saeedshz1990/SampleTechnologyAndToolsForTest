namespace SampleTechnologyForTest.Entities.Entity.Countries
{
    public class Country : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;

        public List<Province> Provinces { get; set; } = [];


        private Country()
        {

        }

        private Country(string title, string countryCode)
        {
            Title = title;
            CountryCode = countryCode;
            UserId = Guid.NewGuid().ToString();
            InsertDate = DateTime.Now;
            IsDelete = false;
        }


        public static Country Create(string title, string countryCode)
        {
            return new Country(title, countryCode);
        }
    }
}
