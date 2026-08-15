using SampleTechnologyForTest.Entities.Entity.Products;
using Xunit;

namespace SampleTechnologyForTest.IntegrationTests.Products
{
    public class ProductTests
    {
        [Fact]
        public void Create_Should_Create_Product_With_Expected_Values()
        {
            // Arrange
            const string title = "Test Product";
            const string description = "Test Description";
            const long categoryId = 1;

            // Act
            var product = Product.Create(
                title,
                description,
                categoryId);

            // Assert
            Assert.Equal(title, product.Title);
            Assert.Equal(description, product.Description);
            Assert.Equal(categoryId, product.CategoryId);
            Assert.False(product.IsDeleted);
        }
    }
}
