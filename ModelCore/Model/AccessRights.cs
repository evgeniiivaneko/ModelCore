using System;
using System.Collections.Generic;

namespace ModelCore
{
    public partial class AccessRights
    {
        public AccessRights()
        {
            User = new HashSet<User>();
        }

        public int PkAccessRightsId { get; set; }
        public string Name { get; set; }

        public ICollection<User> User { get; set; }
    }
}
