namespace Query.Application.Articles.QueryResult
{
    public class ArticleQr
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public long ArticleCategoryId { get; set; }
    }
}
