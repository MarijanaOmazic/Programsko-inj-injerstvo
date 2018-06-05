using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class ArtikliTip
    {
        public ArtikliTip()
        {
            Artikli = new HashSet<Artikli>();
            ArtikliGrupe = new HashSet<ArtikliGrupe>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Artikli> Artikli { get; set; }
        public ICollection<ArtikliGrupe> ArtikliGrupe { get; set; }
    }
}
