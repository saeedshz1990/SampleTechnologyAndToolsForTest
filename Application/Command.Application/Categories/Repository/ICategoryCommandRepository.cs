using SampleTechnologyForTest.Entities.Entity.Categories;

namespace Command.Application.Categories.Repository
{
    public interface ICategoryCommandRepository
    {
        void Create(Category command, CancellationToken cancellationToke);
        void Update(Category command);
        void Delete(Category command);
        
        Category? FindByTitle(string title);
        Category? FindById(long categoryId);
    }
}
