using System.ComponentModel.DataAnnotations;

namespace Article.Data.ViewModel
{
    public class ViewModelArticle
    {
        private const int _valueLength = 50;

        [StringLength(_valueLength)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}
