using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCore
{
    [Table("Review")]
    public partial class Review
    {
        public Review()
        {
            Image = new HashSet<Image>();
        }

        [Key]
        public int PK_ReviewId { get; set; }

        [Required]
        [StringLength(1024)]
        public string Message { get; set; }
        public int FkProduct { get; set; }
        public int FkUser { get; set; }

        public Product FkProductNavigation { get; set; }
        public User FkUserNavigation { get; set; }
        public ICollection<Image> Image { get; set; }
    }
}
