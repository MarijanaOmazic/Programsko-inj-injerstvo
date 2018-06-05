using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class LokacijaTip
    {
        public LokacijaTip()
        {
            Lokacije = new HashSet<Lokacije>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        
        public ICollection<Lokacije> Lokacije { get; set; }
    }
}
