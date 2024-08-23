using System.ComponentModel.DataAnnotations;

namespace Ark.Gateway.Domain.Models
{
    public class Article
    {
        [Key]
        public Guid ArticleId { get; set; }
        public string? Title { get; set; }
        public string? YoutubeId { get; set; }
        public string? Image { get; set; }
        public string? Story { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpDatedOn { get; set; }
    }

}
