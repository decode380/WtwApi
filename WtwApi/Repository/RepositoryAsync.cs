using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using WtwApi.Context;
using WtwApi.Interfaces;

namespace WtwApi.Repository
{
    public class RepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly WtwDbContext _dbContext;

        public RepositoryAsync(WtwDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
