using ExchangeAGram.Domain.Common;
using System;
using System.Collections.Generic;

namespace ExchangeAGram.Domain.Entities
{
    public class Photo : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int SizeBytes { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public User User { get; set; }
        public IList<Meta> Metas { get; private set; } = new List<Meta>();
        public IList<AlbumPhoto> AlbumPhotos { get; private set; } = new List<AlbumPhoto>();
        public IList<SharedPhoto> SharedPhotos { get; private set; } = new List<SharedPhoto>();
    }
}
