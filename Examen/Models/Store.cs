using System;
using System.Collections.Generic;

namespace Examen.Models
{
    public partial class Store
    {
        public Store()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string FullAddress { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
