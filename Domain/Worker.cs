using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Repair> Repairs { get; set; }
    }
}
