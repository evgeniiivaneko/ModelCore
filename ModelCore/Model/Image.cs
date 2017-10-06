using System;
using System.Collections.Generic;

namespace ModelCore
{
    public partial class Image
    {
        public int PkImageId { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public int? FkProduct { get; set; }
        public int? FkReview { get; set; }

        public Product FkProductNavigation { get; set; }
        public Review FkReviewNavigation { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
