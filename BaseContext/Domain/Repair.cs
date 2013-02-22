using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Repair
    {
        static decimal LabourCharge = 40M;

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Completed { get; set; }
        public virtual List<Component> PartsUsed { get; set; }
        public int HoursOfLabour { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal? TotalCost
        {
            get
            {   //if repair is completed--
                if (this.Completed)
                {   //calculate total cost of components used
                    decimal price = (PartsUsed != null) ? PartsUsed.Select(p => p.Price).Sum() : 0M;
                    //if the repair took < 1hr cost is £10
                    price += (HoursOfLabour > 0) ? HoursOfLabour * LabourCharge : 10;

                    return price;
                }
                else
                {
                    return null;
                }
            }
        }
        public List<Worker> Team { get; set; }
    }
}
