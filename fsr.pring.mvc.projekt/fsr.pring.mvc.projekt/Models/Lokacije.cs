using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class Lokacije
    {
        public Lokacije()
        {
            Dokumeti = new HashSet<Dokumeti>();
        }

        public int Id { get; set; }
        public int? LokacijaTipId { get; set; }
        public int? PartnerId { get; set; }
        public int? LokacijaKategorijaId { get; set; }
        public int Koordinate { get; set; }
        public int GPS { get; set; }

        public LokacijaTip LokacijaTip { get; set; }
        public LokacijaKategorija LokacijaKategorija{ get; set; }
        public Partner Partner { get; set; }
        public ICollection<Dokumeti> Dokumeti { get; set; }
    }
}
