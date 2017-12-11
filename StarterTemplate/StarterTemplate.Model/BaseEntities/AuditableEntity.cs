using System;

namespace StarterTemplate.Model
{
    public class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        public DateTime CreatedDateTime { get; set; }

        public long CreatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public long UpdatedBy { get; set; }
    }
}
