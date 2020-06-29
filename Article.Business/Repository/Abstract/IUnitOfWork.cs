using System;

namespace Article.Business.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Article { get; }

        void SaveChanges();
    }
}
