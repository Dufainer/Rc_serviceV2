using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rc_serviceV2.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            Oferta = new HashSet<Oferta>();
            PrestadoresDeServicios = new HashSet<PrestadoresDeServicio>();
        }
        [Display(Name ="Id")]
        public int IdServicio { get; set; }
        [Display(Name = "Tipo de servicio")]
        public string? TipoServicio { get; set; }
        [Display(Name = "Detalles del servicio")]
        public string? DetallesServicio { get; set; }
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        public virtual ICollection<Oferta> Oferta { get; set; }
        public virtual ICollection<PrestadoresDeServicio> PrestadoresDeServicios { get; set; }
    }
}
