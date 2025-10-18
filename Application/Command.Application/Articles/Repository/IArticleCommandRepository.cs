using SampleTechnologyForTest.Entities.Entity.Articles;

namespace Command.Application.Articles.Repository
{
    public interface IArticleCommandRepository
    {
        void Create(Article command, CancellationToken cancellationToken);
        void Update(Article command);
        void Delete(Article command);
        Article? FindByTitle(string title);
        Article? FindById(long id);
    }
}
