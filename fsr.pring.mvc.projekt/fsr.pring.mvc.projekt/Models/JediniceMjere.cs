using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class JediniceMjere
    {
        public JediniceMjere()
        {
            Artikli = new HashSet<Artikli>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Artikli> Artikli { get; set; }
    }
}
