namespace Query.Application.Products.QueryResult
{
    public class ProductQr
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long CategoryId { get; set; }
    }
}
