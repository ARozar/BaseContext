using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new BaseContextInitializer());

            using(var db = new BaseContext())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var query = db.Repairs
                    .Include(r=>r.Account)
                    .Include(r=>r.Team)
                    .Include(r=>r.PartsUsed.Select(p=>p.Component))
                    .ToList();
            }
        }
    }
}
