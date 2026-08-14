namespace SampleTechnologyForTest.Entities.Entity.Articles
{
    public class Article : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public long ArticleCategoryId { get; set; }
        public ArticleCategory ArticleCategory { get; set; }

        private Article()
        {

        }

        private Article(string title, string body, string tag, string description, long articleCategory)
        {
            Title = title;
            Body = body;
            Tag = tag;
            Description = description;
            ArticleCategoryId = articleCategory;
            InsertDate = DateTime.Now;
            IsDeleted = false;
        }

        public static Article Create(string title, string body, string tag, string description, long articleCategory)
        {
            return new Article(title, body, tag, description, articleCategory);
        }
    }
}
