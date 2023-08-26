using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models
{
    public class Staff
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<StaffEmoloyee> StaffEmoloyees { get; set; }

    }
}
