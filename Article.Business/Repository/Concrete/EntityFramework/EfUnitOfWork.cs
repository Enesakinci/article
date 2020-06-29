using Article.Business.Repository.Abstract;
using Article.Data;
using Microsoft.AspNetCore.Http;
using System;

namespace Article.Business.Repository.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly EfArticleDbContext dbContext;
        private IHttpContextAccessor accessor;
        public EfUnitOfWork(EfArticleDbContext _dbContext, IHttpContextAccessor _accessor)
        {
            dbContext = _dbContext ?? throw new ArgumentException("dbContext can cot ne null");
            accessor = _accessor;


        }
        #region Article

        private IArticleRepository _articleRepository;

        public IArticleRepository Article
        {
            get
            {
                return _articleRepository ?? (_articleRepository = new EfArticleRepository(dbContext, accessor));
            }
        }

        #endregion

        public void SaveChanges()
        {
            try
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        dbContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        //throw;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO:Logging
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
