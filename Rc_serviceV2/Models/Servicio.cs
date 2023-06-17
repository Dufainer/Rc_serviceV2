using System;
using System.Collections.Generic;

namespace Rc_serviceV2.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Oferta = new HashSet<Oferta>();
            PrestadoresDeServicios = new HashSet<PrestadoresDeServicio>();
        }

        public int IdServicio { get; set; }
        public string? TipoServicio { get; set; }
        public string? DetallesServicio { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Oferta> Oferta { get; set; }
        public virtual ICollection<PrestadoresDeServicio> PrestadoresDeServicios { get; set; }
    }
}
