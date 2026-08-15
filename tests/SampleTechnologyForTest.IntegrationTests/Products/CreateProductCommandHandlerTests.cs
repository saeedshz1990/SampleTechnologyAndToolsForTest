using Command.Application;
using Command.Application.Products.Dto.Create;
using Command.Application.Products.Repository;
using Command.Application.Products.Service.Create;
using Moq;
using SampleTechnologyForTest.Entities.Entity.Outbox;
using SampleTechnologyForTest.Entities.Entity.Products;
using Xunit;

namespace SampleTechnologyForTest.IntegrationTests.Products
{
    public class CreateProductCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Create_Product_And_Save_Outbox_Message()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IProductCommandRepository>();

            Product? createdProduct = null;
            OutboxMessage? createdOutboxMessage = null;

            repositoryMock
                .Setup(x => x.Create(
                    It.IsAny<Product>(),
                    It.IsAny<CancellationToken>()))
                .Callback<Product, CancellationToken>((product, _) =>
                {
                    createdProduct = product;
                })
                .Returns(Task.CompletedTask);

            unitOfWorkMock
                .Setup(x => x.AddOutboxMessageAsync(
                    It.IsAny<OutboxMessage>(),
                    It.IsAny<CancellationToken>()))
                .Callback<OutboxMessage, CancellationToken>((message, _) =>
                {
                    createdOutboxMessage = message;
                })
                .Returns(Task.CompletedTask);

            unitOfWorkMock
                .Setup(x => x.SaveChangesAndCommitAsync(
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new CreateProductCommandHandler(
                unitOfWorkMock.Object,
                repositoryMock.Object);

            var command = new CreateProductCommand
            {
                Title = "Test Product",
                Description = "Test Description",
                CategoryId = 1
            };

            // Act
            var result = await handler.Handle(
                command,
                CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);

            Assert.NotNull(createdProduct);
            Assert.Equal(command.Title, createdProduct.Title);
            Assert.Equal(command.Description, createdProduct.Description);
            Assert.Equal(command.CategoryId, createdProduct.CategoryId);

            Assert.NotNull(createdOutboxMessage);
            Assert.Equal("ProductCreatedEvent", createdOutboxMessage.Type);
            Assert.False(string.IsNullOrWhiteSpace(createdOutboxMessage.Payload));

            repositoryMock.Verify(
                x => x.Create(
                    It.IsAny<Product>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            unitOfWorkMock.Verify(
                x => x.AddOutboxMessageAsync(
                    It.IsAny<OutboxMessage>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            unitOfWorkMock.Verify(
                x => x.SaveChangesAndCommitAsync(
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
