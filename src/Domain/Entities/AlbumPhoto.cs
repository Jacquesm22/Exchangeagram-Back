using ExchangeAGram.Domain.Common;
using System;

namespace ExchangeAGram.Domain.Entities
{
    public class AlbumPhoto : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid PhotoId { get; set; }
        public Guid AlbumId { get; set; }

        public Photo Photo { get; set; }
        public Album Album { get; set; }
    }
}
