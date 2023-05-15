using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Domain.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity entity);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        // This method takes a method as a parameter and calls the method.
        Task<TEntity> CustomSingleWithIncludes(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeMethod, Expression<Func<TEntity, bool>>? predicate = null);
        Task<IEnumerable<TEntity>> CustomManyWithIncludes(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeMethod, Expression<Func<TEntity, bool>>? predicate = null);

        DbSet<TEntity> Entity { get; }

    }
}
