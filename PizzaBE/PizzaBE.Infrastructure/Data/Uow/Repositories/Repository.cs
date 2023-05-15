using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PizzaBE.Domain.Base;
using PizzaBE.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Infrastructure.Data.Uow.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;
        protected IMemoryCache _memoryCache; //should be private.


        //        private ILogger<Repository<TEntity>> _logger;

        public Repository(ApplicationDbContext context, IMemoryCache memoryCache)
        {
            Context = context;
            _memoryCache = memoryCache;
            Entity = Context.Set<TEntity>();
            //           _logger = logger;
        }
        public DbSet<TEntity> Entity { get; private set; }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);

        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync() > 0);
        }
        public async Task<TEntity> CustomSingleWithIncludes(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeMethod, Expression<Func<TEntity, bool>>? predicate)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            query = includeMethod(query);
            if (predicate == null)
                return await query.SingleOrDefaultAsync();

            return await query.SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> CustomManyWithIncludes(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeMethod, Expression<Func<TEntity, bool>>? predicate)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            query = includeMethod(query);
            if (predicate == null)
                return await query.ToListAsync();

            return await query.Where(predicate).ToListAsync();
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        #region Caching 

        internal void AddToCache(string cachKey, object departments)
        {
            var opts = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(6)
            };

            _memoryCache.Set(cachKey, departments, opts);
        }

        internal bool GetCachedValue(string cacheKey, out object value)
        {
            return _memoryCache.TryGetValue(cacheKey, out value);
        }

        internal void ClearCache(string keyPattern)
        {
            _memoryCache.Remove(keyPattern);
            _memoryCache.Remove("maingPageCachedData");
            _memoryCache.Remove("maingPageCachedData");
        }

       

        #endregion Caching
    }
}
