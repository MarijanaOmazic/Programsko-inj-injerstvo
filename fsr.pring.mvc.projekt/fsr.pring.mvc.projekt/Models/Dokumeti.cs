using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class Dokumeti
    {
        public Dokumeti()
        {
            Stavke = new HashSet<Stavke>();
        }

        public int Id { get; set; }
        public int? DokumentTipId { get; set; }
        public int? DobavljacId { get; set; }
        public int? KupacId { get; set; }
        public int? LoakcijaId { get; set; }
        public DateTime? Datum { get; set; }
        public string BrojDokumenta { get; set; }

        public Partner Dobavljac { get; set; }
        public DukumentTipovi DokumentTip { get; set; }
        public Partner Kupac { get; set; }
        public Lokacije Loakcija { get; set; }
        public ICollection<Stavke> Stavke { get; set; }
    }
}
