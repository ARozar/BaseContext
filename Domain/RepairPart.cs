using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RepairPart
    {
        public int Quantity { get; set; }
        public int RepairId { get; set; }
        public virtual Repair repair { get; set; }
        public int ComponentId { get; set; }
        public virtual Component Component { get; set; }
    }
}
