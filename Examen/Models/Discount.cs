using System;
using System.Collections.Generic;

namespace Examen.Models
{
    public partial class Discount
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public int? Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
