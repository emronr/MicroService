using System.Collections.Generic;
using MicroService.Entities;

namespace MicroService.OrderAPI.Models
{
    public class OrderListModel
    {
        public List<Orders> Orders { get; set; } 
    }
}