using ExchangeAGram.Domain.Common;
using System;

namespace ExchangeAGram.Domain.Entities
{
    public class SharedPhoto : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid PhotoId { get; set; }
        public Guid UserId { get; set; }
        public Guid SharedUserId { get; set; }
        public bool AllowMetaUpdate { get; set; }
        public bool AllowDelete { get; set; }
        public Photo Photo { get; set; }
        public User User { get; set; }
        public User SharedUser { get; set; }
    }
}
