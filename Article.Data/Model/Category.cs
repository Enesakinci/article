using Article.Data.Model.BaseModel;
using System.ComponentModel.DataAnnotations;

namespace Article.Data.Model
{
    public class Category: _baseModel
    {
        private const int _valueLength = 50;

        [StringLength(_valueLength)]
        public string Name { get; set; }
    }
}
