using Command.Application.Articles.Repository;
using Command.Persistence.Common;
using SampleTechnologyForTest.Entities.Entity.Articles;

namespace Command.Persistence.ArticleConfigs.Repository
{
    public class ArticleCategoryCommandRepository : IArticleCategoryCommandRepository
    {
        private readonly SampleCommandContext _context;

        public ArticleCategoryCommandRepository(SampleCommandContext context)
        {
            _context = context;
        }

        public void Create(ArticleCategory command, CancellationToken cancellationToken)
        {
            _context.ArticleCategories.Add(command);
        }

        public void Delete(ArticleCategory command)
        {
            _context.ArticleCategories.Remove(command);
        }

        public ArticleCategory? FindById(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(_ => _.Id == id);
        }

        public ArticleCategory? FindByTitle(string title)
        {
            return _context.ArticleCategories.FirstOrDefault(_ => _.Title.Contains(title.Trim()));
        }

        public void Update(ArticleCategory command)
        {
            _context.ArticleCategories.Update(command);
        }
    }
}