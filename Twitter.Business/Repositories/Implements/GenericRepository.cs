using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Core.Entities.Common;
using Twitter.DAL.Contexts;

namespace Twitter.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        TwitterContext _context {  get; }

        public GenericRepository(TwitterContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool notTracking = true)
            => notTracking ? Table.AsNoTracking() : Table;

        public async Task<bool> IsExistAsync()
        {
            return await Table.AnyAsync();
        }

        public async Task<bool> isExistAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.AnyAsync(); 
        }
    }
}
