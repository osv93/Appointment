using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Appointment.API.Data.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetById(string id); 
        Task<T> GetByIdWithDetails(Expression<Func<T, bool>> predicate = null,
                                   Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<bool> EntityExistById(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
