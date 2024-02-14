using H5API.Data;
using H5API.Models;
using H5API.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace H5API.Repositories
{
    public class StoreRepository : BaseRepository<Store, Guid, H5DbContext>
    {
        public StoreRepository(H5DbContext context) : base(context) { }

        protected override DbSet<Store> Set => _context.Stores;

        public async Task<Store>? GetWithAllRelations(Guid Id) => await Set
            .Include(store => store.Categories).ThenInclude(x => x.Goods)
            .FirstOrDefaultAsync(store => store.Id == Id);

        public async Task<IEnumerable<Store>> GetAllWithAllRelations() => await Set
            .Include(store => store.Categories)
            .ToListAsync();
    }
}
