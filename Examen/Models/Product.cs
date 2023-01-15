using System;
using System.Collections.Generic;

namespace Examen.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Calories { get; set; }
        public int? StoreId { get; set; }

        public virtual Store Store { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
