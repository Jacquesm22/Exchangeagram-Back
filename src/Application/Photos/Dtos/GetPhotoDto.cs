using System;

namespace ExchangeAGram.Application.Photos.Dtos
{
    public class GetPhotoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public String Path { get; set; }
        public String Extension { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
