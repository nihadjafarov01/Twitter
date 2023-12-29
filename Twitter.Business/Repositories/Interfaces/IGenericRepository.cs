using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Twitter.Core.Entities.Common;

namespace Twitter.Business.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        IQueryable<T> GetAll(bool notTracking = true);
        Task<bool> isExistAsync(Expression<Func<T, bool>> expression);
    }
}
