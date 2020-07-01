using System.ComponentModel.DataAnnotations;

namespace Article.Data.ViewModel.Dtos
{
    public class ArticleUpdateDto
    {
        private const int _valueLength = 50;

        public int Id { get; set; }
        [StringLength(_valueLength)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}
