using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Model.DataBaseModel
{
    public class CanalModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Token { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Estado { get; set; }
    }
}
