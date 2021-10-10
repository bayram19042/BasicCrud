using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCrud.Models
{

    [Table("Product")]
    public class Product
    {
       
        public int ProductId { get; set; }
        [MaxLength(50),Required(ErrorMessage ="lütfen alanları doldurun")]
        public string Name { get; set; }
        [MaxLength(50), Required(ErrorMessage ="lütfen alanları doldurun")]
        public string Category { get; set; }
        [Required(ErrorMessage ="lütfen alanları doldurun")]
        public int ProductCount { get; set; }

        
    }
}
