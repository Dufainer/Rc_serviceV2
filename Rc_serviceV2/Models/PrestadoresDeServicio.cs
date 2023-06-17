using System;
using System.Collections.Generic;

namespace Rc_serviceV2.Models
{
    public partial class PrestadoresDeServicio
    {
        public string IdPrestador { get; set; } = null!;
        public string? NamePrestador { get; set; }
        public string? LastnamePrestador { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public string? UbicacionId { get; set; }
        public int? ServiciosIdServicio { get; set; }

        public virtual Servicio? ServiciosIdServicioNavigation { get; set; }
    }
}
