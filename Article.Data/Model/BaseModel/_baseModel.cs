using System;
using System.ComponentModel.DataAnnotations;

namespace Article.Data.Model.BaseModel
{
    public class _baseModel 
    {
        public const int maxLengthIP = 20;

        [Key]
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }

        [StringLength(maxLengthIP)]
        public string CreateIpAddress { get; set; }
        [StringLength(maxLengthIP)]
        public string LastModifiedIpAddress { get; set; }

        public _baseModel() { }
    }
}
