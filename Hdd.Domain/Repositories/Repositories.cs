
using Hdd.Domain.Models;
using Hdd.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Hdd.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        protected readonly DbContext Context;

        public Repository(DbContex context)
        {
            Context = context;
        }

        public virtual IQueryable<TEntity> Get(string includeProperties = "")
        {
            IQueryable<TEntity> query = Context;
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual TEntity GetById(object id)
        {
            return Context.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Context.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entity)
        {
            Context.AddRange(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entity)
        {
            Context.RemoveRange(entity);
        }
    }
}



