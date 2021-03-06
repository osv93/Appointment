﻿using Appointment.API.Contexts;
using Appointment.API.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Appointment.API.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private Context Context { get; set; }

        public RepositoryBase(Context Context)
        {
            this.Context = Context;
        }

        private IQueryable<T> PrepareQuery(
            IQueryable<T> query,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null
            )
        {
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (take.HasValue)
                query = query.Take(Convert.ToInt32(take));

            return query;
        }

        public async Task Add(T entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public async Task<T> GetById(string citaID)
        {
            return await Context.Set<T>().FindAsync(citaID);
        }

        public async Task<T> GetByIdWithDetails( 
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = Context.Set<T>().AsQueryable();
            query = PrepareQuery(query, predicate, include);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> EntityExistById(Expression<Func<T, bool>> predicate = null)
        {
            return await Context.Set<T>().AnyAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = Context.Set<T>().AsQueryable();
            query = PrepareQuery(query, predicate, include);
            return await query.ToListAsync();
        }

    }
}
