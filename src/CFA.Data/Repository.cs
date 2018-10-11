using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CFA.Service.Interfaces;
using System.Linq.Expressions;
using CFA.Infrastructure;
using CFA.Infrastructure.Extensions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CFA.Domain.Interfaces;

namespace CFA.Data
{
    public class Repository : IRepository
    {
        readonly DbContext _dbContext;

        public Repository() { }
       
        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }

            _dbContext = dbContext;
        }

        //public virtual IQueryable<T> GetAll<T>() where T : class
        //{
        //    return _dbContext.Set<T>();
        //}

        public int GetMaxValueBy<E>(Func<E, int> match) where E : class
        {
            try
            {
                int maximum = 0;
                DbSet<E> entities = _dbContext.Set<E>();

                if (entities != null && entities.Count() > 0)
                {
                    maximum = _dbContext.Set<E>().Max(match);
                }

                return maximum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IQueryable<T> GetAll<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (query != null && query.Count() > 0)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query;
        }
        //public virtual IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();
        //    foreach (var includeProperty in includeProperties)
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    return query;
        //}

        public T GetSingle<T>(int id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }
        public T GetSingle<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _dbContext.Set<T>().SingleOrDefault(predicate);
        }
        public T GetSingle<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (includeProperties.HasItem())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.SingleOrDefault(predicate);
        }

        public virtual IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public virtual PaginatedList<T> Paginate<TKey, T>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector) where T : class
        {
            return Paginate(pageIndex, pageSize, keySelector, null);
        }

        public virtual PaginatedList<T> Paginate<TKey, T>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            //IQueryable<T> query = AllIncluding(includeProperties).OrderBy(keySelector);

            IQueryable<T> query = GetAll(includeProperties).OrderBy(keySelector);
            query = (predicate == null) ? query : query.Where(predicate);
            return query.ToPaginatedList(pageIndex, pageSize);
        }

        public virtual void Add<T>(T entity) where T : class
        {
            //DbEntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
            _dbContext.Set<T>().Add(entity);
        }
        public virtual void AddRange<T>(IList<T> entities) where T : class
        {
            //DbEntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
            _dbContext.Set<T>().AddRange(entities);
        }

        public virtual void Update<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = _dbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = _dbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }
        public void Delete<E>(Func<E, bool> selector) where E : class
        {
            DbSet<E> dbSet = _dbContext.Set<E>();
            IEnumerable<E> records = from x in dbSet.Where<E>(selector) select x;

            foreach (E e in records)
            {
                if (_dbContext.Entry(e).State == EntityState.Detached)
                {
                    dbSet.Attach(e);
                }

                dbSet.Remove(e);
            }
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }



    }



}
