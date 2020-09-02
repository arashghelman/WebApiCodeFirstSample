using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi_CodeFirst.Models.DomainModels.EF.MetaData
{

    [MetadataType(typeof(DTO.Category))]
    public partial class Category
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        [Required]
        [Column("Title", Order = 1)]
        [MaxLength(20), MinLength(3)]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }


        public ICollection<DTO.Product> Products { get; set; }
    }
}