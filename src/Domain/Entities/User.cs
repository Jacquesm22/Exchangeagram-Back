using ExchangeAGram.Domain.Common;
using System;
using System.Collections.Generic;

namespace ExchangeAGram.Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public IList<Photo> Photos { get; private set; } = new List<Photo>();
        public IList<SharedAlbum> SharedAlbums { get; private set; } = new List<SharedAlbum>();
        public IList<SharedPhoto> SharedPhotos { get; private set; } = new List<SharedPhoto>();
    }
}
