using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCore
{
    public partial class Brand
    {
        public Brand()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int PK_BrandId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        [Required]
        [StringLength(512)]
        public string Contact { get; set; }

        [Required]
        [StringLength(40)]
        public string Country { get; set; }

        public int FK_Image { get; set; }

        public ICollection<Product> Product { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, Name: {1}{2}Description: {3}{2}Contact:{4}{2}Country: {5}", PK_BrandId, Name, Environment.NewLine,
                Description, Contact, Country);
            //return base.ToString();
        }
    }
}
