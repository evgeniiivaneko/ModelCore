using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelCore
{
    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int PK_OrderId { get; set; }
        public DateTime Date { get; set; }
        [StringLength(1024)]
        public string Comment { get; set; }
        public int FkUser { get; set; }
        public int FkProduct { get; set; }

        public Product FkProductNavigation { get; set; }
        public User FkUserNavigation { get; set; }
    }
}
