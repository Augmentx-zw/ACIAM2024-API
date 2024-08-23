﻿using System.ComponentModel.DataAnnotations;

namespace Ark.Gateway.Domain.Models
{
    public class Abstract
    {
        [Key]
        public Guid AbstractId { get; set; }
        public string? Prefix { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public string? Designation { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Institution { get; set; }
        public string? ConferenceName { get; set; }
        public string? Register { get; set; }
        public string? JournalPublication { get; set; }
        public string? Comments { get; set; }
        public string? AbstractName { get; set; }
        public string? AbstractTitle { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpDatedOn { get; set; }
    }
}
