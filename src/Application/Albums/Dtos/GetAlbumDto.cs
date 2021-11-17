using System;

namespace ExchangeAGram.Application.Albums.Dtos
{
    public class GetAlbumDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
