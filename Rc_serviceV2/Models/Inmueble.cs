using System;
using System.Collections.Generic;

namespace Rc_serviceV2.Models
{
    public partial class Inmueble
    {
        public Inmueble()
        {
            Oferta = new HashSet<Oferta>();
        }

        public int IdInmueble { get; set; }
        public string? TipoInmueble { get; set; }
        public string? DetallesInmueble { get; set; }
        public string? UbicacionId { get; set; }
        public string? PropietariosIdPropietario { get; set; }

        public virtual Propietario? PropietariosIdPropietarioNavigation { get; set; }
        public virtual ICollection<Oferta> Oferta { get; set; }
    }
}
