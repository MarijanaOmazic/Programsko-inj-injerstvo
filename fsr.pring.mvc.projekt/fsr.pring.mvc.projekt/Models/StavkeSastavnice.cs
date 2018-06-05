using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class StavkeSastavnice
    {
        public int SastavnicaId { get; set; }
        public int? ArtiklId { get; set; }
        public double? Kolicina { get; set; }

        public Artikli Artikl { get; set; }
        public Artikli Sastavnica { get; set; }
    }
}
