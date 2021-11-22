using System;

namespace ExchangeAGram.Application.Photos.Dtos
{
    public class GetPhotosDto
    {
        public Guid Id { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
