using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi_CodeFirst.Models.DomainModels.EF.MetaData
{
    [MetadataType(typeof(DTO.Product))]
    public partial class Product
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        [ForeignKey("Category")]
        [Column(Order = 1)]
        public int CategoryRef { get; set; }

        [Required]
        [MaxLength(50), MinLength(3)]
        [StringLength(50, MinimumLength = 3)]
        [Column("Title", Order = 2)]
        public string Name { get; set; }

        [Required]
        [Column(Order = 3)]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column("UnitsInStock", Order = 4)]
        public int Quantity { get; set; }

        [Required]
        [Column(Order = 5)]
        public decimal Discount { get; set; }

        [Column(Order = 6)]
        public byte[] Photo { get; set; }

        [NotMapped]
        public decimal Price { get { return UnitPrice * Quantity; } }

        public Category Category { get; set; }
    }
}