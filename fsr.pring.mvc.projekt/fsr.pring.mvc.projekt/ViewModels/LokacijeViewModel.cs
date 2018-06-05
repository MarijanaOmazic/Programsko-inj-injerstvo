using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fsr.pring.mvc.projekt.ViewModels
{
    public class LokacijeViewModel
    {
        public IEnumerable<Models.Lokacije> Lokacijes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
