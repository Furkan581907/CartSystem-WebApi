using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sepetApp.Models.Entities
{
    public class CartDetail
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}
