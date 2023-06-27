using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rc_serviceV2.Models
{
    public partial class Propietario
    {
        public Propietario()
        {
            Inmuebles = new HashSet<Inmueble>();
        }

        public string IdPropietario { get; set; } = null!;
        public string? NamePropietario { get; set; }
        public string? LastnamePropietario { get; set; }
        public string? Celular { get; set; }

        [EmailAddress(ErrorMessage = "Debe ingresar un Email valido")]
        public string? Email { get; set; }

        public string? UbicacionId { get; set; }

        public virtual ICollection<Inmueble> Inmuebles { get; set; }
    }
}