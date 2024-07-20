using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTixx.Core.DTOs
{
    public class PositionDto
    {
        public Guid Id { get; set; }
        public string PositionName { get; set; }
        public string PositionDescription { get; set; }
        public string Shift { get; set; }
    }

}
