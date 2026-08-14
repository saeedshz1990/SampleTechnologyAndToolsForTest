using SampleTechnologyForTest.Entities.Entity.Categories;
using SampleTechnologyForTest.Entities.Entity.Orders;

namespace SampleTechnologyForTest.Entities.Entity.Products
{
    public class Product : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public List<OrderItem> OrderItems { get; set; } = [];

        private Product()
        {

        }

        private Product(string title, string description, long categoryId)
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
            InsertDate = DateTime.Now;
            IsDeleted = false;
        }

        public static Product Create(string title, string description, long categoryId)
        {
            return new Product(title, description, categoryId);
        }
    }
}
