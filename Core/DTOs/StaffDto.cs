using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.DTOs
{
    public class StaffDto
    {
        public Guid UniqueId { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public Guid PositionId { get; set; }
        public Guid UserId { get; set; }
    }

}
