using System;
using System.Collections.Generic;

namespace Rc_serviceV2.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Contratacions = new HashSet<Contratacion>();
        }

        public int Id { get; set; }
        public string? TipoEstado { get; set; }

        public virtual ICollection<Contratacion> Contratacions { get; set; }
    }
}
