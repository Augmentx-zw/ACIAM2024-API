using System.ComponentModel.DataAnnotations;

namespace Ark.Gateway.Domain.Models
{
    public class Committee
    {
        [Key]
        public Guid CommitteeId { get; set; }
        public string? Prefix { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public string? Image { get; set; }
        public string? Institution { get; set; }
        public string? Type { get; set; }
        public string? SubType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpDatedOn { get; set; }
    }

}
