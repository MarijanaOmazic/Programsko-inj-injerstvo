using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fsr.pring.mvc.projekt.ViewModels
{
    public class PartneriViewModel
    {
        public IEnumerable<Models.Partner> Partneri { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
