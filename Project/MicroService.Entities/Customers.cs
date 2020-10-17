using System;

namespace MicroService.Entities
{
    public class Customers
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
    }
}
