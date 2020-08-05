using System;
using System.Collections.Generic;

namespace sepetApp.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public string Products { get; set; }
        public int? UserId { get; set; }
    }
}
