using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models
{
    public class StaffEmoloyee
    {
        public Guid Id { get; set; }

        public Guid StaffId { get; set; }
        public Guid EmployeeId { get; set; }

        public Staff Staff { get; set; }
        public Employee Employee { get; set; }
    }
}
