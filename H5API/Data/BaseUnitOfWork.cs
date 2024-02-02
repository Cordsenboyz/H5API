using Microsoft.EntityFrameworkCore;

namespace H5API.Data
{
    public abstract class BaseUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        /// <param name="context">ApplicationDbContext</param>
        public BaseUnitOfWork(TDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// DbContext
        /// </summary>
        protected TDbContext Context { get; }

        /// <inheritdoc/>
        public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();
    }
}
