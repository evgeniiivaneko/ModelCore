using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCore
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
            Review = new HashSet<Review>();
        }

        [Key]
        public int PK_UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(128)]
        public string Address { get; set; }

        [Required]
        [StringLength(12)]
        public string Number { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public int? FkAccessRights { get; set; }
        public int FkImage { get; set; }

        public AccessRights FkAccessRightsNavigation { get; set; }
        public Image FkImageNavigation { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
