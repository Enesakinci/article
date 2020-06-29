using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static Article.Business.Repository.Abstract.IGenericRepository;

namespace Article.Business.Repository.Concrete.EntityFramework
{

    public abstract class EfGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        internal DbSet<TEntity> dbSet;
        protected readonly string lang;

        public EfGenericRepository(DbContext ctx)
        {
            context = ctx;
            this.dbSet = context.Set<TEntity>();
            lang = "TR";
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> AllDataList(Expression<Func<TEntity, bool>> _expression = null, Expression<Func<TEntity, object>> _orderBy = null, int take = 0, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (take == 0)
                return query.Where(_expression).OrderByDescending(_orderBy);

            return query.Where(_expression).OrderByDescending(_orderBy).Take(take);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public TEntity GetDataById(Expression<Func<TEntity, bool>> _expression = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                foreach (var includeProperty in includeProperties.Split
                  (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return query.Where(_expression).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            return null;
        }
    }
}

