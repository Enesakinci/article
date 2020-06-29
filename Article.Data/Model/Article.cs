using Article.Data.Model.BaseModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Article.Data.Model
{
    [Table("db.Article")]
    public class Article : _baseModel
    {
        private const int _valueLength = 50;

        [StringLength(_valueLength)]
        public string Title { get; set; }
        public string  Content { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category{ get; set; }
    }
}
