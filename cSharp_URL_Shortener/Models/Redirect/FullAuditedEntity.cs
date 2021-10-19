using System;
using System.ComponentModel.DataAnnotations;

namespace cSharp_URL_Shortener.Models.Redirect
{
    public class FullAuditedEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

        // Soft Delete
        public bool? IsDeleted { get; set; }

        public Guid? DeleteUserId { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}