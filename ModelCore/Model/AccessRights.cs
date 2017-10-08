using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCore
{
    public partial class AccessRights
    {
        public AccessRights()
        {
            User = new HashSet<User>();
        }

        [Key]
        public int PK_AccessRightsId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public ICollection<User> User { get; set; }
    }
}
