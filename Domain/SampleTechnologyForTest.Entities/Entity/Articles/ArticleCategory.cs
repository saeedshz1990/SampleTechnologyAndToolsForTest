namespace SampleTechnologyForTest.Entities.Entity.Articles
{
    public class ArticleCategory : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Article> Articles { get; set; } = [];

        private ArticleCategory()
        {
            
        }

        private ArticleCategory(string title,string description)
        {
            Title = title;
            Description = description;
            InsertDate = DateTime.Now;
            IsDeleted = false;
        }

        public static ArticleCategory Create(string title, string description)
        {
            return new ArticleCategory(title, description);
        }
    }
}
