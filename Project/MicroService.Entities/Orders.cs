using System;

namespace MicroService.Entities
{
    public class Orders
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string CustomerId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}