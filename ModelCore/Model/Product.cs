using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCore
{
    public partial class Product
    {
        public Product()
        {
            Image = new HashSet<Image>();
            Order = new HashSet<Order>();
            Review = new HashSet<Review>();
        }

        [Key]
        public int PK_ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int FkType { get; set; }
        public int FkBrand { get; set; }
        public int FkImage { get; set; }

        public Brand FkBrandNavigation { get; set; }
        public Image FkImageNavigation { get; set; }
        public Type FkTypeNavigation { get; set; }
        public Conditioner Conditioner { get; set; }
        public ICollection<Image> Image { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
