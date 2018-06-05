using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class DukumentTipovi
    {
        public DukumentTipovi()
        {
            Dokumeti = new HashSet<Dokumeti>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Dokumeti> Dokumeti { get; set; }
    }
}
