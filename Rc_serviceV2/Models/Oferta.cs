using System;
using System.Collections.Generic;

namespace Rc_serviceV2.Models
{
    public partial class Oferta
    {
        public Oferta()
        {
            Contratacions = new HashSet<Contratacion>();
        }

        public int IdOfertas { get; set; }
        public int? InmueblesIdInmueble { get; set; }
        public int? ServiciosIdServicio { get; set; }

        public virtual Inmueble? InmueblesIdInmuebleNavigation { get; set; }
        public virtual Servicio? ServiciosIdServicioNavigation { get; set; }
        public virtual ICollection<Contratacion> Contratacions { get; set; }
    }
}
