using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCore
{
    [Table("Type")]
    public partial class Type
    {
        public Type()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int PK_TypeId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
