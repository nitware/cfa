using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using CFA.Infrastructure;
using CFA.Domain.Interfaces;

namespace CFA.Service.Interfaces
{
    public interface IRepository
    {
        int GetMaxValueBy<E>(Func<E, int> match) where E : class;

        T GetSingle<T>(int id) where T : class;
        T GetSingle<T>(Expression<Func<T, bool>> predicate) where T : class;
        T GetSingle<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class;
        //IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
        IQueryable<T> GetAll<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;

        //IQueryable<T> All { get; }

        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        PaginatedList<T> Paginate<TKey, T>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector) where T : class;
        PaginatedList<T> Paginate<TKey, T>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class;

        void Add<T>(T entity) where T : class;
        void AddRange<T>(IList<T> entities) where T : class;
        void Delete<E>(Func<E, bool> selector) where E : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Save();

    }
}
