using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_CodeFirst.Models.DomainModels.EF.DTO
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int CategoryRef { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public byte[] Photo { get; set; }
        public decimal Price { get { return UnitPrice * Quantity; } }

        public Category Category { get; set; }
    }
}