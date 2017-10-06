using System;
using System.Collections.Generic;

namespace ModelCore
{
    public partial class Review
    {
        public Review()
        {
            Image = new HashSet<Image>();
        }

        public int PkReviewId { get; set; }
        public string Message { get; set; }
        public int FkProduct { get; set; }
        public int FkUser { get; set; }

        public Product FkProductNavigation { get; set; }
        public User FkUserNavigation { get; set; }
        public ICollection<Image> Image { get; set; }
    }
}
