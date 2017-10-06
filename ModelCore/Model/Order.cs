using System;
using System.Collections.Generic;

namespace ModelCore
{
    public partial class Order
    {
        public int PkOrderId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int FkUser { get; set; }
        public int FkProduct { get; set; }

        public Product FkProductNavigation { get; set; }
        public User FkUserNavigation { get; set; }
    }
}
