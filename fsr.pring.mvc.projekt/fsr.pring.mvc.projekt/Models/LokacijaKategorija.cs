using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class LokacijaKategorija
    {
        public LokacijaKategorija()
        {
            Lokacije = new HashSet<Lokacije>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Kategorizacija { get; set; }

        public ICollection<Lokacije> Lokacije { get; set; }

    }
}
