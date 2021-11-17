using ExchangeAGram.Domain.Common;
using System;

namespace ExchangeAGram.Domain.Entities
{
    public class Meta : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid PhotoId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Tags { get; set; }
        public Photo Photo { get; set; }
    }
}
