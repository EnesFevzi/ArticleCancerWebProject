using ArticleCancer.Application.Interfaces.Repositories;
using ArticleCancer.Persistence.Context;
using ArticleCancer.Persistence.Repositories;

namespace ArticleCancer.Persistence.UnıtOfWorks
{
    public class UnitOfWork : IUnıtOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }


        IRepository<T> IUnıtOfWork.GetRepository<T>()
        {
            return new Repository<T>(_dbContext);
        }
    }
}
