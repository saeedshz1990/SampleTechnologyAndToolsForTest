using SampleTechnologyForTest.Entities.Entity.Articles;

namespace Command.Application.Articles.Repository
{
    public interface IArticleCategoryCommandRepository
    {
        void Create(ArticleCategory command, CancellationToken cancellationToken);
        void Update(ArticleCategory command);
        void Delete(ArticleCategory command);
        ArticleCategory? FindById(long id);
        ArticleCategory? FindByTitle(string title);
    }
}
