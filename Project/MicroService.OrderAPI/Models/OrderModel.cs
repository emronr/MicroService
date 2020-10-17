using System;

namespace MicroService.OrderAPI.Models
{
    public class OrderModel
    {
        
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string CustomerId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}