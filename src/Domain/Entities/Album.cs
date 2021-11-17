using ExchangeAGram.Domain.Common;
using System;
using System.Collections.Generic;

namespace ExchangeAGram.Domain.Entities
{
    public class Album : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public IList<AlbumPhoto> AlbumPhotos { get; private set; } = new List<AlbumPhoto>();
        public IList<SharedAlbum> SharedAlbums { get; private set; } = new List<SharedAlbum>();
    }
}
