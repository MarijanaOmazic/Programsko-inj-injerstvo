using fsr.pring.mvc.projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fsr.pring.mvc.projekt.Migrations
{
    public class DBInitilize
    {
        public static void Initiliaze(DataContext context)
        {
            context.Database.EnsureCreated();
            DodajTipoveDokumenata(context);
        }

        private static void DodajTipoveDokumenata(DataContext context)
        {
            if (!context.DukumentTipovi.Any())
            {
                var dokomentTipovi = new List<DukumentTipovi>()
                {
                    new DukumentTipovi{ Id = 1, Naziv = "Tip 1" },
                    new DukumentTipovi{ Id = 2, Naziv = "Tip 2" }
                };

                context.DukumentTipovi.AddRange(dokomentTipovi);
                context.SaveChanges();
            }
        }
    }
}
