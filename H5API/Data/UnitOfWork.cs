using H5API.Models;
using H5API.Repositories;
using H5API.Repositories.Base;

namespace H5API.Data
{
    public class UnitOfWork : BaseUnitOfWork<H5DbContext>
    {
        public UnitOfWork(H5DbContext context) : base(context)
        {
            Stores = new(context);
            Categories = new(context);
            Orders = new(context);
            Goods = new(context);
        }

        public StoreRepository Stores { get; set; }
        public CategoryRepository Categories { get; set; }
        public OrderRepository Orders { get; set; }
        public GoodsRepository Goods { get; set; }
    }
}
