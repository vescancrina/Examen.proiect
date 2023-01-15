using System;
using System.Collections.Generic;

namespace Examen.Models
{
    public partial class EmployeeLogin
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string EmpoyeeName { get; set; }
    }
}
