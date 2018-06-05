using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class Stavke
    {
        public int Id { get; set; }
        public int? DokumentId { get; set; }
        public int? ArtiklId { get; set; }
        public int? ZivotinjaId { get; set; }
        public double? Kolicina { get; set; }
        public decimal? Cijena { get; set; }

        public Artikli Artikl { get; set; }
        public Dokumeti Dokument { get; set; }
        public Artikli Zivotinja { get; set; }
    }
}
