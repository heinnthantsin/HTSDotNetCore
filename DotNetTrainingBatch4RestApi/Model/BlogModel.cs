using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTrainingBatch4RestApi.Model
{
    [Table("tbl_blog")]
    public class BlogModel
    {
        [Key]
        public int BlogId { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogContent { get; set; }
    }
}
