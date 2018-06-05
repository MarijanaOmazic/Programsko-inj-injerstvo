using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class Artikli
    {
        public Artikli()
        {
            StavkeArtikl = new HashSet<Stavke>();
            StavkeSastavniceArtikl = new HashSet<StavkeSastavnice>();
            StavkeZivotinja = new HashSet<Stavke>();
        }

        public int Id { get; set; }
        public int? ArtikliTipId { get; set; }
        public int? ArtikliGrupaId { get; set; }
        public string Naziv { get; set; }
        public decimal? Cijena { get; set; }
        public int? JedinicaMjereId { get; set; }
        public string Oznaka { get; set; }
        public bool? Status { get; set; }

        public ArtikliGrupe ArtikliGrupa { get; set; }
        public ArtikliTip ArtikliTip { get; set; }
        public JediniceMjere JedinicaMjere { get; set; }
        public StavkeSastavnice StavkeSastavniceSastavnica { get; set; }
        public ICollection<Stavke> StavkeArtikl { get; set; }
        public ICollection<StavkeSastavnice> StavkeSastavniceArtikl { get; set; }
        public ICollection<Stavke> StavkeZivotinja { get; set; }
    }
}
