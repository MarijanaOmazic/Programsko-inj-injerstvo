using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class ArtikliGrupe
    {
        public ArtikliGrupe()
        {
            Artikli = new HashSet<Artikli>();
        }

        public int Id { get; set; }
        public int? ArtikliTipId { get; set; }
        public string Naziv { get; set; }

        public ArtikliTip ArtikliTip { get; set; }
        public ICollection<Artikli> Artikli { get; set; }
    }
}
