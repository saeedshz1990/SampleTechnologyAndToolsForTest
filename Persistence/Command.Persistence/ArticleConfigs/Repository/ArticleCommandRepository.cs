using Command.Application.Articles.Repository;
using Command.Persistence.Common;
using SampleTechnologyForTest.Entities.Entity.Articles;

namespace Command.Persistence.ArticleConfigs.Repository
{
    public class ArticleCommandRepository : IArticleCommandRepository
    {
        private readonly SampleCommandContext _context;

        public ArticleCommandRepository(SampleCommandContext context)
        {
            _context = context;
        }

        public void Create(Article command, CancellationToken cancellationToken)
        {
            _context.Articles.AddAsync(command, cancellationToken);
        }

        public void Delete(Article command)
        {
            _context.Articles.Remove(command);
        }

        public Article? FindById(long id)
        {
            return _context.Articles.FirstOrDefault(_ => _.Id == id);
        }

        public Article? FindByTitle(string title)
        {
            return _context.Articles.FirstOrDefault(_ => _.Title.Contains(title));
        }

        public void Update(Article command)
        {
            _context.Articles.Update(command);
        }
    }
}
