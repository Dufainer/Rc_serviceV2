using System;
using System.Collections.Generic;

namespace Rc_serviceV2.Models
{
    public partial class Contratacion
    {
        public int Id { get; set; }
        public int? OfertasIdOfertas { get; set; }
        public int? EstadosId { get; set; }

        public virtual Estado? Estados { get; set; }
        public virtual Oferta? OfertasIdOfertasNavigation { get; set; }
    }
}
