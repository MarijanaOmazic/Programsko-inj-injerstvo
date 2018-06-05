using System;
using System.Collections.Generic;

namespace fsr.pring.mvc.projekt.Models
{
    public partial class PartnerTip
    {
        public PartnerTip()
        {
            Partner = new HashSet<Partner>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Partner> Partner { get; set; }
    }
}
