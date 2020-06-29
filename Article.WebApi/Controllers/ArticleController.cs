using Article.Business.Repository.Abstract;
using Article.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Article.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly IUnitOfWork _uow;
        public ArticleController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var retval = _uow.Article.GetAll();
                return Json(retval);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Article.Data.Model.Article article = _uow.Article.Get(id);
                _uow.Article.Delete(article);
                _uow.SaveChanges();
                 return Json("Article is deleted");
            }
            catch (Exception e)
            {
                return Json("This is a problem: " + e);
            }
        }
        [HttpPost("AddArticle")]
        public async Task<IActionResult> AddArticle([FromBody] ViewModelArticle form)
        {
            try
            {
                bool retval = _uow.Article.AddArticle(form);
                if (retval == true)
                    return Json("Article is added");
                return Json("Article is not added");
            }
            catch (Exception e)
            {
                return Json("This is a problem: " + e);
            }
        }
        [HttpPost("UpdateArticle")]
        public async Task<IActionResult> UpdateArticle([FromBody] ViewModelArticle form)
        {
            try
            {
                bool retval = _uow.Article.AddArticle(form);
                if (retval == true)
                    return Json("Article is added");
                return Json("Article is not added");
            }
            catch (Exception e)
            {
                return Json("This is a problem: " + e);
            }
        }
    }
}