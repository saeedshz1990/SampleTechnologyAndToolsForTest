namespace SampleTechnologyForTest.Entities.Events.Products
{
    public record ProductCreatedEvent(
        long ProductId,
        string Title,
        string Description,
        long CategoryId);
}
