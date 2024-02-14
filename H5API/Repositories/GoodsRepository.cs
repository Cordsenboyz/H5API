using H5API.Data;
using H5API.Models;
using H5API.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace H5API.Repositories
{
    public class GoodsRepository : BaseRepository<Goods, Guid, H5DbContext>
    {
        public GoodsRepository(H5DbContext context) : base(context) { }

        protected override DbSet<Goods> Set => _context.Goods;
    }
}
