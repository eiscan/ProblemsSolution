using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Dtos
{
    public class ReceiptRequestDto
    {
        public string? Locale { get; set; }
        public string Description { get; set; }
        public BoundingPolyDto BoundingPoly { get; set; }
    }
}
