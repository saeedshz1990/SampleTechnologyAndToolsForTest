using Command.Application.Categories.Repository;
using Command.Persistence.Common;
using SampleTechnologyForTest.Entities.Entity.Categories;

namespace Command.Persistence.CategoryConfigs.Repository
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        private readonly SampleCommandContext _context;

        public CategoryCommandRepository(SampleCommandContext context)
        {
            _context = context;
        }

        public void Create(Category command, CancellationToken cancellationToke)
        {
            _context.Categories.AddAsync(command, cancellationToke);
        }

        public void Delete(Category command)
        {
            _context.Categories.Remove(command);
        }

        public Category? FindByTitle(string title)
        {
            return _context.Categories.FirstOrDefault(_ => _.Title.Contains(title));
        }

        public Category? FindById(long categoryId)
        {
            return _context.Categories.FirstOrDefault(_ => _.Id == categoryId);
        }

        public void Update(Category command)
        {
            _context.Categories.Update(command);
        }
    }
}