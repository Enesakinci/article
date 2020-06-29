using Article.Data.ViewModel;
using static Article.Business.Repository.Abstract.IGenericRepository;

namespace Article.Business.Repository.Abstract
{
    public interface IArticleRepository : IGenericRepository<Article.Data.Model.Article>
    {
        bool AddArticle(ViewModelArticle form);
        bool UpdateArticle(ViewModelArticle form);

    }
}
