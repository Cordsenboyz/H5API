using H5API.Data;
using H5API.Models;
using H5API.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace H5API.Repositories
{
    public class OrderRepository : BaseRepository<Order, Guid, H5DbContext>
    {
        public OrderRepository(H5DbContext context) : base(context) { }

        protected override DbSet<Order> Set => _context.Orders;

        public async Task<Order> GetWithRelationsAsnyc(Guid Id) => await Set
            .Include(order => order.User)
            .Include(order => order.Goods)
            .FirstOrDefaultAsync(order => order.Id == Id);

        public async Task<IEnumerable<Order>> GetAllByUser(Guid Id) => await Set.Where(order => order.User.Id == Id).ToListAsync(); 
    }
}
