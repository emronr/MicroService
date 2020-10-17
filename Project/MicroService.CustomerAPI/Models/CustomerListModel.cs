using System.Collections.Generic;
using MicroService.Entities;

namespace MicroService.CustomerAPI.Models
{
    public class CustomerListModel
    {
        public List<Customers> Customers { get; set; }
    }
}