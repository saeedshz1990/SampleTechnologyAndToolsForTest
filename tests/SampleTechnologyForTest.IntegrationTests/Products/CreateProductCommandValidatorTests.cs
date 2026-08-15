using Command.Application.Products.Dto.Create;
using Command.Application.Products.Service.Create;
using Xunit;

namespace SampleTechnologyForTest.IntegrationTests.Products
{
    public class CreateProductCommandValidatorTests
    {
        private readonly CreateProductCommandValidator _validator = new();

        [Fact]
        public async Task Validate_Should_Pass_When_Command_Is_Valid()
        {
            var command = new CreateProductCommand
            {
                Title = "Test Product",
                Description = "Test Description",
                CategoryId = 1
            };

            var result = await _validator.ValidateAsync(command);

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task Validate_Should_Fail_When_Title_Is_Empty()
        {
            var command = new CreateProductCommand
            {
                Title = string.Empty,
                Description = "Test Description",
                CategoryId = 1
            };

            var result = await _validator.ValidateAsync(command);

            Assert.False(result.IsValid);
            Assert.Contains(
                result.Errors,
                x => x.PropertyName == nameof(command.Title));
        }

        [Fact]
        public async Task Validate_Should_Fail_When_CategoryId_Is_Invalid()
        {
            var command = new CreateProductCommand
            {
                Title = "Test Product",
                Description = "Test Description",
                CategoryId = 0
            };

            var result = await _validator.ValidateAsync(command);

            Assert.False(result.IsValid);
            Assert.Contains(
                result.Errors,
                x => x.PropertyName == nameof(command.CategoryId));
        }
    }
}
