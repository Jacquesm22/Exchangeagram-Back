using ExchangeAGram.Domain.Common;
using System;

namespace ExchangeAGram.Domain.Entities
{
    public class SharedAlbum : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SharedUserId { get; set; }
        public Guid AlbumId { get; set; }
        public User User { get; set; }
        public Album Album { get; set; }
    }
}
