using Article.Business.Repository.Abstract;
using Article.Data;
using Article.Data.Model;
using Article.Data.ViewModel;
using Microsoft.AspNetCore.Http;

namespace Article.Business.Repository.Concrete.EntityFramework
{
	public class EfArticleRepository : EfGenericRepository<Article.Data.Model.Article>, IArticleRepository
	{
		private IHttpContextAccessor _accessor;
		private Article.Data.Model.Article article;
		public EfArticleRepository(EfArticleDbContext context, IHttpContextAccessor accessor) : base(context)
		{
			article = new Data.Model.Article();
			_accessor = accessor;
		}

		public EfArticleDbContext articleContext
		{
			get { return context as EfArticleDbContext; }
		}
		public bool AddArticle(ViewModelArticle form)
		{
			try
			{
				article.CategoryId = form.CategoryId;
				article.Content = form.Content;
				article.IsActive = true;
				article.IsDeleted = false;
				article.Title = form.Title;
				article.CreateIpAddress= _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
				article.CreatedDateTime = System.DateTime.Now;
				articleContext.Add(article);
				articleContext.SaveChanges();
				return true;

			}
			catch (System.Exception)
			{

				return false;
			}
		}
		public bool UpdateArticle(ViewModelArticle form)
		{
			try
			{
				article.CategoryId = form.CategoryId;
				article.Content = form.Content;
				article.IsActive = true;
				article.IsDeleted = false;
				article.Title = form.Title;
				article.CreateIpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
				article.CreatedDateTime = System.DateTime.Now;
				articleContext.Add(article);
				articleContext.SaveChanges();
				return true;

			}
			catch (System.Exception)
			{

				return false;
			}
		}
	}
}
