using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Article.Business.Repository.Abstract
{
    public interface IGenericRepository
    {
        public interface IGenericRepository<TEntity> where TEntity : class
        {
            /// <summary>
            /// return get data
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            TEntity Get(int id);

            /// <summary>
            /// return get all data
            /// </summary>
            /// <returns></returns>
            IQueryable<TEntity> GetAll();

            /// <summary>
            /// return Tentity find model
            /// </summary>
            /// <param name="predicate"></param>
            /// <returns></returns>
            IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

            /// <summary>
            /// Add data
            /// </summary>
            /// <param name="entity"></param>
            void Add(TEntity entity);

            /// <summary>
            /// Delete data
            /// </summary>
            /// <param name="entity"></param>
            void Delete(TEntity entity);

            /// <summary>
            /// Edit data
            /// </summary>
            /// <param name="entity"></param>
            void Edit(TEntity entity);

            /// <summary>
            /// Save context
            /// </summary>
            void Save();  //Savechanges Unit of Work

            IQueryable<TEntity> AllDataList(Expression<Func<TEntity, bool>> _expression = null, Expression<Func<TEntity, object>> _orderBy = null, int take = 10, string includeProperties = "");

            /// <summary>
            /// GetDataForById
            /// </summary>
            /// <param name="_expression">table primerykey Id parameter</param>
            /// <returns></returns>
            TEntity GetDataById(Expression<Func<TEntity, bool>> _expression = null, string includeProperties = "");
        }
    }
}
