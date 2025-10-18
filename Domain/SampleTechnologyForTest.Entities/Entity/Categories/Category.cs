using SampleTechnologyForTest.Entities.Entity.Products;

namespace SampleTechnologyForTest.Entities.Entity.Categories
{
    public class Category : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public List<Product> Products { get; set; } = [];

        private Category() { }
        private Category(string title, string description)
        {
            Title = title;
            Description = description;
            UserId = Guid.NewGuid().ToString();
            InsertDate = DateTime.Now;
            IsDelete = false;
        }

        public static Category Create(string title, string description)
        {
            return new Category(title, description);
        }
    }
}
