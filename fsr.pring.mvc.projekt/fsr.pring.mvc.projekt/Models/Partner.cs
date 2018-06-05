using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class Partner
    {
        public Partner()
        {
            DokumetiDobavljac = new HashSet<Dokumeti>();
            DokumetiKupac = new HashSet<Dokumeti>();
            Lokacije = new HashSet<Lokacije>();
        }

        public int Id { get; set; }
        public int? PartnerTipoviId { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Mobitel { get; set; }

        public PartnerTip PartnerTipovi { get; set; }
        public ICollection<Dokumeti> DokumetiDobavljac { get; set; }
        public ICollection<Dokumeti> DokumetiKupac { get; set; }
        public ICollection<Lokacije> Lokacije { get; set; }
    }
}
