using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_CodeFirst.Models.DomainModels.EF.DTO
{
    public class Category
    {

        public Category()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}