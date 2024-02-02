using H5API.Data;
using H5API.Models;
using H5API.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace H5API.Repositories
{
    public class CategoryRepository : BaseRepository<Category, Guid, H5DbContext>
    {
        public CategoryRepository(H5DbContext context) : base(context) { }

        protected override DbSet<Category> Set => _context.Categories;

        public async Task<IEnumerable<Category>> GetCategoriesWithinStore(Guid id) => await Set.Where(category => category.Store.Id == id).ToListAsync();

        public async Task<Category>? GetByObject(Category category) => await Set.FirstOrDefaultAsync(c => c.Name == category.Name);
    }
}
