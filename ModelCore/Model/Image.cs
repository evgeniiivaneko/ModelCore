using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCore
{
    [Table("Image")]
    public partial class Image
    {
        [Key]
        public int PK_ImageId { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Picture { get; set; }

        [StringLength(128)]
        public string Description { get; set; }
        public int? FkProduct { get; set; }
        public int? FkReview { get; set; }

        public Product FkProductNavigation { get; set; }
        public Review FkReviewNavigation { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
